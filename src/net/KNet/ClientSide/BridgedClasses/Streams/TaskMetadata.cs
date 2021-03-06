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
using MASES.KNet.Common;
using Java.Util;
using MASES.KNet.Streams.Processor;

namespace MASES.KNet.Streams
{
    public interface ITaskMetadata : IJVMBridgeBase
    {
        TaskId TaskId { get; }

        Set<TopicPartition> TopicPartitions { get; }

        Map<TopicPartition, long> CommittedOffsets { get; }

        Map<TopicPartition, long> EndOffsets { get; }

        Optional<long> TimeCurrentIdlingStarted { get; }
    }

    public class TaskMetadata : JVMBridgeBase<TaskMetadata, ITaskMetadata>, ITaskMetadata
    {
        public override string ClassName => "org.apache.kafka.streams.TaskMetadata";

        public TaskId TaskId => IExecute<TaskId>("taskId");

        public Set<TopicPartition> TopicPartitions => IExecute<Set<TopicPartition>>("topicPartitions");

        public Map<TopicPartition, long> CommittedOffsets => IExecute<Map<TopicPartition, long>>("committedOffsets");

        public Map<TopicPartition, long> EndOffsets => IExecute<Map<TopicPartition, long>>("endOffsets");

        public Optional<long> TimeCurrentIdlingStarted => IExecute<Optional<long>>("timeCurrentIdlingStarted");
    }
}
