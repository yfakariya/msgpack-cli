// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Microsoft.VisualBasic.CompilerServices;
using MsgPack.Internal;

namespace MsgPack.Serialization
{
#warning TODO: Revise all options are used.

	/// <summary>
	///		A builder object for <see cref="SerializationOptions"/> which defines options for each serialization operations.
	/// </summary>
	/// <seealso cref="SerializationOptions"/>
	public sealed class SerializationOptionsBuilder
	{
		/// <summary>
		///		Gets the maximum depth of the serialized object tree.
		/// </summary>
		/// <value>
		///		The maximum depth of the serialized object tree. Default is <c>100</c>.
		/// </value>
		public int MaxDepth { get; private set; } = OptionsDefaults.MaxDepth;

		/// <summary>
		///		Gets the default string encoding for string members or map keys which are not specified explicitly.
		/// </summary>
		/// <value>
		///		The default string encoding for string members or map keys which are not specified explicitly.
		///		Default value is <c>null</c>, which means using default encoding of underlying codec.
		/// </value>
		public Encoding? DefaultStringEncoding { get; private set; }

		/// <summary>
		///		Gets the preferred <see cref="SerializationMethod"/> which will be used members which serialization methods are not derived from their attributes nor member types.  
		/// </summary>
		/// <value>
		///		The preferred <see cref="SerializationMethod"/> which will be used members which serialization methods are not derived from their attributes nor member types.  
		///		Default is <c>null</c>, which means using default method of underlying codec.
		/// </value>
		public SerializationMethod? PreferredSerializationMethod { get; private set; } = OptionsDefaults.PreferredSerializationMethod;

		/// <summary>
		///		Initializes a new instance of <see cref="SerializationOptionsBuilder"/> class.
		/// </summary>
		public SerializationOptionsBuilder() { }

		/// <summary>
		///		Creates a new instance of <see cref="SerializationOptions"/> object from current state of this instance.
		/// </summary>
		/// <returns>A new instance of <see cref="SerializationOptions"/> object.</returns>
		public SerializationOptions Create()
			=> new SerializationOptions(this);

		/// <summary>
		///		Indicates the maximum depth of the serialized object tree to the default value.
		/// </summary>
		/// <returns>This <see cref="SerializationOptionsBuilder"/> instance.</returns>
		/// <remarks>
		///		This method resets <see cref="MaxDepth"/> to default state.
		///		It is not required to call this method normally, but you can use this method to clarify option settings.
		/// </remarks>
		public SerializationOptionsBuilder UseDefaultMaxDepth()
			=> this.UseMaxDepth(OptionsDefaults.MaxDepth);

		/// <summary>
		///		Sets the maximum depth of the serialized object tree.
		/// </summary>
		/// <param name="value">A value to be set.</param>
		/// <returns>This <see cref="SerializationOptionsBuilder"/> instance.</returns>
		/// <exception cref="System.ArgumentNullException">
		///		<paramref name="value"/> is less than or equal to <c>0</c>, or exceeds <c>0x7FEFFFFF</c>.
		/// </exception>
		public SerializationOptionsBuilder UseMaxDepth(int value)
		{
			this.MaxDepth = Ensure.IsBetween(value, 1, OptionsDefaults.MaxMultiByteCollectionLength); ;
			return this;
		}

		/// <summary>
		///		Indicates the default string encoding for string members or map keys to use default encoding of the codec.
		/// </summary>
		/// <returns>This <see cref="SerializationOptionsBuilder"/> instance.</returns>
		/// <remarks>
		///		This method resets <see cref="DefaultStringEncoding"/> to default state.
		///		It is not required to call this method normally, but you can use this method to clarify option settings.
		/// </remarks>
		public SerializationOptionsBuilder UseCodecDefaultStringEncoding()
		{
			this.DefaultStringEncoding = null;
			return this;
		}

		/// <summary>
		///		Sets the default string encoding for string members or map keys which are not specified explicitly.
		/// </summary>
		/// <param name="value">An <see cref="Encoding"/> to use encode/decode string value.</param>
		/// <returns>This <see cref="SerializationOptionsBuilder"/> instance.</returns>
		/// <exception cref="System.ArgumentNullException"><paramref name="value"/> is <c>null</c>.</exception>
		/// <remarks>
		///		This method should be called only when you needs to interoperability with system which uses non-default encoding for the codec.
		/// </remarks>
		public SerializationOptionsBuilder UseCustomDefaultStringEncoding(Encoding value)
		{
			this.DefaultStringEncoding = Ensure.NotNull(value);
			return this;
		}

		/// <summary>
		///		Indicates the preferred <see cref="SerializationMethod"/> to use codec's default.
		/// </summary>
		/// <returns>This <see cref="SerializationOptionsBuilder"/> instance.</returns>
		/// <remarks>
		///		This method resets <see cref="PreferredSerializationMethod"/> to default state.
		///		It is not required to call this method normally, but you can use this method to clarify option settings.
		/// </remarks>
		public SerializationOptionsBuilder UseCodecDefaultPreferredSerializationMethod()
		{
			this.PreferredSerializationMethod = null;
			return this;
		}

		/// <summary>
		///		Sets the preferred <see cref="SerializationMethod"/> which will be used members which serialization methods are not derived from their attributes nor member types.  
		/// </summary>
		/// <returns>This <see cref="SerializationOptionsBuilder"/> instance.</returns>
		/// <exception cref="System.ArgumentOutOfRangeException"><paramref name="value"/> is not known <see cref="SerializationMethod"/> value.</exception>
		/// <remarks>
		///		Note that preferred <see cref="SerializationMethod"/> may cause error when the codec does not support the value.
		/// </remarks>
		public SerializationOptionsBuilder UseCustomPreferredSerializationMethod(SerializationMethod value)
		{
			switch (value)
			{
				case SerializationMethod.Array:
				case SerializationMethod.Map:
				{
					break;
				}
				default:
				{
					Throw.UndefinedEnumMember(value);
					break; // never
				}
			}
			this.PreferredSerializationMethod = value;
			return this;
		}
	}
}
