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

using Org.Apache.Kafka.Common.Header;

namespace Org.Apache.Kafka.Streams.Processor.Api
{
    public class Record<K, V> : MASES.JCOBridge.C2JBridge.JVMBridgeBase<Record<K, V>>
    {
        public override string ClassName => "org.apache.kafka.streams.processor.api.Record";

        [System.Obsolete("This is not public in Apache Kafka API")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public Record() { }

        public Record(K key, V value, long timestamp, Headers headers)
            : base(key, value, timestamp, headers)
        {
        }

        public Record(K key, V value, long timestamp)
            : base(key, value, timestamp)
        {
        }

        public K Key => IExecute<K>("key");

        public V Value => IExecute<V>("value");

        public long Timestamp => IExecute<long>("timestamp");

        public Headers Headers => IExecute<Headers>("headers");

        public Record<NewK, V> WithKey<NewK>(NewK key)
        {
            return IExecute<Record<NewK, V>>("withKey", key);
        }

        public Record<K, NewV> WithValue<NewV>(NewV value)
        {
            return IExecute<Record<K, NewV>>("withValue", value);
        }

        public Record<K, V> WithTimestamp(long timestamp)
        {
            return IExecute<Record<K, V>>("withTimestamp", timestamp);
        }

        public Record<K, V> WithHeaders(Headers headers)
        {
            return IExecute<Record<K, V>>("withHeaders", headers);
        }
    }
}
