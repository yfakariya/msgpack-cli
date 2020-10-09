// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

using System.Buffers;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using MsgPack.Codecs;
using MsgPack.Internal;

namespace MsgPack.Serialization
{
	/// <summary>
	///		Defines basic interface for serializers which handle individual object rather than entire object tree.
	/// </summary>
	/// <remarks>
	///		This object is intended to be used by serializer implementation.
	///		Applications should use <see cref="Serializer"/> instead.
	/// </remarks>
	public abstract class ObjectSerializer
	{
		private readonly ObjectSerializerProvider _ownerProvider;
		protected IObjectSerializerProvider OwnerProvider => this._ownerProvider;
		private protected ISerializerGenerationOptions GenerationOptions => this._ownerProvider.GenerationOptions;
		public SerializerCapabilities Capabilities { get; }
		public bool CanSerialize => (this.Capabilities & SerializerCapabilities.Serialize) != 0;
		public bool CanDeserialize => (this.Capabilities & SerializerCapabilities.Deserialize) != 0;
		public bool CanDeserializeTo => (this.Capabilities & SerializerCapabilities.DeserializeTo) != 0;

		protected ObjectSerializer(ObjectSerializerProvider ownerProvider, SerializerCapabilities capabilities)
		{
			this._ownerProvider = Ensure.NotNull(ownerProvider);
			this.Capabilities = capabilities;
		}

		protected SerializationMethod GetDefaultSerializationMethod(CodecFeatures codecFeatures)
			=> this.GenerationOptions.SerializationOptions.GetDefaultObjectSerializationMethod(codecFeatures);

		protected EnumSerializationMethod GetEnumSerializationMethod(CodecFeatures codecFeatures)
			=> this.GenerationOptions.EnumOptions.GetSerializationMethod(codecFeatures);

		protected DateTimeConversionMethod GetDefaultDateTimeConversionMethod(CodecFeatures codecFeatures)
			=> this.GenerationOptions.DateTimeOptions.GetDefaultDateTimeConversionMethod(codecFeatures);

		protected char? GetIso8601DecimalMark(CodecFeatures codecFeatures)
			=> this.GenerationOptions.DateTimeOptions.GetIso8601DecimalMark(codecFeatures);

		protected int? GetIso8601SubsecondsPrecision(CodecFeatures codecFeatures)
			=> this.GenerationOptions.DateTimeOptions.GetIso8601SubsecondsPrecision(codecFeatures);

		public abstract void SerializeObject(ref SerializationOperationContext context, object? obj, IBufferWriter<byte> sink);
		public async ValueTask SerializeObjectAsync(AsyncSerializationOperationContext context, object? obj, Stream streamSink)
		{
			await using (var writer = new StreamBufferWriter(streamSink, ownsStream: false, ArrayPool<byte>.Shared, cleansBuffer: true))
			{
				var serializationOperationContext = context.AsSerializationOperationContext();
				this.SerializeObject(ref serializationOperationContext, obj, writer);
			}
		}

		[return: MaybeNull]
		public abstract object? DeserializeObject(ref DeserializationOperationContext context, ref SequenceReader<byte> source);
		public abstract ValueTask<object?> DeserializeObjectAsync(AsyncDeserializationOperationContext context, ReadOnlyStreamSequence source);
		public abstract bool DeserializeObjectTo(ref DeserializationOperationContext context, ref SequenceReader<byte> source, object obj);
		public abstract ValueTask<bool> DeserializeObjectToAsync(AsyncDeserializationOperationContext context, ReadOnlyStreamSequence source, object obj);
	}
}
