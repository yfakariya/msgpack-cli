// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

using System.Buffers;
using System.Runtime.CompilerServices;
using System.Threading;
using MsgPack.Internal;

namespace MsgPack.Codecs
{
	/// <summary>
	///		Defines interation logic for collection with deserialization
	///		even if the format does not support collection length prefix.
	/// </summary>
	public struct CollectionItemIterator
	{
#warning Remove ref from nextItemIndex
#warning Rename to EndOfCollectionDetection
		/// <summary>
		///		Defines delegate for the logic which detects end of the collection in format specific way.
		/// </summary>
		/// <param name="source">The reader of the source byte sequence. If and only if this method succeeds, the reader will be advanced.</param>
		/// <param name="nextItemIndex">The index of a next item in the collection.</param>
		/// <param name="itemsCount">The total count of the collection if available. If the format does not contain length prefix, the value will be ignored, so caller may specify any value</param>
		/// <param name="requestHint">
		///		<c>0</c> if this method succeeds to decode value; Positive integer when <paramref name="source" /> does not contain enough bytes to decode, and required memory bytes hint is stored.
		///		Note that <c>-1</c> represents unknown size. If so, caller must supply new buffer with most efficient size.
		/// </param>
		/// <returns><c>true</c> if the underlying collection ends; <c>false</c>, otherwise.</returns>
		public delegate bool CollectionEndDetection(ref SequenceReader<byte> source, ref long nextItemIndex, long itemsCount, out int requestHint);

		private readonly long _itemsCount;
		private readonly CollectionEndDetection _endOfCollectionDetection;
		private long _nextItemIndex;

#warning Remove -1 from JSON
		/// <summary>
		///		Initializes a new instance of <see cref="CollectionItemIterator"/> structure.
		/// </summary>
		/// <param name="endOfCollectionDetection">The delegate for the logic which detects end of the collection in format specific way.</param>
		/// <param name="itemsCount">The total count of the collection if available.</param>
		public CollectionItemIterator(
			CollectionEndDetection endOfCollectionDetection,
			long itemsCount = -1
		)
		{
			this._endOfCollectionDetection = Ensure.NotNull(endOfCollectionDetection);
			this._itemsCount = itemsCount;
			this._nextItemIndex = 0;
		}

		/// <summary>
		///		Determines whether the underlying collection ends.
		/// </summary>
		/// <param name="source">The reader of the source byte sequence. If and only if this method succeeds, the reader will be advanced.</param>
		/// <returns><c>true</c> if the underlying collection ends; <c>false</c>, otherwise.</returns>
		///	<exception cref="InsufficientInputException"><paramref name="source"/> does not contain enough bytes to decode.</exception>
		[MethodImpl(MethodImplOptionsShim.AggressiveInlining)]
		public bool CollectionEnds(ref SequenceReader<byte> source)
		{
			var result = this._endOfCollectionDetection(ref source, ref this._nextItemIndex, this._itemsCount, out var requestHint);
			if (requestHint != 0)
			{
				Throw.InsufficientInputForDetectCollectionEnds(source.Consumed, requestHint);
			}

			return result;
		}

		/// <summary>
		///		Determines whether the underlying collection ends.
		/// </summary>
		/// <param name="source">The reader of the source byte sequence. If and only if this method succeeds, the reader will be advanced.</param>
		/// <param name="requestHint">
		///		<c>0</c> if this method succeeds to decode value; Positive integer when <paramref name="source" /> does not contain enough bytes to decode, and required memory bytes hint is stored.
		///		Note that <c>-1</c> represents unknown size. If so, caller must supply new buffer with most efficient size.
		/// </param>
		/// <returns><c>true</c> if the underlying collection ends; <c>false</c>, otherwise.</returns>
		[MethodImpl(MethodImplOptionsShim.AggressiveInlining)]
		public bool CollectionEnds(ref SequenceReader<byte> source, out int requestHint)
			=> this._endOfCollectionDetection(ref source, ref this._nextItemIndex, this._itemsCount, out requestHint);

#warning TODO: in -> ref
		/// <summary>
		///		Determines whether the underlying collection ends.
		/// </summary>
		/// <param name="source">The source byte sequence. If and only if this method succeeds, the sequence will be advanced.</param>
		/// <param name="requestHint">
		///		<c>0</c> if this method succeeds to decode value; Positive integer when <paramref name="source" /> does not contain enough bytes to decode, and required memory bytes hint is stored.
		///		Note that <c>-1</c> represents unknown size. If so, caller must supply new buffer with most efficient size.
		/// </param>
		/// <returns><c>true</c> if the underlying collection ends; <c>false</c>, otherwise.</returns>
		[MethodImpl(MethodImplOptionsShim.AggressiveInlining)]
		public bool CollectionEnds(in ReadOnlySequence<byte> source, out int requestHint)
		{
			var reader = new SequenceReader<byte>(source);
			return this.CollectionEnds(ref reader, out requestHint);
		}

		/// <summary>
		///		Drains and discards remaining collection items.
		/// </summary>
		/// <param name="source">The reader of the source byte sequence. If and only if this method succeeds, the reader will be advanced.</param>
		/// <param name="cancellationToken">The token to monitor for cancellation requests. This value can be omitted.</param>
		///	<exception cref="InsufficientInputException"><paramref name="source"/> does not contain enough bytes to decode.</exception>
		[MethodImpl(MethodImplOptionsShim.AggressiveInlining)]
		public void Drain(ref SequenceReader<byte> source, CancellationToken cancellationToken = default)
		{
			if (!this.Drain(ref source, out var requestHint, cancellationToken))
			{
				Throw.InsufficientInputForDrainCollectionItems(source.Consumed, requestHint);
			}
		}

		/// <summary>
		///		Drains and discards remaining collection items.
		/// </summary>
		/// <param name="source">The reader of the source byte sequence. If and only if this method succeeds, the reader will be advanced.</param>
		/// <param name="requestHint">
		///		<c>0</c> if this method succeeds to decode value; Positive integer when <paramref name="source" /> does not contain enough bytes to decode, and required memory bytes hint is stored.
		///		Note that <c>-1</c> represents unknown size. If so, caller must supply new buffer with most efficient size.
		/// </param>
		/// <param name="cancellationToken">The token to monitor for cancellation requests. This value can be omitted.</param>
		[MethodImpl(MethodImplOptionsShim.AggressiveInlining)]
		public bool Drain(ref SequenceReader<byte> source, out int requestHint, CancellationToken cancellationToken = default)
		{
			while (!this.CollectionEnds(ref source, out requestHint))
			{
				if (requestHint != 0)
				{
					return false;
				}

				cancellationToken.ThrowIfCancellationRequested();
			}

			return true;
		}

		/// <summary>
		///		Drains and discards remaining collection items.
		/// </summary>
		/// <param name="source">The source byte sequence. If and only if this method succeeds, the sequence will be advanced.</param>
		/// <param name="requestHint">
		///		<c>0</c> if this method succeeds to decode value; Positive integer when <paramref name="source" /> does not contain enough bytes to decode, and required memory bytes hint is stored.
		///		Note that <c>-1</c> represents unknown size. If so, caller must supply new buffer with most efficient size.
		/// </param>
		/// <param name="cancellationToken">The token to monitor for cancellation requests. This value can be omitted.</param>
		[MethodImpl(MethodImplOptionsShim.AggressiveInlining)]
		public bool Drain(ref ReadOnlySequence<byte> source, out int requestHint, CancellationToken cancellationToken = default)
		{
			var reader = new SequenceReader<byte>(source);
			var ends = this.Drain(ref reader, out requestHint, cancellationToken);
			source = source.Slice((int)reader.Consumed);
			return ends;
		}
	}
}
