// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using static MsgPack.MessagePackObject;

namespace MsgPack
{
	/// <summary>
	///		Implements <see cref="IPackable"/> over <see cref="MessagePackObject"/>.
	/// </summary>
	internal sealed class PackableMessagePackObject : IPackable
#if FEATURE_TAP
		, IAsyncPackable
#endif // FEATURE_TAP
	{
		private readonly MessagePackObject _obj;

		public PackableMessagePackObject(MessagePackObject obj)
		{
			this._obj = obj;
		}

		/// <summary>
		///		Packs this instance itself using specified <see cref="Packer"/>.
		/// </summary>
		/// <param name="packer"><see cref="Packer"/>.</param>
		/// <param name="options">Packing options. This value can be null.</param>
		/// <exception cref="ArgumentNullException"><paramref name="packer"/> is null.</exception>
		public void PackToMessage(Packer packer, PackingOptions options)
		{
			packer = Ensure.NotNull(packer);

			if (this._obj.InternalHandleOrTypeCode == null)
			{
				packer.PackNull();
				return;
			}

			var typeCode = this._obj.InternalHandleOrTypeCode as MessagePackObject.ValueTypeCode;
			if (typeCode == null)
			{
				if (this._obj.InternalHandleOrTypeCode is MessagePackString asString)
				{
					if (asString.GetUnderlyingType() == typeof(string) || (packer.CompatibilityOptions & PackerCompatibilityOptions.PackBinaryAsRaw) != 0)
					{
						packer.PackRaw(asString.GetByteArray());
					}
					else
					{
						packer.PackBinary(asString.GetByteArray());
					}
				}
				else if (this._obj.InternalHandleOrTypeCode is IList<MessagePackObject> asList)
				{
					packer.PackArrayHeader(asList.Count);
					foreach (var item in asList)
					{
						item.AsPackable().PackToMessage(packer, options);
					}
				}
				else if (this._obj.InternalHandleOrTypeCode is IDictionary<MessagePackObject, MessagePackObject> asDictionary)
				{
					packer.PackMapHeader(asDictionary.Count);
					foreach (var item in asDictionary)
					{
						item.Key.AsPackable().PackToMessage(packer, options);
						item.Value.AsPackable().PackToMessage(packer, options);
					}
				}
				// ReSharper disable once ConditionIsAlwaysTrueOrFalse
				// ReSharper disable HeuristicUnreachableCode
				else if (this._obj.InternalHandleOrTypeCode is byte[] asExtendedTypeObjectBody)
				{
					packer.PackExtendedTypeValue(unchecked((byte)this._obj.InternalValue), asExtendedTypeObjectBody);
				}
				// ReSharper restore HeuristicUnreachableCode
				else
				{
					throw new SerializationException("Failed to pack this object.");
				}

				return;
			}

			switch (typeCode.TypeCode)
			{
				case MessagePackValueTypeCode.Single:
				{
					packer.Pack((float)this._obj);
					return;
				}
				case MessagePackValueTypeCode.Double:
				{
					packer.Pack((double)this._obj);
					return;
				}
				case MessagePackValueTypeCode.Int8:
				{
					packer.Pack((sbyte)this._obj);
					return;
				}
				case MessagePackValueTypeCode.Int16:
				{
					packer.Pack((short)this._obj);
					return;
				}
				case MessagePackValueTypeCode.Int32:
				{
					packer.Pack((int)this._obj);
					return;
				}
				case MessagePackValueTypeCode.Int64:
				{
					packer.Pack((long)this._obj);
					return;
				}
				case MessagePackValueTypeCode.UInt8:
				{
					packer.Pack((byte)this._obj);
					return;
				}
				case MessagePackValueTypeCode.UInt16:
				{
					packer.Pack((ushort)this._obj);
					return;
				}
				case MessagePackValueTypeCode.UInt32:
				{
					packer.Pack((uint)this._obj);
					return;
				}
				case MessagePackValueTypeCode.UInt64:
				{
					packer.Pack(this._obj.InternalValue);
					return;
				}
				case MessagePackValueTypeCode.Boolean:
				{
					packer.Pack(this._obj.InternalValue != 0);
					return;
				}
				default:
				{
					throw new SerializationException("Failed to pack this object.");
				}
			}
		}

#if FEATURE_TAP

		/// <summary>
		///		Packs this object contents to the specified <see cref="Packer"/> asynchronously.
		/// </summary>
		/// <param name="packer"><see cref="Packer" />.</param>
		/// <param name="options">Packing options. This value can be null.</param>
		/// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is <see cref="CancellationToken.None" />.</param>
		/// <returns>
		///		A <see cref="Task" /> that represents the asynchronous operation.
		/// </returns>
		/// <exception cref="System.ArgumentNullException">packer</exception>
		/// <exception cref="System.Runtime.Serialization.SerializationException">
		///		Failed to serialize this object.
		/// </exception>
		public async Task PackToMessageAsync(Packer packer, PackingOptions options, CancellationToken cancellationToken)
		{
			if (packer == null)
			{
				throw new ArgumentNullException("packer");
			}

			await PackToMessageAsync(this._obj, packer, options, cancellationToken);
		}

		private static async Task PackToMessageAsync(MessagePackObject obj, Packer packer, PackingOptions options, CancellationToken cancellationToken)
		{
			if (obj.InternalHandleOrTypeCode == null)
			{
				await packer.PackNullAsync(cancellationToken).ConfigureAwait(false);
				return;
			}

			var typeCode = obj.InternalHandleOrTypeCode as ValueTypeCode;
			if (typeCode == null)
			{
				MessagePackString asString;
				IList<MessagePackObject> asList;
				IDictionary<MessagePackObject, MessagePackObject> asDictionary;
				byte[] asExtendedTypeObjectBody;
				if ((asString = obj.InternalHandleOrTypeCode as MessagePackString) != null)
				{
					if (asString.GetUnderlyingType() == typeof(string) || (packer.CompatibilityOptions & PackerCompatibilityOptions.PackBinaryAsRaw) != 0)
					{
						await packer.PackRawAsync(asString.GetByteArray(), cancellationToken).ConfigureAwait(false);
					}
					else
					{
						await packer.PackBinaryAsync(asString.GetByteArray(), cancellationToken).ConfigureAwait(false);
					}
				}
				else if ((asList = obj.InternalHandleOrTypeCode as IList<MessagePackObject>) != null)
				{
					await packer.PackArrayHeaderAsync(asList.Count, cancellationToken).ConfigureAwait(false);
					foreach (var item in asList)
					{
						await PackToMessageAsync(item, packer, options, cancellationToken).ConfigureAwait(false);
					}
				}
				else if ((asDictionary = obj.InternalHandleOrTypeCode as IDictionary<MessagePackObject, MessagePackObject>) != null)
				{
					await packer.PackMapHeaderAsync(asDictionary.Count, cancellationToken).ConfigureAwait(false);
					foreach (var item in asDictionary)
					{
						await PackToMessageAsync(item.Key, packer, options, cancellationToken).ConfigureAwait(false);
						await PackToMessageAsync(item.Value, packer, options, cancellationToken).ConfigureAwait(false);
					}
				}
				// ReSharper disable once ConditionIsAlwaysTrueOrFalse
				// ReSharper disable HeuristicUnreachableCode
				else if ((asExtendedTypeObjectBody = obj.InternalHandleOrTypeCode as byte[]) != null)
				{
					await packer.PackExtendedTypeValueAsync(unchecked((byte)obj.InternalValue), asExtendedTypeObjectBody, cancellationToken).ConfigureAwait(false);
				}
				// ReSharper restore HeuristicUnreachableCode
				else
				{
					throw new SerializationException("Failed to pack this object.");
				}

				return;
			}

			switch (typeCode.TypeCode)
			{
				case MessagePackValueTypeCode.Single:
				{
					await packer.PackAsync((float)obj, cancellationToken).ConfigureAwait(false);
					return;
				}
				case MessagePackValueTypeCode.Double:
				{
					await packer.PackAsync((double)obj, cancellationToken).ConfigureAwait(false);
					return;
				}
				case MessagePackValueTypeCode.Int8:
				{
					await packer.PackAsync((sbyte)obj, cancellationToken).ConfigureAwait(false);
					return;
				}
				case MessagePackValueTypeCode.Int16:
				{
					await packer.PackAsync((short)obj, cancellationToken).ConfigureAwait(false);
					return;
				}
				case MessagePackValueTypeCode.Int32:
				{
					await packer.PackAsync((int)obj, cancellationToken).ConfigureAwait(false);
					return;
				}
				case MessagePackValueTypeCode.Int64:
				{
					await packer.PackAsync((long)obj, cancellationToken).ConfigureAwait(false);
					return;
				}
				case MessagePackValueTypeCode.UInt8:
				{
					await packer.PackAsync((byte)obj, cancellationToken).ConfigureAwait(false);
					return;
				}
				case MessagePackValueTypeCode.UInt16:
				{
					await packer.PackAsync((ushort)obj, cancellationToken).ConfigureAwait(false);
					return;
				}
				case MessagePackValueTypeCode.UInt32:
				{
					await packer.PackAsync((uint)obj, cancellationToken).ConfigureAwait(false);
					return;
				}
				case MessagePackValueTypeCode.UInt64:
				{
					await packer.PackAsync(obj.InternalValue, cancellationToken).ConfigureAwait(false);
					return;
				}
				case MessagePackValueTypeCode.Boolean:
				{
					await packer.PackAsync(obj.InternalValue != 0, cancellationToken).ConfigureAwait(false);
					return;
				}
				default:
				{
					throw new SerializationException("Failed to pack this object.");
				}
			}
		}

#endif // FEATURE_TAP
	}
}
