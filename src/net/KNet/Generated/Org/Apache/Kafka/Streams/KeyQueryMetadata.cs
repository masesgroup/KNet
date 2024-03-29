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
    #region KeyQueryMetadata
    public partial class KeyQueryMetadata
    {
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KeyQueryMetadata.html#org.apache.kafka.streams.KeyQueryMetadata(org.apache.kafka.streams.state.HostInfo,java.util.Set,int)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.State.HostInfo"/></param>
        /// <param name="arg1"><see cref="Java.Util.Set"/></param>
        /// <param name="arg2"><see cref="int"/></param>
        public KeyQueryMetadata(Org.Apache.Kafka.Streams.State.HostInfo arg0, Java.Util.Set<Org.Apache.Kafka.Streams.State.HostInfo> arg1, int arg2)
            : base(arg0, arg1, arg2)
        {
        }

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KeyQueryMetadata.html#NOT_AVAILABLE"/>
        /// </summary>
        public static Org.Apache.Kafka.Streams.KeyQueryMetadata NOT_AVAILABLE { get { if (!_NOT_AVAILABLEReady) { _NOT_AVAILABLEContent = SGetField<Org.Apache.Kafka.Streams.KeyQueryMetadata>(LocalBridgeClazz, "NOT_AVAILABLE"); _NOT_AVAILABLEReady = true; } return _NOT_AVAILABLEContent; } }
        private static Org.Apache.Kafka.Streams.KeyQueryMetadata _NOT_AVAILABLEContent = default;
        private static bool _NOT_AVAILABLEReady = false; // this is used because in case of generics 

        #endregion

        #region Static methods

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KeyQueryMetadata.html#partition--"/>
        /// </summary>

        /// <returns><see cref="int"/></returns>
        public int Partition()
        {
            return IExecuteWithSignature<int>("partition", "()I");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KeyQueryMetadata.html#standbyHosts--"/>
        /// </summary>

        /// <returns><see cref="Java.Util.Set"/></returns>
        public Java.Util.Set<Org.Apache.Kafka.Streams.State.HostInfo> StandbyHosts()
        {
            return IExecuteWithSignature<Java.Util.Set<Org.Apache.Kafka.Streams.State.HostInfo>>("standbyHosts", "()Ljava/util/Set;");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KeyQueryMetadata.html#activeHost--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Streams.State.HostInfo"/></returns>
        public Org.Apache.Kafka.Streams.State.HostInfo ActiveHost()
        {
            return IExecuteWithSignature<Org.Apache.Kafka.Streams.State.HostInfo>("activeHost", "()Lorg/apache/kafka/streams/state/HostInfo;");
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}