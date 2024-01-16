﻿/*
*  Copyright 2023 MASES s.r.l.
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

using Java.Util;
using MASES.JCOBridge.C2JBridge;
using MASES.JCOBridge.C2JBridge.JVMInterop;
using MASES.KNet.Serialization;
using System;
using System.Collections.Generic;

namespace MASES.KNet.Streams.State
{
    /// <summary>
    /// KNet implementation of <see cref="Org.Apache.Kafka.Streams.State.KeyValueIterator{K, V}"/> 
    /// </summary>
    /// <typeparam name="TKey">The key type</typeparam>
    /// <typeparam name="TValue">The value type</typeparam>
    public class KNetTimestampedKeyValueIterator<TKey, TValue> : IGenericSerDesFactoryApplier
    {
        class LocalEnumerator(bool isVersion2, IGenericSerDesFactory factory, IJavaObject obj) : JVMBridgeBaseEnumerator<KNetTimestampedKeyValue<TKey, TValue>>(obj), IGenericSerDesFactoryApplier
        {
            IGenericSerDesFactory _factory = factory;
            IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

            protected override object ConvertObject(object input)
            {
                if (input is IJavaObject obj)
                {
                    return isVersion2 ? new KNetTimestampedKeyValue<TKey, TValue>(_factory, JVMBridgeBase.Wraps<Org.Apache.Kafka.Streams.KeyValue<long, Org.Apache.Kafka.Streams.State.ValueAndTimestamp<byte[]>>>(obj))
                                      : new KNetTimestampedKeyValue<TKey, TValue>(_factory, JVMBridgeBase.Wraps<Org.Apache.Kafka.Streams.KeyValue<byte[], Org.Apache.Kafka.Streams.State.ValueAndTimestamp<byte[]>>>(obj));
                }
                throw new InvalidCastException($"input is not a valid IJavaObject");
            }
        }

        readonly Org.Apache.Kafka.Streams.State.KeyValueIterator<byte[], Org.Apache.Kafka.Streams.State.ValueAndTimestamp<byte[]>> _iterator = null;
        readonly Org.Apache.Kafka.Streams.State.KeyValueIterator<long, Org.Apache.Kafka.Streams.State.ValueAndTimestamp<byte[]>> _iterator2 = null;
        readonly IKNetSerDes<TKey> _keySerDes;
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

        internal KNetTimestampedKeyValueIterator(IGenericSerDesFactory factory, Org.Apache.Kafka.Streams.State.KeyValueIterator<byte[], Org.Apache.Kafka.Streams.State.ValueAndTimestamp<byte[]>> iterator)
        {
            _factory = factory;
            _keySerDes = _factory.BuildKeySerDes<TKey>();
            _iterator = iterator;
        }

        internal KNetTimestampedKeyValueIterator(IGenericSerDesFactory factory, Org.Apache.Kafka.Streams.State.KeyValueIterator<long, Org.Apache.Kafka.Streams.State.ValueAndTimestamp<byte[]>> iterator)
        {
            _factory = factory;
            _keySerDes = _factory.BuildKeySerDes<TKey>();
            _iterator2 = iterator;
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
            get { return new KNetTimestampedKeyValue<TKey, TValue>(_factory, _iterator.Next); }
        }
        /// <summary>
        /// <see href="https://docs.oracle.com/en/java/javase/11/docs/api/java.base/java/util/Iterator.html#remove()"/>
        /// </summary>
        public void Remove()
        {
            _iterator.Remove();
        }
        /// <summary>
        /// Converts an <see cref="Iterator{E}"/> to a <see cref="IEnumerator{E}"/>
        /// </summary>
        public IEnumerator<KNetTimestampedKeyValue<TKey, TValue>> ToIEnumerator() => _iterator != null ? new LocalEnumerator(false, _factory, _iterator.BridgeInstance) : new LocalEnumerator(true, _factory, _iterator2.BridgeInstance);
        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/KeyValueIterator.html#peekNextKey--"/>
        /// </summary>
        /// <returns><typeparamref name="TKey"/></returns>
        public TKey PeekNextKey
        {
            get
            {
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
