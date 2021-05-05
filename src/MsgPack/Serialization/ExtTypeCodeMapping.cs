// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MsgPack.Codecs;

namespace MsgPack.Serialization
{
	/// <summary>
	///		Implements mapping table between known ext type codes and names.
	/// </summary>
	/// <remarks>
	///		Well-known (pre-defined) ext type names are defined in <see cref="KnownExtTypeName"/>, and their default mapped codes are found in <see cref="KnownExtTypeCode"/>.
	/// </remarks>
	/// <threadsafety instance="true" static="true" />
	public sealed class ExtTypeCodeMapping : IEnumerable<KeyValuePair<string, byte>>
	{
		private readonly object _syncRoot;
		private readonly ExtensionTypeMappings _mappings;

		/// <summary>
		///		Gets a mapped byte to the specified ext type name.
		/// </summary>
		/// <param name="name">The name of the ext type.</param>
		/// <returns>
		///		The byte code for specified ext type in the current context.
		/// </returns>
		/// <exception cref="ArgumentNullException"><paramref name="name"/> is <c>null</c>.</exception>
		/// <exception cref="ArgumentException"><paramref name="name"/> is empty.</exception>
		/// <exception cref="KeyNotFoundException"><paramref name="name"/> is not registered as known ext type name.</exception>
		public byte this[string name]
		{
			get
			{
				ValidateName(name);

				lock (this._syncRoot)
				{
					if (!this._mappings.InternalMappings.TryGetValue(name, out var mapping))
					{
						throw new KeyNotFoundException(
							String.Format(CultureInfo.CurrentCulture, "Ext type '{0}' is not found.", name)
						);
					}

					return (byte)mapping.Type.Tag;
				}
			}
		}

		internal ExtTypeCodeMapping()
		{
			this._syncRoot = new object();
			this._mappings = new ExtensionTypeMappings(new Dictionary<string, ExtensionTypeMapping>());
		}

		/// <summary>
		///		Adds the known ext type mapping.
		/// </summary>
		/// <param name="name">The name of the ext type.</param>
		/// <param name="typeCode">The ext type code to be mapped.</param>
		/// <returns>
		///		<c>true</c> if <paramref name="name"/> AND <paramref name="typeCode"/> were not registered and then newly registered; <c>false</c>, otherwise.
		/// </returns>
		/// <exception cref="ArgumentNullException"><paramref name="name"/> is <c>null</c>.</exception>
		/// <exception cref="ArgumentException"><paramref name="name"/> is empty.</exception>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="typeCode"/> is greater than 0x7F.</exception>
		public bool Add(string name, byte typeCode)
		{
			ValidateName(name);
			ValidateTypeCode(typeCode);
			return this.AddInternal(name, typeCode);
		}

		private bool AddInternal(string name, byte typeCode)
		{
			lock (this._syncRoot)
			{
				return this._mappings.InternalMappings.TryAdd(name, new ExtensionTypeMapping(name, new ExtensionType(typeCode), Enumerable.Empty<ExtraExtensionTypeMapping>()));
			}
		}

		/// <summary>
		///		Removes the mapping with specified name.
		/// </summary>
		/// <param name="name">The name of the ext type.</param>
		/// <returns>
		///		<c>true</c> if <paramref name="name"/> was registered and has been removed successfully; <c>false</c>, otherwise.
		/// </returns>
		/// <exception cref="ArgumentNullException"><paramref name="name"/> is <c>null</c>.</exception>
		/// <exception cref="ArgumentException"><paramref name="name"/> is empty.</exception>
		public bool Remove(string name)
		{
			ValidateName(name);

			lock (this._syncRoot)
			{
				return this._mappings.InternalMappings.Remove(name);
			}
		}

		/// <summary>
		///		Removes the mapping with specified code.
		/// </summary>
		/// <param name="typeCode">The type code of the ext type.</param>
		/// <returns>
		///		<c>true</c> if <paramref name="typeCode"/> was registered and has been removed successfully; <c>false</c>, otherwise.
		/// </returns>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="typeCode"/> is greater than 0x7F.</exception>
		public bool Remove(byte typeCode)
		{
			ValidateTypeCode(typeCode);

			lock (this._syncRoot)
			{
				// This is not fast but it is OK because removal should be rare.

				var mappings = this._mappings.Where(m => m.Type.Tag == typeCode || m.ExtraMappings.Any(x => x.Type.Tag == typeCode)).Select(x => x.Name);
				var found = false;
				foreach (var key in mappings)
				{
					this._mappings.InternalMappings.Remove(key);
					found = true;
				}

				return found;
			}
		}

		/// <summary>
		///		Clears all mappings.
		/// </summary>
		public void Clear()
		{
			lock (this._syncRoot)
			{
				this._mappings.InternalMappings.Clear();
			}
		}

		/// <summary>
		///		Returns an enumerator that iterates through the collection.
		/// </summary>
		/// <returns>
		///		A <see cref="T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.
		/// </returns>
		/// <remarks>
		///		This method causes internal collection copying, so this makes O(n) time.
		/// </remarks>
		public IEnumerator<KeyValuePair<string, byte>> GetEnumerator()
		{
			foreach (var mapping in this._mappings)
			{
				yield return new KeyValuePair<string, byte>(mapping.Name, (byte)mapping.Type.Tag);
			}
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		private static void ValidateName(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}

			if (name.Length == 0)
			{
				throw new ArgumentException(String.Format(CultureInfo.CurrentCulture, "A parameter cannot be empty."), "name");
			}
		}

		private static void ValidateTypeCode(byte typeCode)
		{
			if (typeCode > 0x7F)
			{
				throw new ArgumentOutOfRangeException("typeCode", "Ext type code must be between 0 and 0x7F.");
			}
		}
	}
}
