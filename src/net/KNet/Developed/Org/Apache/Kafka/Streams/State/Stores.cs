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

using Org.Apache.Kafka.Common.Serialization;
using Java.Time;

namespace Org.Apache.Kafka.Streams.State
{
    public partial class Stores
    {
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
