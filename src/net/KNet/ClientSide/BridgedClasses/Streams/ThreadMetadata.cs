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
using Java.Util;

namespace MASES.KNet.Streams
{
    public interface IThreadMetadata : IJVMBridgeBase
    {
        string ThreadState { get; }

        string ThreadName { get; }

        Set<TaskMetadata> ActiveTasks { get; }

        Set<TaskMetadata> StandbyTasks { get; }

        string ConsumerClientId { get; }

        string RestoreConsumerClientId { get; }

        Set<string> ProducerClientIds { get; }

        string AdminClientId { get; }
    }

    public class ThreadMetadata : JVMBridgeBase<ThreadMetadata, IThreadMetadata>, IThreadMetadata
    {
        public override string BridgeClassName => "org.apache.kafka.streams.ThreadMetadata";

        public string ThreadState => IExecute<string>("threadState");

        public string ThreadName => IExecute<string>("threadName");

        public Set<TaskMetadata> ActiveTasks => IExecute<Set<TaskMetadata>>("activeTasks");

        public Set<TaskMetadata> StandbyTasks => IExecute<Set<TaskMetadata>>("standbyTasks");

        public string ConsumerClientId => IExecute<string>("consumerClientId");

        public string RestoreConsumerClientId => IExecute<string>("restoreConsumerClientId");

        public Set<string> ProducerClientIds => IExecute<Set<string>>("producerClientIds");

        public string AdminClientId => IExecute<string>("adminClientId");
    }
}
