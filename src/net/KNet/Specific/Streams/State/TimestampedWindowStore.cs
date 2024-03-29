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
    /// KNet implementation of <see cref="Org.Apache.Kafka.Streams.State.ReadOnlyWindowStore{TJVMKey, TJVMValue}"/> 
    /// </summary>
    /// <typeparam name="TKey">The key type</typeparam>
    /// <typeparam name="TValue">The value type</typeparam>
    public abstract class TimestampedWindowStore<TKey, TValue, TJVMKey, TJVMValue> : ManagedStore<Org.Apache.Kafka.Streams.State.ReadOnlyWindowStore<TJVMKey, Org.Apache.Kafka.Streams.State.ValueAndTimestamp<TJVMValue>>>
    {
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyWindowStore.html#all--"/>
        /// </summary>
        /// <returns><see cref="TimestampedWindowedKeyValueIterator{TKey, TValue}"/></returns>
        public abstract TimestampedWindowedKeyValueIterator<TKey, TValue> All { get; }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyWindowStore.html#fetch-java.lang.Object-java.lang.Object-java.time.Instant-java.time.Instant-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="TKey"/></param>
        /// <param name="arg1"><typeparamref name="TKey"/></param>
        /// <param name="arg2"><see cref="Java.Time.Instant"/></param>
        /// <param name="arg3"><see cref="Java.Time.Instant"/></param>
        /// <returns><see cref="TimestampedWindowedKeyValueIterator{TKey, TValue}"/></returns>
        /// <exception cref="Java.Lang.IllegalArgumentException"/>
        public abstract TimestampedWindowedKeyValueIterator<TKey, TValue> Fetch(TKey arg0, TKey arg1, Java.Time.Instant arg2, Java.Time.Instant arg3);
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyWindowStore.html#fetchAll-java.time.Instant-java.time.Instant-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Time.Instant"/></param>
        /// <param name="arg1"><see cref="Java.Time.Instant"/></param>
        /// <returns><see cref="TimestampedWindowedKeyValueIterator{TKey, TValue}"/></returns>
        /// <exception cref="Java.Lang.IllegalArgumentException"/>
        public abstract TimestampedWindowedKeyValueIterator<TKey, TValue> FetchAll(Java.Time.Instant arg0, Java.Time.Instant arg1);
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyWindowStore.html#fetch-java.lang.Object-java.time.Instant-java.time.Instant-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="TKey"/></param>
        /// <param name="arg1"><see cref="Java.Time.Instant"/></param>
        /// <param name="arg2"><see cref="Java.Time.Instant"/></param>
        /// <returns><see cref="TimestampedWindowStoreIterator{TValue}"/></returns>
        /// <exception cref="Java.Lang.IllegalArgumentException"/>
        public abstract TimestampedWindowStoreIterator<TValue> Fetch(TKey arg0, Java.Time.Instant arg1, Java.Time.Instant arg2);
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyWindowStore.html#fetch-java.lang.Object-long-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="TKey"/></param>
        /// <param name="arg1"><see cref="long"/></param>
        /// <returns><see cref="ValueAndTimestamp{TValue}"/></returns>
        public abstract ValueAndTimestamp<TValue> Fetch(TKey arg0, long arg1);
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyWindowStore.html#backwardAll--"/>
        /// </summary>
        /// <returns><see cref="TimestampedWindowedKeyValueIterator{TKey, TValue}"/></returns>
        public abstract TimestampedWindowedKeyValueIterator<TKey, TValue> BackwardAll { get; }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyWindowStore.html#backwardFetch-java.lang.Object-java.lang.Object-java.time.Instant-java.time.Instant-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="TKey"/></param>
        /// <param name="arg1"><typeparamref name="TKey"/></param>
        /// <param name="arg2"><see cref="Java.Time.Instant"/></param>
        /// <param name="arg3"><see cref="Java.Time.Instant"/></param>
        /// <returns><see cref="TimestampedWindowedKeyValueIterator{TKey, TValue}"/></returns>
        /// <exception cref="Java.Lang.IllegalArgumentException"/>
        public abstract TimestampedWindowedKeyValueIterator<TKey, TValue> BackwardFetch(TKey arg0, TKey arg1, Java.Time.Instant arg2, Java.Time.Instant arg3);
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyWindowStore.html#backwardFetchAll-java.time.Instant-java.time.Instant-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Time.Instant"/></param>
        /// <param name="arg1"><see cref="Java.Time.Instant"/></param>
        /// <returns><see cref="TimestampedWindowedKeyValueIterator{TKey, TValue}"/></returns>
        /// <exception cref="Java.Lang.IllegalArgumentException"/>
        public abstract TimestampedWindowedKeyValueIterator<TKey, TValue> BackwardFetchAll(Java.Time.Instant arg0, Java.Time.Instant arg1);
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyWindowStore.html#backwardFetch-java.lang.Object-java.time.Instant-java.time.Instant-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="TKey"/></param>
        /// <param name="arg1"><see cref="Java.Time.Instant"/></param>
        /// <param name="arg2"><see cref="Java.Time.Instant"/></param>
        /// <returns><see cref="TimestampedWindowStoreIterator{TValue}"/></returns>
        /// <exception cref="Java.Lang.IllegalArgumentException"/>
        public abstract TimestampedWindowStoreIterator<TValue> BackwardFetch(TKey arg0, Java.Time.Instant arg1, Java.Time.Instant arg2);
    }

    /// <summary>
    /// KNet implementation of <see cref="Org.Apache.Kafka.Streams.State.ReadOnlyWindowStore{K, V}"/> 
    /// </summary>
    /// <typeparam name="TKey">The key type</typeparam>
    /// <typeparam name="TValue">The value type</typeparam>
    public class TimestampedWindowStore<TKey, TValue> : TimestampedWindowStore<TKey, TValue, byte[], byte[]>
    {
        /// <inheritdoc/>
        public override TimestampedWindowedKeyValueIterator<TKey, TValue> All => new TimestampedWindowedKeyValueIterator<TKey, TValue>(Factory, Store.All());
        /// <inheritdoc/>
        public override TimestampedWindowedKeyValueIterator<TKey, TValue> Fetch(TKey arg0, TKey arg1, Java.Time.Instant arg2, Java.Time.Instant arg3)
        {
            IGenericSerDesFactory factory = Factory;
            var _keySerDes = factory?.BuildKeySerDes<TKey>();

            var r0 = _keySerDes.Serialize(null, arg0);
            var r1 = _keySerDes.Serialize(null, arg1);

            return new(factory, Store.Fetch(r0, r1, arg2, arg3));
        }
        /// <inheritdoc/>
        public override TimestampedWindowedKeyValueIterator<TKey, TValue> FetchAll(Java.Time.Instant arg0, Java.Time.Instant arg1)
        {
            return new(Factory, Store.FetchAll(arg0, arg1));
        }
        /// <inheritdoc/>
        public override TimestampedWindowStoreIterator<TValue> Fetch(TKey arg0, Java.Time.Instant arg1, Java.Time.Instant arg2)
        {
            IGenericSerDesFactory factory = Factory;
            var _keySerDes = factory?.BuildKeySerDes<TKey>();

            var r0 = _keySerDes.Serialize(null, arg0);
            return new(factory, Store.Fetch(r0, arg1, arg2));
        }
        /// <inheritdoc/>
        public override ValueAndTimestamp<TValue> Fetch(TKey arg0, long arg1)
        {
            IGenericSerDesFactory factory = Factory;
            var _keySerDes = factory?.BuildKeySerDes<TKey>();

            var r0 = _keySerDes.Serialize(null, arg0);
            var agg = Store.Fetch(r0, arg1);
            return new ValueAndTimestamp<TValue>(factory, agg);
        }
        /// <inheritdoc/>
        public override TimestampedWindowedKeyValueIterator<TKey, TValue> BackwardAll => new(Factory, Store.BackwardAll());
        /// <inheritdoc/>
        public override TimestampedWindowedKeyValueIterator<TKey, TValue> BackwardFetch(TKey arg0, TKey arg1, Java.Time.Instant arg2, Java.Time.Instant arg3)
        {
            IGenericSerDesFactory factory = Factory;
            var _keySerDes = factory?.BuildKeySerDes<TKey>();

            var r0 = _keySerDes.Serialize(null, arg0);
            var r1 = _keySerDes.Serialize(null, arg1);

            return new(factory, Store.BackwardFetch(r0, r1, arg2, arg3));
        }
        /// <inheritdoc/>
        public override TimestampedWindowedKeyValueIterator<TKey, TValue> BackwardFetchAll(Java.Time.Instant arg0, Java.Time.Instant arg1)
        {
            return new(Factory, Store.BackwardFetchAll(arg0, arg1));
        }
        /// <inheritdoc/>
        public override TimestampedWindowStoreIterator<TValue> BackwardFetch(TKey arg0, Java.Time.Instant arg1, Java.Time.Instant arg2)
        {
            IGenericSerDesFactory factory = Factory;
            var _keySerDes = factory?.BuildKeySerDes<TKey>();

            var r0 = _keySerDes.Serialize(null, arg0);

            return new(factory, Store.BackwardFetch(r0, arg1, arg2));
        }
    }
}
