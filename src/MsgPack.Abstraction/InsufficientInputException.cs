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
	///		An exception thrown if there are no more inputs when be requested.
	/// </summary>
#if FEATURE_BINARY_SERIALIZATION
	[Serializable]
#endif // FEATURE_BINARY_SERIALIZATION
	public sealed class InsufficientInputException : DecodeException
	{
		/// <summary>
		///		Initializes a new instance of <see cref="InsufficientInputException"/> class with default error message.
		/// </summary>
		/// <param name="position">The position of the input sequence.</param>
		/// <seealso cref="DecodeException.Position"/>
		public InsufficientInputException(long position)
			: this(position, "There are no more inputs.") { }

		/// <summary>
		///		Initializes a new instance of <see cref="InsufficientInputException"/> class with a specified error message.
		/// </summary>
		/// <param name="position">The position of the input sequence.</param>
		/// <param name="message">The message that describes the error.</param>
		/// <seealso cref="DecodeException.Position"/>
		public InsufficientInputException(long position, string? message)
			: base(position, message) { }

		/// <summary>
		///		Initializes a new instance of <see cref="InsufficientInputException"/> class with a specified error message
		///		and a reference to the inner exception that is the cause of this exception.
		/// </summary>
		/// <param name="position">The position of the input sequence.</param>
		/// <param name="message">The message that describes the error.</param>
		/// <param name="innerException">
		///		The exception that is the cause of the current exception, or <c>null</c> if no inner exception is specified.
		/// </param>
		/// <seealso cref="DecodeException.Position"/>
		public InsufficientInputException(long position, string? message, Exception? innerException)
			: base(position, message, innerException) { }

#if FEATURE_BINARY_SERIALIZATION

		private InsufficientInputException(SerializationInfo info, StreamingContext context)
			: base(info, context) { }

#endif // FEATURE_BINARY_SERIALIZATION
	}
}
