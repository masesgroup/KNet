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

using MASES.JCOBridge.C2JBridge;
using MASES.KNet.Serialization;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MASES.KNet.Consumer
{
    sealed class ConsumerRecordsEnumerator<K, V, TJVMK, TJVMV> : IKNetInnerReference<Org.Apache.Kafka.Clients.Consumer.ConsumerRecords<TJVMK, TJVMV>>, IEnumerator<ConsumerRecord<K, V, TJVMK, TJVMV>>, IAsyncEnumerator<ConsumerRecord<K, V, TJVMK, TJVMV>>
    {
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        static ConsumerRecordsEnumerator<K, V, TJVMK, TJVMV> Allocate() => new ConsumerRecordsEnumerator<K, V, TJVMK, TJVMV>();
        static JCOBridgeObjectPool<ConsumerRecordsEnumerator<K, V, TJVMK, TJVMV>> _pool = new JCOBridgeObjectPool<ConsumerRecordsEnumerator<K, V, TJVMK, TJVMV>>(Allocate);

        IDeserializer<K, TJVMK> _keyDeserializer;
        IDeserializer<V, TJVMV> _valueDeserializer;
        CancellationToken _cancellationToken;
        Org.Apache.Kafka.Clients.Consumer.ConsumerRecords<TJVMK, TJVMV> _records;
        IEnumerator<Org.Apache.Kafka.Clients.Consumer.ConsumerRecord<TJVMK, TJVMV>> _recordEnumerator;
        IAsyncEnumerator<Org.Apache.Kafka.Clients.Consumer.ConsumerRecord<TJVMK, TJVMV>> _recordAsyncEnumerator;

        internal static ConsumerRecordsEnumerator<K, V, TJVMK, TJVMV> Create(Org.Apache.Kafka.Clients.Consumer.ConsumerRecords<TJVMK, TJVMV> records, IDeserializer<K, TJVMK> keyDeserializer, IDeserializer<V, TJVMV> valueDeserializer)
        {
            bool fromPool = false;
            var instance = _pool.Rent(ref fromPool);
            instance.Setup(records, keyDeserializer, valueDeserializer, fromPool);
            return instance;
        }

        void Setup(Org.Apache.Kafka.Clients.Consumer.ConsumerRecords<TJVMK, TJVMV> records, IDeserializer<K, TJVMK> keyDeserializer, IDeserializer<V, TJVMV> valueDeserializer, bool fromPool)
        {
            if (fromPool)
            {
                _disposed = 0;
                GC.ReRegisterForFinalize(this);
            }
            _records = records;
            _recordEnumerator = _records.GetEnumerator();
            _keyDeserializer = keyDeserializer;
            _valueDeserializer = valueDeserializer;
        }

        internal static ConsumerRecordsEnumerator<K, V, TJVMK, TJVMV> Create(Org.Apache.Kafka.Clients.Consumer.ConsumerRecords<TJVMK, TJVMV> records, IDeserializer<K, TJVMK> keyDeserializer, IDeserializer<V, TJVMV> valueDeserializer, CancellationToken cancellationToken)
        {
            bool fromPool = false;
            var instance = _pool.Rent(ref fromPool);
            instance.Setup(records, keyDeserializer, valueDeserializer, cancellationToken, fromPool);
            return instance;
        }

        void Setup(Org.Apache.Kafka.Clients.Consumer.ConsumerRecords<TJVMK, TJVMV> records, IDeserializer<K, TJVMK> keyDeserializer, IDeserializer<V, TJVMV> valueDeserializer, CancellationToken cancellationToken, bool fromPool)
        {
            if (fromPool)
            {
                _disposed = 0;
                GC.ReRegisterForFinalize(this);
            }
            _records = records;
            _recordAsyncEnumerator = _records.GetAsyncEnumerator(cancellationToken);
            _keyDeserializer = keyDeserializer;
            _valueDeserializer = valueDeserializer;
            _cancellationToken = cancellationToken;
        }

        /// <inheritdoc/>
        public Org.Apache.Kafka.Clients.Consumer.ConsumerRecords<TJVMK, TJVMV> InnerReference => _records;

        ConsumerRecord<K, V, TJVMK, TJVMV> IAsyncEnumerator<ConsumerRecord<K, V, TJVMK, TJVMV>>.Current => ConsumerRecord<K, V, TJVMK, TJVMV>.Create(_recordAsyncEnumerator.Current, _keyDeserializer, _valueDeserializer, false);

        ConsumerRecord<K, V, TJVMK, TJVMV> IEnumerator<ConsumerRecord<K, V, TJVMK, TJVMV>>.Current => ConsumerRecord<K, V, TJVMK, TJVMV>.Create(_recordEnumerator.Current, _keyDeserializer, _valueDeserializer, false);

        object System.Collections.IEnumerator.Current => (_recordEnumerator as System.Collections.IEnumerator)?.Current;

        volatile int _disposed; // 0 = live, 1 = disposed
        /// <summary>
        /// Test if this instance was disposed
        /// </summary>
        /// <exception cref="ObjectDisposedException">When this instance was disposed</exception>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        void CheckDisposed() { if (_disposed != 0) throw new ObjectDisposedException(GetType().Name); }
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
        void Dispose(bool disposing)
        {
            if (Interlocked.Exchange(ref _disposed, 1) != 0)
                return;

            if (disposing)
            {
                _recordEnumerator?.Dispose();
                _recordAsyncEnumerator?.DisposeAsync();
                _records = null;
                _keyDeserializer = null;
                _valueDeserializer = null;
                _pool.Return(this);
            }
        }

        public ValueTask DisposeAsync()
        {
            CheckDisposed();
            return _recordAsyncEnumerator.DisposeAsync();
        }

        public bool MoveNext()
        {
            CheckDisposed();
            return _recordEnumerator.MoveNext();
        }

        public ValueTask<bool> MoveNextAsync()
        {
            CheckDisposed();
            return _recordAsyncEnumerator.MoveNextAsync();
        }

        public void Reset()
        {
            CheckDisposed();
            _recordEnumerator = _records.GetEnumerator();
        }
    }
}
