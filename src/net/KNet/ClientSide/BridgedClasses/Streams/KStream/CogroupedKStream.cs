﻿/*
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
    public interface ICogroupedKStream<K, VOut> : IJVMBridgeBase
    {
        CogroupedKStream<K, VOut> Cogroup<TSuperK, TSuperVIn, VIn>(KGroupedStream<K, VIn> groupedStream,
                                                                   Aggregator<TSuperK, TSuperVIn, VOut> aggregator);

        KTable<K, VOut> Aggregate(Initializer<VOut> initializer);

        KTable<K, VOut> Aggregate(Initializer<VOut> initializer,
                                  Named named);

        KTable<K, VOut> Aggregate(Initializer<VOut> initializer,
                                  Materialized<K, VOut, KeyValueStore<Bytes, byte[]>> materialized);

        KTable<K, VOut> Aggregate(Initializer<VOut> initializer,
                                  Named named,
                                  Materialized<K, VOut, KeyValueStore<Bytes, byte[]>> materialized);

        TimeWindowedCogroupedKStream<K, VOut> WindowedBy<W>(Windows<W> windows)
            where W : Window;

        TimeWindowedCogroupedKStream<K, VOut> WindowedBy(SlidingWindows windows);

        SessionWindowedCogroupedKStream<K, VOut> WindowedBy(SessionWindows windows);
    }

    public class CogroupedKStream<K, VOut> : JVMBridgeBase<CogroupedKStream<K, VOut>, ICogroupedKStream<K, VOut>>, ICogroupedKStream<K, VOut>
    {
        public override string ClassName => "org.apache.kafka.streams.kstream.CogroupedKStream";

        public KTable<K, VOut> Aggregate(Initializer<VOut> initializer)
        {
            return IExecute<KTable<K, VOut>>("aggregate", initializer);
        }

        public KTable<K, VOut> Aggregate(Initializer<VOut> initializer, Named named)
        {
            return IExecute<KTable<K, VOut>>("aggregate", initializer, named);
        }

        public KTable<K, VOut> Aggregate(Initializer<VOut> initializer, Materialized<K, VOut, KeyValueStore<Bytes, byte[]>> materialized)
        {
            return IExecute<KTable<K, VOut>>("aggregate", initializer, materialized);
        }

        public KTable<K, VOut> Aggregate(Initializer<VOut> initializer, Named named, Materialized<K, VOut, KeyValueStore<Bytes, byte[]>> materialized)
        {
            return IExecute<KTable<K, VOut>>("aggregate", initializer, named, materialized);
        }

        public CogroupedKStream<K, VOut> Cogroup<TSuperK, TSuperVIn, VIn>(KGroupedStream<K, VIn> groupedStream, Aggregator<TSuperK, TSuperVIn, VOut> aggregator)
        {
            return IExecute<CogroupedKStream<K, VOut>>("cogroup", groupedStream, aggregator);
        }

        public TimeWindowedCogroupedKStream<K, VOut> WindowedBy<W>(Windows<W> windows) where W : Window
        {
            return IExecute<TimeWindowedCogroupedKStream<K, VOut>>("windowedBy", windows);
        }

        public TimeWindowedCogroupedKStream<K, VOut> WindowedBy(SlidingWindows windows)
        {
            return IExecute<TimeWindowedCogroupedKStream<K, VOut>>("windowedBy", windows);
        }

        public SessionWindowedCogroupedKStream<K, VOut> WindowedBy(SessionWindows windows)
        {
            return IExecute<SessionWindowedCogroupedKStream<K, VOut>>("windowedBy", windows);
        }
    }
}
