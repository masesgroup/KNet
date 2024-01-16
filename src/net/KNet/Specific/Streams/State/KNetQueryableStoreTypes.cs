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
    /// Generator of KNet <see cref="Org.Apache.Kafka.Streams.State.QueryableStoreTypes"/>
    /// </summary>
    public static class KNetQueryableStoreTypes
    {
        /// <summary>
        /// Supporting class for <see cref="KNetQueryableStoreTypes"/>
        /// </summary>
        /// <typeparam name="TKNetManagedStore"></typeparam>
        /// <typeparam name="TStore"></typeparam>
        public class StoreType<TKNetManagedStore, TStore> where TKNetManagedStore : KNetManagedStore<TStore>, IGenericSerDesFactoryApplier, new()
        {
            internal StoreType(Org.Apache.Kafka.Streams.State.QueryableStoreType<TStore> store) { Store = store; }
            internal Org.Apache.Kafka.Streams.State.QueryableStoreType<TStore> Store;
        }

        /// <summary>
        /// KNet value of <see cref="Org.Apache.Kafka.Streams.State.QueryableStoreTypes.KeyValueStore{K, V}"/> based on array of <see cref="byte"/>
        /// </summary>
        public static StoreType<KNetReadOnlyKeyValueStore<TKey, TValue>, Org.Apache.Kafka.Streams.State.ReadOnlyKeyValueStore<byte[], byte[]>> KeyValueStore<TKey, TValue>()
        {
            return new StoreType<KNetReadOnlyKeyValueStore<TKey, TValue>, Org.Apache.Kafka.Streams.State.ReadOnlyKeyValueStore<byte[], byte[]>>(Org.Apache.Kafka.Streams.State.QueryableStoreTypes.KeyValueStore<byte[], byte[]>());
        }
        /// <summary>
        /// KNet value of <see cref="Org.Apache.Kafka.Streams.State.QueryableStoreTypes.SessionStore{K, V}"/> based on array of <see cref="byte"/>
        /// </summary>
        public static StoreType<KNetReadOnlySessionStore<TKey, TValue>, Org.Apache.Kafka.Streams.State.ReadOnlySessionStore<byte[], byte[]>> SessionStore<TKey, TValue>()
        {
            return new StoreType<KNetReadOnlySessionStore<TKey, TValue>, Org.Apache.Kafka.Streams.State.ReadOnlySessionStore<byte[], byte[]>>(Org.Apache.Kafka.Streams.State.QueryableStoreTypes.SessionStore<byte[], byte[]>());
        }
        /// <summary>
        /// KNet value of <see cref="Org.Apache.Kafka.Streams.State.QueryableStoreTypes.WindowStore{K, V}"/> based on array of <see cref="byte"/>
        /// </summary>
        public static StoreType<KNetReadOnlyWindowStore<TKey, TValue>, Org.Apache.Kafka.Streams.State.ReadOnlyWindowStore<byte[], byte[]>> WindowStore<TKey, TValue>()
        {
            return new StoreType<KNetReadOnlyWindowStore<TKey, TValue>, Org.Apache.Kafka.Streams.State.ReadOnlyWindowStore<byte[], byte[]>>(Org.Apache.Kafka.Streams.State.QueryableStoreTypes.WindowStore<byte[], byte[]>());
        }

        /// <summary>
        /// KNet value of <see cref="Org.Apache.Kafka.Streams.State.QueryableStoreTypes.TimestampedKeyValueStore{K, V}"/> based on array of <see cref="byte"/>
        /// </summary>
        public static StoreType<KNetTimestampedKeyValueStore<TKey, TValue>, Org.Apache.Kafka.Streams.State.ReadOnlyKeyValueStore<byte[], Org.Apache.Kafka.Streams.State.ValueAndTimestamp<byte[]>>> TimestampedKeyValueStore<TKey, TValue>()
        {
            return new StoreType<KNetTimestampedKeyValueStore<TKey, TValue>, Org.Apache.Kafka.Streams.State.ReadOnlyKeyValueStore<byte[], Org.Apache.Kafka.Streams.State.ValueAndTimestamp<byte[]>>>(Org.Apache.Kafka.Streams.State.QueryableStoreTypes.TimestampedKeyValueStore<byte[], byte[]>());
        }

        /// <summary>
        /// KNet value of <see cref="Org.Apache.Kafka.Streams.State.QueryableStoreTypes.TimestampedWindowStore{K, V}"/> based on array of <see cref="byte"/>
        /// </summary>
        public static StoreType<KNetTimestampedWindowStore<TKey, TValue>, Org.Apache.Kafka.Streams.State.ReadOnlyWindowStore<byte[], Org.Apache.Kafka.Streams.State.ValueAndTimestamp<byte[]>>> TimestampedWindowStore<TKey, TValue>()
        {
            return new StoreType<KNetTimestampedWindowStore<TKey, TValue>, Org.Apache.Kafka.Streams.State.ReadOnlyWindowStore<byte[], Org.Apache.Kafka.Streams.State.ValueAndTimestamp<byte[]>>>(Org.Apache.Kafka.Streams.State.QueryableStoreTypes.TimestampedWindowStore<byte[], byte[]>());
        }
    }
}
