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

using MASES.JCOBridge.C2JBridge;
using MASES.JCOBridge.C2JBridge.JVMInterop;

namespace MASES.KNet.Serialization
{
    /// <summary>
    /// KNet specific class for org.mases.knet.developed.common.serialization.ByteBufferDeserializer
    /// </summary>
    public class ByteBufferDeserializer : JVMBridgeBase<ByteBufferDeserializer>
    {
        /// <inheritdoc/>
        public override string BridgeClassName => "org.mases.knet.developed.common.serialization.ByteBufferDeserializer";
    }

    /// <summary>
    /// KNet specific class for org.mases.knet.developed.common.serialization.ByteBufferSerializer
    /// </summary>
    public class ByteBufferSerializer : JVMBridgeBase<ByteBufferSerializer>
    {
        /// <inheritdoc/>
        public override string BridgeClassName => "org.mases.knet.developed.common.serialization.ByteBufferSerializer";
    }

    /// <summary>
    /// KNet specific class for org.mases.knet.developed.common.serialization.Serdes
    /// </summary>
    public class Serdes : JVMBridgeBase<Serdes>
    {
        /// <inheritdoc/>
        public override string BridgeClassName => "org.mases.knet.developed.common.serialization.Serdes";
        /// <summary>
        /// Returns <see cref="Org.Apache.Kafka.Common.Serialization.Serde{T}"/> of <see cref="Java.Nio.ByteBuffer"/>
        /// </summary>
        /// <returns><see cref="Org.Apache.Kafka.Common.Serialization.Serde{T}"/> of <see cref="Java.Nio.ByteBuffer"/></returns>
        public static Org.Apache.Kafka.Common.Serialization.Serde<Java.Nio.ByteBuffer> ByteBuffer()
        {
            return SExecuteWithSignature<Org.Apache.Kafka.Common.Serialization.Serde<Java.Nio.ByteBuffer>>("ByteBuffer", "()Lorg/apache/kafka/common/serialization/Serde;");
        }

        #region ByteBufferSerde
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/serialization/Serdes.ByteBufferSerde.html"/>
        /// </summary>
        public partial class ByteBufferSerde : Org.Apache.Kafka.Common.Serialization.Serdes.WrapperSerde<Java.Nio.ByteBuffer>
        {
            const string _bridgeClassName = "org.mases.knet.developed.common.serialization.Serdes$ByteBufferSerde";
            /// <summary>
            /// Default constructor: even if the corresponding Java class does not have one, it is mandatory for JCOBridge
            /// </summary>
            public ByteBufferSerde() { }
            /// <summary>
            /// Generic constructor: it is useful for JCOBridge when there is a derived class which needs to pass arguments to the highest JVMBridgeBase class
            /// </summary>
            public ByteBufferSerde(params object[] args) : base(args) { }

            private static readonly IJavaType LocalBridgeClazz = ClazzOf(_bridgeClassName);

            /// <summary>
            /// <see href="https://www.jcobridge.com/api-clr/html/P_MASES_JCOBridge_C2JBridge_JVMBridgeBase_BridgeClassName.htm"/>
            /// </summary>
            public override string BridgeClassName => _bridgeClassName;
            /// <summary>
            /// <see href="https://www.jcobridge.com/api-clr/html/P_MASES_JCOBridge_C2JBridge_JVMBridgeBase_IsBridgeAbstract.htm"/>
            /// </summary>
            public override bool IsBridgeAbstract => false;
            /// <summary>
            /// <see href="https://www.jcobridge.com/api-clr/html/P_MASES_JCOBridge_C2JBridge_JVMBridgeBase_IsBridgeCloseable.htm"/>
            /// </summary>
            public override bool IsBridgeCloseable => false;
            /// <summary>
            /// <see href="https://www.jcobridge.com/api-clr/html/P_MASES_JCOBridge_C2JBridge_JVMBridgeBase_IsBridgeInterface.htm"/>
            /// </summary>
            public override bool IsBridgeInterface => false;
            /// <summary>
            /// <see href="https://www.jcobridge.com/api-clr/html/P_MASES_JCOBridge_C2JBridge_JVMBridgeBase_IsBridgeStatic.htm"/>
            /// </summary>
            public override bool IsBridgeStatic => true;

            // TODO: complete the class

        }
        #endregion
    }
}
