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
    #region IWritable
    /// <summary>
    /// .NET interface for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/protocol/Writable.html"/>
    /// </summary>
    public partial interface IWritable
    {
        #region Instance methods

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion

    #region Writable
    public partial class Writable : Org.Apache.Kafka.Common.Protocol.IWritable
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields

        #endregion

        #region Static methods

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/protocol/Writable.html#writeByte(byte)"/>
        /// </summary>
        /// <param name="arg0"><see cref="byte"/></param>
        public void WriteByte(byte arg0)
        {
            IExecute("writeByte", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/protocol/Writable.html#writeByteArray(byte[])"/>
        /// </summary>
        /// <param name="arg0"><see cref="byte"/></param>
        public void WriteByteArray(byte[] arg0)
        {
            IExecute("writeByteArray", new object[] { arg0 });
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/protocol/Writable.html#writeByteBuffer(java.nio.ByteBuffer)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Nio.ByteBuffer"/></param>
        public void WriteByteBuffer(Java.Nio.ByteBuffer arg0)
        {
            IExecute("writeByteBuffer", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/protocol/Writable.html#writeDouble(double)"/>
        /// </summary>
        /// <param name="arg0"><see cref="double"/></param>
        public void WriteDouble(double arg0)
        {
            IExecute("writeDouble", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/protocol/Writable.html#writeInt(int)"/>
        /// </summary>
        /// <param name="arg0"><see cref="int"/></param>
        public void WriteInt(int arg0)
        {
            IExecute("writeInt", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/protocol/Writable.html#writeLong(long)"/>
        /// </summary>
        /// <param name="arg0"><see cref="long"/></param>
        public void WriteLong(long arg0)
        {
            IExecute("writeLong", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/protocol/Writable.html#writeShort(short)"/>
        /// </summary>
        /// <param name="arg0"><see cref="short"/></param>
        public void WriteShort(short arg0)
        {
            IExecute("writeShort", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/protocol/Writable.html#writeUnsignedVarint(int)"/>
        /// </summary>
        /// <param name="arg0"><see cref="int"/></param>
        public void WriteUnsignedVarint(int arg0)
        {
            IExecute("writeUnsignedVarint", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/protocol/Writable.html#writeVarint(int)"/>
        /// </summary>
        /// <param name="arg0"><see cref="int"/></param>
        public void WriteVarint(int arg0)
        {
            IExecute("writeVarint", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/protocol/Writable.html#writeVarlong(long)"/>
        /// </summary>
        /// <param name="arg0"><see cref="long"/></param>
        public void WriteVarlong(long arg0)
        {
            IExecute("writeVarlong", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/protocol/Writable.html#writeUnsignedInt(long)"/>
        /// </summary>
        /// <param name="arg0"><see cref="long"/></param>
        public void WriteUnsignedInt(long arg0)
        {
            IExecute("writeUnsignedInt", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/protocol/Writable.html#writeUnsignedShort(int)"/>
        /// </summary>
        /// <param name="arg0"><see cref="int"/></param>
        public void WriteUnsignedShort(int arg0)
        {
            IExecute("writeUnsignedShort", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/protocol/Writable.html#writeUuid(org.apache.kafka.common.Uuid)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Uuid"/></param>
        public void WriteUuid(Org.Apache.Kafka.Common.Uuid arg0)
        {
            IExecute("writeUuid", arg0);
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}