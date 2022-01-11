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

using MASES.KafkaBridge.Common;
using MASES.KafkaBridge.Common.Serialization;
using MASES.KafkaBridge.Java.Time;
using MASES.KafkaBridge.Java.Util;
using MASES.KafkaBridge.Java.Util.Regex;

namespace MASES.KafkaBridge.Clients.Consumer
{
    public class KafkaConsumer<K, V> : JCOBridge.C2JBridge.JVMBridgeBase<KafkaConsumer<K, V>>
    {
        public override bool IsCloseable => true;

        public override string ClassName => "org.apache.kafka.clients.consumer.KafkaConsumer";

        public KafkaConsumer()
        {
        }

        public KafkaConsumer(Properties props)
            : base(props)
        {
        }

        public KafkaConsumer(Properties props, Deserializer<K> keyDeserializer, Deserializer<V> valueDeserializer)
            : base(props, keyDeserializer.Listener, valueDeserializer.Listener)
        {
        }

        public Set<TopicPartition> Assignment => New<Set<TopicPartition>>("assignment");

        public Set<string> Subscription => New<Set<string>>("subscription");

        public Set<TopicPartition> Paused => New<Set<TopicPartition>>("paused");

        public void Subscribe(Collection<string> topics, ConsumerRebalanceListener listener)
        {
            IExecute("subscribe", topics.Instance, listener.Listener);
        }

        public void Subscribe(Collection<string> topics)
        {
            IExecute("subscribe", topics.Instance);
        }

        public void Subscribe(Pattern pattern, ConsumerRebalanceListener listener)
        {
            IExecute("subscribe", pattern.Instance, listener.Listener);
        }

        public void Subscribe(Pattern pattern)
        {
            IExecute("subscribe", pattern.Instance);
        }

        public void Unsubscribe()
        {
            IExecute("unsubscribe");
        }

        public void Assign(Collection<TopicPartition> partitions)
        {
            IExecute("assign", partitions.Instance);
        }

        public ConsumerRecords<K, V> Poll(long timeoutMs)
        {
            return New<ConsumerRecords<K, V>>("poll", timeoutMs);
        }

        public ConsumerRecords<K, V> Poll(Duration timeout)
        {
            return New<ConsumerRecords<K, V>>("poll", timeout.Instance);
        }

        public void CommitSync()
        {
            IExecute("commitSync");
        }

        public void CommitSync(Duration timeout)
        {
            IExecute("commitSync", timeout.Instance);
        }

        public void CommitSync(Map<TopicPartition, OffsetAndMetadata> offsets)
        {
            IExecute("commitSync", offsets.Instance);
        }

        public void CommitSync(Map<TopicPartition, OffsetAndMetadata> offsets, Duration timeout)
        {
            IExecute("commitSync", offsets.Instance, timeout.Instance);
        }

        public void CommitAsync()
        {
            IExecute("commitAsync");
        }

        public void CommitAsync(OffsetCommitCallback callback)
        {
            IExecute("commitAsync", callback.Listener);
        }

        public void CommitAsync(Map<TopicPartition, OffsetAndMetadata> offsets, OffsetCommitCallback callback)
        {
            IExecute("commitAsync", offsets.Instance, callback.Listener);
        }

        public void Seek(TopicPartition partition, long offset)
        {
            IExecute("seek", partition.Instance, offset);
        }

        public void SeekToBeginning(TopicPartition partition, OffsetAndMetadata offsetAndMetadata)
        {
            IExecute("seekToBeginning", partition.Instance, offsetAndMetadata.Instance);
        }

        public void SeekToBeginning(Collection<TopicPartition> partitions)
        {
            IExecute("seekToBeginning", partitions.Instance);
        }

        public void SeekToEnd(Collection<TopicPartition> partitions)
        {
            IExecute("seekToEnd", partitions.Instance);
        }

        public long Position(TopicPartition partition)
        {
            return IExecute<long>("position", partition.Instance);
        }

        public long Position(TopicPartition partition, Duration timeout)
        {
            return IExecute<long>("position", partition.Instance, timeout.Instance);
        }

        public OffsetAndMetadata Committed(TopicPartition partition)
        {
            return New<OffsetAndMetadata>("committed", partition.Instance);
        }

        public OffsetAndMetadata Committed(TopicPartition partition, Duration timeout)
        {
            return New<OffsetAndMetadata>("committed", partition.Instance, timeout.Instance);
        }

        public Map<TopicPartition, OffsetAndMetadata> Committed(Set<TopicPartition> partitions)
        {
            return New<Map<TopicPartition, OffsetAndMetadata>>("committed", partitions.Instance);
        }

        public Map<TopicPartition, OffsetAndMetadata> Committed(Set<TopicPartition> partitions, Duration timeout)
        {
            return New<Map<TopicPartition, OffsetAndMetadata>>("committed", partitions.Instance, timeout.Instance);
        }

        /** To be added

    public Map<MetricName, ? extends Metric> metrics()
        */

        public List<PartitionInfo> PartitionsFor(string topic)
        {
            return New<List<PartitionInfo>>("partitionsFor", topic);
        }

        public List<PartitionInfo> PartitionsFor(string topic, Duration timeout)
        {
            return New<List<PartitionInfo>>("partitionsFor", topic, timeout.Instance);
        }

        public Map<string, List<PartitionInfo>> ListTopics()
        {
            return New<Map<string, List<PartitionInfo>>>("listTopics");
        }

        public Map<string, List<PartitionInfo>> ListTopics(Duration timeout)
        {
            return New<Map<string, List<PartitionInfo>>>("listTopics", timeout.Instance);
        }

        public void Pause(Collection<TopicPartition> partitions)
        {
            IExecute("pause", partitions.Instance);
        }

        public void Resume(Collection<TopicPartition> partitions)
        {
            IExecute("resume", partitions.Instance);
        }

        public Map<TopicPartition, OffsetAndTimestamp> OffsetsForTimes(Map<TopicPartition, long> timestampsToSearch)
        {
            return New<Map<TopicPartition, OffsetAndTimestamp>>("offsetsForTimes", timestampsToSearch.Instance);
        }

        public Map<TopicPartition, OffsetAndTimestamp> OffsetsForTimes(Map<TopicPartition, long> timestampsToSearch, Duration timeout)
        {
            return New<Map<TopicPartition, OffsetAndTimestamp>>("offsetsForTimes", timestampsToSearch.Instance, timeout.Instance);
        }

        public Map<TopicPartition, long> BeginningOffsets(Collection<TopicPartition> partitions)
        {
            return New<Map<TopicPartition, long>>("beginningOffsets", partitions.Instance);
        }

        public Map<TopicPartition, long> BeginningOffsets(Collection<TopicPartition> partitions, Duration timeout)
        {
            return New<Map<TopicPartition, long>>("beginningOffsets", partitions.Instance, timeout.Instance);
        }

        public Map<TopicPartition, long> EndOffsets(Collection<TopicPartition> partitions)
        {
            return New<Map<TopicPartition, long>>("endOffsets", partitions.Instance);
        }

        public Map<TopicPartition, long> EndOffsets(Collection<TopicPartition> partitions, Duration timeout)
        {
            return New<Map<TopicPartition, long>>("endOffsets", partitions.Instance, timeout.Instance);
        }

        public Optional<long> CurrentLag(TopicPartition topicPartition)
        {
            return New<Optional<long>>("currentLag", topicPartition.Instance);
        }

        public ConsumerGroupMetadata GroupMetadata()
        {
            return New<ConsumerGroupMetadata>("groupMetadata");
        }

        public void EnforceRebalance()
        {
            IExecute("enforceRebalance");
        }

        public void Wakeup()
        {
            IExecute("wakeup");
        }
    }

    public class KafkaConsumer : KafkaConsumer<object, object>
    {
        public KafkaConsumer(Properties props) : base(props) { }
    }
}
