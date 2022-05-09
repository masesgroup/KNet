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

using Java.Lang;
using MASES.JCOBridge.C2JBridge;
using MASES.KNet.Connect.Data;
using MASES.KNet.Connect.Header;

namespace MASES.KNet.Connect.Connector
{
    public class ConnectRecord<R> : JVMBridgeBase<ConnectRecord<R>> where R : ConnectRecord<R>
    {
        public override bool IsAbstract => true;
        public override string ClassName => "org.apache.kafka.connect.connector.ConnectRecord";

        [System.Obsolete("This is not public in Apache Kafka API")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public ConnectRecord()
        {

        }

        public ConnectRecord(string topic, int kafkaPartition,
                              Schema keySchema, object key,
                              Schema valueSchema, object value,
                              long timestamp)
            : base(topic, kafkaPartition, keySchema, key, valueSchema, value, timestamp)
        {
        }

        public ConnectRecord(string topic, int kafkaPartition,
                             Schema keySchema, object key,
                             Schema valueSchema, object value,
                             long timestamp, Iterable<Header.Header> headers)
             : base(topic, kafkaPartition, keySchema, key, valueSchema, value, timestamp, headers)
        {
        }

        public ConnectRecord(params object[] args) : base(args)
        {
        }

        public string Topic => IExecute<string>("topic");

        public int KafkaPartition => IExecute<int>("kafkaPartition");

        public object Key => IExecute("key");

        public Schema KeySchema => IExecute<Schema>("keySchema");

        public object Value => IExecute("value");

        public Schema ValueSchema => IExecute<Schema>("valueSchema");

        public long Timestamp => IExecute<long>("timestamp");

        public Headers Headers => IExecute<Headers>("headers");

        public R NewRecord(string topic, int kafkaPartition, Schema keySchema, object key, Schema valueSchema, object value, long timestamp) => IExecute<R>("newRecord", topic, kafkaPartition, keySchema, key, valueSchema, value, timestamp);

        public R NewRecord(string topic, int kafkaPartition, Schema keySchema, object key, Schema valueSchema, object value, long timestamp, Iterable<Header.Header> headers) => IExecute<R>("newRecord", topic, kafkaPartition, keySchema, key, valueSchema, value, timestamp, headers);
    }
}
