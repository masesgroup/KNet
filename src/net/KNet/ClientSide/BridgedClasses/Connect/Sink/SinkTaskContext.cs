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

using Java.Util;
using MASES.JCOBridge.C2JBridge;
using MASES.KNet.Common;

namespace MASES.KNet.Connect.Sink
{
    public class SinkTaskContext : JVMBridgeBase<SinkTaskContext>
    {
        public override bool IsInterface => true;

        public override string ClassName => "org.apache.kafka.connect.sink.SinkTaskContext";

        public Map<string, string> Configs => IExecute<Map<string, string>>("configs");

        public void Offset(Map<TopicPartition, long> offsets) => IExecute("offset", offsets);

        public void Offset(TopicPartition tp, long offset) => IExecute("offset", tp, offset);

        public void Timeout(long timeoutMs) => IExecute("timeout", timeoutMs);

        public Set<TopicPartition> Assignment => IExecute<Set<TopicPartition>>("assignment");

        public void Pause(params TopicPartition[] partitions) => IExecute("pause", partitions);

        public void Resume(params TopicPartition[] partitions) => IExecute("resume", partitions);

        public void RequestCommit() => IExecute("requestCommit");

        public ErrantRecordReporter ErrantRecordReporter => IExecute<ErrantRecordReporter>("errantRecordReporter");
    }
}
