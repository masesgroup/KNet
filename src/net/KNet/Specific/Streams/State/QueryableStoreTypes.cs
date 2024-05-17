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
    /// Generator of KNet <see cref="Org.Apache.Kafka.Streams.State.QueryableStoreTypes"/>
    /// </summary>
    public static class QueryableStoreTypes
    {
        /// <summary>
        /// Supporting class for <see cref="QueryableStoreTypes"/>
        /// </summary>
        /// <typeparam name="TKNetManagedStore"></typeparam>
        /// <typeparam name="TStore"></typeparam>
        public class StoreType<TKNetManagedStore, TStore> where TKNetManagedStore : ManagedStore<TStore>, IGenericSerDesFactoryApplier
        {
            internal StoreType(Org.Apache.Kafka.Streams.State.QueryableStoreType<TStore> store) { Store = store; }
            internal Org.Apache.Kafka.Streams.State.QueryableStoreType<TStore> Store;
        }

        /// <summary>
        /// KNet value of <see cref="Org.Apache.Kafka.Streams.State.QueryableStoreTypes.KeyValueStore{K, V}"/> based on <typeparamref name="TJVMK"/> and <typeparamref name="TJVMV"/>
        /// </summary>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
        /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
        public static StoreType<ReadOnlyKeyValueStore<K, V, TJVMK, TJVMV>, Org.Apache.Kafka.Streams.State.ReadOnlyKeyValueStore<TJVMK, TJVMV>> KeyValueStore<K, V, TJVMK, TJVMV>()
        {
            return new StoreType<ReadOnlyKeyValueStore<K, V, TJVMK, TJVMV>, Org.Apache.Kafka.Streams.State.ReadOnlyKeyValueStore<TJVMK, TJVMV>>(Org.Apache.Kafka.Streams.State.QueryableStoreTypes.KeyValueStore<TJVMK, TJVMV>());
        }

        /// <summary>
        /// KNet value of <see cref="Org.Apache.Kafka.Streams.State.QueryableStoreTypes.KeyValueStore{K, V}"/> based on array of <see cref="byte"/>
        /// </summary>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        public static StoreType<ReadOnlyKeyValueStore<K, V>, Org.Apache.Kafka.Streams.State.ReadOnlyKeyValueStore<byte[], byte[]>> KeyValueStore<K, V>()
        {
            return new StoreType<ReadOnlyKeyValueStore<K, V>, Org.Apache.Kafka.Streams.State.ReadOnlyKeyValueStore<byte[], byte[]>>(Org.Apache.Kafka.Streams.State.QueryableStoreTypes.KeyValueStore<byte[], byte[]>());
        }

        /// <summary>
        /// KNet value of <see cref="Org.Apache.Kafka.Streams.State.QueryableStoreTypes.SessionStore{K, V}"/> based on <typeparamref name="TJVMK"/> and <typeparamref name="TJVMV"/>
        /// </summary>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
        /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
        public static StoreType<ReadOnlySessionStore<K, V, TJVMK, TJVMV>, Org.Apache.Kafka.Streams.State.ReadOnlySessionStore<TJVMK, TJVMV>> SessionStore<K, V, TJVMK, TJVMV>()
        {
            return new StoreType<ReadOnlySessionStore<K, V, TJVMK, TJVMV>, Org.Apache.Kafka.Streams.State.ReadOnlySessionStore<TJVMK, TJVMV>>(Org.Apache.Kafka.Streams.State.QueryableStoreTypes.SessionStore<TJVMK, TJVMV>());
        }

        /// <summary>
        /// KNet value of <see cref="Org.Apache.Kafka.Streams.State.QueryableStoreTypes.SessionStore{K, V}"/> based on array of <see cref="byte"/>
        /// </summary>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        public static StoreType<ReadOnlySessionStore<K, V>, Org.Apache.Kafka.Streams.State.ReadOnlySessionStore<byte[], byte[]>> SessionStore<K, V>()
        {
            return new StoreType<ReadOnlySessionStore<K, V>, Org.Apache.Kafka.Streams.State.ReadOnlySessionStore<byte[], byte[]>>(Org.Apache.Kafka.Streams.State.QueryableStoreTypes.SessionStore<byte[], byte[]>());
        }

        /// <summary>
        /// KNet value of <see cref="Org.Apache.Kafka.Streams.State.QueryableStoreTypes.WindowStore{K, V}"/> based on <typeparamref name="TJVMK"/> and <typeparamref name="TJVMV"/>
        /// </summary>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
        /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
        public static StoreType<ReadOnlyWindowStore<K, V, TJVMK, TJVMV>, Org.Apache.Kafka.Streams.State.ReadOnlyWindowStore<TJVMK, TJVMV>> WindowStore<K, V, TJVMK, TJVMV>()
        {
            return new StoreType<ReadOnlyWindowStore<K, V, TJVMK, TJVMV>, Org.Apache.Kafka.Streams.State.ReadOnlyWindowStore<TJVMK, TJVMV>>(Org.Apache.Kafka.Streams.State.QueryableStoreTypes.WindowStore<TJVMK, TJVMV>());
        }

        /// <summary>
        /// KNet value of <see cref="Org.Apache.Kafka.Streams.State.QueryableStoreTypes.WindowStore{K, V}"/> based on array of <see cref="byte"/>
        /// </summary>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        public static StoreType<ReadOnlyWindowStore<K, V>, Org.Apache.Kafka.Streams.State.ReadOnlyWindowStore<byte[], byte[]>> WindowStore<K, V>()
        {
            return new StoreType<ReadOnlyWindowStore<K, V>, Org.Apache.Kafka.Streams.State.ReadOnlyWindowStore<byte[], byte[]>>(Org.Apache.Kafka.Streams.State.QueryableStoreTypes.WindowStore<byte[], byte[]>());
        }

        /// <summary>
        /// KNet value of <see cref="Org.Apache.Kafka.Streams.State.QueryableStoreTypes.TimestampedKeyValueStore{K, V}"/> based on <typeparamref name="TJVMK"/> and <typeparamref name="TJVMV"/>
        /// </summary>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
        /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
        public static StoreType<TimestampedKeyValueStore<K, V, TJVMK, TJVMV>, Org.Apache.Kafka.Streams.State.ReadOnlyKeyValueStore<TJVMK, Org.Apache.Kafka.Streams.State.ValueAndTimestamp<TJVMV>>> TimestampedKeyValueStore<K, V, TJVMK, TJVMV>()
        {
            return new StoreType<TimestampedKeyValueStore<K, V, TJVMK, TJVMV>, Org.Apache.Kafka.Streams.State.ReadOnlyKeyValueStore<TJVMK, Org.Apache.Kafka.Streams.State.ValueAndTimestamp<TJVMV>>>(Org.Apache.Kafka.Streams.State.QueryableStoreTypes.TimestampedKeyValueStore<TJVMK, TJVMV>());
        }

        /// <summary>
        /// KNet value of <see cref="Org.Apache.Kafka.Streams.State.QueryableStoreTypes.TimestampedKeyValueStore{K, V}"/> based on array of <see cref="byte"/>
        /// </summary>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        public static StoreType<TimestampedKeyValueStore<K, V>, Org.Apache.Kafka.Streams.State.ReadOnlyKeyValueStore<byte[], Org.Apache.Kafka.Streams.State.ValueAndTimestamp<byte[]>>> TimestampedKeyValueStore<K, V>()
        {
            return new StoreType<TimestampedKeyValueStore<K, V>, Org.Apache.Kafka.Streams.State.ReadOnlyKeyValueStore<byte[], Org.Apache.Kafka.Streams.State.ValueAndTimestamp<byte[]>>>(Org.Apache.Kafka.Streams.State.QueryableStoreTypes.TimestampedKeyValueStore<byte[], byte[]>());
        }

        /// <summary>
        /// KNet value of <see cref="Org.Apache.Kafka.Streams.State.QueryableStoreTypes.TimestampedWindowStore{K, V}"/> based on <typeparamref name="TJVMK"/> and <typeparamref name="TJVMV"/>
        /// </summary>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
        /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
        public static StoreType<TimestampedWindowStore<K, V, TJVMK, TJVMV>, Org.Apache.Kafka.Streams.State.ReadOnlyWindowStore<TJVMK, Org.Apache.Kafka.Streams.State.ValueAndTimestamp<TJVMV>>> TimestampedWindowStore<K, V, TJVMK, TJVMV>()
        {
            return new StoreType<TimestampedWindowStore<K, V, TJVMK, TJVMV>, Org.Apache.Kafka.Streams.State.ReadOnlyWindowStore<TJVMK, Org.Apache.Kafka.Streams.State.ValueAndTimestamp<TJVMV>>>(Org.Apache.Kafka.Streams.State.QueryableStoreTypes.TimestampedWindowStore<TJVMK, TJVMV>());
        }

        /// <summary>
        /// KNet value of <see cref="Org.Apache.Kafka.Streams.State.QueryableStoreTypes.TimestampedWindowStore{K, V}"/> based on array of <see cref="byte"/>
        /// </summary>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        public static StoreType<TimestampedWindowStore<K, V>, Org.Apache.Kafka.Streams.State.ReadOnlyWindowStore<byte[], Org.Apache.Kafka.Streams.State.ValueAndTimestamp<byte[]>>> TimestampedWindowStore<K, V>()
        {
            return new StoreType<TimestampedWindowStore<K, V>, Org.Apache.Kafka.Streams.State.ReadOnlyWindowStore<byte[], Org.Apache.Kafka.Streams.State.ValueAndTimestamp<byte[]>>>(Org.Apache.Kafka.Streams.State.QueryableStoreTypes.TimestampedWindowStore<byte[], byte[]>());
        }
    }
}
