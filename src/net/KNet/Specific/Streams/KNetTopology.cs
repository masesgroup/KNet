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
using MASES.KNet.Specific.Streams.Processor;
using Org.Apache.Kafka.Streams;

namespace MASES.KNet.Specific.Streams
{
    /// <summary>
    /// KNet implementation of <see cref="Topology"/>
    /// </summary>
    public class KNetTopology
    {
        Topology _Topology;

        #region Constructors
        /// <inheritdoc/>
        public KNetTopology() { _Topology = new Topology(); }
        /// <summary>
        /// KNet override of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/Topology.html#org.apache.kafka.streams.Topology(org.apache.kafka.streams.TopologyConfig)"/>
        /// </summary>
        /// <param name="arg0"><see cref="KNetTopologyConfig"/></param>
        public KNetTopology(KNetTopologyConfig arg0)
        {
            _Topology = new Topology(arg0);
        }

        KNetTopology(Topology topology)
        {
            _Topology = topology;
        }

        #endregion

        #region Class/Interface conversion operators
        /// <summary>
        /// Converter from <see cref="KNetTopology"/> to <see cref="Topology"/>
        /// </summary>
        public static implicit operator Topology(KNetTopology t) => t._Topology;

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/Topology.html#addSink-java.lang.String-java.lang.String-org.apache.kafka.common.serialization.Serializer-org.apache.kafka.common.serialization.Serializer-java.lang.String[]-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="string"/></param>
        /// <param name="arg2"><see cref="IKNetSerializer{T}"/></param>
        /// <param name="arg3"><see cref="IKNetSerializer{T}"/></param>
        /// <param name="arg4"><see cref="string"/></param>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <returns><see cref="KNetTopology"/></returns>
        public KNetTopology AddSink<K, V>(string arg0, string arg1, IKNetSerializer<K> arg2, IKNetSerializer<V> arg3, params string[] arg4)
        {
            var top = _Topology.AddSink(arg0, arg1, arg2.KafkaSerializer, arg3.KafkaSerializer, arg4);
            return new KNetTopology(top);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/Topology.html#addSink-java.lang.String-java.lang.String-org.apache.kafka.common.serialization.Serializer-org.apache.kafka.common.serialization.Serializer-org.apache.kafka.streams.processor.StreamPartitioner-java.lang.String[]-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="string"/></param>
        /// <param name="arg2"><see cref="IKNetSerializer{T}"/></param>
        /// <param name="arg3"><see cref="IKNetSerializer{T}"/></param>
        /// <param name="arg4"><see cref="KNetStreamPartitioner{TKey, TValue}"/></param>
        /// <param name="arg5"><see cref="string"/></param>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <typeparam name="Arg4objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg4objectSuperV"><typeparamref name="V"/></typeparam>
        /// <returns><see cref="KNetTopology"/></returns>
        public KNetTopology AddSink<K, V, Arg4objectSuperK, Arg4objectSuperV>(string arg0, string arg1, IKNetSerializer<K> arg2, IKNetSerializer<V> arg3, KNetStreamPartitioner<Arg4objectSuperK, Arg4objectSuperV> arg4, params string[] arg5) where Arg4objectSuperK : K where Arg4objectSuperV : V
        {
            var top = _Topology.AddSink(arg0, arg1, arg2.KafkaSerializer, arg3.KafkaSerializer, arg4, arg5);
            return new KNetTopology(top);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/Topology.html#addSink-java.lang.String-java.lang.String-org.apache.kafka.streams.processor.StreamPartitioner-java.lang.String[]-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="string"/></param>
        /// <param name="arg2"><see cref="KNetStreamPartitioner{TKey, TValue}"/></param>
        /// <param name="arg3"><see cref="string"/></param>
        /// <typeparam name="Arg2objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="Arg2objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <returns><see cref="KNetTopology"/></returns>
        public KNetTopology AddSink<Arg2objectSuperK, K, Arg2objectSuperV, V>(string arg0, string arg1, KNetStreamPartitioner<Arg2objectSuperK, Arg2objectSuperV> arg2, params string[] arg3) where Arg2objectSuperK : K where Arg2objectSuperV : V
        {
            var top = (arg3.Length == 0) ? _Topology.IExecute<Topology>("addSink", arg0, arg1, arg2) : _Topology.IExecute<Topology>("addSource", arg0, arg1, arg2, arg3);
            return new KNetTopology(top);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/Topology.html#addSink-java.lang.String-org.apache.kafka.streams.processor.TopicNameExtractor-java.lang.String[]-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="KNetTopicNameExtractor{TKey, TValue}"/></param>
        /// <param name="arg2"><see cref="string"/></param>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <returns><see cref="KNetTopology"/></returns>
        public KNetTopology AddSink<K, V>(string arg0, KNetTopicNameExtractor<K, V> arg1, params string[] arg2)
        {
            var top = _Topology.AddSink(arg0, arg1, arg2);
            return new KNetTopology(top);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/Topology.html#addSink-java.lang.String-org.apache.kafka.streams.processor.TopicNameExtractor-org.apache.kafka.common.serialization.Serializer-org.apache.kafka.common.serialization.Serializer-java.lang.String[]-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="KNetTopicNameExtractor{TKey, TValue}"/></param>
        /// <param name="arg2"><see cref="IKNetSerializer{T}"/></param>
        /// <param name="arg3"><see cref="IKNetSerializer{T}"/></param>
        /// <param name="arg4"><see cref="string"/></param>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <returns><see cref="KNetTopology"/></returns>
        public KNetTopology AddSink<K, V>(string arg0, KNetTopicNameExtractor<K, V> arg1, IKNetSerializer<K> arg2, IKNetSerializer<V> arg3, params string[] arg4)
        {
            var top = _Topology.AddSink(arg0, arg1, arg2.KafkaSerializer, arg3.KafkaSerializer, arg4);
            return new KNetTopology(top);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/Topology.html#addSink-java.lang.String-org.apache.kafka.streams.processor.TopicNameExtractor-org.apache.kafka.common.serialization.Serializer-org.apache.kafka.common.serialization.Serializer-org.apache.kafka.streams.processor.StreamPartitioner-java.lang.String[]-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="KNetTopicNameExtractor{TKey, TValue}"/></param>
        /// <param name="arg2"><see cref="IKNetSerializer{T}"/></param>
        /// <param name="arg3"><see cref="IKNetSerializer{T}"/></param>
        /// <param name="arg4"><see cref="KNetStreamPartitioner{TKey, TValue}"/></param>
        /// <param name="arg5"><see cref="string"/></param>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <typeparam name="Arg4objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg4objectSuperV"><typeparamref name="V"/></typeparam>
        /// <returns><see cref="KNetTopology"/></returns>
        public KNetTopology AddSink<K, V, Arg4objectSuperK, Arg4objectSuperV>(string arg0, KNetTopicNameExtractor<K, V> arg1, IKNetSerializer<K> arg2, IKNetSerializer<V> arg3, KNetStreamPartitioner<Arg4objectSuperK, Arg4objectSuperV> arg4, params string[] arg5) where Arg4objectSuperK : K where Arg4objectSuperV : V
        {
            var top = _Topology.AddSink(arg0, arg1, arg2.KafkaSerializer, arg3.KafkaSerializer, arg4, arg5);
            return new KNetTopology(top);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/Topology.html#addSink-java.lang.String-org.apache.kafka.streams.processor.TopicNameExtractor-org.apache.kafka.streams.processor.StreamPartitioner-java.lang.String[]-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="KNetTopicNameExtractor{TKey, TValue}"/></param>
        /// <param name="arg2"><see cref="KNetStreamPartitioner{TKey, TValue}"/></param>
        /// <param name="arg3"><see cref="string"/></param>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <typeparam name="Arg2objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg2objectSuperV"><typeparamref name="V"/></typeparam>
        /// <returns><see cref="KNetTopology"/></returns>
        public KNetTopology AddSink<K, V, Arg2objectSuperK, Arg2objectSuperV>(string arg0, KNetTopicNameExtractor<K, V> arg1, KNetStreamPartitioner<Arg2objectSuperK, Arg2objectSuperV> arg2, params string[] arg3) where Arg2objectSuperK : K where Arg2objectSuperV : V
        {
            var top = _Topology.AddSink(arg0, arg1, arg2, arg3);
            return new KNetTopology(top);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/Topology.html#addSink-java.lang.String-java.lang.String-java.lang.String[]-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="string"/></param>
        /// <param name="arg2"><see cref="string"/></param>
        /// <returns><see cref="KNetTopology"/></returns>
        public KNetTopology AddSink(string arg0, string arg1, params string[] arg2)
        {
            var top = _Topology.AddSink(arg0, arg1, arg2);
            return new KNetTopology(top);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/Topology.html#addSource-java.lang.String-java.lang.String[]-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="string"/></param>
        /// <returns><see cref="KNetTopology"/></returns>
        public KNetTopology AddSource(string arg0, params string[] arg1)
        {
            var top = _Topology.AddSource(arg0, arg1);
            return new KNetTopology(top);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/Topology.html#addSource-java.lang.String-java.util.regex.Pattern-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="Java.Util.Regex.Pattern"/></param>
        /// <returns><see cref="KNetTopology"/></returns>
        public KNetTopology AddSource(string arg0, Java.Util.Regex.Pattern arg1)
        {
            var top = _Topology.AddSource(arg0, arg1);
            return new KNetTopology(top);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/Topology.html#addSource-java.lang.String-IKNetDeserializer-IKNetDeserializer-java.lang.String[]-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="IKNetDeserializer{T}"/></param>
        /// <param name="arg2"><see cref="IKNetDeserializer{T}"/></param>
        /// <param name="arg3"><see cref="string"/></param>
        /// <returns><see cref="KNetTopology"/></returns>
        public KNetTopology AddSource(string arg0, IKNetDeserializer<object> arg1, IKNetDeserializer<object> arg2, params string[] arg3)
        {
            var top = (arg3.Length == 0) ? _Topology.IExecute<Topology>("addSource", arg0, arg1.KafkaDeserializer, arg2.KafkaDeserializer) : _Topology.IExecute<Topology>("addSource", arg0, arg1.KafkaDeserializer, arg2.KafkaDeserializer, arg3);
            return new KNetTopology(top);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/Topology.html#addSource-java.lang.String-IKNetDeserializer-IKNetDeserializer-java.util.regex.Pattern-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="IKNetDeserializer{T}"/></param>
        /// <param name="arg2"><see cref="IKNetDeserializer{T}"/></param>
        /// <param name="arg3"><see cref="Java.Util.Regex.Pattern"/></param>
        /// <returns><see cref="KNetTopology"/></returns>
        public KNetTopology AddSource(string arg0, IKNetDeserializer<object> arg1, IKNetDeserializer<object> arg2, Java.Util.Regex.Pattern arg3)
        {
            var top = _Topology.IExecute<Topology>("addSource", arg0, arg1.KafkaDeserializer, arg2.KafkaDeserializer, arg3);
            return new KNetTopology(top);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/Topology.html#addSource-org.apache.kafka.streams.processor.TimestampExtractor-java.lang.String-java.lang.String[]-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Processor.TimestampExtractor"/></param>
        /// <param name="arg1"><see cref="string"/></param>
        /// <param name="arg2"><see cref="string"/></param>
        /// <returns><see cref="KNetTopology"/></returns>
        public KNetTopology AddSource(Org.Apache.Kafka.Streams.Processor.TimestampExtractor arg0, string arg1, params string[] arg2)
        {
            var top = (arg2.Length == 0) ? _Topology.IExecute<Topology>("addSource", arg0, arg1) : _Topology.IExecute<Topology>("addSource", arg0, arg1, arg2);
            return new KNetTopology(top);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/Topology.html#addSource-org.apache.kafka.streams.processor.TimestampExtractor-java.lang.String-java.util.regex.Pattern-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Processor.TimestampExtractor"/></param>
        /// <param name="arg1"><see cref="string"/></param>
        /// <param name="arg2"><see cref="Java.Util.Regex.Pattern"/></param>
        /// <returns><see cref="KNetTopology"/></returns>
        public KNetTopology AddSource(Org.Apache.Kafka.Streams.Processor.TimestampExtractor arg0, string arg1, Java.Util.Regex.Pattern arg2)
        {
            var top = _Topology.AddSource(arg0, arg1, arg2);
            return new KNetTopology(top);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/Topology.html#addSource-org.apache.kafka.streams.Topology.AutoOffsetReset-java.lang.String-java.lang.String[]-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Topology.AutoOffsetReset"/></param>
        /// <param name="arg1"><see cref="string"/></param>
        /// <param name="arg2"><see cref="string"/></param>
        /// <returns><see cref="KNetTopology"/></returns>
        public KNetTopology AddSource(Topology.AutoOffsetReset arg0, string arg1, params string[] arg2)
        {
            var top = _Topology.AddSource(arg0, arg1, arg2);
            return new KNetTopology(top);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/Topology.html#addSource-org.apache.kafka.streams.Topology.AutoOffsetReset-java.lang.String-java.util.regex.Pattern-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Topology.AutoOffsetReset"/></param>
        /// <param name="arg1"><see cref="string"/></param>
        /// <param name="arg2"><see cref="Java.Util.Regex.Pattern"/></param>
        /// <returns><see cref="KNetTopology"/></returns>
        public KNetTopology AddSource(Topology.AutoOffsetReset arg0, string arg1, Java.Util.Regex.Pattern arg2)
        {
            var top = _Topology.AddSource(arg0, arg1, arg2);
            return new KNetTopology(top);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/Topology.html#addSource-org.apache.kafka.streams.Topology.AutoOffsetReset-java.lang.String-IKNetDeserializer-IKNetDeserializer-java.lang.String[]-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Topology.AutoOffsetReset"/></param>
        /// <param name="arg1"><see cref="string"/></param>
        /// <param name="arg2"><see cref="IKNetDeserializer{T}"/></param>
        /// <param name="arg3"><see cref="IKNetDeserializer{T}"/></param>
        /// <param name="arg4"><see cref="string"/></param>
        /// <returns><see cref="KNetTopology"/></returns>
        public KNetTopology AddSource(Topology.AutoOffsetReset arg0, string arg1, IKNetDeserializer<object> arg2, IKNetDeserializer<object> arg3, params string[] arg4)
        {
            var top = (arg4.Length == 0) ? _Topology.IExecute<Topology>("addSource", arg0, arg1, arg2.KafkaDeserializer, arg3.KafkaDeserializer) : _Topology.IExecute<Topology>("addSource", arg0, arg1, arg2.KafkaDeserializer, arg3.KafkaDeserializer, arg4);
            return new KNetTopology(top);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/Topology.html#addSource-org.apache.kafka.streams.Topology.AutoOffsetReset-java.lang.String-IKNetDeserializer-IKNetDeserializer-java.util.regex.Pattern-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Topology.AutoOffsetReset"/></param>
        /// <param name="arg1"><see cref="string"/></param>
        /// <param name="arg2"><see cref="IKNetDeserializer{T}"/></param>
        /// <param name="arg3"><see cref="IKNetDeserializer{T}"/></param>
        /// <param name="arg4"><see cref="Java.Util.Regex.Pattern"/></param>
        /// <returns><see cref="KNetTopology"/></returns>
        public KNetTopology AddSource(Topology.AutoOffsetReset arg0, string arg1, IKNetDeserializer<object> arg2, IKNetDeserializer<object> arg3, Java.Util.Regex.Pattern arg4)
        {
            var top = _Topology.IExecute<Topology>("addSource", arg0, arg1, arg2.KafkaDeserializer, arg3.KafkaDeserializer, arg4);
            return new KNetTopology(top);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/Topology.html#addSource-org.apache.kafka.streams.Topology.AutoOffsetReset-java.lang.String-org.apache.kafka.streams.processor.TimestampExtractor-IKNetDeserializer-IKNetDeserializer-java.lang.String[]-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Topology.AutoOffsetReset"/></param>
        /// <param name="arg1"><see cref="string"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Processor.TimestampExtractor"/></param>
        /// <param name="arg3"><see cref="IKNetDeserializer{T}"/></param>
        /// <param name="arg4"><see cref="IKNetDeserializer{T}"/></param>
        /// <param name="arg5"><see cref="string"/></param>
        /// <returns><see cref="KNetTopology"/></returns>
        public KNetTopology AddSource(Topology.AutoOffsetReset arg0, string arg1, Org.Apache.Kafka.Streams.Processor.TimestampExtractor arg2, IKNetDeserializer<object> arg3, IKNetDeserializer<object> arg4, params string[] arg5)
        {
            var top = (arg5.Length == 0) ? _Topology.IExecute<Topology>("addSource", arg0, arg1, arg2, arg3.KafkaDeserializer, arg4.KafkaDeserializer) : _Topology.IExecute<Topology>("addSource", arg0, arg1, arg2, arg3.KafkaDeserializer, arg4.KafkaDeserializer, arg5);
            return new KNetTopology(top);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/Topology.html#addSource-org.apache.kafka.streams.Topology.AutoOffsetReset-java.lang.String-org.apache.kafka.streams.processor.TimestampExtractor-IKNetDeserializer-IKNetDeserializer-java.util.regex.Pattern-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Topology.AutoOffsetReset"/></param>
        /// <param name="arg1"><see cref="string"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Processor.TimestampExtractor"/></param>
        /// <param name="arg3"><see cref="IKNetDeserializer{T}"/></param>
        /// <param name="arg4"><see cref="IKNetDeserializer{T}"/></param>
        /// <param name="arg5"><see cref="Java.Util.Regex.Pattern"/></param>
        /// <returns><see cref="KNetTopology"/></returns>
        public KNetTopology AddSource(Topology.AutoOffsetReset arg0, string arg1, Org.Apache.Kafka.Streams.Processor.TimestampExtractor arg2, IKNetDeserializer<object> arg3, IKNetDeserializer<object> arg4, Java.Util.Regex.Pattern arg5)
        {
            var top = _Topology.IExecute<Topology>("addSource", arg0, arg1, arg2, arg3.KafkaDeserializer, arg4.KafkaDeserializer, arg5);
            return new KNetTopology(top);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/Topology.html#addSource-org.apache.kafka.streams.Topology.AutoOffsetReset-org.apache.kafka.streams.processor.TimestampExtractor-java.lang.String-java.lang.String[]-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Topology.AutoOffsetReset"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Processor.TimestampExtractor"/></param>
        /// <param name="arg2"><see cref="string"/></param>
        /// <param name="arg3"><see cref="string"/></param>
        /// <returns><see cref="KNetTopology"/></returns>
        public KNetTopology AddSource(Topology.AutoOffsetReset arg0, Org.Apache.Kafka.Streams.Processor.TimestampExtractor arg1, string arg2, params string[] arg3)
        {
            var top = _Topology.AddSource(arg0, arg1, arg2, arg3);
            return new KNetTopology(top);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/Topology.html#addSource-org.apache.kafka.streams.Topology.AutoOffsetReset-org.apache.kafka.streams.processor.TimestampExtractor-java.lang.String-java.util.regex.Pattern-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Topology.AutoOffsetReset"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Processor.TimestampExtractor"/></param>
        /// <param name="arg2"><see cref="string"/></param>
        /// <param name="arg3"><see cref="Java.Util.Regex.Pattern"/></param>
        /// <returns><see cref="KNetTopology"/></returns>
        public KNetTopology AddSource(Topology.AutoOffsetReset arg0, Org.Apache.Kafka.Streams.Processor.TimestampExtractor arg1, string arg2, Java.Util.Regex.Pattern arg3)
        {
            var top = _Topology.AddSource(arg0, arg1, arg2, arg3);
            return new KNetTopology(top);
        }

        #endregion
    }
}
