// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

using System;
using System.ComponentModel;

namespace MsgPack.Serialization
{
	/// <summary>
	///		Defines dictionary (map) based serialization options.
	/// </summary>
	/// <remarks>
	///		These options do NOT affect serialization of <see cref="System.Collections.IDictionary"/> 
	///		and <see cref="System.Collections.Generic.IDictionary{TKey, TValue}"/>.
	///		The option only affect dictionary (map) based serialization which can be enabled via <see cref="SerializerProvider.SerializationMethod"/>.
	/// </remarks>
	public sealed class DictionarySerializationOptions : IDictionarySerializationOptions
	{
		bool IDictionarySerializationOptions.OmitsNullEntries => this.OmitNullEntry;
		Func<string, string> IDictionarySerializationOptions.KeyTransformer => this.KeyTransformer ?? KeyNameTransformers.AsIs;

		/// <summary>
		///		Gets or sets a value indicating whether omit key-value entry itself when the value is <c>null</c>.
		/// </summary>
		/// <value>
		///		<c>true</c> if key-value entry itself when the value is <c>null</c>; otherwise, <c>false</c>.
		///		The default is <c>false</c>.
		/// </value>
		/// <remarks>
		///		When the value is <c>false</c>, null value entry is emitted as following (using JSON syntax for easy visualization):
		///		<code><pre>
		///		{ "Foo": null }
		///		</pre></code>
		///		else, the value is <c>true</c>, null value entry is ommitted as following:
		///		<code><pre>
		///		{}
		///		</pre></code>
		/// </remarks>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool OmitNullEntry
		{
			get;
			[Obsolete("Use SerializationContextBuilder.ConfigureDictionaryOptions() method with DictionarySerializationOptionsBuilder.OmitNullEntry() method instead.")]
			set;
		}

		/// <summary>
		///		Gets or sets a key name handler which enables dictionary key name customization.
		/// </summary>
		/// <value>
		///		A key name handler which enables dictionary key name customization.
		///		The default value is <c>null</c>, which indicates that key name is not transformed.
		/// </value>
		/// <see cref="DictionaryKeyTransformers"/>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public Func<string, string>? KeyTransformer
		{
			get;
			[Obsolete("Use SerializationContextBuilder.ConfigureDictionaryOptions() method with DictionarySerializationOptionsBuilder.SetKeyTransformer() method instead.")]
			set;
		}
	}

}
