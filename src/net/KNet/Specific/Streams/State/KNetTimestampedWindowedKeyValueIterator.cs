/*
*  Copyright 2024 MASES s.r.l.
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
using MASES.JCOBridge.C2JBridge.JVMInterop;
using MASES.KNet.Serialization;
using MASES.KNet.Streams.Kstream;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MASES.KNet.Streams.State
{
    /// <summary>
    /// KNet implementation of <see cref="Org.Apache.Kafka.Streams.State.KeyValueIterator{K, V}"/> 
    /// </summary>
    /// <typeparam name="TKey">The key type</typeparam>
    /// <typeparam name="TValue">The value type</typeparam>
    public class KNetTimestampedWindowedKeyValueIterator<TKey, TValue> : CommonIterator<KNetTimestampedWindowedKeyValue<TKey, TValue>>
    {
#if NET7_0_OR_GREATER
        class PrefetchableLocalEnumerator(IGenericSerDesFactory factory,
                                          IJavaObject obj,
                                          bool isAsync, CancellationToken token = default)
            : JVMBridgeBasePrefetchableEnumerator<KNetTimestampedWindowedKeyValue<TKey, TValue>>(obj, new PrefetchableEnumeratorSettings()),
              IGenericSerDesFactoryApplier,
              IAsyncEnumerator<KNetTimestampedWindowedKeyValue<TKey, TValue>>
        {
            IGenericSerDesFactory _factory = factory;
            IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

            protected override object ConvertObject(object input)
            {
                if (input is IJavaObject obj)
                {
                    return new KNetTimestampedWindowedKeyValue<TKey, TValue>(factory, JVMBridgeBase.Wraps<Org.Apache.Kafka.Streams.KeyValue<Org.Apache.Kafka.Streams.Kstream.Windowed<byte[]>, Org.Apache.Kafka.Streams.State.ValueAndTimestamp<byte[]>>>(obj));
                }
                throw new InvalidCastException($"input is not a valid IJavaObject");
            }

            protected override bool DoWorkCycle()
            {
                return isAsync ? !token.IsCancellationRequested : base.DoWorkCycle();
            }

            public KNetTimestampedWindowedKeyValue<TKey, TValue> Current => (this as IEnumerator<KNetTimestampedWindowedKeyValue<TKey, TValue>>).Current;

            public ValueTask<bool> MoveNextAsync()
            {
                return new ValueTask<bool>(MoveNext());
            }

            public ValueTask DisposeAsync()
            {
                Dispose();
                return new ValueTask();
            }
        }
#endif

        class StandardLocalEnumerator : JVMBridgeBaseEnumerator<KNetTimestampedWindowedKeyValue<TKey, TValue>>, IGenericSerDesFactoryApplier, IAsyncEnumerator<KNetTimestampedWindowedKeyValue<TKey, TValue>>
        {
            IGenericSerDesFactory _factory;
            IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

            public StandardLocalEnumerator(IGenericSerDesFactory factory, IJavaObject obj) : base(obj)
            {
                _factory = factory;
            }

            protected override object ConvertObject(object input)
            {
                if (input is IJavaObject obj)
                {
                    return new KNetTimestampedWindowedKeyValue<TKey, TValue>(_factory, JVMBridgeBase.Wraps<Org.Apache.Kafka.Streams.KeyValue<Org.Apache.Kafka.Streams.Kstream.Windowed<byte[]>, Org.Apache.Kafka.Streams.State.ValueAndTimestamp<byte[]>>>(obj));
                }
                throw new InvalidCastException($"input is not a valid IJavaObject");
            }

            public KNetTimestampedWindowedKeyValue<TKey, TValue> Current => (this as IEnumerator<KNetTimestampedWindowedKeyValue<TKey, TValue>>).Current;

            public ValueTask<bool> MoveNextAsync()
            {
                return new ValueTask<bool>(MoveNext());
            }

            public ValueTask DisposeAsync()
            {
                Dispose();
                return new ValueTask();
            }
        }

        readonly Org.Apache.Kafka.Streams.State.KeyValueIterator<Org.Apache.Kafka.Streams.Kstream.Windowed<byte[]>, Org.Apache.Kafka.Streams.State.ValueAndTimestamp<byte[]>> _iterator;

        internal KNetTimestampedWindowedKeyValueIterator(IGenericSerDesFactory factory, Org.Apache.Kafka.Streams.State.KeyValueIterator<Org.Apache.Kafka.Streams.Kstream.Windowed<byte[]>, Org.Apache.Kafka.Streams.State.ValueAndTimestamp<byte[]>> iterator)
            :base(factory)
        {
            _iterator = iterator;
        }

        /// <inheritdoc/>
        protected override object GetEnumerator(bool isAsync, CancellationToken cancellationToken = default)
        {
#if NET7_0_OR_GREATER
            if (UsePrefetch)
            {
                return new PrefetchableLocalEnumerator(_factory, _iterator.BridgeInstance, isAsync, cancellationToken);
            }
#endif
            return new StandardLocalEnumerator(_factory, _iterator.BridgeInstance);
        }
        /// <summary>
        /// KNet implementation of <see href="https://docs.oracle.com/en/java/javase/11/docs/api/java.base/java/util/Iterator.html#hasNext()"/> 
        /// </summary>
        public bool HasNext => _iterator.HasNext;
        /// <summary>
        /// KNet implementation of <see href="https://docs.oracle.com/en/java/javase/11/docs/api/java.base/java/util/Iterator.html#next()"/> 
        /// </summary>
        public KNetTimestampedWindowedKeyValue<TKey, TValue> Next
        {
            get { return new KNetTimestampedWindowedKeyValue<TKey, TValue>(_factory, _iterator.Next); }
        }
        /// <summary>
        /// <see href="https://docs.oracle.com/en/java/javase/11/docs/api/java.base/java/util/Iterator.html#remove()"/>
        /// </summary>
        public void Remove()
        {
            _iterator.Remove();
        }
        /// <summary>
        /// Returns an <see cref="IEnumerator{E}"/> of <see cref="KNetTimestampedWindowedKeyValue{TKey, TValue}"/>
        /// </summary>
        /// <param name="usePrefetch"><see langword="true"/> to return an <see cref="IEnumerator{T}"/> making preparation of <see cref="KNetTimestampedWindowedKeyValue{TKey, TValue}"/> in parallel</param>
        /// <returns>An <see cref="IEnumerator{T}"/> of <see cref="KNetTimestampedWindowedKeyValue{TKey, TValue}"/></returns>
        /// <remarks><paramref name="usePrefetch"/> is not considered with .NET 6 and .NET Framework</remarks>
        public IEnumerator<KNetTimestampedWindowedKeyValue<TKey, TValue>> ToIEnumerator(bool usePrefetch = true)
        {
            UsePrefetch = usePrefetch;
            return GetEnumerator(false) as IEnumerator<KNetTimestampedWindowedKeyValue<TKey, TValue>>;
        }
        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/KeyValueIterator.html#peekNextKey--"/>
        /// </summary>
        /// <returns><typeparamref name="TKey"/></returns>
        public KNetWindowed<TKey> PeekNextKey
        {
            get
            {
                var kk = _iterator.PeekNextKey();
                return new KNetWindowed<TKey>(_factory, kk);
            }
        }
        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/KeyValueIterator.html#close--"/>
        /// </summary>
        public void Close()
        {
            _iterator.Close();
        }
    }
}
