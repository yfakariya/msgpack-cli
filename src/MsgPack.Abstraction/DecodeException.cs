// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

using System;
#if FEATURE_BINARY_SERIALIZATION
using System.Runtime.Serialization;
#endif // FEATURE_BINARY_SERIALIZATION

namespace MsgPack
{
	/// <summary>
	///		Defines common exception for decoding error which is caused by invalid input byte sequence.
	/// </summary>
#if FEATURE_BINARY_SERIALIZATION
	[Serializable]
#endif // FEATURE_BINARY_SERIALIZATION
	public abstract class DecodeException : Exception
	{
		/// <summary>
		///		Gets the position of the input sequence.
		/// </summary>
		/// <value>
		///		The position of the input sequence.
		/// </value>
		/// <remarks>
		///		This value MAY NOT represents actual position of source byte sequence espetially in asynchronous deserialization 
		///		because the position stored in this property may reflect the offset in the buffer which is gotten from underlying byte stream rather than the stream position.
		///		So, the serializer, which is consumer of the decoder,  must provide appropriate exception message with calculated position information with this property.
		///		
		///		<note>Because of above limitation, this property's value will not included in <see cref="P:Message"/> property nand <see cref="M:ToString()"/> result.</note>
		/// </remarks>
		public long Position { get; }

		/// <summary>
		///		Initializes a new instance of <see cref="DecodeException"/> class with default error message.
		/// </summary>
		/// <param name="position">The position of the input sequence.</param>
		/// <seealso cref="Position"/>
		protected DecodeException(long position)
			: base()
		{
			this.Position = position;
		}

		/// <summary>
		///		Initializes a new instance of <see cref="DecodeException"/> class with a specified error message.
		/// </summary>
		/// <param name="position">The position of the input sequence.</param>
		/// <param name="message">The message that describes the error.</param>
		/// <seealso cref="Position"/>
		protected DecodeException(long position, string? message)
			: base(message)
		{
			this.Position = position;
		}

		/// <summary>
		///		Initializes a new instance of <see cref="DecodeException"/> class with a specified error message
		///		and a reference to the inner exception that is the cause of this exception.
		/// </summary>
		/// <param name="position">The position of the input sequence.</param>
		/// <param name="message">The message that describes the error.</param>
		/// <param name="innerException">
		///		The exception that is the cause of the current exception, or <c>null</c> if no inner exception is specified.
		/// </param>
		/// <seealso cref="Position"/>
		protected DecodeException(long position, string? message, Exception? innerException)
			: base(message, innerException)
		{
			this.Position = position;
		}

#if FEATURE_BINARY_SERIALIZATION

		// 例外:
		//   T:System.ArgumentNullException:
		//     info is null.
		//
		//   T:System.Runtime.Serialization.SerializationException:
		//     The class name is null or System.Exception.HResult is zero (0).
		/// <summary>
		///		Initializes a new instance of the <see cref="DecodeException"/> class with serialized data.
		/// </summary>
		/// <param name="info">
		///		The <see cref="SerializationInfo"/> that holds the serialized object data about the exception being thrown.
		/// </param>
		/// <param name="context">
		///		The <see cref="StreamingContext"/> that contains contextual information about the source or destination.
		/// </param>
		/// <exception cref="ArgumentNullException">
		///		<paramref name="info"/> is <c>null</c>.
		/// </exception>
		/// <exception cref="SerializationException">
		///		The class name is <c>null</c> or <see cref="Exception.HResult"/> is <c>0</c>.
		/// </exception>
		protected DecodeException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
			this.Position = info.GetInt64("Position");
		}

		/// <inheritdoc />
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			base.GetObjectData(info, context);
			info.AddValue("Position", this.Position);
		}

#endif // FEATURE_BINARY_SERIALIZATION
	}
}
