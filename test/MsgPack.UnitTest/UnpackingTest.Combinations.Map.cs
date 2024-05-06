
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
	public 	partial class UnpackingTest_Combinations_Map
	{
		[Test]
		public void TestUnpackDictionaryCount_ByteArray_FixMap0Value_AsFixMap0_AsIs()
		{
			var result = Unpacking.UnpackDictionaryCount( new byte[] { 0x80 } );
			Assert.That( result.ReadCount, Is.EqualTo( 1 ) );
			Assert.That( result.Value, Is.EqualTo( 0 ) );
		}

		[Test]
		public void TestUnpackDictionaryCount_Stream_FixMap0Value_AsFixMap0_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0x80 } ) )
			{
				var result = Unpacking.UnpackDictionaryCount( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 1 ) );
				Assert.That( result, Is.EqualTo( 0 ) );
			}
		}

		[Test]
		public void TestUnpackDictionary_ByteArray_FixMap0Value_AsFixMap0_AsIs()
		{
			var result = Unpacking.UnpackDictionary( new byte[] { 0x80 } );
			Assert.That( result.ReadCount, Is.EqualTo( 1 ) );
			Assert.That( result.Value.Count, Is.EqualTo( 0 ) );
			for ( int i = 0; i < result.Value.Count; i++ )
			{
				MessagePackObject value;
				Assert.That( result.Value.TryGetValue( i + 1, out value ), Is.True );
				Assert.That( value, Is.EqualTo( ( MessagePackObject )0x57 ) );
			}
		}

		[Test]
		public void TestUnpackDictionary_Stream_FixMap0Value_AsFixMap0_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0x80 } ) )
			{
				var result = Unpacking.UnpackDictionary( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 1 ) );
				Assert.That( result.Count, Is.EqualTo( 0 ) );
				for ( int i = 0; i < result.Count; i++ )
				{
					MessagePackObject value;
					Assert.That( result.TryGetValue( i + 1, out value ), Is.True );
					Assert.That( value, Is.EqualTo( ( MessagePackObject )0x57 ) );
				}
			}
		}

		[Test]
		public void TestUnpackDictionaryCount_ByteArray_FixMap0Value_AsMap16_AsIs()
		{
			var result = Unpacking.UnpackDictionaryCount( new byte[] { 0xDE, 0x00, 0x00 } );
			Assert.That( result.ReadCount, Is.EqualTo( 3 ) );
			Assert.That( result.Value, Is.EqualTo( 0 ) );
		}

		[Test]
		public void TestUnpackDictionaryCount_Stream_FixMap0Value_AsMap16_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xDE, 0x00, 0x00 } ) )
			{
				var result = Unpacking.UnpackDictionaryCount( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 3 ) );
				Assert.That( result, Is.EqualTo( 0 ) );
			}
		}

		[Test]
		public void TestUnpackDictionary_ByteArray_FixMap0Value_AsMap16_AsIs()
		{
			var result = Unpacking.UnpackDictionary( new byte[] { 0xDE, 0x00, 0x00 } );
			Assert.That( result.ReadCount, Is.EqualTo( 3 ) );
			Assert.That( result.Value.Count, Is.EqualTo( 0 ) );
			for ( int i = 0; i < result.Value.Count; i++ )
			{
				MessagePackObject value;
				Assert.That( result.Value.TryGetValue( i + 1, out value ), Is.True );
				Assert.That( value, Is.EqualTo( ( MessagePackObject )0x57 ) );
			}
		}

		[Test]
		public void TestUnpackDictionary_Stream_FixMap0Value_AsMap16_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xDE, 0x00, 0x00 } ) )
			{
				var result = Unpacking.UnpackDictionary( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 3 ) );
				Assert.That( result.Count, Is.EqualTo( 0 ) );
				for ( int i = 0; i < result.Count; i++ )
				{
					MessagePackObject value;
					Assert.That( result.TryGetValue( i + 1, out value ), Is.True );
					Assert.That( value, Is.EqualTo( ( MessagePackObject )0x57 ) );
				}
			}
		}

		[Test]
		public void TestUnpackDictionaryCount_ByteArray_FixMap0Value_AsMap32_AsIs()
		{
			var result = Unpacking.UnpackDictionaryCount( new byte[] { 0xDF, 0x00, 0x00, 0x00, 0x00 } );
			Assert.That( result.ReadCount, Is.EqualTo( 5 ) );
			Assert.That( result.Value, Is.EqualTo( 0 ) );
		}

		[Test]
		public void TestUnpackDictionaryCount_Stream_FixMap0Value_AsMap32_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xDF, 0x00, 0x00, 0x00, 0x00 } ) )
			{
				var result = Unpacking.UnpackDictionaryCount( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 5 ) );
				Assert.That( result, Is.EqualTo( 0 ) );
			}
		}

		[Test]
		public void TestUnpackDictionary_ByteArray_FixMap0Value_AsMap32_AsIs()
		{
			var result = Unpacking.UnpackDictionary( new byte[] { 0xDF, 0x00, 0x00, 0x00, 0x00 } );
			Assert.That( result.ReadCount, Is.EqualTo( 5 ) );
			Assert.That( result.Value.Count, Is.EqualTo( 0 ) );
			for ( int i = 0; i < result.Value.Count; i++ )
			{
				MessagePackObject value;
				Assert.That( result.Value.TryGetValue( i + 1, out value ), Is.True );
				Assert.That( value, Is.EqualTo( ( MessagePackObject )0x57 ) );
			}
		}

		[Test]
		public void TestUnpackDictionary_Stream_FixMap0Value_AsMap32_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xDF, 0x00, 0x00, 0x00, 0x00 } ) )
			{
				var result = Unpacking.UnpackDictionary( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 5 ) );
				Assert.That( result.Count, Is.EqualTo( 0 ) );
				for ( int i = 0; i < result.Count; i++ )
				{
					MessagePackObject value;
					Assert.That( result.TryGetValue( i + 1, out value ), Is.True );
					Assert.That( value, Is.EqualTo( ( MessagePackObject )0x57 ) );
				}
			}
		}

		[Test]
		public void TestUnpackDictionaryCount_ByteArray_FixMap1Value_AsFixMap1_AsIs()
		{
			var result = Unpacking.UnpackDictionaryCount( new byte[] { 0x81 }.Concat( CreateDictionaryBodyBinary( 1 ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 1 ) );
			Assert.That( result.Value, Is.EqualTo( 0x1 ) );
		}

		[Test]
		public void TestUnpackDictionaryCount_Stream_FixMap1Value_AsFixMap1_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0x81 }.Concat( CreateDictionaryBodyBinary( 1 ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackDictionaryCount( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 1 ) );
				Assert.That( result, Is.EqualTo( 0x1 ) );
			}
		}

		[Test]
		public void TestUnpackDictionary_ByteArray_FixMap1Value_AsFixMap1_AsIs()
		{
			var result = Unpacking.UnpackDictionary( new byte[] { 0x81 }.Concat( CreateDictionaryBodyBinary( 1 ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 7 ) );
			Assert.That( result.Value.Count, Is.EqualTo( 0x1 ) );
			for ( int i = 0; i < result.Value.Count; i++ )
			{
				MessagePackObject value;
				Assert.That( result.Value.TryGetValue( i + 1, out value ), Is.True );
				Assert.That( value, Is.EqualTo( ( MessagePackObject )0x57 ) );
			}
		}

		[Test]
		public void TestUnpackDictionary_Stream_FixMap1Value_AsFixMap1_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0x81 }.Concat( CreateDictionaryBodyBinary( 1 ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackDictionary( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 7 ) );
				Assert.That( result.Count, Is.EqualTo( 0x1 ) );
				for ( int i = 0; i < result.Count; i++ )
				{
					MessagePackObject value;
					Assert.That( result.TryGetValue( i + 1, out value ), Is.True );
					Assert.That( value, Is.EqualTo( ( MessagePackObject )0x57 ) );
				}
			}
		}

		[Test]
		public void TestUnpackDictionaryCount_ByteArray_FixMap1Value_AsMap16_AsIs()
		{
			var result = Unpacking.UnpackDictionaryCount( new byte[] { 0xDE, 0x00, 0x01 }.Concat( CreateDictionaryBodyBinary( 1 ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 3 ) );
			Assert.That( result.Value, Is.EqualTo( 0x1 ) );
		}

		[Test]
		public void TestUnpackDictionaryCount_Stream_FixMap1Value_AsMap16_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xDE, 0x00, 0x01 }.Concat( CreateDictionaryBodyBinary( 1 ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackDictionaryCount( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 3 ) );
				Assert.That( result, Is.EqualTo( 0x1 ) );
			}
		}

		[Test]
		public void TestUnpackDictionary_ByteArray_FixMap1Value_AsMap16_AsIs()
		{
			var result = Unpacking.UnpackDictionary( new byte[] { 0xDE, 0x00, 0x01 }.Concat( CreateDictionaryBodyBinary( 1 ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 9 ) );
			Assert.That( result.Value.Count, Is.EqualTo( 0x1 ) );
			for ( int i = 0; i < result.Value.Count; i++ )
			{
				MessagePackObject value;
				Assert.That( result.Value.TryGetValue( i + 1, out value ), Is.True );
				Assert.That( value, Is.EqualTo( ( MessagePackObject )0x57 ) );
			}
		}

		[Test]
		public void TestUnpackDictionary_Stream_FixMap1Value_AsMap16_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xDE, 0x00, 0x01 }.Concat( CreateDictionaryBodyBinary( 1 ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackDictionary( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 9 ) );
				Assert.That( result.Count, Is.EqualTo( 0x1 ) );
				for ( int i = 0; i < result.Count; i++ )
				{
					MessagePackObject value;
					Assert.That( result.TryGetValue( i + 1, out value ), Is.True );
					Assert.That( value, Is.EqualTo( ( MessagePackObject )0x57 ) );
				}
			}
		}

		[Test]
		public void TestUnpackDictionaryCount_ByteArray_FixMap1Value_AsMap32_AsIs()
		{
			var result = Unpacking.UnpackDictionaryCount( new byte[] { 0xDF, 0x00, 0x00, 0x00, 0x01 }.Concat( CreateDictionaryBodyBinary( 1 ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 5 ) );
			Assert.That( result.Value, Is.EqualTo( 0x1 ) );
		}

		[Test]
		public void TestUnpackDictionaryCount_Stream_FixMap1Value_AsMap32_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xDF, 0x00, 0x00, 0x00, 0x01 }.Concat( CreateDictionaryBodyBinary( 1 ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackDictionaryCount( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 5 ) );
				Assert.That( result, Is.EqualTo( 0x1 ) );
			}
		}

		[Test]
		public void TestUnpackDictionary_ByteArray_FixMap1Value_AsMap32_AsIs()
		{
			var result = Unpacking.UnpackDictionary( new byte[] { 0xDF, 0x00, 0x00, 0x00, 0x01 }.Concat( CreateDictionaryBodyBinary( 1 ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 11 ) );
			Assert.That( result.Value.Count, Is.EqualTo( 0x1 ) );
			for ( int i = 0; i < result.Value.Count; i++ )
			{
				MessagePackObject value;
				Assert.That( result.Value.TryGetValue( i + 1, out value ), Is.True );
				Assert.That( value, Is.EqualTo( ( MessagePackObject )0x57 ) );
			}
		}

		[Test]
		public void TestUnpackDictionary_Stream_FixMap1Value_AsMap32_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xDF, 0x00, 0x00, 0x00, 0x01 }.Concat( CreateDictionaryBodyBinary( 1 ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackDictionary( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 11 ) );
				Assert.That( result.Count, Is.EqualTo( 0x1 ) );
				for ( int i = 0; i < result.Count; i++ )
				{
					MessagePackObject value;
					Assert.That( result.TryGetValue( i + 1, out value ), Is.True );
					Assert.That( value, Is.EqualTo( ( MessagePackObject )0x57 ) );
				}
			}
		}

		[Test]
		public void TestUnpackDictionaryCount_ByteArray_FixMapMaxValue_AsFixMap15_AsIs()
		{
			var result = Unpacking.UnpackDictionaryCount( new byte[] { 0x8F }.Concat( CreateDictionaryBodyBinary( 0xF ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 1 ) );
			Assert.That( result.Value, Is.EqualTo( 0xF ) );
		}

		[Test]
		public void TestUnpackDictionaryCount_Stream_FixMapMaxValue_AsFixMap15_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0x8F }.Concat( CreateDictionaryBodyBinary( 0xF ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackDictionaryCount( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 1 ) );
				Assert.That( result, Is.EqualTo( 0xF ) );
			}
		}

		[Test]
		public void TestUnpackDictionary_ByteArray_FixMapMaxValue_AsFixMap15_AsIs()
		{
			var result = Unpacking.UnpackDictionary( new byte[] { 0x8F }.Concat( CreateDictionaryBodyBinary( 0xF ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 91 ) );
			Assert.That( result.Value.Count, Is.EqualTo( 0xF ) );
			for ( int i = 0; i < result.Value.Count; i++ )
			{
				MessagePackObject value;
				Assert.That( result.Value.TryGetValue( i + 1, out value ), Is.True );
				Assert.That( value, Is.EqualTo( ( MessagePackObject )0x57 ) );
			}
		}

		[Test]
		public void TestUnpackDictionary_Stream_FixMapMaxValue_AsFixMap15_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0x8F }.Concat( CreateDictionaryBodyBinary( 0xF ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackDictionary( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 91 ) );
				Assert.That( result.Count, Is.EqualTo( 0xF ) );
				for ( int i = 0; i < result.Count; i++ )
				{
					MessagePackObject value;
					Assert.That( result.TryGetValue( i + 1, out value ), Is.True );
					Assert.That( value, Is.EqualTo( ( MessagePackObject )0x57 ) );
				}
			}
		}

		[Test]
		public void TestUnpackDictionaryCount_ByteArray_FixMapMaxValue_AsMap16_AsIs()
		{
			var result = Unpacking.UnpackDictionaryCount( new byte[] { 0xDE, 0x00, 0x0F }.Concat( CreateDictionaryBodyBinary( 0xF ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 3 ) );
			Assert.That( result.Value, Is.EqualTo( 0xF ) );
		}

		[Test]
		public void TestUnpackDictionaryCount_Stream_FixMapMaxValue_AsMap16_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xDE, 0x00, 0x0F }.Concat( CreateDictionaryBodyBinary( 0xF ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackDictionaryCount( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 3 ) );
				Assert.That( result, Is.EqualTo( 0xF ) );
			}
		}

		[Test]
		public void TestUnpackDictionary_ByteArray_FixMapMaxValue_AsMap16_AsIs()
		{
			var result = Unpacking.UnpackDictionary( new byte[] { 0xDE, 0x00, 0x0F }.Concat( CreateDictionaryBodyBinary( 0xF ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 93 ) );
			Assert.That( result.Value.Count, Is.EqualTo( 0xF ) );
			for ( int i = 0; i < result.Value.Count; i++ )
			{
				MessagePackObject value;
				Assert.That( result.Value.TryGetValue( i + 1, out value ), Is.True );
				Assert.That( value, Is.EqualTo( ( MessagePackObject )0x57 ) );
			}
		}

		[Test]
		public void TestUnpackDictionary_Stream_FixMapMaxValue_AsMap16_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xDE, 0x00, 0x0F }.Concat( CreateDictionaryBodyBinary( 0xF ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackDictionary( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 93 ) );
				Assert.That( result.Count, Is.EqualTo( 0xF ) );
				for ( int i = 0; i < result.Count; i++ )
				{
					MessagePackObject value;
					Assert.That( result.TryGetValue( i + 1, out value ), Is.True );
					Assert.That( value, Is.EqualTo( ( MessagePackObject )0x57 ) );
				}
			}
		}

		[Test]
		public void TestUnpackDictionaryCount_ByteArray_FixMapMaxValue_AsMap32_AsIs()
		{
			var result = Unpacking.UnpackDictionaryCount( new byte[] { 0xDF, 0x00, 0x00, 0x00, 0x0F }.Concat( CreateDictionaryBodyBinary( 0xF ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 5 ) );
			Assert.That( result.Value, Is.EqualTo( 0xF ) );
		}

		[Test]
		public void TestUnpackDictionaryCount_Stream_FixMapMaxValue_AsMap32_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xDF, 0x00, 0x00, 0x00, 0x0F }.Concat( CreateDictionaryBodyBinary( 0xF ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackDictionaryCount( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 5 ) );
				Assert.That( result, Is.EqualTo( 0xF ) );
			}
		}

		[Test]
		public void TestUnpackDictionary_ByteArray_FixMapMaxValue_AsMap32_AsIs()
		{
			var result = Unpacking.UnpackDictionary( new byte[] { 0xDF, 0x00, 0x00, 0x00, 0x0F }.Concat( CreateDictionaryBodyBinary( 0xF ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 95 ) );
			Assert.That( result.Value.Count, Is.EqualTo( 0xF ) );
			for ( int i = 0; i < result.Value.Count; i++ )
			{
				MessagePackObject value;
				Assert.That( result.Value.TryGetValue( i + 1, out value ), Is.True );
				Assert.That( value, Is.EqualTo( ( MessagePackObject )0x57 ) );
			}
		}

		[Test]
		public void TestUnpackDictionary_Stream_FixMapMaxValue_AsMap32_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xDF, 0x00, 0x00, 0x00, 0x0F }.Concat( CreateDictionaryBodyBinary( 0xF ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackDictionary( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 95 ) );
				Assert.That( result.Count, Is.EqualTo( 0xF ) );
				for ( int i = 0; i < result.Count; i++ )
				{
					MessagePackObject value;
					Assert.That( result.TryGetValue( i + 1, out value ), Is.True );
					Assert.That( value, Is.EqualTo( ( MessagePackObject )0x57 ) );
				}
			}
		}

		[Test]
		public void TestUnpackDictionaryCount_ByteArray_Map16MinValue_AsMap16_AsIs()
		{
			var result = Unpacking.UnpackDictionaryCount( new byte[] { 0xDE, 0x00, 0x10 }.Concat( CreateDictionaryBodyBinary( 0x10 ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 3 ) );
			Assert.That( result.Value, Is.EqualTo( 0x10 ) );
		}

		[Test]
		public void TestUnpackDictionaryCount_Stream_Map16MinValue_AsMap16_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xDE, 0x00, 0x10 }.Concat( CreateDictionaryBodyBinary( 0x10 ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackDictionaryCount( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 3 ) );
				Assert.That( result, Is.EqualTo( 0x10 ) );
			}
		}

		[Test]
		public void TestUnpackDictionary_ByteArray_Map16MinValue_AsMap16_AsIs()
		{
			var result = Unpacking.UnpackDictionary( new byte[] { 0xDE, 0x00, 0x10 }.Concat( CreateDictionaryBodyBinary( 0x10 ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 99 ) );
			Assert.That( result.Value.Count, Is.EqualTo( 0x10 ) );
			for ( int i = 0; i < result.Value.Count; i++ )
			{
				MessagePackObject value;
				Assert.That( result.Value.TryGetValue( i + 1, out value ), Is.True );
				Assert.That( value, Is.EqualTo( ( MessagePackObject )0x57 ) );
			}
		}

		[Test]
		public void TestUnpackDictionary_Stream_Map16MinValue_AsMap16_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xDE, 0x00, 0x10 }.Concat( CreateDictionaryBodyBinary( 0x10 ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackDictionary( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 99 ) );
				Assert.That( result.Count, Is.EqualTo( 0x10 ) );
				for ( int i = 0; i < result.Count; i++ )
				{
					MessagePackObject value;
					Assert.That( result.TryGetValue( i + 1, out value ), Is.True );
					Assert.That( value, Is.EqualTo( ( MessagePackObject )0x57 ) );
				}
			}
		}

		[Test]
		public void TestUnpackDictionaryCount_ByteArray_Map16MinValue_AsMap32_AsIs()
		{
			var result = Unpacking.UnpackDictionaryCount( new byte[] { 0xDF, 0x00, 0x00, 0x00, 0x10 }.Concat( CreateDictionaryBodyBinary( 0x10 ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 5 ) );
			Assert.That( result.Value, Is.EqualTo( 0x10 ) );
		}

		[Test]
		public void TestUnpackDictionaryCount_Stream_Map16MinValue_AsMap32_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xDF, 0x00, 0x00, 0x00, 0x10 }.Concat( CreateDictionaryBodyBinary( 0x10 ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackDictionaryCount( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 5 ) );
				Assert.That( result, Is.EqualTo( 0x10 ) );
			}
		}

		[Test]
		public void TestUnpackDictionary_ByteArray_Map16MinValue_AsMap32_AsIs()
		{
			var result = Unpacking.UnpackDictionary( new byte[] { 0xDF, 0x00, 0x00, 0x00, 0x10 }.Concat( CreateDictionaryBodyBinary( 0x10 ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 101 ) );
			Assert.That( result.Value.Count, Is.EqualTo( 0x10 ) );
			for ( int i = 0; i < result.Value.Count; i++ )
			{
				MessagePackObject value;
				Assert.That( result.Value.TryGetValue( i + 1, out value ), Is.True );
				Assert.That( value, Is.EqualTo( ( MessagePackObject )0x57 ) );
			}
		}

		[Test]
		public void TestUnpackDictionary_Stream_Map16MinValue_AsMap32_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xDF, 0x00, 0x00, 0x00, 0x10 }.Concat( CreateDictionaryBodyBinary( 0x10 ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackDictionary( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 101 ) );
				Assert.That( result.Count, Is.EqualTo( 0x10 ) );
				for ( int i = 0; i < result.Count; i++ )
				{
					MessagePackObject value;
					Assert.That( result.TryGetValue( i + 1, out value ), Is.True );
					Assert.That( value, Is.EqualTo( ( MessagePackObject )0x57 ) );
				}
			}
		}

		[Test]
		public void TestUnpackDictionaryCount_ByteArray_Map16MaxValue_AsMap16_AsIs()
		{
			var result = Unpacking.UnpackDictionaryCount( new byte[] { 0xDE, 0xFF, 0xFF }.Concat( CreateDictionaryBodyBinary( 0xFFFF ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 3 ) );
			Assert.That( result.Value, Is.EqualTo( 0xFFFF ) );
		}

		[Test]
		public void TestUnpackDictionaryCount_Stream_Map16MaxValue_AsMap16_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xDE, 0xFF, 0xFF }.Concat( CreateDictionaryBodyBinary( 0xFFFF ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackDictionaryCount( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 3 ) );
				Assert.That( result, Is.EqualTo( 0xFFFF ) );
			}
		}

		[Test]
		public void TestUnpackDictionary_ByteArray_Map16MaxValue_AsMap16_AsIs()
		{
			var result = Unpacking.UnpackDictionary( new byte[] { 0xDE, 0xFF, 0xFF }.Concat( CreateDictionaryBodyBinary( 0xFFFF ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 393213 ) );
			Assert.That( result.Value.Count, Is.EqualTo( 0xFFFF ) );
			for ( int i = 0; i < result.Value.Count; i++ )
			{
				MessagePackObject value;
				Assert.That( result.Value.TryGetValue( i + 1, out value ), Is.True );
				Assert.That( value, Is.EqualTo( ( MessagePackObject )0x57 ) );
			}
		}

		[Test]
		public void TestUnpackDictionary_Stream_Map16MaxValue_AsMap16_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xDE, 0xFF, 0xFF }.Concat( CreateDictionaryBodyBinary( 0xFFFF ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackDictionary( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 393213 ) );
				Assert.That( result.Count, Is.EqualTo( 0xFFFF ) );
				for ( int i = 0; i < result.Count; i++ )
				{
					MessagePackObject value;
					Assert.That( result.TryGetValue( i + 1, out value ), Is.True );
					Assert.That( value, Is.EqualTo( ( MessagePackObject )0x57 ) );
				}
			}
		}

		[Test]
		public void TestUnpackDictionaryCount_ByteArray_Map16MaxValue_AsMap32_AsIs()
		{
			var result = Unpacking.UnpackDictionaryCount( new byte[] { 0xDF, 0x00, 0x00, 0xFF, 0xFF }.Concat( CreateDictionaryBodyBinary( 0xFFFF ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 5 ) );
			Assert.That( result.Value, Is.EqualTo( 0xFFFF ) );
		}

		[Test]
		public void TestUnpackDictionaryCount_Stream_Map16MaxValue_AsMap32_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xDF, 0x00, 0x00, 0xFF, 0xFF }.Concat( CreateDictionaryBodyBinary( 0xFFFF ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackDictionaryCount( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 5 ) );
				Assert.That( result, Is.EqualTo( 0xFFFF ) );
			}
		}

		[Test]
		public void TestUnpackDictionary_ByteArray_Map16MaxValue_AsMap32_AsIs()
		{
			var result = Unpacking.UnpackDictionary( new byte[] { 0xDF, 0x00, 0x00, 0xFF, 0xFF }.Concat( CreateDictionaryBodyBinary( 0xFFFF ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 393215 ) );
			Assert.That( result.Value.Count, Is.EqualTo( 0xFFFF ) );
			for ( int i = 0; i < result.Value.Count; i++ )
			{
				MessagePackObject value;
				Assert.That( result.Value.TryGetValue( i + 1, out value ), Is.True );
				Assert.That( value, Is.EqualTo( ( MessagePackObject )0x57 ) );
			}
		}

		[Test]
		public void TestUnpackDictionary_Stream_Map16MaxValue_AsMap32_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xDF, 0x00, 0x00, 0xFF, 0xFF }.Concat( CreateDictionaryBodyBinary( 0xFFFF ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackDictionary( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 393215 ) );
				Assert.That( result.Count, Is.EqualTo( 0xFFFF ) );
				for ( int i = 0; i < result.Count; i++ )
				{
					MessagePackObject value;
					Assert.That( result.TryGetValue( i + 1, out value ), Is.True );
					Assert.That( value, Is.EqualTo( ( MessagePackObject )0x57 ) );
				}
			}
		}

		[Test]
		public void TestUnpackDictionaryCount_ByteArray_Map32MinValue_AsMap32_AsIs()
		{
			var result = Unpacking.UnpackDictionaryCount( new byte[] { 0xDF, 0x00, 0x01, 0x00, 0x00 }.Concat( CreateDictionaryBodyBinary( 0x10000 ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 5 ) );
			Assert.That( result.Value, Is.EqualTo( 0x10000 ) );
		}

		[Test]
		public void TestUnpackDictionaryCount_Stream_Map32MinValue_AsMap32_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xDF, 0x00, 0x01, 0x00, 0x00 }.Concat( CreateDictionaryBodyBinary( 0x10000 ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackDictionaryCount( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 5 ) );
				Assert.That( result, Is.EqualTo( 0x10000 ) );
			}
		}

		[Test]
		public void TestUnpackDictionary_ByteArray_Map32MinValue_AsMap32_AsIs()
		{
			var result = Unpacking.UnpackDictionary( new byte[] { 0xDF, 0x00, 0x01, 0x00, 0x00 }.Concat( CreateDictionaryBodyBinary( 0x10000 ) ).ToArray() );
			Assert.That( result.ReadCount, Is.EqualTo( 393221 ) );
			Assert.That( result.Value.Count, Is.EqualTo( 0x10000 ) );
			for ( int i = 0; i < result.Value.Count; i++ )
			{
				MessagePackObject value;
				Assert.That( result.Value.TryGetValue( i + 1, out value ), Is.True );
				Assert.That( value, Is.EqualTo( ( MessagePackObject )0x57 ) );
			}
		}

		[Test]
		public void TestUnpackDictionary_Stream_Map32MinValue_AsMap32_AsIs()
		{
			using ( var buffer = new MemoryStream( new byte[] { 0xDF, 0x00, 0x01, 0x00, 0x00 }.Concat( CreateDictionaryBodyBinary( 0x10000 ) ).ToArray() ) )
			{
				var result = Unpacking.UnpackDictionary( buffer );
				Assert.That( buffer.Position, Is.EqualTo( 393221 ) );
				Assert.That( result.Count, Is.EqualTo( 0x10000 ) );
				for ( int i = 0; i < result.Count; i++ )
				{
					MessagePackObject value;
					Assert.That( result.TryGetValue( i + 1, out value ), Is.True );
					Assert.That( value, Is.EqualTo( ( MessagePackObject )0x57 ) );
				}
			}
		}


		[Test]
		public void TestUnpackDictionaryCount_ByteArray_Empty()
		{
			Assert.Throws<ArgumentException>( () => Unpacking.UnpackDictionaryCount( new byte[ 0 ] ) );
		}

		[Test]
		public void TestUnpackDictionaryCount_ByteArray_Null()
		{
			Assert.Throws<ArgumentNullException>( () => Unpacking.UnpackDictionaryCount( default( byte[] ) ) );
		}

		[Test]
		public void TestUnpackDictionaryCount_ByteArray_Offset_Null()
		{
			Assert.Throws<ArgumentNullException>( () => Unpacking.UnpackDictionaryCount( default( byte[] ), 0 ) );
		}

		[Test]
		public void TestUnpackDictionaryCount_ByteArray_Offset_OffsetIsNegative()
		{
			Assert.Throws<ArgumentOutOfRangeException>( () => Unpacking.UnpackDictionaryCount( new byte[]{ 0x1 }, -1 ) );
		}

		[Test]
		public void TestUnpackDictionaryCount_ByteArray_Offset_OffsetIsTooBig()
		{
			Assert.Throws<ArgumentException>( () => Unpacking.UnpackDictionaryCount( new byte[]{ 0x1 }, 1 ) );
		}

		[Test]
		public void TestUnpackDictionaryCount_ByteArray_Offset_Empty()
		{
			Assert.Throws<ArgumentException>( () => Unpacking.UnpackDictionaryCount( new byte[ 0 ], 0 ) );
		}

		[Test]
		public void TestUnpackDictionaryCount_Stream_Null()
		{
			Assert.Throws<ArgumentNullException>( () => Unpacking.UnpackDictionaryCount( default( Stream ) ) );
		}

		[Test]
		public void TestUnpackDictionaryCount_ByteArray_Offset_OffsetIsValid_OffsetIsRespected()
		{
			var result = Unpacking.UnpackDictionaryCount( new byte[] { 0xFF, 0x80, 0xFF }, 1 );
			Assert.That( result.ReadCount, Is.EqualTo( 1 ) );
			Assert.That( result.Value, Is.EqualTo( 0 ) );
		}

		[Test]
		public void TestUnpackDictionaryCount_ByteArray_Null_Nil()
		{
			var result = Unpacking.UnpackDictionaryCount( new byte[] { 0xC0 } );
			Assert.That( result.ReadCount, Is.EqualTo( 1 ) );
			Assert.That( result.Value, Is.Null );
		}
	
		[Test]
		public void TestUnpackDictionaryCount_ByteArray_NotMap()
		{
			Assert.Throws<MessageTypeException>( () => Unpacking.UnpackDictionaryCount( new byte[] { 0x1 } ) );
		}

		[Test]
		public void TestUnpackDictionary_ByteArray_Null_Nil()
		{
			var result = Unpacking.UnpackDictionary( new byte[] { 0xC0 } );
			Assert.That( result.ReadCount, Is.EqualTo( 1 ) );
			Assert.That( result.Value, Is.Null );
		}
	
		[Test]
		public void TestUnpackDictionary_ByteArray_NotMap()
		{
			Assert.Throws<MessageTypeException>( () => Unpacking.UnpackDictionary( new byte[] { 0x1 } ) );
		}

		private static IEnumerable<byte> CreateDictionaryBodyBinary( int count )
		{
			return 
				Enumerable.Range( 1, count )
				.SelectMany( i => 
					new byte[]{ 0xD2 } // Int32 header for key
					.Concat( BitConverter.GetBytes( i ).Reverse() ) // Key : i (Big-Endean)
					.Concat( new byte[] { 0x57 } ) // Value = 0x57
				);
		}

	}
}
