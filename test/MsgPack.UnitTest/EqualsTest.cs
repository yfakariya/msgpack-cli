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
	public class EqualsTest
	{
		[Test]
		public void TestInt()
		{
			TestInt( 0 );
			TestInt( -1 );
			TestInt( 1 );
			TestInt( Int32.MinValue );
			TestInt( Int32.MaxValue );
			Random rand = new Random();
			for ( int i = 0; i < 1000; i++ )
			{
				TestInt( rand.Next() );
			}
		}

		private static void TestInt( int val )
		{
			MessagePackObject objInt = val;
			MessagePackObject objLong = ( long )val;
#pragma warning disable 1718
			Assert.That( objInt == objInt, Is.True );
#pragma warning restore 1718
			Assert.That( objInt == objLong, Is.True );
			Assert.That( objLong == objInt, Is.True );
#pragma warning disable 1718
			Assert.That( objLong == objLong, Is.True );
#pragma warning restore 1718
		}

		[Test]
		public void TestLong()
		{
			TestLong( 0 );
			TestLong( -1 );
			TestLong( 1 );
			TestLong( Int32.MinValue );
			TestLong( Int32.MaxValue );
			TestLong( Int64.MinValue );
			TestLong( Int64.MaxValue );
			Random rand = new Random();
			var buffer = new byte[ sizeof( long ) ];
			for ( int i = 0; i < 1000; i++ )
			{
				rand.NextBytes( buffer );
				TestLong( BitConverter.ToInt64( buffer, 0 ) );
			}
		}

		private static void TestLong( long val )
		{
			MessagePackObject objInt = unchecked(( int )( val & 0xffffffff ));
			MessagePackObject objLong = val;
			if ( val > ( long )Int32.MaxValue || val < ( long )Int32.MinValue )
			{
#pragma warning disable 1718
				Assert.That( objInt == objInt, Is.True );
#pragma warning restore 1718
				Assert.That( objInt == objLong, Is.False );
				Assert.That( objLong == objInt, Is.False );
#pragma warning disable 1718
				Assert.That( objLong == objLong, Is.True );
#pragma warning restore 1718
			}
			else
			{
#pragma warning disable 1718
				Assert.That( objInt == objInt, Is.True );
#pragma warning restore 1718
				Assert.That( objInt == objLong, Is.True );
				Assert.That( objLong == objInt, Is.True );
#pragma warning disable 1718
				Assert.That( objLong == objLong, Is.True );
#pragma warning restore 1718
			}
		}

		[Test]
		public void TestNil()
		{
#pragma warning disable 1718
			Assert.That( MessagePackObject.Nil == MessagePackObject.Nil, Is.True );
#pragma warning restore 1718
			Assert.That( MessagePackObject.Nil == default( MessagePackObject ), Is.True );
			Assert.That( MessagePackObject.Nil == 0, Is.False );
			Assert.That( MessagePackObject.Nil == false, Is.False );
		}

		[Test]
		public void TestString()
		{
			TestString( "" );
			TestString( "a" );
			TestString( "ab" );
			TestString( "abc" );
		}

		private static void TestString( String str )
		{
			Assert.That( new MessagePackObject( Encoding.UTF8.GetBytes( str ) ) == Encoding.UTF8.GetBytes( str ), Is.True );
		}
	}
}
