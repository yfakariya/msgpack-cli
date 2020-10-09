// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

using System;
using System.Buffers;
using System.Buffers.Text;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using MsgPack.Internal;

namespace MsgPack.Json
{
	public partial class JsonDecoder
	{
		/// <inheritdoc />
		[MethodImpl(MethodImplOptionsShim.AggressiveInlining)]
		public sealed override int GetRawString(ref SequenceReader<byte> source, Span<byte> buffer, out int requestHint, CancellationToken cancellationToken = default)
		{
			var position = source.Consumed;
			if (!this.GetRawStringCore(ref source, out var rawStringSequence, out requestHint, cancellationToken))
			{
				// Int32.MaxValue * -1 -> Overflow, so this value is suitable to "undefined value".
				return Int32.MinValue;
			}

			if (rawStringSequence.Length > this.Options.MaxBinaryLengthInBytes)
			{
				Throw.BinaryLengthExceeded(position, rawStringSequence.Length, this.Options.MaxBinaryLengthInBytes);
			}

			if (buffer.Length < rawStringSequence.Length)
			{
				return -((int)rawStringSequence.Length);
			}

			rawStringSequence.CopyTo(buffer);
			return (int)rawStringSequence.Length;
		}

		private bool GetRawStringCore(ref SequenceReader<byte> source, out ReadOnlySequence<byte> rawString, out int requestHint, CancellationToken cancellationToken = default)
		{
			this.ReadTrivia(ref source);
			var startOffset = source.Consumed;

			var quotation = this.ReadStringStart(ref source, out requestHint);
			if (requestHint != 0)
			{
				rawString = default;
				return false;
			}

			if (!source.TryReadTo(out ReadOnlySequence<byte> sequence, quotation, (byte)'\\', advancePastDelimiter: false))
			{
				// EoF
				requestHint = 1;
				rawString = default;
				source.Rewind(source.Consumed - startOffset);
				return false;
			}

			rawString = sequence;
			source.Advance(1); // skip end quote
			return true;
		}

		private byte ReadStringStart(ref SequenceReader<byte> source, out int requestHint)
		{
			if (source.End)
			{
				requestHint = 2;
				return default;
			}

			requestHint = 0;

			if (source.IsNext((byte)'"', advancePast: false))
			{
				source.Advance(1);
				return (byte)'"';
			}
			else
			{
				if ((this.Options.ParseOptions & JsonParseOptions.AllowSingleQuotationString) != 0)
				{
					// ['"]
					if (source.IsNext((byte)'\'', advancePast: false))
					{
						source.Advance(1);
						return (byte)'\'';
					}
					else
					{
						JsonThrow.IsNotStringStart(source.Consumed, JsonStringTokens.AnyQuotations);
						// never
						return default;
					}
				}
				else
				{
					JsonThrow.IsNotStringStart(source.Consumed, JsonStringTokens.DoubleQuotation);
					// never
					return default;
				}
			}
		}

		private static void DecodeSpetialEscapeSequence(ref SequenceReader<byte> source, StringBuilderBufferWriter result)
		{
			source.TryPeek(out var escaped);
			char unescaped;
			switch (escaped)
			{
				case (byte)'b':
				{
					unescaped = '\b';
					break;
				}
				case (byte)'t':
				{
					unescaped = '\t';
					break;
				}
				case (byte)'f':
				{
					unescaped = '\f';
					break;
				}
				case (byte)'r':
				{
					unescaped = '\r';
					break;
				}
				case (byte)'n':
				{
					unescaped = '\n';
					break;
				}
				case (byte)'"':
				{
					unescaped = '"';
					break;
				}
				case (byte)'\\':
				{
					unescaped = '\\';
					break;
				}
				case (byte)'/':
				{
					unescaped = '/';
					break;
				}
				default:
				{
					JsonThrow.InvalidEscapeSequence(source.Consumed - 1, escaped);
					// never
					unescaped = default;
					break;
				}
			}

			result.AppendUtf16CodePoint(unescaped);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void DecodeUnicodeEscapceSequence(ref SequenceReader<byte> source, StringBuilderBufferWriter result, out int requestHint)
		{
			Span<byte> buffer = stackalloc byte[4];
			if (!source.TryCopyTo(buffer))
			{
				requestHint = buffer.Length - (int)source.Remaining;
				return;
			}

			if (!Utf8Parser.TryParse(buffer, out int codePointOrHighSurrogate, out var consumed, standardFormat: 'X'))
			{
				JsonThrow.InvalidUnicodeEscapeSequence(source.Consumed - 2, buffer);
			}

			Debug.Assert(consumed == 4, $"consumed ({consumed}) == 4 for '{BitConverter.ToString(buffer.ToArray())}'");

			var positionOf1stSurrogate = source.Consumed - 2;
			if (Unicode.IsLowSurrogate(codePointOrHighSurrogate))
			{
				// 1st surrogte must be high surrogate.
				JsonThrow.OrphanSurrogate(positionOf1stSurrogate, codePointOrHighSurrogate);
			}

			source.Advance(consumed);
			result.AppendUtf16CodePoint(codePointOrHighSurrogate);

			if (Unicode.IsHighSurrogate(codePointOrHighSurrogate))
			{
				if (source.Remaining < 7)
				{
					requestHint = 7 - (int)source.Remaining;
					return;
				}

				// Search lower surrogate
				if (!source.IsNext((byte)'\\', advancePast: true))
				{
					// No paired low surrogate.
					JsonThrow.OrphanSurrogate(positionOf1stSurrogate, codePointOrHighSurrogate);
				}

				if (!source.IsNext((byte)'u', advancePast: true))
				{
					// No paired low surrogate.
					JsonThrow.OrphanSurrogate(positionOf1stSurrogate, codePointOrHighSurrogate);
				}

				if (!source.TryCopyTo(buffer))
				{
					requestHint = buffer.Length - (int)source.Remaining;
					return;
				}

				source.Advance(4);

				if (!Utf8Parser.TryParse(buffer, out int shouldBeLowSurrogate, out consumed, standardFormat: 'X'))
				{
					JsonThrow.InvalidUnicodeEscapeSequence(source.Consumed, buffer);
				}

				if (!Unicode.IsLowSurrogate(shouldBeLowSurrogate))
				{
					// No paired low surrogate.
					JsonThrow.OrphanSurrogate(positionOf1stSurrogate, codePointOrHighSurrogate);
				}

				Debug.Assert(consumed == 4, $"consumed ({consumed}) == 4 for '{BitConverter.ToString(buffer.ToArray())}'");

				source.Advance(consumed);
				result.AppendUtf16CodePoint(shouldBeLowSurrogate);
			}

			requestHint = 0;
		}
	}
}
