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

using MASES.KNet.Streams;
using Org.Apache.Kafka.Streams;

namespace MASES.KNet.Specific.Streams
{
    /// <summary>
    /// KNet implementation of <see cref="TopologyConfig"/>
    /// </summary>
    public class KNetTopologyConfig : TopologyConfig
    {
        StreamsConfigBuilder _StreamsConfigBuilder;

        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/TopologyConfig.html#org.apache.kafka.streams.TopologyConfig(java.lang.String,org.apache.kafka.streams.StreamsConfig,java.util.Properties)"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="StreamsConfigBuilder"/></param>
        /// <param name="arg2"><see cref="Java.Util.Properties"/></param>
        public KNetTopologyConfig(string arg0, StreamsConfigBuilder arg1, Java.Util.Properties arg2)
            : base(arg0, arg1, arg2)
        {
            _StreamsConfigBuilder = arg1;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/TopologyConfig.html#org.apache.kafka.streams.TopologyConfig(org.apache.kafka.streams.StreamsConfig)"/>
        /// </summary>
        /// <param name="arg0"><see cref="StreamsConfigBuilder"/></param>
        public KNetTopologyConfig(StreamsConfigBuilder arg0)
            : base(arg0)
        {
            _StreamsConfigBuilder = arg0;
        }
        #endregion
        /// <summary>
        /// <see cref="StreamsConfigBuilder"/> used in initialization
        /// </summary>
        public StreamsConfigBuilder StreamsConfigBuilder => _StreamsConfigBuilder;
    }
}
