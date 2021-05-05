// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("MsgPack.Core")]
[assembly: InternalsVisibleTo("MsgPack.Json")]
[assembly: InternalsVisibleTo("MsgPack.Serialization")]
[assembly: InternalsVisibleTo("MsgPack.Compatibility")]

#warning TODO: This assembly should be "MsgPack.Core"
#warning TODO: Some of ".Internal" namespace contents should be ".Codec" namespace
#warning TODO: Specify versions in build script with /p:
#warning TODO: MsgPackObject, MsgPackObjectDictionary, MsgPackString should be .Compatibility assembly
