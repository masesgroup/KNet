/*
*  Copyright 2021 MASES s.r.l.
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

using MASES.JCOBridge.C2JBridge.JVMInterop;
using MASES.KafkaBridge.Java.Util;
using System;

namespace MASES.KafkaBridge.Streams
{
    public class KafkaStreams : JCOBridge.C2JBridge.JVMBridgeBase<KafkaStreams>
    {
        public override bool IsCloseable => true;

        public override string ClassName => "org.apache.kafka.streams.KafkaStreams";

        public enum StateType
        {
            CREATED,          // 0
            REBALANCING,   // 1
            RUNNING,    // 2
            PENDING_SHUTDOWN,    // 3
            NOT_RUNNING,            // 4
            PENDING_ERROR,       // 5
            ERROR,                 // 6
        }
        [Obsolete("This is not public in Apache Kafka API")]
        public KafkaStreams() { }

        public KafkaStreams(Topology topology, Properties props)
            : base(topology.Instance, props.Instance)
        {

        }

        public StateType State => (StateType)IExecute<IJavaObject>("state").Invoke<int>("ordinal");

        public Optional<string> AddStreamThread() { return New<Optional<string>>("addStreamThread"); }

        public Optional<string> RemoveStreamThread() { return New<Optional<string>>("removeStreamThread"); }

        public void Start() { IExecute("start"); }
    }
}

