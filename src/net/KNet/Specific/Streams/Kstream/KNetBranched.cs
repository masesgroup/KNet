/*
*  Copyright 2024 MASES s.r.l.
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
using MASES.KNet.Streams.Utils;

namespace MASES.KNet.Streams.Kstream
{
    /// <summary>
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.Kstream.Branched{K, V}"/>
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    public class KNetBranched<K, V> : IGenericSerDesFactoryApplier
    {
        readonly Org.Apache.Kafka.Streams.Kstream.Branched<byte[], byte[]> _inner;
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

        KNetBranched(Org.Apache.Kafka.Streams.Kstream.Branched<byte[], byte[]> inner)
        {
            _inner = inner;
        }

        /// <summary>
        /// Converter from <see cref="KNetBranched{K, V}"/> to <see cref="Org.Apache.Kafka.Streams.Kstream.Branched{K, V}"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.Kstream.Branched<byte[], byte[]>(KNetBranched<K, V> t) => t._inner;

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Branched.html#as-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="KNetBranched{K, V}"/></returns>
        public static KNetBranched<K, V> As(string arg0)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Branched<byte[], byte[]>.As(arg0);
            return new KNetBranched<K, V>(cons);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Branched.html#withConsumer-java.util.function.Consumer-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="KNetKStreamConsumer{K, V}"/></param>
        /// <param name="arg1"><see cref="string"/></param>
        /// <returns><see cref="KNetBranched{K, V}"/></returns>
        public static KNetBranched<K, V> WithConsumer(KNetKStreamConsumer<K, V> arg0, string arg1)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Branched<byte[], byte[]>.WithConsumer(arg0, arg1);
            return new KNetBranched<K, V>(cons);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Branched.html#withConsumer-java.util.function.Consumer-"/>
        /// </summary>
        /// <param name="arg0"><see cref="KNetKStreamConsumer{K, V}"/></param>
        /// <returns><see cref="KNetBranched{K, V}"/></returns>
        public static KNetBranched<K, V> WithConsumer(KNetKStreamConsumer<K, V> arg0)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Branched<byte[], byte[]>.WithConsumer(arg0);
            return new KNetBranched<K, V>(cons);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Branched.html#withFunction-java.util.function.Function-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="KNetKStreamFunction{K, V}"/></param>
        /// <param name="arg1"><see cref="string"/></param>
        /// <returns><see cref="KNetBranched{K, V}"/></returns>
        public static KNetBranched<K, V> WithFunction(KNetKStreamFunction<K, V> arg0, string arg1)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Branched<byte[], byte[]>.WithFunction(arg0, arg1);
            return new KNetBranched<K, V>(cons);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Branched.html#withFunction-java.util.function.Function-"/>
        /// </summary>
        /// <param name="arg0"><see cref="KNetKStreamFunction{K, V}"/></param>
        /// <returns><see cref="KNetBranched{K, V}"/></returns>
        public static KNetBranched<K, V> WithFunction(KNetKStreamFunction<K, V> arg0)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Branched<byte[], byte[]>.WithFunction(arg0);
            return new KNetBranched<K, V>(cons);
        }

        #endregion
    }
}
