/*
*  Copyright 2022 MASES s.r.l.
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

using MASES.KNet.Common.Serialization;
using Java.Time;

namespace MASES.KNet.Streams.State
{
    public class Stores : JCOBridge.C2JBridge.JVMBridgeBase<Stores>
    {
        public override string ClassName => "org.apache.kafka.streams.state.Stores";

        public static KeyValueBytesStoreSupplier PersistentKeyValueStore(string name)
        {
            return SExecute<KeyValueBytesStoreSupplier>("persistentKeyValueStore", name);
        }

        public static KeyValueBytesStoreSupplier PersistentTimestampedKeyValueStore(string name)
        {
            return SExecute<KeyValueBytesStoreSupplier>("persistentTimestampedKeyValueStore", name);
        }

        public static KeyValueBytesStoreSupplier InMemoryKeyValueStore(string name)
        {
            return SExecute<KeyValueBytesStoreSupplier>("inMemoryKeyValueStore", name);
        }

        public static KeyValueBytesStoreSupplier LruMap(string name, int maxCacheSize)
        {
            return SExecute<KeyValueBytesStoreSupplier>("lruMap", name, maxCacheSize);
        }


        public static WindowBytesStoreSupplier PersistentWindowStore(string name,
                                                                      Duration retentionPeriod,
                                                                      Duration windowSize,
                                                                      bool retainDuplicates)
        {
            return SExecute<WindowBytesStoreSupplier>("persistentWindowStore", name, retentionPeriod, windowSize, retainDuplicates);
        }

        public static WindowBytesStoreSupplier PersistentTimestampedWindowStore(string name,
                                                                                Duration retentionPeriod,
                                                                                Duration windowSize,
                                                                                bool retainDuplicates)
        {
            return SExecute<WindowBytesStoreSupplier>("persistentTimestampedWindowStore", name, retentionPeriod, windowSize, retainDuplicates);
        }

        public static WindowBytesStoreSupplier InMemoryWindowStore(string name,
                                                                    Duration retentionPeriod,
                                                                    Duration windowSize,
                                                                    bool retainDuplicates)
        {
            return SExecute<WindowBytesStoreSupplier>("inMemoryWindowStore", name, retentionPeriod, windowSize, retainDuplicates);
        }

        public static SessionBytesStoreSupplier PersistentSessionStore(string name,
                                                                        Duration retentionPeriod)
        {
            return SExecute<SessionBytesStoreSupplier>("persistentSessionStore", name, retentionPeriod);
        }

        public static SessionBytesStoreSupplier InMemorySessionStore(string name, Duration retentionPeriod)
        {
            return SExecute<SessionBytesStoreSupplier>("inMemorySessionStore", name, retentionPeriod);
        }


        public static StoreBuilder<KeyValueStore<K, V>> KeyValueStoreBuilder<K, V>(KeyValueBytesStoreSupplier supplier,
                                                                                   Serde<K> keySerde,
                                                                                   Serde<V> valueSerde)
        {
            return SExecute<StoreBuilder<KeyValueStore<K, V>>>("keyValueStoreBuilder", supplier, keySerde, valueSerde);
        }

        public static StoreBuilder<TimestampedKeyValueStore<K, V>> TimestampedKeyValueStoreBuilder<K, V>(KeyValueBytesStoreSupplier supplier,
                                                                                                         Serde<K> keySerde,
                                                                                                         Serde<V> valueSerde)
        {
            return SExecute<StoreBuilder<TimestampedKeyValueStore<K, V>>>("timestampedKeyValueStoreBuilder", supplier, keySerde, valueSerde);
        }

        public static StoreBuilder<WindowStore<K, V>> WindowStoreBuilder<K, V>(WindowBytesStoreSupplier supplier,
                                                                               Serde<K> keySerde,
                                                                               Serde<V> valueSerde)
        {
            return SExecute<StoreBuilder<WindowStore<K, V>>>("windowStoreBuilder", supplier, keySerde, valueSerde);
        }

        public static StoreBuilder<TimestampedWindowStore<K, V>> TimestampedWindowStoreBuilder<K, V>(WindowBytesStoreSupplier supplier,
                                                                                                     Serde<K> keySerde,
                                                                                                     Serde<V> valueSerde)
        {
            return SExecute<StoreBuilder<TimestampedWindowStore<K, V>>>("timestampedWindowStoreBuilder", supplier, keySerde, valueSerde);
        }

        public static StoreBuilder<SessionStore<K, V>> SessionStoreBuilder<K, V>(SessionBytesStoreSupplier supplier,
                                                                                 Serde<K> keySerde,
                                                                                 Serde<V> valueSerde)
        {
            return SExecute<StoreBuilder<SessionStore<K, V>>>("sessionStoreBuilder", supplier, keySerde, valueSerde);
        }
    }
}
