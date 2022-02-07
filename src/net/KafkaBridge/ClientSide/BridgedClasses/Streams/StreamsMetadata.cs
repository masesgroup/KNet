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
using MASES.KafkaBridge.Common;
using MASES.KafkaBridge.Java.Util;
using MASES.KafkaBridge.Streams.State;

namespace MASES.KafkaBridge.Streams
{
    public interface IStreamsMetadata : IJVMBridgeBase
    {
        HostInfo HostInfo { get; }

        Set<string> StateStoreNames { get; }

        Set<TopicPartition> TopicPartitions { get; }

        Set<TopicPartition> StandbyTopicPartitions { get; }

        Set<string> StandbyStateStoreNames { get; }

        string Host { get; }

        int Port { get; }
    }

    public class StreamsMetadata : JVMBridgeBase<StreamsMetadata, IStreamsMetadata>, IStreamsMetadata
    {
        public override string ClassName => "org.apache.kafka.streams.StreamsMetadata";

        public HostInfo HostInfo => IExecute<HostInfo>("hostInfo");

        public Set<string> StateStoreNames => IExecute<Set<string>>("stateStoreNames");

        public Set<TopicPartition> TopicPartitions => IExecute<Set<TopicPartition>>("topicPartitions");

        public Set<TopicPartition> StandbyTopicPartitions => IExecute<Set<TopicPartition>>("standbyTopicPartitions");

        public Set<string> StandbyStateStoreNames => IExecute<Set<string>>("standbyStateStoreNames");

        public string Host => IExecute<string>("host");

        public int Port => IExecute<int>("port");
    }
}
