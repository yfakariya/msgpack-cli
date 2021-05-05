// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

using System.Buffers;
using MsgPack.Internal;

namespace MsgPack.Codecs
{
	/// <summary>
	///		A builder object for <see cref="FormatDecoderOptions"/>.
	/// </summary>
	public abstract class FormatDecoderOptionsBuilder
	{
		/// <summary>
		///		Gets the value whether the <see cref="FormatDecoder"/> can decode integer from an encoded real number.
		/// </summary>
		/// <value>
		///		<c>true</c> if the <see cref="FormatDecoder"/> can decode integer from an encoded real number; <c>false</c>, otherwise.
		///		Default is <c>true</c>.
		/// </value>
		public bool CanTreatRealAsInteger { get; private set; } = OptionsDefaults.CanTreatRealAsInteger;

		/// <summary>
		///		Gets the threshold for the <see cref="FormatDecoder"/> ignores to check <see cref="System.Threading.CancellationToken"/> in processing of collections, binaries, or strings.
		/// </summary>
		/// <value>
		///		The threshold for the <see cref="FormatDecoder"/> ignores to check <see cref="System.Threading.CancellationToken"/> in processing of collections, binaries, or strings.
		///		Default is <c>128 * 1024 * 1024</c> (<c>128MBi</c>).
		/// </value>
		public int CancellationSupportThreshold { get; private set; } = OptionsDefaults.CancellationSupportThreshold;

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
		public int MaxNumberLengthInBytes { get; private set; } = OptionsDefaults.MaxNumberLengthInBytes;

		/// <summary>
		///		Gets the maximum allowed length of serialized strings in bytes. 
		/// </summary>
		/// <value>
		///		The maximum allowed length of serialized strings in bytes. 
		///		Default is <c>256 * 1024 * 1024</c> (<c>256MBi</c>).
		/// </value>
		/// <remarks>
		///		String may be very lengthy, so it may cause DoS attack.
		///		This property prevents such security issues.
		/// </remarks>
		public int MaxStringLengthInBytes { get; private set; } = OptionsDefaults.MaxStringLengthInBytes;

		/// <summary>
		///		Gets the maximum allowed length of serialized binaries in bytes. 
		/// </summary>
		/// <value>
		///		The maximum allowed length of serialized binaries in bytes. 
		///		Default is <c>256 * 1024 * 1024</c> (<c>256MBi</c>).
		/// </value>
		/// <remarks>
		///		Binary may be very lengthy, so it may cause DoS attack.
		///		This property prevents such security issues.
		/// </remarks>
		public int MaxBinaryLengthInBytes { get; private set; } = OptionsDefaults.MaxBinaryLengthInBytes;

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
		///		Gets the defaultlength of buffers fetched from <see cref="ByteBufferPool"/>.
		/// </summary>
		/// <value>
		///		The default length of buffers fetched from <see cref="ByteBufferPool"/>.
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
		///		Initializes a new instance of <see cref="FormatDecoderOptionsBuilder"/> class.
		/// </summary>
		protected FormatDecoderOptionsBuilder() { }

		/// <summary>
		///		Sets <see cref="CanTreatRealAsInteger"/> to <c>true</c>.
		/// </summary>
		/// <returns>
		///		This <see cref="FormatDecoderOptionsBuilder"/> object.
		/// </returns>
		/// <remarks>
		///		This method just reset <see cref="CanTreatRealAsInteger"/> to the default value.
		///		This method is useful to clarify the intent in your code.
		/// </remarks>
		public FormatDecoderOptionsBuilder AllowTreatRealAsInteger()
		{
			this.CanTreatRealAsInteger = true;
			return this;
		}

		/// <summary>
		///		Sets <see cref="CanTreatRealAsInteger"/> to <c>false</c>.
		/// </summary>
		/// <returns>
		///		This <see cref="FormatDecoderOptionsBuilder"/> object.
		/// </returns>
		public FormatDecoderOptionsBuilder ProhibitTreatRealAsInteger()
		{
			this.CanTreatRealAsInteger = false;
			return this;
		}

		/// <summary>
		///		Sets the threshold for the <see cref="FormatDecoder"/> ignores to check <see cref="System.Threading.CancellationToken"/> in processing of collections, binaries, or strings.
		/// </summary>
		/// <param name="value">
		///		The threshold for the <see cref="FormatDecoder"/> ignores to check <see cref="System.Threading.CancellationToken"/> in processing of collections, binaries, or strings.
		/// </param>
		/// <returns>
		///		This <see cref="FormatDecoderOptionsBuilder"/> object.
		/// </returns>
		/// <exception cref="System.ArgumentOutOfRangeException">
		///		<paramref name="value"/> is less than <c>1</c>.
		/// </exception>
		public FormatDecoderOptionsBuilder SetCancellationSupportThreshold(int value)
		{
			this.CancellationSupportThreshold = Ensure.IsNotLessThan(value, 1);
			return this;
		}

		/// <summary>
		///		Resets the threshold for the <see cref="FormatDecoder"/> ignores to check <see cref="System.Threading.CancellationToken"/> in processing of collections, binaries, or strings.
		/// </summary>
		/// <returns>
		///		This <see cref="FormatDecoderOptionsBuilder"/> object.
		/// </returns>
		/// <remarks>
		///		This method is useful to clarify the intent in your code.
		/// </remarks>
		public FormatDecoderOptionsBuilder ResetCancellationSupportThreshold()
		{
			this.CancellationSupportThreshold = OptionsDefaults.CancellationSupportThreshold;
			return this;
		}

		/// <summary>
		///		Sets the maximum allowed length of serialized numbers in bytes. 
		/// </summary>
		/// <param name="value">
		///		The maximum allowed length of serialized numbers in bytes. 
		/// </param>
		/// <returns>
		///		This <see cref="FormatDecoderOptionsBuilder"/> object.
		/// </returns>
		/// <exception cref="System.ArgumentOutOfRangeException">
		///		<paramref name="value"/> is less than <c>1</c>, or is too large.
		/// </exception>
		/// <remarks>
		///		Floating point representation may be very lengthy number,
		///		so it may cause DoS attack.
		///		This property prevents such security issues.
		/// </remarks>
		public FormatDecoderOptionsBuilder SetMaxNumberLengthInBytes(int value)
		{
			this.MaxNumberLengthInBytes = Ensure.IsBetween(value, 1, OptionsDefaults.MaxSingleByteCollectionLength);
			return this;
		}

		/// <summary>
		///		Resets the maximum allowed length of serialized numbers in bytes. 
		/// </summary>
		/// <returns>
		///		This <see cref="FormatDecoderOptionsBuilder"/> object.
		/// </returns>
		/// <remarks>
		///		This method is useful to clarify the intent in your code.
		/// </remarks>
		public FormatDecoderOptionsBuilder ResetMaxNumberLengthInBytes()
		{
			this.MaxNumberLengthInBytes = OptionsDefaults.MaxNumberLengthInBytes;
			return this;
		}

		/// <summary>
		///		Sets the maximum allowed length of serialized strings in bytes. 
		/// </summary>
		/// <param name="value">
		///		The maximum allowed length of serialized strings in bytes. 
		/// </param>
		/// <returns>
		///		This <see cref="FormatDecoderOptionsBuilder"/> object.
		/// </returns>
		/// <exception cref="System.ArgumentOutOfRangeException">
		///		<paramref name="value"/> is less than <c>1</c>, or is too large.
		/// </exception>
		/// <remarks>
		///		String may be very lengthy, so it may cause DoS attack.
		///		This property prevents such security issues.
		/// </remarks>
		public FormatDecoderOptionsBuilder SetMaxStringLengthInBytes(int value)
		{
			this.MaxStringLengthInBytes = Ensure.IsBetween(value, 1, OptionsDefaults.MaxMultiByteCollectionLength);
			return this;
		}

		/// <summary>
		///		Resets the maximum allowed length of serialized strings in bytes. 
		/// </summary>
		/// <returns>
		///		This <see cref="FormatDecoderOptionsBuilder"/> object.
		/// </returns>
		/// <remarks>
		///		This method is useful to clarify the intent in your code.
		/// </remarks>
		public FormatDecoderOptionsBuilder ResetMaxStringLengthInBytes()
		{
			this.MaxStringLengthInBytes = OptionsDefaults.MaxStringLengthInBytes;
			return this;
		}

		/// <summary>
		///		Sets the maximum allowed length of serialized binaries in bytes. 
		/// </summary>
		/// <param name="value">
		///		The maximum allowed length of serialized binaries in bytes. 
		/// </param>
		/// <returns>
		///		This <see cref="FormatDecoderOptionsBuilder"/> object.
		/// </returns>
		/// <exception cref="System.ArgumentOutOfRangeException">
		///		<paramref name="value"/> is less than <c>1</c>, or is too large.
		/// </exception>
		/// <remarks>
		///		Binary may be very lengthy, so it may cause DoS attack.
		///		This property prevents such security issues.
		/// </remarks>
		public FormatDecoderOptionsBuilder SetMaxBinaryLengthInBytes(int value)
		{
			this.MaxBinaryLengthInBytes = Ensure.IsBetween(value, 1, OptionsDefaults.MaxSingleByteCollectionLength);
			return this;
		}

		/// <summary>
		///		Resets the maximum allowed length of serialized binaries in bytes. 
		/// </summary>
		/// <returns>
		///		This <see cref="FormatDecoderOptionsBuilder"/> object.
		/// </returns>
		/// <remarks>
		///		This method is useful to clarify the intent in your code.
		/// </remarks>
		public FormatDecoderOptionsBuilder ResetMaxBinaryLengthInBytes()
		{
			this.MaxBinaryLengthInBytes = OptionsDefaults.MaxBinaryLengthInBytes;
			return this;
		}

		/// <summary>
		///		Sets the <see cref="ArrayPool{T}"/> of <see cref="System.Byte"/> used for buffer.
		/// </summary>
		/// <param name="value">
		///		The <see cref="ArrayPool{T}"/> of <see cref="System.Byte"/> used for buffer.
		/// </param>
		/// <returns>
		///		This <see cref="FormatDecoderOptionsBuilder"/> object.
		/// </returns>
		/// <exception cref="System.ArgumentNullException">
		///		<paramref name="value"/> is <c>null</c>.
		/// </exception>
		public FormatDecoderOptionsBuilder SetByteBufferPool(ArrayPool<byte> value)
		{
			this.ByteBufferPool = Ensure.NotNull(value);
			return this;
		}

		/// <summary>
		///		Resets the <see cref="ArrayPool{T}"/> of <see cref="System.Byte"/> used for buffer.
		/// </summary>
		/// <returns>
		///		This <see cref="FormatDecoderOptionsBuilder"/> object.
		/// </returns>
		/// <remarks>
		///		This method is useful to clarify the intent in your code.
		/// </remarks>
		public FormatDecoderOptionsBuilder ResetByteBufferPool()
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
		///		This <see cref="FormatDecoderOptionsBuilder"/> object.
		/// </returns>
		/// <exception cref="System.ArgumentNullException">
		///		<paramref name="value"/> is <c>null</c>.
		/// </exception>
		public FormatDecoderOptionsBuilder SetCharBufferPool(ArrayPool<char> value)
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
		///		This <see cref="FormatDecoderOptionsBuilder"/> object.
		/// </returns>
		/// <exception cref="System.ArgumentOutOfRangeException">
		///		<paramref name="value"/> is less than <c>4</c>.
		/// </exception>
		public FormatDecoderOptionsBuilder SetMaxByteBufferLength(int value)
		{
			this.MaxByteBufferLength = Ensure.IsNotLessThan(value, 4);
			return this;
		}

		/// <summary>
		///		Resets the default length of buffers fetched from <see cref="ByteBufferPool"/>.
		/// </summary>
		/// <returns>
		///		This <see cref="FormatDecoderOptionsBuilder"/> object.
		/// </returns>
		/// <remarks>
		///		This method is useful to clarify the intent in your code.
		/// </remarks>
		public FormatDecoderOptionsBuilder ResetMaxByteBufferLength()
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
		///		This <see cref="FormatDecoderOptionsBuilder"/> object.
		/// </returns>
		/// <exception cref="System.ArgumentOutOfRangeException">
		///		<paramref name="value"/> is less than <c>2</c>.
		/// </exception>
		public FormatDecoderOptionsBuilder SetMaxCharBufferLength(int value)
		{
			this.MaxCharBufferLength = Ensure.IsNotLessThan(value, 2);
			return this;
		}

		/// <summary>
		///		Resets the default length of buffers fetched from <see cref="CharBufferPool"/>.
		/// </summary>
		/// <returns>
		///		This <see cref="FormatDecoderOptionsBuilder"/> object.
		/// </returns>
		/// <remarks>
		///		This method is useful to clarify the intent in your code.
		/// </remarks>
		public FormatDecoderOptionsBuilder ResetMaxCharBufferLength()
		{
			this.MaxCharBufferLength = OptionsDefaults.MaxCharBufferLength;
			return this;
		}

		/// <summary>
		///		Resets the <see cref="ArrayPool{T}"/> of <see cref="System.Char"/> used for buffer.
		/// </summary>
		/// <returns>
		///		This <see cref="FormatDecoderOptionsBuilder"/> object.
		/// </returns>
		/// <remarks>
		///		This method is useful to clarify the intent in your code.
		/// </remarks>
		public FormatDecoderOptionsBuilder ResetCharBufferPool()
		{
			this.CharBufferPool = OptionsDefaults.CharBufferPool;
			return this;
		}

		/// <summary>
		///		Sets buffers should be cleared when they are returned to pool.
		/// </summary>
		/// <returns>
		///		This <see cref="FormatDecoderOptionsBuilder"/> object.
		/// </returns>
		/// <remarks>
		///		If serialized value may contain sensitive data, setting this property to <c>true</c>.
		///		It minimizes an opportunity of the data exposure from memory dump or other consumsers of shared buffer pool.
		/// </remarks>
		public FormatDecoderOptionsBuilder WithBufferClear()
		{
			this.ClearsBuffer = true;
			return this;
		}

		/// <summary>
		///		Sets buffers should not be cleared when they are returned to pool.
		/// </summary>
		/// <returns>
		///		This <see cref="FormatDecoderOptionsBuilder"/> object.
		/// </returns>
		/// <remarks>
		///		This method just reset <see cref="ClearsBuffer"/> to the default value.
		///		This method is useful to clarify the intent in your code.
		/// </remarks>
		public FormatDecoderOptionsBuilder WithoutBufferClear()
		{
			this.ClearsBuffer = false;
			return this;
		}
	}
}
