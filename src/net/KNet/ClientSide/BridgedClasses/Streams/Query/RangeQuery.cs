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

using Java.Util;

namespace MASES.KNet.Streams.Query
{
    public class RangeQuery<K, V> : Query<RangeQuery<K, V>>
    {
        public override bool IsBridgeInterface => false;

        public override string BridgeClassName => "org.apache.kafka.streams.query.RangeQuery";

        public static RangeQuery<K, V> WithRange(K lower, K upper) => SExecute<RangeQuery<K, V>>("withRange", lower, upper);

        public static RangeQuery<K, V> WithUpperBound(K upper) => SExecute<RangeQuery<K, V>>("withUpperBound", upper);

        public static RangeQuery<K, V> WithLowerBound(K lower) => SExecute<RangeQuery<K, V>>("withLowerBound", lower);

        public static RangeQuery<K, V> WithNoBounds() => SExecute<RangeQuery<K, V>>("withNoBounds");

        public Optional<K> LowerBound => IExecute<Optional<K>>("getLowerBound");

        public Optional<K> UpperBound => IExecute<Optional<K>>("getUpperBound");
    }
}
