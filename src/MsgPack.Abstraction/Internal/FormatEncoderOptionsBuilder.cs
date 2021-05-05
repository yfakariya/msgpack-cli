// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

using System.Buffers;

namespace MsgPack.Internal
{
	/// <summary>
	///		A builder object for <see cref="FormatEncoderOptions"/>.
	/// </summary>
	public abstract class FormatEncoderOptionsBuilder
	{
		/// <summary>
		///		Gets the threshold for the <see cref="FormatEncoder"/> ignores to check <see cref="System.Threading.CancellationToken"/> in processing of collections, binaries, or strings.
		/// </summary>
		/// <value>
		///		The threshold for the <see cref="FormatEncoder"/> ignores to check <see cref="System.Threading.CancellationToken"/> in processing of collections, binaries, or strings.
		///		Default is <c>128 * 1024 * 1024</c> (<c>128Mi</c>).
		/// </value>
		public int CancellationSupportThreshold { get; private set; } = OptionsDefaults.CancellationSupportThreshold;

		/// <summary>
		///		Gets the <see cref="ArrayPool{T}"/> of <see cref="System.Byte"/> used for buffer.
		/// </summary>
		/// <value>
		///		The <see cref="ArrayPool{T}"/> of <see cref="System.Byte"/> used for buffer.
		/// </value>
		public ArrayPool<byte> ByteBufferPool { get; private set; } = OptionsDefaults.ByteBufferPool;

		/// <summary>
		///		Gets the <see cref="ArrayPool{T}"/> of <see cref="System.Char"/> used for buffer.
		/// </summary>
		/// <value>
		///		The <see cref="ArrayPool{T}"/> of <see cref="System.Char"/> used for buffer.
		/// </value>
		public ArrayPool<char> CharBufferPool { get; private set; } = OptionsDefaults.CharBufferPool;

		/// <summary>
		///		Gets the default length of buffers fetched from <see cref="ByteBufferPool"/> or <see cref="System.Buffers.IBufferWriter{T}"/>.
		/// </summary>
		/// <value>
		///		The default length of buffers fetched from <see cref="ByteBufferPool"/> or <see cref="System.Buffers.IBufferWriter{T}"/>.
		///		Default is <c>2 * 1024 * 1024</c> (<c>2Mi</c>).
		/// </value>
		public int MaxByteBufferLength { get; private set; } = OptionsDefaults.MaxByteBufferLength;

		/// <summary>
		///		Gets the default length of buffers fetched from <see cref="CharBufferPool"/>.
		/// </summary>
		/// <value>
		///		The default length of buffers fetched from <see cref="CharBufferPool"/>.
		///		Default is <c>2 * 1024 * 1024</c> (<c>2Mi</c>).
		/// </value>
		public int MaxCharBufferLength { get; private set; } = OptionsDefaults.MaxCharBufferLength;

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
		public bool ClearsBuffer { get; private set; } = OptionsDefaults.ClearsBufferOnReturn;

		/// <summary>
		///		Initializes a new instance of <see cref="FormatEncoderOptionsBuilder"/> class.
		/// </summary>
		protected FormatEncoderOptionsBuilder() { }

		/// <summary>
		///		Sets the threshold for the <see cref="FormatEncoder"/> ignores to check <see cref="System.Threading.CancellationToken"/> in processing of collections, binaries, or strings.
		/// </summary>
		/// <param name="value">
		///		The threshold for the <see cref="FormatEncoder"/> ignores to check <see cref="System.Threading.CancellationToken"/> in processing of collections, binaries, or strings.
		/// </param>
		/// <returns>
		///		This <see cref="FormatEncoderOptionsBuilder"/> object.
		/// </returns>
		/// <exception cref="System.ArgumentOutOfRangeException">
		///		<paramref name="value"/> is less than <c>1</c>.
		/// </exception>
		public FormatEncoderOptionsBuilder SetCancellationSupportThreshold(int value)
		{
			this.CancellationSupportThreshold = Ensure.IsNotLessThan(value, 1);
			return this;
		}

		/// <summary>
		///		Resets the threshold for the <see cref="FormatEncoder"/> ignores to check <see cref="System.Threading.CancellationToken"/> in processing of collections, binaries, or strings.
		/// </summary>
		/// <returns>
		///		This <see cref="FormatEncoderOptionsBuilder"/> object.
		/// </returns>
		/// <remarks>
		///		This method is useful to clarify the intent in your code.
		/// </remarks>
		public FormatEncoderOptionsBuilder ResetCancellationSupportThreshold()
		{
			this.CancellationSupportThreshold = OptionsDefaults.CancellationSupportThreshold;
			return this;
		}

		/// <summary>
		///		Sets the <see cref="ArrayPool{T}"/> of <see cref="System.Byte"/> used for buffer.
		/// </summary>
		/// <param name="value">
		///		The <see cref="ArrayPool{T}"/> of <see cref="System.Byte"/> used for buffer.
		/// </param>
		/// <returns>
		///		This <see cref="FormatEncoderOptionsBuilder"/> object.
		/// </returns>
		/// <exception cref="System.ArgumentNullException">
		///		<paramref name="value"/> is <c>null</c>.
		/// </exception>
		public FormatEncoderOptionsBuilder SetByteBufferPool(ArrayPool<byte> value)
		{
			this.ByteBufferPool = Ensure.NotNull(value);
			return this;
		}

		/// <summary>
		///		Resets the <see cref="ArrayPool{T}"/> of <see cref="System.Byte"/> used for buffer.
		/// </summary>
		/// <returns>
		///		This <see cref="FormatEncoderOptionsBuilder"/> object.
		/// </returns>
		/// <remarks>
		///		This method is useful to clarify the intent in your code.
		/// </remarks>
		public FormatEncoderOptionsBuilder ResetByteBufferPool()
		{
			this.ByteBufferPool = OptionsDefaults.ByteBufferPool;
			return this;
		}

		/// <summary>
		///		Sets the <see cref="ArrayPool{T}"/> of <see cref="System.Char"/> used for buffer.
		/// </summary>
		/// <param name="value">
		///		The <see cref="ArrayPool{T}"/> of <see cref="System.Char"/> used for buffer.
		/// </param>
		/// <returns>
		///		This <see cref="FormatEncoderOptionsBuilder"/> object.
		/// </returns>
		/// <exception cref="System.ArgumentNullException">
		///		<paramref name="value"/> is <c>null</c>.
		/// </exception>
		public FormatEncoderOptionsBuilder SetCharBufferPool(ArrayPool<char> value)
		{
			this.CharBufferPool = Ensure.NotNull(value);
			return this;
		}

		/// <summary>
		///		Sets the default length of buffers fetched from <see cref="ByteBufferPool"/>.
		/// </summary>
		/// <param name="value">
		///		The default length of buffers fetched from <see cref="ByteBufferPool"/>.
		/// </param>
		/// <returns>
		///		This <see cref="FormatEncoderOptionsBuilder"/> object.
		/// </returns>
		/// <exception cref="System.ArgumentOutOfRangeException">
		///		<paramref name="value"/> is less than <c>4</c>.
		/// </exception>
		public FormatEncoderOptionsBuilder SetMaxByteBufferLength(int value)
		{
			this.MaxByteBufferLength = Ensure.IsNotLessThan(value, 4);
			return this;
		}

		/// <summary>
		///		Resets the default length of buffers fetched from <see cref="ByteBufferPool"/>.
		/// </summary>
		/// <returns>
		///		This <see cref="FormatEncoderOptionsBuilder"/> object.
		/// </returns>
		/// <remarks>
		///		This method is useful to clarify the intent in your code.
		/// </remarks>
		public FormatEncoderOptionsBuilder ResetMaxByteBufferLength()
		{
			this.MaxByteBufferLength = OptionsDefaults.MaxByteBufferLength;
			return this;
		}

		/// <summary>
		///		Sets the default length of buffers fetched from <see cref="CharBufferPool"/>.
		/// </summary>
		/// <param name="value">
		///		The default length of buffers fetched from <see cref="CharBufferPool"/>.
		/// </param>
		/// <returns>
		///		This <see cref="FormatEncoderOptionsBuilder"/> object.
		/// </returns>
		/// <exception cref="System.ArgumentOutOfRangeException">
		///		<paramref name="value"/> is less than <c>2</c>.
		/// </exception>
		public FormatEncoderOptionsBuilder SetMaxCharBufferLength(int value)
		{
			this.MaxCharBufferLength = Ensure.IsNotLessThan(value, 2);
			return this;
		}

		/// <summary>
		///		Resets the default length of buffers fetched from <see cref="CharBufferPool"/>.
		/// </summary>
		/// <returns>
		///		This <see cref="FormatEncoderOptionsBuilder"/> object.
		/// </returns>
		/// <remarks>
		///		This method is useful to clarify the intent in your code.
		/// </remarks>
		public FormatEncoderOptionsBuilder ResetMaxCharBufferLength()
		{
			this.MaxCharBufferLength = OptionsDefaults.MaxCharBufferLength;
			return this;
		}

		/// <summary>
		///		Resets the <see cref="ArrayPool{T}"/> of <see cref="System.Char"/> used for buffer.
		/// </summary>
		/// <returns>
		///		This <see cref="FormatEncoderOptionsBuilder"/> object.
		/// </returns>
		/// <remarks>
		///		This method is useful to clarify the intent in your code.
		/// </remarks>
		public FormatEncoderOptionsBuilder ResetCharBufferPool()
		{
			this.CharBufferPool = OptionsDefaults.CharBufferPool;
			return this;
		}

		/// <summary>
		///		Sets buffers should be cleared when they are returned to pool.
		/// </summary>
		/// <returns>
		///		This <see cref="FormatEncoderOptionsBuilder"/> object.
		/// </returns>
		/// <remarks>
		///		If serialized value may contain sensitive data, setting this property to <c>true</c>.
		///		It minimizes an opportunity of the data exposure from memory dump or other consumsers of shared buffer pool.
		/// </remarks>
		public FormatEncoderOptionsBuilder WithBufferClear()
		{
			this.ClearsBuffer = true;
			return this;
		}

		/// <summary>
		///		Sets buffers should not be cleared when they are returned to pool.
		/// </summary>
		/// <returns>
		///		This <see cref="FormatEncoderOptionsBuilder"/> object.
		/// </returns>
		/// <remarks>
		///		This method just reset <see cref="ClearsBuffer"/> to the default value.
		///		This method is useful to clarify the intent in your code.
		/// </remarks>
		public FormatEncoderOptionsBuilder WithoutBufferClear()
		{
			this.ClearsBuffer = false;
			return this;
		}
	}
}
