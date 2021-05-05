// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

namespace MsgPack.Internal
{
	// Basic idea is borrwed from AutomataDictionary of Message Pack C#
	// https://github.com/neuecc/MessagePack-CSharp/blob/51649e0d7b8641ad5d3cdd6dfdc130c7671066fc/src/MessagePack.UnityClient/Assets/Scripts/MessagePack/Internal/AutomataDictionary.cs#L1

	[DebuggerTypeProxy(typeof(ScalarStringTrie<>.DebuggerProxy))]
	internal sealed class ScalarStringTrie<T>
	{
		private readonly T _default;
		private readonly Node _root;

		public ScalarStringTrie(T defaultValue)
		{
			this._default = defaultValue;
			this._root = new Node(defaultValue, Array.Empty<Node>(), Array.Empty<ulong>());
		}

		public bool TryAddRaw(ReadOnlySpan<byte> utf8Key, T value)
			=> this.TryAdd(this._root, ScalarStringTrieKey.GetRaw64(ref utf8Key), utf8Key, value);

		private static int BinarySearch(ulong[] nodes, ulong key)
		{
			// Span<T>.BinarySearch is slower maybe because of ComapreTo method overhead, so we implement binary search manually.
			var low = 0;
			var high = nodes.Length - 1;
			while (low <= high)
			{
				// Peformance trick borrowed from https://github.com/dotnet/runtime/blob/f2786223508c0c70040fbf48ec3a39a607dd7f75/src/libraries/System.Private.CoreLib/src/System/SpanHelpers.BinarySearch.cs#L42
				var index = unchecked((int)(((uint)high + (uint)low) >> 1));
				var found = nodes[index];
				if (found == key)
				{
					return index;
				}
				else if (found < key)
				{
					low = index + 1;
				}
				else
				{
					high = index - 1;
				}
			}

			return ~low;
		}

		public T GetOrDefault(ReadOnlySpan<byte> ut8Key)
		{
			var result = this.Find(this._root, ScalarStringTrieKey.GetRaw64(ref ut8Key), ut8Key);
			return result != null ? result.Value : this._default;
		}

		private bool TryAdd(Node parent, ulong key, ReadOnlySpan<byte> trailingKey, T value)
		{
			var nodes = parent.ChildNodes;
			var keys = parent.ChildKeys;

			while (true)
			{
				var index = BinarySearch(keys, key);

				if (index < 0)
				{
					// No matching leaf.
					this.AddNode(parent, key, trailingKey, ~index, value, out _);
					return true;
				}

				var found = nodes[index];
				if (trailingKey.IsEmpty)
				{
					// The leaf matches.
					return false;
				}

				if (found.ChildNodes.Length == 0)
				{
					// Search key is longer than trie path.
					this.AddNode(found, key, trailingKey, 0, value, out _);
					return true;
				}

				nodes = found.ChildNodes;
				keys = found.ChildKeys;

				key = ScalarStringTrieKey.GetRaw64(ref trailingKey);
			}
		}

		private Node? Find(Node parent, ulong key, ReadOnlySpan<byte> trailingKey)
		{
			var nodes = parent.ChildNodes;
			var keys = parent.ChildKeys;

			while (true)
			{
				var index = BinarySearch(keys, key);

				if (index < 0)
				{
					// No matching leaf.
					return null;
				}

				var found = nodes[index];
				if (trailingKey.IsEmpty)
				{
					// The leaf matches.
					return found;
				}

				if (found.ChildNodes.Length == 0)
				{
					// Search key is longer than trie path.
					return null;
				}

				nodes = found.ChildNodes;
				keys = found.ChildKeys;
				key = ScalarStringTrieKey.GetRaw64(ref trailingKey);
			}
		}

		private void AddNode(Node node, ulong key, ReadOnlySpan<byte> trailingKey, int targetIndex, T value, out Node result)
		{
			Array.Resize(ref node.ChildKeys, node.ChildKeys.Length + 1);
			Array.Resize(ref node.ChildNodes, node.ChildNodes.Length + 1);
			var nodes = node.ChildNodes;
			var keys = node.ChildKeys;

			while (true)
			{
				var child =
					trailingKey.IsEmpty ?
						new Node(value, Array.Empty<Node>(), Array.Empty<ulong>()) :
						new Node(this._default, new Node[1], new ulong[1]);

				if (nodes.Length > 1 && targetIndex < nodes.Length - 1)
				{
					// Shift existing.
					Array.Copy(nodes, targetIndex, nodes, targetIndex + 1, nodes.Length - targetIndex - 1);
					Array.Copy(keys, targetIndex, keys, targetIndex + 1, keys.Length - targetIndex - 1);
				}

				nodes[targetIndex] = child;
				keys[targetIndex] = key;

				if (trailingKey.IsEmpty)
				{
					// This is leaf.
					result = child;
					return;
				}

				nodes = child.ChildNodes;
				keys = child.ChildKeys;

				Debug.Assert(nodes.Length == 1);
				Debug.Assert(keys.Length == 1);
				targetIndex = 0;

				key = ScalarStringTrieKey.GetRaw64(ref trailingKey);
			}
		}

		internal sealed class Node
		{
			// There 2 separate array to improve search performance due to CPU cache line and prediction.
			public ulong[] ChildKeys;
			public Node[] ChildNodes;
			public readonly T Value;

			public Node(T value, Node[] childNodes, ulong[] childKeys)
			{
				this.Value = value;
				this.ChildNodes = childNodes;
				this.ChildKeys = childKeys;
			}
		}

		internal IEnumerable<(ulong[] Keys, T Value)> GetDebugView()
			=> GetDebugView(this._root, new List<ulong>());

		private static IEnumerable<(ulong[] Keys, T Value)> GetDebugView(Node node, List<ulong> keyChain)
		{
			if (node.ChildKeys.Length == 0)
			{
				yield return (keyChain.ToArray(), node.Value);
			}
			else
			{
				for (var i = 0; i < node.ChildKeys.Length; i++)
				{
					var childKey = node.ChildKeys[i];
					keyChain.Add(childKey);
					var childNode = node.ChildNodes[i];
					foreach (var item in GetDebugView(childNode, keyChain))
					{
						yield return item;
					}
					keyChain.RemoveAt(keyChain.Count - 1);
				}
			}
		}

		internal sealed class DebuggerProxy
		{
			private readonly ScalarStringTrie<T> _trie;

			public int Count => this._trie.GetDebugView().Count();

			public IEnumerable<(ulong[] Keys, T Value)> Items => this._trie.GetDebugView();

			public NodeDebuggerProxy Root => new NodeDebuggerProxy(Array.Empty<ulong>(), this._trie._root);

			public DebuggerProxy(ScalarStringTrie<T> trie)
			{
				this._trie = trie;
			}
		}

		internal sealed class NodeDebuggerProxy
		{
			private readonly ulong[] _key;

			public ReadOnlySpan<byte> Key => MemoryMarshal.AsBytes<ulong>(this._key);

			public T Value { get; }

			public IReadOnlyList<NodeDebuggerProxy> Children { get; }

			public NodeDebuggerProxy(ulong[] fullKey, Node node)
			{
				this._key = fullKey;
				this.Value = node.Value;
				this.Children =
					node.ChildKeys.Zip(node.ChildNodes).Select(
						(child) =>
						{
							var newFullKey = new ulong[fullKey.Length + 1];
							fullKey.CopyTo(newFullKey, 0);
							newFullKey[newFullKey.Length - 1] = child.First;
							return new NodeDebuggerProxy(newFullKey, child.Second);
						}
					).ToArray();
			}
		}
	}
}
