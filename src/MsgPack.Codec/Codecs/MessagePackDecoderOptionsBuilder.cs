// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache 2 license.
// See the LICENSE in the project root for more information.

using MsgPack.Codecs;

namespace MsgPack.Codecs
{
	/// <summary>
	///		A builder object for <see cref="MessagePackDecoderOptions"/> object.
	/// </summary>
	public sealed class MessagePackDecoderOptionsBuilder : FormatDecoderOptionsBuilder
	{
		/// <summary>
		///		Initializes a new instance of <see cref="MessagePackDecoderOptionsBuilder"/> class.
		/// </summary>
		public MessagePackDecoderOptionsBuilder() { }

		/// <summary>
		///		Builds <see cref="MessagePackDecoderOptions"/> from settings of this object.
		/// </summary>
		/// <returns><see cref="MessagePackDecoderOptions"/> built from settings of this object.</returns>
		public MessagePackDecoderOptions Build() => new MessagePackDecoderOptions(this, MessagePackCodecFeatures.Latest);
	}
}
