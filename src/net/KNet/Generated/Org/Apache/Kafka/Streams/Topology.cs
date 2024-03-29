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

/*
*  This file is generated by MASES.JNetReflector (ver. 2.4.0.0)
*  using kafka-streams-3.6.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Streams
{
    #region Topology
    public partial class Topology
    {
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/Topology.html#org.apache.kafka.streams.Topology(org.apache.kafka.streams.TopologyConfig)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.TopologyConfig"/></param>
        public Topology(Org.Apache.Kafka.Streams.TopologyConfig arg0)
            : base(arg0)
        {
        }

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields

        #endregion

        #region Static methods

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/Topology.html#addSink-java.lang.String-java.lang.String-org.apache.kafka.common.serialization.Serializer-org.apache.kafka.common.serialization.Serializer-java.lang.String[]-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.String"/></param>
        /// <param name="arg1"><see cref="Java.Lang.String"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Common.Serialization.Serializer"/></param>
        /// <param name="arg3"><see cref="Org.Apache.Kafka.Common.Serialization.Serializer"/></param>
        /// <param name="arg4"><see cref="Java.Lang.String"/></param>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Topology"/></returns>
        public Org.Apache.Kafka.Streams.Topology AddSink<K, V>(Java.Lang.String arg0, Java.Lang.String arg1, Org.Apache.Kafka.Common.Serialization.Serializer<K> arg2, Org.Apache.Kafka.Common.Serialization.Serializer<V> arg3, params Java.Lang.String[] arg4)
        {
            if (arg4.Length == 0) return IExecute<Org.Apache.Kafka.Streams.Topology>("addSink", arg0, arg1, arg2, arg3); else return IExecute<Org.Apache.Kafka.Streams.Topology>("addSink", arg0, arg1, arg2, arg3, arg4);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/Topology.html#addSink-java.lang.String-java.lang.String-org.apache.kafka.common.serialization.Serializer-org.apache.kafka.common.serialization.Serializer-org.apache.kafka.streams.processor.StreamPartitioner-java.lang.String[]-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.String"/></param>
        /// <param name="arg1"><see cref="Java.Lang.String"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Common.Serialization.Serializer"/></param>
        /// <param name="arg3"><see cref="Org.Apache.Kafka.Common.Serialization.Serializer"/></param>
        /// <param name="arg4"><see cref="Org.Apache.Kafka.Streams.Processor.StreamPartitioner"/></param>
        /// <param name="arg5"><see cref="Java.Lang.String"/></param>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <typeparam name="Arg4objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg4objectSuperV"><typeparamref name="V"/></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Topology"/></returns>
        public Org.Apache.Kafka.Streams.Topology AddSink<K, V, Arg4objectSuperK, Arg4objectSuperV>(Java.Lang.String arg0, Java.Lang.String arg1, Org.Apache.Kafka.Common.Serialization.Serializer<K> arg2, Org.Apache.Kafka.Common.Serialization.Serializer<V> arg3, Org.Apache.Kafka.Streams.Processor.StreamPartitioner<Arg4objectSuperK, Arg4objectSuperV> arg4, params Java.Lang.String[] arg5) where Arg4objectSuperK: K where Arg4objectSuperV: V
        {
            if (arg5.Length == 0) return IExecute<Org.Apache.Kafka.Streams.Topology>("addSink", arg0, arg1, arg2, arg3, arg4); else return IExecute<Org.Apache.Kafka.Streams.Topology>("addSink", arg0, arg1, arg2, arg3, arg4, arg5);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/Topology.html#addSink-java.lang.String-java.lang.String-org.apache.kafka.streams.processor.StreamPartitioner-java.lang.String[]-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.String"/></param>
        /// <param name="arg1"><see cref="Java.Lang.String"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Processor.StreamPartitioner"/></param>
        /// <param name="arg3"><see cref="Java.Lang.String"/></param>
        /// <typeparam name="Arg2objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="Arg2objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Topology"/></returns>
        public Org.Apache.Kafka.Streams.Topology AddSink<Arg2objectSuperK, K, Arg2objectSuperV, V>(Java.Lang.String arg0, Java.Lang.String arg1, Org.Apache.Kafka.Streams.Processor.StreamPartitioner<Arg2objectSuperK, Arg2objectSuperV> arg2, params Java.Lang.String[] arg3) where Arg2objectSuperK: K where Arg2objectSuperV: V
        {
            if (arg3.Length == 0) return IExecute<Org.Apache.Kafka.Streams.Topology>("addSink", arg0, arg1, arg2); else return IExecute<Org.Apache.Kafka.Streams.Topology>("addSink", arg0, arg1, arg2, arg3);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/Topology.html#addSink-java.lang.String-org.apache.kafka.streams.processor.TopicNameExtractor-java.lang.String[]-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.String"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Processor.TopicNameExtractor"/></param>
        /// <param name="arg2"><see cref="Java.Lang.String"/></param>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Topology"/></returns>
        public Org.Apache.Kafka.Streams.Topology AddSink<K, V>(Java.Lang.String arg0, Org.Apache.Kafka.Streams.Processor.TopicNameExtractor<K, V> arg1, params Java.Lang.String[] arg2)
        {
            if (arg2.Length == 0) return IExecute<Org.Apache.Kafka.Streams.Topology>("addSink", arg0, arg1); else return IExecute<Org.Apache.Kafka.Streams.Topology>("addSink", arg0, arg1, arg2);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/Topology.html#addSink-java.lang.String-org.apache.kafka.streams.processor.TopicNameExtractor-org.apache.kafka.common.serialization.Serializer-org.apache.kafka.common.serialization.Serializer-java.lang.String[]-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.String"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Processor.TopicNameExtractor"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Common.Serialization.Serializer"/></param>
        /// <param name="arg3"><see cref="Org.Apache.Kafka.Common.Serialization.Serializer"/></param>
        /// <param name="arg4"><see cref="Java.Lang.String"/></param>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Topology"/></returns>
        public Org.Apache.Kafka.Streams.Topology AddSink<K, V>(Java.Lang.String arg0, Org.Apache.Kafka.Streams.Processor.TopicNameExtractor<K, V> arg1, Org.Apache.Kafka.Common.Serialization.Serializer<K> arg2, Org.Apache.Kafka.Common.Serialization.Serializer<V> arg3, params Java.Lang.String[] arg4)
        {
            if (arg4.Length == 0) return IExecute<Org.Apache.Kafka.Streams.Topology>("addSink", arg0, arg1, arg2, arg3); else return IExecute<Org.Apache.Kafka.Streams.Topology>("addSink", arg0, arg1, arg2, arg3, arg4);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/Topology.html#addSink-java.lang.String-org.apache.kafka.streams.processor.TopicNameExtractor-org.apache.kafka.common.serialization.Serializer-org.apache.kafka.common.serialization.Serializer-org.apache.kafka.streams.processor.StreamPartitioner-java.lang.String[]-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.String"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Processor.TopicNameExtractor"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Common.Serialization.Serializer"/></param>
        /// <param name="arg3"><see cref="Org.Apache.Kafka.Common.Serialization.Serializer"/></param>
        /// <param name="arg4"><see cref="Org.Apache.Kafka.Streams.Processor.StreamPartitioner"/></param>
        /// <param name="arg5"><see cref="Java.Lang.String"/></param>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <typeparam name="Arg4objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg4objectSuperV"><typeparamref name="V"/></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Topology"/></returns>
        public Org.Apache.Kafka.Streams.Topology AddSink<K, V, Arg4objectSuperK, Arg4objectSuperV>(Java.Lang.String arg0, Org.Apache.Kafka.Streams.Processor.TopicNameExtractor<K, V> arg1, Org.Apache.Kafka.Common.Serialization.Serializer<K> arg2, Org.Apache.Kafka.Common.Serialization.Serializer<V> arg3, Org.Apache.Kafka.Streams.Processor.StreamPartitioner<Arg4objectSuperK, Arg4objectSuperV> arg4, params Java.Lang.String[] arg5) where Arg4objectSuperK: K where Arg4objectSuperV: V
        {
            if (arg5.Length == 0) return IExecute<Org.Apache.Kafka.Streams.Topology>("addSink", arg0, arg1, arg2, arg3, arg4); else return IExecute<Org.Apache.Kafka.Streams.Topology>("addSink", arg0, arg1, arg2, arg3, arg4, arg5);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/Topology.html#addSink-java.lang.String-org.apache.kafka.streams.processor.TopicNameExtractor-org.apache.kafka.streams.processor.StreamPartitioner-java.lang.String[]-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.String"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Processor.TopicNameExtractor"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Processor.StreamPartitioner"/></param>
        /// <param name="arg3"><see cref="Java.Lang.String"/></param>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <typeparam name="Arg2objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg2objectSuperV"><typeparamref name="V"/></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Topology"/></returns>
        public Org.Apache.Kafka.Streams.Topology AddSink<K, V, Arg2objectSuperK, Arg2objectSuperV>(Java.Lang.String arg0, Org.Apache.Kafka.Streams.Processor.TopicNameExtractor<K, V> arg1, Org.Apache.Kafka.Streams.Processor.StreamPartitioner<Arg2objectSuperK, Arg2objectSuperV> arg2, params Java.Lang.String[] arg3) where Arg2objectSuperK: K where Arg2objectSuperV: V
        {
            if (arg3.Length == 0) return IExecute<Org.Apache.Kafka.Streams.Topology>("addSink", arg0, arg1, arg2); else return IExecute<Org.Apache.Kafka.Streams.Topology>("addSink", arg0, arg1, arg2, arg3);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/Topology.html#addSink-java.lang.String-java.lang.String-java.lang.String[]-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.String"/></param>
        /// <param name="arg1"><see cref="Java.Lang.String"/></param>
        /// <param name="arg2"><see cref="Java.Lang.String"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Topology"/></returns>
        public Org.Apache.Kafka.Streams.Topology AddSink(Java.Lang.String arg0, Java.Lang.String arg1, params Java.Lang.String[] arg2)
        {
            if (arg2.Length == 0) return IExecute<Org.Apache.Kafka.Streams.Topology>("addSink", arg0, arg1); else return IExecute<Org.Apache.Kafka.Streams.Topology>("addSink", arg0, arg1, arg2);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/Topology.html#addSource-java.lang.String-java.lang.String[]-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.String"/></param>
        /// <param name="arg1"><see cref="Java.Lang.String"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Topology"/></returns>
        public Org.Apache.Kafka.Streams.Topology AddSource(Java.Lang.String arg0, params Java.Lang.String[] arg1)
        {
            if (arg1.Length == 0) return IExecute<Org.Apache.Kafka.Streams.Topology>("addSource", arg0); else return IExecute<Org.Apache.Kafka.Streams.Topology>("addSource", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/Topology.html#addSource-java.lang.String-java.util.regex.Pattern-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.String"/></param>
        /// <param name="arg1"><see cref="Java.Util.Regex.Pattern"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Topology"/></returns>
        public Org.Apache.Kafka.Streams.Topology AddSource(Java.Lang.String arg0, Java.Util.Regex.Pattern arg1)
        {
            return IExecute<Org.Apache.Kafka.Streams.Topology>("addSource", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/Topology.html#addSource-java.lang.String-org.apache.kafka.common.serialization.Deserializer-org.apache.kafka.common.serialization.Deserializer-java.lang.String[]-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.String"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Common.Serialization.Deserializer"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Common.Serialization.Deserializer"/></param>
        /// <param name="arg3"><see cref="Java.Lang.String"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Topology"/></returns>
        public Org.Apache.Kafka.Streams.Topology AddSource(Java.Lang.String arg0, Org.Apache.Kafka.Common.Serialization.Deserializer<object> arg1, Org.Apache.Kafka.Common.Serialization.Deserializer<object> arg2, params Java.Lang.String[] arg3)
        {
            if (arg3.Length == 0) return IExecute<Org.Apache.Kafka.Streams.Topology>("addSource", arg0, arg1, arg2); else return IExecute<Org.Apache.Kafka.Streams.Topology>("addSource", arg0, arg1, arg2, arg3);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/Topology.html#addSource-java.lang.String-org.apache.kafka.common.serialization.Deserializer-org.apache.kafka.common.serialization.Deserializer-java.util.regex.Pattern-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.String"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Common.Serialization.Deserializer"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Common.Serialization.Deserializer"/></param>
        /// <param name="arg3"><see cref="Java.Util.Regex.Pattern"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Topology"/></returns>
        public Org.Apache.Kafka.Streams.Topology AddSource(Java.Lang.String arg0, Org.Apache.Kafka.Common.Serialization.Deserializer<object> arg1, Org.Apache.Kafka.Common.Serialization.Deserializer<object> arg2, Java.Util.Regex.Pattern arg3)
        {
            return IExecute<Org.Apache.Kafka.Streams.Topology>("addSource", arg0, arg1, arg2, arg3);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/Topology.html#addSource-org.apache.kafka.streams.processor.TimestampExtractor-java.lang.String-java.lang.String[]-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Processor.TimestampExtractor"/></param>
        /// <param name="arg1"><see cref="Java.Lang.String"/></param>
        /// <param name="arg2"><see cref="Java.Lang.String"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Topology"/></returns>
        public Org.Apache.Kafka.Streams.Topology AddSource(Org.Apache.Kafka.Streams.Processor.TimestampExtractor arg0, Java.Lang.String arg1, params Java.Lang.String[] arg2)
        {
            if (arg2.Length == 0) return IExecute<Org.Apache.Kafka.Streams.Topology>("addSource", arg0, arg1); else return IExecute<Org.Apache.Kafka.Streams.Topology>("addSource", arg0, arg1, arg2);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/Topology.html#addSource-org.apache.kafka.streams.processor.TimestampExtractor-java.lang.String-java.util.regex.Pattern-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Processor.TimestampExtractor"/></param>
        /// <param name="arg1"><see cref="Java.Lang.String"/></param>
        /// <param name="arg2"><see cref="Java.Util.Regex.Pattern"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Topology"/></returns>
        public Org.Apache.Kafka.Streams.Topology AddSource(Org.Apache.Kafka.Streams.Processor.TimestampExtractor arg0, Java.Lang.String arg1, Java.Util.Regex.Pattern arg2)
        {
            return IExecute<Org.Apache.Kafka.Streams.Topology>("addSource", arg0, arg1, arg2);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/Topology.html#addSource-org.apache.kafka.streams.Topology.AutoOffsetReset-java.lang.String-java.lang.String[]-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Topology.AutoOffsetReset"/></param>
        /// <param name="arg1"><see cref="Java.Lang.String"/></param>
        /// <param name="arg2"><see cref="Java.Lang.String"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Topology"/></returns>
        public Org.Apache.Kafka.Streams.Topology AddSource(Org.Apache.Kafka.Streams.Topology.AutoOffsetReset arg0, Java.Lang.String arg1, params Java.Lang.String[] arg2)
        {
            if (arg2.Length == 0) return IExecute<Org.Apache.Kafka.Streams.Topology>("addSource", arg0, arg1); else return IExecute<Org.Apache.Kafka.Streams.Topology>("addSource", arg0, arg1, arg2);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/Topology.html#addSource-org.apache.kafka.streams.Topology.AutoOffsetReset-java.lang.String-java.util.regex.Pattern-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Topology.AutoOffsetReset"/></param>
        /// <param name="arg1"><see cref="Java.Lang.String"/></param>
        /// <param name="arg2"><see cref="Java.Util.Regex.Pattern"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Topology"/></returns>
        public Org.Apache.Kafka.Streams.Topology AddSource(Org.Apache.Kafka.Streams.Topology.AutoOffsetReset arg0, Java.Lang.String arg1, Java.Util.Regex.Pattern arg2)
        {
            return IExecute<Org.Apache.Kafka.Streams.Topology>("addSource", arg0, arg1, arg2);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/Topology.html#addSource-org.apache.kafka.streams.Topology.AutoOffsetReset-java.lang.String-org.apache.kafka.common.serialization.Deserializer-org.apache.kafka.common.serialization.Deserializer-java.lang.String[]-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Topology.AutoOffsetReset"/></param>
        /// <param name="arg1"><see cref="Java.Lang.String"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Common.Serialization.Deserializer"/></param>
        /// <param name="arg3"><see cref="Org.Apache.Kafka.Common.Serialization.Deserializer"/></param>
        /// <param name="arg4"><see cref="Java.Lang.String"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Topology"/></returns>
        public Org.Apache.Kafka.Streams.Topology AddSource(Org.Apache.Kafka.Streams.Topology.AutoOffsetReset arg0, Java.Lang.String arg1, Org.Apache.Kafka.Common.Serialization.Deserializer<object> arg2, Org.Apache.Kafka.Common.Serialization.Deserializer<object> arg3, params Java.Lang.String[] arg4)
        {
            if (arg4.Length == 0) return IExecute<Org.Apache.Kafka.Streams.Topology>("addSource", arg0, arg1, arg2, arg3); else return IExecute<Org.Apache.Kafka.Streams.Topology>("addSource", arg0, arg1, arg2, arg3, arg4);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/Topology.html#addSource-org.apache.kafka.streams.Topology.AutoOffsetReset-java.lang.String-org.apache.kafka.common.serialization.Deserializer-org.apache.kafka.common.serialization.Deserializer-java.util.regex.Pattern-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Topology.AutoOffsetReset"/></param>
        /// <param name="arg1"><see cref="Java.Lang.String"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Common.Serialization.Deserializer"/></param>
        /// <param name="arg3"><see cref="Org.Apache.Kafka.Common.Serialization.Deserializer"/></param>
        /// <param name="arg4"><see cref="Java.Util.Regex.Pattern"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Topology"/></returns>
        public Org.Apache.Kafka.Streams.Topology AddSource(Org.Apache.Kafka.Streams.Topology.AutoOffsetReset arg0, Java.Lang.String arg1, Org.Apache.Kafka.Common.Serialization.Deserializer<object> arg2, Org.Apache.Kafka.Common.Serialization.Deserializer<object> arg3, Java.Util.Regex.Pattern arg4)
        {
            return IExecute<Org.Apache.Kafka.Streams.Topology>("addSource", arg0, arg1, arg2, arg3, arg4);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/Topology.html#addSource-org.apache.kafka.streams.Topology.AutoOffsetReset-java.lang.String-org.apache.kafka.streams.processor.TimestampExtractor-org.apache.kafka.common.serialization.Deserializer-org.apache.kafka.common.serialization.Deserializer-java.lang.String[]-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Topology.AutoOffsetReset"/></param>
        /// <param name="arg1"><see cref="Java.Lang.String"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Processor.TimestampExtractor"/></param>
        /// <param name="arg3"><see cref="Org.Apache.Kafka.Common.Serialization.Deserializer"/></param>
        /// <param name="arg4"><see cref="Org.Apache.Kafka.Common.Serialization.Deserializer"/></param>
        /// <param name="arg5"><see cref="Java.Lang.String"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Topology"/></returns>
        public Org.Apache.Kafka.Streams.Topology AddSource(Org.Apache.Kafka.Streams.Topology.AutoOffsetReset arg0, Java.Lang.String arg1, Org.Apache.Kafka.Streams.Processor.TimestampExtractor arg2, Org.Apache.Kafka.Common.Serialization.Deserializer<object> arg3, Org.Apache.Kafka.Common.Serialization.Deserializer<object> arg4, params Java.Lang.String[] arg5)
        {
            if (arg5.Length == 0) return IExecute<Org.Apache.Kafka.Streams.Topology>("addSource", arg0, arg1, arg2, arg3, arg4); else return IExecute<Org.Apache.Kafka.Streams.Topology>("addSource", arg0, arg1, arg2, arg3, arg4, arg5);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/Topology.html#addSource-org.apache.kafka.streams.Topology.AutoOffsetReset-java.lang.String-org.apache.kafka.streams.processor.TimestampExtractor-org.apache.kafka.common.serialization.Deserializer-org.apache.kafka.common.serialization.Deserializer-java.util.regex.Pattern-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Topology.AutoOffsetReset"/></param>
        /// <param name="arg1"><see cref="Java.Lang.String"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Processor.TimestampExtractor"/></param>
        /// <param name="arg3"><see cref="Org.Apache.Kafka.Common.Serialization.Deserializer"/></param>
        /// <param name="arg4"><see cref="Org.Apache.Kafka.Common.Serialization.Deserializer"/></param>
        /// <param name="arg5"><see cref="Java.Util.Regex.Pattern"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Topology"/></returns>
        public Org.Apache.Kafka.Streams.Topology AddSource(Org.Apache.Kafka.Streams.Topology.AutoOffsetReset arg0, Java.Lang.String arg1, Org.Apache.Kafka.Streams.Processor.TimestampExtractor arg2, Org.Apache.Kafka.Common.Serialization.Deserializer<object> arg3, Org.Apache.Kafka.Common.Serialization.Deserializer<object> arg4, Java.Util.Regex.Pattern arg5)
        {
            return IExecute<Org.Apache.Kafka.Streams.Topology>("addSource", arg0, arg1, arg2, arg3, arg4, arg5);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/Topology.html#addSource-org.apache.kafka.streams.Topology.AutoOffsetReset-org.apache.kafka.streams.processor.TimestampExtractor-java.lang.String-java.lang.String[]-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Topology.AutoOffsetReset"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Processor.TimestampExtractor"/></param>
        /// <param name="arg2"><see cref="Java.Lang.String"/></param>
        /// <param name="arg3"><see cref="Java.Lang.String"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Topology"/></returns>
        public Org.Apache.Kafka.Streams.Topology AddSource(Org.Apache.Kafka.Streams.Topology.AutoOffsetReset arg0, Org.Apache.Kafka.Streams.Processor.TimestampExtractor arg1, Java.Lang.String arg2, params Java.Lang.String[] arg3)
        {
            if (arg3.Length == 0) return IExecute<Org.Apache.Kafka.Streams.Topology>("addSource", arg0, arg1, arg2); else return IExecute<Org.Apache.Kafka.Streams.Topology>("addSource", arg0, arg1, arg2, arg3);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/Topology.html#addSource-org.apache.kafka.streams.Topology.AutoOffsetReset-org.apache.kafka.streams.processor.TimestampExtractor-java.lang.String-java.util.regex.Pattern-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Topology.AutoOffsetReset"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Processor.TimestampExtractor"/></param>
        /// <param name="arg2"><see cref="Java.Lang.String"/></param>
        /// <param name="arg3"><see cref="Java.Util.Regex.Pattern"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Topology"/></returns>
        public Org.Apache.Kafka.Streams.Topology AddSource(Org.Apache.Kafka.Streams.Topology.AutoOffsetReset arg0, Org.Apache.Kafka.Streams.Processor.TimestampExtractor arg1, Java.Lang.String arg2, Java.Util.Regex.Pattern arg3)
        {
            return IExecute<Org.Apache.Kafka.Streams.Topology>("addSource", arg0, arg1, arg2, arg3);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/Topology.html#addStateStore-org.apache.kafka.streams.state.StoreBuilder-java.lang.String[]-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.State.StoreBuilder"/></param>
        /// <param name="arg1"><see cref="Java.Lang.String"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Topology"/></returns>
        public Org.Apache.Kafka.Streams.Topology AddStateStore(Org.Apache.Kafka.Streams.State.StoreBuilder arg0, params Java.Lang.String[] arg1)
        {
            if (arg1.Length == 0) return IExecute<Org.Apache.Kafka.Streams.Topology>("addStateStore", arg0); else return IExecute<Org.Apache.Kafka.Streams.Topology>("addStateStore", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/Topology.html#connectProcessorAndStateStores-java.lang.String-java.lang.String[]-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.String"/></param>
        /// <param name="arg1"><see cref="Java.Lang.String"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Topology"/></returns>
        public Org.Apache.Kafka.Streams.Topology ConnectProcessorAndStateStores(Java.Lang.String arg0, params Java.Lang.String[] arg1)
        {
            if (arg1.Length == 0) return IExecute<Org.Apache.Kafka.Streams.Topology>("connectProcessorAndStateStores", arg0); else return IExecute<Org.Apache.Kafka.Streams.Topology>("connectProcessorAndStateStores", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/Topology.html#describe--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Streams.TopologyDescription"/></returns>
        public Org.Apache.Kafka.Streams.TopologyDescription Describe()
        {
            return IExecuteWithSignature<Org.Apache.Kafka.Streams.TopologyDescription>("describe", "()Lorg/apache/kafka/streams/TopologyDescription;");
        }

        #endregion

        #region Nested classes
        #region AutoOffsetReset
        public partial class AutoOffsetReset
        {
            #region Constructors

            #endregion

            #region Class/Interface conversion operators

            #endregion

            #region Fields
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/Topology.AutoOffsetReset.html#EARLIEST"/>
            /// </summary>
            public static Org.Apache.Kafka.Streams.Topology.AutoOffsetReset EARLIEST { get { if (!_EARLIESTReady) { _EARLIESTContent = SGetField<Org.Apache.Kafka.Streams.Topology.AutoOffsetReset>(LocalBridgeClazz, "EARLIEST"); _EARLIESTReady = true; } return _EARLIESTContent; } }
            private static Org.Apache.Kafka.Streams.Topology.AutoOffsetReset _EARLIESTContent = default;
            private static bool _EARLIESTReady = false; // this is used because in case of generics 
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/Topology.AutoOffsetReset.html#LATEST"/>
            /// </summary>
            public static Org.Apache.Kafka.Streams.Topology.AutoOffsetReset LATEST { get { if (!_LATESTReady) { _LATESTContent = SGetField<Org.Apache.Kafka.Streams.Topology.AutoOffsetReset>(LocalBridgeClazz, "LATEST"); _LATESTReady = true; } return _LATESTContent; } }
            private static Org.Apache.Kafka.Streams.Topology.AutoOffsetReset _LATESTContent = default;
            private static bool _LATESTReady = false; // this is used because in case of generics 

            #endregion

            #region Static methods
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/Topology.AutoOffsetReset.html#valueOf-java.lang.String-"/>
            /// </summary>
            /// <param name="arg0"><see cref="Java.Lang.String"/></param>
            /// <returns><see cref="Org.Apache.Kafka.Streams.Topology.AutoOffsetReset"/></returns>
            public static Org.Apache.Kafka.Streams.Topology.AutoOffsetReset ValueOf(Java.Lang.String arg0)
            {
                return SExecuteWithSignature<Org.Apache.Kafka.Streams.Topology.AutoOffsetReset>(LocalBridgeClazz, "valueOf", "(Ljava/lang/String;)Lorg/apache/kafka/streams/Topology$AutoOffsetReset;", arg0);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/Topology.AutoOffsetReset.html#values--"/>
            /// </summary>

            /// <returns><see cref="Org.Apache.Kafka.Streams.Topology.AutoOffsetReset"/></returns>
            public static Org.Apache.Kafka.Streams.Topology.AutoOffsetReset[] Values()
            {
                return SExecuteWithSignatureArray<Org.Apache.Kafka.Streams.Topology.AutoOffsetReset>(LocalBridgeClazz, "values", "()[Lorg/apache/kafka/streams/Topology$AutoOffsetReset;");
            }

            #endregion

            #region Instance methods

            #endregion

            #region Nested classes

            #endregion

            // TODO: complete the class
        }
        #endregion

    
        #endregion

        // TODO: complete the class
    }
    #endregion
}