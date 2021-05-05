// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

using System.Buffers;
using MsgPack.Serialization;

namespace MsgPack.Internal
{
#warning TODO: tuning default as backward compatible
	internal static class OptionsDefaults
	{
		/// <summary>
		///		<c>0x7FFFFFC7</c>, defined by CoreCLR implementation.
		/// </summary>
		public const int MaxSingleByteCollectionLength = 0x7FFFFFC7;

		/// <summary>
		///		<c>0X7FEFFFFF</c>, defined by CoreCLR implementation.
		/// </summary>
		public const int MaxMultiByteCollectionLength = 0X7FEFFFFF;

		/// <summary>
		///		<c>128Mi</c>
		/// </summary>
		public static readonly int CancellationSupportThreshold = 128 * 1024 * 1024; // About 0.1 sec in desktop, more for IoT

		/// <summary>
		///		<c>32</c>
		/// </summary>
		public static readonly int MaxNumberLengthInBytes = 32;

		/// <summary>
		///		<c>256Mi</c>
		/// </summary>
		public static readonly int MaxStringLengthInBytes = 256 * 1024 * 1024;

		/// <summary>
		///		<c>256Mi</c>
		/// </summary>
		public static readonly int MaxBinaryLengthInBytes = 256 * 1024 * 1024;

		/// <summary>
		///		<c>2Mi</c>
		/// </summary>
		public static readonly int MaxByteBufferLength = 2 * 1024 * 1024;

		/// <summary>
		///		<c>2Mi</c>
		/// </summary>
		public static readonly int MaxCharBufferLength = 2 * 1024 * 1024;

		/// <summary>
		///		<c>1Mi</c>
		/// </summary>
		public static readonly int MaxArrayLength = 1024 * 1024;

		/// <summary>
		///		<c>1Mi</c>
		/// </summary>
		public static readonly int MaxMapCount = 1024 * 1024;

		/// <summary>
		///		<c>256</c>
		/// </summary>
		public static readonly int MaxPropertyKeyLength = 256;

		/// <summary>
		///		<c>100</c>
		/// </summary>
		public static readonly int MaxDepth = 100;

		/// <summary>
		///		<see cref="ArrayPool{T}.Shared"/>
		/// </summary>
		public static readonly ArrayPool<byte> ByteBufferPool = ArrayPool<byte>.Shared;

		/// <summary>
		///		<see cref="ArrayPool{T}.Shared"/>
		/// </summary>
		public static readonly ArrayPool<char> CharBufferPool = ArrayPool<char>.Shared;

		/// <summary>
		///		<c>false</c>
		/// </summary>
		public static readonly bool ClearsBufferOnReturn = false;

		/// <summary>
		///		<c>true</c>
		/// </summary>
		public static readonly bool CanTreatRealAsInteger = true;

		/// <summary>
		///		<c>null</c>
		/// </summary>
		public static readonly SerializationMethod? PreferredSerializationMethod = null;
	}
}
