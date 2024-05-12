#region -- License Terms --
//
// MessagePack for CLI
//
// Copyright (C) 2010-2012 FUJIWARA, Yusuke
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//        http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//
#endregion -- License Terms --

using System;
using System.IO;
using System.Linq;
using System.Text;
#if !MSTEST
using NUnit.Framework;
#else
using TestFixtureAttribute = Microsoft.VisualStudio.TestPlatform.UnitTestFramework.TestClassAttribute;
using TestAttribute = Microsoft.VisualStudio.TestPlatform.UnitTestFramework.TestMethodAttribute;
using TimeoutAttribute = NUnit.Framework.TimeoutAttribute;
using Assert = NUnit.Framework.Assert;
using Is = NUnit.Framework.Is;
#endif

namespace MsgPack
{
	[TestFixture]
	public class MessagePackObjectTest_String
	{
		private const string _japanese = "\uFF21\uFF22\uFF23";

		[Test]
		public void TestAsString_EncodingMissmatch()
		{
			var target = new MessagePackObject( Encoding.Unicode.GetBytes( _japanese ) );
			Assert.Throws<InvalidOperationException>( () => target.AsString() );
		}

		[Test]
		public void TestAsString_Null_Success()
		{
			var target = new MessagePackObject( default( string ) );
			Assert.That( target.AsString(), Is.Null );
		}

		[Test]
		public void TestAsString_IsNotString()
		{
			var target = new MessagePackObject( 0 );
			Assert.Throws<InvalidOperationException>( () => target.AsString() );
		}

		[Test]
		public void TestAsString1_EncodingMissmatchAndThrowsDecoderFallbackException()
		{
			var target = new MessagePackObject( Encoding.Unicode.GetBytes( _japanese ) );
			Assert.Throws<InvalidOperationException>( () => target.AsString( new UTF8Encoding( encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true ) ) );
		}

		[Test]
		public void TestAsString1_EncodingMissmatchAndReturnsNull_Null()
		{
			var target = new MessagePackObject( Encoding.Unicode.GetBytes( _japanese ) );
			Assert.Throws<InvalidOperationException>( () => target.AsString( new UTF8Encoding( encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: false ) ) );
		}

		[Test]
		public void TestAsString1_EncodingIsNull()
		{
			var target = new MessagePackObject( Encoding.Unicode.GetBytes( _japanese ) );
			Assert.Throws<ArgumentNullException>( () => target.AsString( null ) );
		}

#if !NETFX_CORE && !SILVERLIGHT
		[Test]
		public void TestAsString1_EncodingIsUtf32_SpecifyUtf32_Success()
		{
			var target = new MessagePackObject( Encoding.UTF32.GetBytes( _japanese ) );
			var result = target.AsString( Encoding.UTF32 );
			Assert.That( result, Is.EqualTo( _japanese ) );
		}

		[Test]
		public void TestAsString1_EncodingIsUtf32_SpecifyNotUtf32_Fail()
		{
			var target = new MessagePackObject( Encoding.UTF32.GetBytes( _japanese ) );
			Assert.Throws<InvalidOperationException>( () => target.AsString( new UTF8Encoding( encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true ) ) );
		}

		[Test]
		public void TestAsString1_EncodingIsNotUtf32_SpecifyUtf32_Fail()
		{
#if MONO || XAMDROID || UNITY
#warning TODO:Workaround
			Assert.Inconclusive( "UTF32Encoding does not throw exception on Mono FCL." );
#endif // MONO || XAMDROID
			var target = new MessagePackObject( new byte[] { 0xFF } );
			Assert.Throws<InvalidOperationException>( () => target.AsString( new UTF32Encoding( bigEndian: false, byteOrderMark: false, throwOnInvalidCharacters: true ) ) );
		}
#endif // !NETFX_CORE && !SILVERLIGHT

		[Test]
		public void TestAsString1_Null_Success()
		{
			var target = new MessagePackObject( default( string ) );
			Assert.That( target.AsString( Encoding.UTF8 ), Is.Null );
		}

		[Test]
		public void TestAsString1_IsNotString()
		{
			var target = new MessagePackObject( 0 );
			Assert.Throws<InvalidOperationException>( () => target.AsString( Encoding.UTF8 ) );
		}

		[Test]
		public void TestAsStringUtf8_Normal_Success()
		{
			var target = new MessagePackObject( Encoding.UTF8.GetBytes( _japanese ) );
			Assert.That( target.AsStringUtf8(), Is.EqualTo( _japanese ) );
		}

		[Test]
		public void TestAsStringUtf8_Empty_Success()
		{
			var target = new MessagePackObject( new byte[ 0 ] );
			Assert.That( target.AsStringUtf8(), Is.EqualTo( "" ) );
		}

		[Test]
		public void TestAsStringUtf8_Null_Success()
		{
			var target = new MessagePackObject( default( string ) );
			Assert.That( target.AsStringUtf8(), Is.Null );
		}

		[Test]
		public void TestAsStringUtf8_IsNotString()
		{
			var target = new MessagePackObject( 0 );
			Assert.Throws<InvalidOperationException>( () => target.AsStringUtf8() );
		}

		[Test]
		public void TestAsStringUtf8_EncodingMissmatch()
		{
			var target = new MessagePackObject( Encoding.Unicode.GetBytes( _japanese ) );
			Assert.Throws<InvalidOperationException>( () => target.AsStringUtf8() );
		}

		[Test]
		public void TestAsStringUtf16_Utf16LEWithBom_Success()
		{
			var target = new MessagePackObject( Encoding.Unicode.GetPreamble().Concat( Encoding.Unicode.GetBytes( _japanese ) ).ToArray() );
			Assert.That( target.AsStringUtf16(), Is.EqualTo( _japanese ) );
		}

		[Test]
		public void TestAsStringUtf16_Utf16LEWithoutBom_CannotDetected()
		{
			var target = new MessagePackObject( Encoding.Unicode.GetBytes( _japanese ) );
			string result;
			try
			{
				result = target.AsStringUtf16();
			}
			catch ( InvalidOperationException )
			{
				// It is OK. The bytes cannot be decoded as UTF-16BE.
				return;
			}

			// It is OK. The bytes incidentally can be decoded as UTF-16BE.
			Assert.That( result, Is.Not.EqualTo( _japanese ) );
		}

		[Test]
		public void TestAsStringUtf16_Utf16BEWithBom_Success()
		{
			var target = new MessagePackObject( Encoding.BigEndianUnicode.GetPreamble().Concat( Encoding.BigEndianUnicode.GetBytes( _japanese ) ).ToArray() );
			Assert.That( target.AsStringUtf16(), Is.EqualTo( _japanese ) );
		}

		[Test]
		public void TestAsStringUtf16_Utf16BEWithoutBom_Success()
		{
			var target = new MessagePackObject( Encoding.BigEndianUnicode.GetBytes( _japanese ) );
			Assert.That( target.AsStringUtf16(), Is.EqualTo( _japanese ) );
		}

		[Test]
		public void TestAsStringUtf16_Empty_Success()
		{
			var target = new MessagePackObject( new byte[ 0 ] );
			Assert.That( target.AsStringUtf16(), Is.EqualTo( "" ) );
		}

		[Test]
		public void TestAsStringUtf16_ForNonEncoded_Success()
		{
			var target = new MessagePackObject( _japanese );
			Assert.That( target.AsStringUtf16(), Is.EqualTo( _japanese ) );
		}

		[Test]
		public void TestAsStringUtf16_EncodingMissmatch()
		{
			var target = new MessagePackObject( Encoding.UTF8.GetBytes( _japanese ) );
			Assert.Throws<InvalidOperationException>( () => target.AsStringUtf16() );
		}

		[Test]
		public void TestAsStringUtf16_Null_Success()
		{
			var target = new MessagePackObject( default( string ) );
			Assert.That( target.AsStringUtf16(), Is.Null );
		}

		[Test]
		public void TestAsStringUtf16_IsNotString()
		{
			var target = new MessagePackObject( 0 );
			Assert.Throws<InvalidOperationException>( () => target.AsStringUtf16() );
		}

		[Test]
		public void TestAsStringUtf16_NonStringBinary()
		{
			var target = new MessagePackObject( new byte[] { 0xFF } );
			Assert.Throws<InvalidOperationException>( () => target.AsStringUtf16() );
		}
	}
}
