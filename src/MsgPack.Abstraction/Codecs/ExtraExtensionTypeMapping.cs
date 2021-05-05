// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

using System;

namespace MsgPack.Codecs
{
	/// <summary>
	///		Represents an extra extension type mapping of <see cref="ExtensionTypeMappings"/>.
	/// </summary>
	public readonly struct ExtraExtensionTypeMapping : IEquatable<ExtraExtensionTypeMapping>
	{
		/// <summary>
		///		Gets the <see cref="ExtensionType"/> for this extra mapping entry.
		/// </summary>
		/// <value>
		///		The <see cref="ExtensionType"/> for this extra mapping entry.
		///		This value is unique in parent <see cref="ExtensionTypeMappings"/>.
		/// </value>
		public ExtensionType Type { get; }

		/// <summary>
		///		Gets the arbitrary label which describes this entry specified by registerer.
		/// </summary>
		/// <value>
		///		The arbitrary label which describes this entry specified by registerer.
		/// </value>
		public string? Label { get; }

		/// <summary>
		///		Initializes a new instance of <see cref="ExtraExtensionTypeMapping"/> object.
		/// </summary>
		/// <param name="type">The <see cref="ExtensionType"/> for this extra mapping entry.</param>
		/// <param name="label">The arbitrary label which describes this entry specified by registerer.</param>
		public ExtraExtensionTypeMapping(ExtensionType type, string? label)
		{
			this.Type = type;
			this.Label = label;
		}

		/// <inheritdoc />
		public override bool Equals(object? obj)
			=> (obj is ExtraExtensionTypeMapping other) ? this.Equals(other) : false;

		/// <inheritdoc />
		public bool Equals(ExtraExtensionTypeMapping other)
			=> this.Type == other.Type && this.Label == other.Label;

		/// <inheritdoc />
		public override int GetHashCode()
			=> HashCode.Combine(this.Type, this.Label);

		/// <summary>
		///		Returns a value that indicates whether two <see cref="ExtraExtensionTypeMapping" /> objects are equal.
		/// </summary>
		/// <param name="left">The first <see cref="ExtraExtensionTypeMapping" /> to compare.</param>
		/// <param name="right">The second <see cref="ExtraExtensionTypeMapping" /> to compare.</param>
		/// <returns>
		///   <c>true</c> if the two <see cref="ExtraExtensionTypeMapping" /> objects are equal; otherwise, <c>false</c>.
		/// </returns>
		public static bool operator ==(ExtraExtensionTypeMapping left, ExtraExtensionTypeMapping right)
			=> left.Equals(right);

		/// <summary>
		///		Returns a value that indicates whether two <see cref="ExtraExtensionTypeMapping" /> objects are not equal.
		/// </summary>
		/// <param name="left">The first <see cref="ExtraExtensionTypeMapping" /> to compare.</param>
		/// <param name="right">The second <see cref="ExtraExtensionTypeMapping" /> to compare.</param>
		/// <returns>
		///   <c>true</c> if the two <see cref="ExtraExtensionTypeMapping" /> objects are not equal; otherwise, <c>false</c>.
		/// </returns>
		public static bool operator !=(ExtraExtensionTypeMapping left, ExtraExtensionTypeMapping right)
			=> !left.Equals(right);

		/// <summary>
		///		Converts specified <see cref="Int64"/> to <see cref="ExtraExtensionTypeMapping"/> implicitly.
		/// </summary>
		/// <param name="tag">The tag value of <see cref="ExtensionType"/>.</param>
		/// <returns>
		///		An <see cref="ExtraExtensionTypeMapping"/> which has <see cref="ExtensionType"/> with <paramref name="tag"/> and does not have a label.
		/// </returns>
		public static implicit operator ExtraExtensionTypeMapping(long tag)
			=> new ExtraExtensionTypeMapping(new ExtensionType(tag), null);

		/// <summary>
		///		Converts specified <see cref="ExtensionType"/> to <see cref="ExtraExtensionTypeMapping"/> implicitly.
		/// </summary>
		/// <param name="type">The <see cref="ExtensionType"/>.</param>
		/// <returns>
		///		An <see cref="ExtraExtensionTypeMapping"/> which has <paramref name="type"/> and does not have a label.
		/// </returns>
		public static implicit operator ExtraExtensionTypeMapping(ExtensionType type)
			=> new ExtraExtensionTypeMapping(type, null);
	}

}
