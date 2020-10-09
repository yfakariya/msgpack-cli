// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

using MsgPack.Codecs;

namespace MsgPack.Serialization
{
	/// <summary>
	///		Defines interface to provide date time serialization options with <see cref="CodecFeatures"/> and configured options.
	/// </summary>
	internal interface IRuntimeDateTimeSerializationOptionsProvider
	{
		/// <summary>
		///		Gets the default value of date time conversion method for specified codec.
		/// </summary>
		/// <param name="codecFeatures">The feature of the codec.</param>
		/// <returns>
		///		<see cref="DateTimeConversionMethod"/> for specified codec features.
		///		If an any value is set via builder object, the value will be returned,
		///		else returns <see cref="CodecFeatures.PreferredDateTimeConversionMethod"/>.
		/// </returns>
		DateTimeConversionMethod GetDefaultDateTimeConversionMethod(CodecFeatures codecFeatures);

		/// <summary>
		///		Gets the precision of fraction portion on ISO 8601 date time string as specified for specified codec.
		/// </summary>
		/// <param name="codecFeatures">The feature of the codec.</param>
		/// <returns>
		///		The precision of fraction portion on ISO 8601 date time string for specified codec features.
		///		If an any value is set via builder object, the value will be returned,
		///		else returns <see cref="CodecFeatures.Iso8601FractionOfSecondsPrecision"/>.
		///		<c>null</c> means that the serializer implementation's default should be used.
		/// </returns>
		/// <remarks>
		///		<include file='../../Common/Remarks.xml' path='docs/doc[@name="DateTimeConversion"]'/>
		/// </remarks>
		int? GetIso8601SubsecondsPrecision(CodecFeatures codecFeatures);

		/// <summary>
		///		Gets the separator char for fraction portion.
		/// </summary>
		/// <returns>
		///		The separator char for fraction portion on ISO 8601 date time string for specified codec features.
		///		If an any value is set via builder object, the value will be returned,
		///		else returns <see cref="CodecFeatures.Iso8601DecimalSeparator"/>.
		///		<c>null</c> means that the serializer implementation's default should be used.
		/// </returns>
		char? GetIso8601DecimalMark(CodecFeatures codecFeatures);
	}
}
