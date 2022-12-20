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
using MASES.KNet.Common.Record;
using MASES.KNet.Connect.Connector;
using MASES.KNet.Connect.Data;
using MASES.KNet.Connect.Header;
using System;

namespace MASES.KNet.Connect.Sink
{
    public class SinkRecord : ConnectRecord<SinkRecord>
    {
        public override bool IsAbstract => false;

        public override string ClassName => "org.apache.kafka.connect.sink.SinkRecord";

        /// <summary>
        /// Offset in Kafka
        /// </summary>
        public long KafkaOffset => IExecute<long>("kafkaOffset");
        /// <summary>
        /// The <see cref="MASES.KNet.Common.Record.TimestampType"/>
        /// </summary>
        public TimestampType TimestampType => IExecute<TimestampType>("timestampType");

        public SinkRecord<TKey, TValue> CastTo<TKey, TValue>() => this.Cast<SinkRecord<TKey, TValue>>();
    }

    public class SinkRecord<TKey, TValue> : ConnectRecord<SinkRecord<TKey, TValue>, TKey, TValue>
    {
        public override bool IsAbstract => false;

        public override string ClassName => "org.apache.kafka.connect.sink.SinkRecord";

        /// <summary>
        /// Converts an <see cref="SinkRecord{TKey, TValue}"/> in <see cref="SinkRecord"/>
        /// </summary>
        /// <param name="source">The <see cref="SinkRecord{TKey, TValue}"/> to convert</param>
        public static implicit operator SinkRecord(SinkRecord<TKey, TValue> source) => source.Cast<SinkRecord>();

        public SinkRecord()
        {
        }

        public SinkRecord(string topic, int partition, Schema keySchema, TKey key, Schema valueSchema, TValue value, long kafkaOffset)
            : base(topic, partition, keySchema, key, valueSchema, value, kafkaOffset)
        {
        }

        public SinkRecord(string topic, int partition, Schema keySchema, TKey key, Schema valueSchema, TValue value, long kafkaOffset,
                          DateTime timestamp, TimestampType timestampType)
            : base(topic, partition, keySchema, key, valueSchema, value, kafkaOffset, timestamp, timestampType)
        {
        }

        public SinkRecord(string topic, int partition, Schema keySchema, TKey key, Schema valueSchema, TValue value, long kafkaOffset,
                          DateTime timestamp, TimestampType timestampType, Headers headers)
            : base(topic, partition, keySchema, key, valueSchema, value, kafkaOffset, timestamp, timestampType, headers)
        {
        }
        /// <summary>
        /// Offset in Kafka
        /// </summary>
        public long KafkaOffset => IExecute<long>("kafkaOffset");
        /// <summary>
        /// The <see cref="MASES.KNet.Common.Record.TimestampType"/>
        /// </summary>
        public TimestampType TimestampType => IExecute<TimestampType>("timestampType");
    }
}