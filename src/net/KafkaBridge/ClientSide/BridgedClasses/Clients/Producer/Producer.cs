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
using MASES.KafkaBridge.Clients.Consumer;
using MASES.KafkaBridge.Common;
using MASES.KafkaBridge.Java.Util;
using MASES.KafkaBridge.Java.Util.Concurrent;
using System;

namespace MASES.KafkaBridge.Clients.Producer
{
    public interface IProducer<K, V> : IJVMBridgeBase
    {
        void InitTransactions();

        void BeginTransaction();

        [Obsolete()]
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
