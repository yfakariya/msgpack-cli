// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

namespace MsgPack.Internal
{
	/// <summary>
	///		Represents the type of <see cref="DecodeItemResult"/>.
	/// </summary>
	public enum ElementType
	{
		/// <summary>
		///		The <see cref="DecodeItemResult"/> is empty. That is, the value does not represent any result.
		/// </summary>
		None = 0,

		/// <summary>
		///		The <see cref="DecodeItemResult"/> is an integer value in valid <see cref="System.Int32"/> range.
		/// </summary>
		Int32 = 1,

		/// <summary>
		///		The <see cref="DecodeItemResult"/> is an integer value in valid <see cref="System.Int64"/> range.
		/// </summary>
		Int64 = 2,

		/// <summary>
		///		The <see cref="DecodeItemResult"/> is an integer value in valid <see cref="System.UInt64"/> range.
		/// </summary>
		UInt64 = 3,

		/// <summary>
		///		The <see cref="DecodeItemResult"/> is a <see cref="System.Single"/> value.
		/// </summary>
		Single = 4,

		/// <summary>
		///		The <see cref="DecodeItemResult"/> is a <see cref="System.Double"/> value.
		/// </summary>
		Double = 5,

		/// <summary>
		///		The <see cref="DecodeItemResult"/> is a <see cref="System.Boolean"/> <c>true</c>.
		/// </summary>
		True = 6,

		/// <summary>
		///		The <see cref="DecodeItemResult"/> is a <see cref="System.Boolean"/> <c>false</c>.
		/// </summary>
		False = 7,

		/// <summary>
		///		The <see cref="DecodeItemResult"/> is <c>null</c> (<c>nil</c>).
		/// </summary>
		Null = 8,

		/// <summary>
		///		The <see cref="DecodeItemResult"/> is an array.
		/// </summary>
		Array = 0x11,

		/// <summary>
		///		The <see cref="DecodeItemResult"/> is a map.
		/// </summary>
		Map = 0x12,

		/// <summary>
		///		The <see cref="DecodeItemResult"/> is a <see cref="System.String"/> value.
		/// </summary>
		String = 0x21,

		/// <summary>
		///		The <see cref="DecodeItemResult"/> is a binary (byte sequence) value.
		/// </summary>
		Binary = 0x22,

		/// <summary>
		///		The <see cref="DecodeItemResult"/> is an extension type object value.
		/// </summary>
		Extension = 0x31,

		/// <summary>
		///		The <see cref="DecodeItemResult"/> is trivial whitespaces.
		/// </summary>
		Whitespace = 0x41,

		/// <summary>
		///		The <see cref="DecodeItemResult"/> is trivial comments.
		/// </summary>
		Comment = 0x42,

		/// <summary>
		///		The <see cref="DecodeItemResult"/> is trivial bytes other than whitespaces nor comments.
		/// </summary>
		OtherTrivia = 0x4F,

		/// <summary>
		///		The <see cref="DecodeItemResult"/> represents an error due to insuficient input.
		/// </summary>
		InsufficientInputError = -1
	}
}
