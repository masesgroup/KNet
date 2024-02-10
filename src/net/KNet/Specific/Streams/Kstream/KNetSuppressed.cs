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
using System;

namespace MASES.KNet.Streams.Kstream
{
    /// <summary>
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.Kstream.Suppressed{K}"/>
    /// </summary>
    /// <typeparam name="K"></typeparam>
    public class KNetSuppressed<K> : IGenericSerDesFactoryApplier
    {
        readonly Org.Apache.Kafka.Streams.Kstream.Suppressed<byte[]> _inner;
        readonly Org.Apache.Kafka.Streams.Kstream.Suppressed<Org.Apache.Kafka.Streams.Kstream.Windowed> _inner2;
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

        KNetSuppressed(Org.Apache.Kafka.Streams.Kstream.Suppressed<byte[]> inner)
        {
            _inner = inner;
        }

        KNetSuppressed(Org.Apache.Kafka.Streams.Kstream.Suppressed<Org.Apache.Kafka.Streams.Kstream.Windowed> inner)
        {
            _inner2 = inner;
        }

        /// <summary>
        /// Converter from <see cref="KNetSuppressed{K}"/> to <see cref="Org.Apache.Kafka.Streams.Kstream.Suppressed{K}"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.Kstream.Suppressed<byte[]>(KNetSuppressed<K> t) => t._inner;
        /// <summary>
        /// Converter from <see cref="KNetSuppressed{K}"/> to <see cref="Org.Apache.Kafka.Streams.Kstream.Suppressed{K}"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.Kstream.Suppressed<Org.Apache.Kafka.Streams.Kstream.Windowed>(KNetSuppressed<K> t) => t._inner2;

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Suppressed.html#untilTimeLimit-java.time.Duration-org.apache.kafka.streams.kstream.Suppressed.BufferConfig-"/>
        /// </summary>
        /// <param name="arg0"><see cref="TimeSpan"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.Suppressed.BufferConfig"/></param>
        /// <returns><see cref="KNetSuppressed{K}"/></returns>
        public static KNetSuppressed<K> UntilTimeLimit(TimeSpan arg0, Org.Apache.Kafka.Streams.Kstream.Suppressed.BufferConfig arg1)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Suppressed<byte[]>.UntilTimeLimit(arg0, arg1);
            return new KNetSuppressed<K>(cons);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Suppressed.html#untilWindowCloses-org.apache.kafka.streams.kstream.Suppressed.StrictBufferConfig-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.Suppressed.StrictBufferConfig"/></param>
        /// <returns><see cref="KNetSuppressed{K}"/> with <see cref="Org.Apache.Kafka.Streams.Kstream.Windowed"/></returns>
        public static KNetSuppressed<Org.Apache.Kafka.Streams.Kstream.Windowed> UntilWindowCloses(Org.Apache.Kafka.Streams.Kstream.Suppressed.StrictBufferConfig arg0)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Suppressed<byte[]>.UntilWindowCloses(arg0);
            return new KNetSuppressed<Org.Apache.Kafka.Streams.Kstream.Windowed>(cons);
        }

        #endregion
    }
}
