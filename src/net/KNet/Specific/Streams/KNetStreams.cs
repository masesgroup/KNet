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
    /// KNet extension of <see cref="KafkaStreams"/>
    /// </summary>
    public class KNetStreams : KafkaStreams
    {
        #region Constructors
        /// <inheritdoc/>
        public KNetStreams() : base() { }
        /// <inheritdoc/>
        public KNetStreams(params object[] args) : base(args) { }
        /// <summary>
        /// KNet override of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#org.apache.kafka.streams.KafkaStreams(KNetTopology,java.util.Properties,org.apache.kafka.common.utils.Time)"/>
        /// </summary>
        /// <param name="arg0"><see cref="KNetTopology"/></param>
        /// <param name="arg1"><see cref="Java.Util.Properties"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Common.Utils.Time"/></param>
        public KNetStreams(KNetTopology arg0, Java.Util.Properties arg1, Org.Apache.Kafka.Common.Utils.Time arg2)
            : base(arg0, arg1, arg2)
        {
        }
        /// <summary>
        /// KNet override of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#org.apache.kafka.streams.KafkaStreams(KNetTopology,java.util.Properties,KNetClientSupplier,org.apache.kafka.common.utils.Time)"/>
        /// </summary>
        /// <param name="arg0"><see cref="KNetTopology"/></param>
        /// <param name="arg1"><see cref="Java.Util.Properties"/></param>
        /// <param name="arg2"><see cref="KNetClientSupplier"/></param>
        /// <param name="arg3"><see cref="Org.Apache.Kafka.Common.Utils.Time"/></param>
        public KNetStreams(KNetTopology arg0, Java.Util.Properties arg1, KNetClientSupplier arg2, Org.Apache.Kafka.Common.Utils.Time arg3)
            : base(arg0, arg1, arg2, arg3)
        {
        }
        /// <summary>
        /// KNet override of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#org.apache.kafka.streams.KafkaStreams(KNetTopology,java.util.Properties,KNetClientSupplier)"/>
        /// </summary>
        /// <param name="arg0"><see cref="KNetTopology"/></param>
        /// <param name="arg1"><see cref="Java.Util.Properties"/></param>
        /// <param name="arg2"><see cref="KNetClientSupplier"/></param>
        public KNetStreams(KNetTopology arg0, Java.Util.Properties arg1, KNetClientSupplier arg2)
            : base(arg0, arg1, arg2)
        {
        }
        /// <summary>
        /// KNet override of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#org.apache.kafka.streams.KafkaStreams(KNetTopology,java.util.Properties)"/>
        /// </summary>
        /// <param name="arg0"><see cref="KNetTopology"/></param>
        /// <param name="arg1"><see cref="Java.Util.Properties"/></param>
        public KNetStreams(KNetTopology arg0, Java.Util.Properties arg1)
            : base(arg0, arg1)
        {
        }
        /// <summary>
        /// KNet override of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#org.apache.kafka.streams.KafkaStreams(KNetTopology,org.apache.kafka.streams.StreamsConfig,org.apache.kafka.common.utils.Time)"/>
        /// </summary>
        /// <param name="arg0"><see cref="KNetTopology"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.StreamsConfig"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Common.Utils.Time"/></param>
        public KNetStreams(KNetTopology arg0, Org.Apache.Kafka.Streams.StreamsConfig arg1, Org.Apache.Kafka.Common.Utils.Time arg2)
            : base(arg0, arg1, arg2)
        {
        }
        /// <summary>
        /// KNet override of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#org.apache.kafka.streams.KafkaStreams(KNetTopology,org.apache.kafka.streams.StreamsConfig,KNetClientSupplier)"/>
        /// </summary>
        /// <param name="arg0"><see cref="KNetTopology"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.StreamsConfig"/></param>
        /// <param name="arg2"><see cref="KNetClientSupplier"/></param>
        public KNetStreams(KNetTopology arg0, Org.Apache.Kafka.Streams.StreamsConfig arg1, KNetClientSupplier arg2)
            : base(arg0, arg1, arg2)
        {
        }
        /// <summary>
        /// KNet override of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#org.apache.kafka.streams.KafkaStreams(KNetTopology,org.apache.kafka.streams.StreamsConfig)"/>
        /// </summary>
        /// <param name="arg0"><see cref="KNetTopology"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.StreamsConfig"/></param>
        public KNetStreams(KNetTopology arg0, Org.Apache.Kafka.Streams.StreamsConfig arg1)
            : base(arg0, arg1)
        {
        }

        #endregion

        #region Instance methods
        /// <summary>
        /// KNet override of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#queryMetadataForKey-java.lang.String-java.lang.Object-org.apache.kafka.common.serialization.Serializer-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><typeparamref name="TKey"/></param>
        /// <param name="arg2"><see cref="IKNetSerializer{T}"/></param>
        /// <typeparam name="TKey"></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.KeyQueryMetadata"/></returns>
        public Org.Apache.Kafka.Streams.KeyQueryMetadata QueryMetadataForKey<TKey>(string arg0, TKey arg1, IKNetSerializer<TKey> arg2)
        {
            return QueryMetadataForKey<byte[]>(arg0, arg2.Serialize(null, arg1), arg2.KafkaSerializer);
        }
        /// <summary>
        /// KNet override of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#queryMetadataForKey-java.lang.String-java.lang.Object-org.apache.kafka.streams.processor.StreamPartitioner-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><typeparamref name="TKey"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Processor.StreamPartitioner"/></param>
        /// <typeparam name="TKey">The key type</typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.KeyQueryMetadata"/></returns>
        public Org.Apache.Kafka.Streams.KeyQueryMetadata QueryMetadataForKey<TKey>(string arg0, TKey arg1, KNetStreamPartitioner<TKey, object> arg2)
        {
            return IExecute<Org.Apache.Kafka.Streams.KeyQueryMetadata>("queryMetadataForKey", arg0, arg2.KeySerializer.Serialize(null, arg1), arg2);
        }

        #endregion
    }
}
