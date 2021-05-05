// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

namespace MsgPack.Serialization
{
#warning TODO: DO NOT USE THIS ENUM
	/// <summary>
	///		Represents compatibility level.
	/// </summary>
	[System.Obsolete("DO NOT USE THIS")]
	public enum SerializationCompatibilityLevel
	{
		/// <summary>
		///		Use latest feature. Almost backward compatible, but some compatibities are broken.
		/// </summary>
		Latest = 0,

		/// <summary>
		///		Compatible for version 0.5.x or former.
		/// </summary>
		Version0_5,

		/// <summary>
		///		Compatible for version 0.6.x, 0.7.x, 0.8.x, and 0.9.x.
		/// </summary>
		Version0_9
	}
}
