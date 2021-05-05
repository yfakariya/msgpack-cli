// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache 2 license.
// See the LICENSE in the project root for more information.

using MsgPack.Codecs;

namespace MsgPack.Codecs
{
	/// <summary>
	///		Defines options for <see cref="MessagePackDecoder"/>.
	/// </summary>
	public sealed class MessagePackDecoderOptions : FormatDecoderOptions
	{
		/// <summary>
		///		Gets the <see cref="MessagePackDecoderOptions"/> object which has default settings.
		/// </summary>
		/// <value>
		///		The <see cref="MessagePackDecoderOptions"/> object which has default settings.
		/// </value>
		public static MessagePackDecoderOptions Default { get; } = new MessagePackDecoderOptionsBuilder().Build();

		internal MessagePackDecoderOptions(MessagePackDecoderOptionsBuilder builder)
			: base(builder) { }
	}
}
