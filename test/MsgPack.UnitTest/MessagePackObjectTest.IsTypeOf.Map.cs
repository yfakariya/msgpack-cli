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
	partial class MessagePackObjectTest_IsTypeOf
	{
		[Test]
		public void TestIsTypeOf_DictionaryNotNull_IsTypeOfArrayOfNotItemType_False()
		{
			Assert.That( new MessagePackObject( new MessagePackObjectDictionary() { { "1", 1 } } ).IsTypeOf( typeof( KeyValuePair<string, bool>[] ) ), Is.False );
		}

		[Test]
		public void TestIsTypeOf_DictionaryNotNull_IsTypeOfArrayOfMessagePackObject_False()
		{
			Assert.That( new MessagePackObject( new MessagePackObjectDictionary() { { "1", 1 } } ).IsTypeOf( typeof( KeyValuePair<MessagePackObject, MessagePackObject>[] ) ), Is.False );
		}

		[Test]
		public void TestIsTypeOf_DictionaryNotNull_IsTypeOfArrayOfItemType_False()
		{
			Assert.That( new MessagePackObject(  new MessagePackObjectDictionary() { { "1", 1 } } ).IsTypeOf( typeof( KeyValuePair<string, int>[] ) ), Is.False );
		}

		[Test]
		public void TestIsTypeOf_DictionaryNotNull_IsTypeOfIEnumerableOfMessagePackObject_True()
		{
			Assert.That( new MessagePackObject(  new MessagePackObjectDictionary() { { "1", 1 } } ).IsTypeOf( typeof( IEnumerable<KeyValuePair<MessagePackObject, MessagePackObject>> ) ), Is.True );
		}

		[Test]
		public void TestIsTypeOf_DictionaryNotNull_IsTypeOfIListOfMessagePackObject_False()
		{
			Assert.That( new MessagePackObject(  new MessagePackObjectDictionary() { { "1", 1 } } ).IsTypeOf( typeof( IList<KeyValuePair<MessagePackObject, MessagePackObject>> ) ), Is.False );
		}

		[Test]
		public void TestIsTypeOf_DictionaryNotNull_IsTypeOfListOfMessagePackObject_False()
		{
			Assert.That( new MessagePackObject(  new MessagePackObjectDictionary() { { "1", 1 } } ).IsTypeOf( typeof( List<KeyValuePair<MessagePackObject, MessagePackObject>> ) ), Is.False );
		}

		[Test]
		public void TestIsTypeOf_DictionaryNotNull_IsTypeOfIDictionaryOfMessagePackObject_True()
		{
			Assert.That( new MessagePackObject(  new MessagePackObjectDictionary() { { "1", 1 } } ).IsTypeOf( typeof( IDictionary<MessagePackObject, MessagePackObject> ) ), Is.True );
		}

		[Test]
		public void TestIsTypeOf_DictionaryNotNull_IsTypeOfMessagePackObjectDictionary_True()
		{
			Assert.That( new MessagePackObject(  new MessagePackObjectDictionary() { { "1", 1 } } ).IsTypeOf( typeof( MessagePackObjectDictionary ) ), Is.True );
		}
		
		[Test]
		public void TestIsMap_DictionaryNotNull_True()
		{
			Assert.That( new MessagePackObject(  new MessagePackObjectDictionary() { { "1", 1 } } ).IsMap, Is.True );
		}
		[Test]
		public void TestIsTypeOf_DictionaryEmptyNotNull_IsTypeOfArrayOfNotItemType_False()
		{
			Assert.That( new MessagePackObject( new MessagePackObjectDictionary() ).IsTypeOf( typeof( KeyValuePair<string, bool>[] ) ), Is.False );
		}

		[Test]
		public void TestIsTypeOf_DictionaryEmptyNotNull_IsTypeOfArrayOfMessagePackObject_False()
		{
			Assert.That( new MessagePackObject( new MessagePackObjectDictionary() ).IsTypeOf( typeof( KeyValuePair<MessagePackObject, MessagePackObject>[] ) ), Is.False );
		}

		[Test]
		public void TestIsTypeOf_DictionaryEmptyNotNull_IsTypeOfArrayOfItemType_False()
		{
			Assert.That( new MessagePackObject(  new MessagePackObjectDictionary() ).IsTypeOf( typeof( KeyValuePair<string, int>[] ) ), Is.False );
		}

		[Test]
		public void TestIsTypeOf_DictionaryEmptyNotNull_IsTypeOfIEnumerableOfMessagePackObject_True()
		{
			Assert.That( new MessagePackObject(  new MessagePackObjectDictionary() ).IsTypeOf( typeof( IEnumerable<KeyValuePair<MessagePackObject, MessagePackObject>> ) ), Is.True );
		}

		[Test]
		public void TestIsTypeOf_DictionaryEmptyNotNull_IsTypeOfIListOfMessagePackObject_False()
		{
			Assert.That( new MessagePackObject(  new MessagePackObjectDictionary() ).IsTypeOf( typeof( IList<KeyValuePair<MessagePackObject, MessagePackObject>> ) ), Is.False );
		}

		[Test]
		public void TestIsTypeOf_DictionaryEmptyNotNull_IsTypeOfListOfMessagePackObject_False()
		{
			Assert.That( new MessagePackObject(  new MessagePackObjectDictionary() ).IsTypeOf( typeof( List<KeyValuePair<MessagePackObject, MessagePackObject>> ) ), Is.False );
		}

		[Test]
		public void TestIsTypeOf_DictionaryEmptyNotNull_IsTypeOfIDictionaryOfMessagePackObject_True()
		{
			Assert.That( new MessagePackObject(  new MessagePackObjectDictionary() ).IsTypeOf( typeof( IDictionary<MessagePackObject, MessagePackObject> ) ), Is.True );
		}

		[Test]
		public void TestIsTypeOf_DictionaryEmptyNotNull_IsTypeOfMessagePackObjectDictionary_True()
		{
			Assert.That( new MessagePackObject(  new MessagePackObjectDictionary() ).IsTypeOf( typeof( MessagePackObjectDictionary ) ), Is.True );
		}
		
		[Test]
		public void TestIsMap_DictionaryEmptyNotNull_True()
		{
			Assert.That( new MessagePackObject(  new MessagePackObjectDictionary() ).IsMap, Is.True );
		}
		[Test]
		public void TestIsTypeOf_DictionaryNull_IsTypeOfArrayOfNotItemType_Null()
		{
			Assert.That( new MessagePackObject( default( MessagePackObjectDictionary ) ).IsTypeOf( typeof( KeyValuePair<string, bool>[] ) ), Is.Null );
		}

		[Test]
		public void TestIsTypeOf_DictionaryNull_IsTypeOfArrayOfMessagePackObject_Null()
		{
			Assert.That( new MessagePackObject( default( MessagePackObjectDictionary ) ).IsTypeOf( typeof( KeyValuePair<MessagePackObject, MessagePackObject>[] ) ), Is.Null );
		}

		[Test]
		public void TestIsTypeOf_DictionaryNull_IsTypeOfArrayOfItemType_Null()
		{
			Assert.That( new MessagePackObject(  default( MessagePackObjectDictionary ) ).IsTypeOf( typeof( KeyValuePair<string, int>[] ) ), Is.Null );
		}

		[Test]
		public void TestIsTypeOf_DictionaryNull_IsTypeOfIEnumerableOfMessagePackObject_Null()
		{
			Assert.That( new MessagePackObject(  default( MessagePackObjectDictionary ) ).IsTypeOf( typeof( IEnumerable<KeyValuePair<MessagePackObject, MessagePackObject>> ) ), Is.Null );
		}

		[Test]
		public void TestIsTypeOf_DictionaryNull_IsTypeOfIListOfMessagePackObject_Null()
		{
			Assert.That( new MessagePackObject(  default( MessagePackObjectDictionary ) ).IsTypeOf( typeof( IList<KeyValuePair<MessagePackObject, MessagePackObject>> ) ), Is.Null );
		}

		[Test]
		public void TestIsTypeOf_DictionaryNull_IsTypeOfListOfMessagePackObject_Null()
		{
			Assert.That( new MessagePackObject(  default( MessagePackObjectDictionary ) ).IsTypeOf( typeof( List<KeyValuePair<MessagePackObject, MessagePackObject>> ) ), Is.Null );
		}

		[Test]
		public void TestIsTypeOf_DictionaryNull_IsTypeOfIDictionaryOfMessagePackObject_Null()
		{
			Assert.That( new MessagePackObject(  default( MessagePackObjectDictionary ) ).IsTypeOf( typeof( IDictionary<MessagePackObject, MessagePackObject> ) ), Is.Null );
		}

		[Test]
		public void TestIsTypeOf_DictionaryNull_IsTypeOfMessagePackObjectDictionary_Null()
		{
			Assert.That( new MessagePackObject(  default( MessagePackObjectDictionary ) ).IsTypeOf( typeof( MessagePackObjectDictionary ) ), Is.Null );
		}
		
		[Test]
		public void TestIsMap_DictionaryNull_False()
		{
			Assert.That( new MessagePackObject(  default( MessagePackObjectDictionary ) ).IsMap, Is.False );
		}
	}
}
