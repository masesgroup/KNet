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


using Java.Util;

namespace MASES.KNet.Streams.State
{
    public interface ITimestampedKeyValueStore<K, V> : IKeyValueStore<K, ValueAndTimestamp<V>>
    {
    }

    public class TimestampedKeyValueStore<K, V> : KeyValueStore<K, V>, ITimestampedKeyValueStore<K, V>
    {
        public override string ClassName => "org.apache.kafka.streams.state.TimestampedKeyValueStore";

        public new KeyValueIterator<K, ValueAndTimestamp<V>> All => IExecute<KeyValueIterator<K, ValueAndTimestamp<V>>>("all");

        public void Put(K key, ValueAndTimestamp<V> value)
        {
            IExecute("put", key, value);
        }

        public void PutAll(List<KeyValue<K, ValueAndTimestamp<V>>> entries)
        {
            IExecute("putAll", entries);
        }

        public ValueAndTimestamp<V> PutIfAbsent(K key, ValueAndTimestamp<V> value)
        {
            return IExecute<ValueAndTimestamp<V>>("putIfAbsent", key, value);
        }

        public new ValueAndTimestamp<V> Delete(K key)
        {
            return IExecute<ValueAndTimestamp<V>>("delete", key);
        }

        public new ValueAndTimestamp<V> Get(K key)
        {
            return IExecute<ValueAndTimestamp<V>>("get", key);
        }

        public new KeyValueIterator<K, ValueAndTimestamp<V>> Range(K from, K to)
        {
            return IExecute<KeyValueIterator<K, ValueAndTimestamp<V>>>("range", from, to);
        }
    }
}
