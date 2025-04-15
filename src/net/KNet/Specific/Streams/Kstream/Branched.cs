/*
*  Copyright 2025 MASES s.r.l.
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
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.Kstream.Branched{TJVMK, TJVMV}"/>
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
    /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
    public class Branched<K, V, TJVMK, TJVMV> : IGenericSerDesFactoryApplier
    {
        readonly Org.Apache.Kafka.Streams.Kstream.Branched<TJVMK, TJVMV> _inner;
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

        Branched(Org.Apache.Kafka.Streams.Kstream.Branched<TJVMK, TJVMV> inner)
        {
            _inner = inner;
        }

        /// <summary>
        /// Converter from <see cref="Branched{K, V, TJVMK, TJVMV}"/> to <see cref="Org.Apache.Kafka.Streams.Kstream.Branched{TJVMK, TJVMV}"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.Kstream.Branched<TJVMK, TJVMV>(Branched<K, V, TJVMK, TJVMV> t) => t._inner;

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/Branched.html#as(java.lang.String)"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="Branched{K, V, TJVMK, TJVMV}"/></returns>
        public static Branched<K, V, TJVMK, TJVMV> As(string arg0)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Branched<TJVMK, TJVMV>.As(arg0);
            return new Branched<K, V, TJVMK, TJVMV>(cons);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/Branched.html#withConsumer(java.util.function.Consumer,java.lang.String)"/>
        /// </summary>
        /// <param name="arg0"><see cref="KStreamConsumer{K, V, TJVMK, TJVMV}"/></param>
        /// <param name="arg1"><see cref="string"/></param>
        /// <returns><see cref="Branched{K, V, TJVMK, TJVMV}"/></returns>
        public static Branched<K, V, TJVMK, TJVMV> WithConsumer(KStreamConsumer<K, V, TJVMK, TJVMV> arg0, string arg1)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Branched<TJVMK, TJVMV>.WithConsumer(arg0, arg1);
            return new Branched<K, V, TJVMK, TJVMV>(cons);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/Branched.html#withConsumer(java.util.function.Consumer)"/>
        /// </summary>
        /// <param name="arg0"><see cref="KStreamConsumer{K, V}"/></param>
        /// <returns><see cref="Branched{K, V, TJVMK, TJVMV}"/></returns>
        public static Branched<K, V, TJVMK, TJVMV> WithConsumer(KStreamConsumer<K, V, TJVMK, TJVMV> arg0)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Branched<TJVMK, TJVMV>.WithConsumer(arg0);
            return new Branched<K, V, TJVMK, TJVMV>(cons);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/Branched.html#withFunction(java.util.function.Function,java.lang.String)"/>
        /// </summary>
        /// <param name="arg0"><see cref="KStreamFunction{K, V}"/></param>
        /// <param name="arg1"><see cref="string"/></param>
        /// <returns><see cref="Branched{K, V, TJVMK, TJVMV}"/></returns>
        public static Branched<K, V, TJVMK, TJVMV> WithFunction(KStreamFunction<K, V, TJVMK, TJVMV> arg0, string arg1)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Branched<TJVMK, TJVMV>.WithFunction(arg0, arg1);
            return new Branched<K, V, TJVMK, TJVMV>(cons);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/Branched.html#withFunction(java.util.function.Function)"/>
        /// </summary>
        /// <param name="arg0"><see cref="KStreamFunction{K, V, TJVMK, TJVMV}"/></param>
        /// <returns><see cref="Branched{K, V, TJVMK, TJVMV}"/></returns>
        public static Branched<K, V, TJVMK, TJVMV> WithFunction(KStreamFunction<K, V, TJVMK, TJVMV> arg0)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Branched<TJVMK, TJVMV>.WithFunction(arg0);
            return new Branched<K, V, TJVMK, TJVMV>(cons);
        }

        #endregion
    }
}
