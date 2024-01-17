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

using MASES.KNet.Serialization;

namespace MASES.KNet.Streams.State
{
    /// <summary>
    /// KNet implementation of <see cref="Org.Apache.Kafka.Streams.State.ReadOnlyKeyValueStore{K, V}"/> 
    /// </summary>
    /// <typeparam name="TKey">The key type</typeparam>
    /// <typeparam name="TValue">The value type</typeparam>
    public class KNetReadOnlyKeyValueStore<TKey, TValue> : KNetManagedStore<Org.Apache.Kafka.Streams.State.ReadOnlyKeyValueStore<byte[], byte[]>>
    {
        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyKeyValueStore.html#approximateNumEntries--"/>
        /// </summary>
        /// <returns><see cref="long"/></returns>
        public long ApproximateNumEntries => _store.ApproximateNumEntries();
        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyKeyValueStore.html#all--"/>
        /// </summary>
        /// <returns><see cref="KNetKeyValueIterator{TKey, TValue}"/></returns>
        public KNetKeyValueIterator<TKey, TValue> All => new(_factory, _store.All());
        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyKeyValueStore.html#range-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="TKey"/></param>
        /// <param name="arg1"><typeparamref name="TValue"/></param>
        /// <returns><see cref="KNetKeyValueIterator{TKey, TValue}"/></returns>
        public KNetKeyValueIterator<TKey, TValue> Range(TKey arg0, TKey arg1)
        {
            var _keySerDes = _factory.BuildKeySerDes<TKey>();

            var r0 = _keySerDes.Serialize(null, arg0);
            var r1 = _keySerDes.Serialize(null, arg1);

            return new(_factory, _store.Range(r0, r1));
        }
        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyKeyValueStore.html#get-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="TKey"/></param>
        /// <returns><typeparamref name="TValue"/></returns>
        public TValue Get(TKey arg0)
        {
            var _keySerDes = _factory.BuildKeySerDes<TKey>();
            var _valueSerDes = _factory.BuildValueSerDes<TValue>();

            var r0 = _keySerDes.Serialize(null, arg0);
            var res = _store.Get(r0);
            return _valueSerDes.Deserialize(null, res);
        }
        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyKeyValueStore.html#reverseAll--"/>
        /// </summary>
        /// <returns><see cref="KNetKeyValueIterator{TKey, TValue}"/></returns>
        public KNetKeyValueIterator<TKey, TValue> ReverseAll => new(_factory, _store.ReverseAll());
        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyKeyValueStore.html#reverseRange-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="K"/></param>
        /// <param name="arg1"><typeparamref name="K"/></param>
        /// <returns><see cref="KNetKeyValueIterator{TKey, TValue}"/></returns>
        public KNetKeyValueIterator<TKey, TValue> ReverseRange(TKey arg0, TKey arg1)
        {
            var _keySerDes = _factory.BuildKeySerDes<TKey>();

            var r0 = _keySerDes.Serialize(null, arg0);
            var r1 = _keySerDes.Serialize(null, arg1);

            return new(_factory, _store.ReverseRange(r0, r1));
        }
    }
}
