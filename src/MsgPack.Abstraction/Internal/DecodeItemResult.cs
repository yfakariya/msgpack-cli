// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

using System;
using System.Buffers;
using System.Runtime.CompilerServices;

namespace MsgPack.Internal
{
	/// <summary>
	///		Represents a result of <see cref="FormatDecoder.DecodeItem(ref SequenceReader{Byte}, out DecodeItemResult, System.Threading.CancellationToken)"/>
	///		and <see cref="FormatDecoder.DecodeItem(ref SequenceReader{Byte}, out DecodeItemResult, out Int32, System.Threading.CancellationToken)"/>.
	/// </summary>
	public readonly struct DecodeItemResult
	{
		/// <summary>
		///		Gets the value which indicates this instance has any value or not.
		/// </summary>
		/// <value>
		///		<c>true</c> if this instance has any value; <c>false</c>, otherwise.
		/// </value>
		public bool HasValue => this.ElementType != ElementType.None;

		/// <summary>
		///		Gets the value which indicates this instance indicates any error.
		/// </summary>
		/// <value>
		///		<c>true</c> if this instance indicates error; <c>false</c>, otherwise.
		/// </value>
		public bool IsError => this.ElementType < 0;

		/// <summary>
		///		Gets the type of this result.
		/// </summary>
		/// <value>
		///		The type of this result.
		/// </value>
		public ElementType ElementType { get; }

		// If ElementType is string , this value is not decoded.
		/// <summary>
		///		Gets the value in raw binary format.
		/// </summary>
		/// <value>
		///		The value in raw binary format.
		/// </value>
		/// <remarks>
		///		The actual value of this property vary from the value of <see cref="ElementType"/> as following:
		///		<list type="table">
		///			<listheader>
		///				<term>The value of <see cref="ElementType"/></term>
		///				<description>The content of this property</description>
		///			</listheader>
		///			<item>
		///				<term><see cref="ElementType.Int32"/>, <see cref="ElementType.Int64"/>, <see cref="ElementType.UInt64"/>, <see cref="ElementType.Single"/>, or <see cref="ElementType.Double"/></term>
		///				<description>
		///					The scalar value with platform endianness.
		///					You can get scalar value with pointer operation or <see cref="System.Runtime.InteropServices.MemoryMarshal.Cast{TFrom, TTo}(ReadOnlySpan{TFrom})"/>.
		///				</description>
		///			</item>
		///			<item>
		///				<term><see cref="ElementType.String"/></term>
		///				<description>
		///					Raw, encoded string. So, caller might have to decode it with <see cref="System.Text.Encoding"/>.
		///				</description>
		///			</item>
		///			<item>
		///				<term><see cref="ElementType.Binary"/></term>
		///				<description>The binary itself.</description>
		///			</item>
		///			<item>
		///				<term><see cref="ElementType.Extension"/></term>
		///				<description>The extension type object body.</description>
		///			</item>
		///			<item>
		///				<term>Others</term>
		///				<description>Empty.</description>
		///			</item>
		///		</list>
		/// </remarks>
		public ReadOnlySequence<byte> Value { get; }

		/// <summary>
		///		Gets the <see cref="CollectionItemIterator"/> when available.
		/// </summary>
		/// <value>
		///		The valid <see cref="CollectionItemIterator"/> when <see cref="ElementType"/> property is <see cref="ElementType.Array"/> or <see cref="ElementType.Map"/>.
		///		Otherwise, empty <see cref="CollectionItemIterator"/>.
		/// </value>
		public CollectionItemIterator CollectionIterator { get; }

		/// <summary>
		///		Gets the collection length when available.
		/// </summary>
		/// <value>
		///		One of following depending on condition:
		///		<list type="bullet">
		///			<item>
		///				The collection length when <see cref="ElementType"/> property is <see cref="ElementType.Array"/> or <see cref="ElementType.Map"/>, and codec supports collection length encoding.
		///				Note that value can be <c>0</c> for empty collection.
		///				You can use <see cref="CollectionIterator"/> property, too.
		///			</item>
		///			<item>
		///				<c>-1</c> when <see cref="ElementType"/> property is <see cref="ElementType.Array"/> or <see cref="ElementType.Map"/>, and codec does NOT support collection length encoding.
		///				You can only iterate over the collection with <see cref="CollectionIterator"/> property.
		///			</item>
		///			<item>
		///				<c>0</c> when <see cref="ElementType"/> property is not <see cref="ElementType.Array"/> nor <see cref="ElementType.Map"/>.
		///				DO NOT determine the result only depending on this property is <c>0</c> -- it also be returned for empty array or map.
		///			</item>
		///		</list>
		/// </value>
		public long CollectionLength { get; }

		/// <summary>
		///		Gets the <see cref="ExtensionType"/> for extension type.
		/// </summary>
		/// <value>
		///		The valid <see cref="T:ExtensionType"/> when <see cref="ElementType"/> property is <see cref="ElementType.Extension"/>.
		///		Empty <see cref="T:ExtensionType"/>, otherwise.
		/// </value>
		public ExtensionType ExtensionType { get; }

		/// <summary>
		///		Gets the body of extension type object.
		/// </summary>
		/// <value>
		///		The body of extension type object.
		/// </value>
		/// <remarks>
		///		This property just returns <see cref="Value"/> even if the <see cref="ElementType"/> is not <see cref="ElementType.Extension"/>.
		/// </remarks>
		/// <seealso cref="Value"/>
		public ReadOnlySequence<byte> ExtensionBody => this.Value;

		private DecodeItemResult(
			ElementType elementType,
			in ReadOnlySequence<byte> value = default,
			in CollectionItemIterator collectionIterator = default,
			long collectionLength = default,
			ExtensionType extensionType = default
		)
		{
			this.ElementType = elementType;
			this.Value = value;
			this.CollectionIterator = collectionIterator;
			this.CollectionLength = collectionLength;
			this.ExtensionType = extensionType;
		}

		/// <summary>
		///		Returns a new instance of <see cref="DecodeItemResult"/> which represents collection header.
		/// </summary>
		/// <param name="elementType"><see cref="ElementType.Array"/> or <see cref="ElementType.Map"/>.</param>
		/// <param name="iterator">The valid <see cref="CollectionItemIterator"/>.</param>
		/// <param name="length">The length of the collection if available. This parameter is optional.</param>
		/// <returns>A new instance of <see cref="DecodeItemResult"/> which represents collection header.</returns>
		[MethodImpl(MethodImplOptionsShim.AggressiveInlining)]
		public static DecodeItemResult CollectionHeader(ElementType elementType, in CollectionItemIterator iterator, long length = -1)
			=> new DecodeItemResult(elementType, collectionIterator: iterator, collectionLength: length);

		/// <summary>
		///		Returns a new instance of <see cref="DecodeItemResult"/> which represents scalar value or sequence (string or binary).
		/// </summary>
		/// <param name="elementType">
		///		<see cref="ElementType.Int32"/>, <see cref="ElementType.Int64"/>, <see cref="ElementType.UInt64"/>,
		///		<see cref="ElementType.Single"/>, <see cref="ElementType.Double"/>,
		///		<see cref="ElementType.Binary"/>, or <see cref="ElementType.String"/>.
		///	</param>
		/// <param name="value">The raw value. See <see cref="Value"/> property's remarks document for the format details.</param>
		/// <returns>
		///		A new instance of <see cref="DecodeItemResult"/> which represents scalar value or sequence (string or binary).
		/// </returns>
		[MethodImpl(MethodImplOptionsShim.AggressiveInlining)]
		public static DecodeItemResult ScalarOrSequence(ElementType elementType, ReadOnlyMemory<byte> value)
			=> ScalarOrSequence(elementType, new ReadOnlySequence<byte>(value));

		/// <summary>
		///		Returns a new instance of <see cref="DecodeItemResult"/> which represents scalar value or sequence (string or binary).
		/// </summary>
		/// <param name="elementType">
		///		<see cref="ElementType.Int32"/>, <see cref="ElementType.Int64"/>, <see cref="ElementType.UInt64"/>,
		///		<see cref="ElementType.Single"/>, <see cref="ElementType.Double"/>,
		///		<see cref="ElementType.Binary"/>, or <see cref="ElementType.String"/>.
		///	</param>
		/// <param name="value">The raw value. See <see cref="Value"/> property's remarks document for the format details.</param>
		/// <returns>
		///		A new instance of <see cref="DecodeItemResult"/> which represents scalar value or sequence (string or binary).
		/// </returns>
		[MethodImpl(MethodImplOptionsShim.AggressiveInlining)]
		public static DecodeItemResult ScalarOrSequence(ElementType elementType, in ReadOnlySequence<byte> value)
			=> new DecodeItemResult(elementType, value: value);

		/// <summary>
		///		Returns a new instance of <see cref="DecodeItemResult"/> which represents <c>null</c>(<c>nil</c>).
		/// </summary>
		/// <returns>
		///		A new instance of <see cref="DecodeItemResult"/> which represents <c>null</c>(<c>nil</c>).
		/// </returns>
		[MethodImpl(MethodImplOptionsShim.AggressiveInlining)]
		public static DecodeItemResult Null()
			=> new DecodeItemResult(ElementType.Null);

		/// <summary>
		///		Returns a new instance of <see cref="DecodeItemResult"/> which represents <c>true</c>.
		/// </summary>
		/// <returns>
		///		A new instance of <see cref="DecodeItemResult"/> which represents <c>true</c>.
		/// </returns>
		[MethodImpl(MethodImplOptionsShim.AggressiveInlining)]
		public static DecodeItemResult True()
			=> new DecodeItemResult(ElementType.True);

		/// <summary>
		///		Returns a new instance of <see cref="DecodeItemResult"/> which represents <c>false</c>.
		/// </summary>
		/// <returns>
		///		A new instance of <see cref="DecodeItemResult"/> which represents <c>false</c>.
		/// </returns>
		[MethodImpl(MethodImplOptionsShim.AggressiveInlining)]
		public static DecodeItemResult False()
			=> new DecodeItemResult(ElementType.False);

		/// <summary>
		///		Returns a new instance of <see cref="DecodeItemResult"/> which represents extension type object.
		/// </summary>
		/// <param name="extensionType">The decoded <see cref="ExtensionType"/>.</param>
		/// <param name="body">The value of the body of the extension type object.</param>
		/// <returns>
		///		A new instance of <see cref="DecodeItemResult"/> which represents extension type object.
		/// </returns>
		[MethodImpl(MethodImplOptionsShim.AggressiveInlining)]
		public static DecodeItemResult ExtensionTypeObject(ExtensionType extensionType, in ReadOnlySequence<byte> body)
			=> new DecodeItemResult(ElementType.Extension, extensionType: extensionType, value: body);

		/// <summary>
		///		Returns a new instance of <see cref="DecodeItemResult"/> which represents an error (insufficient input bytes).
		/// </summary>
		/// <returns>
		///		A new instance of <see cref="DecodeItemResult"/> which represents an error (insufficient input bytes).
		/// </returns>
		[MethodImpl(MethodImplOptionsShim.AggressiveInlining)]
		public static DecodeItemResult InsufficientInput()
			=> new DecodeItemResult(ElementType.InsufficientInputError);
	}
}
