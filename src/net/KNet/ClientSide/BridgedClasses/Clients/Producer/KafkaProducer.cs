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

using MASES.KNet.Clients.Consumer;
using MASES.KNet.Common;
using MASES.KNet.Common.Serialization;
using Java.Util;
using Java.Util.Concurrent;

namespace MASES.KNet.Clients.Producer
{
    public class KafkaProducer : JCOBridge.C2JBridge.JVMBridgeBase<KafkaProducer>, IProducer
    {
        public override bool IsBridgeCloseable => true;

        public override string BridgeClassName => "org.apache.kafka.clients.producer.KafkaProducer";

        public KafkaProducer()
        {
        }

        protected KafkaProducer(params object[] args)
            : base(args)
        {
        }


        public Map<MetricName, Metric> Metrics => IExecute<Map<MetricName, Metric>>("metrics");

        public void InitTransactions()
        {
            IExecute("initTransactions");
        }

        public void BeginTransaction()
        {
            IExecute("beginTransaction");
        }

        public void SendOffsetsToTransaction(Map<TopicPartition, OffsetAndMetadata> offsets, string consumerGroupId)
        {
            IExecute("sendOffsetsToTransaction", offsets, consumerGroupId);
        }

        public void SendOffsetsToTransaction(Map<TopicPartition, OffsetAndMetadata> offsets, ConsumerGroupMetadata groupMetadata)
        {
            IExecute("sendOffsetsToTransaction", offsets, groupMetadata);
        }

        public void CommitTransaction()
        {
            IExecute("commitTransaction");
        }

        public void AbortTransaction()
        {
            IExecute("abortTransaction");
        }

        public Future<RecordMetadata> Send(ProducerRecord record)
        {
            return IExecute<Future<RecordMetadata>>("send", record);
        }

        public Future<RecordMetadata> Send(ProducerRecord record, Callback callback)
        {
            return IExecute<Future<RecordMetadata>>("send", record, callback);
        }

        public void Flush()
        {
            IExecute("flush");
        }

        public List<PartitionInfo> PartitionsFor(string topic)
        {
            return IExecute<List<PartitionInfo>>("partitionsFor", topic);
        }
    }

    public class KafkaProducer<K, V> : KafkaProducer, IProducer<K, V>
    {
        public KafkaProducer()
        {
        }

        public KafkaProducer(Properties props)
            : base(props)
        {
        }

        public KafkaProducer(Properties props, Serializer<K> keySerializer, Serializer<V> valueSerializer)
            : base(props, keySerializer, valueSerializer)
        {
        }

        public Future<RecordMetadata> Send(ProducerRecord<K, V> record)
        {
            return IExecute<Future<RecordMetadata>>("send", record);
        }

        public Future<RecordMetadata> Send(ProducerRecord<K, V> record, Callback callback)
        {
            return IExecute<Future<RecordMetadata>>("send", record, callback);
        }
    }
}
