// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

using System.Collections.Generic;

namespace MsgPack
{
	public partial class MessagePackObjectDictionary : IReadOnlyDictionary<MessagePackObject, MessagePackObject>
	{
		IEnumerable<MessagePackObject> IReadOnlyDictionary<MessagePackObject, MessagePackObject>.Keys => this.Keys;

		IEnumerable<MessagePackObject> IReadOnlyDictionary<MessagePackObject, MessagePackObject>.Values => this.Values;

#if !UNITY
		public partial class KeySet :
#else // !UNITY
		public partial class KeyCollection :
#endif // else !UNITY
			IReadOnlyCollection<MessagePackObject>
		{ }

		public partial class ValueCollection : IReadOnlyCollection<MessagePackObject> { }
	}
}
