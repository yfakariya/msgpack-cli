// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

using System.Text;
using MsgPack.Serialization;
using MsgPack.Internal;

namespace MsgPack.Codecs
{
	/// <summary>
	///		Represents features of the specific codec.
	/// </summary>
	public sealed class CodecFeatures
	{
		/// <summary>
		///		Gets a unique name of the underlying codec.
		/// </summary>
		/// <value>
		///		A unique name of the underlying codec which is non-blank string.
		/// </value>
		public string Name { get; }

		/// <summary>
		///		Gets a value which indicates the underlying codec supports collection length.
		/// </summary>
		/// <value>
		///		<c>true</c> if the underlyng codec supports collection length; <c>false</c>, otherwise.
		/// </value>
		/// <remarks>
		///		When this property returns <c>false</c>, following methods should throw <see cref="System.NotSupportedException"/>.
		///		<list type="bullet">
		///			<item><see cref="FormatDecoder.DecodeArrayHeader(ref System.Buffers.SequenceReader{System.Byte})"/></item>
		///			<item><see cref="FormatDecoder.DecodeArrayHeader(ref System.Buffers.SequenceReader{System.Byte}, out System.Int32)"/></item>
		///			<item><see cref="FormatDecoder.DecodeMapHeader(ref System.Buffers.SequenceReader{System.Byte})"/></item>
		///			<item><see cref="FormatDecoder.DecodeMapHeader(ref System.Buffers.SequenceReader{System.Byte}, out System.Int32)"/></item>
		///			<item><see cref="FormatDecoder.DecodeArrayOrMapHeader(ref System.Buffers.SequenceReader{System.Byte}, out System.Int32)"/></item>
		///			<item><see cref="FormatDecoder.DecodeArrayOrMapHeader(ref System.Buffers.SequenceReader{System.Byte}, out System.Int32, out System.Int32)"/></item>
		///			<item><see cref="FormatDecoder.Drain(ref System.Buffers.SequenceReader{System.Byte}, in CollectionContext, System.Int64, System.Threading.CancellationToken)"/></item>
		///			<item><see cref="FormatDecoder.Drain(ref System.Buffers.SequenceReader{System.Byte}, in CollectionContext, System.Int64, out System.Int32, System.Threading.CancellationToken)"/></item>
		///		</list>
		/// </remarks>
		public bool CanCountCollectionItems { get; }

		/// <summary>
		///		Gets a value which indicates the underlying codec supports custom string encoding.
		/// </summary>
		/// <value>
		///		<c>true</c> if the underlyng format supports custom string encoding; <c>false</c>, otherwise.
		/// </value>
		/// <remarks>
		///		When this property returns <c>false</c>, <see cref="System.Text.Encoding"/> typed parameters in <see cref="FormatEncoder"/> and <see cref="FormatDecoder"/> methods will be ignored.
		/// </remarks>
		public bool CanSpecifyStringEncoding { get; }

		/// <summary>
		///		Gets a value which indicates the underlying codec supports extension types.
		/// </summary>
		/// <value>
		///		<c>true</c> if the underlyng codec supports extension types; <c>false</c>, otherwise.
		/// </value>
		/// <remarks>
		///		When this property returns <c>false</c>, following methods should throw <see cref="System.NotSupportedException"/>.
		///		<list type="bullet">
		///			<item><see cref="FormatEncoder.EncodeExtension(ExtensionType, System.ReadOnlySpan{System.Byte}, System.Buffers.IBufferWriter{System.Byte})"/></item>
		///			<item><see cref="FormatEncoder.EncodeExtension(ExtensionType, in System.Buffers.ReadOnlySequence{System.Byte}, System.Buffers.IBufferWriter{System.Byte})"/></item>
		///			<item><see cref="FormatDecoder.DecodeExtension(ref System.Buffers.SequenceReader{System.Byte}, out ExtensionTypeObject, out System.Int32, System.Threading.CancellationToken)"/></item>
		///		</list>
		/// </remarks>
		public bool SupportsExtensionTypes { get; }

		/// <summary>
		///		Gets a value which indicates preferred <see cref="SerializationMethod"/> for the underlying codec.
		/// </summary>
		/// <value>
		///		A value which indicates preferred <see cref="SerializationMethod"/> for the underlying codec.
		/// </value>
		public SerializationMethod PreferredObjectSerializationMethod { get; }

		/// <summary>
		///		Gets a value which indicates preferred <see cref="EnumSerializationMethod"/> for the underlying codec.
		/// </summary>
		/// <value>
		///		A value which indicates preferred <see cref="EnumSerializationMethod"/> for the underlying codec.
		/// </value>
		public EnumSerializationMethod PreferredEnumSerializationMethod { get; }

		/// <summary>
		///		Gets a value which indicates preferred <see cref="DateTimeConversionMethod"/> for the underlying codec.
		/// </summary>
		/// <value>
		///		A value which indicates preferred <see cref="DateTimeConversionMethod"/> for the underlying codec.
		/// </value>
		public DateTimeConversionMethod PreferredDateTimeConversionMethod { get; }

		/// <summary>
		///		Gets a value which indicates available <see cref="SerializationMethod"/> set as <see cref="MsgPack.Serialization.AvailableSerializationMethods"/>.
		/// </summary>
		/// <value>
		///		A value which indicates available <see cref="SerializationMethod"/> set as <see cref="MsgPack.Serialization.AvailableSerializationMethods"/>.
		/// </value>
		public AvailableSerializationMethods AvailableSerializationMethods { get; }

		/// <summary>
		///		Gets the default encoding of strings.
		/// </summary>
		/// <value>
		///		The default encoding of strings.
		/// </value>
		public Encoding DefaultStringEncoding { get; }

		/// <summary>
		///		Gets the precision of fraction portion on ISO 8601 date time string as specified by this codec.
		/// </summary>
		/// <value>
		///		The precision of fraction portion on ISO 8601 date time string as specified by this codec.
		///		<c>null</c> means that the value will be determined by serialization option or serializer implementation.
		/// </value>
		/// <remarks>
		///		<include file='../../Common/Remarks.xml' path='docs/doc[@name="DateTimeConversion"]'/>
		/// </remarks>
		public int? Iso8601FractionOfSecondsPrecision { get; }

		/// <summary>
		///		Gets a separator char for fraction portion by this codec.
		/// </summary>
		/// <value>
		///		A separator char for fraction portion.
		///		<c>null</c> means that the value will be determined by serialization option or serializer implementation.
		/// </value>
		public char? Iso8601DecimalSeparator { get; }

		/// <summary>
		///		Gets the mapping table between known extension types and their names.
		/// </summary>
		/// <value>
		///		The mapping table between known extension types and their names.
		/// </value>
		public ExtensionTypeMappings ExtensionTypeMappings { get; }

		internal CodecFeatures(CodecFeaturesBuilder builder)
		{
			this.Name = builder.Name;
			this.CanCountCollectionItems = builder.CanCountCollectionItems;
			this.CanSpecifyStringEncoding = builder.CanSpecifyStringEncoding;
			this.SupportsExtensionTypes = builder.SupportsExtensionTypes;
			this.PreferredObjectSerializationMethod = builder.PreferredObjectSerializationMethod;
			this.PreferredEnumSerializationMethod = builder.PreferredEnumSerializationMethod;
			this.PreferredDateTimeConversionMethod = builder.PreferredDateTimeConversionMethod;
			this.AvailableSerializationMethods = builder.AvailableSerializationMethods;
			this.DefaultStringEncoding = builder.DefaultStringEncoding;
			this.Iso8601FractionOfSecondsPrecision = builder.Iso8601FractionOfSecondsPrecision;
			this.Iso8601DecimalSeparator = builder.Iso8601DecimalSeparator;
			this.ExtensionTypeMappings = builder.ExtensionTypeMappings.Build();
		}
	}
}
