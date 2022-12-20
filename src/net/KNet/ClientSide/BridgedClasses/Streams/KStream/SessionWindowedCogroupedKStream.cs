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
    public interface ISessionWindowedCogroupedKStream<K, V> : IJVMBridgeBase
    {
        KTable<Windowed<K>, V> Aggregate<TSuperK>(Initializer<V> initializer,
                                         Merger<TSuperK, V> sessionMerger)
            where TSuperK : K;

        KTable<Windowed<K>, V> Aggregate<TSuperK>(Initializer<V> initializer,
                                         Merger<TSuperK, V> sessionMerger,
                                         Named named)
            where TSuperK : K;

        KTable<Windowed<K>, V> Aggregate<TSuperK>(Initializer<V> initializer,
                                         Merger<TSuperK, V> sessionMerger,
                                         Materialized<K, V, SessionStore<Bytes, byte[]>> materialized)
            where TSuperK : K;

        KTable<Windowed<K>, V> Aggregate<TSuperK>(Initializer<V> initializer,
                                         Merger<TSuperK, V> sessionMerger,
                                         Named named,
                                         Materialized<K, V, SessionStore<Bytes, byte[]>> materialized)
            where TSuperK : K;
    }

    public class SessionWindowedCogroupedKStream<K, V> : JVMBridgeBase<SessionWindowedCogroupedKStream<K, V>, ISessionWindowedCogroupedKStream<K, V>>, ISessionWindowedCogroupedKStream<K, V>
    {
        public override string ClassName => "org.apache.kafka.streams.kstream.SessionWindowedCogroupedKStream";

        public KTable<Windowed<K>, V> Aggregate<TSuperK>(Initializer<V> initializer, Merger<TSuperK, V> sessionMerger) where TSuperK : K
        {
            return IExecute<KTable<Windowed<K>, V>>("aggregate", initializer, sessionMerger);
        }

        public KTable<Windowed<K>, V> Aggregate<TSuperK>(Initializer<V> initializer, Merger<TSuperK, V> sessionMerger, Named named) where TSuperK : K
        {
            return IExecute<KTable<Windowed<K>, V>>("aggregate", initializer, sessionMerger, named);
        }

        public KTable<Windowed<K>, V> Aggregate<TSuperK>(Initializer<V> initializer, Merger<TSuperK, V> sessionMerger, Materialized<K, V, SessionStore<Bytes, byte[]>> materialized) where TSuperK : K
        {
            return IExecute<KTable<Windowed<K>, V>>("aggregate", initializer, sessionMerger, materialized);
        }

        public KTable<Windowed<K>, V> Aggregate<TSuperK>(Initializer<V> initializer, Merger<TSuperK, V> sessionMerger, Named named, Materialized<K, V, SessionStore<Bytes, byte[]>> materialized) where TSuperK : K
        {
            return IExecute<KTable<Windowed<K>, V>>("aggregate", initializer, sessionMerger, named, materialized);
        }
    }
}
