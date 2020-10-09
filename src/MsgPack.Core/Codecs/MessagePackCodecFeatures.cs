// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache 2 license.
// See the LICENSE in the project root for more information.

using MsgPack.Serialization;

namespace MsgPack.Codecs
{
	internal static class MessagePackCodecFeatures
	{
		public static CodecFeatures Latest => Version2017;

		public static CodecFeatures Version2017 { get; } =
			new CodecFeaturesBuilder("MessagePack")
			{
				CanCountCollectionItems = true,
				CanSpecifyStringEncoding = true,
				SupportsExtensionTypes = true,
				PreferredDateTimeConversionMethod = DateTimeConversionMethod.Timestamp,
			}.SetObjectSerializationMethod(SerializationMethod.Array, AvailableSerializationMethods.Array | AvailableSerializationMethods.Map)
			.Build();

		public static CodecFeatures Version2013 { get; } =
			new CodecFeaturesBuilder("MessagePack")
			{
				CanCountCollectionItems = true,
				CanSpecifyStringEncoding = true,
				SupportsExtensionTypes = true,
				PreferredDateTimeConversionMethod = DateTimeConversionMethod.UnixEpoc,
			}.SetObjectSerializationMethod(SerializationMethod.Array, AvailableSerializationMethods.Array | AvailableSerializationMethods.Map)
			.Build();

		public static CodecFeatures Version2008 { get; } =
			new CodecFeaturesBuilder("MessagePack")
			{
				CanCountCollectionItems = true,
				CanSpecifyStringEncoding = true,
				SupportsExtensionTypes = false,
				PreferredDateTimeConversionMethod = DateTimeConversionMethod.UnixEpoc
			}.SetObjectSerializationMethod(SerializationMethod.Array, AvailableSerializationMethods.Array | AvailableSerializationMethods.Map)
			.Build();
	}
}
