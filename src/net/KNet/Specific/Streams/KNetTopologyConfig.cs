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
using System;

namespace MASES.KNet.Streams
{
    /// <summary>
    /// KNet implementation of <see cref="Org.Apache.Kafka.Streams.TopologyConfig"/>
    /// </summary>
    public class KNetTopologyConfig : IGenericSerDesFactoryApplier
    {
        readonly Org.Apache.Kafka.Streams.TopologyConfig _inner;
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/TopologyConfig.html#org.apache.kafka.streams.TopologyConfig(java.lang.String,org.apache.kafka.streams.StreamsConfig,java.util.Properties)"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="StreamsConfigBuilder"/></param>
        /// <param name="arg2"><see cref="Java.Util.Properties"/></param>
        public KNetTopologyConfig(string arg0, StreamsConfigBuilder arg1, Java.Util.Properties arg2)
        {
            _inner = new Org.Apache.Kafka.Streams.TopologyConfig(arg0, PrepareProperties(arg1), arg2);
            _factory = arg1;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/TopologyConfig.html#org.apache.kafka.streams.TopologyConfig(org.apache.kafka.streams.StreamsConfig)"/>
        /// </summary>
        /// <param name="arg0"><see cref="StreamsConfigBuilder"/></param>
        public KNetTopologyConfig(StreamsConfigBuilder arg0)
        {
            _inner = new Org.Apache.Kafka.Streams.TopologyConfig(PrepareProperties(arg0));
            _factory = arg0;
        }
        #endregion

        /// <summary>
        /// Converter from <see cref="KNetTopologyConfig"/> to <see cref="Org.Apache.Kafka.Streams.TopologyConfig"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.TopologyConfig(KNetTopologyConfig t) => t._inner;
        /// <summary>
        /// If set, this <see cref="Func{T, TResult}"/> will be called from <see cref="PrepareProperties(StreamsConfigBuilder)"/>
        /// </summary>
        public static Func<Java.Util.Properties, StreamsConfigBuilder> OverrideProperties { get; set; }
        /// <summary>
        /// Override this method to check and modify the <see cref="Java.Util.Properties"/> returned to underlying <see cref="Org.Apache.Kafka.Streams.KafkaStreams"/>
        /// </summary>
        /// <param name="builder"><see cref="StreamsConfigBuilder"/> to use to return <see cref="Java.Util.Properties"/></param>
        /// <returns><see cref="Java.Util.Properties"/> used from underlying <see cref="Org.Apache.Kafka.Streams.KafkaStreams"/></returns>
        protected virtual Java.Util.Properties PrepareProperties(StreamsConfigBuilder builder)
        {
            return OverrideProperties != null ? OverrideProperties(builder) : builder;
        }
    }
}
