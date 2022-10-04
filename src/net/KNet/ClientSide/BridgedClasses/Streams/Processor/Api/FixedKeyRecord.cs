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

using MASES.KNet.Common.Header;

namespace MASES.KNet.Streams.Processor.Api
{
    public class FixedKeyRecord<K, V> : JCOBridge.C2JBridge.JVMBridgeBase<FixedKeyRecord<K, V>>
    {
        public override string ClassName => "org.apache.kafka.streams.processor.api.FixedKeyRecord";

        [System.Obsolete("This is not public in Apache Kafka API")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public FixedKeyRecord() { }

        public FixedKeyRecord(K key, V value, long timestamp, Headers headers)
            : base(key, value, timestamp, headers)
        {
        }

        public FixedKeyRecord(K key, V value, long timestamp)
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

        public FixedKeyRecord<K, NewV> WithValue<NewV>(NewV value)
        {
            return IExecute<FixedKeyRecord<K, NewV>>("withValue", value);
        }

        public FixedKeyRecord<K, V> WithTimestamp(long timestamp)
        {
            return IExecute<FixedKeyRecord<K, V>>("withTimestamp", timestamp);
        }

        public FixedKeyRecord<K, V> WithHeaders(Headers headers)
        {
            return IExecute<FixedKeyRecord<K, V>>("withHeaders", headers);
        }
    }
}
