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
using Java.Time;
using MASES.KNet.Streams.KStream;

namespace MASES.KNet.Streams.State
{
    public interface IReadOnlyWindowStore<K, V> : IJVMBridgeBase
    {
        V Fetch(K key, long time);

        WindowStoreIterator<V> Fetch(K key, Instant timeFrom, Instant timeTo);

        KeyValueIterator<Windowed<K>, V> Fetch(K keyFrom, K keyTo, Instant timeFrom, Instant timeTo);

        KeyValueIterator<Windowed<K>, V> All { get; }

        KeyValueIterator<Windowed<K>, V> FetchAll(Instant timeFrom, Instant timeTo);
    }

    public class ReadOnlyWindowStore<K, V> : JVMBridgeBase<ReadOnlyWindowStore<K, V>, IReadOnlyWindowStore<K, V>>, IReadOnlyWindowStore<K, V>
    {
        public override string ClassName => "org.apache.kafka.streams.state.ReadOnlyWindowStore";

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
            return IExecute<KeyValueIterator<Windowed<K>, V>>("fetch", keyFrom, keyTo, timeFrom, timeTo);
        }

        public KeyValueIterator<Windowed<K>, V> FetchAll(Instant timeFrom, Instant timeTo)
        {
            return IExecute<KeyValueIterator<Windowed<K>, V>>("fetchAll", timeFrom, timeTo);
        }
    }
}

