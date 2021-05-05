// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

using System.Buffers;
using MsgPack.Codecs;

namespace MsgPack.Codecs
{
#warning TODO MaxXXXBufferLength -> DefaultXXXBufferLength
	/// <summary>
	///		Represents options for <see cref="FormatDecoder"/>.
	/// </summary>
	public abstract class FormatDecoderOptions
	{
		/// <summary>
		///		Gets the value whether the <see cref="FormatDecoder"/> can decode integer from an encoded real number.
		/// </summary>
		/// <value>
		///		<c>true</c> if the <see cref="FormatDecoder"/> can decode integer from an encoded real number; <c>false</c>, otherwise.
		///		Default is <c>true</c>.
		/// </value>
		public bool CanTreatRealAsInteger { get; }

		/// <summary>
		///		Gets the threshold for the <see cref="FormatDecoder"/> ignores to check <see cref="System.Threading.CancellationToken"/> in processing of collections, binaries, or strings.
		/// </summary>
		/// <value>
		///		The threshold for the <see cref="FormatDecoder"/> ignores to check <see cref="System.Threading.CancellationToken"/> in processing of collections, binaries, or strings.
		///		Default is <c>128 * 1024 * 1024</c> (<c>128Mi</c>).
		/// </value>
		public int CancellationSupportThreshold { get; }

		/// <summary>
		///		Gets the maximum allowed length of serialized numbers in bytes. 
		/// </summary>
		/// <value>
		///		The maximum allowed length of serialized numbers in bytes. 
		///		Default is <c>32</c>.
		/// </value>
		/// <remarks>
		///		Floating point representation may be very lengthy number,
		///		so it may cause DoS attack.
		///		This property prevents such security issues.
		/// </remarks>
		public int MaxNumberLengthInBytes { get; }

		/// <summary>
		///		Gets the maximum allowed length of serialized strings in bytes. 
		/// </summary>
		/// <value>
		///		The maximum allowed length of serialized strings in bytes. 
		///		Default is <c>256 * 1024 * 1024</c> (<c>256Mi</c>).
		/// </value>
		/// <remarks>
		///		String may be very lengthy, so it may cause DoS attack.
		///		This property prevents such security issues.
		/// </remarks>
		public int MaxStringLengthInBytes { get; }

		/// <summary>
		///		Gets the maximum allowed length of serialized binaries in bytes. 
		/// </summary>
		/// <value>
		///		The maximum allowed length of serialized binaries in bytes. 
		///		Default is <c>256 * 1024 * 1024</c> (<c>256Mi</c>).
		/// </value>
		/// <remarks>
		///		Binary may be very lengthy, so it may cause DoS attack.
		///		This property prevents such security issues.
		/// </remarks>
		public int MaxBinaryLengthInBytes { get; }

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
		///		Gets the default length of buffers fetched from <see cref="ByteBufferPool"/>.
		/// </summary>
		/// <value>
		///		The default length of buffers fetched from <see cref="ByteBufferPool"/>.
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
		protected FormatDecoderOptions(FormatDecoderOptionsBuilder builder, CodecFeatures features)
		{
			builder = Ensure.NotNull(builder);

			this.CanTreatRealAsInteger = builder.CanTreatRealAsInteger;
			this.CancellationSupportThreshold = builder.CancellationSupportThreshold;
			this.MaxByteBufferLength = builder.MaxByteBufferLength;
			this.MaxCharBufferLength = builder.MaxCharBufferLength;
			this.MaxNumberLengthInBytes = builder.MaxNumberLengthInBytes;
			this.MaxStringLengthInBytes = builder.MaxStringLengthInBytes;
			this.MaxBinaryLengthInBytes = builder.MaxBinaryLengthInBytes;
			this.ByteBufferPool = builder.ByteBufferPool;
			this.CharBufferPool = builder.CharBufferPool;
			this.ClearsBuffer = builder.ClearsBuffer;
			this.Features = Ensure.NotNull(features);
		}
	}
}
