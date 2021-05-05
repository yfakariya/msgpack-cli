// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MsgPack.Serialization.Reflection
{
	/// <summary>
	///		Define utility extension method for generic type.
	/// </summary>
	internal static class GenericTypeExtensions
	{
		/// <summary>
		///		Determine whether the source type implements specified generic type or its built type.
		/// </summary>
		/// <param name="source">Target type.</param>
		/// <param name="genericType">Generic interface type.</param>
		/// <returns>
		///		<c>true</c> if <paramref name="source"/> implements <paramref name="genericType"/>,
		///		or built closed generic interface type;
		///		otherwise <c>false</c>.
		/// </returns>
		public static bool Implements(this Type source, Type genericType)
		{
			Debug.Assert(source != null, "source != null");
			Debug.Assert(genericType != null, "genericType != null");
			Debug.Assert(genericType.GetIsInterface(), "genericType.GetIsInterface()");

			return EnumerateGenericIntefaces(source, genericType, false).Any();
		}

		private static IEnumerable<Type> EnumerateGenericIntefaces(Type source, Type genericType, bool includesOwn)
		{
			return
				(includesOwn ? new[] { source }.Concat(source.GetInterfaces()) : source.GetInterfaces())
				.Where(@interface =>
				   @interface.GetIsGenericType()
				   && (genericType.GetIsGenericTypeDefinition()
					   ? @interface.GetGenericTypeDefinition() == genericType
					   : @interface == genericType
				   )
				).Select(@interface => // If source is GenericTypeDefinition, type def is only valid type (i.e. has name)
				   source.GetIsGenericTypeDefinition() ? @interface.GetGenericTypeDefinition() : @interface
				);
		}
	}
}
