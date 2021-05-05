// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MsgPack.Serialization
{
	public static class CompatibilityExtensions
	{
		public static MessagePackSerializer<T> GetSerializer<T>(this SerializerProvider context)
			=> GetSerializer(context, null);

		public static MessagePackSerializer<T> GetSerializer<T>(this SerializerProvider context, object? providerParameter)
			=> throw new NotImplementedException();

		public static MessagePackSerializer GetSerializer(this SerializerProvider context, Type targetType)
			=> GetSerializer(context, targetType, null);

		public static MessagePackSerializer GetSerializer(this SerializerProvider context, Type targetType, object? providerParameter)
			=> throw new NotImplementedException();

		/// <summary>
		///		Sets the serializer instance which can handle <see cref="ResolveSerializerEventArgs.TargetType" /> type instance correctly.
		/// </summary>
		/// <param name="foundSerializer">The serializer instance which can handle <see cref="ResolveSerializerEventArgs.TargetType" /> type instance correctly; <c>null</c> when you cannot provide appropriate serializer instance.</param>
		/// <remarks>
		///		If you decide to delegate serializer generation to MessagePack for CLI infrastructure, do not call this method in your event handler or specify <c>null</c> for <paramref name="foundSerializer"/>.
		/// </remarks>
		[Obsolete(
			Obsoletion.NewSerializer.Message
#if FEATURE_ADVANCED_OBSOLETE
			, DiagId = Obsoletion.NewSerializer.DiagId
			, Url = Obsoletion.NewSerializer.Url
#endif // FEATURE_ADVANCED_OBSOLETE
		)]
		public static void SetSerializer<T>(this ResolveSerializerEventArgs e, MessagePackSerializer<T> foundSerializer)
		{
			if (typeof(T) != (e ?? throw new ArgumentNullException(nameof(e))).TargetType)
			{
				throw new InvalidOperationException(
					$"The serializer must be {typeof(MessagePackSerializer<>).MakeGenericType(e.TargetType)} type."
				);
			}

			e.SetFoundSerializer(foundSerializer);
		}
	}

}
