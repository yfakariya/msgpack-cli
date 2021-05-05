// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

using System;
using System.Diagnostics;
using System.Reflection;

namespace MsgPack.Serialization
{
	/// <summary>
	///		Represents and encapsulates context informatino to verify actual type for runtime type polymorphism.
	/// </summary>
	public struct PolymorphicTypeVerificationContext : IEquatable<PolymorphicTypeVerificationContext>
	{
		/// <summary>
		///		Gets the full type name including its namespace to be loaded.
		/// </summary>
		/// <value>
		///		The full type name including its namespace to be loaded. This value will not be <c>null</c>.
		/// </value>
		public string LoadingTypeFullName { get; }

		/// <summary>
		///		Gets the full name of the loading assembly.
		/// </summary>
		/// <value>
		///		The full name of the loading assembly.
		/// </value>
		public string LoadingAssemblyFullName { get; }

		/// <summary>
		///		Gets the name of the loading assembly.
		/// </summary>
		/// <value>
		///		The name of the loading assembly.
		/// </value>
		public AssemblyName LoadingAssemblyName { get; }

		internal PolymorphicTypeVerificationContext(string loadingTypeFullName, AssemblyName loadingAssemblyName, string loadingAssemblyFullName)
		{
			Debug.Assert(loadingTypeFullName != null);
			Debug.Assert(loadingAssemblyName != null);
			this.LoadingTypeFullName = loadingTypeFullName;
			this.LoadingAssemblyName = loadingAssemblyName;
			this.LoadingAssemblyFullName = loadingAssemblyFullName;
		}

		/// <summary>
		///		Returns a <see cref="String" /> that represents this instance.
		/// </summary>
		/// <returns>
		///		A <see cref="String" /> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			if (this.LoadingTypeFullName == null)
			{
				return String.Empty;
			}

			return this.LoadingTypeFullName + ", " + this.LoadingAssemblyFullName;
		}

		/// <summary>
		///		Determines whether the specified <see cref="System.Object" /> is equal to this instance.
		/// </summary>
		/// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
		/// <returns>
		///		<c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
		/// </returns>
		public override bool Equals(object? obj)
			=> (obj is PolymorphicTypeVerificationContext other) && this.Equals(other);

		/// <summary>
		///		Determines whether the specified <see cref="PolymorphicTypeVerificationContext" /> is equal to this instance.
		/// </summary>
		/// <param name="other">The <see cref="PolymorphicTypeVerificationContext" /> to compare with this instance.</param>
		/// <returns>
		///		<c>true</c> if the specified <see cref="PolymorphicTypeVerificationContext" /> is equal to this instance; otherwise, <c>false</c>.
		/// </returns>
		public bool Equals(PolymorphicTypeVerificationContext other)
			=> this.LoadingTypeFullName == other.LoadingTypeFullName && this.LoadingAssemblyFullName == other.LoadingAssemblyFullName;

		/// <summary>
		///		Returns a hash code for this instance.
		/// </summary>
		/// <returns>
		///		A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
		/// </returns>
		public override int GetHashCode()
		{
			if (this.LoadingTypeFullName == null)
			{
				return 0;
			}

			return this.LoadingTypeFullName.GetHashCode() ^ this.LoadingAssemblyFullName.GetHashCode();
		}

		/// <summary>
		///		Returns a value that indicates whether two <see cref="PolymorphicTypeVerificationContext" /> objects are equal.
		/// </summary>
		/// <param name="left">The first <see cref="PolymorphicTypeVerificationContext" /> to compare.</param>
		/// <param name="right">The second <see cref="PolymorphicTypeVerificationContext" /> to compare.</param>
		/// <returns>
		///   <c>true</c> if the two <see cref="PolymorphicTypeVerificationContext" /> objects are equal; otherwise, <c>false</c>.
		/// </returns>
		public static bool operator ==(PolymorphicTypeVerificationContext left, PolymorphicTypeVerificationContext right)
			=> left.Equals(right);

		/// <summary>
		///		Returns a value that indicates whether two <see cref="PolymorphicTypeVerificationContext" /> objects are not equal.
		/// </summary>
		/// <param name="left">The first <see cref="PolymorphicTypeVerificationContext" /> to compare.</param>
		/// <param name="right">The second <see cref="PolymorphicTypeVerificationContext" /> to compare.</param>
		/// <returns>
		///   <c>true</c> if the two <see cref="PolymorphicTypeVerificationContext" /> objects are not equal; otherwise, <c>false</c>.
		/// </returns>
		public static bool operator !=(PolymorphicTypeVerificationContext left, PolymorphicTypeVerificationContext right)
			=> !left.Equals(right);
	}
}
