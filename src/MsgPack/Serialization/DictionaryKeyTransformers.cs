// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

using System;

namespace MsgPack.Serialization
{
	/// <summary>
	///		Defines built-in, out-of-box handlers for <see cref="DictionarySerializationOptionsBuilder.KeyTransformer"/>.
	/// </summary>
	public static class DictionaryKeyTransformers
	{
		/// <summary>
		///		Gets the handler which transforms upper camel casing (PascalCasing) key to lower camel casing (camelCasing) key.
		/// </summary>
		/// <value>
		///		The handler which transforms upper camel casing (PascalCasing) key to lower camel casing (camelCasing) key.
		/// </value>
		/// <remarks>
		///		This method uses <see cref="Char"/> based invariant culture to tranform casing, so non ASCII charactors may not be transformed correctly espetially surrogate pairs.
		/// </remarks>
		public static Func<string, string> LowerCamel => KeyNameTransformers.ToLowerCamel;
	}
}
