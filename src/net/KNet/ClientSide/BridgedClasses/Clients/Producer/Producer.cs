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

using MASES.JCOBridge.C2JBridge;
using MASES.KNet.Clients.Consumer;
using MASES.KNet.Common;
using Java.Util;
using Java.Util.Concurrent;

namespace MASES.KNet.Clients.Producer
{
    public interface IProducer<K, V> : IJVMBridgeBase, System.IDisposable
    {
        void InitTransactions();

        void BeginTransaction();

        [System.Obsolete()]
        void SendOffsetsToTransaction(Map<TopicPartition, OffsetAndMetadata> offsets, string consumerGroupId);

        void SendOffsetsToTransaction(Map<TopicPartition, OffsetAndMetadata> offsets, ConsumerGroupMetadata groupMetadata);

        void CommitTransaction();

        void AbortTransaction();

        Future<RecordMetadata> Send(ProducerRecord record);

        Future<RecordMetadata> Send(ProducerRecord record, Callback callback);

        Future<RecordMetadata> Send(ProducerRecord<K, V> record);

        Future<RecordMetadata> Send(ProducerRecord<K, V> record, Callback callback);

        void Flush();

        List<PartitionInfo> PartitionsFor(string topic);

        Map<MetricName, Metric> Metrics { get; }
    }
}
