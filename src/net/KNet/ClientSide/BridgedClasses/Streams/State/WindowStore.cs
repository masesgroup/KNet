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

using Java.Time;
using MASES.KNet.Streams.KStream;
using MASES.KNet.Streams.Processor;

namespace MASES.KNet.Streams.State
{
    public interface IWindowStore<K, V> : IStateStore, IReadOnlyWindowStore<K, V>
    {
        void Put(K key, V value, long windowStartTimestamp);
    }

    public class WindowStore<K, V> : StateStore, IWindowStore<K, V>
    {
        public override string BridgeClassName => "org.apache.kafka.streams.state.WindowStore";

        public KeyValueIterator<Windowed<K>, V> All => IExecute<KeyValueIterator<Windowed<K>, V>>("all");

        public V Fetch(K key, long time)
        {
            return IExecute<V>("fetch", key, time);
        }

        public WindowStoreIterator<V> Fetch(K key, Instant timeFrom, Instant timeTo)
        {
            return IExecute<WindowStoreIterator<V>>("fetch", key, timeFrom, timeTo);
        }

        public KeyValueIterator<Windowed<K>, V> Fetch(K keyFrom, K keyTo, Instant timeFrom, Instant timeTo)
        {
            return IExecute<KeyValueIterator<Windowed<K>, V>>("fetch", keyFrom, timeFrom, timeTo);
        }

        public KeyValueIterator<Windowed<K>, V> FetchAll(Instant timeFrom, Instant timeTo)
        {
            return IExecute<KeyValueIterator<Windowed<K>, V>>("fetchAll", timeFrom, timeTo);
        }

        public void Put(K key, V value, long windowStartTimestamp)
        {
            IExecute("put", key, value, windowStartTimestamp);
        }
    }
}

