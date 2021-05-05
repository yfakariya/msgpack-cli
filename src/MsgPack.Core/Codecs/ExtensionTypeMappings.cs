// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

using System.Collections;
using System.Collections.Generic;

namespace MsgPack.Codecs
{
	/// <summary>
	///		Implements mapping table between known extension types and their names.
	/// </summary>
	/// <remarks>
	///		Well-known (pre-defined) ext type names are defined in <c>KnownExtensionTypeNames</c>, and their default mapped codes are found in <c>KnownExtensionTypeCodes</c>.
	///		They should be defined in codec assemblies if available.
	///		<para>
	///			Initially, this mapping is constructed as system default.
	///			All built-in serializers (and possibly all custom serializers) which use extension type to serialize objects uses this mapping to find actual extension type code.
	///			This mapping enables application developers change actual extension type code for them.
	///		</para>
	///		<para>
	///			This mapping also supports backward compability.
	///			For example, assume that you have application defined extension type code 123 for half-precision floating point value,
	///			and then the codec specification become supporting the half type with system defined extension type code -123.
	///			If so, you can register the mapping to use -123 for serialization to improve interoperability,
	///			while you also keep using 123 for deserialization to handle serialized value by legacy serializer.
	///		</para>
	/// </remarks>
	public sealed class ExtensionTypeMappings : IEnumerable<ExtensionTypeMapping>
	{
		private readonly Dictionary<string, ExtensionTypeMapping> _mappings;

		/// <summary>
		///		Gets the related primary extension type for the specified name.
		/// </summary>
		/// <param name="name">The name of the mapping.</param>
		/// <returns>
		///		<see cref="ExtensionType"/>.
		/// </returns>
		/// <exception cref="System.ArgumentNullException">
		///		<paramref name="name"/> is <c>null</c>.
		/// </exception>
		/// <exception cref="System.ArgumentException">
		///		<paramref name="name"/> is empty string.
		/// </exception>
		/// <exception cref="KeyNotFoundException">
		///		<paramref name="name"/> is not registered.
		/// </exception>
		public ExtensionType this[string name]
		{
			get
			{
				if (!this._mappings.TryGetValue(Ensure.NotNullNorEmpty(name), out var result))
				{
					Throw.UnknownExtensionTypeMappingName(name);
				}

				return result.Type;
			}
		}

		internal ExtensionTypeMappings(Dictionary<string, ExtensionTypeMapping> mappings)
		{
			this._mappings = mappings;
		}

		/// <inheritdoc />
		public Enumerator GetEnumerator()
			=> new Enumerator(this._mappings.Values.GetEnumerator());

		/// <inheritdoc />
		IEnumerator<ExtensionTypeMapping> IEnumerable<ExtensionTypeMapping>.GetEnumerator()
			=> this.GetEnumerator();

		/// <inheritdoc />
		IEnumerator IEnumerable.GetEnumerator()
			=> this.GetEnumerator();

		/// <summary>
		///		Implements enumerator for <see cref="ExtensionTypeMappings"/>.
		/// </summary>
		public struct Enumerator : IEnumerator<ExtensionTypeMapping>
		{
			private Dictionary<string, ExtensionTypeMapping>.ValueCollection.Enumerator _enumerator;

			/// <inheritdoc />
			public ExtensionTypeMapping Current => this._enumerator.Current;

			/// <inheritdoc />
			object? IEnumerator.Current => this.Current;

			internal Enumerator(Dictionary<string, ExtensionTypeMapping>.ValueCollection.Enumerator enumerator)
			{
				this._enumerator = enumerator;
			}

			/// <inheritdoc />
			public void Dispose()
			{
				var enumerator = this._enumerator;
				enumerator.Dispose();
				this._enumerator = enumerator;
			}

			/// <inheritdoc />
			public bool MoveNext()
			{
				var enumerator = this._enumerator;
				var result = enumerator.MoveNext();
				this._enumerator = enumerator;
				return result;
			}

			/// <inheritdoc />
			void IEnumerator.Reset()
			{
				IEnumerator<ExtensionTypeMapping> enumerator = this._enumerator;
				enumerator.Reset();
				this._enumerator = (Dictionary<string, ExtensionTypeMapping>.ValueCollection.Enumerator)enumerator;
			}
		}
	}

}
