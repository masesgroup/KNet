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
using Org.Apache.Kafka.Clients.Consumer;
using Org.Apache.Kafka.Common;
using Java.Util;
using Java.Util.Concurrent;

namespace Org.Apache.Kafka.Clients.Producer
{
    public interface IProducer : IJVMBridgeBase, System.IDisposable
    {
        void InitTransactions();

        void BeginTransaction();

        void SendOffsetsToTransaction(Map<TopicPartition, OffsetAndMetadata> offsets, ConsumerGroupMetadata groupMetadata);

        void CommitTransaction();

        void AbortTransaction();

        void Flush();

        List<PartitionInfo> PartitionsFor(string topic);

        Map<MetricName, T> Metrics<T>() where T : Metric;
    }

    public partial interface IProducer<K, V> : IProducer
    {
        Future<RecordMetadata> Send(ProducerRecord<K, V> record);

        Future<RecordMetadata> Send(ProducerRecord<K, V> record, Callback callback);
    }
}
