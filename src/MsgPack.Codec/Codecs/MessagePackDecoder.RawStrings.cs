// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache 2 license.
// See the LICENSE in the project root for more information.

using System;
using System.Buffers;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using MsgPack.Internal;

namespace MsgPack.Codecs
{
	public partial class MessagePackDecoder
	{
		/// <inheritdoc />
		[MethodImpl(MethodImplOptionsShim.AggressiveInlining)]
		public sealed override int GetRawString(ref SequenceReader<byte> source, Span<byte> buffer, out int requestHint, CancellationToken cancellationToken = default)
		{
			var subReader = source;

			var length = this.GetRawStringLength(ref subReader, out var headerLength, out requestHint, cancellationToken);
			if (requestHint != 0)
			{
				// Int32.MaxValue * -1 -> Overflow, so this value is suitable to "undefined value".
				return Int32.MaxValue;
			}

			if (length > this.Options.MaxBinaryLengthInBytes)
			{
				Throw.BinaryLengthExceeded(source.Consumed, length, this.Options.MaxBinaryLengthInBytes);
			}

			if (length > buffer.Length)
			{
				return -length;
			}

			if (source.UnreadSpan.Length < length)
			{
				source.UnreadSpan.Slice(0, length).CopyTo(buffer);
				source.Advance(length);
				requestHint = 0;
				return length;
			}

			if (source.Remaining < length)
			{
				requestHint = length - (int)source.Remaining;
				// Int32.MaxValue * -1 -> Overflow, so this value is suitable to "undefined value".
				return Int32.MaxValue;
			}

			return this.GetRawStringMultiSegment(ref source, buffer, out requestHint, length + headerLength, cancellationToken);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private int GetRawStringMultiSegment(ref SequenceReader<byte> source, Span<byte> buffer, out int requestHint, int totalLength, CancellationToken cancellationToken)
		{
			var copyLength = Math.Min(this.Options.CancellationSupportThreshold, totalLength);
			var bufferSpan = buffer;
			var remaining = totalLength;

			while (remaining > 0)
			{
				var destination = bufferSpan.Slice(0, Math.Min(copyLength, remaining));
				var shouldTrue = source.TryCopyTo(destination);
				Debug.Assert(shouldTrue, "SequenceReader<byte>.Remaining lied.");

				remaining -= destination.Length;
				bufferSpan = bufferSpan.Slice(destination.Length);
				source.Advance(copyLength);

				cancellationToken.ThrowIfCancellationRequested();
			}

			requestHint = 0;
			return totalLength;
		}

		[MethodImpl(MethodImplOptionsShim.AggressiveInlining)]
		private int GetRawStringLength(ref SequenceReader<byte> source, out int consumed, out int requestHint, CancellationToken cancellationToken)
		{
			var length = this.DecodeStringHeader(ref source, out var header, out requestHint, out consumed);
			if (requestHint != 0)
			{
				return default;
			}

			if (length > Int32.MaxValue)
			{
				MessagePackThrow.TooLargeByteLength(header, source.Consumed - consumed, length);
			}

			return (int)length;
		}

		private long DecodeStringHeader(ref SequenceReader<byte> source, out byte header, out int requestHint, out int consumed)
		{
			if (!source.TryPeek(out header))
			{
				requestHint = 1;
				consumed = 0;
				return 0;
			}

			if (header >= MessagePackCode.MinimumFixedRaw && header <= MessagePackCode.MaximumFixedRaw)
			{
				requestHint = 0;
				consumed = 1;
				source.Advance(1);
				return header - MessagePackCode.MinimumFixedRaw;
			}

			long length;
			switch (header)
			{
				case MessagePackCode.Str8:
				{
					length = ReadByte(ref source, offset: 1, out requestHint);
					consumed = 2;
					break;
				}
				case MessagePackCode.Str16:
				{
					length = ReadValue<ushort>(ref source, offset: 1, out requestHint);
					consumed = 3;
					break;
				}
				case MessagePackCode.Str32:
				{
					length = ReadValue<uint>(ref source, offset: 1, out requestHint);
					consumed = 5;
					break;
				}
				default:
				{
					MessagePackThrow.IsNotUtf8String(header, source.Consumed);
					// never
					requestHint = default;
					consumed = default;
					return 0;
				}
			}

			source.Advance(consumed);
			return requestHint == 0 ? length : 0;
		}

		private int DecodeBinaryHeader(ref SequenceReader<byte> source, out int requestHint, out int consumed)
		{
			if (!source.TryPeek(out var header))
			{
				requestHint = 1;
				consumed = 0;
				return 0;
			}

			if (header >= MessagePackCode.MinimumFixedRaw && header <= MessagePackCode.MaximumFixedRaw)
			{
				requestHint = 0;
				consumed = 1;
				return header - MessagePackCode.MinimumFixedRaw;
			}

			int length;
			switch (header)
			{
				case MessagePackCode.Str8:
				case MessagePackCode.Bin8:
				{
					length = ReadByte(ref source, offset: 1, out requestHint);
					consumed = 2;
					break;
				}
				case MessagePackCode.Str16:
				case MessagePackCode.Bin16:
				{
					length = ReadValue<ushort>(ref source, offset: 1, out requestHint);
					consumed = 3;
					break;
				}
				case MessagePackCode.Str32:
				case MessagePackCode.Bin32:
				{
					length = ReadValue<int>(ref source, offset: 1, out requestHint);
					if (length < 0)
					{
						MessagePackThrow.TooLargeByteLength(header, source.Consumed - 5, unchecked((uint)length));
					}

					consumed = 5;
					break;
				}
				default:
				{
					MessagePackThrow.IsNotUtf8String(header, source.Consumed);
					// never
					requestHint = default;
					consumed = default;
					return 0;
				}
			}

			return requestHint == 0 ? length : 0;
		}
	}
}
