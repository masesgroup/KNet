/*
*  Copyright (c) 2021-2026 MASES s.r.l.
*
*  Licensed under the Apache License, Version 2.0 (the "License");
*  you may not use this file except in compliance with the License.
*  You may obtain a copy of the License at
*
*  http://www.apache.org/licenses/LICENSE-2.0
*
*  Unless required by applicable law or agreed to in writing, software
*  distributed under the License is distributed on an "AS IS" BASIS,
*  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
*  See the License for the specific language governing permissions and
*  limitations under the License.
*
*  Refer to LICENSE for more information.
*/

using MASES.KNet.Serialization;
using System;

namespace MASES.KNet.Streams.Kstream
{
    /// <summary>
    /// KNet implementation of <see cref="Org.Apache.Kafka.Streams.Kstream.Windowed{K}"/>
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
    public class Windowed<K, TJVMK> : IGenericSerDesFactoryApplier, IDisposable
    {
        readonly Org.Apache.Kafka.Streams.Kstream.Windowed<TJVMK> _inner;
        ISerDes<K, TJVMK> _keySerDes = null;
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set => _factory = value; }

        internal Windowed(IGenericSerDesFactory factory, Org.Apache.Kafka.Streams.Kstream.Windowed<TJVMK> windowed)
        {
            _factory = factory;
            _inner = windowed;
        }

        #region IDisposable

        readonly object _lock = new object();
        bool _disposed = false;
        /// <summary>
        /// Test if this instance was disposed
        /// </summary>
        /// <exception cref="ObjectDisposedException">When this instance was disposed</exception>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        protected void CheckDisposed() { lock (_lock) { if (_disposed) throw new ObjectDisposedException(nameof(Windowed<K, TJVMK>)); } }
        /// <inheritdoc cref="IDisposable.Dispose"/>
        public void Dispose()
        {
            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Implements the pattern described in https://learn.microsoft.com/en-en/dotnet/standard/garbage-collection/implementing-dispose
        /// </summary>
        /// <param name="disposing">The disposing parameter is a <see langword="bool"/> that indicates whether the method call comes from a <see cref="IDisposable.Dispose"/> method (its value is <see langword="true"/>) or from a finalizer (its value is <see langword="false"/>)</param>
        protected virtual void Dispose(bool disposing)
        {
            lock (_lock)
            {
                if (_disposed)
                {
                    return;
                }

                if (disposing)
                {
                    _inner?.Dispose();
                }

                _disposed = true;
            }
        }

        #endregion

        /// <summary>
        /// Converter from <see cref="Windowed{K, TJVMK}"/> to <see cref="Org.Apache.Kafka.Streams.Kstream.Windowed{K}"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.Kstream.Windowed<TJVMK>(Windowed<K, TJVMK> t) => t._inner;

        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.2.0/org/apache/kafka/streams/kstream/Windowed.html#key()"/>
        /// </summary>
        /// <returns><typeparamref name="K"/></returns>
        public K Key { get { CheckDisposed(); _keySerDes ??= _factory?.BuildKeySerDes<K, TJVMK>(); return _keySerDes.Deserialize(null, _inner.Key()); } }
        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.2.0/org/apache/kafka/streams/kstream/Windowed.html#window()"/>
        /// </summary>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Window"/></returns>
        public Org.Apache.Kafka.Streams.Kstream.Window Window
        {
            get
            {
                CheckDisposed(); return _inner.Window();
            }
        }
    }
}
