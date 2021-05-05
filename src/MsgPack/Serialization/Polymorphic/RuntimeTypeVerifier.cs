// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Runtime.Serialization;
using System.Threading;

namespace MsgPack.Serialization.Polymorphic
{
	internal static class RuntimeTypeVerifier
	{
		private const int CacheSize = 1000;

		private static readonly ReaderWriterLockSlim s_resultCacheLock = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);
		private static readonly Dictionary<KeyValuePair<string, string>, bool> s_resultCache = new Dictionary<KeyValuePair<string, string>, bool>(CacheSize);
		private static readonly Queue<KeyValuePair<string, string>> s_histories = new Queue<KeyValuePair<string, string>>(CacheSize);

		public static void Verify(AssemblyName assemblyName, string typeFullName, Func<PolymorphicTypeVerificationContext, bool> typeVerifier)
		{
			var assemblyFullName = assemblyName.FullName;
			if (!VerifyCore(assemblyName, assemblyFullName, typeFullName, typeVerifier))
			{
				throw new SerializationException(String.Format(CultureInfo.CurrentCulture, "Type verifier rejects type '{0}'", typeFullName + ", " + assemblyFullName));
			}
		}

		private static bool VerifyCore(AssemblyName assemblyName, string assemblyFullName, string typeFullName, Func<PolymorphicTypeVerificationContext, bool> typeVerifier)
		{
			var key = new KeyValuePair<string, string>(assemblyFullName, typeFullName);

			s_resultCacheLock.EnterReadLock();
			try
			{
				if (s_resultCache.TryGetValue(key, out var cachedResult))
				{
					return cachedResult;
				}
			}
			finally
			{
				s_resultCacheLock.ExitReadLock();
			}

			var result = typeVerifier(new PolymorphicTypeVerificationContext(typeFullName, assemblyName, assemblyFullName));

			s_resultCacheLock.EnterWriteLock();
			try
			{
				var count = s_resultCache.Count;
				s_resultCache[key] = result;
				if (count < s_resultCache.Count && CacheSize < s_resultCache.Count)
				{
					// Added. Start eviction.
					var removalKey = s_histories.Dequeue();
					var removed = s_resultCache.Remove(removalKey);
					Debug.Assert(removed);
				}

				Debug.Assert(s_histories.Count < 1000);
				s_histories.Enqueue(key);
			}
			finally
			{
				s_resultCacheLock.ExitWriteLock();
			}

			return result;
		}
	}
}
