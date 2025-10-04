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
    /// KNet implementation of <see cref="Org.Apache.Kafka.Streams.State.ReadOnlyKeyValueStore{TJVMK, TJVMV}"/> 
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="V">The value type</typeparam>
    /// <typeparam name="TJVMK">The JVM key type</typeparam>
    /// <typeparam name="TJVMV">The JVM value type</typeparam>
    public class ReadOnlyKeyValueStore<K, V, TJVMK, TJVMV> : ManagedStore<Org.Apache.Kafka.Streams.State.ReadOnlyKeyValueStore<TJVMK, TJVMV>>
    {
        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.1/org/apache/kafka/streams/state/ReadOnlyKeyValueStore.html#approximateNumEntries()"/>
        /// </summary>
        /// <returns><see cref="long"/></returns>
        public virtual long ApproximateNumEntries => Store.ApproximateNumEntries();
        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.1/org/apache/kafka/streams/state/ReadOnlyKeyValueStore.html#all()"/>
        /// </summary>
        /// <returns><see cref="KeyValueIterator{K, V, TJVMK, TJVMV}"/></returns>
        public virtual KeyValueIterator<K, V, TJVMK, TJVMV> All() => new(Factory, Store.All());
        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.1/org/apache/kafka/streams/state/ReadOnlyKeyValueStore.html#range(java.lang.Object,java.lang.Object)"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="K"/></param>
        /// <param name="arg1"><typeparamref name="V"/></param>
        /// <returns><see cref="KeyValueIterator{K, V, TJVMK, TJVMV}"/></returns>
        public virtual KeyValueIterator<K, V, TJVMK, TJVMV> Range(K arg0, K arg1)
        {
            IGenericSerDesFactory factory = Factory;
            var _keySerDes = factory?.BuildKeySerDes<K, TJVMK>();

            var r0 = _keySerDes.Serialize(null, arg0);
            var r1 = _keySerDes.Serialize(null, arg1);

            return new(factory, Store.Range(r0, r1));
        }
        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.1/org/apache/kafka/streams/state/ReadOnlyKeyValueStore.html#get(java.lang.Object)"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="K"/></param>
        /// <returns><typeparamref name="V"/></returns>
        public virtual V Get(K arg0)
        {
            IGenericSerDesFactory factory = Factory;
            var _keySerDes = factory?.BuildKeySerDes<K, TJVMK>();
            var _valueSerDes = factory?.BuildValueSerDes<V, TJVMV>();

            var r0 = _keySerDes.Serialize(null, arg0);
            var res = Store.Get(r0);
            return _valueSerDes.Deserialize(null, res);
        }
        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.1/org/apache/kafka/streams/state/ReadOnlyKeyValueStore.html#reverseAll()"/>
        /// </summary>
        /// <returns><see cref="KeyValueIterator{K, V, TJVMK, TJVMV}"/></returns>
        public virtual KeyValueIterator<K, V, TJVMK, TJVMV> ReverseAll => new(Factory, Store.ReverseAll());
        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.1/org/apache/kafka/streams/state/ReadOnlyKeyValueStore.html#reverseRange(java.lang.Object,java.lang.Object)"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="K"/></param>
        /// <param name="arg1"><typeparamref name="K"/></param>
        /// <returns><see cref="KeyValueIterator{K, V, TJVMK, TJVMV}"/></returns>
        public virtual KeyValueIterator<K, V, TJVMK, TJVMV> ReverseRange(K arg0, K arg1)
        {
            IGenericSerDesFactory factory = Factory;
            var _keySerDes = factory?.BuildKeySerDes<K, TJVMK>();

            var r0 = _keySerDes.Serialize(null, arg0);
            var r1 = _keySerDes.Serialize(null, arg1);

            return new(factory, Store.ReverseRange(r0, r1));
        }
    }

    /// <summary>
    /// KNet implementation of <see cref="ReadOnlyKeyValueStore{K, V, TJVMK, TJVMV}"/> 
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="V">The value type</typeparam>
    public class ReadOnlyKeyValueStore<K, V> : ReadOnlyKeyValueStore<K, V, byte[], byte[]>
    {
    }
}
