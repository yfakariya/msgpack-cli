// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MsgPack.Serialization
{
	/// <summary>
	///		Repository of known concrete collection type for abstract collection type.
	/// </summary>
	[Obsolete(
		Obsoletion.UseBuilder.Message
#if FEATURE_ADVANCED_OBSOLETE
		, DiagId = Obsoletion.UseBuilder.DiagId
		, Url = Obsoletion.UseBuilder.Url
#endif // FEATURE_ADVANCED_OBSOLETE
	)]
	public sealed class DefaultConcreteTypeRepository : IDefaultConcreteTypeRepository
	{
		private readonly DefaultConcreteTypeRepositoryBuilder _underlying;

		internal DefaultConcreteTypeRepository(Dictionary<RuntimeTypeHandle, object> original)
		{
			this._underlying = new DefaultConcreteTypeRepositoryBuilder(new TypeKeyRepository(original));
		}

		/// <summary>
		///		Gets the default type for the collection.
		/// </summary>
		/// <param name="abstractCollectionType">Type of the abstract collection.</param>
		/// <returns>
		///		Type of default concrete collection.
		///		If concrete collection type of <paramref name="abstractCollectionType"/>, then returns <c>null</c>.
		/// </returns>
		/// <exception cref="System.ArgumentNullException">
		///		<paramref name="abstractCollectionType"/> is <c>null</c>.
		/// </exception>
		/// <remarks>
		///		By default, following types are registered:
		///		<list type="table">
		///			<listheader>
		///				<term>Abstract Collection Type</term>
		///				<description>Concrete Default Collection Type</description>
		///			</listheader>
		///			<item>
		///				<term><see cref="IEnumerable{T}"/></term>
		///				<description><see cref="List{T}"/></description>
		///			</item>
		///			<item>
		///				<term><see cref="ICollection{T}"/></term>
		///				<description><see cref="List{T}"/></description>
		///			</item>
		///			<item>
		///				<term><c>ISet{T}</c> (.NET 4 or lator)</term>
		///				<description><see cref="HashSet{T}"/></description>
		///			</item>
		///			<item>
		///				<term><see cref="IList{T}"/></term>
		///				<description><see cref="List{T}"/></description>
		///			</item>
		///			<item>
		///				<term><see cref="IDictionary{TKey,TValue}"/></term>
		///				<description><see cref="Dictionary{TKey,TValue}"/></description>
		///			</item>
		///			<item>
		///				<term><see cref="IEnumerable"/></term>
		///				<description><see cref="List{T}"/> of <see cref="MessagePackObject"/>.</description>
		///			</item>
		///			<item>
		///				<term><see cref="ICollection"/></term>
		///				<description><see cref="List{T}"/> of <see cref="MessagePackObject"/>.</description>
		///			</item>
		///			<item>
		///				<term><see cref="IList"/></term>
		///				<description><see cref="List{T}"/> of <see cref="MessagePackObject"/>.</description>
		///			</item>
		///			<item>
		///				<term><see cref="IDictionary"/></term>
		///				<description><see cref="MessagePackObjectDictionary"/></description>
		///			</item>
		///		</list>
		/// </remarks>
		public Type? Get(Type abstractCollectionType)
		{
			this._underlying.DefaultCollectionTypes.Get(abstractCollectionType ?? throw new ArgumentNullException(nameof(abstractCollectionType)), out var concrete, out var genericDefinition);

			return concrete as Type ?? genericDefinition as Type;
		}

		/// <summary>
		///		Registers the default type of the collection.
		/// </summary>
		/// <param name="abstractCollectionType">Type of the abstract collection.</param>
		/// <param name="defaultCollectionType">Default concrete type of the <paramref name="abstractCollectionType"/>.</param>
		/// <exception cref="System.ArgumentNullException">
		///		<paramref name="abstractCollectionType"/> is <c>null</c>.
		///		Or <paramref name="defaultCollectionType"/> is <c>null</c>.
		/// </exception>
		/// <exception cref="System.ArgumentException">
		///		<paramref name="abstractCollectionType"/> is not collection type.
		///		Or <paramref name="defaultCollectionType"/> is abstract class or interface.
		///		Or <paramref name="defaultCollectionType"/> is open generic type but <paramref name="abstractCollectionType"/> is closed generic type.
		///		Or <paramref name="defaultCollectionType"/> is closed generic type but <paramref name="abstractCollectionType"/> is open generic type.
		///		Or <paramref name="defaultCollectionType"/> does not have same arity for <paramref name="abstractCollectionType"/>.
		///		Or <paramref name="defaultCollectionType"/> is not assignable to <paramref name="abstractCollectionType"/>
		///		or the constructed type from <paramref name="defaultCollectionType"/> will not be assignable to the constructed type from <paramref name="abstractCollectionType"/>.
		/// </exception>
		/// <remarks>
		///		If you want to overwrite default type for collection interfaces, you can use this method.
		///		Note that this method only supports collection interface, that is subtype of the <see cref="IEnumerable"/> interface.
		///		<note>
		///			If you register invalid type for <paramref name="defaultCollectionType"/>, then runtime exception will be occurred.
		///			For example, you register <see cref="IEnumerable{T}"/> of <see cref="Char"/> and <see cref="String"/> pair, but it will cause runtime error.
		///		</note>
		/// </remarks>
		/// <seealso cref="Get"/>
		public void Register(Type abstractCollectionType, Type defaultCollectionType)
			=> this._underlying.Register(abstractCollectionType, defaultCollectionType);

		/// <summary>
		///		Unregisters the default type of the collection.
		/// </summary>
		/// <param name="abstractCollectionType">Type of the abstract collection.</param>
		/// <returns>
		///		<c>true</c> if default collection type is removed successfully;
		///		otherwise, <c>false</c>.
		/// </returns>
		public bool Unregister(Type abstractCollectionType)
			=> this._underlying.Unregister(abstractCollectionType);

		IEnumerable<KeyValuePair<RuntimeTypeHandle, object>> IDefaultConcreteTypeRepository.AsEnumerable()
			=> this._underlying.DefaultCollectionTypes.GetEntries().Select(e => new KeyValuePair<RuntimeTypeHandle, object>(e.Key.TypeHandle, e.Value));
	}
}
