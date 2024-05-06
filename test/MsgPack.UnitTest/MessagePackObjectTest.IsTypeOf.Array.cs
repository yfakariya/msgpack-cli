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
		public void TestIsTypeOf_ArrayNotNull_IsTypeOfArrayOfNotItemType_False()
		{
			Assert.That( new MessagePackObject( new MessagePackObject[] { 1 } ).IsTypeOf( typeof( bool[] ) ), Is.False );
		}

		[Test]
		public void TestIsTypeOf_ArrayNotNull_IsTypeOfArrayOfMessagePackObject_True()
		{
			Assert.That( new MessagePackObject( new MessagePackObject[] { 1 } ).IsTypeOf( typeof( MessagePackObject[] ) ), Is.True );
		}

		[Test]
		public void TestIsTypeOf_ArrayNotNull_IsTypeOfArrayOfItemType_False()
		{
			Assert.That( new MessagePackObject(  new MessagePackObject[] { 1 } ).IsTypeOf( typeof( int[] ) ), Is.False );
		}

		[Test]
		public void TestIsTypeOf_ArrayNotNull_IsTypeOfIEnumerableOfMessagePackObject_True()
		{
			Assert.That( new MessagePackObject(  new MessagePackObject[] { 1 } ).IsTypeOf( typeof( IEnumerable<MessagePackObject> ) ), Is.True );
		}

		[Test]
		public void TestIsTypeOf_ArrayNotNull_IsTypeOfIListOfMessagePackObject_True()
		{
			Assert.That( new MessagePackObject(  new MessagePackObject[] { 1 } ).IsTypeOf( typeof( IList<MessagePackObject> ) ), Is.True );
		}

		[Test]
		public void TestIsTypeOf_ArrayNotNull_IsTypeOfListOfMessagePackObject_False()
		{
			Assert.That( new MessagePackObject(  new MessagePackObject[] { 1 } ).IsTypeOf( typeof( List<MessagePackObject> ) ), Is.False );
		}
		
		[Test]
		public void TestIsArray_ArrayNotNull_True()
		{
			Assert.That( new MessagePackObject(  new MessagePackObject[] { 1 } ).IsArray, Is.True );
		}
		
		[Test]
		public void TestIsList_ArrayNotNull_True()
		{
			Assert.That( new MessagePackObject(  new MessagePackObject[] { 1 } ).IsList, Is.True );
		}

		[Test]
		public void TestIsTypeOf_ArrayEmptyNotNull_IsTypeOfArrayOfNotItemType_False()
		{
			Assert.That( new MessagePackObject( new MessagePackObject[ 0 ] ).IsTypeOf( typeof( bool[] ) ), Is.False );
		}

		[Test]
		public void TestIsTypeOf_ArrayEmptyNotNull_IsTypeOfArrayOfMessagePackObject_True()
		{
			Assert.That( new MessagePackObject( new MessagePackObject[ 0 ] ).IsTypeOf( typeof( MessagePackObject[] ) ), Is.True );
		}

		[Test]
		public void TestIsTypeOf_ArrayEmptyNotNull_IsTypeOfArrayOfItemType_False()
		{
			Assert.That( new MessagePackObject(  new MessagePackObject[ 0 ] ).IsTypeOf( typeof( int[] ) ), Is.False );
		}

		[Test]
		public void TestIsTypeOf_ArrayEmptyNotNull_IsTypeOfIEnumerableOfMessagePackObject_True()
		{
			Assert.That( new MessagePackObject(  new MessagePackObject[ 0 ] ).IsTypeOf( typeof( IEnumerable<MessagePackObject> ) ), Is.True );
		}

		[Test]
		public void TestIsTypeOf_ArrayEmptyNotNull_IsTypeOfIListOfMessagePackObject_True()
		{
			Assert.That( new MessagePackObject(  new MessagePackObject[ 0 ] ).IsTypeOf( typeof( IList<MessagePackObject> ) ), Is.True );
		}

		[Test]
		public void TestIsTypeOf_ArrayEmptyNotNull_IsTypeOfListOfMessagePackObject_False()
		{
			Assert.That( new MessagePackObject(  new MessagePackObject[ 0 ] ).IsTypeOf( typeof( List<MessagePackObject> ) ), Is.False );
		}
		
		[Test]
		public void TestIsArray_ArrayEmptyNotNull_True()
		{
			Assert.That( new MessagePackObject(  new MessagePackObject[ 0 ] ).IsArray, Is.True );
		}
		
		[Test]
		public void TestIsList_ArrayEmptyNotNull_True()
		{
			Assert.That( new MessagePackObject(  new MessagePackObject[ 0 ] ).IsList, Is.True );
		}

		[Test]
		public void TestIsTypeOf_ArrayNull_IsTypeOfArrayOfNotItemType_Null()
		{
			Assert.That( new MessagePackObject( default( MessagePackObject[] ) ).IsTypeOf( typeof( bool[] ) ), Is.Null );
		}

		[Test]
		public void TestIsTypeOf_ArrayNull_IsTypeOfArrayOfMessagePackObject_Null()
		{
			Assert.That( new MessagePackObject( default( MessagePackObject[] ) ).IsTypeOf( typeof( MessagePackObject[] ) ), Is.Null );
		}

		[Test]
		public void TestIsTypeOf_ArrayNull_IsTypeOfArrayOfItemType_Null()
		{
			Assert.That( new MessagePackObject(  default( MessagePackObject[] ) ).IsTypeOf( typeof( int[] ) ), Is.Null );
		}

		[Test]
		public void TestIsTypeOf_ArrayNull_IsTypeOfIEnumerableOfMessagePackObject_Null()
		{
			Assert.That( new MessagePackObject(  default( MessagePackObject[] ) ).IsTypeOf( typeof( IEnumerable<MessagePackObject> ) ), Is.Null );
		}

		[Test]
		public void TestIsTypeOf_ArrayNull_IsTypeOfIListOfMessagePackObject_Null()
		{
			Assert.That( new MessagePackObject(  default( MessagePackObject[] ) ).IsTypeOf( typeof( IList<MessagePackObject> ) ), Is.Null );
		}

		[Test]
		public void TestIsTypeOf_ArrayNull_IsTypeOfListOfMessagePackObject_Null()
		{
			Assert.That( new MessagePackObject(  default( MessagePackObject[] ) ).IsTypeOf( typeof( List<MessagePackObject> ) ), Is.Null );
		}
		
		[Test]
		public void TestIsArray_ArrayNull_False()
		{
			Assert.That( new MessagePackObject(  default( MessagePackObject[] ) ).IsArray, Is.False );
		}
		
		[Test]
		public void TestIsList_ArrayNull_False()
		{
			Assert.That( new MessagePackObject(  default( MessagePackObject[] ) ).IsList, Is.False );
		}

		[Test]
		public void TestIsTypeOf_ListNotNull_IsTypeOfArrayOfNotItemType_False()
		{
			Assert.That( new MessagePackObject( new List<MessagePackObject>(){ 1 } ).IsTypeOf( typeof( bool[] ) ), Is.False );
		}

		[Test]
		public void TestIsTypeOf_ListNotNull_IsTypeOfArrayOfMessagePackObject_True()
		{
			Assert.That( new MessagePackObject( new List<MessagePackObject>(){ 1 } ).IsTypeOf( typeof( MessagePackObject[] ) ), Is.True );
		}

		[Test]
		public void TestIsTypeOf_ListNotNull_IsTypeOfArrayOfItemType_False()
		{
			Assert.That( new MessagePackObject(  new List<MessagePackObject>(){ 1 } ).IsTypeOf( typeof( int[] ) ), Is.False );
		}

		[Test]
		public void TestIsTypeOf_ListNotNull_IsTypeOfIEnumerableOfMessagePackObject_True()
		{
			Assert.That( new MessagePackObject(  new List<MessagePackObject>(){ 1 } ).IsTypeOf( typeof( IEnumerable<MessagePackObject> ) ), Is.True );
		}

		[Test]
		public void TestIsTypeOf_ListNotNull_IsTypeOfIListOfMessagePackObject_True()
		{
			Assert.That( new MessagePackObject(  new List<MessagePackObject>(){ 1 } ).IsTypeOf( typeof( IList<MessagePackObject> ) ), Is.True );
		}

		[Test]
		public void TestIsTypeOf_ListNotNull_IsTypeOfListOfMessagePackObject_False()
		{
			Assert.That( new MessagePackObject(  new List<MessagePackObject>(){ 1 } ).IsTypeOf( typeof( List<MessagePackObject> ) ), Is.False );
		}
		
		[Test]
		public void TestIsArray_ListNotNull_True()
		{
			Assert.That( new MessagePackObject(  new List<MessagePackObject>(){ 1 } ).IsArray, Is.True );
		}
		
		[Test]
		public void TestIsList_ListNotNull_True()
		{
			Assert.That( new MessagePackObject(  new List<MessagePackObject>(){ 1 } ).IsList, Is.True );
		}

		[Test]
		public void TestIsTypeOf_ListEmptyNotNull_IsTypeOfArrayOfNotItemType_False()
		{
			Assert.That( new MessagePackObject( new List<MessagePackObject>() ).IsTypeOf( typeof( bool[] ) ), Is.False );
		}

		[Test]
		public void TestIsTypeOf_ListEmptyNotNull_IsTypeOfArrayOfMessagePackObject_True()
		{
			Assert.That( new MessagePackObject( new List<MessagePackObject>() ).IsTypeOf( typeof( MessagePackObject[] ) ), Is.True );
		}

		[Test]
		public void TestIsTypeOf_ListEmptyNotNull_IsTypeOfArrayOfItemType_False()
		{
			Assert.That( new MessagePackObject(  new List<MessagePackObject>() ).IsTypeOf( typeof( int[] ) ), Is.False );
		}

		[Test]
		public void TestIsTypeOf_ListEmptyNotNull_IsTypeOfIEnumerableOfMessagePackObject_True()
		{
			Assert.That( new MessagePackObject(  new List<MessagePackObject>() ).IsTypeOf( typeof( IEnumerable<MessagePackObject> ) ), Is.True );
		}

		[Test]
		public void TestIsTypeOf_ListEmptyNotNull_IsTypeOfIListOfMessagePackObject_True()
		{
			Assert.That( new MessagePackObject(  new List<MessagePackObject>() ).IsTypeOf( typeof( IList<MessagePackObject> ) ), Is.True );
		}

		[Test]
		public void TestIsTypeOf_ListEmptyNotNull_IsTypeOfListOfMessagePackObject_False()
		{
			Assert.That( new MessagePackObject(  new List<MessagePackObject>() ).IsTypeOf( typeof( List<MessagePackObject> ) ), Is.False );
		}
		
		[Test]
		public void TestIsArray_ListEmptyNotNull_True()
		{
			Assert.That( new MessagePackObject(  new List<MessagePackObject>() ).IsArray, Is.True );
		}
		
		[Test]
		public void TestIsList_ListEmptyNotNull_True()
		{
			Assert.That( new MessagePackObject(  new List<MessagePackObject>() ).IsList, Is.True );
		}

		[Test]
		public void TestIsTypeOf_ListNull_IsTypeOfArrayOfNotItemType_Null()
		{
			Assert.That( new MessagePackObject( default( IList<MessagePackObject> ) ).IsTypeOf( typeof( bool[] ) ), Is.Null );
		}

		[Test]
		public void TestIsTypeOf_ListNull_IsTypeOfArrayOfMessagePackObject_Null()
		{
			Assert.That( new MessagePackObject( default( IList<MessagePackObject> ) ).IsTypeOf( typeof( MessagePackObject[] ) ), Is.Null );
		}

		[Test]
		public void TestIsTypeOf_ListNull_IsTypeOfArrayOfItemType_Null()
		{
			Assert.That( new MessagePackObject(  default( IList<MessagePackObject> ) ).IsTypeOf( typeof( int[] ) ), Is.Null );
		}

		[Test]
		public void TestIsTypeOf_ListNull_IsTypeOfIEnumerableOfMessagePackObject_Null()
		{
			Assert.That( new MessagePackObject(  default( IList<MessagePackObject> ) ).IsTypeOf( typeof( IEnumerable<MessagePackObject> ) ), Is.Null );
		}

		[Test]
		public void TestIsTypeOf_ListNull_IsTypeOfIListOfMessagePackObject_Null()
		{
			Assert.That( new MessagePackObject(  default( IList<MessagePackObject> ) ).IsTypeOf( typeof( IList<MessagePackObject> ) ), Is.Null );
		}

		[Test]
		public void TestIsTypeOf_ListNull_IsTypeOfListOfMessagePackObject_Null()
		{
			Assert.That( new MessagePackObject(  default( IList<MessagePackObject> ) ).IsTypeOf( typeof( List<MessagePackObject> ) ), Is.Null );
		}
		
		[Test]
		public void TestIsArray_ListNull_False()
		{
			Assert.That( new MessagePackObject(  default( IList<MessagePackObject> ) ).IsArray, Is.False );
		}
		
		[Test]
		public void TestIsList_ListNull_False()
		{
			Assert.That( new MessagePackObject(  default( IList<MessagePackObject> ) ).IsList, Is.False );
		}

	}
}
