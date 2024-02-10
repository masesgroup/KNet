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

namespace MASES.KNet.Streams.Kstream
{
    /// <summary>
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.Kstream.Printed{K, V}"/>
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    public class KNetPrinted<K, V> : IGenericSerDesFactoryApplier
    {
        readonly Org.Apache.Kafka.Streams.Kstream.Printed<byte[], byte[]> _inner;
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

        KNetPrinted(Org.Apache.Kafka.Streams.Kstream.Printed<byte[], byte[]> inner)
        {
            _inner = inner;
        }

        /// <summary>
        /// Converter from <see cref="KNetPrinted{K, V}"/> to <see cref="Org.Apache.Kafka.Streams.Kstream.Printed{K, V}"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.Kstream.Printed<byte[], byte[]>(KNetPrinted<K, V> t) => t._inner;

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Printed.html#toFile-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="KNetPrinted{K, V}"/></returns>
        public static KNetPrinted<K, V> ToFile(string arg0)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Printed<byte[], byte[]>.ToFile(arg0);
            return new KNetPrinted<K, V>(cons);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Printed.html#toSysOut--"/>
        /// </summary>
        /// <returns><see cref="KNetPrinted{K, V}"/></returns>
        public static KNetPrinted<K, V> ToSysOut()
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Printed<byte[], byte[]>.ToSysOut();
            return new KNetPrinted<K, V>(cons);
        }

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Printed.html#withKeyValueMapper-org.apache.kafka.streams.kstream.KeyValueMapper-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.KeyValueMapper"/></param>
        /// <typeparam name="Arg0objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg0objectSuperV"><typeparamref name="V"/></typeparam>
        /// <returns><see cref="KNetPrinted{K, V}"/></returns>
        public KNetPrinted<K, V> WithKeyValueMapper<Arg0objectSuperK, Arg0objectSuperV>(KNetKeyValueMapperForString<Arg0objectSuperK, Arg0objectSuperV> arg0) where Arg0objectSuperK : K where Arg0objectSuperV : V
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            _inner?.WithKeyValueMapper(arg0);
            return this;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Printed.html#withLabel-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="KNetPrinted{K, V}"/></returns>
        public KNetPrinted<K, V> WithLabel(string arg0)
        {
            _inner?.WithLabel(arg0);
            return this;
        }

        #endregion
    }
}
