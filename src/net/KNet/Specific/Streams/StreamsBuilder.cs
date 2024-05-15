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

using MASES.JNet.Specific.Extensions;
using MASES.KNet.Serialization;
using MASES.KNet.Streams.Kstream;
using System;
using System.Collections;

namespace MASES.KNet.Streams
{
    /// <summary>
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.StreamsBuilder"/>
    /// </summary>
    public class StreamsBuilder : IGenericSerDesFactoryApplier
    {
        Org.Apache.Kafka.Streams.StreamsBuilder _builder;
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/StreamsBuilder.html#org.apache.kafka.streams.StreamsBuilder(org.apache.kafka.streams.TopologyConfig)"/>
        /// </summary>
        /// <param name="factory"><see cref="StreamsConfigBuilder"/> used as reference of <see cref="IGenericSerDesFactory"/></param>
        public StreamsBuilder(StreamsConfigBuilder factory) : base() { _factory = factory; _builder = new Org.Apache.Kafka.Streams.StreamsBuilder(); }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/StreamsBuilder.html#org.apache.kafka.streams.StreamsBuilder(org.apache.kafka.streams.TopologyConfig)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.TopologyConfig"/></param>
        public StreamsBuilder(TopologyConfig arg0)
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) _factory = applier.Factory;
            _builder = new Org.Apache.Kafka.Streams.StreamsBuilder(arg0);
        }

        StreamsBuilder(IGenericSerDesFactory factory, Org.Apache.Kafka.Streams.StreamsBuilder builder) : base() { _factory = factory; _builder = builder; }

        #endregion
        /// <summary>
        /// If set, this <see cref="Func{T, TResult}"/> will be called from <see cref="PrepareProperties(StreamsConfigBuilder)"/>
        /// </summary>
        public static Func<StreamsConfigBuilder, Java.Util.Properties> OverrideProperties { get; set; }
        /// <summary>
        /// Override this method to check and modify the <see cref="Java.Util.Properties"/> returned to underlying <see cref="Org.Apache.Kafka.Streams.KafkaStreams"/>
        /// </summary>
        /// <param name="builder"><see cref="StreamsConfigBuilder"/> to use to return <see cref="Java.Util.Properties"/></param>
        /// <returns><see cref="Java.Util.Properties"/> used from underlying <see cref="Org.Apache.Kafka.Streams.KafkaStreams"/></returns>
        protected virtual Java.Util.Properties PrepareProperties(StreamsConfigBuilder builder)
        {
            return OverrideProperties != null ? OverrideProperties(builder) : builder;
        }

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/StreamsBuilder.html#globalTable-java.lang.String-KNetConsumed{K, V}-KNetMaterialized{K, V}-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="Consumed{K, V, TJVMK, TJVMV}"/></param>
        /// <param name="arg2"><see cref="Materialized{K, V, TJVMK, TJVMV}"/></param>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <returns><see cref="GlobalKTable{K, V, TJVMK, TJVMV}"/></returns>
        public GlobalKTable<K, V, byte[], byte[]> GlobalTable<K, V>(string arg0, Consumed<K, V, byte[], byte[]> arg1, Materialized<K, V, byte[], byte[]> arg2)
        {
            if (arg1 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            if (arg2 is IGenericSerDesFactoryApplier applier2) applier2.Factory = _factory;
            return new GlobalKTable<K, V, byte[], byte[]>(_factory, _builder.GlobalTable<byte[], byte[]>(arg0, arg1, arg2));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/StreamsBuilder.html#globalTable-java.lang.String-KNetConsumed{K, V}-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="Consumed{K, V, TJVMK, TJVMV}"/></param>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <returns><see cref="GlobalKTable{K, V, TJVMK, TJVMV}"/></returns>
        public GlobalKTable<K, V, byte[], byte[]> GlobalTable<K, V>(string arg0, Consumed<K, V, byte[], byte[]> arg1)
        {
            if (arg1 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new GlobalKTable<K, V, byte[], byte[]>(_factory, _builder.GlobalTable<byte[], byte[]>(arg0, arg1));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/StreamsBuilder.html#globalTable-java.lang.String-KNetMaterialized{K, V}-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="Materialized{K, V, TJVMK, TJVMV}"/></param>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <returns><see cref="GlobalKTable{K, V, TJVMK, TJVMV}"/></returns>
        public GlobalKTable<K, V, byte[], byte[]> GlobalTable<K, V>(string arg0, Materialized<K, V, byte[], byte[]> arg1)
        {
            if (arg1 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new GlobalKTable<K, V, byte[], byte[]>(_factory, _builder.GlobalTable<byte[], byte[]>(arg0, arg1));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/StreamsBuilder.html#globalTable-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <returns><see cref="GlobalKTable{K, V, TJVMK, TJVMV}"/></returns>
        public GlobalKTable<K, V, byte[], byte[]> GlobalTable<K, V>(string arg0)
        {
            return new GlobalKTable<K, V, byte[], byte[]>(_factory, _builder.GlobalTable<byte[], byte[]>(arg0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/StreamsBuilder.html#stream-java.lang.String-KNetConsumed{K, V}-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="Consumed{K, V, TJVMK, TJVMV}"/></param>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <returns><see cref="KStream{K, V, TJVMK, TJVMV}"/></returns>
        public KStream<K, V, byte[], byte[]> Stream<K, V>(string arg0, Consumed<K, V, byte[], byte[]> arg1)
        {
            if (arg1 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KStream<K, V, byte[], byte[]>(_factory, _builder.Stream<byte[], byte[]>(arg0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/StreamsBuilder.html#stream-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <returns><see cref="KStream{K, V, TJVMK, TJVMV}"/></returns>
        public KStream<K, V, byte[], byte[]> Stream<K, V>(string arg0)
        {
            return new KStream<K, V, byte[], byte[]>(_factory, _builder.Stream<byte[], byte[]>(arg0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/StreamsBuilder.html#stream-java.util.Collection-KNetConsumed{K, V}-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.Collection"/></param>
        /// <param name="arg1"><see cref="Consumed{K, V, TJVMK, TJVMV}"/></param>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <returns><see cref="KStream{K, V, TJVMK, TJVMV}"/></returns>
        public KStream<K, V, byte[], byte[]> Stream<K, V>(System.Collections.Generic.IEnumerable<string> arg0, Consumed<K, V, byte[], byte[]> arg1)
        {
            if (arg1 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KStream<K, V, byte[], byte[]>(_factory, _builder.Stream<byte[], byte[]>(arg0.ToJVMCollection<Java.Lang.String, string>(), arg1));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/StreamsBuilder.html#stream-java.util.Collection-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.Collection"/></param>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <returns><see cref="KStream{K, V, TJVMK, TJVMV}"/></returns>
        public KStream<K, V, byte[], byte[]> Stream<K, V>(System.Collections.Generic.IEnumerable<string> arg0)
        {
            return new KStream<K, V, byte[], byte[]>(_factory, _builder.Stream<byte[], byte[]>(arg0.ToJVMCollection<Java.Lang.String, string>()));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/StreamsBuilder.html#stream-java.util.regex.Pattern-KNetConsumed{K, V}-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.Regex.Pattern"/></param>
        /// <param name="arg1"><see cref="Consumed{K, V, TJVMK, TJVMV}"/></param>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <returns><see cref="KStream{K, V, TJVMK, TJVMV}"/></returns>
        public KStream<K, V, byte[], byte[]> Stream<K, V>(Java.Util.Regex.Pattern arg0, Consumed<K, V, byte[], byte[]> arg1)
        {
            if (arg1 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KStream<K, V, byte[], byte[]>(_factory, _builder.Stream<byte[], byte[]>(arg0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/StreamsBuilder.html#stream-java.util.regex.Pattern-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.Regex.Pattern"/></param>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <returns><see cref="KStream{K, V, TJVMK, TJVMV}"/></returns>
        public KStream<K, V, byte[], byte[]> Stream<K, V>(Java.Util.Regex.Pattern arg0)
        {
            return new KStream<K, V, byte[], byte[]>(_factory, _builder.Stream<byte[], byte[]>(arg0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/StreamsBuilder.html#table-java.lang.String-KNetConsumed{K, V}-KNetMaterialized{K, V}-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="Consumed{K, V, TJVMK, TJVMV}"/></param>
        /// <param name="arg2"><see cref="Materialized{K, V, TJVMK, TJVMV}"/></param>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></returns>
        public KTable<K, V, byte[], byte[]> Table<K, V>(string arg0, Consumed<K, V, byte[], byte[]> arg1, Materialized<K, V, byte[], byte[]> arg2)
        {
            if (arg1 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            if (arg2 is IGenericSerDesFactoryApplier applier2) applier2.Factory = _factory;
            return new KTable<K, V, byte[], byte[]>(_factory, _builder.Table<byte[], byte[]>(arg0, arg1, arg2));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/StreamsBuilder.html#table-java.lang.String-KNetConsumed{K, V}-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="Consumed{K, V, TJVMK, TJVMV}"/></param>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <returns><see cref="KTable{K, V, TJVMK, TJVMV}"/></returns>
        public KTable<K, V, byte[], byte[]> Table<K, V>(string arg0, Consumed<K, V, byte[], byte[]> arg1)
        {
            if (arg1 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KTable<K, V, byte[], byte[]>(_factory, _builder.Table<byte[], byte[]>(arg0, arg1));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/StreamsBuilder.html#table-java.lang.String-KNetMaterialized{K, V}-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="Materialized{K, V, TJVMK, TJVMV}"/></param>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <returns><see cref="KTable{K, V, TJVMK, TJVMV}"/></returns>
        public KTable<K, V, byte[], byte[]> Table<K, V>(string arg0, Materialized<K, V, byte[], byte[]> arg1)
        {
            if (arg1 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KTable<K, V, byte[], byte[]>(_factory, _builder.Table<byte[], byte[]>(arg0, arg1));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/StreamsBuilder.html#table-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <returns><see cref="KTable{K, V, TJVMK, TJVMV}"/></returns>
        public KTable<K, V, byte[], byte[]> Table<K, V>(string arg0)
        {
            return new KTable<K, V, byte[], byte[]>(_factory, _builder.Table<byte[], byte[]>(arg0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/StreamsBuilder.html#addStateStore-org.apache.kafka.streams.state.StoreBuilder-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.State.StoreBuilder"/></param>
        /// <returns><see cref="StreamsBuilder"/></returns>
        public StreamsBuilder AddStateStore(Org.Apache.Kafka.Streams.State.StoreBuilder arg0)
        {
            return new StreamsBuilder(_factory, _builder.AddStateStore(arg0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/StreamsBuilder.html#build--"/>
        /// </summary>
        /// <returns><see cref="Topology"/></returns>
        public Topology Build()
        {
            return new Topology(_builder.Build(), _factory);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/StreamsBuilder.html#build-java.util.Properties-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.Properties"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Topology"/></returns>
        public Topology Build(Java.Util.Properties arg0)
        {
            return new Topology(_builder.Build(arg0), _factory);
        }

        #endregion
    }
}
