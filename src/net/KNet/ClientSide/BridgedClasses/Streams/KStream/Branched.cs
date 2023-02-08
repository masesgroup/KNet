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
using Java.Util.Function;

namespace MASES.KNet.Streams.KStream
{
    public class Branched<K, V> : JVMBridgeBase<Branched<K, V>>, INamedOperation<Branched<K, V>>
    {
        public override string ClassName => "org.apache.kafka.streams.kstream.Branched";

        public static Branched<K, V> As(string name)
        {
            return SExecute<Branched<K, V>>("as", name);
        }

        public static Branched<K, V> WithFunction<TKey, TValue>(Function<TKey, TValue> chain)
            where TKey : KStream<K, V>, new()
            where TValue : KStream<K, V>, new()
        {
            return SExecute<Branched<K, V>>("withFunction", chain);
        }

        public static Branched<K, V> WithConsumer<TConsumer>(Consumer<TConsumer> chain)
            where TConsumer : KStream<K, V>, new()
        {
            return SExecute<Branched<K, V>>("withConsumer", chain);
        }

        public static Branched<K, V> WithFunction<TKey, TValue>(Function<TKey, TValue> chain, string name)
            where TKey : KStream<K, V>, new()
            where TValue : KStream<K, V>, new()
        {
            return SExecute<Branched<K, V>>("withFunction", chain, name);
        }

        public static Branched<K, V> WithConsumer<TConsumer>(Consumer<TConsumer> chain, string name)
            where TConsumer : KStream<K, V>, new()
        {
            return SExecute<Branched<K, V>>("withConsumer", chain, name);
        }

        public Branched<K, V> WithName(string name)
        {
            return IExecute<Branched<K, V>>("withName", name);
        }
    }
}
