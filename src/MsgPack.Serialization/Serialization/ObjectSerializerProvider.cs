// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

using System;

namespace MsgPack.Serialization
{
	/// <summary>
	///		Provides interfaces and foundational features for object serializers to provide child serializers.
	/// </summary>
	/// <remarks>
	///		Users cannot inherit this class.
	/// </remarks>
	public abstract class ObjectSerializerProvider : IObjectSerializerProvider
	{
		// Internaly, this type also holds non public ISerializerGenerationOptions for special serializers including reflection serializers.

		internal ISerializerGenerationOptions GenerationOptions { get; }

		private protected ObjectSerializerProvider(ISerializerGenerationOptions options)
		{
			this.GenerationOptions = options;
		}

		private protected abstract ObjectSerializer GetObjectSerializer(Type targetType, object? providerParameter);

		ObjectSerializer IObjectSerializerProvider.GetSerializer(Type targetType, object? providerParameter)
			=> this.GetObjectSerializer(targetType, providerParameter);
	}
}
