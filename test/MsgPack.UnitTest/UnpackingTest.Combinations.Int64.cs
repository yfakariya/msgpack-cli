
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
using System.Collections.Generic;
using System.Diagnostics;
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
	public partial class UnpackingTest_Combinations_Int64
	{
		[Test]
		public void TestUnpackInt64_ByteArray_Int64MinValueAsInt64_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xD3, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 } );
			Assert.That( result.ReadCount, Is.EqualTo( 9 ) );
			Assert.That( result.Value, Is.EqualTo( -9223372036854775808L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_Int64MinValueAsInt64_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD3, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 9 ) );
				Assert.That( result, Is.EqualTo( -9223372036854775808L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_Int32MinValueMinusOneAsInt64_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xD3, 0xFF, 0xFF, 0xFF, 0xFF, 0x7F, 0xFF, 0xFF, 0xFF } );
			Assert.That( result.ReadCount, Is.EqualTo( 9 ) );
			Assert.That( result.Value, Is.EqualTo( -2147483649L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_Int32MinValueMinusOneAsInt64_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD3, 0xFF, 0xFF, 0xFF, 0xFF, 0x7F, 0xFF, 0xFF, 0xFF } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 9 ) );
				Assert.That( result, Is.EqualTo( -2147483649L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_Int32MinValueAsInt64_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xD3, 0xFF, 0xFF, 0xFF, 0xFF, 0x80, 0x00, 0x00, 0x00 } );
			Assert.That( result.ReadCount, Is.EqualTo( 9 ) );
			Assert.That( result.Value, Is.EqualTo( -2147483648L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_Int32MinValueAsInt64_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD3, 0xFF, 0xFF, 0xFF, 0xFF, 0x80, 0x00, 0x00, 0x00 } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 9 ) );
				Assert.That( result, Is.EqualTo( -2147483648L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_Int32MinValueAsInt32_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xD2, 0x80, 0x00, 0x00, 0x00 } );
			Assert.That( result.ReadCount, Is.EqualTo( 5 ) );
			Assert.That( result.Value, Is.EqualTo( -2147483648L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_Int32MinValueAsInt32_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD2, 0x80, 0x00, 0x00, 0x00 } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 5 ) );
				Assert.That( result, Is.EqualTo( -2147483648L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_Int16MinValueMinusOneAsInt64_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xD3, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x7F, 0xFF } );
			Assert.That( result.ReadCount, Is.EqualTo( 9 ) );
			Assert.That( result.Value, Is.EqualTo( -32769L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_Int16MinValueMinusOneAsInt64_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD3, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x7F, 0xFF } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 9 ) );
				Assert.That( result, Is.EqualTo( -32769L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_Int16MinValueMinusOneAsInt32_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xD2, 0xFF, 0xFF, 0x7F, 0xFF } );
			Assert.That( result.ReadCount, Is.EqualTo( 5 ) );
			Assert.That( result.Value, Is.EqualTo( -32769L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_Int16MinValueMinusOneAsInt32_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD2, 0xFF, 0xFF, 0x7F, 0xFF } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 5 ) );
				Assert.That( result, Is.EqualTo( -32769L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_Int16MinValueAsInt64_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xD3, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x80, 0x00 } );
			Assert.That( result.ReadCount, Is.EqualTo( 9 ) );
			Assert.That( result.Value, Is.EqualTo( -32768L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_Int16MinValueAsInt64_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD3, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x80, 0x00 } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 9 ) );
				Assert.That( result, Is.EqualTo( -32768L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_Int16MinValueAsInt32_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xD2, 0xFF, 0xFF, 0x80, 0x00 } );
			Assert.That( result.ReadCount, Is.EqualTo( 5 ) );
			Assert.That( result.Value, Is.EqualTo( -32768L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_Int16MinValueAsInt32_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD2, 0xFF, 0xFF, 0x80, 0x00 } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 5 ) );
				Assert.That( result, Is.EqualTo( -32768L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_Int16MinValueAsInt16_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xD1, 0x80, 0x00 } );
			Assert.That( result.ReadCount, Is.EqualTo( 3 ) );
			Assert.That( result.Value, Is.EqualTo( -32768L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_Int16MinValueAsInt16_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD1, 0x80, 0x00 } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 3 ) );
				Assert.That( result, Is.EqualTo( -32768L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_SByteMinValueMinusOneAsInt64_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xD3, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x7F } );
			Assert.That( result.ReadCount, Is.EqualTo( 9 ) );
			Assert.That( result.Value, Is.EqualTo( -129L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_SByteMinValueMinusOneAsInt64_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD3, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x7F } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 9 ) );
				Assert.That( result, Is.EqualTo( -129L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_SByteMinValueMinusOneAsInt32_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xD2, 0xFF, 0xFF, 0xFF, 0x7F } );
			Assert.That( result.ReadCount, Is.EqualTo( 5 ) );
			Assert.That( result.Value, Is.EqualTo( -129L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_SByteMinValueMinusOneAsInt32_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD2, 0xFF, 0xFF, 0xFF, 0x7F } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 5 ) );
				Assert.That( result, Is.EqualTo( -129L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_SByteMinValueMinusOneAsInt16_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xD1, 0xFF, 0x7F } );
			Assert.That( result.ReadCount, Is.EqualTo( 3 ) );
			Assert.That( result.Value, Is.EqualTo( -129L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_SByteMinValueMinusOneAsInt16_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD1, 0xFF, 0x7F } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 3 ) );
				Assert.That( result, Is.EqualTo( -129L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_SByteMinValueAsInt64_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xD3, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x80 } );
			Assert.That( result.ReadCount, Is.EqualTo( 9 ) );
			Assert.That( result.Value, Is.EqualTo( -128L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_SByteMinValueAsInt64_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD3, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x80 } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 9 ) );
				Assert.That( result, Is.EqualTo( -128L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_SByteMinValueAsInt32_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xD2, 0xFF, 0xFF, 0xFF, 0x80 } );
			Assert.That( result.ReadCount, Is.EqualTo( 5 ) );
			Assert.That( result.Value, Is.EqualTo( -128L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_SByteMinValueAsInt32_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD2, 0xFF, 0xFF, 0xFF, 0x80 } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 5 ) );
				Assert.That( result, Is.EqualTo( -128L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_SByteMinValueAsInt16_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xD1, 0xFF, 0x80 } );
			Assert.That( result.ReadCount, Is.EqualTo( 3 ) );
			Assert.That( result.Value, Is.EqualTo( -128L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_SByteMinValueAsInt16_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD1, 0xFF, 0x80 } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 3 ) );
				Assert.That( result, Is.EqualTo( -128L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_SByteMinValueAsInt8_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xD0, 0x80 } );
			Assert.That( result.ReadCount, Is.EqualTo( 2 ) );
			Assert.That( result.Value, Is.EqualTo( -128L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_SByteMinValueAsInt8_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD0, 0x80 } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 2 ) );
				Assert.That( result, Is.EqualTo( -128L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_NegativeFixNumMinValueMinusOneAsInt64_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xD3, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xDF } );
			Assert.That( result.ReadCount, Is.EqualTo( 9 ) );
			Assert.That( result.Value, Is.EqualTo( -33L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_NegativeFixNumMinValueMinusOneAsInt64_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD3, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xDF } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 9 ) );
				Assert.That( result, Is.EqualTo( -33L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_NegativeFixNumMinValueMinusOneAsInt32_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xD2, 0xFF, 0xFF, 0xFF, 0xDF } );
			Assert.That( result.ReadCount, Is.EqualTo( 5 ) );
			Assert.That( result.Value, Is.EqualTo( -33L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_NegativeFixNumMinValueMinusOneAsInt32_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD2, 0xFF, 0xFF, 0xFF, 0xDF } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 5 ) );
				Assert.That( result, Is.EqualTo( -33L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_NegativeFixNumMinValueMinusOneAsInt16_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xD1, 0xFF, 0xDF } );
			Assert.That( result.ReadCount, Is.EqualTo( 3 ) );
			Assert.That( result.Value, Is.EqualTo( -33L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_NegativeFixNumMinValueMinusOneAsInt16_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD1, 0xFF, 0xDF } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 3 ) );
				Assert.That( result, Is.EqualTo( -33L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_NegativeFixNumMinValueMinusOneAsInt8_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xD0, 0xDF } );
			Assert.That( result.ReadCount, Is.EqualTo( 2 ) );
			Assert.That( result.Value, Is.EqualTo( -33L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_NegativeFixNumMinValueMinusOneAsInt8_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD0, 0xDF } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 2 ) );
				Assert.That( result, Is.EqualTo( -33L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_NegativeFixNumMinValueAsInt64_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xD3, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xE0 } );
			Assert.That( result.ReadCount, Is.EqualTo( 9 ) );
			Assert.That( result.Value, Is.EqualTo( -32L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_NegativeFixNumMinValueAsInt64_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD3, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xE0 } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 9 ) );
				Assert.That( result, Is.EqualTo( -32L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_NegativeFixNumMinValueAsInt32_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xD2, 0xFF, 0xFF, 0xFF, 0xE0 } );
			Assert.That( result.ReadCount, Is.EqualTo( 5 ) );
			Assert.That( result.Value, Is.EqualTo( -32L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_NegativeFixNumMinValueAsInt32_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD2, 0xFF, 0xFF, 0xFF, 0xE0 } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 5 ) );
				Assert.That( result, Is.EqualTo( -32L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_NegativeFixNumMinValueAsInt16_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xD1, 0xFF, 0xE0 } );
			Assert.That( result.ReadCount, Is.EqualTo( 3 ) );
			Assert.That( result.Value, Is.EqualTo( -32L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_NegativeFixNumMinValueAsInt16_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD1, 0xFF, 0xE0 } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 3 ) );
				Assert.That( result, Is.EqualTo( -32L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_NegativeFixNumMinValueAsInt8_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xD0, 0xE0 } );
			Assert.That( result.ReadCount, Is.EqualTo( 2 ) );
			Assert.That( result.Value, Is.EqualTo( -32L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_NegativeFixNumMinValueAsInt8_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD0, 0xE0 } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 2 ) );
				Assert.That( result, Is.EqualTo( -32L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_NegativeFixNumMinValueAsNegativeFixNumMinus32_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xE0 } );
			Assert.That( result.ReadCount, Is.EqualTo( 1 ) );
			Assert.That( result.Value, Is.EqualTo( -32L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_NegativeFixNumMinValueAsNegativeFixNumMinus32_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xE0 } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 1 ) );
				Assert.That( result, Is.EqualTo( -32L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_MinusOneAsInt64_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xD3, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF } );
			Assert.That( result.ReadCount, Is.EqualTo( 9 ) );
			Assert.That( result.Value, Is.EqualTo( -1L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_MinusOneAsInt64_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD3, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 9 ) );
				Assert.That( result, Is.EqualTo( -1L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_MinusOneAsInt32_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xD2, 0xFF, 0xFF, 0xFF, 0xFF } );
			Assert.That( result.ReadCount, Is.EqualTo( 5 ) );
			Assert.That( result.Value, Is.EqualTo( -1L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_MinusOneAsInt32_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD2, 0xFF, 0xFF, 0xFF, 0xFF } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 5 ) );
				Assert.That( result, Is.EqualTo( -1L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_MinusOneAsInt16_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xD1, 0xFF, 0xFF } );
			Assert.That( result.ReadCount, Is.EqualTo( 3 ) );
			Assert.That( result.Value, Is.EqualTo( -1L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_MinusOneAsInt16_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD1, 0xFF, 0xFF } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 3 ) );
				Assert.That( result, Is.EqualTo( -1L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_MinusOneAsInt8_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xD0, 0xFF } );
			Assert.That( result.ReadCount, Is.EqualTo( 2 ) );
			Assert.That( result.Value, Is.EqualTo( -1L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_MinusOneAsInt8_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD0, 0xFF } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 2 ) );
				Assert.That( result, Is.EqualTo( -1L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_MinusOneAsNegativeFixNumMinus1_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xFF } );
			Assert.That( result.ReadCount, Is.EqualTo( 1 ) );
			Assert.That( result.Value, Is.EqualTo( -1L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_MinusOneAsNegativeFixNumMinus1_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xFF } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 1 ) );
				Assert.That( result, Is.EqualTo( -1L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_ZeroAsInt64_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xD3, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 } );
			Assert.That( result.ReadCount, Is.EqualTo( 9 ) );
			Assert.That( result.Value, Is.EqualTo( 0L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_ZeroAsInt64_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD3, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 9 ) );
				Assert.That( result, Is.EqualTo( 0L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_ZeroAsUInt64_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xCF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 } );
			Assert.That( result.ReadCount, Is.EqualTo( 9 ) );
			Assert.That( result.Value, Is.EqualTo( 0L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_ZeroAsUInt64_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xCF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 9 ) );
				Assert.That( result, Is.EqualTo( 0L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_ZeroAsInt32_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xD2, 0x00, 0x00, 0x00, 0x00 } );
			Assert.That( result.ReadCount, Is.EqualTo( 5 ) );
			Assert.That( result.Value, Is.EqualTo( 0L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_ZeroAsInt32_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD2, 0x00, 0x00, 0x00, 0x00 } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 5 ) );
				Assert.That( result, Is.EqualTo( 0L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_ZeroAsUInt32_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xCE, 0x00, 0x00, 0x00, 0x00 } );
			Assert.That( result.ReadCount, Is.EqualTo( 5 ) );
			Assert.That( result.Value, Is.EqualTo( 0L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_ZeroAsUInt32_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xCE, 0x00, 0x00, 0x00, 0x00 } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 5 ) );
				Assert.That( result, Is.EqualTo( 0L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_ZeroAsInt16_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xD1, 0x00, 0x00 } );
			Assert.That( result.ReadCount, Is.EqualTo( 3 ) );
			Assert.That( result.Value, Is.EqualTo( 0L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_ZeroAsInt16_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD1, 0x00, 0x00 } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 3 ) );
				Assert.That( result, Is.EqualTo( 0L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_ZeroAsUInt16_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xCD, 0x00, 0x00 } );
			Assert.That( result.ReadCount, Is.EqualTo( 3 ) );
			Assert.That( result.Value, Is.EqualTo( 0L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_ZeroAsUInt16_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xCD, 0x00, 0x00 } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 3 ) );
				Assert.That( result, Is.EqualTo( 0L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_ZeroAsInt8_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xD0, 0x00 } );
			Assert.That( result.ReadCount, Is.EqualTo( 2 ) );
			Assert.That( result.Value, Is.EqualTo( 0L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_ZeroAsInt8_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD0, 0x00 } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 2 ) );
				Assert.That( result, Is.EqualTo( 0L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_ZeroAsUInt8_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xCC, 0x00 } );
			Assert.That( result.ReadCount, Is.EqualTo( 2 ) );
			Assert.That( result.Value, Is.EqualTo( 0L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_ZeroAsUInt8_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xCC, 0x00 } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 2 ) );
				Assert.That( result, Is.EqualTo( 0L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_ZeroAsPositiveFixNum0_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0x00 } );
			Assert.That( result.ReadCount, Is.EqualTo( 1 ) );
			Assert.That( result.Value, Is.EqualTo( 0L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_ZeroAsPositiveFixNum0_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0x00 } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 1 ) );
				Assert.That( result, Is.EqualTo( 0L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_PlusOneAsInt64_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xD3, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01 } );
			Assert.That( result.ReadCount, Is.EqualTo( 9 ) );
			Assert.That( result.Value, Is.EqualTo( 1L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_PlusOneAsInt64_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD3, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01 } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 9 ) );
				Assert.That( result, Is.EqualTo( 1L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_PlusOneAsUInt64_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xCF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01 } );
			Assert.That( result.ReadCount, Is.EqualTo( 9 ) );
			Assert.That( result.Value, Is.EqualTo( 1L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_PlusOneAsUInt64_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xCF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01 } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 9 ) );
				Assert.That( result, Is.EqualTo( 1L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_PlusOneAsInt32_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xD2, 0x00, 0x00, 0x00, 0x01 } );
			Assert.That( result.ReadCount, Is.EqualTo( 5 ) );
			Assert.That( result.Value, Is.EqualTo( 1L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_PlusOneAsInt32_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD2, 0x00, 0x00, 0x00, 0x01 } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 5 ) );
				Assert.That( result, Is.EqualTo( 1L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_PlusOneAsUInt32_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xCE, 0x00, 0x00, 0x00, 0x01 } );
			Assert.That( result.ReadCount, Is.EqualTo( 5 ) );
			Assert.That( result.Value, Is.EqualTo( 1L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_PlusOneAsUInt32_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xCE, 0x00, 0x00, 0x00, 0x01 } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 5 ) );
				Assert.That( result, Is.EqualTo( 1L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_PlusOneAsInt16_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xD1, 0x00, 0x01 } );
			Assert.That( result.ReadCount, Is.EqualTo( 3 ) );
			Assert.That( result.Value, Is.EqualTo( 1L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_PlusOneAsInt16_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD1, 0x00, 0x01 } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 3 ) );
				Assert.That( result, Is.EqualTo( 1L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_PlusOneAsUInt16_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xCD, 0x00, 0x01 } );
			Assert.That( result.ReadCount, Is.EqualTo( 3 ) );
			Assert.That( result.Value, Is.EqualTo( 1L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_PlusOneAsUInt16_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xCD, 0x00, 0x01 } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 3 ) );
				Assert.That( result, Is.EqualTo( 1L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_PlusOneAsInt8_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xD0, 0x01 } );
			Assert.That( result.ReadCount, Is.EqualTo( 2 ) );
			Assert.That( result.Value, Is.EqualTo( 1L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_PlusOneAsInt8_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD0, 0x01 } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 2 ) );
				Assert.That( result, Is.EqualTo( 1L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_PlusOneAsUInt8_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xCC, 0x01 } );
			Assert.That( result.ReadCount, Is.EqualTo( 2 ) );
			Assert.That( result.Value, Is.EqualTo( 1L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_PlusOneAsUInt8_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xCC, 0x01 } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 2 ) );
				Assert.That( result, Is.EqualTo( 1L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_PlusOneAsPositiveFixNum1_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0x01 } );
			Assert.That( result.ReadCount, Is.EqualTo( 1 ) );
			Assert.That( result.Value, Is.EqualTo( 1L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_PlusOneAsPositiveFixNum1_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0x01 } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 1 ) );
				Assert.That( result, Is.EqualTo( 1L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_PositiveFixNumMaxValueAsInt64_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xD3, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x7F } );
			Assert.That( result.ReadCount, Is.EqualTo( 9 ) );
			Assert.That( result.Value, Is.EqualTo( 127L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_PositiveFixNumMaxValueAsInt64_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD3, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x7F } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 9 ) );
				Assert.That( result, Is.EqualTo( 127L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_PositiveFixNumMaxValueAsUInt64_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xCF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x7F } );
			Assert.That( result.ReadCount, Is.EqualTo( 9 ) );
			Assert.That( result.Value, Is.EqualTo( 127L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_PositiveFixNumMaxValueAsUInt64_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xCF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x7F } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 9 ) );
				Assert.That( result, Is.EqualTo( 127L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_PositiveFixNumMaxValueAsInt32_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xD2, 0x00, 0x00, 0x00, 0x7F } );
			Assert.That( result.ReadCount, Is.EqualTo( 5 ) );
			Assert.That( result.Value, Is.EqualTo( 127L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_PositiveFixNumMaxValueAsInt32_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD2, 0x00, 0x00, 0x00, 0x7F } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 5 ) );
				Assert.That( result, Is.EqualTo( 127L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_PositiveFixNumMaxValueAsUInt32_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xCE, 0x00, 0x00, 0x00, 0x7F } );
			Assert.That( result.ReadCount, Is.EqualTo( 5 ) );
			Assert.That( result.Value, Is.EqualTo( 127L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_PositiveFixNumMaxValueAsUInt32_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xCE, 0x00, 0x00, 0x00, 0x7F } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 5 ) );
				Assert.That( result, Is.EqualTo( 127L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_PositiveFixNumMaxValueAsInt16_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xD1, 0x00, 0x7F } );
			Assert.That( result.ReadCount, Is.EqualTo( 3 ) );
			Assert.That( result.Value, Is.EqualTo( 127L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_PositiveFixNumMaxValueAsInt16_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD1, 0x00, 0x7F } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 3 ) );
				Assert.That( result, Is.EqualTo( 127L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_PositiveFixNumMaxValueAsUInt16_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xCD, 0x00, 0x7F } );
			Assert.That( result.ReadCount, Is.EqualTo( 3 ) );
			Assert.That( result.Value, Is.EqualTo( 127L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_PositiveFixNumMaxValueAsUInt16_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xCD, 0x00, 0x7F } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 3 ) );
				Assert.That( result, Is.EqualTo( 127L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_PositiveFixNumMaxValueAsInt8_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xD0, 0x7F } );
			Assert.That( result.ReadCount, Is.EqualTo( 2 ) );
			Assert.That( result.Value, Is.EqualTo( 127L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_PositiveFixNumMaxValueAsInt8_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD0, 0x7F } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 2 ) );
				Assert.That( result, Is.EqualTo( 127L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_PositiveFixNumMaxValueAsUInt8_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xCC, 0x7F } );
			Assert.That( result.ReadCount, Is.EqualTo( 2 ) );
			Assert.That( result.Value, Is.EqualTo( 127L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_PositiveFixNumMaxValueAsUInt8_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xCC, 0x7F } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 2 ) );
				Assert.That( result, Is.EqualTo( 127L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_PositiveFixNumMaxValueAsPositiveFixNum127_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0x7F } );
			Assert.That( result.ReadCount, Is.EqualTo( 1 ) );
			Assert.That( result.Value, Is.EqualTo( 127L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_PositiveFixNumMaxValueAsPositiveFixNum127_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0x7F } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 1 ) );
				Assert.That( result, Is.EqualTo( 127L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_PositiveFixNumMaxValuePlusOneAsInt64_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xD3, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80 } );
			Assert.That( result.ReadCount, Is.EqualTo( 9 ) );
			Assert.That( result.Value, Is.EqualTo( 128L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_PositiveFixNumMaxValuePlusOneAsInt64_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD3, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80 } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 9 ) );
				Assert.That( result, Is.EqualTo( 128L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_PositiveFixNumMaxValuePlusOneAsUInt64_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xCF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80 } );
			Assert.That( result.ReadCount, Is.EqualTo( 9 ) );
			Assert.That( result.Value, Is.EqualTo( 128L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_PositiveFixNumMaxValuePlusOneAsUInt64_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xCF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80 } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 9 ) );
				Assert.That( result, Is.EqualTo( 128L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_PositiveFixNumMaxValuePlusOneAsInt32_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xD2, 0x00, 0x00, 0x00, 0x80 } );
			Assert.That( result.ReadCount, Is.EqualTo( 5 ) );
			Assert.That( result.Value, Is.EqualTo( 128L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_PositiveFixNumMaxValuePlusOneAsInt32_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD2, 0x00, 0x00, 0x00, 0x80 } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 5 ) );
				Assert.That( result, Is.EqualTo( 128L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_PositiveFixNumMaxValuePlusOneAsUInt32_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xCE, 0x00, 0x00, 0x00, 0x80 } );
			Assert.That( result.ReadCount, Is.EqualTo( 5 ) );
			Assert.That( result.Value, Is.EqualTo( 128L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_PositiveFixNumMaxValuePlusOneAsUInt32_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xCE, 0x00, 0x00, 0x00, 0x80 } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 5 ) );
				Assert.That( result, Is.EqualTo( 128L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_PositiveFixNumMaxValuePlusOneAsInt16_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xD1, 0x00, 0x80 } );
			Assert.That( result.ReadCount, Is.EqualTo( 3 ) );
			Assert.That( result.Value, Is.EqualTo( 128L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_PositiveFixNumMaxValuePlusOneAsInt16_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD1, 0x00, 0x80 } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 3 ) );
				Assert.That( result, Is.EqualTo( 128L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_PositiveFixNumMaxValuePlusOneAsUInt16_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xCD, 0x00, 0x80 } );
			Assert.That( result.ReadCount, Is.EqualTo( 3 ) );
			Assert.That( result.Value, Is.EqualTo( 128L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_PositiveFixNumMaxValuePlusOneAsUInt16_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xCD, 0x00, 0x80 } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 3 ) );
				Assert.That( result, Is.EqualTo( 128L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_PositiveFixNumMaxValuePlusOneAsUInt8_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xCC, 0x80 } );
			Assert.That( result.ReadCount, Is.EqualTo( 2 ) );
			Assert.That( result.Value, Is.EqualTo( 128L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_PositiveFixNumMaxValuePlusOneAsUInt8_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xCC, 0x80 } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 2 ) );
				Assert.That( result, Is.EqualTo( 128L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_ByteMaxValueAsInt64_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xD3, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF } );
			Assert.That( result.ReadCount, Is.EqualTo( 9 ) );
			Assert.That( result.Value, Is.EqualTo( 255L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_ByteMaxValueAsInt64_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD3, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 9 ) );
				Assert.That( result, Is.EqualTo( 255L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_ByteMaxValueAsUInt64_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xCF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF } );
			Assert.That( result.ReadCount, Is.EqualTo( 9 ) );
			Assert.That( result.Value, Is.EqualTo( 255L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_ByteMaxValueAsUInt64_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xCF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 9 ) );
				Assert.That( result, Is.EqualTo( 255L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_ByteMaxValueAsInt32_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xD2, 0x00, 0x00, 0x00, 0xFF } );
			Assert.That( result.ReadCount, Is.EqualTo( 5 ) );
			Assert.That( result.Value, Is.EqualTo( 255L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_ByteMaxValueAsInt32_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD2, 0x00, 0x00, 0x00, 0xFF } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 5 ) );
				Assert.That( result, Is.EqualTo( 255L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_ByteMaxValueAsUInt32_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xCE, 0x00, 0x00, 0x00, 0xFF } );
			Assert.That( result.ReadCount, Is.EqualTo( 5 ) );
			Assert.That( result.Value, Is.EqualTo( 255L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_ByteMaxValueAsUInt32_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xCE, 0x00, 0x00, 0x00, 0xFF } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 5 ) );
				Assert.That( result, Is.EqualTo( 255L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_ByteMaxValueAsInt16_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xD1, 0x00, 0xFF } );
			Assert.That( result.ReadCount, Is.EqualTo( 3 ) );
			Assert.That( result.Value, Is.EqualTo( 255L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_ByteMaxValueAsInt16_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD1, 0x00, 0xFF } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 3 ) );
				Assert.That( result, Is.EqualTo( 255L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_ByteMaxValueAsUInt16_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xCD, 0x00, 0xFF } );
			Assert.That( result.ReadCount, Is.EqualTo( 3 ) );
			Assert.That( result.Value, Is.EqualTo( 255L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_ByteMaxValueAsUInt16_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xCD, 0x00, 0xFF } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 3 ) );
				Assert.That( result, Is.EqualTo( 255L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_ByteMaxValueAsUInt8_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xCC, 0xFF } );
			Assert.That( result.ReadCount, Is.EqualTo( 2 ) );
			Assert.That( result.Value, Is.EqualTo( 255L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_ByteMaxValueAsUInt8_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xCC, 0xFF } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 2 ) );
				Assert.That( result, Is.EqualTo( 255L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_ByteMaxValuePlusOneAsInt64_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xD3, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00 } );
			Assert.That( result.ReadCount, Is.EqualTo( 9 ) );
			Assert.That( result.Value, Is.EqualTo( 256L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_ByteMaxValuePlusOneAsInt64_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD3, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00 } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 9 ) );
				Assert.That( result, Is.EqualTo( 256L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_ByteMaxValuePlusOneAsUInt64_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xCF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00 } );
			Assert.That( result.ReadCount, Is.EqualTo( 9 ) );
			Assert.That( result.Value, Is.EqualTo( 256L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_ByteMaxValuePlusOneAsUInt64_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xCF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00 } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 9 ) );
				Assert.That( result, Is.EqualTo( 256L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_ByteMaxValuePlusOneAsInt32_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xD2, 0x00, 0x00, 0x01, 0x00 } );
			Assert.That( result.ReadCount, Is.EqualTo( 5 ) );
			Assert.That( result.Value, Is.EqualTo( 256L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_ByteMaxValuePlusOneAsInt32_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD2, 0x00, 0x00, 0x01, 0x00 } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 5 ) );
				Assert.That( result, Is.EqualTo( 256L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_ByteMaxValuePlusOneAsUInt32_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xCE, 0x00, 0x00, 0x01, 0x00 } );
			Assert.That( result.ReadCount, Is.EqualTo( 5 ) );
			Assert.That( result.Value, Is.EqualTo( 256L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_ByteMaxValuePlusOneAsUInt32_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xCE, 0x00, 0x00, 0x01, 0x00 } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 5 ) );
				Assert.That( result, Is.EqualTo( 256L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_ByteMaxValuePlusOneAsInt16_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xD1, 0x01, 0x00 } );
			Assert.That( result.ReadCount, Is.EqualTo( 3 ) );
			Assert.That( result.Value, Is.EqualTo( 256L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_ByteMaxValuePlusOneAsInt16_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD1, 0x01, 0x00 } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 3 ) );
				Assert.That( result, Is.EqualTo( 256L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_ByteMaxValuePlusOneAsUInt16_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xCD, 0x01, 0x00 } );
			Assert.That( result.ReadCount, Is.EqualTo( 3 ) );
			Assert.That( result.Value, Is.EqualTo( 256L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_ByteMaxValuePlusOneAsUInt16_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xCD, 0x01, 0x00 } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 3 ) );
				Assert.That( result, Is.EqualTo( 256L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_UInt16MaxValueAsInt64_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xD3, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF } );
			Assert.That( result.ReadCount, Is.EqualTo( 9 ) );
			Assert.That( result.Value, Is.EqualTo( 65535L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_UInt16MaxValueAsInt64_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD3, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 9 ) );
				Assert.That( result, Is.EqualTo( 65535L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_UInt16MaxValueAsUInt64_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xCF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF } );
			Assert.That( result.ReadCount, Is.EqualTo( 9 ) );
			Assert.That( result.Value, Is.EqualTo( 65535L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_UInt16MaxValueAsUInt64_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xCF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 9 ) );
				Assert.That( result, Is.EqualTo( 65535L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_UInt16MaxValueAsInt32_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xD2, 0x00, 0x00, 0xFF, 0xFF } );
			Assert.That( result.ReadCount, Is.EqualTo( 5 ) );
			Assert.That( result.Value, Is.EqualTo( 65535L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_UInt16MaxValueAsInt32_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD2, 0x00, 0x00, 0xFF, 0xFF } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 5 ) );
				Assert.That( result, Is.EqualTo( 65535L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_UInt16MaxValueAsUInt32_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xCE, 0x00, 0x00, 0xFF, 0xFF } );
			Assert.That( result.ReadCount, Is.EqualTo( 5 ) );
			Assert.That( result.Value, Is.EqualTo( 65535L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_UInt16MaxValueAsUInt32_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xCE, 0x00, 0x00, 0xFF, 0xFF } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 5 ) );
				Assert.That( result, Is.EqualTo( 65535L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_UInt16MaxValueAsUInt16_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xCD, 0xFF, 0xFF } );
			Assert.That( result.ReadCount, Is.EqualTo( 3 ) );
			Assert.That( result.Value, Is.EqualTo( 65535L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_UInt16MaxValueAsUInt16_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xCD, 0xFF, 0xFF } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 3 ) );
				Assert.That( result, Is.EqualTo( 65535L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_UInt16MaxValuePlusOneAsInt64_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xD3, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00 } );
			Assert.That( result.ReadCount, Is.EqualTo( 9 ) );
			Assert.That( result.Value, Is.EqualTo( 65536L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_UInt16MaxValuePlusOneAsInt64_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD3, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00 } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 9 ) );
				Assert.That( result, Is.EqualTo( 65536L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_UInt16MaxValuePlusOneAsUInt64_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xCF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00 } );
			Assert.That( result.ReadCount, Is.EqualTo( 9 ) );
			Assert.That( result.Value, Is.EqualTo( 65536L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_UInt16MaxValuePlusOneAsUInt64_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xCF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00 } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 9 ) );
				Assert.That( result, Is.EqualTo( 65536L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_UInt16MaxValuePlusOneAsInt32_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xD2, 0x00, 0x01, 0x00, 0x00 } );
			Assert.That( result.ReadCount, Is.EqualTo( 5 ) );
			Assert.That( result.Value, Is.EqualTo( 65536L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_UInt16MaxValuePlusOneAsInt32_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD2, 0x00, 0x01, 0x00, 0x00 } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 5 ) );
				Assert.That( result, Is.EqualTo( 65536L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_UInt16MaxValuePlusOneAsUInt32_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xCE, 0x00, 0x01, 0x00, 0x00 } );
			Assert.That( result.ReadCount, Is.EqualTo( 5 ) );
			Assert.That( result.Value, Is.EqualTo( 65536L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_UInt16MaxValuePlusOneAsUInt32_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xCE, 0x00, 0x01, 0x00, 0x00 } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 5 ) );
				Assert.That( result, Is.EqualTo( 65536L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_UInt32MaxValueAsInt64_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xD3, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF } );
			Assert.That( result.ReadCount, Is.EqualTo( 9 ) );
			Assert.That( result.Value, Is.EqualTo( 4294967295L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_UInt32MaxValueAsInt64_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD3, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 9 ) );
				Assert.That( result, Is.EqualTo( 4294967295L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_UInt32MaxValueAsUInt64_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xCF, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF } );
			Assert.That( result.ReadCount, Is.EqualTo( 9 ) );
			Assert.That( result.Value, Is.EqualTo( 4294967295L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_UInt32MaxValueAsUInt64_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xCF, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 9 ) );
				Assert.That( result, Is.EqualTo( 4294967295L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_UInt32MaxValueAsUInt32_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xCE, 0xFF, 0xFF, 0xFF, 0xFF } );
			Assert.That( result.ReadCount, Is.EqualTo( 5 ) );
			Assert.That( result.Value, Is.EqualTo( 4294967295L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_UInt32MaxValueAsUInt32_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xCE, 0xFF, 0xFF, 0xFF, 0xFF } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 5 ) );
				Assert.That( result, Is.EqualTo( 4294967295L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_UInt32MaxValuePlusOneAsInt64_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xD3, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00 } );
			Assert.That( result.ReadCount, Is.EqualTo( 9 ) );
			Assert.That( result.Value, Is.EqualTo( 4294967296L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_UInt32MaxValuePlusOneAsInt64_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD3, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00 } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 9 ) );
				Assert.That( result, Is.EqualTo( 4294967296L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_UInt32MaxValuePlusOneAsUInt64_Fail()
		{
			var result = Unpacking.UnpackInt64( new byte[] { 0xCF, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00 } );
			Assert.That( result.ReadCount, Is.EqualTo( 9 ) );
			Assert.That( result.Value, Is.EqualTo( 4294967296L ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_UInt32MaxValuePlusOneAsUInt64_Fail()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xCF, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00 } ) )
			{
				var result = Unpacking.UnpackInt64( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 9 ) );
				Assert.That( result, Is.EqualTo( 4294967296L ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_UInt64MaxValueAsUInt64_AsIs()
		{
			Assert.Throws<MessageTypeException>( () => Unpacking.UnpackInt64( new byte[] { 0xCF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF } ) );
		}
		
		[Test]
		public void TestUnpackInt64_Stream_UInt64MaxValueAsUInt64_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xCF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF } ) )
			{
				Assert.Throws<MessageTypeException>( () => Unpacking.UnpackInt64( buffer ) );
			}
		}

		[Test]
		public void TestUnpackInt64_ByteArray_Empty()
		{
			Assert.Throws<ArgumentException>( () => Unpacking.UnpackInt64( new byte[ 0 ] ) );
		}

		[Test]
		public void TestUnpackInt64_ByteArray_Null()
		{
			Assert.Throws<ArgumentNullException>( () => Unpacking.UnpackInt64( default( byte[] ) ) );
		}

		[Test]
		public void TestUnpackInt64_ByteArray_Offset_Null()
		{
			Assert.Throws<ArgumentNullException>( () => Unpacking.UnpackInt64( default( byte[] ), 0 ) );
		}

		[Test]
		public void TestUnpackInt64_ByteArray_Offset_OffsetIsNegative()
		{
			Assert.Throws<ArgumentOutOfRangeException>( () => Unpacking.UnpackInt64( new byte[]{ 0x1 }, -1 ) );
		}

		[Test]
		public void TestUnpackInt64_ByteArray_Offset_OffsetIsTooBig()
		{
			Assert.Throws<ArgumentException>( () => Unpacking.UnpackInt64( new byte[]{ 0x1 }, 1 ) );
		}

		[Test]
		public void TestUnpackInt64_ByteArray_Offset_Empty()
		{
			Assert.Throws<ArgumentException>( () => Unpacking.UnpackInt64( new byte[ 0 ], 0 ) );
		}

		[Test]
		public void TestUnpackInt64_Stream_Null()
		{
			Assert.Throws<ArgumentNullException>( () => Unpacking.UnpackInt64( default( Stream ) ) );
		}

		[Test]
		public void TestUnpackInt64_ByteArray_Offset_OffsetIsValid_OffsetIsRespected()
		{
			// Offset 1 is positive fix num 1.
			var result = Unpacking.UnpackInt64( new byte[] { 0xFF, 0x57, 0xFF }, 1 );
			Assert.That( result.ReadCount, Is.EqualTo( 1 ) );
			Assert.That( result.Value, Is.EqualTo( 0x57 ) );
		}

		[Test]
		public void TestUnpackInt64_ByteArray_Null_Nil()
		{
			Assert.Throws<MessageTypeException>( () => Unpacking.UnpackInt64( new byte[] { 0xC0 } ) );
		}
	
		[Test]
		public void TestUnpackInt64_ByteArray_NotInt64()
		{
			Assert.Throws<MessageTypeException>( () => Unpacking.UnpackInt64( new byte[] { 0xA0 } ) );
		}
	}
}
