// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("MsgPack.Compatibility")]

#if DEBUG
[assembly: InternalsVisibleTo("MsgPack.Codec.UnitTest")]
#endif // DEBUG
