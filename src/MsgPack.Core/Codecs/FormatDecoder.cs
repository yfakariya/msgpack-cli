// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

using System;
using System.Buffers;
using System.Runtime.CompilerServices;
using System.Threading;
using MsgPack.Internal;

namespace MsgPack.Codecs
{
	/// <summary>
	///		Defines an interface and basic functionarity of stateless <see cref="FormatDecoder"/>.
	/// </summary>
	/// <remarks>
	///		The <see cref="FormatDecoder"/> is stateless, so caller (serializer, writer, etc.) can cache the instance for performance.
	/// </remarks>
	public abstract partial class FormatDecoder
	{
		/// <summary>
		///		Gets the option settings of this parser.
		/// </summary>
		/// <value>
		///		The option settings of this parser.
		/// </value>
		public FormatDecoderOptions Options { get; }

#warning TODO: Separete CodeFeatures(FormatFeatures) from ParserOptions
		/// <summary>
		///		Initializes a new instance of <see cref="FormatDecoder"/> class.
		/// </summary>
		/// <param name="options">The option settings of this decoder.</param>
		/// <exception cref="ArgumentNullException">
		///		<paramref name="options"/> is <c>null</c>.
		/// </exception>
		protected FormatDecoder(FormatDecoderOptions options)
		{
			this.Options = Ensure.NotNull(options);
		}

		/// <summary>
		///		Skips next item in the source byte stream.
		/// </summary>
		/// <param name="source">The reader of the source byte sequence. If and only if this method succeeds, the reader will be advanced.</param>
		/// <param name="collectionContext">The context information for collection deserialization.</param>
		/// <param name="cancellationToken">The token to monitor for cancellation requests. This value can be omitted.</param>
		/// <exception cref="MessageFormatException"><paramref name="source"/> contains invalid byte sequence for the underlying format.</exception>
		///	<exception cref="InsufficientInputException"><paramref name="source"/> does not contain enough bytes to decode.</exception>
		[MethodImpl(MethodImplOptionsShim.AggressiveInlining)]
		public void Skip(ref SequenceReader<byte> source, in CollectionContext collectionContext, CancellationToken cancellationToken = default)
		{
			this.Skip(ref source, collectionContext, out var requestHint, cancellationToken);
			if (requestHint != 0)
			{
				Throw.InsufficientInputForSkip(source.Consumed, requestHint);
			}
		}

		/// <summary>
		///		Skips next item in the source byte stream.
		/// </summary>
		/// <param name="source">The reader of the source byte sequence. If and only if this method succeeds, the reader will be advanced.</param>
		/// <param name="collectionContext">The context information for collection deserialization.</param>
		/// <param name="requestHint">
		///		<c>0</c> if this method succeeds to decode value; Positive integer when <paramref name="source" /> does not contain enough bytes to decode, and required memory bytes hint is stored.
		///		Note that <c>-1</c> represents unknown size. If so, caller must supply new buffer with most efficient size.
		/// </param>
		/// <param name="cancellationToken">The token to monitor for cancellation requests. This value can be omitted.</param>
		/// <exception cref="MessageFormatException"><paramref name="source"/> contains invalid byte sequence for the underlying format.</exception>
		public abstract void Skip(ref SequenceReader<byte> source, in CollectionContext collectionContext, out int requestHint, CancellationToken cancellationToken = default);

		/// <summary>
		///		Parses next item from the source byte stream.
		/// </summary>
		/// <param name="source">The reader of the source byte sequence. If and only if this method succeeds, the reader will be advanced.</param>
		/// <param name="result"><see cref="DecodeItemResult"/> which contains all information about parsing result.</param>
		/// <param name="cancellationToken">The token to monitor for cancellation requests. This value can be omitted.</param>
		/// <exception cref="MessageFormatException"><paramref name="source"/> contains invalid byte sequence for the underlying format.</exception>
		///	<exception cref="InsufficientInputException"><paramref name="source"/> does not contain enough bytes to decode.</exception>
		[MethodImpl(MethodImplOptionsShim.AggressiveInlining)]
		public void DecodeItem(ref SequenceReader<byte> source, out DecodeItemResult result, CancellationToken cancellationToken = default)
		{
			this.DecodeItem(ref source, out result, out var requestHint, cancellationToken);
			if (requestHint != 0)
			{
				Throw.InsufficientInputForAnyItem(source.Consumed, requestHint);
			}
		}

		/// <summary>
		///		Parses next item from the source byte stream.
		/// </summary>
		/// <param name="source">The reader of the source byte sequence. If and only if this method succeeds, the reader will be advanced.</param>
		/// <param name="result"><see cref="DecodeItemResult"/> which contains all information about parsing result.</param>
		/// <param name="requestHint">
		///		<c>0</c> if this method succeeds to decode value; Positive integer when <paramref name="source" /> does not contain enough bytes to decode, and required memory bytes hint is stored.
		///		Note that <c>-1</c> represents unknown size. If so, caller must supply new buffer with most efficient size.
		/// </param>
		/// <param name="cancellationToken">The token to monitor for cancellation requests. This value can be omitted.</param>
		/// <exception cref="MessageFormatException"><paramref name="source"/> contains invalid byte sequence for the underlying format.</exception>
		public abstract void DecodeItem(ref SequenceReader<byte> source, out DecodeItemResult result, out int requestHint, CancellationToken cancellationToken = default);

		/// <summary>
		///		Gets a raw encoded string value.
		/// </summary>
		/// <param name="source">The reader of the source byte sequence. If and only if this method succeeds, the reader will be advanced.</param>
		/// <param name="buffer"></param>
		/// <param name="cancellationToken">The token to monitor for cancellation requests. This value can be omitted.</param>
		/// <returns>
		///		If <paramref name="buffer"/> has enough bytes, actually used bytes length will be returned.
		///		Otherwise, negated value of raw string length is returned.
		///		Note that <c>0</c> means successful result for empty raw string.
		/// </returns>
		/// <exception cref="MessageFormatException"><paramref name="source"/> contains invalid byte sequence for the underlying format.</exception>
		/// <exception cref="MessageTypeException">The underlying format value is not compatible to <see cref="String"/> type.</exception>
		///	<exception cref="InsufficientInputException"><paramref name="source"/> does not contain enough bytes to decode.</exception>
		///	<remarks>
		///		Actual meanings of "raw" encoded string depends on underlying format.
		///		It will not contain quotations and will not be unescaped.
		///		So, it is suitable for rarely escaped content, namely property keys.
		///		Serialziers should implement fallback mechanism to use general <see cref="DecodeString(ref SequenceReader{Byte}, System.Text.Encoding?, CancellationToken)"/> or one of its overloads.
		///	</remarks>
		[MethodImpl(MethodImplOptionsShim.AggressiveInlining)]
		public int GetRawString(ref SequenceReader<byte> source, Span<byte> buffer, CancellationToken cancellationToken = default)
		{
			var usedOrRequested = this.GetRawString(ref source, buffer, out var requestHint, cancellationToken);
			if (requestHint != 0)
			{
				Throw.InsufficientInputForRawString(source.Consumed, requestHint);
			}

			return usedOrRequested;
		}

		/// <summary>
		///		Gets a raw encoded string value.
		/// </summary>
		/// <param name="source">The reader of the source byte sequence. If and only if this method succeeds, the reader will be advanced.</param>
		/// <param name="buffer"></param>
		/// <param name="requestHint">
		///		<c>0</c> if this method succeeds to decode value; Positive integer when <paramref name="source" /> does not contain enough bytes to decode, and required memory bytes hint is stored.
		///		Note that <c>-1</c> represents unknown size. If so, caller must supply new buffer with most efficient size.
		/// </param>
		/// <param name="cancellationToken">The token to monitor for cancellation requests. This value can be omitted.</param>
		/// <returns>
		///		If <paramref name="buffer"/> has enough bytes, actually used bytes length will be returned.
		///		Otherwise, negated value of raw string length is returned.
		///		Note that <c>0</c> means successful result for empty raw string.
		///		Also, note that the return value is undefined when <paramref name="requestHint"/> is not <c>0</c>.
		/// </returns>
		/// <exception cref="MessageFormatException"><paramref name="source"/> contains invalid byte sequence for the underlying format.</exception>
		/// <exception cref="MessageTypeException">The underlying format value is not compatible to <see cref="String"/> type.</exception>
		///	<remarks>
		///		Actual meanings of "raw" encoded string depends on underlying format.
		///		It will not contain quotations and will not be unescaped.
		///		So, it is suitable for rarely escaped content, namely property keys.
		///		Serialziers should implement fallback mechanism to use general <see cref="DecodeString(ref SequenceReader{Byte}, System.Text.Encoding?, CancellationToken)"/> or one of its overloads.
		///	</remarks>
		public abstract int GetRawString(ref SequenceReader<byte> source, Span<byte> buffer, out int requestHint, CancellationToken cancellationToken = default);

		/// <summary>
		///		Checks whether next item is <c>null</c> or not.
		/// </summary>
		/// <param name="source">The reader of the source byte sequence. If and only if this method returns <c>true</c>, the reader will be advanced.</param>
		/// <returns>
		///		<c>true</c> if the next item is <c>null</c>; <c>false</c>, otherwise.
		/// </returns>
		/// <exception cref="MessageFormatException"><paramref name="source"/> contains invalid byte sequence for the underlying format.</exception>
		///	<exception cref="InsufficientInputException"><paramref name="source"/> does not contain enough bytes to decode.</exception>
		///	<remarks>
		///		<see cref="SequenceReader{T}.Consumed"/> transition will be as follow:
		///		<list type="table">
		///			<listheader>
		///				<term>Return value</term>
		///				<description>Transition</description>
		///			</listheader>
		///			<item>
		///				<term><c>true</c></term>
		///				<description>Moves to next to <c>null</c>.</description>
		///			</item>
		///			<item>
		///				<term><c>false</c></term>
		///				<description>Does not move.</description>
		///			</item>
		///			<item>
		///				<term>Exception</term>
		///				<description>Does not move.</description>
		///			</item>
		///		</list>
		///	</remarks>
		[MethodImpl(MethodImplOptionsShim.AggressiveInlining)]
		public bool TryDecodeNull(ref SequenceReader<byte> source)
		{
			if (this.TryDecodeNull(ref source, out var requestHint))
			{
				return true;
			}

			if (requestHint != 0)
			{
				Throw.InsufficientInputForNull(source.Consumed, requestHint);
			}

			return false;
		}

		/// <summary>
		///		Checks whether next item is <c>null</c> or not.
		/// </summary>
		/// <param name="source">The reader of the source byte sequence. If and only if this method returns <c>true</c>, the reader will be advanced.</param>
		/// <param name="requestHint">
		///		<c>0</c> if this method succeeds to decode value; Positive integer when <paramref name="source" /> does not contain enough bytes to decode, and required memory bytes hint is stored.
		///		Note that <c>-1</c> represents unknown size. If so, caller must supply new buffer with most efficient size.
		/// </param>
		/// <returns>
		///		<c>true</c> if the next item is <c>null</c>; <c>false</c>, otherwise.
		/// </returns>
		/// <exception cref="MessageFormatException"><paramref name="source"/> contains invalid byte sequence for the underlying format.</exception>
		///	<exception cref="InsufficientInputException"><paramref name="source"/> does not contain enough bytes to decode.</exception>
		///	<remarks>
		///		<see cref="SequenceReader{T}.Consumed"/> transition will be as follow:
		///		<list type="table">
		///			<listheader>
		///				<term>Return value</term>
		///				<description>Transition</description>
		///			</listheader>
		///			<item>
		///				<term><c>true</c></term>
		///				<description>Moves to next to <c>null</c>.</description>
		///			</item>
		///			<item>
		///				<term><c>false</c></term>
		///				<description>Does not move.</description>
		///			</item>
		///			<item>
		///				<term>Exception</term>
		///				<description>Does not move.</description>
		///			</item>
		///		</list>
		///	</remarks>
		public abstract bool TryDecodeNull(ref SequenceReader<byte> source, out int requestHint);

		/// <summary>
		///		Decodes current data as array or map header, and returns the items count if known.
		/// </summary>
		/// <param name="source">The reader of the source byte sequence. If and only if this method succeeds, the reader will be advanced.</param>
		/// <param name="itemsCount">Items count if known; <c>-1</c> if underlying format does not contain any count information; <c>0</c> if underlying format is not an array nor a map.</param>
		/// <returns>
		///		<see cref="ElementType.Array"/> for array, <see cref="ElementType.Map"/> for map (dictionary).
		///		This method does not return anything else, but may throw an exception.
		///	</returns>
		/// <exception cref="MessageFormatException"><paramref name="source"/> contains invalid byte sequence for the underlying format.</exception>
		///	<exception cref="MessageTypeException">The decoded value is not an array nor a map.</exception>
		///	<exception cref="InsufficientInputException"><paramref name="source"/> does not contain enough bytes to decode.</exception>
		[MethodImpl(MethodImplOptionsShim.AggressiveInlining)]
		public CollectionType DecodeArrayOrMapHeader(ref SequenceReader<byte> source, out int itemsCount)
		{
			var result = this.DecodeArrayOrMapHeader(ref source, out itemsCount, out var requestHint);
			if (requestHint != 0)
			{
				Throw.InsufficientInputForDecodeArrayOrMapHeader(source.Consumed, requestHint);
			}

			return result;
		}

		/// <summary>
		///		Decodes current data as array or map header, and returns the items count if known.
		/// </summary>
		/// <param name="source">The reader of the source byte sequence. If and only if this method succeeds, the reader will be advanced.</param>
		/// <param name="itemsCount">Items count if known; <c>-1</c> if underlying format does not contain any count information; <c>0</c> if underlying format is not an array nor a map.</param>
		/// <param name="requestHint">
		///		<c>0</c> if this method succeeds to decode value; Positive integer when <paramref name="source" /> does not contain enough bytes to decode, and required memory bytes hint is stored.
		///		Note that <c>-1</c> represents unknown size. If so, caller must supply new buffer with most efficient size.
		///	</param>
		/// <returns>
		///		<see cref="ElementType.Array"/> for array, <see cref="ElementType.Map"/> for map (dictionary), or <see cref="ElementType.None"/> if there were not enough bytes to decode.
		///		This method does not return anything else, but may throw an exception.
		///	</returns>
		/// <exception cref="MessageFormatException"><paramref name="source"/> contains invalid byte sequence for the underlying format.</exception>
		///	<exception cref="MessageTypeException">The decoded value is not an array nor a map.</exception>
		public abstract CollectionType DecodeArrayOrMapHeader(ref SequenceReader<byte> source, out int itemsCount, out int requestHint);

		/// <summary>
		///		Decodes current data as array header, and returns the items count if known.
		/// </summary>
		/// <param name="source">The reader of the source byte sequence. If and only if this method succeeds, the reader will be advanced.</param>
		/// <returns>
		///		Items count if known; <c>-1</c> if underlying format does not contain any count information.
		///		Note that <c>0</c> is valid value when the array is empty.
		///	</returns>
		///	<exception cref="MessageTypeException">The decoded value is not an array.</exception>
		///	<exception cref="InsufficientInputException"><paramref name="source"/> does not contain enough bytes to decode.</exception>
		[MethodImpl(MethodImplOptionsShim.AggressiveInlining)]
		public int DecodeArrayHeader(ref SequenceReader<byte> source)
		{
			var result = this.DecodeArrayHeader(ref source, out var requestHint);
			if (requestHint != 0)
			{
				Throw.InsufficientInputForDecodeArrayHeader(source.Consumed, requestHint);
			}

			return result;
		}

		/// <summary>
		///		Decodes current data as array header, and returns the items count if known.
		/// </summary>
		/// <param name="source">The reader of the source byte sequence. If and only if this method succeeds, the reader will be advanced.</param>
		/// <param name="requestHint">
		///		<c>0</c> if this method succeeds to decode value; Positive integer when <paramref name="source" /> does not contain enough bytes to decode, and required memory bytes hint is stored.
		///		Note that <c>-1</c> represents unknown size. If so, caller must supply new buffer with most efficient size.
		///	</param>
		/// <returns>
		///		Items count if known; <c>-1</c> if underlying format does not contain any count information.
		///		Note that <c>0</c> is valid value when the array is empty.
		///	</returns>
		/// <exception cref="MessageFormatException"><paramref name="source"/> contains invalid byte sequence for the underlying format.</exception>
		///	<exception cref="MessageTypeException">The decoded value is not an array.</exception>
		[MethodImpl(MethodImplOptionsShim.AggressiveInlining)]
		public abstract int DecodeArrayHeader(ref SequenceReader<byte> source, out int requestHint);

		/// <summary>
		///		Decodes current data as map header, and returns the items count if known.
		/// </summary>
		/// <param name="source">The reader of the source byte sequence. If and only if this method succeeds, the reader will be advanced.</param>
		/// <returns>
		///		Items count if known; <c>-1</c> if underlying format does not contain any count information.
		///		Note that <c>0</c> is valid value when the map is empty.
		///	</returns>
		///	<exception cref="MessageTypeException">The decoded value is not a map.</exception>
		///	<exception cref="InsufficientInputException"><paramref name="source"/> does not contain enough bytes to decode.</exception>
		[MethodImpl(MethodImplOptionsShim.AggressiveInlining)]
		public int DecodeMapHeader(ref SequenceReader<byte> source)
		{
			var result = this.DecodeMapHeader(ref source, out var requestHint);
			if (requestHint != 0)
			{
				Throw.InsufficientInputForDecodeMapHeader(source.Consumed, requestHint);
			}

			return result;
		}

		/// <summary>
		///		Decodes current data as map header, and returns the items count if known.
		/// </summary>
		/// <param name="source">The reader of the source byte sequence. If and only if this method succeeds, the reader will be advanced.</param>
		/// <param name="requestHint">
		///		<c>0</c> if this method succeeds to decode value; Positive integer when <paramref name="source" /> does not contain enough bytes to decode, and required memory bytes hint is stored.
		///		Note that <c>-1</c> represents unknown size. If so, caller must supply new buffer with most efficient size.
		///	</param>
		/// <returns>
		///		Items count if known; <c>-1</c> if underlying format does not contain any count information.
		///		Note that <c>0</c> is valid value when the map is empty.
		///	</returns>
		/// <exception cref="MessageFormatException"><paramref name="source"/> contains invalid byte sequence for the underlying format.</exception>
		///	<exception cref="MessageTypeException">The decoded value is not a map.</exception>
		public abstract int DecodeMapHeader(ref SequenceReader<byte> source, out int requestHint);

		/// <summary>
		///		Parses current data as the <see cref="ExtensionTypeObject"/>.
		/// </summary>
		/// <param name="source">The reader of the source byte sequence. If and only if this method succeeds, the reader will be advanced.</param>
		/// <param name="result">The <see cref="ExtensionTypeObject"/> parsed.</param>
		/// <param name="cancellationToken">The token to monitor for cancellation requests. This value can be omitted.</param>
		/// <exception cref="NotSupportedException">The underlying format does not support extension type object.</exception>
		/// <exception cref="MessageFormatException"><paramref name="source"/> contains invalid byte sequence for the underlying format.</exception>
		/// <exception cref="MessageTypeException">The underlying format value is not an extension type object.</exception>
		///	<exception cref="InsufficientInputException"><paramref name="source"/> does not contain enough bytes to decode.</exception>
		///	<remarks>
		///		Callers can determine that the underlying format supports extension type object with <see cref="Codecs.CodecFeatures.SupportsExtensionTypes"/>.
		///	</remarks>
		public void DecodeExtension(ref SequenceReader<byte> source, out ExtensionTypeObject result, CancellationToken cancellationToken = default)
		{
			this.DecodeExtension(ref source, out result, out var requestHint, cancellationToken);
			if (requestHint != 0)
			{
				Throw.InsufficientInputForDecodeMapHeader(source.Consumed, requestHint);
			}
		}

		/// <summary>
		///		Parses current data as the <see cref="ExtensionTypeObject"/>.
		/// </summary>
		/// <param name="source">The reader of the source byte sequence. If and only if this method succeeds, the reader will be advanced.</param>
		/// <param name="result">The <see cref="ExtensionTypeObject"/> parsed.</param>
		/// <param name="requestHint">
		///		<c>0</c> if this method succeeds to decode value; Positive integer when <paramref name="source" /> does not contain enough bytes to decode, and required memory bytes hint is stored.
		///		Note that <c>-1</c> represents unknown size. If so, caller must supply new buffer with most efficient size.
		/// </param>
		/// <param name="cancellationToken">The token to monitor for cancellation requests. This value can be omitted.</param>
		/// <exception cref="NotSupportedException">The underlying format does not support extension type object.</exception>
		/// <exception cref="MessageFormatException"><paramref name="source"/> contains invalid byte sequence for the underlying format.</exception>
		/// <exception cref="MessageTypeException">The underlying format value is not an extension type object.</exception>
		///	<remarks>
		///		Callers can determine that the underlying format supports extension type object with <see cref="Codecs.CodecFeatures.SupportsExtensionTypes"/>.
		///	</remarks>
		public virtual void DecodeExtension(ref SequenceReader<byte> source, out ExtensionTypeObject result, out int requestHint, CancellationToken cancellationToken = default)
		{
			Throw.ExtensionsIsNotSupported();
			// never
			result = default;
			requestHint = -1;
		}

		/// <summary>
		///		Parses next items as a collection.
		/// </summary>
		/// <param name="source">The reader of the source byte sequence. If and only if this method succeeds, the reader will be advanced.</param>
		/// <param name="iterator">The iterator to iterate collection items.</param>
		/// <returns>The <see cref="CollectionType"/> which represents actual kind of the collection.</returns>
		/// <exception cref="MessageFormatException"><paramref name="source"/> contains invalid byte sequence for the underlying format.</exception>
		///	<exception cref="MessageTypeException">The decoded value is not an array nor a map.</exception>
		///	<exception cref="InsufficientInputException"><paramref name="source"/> does not contain enough bytes to decode.</exception>
		public CollectionType DecodeArrayOrMap(ref SequenceReader<byte> source, out CollectionItemIterator iterator)
		{
			var result = this.DecodeArrayOrMap(ref source, out iterator, out var requestHint);
			if (requestHint != 0)
			{
				Throw.InsufficientInputForDecodeArrayOrMapHeader(source.Consumed, requestHint);
			}

			return result;
		}

		/// <summary>
		///		Parses next items as a collection.
		/// </summary>
		/// <param name="source">The reader of the source byte sequence. If and only if this method succeeds, the reader will be advanced.</param>
		/// <param name="iterator">The iterator to iterate collection items.</param>
		/// <param name="requestHint">
		///		<c>0</c> if this method succeeds to decode value; Positive integer when <paramref name="source" /> does not contain enough bytes to decode, and required memory bytes hint is stored.
		///		Note that <c>-1</c> represents unknown size. If so, caller must supply new buffer with most efficient size.
		/// </param>
		/// <returns>The <see cref="CollectionType"/> which represents actual kind of the collection.</returns>
		/// <exception cref="MessageFormatException"><paramref name="source"/> contains invalid byte sequence for the underlying format.</exception>
		///	<exception cref="MessageTypeException">The decoded value is not an array nor a map.</exception>
		public abstract CollectionType DecodeArrayOrMap(ref SequenceReader<byte> source, out CollectionItemIterator iterator, out int requestHint);

		/// <summary>
		///		Decodes current data as array header, and returns the iterator to itereate items.
		/// </summary>
		/// <param name="source">The reader of the source byte sequence. If and only if this method succeeds, the reader will be advanced.</param>
		/// <returns>
		///		The iterator to iterate collection items.
		///	</returns>
		/// <exception cref="MessageFormatException"><paramref name="source"/> contains invalid byte sequence for the underlying format.</exception>
		///	<exception cref="MessageTypeException">The decoded value is not an array.</exception>
		///	<exception cref="InsufficientInputException"><paramref name="source"/> does not contain enough bytes to decode.</exception>
		public CollectionItemIterator DecodeArray(ref SequenceReader<byte> source)
		{
			var result = this.DecodeArray(ref source, out var requestHint);
			if (requestHint != 0)
			{
				Throw.InsufficientInputForDecodeArrayHeader(source.Consumed, requestHint);
			}

			return result;
		}

		/// <summary>
		///		Decodes current data as array header, and returns the iterator to itereate items.
		/// </summary>
		/// <param name="source">The reader of the source byte sequence. If and only if this method succeeds, the reader will be advanced.</param>
		/// <param name="requestHint">
		///		<c>0</c> if this method succeeds to decode value; Positive integer when <paramref name="source" /> does not contain enough bytes to decode, and required memory bytes hint is stored.
		///		Note that <c>-1</c> represents unknown size. If so, caller must supply new buffer with most efficient size.
		///	</param>
		/// <returns>
		///		The iterator to iterate collection items.
		///	</returns>
		/// <exception cref="MessageFormatException"><paramref name="source"/> contains invalid byte sequence for the underlying format.</exception>
		///	<exception cref="MessageTypeException">The decoded value is not an array.</exception>
		public abstract CollectionItemIterator DecodeArray(ref SequenceReader<byte> source, out int requestHint);

		/// <summary>
		///		Decodes current data as map header, and returns the iterator to itereate key and value pairs.
		/// </summary>
		/// <param name="source">The reader of the source byte sequence. If and only if this method succeeds, the reader will be advanced.</param>
		/// <returns>
		///		The iterator to iterate collection items, which returns keys and value alternately.
		///	</returns>
		/// <exception cref="MessageFormatException"><paramref name="source"/> contains invalid byte sequence for the underlying format.</exception>
		///	<exception cref="MessageTypeException">The decoded value is not a map.</exception>
		///	<exception cref="InsufficientInputException"><paramref name="source"/> does not contain enough bytes to decode.</exception>
		public CollectionItemIterator DecodeMap(ref SequenceReader<byte> source)
		{
			var result = this.DecodeMap(ref source, out var requestHint);
			if (requestHint != 0)
			{
				Throw.InsufficientInputForDecodeMapHeader(source.Consumed, requestHint);
			}

			return result;
		}

		/// <summary>
		///		Decodes current data as map header, and returns the iterator to itereate key and value pairs.
		/// </summary>
		/// <param name="source">The reader of the source byte sequence. If and only if this method succeeds, the reader will be advanced.</param>
		/// <param name="requestHint">
		///		<c>0</c> if this method succeeds to decode value; Positive integer when <paramref name="source" /> does not contain enough bytes to decode, and required memory bytes hint is stored.
		///		Note that <c>-1</c> represents unknown size. If so, caller must supply new buffer with most efficient size.
		///	</param>
		/// <returns>
		///		The iterator to iterate collection items, which returns keys and value alternately.
		///	</returns>
		/// <exception cref="MessageFormatException"><paramref name="source"/> contains invalid byte sequence for the underlying format.</exception>
		///	<exception cref="MessageTypeException">The decoded value is not a map.</exception>
		public abstract CollectionItemIterator DecodeMap(ref SequenceReader<byte> source, out int requestHint);

		/// <summary>
		///		Drains remaining items of the current collection from the source byte stream.
		/// </summary>
		/// <param name="source">The reader of the source byte sequence. If and only if this method succeeds, the reader will be advanced.</param>
		/// <param name="collectionContext">The context information for collection deserialization.</param>
		/// <param name="itemsCount">The remaining count of the collection if available. If the format does not contain length prefix, this value will be ignored, so caller can specify any value.</param>
		/// <param name="cancellationToken">The token to monitor for cancellation requests. This value can be omitted.</param>
		/// <exception cref="MessageFormatException"><paramref name="source"/> contains invalid byte sequence for the underlying format.</exception>
		///	<exception cref="InsufficientInputException"><paramref name="source"/> does not contain enough bytes to decode.</exception>
		[MethodImpl(MethodImplOptionsShim.AggressiveInlining)]
		public void Drain(ref SequenceReader<byte> source, in CollectionContext collectionContext, long itemsCount, CancellationToken cancellationToken = default)
		{
			if (itemsCount <= 0)
			{
				return;
			}

			this.Drain(ref source, collectionContext, itemsCount, out var requestHint, cancellationToken);
			if (requestHint != 0)
			{
				Throw.InsufficientInputForDecodeMapHeader(source.Consumed, requestHint);
			}
		}

		/// <summary>
		///		Drains remaining items of the current collection from the source byte stream.
		/// </summary>
		/// <param name="source">The reader of the source byte sequence. If and only if this method succeeds, the reader will be advanced.</param>
		/// <param name="collectionContext">The context information for collection deserialization.</param>
		/// <param name="itemsCount">The remaining count of the collection if available. If the format does not contain length prefix, this value will be ignored, so caller can specify any value.</param>
		/// <param name="requestHint">
		///		<c>0</c> if this method succeeds to decode value; Positive integer when <paramref name="source" /> does not contain enough bytes to decode, and required memory bytes hint is stored.
		///		Note that <c>-1</c> represents unknown size. If so, caller must supply new buffer with most efficient size.
		/// </param>
		/// <param name="cancellationToken">The token to monitor for cancellation requests. This value can be omitted.</param>
		/// <exception cref="MessageFormatException"><paramref name="source"/> contains invalid byte sequence for the underlying format.</exception>
		public abstract void Drain(ref SequenceReader<byte> source, in CollectionContext collectionContext, long itemsCount, out int requestHint, CancellationToken cancellationToken = default);
	}
}
