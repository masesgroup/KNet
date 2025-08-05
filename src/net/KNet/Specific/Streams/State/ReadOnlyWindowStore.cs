/*
*  Copyright (c) 2021-2025 MASES s.r.l.
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
    /// KNet implementation of <see cref="Org.Apache.Kafka.Streams.State.ReadOnlyWindowStore{TJVMK, TJVMV}"/> 
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="V">The value type</typeparam>
    /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
    /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
    public class ReadOnlyWindowStore<K, V, TJVMK, TJVMV> : ManagedStore<Org.Apache.Kafka.Streams.State.ReadOnlyWindowStore<TJVMK, TJVMV>>
    {
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/state/ReadOnlyWindowStore.html#all()"/>
        /// </summary>
        /// <returns><see cref="WindowedKeyValueIterator{K, V, TJVMK, TJVMV}"/></returns>
        public virtual WindowedKeyValueIterator<K, V, TJVMK, TJVMV> All() => new WindowedKeyValueIterator<K, V, TJVMK, TJVMV>(Factory, Store.All());
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/state/ReadOnlyWindowStore.html#fetch(java.lang.Object,java.lang.Object,java.time.Instant,java.time.Instant)"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="K"/></param>
        /// <param name="arg1"><typeparamref name="K"/></param>
        /// <param name="arg2"><see cref="Java.Time.Instant"/></param>
        /// <param name="arg3"><see cref="Java.Time.Instant"/></param>
        /// <returns><see cref="WindowedKeyValueIterator{K, V, TJVMK, TJVMV}"/></returns>
        /// <exception cref="Java.Lang.IllegalArgumentException"/>
        public virtual WindowedKeyValueIterator<K, V, TJVMK, TJVMV> Fetch(K arg0, K arg1, Java.Time.Instant arg2, Java.Time.Instant arg3)
        {
            IGenericSerDesFactory factory = Factory;
            var _keySerDes = factory?.BuildKeySerDes<K, TJVMK>();

            var r0 = _keySerDes.Serialize(null, arg0);
            var r1 = _keySerDes.Serialize(null, arg1);
            return new WindowedKeyValueIterator<K, V, TJVMK, TJVMV>(factory, Store.Fetch(r0, r1, arg2, arg3));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/state/ReadOnlyWindowStore.html#fetchAll(java.time.Instant,java.time.Instant)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Time.Instant"/></param>
        /// <param name="arg1"><see cref="Java.Time.Instant"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.State.KeyValueIterator"/></returns>
        /// <exception cref="Java.Lang.IllegalArgumentException"/>
        public virtual WindowedKeyValueIterator<K, V, TJVMK, TJVMV> FetchAll(Java.Time.Instant arg0, Java.Time.Instant arg1)
        {
            return new WindowedKeyValueIterator<K, V, TJVMK, TJVMV>(Factory, Store.FetchAll(arg0, arg1));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/state/ReadOnlyWindowStore.html#fetch(java.lang.Object,java.time.Instant,java.time.Instant)"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="K"/></param>
        /// <param name="arg1"><see cref="Java.Time.Instant"/></param>
        /// <param name="arg2"><see cref="Java.Time.Instant"/></param>
        /// <returns><see cref="WindowStoreIterator{V, TJVMV}"/></returns>
        /// <exception cref="Java.Lang.IllegalArgumentException"/>
        public virtual WindowStoreIterator<V, TJVMV> Fetch(K arg0, Java.Time.Instant arg1, Java.Time.Instant arg2)
        {
            IGenericSerDesFactory factory = Factory;
            var _keySerDes = factory?.BuildKeySerDes<K, TJVMK>();

            var r0 = _keySerDes.Serialize(null, arg0);
            return new WindowStoreIterator<V, TJVMV>(factory, Store.Fetch(r0, arg1, arg2));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/state/ReadOnlyWindowStore.html#fetch(java.lang.Object,long)"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="K"/></param>
        /// <param name="arg1"><see cref="long"/></param>
        /// <returns><typeparamref name="V"/></returns>
        public virtual V Fetch(K arg0, long arg1)
        {
            IGenericSerDesFactory factory = Factory;
            var _keySerDes = factory?.BuildKeySerDes<K, TJVMK>();
            var _valueSerDes = factory?.BuildValueSerDes<V, TJVMV>();

            var r0 = _keySerDes.Serialize(null, arg0);
            var agg = Store.Fetch(r0, arg1);
            return _valueSerDes.Deserialize(null, agg);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/state/ReadOnlyWindowStore.html#backwardAll()"/>
        /// </summary>
        /// <returns><see cref="WindowedKeyValueIterator{K, V, TJVMK, TJVMV}"/></returns>
        public virtual WindowedKeyValueIterator<K, V, TJVMK, TJVMV> BackwardAll => new WindowedKeyValueIterator<K, V, TJVMK, TJVMV>(Factory, Store.BackwardAll());
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/state/ReadOnlyWindowStore.html#backwardFetch(java.lang.Object,java.lang.Object,java.time.Instant,java.time.Instant)"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="K"/></param>
        /// <param name="arg1"><typeparamref name="K"/></param>
        /// <param name="arg2"><see cref="Java.Time.Instant"/></param>
        /// <param name="arg3"><see cref="Java.Time.Instant"/></param>
        /// <returns><see cref="WindowedKeyValueIterator{K, V, TJVMK, TJVMV}"/></returns>
        /// <exception cref="Java.Lang.IllegalArgumentException"/>
        public virtual WindowedKeyValueIterator<K, V, TJVMK, TJVMV> BackwardFetch(K arg0, K arg1, Java.Time.Instant arg2, Java.Time.Instant arg3)
        {
            IGenericSerDesFactory factory = Factory;
            var _keySerDes = factory?.BuildKeySerDes<K, TJVMK>();

            var r0 = _keySerDes.Serialize(null, arg0);
            var r1 = _keySerDes.Serialize(null, arg1);
            return new WindowedKeyValueIterator<K, V, TJVMK, TJVMV>(factory, Store.BackwardFetch(r0, r1, arg2, arg3));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/state/ReadOnlyWindowStore.html#backwardFetchAll(java.time.Instant,java.time.Instant)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Time.Instant"/></param>
        /// <param name="arg1"><see cref="Java.Time.Instant"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.State.KeyValueIterator"/></returns>
        /// <exception cref="Java.Lang.IllegalArgumentException"/>
        public virtual WindowedKeyValueIterator<K, V, TJVMK, TJVMV> BackwardFetchAll(Java.Time.Instant arg0, Java.Time.Instant arg1)
        {
            return new WindowedKeyValueIterator<K, V, TJVMK, TJVMV>(Factory, Store.BackwardFetchAll(arg0, arg1));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/state/ReadOnlyWindowStore.html#backwardFetch(java.lang.Object,java.time.Instant,java.time.Instant)"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="K"/></param>
        /// <param name="arg1"><see cref="Java.Time.Instant"/></param>
        /// <param name="arg2"><see cref="Java.Time.Instant"/></param>
        /// <returns><see cref="WindowStoreIterator{V, TJVMV}"/></returns>
        /// <exception cref="Java.Lang.IllegalArgumentException"/>
        public virtual WindowStoreIterator<V, TJVMV> BackwardFetch(K arg0, Java.Time.Instant arg1, Java.Time.Instant arg2)
        {
            IGenericSerDesFactory factory = Factory;
            var _keySerDes = factory?.BuildKeySerDes<K, TJVMK>();

            var r0 = _keySerDes.Serialize(null, arg0);
            return new WindowStoreIterator<V, TJVMV>(factory, Store.BackwardFetch(r0, arg1, arg2));
        }
    }

    /// <summary>
    /// KNet implementation of <see cref="ReadOnlyWindowStore{K, V, TJVMK, TJVMV}"/> 
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="V">The value type</typeparam>
    public class ReadOnlyWindowStore<K, V> : ReadOnlyWindowStore<K, V, byte[], byte[]>
    {
    }
}
