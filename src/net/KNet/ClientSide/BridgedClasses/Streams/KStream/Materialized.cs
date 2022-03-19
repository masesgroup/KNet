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
using MASES.KNet.Common.Utils;
using Java.Time;
using Java.Util;
using MASES.KNet.Streams.Processor;
using MASES.KNet.Streams.State;

namespace MASES.KNet.Streams.KStream
{
    public class Materialized<K, V, S> : JCOBridge.C2JBridge.JVMBridgeBase<Materialized<K, V, S>>
        where S : IStateStore
    {
        public override string ClassName => "org.apache.kafka.streams.kstream.Materialized";

        public static Materialized<K, V, S> As(string storeName)
        {
            return SExecute<Materialized<K, V, S>>("as", storeName);
        }

        public static Materialized<K, V, WindowStore<Bytes, byte[]>> As(WindowBytesStoreSupplier supplier)
        {
            return SExecute<Materialized<K, V, WindowStore<Bytes, byte[]>>>("as", supplier);
        }

        public static Materialized<K, V, SessionStore<Bytes, byte[]>> As(SessionBytesStoreSupplier supplier)
        {
            return SExecute<Materialized<K, V, SessionStore<Bytes, byte[]>>>("as", supplier);
        }

        public static Materialized<K, V, KeyValueStore<Bytes, byte[]>> As(KeyValueBytesStoreSupplier supplier)
        {
            return SExecute<Materialized<K, V, KeyValueStore<Bytes, byte[]>>>("as", supplier);
        }

        public static Materialized<K, V, S> With(Serde<K> keySerde, Serde<V> valueSerde)
        {
            return SExecute<Materialized<K, V, S>>("with", keySerde, valueSerde);
        }

        public Materialized<K, V, S> WithValueSerde(Serde<V> valueSerde)
        {
            return IExecute<Materialized<K, V, S>>("withValueSerde", valueSerde);
        }

        public Materialized<K, V, S> WithKeySerde(Serde<K> keySerde)
        {
            return IExecute<Materialized<K, V, S>>("withKeySerde", keySerde);
        }

        public Materialized<K, V, S> WithLoggingEnabled(Map<string, string> config)
        {
            return IExecute<Materialized<K, V, S>>("withLoggingEnabled", config);
        }

        public Materialized<K, V, S> WithLoggingDisabled()
        {
            return IExecute<Materialized<K, V, S>>("withLoggingDisabled");
        }

        public Materialized<K, V, S> WithCachingEnabled()
        {
            return IExecute<Materialized<K, V, S>>("withCachingEnabled");
        }

        public Materialized<K, V, S> WithCachingDisabled()
        {
            return IExecute<Materialized<K, V, S>>("withCachingDisabled");
        }

        public Materialized<K, V, S> WithRetention(Duration retention)
        {
            return IExecute<Materialized<K, V, S>>("withRetention", retention);
        }
    }
}
