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
using Org.Apache.Kafka.Common;
using Java.Time;
using Java.Util;
using Java.Util.Regex;

namespace Org.Apache.Kafka.Clients.Consumer
{
    /// <summary>
    /// .NET interface for <see cref="Consumer"/>
    /// </summary>
    public partial interface IConsumer: IJVMBridgeBase, System.IDisposable
    {
        /// <inheritdoc cref="Consumer.Assignment"/>
        Set<TopicPartition> Assignment();
        /// <inheritdoc cref="Consumer.Subscription"/>
        Set<string> Subscription();
        /// <inheritdoc cref="Consumer.Paused"/>
        Set<TopicPartition> Paused();
        /// <inheritdoc cref="Consumer.Metrics"/>
        Map<MetricName, T> Metrics<T>() where T : Metric;
        /// <inheritdoc cref="Consumer.Subscribe(Collection)"/>
        void Subscribe(Collection<string> topics);
        /// <inheritdoc cref="Consumer.Subscribe(Collection, ConsumerRebalanceListener)"/>
        void Subscribe(Collection<string> topics, ConsumerRebalanceListener listener);
        /// <inheritdoc cref="Consumer.Assign(Collection)"/>
        void Assign(Collection<TopicPartition> partitions);
        /// <inheritdoc cref="Consumer.Subscribe(Pattern, ConsumerRebalanceListener)"/>
        void Subscribe(Pattern pattern, ConsumerRebalanceListener listener);
        /// <inheritdoc cref="Consumer.Subscribe(Pattern)"/>
        void Subscribe(Pattern pattern);
        /// <inheritdoc cref="Consumer.Unsubscribe"/>
        void Unsubscribe();
        /// <inheritdoc cref="Consumer.CommitSync()"/>
        void CommitSync();
        /// <inheritdoc cref="Consumer.CommitSync(Duration)"/>
        void CommitSync(Duration timeout);
        /// <inheritdoc cref="Consumer.CommitSync(Map)"/>
        void CommitSync(Map<TopicPartition, OffsetAndMetadata> offsets);
        /// <inheritdoc cref="Consumer.CommitSync(Map, Duration)"/>
        void CommitSync(Map<TopicPartition, OffsetAndMetadata> offsets, Duration timeout);
        /// <inheritdoc cref="Consumer.CommitAsync()"/>
        void CommitAsync();
        /// <inheritdoc cref="Consumer.CommitAsync(OffsetCommitCallback)"/>
        void CommitAsync(OffsetCommitCallback callback);
        /// <inheritdoc cref="Consumer.CommitAsync(Map, OffsetCommitCallback)"/>
        void CommitAsync(Map<TopicPartition, OffsetAndMetadata> offsets, OffsetCommitCallback callback);
        /// <inheritdoc cref="Consumer.Seek(TopicPartition, long)"/>
        void Seek(TopicPartition partition, long offset);
        /// <inheritdoc cref="Consumer.Seek(TopicPartition, OffsetAndMetadata)"/>
        void Seek(TopicPartition partition, OffsetAndMetadata offsetAndMetadata);
        /// <inheritdoc cref="Consumer.SeekToBeginning(Collection)"/>
        void SeekToBeginning(Collection<TopicPartition> partitions);
        /// <inheritdoc cref="Consumer.SeekToEnd(Collection)"/>
        void SeekToEnd(Collection<TopicPartition> partitions);
        /// <inheritdoc cref="Consumer.Position(TopicPartition)"/>
        long Position(TopicPartition partition);
        /// <inheritdoc cref="Consumer.Position(TopicPartition, Duration)"/>
        long Position(TopicPartition partition, Duration timeout);
        /// <inheritdoc cref="Consumer.Committed(Set)"/>
        Map<TopicPartition, OffsetAndMetadata> Committed(Set<TopicPartition> partitions);
        /// <inheritdoc cref="Consumer.Committed(Set, Duration)"/>
        Map<TopicPartition, OffsetAndMetadata> Committed(Set<TopicPartition> partitions, Duration timeout);
        /// <inheritdoc cref="Consumer.PartitionsFor(string)"/>
        List<PartitionInfo> PartitionsFor(string topic);
        /// <inheritdoc cref="Consumer.PartitionsFor(string, Duration)"/>
        List<PartitionInfo> PartitionsFor(string topic, Duration timeout);
        /// <inheritdoc cref="Consumer.ListTopics()"/>
        Map<string, List<PartitionInfo>> ListTopics();
        /// <inheritdoc cref="Consumer.ListTopics(Duration)"/>
        Map<string, List<PartitionInfo>> ListTopics(Duration timeout);
        /// <inheritdoc cref="Consumer.Pause(Collection)"/>
        void Pause(Collection<TopicPartition> partitions);
        /// <inheritdoc cref="Consumer.Resume(Collection)"/>
        void Resume(Collection<TopicPartition> partitions);
        /// <inheritdoc cref="Consumer.OffsetsForTimes(Map)"/>
        Map<TopicPartition, OffsetAndTimestamp> OffsetsForTimes(Map<TopicPartition, Java.Lang.Long> timestampsToSearch);
        /// <inheritdoc cref="Consumer.OffsetsForTimes(Map, Duration)"/>
        Map<TopicPartition, OffsetAndTimestamp> OffsetsForTimes(Map<TopicPartition, Java.Lang.Long> timestampsToSearch, Duration timeout);
        /// <inheritdoc cref="Consumer.BeginningOffsets(Collection)"/>
        Map<TopicPartition, Java.Lang.Long> BeginningOffsets(Collection<TopicPartition> partitions);
        /// <inheritdoc cref="Consumer.BeginningOffsets(Collection, Duration)"/>
        Map<TopicPartition, Java.Lang.Long> BeginningOffsets(Collection<TopicPartition> partitions, Duration timeout);
        /// <inheritdoc cref="Consumer.EndOffsets(Collection)"/>
        Map<TopicPartition, Java.Lang.Long> EndOffsets(Collection<TopicPartition> partitions);
        /// <inheritdoc cref="Consumer.EndOffsets(Collection, Duration)"/>
        Map<TopicPartition, Java.Lang.Long> EndOffsets(Collection<TopicPartition> partitions, Duration timeout);
        /// <inheritdoc cref="Consumer.CurrentLag(TopicPartition)"/>
        OptionalLong CurrentLag(TopicPartition topicPartition);
        /// <inheritdoc cref="Consumer.GroupMetadata"/>
        ConsumerGroupMetadata GroupMetadata();
        /// <inheritdoc cref="Consumer.EnforceRebalance()"/>
        void EnforceRebalance();
        /// <inheritdoc cref="Consumer.EnforceRebalance(string)"/>
        void EnforceRebalance(string reason);
        /// <inheritdoc cref="Consumer.Wakeup"/>
        void Wakeup();
    }

    public partial interface IConsumer<K, V> : IConsumer
    {
        /// <inheritdoc cref="Consumer.Poll(Duration)"/>
        ConsumerRecords<K, V> Poll(Duration timeout);
    }
}
