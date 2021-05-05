// Copyright (c) FUJIWARA, Yusuke and all contributors.
// This file is licensed under Apache2 license.
// See the LICENSE in the project root for more information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace MsgPack
{
	public partial class MessagePackObjectDictionary
	{
		/// <summary>
		///		Enumerates the elements of a <see cref="MessagePackObjectDictionary"/> in order.
		/// </summary>
		public struct Enumerator : IEnumerator<KeyValuePair<MessagePackObject, MessagePackObject>>, IDictionaryEnumerator
		{
			private const int BeforeHead = -1;
			private const int IsDictionary = -2;
			private const int End = -3;

			private readonly MessagePackObjectDictionary _underlying;
			private Dictionary<MessagePackObject, MessagePackObject>.Enumerator _enumerator;
			private KeyValuePair<MessagePackObject, MessagePackObject> _current;
			private int _position;
			private int _initialVersion;

			/// <summary>
			///		Gets the element at the current position of the enumerator.
			/// </summary>
			/// <value>
			///		The element in the underlying collection at the current position of the enumerator.
			/// </value>
			public KeyValuePair<MessagePackObject, MessagePackObject> Current
			{
				get
				{
					this.VerifyVersion();
					return this._current;
				}
			}

			/// <summary>
			///		Gets the element at the current position of the enumerator.
			/// </summary>
			/// <value>
			///		The element in the collection at the current position of the enumerator, as an <see cref="Object"/>.
			/// </value>
			/// <exception cref="InvalidOperationException">
			///		The enumerator is positioned before the first element of the collection or after the last element. 
			/// </exception>
			object IEnumerator.Current
			{
				get { return this.GetCurrentStrict(); }
			}

			DictionaryEntry IDictionaryEnumerator.Entry
			{
				get
				{
					var entry = this.GetCurrentStrict();
					return new DictionaryEntry(entry.Key, entry.Value);
				}
			}

			object IDictionaryEnumerator.Key
			{
				get { return this.GetCurrentStrict().Key; }
			}

			object IDictionaryEnumerator.Value
			{
				get { return this.GetCurrentStrict().Value; }
			}

			internal KeyValuePair<MessagePackObject, MessagePackObject> GetCurrentStrict()
			{
				this.VerifyVersion();

				if (this._position == BeforeHead || this._position == End)
				{
					throw new InvalidOperationException("The enumerator is positioned before the first element of the collection or after the last element.");
				}

				return this._current;
			}

			internal Enumerator(MessagePackObjectDictionary dictionary)
				: this()
			{
				Debug.Assert(dictionary != null, "dictionary != null");

				this = default(Enumerator);
				this._underlying = dictionary;
				this.ResetCore();
			}

			internal void VerifyVersion()
			{
				if (this._underlying != null && this._underlying._version != this._initialVersion)
				{
					throw new InvalidOperationException("The collection was modified after the enumerator was created.");
				}
			}

			/// <summary>
			///		Releases all resources used by the this instance.
			/// </summary>
			public void Dispose()
			{
				this._enumerator.Dispose();
			}

			/// <summary>
			///		Advances the enumerator to the next element of the underlying collection.
			/// </summary>
			/// <returns>
			///		<c>true</c> if the enumerator was successfully advanced to the next element; 
			///		<c>false</c> if the enumerator has passed the end of the collection.
			/// </returns>
			/// <exception cref="T:System.InvalidOperationException">
			///		The collection was modified after the enumerator was created. 
			///	</exception>
			public bool MoveNext()
			{
				if (this._position == End)
				{
					return false;
				}

				if (this._position == IsDictionary)
				{
					if (!this._enumerator.MoveNext())
					{
						return false;
					}

					this._current = this._enumerator.Current;
					return true;
				}

				Debug.Assert(this._underlying._keys != null);
				Debug.Assert(this._underlying._values != null);

				if (this._position == BeforeHead)
				{
					if (this._underlying._keys.Count == 0)
					{
						this._position = End;
						return false;
					}

					// First
					this._position = 0;
				}
				else
				{
					this._position++;
				}

				if (this._position == this._underlying.Count)
				{
					this._position = End;
					return false;
				}

				this._current = new KeyValuePair<MessagePackObject, MessagePackObject>(this._underlying._keys[this._position], this._underlying._values[this._position]);
				return true;
			}

			/// <summary>
			///		Sets the enumerator to its initial position, which is before the first element in the collection.
			/// </summary>
			/// <exception cref="T:System.InvalidOperationException">
			///		The collection was modified after the enumerator was created. 
			///	</exception>
			void IEnumerator.Reset()
			{
				this.ResetCore();
			}

			internal void ResetCore()
			{
				this._initialVersion = this._underlying._version;
				this._current = default(KeyValuePair<MessagePackObject, MessagePackObject>);
				this._initialVersion = this._underlying._version;
				if (this._underlying._dictionary != null)
				{
					this._enumerator = this._underlying._dictionary.GetEnumerator();
					this._position = IsDictionary;
				}
				else
				{
					this._position = BeforeHead;
				}
			}
		}

		/// <summary>
		///		Enumerates the elements of a <see cref="MessagePackObjectDictionary"/> in order.
		/// </summary>
		private struct DictionaryEnumerator : IDictionaryEnumerator
		{
			private readonly IDictionaryEnumerator _underlying;

			/// <summary>
			///		Gets the element at the current position of the enumerator.
			/// </summary>
			/// <value>
			///		The element in the collection at the current position of the enumerator, as an <see cref="Object"/>.
			/// </value>
			/// <exception cref="InvalidOperationException">
			///		The enumerator is positioned before the first element of the collection or after the last element. 
			/// </exception>
			public object Current => this._underlying.Entry;

			/// <summary>
			///		Gets the element at the current position of the enumerator.
			/// </summary>
			/// <returns>
			///		The element in the dictionary at the current position of the enumerator, as a <see cref="T:System.Collections.DictionaryEntry"/>.
			///	</returns>
			/// <exception cref="T:System.InvalidOperationException">
			///		The enumerator is positioned before the first element of the collection or after the last element. 
			///	</exception>
			public DictionaryEntry Entry => this._underlying.Entry;

			/// <summary>
			///		Gets the key of the element at the current position of the enumerator.
			/// </summary>
			/// <returns>
			///		The key of the element in the dictionary at the current position of the enumerator.
			/// </returns>
			/// <exception cref="T:System.InvalidOperationException">
			///		The enumerator is positioned before the first element of the collection or after the last element. 
			///	</exception>
			public object Key => this.Entry.Key;

			/// <summary>
			///		Gets the value of the element at the current position of the enumerator.
			/// </summary>
			/// <returns>
			///		The value of the element in the dictionary at the current position of the enumerator.
			/// </returns>
			/// <exception cref="T:System.InvalidOperationException">
			///		The enumerator is positioned before the first element of the collection or after the last element. 
			///	</exception>
			public object? Value => this.Entry.Value;

			internal DictionaryEnumerator(MessagePackObjectDictionary dictionary)
				: this()
			{
				Debug.Assert(dictionary != null, "dictionary != null");

				this._underlying = new Enumerator(dictionary);
			}

			/// <summary>
			///		Advances the enumerator to the next element of the underlying collection.
			/// </summary>
			/// <returns>
			///		<c>true</c> if the enumerator was successfully advanced to the next element; 
			///		<c>false</c> if the enumerator has passed the end of the collection.
			/// </returns>
			/// <exception cref="T:System.InvalidOperationException">
			///		The collection was modified after the enumerator was created. 
			///	</exception>
			public bool MoveNext() => this._underlying.MoveNext();

			/// <summary>
			///		Sets the enumerator to its initial position, which is before the first element in the collection.
			/// </summary>
			/// <exception cref="T:System.InvalidOperationException">
			///		The collection was modified after the enumerator was created. 
			///	</exception>
			void IEnumerator.Reset() => this._underlying.Reset();
		}
	}
}
