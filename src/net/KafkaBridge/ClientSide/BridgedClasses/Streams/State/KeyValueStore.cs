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

using MASES.KafkaBridge.Java.Util;
using MASES.KafkaBridge.Streams.Processor;

namespace MASES.KafkaBridge.Streams.State
{
    public interface IKeyValueStore<K, V> : IStateStore, IReadOnlyKeyValueStore<K, V>
    {
        void Put(K key, V value);

        V PutIfAbsent(K key, V value);

        void PutAll(List<KeyValue<K, V>> entries);

        V Delete(K key);
    }

    public class KeyValueStore<K, V> : StateStore, IKeyValueStore<K, V>
    {
        public override string ClassName => "org.apache.kafka.streams.state.KeyValueStore";

        public KeyValueIterator<K, V> All => IExecute<KeyValueIterator<K, V>>("all");

        public long ApproximateNumEntries => IExecute<long>("approximateNumEntries");

        public V Delete(K key)
        {
            return IExecute<V>("delete", key);
        }

        public V Get(K key)
        {
            return IExecute<V>("get", key);
        }

        public void Put(K key, V value)
        {
            IExecute("put", key, value);
        }

        public void PutAll(List<KeyValue<K, V>> entries)
        {
            IExecute("putAll", entries);
        }

        public V PutIfAbsent(K key, V value)
        {
            return IExecute<V>("putIfAbsent", key, value);
        }

        public KeyValueIterator<K, V> Range(K from, K to)
        {
            return IExecute<KeyValueIterator<K, V>>("range", from, to);
        }
    }
}