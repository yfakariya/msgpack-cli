// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("MsgPack.Codec")]
[assembly: InternalsVisibleTo("MsgPack.Codec.Json")]
[assembly: InternalsVisibleTo("MsgPack.Serialization")]
[assembly: InternalsVisibleTo("MsgPack.Compatibility")]

#if DEBUG
[assembly: InternalsVisibleTo("MsgPack.Core.UnitTest")]
#endif // DEBUG

#if BENCHMARK || DEBUG
[assembly: InternalsVisibleTo("Benchmark")]
#endif // BENCHMARK || DEBUG

#warning TODO: Specify versions in build script with /p:
#warning TODO: MsgPackObject, MsgPackObjectDictionary, MsgPackString should be .Compatibility assembly
