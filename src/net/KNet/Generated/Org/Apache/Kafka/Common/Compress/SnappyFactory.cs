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
    #region SnappyFactory
    public partial class SnappyFactory
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/common/compress/SnappyFactory.html#wrapForInput-java.nio.ByteBuffer-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Nio.ByteBuffer"/></param>
        /// <returns><see cref="Java.Io.InputStream"/></returns>
        public static Java.Io.InputStream WrapForInput(Java.Nio.ByteBuffer arg0)
        {
            return SExecute<Java.Io.InputStream>(LocalBridgeClazz, "wrapForInput", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/common/compress/SnappyFactory.html#wrapForOutput-org.apache.kafka.common.utils.ByteBufferOutputStream-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Utils.ByteBufferOutputStream"/></param>
        /// <returns><see cref="Java.Io.OutputStream"/></returns>
        public static Java.Io.OutputStream WrapForOutput(Org.Apache.Kafka.Common.Utils.ByteBufferOutputStream arg0)
        {
            return SExecute<Java.Io.OutputStream>(LocalBridgeClazz, "wrapForOutput", arg0);
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