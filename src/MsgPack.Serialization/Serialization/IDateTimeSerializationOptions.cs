// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

using System;
using System.Collections.Generic;

namespace MsgPack.Serialization
{
	/// <summary>
	///		Defines interface of date time serialization related options.
	/// </summary>
	internal interface IDateTimeSerializationOptions : IRuntimeDateTimeSerializationOptionsProvider
	{
		/// <summary>
		///		Gets the collection which contains types which will be considered as date-time like type.
		/// </summary>
		/// <value>
		///		The collection which contains types which will be considered as date-time like type.
		/// </value>
		ISet<Type> KnownDateTimeLikeTypes { get; }
	}
}
