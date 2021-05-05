// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

using System;

namespace MsgPack.Serialization.Polymorphic
{
	/// <summary>
	///		Common interfaces among polymorhic helper attributes.
	/// </summary>
	internal interface IPolymorphicHelperAttribute
	{
		PolymorphismTarget Target { get; }
	}

	/// <summary>
	///		Common interfaces among *Known*TypeAttrbutes.
	/// </summary>
	internal interface IPolymorphicKnownTypeAttribute : IPolymorphicHelperAttribute
	{
		Type? BindingType { get; }
		string? TypeCode { get; }
	}

	/// <summary>
	///		Common(marker) interfaces among *Runtime*TypeAttrbutes.
	/// </summary>
	internal interface IPolymorphicRuntimeTypeAttribute : IPolymorphicHelperAttribute
	{
		Type? VerifierType { get; }
		string? VerifierMethodName { get; }
	}

	/// <summary>
	///		Common interfaces among *TupleItemTypeAttributes.
	/// </summary>
	internal interface IPolymorphicTupleItemTypeAttribute : IPolymorphicHelperAttribute
	{
		int ItemNumber { get; }
	}
}
