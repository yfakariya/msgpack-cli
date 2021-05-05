// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

using MsgPack.Codecs;
using MsgPack.Serialization;

namespace MsgPack.Codecs.Json
{
	internal static class JsonFormatFeatures
	{
		public static CodecFeatures Value { get; } =
			new CodecFeaturesBuilder("Json")
			{
				CanCountCollectionItems = false,
				CanSpecifyStringEncoding = false,
				SupportsExtensionTypes = false
			}.SetObjectSerializationMethod(SerializationMethod.Map, AvailableSerializationMethods.Map)
			.Build();
	}
}
