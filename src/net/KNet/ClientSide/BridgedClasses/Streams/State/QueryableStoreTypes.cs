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

using MASES.JCOBridge.C2JBridge;

namespace MASES.KNet.Streams.State
{
    public class QueryableStoreTypes : JVMBridgeBase<QueryableStoreTypes>
    {
        public override string ClassName => "org.apache.kafka.streams.state.QueryableStoreTypes";

        public static QueryableStoreType<ReadOnlyKeyValueStore<K, V>> KeyValueStore<K, V>() => SExecute<QueryableStoreType<ReadOnlyKeyValueStore<K, V>>>("keyValueStore");

        public static QueryableStoreType<ReadOnlyKeyValueStore<K, ValueAndTimestamp<V>>> TimestampedKeyValueStore<K, V>() => SExecute<QueryableStoreType<ReadOnlyKeyValueStore<K, ValueAndTimestamp<V>>>>("timestampedKeyValueStore");

        public static QueryableStoreType<ReadOnlyWindowStore<K, V>> WindowStore<K, V>() => SExecute<QueryableStoreType<ReadOnlyWindowStore<K, V>>>("windowStore");

        public static QueryableStoreType<ReadOnlyWindowStore<K, ValueAndTimestamp<V>>> TimestampedWindowStore<K, V>() => SExecute<QueryableStoreType<ReadOnlyWindowStore<K, ValueAndTimestamp<V>>>>("timestampedWindowStore");

        public static QueryableStoreType<ReadOnlySessionStore<K, V>> SessionStore<K, V>() => SExecute<QueryableStoreType<ReadOnlySessionStore<K, V>>>("sessionStore");
    }
}
