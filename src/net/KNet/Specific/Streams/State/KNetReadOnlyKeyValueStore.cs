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
    /// KNet implementation of <see cref="Org.Apache.Kafka.Streams.State.ReadOnlyKeyValueStore{TJVMTKey, TJVMTValue}"/> 
    /// </summary>
    /// <typeparam name="TKey">The key type</typeparam>
    /// <typeparam name="TValue">The value type</typeparam>
    /// <typeparam name="TJVMTKey">The JVM key type</typeparam>
    /// <typeparam name="TJVMTValue">The JVM value type</typeparam>
    public abstract class KNetReadOnlyKeyValueStore<TKey, TValue, TJVMTKey, TJVMTValue> : KNetManagedStore<Org.Apache.Kafka.Streams.State.ReadOnlyKeyValueStore<TJVMTKey, TJVMTValue>>
    {
        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyKeyValueStore.html#approximateNumEntries--"/>
        /// </summary>
        /// <returns><see cref="long"/></returns>
        public abstract long ApproximateNumEntries { get; }
        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyKeyValueStore.html#all--"/>
        /// </summary>
        /// <returns><see cref="KNetKeyValueIterator{TKey, TValue}"/></returns>
        public abstract KNetKeyValueIterator<TKey, TValue> All { get; }
        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyKeyValueStore.html#range-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="TKey"/></param>
        /// <param name="arg1"><typeparamref name="TValue"/></param>
        /// <returns><see cref="KNetKeyValueIterator{TKey, TValue}"/></returns>
        public abstract KNetKeyValueIterator<TKey, TValue> Range(TKey arg0, TKey arg1);
        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyKeyValueStore.html#get-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="TKey"/></param>
        /// <returns><typeparamref name="TValue"/></returns>
        public abstract TValue Get(TKey arg0);
        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyKeyValueStore.html#reverseAll--"/>
        /// </summary>
        /// <returns><see cref="KNetKeyValueIterator{TKey, TValue}"/></returns>
        public abstract KNetKeyValueIterator<TKey, TValue> ReverseAll { get; }
        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyKeyValueStore.html#reverseRange-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="TKey"/></param>
        /// <param name="arg1"><typeparamref name="TKey"/></param>
        /// <returns><see cref="KNetKeyValueIterator{TKey, TValue}"/></returns>
        public abstract KNetKeyValueIterator<TKey, TValue> ReverseRange(TKey arg0, TKey arg1);
    }

    /// <summary>
    /// KNet implementation of <see cref="KNetReadOnlyKeyValueStore{TKey, TValue, TJVMTKey, TJVMTValue}"/> 
    /// </summary>
    /// <typeparam name="TKey">The key type</typeparam>
    /// <typeparam name="TValue">The value type</typeparam>
    public class KNetReadOnlyKeyValueStore<TKey, TValue> : KNetReadOnlyKeyValueStore<TKey, TValue, byte[], byte[]>
    {
        /// <inheritdoc/>
        public override long ApproximateNumEntries => Store.ApproximateNumEntries();
        /// <inheritdoc/>
        public override KNetKeyValueIterator<TKey, TValue> All => new(Factory, Store.All());
        /// <inheritdoc/>
        public override KNetKeyValueIterator<TKey, TValue> Range(TKey arg0, TKey arg1)
        {
            IGenericSerDesFactory factory = Factory;
            var _keySerDes = factory?.BuildKeySerDes<TKey>();

            var r0 = _keySerDes.Serialize(null, arg0);
            var r1 = _keySerDes.Serialize(null, arg1);

            return new(factory, Store.Range(r0, r1));
        }
        /// <inheritdoc/>
        public override TValue Get(TKey arg0)
        {
            IGenericSerDesFactory factory = Factory;
            var _keySerDes = factory?.BuildKeySerDes<TKey>();
            var _valueSerDes = factory?.BuildValueSerDes<TValue>();

            var r0 = _keySerDes.Serialize(null, arg0);
            var res = Store.Get(r0);
            return _valueSerDes.Deserialize(null, res);
        }
        /// <inheritdoc/>
        public override KNetKeyValueIterator<TKey, TValue> ReverseAll => new(Factory, Store.ReverseAll());
        /// <inheritdoc/>
        public override KNetKeyValueIterator<TKey, TValue> ReverseRange(TKey arg0, TKey arg1)
        {
            IGenericSerDesFactory factory = Factory;
            var _keySerDes = factory?.BuildKeySerDes<TKey>();

            var r0 = _keySerDes.Serialize(null, arg0);
            var r1 = _keySerDes.Serialize(null, arg1);

            return new(factory, Store.ReverseRange(r0, r1));
        }
    }
}
