// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

using System;
using System.Buffers.Binary;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MsgPack.Internal
{
	internal static class ScalarStringTrieKey
	{
		public static ulong GetRaw64(ref ReadOnlySpan<byte> source)
		{
			Debug.Assert(!source.IsEmpty);
			if (source.Length >= sizeof(ulong))
			{
				var result = MemoryMarshal.Cast<byte, ulong>(source)[0];
				source = source.Slice(sizeof(ulong));
				return result;
			}
			else
			{
				ulong result;
				unchecked
				{
					switch (source.Length)
					{
						case 1:
						{
							result = source[0];
							break;
						}
						case 2:
						{
							result = BinaryPrimitives.ReadUInt16LittleEndian(source);
							break;
						}
						case 3:
						{
							result = BinaryPrimitives.ReadUInt16LittleEndian(source);
							source = source.Slice(2);
							result |= (uint)(source[0] << 16);
							break;
						}
						case 4:
						{
							result = BinaryPrimitives.ReadUInt32LittleEndian(source);
							break;
						}
						case 5:
						{
							result = BinaryPrimitives.ReadUInt32LittleEndian(source);
							source = source.Slice(4);
							result |= ((ulong)source[0] << 32);
							break;
						}
						case 6:
						{
							result = BinaryPrimitives.ReadUInt32LittleEndian(source);
							source = source.Slice(4);
							result |= ((ulong)BinaryPrimitives.ReadUInt16LittleEndian(source) << 32);
							break;
						}
						default: // 7
						{
							result = BinaryPrimitives.ReadUInt32LittleEndian(source);
							source = source.Slice(4);
							result |= ((ulong)BinaryPrimitives.ReadUInt16LittleEndian(source) << 32);
							source = source.Slice(2);
							result |= ((ulong)source[0] << 48);
							break;
						}
					}
				}

				source = ReadOnlySpan<byte>.Empty;
				return result;
			}
		}
	}
}
