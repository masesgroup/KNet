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

namespace MASES.KNet.Streams.State
{
    /// <summary>
    /// KNet implementation of <see cref="Org.Apache.Kafka.Streams.State.ReadOnlyWindowStore{K, V}"/> 
    /// </summary>
    /// <typeparam name="TKey">The key type</typeparam>
    /// <typeparam name="TValue">The value type</typeparam>
    public class KNetReadOnlyWindowStore<TKey, TValue> : KNetManagedStore<Org.Apache.Kafka.Streams.State.ReadOnlyWindowStore<byte[], byte[]>>, IGenericSerDesFactoryApplier
    {
        readonly Org.Apache.Kafka.Streams.State.ReadOnlyWindowStore<byte[], byte[]> _store;
        readonly IKNetSerDes<TKey> _keySerDes;
        readonly IKNetSerDes<TValue> _valueSerDes;
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

        internal KNetReadOnlyWindowStore(IGenericSerDesFactory factory, Org.Apache.Kafka.Streams.State.ReadOnlyWindowStore<byte[], byte[]> store)
        {
            _factory = factory;
            _keySerDes = _factory.BuildKeySerDes<TKey>();
            _valueSerDes = _factory.BuildValueSerDes<TValue>();
            _store = store;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyWindowStore.html#all--"/>
        /// </summary>
        /// <returns><see cref="KNetWindowedKeyValueIterator{TKey, TValue}"/></returns>
        public KNetWindowedKeyValueIterator<TKey, TValue> All => new KNetWindowedKeyValueIterator<TKey, TValue>(_factory, _store.All());
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyWindowStore.html#fetch-java.lang.Object-java.lang.Object-java.time.Instant-java.time.Instant-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="TKey"/></param>
        /// <param name="arg1"><typeparamref name="TKey"/></param>
        /// <param name="arg2"><see cref="Java.Time.Instant"/></param>
        /// <param name="arg3"><see cref="Java.Time.Instant"/></param>
        /// <returns><see cref="KNetWindowedKeyValueIterator{TKey, TValue}"/></returns>
        /// <exception cref="Java.Lang.IllegalArgumentException"/>
        public KNetWindowedKeyValueIterator<TKey, TValue> Fetch(TKey arg0, TKey arg1, Java.Time.Instant arg2, Java.Time.Instant arg3)
        {
            var r0 = _keySerDes.Serialize(null, arg0);
            var r1 = _keySerDes.Serialize(null, arg1);
            return new KNetWindowedKeyValueIterator<TKey, TValue>(_factory, _store.Fetch(r0, r1, arg2, arg3));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyWindowStore.html#fetchAll-java.time.Instant-java.time.Instant-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Time.Instant"/></param>
        /// <param name="arg1"><see cref="Java.Time.Instant"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.State.KeyValueIterator"/></returns>
        /// <exception cref="Java.Lang.IllegalArgumentException"/>
        public KNetWindowedKeyValueIterator<TKey, TValue> FetchAll(Java.Time.Instant arg0, Java.Time.Instant arg1)
        {
            return new KNetWindowedKeyValueIterator<TKey, TValue>(_factory, _store.FetchAll(arg0, arg1));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyWindowStore.html#fetch-java.lang.Object-java.time.Instant-java.time.Instant-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="K"/></param>
        /// <param name="arg1"><see cref="Java.Time.Instant"/></param>
        /// <param name="arg2"><see cref="Java.Time.Instant"/></param>
        /// <returns><see cref="KNetWindowStoreIterator{TValue}"/></returns>
        /// <exception cref="Java.Lang.IllegalArgumentException"/>
        public KNetWindowStoreIterator<TValue> Fetch(TKey arg0, Java.Time.Instant arg1, Java.Time.Instant arg2)
        {
            var r0 = _keySerDes.Serialize(null, arg0);
            return new KNetWindowStoreIterator<TValue>(_factory, _store.Fetch(r0, arg1, arg2));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyWindowStore.html#fetch-java.lang.Object-long-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="TKey"/></param>
        /// <param name="arg1"><see cref="long"/></param>
        /// <returns><typeparamref name="TValue"/></returns>
        public TValue Fetch(TKey arg0, long arg1)
        {
            var r0 = _keySerDes.Serialize(null, arg0);
            var agg = _store.Fetch(r0, arg1);
            return _valueSerDes.Deserialize(null, agg);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyWindowStore.html#backwardAll--"/>
        /// </summary>
        /// <returns><see cref="KNetWindowedKeyValueIterator{TKey, TValue}"/></returns>
        public KNetWindowedKeyValueIterator<TKey, TValue> BackwardAll => new KNetWindowedKeyValueIterator<TKey, TValue>(_factory, _store.BackwardAll());
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyWindowStore.html#backwardFetch-java.lang.Object-java.lang.Object-java.time.Instant-java.time.Instant-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="TKey"/></param>
        /// <param name="arg1"><typeparamref name="TKey"/></param>
        /// <param name="arg2"><see cref="Java.Time.Instant"/></param>
        /// <param name="arg3"><see cref="Java.Time.Instant"/></param>
        /// <returns><see cref="KNetWindowedKeyValueIterator{TKey, TValue}"/></returns>
        /// <exception cref="Java.Lang.IllegalArgumentException"/>
        public KNetWindowedKeyValueIterator<TKey, TValue> BackwardFetch(TKey arg0, TKey arg1, Java.Time.Instant arg2, Java.Time.Instant arg3)
        {
            var r0 = _keySerDes.Serialize(null, arg0);
            var r1 = _keySerDes.Serialize(null, arg1);
            return new KNetWindowedKeyValueIterator<TKey, TValue>(_factory, _store.BackwardFetch(r0, r1, arg2, arg3));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyWindowStore.html#backwardFetchAll-java.time.Instant-java.time.Instant-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Time.Instant"/></param>
        /// <param name="arg1"><see cref="Java.Time.Instant"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.State.KeyValueIterator"/></returns>
        /// <exception cref="Java.Lang.IllegalArgumentException"/>
        public KNetWindowedKeyValueIterator<TKey, TValue> BackwardFetchAll(Java.Time.Instant arg0, Java.Time.Instant arg1)
        {
            return new KNetWindowedKeyValueIterator<TKey, TValue>(_factory, _store.BackwardFetchAll(arg0, arg1));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyWindowStore.html#backwardFetch-java.lang.Object-java.time.Instant-java.time.Instant-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="K"/></param>
        /// <param name="arg1"><see cref="Java.Time.Instant"/></param>
        /// <param name="arg2"><see cref="Java.Time.Instant"/></param>
        /// <returns><see cref="KNetWindowStoreIterator{TValue}"/></returns>
        /// <exception cref="Java.Lang.IllegalArgumentException"/>
        public KNetWindowStoreIterator<TValue> BackwardFetch(TKey arg0, Java.Time.Instant arg1, Java.Time.Instant arg2)
        {
            var r0 = _keySerDes.Serialize(null, arg0);
            return new KNetWindowStoreIterator<TValue>(_factory, _store.BackwardFetch(r0, arg1, arg2));
        }
    }
}
