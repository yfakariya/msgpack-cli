// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MsgPack.Codecs
{
	/// <summary>
	///		A builder object for <see cref="ExtensionTypeMappings"/>.
	/// </summary>
	public sealed class ExtensionTypeMappingsBuilder : IEnumerable<ExtensionTypeMapping>
	{
		private static readonly Action<ExtensionType> None = _ => { };

		private readonly Action<ExtensionType> _customValidator;
		private readonly Dictionary<string, ExtensionTypeMapping> _mapping;
		private readonly Dictionary<ExtensionType, (string Name, bool IsPrimary, string? Label)> _reverseIndex;

		/// <summary>
		///		Initializes a new instance of <see cref="ExtensionTypeMappingsBuilder"/> object.
		/// </summary>
		/// <param name="initialCapacity">The initial capacity of internal collections.</param>
		/// <param name="customValidator">The delegate which validates <see cref="ExtensionType"/> value for the codec. The validator should throw <see cref="ArgumentOutOfRangeException" /> for validation error.</param>
		public ExtensionTypeMappingsBuilder(int initialCapacity = 0, Action<ExtensionType> customValidator = null!)
		{
			this._customValidator = customValidator ?? None;
			this._mapping = new Dictionary<string, ExtensionTypeMapping>(initialCapacity);
			this._reverseIndex = new Dictionary<ExtensionType, (string Name, bool IsPrimary, string? Label)>(initialCapacity);
		}

		internal ExtensionTypeMappings Build()
			=> new ExtensionTypeMappings(this._mapping);

		/// <summary>
		///		Tries to add specified mapping without extra mappings.
		/// </summary>
		/// <param name="name">The unique name of the mapping.</param>
		/// <param name="type">The unique extension type of the mapping. This value will be used on both of serialization and deserialization.</param>
		/// <returns>
		///		<c>true</c> if they are added successfully; <c>false</c>, otherwise.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		///		<paramref name="name"/> is <c>null</c>.
		/// </exception>
		/// <exception cref="ArgumentException">
		///		<paramref name="name"/> is empty string.
		/// </exception>
		/// <exception cref="ArgumentOutOfRangeException">
		///		<paramref name="type"/> is invalid for current codec.
		/// </exception>
		public bool TryAdd(string name, ExtensionType type)
		{
			this._customValidator(type);

			if (!this._reverseIndex.TryAdd(type, (Ensure.NotNullNorEmpty(name), IsPrimary: true, Label: null)))
			{
				return false;
			}

			if (!this._mapping.TryAdd(name, new ExtensionTypeMapping(name, type, Array.Empty<ExtraExtensionTypeMapping>())))
			{
				this._reverseIndex.Remove(type);
				return false;
			}

			return true;
		}

		/// <summary>
		///		Tries to add specified mapping with extra mappings.
		/// </summary>
		/// <param name="name">The unique name of the mapping.</param>
		/// <param name="type">The unique extension type of the mapping. This value will be used both of serialization and deserialization.</param>
		/// <param name="extras">
		///		The extra mappings. 
		///		These values will be used on deserlialization to handle backward compatibility for previous mapping definition.
		///		Note that all items must have unique <see cref="ExtensionType"/> for whole <see cref="ExtensionTypeMappingsBuilder"/>.
		///	</param>
		/// <returns>
		///		<c>true</c> if they are added successfully; <c>false</c>, otherwise.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		///		<paramref name="name"/> is <c>null</c>.
		/// </exception>
		/// <exception cref="ArgumentException">
		///		<paramref name="name"/> is empty string.
		/// </exception>
		/// <exception cref="ArgumentOutOfRangeException">
		///		<paramref name="type"/> is invalid for current codec.
		/// </exception>
		public bool TryAdd(string name, ExtensionType type, params ExtraExtensionTypeMapping[] extras)
		{
			this._customValidator(type);
			foreach (var extra in extras ?? Enumerable.Empty<ExtraExtensionTypeMapping>())
			{
				this._customValidator(extra.Type);
			}

			if (!this._reverseIndex.TryAdd(type, (Ensure.NotNullNorEmpty(name), IsPrimary: true, Label: null)))
			{
				return false;
			}

			var extraEntries = Array.Empty<ExtraExtensionTypeMapping>();
			if (extras != null)
			{
				extraEntries = new ExtraExtensionTypeMapping[extras.Length];

				for (var i = 0; i < extras.Length; i++)
				{
					if (!this._reverseIndex.TryAdd(extras[i].Type, (name, IsPrimary: false, Label: extras[i].Label)))
					{
						// Roll back
						this._reverseIndex.Remove(type);
						for (var j = i - 1; j >= 0; j--)
						{
							this._reverseIndex.Remove(extras[j].Type);
						}

						return false;
					}

					extraEntries[i] = extras[i];
				}

				Array.Sort(extraEntries);
			}

			if (!this._mapping.TryAdd(name, new ExtensionTypeMapping(name, type, extraEntries)))
			{
				// Roll back
				this._reverseIndex.Remove(type);
				if (extras != null)
				{
					for (var i = 0; i < extras.Length; i++)
					{
						this._reverseIndex.Remove(extras[i].Type);
					}
				}

				return false;
			}

			return true;
		}

		/// <summary>
		///		Tries to remove specified named mapping.
		/// </summary>
		/// <param name="name">The name of the mapping.</param>
		/// <returns>
		///		<c>true</c> if the mapping was found and removed successfully; <c>false</c>, otherwise.
		/// </returns>
		/// <remarks>
		///		The related extra types are also removed.
		/// </remarks>
		public bool Remove(string name)
		{
			if (name == null)
			{
				return false;
			}

			if (!this._mapping.Remove(name, out var entry))
			{
				return false;
			}

			return this._reverseIndex.Remove(entry.Type);
		}

		/// <summary>
		///		Tries to remove specified extension type mapping.
		/// </summary>
		/// <param name="type">The extension type of the mapping. This value can be primary mapping value or one of extra mapping values.</param>
		/// <returns>
		///		<c>true</c> if the mapping was found and removed successfully; <c>false</c>, otherwise.
		/// </returns>
		/// <remarks>
		///		The related primary type and extra types are also removed.
		/// </remarks>
		public bool Remove(ExtensionType type)
		{
			if (!this._reverseIndex.Remove(type, out var entry))
			{
				return false;
			}

			return this._mapping.Remove(entry.Name);
		}

		/// <summary>
		///		Determines whether the specified name is already registered in this mappings or not.
		/// </summary>
		/// <param name="name">The name of the mapping.</param>
		/// <returns>
		///		<c>true</c> if the mapping which has specified name is found; <c>false</c>, otherwise.
		/// </returns>
		public bool Contains(string name)
			=> String.IsNullOrEmpty(name) ? false : this._mapping.ContainsKey(name);

		/// <summary>
		///		Determines whether the specified extension type is already registered in this mappings or not.
		/// </summary>
		/// <param name="type">The type of the mapping.</param>
		/// <returns>
		///		<c>true</c> if the mapping which has specified extension type as primary type or one of extra types is found; <c>false</c>, otherwise.
		/// </returns>
		public bool Contains(ExtensionType type)
			=> this._reverseIndex.ContainsKey(type);

		/// <summary>
		///		Determines whether the specified extension type is registered as primary mapping in this mappings or not.
		/// </summary>
		/// <param name="type">The type of the mapping.</param>
		/// <returns>
		///		<c>true</c> if the mapping which has specified extension type as primary maping is found; <c>false</c>, otherwise.
		/// </returns>
		public bool IsPrimary(ExtensionType type)
			=> this._reverseIndex.TryGetValue(type, out var entry) && entry.IsPrimary;

		/// <summary>
		///		Gets the related primary extension type for the specified name.
		/// </summary>
		/// <param name="name">The name of the mapping.</param>
		/// <returns>
		///		<see cref="ExtensionType"/>.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		///		<paramref name="name"/> is <c>null</c>.
		/// </exception>
		/// <exception cref="ArgumentException">
		///		<paramref name="name"/> is empty string.
		/// </exception>
		/// <exception cref="KeyNotFoundException">
		///		<paramref name="name"/> is not registered.
		/// </exception>
		public ExtensionType GetExtensionType(string name)
		{
			if (!this._mapping.TryGetValue(Ensure.NotNullNorEmpty(name), out var result))
			{
				Throw.UnknownExtensionTypeMappingName(name);
			}

			return result.Type;
		}

		/// <summary>
		///		Gets the all extra extension types for the specified name.
		/// </summary>
		/// <param name="name">The name of the mapping.</param>
		/// <returns>
		///		A collection of <see cref="ExtraExtensionTypeMapping"/>.
		///		Note that the order of the collection is undefined.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		///		<paramref name="name"/> is <c>null</c>.
		/// </exception>
		/// <exception cref="ArgumentException">
		///		<paramref name="name"/> is empty string.
		/// </exception>
		/// <exception cref="KeyNotFoundException">
		///		<paramref name="name"/> is not registered.
		/// </exception>
		public IEnumerable<ExtraExtensionTypeMapping> GetExtraMappings(string name)
		{
			if (!this._mapping.TryGetValue(Ensure.NotNullNorEmpty(name), out var result))
			{
				Throw.UnknownExtensionTypeMappingName(name);
			}

			return result.ExtraMappings;
		}

		/// <inheritdoc />
		public IEnumerator<ExtensionTypeMapping> GetEnumerator()
			=> this._mapping.Values.GetEnumerator();

		/// <inheritdoc />
		IEnumerator IEnumerable.GetEnumerator()
			=> this.GetEnumerator();
	}
}
