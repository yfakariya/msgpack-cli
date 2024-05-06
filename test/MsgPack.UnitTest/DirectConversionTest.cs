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
#if NET35
using Debug = System.Console; // For missing Debug.WriteLine(String, params Object[])
#endif // NET35
using System.IO;
using System.Text;
#if !MSTEST
using NUnit.Framework;
#else
using TestFixtureAttribute = Microsoft.VisualStudio.TestPlatform.UnitTestFramework.TestClassAttribute;
using TestAttribute = Microsoft.VisualStudio.TestPlatform.UnitTestFramework.TestMethodAttribute;
using TimeoutAttribute = NUnit.Framework.TimeoutAttribute;
using Assert = NUnit.Framework.Assert;
using Is = NUnit.Framework.Is;
using ExplicitAttribute = Microsoft.VisualStudio.TestPlatform.UnitTestFramework.IgnoreAttribute;
#endif

namespace MsgPack
{
	[TestFixture]
#if NETFRAMEWORK
	[Timeout( 5000 )]
#else // NETFRAMEWORK
	[CancelAfter( 5000 )]
#endif // NETFRAMEWORK
	public partial class DirectConversionTest
	{
#if MSTEST
		public Microsoft.VisualStudio.TestPlatform.UnitTestFramework.TestContext TestContext
		{
			get;
			set;
		}

		private System.IO.TextWriter Console
		{
			get
			{
#if !SILVERLIGHT && !NETFX_CORE
				return System.Console.Out;
#else
				return System.IO.TextWriter.Null;
#endif
			}
		}
#endif

		[Test]
		public void TestNil()
		{
			var output = new MemoryStream();
			Packer.Create( output ).PackNull();
			Assert.That( Unpacking.UnpackNull( new MemoryStream( output.ToArray() ) ), Is.Null );
			Assert.That( Unpacking.UnpackNull( output.ToArray() ).Value, Is.Null );
		}

		[Test]
		public void TestBoolean()
		{
			TestBoolean( false );
			TestBoolean( true );
		}

		private static void TestBoolean( bool value )
		{
			var output = new MemoryStream();
			Packer.Create( output ).Pack( value );
			Assert.That( Unpacking.UnpackBoolean( new MemoryStream( output.ToArray() ) ), Is.EqualTo( value ) );
			Assert.That( Unpacking.UnpackBoolean( output.ToArray() ).Value, Is.EqualTo( value ) );
		}

#if !SILVERLIGHT
		[Test]
		[Explicit] // FIXME : split
		public void TestString()
		{
			TestString( "" );
			TestString( "a" );
			TestString( "ab" );
			TestString( "abc" );
			TestString( "\ud9c9\udd31" );
			TestString( "\u30e1\u30c3\u30bb\u30fc\u30b8\u30d1\u30c3\u30af" );

			var sw = Stopwatch.StartNew();
			var avg = 0.0;
			Random random = new Random();
#if !SKIP_LARGE_TEST && !NET35
			var sb = new StringBuilder( 1000 * 1000 * 200 );
#else
			var sb = new StringBuilder( 1000 * 200 );
#endif
			// small size string
			for ( int i = 0; i < 100; i++ )
			{
				sb.Length = 0;
				int len = ( int )random.Next() % 31 + 1;
				for ( int j = 0; j < len; j++ )
				{
					sb.Append( 'a' + ( ( int )random.Next() ) & 26 );
				}
				avg = ( avg + sb.Length ) / 2.0;
				TestString( sb.ToString() );
			}
			sw.Stop();
			Debug.WriteLine( "Small String ({1:#.0}): {0:0.###} msec/object", sw.ElapsedMilliseconds / 100.0, avg );
			sw.Reset();
			sw.Start();

			avg = 0.0;
			// medium size string
			for ( int i = 0; i < 100; i++ )
			{
				sb.Length = 0;
				int len = ( int )random.Next() % 100 + ( 1 << 15 );
				for ( int j = 0; j < len; j++ )
				{
					sb.Append( 'a' + ( ( int )random.Next() ) & 26 );
				}
				avg = ( avg + sb.Length ) / 2.0;
				TestString( sb.ToString() );
			}
			sw.Stop();
			Debug.WriteLine( "Medium String ({1:#.0}): {0:0.###} msec/object", sw.ElapsedMilliseconds / 100.0, avg );
			sw.Reset();
#if !SKIP_LARGE_TEST && !NET35
			sw.Start();

			avg = 0.0;
			// large size string
			for ( int i = 0; i < 10; i++ )
			{
				sb.Length = 0;
				int len = ( int )random.Next() % 100 + ( 1 << 24 );
				for ( int j = 0; j < len; j++ )
				{
					sb.Append( 'a' + ( ( int )random.Next() ) & 26 );
				}
				avg = ( avg + sb.Length ) / 2.0;
				TestString( sb.ToString() );
			}
			sw.Stop();
			Debug.WriteLine( "Large String ({1:#.0}): {0:0.###} msec/object", sw.ElapsedMilliseconds / 10.0, avg );
			sw.Reset();
#endif

			// Non-ASCII
			avg = 0.0;
			// medium size string
			for ( int i = 0; i < 100; i++ )
			{
				sb.Length = 0;
				int len = ( int )random.Next() % 100 + ( 1 << 8 );
				for ( int j = 0; j < len; j++ )
				{
					var cp = random.Next( 0x10ffff );
					if ( 0xd800 <= cp && cp <= 0xdfff )
					{
						cp /= 2;
					}

					sb.Append( Char.ConvertFromUtf32( cp ) );
				}
				avg = ( avg + sb.Length ) / 2.0;
				TestString( sb.ToString() );
			}
			sw.Stop();
			Debug.WriteLine( "Medium String ({1:#.0}): {0:0.###} msec/object", sw.ElapsedMilliseconds / 100.0, avg );
		}

		private static void TestString( String value )
		{
			var output = new MemoryStream();
			Packer.Create( output ).PackString( value );
			Assert.That( Unpacking.UnpackString( new MemoryStream( output.ToArray() ) ), Is.EqualTo( value ) );
			Assert.That( Unpacking.UnpackString( output.ToArray() ).Value, Is.EqualTo( value ) );
		}
#endif // !SILVERLIGHT

		[Test]
#if NETFRAMEWORK
		[Timeout( 30000 )]
#else // NETFRAMEWORK
		[CancelAfter( 30000 )]
#endif // NETFRAMEWORK
		public void TestArray()
		{
			var emptyList = new List<int>();
			{
				var output = new MemoryStream();
				Packer.Create( output ).PackCollection( emptyList );
				Assert.That( Unpacking.UnpackArrayLength( new MemoryStream( output.ToArray() ) ), Is.EqualTo( 0 ) );
				Assert.That( Unpacking.UnpackArrayLength( output.ToArray() ).Value, Is.EqualTo( 0 ) );
			}

			var random = new Random();

			for ( int i = 0; i < 100; i++ )
			{
				var l = new List<int>();
				int len = ( int )random.Next() % 1000 + 1;
				for ( int j = 0; j < len; j++ )
				{
					l.Add( j );
				}
				var output = new MemoryStream();
				Packer.Create( output ).PackCollection( l );

				Stream streamInput = new MemoryStream( output.ToArray() );
				Assert.That( Unpacking.UnpackArrayLength( streamInput ), Is.EqualTo( len ) );
				for ( int j = 0; j < len; j++ )
				{
					Assert.That( Unpacking.UnpackInt32( streamInput ), Is.EqualTo( l[ j ] ) );
				}

				byte[] byteArrayInput = output.ToArray();
				var arrayLength = Unpacking.UnpackArrayLength( byteArrayInput );
				Assert.That( arrayLength.Value, Is.EqualTo( len ) );
				int offset = arrayLength.ReadCount;
				for ( int j = 0; j < len; j++ )
				{
					var uar = Unpacking.UnpackInt32( byteArrayInput, offset );
					Assert.That( uar.ReadCount, Is.Not.EqualTo( 0 ) );
					Assert.That( uar.Value, Is.EqualTo( l[ j ] ) );
					offset += uar.ReadCount;
				}
			}

			for ( int i = 0; i < 100; i++ )
			{
				var l = new List<String>();
				int len = ( int )random.Next() % 1000 + 1;
				for ( int j = 0; j < len; j++ )
				{
					l.Add( j.ToString() );
				}
				var output = new MemoryStream();
				Packer.Create( output ).PackCollection( l );

				Stream streamInput = new MemoryStream( output.ToArray() );
				Assert.That( Unpacking.UnpackArrayLength( streamInput ), Is.EqualTo( len ) );
				for ( int j = 0; j < len; j++ )
				{
					Assert.That( Unpacking.UnpackString( streamInput ), Is.EqualTo( l[ j ] ) );
				}

				byte[] byteArrayInput = output.ToArray();
				var arrayLength = Unpacking.UnpackArrayLength( byteArrayInput );
				Assert.That( arrayLength.Value, Is.EqualTo( len ) );
				int offset = arrayLength.ReadCount;
				for ( int j = 0; j < len; j++ )
				{
					var usr = Unpacking.UnpackString( byteArrayInput, offset );
					Assert.That( usr.Value, Is.EqualTo( l[ j ] ) );
					offset += usr.ReadCount;
				}
			}
		}

		[Test]
#if NETFRAMEWORK
		[Timeout( 30000 )]
#else // NETFRAMEWORK
		[CancelAfter( 30000 )]
#endif // NETFRAMEWORK
		public void TestMap()
		{
			var emptyMap = new Dictionary<int, int>();
			{
				var output = new MemoryStream();
				Packer.Create( output ).PackDictionary( emptyMap );
				Assert.That( Unpacking.UnpackDictionaryCount( new MemoryStream( output.ToArray() ) ), Is.EqualTo( 0 ) );
				Assert.That( Unpacking.UnpackDictionaryCount( output.ToArray() ).Value, Is.EqualTo( 0 ) );
			}

			var random = new Random();

			for ( int i = 0; i < 100; i++ )
			{
				var m = new Dictionary<int, int>();
				int len = ( int )random.Next() % 1000 + 1;
				for ( int j = 0; j < len; j++ )
				{
					m[ j ] = j;
				}
				var output = new MemoryStream();
				Packer.Create( output ).PackDictionary( m );

				Stream streamInput = new MemoryStream( output.ToArray() );
				Assert.That( Unpacking.UnpackDictionaryCount( streamInput ), Is.EqualTo( len ) );
				for ( int j = 0; j < len; j++ )
				{
					int value;
					Assert.That( m.TryGetValue( Unpacking.UnpackInt32( streamInput ), out value ), Is.True );
					Assert.That( Unpacking.UnpackInt32( streamInput ), Is.EqualTo( value ) );
				}

				byte[] byteArrayInput = output.ToArray();
				var arrayLength = Unpacking.UnpackDictionaryCount( byteArrayInput );
				Assert.That( arrayLength.Value, Is.EqualTo( len ) );
				int offset = arrayLength.ReadCount;
				for ( int j = 0; j < len; j++ )
				{
					var keyUar = Unpacking.UnpackInt32( byteArrayInput, offset );
					Assert.That( keyUar.ReadCount, Is.Not.EqualTo( 0 ) );
					int value;
					Assert.That( m.TryGetValue( keyUar.Value, out value ), Is.True );
					var valueUar = Unpacking.UnpackInt32( byteArrayInput, offset + keyUar.ReadCount );
					Assert.That( valueUar.Value, Is.EqualTo( value ) );
					offset += keyUar.ReadCount + valueUar.ReadCount;
				}
			}

			for ( int i = 0; i < 100; i++ )
			{
				var m = new Dictionary<string, int>();
				int len = ( int )random.Next() % 1000 + 1;
				for ( int j = 0; j < len; j++ )
				{
					m[ j.ToString() ] = j;
				}
				var output = new MemoryStream();
				Packer.Create( output ).PackDictionary( m );

				Stream streamInput = new MemoryStream( output.ToArray() );
				Assert.That( Unpacking.UnpackDictionaryCount( streamInput ), Is.EqualTo( len ) );
				for ( int j = 0; j < len; j++ )
				{
					int value;
					Assert.That( m.TryGetValue( Unpacking.UnpackString( streamInput ), out value ), Is.True );
					Assert.That( Unpacking.UnpackInt32( streamInput ), Is.EqualTo( value ) );
				}

				byte[] byteArrayInput = output.ToArray();
				var arrayLength = Unpacking.UnpackDictionaryCount( byteArrayInput );
				Assert.That( arrayLength.Value, Is.EqualTo( len ) );
				int offset = arrayLength.ReadCount;
				for ( int j = 0; j < len; j++ )
				{
					var usr = Unpacking.UnpackString( byteArrayInput, offset );
					Assert.That( usr.ReadCount, Is.Not.EqualTo( 0 ) );
					int value;
					Assert.That( m.TryGetValue( usr.Value, out value ), Is.True );
					var uar = Unpacking.UnpackInt32( byteArrayInput, offset + usr.ReadCount );
					Assert.That( uar.Value, Is.EqualTo( value ) );
					offset += usr.ReadCount + uar.ReadCount;
				}
			}
		}
	}
}
