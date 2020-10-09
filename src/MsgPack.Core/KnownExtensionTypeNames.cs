// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

namespace MsgPack
{
	/// <summary>
	///		Defines known extension type name for MessagePack for CLI.
	/// </summary>
	/// <remarks>
	///		Note that values in this class are not guaranteed as interoperable with other implementations.
	///		These are just known by MessagePack for CLI implementation.
	/// </remarks>
	public static class KnownExtensionTypeNames
	{
		/// <summary>
		///		Gets the ext type name which represents MsgPack timestamp.
		/// </summary>
		/// <value>
		///		"Timestamp".
		/// </value>
		public static string Timestamp => "Timestamp";

		/// <summary>
		///		Gets the ext type name which represents multidimensional array.
		/// </summary>
		/// <value>
		///		"MultidimensionalArray".
		/// </value>
		public static string MultidimensionalArray => "MultidimensionalArray";
	}
}
