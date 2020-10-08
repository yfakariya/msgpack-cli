// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;

namespace MsgPack.Codecs
{
	/// <summary>
	///		Represents single entry of <see cref="ExtensionTypeMappings"/>.
	/// </summary>
	public readonly struct ExtensionTypeMapping : IEquatable<ExtensionTypeMapping>
	{
		private readonly string _name;

		/// <summary>
		///		Gets the unique name of this mapping entry.
		/// </summary>
		/// <value>
		///		The unique name of this mapping entry.
		///		This value is unique in parent <see cref="ExtensionTypeMappings"/>.
		/// </value>
		public string Name => this._name ?? String.Empty;

		/// <summary>
		///		Gets the <see cref="ExtensionType"/> for this primary mapping entry.
		/// </summary>
		/// <value>
		///		The <see cref="ExtensionType"/> for this primary mapping entry.
		///		This value is unique in parent <see cref="ExtensionTypeMappings"/>.
		/// </value>
		public ExtensionType Type { get; }

		private readonly IEnumerable<ExtraExtensionTypeMapping> _extraMappings;

		/// <summary>
		///		Get the collection of <see cref="ExtraExtensionTypeMapping"/> which holds extra mapping used on deserialization for backward compatibility.
		/// </summary>
		/// <value>
		///		The collection of <see cref="ExtraExtensionTypeMapping"/> which holds extra mapping used on deserialization for backward compatibility.
		///		The items are oredered by <see cref="ExtensionType"/> order.
		/// </value>
		public IEnumerable<ExtraExtensionTypeMapping> ExtraMappings => this._extraMappings ?? Enumerable.Empty<ExtraExtensionTypeMapping>();

		internal ExtensionTypeMapping(string name, ExtensionType type, IEnumerable<ExtraExtensionTypeMapping> extraMappings)
		{
			this._name = name;
			this.Type = type;
			this._extraMappings = extraMappings;
		}

		/// <inheritdoc />
		public override bool Equals(object? obj)
			=> (obj is ExtensionTypeMapping other) ? this.Equals(other) : false;

		/// <inheritdoc />
		public bool Equals(ExtensionTypeMapping other)
			=> this.Type == other.Type && this.Name == other.Name && this.ExtraMappings.SequenceEqual(other.ExtraMappings);

		/// <inheritdoc />
		public override int GetHashCode()
		{
			var hashCode = new HashCode();
			hashCode.Add(this.Type);
			hashCode.Add(this.Name);
			foreach (var extra in this.ExtraMappings)
			{
				hashCode.Add(extra);
			}

			return hashCode.ToHashCode();
		}

		/// <summary>
		///		Compares two <see cref="ExtensionTypeMapping"/> are equal.
		/// </summary>
		/// <param name="left">The <see cref="ExtensionTypeMapping"/>.</param>
		/// <param name="right">The <see cref="ExtensionTypeMapping"/>.</param>
		/// <returns>
		///		<c>true</c>, if <paramref name="left"/> and <paramref name="right"/> are equal; <c>false</c>, otherwise.
		/// </returns>
		public static bool operator ==(ExtensionTypeMapping left, ExtensionTypeMapping right)
			=> left.Equals(right);

		/// <summary>
		///		Compares two <see cref="ExtensionTypeMapping"/> are not equal.
		/// </summary>
		/// <param name="left">The <see cref="ExtensionTypeMapping"/>.</param>
		/// <param name="right">The <see cref="ExtensionTypeMapping"/>.</param>
		/// <returns>
		///		<c>true</c>, if <paramref name="left"/> and <paramref name="right"/> are equal; <c>false</c>, otherwise.
		/// </returns>
		public static bool operator !=(ExtensionTypeMapping left, ExtensionTypeMapping right)
			=> !left.Equals(right);
	}

}
