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

using MASES.KafkaBridge.Common.Utils;
using MASES.KafkaBridge.Java.Lang;
using MASES.KafkaBridge.Java.Util;
using MASES.KafkaBridge.Java.Util.Regex;
using MASES.KafkaBridge.Streams.KStream;
using MASES.KafkaBridge.Streams.Processor.Api;
using MASES.KafkaBridge.Streams.State;

namespace MASES.KafkaBridge.Streams
{
    public class StreamsBuilder : JCOBridge.C2JBridge.JVMBridgeBase<StreamsBuilder>
    {
        public override string ClassName => "org.apache.kafka.streams.StreamsBuilder";

        public KStream<K, V> Stream<K, V>(string topic)
        {
            return IExecute<KStream<K, V>>("stream", topic);
        }

        public KStream<K, V> Stream<K, V>(string topic, Consumed<K, V> consumed)
        {
            return IExecute<KStream<K, V>>("stream", topic, consumed);
        }

        public KStream<K, V> Stream<K, V>(Collection<string> topics)
        {
            return IExecute<KStream<K, V>>("stream", topics);
        }

        public KStream<K, V> Stream<K, V>(Collection<string> topics, Consumed<K, V> consumed)
        {
            return IExecute<KStream<K, V>>("stream", topics, consumed);
        }

        public KStream<K, V> Stream<K, V>(Pattern topicPattern)
        {
            return IExecute<KStream<K, V>>("stream", topicPattern);
        }

        public KStream<K, V> Stream<K, V>(Pattern topicPattern, Consumed<K, V> consumed)
        {
            return IExecute<KStream<K, V>>("stream", topicPattern);
        }

        public KTable<K, V> Table<K, V>(string topic, Consumed<K, V> consumed, Materialized<K, V, KeyValueStore<Bytes, byte[]>> materialized)
        {
            return IExecute<KTable<K, V>>("table", topic, consumed, materialized);
        }

        public KTable<K, V> Table<K, V>(string topic)
        {
            return IExecute<KTable<K, V>>("table", topic);
        }

        public KTable<K, V> Table<K, V>(string topic, Consumed<K, V> consumed)
        {
            return IExecute<KTable<K, V>>("table", topic, consumed);
        }

        public KTable<K, V> Table<K, V>(string topic, Materialized<K, V, KeyValueStore<Bytes, byte[]>> materialized)
        {
            return IExecute<KTable<K, V>>("table", topic, materialized);
        }

        public GlobalKTable<K, V> GlobalTable<K, V>(string topic, Consumed<K, V> consumed)
        {
            return IExecute<GlobalKTable<K, V>>("globalTable", topic, consumed);
        }

        public GlobalKTable<K, V> GlobalTable<K, V>(string topic)
        {
            return IExecute<GlobalKTable<K, V>>("globalTable", topic);
        }

        public GlobalKTable<K, V> GlobalTable<K, V>(string topic, Consumed<K, V> consumed, Materialized<K, V, KeyValueStore<Bytes, byte[]>> materialized)
        {
            return IExecute<GlobalKTable<K, V>>("globalTable", topic, consumed, materialized);
        }

        public GlobalKTable<K, V> GlobalTable<K, V>(string topic, Materialized<K, V, KeyValueStore<Bytes, byte[]>> materialized)
        {
            return IExecute<GlobalKTable<K, V>>("globalTable", topic, materialized);
        }

        public StreamsBuilder AddStateStore(StoreBuilder builder)
        {
            return IExecute<StreamsBuilder>("addStateStore", builder);
        }

        public StreamsBuilder AddGlobalStore<KIn, VIn>(StoreBuilder storeBuilder,
                                                       string topic,
                                                       Consumed<KIn, VIn> consumed,
                                                       ProcessorSupplier<KIn, VIn, Void, Void> stateUpdateSupplier)
        {
            return IExecute<StreamsBuilder>("addGlobalStore", storeBuilder, topic, consumed, stateUpdateSupplier);
        }

        public Topology Build()
        {
            return IExecute<Topology>("build");
        }

        public Topology Build(Properties props)
        {
            return IExecute<Topology>("build", props);
        }
    }
}
