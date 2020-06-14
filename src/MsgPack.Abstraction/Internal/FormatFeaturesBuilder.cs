// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

namespace MsgPack.Internal
{
	public sealed class FormatFeaturesBuilder
	{
		public bool IsContextful { get; set; }
		public bool CanCountCollectionItems { get; set; }
		public bool CanSpecifyStringEncoding { get; set; }
		public bool SupportsExtensionTypes { get; set; }

		public FormatFeatures Build() => new FormatFeatures(this);
	}
}
