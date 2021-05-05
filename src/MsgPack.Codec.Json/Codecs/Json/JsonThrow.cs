// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

using System;
using System.Buffers;
using System.Linq;
using System.Text;

namespace MsgPack.Codecs.Json
{
	internal static class JsonThrow
	{
		public static void TooShortUtf8()
			=> throw new FormatException($"Input UTF-8 sequence is invalid. The sequence unexpectedly ends.");

		public static CollectionType CollectionHeaderDecodingIsNotSupported(out int itemsCount, out int requestHint)
			=> throw new NotSupportedException("JSON does not support collection length.");

		public static int CollectionHeaderDecodingIsNotSupported(out int requestHint)
			=> throw new NotSupportedException("JSON does not support collection length.");

		public static void DrainIsNotSupported(out int requestHint)
			=> throw new NotSupportedException("JSON does not support collection length.");

		public static void MalformedUtf8(in ReadOnlySpan<byte> sequence, long position)
			=> throw new MessageFormatException(position, $"Input UTF-8 has invalid sequence {BitConverter.ToString(sequence.ToArray())}.");

		public static void MalformedUtf8(in ReadOnlySequence<byte> sequence, long position)
			=> throw new MessageFormatException(position, $"Input UTF-8 has invalid sequence {BitConverter.ToString(sequence.ToArray())}.");

		public static void SurrogateCharInUtf8(long position, int codePoint)
			=> throw new MessageFormatException(position, $"Input UTF-8 has surrogate charactor U+{codePoint:X4}.");

		public static void IsNotArrayNorObject(in ReadOnlySequence<byte> sequence, long position)
			=> throw new MessageFormatException(position, $"Char {StringEscape.Stringify(sequence)} at position {position:#,0} is not start of array nor object.");

		public static void IsNotArray(long position)
			=> throw new MessageFormatException(position, $"Char '{{' is not start of array.");

		public static void IsNotObject(long position)
			=> throw new MessageFormatException(position, $"Char '[' is not start of object.");

		public static void IsNotType(Type type, in ReadOnlySequence<byte> unit, long position)
			=> throw new MessageFormatException(position, $"Char {StringEscape.Stringify(unit)} is not valid for {type} value.");

		public static void TooLongNumber(long numberLength, long maxLength, long position)
			=> throw new MessageFormatException(position, $"The number has {numberLength:#,0} charactors, but maximum allowed length is {maxLength:#,0}.");

		public static void IsNotStringStart(long position, ReadOnlySpan<byte> validQuotations)
		{
			if (validQuotations.Length == 1)
			{
				throw new MessageFormatException(position, $"String must starts with '{(char)validQuotations[0]}' (U+00{validQuotations[0]:X2}).");
			}
			else
			{
				throw new MessageFormatException(position, $"String must starts with one of [{String.Join(", ", validQuotations.ToArray().Select(b => $"'{(char)b}'(U + 00{b:X2})"))}].");
			}
		}

		public static void InvalidEscapeSequence(long position, byte escaped)
			=> throw new MessageFormatException(position, $"Escape sequence '\\{(char)escaped}' is not valid.");

		public static void InvalidUnicodeEscapeSequence(long position, Span<byte> chars)
			=> throw new MessageFormatException(position, $"Escape sequence '\\u{Encoding.UTF8.GetString(chars)}' is not valid.");

		public static void OrphanSurrogate(long position, int codePoint)
			=> throw new MessageFormatException(position, $"Surrogate char U+{codePoint:X4} is not valid.");

		public static void InvalidBase64(long position, string value)
			=> throw new MessageFormatException(position, $"The string '{StringEscape.ForDisplay(value)}' is not valid BASE64 sequence.");

		public static void UnexpectedToken(long position, byte token)
			=> throw new MessageFormatException(position, $"A token {(token >= 0x80 ? $"0x{token:X2}" : (token < 0x7F && token >= 0x20 ? $"'{(char)token}'" : $"U+00{token:X2}"))} is not expected.");
	}
}
