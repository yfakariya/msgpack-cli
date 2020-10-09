// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache 2 license.
// See the LICENSE in the project root for more information.

using System;
using System.Runtime.CompilerServices;

namespace MsgPack.Internal
{
	internal static class MessagePackThrow
	{
		public static void IsNotType(byte header, long position, Type requestType)
			=> throw new MessageTypeException(position, $"The type is {MessagePackCode.ToString(header)}(0x{header:X2}) but {requestType} is required.");

		public static void RealCannotBeInteger(byte header, long position, Type requestType)
			=> throw new MessageTypeException(position, $"The type is {MessagePackCode.ToString(header)}(0x{header:X2}) is not compatible for {requestType} in current configuration.");

		public static void TypeIsNotArray(byte header, long position)
			=> throw new MessageTypeException(position, $"The type is {MessagePackCode.ToString(header)}(0x{header:X2}) but array is required.");

		public static void TypeIsNotMap(byte header, long position)
			=> throw new MessageTypeException(position, $"The type is {MessagePackCode.ToString(header)}(0x{header:X2}) but map is required.");

		public static void TypeIsNotArrayNorMap(byte header, long position)
			=> throw new MessageTypeException(position, $"The type is {MessagePackCode.ToString(header)}(0x{header:X2}) but array or map is required.");

		public static void IsNotNumber(byte header, long position, Type requestType)
			=> throw new MessageTypeException(position, $"The type is {MessagePackCode.ToString(header)}(0x{header:X2}) but it is not compatible for {requestType}.");

		public static void TooLargeByteLength(byte header, long position, long byteLength)
			=> throw new MessageTypeException(position, $"The length of string {MessagePackCode.ToString(header)}(0x{header:X2}) {byteLength:#,0}(0x{byteLength:X8}) exceeds Int32.MaxValue (0x7FFFFFFF).");

		public static void TooLargeArrayOrMapLength(byte header, long position, long byteLength)
			=> throw new MessageTypeException(position, $"The length of array or map {MessagePackCode.ToString(header)}(0x{header:X2}) {byteLength:#,0}(0x{byteLength:X8}) exceeds Int32.MaxValue (0x7FFFFFFF).");

		public static void OutOfRangeExtensionTypeCode(int typeCode, [CallerArgumentExpression("typeCode")] string? paramName = default)
			=> throw new ArgumentOutOfRangeException(paramName, $"A type code of MessagePack must be non negative 1byte integer (between 0 to 127 inclusive). '{typeCode}' is too large.");

		public static void IsNotUtf8String(byte header, long position)
			=> throw new MessageTypeException(position, $"The type is {MessagePackCode.ToString(header)}(0x{header:X2}) but it is not compatible for UTF8String.");

		public static void IsNotExtension(byte header, long position)
			=> throw new MessageTypeException(position, $"The type is {MessagePackCode.ToString(header)}(0x{header:X2}) but it is not extension.");

		public static void InvalidTypeCode(long typeCode)
			=> throw new ArgumentOutOfRangeException("typeCode", $"Extension type code for MessagePack must be 1 byte, but 0x{typeCode:X} is specified.");
	}
}
