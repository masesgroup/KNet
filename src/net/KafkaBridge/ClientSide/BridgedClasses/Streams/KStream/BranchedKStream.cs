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
using Java.Util;

namespace MASES.KafkaBridge.Streams.KStream
{
    public interface IBranchedKStream<K, V> : IJVMBridgeBase
    {
        BranchedKStream<K, V> Branch<TKey, TValue>(Predicate<TKey, TValue> predicate)
            where TKey : K
            where TValue : V;

        BranchedKStream<K, V> Branch<TKey, TValue>(Predicate<TKey, TValue> predicate, Branched<K, V> branched)
            where TKey : K
            where TValue : V;

        Map<string, KStream<K, V>> DefaultBranch();

        Map<string, KStream<K, V>> DefaultBranch(Branched<K, V> branched);

        Map<string, KStream<K, V>> NoDefaultBranch();
    }

    public class BranchedKStream<K, V> : JVMBridgeBase<BranchedKStream<K, V>, IBranchedKStream<K, V>>, IBranchedKStream<K, V>
    {
        public override string ClassName => "org.apache.kafka.streams.kstream.BranchedKStream";

        public BranchedKStream<K, V> Branch<TKey, TValue>(Predicate<TKey, TValue> predicate)
            where TKey : K
            where TValue : V
        {
            return IExecute<BranchedKStream<K, V>>("branch", predicate);
        }

        public BranchedKStream<K, V> Branch<TKey, TValue>(Predicate<TKey, TValue> predicate, Branched<K, V> branched)
            where TKey : K
            where TValue : V
        {
            return IExecute<BranchedKStream<K, V>>("branch", predicate, branched);
        }

        public Map<string, KStream<K, V>> DefaultBranch()
        {
            return IExecute<Map<string, KStream<K, V>>>("defaultBranch");
        }

        public Map<string, KStream<K, V>> DefaultBranch(Branched<K, V> branched)
        {
            return IExecute<Map<string, KStream<K, V>>>("defaultBranch", branched);
        }

        public Map<string, KStream<K, V>> NoDefaultBranch()
        {
            return IExecute<Map<string, KStream<K, V>>>("noDefaultBranch");
        }
    }
}
