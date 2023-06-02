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

/*
*  This file is generated by MASES.JNetReflector (ver. 1.5.5.0)
*  using kafka-clients-3.4.0.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Common.Protocol
{
    #region MessageUtil
    public partial class MessageUtil
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/protocol/MessageUtil.html#UNSIGNED_SHORT_MAX"/>
        /// </summary>
        public static int UNSIGNED_SHORT_MAX { get { return SGetField<int>(LocalBridgeClazz, "UNSIGNED_SHORT_MAX"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/protocol/MessageUtil.html#UNSIGNED_INT_MAX"/>
        /// </summary>
        public static long UNSIGNED_INT_MAX { get { return SGetField<long>(LocalBridgeClazz, "UNSIGNED_INT_MAX"); } }

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/protocol/MessageUtil.html#compareRawTaggedFields(java.util.List,java.util.List)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.List"/></param>
        /// <param name="arg1"><see cref="Java.Util.List"/></param>
        /// <returns><see cref="bool"/></returns>
        public static bool CompareRawTaggedFields(Java.Util.List<Org.Apache.Kafka.Common.Protocol.Types.RawTaggedField> arg0, Java.Util.List<Org.Apache.Kafka.Common.Protocol.Types.RawTaggedField> arg1)
        {
            return SExecute<bool>(LocalBridgeClazz, "compareRawTaggedFields", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/protocol/MessageUtil.html#byteBufferToArray(java.nio.ByteBuffer)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Nio.ByteBuffer"/></param>
        /// <returns><see cref="byte"/></returns>
        public static byte[] ByteBufferToArray(Java.Nio.ByteBuffer arg0)
        {
            return SExecuteArray<byte>(LocalBridgeClazz, "byteBufferToArray", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/protocol/MessageUtil.html#duplicate(byte[])"/>
        /// </summary>
        /// <param name="arg0"><see cref="byte"/></param>
        /// <returns><see cref="byte"/></returns>
        public static byte[] Duplicate(byte[] arg0)
        {
            return SExecuteArray<byte>(LocalBridgeClazz, "duplicate", new object[] { arg0 });
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/protocol/MessageUtil.html#toVersionPrefixedBytes(short,org.apache.kafka.common.protocol.Message)"/>
        /// </summary>
        /// <param name="arg0"><see cref="short"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Common.Protocol.Message"/></param>
        /// <returns><see cref="byte"/></returns>
        public static byte[] ToVersionPrefixedBytes(short arg0, Org.Apache.Kafka.Common.Protocol.Message arg1)
        {
            return SExecuteArray<byte>(LocalBridgeClazz, "toVersionPrefixedBytes", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/protocol/MessageUtil.html#deepToString(java.util.Iterator)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.Iterator"/></param>
        /// <typeparam name="Arg0Extendsobject"></typeparam>
        /// <returns><see cref="string"/></returns>
        public static string DeepToString<Arg0Extendsobject>(Java.Util.Iterator<Arg0Extendsobject> arg0)
        {
            return SExecute<string>(LocalBridgeClazz, "deepToString", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/protocol/MessageUtil.html#toByteBuffer(org.apache.kafka.common.protocol.Message,short)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Protocol.Message"/></param>
        /// <param name="arg1"><see cref="short"/></param>
        /// <returns><see cref="Java.Nio.ByteBuffer"/></returns>
        public static Java.Nio.ByteBuffer ToByteBuffer(Org.Apache.Kafka.Common.Protocol.Message arg0, short arg1)
        {
            return SExecute<Java.Nio.ByteBuffer>(LocalBridgeClazz, "toByteBuffer", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/protocol/MessageUtil.html#toVersionPrefixedByteBuffer(short,org.apache.kafka.common.protocol.Message)"/>
        /// </summary>
        /// <param name="arg0"><see cref="short"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Common.Protocol.Message"/></param>
        /// <returns><see cref="Java.Nio.ByteBuffer"/></returns>
        public static Java.Nio.ByteBuffer ToVersionPrefixedByteBuffer(short arg0, Org.Apache.Kafka.Common.Protocol.Message arg1)
        {
            return SExecute<Java.Nio.ByteBuffer>(LocalBridgeClazz, "toVersionPrefixedByteBuffer", arg0, arg1);
        }

        #endregion

        #region Instance methods

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}