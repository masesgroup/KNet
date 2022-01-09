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

using MASES.KafkaBridge.Clients.Consumer;
using MASES.KafkaBridge.Common;
using MASES.KafkaBridge.Java.Util;
using MASES.KafkaBridge.Java.Util.Concurrent;

namespace MASES.KafkaBridge.Clients.Producer
{
    public class KafkaProducer : JCOBridge.C2JBridge.JVMBridgeBase<KafkaProducer>
    {
        public override bool IsCloseable => true;

        public override string ClassName => "org.apache.kafka.clients.producer.KafkaProducer";

        public KafkaProducer()
        {
        }

        public KafkaProducer(Properties props)
            : base(props)
        {
        }

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
            IExecute("sendOffsetsToTransaction", offsets.Instance, consumerGroupId);
        }

        public void SendOffsetsToTransaction(Map<TopicPartition, OffsetAndMetadata> offsets, ConsumerGroupMetadata groupMetadata)
        {
            IExecute("sendOffsetsToTransaction", offsets.Instance, groupMetadata.Instance);
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
            return New<Future<RecordMetadata>>("send", record.Instance);
        }

        public Future<RecordMetadata> Send(ProducerRecord record, Callback callback)
        {
            return New<Future<RecordMetadata>>("send", record.Instance, callback.Listener);
        }

        public Future<RecordMetadata> Send<K, V>(ProducerRecord<K, V> record)
        {
            return New<Future<RecordMetadata>>("send", record.Instance);
        }

        public Future<RecordMetadata> Send<K, V>(ProducerRecord<K, V> record, Callback callback)
        {
            return New<Future<RecordMetadata>>("send", record.Instance, callback.Listener);
        }

        public void Flush()
        {
            IExecute("flush");
        }

        public List<PartitionInfo> PartitionsFor(string topic)
        {
            return New<List<PartitionInfo>>("partitionsFor", topic);
        }
    }
}
