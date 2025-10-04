/*
*  Copyright (c) 2021-2025 MASES s.r.l.
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
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.Kstream.TimeWindowedCogroupedKStream{TJVMK, TJVMV}"/>
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
    /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
    public class TimeWindowedCogroupedKStream<K, V, TJVMK, TJVMV> : IGenericSerDesFactoryApplier
    {
        Org.Apache.Kafka.Streams.Kstream.TimeWindowedCogroupedKStream<TJVMK, TJVMV> _inner;

        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set => _factory = value; }

        internal TimeWindowedCogroupedKStream(IGenericSerDesFactory factory, Org.Apache.Kafka.Streams.Kstream.TimeWindowedCogroupedKStream<TJVMK, TJVMV> inner)
        {
            _factory = factory;
            _inner = inner;
        }

        /// <summary>
        /// Converter from <see cref="TimeWindowedCogroupedKStream{K, V, TJVMK, TJVMV}"/> to <see cref="Org.Apache.Kafka.Streams.Kstream.TimeWindowedCogroupedKStream{TJVMK, TJVMV}"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.Kstream.TimeWindowedCogroupedKStream<TJVMK, TJVMV>(TimeWindowedCogroupedKStream<K, V, TJVMK, TJVMV> t) => t._inner;

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.1.0/org/apache/kafka/streams/kstream/TimeWindowedCogroupedKStream.html#aggregate(org.apache.kafka.streams.kstream.Initializer,org.apache.kafka.streams.kstream.Materialized)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Initializer{VA, TJVMVA}"/></param>
        /// <param name="arg1"><see cref="Materialized{K, V, TJVMK, TJVMV}"/></param>
        /// <returns><see cref="KTable{K, V, TJVMK, TJVMV}"/></returns>
        public KTable<K, V, Org.Apache.Kafka.Streams.Kstream.Windowed<TJVMK>, TJVMV> Aggregate(Initializer<V, TJVMV> arg0, Materialized<K, V, TJVMK, TJVMV> arg1)
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            return new KTable<K, V, Org.Apache.Kafka.Streams.Kstream.Windowed<TJVMK>, TJVMV>(_factory, _inner.Aggregate(arg0, arg1));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.1.0/org/apache/kafka/streams/kstream/TimeWindowedCogroupedKStream.html#aggregate(org.apache.kafka.streams.kstream.Initializer,org.apache.kafka.streams.kstream.Named,org.apache.kafka.streams.kstream.Materialized)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Initializer{VA, TJVMVA}"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <param name="arg2"><see cref="Materialized{K, V, TJVMK, TJVMV}"/></param>
        /// <returns><see cref="KTable{K, V, TJVMK, TJVMV}"/></returns>
        public KTable<K, V, Org.Apache.Kafka.Streams.Kstream.Windowed<TJVMK>, TJVMV> Aggregate(Initializer<V, TJVMV> arg0, Org.Apache.Kafka.Streams.Kstream.Named arg1, Materialized<K, V,TJVMK, TJVMV> arg2)
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            if (arg2 is IGenericSerDesFactoryApplier applier2) applier2.Factory = _factory;
            return new KTable<K, V, Org.Apache.Kafka.Streams.Kstream.Windowed<TJVMK>, TJVMV>(_factory, _inner.Aggregate(arg0, arg1, arg2));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.1.0/org/apache/kafka/streams/kstream/TimeWindowedCogroupedKStream.html#aggregate(org.apache.kafka.streams.kstream.Initializer,org.apache.kafka.streams.kstream.Named)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Initializer{VA, TJVMVA}"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <returns><see cref="KTable{K, V, TJVMK, TJVMV}"/></returns>
        public KTable<K, V, Org.Apache.Kafka.Streams.Kstream.Windowed<TJVMK>, TJVMV> Aggregate(Initializer<V, TJVMV> arg0, Org.Apache.Kafka.Streams.Kstream.Named arg1)
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KTable<K, V, Org.Apache.Kafka.Streams.Kstream.Windowed<TJVMK>, TJVMV>(_factory, _inner.Aggregate(arg0, arg1));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.1.0/org/apache/kafka/streams/kstream/TimeWindowedCogroupedKStream.html#aggregate(org.apache.kafka.streams.kstream.Initializer)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Initializer{VA, TJVMVA}"/></param>
        /// <returns><see cref="KTable{K, V, TJVMK, TJVMV}"/></returns>
        public KTable<K, V, Org.Apache.Kafka.Streams.Kstream.Windowed<TJVMK>, TJVMV> Aggregate(Initializer<V, TJVMV> arg0)
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KTable<K, V, Org.Apache.Kafka.Streams.Kstream.Windowed<TJVMK>, TJVMV>(_factory, _inner.Aggregate(arg0));
        }

        #endregion
    }
}
