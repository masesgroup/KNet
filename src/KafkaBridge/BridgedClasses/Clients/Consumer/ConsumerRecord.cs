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

namespace MASES.KafkaBridge.Clients.Consumer
{
    public class ConsumerRecord : JCOBridge.C2JBridge.JVMBridgeBase<ConsumerRecord>
    {
        public override string ClassName => "org.apache.kafka.clients.consumer.ConsumerRecord";

        public string Topic => (string)IExecute("topic");

        public int Partition => (int)IExecute("partition");

        public object Headers => IExecute("headers");

        public object Key => IExecute("key");

        public object Value => IExecute("value");

        public long Offset => (long)IExecute("offset");

        public long Timestamp => (long)IExecute("timestamp");

        public object TimestampType => IExecute("timestampType");

        public int SerializedKeySize => (int)IExecute("serializedKeySize");

        public int SerializedValueSize => (int)IExecute("serializedValueSize");
    }

    public class ConsumerRecord<K, V> : JCOBridge.C2JBridge.JVMBridgeBase<ConsumerRecord<K, V>>
    {
        public override string ClassName => "org.apache.kafka.clients.consumer.ConsumerRecord";
    }
}
