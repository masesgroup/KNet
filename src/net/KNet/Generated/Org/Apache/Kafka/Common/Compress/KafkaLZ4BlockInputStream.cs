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
*  This file is generated by MASES.JNetReflector (ver. 2.0.1.0)
*  using kafka-clients-3.5.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Common.Compress
{
    #region KafkaLZ4BlockInputStream
    public partial class KafkaLZ4BlockInputStream
    {
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/common/compress/KafkaLZ4BlockInputStream.html#org.apache.kafka.common.compress.KafkaLZ4BlockInputStream(java.nio.ByteBuffer,org.apache.kafka.common.utils.BufferSupplier,boolean)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Nio.ByteBuffer"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Common.Utils.BufferSupplier"/></param>
        /// <param name="arg2"><see cref="bool"/></param>
        /// <exception cref="Java.Io.IOException"/>
        public KafkaLZ4BlockInputStream(Java.Nio.ByteBuffer arg0, Org.Apache.Kafka.Common.Utils.BufferSupplier arg1, bool arg2)
            : base(arg0, arg1, arg2)
        {
        }

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/common/compress/KafkaLZ4BlockInputStream.html#BLOCK_HASH_MISMATCH"/>
        /// </summary>
        public static string BLOCK_HASH_MISMATCH { get { return SGetField<string>(LocalBridgeClazz, "BLOCK_HASH_MISMATCH"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/common/compress/KafkaLZ4BlockInputStream.html#DESCRIPTOR_HASH_MISMATCH"/>
        /// </summary>
        public static string DESCRIPTOR_HASH_MISMATCH { get { return SGetField<string>(LocalBridgeClazz, "DESCRIPTOR_HASH_MISMATCH"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/common/compress/KafkaLZ4BlockInputStream.html#NOT_SUPPORTED"/>
        /// </summary>
        public static string NOT_SUPPORTED { get { return SGetField<string>(LocalBridgeClazz, "NOT_SUPPORTED"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/common/compress/KafkaLZ4BlockInputStream.html#PREMATURE_EOS"/>
        /// </summary>
        public static string PREMATURE_EOS { get { return SGetField<string>(LocalBridgeClazz, "PREMATURE_EOS"); } }

        #endregion

        #region Static methods

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/common/compress/KafkaLZ4BlockInputStream.html#ignoreFlagDescriptorChecksum--"/>
        /// </summary>

        /// <returns><see cref="bool"/></returns>
        public bool IgnoreFlagDescriptorChecksum()
        {
            return IExecute<bool>("ignoreFlagDescriptorChecksum");
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}