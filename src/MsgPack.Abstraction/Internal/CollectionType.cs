// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

using System;
using System.Runtime.CompilerServices;

namespace MsgPack.Internal
{
	/// <summary>
	///		Represents collection type.
	/// </summary>
	public readonly struct CollectionType : IEquatable<CollectionType>
	{
		/// <summary>
		///		Gets a value which represents the current type is not a collection.
		/// </summary>
		public static CollectionType None => default;

		/// <summary>
		///		Gets a value which represents the current type is a <c>null</c> value.
		/// </summary>
		public static CollectionType Null => new CollectionType(1);

		/// <summary>
		///		Gets a value which represents the current type is an array.
		/// </summary>
		public static CollectionType Array => new CollectionType(2);

		/// <summary>
		///		Gets a value which represents the current type is a map.
		/// </summary>
		public static CollectionType Map => new CollectionType(3);

		private readonly int _type;

		/// <summary>
		///		Gets a value whether this type represents a <c>null</c> or not.
		/// </summary>
		/// <value>
		///		<c>true</c> if this type represents a <c>null</c>; <c>false</c>, otherwise.
		/// </value>
		public bool IsNull
		{
			[MethodImpl(MethodImplOptionsShim.AggressiveInlining)]
			get => this._type == 1;
		}

		/// <summary>
		///		Gets a value whether this type represents an array or not.
		/// </summary>
		/// <value>
		///		<c>true</c> if this type represents an array; <c>false</c>, otherwise.
		/// </value>
		public bool IsArray
		{
			[MethodImpl(MethodImplOptionsShim.AggressiveInlining)]
			get => this._type == 2;
		}

		/// <summary>
		///		Gets a value whether this type represents a map or not.
		/// </summary>
		/// <value>
		///		<c>true</c> if this type represents a map; <c>false</c>, otherwise.
		/// </value>
		public bool IsMap
		{
			[MethodImpl(MethodImplOptionsShim.AggressiveInlining)]
			get => this._type == 3;
		}

		/// <summary>
		///		Gets a value whether this type represents a non collection object or not.
		/// </summary>
		/// <value>
		///		<c>true</c> if this type represents a non collection object; <c>false</c>, otherwise.
		/// </value>
		public bool IsNone
		{
			[MethodImpl(MethodImplOptionsShim.AggressiveInlining)]
			get => this._type == 0;
		}

		private CollectionType(int type)
		{
			this._type = type;
		}

		/// <inheritdoc />
		public override bool Equals(object? obj)
			=> obj is CollectionType other ? this.Equals(other) : false;

		/// <inheritdoc />
		public bool Equals(CollectionType other)
			=> this._type == other._type;

		/// <inheritdoc />
		public override int GetHashCode()
			=> this._type;

		/// <inheritdoc />
		public override string ToString()
			=> this._type switch
			{
				1 => "Array",
				2 => "Map",
				_ => String.Empty
			};

		/// <summary>
		///		Returns a value that indicates whether two <see cref="CollectionType" /> objects are equal.
		/// </summary>
		/// <param name="left">The first <see cref="CollectionType" /> to compare.</param>
		/// <param name="right">The second <see cref="CollectionType" /> to compare.</param>
		/// <returns>
		///   <c>true</c> if the two <see cref="CollectionType" /> objects are equal; otherwise, <c>false</c>.
		/// </returns>
		public static bool operator ==(CollectionType left, CollectionType right)
			=> left.Equals(right);

		/// <summary>
		///		Returns a value that indicates whether two <see cref="CollectionType" /> objects are not equal.
		/// </summary>
		/// <param name="left">The first <see cref="CollectionType" /> to compare.</param>
		/// <param name="right">The second <see cref="CollectionType" /> to compare.</param>
		/// <returns>
		///   <c>true</c> if the two <see cref="CollectionType" /> objects are not equal; otherwise, <c>false</c>.
		/// </returns>
		public static bool operator !=(CollectionType left, CollectionType right)
			=> !left.Equals(right);
	}
}
