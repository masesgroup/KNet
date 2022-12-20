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

using MASES.JCOBridge.C2JBridge;
using MASES.KNet.Common.Utils;
using MASES.KNet.Streams.State;

namespace MASES.KNet.Streams.KStream
{
    public interface ITimeWindowedCogroupedKStream<K, V> : IJVMBridgeBase
    {
        KTable<Windowed<K>, V> Aggregate(Initializer<V> initializer);

        KTable<Windowed<K>, V> Aggregate(Initializer<V> initializer,
                                         Named named);

        KTable<Windowed<K>, V> Aggregate(Initializer<V> initializer,
                                         Materialized<K, V, WindowStore<Bytes, byte[]>> materialized);

        KTable<Windowed<K>, V> Aggregate(Initializer<V> initializer,
                                         Named named,
                                         Materialized<K, V, WindowStore<Bytes, byte[]>> materialized);
    }

    public class TimeWindowedCogroupedKStream<K, V> : JVMBridgeBase<TimeWindowedCogroupedKStream<K, V>, ITimeWindowedCogroupedKStream<K, V>>, ITimeWindowedCogroupedKStream<K, V>
    {
        public override string ClassName => "org.apache.kafka.streams.kstream.TimeWindowedCogroupedKStream";

        public KTable<Windowed<K>, V> Aggregate(Initializer<V> initializer)
        {
            return IExecute<KTable<Windowed<K>, V>>("aggregate", initializer);
        }

        public KTable<Windowed<K>, V> Aggregate(Initializer<V> initializer, Named named)
        {
            return IExecute<KTable<Windowed<K>, V>>("aggregate", initializer, named);
        }

        public KTable<Windowed<K>, V> Aggregate(Initializer<V> initializer, Materialized<K, V, WindowStore<Bytes, byte[]>> materialized)
        {
            return IExecute<KTable<Windowed<K>, V>>("aggregate", initializer, materialized);
        }

        public KTable<Windowed<K>, V> Aggregate(Initializer<V> initializer, Named named, Materialized<K, V, WindowStore<Bytes, byte[]>> materialized)
        {
            return IExecute<KTable<Windowed<K>, V>>("aggregate", initializer, named, materialized);
        }
    }
}
