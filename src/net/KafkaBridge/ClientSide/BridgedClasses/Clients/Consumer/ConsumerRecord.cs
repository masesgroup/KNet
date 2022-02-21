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

using MASES.JCOBridge.C2JBridge.JVMInterop;
using MASES.KafkaBridge.Common.Header;
using MASES.KafkaBridge.Common.Record;

namespace MASES.KafkaBridge.Clients.Consumer
{
    public class ConsumerRecord<K, V> : JCOBridge.C2JBridge.JVMBridgeBase<ConsumerRecord<K, V>>
    {
        public override string ClassName => "org.apache.kafka.clients.consumer.ConsumerRecord";

        public string Topic => IExecute<string>("topic");

        public int Partition => IExecute<int>("partition");

        public Headers Headers => IExecute<Headers>("headers");

        public K Key => IExecute<K>("key");

        public V Value => IExecute<V>("value");

        public long Offset => IExecute<long>("offset");

        public System.DateTime DateTime => System.DateTimeOffset.FromUnixTimeMilliseconds(Timestamp).DateTime;

        public long Timestamp => IExecute<long>("timestamp");

        public TimestampType TimestampType => (TimestampType)System.Enum.Parse(typeof(TimestampType), IExecute<IJavaObject>("timestampType").Invoke<string>("name")); // (TimestampType)(int)IExecute<IJavaObject>("timestampType").GetField("id");

        public int SerializedKeySize => IExecute<int>("serializedKeySize");

        public int SerializedValueSize => IExecute<int>("serializedValueSize");
    }

    public class ConsumerRecord : ConsumerRecord<object, object>
    {

    }
}
