// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

using System;

namespace MsgPack.Serialization
{
	public sealed class SerializationContextBuilder : SerializationContextBuilder
	{
		public PackerCompatibilityOptions PackerCompatibilityOptions { get; set; }

		public SerializationContextBuilder() { }

		internal static SerializationContextBuilder FromContext(SerializerProvider context)
		{
			var builder = new SerializationContextBuilder();
			builder.Configure(
				optionsBuilder =>
				{
					optionsBuilder.ConfigureDefaultCollectionType(
						b => b.DefaultCollectionTypes.Import(context.SerializerGenerationOptions.DefaultCollectionTypes.AsEnumerable())
					);
					optionsBuilder.DefaultDateTimeConversionMethod = context.SerializerGenerationOptions.DefaultDateTimeConversionMethod;
					optionsBuilder.ConfigureDictionarySerializationOptions(
						b =>
						{
							b.KeyTransformer = context.SerializerGenerationOptions.DictionaryOptions.KeyTransformer;
							b.OmitsNullEntries = context.SerializerGenerationOptions.DictionaryOptions.OmitsNullEntries;
						}
					);
					optionsBuilder.ConfigureEnumSerializationOptions(
						b =>
						{
							b.NameTransformer = context.SerializerGenerationOptions.EnumOptions.NameTransformer;
							b.InternalSetSerializationMethod(context.SerializerGenerationOptions.EnumOptions.SerializationMethod);
						}
					);

					if (context.SerializerGenerationOptions.IsPrivilegedAccessDisabled)
					{
						optionsBuilder.DisablePrivilegedAccess();
					}

					if (context.SerializerGenerationOptions.IsRuntimeCodeGenerationDisabled)
					{
						optionsBuilder.DisableRuntimeCodeGeneration();
					}
				}
			);

			return builder;
		}

		protected sealed override void ConfigureDefault(SerializerGenerationOptionsBuilder builder)
		{
			base.ConfigureDefault(builder);

			throw new NotImplementedException();
		}

		public MessagePackSerializationContext Build() => new MessagePackSerializationContext(this, shouldCopy: true);
	}
}
