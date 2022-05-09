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
using Java.Util;
using MASES.KNet.Connect.Connector;
using MASES.KNet.Connect.Data;

namespace MASES.KNet.Connect.Source
{
    public class SourceRecord : ConnectRecord<SourceRecord>
    {
        public override bool IsAbstract => false;

        public override string ClassName => "org.apache.kafka.connect.source.SourceRecord";

        public SourceRecord(Map<string, object> sourcePartition, Map<string, object> sourceOffset,
                              string topic, int partition, Schema valueSchema, object value)
            : base(sourcePartition, sourceOffset, topic, partition, valueSchema, value)
        {
        }

        public SourceRecord(Map<string, object> sourcePartition, Map<string, object> sourceOffset,
                            string topic, Schema valueSchema, object value)
            : base(sourcePartition, sourceOffset, topic, valueSchema, value)
        {

        }

        public SourceRecord(Map<string, object> sourcePartition, Map<string, object> sourceOffset,
                            string topic, Schema keySchema, object key, Schema valueSchema, object value)
            : base(sourcePartition, sourceOffset, topic, keySchema, key, valueSchema, value)
        {
        }

        public SourceRecord(Map<string, object> sourcePartition, Map<string, object> sourceOffset,
                            string topic, int partition,
                            Schema keySchema, object key, Schema valueSchema, object value)
                 : base(sourcePartition, sourceOffset, topic, partition, keySchema, key, valueSchema, value)
        {
        }

        public SourceRecord(Map<string, object> sourcePartition, Map<string, object> sourceOffset,
                            string topic, int partition,
                            Schema keySchema, object key,
                            Schema valueSchema, object value,
                            long timestamp)
                  : base(sourcePartition, sourceOffset, topic, partition, keySchema, key, valueSchema, value, timestamp)
        {

        }

        public SourceRecord(Map<string, object> sourcePartition, Map<string, object> sourceOffset,
                            string topic, int partition,
                            Schema keySchema, object key,
                            Schema valueSchema, object value,
                            long timestamp, Iterable<Header.Header> headers)
              : base(sourcePartition, sourceOffset, topic, partition, keySchema, key, valueSchema, value, timestamp, headers)
        {
        }

        public Map<string, object> SourcePartition => IExecute<Map<string, object>>("sourcePartition");

        public Map<string, object> SourceOffset => IExecute<Map<string, object>>("sourceOffset");
    }
}