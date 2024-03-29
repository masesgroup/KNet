﻿/*
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
    /// KNet implementation of <see cref="Org.Apache.Kafka.Streams.State.ReadOnlySessionStore{TJVMKey, TJVMValue}"/> 
    /// </summary>
    /// <typeparam name="TKey">The key type</typeparam>
    /// <typeparam name="TValue">The value type</typeparam>
    public abstract class TimestampedKeyValueStore<TKey, TValue, TJVMKey, TJVMValue> : ManagedStore<Org.Apache.Kafka.Streams.State.ReadOnlyKeyValueStore<TJVMKey, Org.Apache.Kafka.Streams.State.ValueAndTimestamp<TJVMValue>>>
    {
        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyKeyValueStore.html#approximateNumEntries--"/>
        /// </summary>
        /// <returns><see cref="long"/></returns>
        public abstract long ApproximateNumEntries { get; }
        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyKeyValueStore.html#all--"/>
        /// </summary>
        /// <returns><see cref="KeyValueIterator{TKey, TValue}"/></returns>
        public abstract TimestampedKeyValueIterator<TKey, TValue> All { get; }
        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyKeyValueStore.html#range-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="TKey"/></param>
        /// <param name="arg1"><typeparamref name="TValue"/></param>
        /// <returns><see cref="KeyValueIterator{TKey, TValue}"/></returns>
        public abstract TimestampedKeyValueIterator<TKey, TValue> Range(TKey arg0, TKey arg1);
        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyKeyValueStore.html#get-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="TKey"/></param>
        /// <returns><typeparamref name="TValue"/></returns>
        public abstract ValueAndTimestamp<TValue> Get(TKey arg0);
        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyKeyValueStore.html#reverseAll--"/>
        /// </summary>
        /// <returns><see cref="KeyValueIterator{TKey, TValue}"/></returns>
        public abstract TimestampedKeyValueIterator<TKey, TValue> ReverseAll { get; }
        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyKeyValueStore.html#reverseRange-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="TKey"/></param>
        /// <param name="arg1"><typeparamref name="TKey"/></param>
        /// <returns><see cref="KeyValueIterator{TKey, TValue}"/></returns>
        public abstract TimestampedKeyValueIterator<TKey, TValue> ReverseRange(TKey arg0, TKey arg1);
    }

    /// <summary>
    /// KNet implementation of <see cref="Org.Apache.Kafka.Streams.State.ReadOnlySessionStore{K, V}"/> 
    /// </summary>
    /// <typeparam name="TKey">The key type</typeparam>
    /// <typeparam name="TValue">The value type</typeparam>
    public class TimestampedKeyValueStore<TKey, TValue> : TimestampedKeyValueStore<TKey, TValue, byte[], byte[]>
    {
        /// <inheritdoc/>
        public override long ApproximateNumEntries => Store.ApproximateNumEntries();
        /// <inheritdoc/>
        public override TimestampedKeyValueIterator<TKey, TValue> All => new(Factory, Store.All());
        /// <inheritdoc/>
        public override TimestampedKeyValueIterator<TKey, TValue> Range(TKey arg0, TKey arg1)
        {
            IGenericSerDesFactory factory = Factory;
            var _keySerDes = factory?.BuildKeySerDes<TKey>();

            var r0 = _keySerDes.Serialize(null, arg0);
            var r1 = _keySerDes.Serialize(null, arg1);

            return new(factory, Store.Range(r0, r1));
        }
        /// <inheritdoc/>
        public override ValueAndTimestamp<TValue> Get(TKey arg0)
        {
            IGenericSerDesFactory factory = Factory;
            var _keySerDes = factory?.BuildKeySerDes<TKey>();

            var r0 = _keySerDes.Serialize(null, arg0);
            var res = Store.Get(r0);
            return new ValueAndTimestamp<TValue>(factory, res);
        }
        /// <inheritdoc/>
        public override TimestampedKeyValueIterator<TKey, TValue> ReverseAll => new(Factory, Store.ReverseAll());
        /// <inheritdoc/>
        public override TimestampedKeyValueIterator<TKey, TValue> ReverseRange(TKey arg0, TKey arg1)
        {
            IGenericSerDesFactory factory = Factory;
            var _keySerDes = factory?.BuildKeySerDes<TKey>();

            var r0 = _keySerDes.Serialize(null, arg0);
            var r1 = _keySerDes.Serialize(null, arg1);

            return new(factory, Store.ReverseRange(r0, r1));
        }
    }
}
