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
    /// <summary>
    /// .NET interface for <see cref="Producer"/>
    /// </summary>
    public interface IProducer : IJVMBridgeBase, System.IDisposable
    {
        /// <inheritdoc cref="Producer.InitTransactions"/>
        void InitTransactions();
        /// <inheritdoc cref="Producer.BeginTransaction"/>
        void BeginTransaction();
        /// <inheritdoc cref="Producer.SendOffsetsToTransaction(Map, ConsumerGroupMetadata)"/>
        void SendOffsetsToTransaction(Map<TopicPartition, OffsetAndMetadata> offsets, ConsumerGroupMetadata groupMetadata);
        /// <inheritdoc cref="Producer.CommitTransaction"/>
        void CommitTransaction();
        /// <inheritdoc cref="Producer.AbortTransaction"/>
        void AbortTransaction();
        /// <inheritdoc cref="Producer.Flush"/>
        void Flush();
        /// <inheritdoc cref="Producer.PartitionsFor(string)"/>
        List<PartitionInfo> PartitionsFor(string topic);
        /// <inheritdoc cref="Producer.Metrics"/>
        Map<MetricName, T> Metrics<T>() where T : Metric;
    }

    public partial interface IProducer<K, V> : IProducer
    {
        /// <inheritdoc cref="Producer{K, V}.Send(ProducerRecord{K, V})"/>
        Future<RecordMetadata> Send(ProducerRecord<K, V> record);
        /// <inheritdoc cref="Producer{K, V}.Send(ProducerRecord{K, V}, Callback)"/>
        Future<RecordMetadata> Send(ProducerRecord<K, V> record, Callback callback);
    }
}
