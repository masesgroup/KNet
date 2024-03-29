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
*  using kafka-clients-3.6.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Common.Record
{
    #region CompressionType
    public partial class CompressionType
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/record/CompressionType.html#id"/>
        /// </summary>
        public byte id { get { if (!_idReady) { _idContent = IGetField<byte>("id"); _idReady = true; } return _idContent; } }
        private byte _idContent = default;
        private bool _idReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/record/CompressionType.html#rate"/>
        /// </summary>
        public float rate { get { if (!_rateReady) { _rateContent = IGetField<float>("rate"); _rateReady = true; } return _rateContent; } }
        private float _rateContent = default;
        private bool _rateReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/record/CompressionType.html#name"/>
        /// </summary>
        public Java.Lang.String name { get { if (!_nameReady) { _nameContent = IGetField<Java.Lang.String>("name"); _nameReady = true; } return _nameContent; } }
        private Java.Lang.String _nameContent = default;
        private bool _nameReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/record/CompressionType.html#GZIP"/>
        /// </summary>
        public static Org.Apache.Kafka.Common.Record.CompressionType GZIP { get { if (!_GZIPReady) { _GZIPContent = SGetField<Org.Apache.Kafka.Common.Record.CompressionType>(LocalBridgeClazz, "GZIP"); _GZIPReady = true; } return _GZIPContent; } }
        private static Org.Apache.Kafka.Common.Record.CompressionType _GZIPContent = default;
        private static bool _GZIPReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/record/CompressionType.html#LZ4"/>
        /// </summary>
        public static Org.Apache.Kafka.Common.Record.CompressionType LZ4 { get { if (!_LZ4Ready) { _LZ4Content = SGetField<Org.Apache.Kafka.Common.Record.CompressionType>(LocalBridgeClazz, "LZ4"); _LZ4Ready = true; } return _LZ4Content; } }
        private static Org.Apache.Kafka.Common.Record.CompressionType _LZ4Content = default;
        private static bool _LZ4Ready = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/record/CompressionType.html#NONE"/>
        /// </summary>
        public static Org.Apache.Kafka.Common.Record.CompressionType NONE { get { if (!_NONEReady) { _NONEContent = SGetField<Org.Apache.Kafka.Common.Record.CompressionType>(LocalBridgeClazz, "NONE"); _NONEReady = true; } return _NONEContent; } }
        private static Org.Apache.Kafka.Common.Record.CompressionType _NONEContent = default;
        private static bool _NONEReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/record/CompressionType.html#SNAPPY"/>
        /// </summary>
        public static Org.Apache.Kafka.Common.Record.CompressionType SNAPPY { get { if (!_SNAPPYReady) { _SNAPPYContent = SGetField<Org.Apache.Kafka.Common.Record.CompressionType>(LocalBridgeClazz, "SNAPPY"); _SNAPPYReady = true; } return _SNAPPYContent; } }
        private static Org.Apache.Kafka.Common.Record.CompressionType _SNAPPYContent = default;
        private static bool _SNAPPYReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/record/CompressionType.html#ZSTD"/>
        /// </summary>
        public static Org.Apache.Kafka.Common.Record.CompressionType ZSTD { get { if (!_ZSTDReady) { _ZSTDContent = SGetField<Org.Apache.Kafka.Common.Record.CompressionType>(LocalBridgeClazz, "ZSTD"); _ZSTDReady = true; } return _ZSTDContent; } }
        private static Org.Apache.Kafka.Common.Record.CompressionType _ZSTDContent = default;
        private static bool _ZSTDReady = false; // this is used because in case of generics 

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/record/CompressionType.html#forId-int-"/>
        /// </summary>
        /// <param name="arg0"><see cref="int"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Common.Record.CompressionType"/></returns>
        public static Org.Apache.Kafka.Common.Record.CompressionType ForId(int arg0)
        {
            return SExecuteWithSignature<Org.Apache.Kafka.Common.Record.CompressionType>(LocalBridgeClazz, "forId", "(I)Lorg/apache/kafka/common/record/CompressionType;", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/record/CompressionType.html#forName-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.String"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Common.Record.CompressionType"/></returns>
        public static Org.Apache.Kafka.Common.Record.CompressionType ForName(Java.Lang.String arg0)
        {
            return SExecuteWithSignature<Org.Apache.Kafka.Common.Record.CompressionType>(LocalBridgeClazz, "forName", "(Ljava/lang/String;)Lorg/apache/kafka/common/record/CompressionType;", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/record/CompressionType.html#valueOf-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.String"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Common.Record.CompressionType"/></returns>
        public static Org.Apache.Kafka.Common.Record.CompressionType ValueOf(Java.Lang.String arg0)
        {
            return SExecuteWithSignature<Org.Apache.Kafka.Common.Record.CompressionType>(LocalBridgeClazz, "valueOf", "(Ljava/lang/String;)Lorg/apache/kafka/common/record/CompressionType;", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/record/CompressionType.html#values--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.Record.CompressionType"/></returns>
        public static Org.Apache.Kafka.Common.Record.CompressionType[] Values()
        {
            return SExecuteWithSignatureArray<Org.Apache.Kafka.Common.Record.CompressionType>(LocalBridgeClazz, "values", "()[Lorg/apache/kafka/common/record/CompressionType;");
        }

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/record/CompressionType.html#wrapForInput-java.nio.ByteBuffer-byte-org.apache.kafka.common.utils.BufferSupplier-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Nio.ByteBuffer"/></param>
        /// <param name="arg1"><see cref="byte"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Common.Utils.BufferSupplier"/></param>
        /// <returns><see cref="Java.Io.InputStream"/></returns>
        public Java.Io.InputStream WrapForInput(Java.Nio.ByteBuffer arg0, byte arg1, Org.Apache.Kafka.Common.Utils.BufferSupplier arg2)
        {
            return IExecute<Java.Io.InputStream>("wrapForInput", arg0, arg1, arg2);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/record/CompressionType.html#wrapForOutput-org.apache.kafka.common.utils.ByteBufferOutputStream-byte-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Utils.ByteBufferOutputStream"/></param>
        /// <param name="arg1"><see cref="byte"/></param>
        /// <returns><see cref="Java.Io.OutputStream"/></returns>
        public Java.Io.OutputStream WrapForOutput(Org.Apache.Kafka.Common.Utils.ByteBufferOutputStream arg0, byte arg1)
        {
            return IExecute<Java.Io.OutputStream>("wrapForOutput", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/record/CompressionType.html#decompressionOutputSize--"/>
        /// </summary>

        /// <returns><see cref="int"/></returns>
        public int DecompressionOutputSize()
        {
            return IExecuteWithSignature<int>("decompressionOutputSize", "()I");
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}