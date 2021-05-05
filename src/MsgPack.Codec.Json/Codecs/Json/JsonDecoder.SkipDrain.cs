// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

using System.Buffers;
using System.Threading;
using MsgPack.Internal;

namespace MsgPack.Codecs.Json
{
	public partial class JsonDecoder
	{
		public override void Drain(ref SequenceReader<byte> source, in CollectionContext collectionContext, long itemsCount, out int requestHint, CancellationToken cancellationToken = default)
			=> JsonThrow.DrainIsNotSupported(out requestHint);

		public override void Skip(ref SequenceReader<byte> source, in CollectionContext collectionContext, out int requestHint, CancellationToken cancellationToken = default)
		{
			var originalPosition = source.Consumed;

			this.DecodeItem(ref source, out var decodeItemResult, out requestHint, cancellationToken);
			if (requestHint != 0 || decodeItemResult.ElementType == ElementType.None)
			{
				return;
			}

			switch (decodeItemResult.ElementType)
			{
				case ElementType.Array:
				case ElementType.Map:
				{
					// Skip current collection with CollectionIterator.Drain()
					var iterator = decodeItemResult.CollectionIterator;
					if (!iterator.Drain(ref source, out requestHint, cancellationToken))
					{
						source.Rewind(source.Consumed - originalPosition);
						return;
					}

					break;
				}
			}

			requestHint = 0;
		}
	}
}
