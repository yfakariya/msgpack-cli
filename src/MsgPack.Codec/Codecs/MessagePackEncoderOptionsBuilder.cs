// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

using MsgPack.Codecs;

namespace MsgPack.Codecs
{
	/// <summary>
	///		A builder object for <see cref="MessagePackEncoderOptions"/> object.
	/// </summary>
	public sealed class MessagePackEncoderOptionsBuilder : FormatEncoderOptionsBuilder
	{
		/// <summary>
		///		Gets the specification compatiblity level.
		/// </summary>
		public MessagePackCompatibilityLevel CompatibilityLevel { get; private set; }

		/// <summary>
		///		Initializes a new instance of <see cref="MessagePackEncoderOptionsBuilder"/> class.
		/// </summary>
		public MessagePackEncoderOptionsBuilder()
		{
			this.CompatibilityLevel = MessagePackCompatibilityLevel.Latest;
		}

		/// <summary>
		///		Resets specification level to latest.
		/// </summary>
		/// <returns>This <see cref="MessagePackEncoderOptionsBuilder"/> instance.</returns>
		/// <remarks>
		///		This default option maximally utilize MessagePack specification capabilities,
		///		but some legacy counterpart might not interpret some relatively new format.
		/// </remarks>
		public MessagePackEncoderOptionsBuilder UseLatestSpecification()
		{
			this.CompatibilityLevel = MessagePackCompatibilityLevel.Latest;
			return this;
		}

		/// <summary>
		///		Uses the specification level which defines extension types, binary types, and <see cref="Timestamp"/> built-in extension type.
		/// </summary>
		/// <returns>This <see cref="MessagePackEncoderOptionsBuilder"/> instance.</returns>
		public MessagePackEncoderOptionsBuilder Use2017Specification()
		{
			this.CompatibilityLevel = MessagePackCompatibilityLevel.Version2017;
			return this;
		}

		/// <summary>
		///		Uses the legacy specification level which defines extension types and binary types, but does NOT define <see cref="Timestamp"/> built-in extension type.
		/// </summary>
		/// <returns>This <see cref="MessagePackEncoderOptionsBuilder"/> instance.</returns>
		public MessagePackEncoderOptionsBuilder Use2013Specification()
		{
			this.CompatibilityLevel = MessagePackCompatibilityLevel.Version2013;
			return this;
		}

		/// <summary>
		///		Uses the legacy specification level which does NOT define extension types, binary types, and <see cref="Timestamp"/> built-in extension type.
		/// </summary>
		/// <returns>This <see cref="MessagePackEncoderOptionsBuilder"/> instance.</returns>
		public MessagePackEncoderOptionsBuilder Use2008Specification()
		{
			this.CompatibilityLevel = MessagePackCompatibilityLevel.Version2008;
			return this;
		}

		/// <summary>
		///		Builds <see cref="MessagePackEncoderOptions"/> from settings of this object.
		/// </summary>
		/// <returns><see cref="MessagePackEncoderOptions"/> built from settings of this object.</returns>
		public MessagePackEncoderOptions Build() =>
			new MessagePackEncoderOptions(
				this				
			);
	}
}
