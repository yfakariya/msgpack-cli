// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

// <auto-generated /> 
// This file is generated from acompanying .tt file.
// DO NOT edit this file directly, edit .tt file instead.

using System;
using System.Buffers;
using System.Runtime.CompilerServices;

// Abstract methods with [CLSCompilant(false)] are intended -- codec implementer must use languages which support unsigned integers.
// [CLSCompliant] is just for users of Codec rather than implementers.
#pragma warning disable 3011 // only CLS-compliant members can be abstract

namespace MsgPack.Internal
{
	partial class FormatEncoder
	{
		/// <summary>
		///		Encodes <see cref="Int32" /> value to specified buffer.
		///		The implementation will choose most compact format.
		/// </summary>
		/// <param name="value">Value to be encoded.</param>
		/// <param name="buffer"><see cref="IBufferWriter{T}">IBufferWriter&lt;byte&gt;</see>.</param>
		/// <exception cref="ArgumentNullException"><paramref name="buffer" /> is <c>null</c>.</exception>
		/// <exception cref="NotSupportedException">The underlying format does not suppor this type.</exception>
		public abstract void EncodeInt32(Int32 value, IBufferWriter<byte> buffer);

		/// <summary>
		///		Encodes <see cref="Int32" /> value or <c>null</c> to specified buffer.
		///		The implementation will choose most compact format.
		/// </summary>
		/// <param name="value">Value to be encoded.</param>
		/// <param name="buffer"><see cref="IBufferWriter{T}">IBufferWriter&lt;byte&gt;</see>.</param>
		[MethodImpl(MethodImplOptionsShim.AggressiveInlining)]
		public void EncodeInt32(Int32? value, IBufferWriter<byte> buffer)
		{
			buffer = Ensure.NotNull(buffer);

			if (value == null)
			{
				this.EncodeNull(buffer);
			}
			else
			{
				this.EncodeInt32(value.GetValueOrDefault(), buffer);
			}
		}
		/// <summary>
		///		Encodes <see cref="Int64" /> value to specified buffer.
		///		The implementation will choose most compact format.
		/// </summary>
		/// <param name="value">Value to be encoded.</param>
		/// <param name="buffer"><see cref="IBufferWriter{T}">IBufferWriter&lt;byte&gt;</see>.</param>
		/// <exception cref="ArgumentNullException"><paramref name="buffer" /> is <c>null</c>.</exception>
		/// <exception cref="NotSupportedException">The underlying format does not suppor this type.</exception>
		public abstract void EncodeInt64(Int64 value, IBufferWriter<byte> buffer);

		/// <summary>
		///		Encodes <see cref="Int64" /> value or <c>null</c> to specified buffer.
		///		The implementation will choose most compact format.
		/// </summary>
		/// <param name="value">Value to be encoded.</param>
		/// <param name="buffer"><see cref="IBufferWriter{T}">IBufferWriter&lt;byte&gt;</see>.</param>
		[MethodImpl(MethodImplOptionsShim.AggressiveInlining)]
		public void EncodeInt64(Int64? value, IBufferWriter<byte> buffer)
		{
			buffer = Ensure.NotNull(buffer);

			if (value == null)
			{
				this.EncodeNull(buffer);
			}
			else
			{
				this.EncodeInt64(value.GetValueOrDefault(), buffer);
			}
		}
		/// <summary>
		///		Encodes <see cref="UInt32" /> value to specified buffer.
		///		The implementation will choose most compact format.
		/// </summary>
		/// <param name="value">Value to be encoded.</param>
		/// <param name="buffer"><see cref="IBufferWriter{T}">IBufferWriter&lt;byte&gt;</see>.</param>
		/// <exception cref="ArgumentNullException"><paramref name="buffer" /> is <c>null</c>.</exception>
		/// <exception cref="NotSupportedException">The underlying format does not suppor this type.</exception>
		[CLSCompliant(false)]
		public abstract void EncodeUInt32(UInt32 value, IBufferWriter<byte> buffer);

		/// <summary>
		///		Encodes <see cref="UInt32" /> value or <c>null</c> to specified buffer.
		///		The implementation will choose most compact format.
		/// </summary>
		/// <param name="value">Value to be encoded.</param>
		/// <param name="buffer"><see cref="IBufferWriter{T}">IBufferWriter&lt;byte&gt;</see>.</param>
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptionsShim.AggressiveInlining)]
		public void EncodeUInt32(UInt32? value, IBufferWriter<byte> buffer)
		{
			buffer = Ensure.NotNull(buffer);

			if (value == null)
			{
				this.EncodeNull(buffer);
			}
			else
			{
				this.EncodeUInt32(value.GetValueOrDefault(), buffer);
			}
		}
		/// <summary>
		///		Encodes <see cref="UInt64" /> value to specified buffer.
		///		The implementation will choose most compact format.
		/// </summary>
		/// <param name="value">Value to be encoded.</param>
		/// <param name="buffer"><see cref="IBufferWriter{T}">IBufferWriter&lt;byte&gt;</see>.</param>
		/// <exception cref="ArgumentNullException"><paramref name="buffer" /> is <c>null</c>.</exception>
		/// <exception cref="NotSupportedException">The underlying format does not suppor this type.</exception>
		[CLSCompliant(false)]
		public abstract void EncodeUInt64(UInt64 value, IBufferWriter<byte> buffer);

		/// <summary>
		///		Encodes <see cref="UInt64" /> value or <c>null</c> to specified buffer.
		///		The implementation will choose most compact format.
		/// </summary>
		/// <param name="value">Value to be encoded.</param>
		/// <param name="buffer"><see cref="IBufferWriter{T}">IBufferWriter&lt;byte&gt;</see>.</param>
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptionsShim.AggressiveInlining)]
		public void EncodeUInt64(UInt64? value, IBufferWriter<byte> buffer)
		{
			buffer = Ensure.NotNull(buffer);

			if (value == null)
			{
				this.EncodeNull(buffer);
			}
			else
			{
				this.EncodeUInt64(value.GetValueOrDefault(), buffer);
			}
		}
		/// <summary>
		///		Encodes <see cref="Single" /> value to specified buffer.
		///		The implementation will choose most compact format.
		/// </summary>
		/// <param name="value">Value to be encoded.</param>
		/// <param name="buffer"><see cref="IBufferWriter{T}">IBufferWriter&lt;byte&gt;</see>.</param>
		/// <exception cref="ArgumentNullException"><paramref name="buffer" /> is <c>null</c>.</exception>
		/// <exception cref="NotSupportedException">The underlying format does not suppor this type.</exception>
		public abstract void EncodeSingle(Single value, IBufferWriter<byte> buffer);

		/// <summary>
		///		Encodes <see cref="Single" /> value or <c>null</c> to specified buffer.
		///		The implementation will choose most compact format.
		/// </summary>
		/// <param name="value">Value to be encoded.</param>
		/// <param name="buffer"><see cref="IBufferWriter{T}">IBufferWriter&lt;byte&gt;</see>.</param>
		[MethodImpl(MethodImplOptionsShim.AggressiveInlining)]
		public void EncodeSingle(Single? value, IBufferWriter<byte> buffer)
		{
			buffer = Ensure.NotNull(buffer);

			if (value == null)
			{
				this.EncodeNull(buffer);
			}
			else
			{
				this.EncodeSingle(value.GetValueOrDefault(), buffer);
			}
		}
		/// <summary>
		///		Encodes <see cref="Double" /> value to specified buffer.
		///		The implementation will choose most compact format.
		/// </summary>
		/// <param name="value">Value to be encoded.</param>
		/// <param name="buffer"><see cref="IBufferWriter{T}">IBufferWriter&lt;byte&gt;</see>.</param>
		/// <exception cref="ArgumentNullException"><paramref name="buffer" /> is <c>null</c>.</exception>
		/// <exception cref="NotSupportedException">The underlying format does not suppor this type.</exception>
		public abstract void EncodeDouble(Double value, IBufferWriter<byte> buffer);

		/// <summary>
		///		Encodes <see cref="Double" /> value or <c>null</c> to specified buffer.
		///		The implementation will choose most compact format.
		/// </summary>
		/// <param name="value">Value to be encoded.</param>
		/// <param name="buffer"><see cref="IBufferWriter{T}">IBufferWriter&lt;byte&gt;</see>.</param>
		[MethodImpl(MethodImplOptionsShim.AggressiveInlining)]
		public void EncodeDouble(Double? value, IBufferWriter<byte> buffer)
		{
			buffer = Ensure.NotNull(buffer);

			if (value == null)
			{
				this.EncodeNull(buffer);
			}
			else
			{
				this.EncodeDouble(value.GetValueOrDefault(), buffer);
			}
		}
		/// <summary>
		///		Encodes <see cref="Boolean" /> value to specified buffer.
		///		The implementation will choose most compact format.
		/// </summary>
		/// <param name="value">Value to be encoded.</param>
		/// <param name="buffer"><see cref="IBufferWriter{T}">IBufferWriter&lt;byte&gt;</see>.</param>
		/// <exception cref="ArgumentNullException"><paramref name="buffer" /> is <c>null</c>.</exception>
		/// <exception cref="NotSupportedException">The underlying format does not suppor this type.</exception>
		public abstract void EncodeBoolean(Boolean value, IBufferWriter<byte> buffer);

		/// <summary>
		///		Encodes <see cref="Boolean" /> value or <c>null</c> to specified buffer.
		///		The implementation will choose most compact format.
		/// </summary>
		/// <param name="value">Value to be encoded.</param>
		/// <param name="buffer"><see cref="IBufferWriter{T}">IBufferWriter&lt;byte&gt;</see>.</param>
		[MethodImpl(MethodImplOptionsShim.AggressiveInlining)]
		public void EncodeBoolean(Boolean? value, IBufferWriter<byte> buffer)
		{
			buffer = Ensure.NotNull(buffer);

			if (value == null)
			{
				this.EncodeNull(buffer);
			}
			else
			{
				this.EncodeBoolean(value.GetValueOrDefault(), buffer);
			}
		}
	}
}
