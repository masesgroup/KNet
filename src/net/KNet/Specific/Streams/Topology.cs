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

using MASES.JNet.Specific.Extensions;
using MASES.KNet.Serialization;
using MASES.KNet.Streams.Processor;

namespace MASES.KNet.Streams
{
    /// <summary>
    /// KNet implementation of <see cref="Org.Apache.Kafka.Streams.Topology"/>
    /// </summary>
    public class Topology : IGenericSerDesFactoryApplier
    {
        readonly Org.Apache.Kafka.Streams.Topology _topology;
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }
        #region Constructors
        /// <inheritdoc/>
        public Topology(IGenericSerDesFactory factory) : base() { _factory = factory; _topology = new Org.Apache.Kafka.Streams.Topology(); }
        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/Topology.html#org.apache.kafka.streams.Topology(org.apache.kafka.streams.TopologyConfig)"/>
        /// </summary>
        /// <param name="arg0"><see cref="TopologyConfig"/></param>
        public Topology(TopologyConfig arg0)
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) _factory = applier.Factory;
            _topology = new Org.Apache.Kafka.Streams.Topology(arg0);
        }

        internal Topology(Org.Apache.Kafka.Streams.Topology topology, IGenericSerDesFactory factory)
        {
            _factory = factory;
            _topology = topology;
        }

        #endregion

        #region Class/Interface conversion operators
        /// <summary>
        /// Converter from <see cref="Topology"/> to <see cref="Org.Apache.Kafka.Streams.Topology"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.Topology(Topology t) => t._topology;

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/Topology.html#addSink-java.lang.String-java.lang.String-org.apache.kafka.common.serialization.Serializer-org.apache.kafka.common.serialization.Serializer-java.lang.String[]-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="string"/></param>
        /// <param name="arg2"><see cref="ISerializer{T, TJVMT}"/></param>
        /// <param name="arg3"><see cref="ISerializer{T, TJVMT}"/></param>
        /// <param name="arg4"><see cref="string"/></param>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <returns><see cref="Topology"/></returns>
        public Topology AddSink<K, V>(string arg0, string arg1, ISerializer<K, byte[]> arg2, ISerializer<V, byte[]> arg3, params string[] arg4)
        {
            var top = _topology.AddSink(arg0, arg1, arg2.KafkaSerializer, arg3.KafkaSerializer, arg4.ToJVMArray<Java.Lang.String, string>());
            return new Topology(top, _factory);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/Topology.html#addSink-java.lang.String-java.lang.String-org.apache.kafka.common.serialization.Serializer-org.apache.kafka.common.serialization.Serializer-org.apache.kafka.streams.processor.StreamPartitioner-java.lang.String[]-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="string"/></param>
        /// <param name="arg2"><see cref="ISerializer{T, TJVMT}"/></param>
        /// <param name="arg3"><see cref="ISerializer{T, TJVMT}"/></param>
        /// <param name="arg4"><see cref="StreamPartitioner{TKey, TValue}"/></param>
        /// <param name="arg5"><see cref="string"/></param>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <typeparam name="Arg4objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg4objectSuperV"><typeparamref name="V"/></typeparam>
        /// <returns><see cref="Topology"/></returns>
        public Topology AddSink<K, V, Arg4objectSuperK, Arg4objectSuperV>(string arg0, string arg1, ISerializer<K, byte[]> arg2, ISerializer<V, byte[]> arg3, StreamPartitioner<Arg4objectSuperK, Arg4objectSuperV> arg4, params string[] arg5) where Arg4objectSuperK : K where Arg4objectSuperV : V
        {
            if (arg4 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            var top = _topology.AddSink(arg0, arg1, arg2.KafkaSerializer, arg3.KafkaSerializer, arg4, arg5.ToJVMArray<Java.Lang.String, string>());
            return new Topology(top, _factory);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/Topology.html#addSink-java.lang.String-java.lang.String-org.apache.kafka.streams.processor.StreamPartitioner-java.lang.String[]-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="string"/></param>
        /// <param name="arg2"><see cref="StreamPartitioner{TKey, TValue}"/></param>
        /// <param name="arg3"><see cref="string"/></param>
        /// <typeparam name="Arg2objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="Arg2objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <returns><see cref="Topology"/></returns>
        public Topology AddSink<Arg2objectSuperK, K, Arg2objectSuperV, V>(string arg0, string arg1, StreamPartitioner<Arg2objectSuperK, Arg2objectSuperV> arg2, params string[] arg3) where Arg2objectSuperK : K where Arg2objectSuperV : V
        {
            if (arg2 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            var top = (arg3.Length == 0) ? _topology.IExecute<Org.Apache.Kafka.Streams.Topology>("addSink", arg0, arg1, arg2) : _topology.IExecute<Org.Apache.Kafka.Streams.Topology>("addSource", arg0, arg1, arg2, arg3);
            return new Topology(top, _factory);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/Topology.html#addSink-java.lang.String-org.apache.kafka.streams.processor.TopicNameExtractor-java.lang.String[]-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="TopicNameExtractor{TKey, TValue}"/></param>
        /// <param name="arg2"><see cref="string"/></param>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <returns><see cref="Topology"/></returns>
        public Topology AddSink<K, V>(string arg0, TopicNameExtractor<K, V> arg1, params string[] arg2)
        {
            if (arg1 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            var top = _topology.AddSink(arg0, arg1, arg2.ToJVMArray<Java.Lang.String, string>());
            return new Topology(top, _factory);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/Topology.html#addSink-java.lang.String-org.apache.kafka.streams.processor.TopicNameExtractor-org.apache.kafka.common.serialization.Serializer-org.apache.kafka.common.serialization.Serializer-java.lang.String[]-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="TopicNameExtractor{TKey, TValue}"/></param>
        /// <param name="arg2"><see cref="ISerializer{T, TJVMT}"/></param>
        /// <param name="arg3"><see cref="ISerializer{T, TJVMT}"/></param>
        /// <param name="arg4"><see cref="string"/></param>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <returns><see cref="Topology"/></returns>
        public Topology AddSink<K, V>(string arg0, TopicNameExtractor<K, V> arg1, ISerializer<K, byte[]> arg2, ISerializer<V, byte[]> arg3, params string[] arg4)
        {
            if (arg1 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            var top = _topology.AddSink(arg0, arg1, arg2.KafkaSerializer, arg3.KafkaSerializer, arg4.ToJVMArray<Java.Lang.String, string>());
            return new Topology(top, _factory);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/Topology.html#addSink-java.lang.String-org.apache.kafka.streams.processor.TopicNameExtractor-org.apache.kafka.common.serialization.Serializer-org.apache.kafka.common.serialization.Serializer-org.apache.kafka.streams.processor.StreamPartitioner-java.lang.String[]-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="TopicNameExtractor{TKey, TValue}"/></param>
        /// <param name="arg2"><see cref="ISerializer{T, TJVMT}"/></param>
        /// <param name="arg3"><see cref="ISerializer{T, TJVMT}"/></param>
        /// <param name="arg4"><see cref="StreamPartitioner{TKey, TValue}"/></param>
        /// <param name="arg5"><see cref="string"/></param>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <typeparam name="Arg4objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg4objectSuperV"><typeparamref name="V"/></typeparam>
        /// <returns><see cref="Topology"/></returns>
        public Topology AddSink<K, V, Arg4objectSuperK, Arg4objectSuperV>(string arg0, TopicNameExtractor<K, V> arg1, ISerializer<K, byte[]> arg2, ISerializer<V, byte[]> arg3, StreamPartitioner<Arg4objectSuperK, Arg4objectSuperV> arg4, params string[] arg5) where Arg4objectSuperK : K where Arg4objectSuperV : V
        {
            if (arg1 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            var top = _topology.AddSink(arg0, arg1, arg2.KafkaSerializer, arg3.KafkaSerializer, arg4, arg5.ToJVMArray<Java.Lang.String, string>());
            return new Topology(top, _factory);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/Topology.html#addSink-java.lang.String-org.apache.kafka.streams.processor.TopicNameExtractor-org.apache.kafka.streams.processor.StreamPartitioner-java.lang.String[]-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="TopicNameExtractor{TKey, TValue}"/></param>
        /// <param name="arg2"><see cref="StreamPartitioner{TKey, TValue}"/></param>
        /// <param name="arg3"><see cref="string"/></param>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <typeparam name="Arg2objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg2objectSuperV"><typeparamref name="V"/></typeparam>
        /// <returns><see cref="Topology"/></returns>
        public Topology AddSink<K, V, Arg2objectSuperK, Arg2objectSuperV>(string arg0, TopicNameExtractor<K, V> arg1, StreamPartitioner<Arg2objectSuperK, Arg2objectSuperV> arg2, params string[] arg3) where Arg2objectSuperK : K where Arg2objectSuperV : V
        {
            if (arg1 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            if (arg2 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            var top = _topology.AddSink(arg0, arg1, arg2, arg3.ToJVMArray<Java.Lang.String, string>());
            return new Topology(top, _factory);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/Topology.html#addSink-java.lang.String-java.lang.String-java.lang.String[]-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="string"/></param>
        /// <param name="arg2"><see cref="string"/></param>
        /// <returns><see cref="Topology"/></returns>
        public Topology AddSink(string arg0, string arg1, params string[] arg2)
        {
            var top = _topology.AddSink(arg0, arg1, arg2.ToJVMArray<Java.Lang.String, string>());
            return new Topology(top, _factory);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/Topology.html#addSource-java.lang.String-java.lang.String[]-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="string"/></param>
        /// <returns><see cref="Topology"/></returns>
        public Topology AddSource(string arg0, params string[] arg1)
        {
            var top = _topology.AddSource(arg0, arg1.ToJVMArray<Java.Lang.String, string>());
            return new Topology(top, _factory);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/Topology.html#addSource-java.lang.String-java.util.regex.Pattern-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="Java.Util.Regex.Pattern"/></param>
        /// <returns><see cref="Topology"/></returns>
        public Topology AddSource(string arg0, Java.Util.Regex.Pattern arg1)
        {
            var top = _topology.AddSource(arg0, arg1);
            return new Topology(top, _factory);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/Topology.html#addSource-java.lang.String-IKNetDeserializer-IKNetDeserializer-java.lang.String[]-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="IDeserializer{T, TJVMT}"/></param>
        /// <param name="arg2"><see cref="IDeserializer{T, TJVMT}"/></param>
        /// <param name="arg3"><see cref="string"/></param>
        /// <returns><see cref="Topology"/></returns>
        public Topology AddSource(string arg0, IDeserializer<object, byte[]> arg1, IDeserializer<object, byte[]> arg2, params string[] arg3)
        {
            var top = (arg3.Length == 0) ? _topology.IExecute<Org.Apache.Kafka.Streams.Topology>("addSource", arg0, arg1.KafkaDeserializer, arg2.KafkaDeserializer) : _topology.IExecute<Org.Apache.Kafka.Streams.Topology>("addSource", arg0, arg1.KafkaDeserializer, arg2.KafkaDeserializer, arg3);
            return new Topology(top, _factory);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/Topology.html#addSource-java.lang.String-IKNetDeserializer-IKNetDeserializer-java.util.regex.Pattern-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="IDeserializer{T, TJVMT}"/></param>
        /// <param name="arg2"><see cref="IDeserializer{T, TJVMT}"/></param>
        /// <param name="arg3"><see cref="Java.Util.Regex.Pattern"/></param>
        /// <returns><see cref="Topology"/></returns>
        public Topology AddSource(string arg0, IDeserializer<object, byte[]> arg1, IDeserializer<object, byte[]> arg2, Java.Util.Regex.Pattern arg3)
        {
            var top = _topology.IExecute<Org.Apache.Kafka.Streams.Topology>("addSource", arg0, arg1.KafkaDeserializer, arg2.KafkaDeserializer, arg3);
            return new Topology(top, _factory);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/Topology.html#addSource-org.apache.kafka.streams.processor.TimestampExtractor-java.lang.String-java.lang.String[]-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Processor.TimestampExtractor"/></param>
        /// <param name="arg1"><see cref="string"/></param>
        /// <param name="arg2"><see cref="string"/></param>
        /// <returns><see cref="Topology"/></returns>
        public Topology AddSource(Org.Apache.Kafka.Streams.Processor.TimestampExtractor arg0, string arg1, params string[] arg2)
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            var top = (arg2.Length == 0) ? _topology.IExecute<Org.Apache.Kafka.Streams.Topology>("addSource", arg0, arg1) : _topology.IExecute<Org.Apache.Kafka.Streams.Topology>("addSource", arg0, arg1, arg2);
            return new Topology(top, _factory);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/Topology.html#addSource-org.apache.kafka.streams.processor.TimestampExtractor-java.lang.String-java.util.regex.Pattern-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Processor.TimestampExtractor"/></param>
        /// <param name="arg1"><see cref="string"/></param>
        /// <param name="arg2"><see cref="Java.Util.Regex.Pattern"/></param>
        /// <returns><see cref="Topology"/></returns>
        public Topology AddSource(Org.Apache.Kafka.Streams.Processor.TimestampExtractor arg0, string arg1, Java.Util.Regex.Pattern arg2)
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            var top = _topology.AddSource(arg0, arg1, arg2);
            return new Topology(top, _factory);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/Topology.html#addSource-Org.Apache.Kafka.Streams.AutoOffsetReset-java.lang.String-java.lang.String[]-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.AutoOffsetReset"/></param>
        /// <param name="arg1"><see cref="string"/></param>
        /// <param name="arg2"><see cref="string"/></param>
        /// <returns><see cref="Topology"/></returns>
        public Topology AddSource(Org.Apache.Kafka.Streams.AutoOffsetReset arg0, string arg1, params string[] arg2)
        {
            var top = _topology.AddSource(arg0, arg1, arg2.ToJVMArray<Java.Lang.String, string>());
            return new Topology(top, _factory);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/Topology.html#addSource-Org.Apache.Kafka.Streams.AutoOffsetReset-java.lang.String-java.util.regex.Pattern-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.AutoOffsetReset"/></param>
        /// <param name="arg1"><see cref="string"/></param>
        /// <param name="arg2"><see cref="Java.Util.Regex.Pattern"/></param>
        /// <returns><see cref="Topology"/></returns>
        public Topology AddSource(Org.Apache.Kafka.Streams.AutoOffsetReset arg0, string arg1, Java.Util.Regex.Pattern arg2)
        {
            var top = _topology.AddSource(arg0, arg1, arg2);
            return new Topology(top, _factory);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/Topology.html#addSource-Org.Apache.Kafka.Streams.AutoOffsetReset-java.lang.String-IKNetDeserializer-IKNetDeserializer-java.lang.String[]-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.AutoOffsetReset"/></param>
        /// <param name="arg1"><see cref="string"/></param>
        /// <param name="arg2"><see cref="IDeserializer{T, TJVMT}"/></param>
        /// <param name="arg3"><see cref="IDeserializer{T, TJVMT}"/></param>
        /// <param name="arg4"><see cref="string"/></param>
        /// <returns><see cref="Topology"/></returns>
        public Topology AddSource(Org.Apache.Kafka.Streams.AutoOffsetReset arg0, string arg1, IDeserializer<object, byte[]> arg2, IDeserializer<object, byte[]> arg3, params string[] arg4)
        {
            var top = (arg4.Length == 0) ? _topology.IExecute<Org.Apache.Kafka.Streams.Topology>("addSource", arg0, arg1, arg2.KafkaDeserializer, arg3.KafkaDeserializer) : _topology.IExecute<Org.Apache.Kafka.Streams.Topology>("addSource", arg0, arg1, arg2.KafkaDeserializer, arg3.KafkaDeserializer, arg4);
            return new Topology(top, _factory);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/Topology.html#addSource-Org.Apache.Kafka.Streams.AutoOffsetReset-java.lang.String-IKNetDeserializer-IKNetDeserializer-java.util.regex.Pattern-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.AutoOffsetReset"/></param>
        /// <param name="arg1"><see cref="string"/></param>
        /// <param name="arg2"><see cref="IDeserializer{T, TJVMT}"/></param>
        /// <param name="arg3"><see cref="IDeserializer{T, TJVMT}"/></param>
        /// <param name="arg4"><see cref="Java.Util.Regex.Pattern"/></param>
        /// <returns><see cref="Topology"/></returns>
        public Topology AddSource(Org.Apache.Kafka.Streams.AutoOffsetReset arg0, string arg1, IDeserializer<object, byte[]> arg2, IDeserializer<object, byte[]> arg3, Java.Util.Regex.Pattern arg4)
        {
            var top = _topology.IExecute<Org.Apache.Kafka.Streams.Topology>("addSource", arg0, arg1, arg2.KafkaDeserializer, arg3.KafkaDeserializer, arg4);
            return new Topology(top, _factory);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/Topology.html#addSource-Org.Apache.Kafka.Streams.AutoOffsetReset-java.lang.String-org.apache.kafka.streams.processor.TimestampExtractor-IKNetDeserializer-IKNetDeserializer-java.lang.String[]-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.AutoOffsetReset"/></param>
        /// <param name="arg1"><see cref="string"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Processor.TimestampExtractor"/></param>
        /// <param name="arg3"><see cref="IDeserializer{T, TJVMT}"/></param>
        /// <param name="arg4"><see cref="IDeserializer{T, TJVMT}"/></param>
        /// <param name="arg5"><see cref="string"/></param>
        /// <returns><see cref="Topology"/></returns>
        public Topology AddSource(Org.Apache.Kafka.Streams.AutoOffsetReset arg0, string arg1, Org.Apache.Kafka.Streams.Processor.TimestampExtractor arg2, IDeserializer<object, byte[]> arg3, IDeserializer<object, byte[]> arg4, params string[] arg5)
        {
            if (arg2 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            var top = (arg5.Length == 0) ? _topology.IExecute<Org.Apache.Kafka.Streams.Topology>("addSource", arg0, arg1, arg2, arg3.KafkaDeserializer, arg4.KafkaDeserializer) : _topology.IExecute<Org.Apache.Kafka.Streams.Topology>("addSource", arg0, arg1, arg2, arg3.KafkaDeserializer, arg4.KafkaDeserializer, arg5);
            return new Topology(top, _factory);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/Topology.html#addSource-Org.Apache.Kafka.Streams.AutoOffsetReset-java.lang.String-org.apache.kafka.streams.processor.TimestampExtractor-IKNetDeserializer-IKNetDeserializer-java.util.regex.Pattern-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.AutoOffsetReset"/></param>
        /// <param name="arg1"><see cref="string"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Processor.TimestampExtractor"/></param>
        /// <param name="arg3"><see cref="IDeserializer{T, TJVMT}"/></param>
        /// <param name="arg4"><see cref="IDeserializer{T, TJVMT}"/></param>
        /// <param name="arg5"><see cref="Java.Util.Regex.Pattern"/></param>
        /// <returns><see cref="Topology"/></returns>
        public Topology AddSource(Org.Apache.Kafka.Streams.AutoOffsetReset arg0, string arg1, Org.Apache.Kafka.Streams.Processor.TimestampExtractor arg2, IDeserializer<object, byte[]> arg3, IDeserializer<object, byte[]> arg4, Java.Util.Regex.Pattern arg5)
        {
            if (arg2 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            var top = _topology.IExecute<Org.Apache.Kafka.Streams.Topology>("addSource", arg0, arg1, arg2, arg3.KafkaDeserializer, arg4.KafkaDeserializer, arg5);
            return new Topology(top, _factory);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/Topology.html#addSource-Org.Apache.Kafka.Streams.AutoOffsetReset-org.apache.kafka.streams.processor.TimestampExtractor-java.lang.String-java.lang.String[]-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.AutoOffsetReset"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Processor.TimestampExtractor"/></param>
        /// <param name="arg2"><see cref="string"/></param>
        /// <param name="arg3"><see cref="string"/></param>
        /// <returns><see cref="Topology"/></returns>
        public Topology AddSource(Org.Apache.Kafka.Streams.AutoOffsetReset arg0, Org.Apache.Kafka.Streams.Processor.TimestampExtractor arg1, string arg2, params string[] arg3)
        {
            if (arg1 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            var top = _topology.AddSource(arg0, arg1, arg2, arg3.ToJVMArray<Java.Lang.String, string>());
            return new Topology(top, _factory);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/Topology.html#addSource-Org.Apache.Kafka.Streams.AutoOffsetReset-org.apache.kafka.streams.processor.TimestampExtractor-java.lang.String-java.util.regex.Pattern-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.AutoOffsetReset"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Processor.TimestampExtractor"/></param>
        /// <param name="arg2"><see cref="string"/></param>
        /// <param name="arg3"><see cref="Java.Util.Regex.Pattern"/></param>
        /// <returns><see cref="Topology"/></returns>
        public Topology AddSource(Org.Apache.Kafka.Streams.AutoOffsetReset arg0, Org.Apache.Kafka.Streams.Processor.TimestampExtractor arg1, string arg2, Java.Util.Regex.Pattern arg3)
        {
            if (arg1 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            var top = _topology.AddSource(arg0, arg1, arg2, arg3);
            return new Topology(top, _factory);
        }

        #endregion
    }
}
