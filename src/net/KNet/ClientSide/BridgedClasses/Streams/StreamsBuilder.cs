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

using Org.Apache.Kafka.Common.Utils;
using Java.Lang;
using Java.Util;
using Java.Util.Regex;
using Org.Apache.Kafka.Streams.Kstream;
using Org.Apache.Kafka.Streams.Processor.Api;
using Org.Apache.Kafka.Streams.State;

namespace Org.Apache.Kafka.Streams
{
    public partial class StreamsBuilder
    {
        public KTable<K, V> Table<K, V>(string topic, Consumed<K, V> consumed, Materialized<K, V, KeyValueStore<Bytes, byte[]>> materialized)
        {
            return IExecute<KTable<K, V>>("table", topic, consumed, materialized);
        }

        public KTable<K, V> Table<K, V>(string topic, Materialized<K, V, KeyValueStore<Bytes, byte[]>> materialized)
        {
            return IExecute<KTable<K, V>>("table", topic, materialized);
        }

        public GlobalKTable<K, V> GlobalTable<K, V>(string topic, Consumed<K, V> consumed, Materialized<K, V, KeyValueStore<Bytes, byte[]>> materialized)
        {
            return IExecute<GlobalKTable<K, V>>("globalTable", topic, consumed, materialized);
        }

        public GlobalKTable<K, V> GlobalTable<K, V>(string topic, Materialized<K, V, KeyValueStore<Bytes, byte[]>> materialized)
        {
            return IExecute<GlobalKTable<K, V>>("globalTable", topic, materialized);
        }
    }
}
