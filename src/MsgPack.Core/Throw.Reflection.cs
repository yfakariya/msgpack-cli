// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

using System;

namespace MsgPack
{
	internal partial class Throw
	{
		public static void EmptyStruct(Type type, string paramName)
			=> throw new ArgumentException($"The instance of value type '{type}' cannot be empty.", paramName);
	}
}
