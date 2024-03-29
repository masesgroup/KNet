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
    public abstract class ReadOnlyWindowStore<TKey, TValue, TJVMKey, TJVMValue> : ManagedStore<Org.Apache.Kafka.Streams.State.ReadOnlyWindowStore<TJVMKey, TJVMValue>>
    {
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyWindowStore.html#all--"/>
        /// </summary>
        /// <returns><see cref="WindowedKeyValueIterator{TKey, TValue}"/></returns>
        public abstract WindowedKeyValueIterator<TKey, TValue> All { get; }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyWindowStore.html#fetch-java.lang.Object-java.lang.Object-java.time.Instant-java.time.Instant-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="TKey"/></param>
        /// <param name="arg1"><typeparamref name="TKey"/></param>
        /// <param name="arg2"><see cref="Java.Time.Instant"/></param>
        /// <param name="arg3"><see cref="Java.Time.Instant"/></param>
        /// <returns><see cref="WindowedKeyValueIterator{TKey, TValue}"/></returns>
        /// <exception cref="Java.Lang.IllegalArgumentException"/>
        public abstract WindowedKeyValueIterator<TKey, TValue> Fetch(TKey arg0, TKey arg1, Java.Time.Instant arg2, Java.Time.Instant arg3);
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyWindowStore.html#fetchAll-java.time.Instant-java.time.Instant-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Time.Instant"/></param>
        /// <param name="arg1"><see cref="Java.Time.Instant"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.State.KeyValueIterator"/></returns>
        /// <exception cref="Java.Lang.IllegalArgumentException"/>
        public abstract WindowedKeyValueIterator<TKey, TValue> FetchAll(Java.Time.Instant arg0, Java.Time.Instant arg1);
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyWindowStore.html#fetch-java.lang.Object-java.time.Instant-java.time.Instant-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="TKey"/></param>
        /// <param name="arg1"><see cref="Java.Time.Instant"/></param>
        /// <param name="arg2"><see cref="Java.Time.Instant"/></param>
        /// <returns><see cref="WindowStoreIterator{TValue}"/></returns>
        /// <exception cref="Java.Lang.IllegalArgumentException"/>
        public abstract WindowStoreIterator<TValue> Fetch(TKey arg0, Java.Time.Instant arg1, Java.Time.Instant arg2);
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyWindowStore.html#fetch-java.lang.Object-long-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="TKey"/></param>
        /// <param name="arg1"><see cref="long"/></param>
        /// <returns><typeparamref name="TValue"/></returns>
        public abstract TValue Fetch(TKey arg0, long arg1);
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyWindowStore.html#backwardAll--"/>
        /// </summary>
        /// <returns><see cref="WindowedKeyValueIterator{TKey, TValue}"/></returns>
        public abstract WindowedKeyValueIterator<TKey, TValue> BackwardAll { get; }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyWindowStore.html#backwardFetch-java.lang.Object-java.lang.Object-java.time.Instant-java.time.Instant-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="TKey"/></param>
        /// <param name="arg1"><typeparamref name="TKey"/></param>
        /// <param name="arg2"><see cref="Java.Time.Instant"/></param>
        /// <param name="arg3"><see cref="Java.Time.Instant"/></param>
        /// <returns><see cref="WindowedKeyValueIterator{TKey, TValue}"/></returns>
        /// <exception cref="Java.Lang.IllegalArgumentException"/>
        public abstract WindowedKeyValueIterator<TKey, TValue> BackwardFetch(TKey arg0, TKey arg1, Java.Time.Instant arg2, Java.Time.Instant arg3);
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyWindowStore.html#backwardFetchAll-java.time.Instant-java.time.Instant-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Time.Instant"/></param>
        /// <param name="arg1"><see cref="Java.Time.Instant"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.State.KeyValueIterator"/></returns>
        /// <exception cref="Java.Lang.IllegalArgumentException"/>
        public abstract WindowedKeyValueIterator<TKey, TValue> BackwardFetchAll(Java.Time.Instant arg0, Java.Time.Instant arg1);
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyWindowStore.html#backwardFetch-java.lang.Object-java.time.Instant-java.time.Instant-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="TKey"/></param>
        /// <param name="arg1"><see cref="Java.Time.Instant"/></param>
        /// <param name="arg2"><see cref="Java.Time.Instant"/></param>
        /// <returns><see cref="WindowStoreIterator{TValue}"/></returns>
        /// <exception cref="Java.Lang.IllegalArgumentException"/>
        public abstract WindowStoreIterator<TValue> BackwardFetch(TKey arg0, Java.Time.Instant arg1, Java.Time.Instant arg2);
    }

    /// <summary>
    /// KNet implementation of <see cref="ReadOnlyWindowStore{TKey, TValue, TJVMKey, TJVMValue}"/> 
    /// </summary>
    /// <typeparam name="TKey">The key type</typeparam>
    /// <typeparam name="TValue">The value type</typeparam>
    public class ReadOnlyWindowStore<TKey, TValue> : ReadOnlyWindowStore<TKey, TValue, byte[], byte[]>
    {
        /// <inheritdoc/>
        public override WindowedKeyValueIterator<TKey, TValue> All => new WindowedKeyValueIterator<TKey, TValue>(Factory, Store.All());
        /// <inheritdoc/>
        public override WindowedKeyValueIterator<TKey, TValue> Fetch(TKey arg0, TKey arg1, Java.Time.Instant arg2, Java.Time.Instant arg3)
        {
            IGenericSerDesFactory factory = Factory;
            var _keySerDes = factory?.BuildKeySerDes<TKey>();

            var r0 = _keySerDes.Serialize(null, arg0);
            var r1 = _keySerDes.Serialize(null, arg1);
            return new WindowedKeyValueIterator<TKey, TValue>(factory, Store.Fetch(r0, r1, arg2, arg3));
        }
        /// <inheritdoc/>
        public override WindowedKeyValueIterator<TKey, TValue> FetchAll(Java.Time.Instant arg0, Java.Time.Instant arg1)
        {
            return new WindowedKeyValueIterator<TKey, TValue>(Factory, Store.FetchAll(arg0, arg1));
        }
        /// <inheritdoc/>
        public override WindowStoreIterator<TValue> Fetch(TKey arg0, Java.Time.Instant arg1, Java.Time.Instant arg2)
        {
            IGenericSerDesFactory factory = Factory;
            var _keySerDes = factory?.BuildKeySerDes<TKey>();

            var r0 = _keySerDes.Serialize(null, arg0);
            return new WindowStoreIterator<TValue>(factory, Store.Fetch(r0, arg1, arg2));
        }
        /// <inheritdoc/>
        public override TValue Fetch(TKey arg0, long arg1)
        {
            IGenericSerDesFactory factory = Factory;
            var _keySerDes = factory?.BuildKeySerDes<TKey>();
            var _valueSerDes = factory?.BuildValueSerDes<TValue>();

            var r0 = _keySerDes.Serialize(null, arg0);
            var agg = Store.Fetch(r0, arg1);
            return _valueSerDes.Deserialize(null, agg);
        }
        /// <inheritdoc/>
        public override WindowedKeyValueIterator<TKey, TValue> BackwardAll => new WindowedKeyValueIterator<TKey, TValue>(Factory, Store.BackwardAll());
        /// <inheritdoc/>
        public override WindowedKeyValueIterator<TKey, TValue> BackwardFetch(TKey arg0, TKey arg1, Java.Time.Instant arg2, Java.Time.Instant arg3)
        {
            IGenericSerDesFactory factory = Factory;
            var _keySerDes = factory?.BuildKeySerDes<TKey>();

            var r0 = _keySerDes.Serialize(null, arg0);
            var r1 = _keySerDes.Serialize(null, arg1);
            return new WindowedKeyValueIterator<TKey, TValue>(factory, Store.BackwardFetch(r0, r1, arg2, arg3));
        }
        /// <inheritdoc/>
        public override WindowedKeyValueIterator<TKey, TValue> BackwardFetchAll(Java.Time.Instant arg0, Java.Time.Instant arg1)
        {
            return new WindowedKeyValueIterator<TKey, TValue>(Factory, Store.BackwardFetchAll(arg0, arg1));
        }
        /// <inheritdoc/>
        public override WindowStoreIterator<TValue> BackwardFetch(TKey arg0, Java.Time.Instant arg1, Java.Time.Instant arg2)
        {
            IGenericSerDesFactory factory = Factory;
            var _keySerDes = factory?.BuildKeySerDes<TKey>();

            var r0 = _keySerDes.Serialize(null, arg0);
            return new WindowStoreIterator<TValue>(factory, Store.BackwardFetch(r0, arg1, arg2));
        }
    }
}
