// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

using System.Buffers;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using MsgPack.Codecs;

namespace MsgPack.Serialization
{
	/// <summary>
	///		Facade serializer of enum serializers which are determined in runtime by codec feature of <see cref="FormatEncoder"/>.
	/// </summary>
	/// <typeparam name="T">The type of the target enum type.</typeparam>
	internal sealed class DynamicEnumSerializer<T> : NonCollectionObjectSerializer<T>
	{
		private readonly ObjectSerializer<T> _byName;
		private readonly ObjectSerializer<T> _byUnderlyingValue;

		public DynamicEnumSerializer(
			ObjectSerializerProvider ownerProvider,
			ObjectSerializer<T> byName,
			ObjectSerializer<T> byUnderlyingValue
		) : base(ownerProvider)
		{
			this._byName = byName;
			this._byUnderlyingValue = byUnderlyingValue;
		}

		private ObjectSerializer<T> GetSerializer(CodecFeatures features)
			=> this.GetEnumSerializationMethod(features) == EnumSerializationMethod.ByName ?
				this._byName :
				this._byUnderlyingValue;

		public override void Serialize(ref SerializationOperationContext context, [AllowNull] T obj, IBufferWriter<byte> sink)
			=> this.GetSerializer(context.Encoder.Features).Serialize(ref context, obj, sink);

		[return: MaybeNull]
		public sealed override T Deserialize(ref DeserializationOperationContext context, ref SequenceReader<byte> source)
			=> this.GetSerializer(context.Decoder.Features).Deserialize(ref context, ref source);

#if FEATURE_TAP

		public sealed override ValueTask<T> DeserializeAsync(AsyncDeserializationOperationContext context, ReadOnlyStreamSequence source)
			=> this.GetSerializer(context.Decoder.Features).DeserializeAsync(context, source);

#endif // FEATURE_TAP
	}
}
