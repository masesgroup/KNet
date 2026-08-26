/*
*  Copyright (c) 2021-2026 MASES s.r.l.
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
        /// <typeparam name="TKNetManagedStore">A class extending <see cref="ManagedStore{TStore}"/> </typeparam>
        /// <typeparam name="TStore">The standard Kafka backing store</typeparam>
        public class StoreType<TKNetManagedStore, TStore> : System.IDisposable
            where TKNetManagedStore : ManagedStore<TStore>, IGenericSerDesFactoryApplier
        {
            Org.Apache.Kafka.Streams.State.QueryableStoreType<TStore> _store;
            internal StoreType(Org.Apache.Kafka.Streams.State.QueryableStoreType<TStore> store) { _store = store; }
            internal Org.Apache.Kafka.Streams.State.QueryableStoreType<TStore> Store => _store;
            /// <inheritdoc/>
            void System.IDisposable.Dispose()
            {
                _store?.Dispose();
            }
        }

        #region TimestampedKeyValueStore

        /// <summary>
        /// KNet value of <see cref="Org.Apache.Kafka.Streams.State.QueryableStoreTypes.TimestampedKeyValueStore{K, V}"/> based on <typeparamref name="TJVMK"/> and <typeparamref name="TJVMV"/>
        /// </summary>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
        /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
        /// <typeparam name="TConcreteStore">A concrete type extending <see cref="TimestampedKeyValueStore{K, V, TJVMK, TJVMV}"/></typeparam>
        public static StoreType<TConcreteStore, Org.Apache.Kafka.Streams.State.ReadOnlyKeyValueStore<TJVMK, Org.Apache.Kafka.Streams.State.ValueAndTimestamp<TJVMV>>> TimestampedKeyValueStore<K, V, TJVMK, TJVMV, TConcreteStore>()
            where TConcreteStore : TimestampedKeyValueStore<K, V, TJVMK, TJVMV>
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

        #endregion

        #region TimestampedKeyValueStoreWithHeaders

        /// <summary>
        /// KNet value of <see cref="Org.Apache.Kafka.Streams.State.QueryableStoreTypes.TimestampedKeyValueStoreWithHeaders{K, V}"/> based on <typeparamref name="TJVMK"/> and <typeparamref name="TJVMV"/>
        /// </summary>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
        /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
        /// <typeparam name="TConcreteStore">A concrete type extending <see cref="TimestampedKeyValueStoreWithHeaders{K, V, TJVMK, TJVMV}"/></typeparam>
        public static StoreType<TConcreteStore, Org.Apache.Kafka.Streams.State.ReadOnlyKeyValueStore<TJVMK, Org.Apache.Kafka.Streams.State.ValueTimestampHeaders<TJVMV>>> TimestampedKeyValueStoreWithHeaders<K, V, TJVMK, TJVMV, TConcreteStore>()
            where TConcreteStore : TimestampedKeyValueStoreWithHeaders<K, V, TJVMK, TJVMV>
        {
            return new StoreType<TConcreteStore, Org.Apache.Kafka.Streams.State.ReadOnlyKeyValueStore<TJVMK, Org.Apache.Kafka.Streams.State.ValueTimestampHeaders<TJVMV>>>(Org.Apache.Kafka.Streams.State.QueryableStoreTypes.TimestampedKeyValueStoreWithHeaders<TJVMK, TJVMV>());
        }

        /// <summary>
        /// KNet value of <see cref="Org.Apache.Kafka.Streams.State.QueryableStoreTypes.TimestampedKeyValueStoreWithHeaders{K, V}"/> based on <typeparamref name="TJVMK"/> and <typeparamref name="TJVMV"/>
        /// </summary>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
        /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
        public static StoreType<TimestampedKeyValueStoreWithHeaders<K, V, TJVMK, TJVMV>, Org.Apache.Kafka.Streams.State.ReadOnlyKeyValueStore<TJVMK, Org.Apache.Kafka.Streams.State.ValueTimestampHeaders<TJVMV>>> TimestampedKeyValueStoreWithHeaders<K, V, TJVMK, TJVMV>()
        {
            return TimestampedKeyValueStoreWithHeaders<K, V, TJVMK, TJVMV, TimestampedKeyValueStoreWithHeaders<K, V, TJVMK, TJVMV>>();
        }

        /// <summary>
        /// KNet value of <see cref="Org.Apache.Kafka.Streams.State.QueryableStoreTypes.TimestampedKeyValueStore{K, V}"/> based on array of <see cref="byte"/>
        /// </summary>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        public static StoreType<TimestampedKeyValueStoreWithHeaders<K, V>, Org.Apache.Kafka.Streams.State.ReadOnlyKeyValueStore<byte[], Org.Apache.Kafka.Streams.State.ValueTimestampHeaders<byte[]>>> TimestampedKeyValueStoreWithHeaders<K, V>()
        {
            return TimestampedKeyValueStoreWithHeaders<K, V, byte[], byte[], TimestampedKeyValueStoreWithHeaders<K, V>>();
        }

        #endregion

        #region KeyValueStore

        /// <summary>
        /// KNet value of <see cref="Org.Apache.Kafka.Streams.State.QueryableStoreTypes.KeyValueStore{K, V}"/> based on <typeparamref name="TJVMK"/> and <typeparamref name="TJVMV"/>
        /// </summary>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
        /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
        /// <typeparam name="TConcreteStore">A concrete type extending <see cref="ReadOnlyKeyValueStore{K, V, TJVMK, TJVMV}"/></typeparam>
        public static StoreType<TConcreteStore, Org.Apache.Kafka.Streams.State.ReadOnlyKeyValueStore<TJVMK, TJVMV>> KeyValueStore<K, V, TJVMK, TJVMV, TConcreteStore>()
            where TConcreteStore : ReadOnlyKeyValueStore<K, V, TJVMK, TJVMV>
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

        #endregion

        #region SessionStoreWithHeaders

        /// <summary>
        /// KNet value of <see cref="Org.Apache.Kafka.Streams.State.QueryableStoreTypes.SessionStoreWithHeaders{K, V}"/> based on <typeparamref name="TJVMK"/> and <typeparamref name="TJVMV"/>
        /// </summary>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
        /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
        /// <typeparam name="TConcreteStore">A concrete type extending <see cref="SessionStoreWithHeaders{K, V, TJVMK, TJVMV}"/></typeparam>
        public static StoreType<TConcreteStore, Org.Apache.Kafka.Streams.State.ReadOnlySessionStore<TJVMK, Org.Apache.Kafka.Streams.State.AggregationWithHeaders<TJVMV>>> SessionStoreWithHeaders<K, V, TJVMK, TJVMV, TConcreteStore>()
            where TConcreteStore : SessionStoreWithHeaders<K, V, TJVMK, TJVMV>
        {
            return new StoreType<TConcreteStore, Org.Apache.Kafka.Streams.State.ReadOnlySessionStore<TJVMK, Org.Apache.Kafka.Streams.State.AggregationWithHeaders<TJVMV>>>(Org.Apache.Kafka.Streams.State.QueryableStoreTypes.SessionStoreWithHeaders<TJVMK, TJVMV>());
        }

        /// <summary>
        /// KNet value of <see cref="Org.Apache.Kafka.Streams.State.QueryableStoreTypes.SessionStoreWithHeaders{K, V}"/> based on <typeparamref name="TJVMK"/> and <typeparamref name="TJVMV"/>
        /// </summary>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
        /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
        public static StoreType<SessionStoreWithHeaders<K, V, TJVMK, TJVMV>, Org.Apache.Kafka.Streams.State.ReadOnlySessionStore<TJVMK, Org.Apache.Kafka.Streams.State.AggregationWithHeaders<TJVMV>>> SessionStoreWithHeaders<K, V, TJVMK, TJVMV>()
        {
            return SessionStoreWithHeaders<K, V, TJVMK, TJVMV, SessionStoreWithHeaders<K, V, TJVMK, TJVMV>>();
        }

        /// <summary>
        /// KNet value of <see cref="Org.Apache.Kafka.Streams.State.QueryableStoreTypes.SessionStoreWithHeaders{K, V}"/> based on array of <see cref="byte"/>
        /// </summary>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        public static StoreType<SessionStoreWithHeaders<K, V>, Org.Apache.Kafka.Streams.State.ReadOnlySessionStore<byte[], Org.Apache.Kafka.Streams.State.AggregationWithHeaders<byte[]>>> SessionStoreWithHeaders<K, V>()
        {
            return SessionStoreWithHeaders<K, V, byte[], byte[], SessionStoreWithHeaders<K, V>>();
        }

        #endregion

        #region SessionStore

        /// <summary>
        /// KNet value of <see cref="Org.Apache.Kafka.Streams.State.QueryableStoreTypes.SessionStore{K, V}"/> based on <typeparamref name="TJVMK"/> and <typeparamref name="TJVMV"/>
        /// </summary>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
        /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
        /// <typeparam name="TConcreteStore">A concrete type extending <see cref="ReadOnlySessionStore{K, V, TJVMK, TJVMV}"/></typeparam>
        public static StoreType<TConcreteStore, Org.Apache.Kafka.Streams.State.ReadOnlySessionStore<TJVMK, TJVMV>> SessionStore<K, V, TJVMK, TJVMV, TConcreteStore>()
            where TConcreteStore : ReadOnlySessionStore<K, V, TJVMK, TJVMV>
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

        #endregion

        #region TimestampedWindowStore

        /// <summary>
        /// KNet value of <see cref="Org.Apache.Kafka.Streams.State.QueryableStoreTypes.TimestampedWindowStore{K, V}"/> based on <typeparamref name="TJVMK"/> and <typeparamref name="TJVMV"/>
        /// </summary>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
        /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
        /// <typeparam name="TConcreteStore">A concrete type extending <see cref="TimestampedWindowStore{K, V, TJVMK, TJVMV}"/></typeparam>
        public static StoreType<TConcreteStore, Org.Apache.Kafka.Streams.State.ReadOnlyWindowStore<TJVMK, Org.Apache.Kafka.Streams.State.ValueAndTimestamp<TJVMV>>> TimestampedWindowStore<K, V, TJVMK, TJVMV, TConcreteStore>()
            where TConcreteStore : TimestampedWindowStore<K, V, TJVMK, TJVMV>
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

        #endregion

        #region TimestampedWindowStoreWithHeaders

        /// <summary>
        /// KNet value of <see cref="Org.Apache.Kafka.Streams.State.QueryableStoreTypes.TimestampedWindowStore{K, V}"/> based on <typeparamref name="TJVMK"/> and <typeparamref name="TJVMV"/>
        /// </summary>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
        /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
        /// <typeparam name="TConcreteStore">A concrete type extending <see cref="TimestampedWindowStoreWithHeaders{K, V, TJVMK, TJVMV}"/></typeparam>
        public static StoreType<TConcreteStore, Org.Apache.Kafka.Streams.State.ReadOnlyWindowStore<TJVMK, Org.Apache.Kafka.Streams.State.ValueTimestampHeaders<TJVMV>>> TimestampedWindowStoreWithHeaders<K, V, TJVMK, TJVMV, TConcreteStore>()
            where TConcreteStore : TimestampedWindowStoreWithHeaders<K, V, TJVMK, TJVMV>
        {
            return new StoreType<TConcreteStore, Org.Apache.Kafka.Streams.State.ReadOnlyWindowStore<TJVMK, Org.Apache.Kafka.Streams.State.ValueTimestampHeaders<TJVMV>>>(Org.Apache.Kafka.Streams.State.QueryableStoreTypes.TimestampedWindowStoreWithHeaders<TJVMK, TJVMV>());
        }

        /// <summary>
        /// KNet value of <see cref="Org.Apache.Kafka.Streams.State.QueryableStoreTypes.TimestampedWindowStoreWithHeaders{K, V}"/> based on <typeparamref name="TJVMK"/> and <typeparamref name="TJVMV"/>
        /// </summary>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
        /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
        public static StoreType<TimestampedWindowStoreWithHeaders<K, V, TJVMK, TJVMV>, Org.Apache.Kafka.Streams.State.ReadOnlyWindowStore<TJVMK, Org.Apache.Kafka.Streams.State.ValueTimestampHeaders<TJVMV>>> TimestampedWindowStoreWithHeaders<K, V, TJVMK, TJVMV>()
        {
            return TimestampedWindowStoreWithHeaders<K, V, TJVMK, TJVMV, TimestampedWindowStoreWithHeaders<K, V, TJVMK, TJVMV>>();
        }

        /// <summary>
        /// KNet value of <see cref="Org.Apache.Kafka.Streams.State.QueryableStoreTypes.TimestampedWindowStore{K, V}"/> based on array of <see cref="byte"/>
        /// </summary>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        public static StoreType<TimestampedWindowStoreWithHeaders<K, V>, Org.Apache.Kafka.Streams.State.ReadOnlyWindowStore<byte[], Org.Apache.Kafka.Streams.State.ValueTimestampHeaders<byte[]>>> TimestampedWindowStoreWithHeaders<K, V>()
        {
            return TimestampedWindowStoreWithHeaders<K, V, byte[], byte[], TimestampedWindowStoreWithHeaders<K, V>>();
        }

        #endregion

        #region WindowStore

        /// <summary>
        /// KNet value of <see cref="Org.Apache.Kafka.Streams.State.QueryableStoreTypes.WindowStore{K, V}"/> based on <typeparamref name="TJVMK"/> and <typeparamref name="TJVMV"/>
        /// </summary>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
        /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
        /// <typeparam name="TConcreteStore">A concrete type extending <see cref="ReadOnlyWindowStore{K, V, TJVMK, TJVMV}"/></typeparam>
        public static StoreType<TConcreteStore, Org.Apache.Kafka.Streams.State.ReadOnlyWindowStore<TJVMK, TJVMV>> WindowStore<K, V, TJVMK, TJVMV, TConcreteStore>()
            where TConcreteStore : ReadOnlyWindowStore<K, V, TJVMK, TJVMV>
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

        #endregion
    }
}
