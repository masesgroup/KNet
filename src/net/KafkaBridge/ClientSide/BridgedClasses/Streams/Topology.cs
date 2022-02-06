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

using MASES.KafkaBridge.Common.Serialization;
using MASES.KafkaBridge.Java.Lang;
using MASES.KafkaBridge.Java.Util.Regex;
using MASES.KafkaBridge.Streams.Processor;
using MASES.KafkaBridge.Streams.State;

namespace MASES.KafkaBridge.Streams
{
    public class Topology : JCOBridge.C2JBridge.JVMBridgeBase<Topology>
    {
        public enum AutoOffsetReset
        {
            EARLIEST, LATEST
        }

        public override string ClassName => "org.apache.kafka.streams.Topology";

        public Topology AddSource(string name, params string[] topics)
        {
            return IExecute<Topology>("addSource", name, topics);
        }

        public Topology AddSource(string name, Pattern topicPattern)
        {
            return IExecute<Topology>("addSource", name, topicPattern);
        }

        public Topology AddSource(AutoOffsetReset offsetReset, string name, params string[] topics)
        {
            return IExecute<Topology>("addSource", offsetReset, name, topics);
        }

        public Topology AddSource(AutoOffsetReset offsetReset, string name, Pattern topicPattern)
        {
            return IExecute<Topology>("addSource", offsetReset, name, topicPattern);
        }

        public Topology AddSource(TimestampExtractor timestampExtractor, string name, params string[] topics)
        {
            return IExecute<Topology>("addSource", timestampExtractor, name, topics);
        }

        public Topology AddSource(TimestampExtractor timestampExtractor, string name, Pattern topicPattern)
        {
            return IExecute<Topology>("addSource", timestampExtractor, name, topicPattern);
        }

        public Topology AddSource(AutoOffsetReset offsetReset, TimestampExtractor timestampExtractor, string name, params string[] topics)
        {
            return IExecute<Topology>("addSource", offsetReset, timestampExtractor, name, topics);
        }

        public Topology AddSource(AutoOffsetReset offsetReset, TimestampExtractor timestampExtractor, string name, Pattern topicPattern)
        {
            return IExecute<Topology>("addSource", offsetReset, timestampExtractor, name, topicPattern);
        }

        public Topology AddSource(string name, IDeserializer keyDeserializer, IDeserializer valueDeserializer, params string[] topics)
        {
            return IExecute<Topology>("addSource", name, keyDeserializer, valueDeserializer, topics);
        }

        public Topology AddSource(string name, IDeserializer keyDeserializer, IDeserializer valueDeserializer, Pattern topicPattern)
        {
            return IExecute<Topology>("addSource", name, keyDeserializer, valueDeserializer, topicPattern);
        }

        public Topology AddSource(AutoOffsetReset offsetReset, string name, IDeserializer keyDeserializer, IDeserializer valueDeserializer, params string[] topics)
        {
            return IExecute<Topology>("addSource", offsetReset, name, keyDeserializer, valueDeserializer, topics);
        }

        public Topology AddSource(AutoOffsetReset offsetReset, string name, IDeserializer keyDeserializer, IDeserializer valueDeserializer, Pattern topicPattern)
        {
            return IExecute<Topology>("addSource", offsetReset, name, keyDeserializer, valueDeserializer, topicPattern);
        }

        public Topology AddSource(AutoOffsetReset offsetReset, string name, TimestampExtractor timestampExtractor, IDeserializer keyDeserializer, IDeserializer valueDeserializer, params string[] topics)
        {
            return IExecute<Topology>("addSource", offsetReset, name, timestampExtractor, keyDeserializer, valueDeserializer, topics);
        }

        public Topology AddSource(AutoOffsetReset offsetReset, string name, TimestampExtractor timestampExtractor, IDeserializer keyDeserializer, IDeserializer valueDeserializer, Pattern topicPattern)
        {
            return IExecute<Topology>("addSource", offsetReset, name, timestampExtractor, keyDeserializer, valueDeserializer, topicPattern);
        }

        public Topology AddSink(string name, string topic, params string[] parentNames)
        {
            return IExecute<Topology>("addSink", name, topic, parentNames);
        }

        public Topology AddSink<TSuperK, TSuperV, K, V>(string name, string topic, StreamPartitioner<TSuperK, TSuperV> partitioner, params string[] parentNames)
            where TSuperK : K
            where TSuperV : V
        {
            return IExecute<Topology>("addSink", name, topic, partitioner, parentNames);
        }

        public Topology AddSink<K, V>(string name, string topic, Serializer<K> keySerializer, Serializer<V> valueSerializer, params string[] parentNames)
        {
            return IExecute<Topology>("addSink", name, topic, keySerializer, valueSerializer, parentNames);
        }

        public Topology AddSink<TSuperK, TSuperV, K, V>(string name, string topic, Serializer<K> keySerializer, Serializer<V> valueSerializer, StreamPartitioner<TSuperK, TSuperV> partitioner, params string[] parentNames)
            where TSuperK : K
            where TSuperV : V
        {
            return IExecute<Topology>("addSink", name, topic, keySerializer, valueSerializer, partitioner, parentNames);
        }

        public Topology AddSink<K, V>(string name, TopicNameExtractor<K, V> topicExtractor, params string[] parentNames)
        {
            return IExecute<Topology>("addSink", name, topicExtractor, parentNames);
        }

        public Topology AddSink<TSuperK, TSuperV, K, V>(string name, TopicNameExtractor<K, V> topicExtractor, StreamPartitioner<TSuperK, TSuperV> partitioner, params string[] parentNames)
            where TSuperK : K
            where TSuperV : V
        {
            return IExecute<Topology>("addSink", name, topicExtractor, partitioner, parentNames);
        }

        public Topology AddSink<K, V>(string name, TopicNameExtractor<K, V> topicExtractor, Serializer<K> keySerializer, Serializer<V> valueSerializer, params string[] parentNames)
        {
            return IExecute<Topology>("addSink", name, topicExtractor, keySerializer, valueSerializer, parentNames);
        }

        public Topology AddSink<TSuperK, TSuperV, K, V>(string name, TopicNameExtractor<K, V> topicExtractor, Serializer<K> keySerializer, Serializer<V> valueSerializer, StreamPartitioner<TSuperK, TSuperV> partitioner, params string[] parentNames)
            where TSuperK : K
            where TSuperV : V
        {
            return IExecute<Topology>("addSink", name, topicExtractor, keySerializer, valueSerializer, partitioner, parentNames);
        }

        public Topology AddProcessor<KIn, VIn, KOut, VOut>(string name, Processor.Api.ProcessorSupplier<KIn, VIn, KOut, VOut> supplier, params string[] parentNames)
        {
            return IExecute<Topology>("addProcessor", name, supplier, parentNames);
        }

        public Topology AddStateStore(IStoreBuilder storeBuilder, params string[] processorNames)
        {
            return IExecute<Topology>("addStateStore", storeBuilder, processorNames);
        }

        public Topology AddGlobalStore<KIn, VIn>(IStoreBuilder storeBuilder,
                                                 string sourceName,
                                                 Deserializer<KIn> keyDeserializer,
                                                 Deserializer<VIn> valueDeserializer,
                                                 string topic,
                                                 string processorName,
                                                 Processor.Api.ProcessorSupplier<KIn, VIn, Void, Void> stateUpdateSupplier)
        {
            return IExecute<Topology>("addGlobalStore", storeBuilder, sourceName, keyDeserializer, valueDeserializer, topic, processorName, stateUpdateSupplier);
        }

        public Topology AddGlobalStore<KIn, VIn>(IStoreBuilder storeBuilder,
                                                 string sourceName,
                                                 TimestampExtractor timestampExtractor,
                                                 Deserializer<KIn> keyDeserializer,
                                                 Deserializer<VIn> valueDeserializer,
                                                 string topic,
                                                 string processorName,
                                                 Processor.Api.ProcessorSupplier<KIn, VIn, Void, Void> stateUpdateSupplier)
        {
            return IExecute<Topology>("addGlobalStore", storeBuilder, sourceName, timestampExtractor, keyDeserializer, valueDeserializer, topic, processorName, stateUpdateSupplier);
        }

        public Topology ConnectProcessorAndStateStores(string processorName, params string[] stateStoreNames)
        {
            return IExecute<Topology>("connectProcessorAndStateStores", processorName, stateStoreNames);
        }

        public TopologyDescription Describe => IExecute<TopologyDescription>("describe");
    }
}
