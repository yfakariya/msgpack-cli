// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

using System;
using MsgPack.Codecs;

namespace MsgPack.Serialization
{
	/// <summary>
	///		Defines enum serialization options.
	/// </summary>
	[Obsolete(
		Obsoletion.UseBuilder.Message
#if FEATURE_ADVANCED_OBSOLETE
		, DiagId = Obsoletion.UseBuilder.DiagId
		, Url = Obsoletion.UseBuilder.Url
#endif // FEATURE_ADVANCED_OBSOLETE
	)]
	public sealed class EnumSerializationOptions : IEnumSerializationOptions
	{
		private EnumSerializationMethod _serializationMethod;

		/// <summary>
		///		Gets or sets a <see cref="EnumSerializationMethod"/> to determine default enum serialization method.
		/// </summary>
		/// <value>
		///		The <see cref="EnumSerializationMethod"/> to determine default enum serialization method.
		/// </value>
		/// <exception cref="ArgumentOutOfRangeException">The setting value is invalid as <see cref="EnumSerializationMethod"/> enum.</exception>
		/// <remarks>
		///		A serialization strategy for specific <strong>member</strong> is determined as following:
		///		<list type="numeric">
		///			<item>If the member is marked with <see cref="MessagePackEnumMemberAttribute"/> and its value is not <see cref="EnumMemberSerializationMethod.Default"/>, then it will be used.</item>
		///			<item>Else, if the enum type itself is marked with <see cref="MessagePackEnumAttribute"/>, then it will be used.</item>
		///			<item>Otherwise, the value of this property will be used.</item>
		/// 	</list>
		///		Note that the default value of this property is <see cref="T:EnumSerializationMethod.ByName"/>, it is not size efficient but tolerant to unexpected enum definition change.
		/// </remarks>
		public EnumSerializationMethod SerializationMethod
		{
			get => this._serializationMethod;
#warning TODO: Obsoletion
			[Obsolete("Use SerializationContextBuilder.ConfigureEnumOptions() method with EnumSerializationOptionsBuilder's static factory methods instead.")]
			set
			{
				switch (value)
				{
					case EnumSerializationMethod.ByName:
					case EnumSerializationMethod.ByUnderlyingValue:
					{
						break;
					}
					default:
					{
						throw new ArgumentOutOfRangeException("value");
					}
				}

				this._serializationMethod = value;
			}
		}

		/// <summary>
		///		Gets or sets a key name handler which enables customization of enum values serialization by their names.
		/// </summary>
		/// <value>
		///		A key name handler which enables customization of enum values serialization by their names.
		///		The default value is <c>null</c>, which indicates that value is not transformed.
		/// </value>
		/// <remarks>
		///		This value will affect when <see cref="P:SerializationMethod"/> is set to <see cref="EnumSerializationMethod.ByName"/>.
		///		In addition, deserialization is always done by case insensitive manner.
		/// </remarks>
		/// <see cref="EnumNameTransformers"/>
		public Func<string, string>? NameTransformer
		{
			get;
#warning TODO: Obsoletion
			[Obsolete("Use SerializationContextBuilder.ConfigureEnumOptions() method with EnumSerializationOptionsBuilder.SetNameTransformer() method instead.")]
			set;
		}

		/// <summary>
		///		Gets or sets a value whether of member names are ignored in deserialization or not.
		/// </summary>
		/// <value>
		///		<c>true</c> if casing of member names are ignored in deserialization; <c>false</c>, otherwise.
		///		Default is <c>false</c>.
		/// </value>
		public bool IgnoresCaseOnDeserialization
		{
			get;
#warning TODO: Obsoletion
			[Obsolete("Use SerializationContextBuilder.ConfigureEnumOptions() method with EnumSerializationOptionsBuilder.SetNameTransformer() method instead.")]
			set;
		}

		EnumSerializationMethod IEnumSerializationOptions.GetSerializationMethod(CodecFeatures codecFeatures)
			=> this.SerializationMethod;

		Func<string, string> IEnumSerializationOptions.NameTransformer => this.NameTransformer ?? KeyNameTransformers.AsIs;

#warning TODO: ctor??
	}
}
