// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

namespace MsgPack.Codecs
{
	/// <summary>
	///		Defines options for <see cref="MessagePackEncoder"/>.
	/// </summary>
	public sealed class MessagePackEncoderOptions : FormatEncoderOptions
	{
		/// <summary>
		///		Gets the <see cref="MessagePackDecoderOptions"/> object which has default settings.
		/// </summary>
		/// <value>
		///		The <see cref="MessagePackDecoderOptions"/> object which has default settings.
		///		It uses latest specification.
		/// </value>
		public static MessagePackEncoderOptions Default { get; } = new MessagePackEncoderOptionsBuilder().Build();

		public MessagePackCompatibilityLevel CompatibilityLevel { get; }

		internal MessagePackEncoderOptions(MessagePackEncoderOptionsBuilder builder)
			: base(builder)
		{
			this.CompatibilityLevel = builder.CompatibilityLevel;
		}
	}
}
