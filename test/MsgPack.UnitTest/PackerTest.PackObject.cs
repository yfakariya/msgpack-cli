#region -- License Terms --
//
// MessagePack for CLI
//
// Copyright (C) 2010-2017 FUJIWARA, Yusuke
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
using System.Threading.Tasks;
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
	// This file was generated from PackerTest.PackObject.tt and StreamingUnapkcerBase.ttinclude T4Template.
	// Do not modify this file. Edit PackerTest.PackObject.tt and StreamingUnapkcerBase.ttinclude instead.

	partial class PackerTest
	{
		[Test]
		public void TestPackObject_DoubleMinValue_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				packer.PackObject( Double.MinValue );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xCB }.Concat( BitConverter.GetBytes( Double.MinValue ).Reverse() ).ToArray() )
				);
			}
		}
		
		[Test]
		public void TestPackObject_SingleMinValue_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				packer.PackObject( Single.MinValue );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xCA }.Concat( BitConverter.GetBytes( Single.MinValue ).Reverse() ).ToArray() )
				);
			}
		}
		
		[Test]
		public void TestPackObject_Int64MinValue_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				packer.PackObject( Int64.MinValue );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xD3 }.Concat( BitConverter.GetBytes( Int64.MinValue ).Reverse() ).ToArray() )
				);
			}
		}
		
		[Test]
		public void TestPackObject_Int32MinValue_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				packer.PackObject( Int32.MinValue );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xD2 }.Concat( BitConverter.GetBytes( Int32.MinValue ).Reverse() ).ToArray() )
				);
			}
		}
		
		[Test]
		public void TestPackObject_Int16MinValue_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				packer.PackObject( Int16.MinValue );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xD1 }.Concat( BitConverter.GetBytes( Int16.MinValue ).Reverse() ).ToArray() )
				);
			}
		}
		
		[Test]
		public void TestPackObject_SByteMinValue_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				packer.PackObject( SByte.MinValue );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xD0, 0x80 } )
				);
			}
		}
		
		[Test]
		public void TestPackObject_DoubleMaxValue_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				packer.PackObject( Double.MaxValue );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xCB }.Concat( BitConverter.GetBytes( Double.MaxValue ).Reverse() ).ToArray() )
				);
			}
		}
		
		[Test]
		public void TestPackObject_SingleMaxValue_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				packer.PackObject( Single.MaxValue );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xCA }.Concat( BitConverter.GetBytes( Single.MaxValue ).Reverse() ).ToArray() )
				);
			}
		}
		
		[Test]
		public void TestPackObject_UInt64MaxValue_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				packer.PackObject( UInt64.MaxValue );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xCF }.Concat( BitConverter.GetBytes( UInt64.MaxValue ).Reverse() ).ToArray() )
				);
			}
		}
		
		[Test]
		public void TestPackObject_UInt32MaxValue_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				packer.PackObject( UInt32.MaxValue );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xCE }.Concat( BitConverter.GetBytes( UInt32.MaxValue ).Reverse() ).ToArray() )
				);
			}
		}
		
		[Test]
		public void TestPackObject_UInt16MaxValue_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				packer.PackObject( UInt16.MaxValue );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xCD }.Concat( BitConverter.GetBytes( UInt16.MaxValue ).Reverse() ).ToArray() )
				);
			}
		}
		
		[Test]
		public void TestPackObject_ByteMaxValue_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				packer.PackObject( Byte.MaxValue );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xCC, 0xFF } )
				);
			}
		}
		
		[Test]
		public void TestPackObject_NegativeFixNumMinValueMinusOne_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				packer.PackObject( ( ( sbyte )-33 ) );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xD0, unchecked( ( byte )( sbyte )-33 ) } )
				);
			}
		}
		
		[Test]
		public void TestPackObject_NegativeFixNumMinValue_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				packer.PackObject( ( -32 ) );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xE0 } )
				);
			}
		}
		
		[Test]
		public void TestPackObject_MinusOne_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				packer.PackObject( ( -1 ) );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xFF } )
				);
			}
		}
		
		[Test]
		public void TestPackObject_Zero_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				packer.PackObject( 0 );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0x00 } )
				);
			}
		}
		
		[Test]
		public void TestPackObject_PlusOne_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				packer.PackObject( ( 1 ) );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0x01 } )
				);
			}
		}
		
		[Test]
		public void TestPackObject_PositiveFixNumMaxValue_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				packer.PackObject( ( 127 ) );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0x7F } )
				);
			}
		}
		
		[Test]
		public void TestPackObject_PositiveFixNumMaxValuePlusOne_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				packer.PackObject( ( ( byte )128 ) );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xCC, 0x80 } )
				);
			}
		}
		
		[Test]
		public void TestPackObject_True_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				packer.PackObject( true );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xC3 } )
				);
			}
		}
		
		[Test]
		public void TestPackObject_False_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				packer.PackObject( false );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xC2 } )
				);
			}
		}
		
		[Test]
		public void TestPackObject_Nil_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				packer.PackObject( default( object ) );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xC0 } )
				);
			}
		}
		
		[Test]
		public void TestPackObject_SingleEpsilon_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				packer.PackObject( Single.Epsilon );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xCA }.Concat( BitConverter.GetBytes( Single.Epsilon ).Reverse() ).ToArray() )
				);
			}
		}
		
		[Test]
		public void TestPackObject_DoubleEpsilon_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				packer.PackObject( Double.Epsilon );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xCB }.Concat( BitConverter.GetBytes( Double.Epsilon ).Reverse() ).ToArray() )
				);
			}
		}
		
		[Test]
		public void TestPackObject_SinglePositiveInfinity_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				packer.PackObject( Single.PositiveInfinity );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xCA }.Concat( BitConverter.GetBytes( Single.PositiveInfinity ).Reverse() ).ToArray() )
				);
			}
		}
		
		[Test]
		public void TestPackObject_DoublePositiveInfinity_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				packer.PackObject( Double.PositiveInfinity );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xCB }.Concat( BitConverter.GetBytes( Double.PositiveInfinity ).Reverse() ).ToArray() )
				);
			}
		}
		
		[Test]
		public void TestPackObject_SingleNegativeInfinity_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				packer.PackObject( Single.NegativeInfinity );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xCA }.Concat( BitConverter.GetBytes( Single.NegativeInfinity ).Reverse() ).ToArray() )
				);
			}
		}
		
		[Test]
		public void TestPackObject_DoubleNegativeInfinity_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				packer.PackObject( Double.NegativeInfinity );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xCB }.Concat( BitConverter.GetBytes( Double.NegativeInfinity ).Reverse() ).ToArray() )
				);
			}
		}
		
		[Test]
		public void TestPackObject_NullableDouble_NotNull_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				packer.PackObject( Double.MinValue );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xCB }.Concat( BitConverter.GetBytes( Double.MinValue ).Reverse() ).ToArray() )
				);
			}
		}

		[Test]
		public void TestPackObject_NullableDouble_Null_AsNil()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				packer.PackObject( default( System.Double?  ) );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xC0 } )
				);
			}
		}
		
		[Test]
		public void TestPackObject_NullableSingle_NotNull_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				packer.PackObject( Single.MinValue );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xCA }.Concat( BitConverter.GetBytes( Single.MinValue ).Reverse() ).ToArray() )
				);
			}
		}

		[Test]
		public void TestPackObject_NullableSingle_Null_AsNil()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				packer.PackObject( default( System.Single?  ) );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xC0 } )
				);
			}
		}
		
		[Test]
		public void TestPackObject_NullableInt64_NotNull_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				packer.PackObject( Int64.MinValue );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xD3 }.Concat( BitConverter.GetBytes( Int64.MinValue ).Reverse() ).ToArray() )
				);
			}
		}

		[Test]
		public void TestPackObject_NullableInt64_Null_AsNil()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				packer.PackObject( default( System.Int64?  ) );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xC0 } )
				);
			}
		}
		
		[Test]
		public void TestPackObject_NullableInt32_NotNull_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				packer.PackObject( Int32.MinValue );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xD2 }.Concat( BitConverter.GetBytes( Int32.MinValue ).Reverse() ).ToArray() )
				);
			}
		}

		[Test]
		public void TestPackObject_NullableInt32_Null_AsNil()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				packer.PackObject( default( System.Int32?  ) );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xC0 } )
				);
			}
		}
		
		[Test]
		public void TestPackObject_NullableInt16_NotNull_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				packer.PackObject( Int16.MinValue );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xD1 }.Concat( BitConverter.GetBytes( Int16.MinValue ).Reverse() ).ToArray() )
				);
			}
		}

		[Test]
		public void TestPackObject_NullableInt16_Null_AsNil()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				packer.PackObject( default( System.Int16?  ) );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xC0 } )
				);
			}
		}
		
		[Test]
		public void TestPackObject_NullableSByte_NotNull_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				packer.PackObject( SByte.MinValue );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xD0, 0x80 } )
				);
			}
		}

		[Test]
		public void TestPackObject_NullableSByte_Null_AsNil()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				packer.PackObject( default( System.SByte?  ) );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xC0 } )
				);
			}
		}
		
		[Test]
		public void TestPackObject_NullableUInt64_NotNull_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				packer.PackObject( UInt64.MaxValue );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xCF }.Concat( BitConverter.GetBytes( UInt64.MaxValue ).Reverse() ).ToArray() )
				);
			}
		}

		[Test]
		public void TestPackObject_NullableUInt64_Null_AsNil()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				packer.PackObject( default( System.UInt64?  ) );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xC0 } )
				);
			}
		}
		
		[Test]
		public void TestPackObject_NullableUInt32_NotNull_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				packer.PackObject( UInt32.MaxValue );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xCE }.Concat( BitConverter.GetBytes( UInt32.MaxValue ).Reverse() ).ToArray() )
				);
			}
		}

		[Test]
		public void TestPackObject_NullableUInt32_Null_AsNil()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				packer.PackObject( default( System.UInt32?  ) );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xC0 } )
				);
			}
		}
		
		[Test]
		public void TestPackObject_NullableUInt16_NotNull_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				packer.PackObject( UInt16.MaxValue );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xCD }.Concat( BitConverter.GetBytes( UInt16.MaxValue ).Reverse() ).ToArray() )
				);
			}
		}

		[Test]
		public void TestPackObject_NullableUInt16_Null_AsNil()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				packer.PackObject( default( System.UInt16?  ) );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xC0 } )
				);
			}
		}
		
		[Test]
		public void TestPackObject_NullableByte_NotNull_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				packer.PackObject( Byte.MaxValue );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xCC, 0xFF } )
				);
			}
		}

		[Test]
		public void TestPackObject_NullableByte_Null_AsNil()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				packer.PackObject( default( System.Byte?  ) );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xC0 } )
				);
			}
		}
		
		[Test]
		public void TestPackObject_NullableBoolean_NotNull_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				packer.PackObject( true );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xC3 } )
				);
			}
		}

		[Test]
		public void TestPackObject_NullableBoolean_Null_AsNil()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				packer.PackObject( default( System.Boolean?  ) );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xC0 } )
				);
			}
		}
		

		[Test]
		public void TestPackObject_StringNotNull_AsIs()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				packer.PackObject( "ABC" );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xA3 }.Concat( new byte[] { ( byte )'A', ( byte )'B', ( byte )'C' } ).ToArray() )
				);
			}
		}

		[Test]
		public void TestPackObject_ByteArrayNotNull_AsIs()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				packer.PackObject( new byte[] { 1, 2, 3 } );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xA3, 1, 2, 3 } )
				);
			}
		}

		[Test]
		public void TestPackObject_ObjectNull_AsNil()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				packer.PackObject( default( object ) );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xC0 } )
				);
			}
		}

#if FEATURE_TAP

		[Test]
		public async Task TestPackObjectAsync_DoubleMinValue_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				await packer.PackObjectAsync( Double.MinValue );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xCB }.Concat( BitConverter.GetBytes( Double.MinValue ).Reverse() ).ToArray() )
				);
			}
		}
		
		[Test]
		public async Task TestPackObjectAsync_SingleMinValue_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				await packer.PackObjectAsync( Single.MinValue );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xCA }.Concat( BitConverter.GetBytes( Single.MinValue ).Reverse() ).ToArray() )
				);
			}
		}
		
		[Test]
		public async Task TestPackObjectAsync_Int64MinValue_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				await packer.PackObjectAsync( Int64.MinValue );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xD3 }.Concat( BitConverter.GetBytes( Int64.MinValue ).Reverse() ).ToArray() )
				);
			}
		}
		
		[Test]
		public async Task TestPackObjectAsync_Int32MinValue_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				await packer.PackObjectAsync( Int32.MinValue );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xD2 }.Concat( BitConverter.GetBytes( Int32.MinValue ).Reverse() ).ToArray() )
				);
			}
		}
		
		[Test]
		public async Task TestPackObjectAsync_Int16MinValue_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				await packer.PackObjectAsync( Int16.MinValue );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xD1 }.Concat( BitConverter.GetBytes( Int16.MinValue ).Reverse() ).ToArray() )
				);
			}
		}
		
		[Test]
		public async Task TestPackObjectAsync_SByteMinValue_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				await packer.PackObjectAsync( SByte.MinValue );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xD0, 0x80 } )
				);
			}
		}
		
		[Test]
		public async Task TestPackObjectAsync_DoubleMaxValue_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				await packer.PackObjectAsync( Double.MaxValue );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xCB }.Concat( BitConverter.GetBytes( Double.MaxValue ).Reverse() ).ToArray() )
				);
			}
		}
		
		[Test]
		public async Task TestPackObjectAsync_SingleMaxValue_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				await packer.PackObjectAsync( Single.MaxValue );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xCA }.Concat( BitConverter.GetBytes( Single.MaxValue ).Reverse() ).ToArray() )
				);
			}
		}
		
		[Test]
		public async Task TestPackObjectAsync_UInt64MaxValue_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				await packer.PackObjectAsync( UInt64.MaxValue );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xCF }.Concat( BitConverter.GetBytes( UInt64.MaxValue ).Reverse() ).ToArray() )
				);
			}
		}
		
		[Test]
		public async Task TestPackObjectAsync_UInt32MaxValue_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				await packer.PackObjectAsync( UInt32.MaxValue );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xCE }.Concat( BitConverter.GetBytes( UInt32.MaxValue ).Reverse() ).ToArray() )
				);
			}
		}
		
		[Test]
		public async Task TestPackObjectAsync_UInt16MaxValue_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				await packer.PackObjectAsync( UInt16.MaxValue );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xCD }.Concat( BitConverter.GetBytes( UInt16.MaxValue ).Reverse() ).ToArray() )
				);
			}
		}
		
		[Test]
		public async Task TestPackObjectAsync_ByteMaxValue_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				await packer.PackObjectAsync( Byte.MaxValue );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xCC, 0xFF } )
				);
			}
		}
		
		[Test]
		public async Task TestPackObjectAsync_NegativeFixNumMinValueMinusOne_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				await packer.PackObjectAsync( ( ( sbyte )-33 ) );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xD0, unchecked( ( byte )( sbyte )-33 ) } )
				);
			}
		}
		
		[Test]
		public async Task TestPackObjectAsync_NegativeFixNumMinValue_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				await packer.PackObjectAsync( ( -32 ) );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xE0 } )
				);
			}
		}
		
		[Test]
		public async Task TestPackObjectAsync_MinusOne_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				await packer.PackObjectAsync( ( -1 ) );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xFF } )
				);
			}
		}
		
		[Test]
		public async Task TestPackObjectAsync_Zero_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				await packer.PackObjectAsync( 0 );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0x00 } )
				);
			}
		}
		
		[Test]
		public async Task TestPackObjectAsync_PlusOne_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				await packer.PackObjectAsync( ( 1 ) );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0x01 } )
				);
			}
		}
		
		[Test]
		public async Task TestPackObjectAsync_PositiveFixNumMaxValue_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				await packer.PackObjectAsync( ( 127 ) );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0x7F } )
				);
			}
		}
		
		[Test]
		public async Task TestPackObjectAsync_PositiveFixNumMaxValuePlusOne_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				await packer.PackObjectAsync( ( ( byte )128 ) );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xCC, 0x80 } )
				);
			}
		}
		
		[Test]
		public async Task TestPackObjectAsync_True_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				await packer.PackObjectAsync( true );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xC3 } )
				);
			}
		}
		
		[Test]
		public async Task TestPackObjectAsync_False_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				await packer.PackObjectAsync( false );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xC2 } )
				);
			}
		}
		
		[Test]
		public async Task TestPackObjectAsync_Nil_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				await packer.PackObjectAsync( default( object ) );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xC0 } )
				);
			}
		}
		
		[Test]
		public async Task TestPackObjectAsync_SingleEpsilon_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				await packer.PackObjectAsync( Single.Epsilon );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xCA }.Concat( BitConverter.GetBytes( Single.Epsilon ).Reverse() ).ToArray() )
				);
			}
		}
		
		[Test]
		public async Task TestPackObjectAsync_DoubleEpsilon_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				await packer.PackObjectAsync( Double.Epsilon );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xCB }.Concat( BitConverter.GetBytes( Double.Epsilon ).Reverse() ).ToArray() )
				);
			}
		}
		
		[Test]
		public async Task TestPackObjectAsync_SinglePositiveInfinity_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				await packer.PackObjectAsync( Single.PositiveInfinity );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xCA }.Concat( BitConverter.GetBytes( Single.PositiveInfinity ).Reverse() ).ToArray() )
				);
			}
		}
		
		[Test]
		public async Task TestPackObjectAsync_DoublePositiveInfinity_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				await packer.PackObjectAsync( Double.PositiveInfinity );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xCB }.Concat( BitConverter.GetBytes( Double.PositiveInfinity ).Reverse() ).ToArray() )
				);
			}
		}
		
		[Test]
		public async Task TestPackObjectAsync_SingleNegativeInfinity_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				await packer.PackObjectAsync( Single.NegativeInfinity );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xCA }.Concat( BitConverter.GetBytes( Single.NegativeInfinity ).Reverse() ).ToArray() )
				);
			}
		}
		
		[Test]
		public async Task TestPackObjectAsync_DoubleNegativeInfinity_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				await packer.PackObjectAsync( Double.NegativeInfinity );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xCB }.Concat( BitConverter.GetBytes( Double.NegativeInfinity ).Reverse() ).ToArray() )
				);
			}
		}
		
		[Test]
		public async Task TestPackObjectAsync_NullableDouble_NotNull_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				await packer.PackObjectAsync( Double.MinValue );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xCB }.Concat( BitConverter.GetBytes( Double.MinValue ).Reverse() ).ToArray() )
				);
			}
		}

		[Test]
		public async Task TestPackObjectAsync_NullableDouble_Null_AsNil()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				await packer.PackObjectAsync( default( System.Double?  ) );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xC0 } )
				);
			}
		}
		
		[Test]
		public async Task TestPackObjectAsync_NullableSingle_NotNull_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				await packer.PackObjectAsync( Single.MinValue );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xCA }.Concat( BitConverter.GetBytes( Single.MinValue ).Reverse() ).ToArray() )
				);
			}
		}

		[Test]
		public async Task TestPackObjectAsync_NullableSingle_Null_AsNil()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				await packer.PackObjectAsync( default( System.Single?  ) );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xC0 } )
				);
			}
		}
		
		[Test]
		public async Task TestPackObjectAsync_NullableInt64_NotNull_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				await packer.PackObjectAsync( Int64.MinValue );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xD3 }.Concat( BitConverter.GetBytes( Int64.MinValue ).Reverse() ).ToArray() )
				);
			}
		}

		[Test]
		public async Task TestPackObjectAsync_NullableInt64_Null_AsNil()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				await packer.PackObjectAsync( default( System.Int64?  ) );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xC0 } )
				);
			}
		}
		
		[Test]
		public async Task TestPackObjectAsync_NullableInt32_NotNull_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				await packer.PackObjectAsync( Int32.MinValue );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xD2 }.Concat( BitConverter.GetBytes( Int32.MinValue ).Reverse() ).ToArray() )
				);
			}
		}

		[Test]
		public async Task TestPackObjectAsync_NullableInt32_Null_AsNil()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				await packer.PackObjectAsync( default( System.Int32?  ) );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xC0 } )
				);
			}
		}
		
		[Test]
		public async Task TestPackObjectAsync_NullableInt16_NotNull_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				await packer.PackObjectAsync( Int16.MinValue );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xD1 }.Concat( BitConverter.GetBytes( Int16.MinValue ).Reverse() ).ToArray() )
				);
			}
		}

		[Test]
		public async Task TestPackObjectAsync_NullableInt16_Null_AsNil()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				await packer.PackObjectAsync( default( System.Int16?  ) );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xC0 } )
				);
			}
		}
		
		[Test]
		public async Task TestPackObjectAsync_NullableSByte_NotNull_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				await packer.PackObjectAsync( SByte.MinValue );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xD0, 0x80 } )
				);
			}
		}

		[Test]
		public async Task TestPackObjectAsync_NullableSByte_Null_AsNil()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				await packer.PackObjectAsync( default( System.SByte?  ) );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xC0 } )
				);
			}
		}
		
		[Test]
		public async Task TestPackObjectAsync_NullableUInt64_NotNull_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				await packer.PackObjectAsync( UInt64.MaxValue );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xCF }.Concat( BitConverter.GetBytes( UInt64.MaxValue ).Reverse() ).ToArray() )
				);
			}
		}

		[Test]
		public async Task TestPackObjectAsync_NullableUInt64_Null_AsNil()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				await packer.PackObjectAsync( default( System.UInt64?  ) );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xC0 } )
				);
			}
		}
		
		[Test]
		public async Task TestPackObjectAsync_NullableUInt32_NotNull_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				await packer.PackObjectAsync( UInt32.MaxValue );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xCE }.Concat( BitConverter.GetBytes( UInt32.MaxValue ).Reverse() ).ToArray() )
				);
			}
		}

		[Test]
		public async Task TestPackObjectAsync_NullableUInt32_Null_AsNil()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				await packer.PackObjectAsync( default( System.UInt32?  ) );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xC0 } )
				);
			}
		}
		
		[Test]
		public async Task TestPackObjectAsync_NullableUInt16_NotNull_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				await packer.PackObjectAsync( UInt16.MaxValue );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xCD }.Concat( BitConverter.GetBytes( UInt16.MaxValue ).Reverse() ).ToArray() )
				);
			}
		}

		[Test]
		public async Task TestPackObjectAsync_NullableUInt16_Null_AsNil()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				await packer.PackObjectAsync( default( System.UInt16?  ) );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xC0 } )
				);
			}
		}
		
		[Test]
		public async Task TestPackObjectAsync_NullableByte_NotNull_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				await packer.PackObjectAsync( Byte.MaxValue );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xCC, 0xFF } )
				);
			}
		}

		[Test]
		public async Task TestPackObjectAsync_NullableByte_Null_AsNil()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				await packer.PackObjectAsync( default( System.Byte?  ) );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xC0 } )
				);
			}
		}
		
		[Test]
		public async Task TestPackObjectAsync_NullableBoolean_NotNull_AsValue()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				await packer.PackObjectAsync( true );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xC3 } )
				);
			}
		}

		[Test]
		public async Task TestPackObjectAsync_NullableBoolean_Null_AsNil()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				await packer.PackObjectAsync( default( System.Boolean?  ) );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xC0 } )
				);
			}
		}
		

		[Test]
		public async Task TestPackObjectAsync_StringNotNull_AsIs()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				await packer.PackObjectAsync( "ABC" );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xA3 }.Concat( new byte[] { ( byte )'A', ( byte )'B', ( byte )'C' } ).ToArray() )
				);
			}
		}

		[Test]
		public async Task TestPackObjectAsync_ByteArrayNotNull_AsIs()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				await packer.PackObjectAsync( new byte[] { 1, 2, 3 } );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xA3, 1, 2, 3 } )
				);
			}
		}

		[Test]
		public async Task TestPackObjectAsync_ObjectNull_AsNil()
		{
			using( var buffer = new MemoryStream() )
			using( var packer = CreatePacker( buffer ) )
			{
				await packer.PackObjectAsync( default( object ) );
				Assert.That(
					this.GetResult( packer ),
					Is.EqualTo( new byte[] { 0xC0 } )
				);
			}
		}

#endif // FEATURE_TAP

	}
}
