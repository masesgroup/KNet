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

namespace Org.Apache.Kafka.Common.Utils
{
    #region ByteUtils
    public partial class ByteUtils
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/ByteUtils.html#EMPTY_BUF"/>
        /// </summary>
        public static Java.Nio.ByteBuffer EMPTY_BUF { get { if (!_EMPTY_BUFReady) { _EMPTY_BUFContent = SGetField<Java.Nio.ByteBuffer>(LocalBridgeClazz, "EMPTY_BUF"); _EMPTY_BUFReady = true; } return _EMPTY_BUFContent; } }
        private static Java.Nio.ByteBuffer _EMPTY_BUFContent = default;
        private static bool _EMPTY_BUFReady = false; // this is used because in case of generics 

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/ByteUtils.html#readDouble-java.io.DataInput-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Io.DataInput"/></param>
        /// <returns><see cref="double"/></returns>
        /// <exception cref="Java.Io.IOException"/>
        public static double ReadDouble(Java.Io.DataInput arg0)
        {
            return SExecuteWithSignature<double>(LocalBridgeClazz, "readDouble", "(Ljava/io/DataInput;)D", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/ByteUtils.html#readDouble-java.nio.ByteBuffer-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Nio.ByteBuffer"/></param>
        /// <returns><see cref="double"/></returns>
        public static double ReadDouble(Java.Nio.ByteBuffer arg0)
        {
            return SExecuteWithSignature<double>(LocalBridgeClazz, "readDouble", "(Ljava/nio/ByteBuffer;)D", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/ByteUtils.html#readIntBE-byte[]-int-"/>
        /// </summary>
        /// <param name="arg0"><see cref="byte"/></param>
        /// <param name="arg1"><see cref="int"/></param>
        /// <returns><see cref="int"/></returns>
        public static int ReadIntBE(byte[] arg0, int arg1)
        {
            return SExecute<int>(LocalBridgeClazz, "readIntBE", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/ByteUtils.html#readUnsignedIntLE-byte[]-int-"/>
        /// </summary>
        /// <param name="arg0"><see cref="byte"/></param>
        /// <param name="arg1"><see cref="int"/></param>
        /// <returns><see cref="int"/></returns>
        public static int ReadUnsignedIntLE(byte[] arg0, int arg1)
        {
            return SExecute<int>(LocalBridgeClazz, "readUnsignedIntLE", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/ByteUtils.html#readUnsignedIntLE-java.io.InputStream-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Io.InputStream"/></param>
        /// <returns><see cref="int"/></returns>
        /// <exception cref="Java.Io.IOException"/>
        public static int ReadUnsignedIntLE(Java.Io.InputStream arg0)
        {
            return SExecuteWithSignature<int>(LocalBridgeClazz, "readUnsignedIntLE", "(Ljava/io/InputStream;)I", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/ByteUtils.html#readUnsignedVarint-java.nio.ByteBuffer-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Nio.ByteBuffer"/></param>
        /// <returns><see cref="int"/></returns>
        public static int ReadUnsignedVarint(Java.Nio.ByteBuffer arg0)
        {
            return SExecuteWithSignature<int>(LocalBridgeClazz, "readUnsignedVarint", "(Ljava/nio/ByteBuffer;)I", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/ByteUtils.html#readVarint-java.io.InputStream-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Io.InputStream"/></param>
        /// <returns><see cref="int"/></returns>
        /// <exception cref="Java.Io.IOException"/>
        public static int ReadVarint(Java.Io.InputStream arg0)
        {
            return SExecuteWithSignature<int>(LocalBridgeClazz, "readVarint", "(Ljava/io/InputStream;)I", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/ByteUtils.html#readVarint-java.nio.ByteBuffer-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Nio.ByteBuffer"/></param>
        /// <returns><see cref="int"/></returns>
        public static int ReadVarint(Java.Nio.ByteBuffer arg0)
        {
            return SExecuteWithSignature<int>(LocalBridgeClazz, "readVarint", "(Ljava/nio/ByteBuffer;)I", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/ByteUtils.html#sizeOfUnsignedVarint-int-"/>
        /// </summary>
        /// <param name="arg0"><see cref="int"/></param>
        /// <returns><see cref="int"/></returns>
        public static int SizeOfUnsignedVarint(int arg0)
        {
            return SExecuteWithSignature<int>(LocalBridgeClazz, "sizeOfUnsignedVarint", "(I)I", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/ByteUtils.html#sizeOfUnsignedVarlong-long-"/>
        /// </summary>
        /// <param name="arg0"><see cref="long"/></param>
        /// <returns><see cref="int"/></returns>
        public static int SizeOfUnsignedVarlong(long arg0)
        {
            return SExecuteWithSignature<int>(LocalBridgeClazz, "sizeOfUnsignedVarlong", "(J)I", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/ByteUtils.html#sizeOfVarint-int-"/>
        /// </summary>
        /// <param name="arg0"><see cref="int"/></param>
        /// <returns><see cref="int"/></returns>
        public static int SizeOfVarint(int arg0)
        {
            return SExecuteWithSignature<int>(LocalBridgeClazz, "sizeOfVarint", "(I)I", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/ByteUtils.html#sizeOfVarlong-long-"/>
        /// </summary>
        /// <param name="arg0"><see cref="long"/></param>
        /// <returns><see cref="int"/></returns>
        public static int SizeOfVarlong(long arg0)
        {
            return SExecuteWithSignature<int>(LocalBridgeClazz, "sizeOfVarlong", "(J)I", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/ByteUtils.html#readUnsignedInt-java.nio.ByteBuffer-int-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Nio.ByteBuffer"/></param>
        /// <param name="arg1"><see cref="int"/></param>
        /// <returns><see cref="long"/></returns>
        public static long ReadUnsignedInt(Java.Nio.ByteBuffer arg0, int arg1)
        {
            return SExecute<long>(LocalBridgeClazz, "readUnsignedInt", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/ByteUtils.html#readUnsignedInt-java.nio.ByteBuffer-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Nio.ByteBuffer"/></param>
        /// <returns><see cref="long"/></returns>
        public static long ReadUnsignedInt(Java.Nio.ByteBuffer arg0)
        {
            return SExecuteWithSignature<long>(LocalBridgeClazz, "readUnsignedInt", "(Ljava/nio/ByteBuffer;)J", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/ByteUtils.html#readVarlong-java.io.InputStream-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Io.InputStream"/></param>
        /// <returns><see cref="long"/></returns>
        /// <exception cref="Java.Io.IOException"/>
        public static long ReadVarlong(Java.Io.InputStream arg0)
        {
            return SExecuteWithSignature<long>(LocalBridgeClazz, "readVarlong", "(Ljava/io/InputStream;)J", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/ByteUtils.html#readVarlong-java.nio.ByteBuffer-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Nio.ByteBuffer"/></param>
        /// <returns><see cref="long"/></returns>
        public static long ReadVarlong(Java.Nio.ByteBuffer arg0)
        {
            return SExecuteWithSignature<long>(LocalBridgeClazz, "readVarlong", "(Ljava/nio/ByteBuffer;)J", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/ByteUtils.html#writeDouble-double-java.io.DataOutput-"/>
        /// </summary>
        /// <param name="arg0"><see cref="double"/></param>
        /// <param name="arg1"><see cref="Java.Io.DataOutput"/></param>
        /// <exception cref="Java.Io.IOException"/>
        public static void WriteDouble(double arg0, Java.Io.DataOutput arg1)
        {
            SExecute(LocalBridgeClazz, "writeDouble", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/ByteUtils.html#writeDouble-double-java.nio.ByteBuffer-"/>
        /// </summary>
        /// <param name="arg0"><see cref="double"/></param>
        /// <param name="arg1"><see cref="Java.Nio.ByteBuffer"/></param>
        public static void WriteDouble(double arg0, Java.Nio.ByteBuffer arg1)
        {
            SExecute(LocalBridgeClazz, "writeDouble", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/ByteUtils.html#writeUnsignedInt-java.nio.ByteBuffer-int-long-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Nio.ByteBuffer"/></param>
        /// <param name="arg1"><see cref="int"/></param>
        /// <param name="arg2"><see cref="long"/></param>
        public static void WriteUnsignedInt(Java.Nio.ByteBuffer arg0, int arg1, long arg2)
        {
            SExecute(LocalBridgeClazz, "writeUnsignedInt", arg0, arg1, arg2);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/ByteUtils.html#writeUnsignedInt-java.nio.ByteBuffer-long-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Nio.ByteBuffer"/></param>
        /// <param name="arg1"><see cref="long"/></param>
        public static void WriteUnsignedInt(Java.Nio.ByteBuffer arg0, long arg1)
        {
            SExecute(LocalBridgeClazz, "writeUnsignedInt", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/ByteUtils.html#writeUnsignedIntLE-byte[]-int-int-"/>
        /// </summary>
        /// <param name="arg0"><see cref="byte"/></param>
        /// <param name="arg1"><see cref="int"/></param>
        /// <param name="arg2"><see cref="int"/></param>
        public static void WriteUnsignedIntLE(byte[] arg0, int arg1, int arg2)
        {
            SExecute(LocalBridgeClazz, "writeUnsignedIntLE", arg0, arg1, arg2);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/ByteUtils.html#writeUnsignedIntLE-java.io.OutputStream-int-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Io.OutputStream"/></param>
        /// <param name="arg1"><see cref="int"/></param>
        /// <exception cref="Java.Io.IOException"/>
        public static void WriteUnsignedIntLE(Java.Io.OutputStream arg0, int arg1)
        {
            SExecute(LocalBridgeClazz, "writeUnsignedIntLE", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/ByteUtils.html#writeUnsignedVarint-int-java.io.DataOutput-"/>
        /// </summary>
        /// <param name="arg0"><see cref="int"/></param>
        /// <param name="arg1"><see cref="Java.Io.DataOutput"/></param>
        /// <exception cref="Java.Io.IOException"/>
        public static void WriteUnsignedVarint(int arg0, Java.Io.DataOutput arg1)
        {
            SExecute(LocalBridgeClazz, "writeUnsignedVarint", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/ByteUtils.html#writeUnsignedVarint-int-java.nio.ByteBuffer-"/>
        /// </summary>
        /// <param name="arg0"><see cref="int"/></param>
        /// <param name="arg1"><see cref="Java.Nio.ByteBuffer"/></param>
        public static void WriteUnsignedVarint(int arg0, Java.Nio.ByteBuffer arg1)
        {
            SExecute(LocalBridgeClazz, "writeUnsignedVarint", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/ByteUtils.html#writeUnsignedVarlong-long-java.nio.ByteBuffer-"/>
        /// </summary>
        /// <param name="arg0"><see cref="long"/></param>
        /// <param name="arg1"><see cref="Java.Nio.ByteBuffer"/></param>
        public static void WriteUnsignedVarlong(long arg0, Java.Nio.ByteBuffer arg1)
        {
            SExecute(LocalBridgeClazz, "writeUnsignedVarlong", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/ByteUtils.html#writeVarint-int-java.io.DataOutput-"/>
        /// </summary>
        /// <param name="arg0"><see cref="int"/></param>
        /// <param name="arg1"><see cref="Java.Io.DataOutput"/></param>
        /// <exception cref="Java.Io.IOException"/>
        public static void WriteVarint(int arg0, Java.Io.DataOutput arg1)
        {
            SExecute(LocalBridgeClazz, "writeVarint", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/ByteUtils.html#writeVarint-int-java.nio.ByteBuffer-"/>
        /// </summary>
        /// <param name="arg0"><see cref="int"/></param>
        /// <param name="arg1"><see cref="Java.Nio.ByteBuffer"/></param>
        public static void WriteVarint(int arg0, Java.Nio.ByteBuffer arg1)
        {
            SExecute(LocalBridgeClazz, "writeVarint", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/ByteUtils.html#writeVarlong-long-java.io.DataOutput-"/>
        /// </summary>
        /// <param name="arg0"><see cref="long"/></param>
        /// <param name="arg1"><see cref="Java.Io.DataOutput"/></param>
        /// <exception cref="Java.Io.IOException"/>
        public static void WriteVarlong(long arg0, Java.Io.DataOutput arg1)
        {
            SExecute(LocalBridgeClazz, "writeVarlong", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/ByteUtils.html#writeVarlong-long-java.nio.ByteBuffer-"/>
        /// </summary>
        /// <param name="arg0"><see cref="long"/></param>
        /// <param name="arg1"><see cref="Java.Nio.ByteBuffer"/></param>
        public static void WriteVarlong(long arg0, Java.Nio.ByteBuffer arg1)
        {
            SExecute(LocalBridgeClazz, "writeVarlong", arg0, arg1);
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