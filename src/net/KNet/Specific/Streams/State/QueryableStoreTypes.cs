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
    /// Generator of KNet <see cref="Org.Apache.Kafka.Streams.State.QueryableStoreTypes"/>
    /// </summary>
    public static class QueryableStoreTypes
    {
        /// <summary>
        /// Supporting class for <see cref="QueryableStoreTypes"/>
        /// </summary>
        /// <typeparam name="TKNetManagedStore"></typeparam>
        /// <typeparam name="TStore"></typeparam>
        public class StoreType<TKNetManagedStore, TStore> where TKNetManagedStore : ManagedStore<TStore>, IGenericSerDesFactoryApplier, new()
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
        /// <typeparam name="TConcreteStore">A concrete type extending <see cref="ReadOnlyKeyValueStore{K, V, TJVMK, TJVMV}"/></typeparam>
        public static StoreType<TConcreteStore, Org.Apache.Kafka.Streams.State.ReadOnlyKeyValueStore<TJVMK, TJVMV>> KeyValueStore<K, V, TJVMK, TJVMV, TConcreteStore>()
            where TConcreteStore : ReadOnlyKeyValueStore<K, V, TJVMK, TJVMV>, new()
        {
            return new StoreType<TConcreteStore, Org.Apache.Kafka.Streams.State.ReadOnlyKeyValueStore<TJVMK, TJVMV>>(Org.Apache.Kafka.Streams.State.QueryableStoreTypes.KeyValueStore<TJVMK, TJVMV>());
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
            return KeyValueStore<K, V, TJVMK, TJVMV, ReadOnlyKeyValueStore<K, V, TJVMK, TJVMV>>();
        }

        /// <summary>
        /// KNet value of <see cref="Org.Apache.Kafka.Streams.State.QueryableStoreTypes.KeyValueStore{K, V}"/> based on array of <see cref="byte"/>
        /// </summary>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        public static StoreType<ReadOnlyKeyValueStore<K, V>, Org.Apache.Kafka.Streams.State.ReadOnlyKeyValueStore<byte[], byte[]>> KeyValueStore<K, V>()
        {
            return KeyValueStore<K, V, byte[], byte[], ReadOnlyKeyValueStore<K, V>>();
        }

        /// <summary>
        /// KNet value of <see cref="Org.Apache.Kafka.Streams.State.QueryableStoreTypes.SessionStore{K, V}"/> based on <typeparamref name="TJVMK"/> and <typeparamref name="TJVMV"/>
        /// </summary>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
        /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
        /// <typeparam name="TConcreteStore">A concrete type extending <see cref="ReadOnlySessionStore{K, V, TJVMK, TJVMV}"/></typeparam>
        public static StoreType<TConcreteStore, Org.Apache.Kafka.Streams.State.ReadOnlySessionStore<TJVMK, TJVMV>> SessionStore<K, V, TJVMK, TJVMV, TConcreteStore>()
            where TConcreteStore : ReadOnlySessionStore<K, V, TJVMK, TJVMV>, new()
        {
            return new StoreType<TConcreteStore, Org.Apache.Kafka.Streams.State.ReadOnlySessionStore<TJVMK, TJVMV>>(Org.Apache.Kafka.Streams.State.QueryableStoreTypes.SessionStore<TJVMK, TJVMV>());
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
            return SessionStore<K, V, TJVMK, TJVMV, ReadOnlySessionStore<K, V, TJVMK, TJVMV>>();
        }

        /// <summary>
        /// KNet value of <see cref="Org.Apache.Kafka.Streams.State.QueryableStoreTypes.SessionStore{K, V}"/> based on array of <see cref="byte"/>
        /// </summary>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        public static StoreType<ReadOnlySessionStore<K, V>, Org.Apache.Kafka.Streams.State.ReadOnlySessionStore<byte[], byte[]>> SessionStore<K, V>()
        {
            return SessionStore<K, V, byte[], byte[], ReadOnlySessionStore<K, V>>();
        }

        /// <summary>
        /// KNet value of <see cref="Org.Apache.Kafka.Streams.State.QueryableStoreTypes.WindowStore{K, V}"/> based on <typeparamref name="TJVMK"/> and <typeparamref name="TJVMV"/>
        /// </summary>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
        /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
        /// <typeparam name="TConcreteStore">A concrete type extending <see cref="ReadOnlyWindowStore{K, V, TJVMK, TJVMV}"/></typeparam>
        public static StoreType<TConcreteStore, Org.Apache.Kafka.Streams.State.ReadOnlyWindowStore<TJVMK, TJVMV>> WindowStore<K, V, TJVMK, TJVMV, TConcreteStore>()
            where TConcreteStore : ReadOnlyWindowStore<K, V, TJVMK, TJVMV>, new()
        {
            return new StoreType<TConcreteStore, Org.Apache.Kafka.Streams.State.ReadOnlyWindowStore<TJVMK, TJVMV>>(Org.Apache.Kafka.Streams.State.QueryableStoreTypes.WindowStore<TJVMK, TJVMV>());
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
            return WindowStore<K, V, TJVMK, TJVMV, ReadOnlyWindowStore<K, V, TJVMK, TJVMV>>();
        }

        /// <summary>
        /// KNet value of <see cref="Org.Apache.Kafka.Streams.State.QueryableStoreTypes.WindowStore{K, V}"/> based on array of <see cref="byte"/>
        /// </summary>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        public static StoreType<ReadOnlyWindowStore<K, V>, Org.Apache.Kafka.Streams.State.ReadOnlyWindowStore<byte[], byte[]>> WindowStore<K, V>()
        {
            return WindowStore<K, V, byte[], byte[], ReadOnlyWindowStore<K, V>>();
        }

        /// <summary>
        /// KNet value of <see cref="Org.Apache.Kafka.Streams.State.QueryableStoreTypes.TimestampedKeyValueStore{K, V}"/> based on <typeparamref name="TJVMK"/> and <typeparamref name="TJVMV"/>
        /// </summary>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
        /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
        /// <typeparam name="TConcreteStore">A concrete type extending <see cref="TimestampedKeyValueStore{K, V, TJVMK, TJVMV}"/></typeparam>
        public static StoreType<TConcreteStore, Org.Apache.Kafka.Streams.State.ReadOnlyKeyValueStore<TJVMK, Org.Apache.Kafka.Streams.State.ValueAndTimestamp<TJVMV>>> TimestampedKeyValueStore<K, V, TJVMK, TJVMV, TConcreteStore>()
            where TConcreteStore : TimestampedKeyValueStore<K, V, TJVMK, TJVMV>, new()
        {
            return new StoreType<TConcreteStore, Org.Apache.Kafka.Streams.State.ReadOnlyKeyValueStore<TJVMK, Org.Apache.Kafka.Streams.State.ValueAndTimestamp<TJVMV>>>(Org.Apache.Kafka.Streams.State.QueryableStoreTypes.TimestampedKeyValueStore<TJVMK, TJVMV>());
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
            return TimestampedKeyValueStore<K, V, TJVMK, TJVMV, TimestampedKeyValueStore<K, V, TJVMK, TJVMV>>();
        }

        /// <summary>
        /// KNet value of <see cref="Org.Apache.Kafka.Streams.State.QueryableStoreTypes.TimestampedKeyValueStore{K, V}"/> based on array of <see cref="byte"/>
        /// </summary>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        public static StoreType<TimestampedKeyValueStore<K, V>, Org.Apache.Kafka.Streams.State.ReadOnlyKeyValueStore<byte[], Org.Apache.Kafka.Streams.State.ValueAndTimestamp<byte[]>>> TimestampedKeyValueStore<K, V>()
        {
            return TimestampedKeyValueStore<K, V, byte[], byte[], TimestampedKeyValueStore<K, V>>();
        }

        /// <summary>
        /// KNet value of <see cref="Org.Apache.Kafka.Streams.State.QueryableStoreTypes.TimestampedWindowStore{K, V}"/> based on <typeparamref name="TJVMK"/> and <typeparamref name="TJVMV"/>
        /// </summary>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
        /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
        /// <typeparam name="TConcreteStore">A concrete type extending <see cref="TimestampedWindowStore{K, V, TJVMK, TJVMV}"/></typeparam>
        public static StoreType<TConcreteStore, Org.Apache.Kafka.Streams.State.ReadOnlyWindowStore<TJVMK, Org.Apache.Kafka.Streams.State.ValueAndTimestamp<TJVMV>>> TimestampedWindowStore<K, V, TJVMK, TJVMV, TConcreteStore>()
            where TConcreteStore : TimestampedWindowStore<K, V, TJVMK, TJVMV>, new()
        {
            return new StoreType<TConcreteStore, Org.Apache.Kafka.Streams.State.ReadOnlyWindowStore<TJVMK, Org.Apache.Kafka.Streams.State.ValueAndTimestamp<TJVMV>>>(Org.Apache.Kafka.Streams.State.QueryableStoreTypes.TimestampedWindowStore<TJVMK, TJVMV>());
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
            return TimestampedWindowStore<K, V, TJVMK, TJVMV, TimestampedWindowStore<K, V, TJVMK, TJVMV>>();
        }

        /// <summary>
        /// KNet value of <see cref="Org.Apache.Kafka.Streams.State.QueryableStoreTypes.TimestampedWindowStore{K, V}"/> based on array of <see cref="byte"/>
        /// </summary>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        public static StoreType<TimestampedWindowStore<K, V>, Org.Apache.Kafka.Streams.State.ReadOnlyWindowStore<byte[], Org.Apache.Kafka.Streams.State.ValueAndTimestamp<byte[]>>> TimestampedWindowStore<K, V>()
        {
            return TimestampedWindowStore<K, V, byte[], byte[], TimestampedWindowStore<K, V>>();
        }
    }
}
