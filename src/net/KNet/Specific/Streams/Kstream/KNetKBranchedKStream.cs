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

using MASES.KNet.Serialization;

namespace MASES.KNet.Streams.Kstream
{
    /// <summary>
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.Kstream.BranchedKStream{K, V}"/>
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    public class KNetBranchedKStream<K, V> : IGenericSerDesFactoryApplier
    {
        Org.Apache.Kafka.Streams.Kstream.BranchedKStream<byte[], byte[]> _inner;

        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

        internal KNetBranchedKStream(IGenericSerDesFactory factory, Org.Apache.Kafka.Streams.Kstream.BranchedKStream<byte[], byte[]> inner)
        {
            _factory = factory;
            _inner = inner;
        }

        /// <summary>
        /// Converter from <see cref="KNetBranchedKStream{K, V}"/> to <see cref="Org.Apache.Kafka.Streams.Kstream.BranchedKStream{K, V}"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.Kstream.BranchedKStream<byte[], byte[]>(KNetBranchedKStream<K, V> t) => t._inner;

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/BranchedKStream.html#defaultBranch--"/>
        /// </summary>
        /// <returns><see cref="System.Collections.Generic.IReadOnlyDictionary{TKey, TValue}"/></returns>
        public System.Collections.Generic.IReadOnlyDictionary<string, KNetKStream<K, V>> DefaultBranch()
        {
            var dict = new System.Collections.Generic.Dictionary<string, KNetKStream<K, V>>();
            var map = _inner.DefaultBranch();
            foreach (var item in map.KeySet())
            {
                var kStream = new KNetKStream<K, V>(_factory, map.Get(item));
                dict.Add(item, kStream);
            }

            return dict;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/BranchedKStream.html#defaultBranch-org.apache.kafka.streams.kstream.Branched-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.Branched"/></param>
        /// <returns><see cref="Java.Util.Map"/></returns>
        public System.Collections.Generic.IReadOnlyDictionary<string, KNetKStream<K, V>> DefaultBranch(KNetBranched<K, V> arg0)
        {
            var dict = new System.Collections.Generic.Dictionary<string, KNetKStream<K, V>>();
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            var map = _inner.DefaultBranch(arg0);
            foreach (var item in map.KeySet())
            {
                var kStream = new KNetKStream<K, V>(_factory, map.Get(item));
                dict.Add(item, kStream);
            }

            return dict;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/BranchedKStream.html#noDefaultBranch--"/>
        /// </summary>
        /// <returns><see cref="Java.Util.Map"/></returns>
        public System.Collections.Generic.IReadOnlyDictionary<string, KNetKStream<K, V>> NoDefaultBranch()
        {
            var dict = new System.Collections.Generic.Dictionary<string, KNetKStream<K, V>>();
            var map = _inner.NoDefaultBranch();
            foreach (var item in map.KeySet())
            {
                var kStream = new KNetKStream<K, V>(_factory, map.Get(item));
                dict.Add(item, kStream);
            }

            return dict;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/BranchedKStream.html#branch-org.apache.kafka.streams.kstream.Predicate-org.apache.kafka.streams.kstream.Branched-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.Predicate"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.Branched"/></param>
        /// <typeparam name="Arg0objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg0objectSuperV"><typeparamref name="V"/></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.BranchedKStream"/></returns>
        public KNetBranchedKStream<K, V> Branch<Arg0objectSuperK, Arg0objectSuperV>(KNetPredicate<Arg0objectSuperK, Arg0objectSuperV> arg0, KNetBranched<K, V> arg1) where Arg0objectSuperK : K where Arg0objectSuperV : V
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            return new KNetBranchedKStream<K, V>(_factory, _inner.Branch<byte[], byte[]>(arg0, arg1));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/BranchedKStream.html#branch-org.apache.kafka.streams.kstream.Predicate-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.Predicate"/></param>
        /// <typeparam name="Arg0objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg0objectSuperV"><typeparamref name="V"/></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.BranchedKStream"/></returns>
        public KNetBranchedKStream<K, V> Branch<Arg0objectSuperK, Arg0objectSuperV>(KNetPredicate<Arg0objectSuperK, Arg0objectSuperV> arg0) where Arg0objectSuperK : K where Arg0objectSuperV : V
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KNetBranchedKStream<K, V>(_factory, _inner.Branch<byte[], byte[]>(arg0));
        }
    }
}
