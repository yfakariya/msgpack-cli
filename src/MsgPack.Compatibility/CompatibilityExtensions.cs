// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

namespace MsgPack
{
	public static class CompatibilityExtensions
	{
		public static IPackable AsPackable(this MessagePackObject obj)
			=> new PackableMessagePackObject(obj);

#if FEATURE_TAP
		public static IAsyncPackable AsAsyncPackable(this MessagePackObject obj)
			=> new PackableMessagePackObject(obj);
#endif // FEATURE_TAP
	}
}
