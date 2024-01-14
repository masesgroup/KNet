/*
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

using MASES.KNet.Serialization;
using Org.Apache.Kafka.Streams.State;

namespace MASES.KNet.Streams.State
{
    /// <summary>
    /// KNet implementation of <see cref="ReadOnlySessionStore{K, V}"/> 
    /// </summary>
    /// <typeparam name="TKey">The key type</typeparam>
    /// <typeparam name="TValue">The value type</typeparam>
    public class KNetTimestampedKeyValueStore<TKey, TValue> : KNetManagedStore<ReadOnlyKeyValueStore<byte[], ValueAndTimestamp<byte[]>>>, IGenericSerDesFactoryApplier
    {
        readonly ReadOnlyKeyValueStore<byte[], ValueAndTimestamp<byte[]>> _store;
        readonly IKNetSerDes<TKey> _keySerDes;
        readonly IKNetSerDes<TValue> _valueSerDes;
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

        internal KNetTimestampedKeyValueStore(IGenericSerDesFactory factory, ReadOnlyKeyValueStore<byte[], ValueAndTimestamp<byte[]>> store)
        {
            _factory = factory;
            _keySerDes = _factory.BuildKeySerDes<TKey>();
            _valueSerDes = _factory.BuildValueSerDes<TValue>();
            _store = store;
        }

        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyKeyValueStore.html#approximateNumEntries--"/>
        /// </summary>
        /// <returns><see cref="long"/></returns>
        public long ApproximateNumEntries => _store.ApproximateNumEntries();
        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyKeyValueStore.html#all--"/>
        /// </summary>
        /// <returns><see cref="KNetKeyValueIterator{TKey, TValue}"/></returns>
        public KNetTimestampedKeyValueIterator<TKey, TValue> All => new(_factory, _store.All());
        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyKeyValueStore.html#range-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="TKey"/></param>
        /// <param name="arg1"><typeparamref name="TValue"/></param>
        /// <returns><see cref="KNetKeyValueIterator{TKey, TValue}"/></returns>
        public KNetTimestampedKeyValueIterator<TKey, TValue> Range(TKey arg0, TKey arg1)
        {
            var r0 = _keySerDes.Serialize(null, arg0);
            var r1 = _keySerDes.Serialize(null, arg1);

            return new(_factory, _store.Range(r0, r1));
        }
        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyKeyValueStore.html#get-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="TKey"/></param>
        /// <returns><typeparamref name="TValue"/></returns>
        public KNetValueAndTimestamp<TValue> Get(TKey arg0)
        {
            var r0 = _keySerDes.Serialize(null, arg0);
            var res = _store.Get(r0);
            return new KNetValueAndTimestamp<TValue>(_factory, res);
        }
        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyKeyValueStore.html#reverseAll--"/>
        /// </summary>
        /// <returns><see cref="KNetKeyValueIterator{TKey, TValue}"/></returns>
        public KNetTimestampedKeyValueIterator<TKey, TValue> ReverseAll => new(_factory, _store.ReverseAll());
        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyKeyValueStore.html#reverseRange-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="K"/></param>
        /// <param name="arg1"><typeparamref name="K"/></param>
        /// <returns><see cref="KNetKeyValueIterator{TKey, TValue}"/></returns>
        public KNetTimestampedKeyValueIterator<TKey, TValue> ReverseRange(TKey arg0, TKey arg1)
        {
            var r0 = _keySerDes.Serialize(null, arg0);
            var r1 = _keySerDes.Serialize(null, arg1);

            return new(_factory, _store.ReverseRange(r0, r1));
        }
    }
}
