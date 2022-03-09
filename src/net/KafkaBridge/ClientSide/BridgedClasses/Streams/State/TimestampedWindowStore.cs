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


using Java.Time;
using Java.Util;
using MASES.KafkaBridge.Streams.KStream;

namespace MASES.KafkaBridge.Streams.State
{
    public interface ITimestampedWindowStore<K, V> : IWindowStore<K, ValueAndTimestamp<V>>
    {
    }

    public class TimestampedWindowStore<K, V> : WindowStore<K, V>, ITimestampedWindowStore<K, V>
    {
        public override string ClassName => "org.apache.kafka.streams.state.TimestampedWindowStore";

        public new KeyValueIterator<Windowed<K>, ValueAndTimestamp<V>> All => IExecute<KeyValueIterator<Windowed<K>, ValueAndTimestamp<V>>>("all");

        public void Put(K key, ValueAndTimestamp<V> value, long windowStartTimestamp)
        {
            IExecute("put", key, value, windowStartTimestamp);
        }

        public new ValueAndTimestamp<V> Fetch(K key, long time)
        {
            return IExecute<ValueAndTimestamp<V>>("fetch", key, time);
        }

        public new WindowStoreIterator<ValueAndTimestamp<V>> Fetch(K key, Instant timeFrom, Instant timeTo)
        {
            return IExecute<WindowStoreIterator<ValueAndTimestamp<V>>>("fetch", key, timeFrom, timeTo);
        }

        public new KeyValueIterator<Windowed<K>, ValueAndTimestamp<V>> Fetch(K keyFrom, K keyTo, Instant timeFrom, Instant timeTo)
        {
            return IExecute<KeyValueIterator<Windowed<K>, ValueAndTimestamp<V>>>("fetch", keyFrom, keyTo, timeFrom, timeTo);
        }

        public new KeyValueIterator<Windowed<K>, ValueAndTimestamp<V>> FetchAll(Instant timeFrom, Instant timeTo)
        {
            return IExecute<KeyValueIterator<Windowed<K>, ValueAndTimestamp<V>>>("fetchAll", timeFrom, timeTo);
        }
    }
}
