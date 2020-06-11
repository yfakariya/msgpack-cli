// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

// <auto-generated /> 
// This file is generated from acompanying .tt file.
// DO NOT edit this file directly, edit .tt file instead.

using System;
using System.Buffers;
using System.Runtime.CompilerServices;
using MsgPack.Internal;

namespace MsgPack.Json
{
	partial class JsonDecoder
	{
		/// <inheritdoc />
		[MethodImpl(MethodImplOptionsShim.AggressiveInlining)]
		public sealed override Byte? DecodeNullableByte(in SequenceReader<byte> source, out int requestHint)
		{
			this.ReadTrivia(source, out _);
			if (this.TryReadNull(source))
			{
				requestHint = 0;
				return null;
			}

			return this.DecodeByteCore(source, out requestHint);
		}

		/// <inheritdoc />
		[MethodImpl(MethodImplOptionsShim.AggressiveInlining)]
		public sealed override SByte? DecodeNullableSByte(in SequenceReader<byte> source, out int requestHint)
		{
			this.ReadTrivia(source, out _);
			if (this.TryReadNull(source))
			{
				requestHint = 0;
				return null;
			}

			return this.DecodeSByteCore(source, out requestHint);
		}

		/// <inheritdoc />
		[MethodImpl(MethodImplOptionsShim.AggressiveInlining)]
		public sealed override Int16? DecodeNullableInt16(in SequenceReader<byte> source, out int requestHint)
		{
			this.ReadTrivia(source, out _);
			if (this.TryReadNull(source))
			{
				requestHint = 0;
				return null;
			}

			return this.DecodeInt16Core(source, out requestHint);
		}

		/// <inheritdoc />
		[MethodImpl(MethodImplOptionsShim.AggressiveInlining)]
		public sealed override UInt16? DecodeNullableUInt16(in SequenceReader<byte> source, out int requestHint)
		{
			this.ReadTrivia(source, out _);
			if (this.TryReadNull(source))
			{
				requestHint = 0;
				return null;
			}

			return this.DecodeUInt16Core(source, out requestHint);
		}

		/// <inheritdoc />
		[MethodImpl(MethodImplOptionsShim.AggressiveInlining)]
		public sealed override Int32? DecodeNullableInt32(in SequenceReader<byte> source, out int requestHint)
		{
			this.ReadTrivia(source, out _);
			if (this.TryReadNull(source))
			{
				requestHint = 0;
				return null;
			}

			return this.DecodeInt32Core(source, out requestHint);
		}

		/// <inheritdoc />
		[MethodImpl(MethodImplOptionsShim.AggressiveInlining)]
		public sealed override UInt32? DecodeNullableUInt32(in SequenceReader<byte> source, out int requestHint)
		{
			this.ReadTrivia(source, out _);
			if (this.TryReadNull(source))
			{
				requestHint = 0;
				return null;
			}

			return this.DecodeUInt32Core(source, out requestHint);
		}

		/// <inheritdoc />
		[MethodImpl(MethodImplOptionsShim.AggressiveInlining)]
		public sealed override Int64? DecodeNullableInt64(in SequenceReader<byte> source, out int requestHint)
		{
			this.ReadTrivia(source, out _);
			if (this.TryReadNull(source))
			{
				requestHint = 0;
				return null;
			}

			return this.DecodeInt64Core(source, out requestHint);
		}

		/// <inheritdoc />
		[MethodImpl(MethodImplOptionsShim.AggressiveInlining)]
		public sealed override UInt64? DecodeNullableUInt64(in SequenceReader<byte> source, out int requestHint)
		{
			this.ReadTrivia(source, out _);
			if (this.TryReadNull(source))
			{
				requestHint = 0;
				return null;
			}

			return this.DecodeUInt64Core(source, out requestHint);
		}

		/// <inheritdoc />
		[MethodImpl(MethodImplOptionsShim.AggressiveInlining)]
		public sealed override Single? DecodeNullableSingle(in SequenceReader<byte> source, out int requestHint)
		{
			this.ReadTrivia(source, out _);
			if (this.TryReadNull(source))
			{
				requestHint = 0;
				return null;
			}

			return this.DecodeSingleCore(source, out requestHint);
		}

		/// <inheritdoc />
		[MethodImpl(MethodImplOptionsShim.AggressiveInlining)]
		public sealed override Double? DecodeNullableDouble(in SequenceReader<byte> source, out int requestHint)
		{
			this.ReadTrivia(source, out _);
			if (this.TryReadNull(source))
			{
				requestHint = 0;
				return null;
			}

			return this.DecodeDoubleCore(source, out requestHint);
		}

		/// <inheritdoc />
		[MethodImpl(MethodImplOptionsShim.AggressiveInlining)]
		public sealed override Boolean? DecodeNullableBoolean(in SequenceReader<byte> source, out int requestHint)
		{
			this.ReadTrivia(source, out _);
			if (this.TryReadNull(source))
			{
				requestHint = 0;
				return null;
			}

			return this.DecodeBooleanCore(source, out requestHint);
		}

	}
}
