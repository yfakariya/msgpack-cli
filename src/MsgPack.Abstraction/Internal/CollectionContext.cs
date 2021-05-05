// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

namespace MsgPack.Internal
{
#warning TODO: This object should be used with ref
	/// <summary>
	///		Represents current context of collection serialization and deserialization.
	/// </summary>
	public partial struct CollectionContext
	{
		/// <summary>
		///		Gets the configured maximum length of serialized arrays.
		/// </summary>
		/// <value>
		///		The configured maximum length of serialized arrays.
		/// </value>
		public int MaxArrayLength { get; }

		/// <summary>
		///		Gets the configured maximum count of serialized maps.
		/// </summary>
		/// <value>
		///		The configured maximum count of serialized maps.
		/// </value>
		public int MaxMapCount { get; }

		/// <summary>
		///		Gets the configured maximum depth of nested objects and collections.
		/// </summary>
		/// <value>
		///		The configured maximum depth of nested objects and collections.
		/// </value>
		public int MaxDepth { get; }

		/// <summary>
		///		Gets the current depth of nested objects and collections.
		/// </summary>
		/// <value>
		///		The current depth of nested objects and collections.
		/// </value>
		public int CurrentDepth { get; private set; }

		internal CollectionContext(int maxArrayLength, int maxMapCount, int maxDepth, int currentDepth)
		{
			this.MaxArrayLength = maxArrayLength;
			this.MaxMapCount = maxMapCount;
			this.MaxDepth = Ensure.IsNotLessThan(maxDepth, 1);
			this.CurrentDepth = currentDepth;
		}

		/// <summary>
		///		Increments current depth.
		/// </summary>
		/// <param name="position">The current position.</param>
		/// <returns>The new <see cref="CurrentDepth"/> value.</returns>
		/// <exception cref="LimitExceededException">The <see cref="CurrentDepth"/> is going to exceed the <see cref="MaxDepth"/>.</exception>
		public int IncrementDepth(long position)
		{
			if (this.CurrentDepth == this.MaxDepth)
			{
				Throw.DepthExeeded(position, this.MaxDepth);
			}

			return this.CurrentDepth++;
		}

		/// <summary>
		///		Decrements current depth.
		/// </summary>
		/// <returns>The new <see cref="CurrentDepth"/> value.</returns>
		public int DecrementDepth()
		{
			if (this.CurrentDepth == 0)
			{
				Throw.DepthUnderflow();
			}

			return this.CurrentDepth--;
		}
	}
}
