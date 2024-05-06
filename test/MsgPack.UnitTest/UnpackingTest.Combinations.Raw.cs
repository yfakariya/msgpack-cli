
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
	public 	partial class UnpackingTest_Combinations_Raw
	{
		[Test]
		public void TestUnpackBinaryFromString_ByteArray_FixRaw0Value_AsFixRaw0_AsIs()
		{
			var result = Unpacking.UnpackBinary( new byte[] { 0xA0 } );
			Assert.That( result.ReadCount, Is.EqualTo( 1 ) );
			Assert.That( result.Value.Length, Is.EqualTo( 0 ) );
			Assert.That( result.Value, Is.All.EqualTo( ( byte )'a' ) );
		}

		[Test]
		public void TestUnpackBinaryFromString_Stream_FixRaw0Value_AsFixRaw0_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xA0 } ) )
			{
				var result = Unpacking.UnpackBinary( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 1 ) );
				Assert.That( result.Length, Is.EqualTo( 0 ) );
				Assert.That( result, Is.All.EqualTo( ( byte )'a' ) );
			}
		}
		
		[Test]
		public void TestUnpackString_ByteArray_FixRaw0Value_AsFixRaw0_AsIs()
		{
			var result = Unpacking.UnpackString( new byte[] { 0xA0 } );
			Assert.That( result.ReadCount, Is.EqualTo( 1 ) );
			Assert.That( result.Value.Length, Is.EqualTo( 0 ) );
			Assert.That( result.Value, Is.All.EqualTo( 'a' ) );
		}

		[Test]
		public void TestUnpackString_Stream_FixRaw0Value_AsFixRaw0_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xA0 } ) )
			{
				var result = Unpacking.UnpackString( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 1 ) );
				Assert.That( result.Length, Is.EqualTo( 0 ) );
				Assert.That( result, Is.All.EqualTo( 'a' ) );
			}
		}
		[Test]
		public void TestUnpackBinaryFromString_ByteArray_FixRaw0Value_AsStr8_AsIs()
		{
			var result = Unpacking.UnpackBinary( new byte[] { 0xD9, 0x00 } );
			Assert.That( result.ReadCount, Is.EqualTo( 2 ) );
			Assert.That( result.Value.Length, Is.EqualTo( 0 ) );
			Assert.That( result.Value, Is.All.EqualTo( ( byte )'a' ) );
		}

		[Test]
		public void TestUnpackBinaryFromString_Stream_FixRaw0Value_AsStr8_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD9, 0x00 } ) )
			{
				var result = Unpacking.UnpackBinary( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 2 ) );
				Assert.That( result.Length, Is.EqualTo( 0 ) );
				Assert.That( result, Is.All.EqualTo( ( byte )'a' ) );
			}
		}
		
		[Test]
		public void TestUnpackString_ByteArray_FixRaw0Value_AsStr8_AsIs()
		{
			var result = Unpacking.UnpackString( new byte[] { 0xD9, 0x00 } );
			Assert.That( result.ReadCount, Is.EqualTo( 2 ) );
			Assert.That( result.Value.Length, Is.EqualTo( 0 ) );
			Assert.That( result.Value, Is.All.EqualTo( 'a' ) );
		}

		[Test]
		public void TestUnpackString_Stream_FixRaw0Value_AsStr8_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD9, 0x00 } ) )
			{
				var result = Unpacking.UnpackString( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 2 ) );
				Assert.That( result.Length, Is.EqualTo( 0 ) );
				Assert.That( result, Is.All.EqualTo( 'a' ) );
			}
		}
		[Test]
		public void TestUnpackBinaryFromString_ByteArray_FixRaw0Value_AsRaw16_AsIs()
		{
			var result = Unpacking.UnpackBinary( new byte[] { 0xDA, 0x00, 0x00 } );
			Assert.That( result.ReadCount, Is.EqualTo( 3 ) );
			Assert.That( result.Value.Length, Is.EqualTo( 0 ) );
			Assert.That( result.Value, Is.All.EqualTo( ( byte )'a' ) );
		}

		[Test]
		public void TestUnpackBinaryFromString_Stream_FixRaw0Value_AsRaw16_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xDA, 0x00, 0x00 } ) )
			{
				var result = Unpacking.UnpackBinary( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 3 ) );
				Assert.That( result.Length, Is.EqualTo( 0 ) );
				Assert.That( result, Is.All.EqualTo( ( byte )'a' ) );
			}
		}
		
		[Test]
		public void TestUnpackString_ByteArray_FixRaw0Value_AsRaw16_AsIs()
		{
			var result = Unpacking.UnpackString( new byte[] { 0xDA, 0x00, 0x00 } );
			Assert.That( result.ReadCount, Is.EqualTo( 3 ) );
			Assert.That( result.Value.Length, Is.EqualTo( 0 ) );
			Assert.That( result.Value, Is.All.EqualTo( 'a' ) );
		}

		[Test]
		public void TestUnpackString_Stream_FixRaw0Value_AsRaw16_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xDA, 0x00, 0x00 } ) )
			{
				var result = Unpacking.UnpackString( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 3 ) );
				Assert.That( result.Length, Is.EqualTo( 0 ) );
				Assert.That( result, Is.All.EqualTo( 'a' ) );
			}
		}
		[Test]
		public void TestUnpackBinaryFromString_ByteArray_FixRaw0Value_AsRaw32_AsIs()
		{
			var result = Unpacking.UnpackBinary( new byte[] { 0xDB, 0x00, 0x00, 0x00, 0x00 } );
			Assert.That( result.ReadCount, Is.EqualTo( 5 ) );
			Assert.That( result.Value.Length, Is.EqualTo( 0 ) );
			Assert.That( result.Value, Is.All.EqualTo( ( byte )'a' ) );
		}

		[Test]
		public void TestUnpackBinaryFromString_Stream_FixRaw0Value_AsRaw32_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xDB, 0x00, 0x00, 0x00, 0x00 } ) )
			{
				var result = Unpacking.UnpackBinary( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 5 ) );
				Assert.That( result.Length, Is.EqualTo( 0 ) );
				Assert.That( result, Is.All.EqualTo( ( byte )'a' ) );
			}
		}
		
		[Test]
		public void TestUnpackString_ByteArray_FixRaw0Value_AsRaw32_AsIs()
		{
			var result = Unpacking.UnpackString( new byte[] { 0xDB, 0x00, 0x00, 0x00, 0x00 } );
			Assert.That( result.ReadCount, Is.EqualTo( 5 ) );
			Assert.That( result.Value.Length, Is.EqualTo( 0 ) );
			Assert.That( result.Value, Is.All.EqualTo( 'a' ) );
		}

		[Test]
		public void TestUnpackString_Stream_FixRaw0Value_AsRaw32_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xDB, 0x00, 0x00, 0x00, 0x00 } ) )
			{
				var result = Unpacking.UnpackString( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 5 ) );
				Assert.That( result.Length, Is.EqualTo( 0 ) );
				Assert.That( result, Is.All.EqualTo( 'a' ) );
			}
		}
		[Test]
		public void TestUnpackBinaryFromString_ByteArray_FixRaw1Value_AsFixRaw1_AsIs()
		{
			var result = Unpacking.UnpackBinary( new byte[] { 0xA1 }.Concat( Enumerable.Repeat( ( byte )'a', 1 ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 2 ) );
			Assert.That( result.Value.Length, Is.EqualTo( 0x1 ) );
			Assert.That( result.Value, Is.All.EqualTo( ( byte )'a' ) );
		}

		[Test]
		public void TestUnpackBinaryFromString_Stream_FixRaw1Value_AsFixRaw1_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xA1 }.Concat( Enumerable.Repeat( ( byte )'a', 1 ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackBinary( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 2 ) );
				Assert.That( result.Length, Is.EqualTo( 0x1 ) );
				Assert.That( result, Is.All.EqualTo( ( byte )'a' ) );
			}
		}
		
		[Test]
		public void TestUnpackString_ByteArray_FixRaw1Value_AsFixRaw1_AsIs()
		{
			var result = Unpacking.UnpackString( new byte[] { 0xA1 }.Concat( Enumerable.Repeat( ( byte )'a', 1 ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 2 ) );
			Assert.That( result.Value.Length, Is.EqualTo( 0x1 ) );
			Assert.That( result.Value, Is.All.EqualTo( 'a' ) );
		}

		[Test]
		public void TestUnpackString_Stream_FixRaw1Value_AsFixRaw1_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xA1 }.Concat( Enumerable.Repeat( ( byte )'a', 1 ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackString( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 2 ) );
				Assert.That( result.Length, Is.EqualTo( 0x1 ) );
				Assert.That( result, Is.All.EqualTo( 'a' ) );
			}
		}
		[Test]
		public void TestUnpackBinaryFromString_ByteArray_FixRaw1Value_AsStr8_AsIs()
		{
			var result = Unpacking.UnpackBinary( new byte[] { 0xD9, 0x01 }.Concat( Enumerable.Repeat( ( byte )'a', 1 ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 3 ) );
			Assert.That( result.Value.Length, Is.EqualTo( 0x1 ) );
			Assert.That( result.Value, Is.All.EqualTo( ( byte )'a' ) );
		}

		[Test]
		public void TestUnpackBinaryFromString_Stream_FixRaw1Value_AsStr8_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD9, 0x01 }.Concat( Enumerable.Repeat( ( byte )'a', 1 ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackBinary( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 3 ) );
				Assert.That( result.Length, Is.EqualTo( 0x1 ) );
				Assert.That( result, Is.All.EqualTo( ( byte )'a' ) );
			}
		}
		
		[Test]
		public void TestUnpackString_ByteArray_FixRaw1Value_AsStr8_AsIs()
		{
			var result = Unpacking.UnpackString( new byte[] { 0xD9, 0x01 }.Concat( Enumerable.Repeat( ( byte )'a', 1 ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 3 ) );
			Assert.That( result.Value.Length, Is.EqualTo( 0x1 ) );
			Assert.That( result.Value, Is.All.EqualTo( 'a' ) );
		}

		[Test]
		public void TestUnpackString_Stream_FixRaw1Value_AsStr8_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD9, 0x01 }.Concat( Enumerable.Repeat( ( byte )'a', 1 ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackString( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 3 ) );
				Assert.That( result.Length, Is.EqualTo( 0x1 ) );
				Assert.That( result, Is.All.EqualTo( 'a' ) );
			}
		}
		[Test]
		public void TestUnpackBinaryFromString_ByteArray_FixRaw1Value_AsRaw16_AsIs()
		{
			var result = Unpacking.UnpackBinary( new byte[] { 0xDA, 0x00, 0x01 }.Concat( Enumerable.Repeat( ( byte )'a', 1 ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 4 ) );
			Assert.That( result.Value.Length, Is.EqualTo( 0x1 ) );
			Assert.That( result.Value, Is.All.EqualTo( ( byte )'a' ) );
		}

		[Test]
		public void TestUnpackBinaryFromString_Stream_FixRaw1Value_AsRaw16_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xDA, 0x00, 0x01 }.Concat( Enumerable.Repeat( ( byte )'a', 1 ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackBinary( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 4 ) );
				Assert.That( result.Length, Is.EqualTo( 0x1 ) );
				Assert.That( result, Is.All.EqualTo( ( byte )'a' ) );
			}
		}
		
		[Test]
		public void TestUnpackString_ByteArray_FixRaw1Value_AsRaw16_AsIs()
		{
			var result = Unpacking.UnpackString( new byte[] { 0xDA, 0x00, 0x01 }.Concat( Enumerable.Repeat( ( byte )'a', 1 ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 4 ) );
			Assert.That( result.Value.Length, Is.EqualTo( 0x1 ) );
			Assert.That( result.Value, Is.All.EqualTo( 'a' ) );
		}

		[Test]
		public void TestUnpackString_Stream_FixRaw1Value_AsRaw16_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xDA, 0x00, 0x01 }.Concat( Enumerable.Repeat( ( byte )'a', 1 ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackString( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 4 ) );
				Assert.That( result.Length, Is.EqualTo( 0x1 ) );
				Assert.That( result, Is.All.EqualTo( 'a' ) );
			}
		}
		[Test]
		public void TestUnpackBinaryFromString_ByteArray_FixRaw1Value_AsRaw32_AsIs()
		{
			var result = Unpacking.UnpackBinary( new byte[] { 0xDB, 0x00, 0x00, 0x00, 0x01 }.Concat( Enumerable.Repeat( ( byte )'a', 1 ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 6 ) );
			Assert.That( result.Value.Length, Is.EqualTo( 0x1 ) );
			Assert.That( result.Value, Is.All.EqualTo( ( byte )'a' ) );
		}

		[Test]
		public void TestUnpackBinaryFromString_Stream_FixRaw1Value_AsRaw32_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xDB, 0x00, 0x00, 0x00, 0x01 }.Concat( Enumerable.Repeat( ( byte )'a', 1 ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackBinary( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 6 ) );
				Assert.That( result.Length, Is.EqualTo( 0x1 ) );
				Assert.That( result, Is.All.EqualTo( ( byte )'a' ) );
			}
		}
		
		[Test]
		public void TestUnpackString_ByteArray_FixRaw1Value_AsRaw32_AsIs()
		{
			var result = Unpacking.UnpackString( new byte[] { 0xDB, 0x00, 0x00, 0x00, 0x01 }.Concat( Enumerable.Repeat( ( byte )'a', 1 ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 6 ) );
			Assert.That( result.Value.Length, Is.EqualTo( 0x1 ) );
			Assert.That( result.Value, Is.All.EqualTo( 'a' ) );
		}

		[Test]
		public void TestUnpackString_Stream_FixRaw1Value_AsRaw32_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xDB, 0x00, 0x00, 0x00, 0x01 }.Concat( Enumerable.Repeat( ( byte )'a', 1 ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackString( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 6 ) );
				Assert.That( result.Length, Is.EqualTo( 0x1 ) );
				Assert.That( result, Is.All.EqualTo( 'a' ) );
			}
		}
		[Test]
		public void TestUnpackBinaryFromString_ByteArray_FixRawMaxValue_AsFixRaw31_AsIs()
		{
			var result = Unpacking.UnpackBinary( new byte[] { 0xBF }.Concat( Enumerable.Repeat( ( byte )'a', 0x1F ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 32 ) );
			Assert.That( result.Value.Length, Is.EqualTo( 0x1F ) );
			Assert.That( result.Value, Is.All.EqualTo( ( byte )'a' ) );
		}

		[Test]
		public void TestUnpackBinaryFromString_Stream_FixRawMaxValue_AsFixRaw31_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xBF }.Concat( Enumerable.Repeat( ( byte )'a', 0x1F ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackBinary( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 32 ) );
				Assert.That( result.Length, Is.EqualTo( 0x1F ) );
				Assert.That( result, Is.All.EqualTo( ( byte )'a' ) );
			}
		}
		
		[Test]
		public void TestUnpackString_ByteArray_FixRawMaxValue_AsFixRaw31_AsIs()
		{
			var result = Unpacking.UnpackString( new byte[] { 0xBF }.Concat( Enumerable.Repeat( ( byte )'a', 0x1F ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 32 ) );
			Assert.That( result.Value.Length, Is.EqualTo( 0x1F ) );
			Assert.That( result.Value, Is.All.EqualTo( 'a' ) );
		}

		[Test]
		public void TestUnpackString_Stream_FixRawMaxValue_AsFixRaw31_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xBF }.Concat( Enumerable.Repeat( ( byte )'a', 0x1F ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackString( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 32 ) );
				Assert.That( result.Length, Is.EqualTo( 0x1F ) );
				Assert.That( result, Is.All.EqualTo( 'a' ) );
			}
		}
		[Test]
		public void TestUnpackBinaryFromString_ByteArray_FixRawMaxValue_AsStr8_AsIs()
		{
			var result = Unpacking.UnpackBinary( new byte[] { 0xD9, 0x1F }.Concat( Enumerable.Repeat( ( byte )'a', 0x1F ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 33 ) );
			Assert.That( result.Value.Length, Is.EqualTo( 0x1F ) );
			Assert.That( result.Value, Is.All.EqualTo( ( byte )'a' ) );
		}

		[Test]
		public void TestUnpackBinaryFromString_Stream_FixRawMaxValue_AsStr8_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD9, 0x1F }.Concat( Enumerable.Repeat( ( byte )'a', 0x1F ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackBinary( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 33 ) );
				Assert.That( result.Length, Is.EqualTo( 0x1F ) );
				Assert.That( result, Is.All.EqualTo( ( byte )'a' ) );
			}
		}
		
		[Test]
		public void TestUnpackString_ByteArray_FixRawMaxValue_AsStr8_AsIs()
		{
			var result = Unpacking.UnpackString( new byte[] { 0xD9, 0x1F }.Concat( Enumerable.Repeat( ( byte )'a', 0x1F ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 33 ) );
			Assert.That( result.Value.Length, Is.EqualTo( 0x1F ) );
			Assert.That( result.Value, Is.All.EqualTo( 'a' ) );
		}

		[Test]
		public void TestUnpackString_Stream_FixRawMaxValue_AsStr8_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD9, 0x1F }.Concat( Enumerable.Repeat( ( byte )'a', 0x1F ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackString( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 33 ) );
				Assert.That( result.Length, Is.EqualTo( 0x1F ) );
				Assert.That( result, Is.All.EqualTo( 'a' ) );
			}
		}
		[Test]
		public void TestUnpackBinaryFromString_ByteArray_FixRawMaxValue_AsRaw16_AsIs()
		{
			var result = Unpacking.UnpackBinary( new byte[] { 0xDA, 0x00, 0x1F }.Concat( Enumerable.Repeat( ( byte )'a', 0x1F ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 34 ) );
			Assert.That( result.Value.Length, Is.EqualTo( 0x1F ) );
			Assert.That( result.Value, Is.All.EqualTo( ( byte )'a' ) );
		}

		[Test]
		public void TestUnpackBinaryFromString_Stream_FixRawMaxValue_AsRaw16_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xDA, 0x00, 0x1F }.Concat( Enumerable.Repeat( ( byte )'a', 0x1F ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackBinary( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 34 ) );
				Assert.That( result.Length, Is.EqualTo( 0x1F ) );
				Assert.That( result, Is.All.EqualTo( ( byte )'a' ) );
			}
		}
		
		[Test]
		public void TestUnpackString_ByteArray_FixRawMaxValue_AsRaw16_AsIs()
		{
			var result = Unpacking.UnpackString( new byte[] { 0xDA, 0x00, 0x1F }.Concat( Enumerable.Repeat( ( byte )'a', 0x1F ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 34 ) );
			Assert.That( result.Value.Length, Is.EqualTo( 0x1F ) );
			Assert.That( result.Value, Is.All.EqualTo( 'a' ) );
		}

		[Test]
		public void TestUnpackString_Stream_FixRawMaxValue_AsRaw16_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xDA, 0x00, 0x1F }.Concat( Enumerable.Repeat( ( byte )'a', 0x1F ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackString( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 34 ) );
				Assert.That( result.Length, Is.EqualTo( 0x1F ) );
				Assert.That( result, Is.All.EqualTo( 'a' ) );
			}
		}
		[Test]
		public void TestUnpackBinaryFromString_ByteArray_FixRawMaxValue_AsRaw32_AsIs()
		{
			var result = Unpacking.UnpackBinary( new byte[] { 0xDB, 0x00, 0x00, 0x00, 0x1F }.Concat( Enumerable.Repeat( ( byte )'a', 0x1F ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 36 ) );
			Assert.That( result.Value.Length, Is.EqualTo( 0x1F ) );
			Assert.That( result.Value, Is.All.EqualTo( ( byte )'a' ) );
		}

		[Test]
		public void TestUnpackBinaryFromString_Stream_FixRawMaxValue_AsRaw32_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xDB, 0x00, 0x00, 0x00, 0x1F }.Concat( Enumerable.Repeat( ( byte )'a', 0x1F ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackBinary( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 36 ) );
				Assert.That( result.Length, Is.EqualTo( 0x1F ) );
				Assert.That( result, Is.All.EqualTo( ( byte )'a' ) );
			}
		}
		
		[Test]
		public void TestUnpackString_ByteArray_FixRawMaxValue_AsRaw32_AsIs()
		{
			var result = Unpacking.UnpackString( new byte[] { 0xDB, 0x00, 0x00, 0x00, 0x1F }.Concat( Enumerable.Repeat( ( byte )'a', 0x1F ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 36 ) );
			Assert.That( result.Value.Length, Is.EqualTo( 0x1F ) );
			Assert.That( result.Value, Is.All.EqualTo( 'a' ) );
		}

		[Test]
		public void TestUnpackString_Stream_FixRawMaxValue_AsRaw32_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xDB, 0x00, 0x00, 0x00, 0x1F }.Concat( Enumerable.Repeat( ( byte )'a', 0x1F ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackString( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 36 ) );
				Assert.That( result.Length, Is.EqualTo( 0x1F ) );
				Assert.That( result, Is.All.EqualTo( 'a' ) );
			}
		}
		[Test]
		public void TestUnpackBinaryFromString_ByteArray_Str8MinValue_AsStr8_AsIs()
		{
			var result = Unpacking.UnpackBinary( new byte[] { 0xD9, 0x20 }.Concat( Enumerable.Repeat( ( byte )'a', 0x20 ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 34 ) );
			Assert.That( result.Value.Length, Is.EqualTo( 0x20 ) );
			Assert.That( result.Value, Is.All.EqualTo( ( byte )'a' ) );
		}

		[Test]
		public void TestUnpackBinaryFromString_Stream_Str8MinValue_AsStr8_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD9, 0x20 }.Concat( Enumerable.Repeat( ( byte )'a', 0x20 ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackBinary( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 34 ) );
				Assert.That( result.Length, Is.EqualTo( 0x20 ) );
				Assert.That( result, Is.All.EqualTo( ( byte )'a' ) );
			}
		}
		
		[Test]
		public void TestUnpackString_ByteArray_Str8MinValue_AsStr8_AsIs()
		{
			var result = Unpacking.UnpackString( new byte[] { 0xD9, 0x20 }.Concat( Enumerable.Repeat( ( byte )'a', 0x20 ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 34 ) );
			Assert.That( result.Value.Length, Is.EqualTo( 0x20 ) );
			Assert.That( result.Value, Is.All.EqualTo( 'a' ) );
		}

		[Test]
		public void TestUnpackString_Stream_Str8MinValue_AsStr8_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD9, 0x20 }.Concat( Enumerable.Repeat( ( byte )'a', 0x20 ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackString( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 34 ) );
				Assert.That( result.Length, Is.EqualTo( 0x20 ) );
				Assert.That( result, Is.All.EqualTo( 'a' ) );
			}
		}
		[Test]
		public void TestUnpackBinaryFromString_ByteArray_Str8MinValue_AsRaw16_AsIs()
		{
			var result = Unpacking.UnpackBinary( new byte[] { 0xDA, 0x00, 0x20 }.Concat( Enumerable.Repeat( ( byte )'a', 0x20 ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 35 ) );
			Assert.That( result.Value.Length, Is.EqualTo( 0x20 ) );
			Assert.That( result.Value, Is.All.EqualTo( ( byte )'a' ) );
		}

		[Test]
		public void TestUnpackBinaryFromString_Stream_Str8MinValue_AsRaw16_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xDA, 0x00, 0x20 }.Concat( Enumerable.Repeat( ( byte )'a', 0x20 ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackBinary( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 35 ) );
				Assert.That( result.Length, Is.EqualTo( 0x20 ) );
				Assert.That( result, Is.All.EqualTo( ( byte )'a' ) );
			}
		}
		
		[Test]
		public void TestUnpackString_ByteArray_Str8MinValue_AsRaw16_AsIs()
		{
			var result = Unpacking.UnpackString( new byte[] { 0xDA, 0x00, 0x20 }.Concat( Enumerable.Repeat( ( byte )'a', 0x20 ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 35 ) );
			Assert.That( result.Value.Length, Is.EqualTo( 0x20 ) );
			Assert.That( result.Value, Is.All.EqualTo( 'a' ) );
		}

		[Test]
		public void TestUnpackString_Stream_Str8MinValue_AsRaw16_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xDA, 0x00, 0x20 }.Concat( Enumerable.Repeat( ( byte )'a', 0x20 ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackString( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 35 ) );
				Assert.That( result.Length, Is.EqualTo( 0x20 ) );
				Assert.That( result, Is.All.EqualTo( 'a' ) );
			}
		}
		[Test]
		public void TestUnpackBinaryFromString_ByteArray_Str8MinValue_AsRaw32_AsIs()
		{
			var result = Unpacking.UnpackBinary( new byte[] { 0xDB, 0x00, 0x00, 0x00, 0x20 }.Concat( Enumerable.Repeat( ( byte )'a', 0x20 ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 37 ) );
			Assert.That( result.Value.Length, Is.EqualTo( 0x20 ) );
			Assert.That( result.Value, Is.All.EqualTo( ( byte )'a' ) );
		}

		[Test]
		public void TestUnpackBinaryFromString_Stream_Str8MinValue_AsRaw32_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xDB, 0x00, 0x00, 0x00, 0x20 }.Concat( Enumerable.Repeat( ( byte )'a', 0x20 ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackBinary( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 37 ) );
				Assert.That( result.Length, Is.EqualTo( 0x20 ) );
				Assert.That( result, Is.All.EqualTo( ( byte )'a' ) );
			}
		}
		
		[Test]
		public void TestUnpackString_ByteArray_Str8MinValue_AsRaw32_AsIs()
		{
			var result = Unpacking.UnpackString( new byte[] { 0xDB, 0x00, 0x00, 0x00, 0x20 }.Concat( Enumerable.Repeat( ( byte )'a', 0x20 ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 37 ) );
			Assert.That( result.Value.Length, Is.EqualTo( 0x20 ) );
			Assert.That( result.Value, Is.All.EqualTo( 'a' ) );
		}

		[Test]
		public void TestUnpackString_Stream_Str8MinValue_AsRaw32_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xDB, 0x00, 0x00, 0x00, 0x20 }.Concat( Enumerable.Repeat( ( byte )'a', 0x20 ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackString( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 37 ) );
				Assert.That( result.Length, Is.EqualTo( 0x20 ) );
				Assert.That( result, Is.All.EqualTo( 'a' ) );
			}
		}
		[Test]
		public void TestUnpackBinaryFromString_ByteArray_Str8MaxValue_AsStr8_AsIs()
		{
			var result = Unpacking.UnpackBinary( new byte[] { 0xD9, 0xFF }.Concat( Enumerable.Repeat( ( byte )'a', 0xFF ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 257 ) );
			Assert.That( result.Value.Length, Is.EqualTo( 0xFF ) );
			Assert.That( result.Value, Is.All.EqualTo( ( byte )'a' ) );
		}

		[Test]
		public void TestUnpackBinaryFromString_Stream_Str8MaxValue_AsStr8_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD9, 0xFF }.Concat( Enumerable.Repeat( ( byte )'a', 0xFF ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackBinary( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 257 ) );
				Assert.That( result.Length, Is.EqualTo( 0xFF ) );
				Assert.That( result, Is.All.EqualTo( ( byte )'a' ) );
			}
		}
		
		[Test]
		public void TestUnpackString_ByteArray_Str8MaxValue_AsStr8_AsIs()
		{
			var result = Unpacking.UnpackString( new byte[] { 0xD9, 0xFF }.Concat( Enumerable.Repeat( ( byte )'a', 0xFF ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 257 ) );
			Assert.That( result.Value.Length, Is.EqualTo( 0xFF ) );
			Assert.That( result.Value, Is.All.EqualTo( 'a' ) );
		}

		[Test]
		public void TestUnpackString_Stream_Str8MaxValue_AsStr8_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xD9, 0xFF }.Concat( Enumerable.Repeat( ( byte )'a', 0xFF ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackString( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 257 ) );
				Assert.That( result.Length, Is.EqualTo( 0xFF ) );
				Assert.That( result, Is.All.EqualTo( 'a' ) );
			}
		}
		[Test]
		public void TestUnpackBinaryFromString_ByteArray_Str8MaxValue_AsRaw16_AsIs()
		{
			var result = Unpacking.UnpackBinary( new byte[] { 0xDA, 0x00, 0xFF }.Concat( Enumerable.Repeat( ( byte )'a', 0xFF ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 258 ) );
			Assert.That( result.Value.Length, Is.EqualTo( 0xFF ) );
			Assert.That( result.Value, Is.All.EqualTo( ( byte )'a' ) );
		}

		[Test]
		public void TestUnpackBinaryFromString_Stream_Str8MaxValue_AsRaw16_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xDA, 0x00, 0xFF }.Concat( Enumerable.Repeat( ( byte )'a', 0xFF ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackBinary( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 258 ) );
				Assert.That( result.Length, Is.EqualTo( 0xFF ) );
				Assert.That( result, Is.All.EqualTo( ( byte )'a' ) );
			}
		}
		
		[Test]
		public void TestUnpackString_ByteArray_Str8MaxValue_AsRaw16_AsIs()
		{
			var result = Unpacking.UnpackString( new byte[] { 0xDA, 0x00, 0xFF }.Concat( Enumerable.Repeat( ( byte )'a', 0xFF ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 258 ) );
			Assert.That( result.Value.Length, Is.EqualTo( 0xFF ) );
			Assert.That( result.Value, Is.All.EqualTo( 'a' ) );
		}

		[Test]
		public void TestUnpackString_Stream_Str8MaxValue_AsRaw16_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xDA, 0x00, 0xFF }.Concat( Enumerable.Repeat( ( byte )'a', 0xFF ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackString( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 258 ) );
				Assert.That( result.Length, Is.EqualTo( 0xFF ) );
				Assert.That( result, Is.All.EqualTo( 'a' ) );
			}
		}
		[Test]
		public void TestUnpackBinaryFromString_ByteArray_Str8MaxValue_AsRaw32_AsIs()
		{
			var result = Unpacking.UnpackBinary( new byte[] { 0xDB, 0x00, 0x00, 0x00, 0xFF }.Concat( Enumerable.Repeat( ( byte )'a', 0xFF ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 260 ) );
			Assert.That( result.Value.Length, Is.EqualTo( 0xFF ) );
			Assert.That( result.Value, Is.All.EqualTo( ( byte )'a' ) );
		}

		[Test]
		public void TestUnpackBinaryFromString_Stream_Str8MaxValue_AsRaw32_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xDB, 0x00, 0x00, 0x00, 0xFF }.Concat( Enumerable.Repeat( ( byte )'a', 0xFF ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackBinary( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 260 ) );
				Assert.That( result.Length, Is.EqualTo( 0xFF ) );
				Assert.That( result, Is.All.EqualTo( ( byte )'a' ) );
			}
		}
		
		[Test]
		public void TestUnpackString_ByteArray_Str8MaxValue_AsRaw32_AsIs()
		{
			var result = Unpacking.UnpackString( new byte[] { 0xDB, 0x00, 0x00, 0x00, 0xFF }.Concat( Enumerable.Repeat( ( byte )'a', 0xFF ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 260 ) );
			Assert.That( result.Value.Length, Is.EqualTo( 0xFF ) );
			Assert.That( result.Value, Is.All.EqualTo( 'a' ) );
		}

		[Test]
		public void TestUnpackString_Stream_Str8MaxValue_AsRaw32_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xDB, 0x00, 0x00, 0x00, 0xFF }.Concat( Enumerable.Repeat( ( byte )'a', 0xFF ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackString( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 260 ) );
				Assert.That( result.Length, Is.EqualTo( 0xFF ) );
				Assert.That( result, Is.All.EqualTo( 'a' ) );
			}
		}
		[Test]
		public void TestUnpackBinaryFromString_ByteArray_Raw16MinValue_AsRaw16_AsIs()
		{
			var result = Unpacking.UnpackBinary( new byte[] { 0xDA, 0x01, 0x00 }.Concat( Enumerable.Repeat( ( byte )'a', 0x100 ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 259 ) );
			Assert.That( result.Value.Length, Is.EqualTo( 0x100 ) );
			Assert.That( result.Value, Is.All.EqualTo( ( byte )'a' ) );
		}

		[Test]
		public void TestUnpackBinaryFromString_Stream_Raw16MinValue_AsRaw16_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xDA, 0x01, 0x00 }.Concat( Enumerable.Repeat( ( byte )'a', 0x100 ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackBinary( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 259 ) );
				Assert.That( result.Length, Is.EqualTo( 0x100 ) );
				Assert.That( result, Is.All.EqualTo( ( byte )'a' ) );
			}
		}
		
		[Test]
		public void TestUnpackString_ByteArray_Raw16MinValue_AsRaw16_AsIs()
		{
			var result = Unpacking.UnpackString( new byte[] { 0xDA, 0x01, 0x00 }.Concat( Enumerable.Repeat( ( byte )'a', 0x100 ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 259 ) );
			Assert.That( result.Value.Length, Is.EqualTo( 0x100 ) );
			Assert.That( result.Value, Is.All.EqualTo( 'a' ) );
		}

		[Test]
		public void TestUnpackString_Stream_Raw16MinValue_AsRaw16_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xDA, 0x01, 0x00 }.Concat( Enumerable.Repeat( ( byte )'a', 0x100 ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackString( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 259 ) );
				Assert.That( result.Length, Is.EqualTo( 0x100 ) );
				Assert.That( result, Is.All.EqualTo( 'a' ) );
			}
		}
		[Test]
		public void TestUnpackBinaryFromString_ByteArray_Raw16MinValue_AsRaw32_AsIs()
		{
			var result = Unpacking.UnpackBinary( new byte[] { 0xDB, 0x00, 0x00, 0x01, 0x00 }.Concat( Enumerable.Repeat( ( byte )'a', 0x100 ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 261 ) );
			Assert.That( result.Value.Length, Is.EqualTo( 0x100 ) );
			Assert.That( result.Value, Is.All.EqualTo( ( byte )'a' ) );
		}

		[Test]
		public void TestUnpackBinaryFromString_Stream_Raw16MinValue_AsRaw32_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xDB, 0x00, 0x00, 0x01, 0x00 }.Concat( Enumerable.Repeat( ( byte )'a', 0x100 ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackBinary( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 261 ) );
				Assert.That( result.Length, Is.EqualTo( 0x100 ) );
				Assert.That( result, Is.All.EqualTo( ( byte )'a' ) );
			}
		}
		
		[Test]
		public void TestUnpackString_ByteArray_Raw16MinValue_AsRaw32_AsIs()
		{
			var result = Unpacking.UnpackString( new byte[] { 0xDB, 0x00, 0x00, 0x01, 0x00 }.Concat( Enumerable.Repeat( ( byte )'a', 0x100 ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 261 ) );
			Assert.That( result.Value.Length, Is.EqualTo( 0x100 ) );
			Assert.That( result.Value, Is.All.EqualTo( 'a' ) );
		}

		[Test]
		public void TestUnpackString_Stream_Raw16MinValue_AsRaw32_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xDB, 0x00, 0x00, 0x01, 0x00 }.Concat( Enumerable.Repeat( ( byte )'a', 0x100 ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackString( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 261 ) );
				Assert.That( result.Length, Is.EqualTo( 0x100 ) );
				Assert.That( result, Is.All.EqualTo( 'a' ) );
			}
		}
		[Test]
		public void TestUnpackBinaryFromString_ByteArray_Raw16MaxValue_AsRaw16_AsIs()
		{
			var result = Unpacking.UnpackBinary( new byte[] { 0xDA, 0xFF, 0xFF }.Concat( Enumerable.Repeat( ( byte )'a', 0xFFFF ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 65538 ) );
			Assert.That( result.Value.Length, Is.EqualTo( 0xFFFF ) );
			Assert.That( result.Value, Is.All.EqualTo( ( byte )'a' ) );
		}

		[Test]
		public void TestUnpackBinaryFromString_Stream_Raw16MaxValue_AsRaw16_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xDA, 0xFF, 0xFF }.Concat( Enumerable.Repeat( ( byte )'a', 0xFFFF ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackBinary( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 65538 ) );
				Assert.That( result.Length, Is.EqualTo( 0xFFFF ) );
				Assert.That( result, Is.All.EqualTo( ( byte )'a' ) );
			}
		}
		
		[Test]
		public void TestUnpackString_ByteArray_Raw16MaxValue_AsRaw16_AsIs()
		{
			var result = Unpacking.UnpackString( new byte[] { 0xDA, 0xFF, 0xFF }.Concat( Enumerable.Repeat( ( byte )'a', 0xFFFF ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 65538 ) );
			Assert.That( result.Value.Length, Is.EqualTo( 0xFFFF ) );
			Assert.That( result.Value, Is.All.EqualTo( 'a' ) );
		}

		[Test]
		public void TestUnpackString_Stream_Raw16MaxValue_AsRaw16_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xDA, 0xFF, 0xFF }.Concat( Enumerable.Repeat( ( byte )'a', 0xFFFF ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackString( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 65538 ) );
				Assert.That( result.Length, Is.EqualTo( 0xFFFF ) );
				Assert.That( result, Is.All.EqualTo( 'a' ) );
			}
		}
		[Test]
		public void TestUnpackBinaryFromString_ByteArray_Raw16MaxValue_AsRaw32_AsIs()
		{
			var result = Unpacking.UnpackBinary( new byte[] { 0xDB, 0x00, 0x00, 0xFF, 0xFF }.Concat( Enumerable.Repeat( ( byte )'a', 0xFFFF ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 65540 ) );
			Assert.That( result.Value.Length, Is.EqualTo( 0xFFFF ) );
			Assert.That( result.Value, Is.All.EqualTo( ( byte )'a' ) );
		}

		[Test]
		public void TestUnpackBinaryFromString_Stream_Raw16MaxValue_AsRaw32_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xDB, 0x00, 0x00, 0xFF, 0xFF }.Concat( Enumerable.Repeat( ( byte )'a', 0xFFFF ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackBinary( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 65540 ) );
				Assert.That( result.Length, Is.EqualTo( 0xFFFF ) );
				Assert.That( result, Is.All.EqualTo( ( byte )'a' ) );
			}
		}
		
		[Test]
		public void TestUnpackString_ByteArray_Raw16MaxValue_AsRaw32_AsIs()
		{
			var result = Unpacking.UnpackString( new byte[] { 0xDB, 0x00, 0x00, 0xFF, 0xFF }.Concat( Enumerable.Repeat( ( byte )'a', 0xFFFF ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 65540 ) );
			Assert.That( result.Value.Length, Is.EqualTo( 0xFFFF ) );
			Assert.That( result.Value, Is.All.EqualTo( 'a' ) );
		}

		[Test]
		public void TestUnpackString_Stream_Raw16MaxValue_AsRaw32_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xDB, 0x00, 0x00, 0xFF, 0xFF }.Concat( Enumerable.Repeat( ( byte )'a', 0xFFFF ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackString( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 65540 ) );
				Assert.That( result.Length, Is.EqualTo( 0xFFFF ) );
				Assert.That( result, Is.All.EqualTo( 'a' ) );
			}
		}
		[Test]
		public void TestUnpackBinaryFromString_ByteArray_Raw32MinValue_AsRaw32_AsIs()
		{
			var result = Unpacking.UnpackBinary( new byte[] { 0xDB, 0x00, 0x01, 0x00, 0x00 }.Concat( Enumerable.Repeat( ( byte )'a', 0x10000 ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 65541 ) );
			Assert.That( result.Value.Length, Is.EqualTo( 0x10000 ) );
			Assert.That( result.Value, Is.All.EqualTo( ( byte )'a' ) );
		}

		[Test]
		public void TestUnpackBinaryFromString_Stream_Raw32MinValue_AsRaw32_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xDB, 0x00, 0x01, 0x00, 0x00 }.Concat( Enumerable.Repeat( ( byte )'a', 0x10000 ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackBinary( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 65541 ) );
				Assert.That( result.Length, Is.EqualTo( 0x10000 ) );
				Assert.That( result, Is.All.EqualTo( ( byte )'a' ) );
			}
		}
		
		[Test]
		public void TestUnpackString_ByteArray_Raw32MinValue_AsRaw32_AsIs()
		{
			var result = Unpacking.UnpackString( new byte[] { 0xDB, 0x00, 0x01, 0x00, 0x00 }.Concat( Enumerable.Repeat( ( byte )'a', 0x10000 ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 65541 ) );
			Assert.That( result.Value.Length, Is.EqualTo( 0x10000 ) );
			Assert.That( result.Value, Is.All.EqualTo( 'a' ) );
		}

		[Test]
		public void TestUnpackString_Stream_Raw32MinValue_AsRaw32_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xDB, 0x00, 0x01, 0x00, 0x00 }.Concat( Enumerable.Repeat( ( byte )'a', 0x10000 ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackString( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 65541 ) );
				Assert.That( result.Length, Is.EqualTo( 0x10000 ) );
				Assert.That( result, Is.All.EqualTo( 'a' ) );
			}
		}
		[Test]
		public void TestUnpackBinaryFromBinary_ByteArray_Bin8MinValue_AsBin8_AsIs()
		{
			var result = Unpacking.UnpackBinary( new byte[] { 0xC4, 0x00 } );
			Assert.That( result.ReadCount, Is.EqualTo( 2 ) );
			Assert.That( result.Value.Length, Is.EqualTo( 0x00 ) );
			Assert.That( result.Value, Is.All.EqualTo( 0xFF ) );
		}

		[Test]
		public void TestUnpackBinaryFromBinary_Stream_Bin8MinValue_AsBin8_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xC4, 0x00 } ) )
			{
				var result = Unpacking.UnpackBinary( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 2 ) );
				Assert.That( result.Length, Is.EqualTo( 0x00 ) );
				Assert.That( result, Is.All.EqualTo( 0xFF ) );
			}
		}
		
		[Test]
		public void TestUnpackBinaryFromBinary_ByteArray_Bin8MinValue_AsBin16_AsIs()
		{
			var result = Unpacking.UnpackBinary( new byte[] { 0xC5, 0x00, 0x00 } );
			Assert.That( result.ReadCount, Is.EqualTo( 3 ) );
			Assert.That( result.Value.Length, Is.EqualTo( 0x00 ) );
			Assert.That( result.Value, Is.All.EqualTo( 0xFF ) );
		}

		[Test]
		public void TestUnpackBinaryFromBinary_Stream_Bin8MinValue_AsBin16_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xC5, 0x00, 0x00 } ) )
			{
				var result = Unpacking.UnpackBinary( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 3 ) );
				Assert.That( result.Length, Is.EqualTo( 0x00 ) );
				Assert.That( result, Is.All.EqualTo( 0xFF ) );
			}
		}
		
		[Test]
		public void TestUnpackBinaryFromBinary_ByteArray_Bin8MinValue_AsBin32_AsIs()
		{
			var result = Unpacking.UnpackBinary( new byte[] { 0xC6, 0x00, 0x00, 0x00, 0x00 } );
			Assert.That( result.ReadCount, Is.EqualTo( 5 ) );
			Assert.That( result.Value.Length, Is.EqualTo( 0x00 ) );
			Assert.That( result.Value, Is.All.EqualTo( 0xFF ) );
		}

		[Test]
		public void TestUnpackBinaryFromBinary_Stream_Bin8MinValue_AsBin32_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xC6, 0x00, 0x00, 0x00, 0x00 } ) )
			{
				var result = Unpacking.UnpackBinary( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 5 ) );
				Assert.That( result.Length, Is.EqualTo( 0x00 ) );
				Assert.That( result, Is.All.EqualTo( 0xFF ) );
			}
		}
		
		[Test]
		public void TestUnpackBinaryFromBinary_ByteArray_Bin8MaxValue_AsBin8_AsIs()
		{
			var result = Unpacking.UnpackBinary( new byte[] { 0xC4, 0xFF }.Concat( Enumerable.Repeat( ( byte )0xFF, 0xFF ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 257 ) );
			Assert.That( result.Value.Length, Is.EqualTo( 0xFF ) );
			Assert.That( result.Value, Is.All.EqualTo( 0xFF ) );
		}

		[Test]
		public void TestUnpackBinaryFromBinary_Stream_Bin8MaxValue_AsBin8_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xC4, 0xFF }.Concat( Enumerable.Repeat( ( byte )0xFF, 0xFF ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackBinary( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 257 ) );
				Assert.That( result.Length, Is.EqualTo( 0xFF ) );
				Assert.That( result, Is.All.EqualTo( 0xFF ) );
			}
		}
		
		[Test]
		public void TestUnpackBinaryFromBinary_ByteArray_Bin8MaxValue_AsBin16_AsIs()
		{
			var result = Unpacking.UnpackBinary( new byte[] { 0xC5, 0x00, 0xFF }.Concat( Enumerable.Repeat( ( byte )0xFF, 0xFF ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 258 ) );
			Assert.That( result.Value.Length, Is.EqualTo( 0xFF ) );
			Assert.That( result.Value, Is.All.EqualTo( 0xFF ) );
		}

		[Test]
		public void TestUnpackBinaryFromBinary_Stream_Bin8MaxValue_AsBin16_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xC5, 0x00, 0xFF }.Concat( Enumerable.Repeat( ( byte )0xFF, 0xFF ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackBinary( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 258 ) );
				Assert.That( result.Length, Is.EqualTo( 0xFF ) );
				Assert.That( result, Is.All.EqualTo( 0xFF ) );
			}
		}
		
		[Test]
		public void TestUnpackBinaryFromBinary_ByteArray_Bin8MaxValue_AsBin32_AsIs()
		{
			var result = Unpacking.UnpackBinary( new byte[] { 0xC6, 0x00, 0x00, 0x00, 0xFF }.Concat( Enumerable.Repeat( ( byte )0xFF, 0xFF ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 260 ) );
			Assert.That( result.Value.Length, Is.EqualTo( 0xFF ) );
			Assert.That( result.Value, Is.All.EqualTo( 0xFF ) );
		}

		[Test]
		public void TestUnpackBinaryFromBinary_Stream_Bin8MaxValue_AsBin32_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xC6, 0x00, 0x00, 0x00, 0xFF }.Concat( Enumerable.Repeat( ( byte )0xFF, 0xFF ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackBinary( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 260 ) );
				Assert.That( result.Length, Is.EqualTo( 0xFF ) );
				Assert.That( result, Is.All.EqualTo( 0xFF ) );
			}
		}
		
		[Test]
		public void TestUnpackBinaryFromBinary_ByteArray_Bin16MinValue_AsBin16_AsIs()
		{
			var result = Unpacking.UnpackBinary( new byte[] { 0xC5, 0x01, 0x00 }.Concat( Enumerable.Repeat( ( byte )0xFF, 0x100 ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 259 ) );
			Assert.That( result.Value.Length, Is.EqualTo( 0x100 ) );
			Assert.That( result.Value, Is.All.EqualTo( 0xFF ) );
		}

		[Test]
		public void TestUnpackBinaryFromBinary_Stream_Bin16MinValue_AsBin16_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xC5, 0x01, 0x00 }.Concat( Enumerable.Repeat( ( byte )0xFF, 0x100 ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackBinary( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 259 ) );
				Assert.That( result.Length, Is.EqualTo( 0x100 ) );
				Assert.That( result, Is.All.EqualTo( 0xFF ) );
			}
		}
		
		[Test]
		public void TestUnpackBinaryFromBinary_ByteArray_Bin16MinValue_AsBin32_AsIs()
		{
			var result = Unpacking.UnpackBinary( new byte[] { 0xC6, 0x00, 0x00, 0x01, 0x00 }.Concat( Enumerable.Repeat( ( byte )0xFF, 0x100 ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 261 ) );
			Assert.That( result.Value.Length, Is.EqualTo( 0x100 ) );
			Assert.That( result.Value, Is.All.EqualTo( 0xFF ) );
		}

		[Test]
		public void TestUnpackBinaryFromBinary_Stream_Bin16MinValue_AsBin32_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xC6, 0x00, 0x00, 0x01, 0x00 }.Concat( Enumerable.Repeat( ( byte )0xFF, 0x100 ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackBinary( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 261 ) );
				Assert.That( result.Length, Is.EqualTo( 0x100 ) );
				Assert.That( result, Is.All.EqualTo( 0xFF ) );
			}
		}
		
		[Test]
		public void TestUnpackBinaryFromBinary_ByteArray_Bin16MaxValue_AsBin16_AsIs()
		{
			var result = Unpacking.UnpackBinary( new byte[] { 0xC5, 0xFF, 0xFF }.Concat( Enumerable.Repeat( ( byte )0xFF, 0xFFFF ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 65538 ) );
			Assert.That( result.Value.Length, Is.EqualTo( 0xFFFF ) );
			Assert.That( result.Value, Is.All.EqualTo( 0xFF ) );
		}

		[Test]
		public void TestUnpackBinaryFromBinary_Stream_Bin16MaxValue_AsBin16_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xC5, 0xFF, 0xFF }.Concat( Enumerable.Repeat( ( byte )0xFF, 0xFFFF ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackBinary( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 65538 ) );
				Assert.That( result.Length, Is.EqualTo( 0xFFFF ) );
				Assert.That( result, Is.All.EqualTo( 0xFF ) );
			}
		}
		
		[Test]
		public void TestUnpackBinaryFromBinary_ByteArray_Bin16MaxValue_AsBin32_AsIs()
		{
			var result = Unpacking.UnpackBinary( new byte[] { 0xC6, 0x00, 0x00, 0xFF, 0xFF }.Concat( Enumerable.Repeat( ( byte )0xFF, 0xFFFF ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 65540 ) );
			Assert.That( result.Value.Length, Is.EqualTo( 0xFFFF ) );
			Assert.That( result.Value, Is.All.EqualTo( 0xFF ) );
		}

		[Test]
		public void TestUnpackBinaryFromBinary_Stream_Bin16MaxValue_AsBin32_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xC6, 0x00, 0x00, 0xFF, 0xFF }.Concat( Enumerable.Repeat( ( byte )0xFF, 0xFFFF ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackBinary( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 65540 ) );
				Assert.That( result.Length, Is.EqualTo( 0xFFFF ) );
				Assert.That( result, Is.All.EqualTo( 0xFF ) );
			}
		}
		
		[Test]
		public void TestUnpackBinaryFromBinary_ByteArray_Bin32MinValue_AsBin32_AsIs()
		{
			var result = Unpacking.UnpackBinary( new byte[] { 0xC6, 0x00, 0x01, 0x00, 0x00 }.Concat( Enumerable.Repeat( ( byte )0xFF, 0x10000 ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 65541 ) );
			Assert.That( result.Value.Length, Is.EqualTo( 0x10000 ) );
			Assert.That( result.Value, Is.All.EqualTo( 0xFF ) );
		}

		[Test]
		public void TestUnpackBinaryFromBinary_Stream_Bin32MinValue_AsBin32_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xC6, 0x00, 0x01, 0x00, 0x00 }.Concat( Enumerable.Repeat( ( byte )0xFF, 0x10000 ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackBinary( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 65541 ) );
				Assert.That( result.Length, Is.EqualTo( 0x10000 ) );
				Assert.That( result, Is.All.EqualTo( 0xFF ) );
			}
		}
		
		[Test]
		public void TestUnpackBinary_ByteArray_Empty()
		{
			Assert.Throws<ArgumentException>( () => Unpacking.UnpackBinary( new byte[ 0 ] ) );
		}

		[Test]
		public void TestUnpackBinary_ByteArray_Null()
		{
			Assert.Throws<ArgumentNullException>( () => Unpacking.UnpackBinary( default( byte[] ) ) );
		}

		[Test]
		public void TestUnpackBinary_ByteArray_Offset_Null()
		{
			Assert.Throws<ArgumentNullException>( () => Unpacking.UnpackBinary( default( byte[] ), 0 ) );
		}

		[Test]
		public void TestUnpackBinary_ByteArray_Offset_OffsetIsNegative()
		{
			Assert.Throws<ArgumentOutOfRangeException>( () => Unpacking.UnpackBinary( new byte[]{ 0x1 }, -1 ) );
		}

		[Test]
		public void TestUnpackBinary_ByteArray_Offset_OffsetIsTooBig()
		{
			Assert.Throws<ArgumentException>( () => Unpacking.UnpackBinary( new byte[]{ 0x1 }, 1 ) );
		}

		[Test]
		public void TestUnpackBinary_ByteArray_Offset_Empty()
		{
			Assert.Throws<ArgumentException>( () => Unpacking.UnpackBinary( new byte[ 0 ], 0 ) );
		}

		[Test]
		public void TestUnpackBinary_Stream_Null()
		{
			Assert.Throws<ArgumentNullException>( () => Unpacking.UnpackBinary( default( Stream ) ) );
		}

		[Test]
		public void TestUnpackBinary_ByteArray_Offset_OffsetIsValid_OffsetIsRespected()
		{
			var result = Unpacking.UnpackBinary( new byte[] { 0xFF, 0xA0, 0xFF }, 1 );
			Assert.That( result.ReadCount, Is.EqualTo( 1 ) );
			Assert.That( result.Value.Length, Is.EqualTo( 0 ) );
		}

		[Test]
		public void TestUnpackBinary_ByteArray_Null_Nil()
		{
			var result = Unpacking.UnpackBinary( new byte[] { 0xC0 } );
			Assert.That( result.ReadCount, Is.EqualTo( 1 ) );
			Assert.That( result.Value, Is.Null );
		}
	
		[Test]
		public void TestUnpackBinary_ByteArray_NotBinary()
		{
			Assert.Throws<MessageTypeException>( () => Unpacking.UnpackBinary( new byte[] { 0x1 } ) );
		}
	}
}