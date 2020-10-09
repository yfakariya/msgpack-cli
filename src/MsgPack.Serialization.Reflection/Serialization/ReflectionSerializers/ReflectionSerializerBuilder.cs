// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

using System;

namespace MsgPack.Serialization.ReflectionSerializers
{
	internal sealed class ReflectionSerializerBuilder : SerializerBuilder
	{
		public sealed override ObjectSerializer BuildObjectSerializer(Type targetType, ObjectSerializerProvider ownerProvider, in SerializationTarget target, PolymorphismSchema schema)
			=> SerializerFactory.CreateObjectSerializer(typeof(ReflectionSerializer<>), targetType, ownerProvider, target, schema);

		public sealed override ObjectSerializer BuildTupleSerializer(Type targetType, ObjectSerializerProvider ownerProvider, in SerializationTarget target, PolymorphismSchema schema)
			=> SerializerFactory.CreateObjectSerializer(typeof(ReflectionSerializer<>), targetType, ownerProvider, target, schema);
	}
}
