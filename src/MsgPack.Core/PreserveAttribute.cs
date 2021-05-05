// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

using System;

namespace MsgPack
{
#pragma warning disable 0649
	// For Unity and Xamarin
	internal sealed class PreserveAttribute : Attribute
	{
		public bool AllMembers;
		public bool Conditional;
	}
#pragma warning restore 0649
}
