// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

using System;
using System.Collections.Generic;
#if SILVERLIGHT
using System.Diagnostics;
#endif // SILVERLIGHT
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;

namespace MsgPack
{
	internal static class ReflectionAbstractions
	{
		[SuppressMessage("Microsoft.Performance", "CA1802:UseLiteralsWhereAppropriate", Justification = "Same as FCL")]
		public static readonly char TypeDelimiter = '.';
		public static readonly Type[] EmptyTypes = new Type[0];

		public static bool GetIsValueType(this Type source)
#if NETSTANDARD1_1 || NETSTANDARD1_3
			=> source.GetTypeInfo().IsValueType;
#else
			=> source.IsValueType;
#endif // NETSTANDARD1_1 || NETSTANDARD1_3

		public static bool GetIsEnum(this Type source)
#if NETSTANDARD1_1 || NETSTANDARD1_3
			=> source.GetTypeInfo().IsEnum;
#else
			=> source.IsEnum;
#endif // NETSTANDARD1_1 || NETSTANDARD1_3

		public static bool GetIsInterface(this Type source)
#if NETSTANDARD1_1 || NETSTANDARD1_3
			=> source.GetTypeInfo().IsInterface;
#else
			=> source.IsInterface;
#endif // NETSTANDARD1_1 || NETSTANDARD1_3

		public static bool GetIsAbstract(this Type source)
#if NETSTANDARD1_1 || NETSTANDARD1_3
			=> source.GetTypeInfo().IsAbstract;
#else
			=> source.IsAbstract;
#endif // NETSTANDARD1_1 || NETSTANDARD1_3

		public static bool GetIsGenericType(this Type source)
#if NETSTANDARD1_1 || NETSTANDARD1_3
			=> source.GetTypeInfo().IsGenericType;
#else
			=> source.IsGenericType;
#endif // NETSTANDARD1_1 || NETSTANDARD1_3

		public static bool GetIsGenericTypeDefinition(this Type source)
#if NETSTANDARD1_1 || NETSTANDARD1_3
			=> source.GetTypeInfo().IsGenericTypeDefinition;
#else
			=> source.IsGenericTypeDefinition;
#endif // NETSTANDARD1_1 || NETSTANDARD1_3

#if DEBUG
		public static bool GetContainsGenericParameters(this Type source)
#if NETSTANDARD1_1 || NETSTANDARD1_3
			=> source.GetTypeInfo().ContainsGenericParameters;
#else
			=> source.ContainsGenericParameters;
#endif // NETSTANDARD1_1 || NETSTANDARD1_3
#endif // DEBUG

		public static Assembly GetAssembly(this Type source)
#if NETSTANDARD1_1 || NETSTANDARD1_3
			=> source.GetTypeInfo().Assembly;
#else
			=> source.Assembly;
#endif // NETSTANDARD1_1 || NETSTANDARD1_3

		public static bool GetIsVisible(this Type source)
#if NETSTANDARD1_1 || NETSTANDARD1_3
			=> source.GetTypeInfo().IsVisible;
#else
			=> source.IsVisible;
#endif // NETSTANDARD1_1 || NETSTANDARD1_3

		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Wrong detection")]
		public static bool GetIsPublic(this Type source)
#if NETSTANDARD1_1 || NETSTANDARD1_3
			=> source.GetTypeInfo().IsPublic;
#else
			=> source.IsPublic;
#endif // NETSTANDARD1_1 || NETSTANDARD1_3

		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Wrong detection")]
		public static bool GetIsNestedPublic(this Type source)
#if NETSTANDARD1_1 || NETSTANDARD1_3
			=> source.GetTypeInfo().IsNestedPublic;
#else
			=> source.IsNestedPublic;
#endif // NETSTANDARD1_1 || NETSTANDARD1_3

#if DEBUG
		public static bool GetIsPrimitive(this Type source)
#if NETSTANDARD1_1 || NETSTANDARD1_3
			=> source.GetTypeInfo().IsPrimitive;
#else
			=> source.IsPrimitive;
#endif // NETSTANDARD1_1 || NETSTANDARD1_3
#endif // DEBUG

		public static Type? GetBaseType(this Type source)
#if NETSTANDARD1_1 || NETSTANDARD1_3
			=> source.GetTypeInfo().BaseType;
#else
			=> source.BaseType;
#endif // NETSTANDARD1_1 || NETSTANDARD1_3

		public static MethodBase? GetDeclaringMethod(this Type source)
#if NETSTANDARD1_1 || NETSTANDARD1_3
			=> source.GetTypeInfo().DeclaringMethod;
#else
			=> source.DeclaringMethod;
#endif // NETSTANDARD1_1 || NETSTANDARD1_3


		public static Type[] GetGenericTypeParameters(this Type source)
#if NETSTANDARD1_1 || NETSTANDARD1_3
			=> source.GetTypeInfo().GenericTypeParameters;
#else
			=> source.GetGenericArguments().Where(t => t.IsGenericParameter).ToArray();
#endif // NETSTANDARD1_1 || NETSTANDARD1_3

		public static MethodInfo? GetRuntimeMethod(this Type source, string name)
		{
			var candidates = source.GetRuntimeMethods().Where(m => m.Name == name).ToArray();
			switch (candidates.Length)
			{
				case 0:
				{
					return null;
				}
				case 1:
				{
					return candidates[0];
				}
				default:
				{
					throw new AmbiguousMatchException();
				}
			}
		}

#if NETSTANDARD1_1 || NETSTANDARD1_3
		public static MethodInfo GetRuntimeMethod(this Type source, string name, Type[] parameters)
			=> source.GetRuntimeMethods()
				.SingleOrDefault(
					m => m.IsPublic && m.Name == name && m.GetParameters().Select(p => p.ParameterType).SequenceEqual(parameters)
				);

#else // NETSTANDARD1_1 || NETSTANDARD1_3
		public static MethodInfo? GetRuntimeMethod(this Type source, string name, Type[] parameters)
			=> source.GetMethod(
				name,
				BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public,
				null,
				parameters,
				null
			);

		public static IEnumerable<MethodInfo> GetRuntimeMethods(this Type source)
			=> source.GetMethods(
				BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic
			);

		public static PropertyInfo? GetRuntimeProperty(this Type source, string name)
			=> source.GetProperty(
				name,
				BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic
			);

#if NET35 || SILVERLIGHT

		public static IEnumerable<PropertyInfo> GetRuntimeProperties(this Type source)
			=> source.GetProperties(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

#endif // NET35 || SILVERLIGHT

#if DEBUG
		public static FieldInfo? GetRuntimeField(this Type source, string name)
			=>
				source.GetField(
					name,
					BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic
				);
#endif // DEBUG

#endif // NETSTANDARD1_1 || NETSTANDARD1_3

		public static ConstructorInfo? GetRuntimeConstructor(this Type source, Type[] parameters)
#if NETSTANDARD1_1 || NETSTANDARD1_3
			=> source.GetTypeInfo().DeclaredConstructors.SingleOrDefault(c => c.GetParameters().Select(p => p.ParameterType).SequenceEqual(parameters));
#else
			=> source.GetConstructor(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, parameters, null);
#endif // NETSTANDARD1_1 || NETSTANDARD1_3

#if NET35 || NET40 || SILVERLIGHT
		public static Delegate CreateDelegate(this MethodInfo source, Type delegateType)
			=> Delegate.CreateDelegate(delegateType, source);

		public static Delegate CreateDelegate(this MethodInfo source, Type delegateType, object target)
			=> Delegate.CreateDelegate(delegateType, target, source);

#endif // NET35 || NET40 || SILVERLIGHT || UNITY

#if NETSTANDARD1_1 || NETSTANDARD1_3
		public static MethodInfo? GetMethod(this Type source, string name)
			=> source.GetRuntimeMethods().SingleOrDefault(m => m.IsPublic && m.Name == name && m.DeclaringType == source);

		public static MethodInfo? GetMethod(this Type source, string name, Type[] parameters)
			=> source.GetRuntimeMethod(name, parameters);

		public static IEnumerable<MethodInfo> GetMethods(this Type source)
			=> source.GetRuntimeMethods();

		public static PropertyInfo? GetProperty(this Type source, string name)
			=> source.GetRuntimeProperty(name);

		public static PropertyInfo? GetProperty(this Type source, string name, Type[] keyTypes)
			=> source.GetRuntimeProperties()
				.SingleOrDefault(
					p => p.Name == name && p.GetMethod != null && p.GetMethod.GetParameters().Select(r => r.ParameterType).SequenceEqual(keyTypes)
				);

		public static IEnumerable<PropertyInfo> GetProperties(this Type source)
			=> source.GetRuntimeProperties();

		public static FieldInfo? GetField(this Type source, string name)
			=> source.GetRuntimeField(name);

		public static ConstructorInfo? GetConstructor(this Type source, Type[] parameteres)
			=> source.GetTypeInfo().GetConstructor(parameteres);

		public static ConstructorInfo? GetConstructor(this TypeInfo source, Type[] parameteres)
			=> source.DeclaredConstructors.SingleOrDefault(c => !c.IsStatic && c.GetParameters().Select(p => p.ParameterType).SequenceEqual(parameteres));


		public static IEnumerable<ConstructorInfo> GetConstructors(this Type source)
			=> source.GetTypeInfo().DeclaredConstructors.Where(c => c.IsPublic);

		public static Type[] GetGenericArguments(this Type source)
			=> source.GenericTypeArguments;

		public static bool IsAssignableFrom(this Type source, Type target)
			=> source.GetTypeInfo().IsAssignableFrom(target.GetTypeInfo());

		public static IEnumerable<Type> GetInterfaces(this Type source)
			=> source.GetTypeInfo().ImplementedInterfaces;

		public static MethodInfo? GetGetMethod(this PropertyInfo source)
			=> GetGetMethod(source, false);

		[SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "containsNonPublic", Justification = "For API compabitility")]
		public static MethodInfo? GetGetMethod(this PropertyInfo source, bool containsNonPublic)
		{
			var getter = source.GetMethod;
			return (containsNonPublic || (getter?.IsPublic).GetValueOrDefault()) ? getter : null;
		}

		public static MethodInfo? GetSetMethod(this PropertyInfo source)
			=> GetSetMethod(source, false);

		[SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "containsNonPublic", Justification = "For API compabitility")]
		public static MethodInfo? GetSetMethod(this PropertyInfo source, bool containsNonPublic)
		{
			var setter = source.SetMethod;
			return (containsNonPublic || (setter?.IsPublic).GetValueOrDefault()) ? setter : null;
		}

		public static IEnumerable<Type> FindInterfaces(this Type source, Func<Type, object, bool> filter, object filterCriteria)
			=> source.GetTypeInfo().ImplementedInterfaces.Where(t => filter(t, filterCriteria));

		public static InterfaceMapping GetInterfaceMap(this Type source, Type interfaceType)
			=> source.GetTypeInfo().GetRuntimeInterfaceMap(interfaceType);

		public static IEnumerable<CustomAttributeData> GetCustomAttributesData(this Type source)
			=> source.GetTypeInfo().CustomAttributes;

		public static IEnumerable<CustomAttributeData> GetCustomAttributesData(this MemberInfo source)
			=> source.CustomAttributes;

		public static Type GetAttributeType(this CustomAttributeData source)
			=> source.AttributeType;

		public static string GetMemberName(this CustomAttributeNamedArgument source)
		{
			// This is hack to check null because .NET Standard 1.1 does not expose CustomAttributeNamedArgument.MemberInfo
			// but it still throws NullReferenceException when its private MemberInfo type field is null.
			// This is caused by default instance of CustomAttributeNamedArgument, so it also should have default CustomAttributeTypedArgument
			// which has null ArgumentType.
			if (source.TypedValue.ArgumentType == null)
			{
				Throw.EmptyStruct(typeof(CustomAttributeNamedArgument), nameof(source));
			}

			return source.MemberName;
		}
#else // NETSTANDARD1_1 || NETSTANDARD1_3
		[return: MaybeNull]
		public static T GetCustomAttribute<T>(this MemberInfo source)
			where T : Attribute
			=> Attribute.GetCustomAttribute(source, typeof(T)) as T;

#if NET35 || NET40 || SILVERLIGHT
		public static bool IsDefined(this MemberInfo source, Type attributeType)
			=> Attribute.IsDefined(source, attributeType);
#endif // NET35 || NET40 || SILVERLIGHT

#if !SILVERLIGHT
		public static Type GetAttributeType(this CustomAttributeData source)
			=> source.Constructor.DeclaringType!;

		public static string GetMemberName(this CustomAttributeNamedArgument source)
		{
			if (source.MemberInfo == null)
			{
				Throw.EmptyStruct(typeof(CustomAttributeNamedArgument), nameof(source));
			}

			return source.MemberInfo!.Name;
		}

#else // !SILVERLIGHT

		public static Type GetAttributeType(this Attribute source)
			=> source.GetType();

#endif // !SILVERLIGHT
#endif // else NETSTANDARD1_1 || NETSTANDARD1_3

		public static string? GetCultureName(this AssemblyName source)
#if NET35 || NET40 || SILVERLIGHT || UNITY
			=> source.CultureInfo?.Name;
#else
			=> source.CultureName;
#endif

#if NET35 || UNITY

		public static IEnumerable<CustomAttributeData> GetCustomAttributesData(this MemberInfo source)
			=> CustomAttributeData.GetCustomAttributes(source);

		public static IEnumerable<CustomAttributeData> GetCustomAttributesData(this ParameterInfo source)
			=> CustomAttributeData.GetCustomAttributes(source);

#endif // NET35 || UNITY

#if NETSTANDARD1_1 || NETSTANDARD1_3

		public static IEnumerable<CustomAttributeData> GetCustomAttributesData(this ParameterInfo source)
			=> source.CustomAttributes;

#endif // NETSTANDARD1_1 || NETSTANDARD1_3

#if SILVERLIGHT

		public static IEnumerable<Attribute> GetCustomAttributesData(this MemberInfo source)
			=> source.GetCustomAttributes(false).OfType<Attribute>();

		public static IEnumerable<NamedArgument> GetNamedArguments(this Attribute attribute)
			=> attribute.GetType()
				.GetMembers(BindingFlags.Public | BindingFlags.Instance)
				.Where(m => m.MemberType == MemberTypes.Field || m.MemberType == MemberTypes.Property)
				.Select(m => new NamedArgument(attribute, m));

#else // SILVERLIGHT
		public static IList<CustomAttributeTypedArgument> GetConstructorArguments(this CustomAttributeData source)
			=> source.ConstructorArguments;

		public static IEnumerable<CustomAttributeNamedArgument> GetNamedArguments(this CustomAttributeData source)
			=> source.NamedArguments;

		public static CustomAttributeTypedArgument GetTypedValue(this CustomAttributeNamedArgument source)
			=> source.TypedValue;
#endif // else SILVERLIGHT

#if SILVERLIGHT

		public struct NamedArgument
		{
			private readonly object _instance;
			private readonly MemberInfo _memberInfo;

			public NamedArgument(object instance, MemberInfo memberInfo)
			{
				this._instance = instance;
				this._memberInfo = memberInfo;
			}

			public string GetMemberName()
				=> this._memberInfo.Name;

			public KeyValuePair<Type, object?> GetTypedValue()
			{
				Type type;
				object? value;
				if (this._memberInfo is PropertyInfo asProperty)
				{
					type = asProperty.PropertyType;
					value = asProperty.GetValue(this._instance, null);
				}
				else
				{
					var asField = this._memberInfo as FieldInfo;
#if DEBUG
					Debug.Assert(asField != null);
#endif
					type = asField.FieldType;
					value = asField.GetValue(this._instance);
				}

				return new KeyValuePair<Type, object?>(type, value);
			}
		}
#endif // SILVERLIGHT

		public static bool GetHasDefaultValue(this ParameterInfo source)
#if NET35 || NET40 || SILVERLIGHT
			=> source.DefaultValue != DBNull.Value;
#else
			=> source.HasDefaultValue;
#endif
	}
}
