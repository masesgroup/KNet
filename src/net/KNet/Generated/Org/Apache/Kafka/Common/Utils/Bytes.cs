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
*  This file is generated by MASES.JNetReflector (ver. 2.1.1.0)
*  using kafka-clients-3.6.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Common.Utils
{
    #region Bytes
    public partial class Bytes
    {
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/Bytes.html#org.apache.kafka.common.utils.Bytes(byte[])"/>
        /// </summary>
        /// <param name="arg0"><see cref="byte"/></param>
        public Bytes(byte[] arg0)
            : base(arg0)
        {
        }

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/Bytes.html#EMPTY"/>
        /// </summary>
        public static byte[] EMPTY { get { return SGetFieldArray<byte>(LocalBridgeClazz, "EMPTY"); } }

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/Bytes.html#increment-org.apache.kafka.common.utils.Bytes-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Utils.Bytes"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Common.Utils.Bytes"/></returns>
        /// <exception cref="Java.Lang.IndexOutOfBoundsException"/>
        public static Org.Apache.Kafka.Common.Utils.Bytes Increment(Org.Apache.Kafka.Common.Utils.Bytes arg0)
        {
            return SExecute<Org.Apache.Kafka.Common.Utils.Bytes>(LocalBridgeClazz, "increment", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/Bytes.html#wrap-byte[]-"/>
        /// </summary>
        /// <param name="arg0"><see cref="byte"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Common.Utils.Bytes"/></returns>
        public static Org.Apache.Kafka.Common.Utils.Bytes Wrap(byte[] arg0)
        {
            return SExecute<Org.Apache.Kafka.Common.Utils.Bytes>(LocalBridgeClazz, "wrap", new object[] { arg0 });
        }

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/Bytes.html#get--"/>
        /// </summary>

        /// <returns><see cref="byte"/></returns>
        public byte[] Get()
        {
            return IExecuteArray<byte>("get");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/Bytes.html#compareTo-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><see cref="object"/></param>
        /// <returns><see cref="int"/></returns>
        public int CompareTo(object arg0)
        {
            return IExecute<int>("compareTo", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/Bytes.html#compareTo-org.apache.kafka.common.utils.Bytes-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Utils.Bytes"/></param>
        /// <returns><see cref="int"/></returns>
        public int CompareTo(Org.Apache.Kafka.Common.Utils.Bytes arg0)
        {
            return IExecute<int>("compareTo", arg0);
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}