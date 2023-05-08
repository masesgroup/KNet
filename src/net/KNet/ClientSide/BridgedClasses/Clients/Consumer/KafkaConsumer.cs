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

using MASES.KNet.Common;
using MASES.KNet.Common.Serialization;
using Java.Time;
using Java.Util;
using Java.Util.Regex;

namespace MASES.KNet.Clients.Consumer
{
    public class KafkaConsumer : JCOBridge.C2JBridge.JVMBridgeBase<KafkaConsumer>, IConsumer
    {
        public override bool IsBridgeCloseable => true;

        public override string BridgeClassName => "org.apache.kafka.clients.consumer.KafkaConsumer";

        public KafkaConsumer()
        {
        }

        protected KafkaConsumer(params object[] args)
            : base(args)
        {
        }

        public Set<TopicPartition> Assignment => IExecute<Set<TopicPartition>>("assignment");

        public Set<string> Subscription => IExecute<Set<string>>("subscription");

        public Set<TopicPartition> Paused => IExecute<Set<TopicPartition>>("paused");

        public Map<MetricName, Metric> Metrics => IExecute<Map<MetricName, Metric>>("metrics");

        public void Subscribe(Collection<string> topics, ConsumerRebalanceListener listener)
        {
            IExecute("subscribe", topics, listener);
        }

        public void Subscribe(Collection<string> topics)
        {
            IExecute("subscribe", topics);
        }

        public void Subscribe(Pattern pattern, ConsumerRebalanceListener listener)
        {
            IExecute("subscribe", pattern, listener);
        }

        public void Subscribe(Pattern pattern)
        {
            IExecute("subscribe", pattern);
        }

        public void Unsubscribe()
        {
            IExecute("unsubscribe");
        }

        public void Assign(Collection<TopicPartition> partitions)
        {
            IExecute("assign", partitions);
        }


        public void CommitSync()
        {
            IExecute("commitSync");
        }

        public void CommitSync(Duration timeout)
        {
            IExecute("commitSync", timeout);
        }

        public void CommitSync(Map<TopicPartition, OffsetAndMetadata> offsets)
        {
            IExecute("commitSync", offsets);
        }

        public void CommitSync(Map<TopicPartition, OffsetAndMetadata> offsets, Duration timeout)
        {
            IExecute("commitSync", offsets, timeout);
        }

        public void CommitAsync()
        {
            IExecute("commitAsync");
        }

        public void CommitAsync(OffsetCommitCallback callback)
        {
            IExecute("commitAsync", callback);
        }

        public void CommitAsync(Map<TopicPartition, OffsetAndMetadata> offsets, OffsetCommitCallback callback)
        {
            IExecute("commitAsync", offsets, callback);
        }

        public void Seek(TopicPartition partition, long offset)
        {
            IExecute("seek", partition, offset);
        }

        public void Seek(TopicPartition partition, OffsetAndMetadata offsetAndMetadata)
        {
            IExecute("seek", partition, offsetAndMetadata);
        }

        public void SeekToBeginning(Collection<TopicPartition> partitions)
        {
            IExecute("seekToBeginning", partitions);
        }

        public void SeekToEnd(Collection<TopicPartition> partitions)
        {
            IExecute("seekToEnd", partitions);
        }

        public long Position(TopicPartition partition)
        {
            return IExecute<long>("position", partition);
        }

        public long Position(TopicPartition partition, Duration timeout)
        {
            return IExecute<long>("position", partition, timeout);
        }

        public OffsetAndMetadata Committed(TopicPartition partition)
        {
            return IExecute<OffsetAndMetadata>("committed", partition);
        }

        public OffsetAndMetadata Committed(TopicPartition partition, Duration timeout)
        {
            return IExecute<OffsetAndMetadata>("committed", partition, timeout);
        }

        public Map<TopicPartition, OffsetAndMetadata> Committed(Set<TopicPartition> partitions)
        {
            return IExecute<Map<TopicPartition, OffsetAndMetadata>>("committed", partitions);
        }

        public Map<TopicPartition, OffsetAndMetadata> Committed(Set<TopicPartition> partitions, Duration timeout)
        {
            return IExecute<Map<TopicPartition, OffsetAndMetadata>>("committed", partitions, timeout);
        }

        public List<PartitionInfo> PartitionsFor(string topic)
        {
            return IExecute<List<PartitionInfo>>("partitionsFor", topic);
        }

        public List<PartitionInfo> PartitionsFor(string topic, Duration timeout)
        {
            return IExecute<List<PartitionInfo>>("partitionsFor", topic, timeout);
        }

        public Map<string, List<PartitionInfo>> ListTopics()
        {
            return IExecute<Map<string, List<PartitionInfo>>>("listTopics");
        }

        public Map<string, List<PartitionInfo>> ListTopics(Duration timeout)
        {
            return IExecute<Map<string, List<PartitionInfo>>>("listTopics", timeout);
        }

        public void Pause(Collection<TopicPartition> partitions)
        {
            IExecute("pause", partitions);
        }

        public void Resume(Collection<TopicPartition> partitions)
        {
            IExecute("resume", partitions);
        }

        public Map<TopicPartition, OffsetAndTimestamp> OffsetsForTimes(Map<TopicPartition, long> timestampsToSearch)
        {
            return IExecute<Map<TopicPartition, OffsetAndTimestamp>>("offsetsForTimes", timestampsToSearch);
        }

        public Map<TopicPartition, OffsetAndTimestamp> OffsetsForTimes(Map<TopicPartition, long> timestampsToSearch, Duration timeout)
        {
            return IExecute<Map<TopicPartition, OffsetAndTimestamp>>("offsetsForTimes", timestampsToSearch, timeout);
        }

        public Map<TopicPartition, long> BeginningOffsets(Collection<TopicPartition> partitions)
        {
            return IExecute<Map<TopicPartition, long>>("beginningOffsets", partitions);
        }

        public Map<TopicPartition, long> BeginningOffsets(Collection<TopicPartition> partitions, Duration timeout)
        {
            return IExecute<Map<TopicPartition, long>>("beginningOffsets", partitions, timeout);
        }

        public Map<TopicPartition, long> EndOffsets(Collection<TopicPartition> partitions)
        {
            return IExecute<Map<TopicPartition, long>>("endOffsets", partitions);
        }

        public Map<TopicPartition, long> EndOffsets(Collection<TopicPartition> partitions, Duration timeout)
        {
            return IExecute<Map<TopicPartition, long>>("endOffsets", partitions, timeout);
        }

        public Optional<long> CurrentLag(TopicPartition topicPartition)
        {
            return IExecute<Optional<long>>("currentLag", topicPartition);
        }

        public ConsumerGroupMetadata GroupMetadata()
        {
            return IExecute<ConsumerGroupMetadata>("groupMetadata");
        }

        public void EnforceRebalance()
        {
            IExecute("enforceRebalance");
        }

        public void EnforceRebalance(string reason)
        {
            IExecute("enforceRebalance", reason);
        }

        public void Wakeup()
        {
            IExecute("wakeup");
        }
    }

    public class KafkaConsumer<K, V> : KafkaConsumer, IConsumer<K, V>
    {
        public KafkaConsumer()
        {
        }

        public KafkaConsumer(Properties props)
            : base(props)
        {
        }

        public KafkaConsumer(Properties props, Deserializer<K> keyDeserializer, Deserializer<V> valueDeserializer)
            : base(props, keyDeserializer, valueDeserializer)
        {
        }

        public ConsumerRecords<K, V> Poll(long timeoutMs)
        {
            return IExecute<ConsumerRecords<K, V>>("poll", timeoutMs);
        }

        public ConsumerRecords<K, V> Poll(Duration timeout)
        {
            return IExecute<ConsumerRecords<K, V>>("poll", timeout);
        }
    }
}
