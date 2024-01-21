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
    public class KNetTimestampedKeyValueIterator<TKey, TValue> : CommonIterator<KNetTimestampedKeyValue<TKey, TValue>>
    {
#if NET7_0_OR_GREATER
        class PrefetchableLocalEnumerator(bool isVersion2,
                                          IGenericSerDesFactory factory,
                                          IJavaObject obj,
                                          IKNetSerDes<TKey> keySerDes,
                                          bool isAsync, CancellationToken token = default)
            : JVMBridgeBasePrefetchableEnumerator<KNetTimestampedKeyValue<TKey, TValue>>(obj, new PrefetchableEnumeratorSettings()),
              IGenericSerDesFactoryApplier,
              IAsyncEnumerator<KNetTimestampedKeyValue<TKey, TValue>>
        {
            readonly bool _isVersion2 = isVersion2;
            IGenericSerDesFactory _factory = factory;
            IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

            protected override object ConvertObject(object input)
            {
                if (input is IJavaObject obj)
                {
                    return _isVersion2 ? new KNetTimestampedKeyValue<TKey, TValue>(factory,
                                                                                   JVMBridgeBase.Wraps<Org.Apache.Kafka.Streams.KeyValue<Java.Lang.Long, Org.Apache.Kafka.Streams.State.ValueAndTimestamp<byte[]>>>(obj),
                                                                                   keySerDes, true)
                                       : new KNetTimestampedKeyValue<TKey, TValue>(factory,
                                                                                   JVMBridgeBase.Wraps<Org.Apache.Kafka.Streams.KeyValue<byte[], Org.Apache.Kafka.Streams.State.ValueAndTimestamp<byte[]>>>(obj),
                                                                                   keySerDes, true);
                }
                throw new InvalidCastException($"input is not a valid IJavaObject");
            }
            protected override bool DoWorkCycle()
            {
                return isAsync ? !token.IsCancellationRequested : base.DoWorkCycle();
            }

            public KNetTimestampedKeyValue<TKey, TValue> Current => (this as IEnumerator<KNetTimestampedKeyValue<TKey, TValue>>).Current;

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
        class StandardLocalEnumerator : JVMBridgeBaseEnumerator<KNetTimestampedKeyValue<TKey, TValue>>, IGenericSerDesFactoryApplier, IAsyncEnumerator<KNetTimestampedKeyValue<TKey, TValue>>
        {
            IKNetSerDes<TKey> _keySerDes = null;
            readonly bool _isVersion2;
            IGenericSerDesFactory _factory;
            IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

            public StandardLocalEnumerator(bool isVersion2,
                                           IGenericSerDesFactory factory,
                                           IJavaObject obj,
                                           IKNetSerDes<TKey> keySerDes)
                : base(obj)
            {
                _isVersion2 = isVersion2;
                _factory = factory;
                _keySerDes = keySerDes;
            }

            protected override object ConvertObject(object input)
            {
                if (input is IJavaObject obj)
                {
                    return _isVersion2 ? new KNetTimestampedKeyValue<TKey, TValue>(_factory,
                                                                                   JVMBridgeBase.Wraps<Org.Apache.Kafka.Streams.KeyValue<Java.Lang.Long, Org.Apache.Kafka.Streams.State.ValueAndTimestamp<byte[]>>>(obj),
                                                                                   _keySerDes, false)
                                       : new KNetTimestampedKeyValue<TKey, TValue>(_factory,
                                                                                   JVMBridgeBase.Wraps<Org.Apache.Kafka.Streams.KeyValue<byte[], Org.Apache.Kafka.Streams.State.ValueAndTimestamp<byte[]>>>(obj),
                                                                                   _keySerDes, false);
                }
                throw new InvalidCastException($"input is not a valid IJavaObject");
            }

            public KNetTimestampedKeyValue<TKey, TValue> Current => (this as IEnumerator<KNetTimestampedKeyValue<TKey, TValue>>).Current;

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

        readonly Org.Apache.Kafka.Streams.State.KeyValueIterator<byte[], Org.Apache.Kafka.Streams.State.ValueAndTimestamp<byte[]>> _iterator = null;
        readonly Org.Apache.Kafka.Streams.State.KeyValueIterator<Java.Lang.Long, Org.Apache.Kafka.Streams.State.ValueAndTimestamp<byte[]>> _iterator2 = null;
        IKNetSerDes<TKey> _keySerDes;

        internal KNetTimestampedKeyValueIterator(IGenericSerDesFactory factory, Org.Apache.Kafka.Streams.State.KeyValueIterator<byte[], Org.Apache.Kafka.Streams.State.ValueAndTimestamp<byte[]>> iterator)
            : base(factory)
        {
            _iterator = iterator;
        }

        internal KNetTimestampedKeyValueIterator(IGenericSerDesFactory factory, Org.Apache.Kafka.Streams.State.KeyValueIterator<Java.Lang.Long, Org.Apache.Kafka.Streams.State.ValueAndTimestamp<byte[]>> iterator)
            : base(factory)
        {
            _iterator2 = iterator;
        }

        /// <inheritdoc/>
        protected override object GetEnumerator(bool isAsync, CancellationToken cancellationToken = default)
        {
            _keySerDes ??= _factory.BuildKeySerDes<TKey>();
#if NET7_0_OR_GREATER
            if (UsePrefetch)
            {
                return _iterator != null ? new PrefetchableLocalEnumerator(false, _factory, _iterator.BridgeInstance, _keySerDes, isAsync, cancellationToken)
                                         : new PrefetchableLocalEnumerator(true, _factory, _iterator2.BridgeInstance, _keySerDes, isAsync, cancellationToken);
            }
#endif
            return _iterator != null ? new StandardLocalEnumerator(false, _factory, _iterator.BridgeInstance, _keySerDes)
                                     : new StandardLocalEnumerator(true, _factory, _iterator2.BridgeInstance, _keySerDes);
        }
        /// <summary>
        /// KNet implementation of <see href="https://docs.oracle.com/en/java/javase/11/docs/api/java.base/java/util/Iterator.html#hasNext()"/> 
        /// </summary>
        public bool HasNext => _iterator.HasNext;
        /// <summary>
        /// KNet implementation of <see href="https://docs.oracle.com/en/java/javase/11/docs/api/java.base/java/util/Iterator.html#next()"/> 
        /// </summary>
        public KNetTimestampedKeyValue<TKey, TValue> Next
        {
            get
            {
                _keySerDes ??= _factory.BuildKeySerDes<TKey>();
                return new KNetTimestampedKeyValue<TKey, TValue>(_factory, _iterator.Next, _keySerDes, false);
            }
        }
        /// <summary>
        /// <see href="https://docs.oracle.com/en/java/javase/11/docs/api/java.base/java/util/Iterator.html#remove()"/>
        /// </summary>
        public void Remove()
        {
            _iterator.Remove();
        }
        /// <summary>
        /// Returns an <see cref="IEnumerator{E}"/> of <see cref="KNetTimestampedKeyValue{TKey, TValue}"/>
        /// </summary>
        /// <param name="usePrefetch"><see langword="true"/> to return an <see cref="IEnumerator{T}"/> making preparation of <see cref="KNetTimestampedKeyValue{TKey, TValue}"/> in parallel</param>
        /// <returns>An <see cref="IEnumerator{T}"/> of <see cref="KNetTimestampedKeyValue{TKey, TValue}"/></returns>
        /// <remarks><paramref name="usePrefetch"/> is not considered with .NET 6 and .NET Framework</remarks>
        public IEnumerator<KNetTimestampedKeyValue<TKey, TValue>> ToIEnumerator(bool usePrefetch = true)
        {
            UsePrefetch = usePrefetch;
            return GetEnumerator(false) as IEnumerator<KNetTimestampedKeyValue<TKey, TValue>>;
        }
        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/KeyValueIterator.html#peekNextKey--"/>
        /// </summary>
        /// <returns><typeparamref name="TKey"/></returns>
        public TKey PeekNextKey
        {
            get
            {
                _keySerDes ??= _factory.BuildKeySerDes<TKey>();
                var kk = _iterator.PeekNextKey();
                return _keySerDes.Deserialize(null, kk);
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
