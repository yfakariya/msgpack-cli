// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

namespace MsgPack
{
	/// <summary>
	///		Defines known extension type code for MessagePack for CLI.
	/// </summary>
	/// <remarks>
	///		Note that values in this class are not guaranteed as interoperable with other implementations.
	///		These are just known by MessagePack for CLI implementation.
	/// </remarks>
	public static class KnownExtensionTypeCodes
	{
		/// <summary>
		///		Gets the ext type code which represents MsgPack timestamp.
		/// </summary>
		/// <value>
		///		0xFF(-1).
		/// </value>
		public static ExtensionType Timestamp { get; } = new ExtensionType(0xFF);

		/// <summary>
		///		Gets the ext type code which represents multidimensional array.
		/// </summary>
		/// <value>
		///		0x71.
		/// </value>
		public static ExtensionType MultidimensionalArray { get; } = new ExtensionType(0x71);
	}
}
