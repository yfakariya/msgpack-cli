// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

using System.Buffers;
using MsgPack.Codecs;

namespace MsgPack.Codecs
{
#warning TODO MaxXXXBufferLength -> DefaultXXXBufferLength
	/// <summary>
	///		Represents options for <see cref="FormatEncoder"/>.
	/// </summary>
	public abstract class FormatEncoderOptions
	{
		/// <summary>
		///		Gets the threshold for the <see cref="FormatEncoder"/> ignores to check <see cref="System.Threading.CancellationToken"/> in processing of collections, binaries, or strings.
		/// </summary>
		/// <value>
		///		The threshold for the <see cref="FormatEncoder"/> ignores to check <see cref="System.Threading.CancellationToken"/> in processing of collections, binaries, or strings.
		///		Default is <c>128 * 1024 * 1024</c> (<c>128Mi</c>).
		/// </value>
		public int CancellationSupportThreshold { get; }

		/// <summary>
		///		Gets the <see cref="ArrayPool{T}"/> of <see cref="System.Byte"/> used for buffer.
		/// </summary>
		/// <value>
		///		The <see cref="ArrayPool{T}"/> of <see cref="System.Byte"/> used for buffer.
		/// </value>
		public ArrayPool<byte> ByteBufferPool { get; }

		/// <summary>
		///		Gets the <see cref="ArrayPool{T}"/> of <see cref="System.Char"/> used for buffer.
		/// </summary>
		/// <value>
		///		The <see cref="ArrayPool{T}"/> of <see cref="System.Char"/> used for buffer.
		/// </value>
		public ArrayPool<char> CharBufferPool { get; }

		/// <summary>
		///		Gets the default length of buffers fetched from <see cref="ByteBufferPool"/> or <see cref="System.Buffers.IBufferWriter{T}"/>.
		/// </summary>
		/// <value>
		///		The default length of buffers fetched from <see cref="ByteBufferPool"/> or <see cref="System.Buffers.IBufferWriter{T}"/>.
		///		Default is <c>2 * 1024 * 1024</c> (<c>2Mi</c>).
		/// </value>
		public int MaxByteBufferLength { get; }

		/// <summary>
		///		Gets the default length of buffers fetched from <see cref="CharBufferPool"/>.
		/// </summary>
		/// <value>
		///		The default length of buffers fetched from <see cref="CharBufferPool"/>.
		///		Default is <c>2 * 1024 * 1024</c> (<c>2Mi</c>).
		/// </value>
		public int MaxCharBufferLength { get; }

		/// <summary>
		///		Gets the value whether buffers should be cleared when they are returned to pool.
		/// </summary>
		/// <value>
		///		<c>true</c> if buffers should be cleared when they are returned to pool; <c>false</c>, otherwise.
		///		Default is <c>false</c>.
		/// </value>
		/// <remarks>
		///		If serialized value may contain sensitive data, setting this property to <c>true</c>.
		///		It minimizes an opportunity of the data exposure from memory dump or other consumsers of shared buffer pool.
		/// </remarks>
		public bool ClearsBuffer { get; }

		/// <summary>
		///		Gets the <see cref="CodecFeatures"/> which provides features of the format.
		/// </summary>
		/// <value>
		///		The <see cref="CodecFeatures"/> which provides features of the format.
		/// </value>
		public CodecFeatures Features { get; }

		/// <summary>
		///		Initializes a new instance of <see cref="FormatDecoderOptions"/> class.
		/// </summary>
		/// <param name="builder">The <see cref="FormatDecoderOptionsBuilder"/> which holds options for the new instance.</param>
		/// <param name="features">The <see cref="CodecFeatures"/> which provides features of the format.</param>
		protected FormatEncoderOptions(FormatEncoderOptionsBuilder builder, CodecFeatures features)
		{
			builder = Ensure.NotNull(builder);

			this.CancellationSupportThreshold = builder.CancellationSupportThreshold;
			this.MaxByteBufferLength = builder.MaxByteBufferLength;
			this.MaxCharBufferLength = builder.MaxCharBufferLength;
			this.ByteBufferPool = builder.ByteBufferPool;
			this.CharBufferPool = builder.CharBufferPool;
			this.ClearsBuffer = builder.ClearsBuffer;
			this.Features = Ensure.NotNull(features);
		}
	}
}
