// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

using MsgPack.Internal;

namespace MsgPack.Codecs
{
	public enum MessagePackCompatibilityLevel
	{
		/// <summary>
		///		Uses latest specification.
		/// </summary>
		Latest = 0,

		/// <summary>
		///		Original specification published in 2008.
		///		<see cref="MessagePackEncoder"/> will not use <c>bin</c> types and <c>ext</c> types to keep compatibility for legacy implementations.
		///		<see cref="CodecFeatures.PreferredDateTimeConversionMethod"/> will be <see cref="DateTimeConversionMethod.UnixEpoc"/>.
		/// </summary>
		Version2008,

		/// <summary>
		///		Official specification published in 2013 with <c>bin</c> type and <c>ext</c> type.
		///		<see cref="CodecFeatures.PreferredDateTimeConversionMethod"/> will be <see cref="DateTimeConversionMethod.UnixEpoc"/>.
		/// </summary>
		Version2013,

		/// <summary>
		///		Official specification published in 2017 with new built-in <c>timestamp</c> extension type support.
		///		<see cref="CodecFeatures.PreferredDateTimeConversionMethod"/> will be <see cref="DateTimeConversionMethod.Timestamp"/>.
		/// </summary>
		Version2017
	}
}
