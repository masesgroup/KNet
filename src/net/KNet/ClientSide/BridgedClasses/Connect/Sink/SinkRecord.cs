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
using MASES.KNet.Common.Record;
using MASES.KNet.Connect.Connector;
using MASES.KNet.Connect.Data;

namespace MASES.KNet.Connect.Sink
{
    public class SinkRecord : ConnectRecord<SinkRecord>
    {
        public override bool IsAbstract => false;

        public override string ClassName => "org.apache.kafka.connect.sink.SinkRecord";

        public SinkRecord(string topic, int partition, Schema keySchema, object key, Schema valueSchema, object value, long kafkaOffset)
            : base(topic, partition, keySchema, key, valueSchema, value, kafkaOffset)
        {
        }

        public SinkRecord(string topic, int partition, Schema keySchema, object key, Schema valueSchema, object value, long kafkaOffset,
                          long timestamp, TimestampType timestampType)
            : base(topic, partition, keySchema, key, valueSchema, value, kafkaOffset, timestamp, timestampType)
        {
        }

        public SinkRecord(string topic, int partition, Schema keySchema, object key, Schema valueSchema, object value, long kafkaOffset,
                          long timestamp, TimestampType timestampType, Iterable<Header.Header> headers)
            : base(topic, partition, keySchema, key, valueSchema, value, kafkaOffset, timestamp, timestampType, headers)
        {
        }

        public long KafkaOffset => IExecute<long>("kafkaOffset");

        public TimestampType TimestampType => IExecute<TimestampType>("timestampType");
    }
}