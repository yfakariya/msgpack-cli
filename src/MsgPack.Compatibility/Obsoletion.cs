// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

using System;

namespace MsgPack
{
	/// <summary>
	///		Defines <see cref="ObsoleteAttribute"/> properties.
	/// </summary>
	internal static class Obsoletion
	{
		private const string V2MigrationDoc = "https://github.com/msgpack/msgpack-cli/doc/migration-from-v1-v2.md";

		public static class UseBuilder
		{
			public const string Message = "Use SerializationConctextBuilder instead.";
			public const string DiagId = "MSGPACKCLI00001";
			public const string Url = V2MigrationDoc;
		}

		public static class AsyncIsByDefault
		{
			public const string Message = "WithAsync is no longer used by generator. All serializers have coarce grained async serialization now.";
			public const string DiagId = "MSGPACKCLI00002";
			public const string Url = V2MigrationDoc;
		}

		public static class NewCodec
		{
			public const string Message = "Packer, Unpacker and related types are obsolete. Use new more efficient MessagePackEncoder and MessagePackDecoder instead.";
			public const string DiagId = "MSGPACKCLI00003";
			public const string Url = V2MigrationDoc;
		}

		public static class NewSerializer
		{
			public const string Message = "MessagePackSerializer and related types are obsolete. Use new more generic Serializer and ObjectSerializer instead.";
			public const string DiagId = "MSGPACKCLI00004";
			public const string Url = V2MigrationDoc;
		}

		public static class GeneratorNoLongerConfigurable
		{
			public const string Message = "SerializationMethodGeneratorOption is no longer used by generator. ";
			public const string DiagId = "MSGPACKCLI00006";
			public const string Url = V2MigrationDoc;
		}
	}
}
