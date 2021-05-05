// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

using System;
using System.Collections.Generic;
using System.Reflection;

namespace MsgPack.Serialization
{
	/// <summary>
	///		Represents compatibility options of serialization runtime.
	/// </summary>
	public sealed class SerializationCompatibilityOptions : ISerializationCompatibilityOptions
	{
		/// <summary>
		///		Gets or sets a value indicating whether <c>System.Runtime.Serialization.DataMemberAttribute.Order</c> should be started with 1 instead of 0.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if <c>System.Runtime.Serialization.DataMemberAttribute.Order</c> should be started with 1 instead of 0; otherwise, <c>false</c>.
		/// 	Default is <c>false</c>.
		/// </value>
		/// <remarks>
		///		Using this value, you can switch between MessagePack for CLI and ProtoBuf.NET seamlessly.
		/// </remarks>
		public bool OneBoundDataMemberOrder { get; set; }

		/// <summary>
		///		Gets or sets the <see cref="PackerCompatibilityOptions"/>.
		/// </summary>
		/// <value>
		///		The <see cref="PackerCompatibilityOptions"/>. The default is <see cref="F:PackerCompatibilityOptions.Classic"/>.
		/// </value>
		/// <remarks>
		///		<note>
		///			Changing this property value does not affect already built serializers -- especially built-in (default) serializers.
		///			You must specify <see cref="T:PackerCompatibilityOptions"/> enumeration to the constructor of <see cref="SerializerProvider"/> to
		///			change built-in serializers' behavior.
		///		</note>
		/// </remarks>
		public PackerCompatibilityOptions PackerCompatibilityOptions { get; set; }

		/// <summary>
		///		Gets or sets a value indicating whether serializer generator ignores packability interfaces for collections or not.
		/// </summary>
		/// <value>
		///		<c>true</c> if serializer generator ignores packability interfaces for collections; otherwise, <c>false</c>. The default is <c>false</c>.
		/// </value>
		/// <remarks>
		///		Historically, MessagePack for CLI ignored packability interfaces (<see cref="IPackable"/>, <see cref="IUnpackable"/>, 
		///		<see cref="IAsyncPackable"/> and <see cref="IAsyncUnpackable"/>) for collection which implements <see cref="IEquatable{T}"/> (except <see cref="String"/> and its kinds).
		///		As of 0.7, the generator respects such interfaces even if the target type is collection.
		///		Although this behavior is desirable and correct, setting this property <c>true</c> turn out the new behavior for backward compatibility.
		/// </remarks>
		public bool IgnorePackabilityForCollection { get; set; }

		/// <summary>
		///		Gets or sets a value indicating whether the serializer generator should serialize types that implement IEnumerable but do not have an Add method.
		/// </summary>
		/// <value>
		///		<c>true</c> if serializer generator should serialize a type implementing <see cref="IEnumerable"/> as a normal type if a public <c>Add</c> method is not found; otherwise, <c>false</c>. The default is <c>true</c>.
		/// </value>
		/// <remarks>
		///		Historically, MessagePack for CLI always tried to serialize any type that implemented <see cref="IEnumerable"/> as a collection, throwing an exception
		///		if an <c>Add</c> method could not be found. However, for types that implement <see cref="IEnumerable"/> but don't have an <c>Add</c> method the generator will now
		///		serialize the type as a non-collection type. To restore the old behavior for backwards compatibility, set this option to <c>false</c>.
		/// </remarks>
		public bool AllowNonCollectionEnumerableTypes { get; set; }

		/// <summary>
		///		Gets or sets a value indicating whether the serializer generator generates serializer types even when the generator determines that feature complete serializer cannot be generated due to lack of some requirement.
		/// </summary>
		/// <value>
		///		<c>true</c> if the serializer generator generates serializer types even when the generator determines that feature complete serializer cannot be generated due to lack of some requirement; otherwise, <c>false</c>. The default is <c>false</c>.
		/// </value>
		/// <remarks>
		///		Currently, the lack of constructor (default or parameterized) or lack of settable members are considerd as "cannot generate feature complete serializer".
		///		Therefore, you can get serialization only serializer if this property is set to <c>true</c>.
		///		This is useful for logging, telemetry injestion, or so.
		///		You can investigate serializer capability via <see cref="MessagePackSerializer.Capabilities"/> property.
		/// </remarks>
		public bool AllowAsymmetricSerializer { get; set; }

		bool ISerializationCompatibilityOptions.AllowsNonCollectionEnumerableTypes => this.AllowNonCollectionEnumerableTypes;
		bool ISerializationCompatibilityOptions.IgnoresAdapterForCollection => this.IgnorePackabilityForCollection;
		bool ISerializationCompatibilityOptions.UsesOneBoundDataMemberOrder => this.OneBoundDataMemberOrder;

#warning TODO: IMPL
		IEnumerable<Func<Type, ISerializerGenerationOptions, bool>> ISerializationCompatibilityOptions.SerializableInterfaceDetectors => throw new NotImplementedException();

#warning TODO: IMPL
		IEnumerable<Func<Type, ISerializerGenerationOptions, bool>> ISerializationCompatibilityOptions.DeserializableInterfaceDetectors => throw new NotImplementedException();

#warning TODO: IMPL
		Func<IEnumerable<CustomAttributeData>, IEnumerable<CustomAttributeData>, MessagePackMemberAttributeData?> ISerializationCompatibilityOptions.MessagePackMemberAttributeCompatibilityProvider => throw new NotImplementedException();

#warning TODO: IMPL
		Func<IEnumerable<CustomAttributeData>, IEnumerable<CustomAttributeData>, MessagePackIgnoreAttributeData?> ISerializationCompatibilityOptions.IgnoringAttributeCompatibilityProvider => throw new NotImplementedException();

		// TODO: CheckNilImplicationInConstructorDeserialization

		internal SerializationCompatibilityOptions()
		{
			this.PackerCompatibilityOptions = PackerCompatibilityOptions.None;
			this.IgnorePackabilityForCollection = false;
			this.AllowNonCollectionEnumerableTypes = true;
			this.AllowAsymmetricSerializer = false;
		}
	}
}
