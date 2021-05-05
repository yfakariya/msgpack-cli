// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

namespace MsgPack.Serialization
{
	/// <summary>
	///		Defines a type of the polymorphism.
	/// </summary>
	internal enum PolymorphismType
	{
		/// <summary>
		///		No polymorphism.
		/// </summary>
		None = 0,

		/// <summary>
		///		Knwon ext-type code based polymorphism.
		/// </summary>
		KnownTypes,

		/// <summary>
		///		Non-interoperable type info embedding based polymorphism.
		/// </summary>
		RuntimeType
	}
}
