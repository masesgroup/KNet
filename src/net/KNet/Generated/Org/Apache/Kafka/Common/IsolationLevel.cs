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
*  This file is generated by MASES.JNetReflector (ver. 2.2.0.0)
*  using kafka-clients-3.6.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Common
{
    #region IsolationLevel
    public partial class IsolationLevel
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/IsolationLevel.html#READ_COMMITTED"/>
        /// </summary>
        public static Org.Apache.Kafka.Common.IsolationLevel READ_COMMITTED { get { return SGetField<Org.Apache.Kafka.Common.IsolationLevel>(LocalBridgeClazz, "READ_COMMITTED"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/IsolationLevel.html#READ_UNCOMMITTED"/>
        /// </summary>
        public static Org.Apache.Kafka.Common.IsolationLevel READ_UNCOMMITTED { get { return SGetField<Org.Apache.Kafka.Common.IsolationLevel>(LocalBridgeClazz, "READ_UNCOMMITTED"); } }

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/IsolationLevel.html#forId-byte-"/>
        /// </summary>
        /// <param name="arg0"><see cref="byte"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Common.IsolationLevel"/></returns>
        public static Org.Apache.Kafka.Common.IsolationLevel ForId(byte arg0)
        {
            return SExecute<Org.Apache.Kafka.Common.IsolationLevel>(LocalBridgeClazz, "forId", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/IsolationLevel.html#valueOf-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Common.IsolationLevel"/></returns>
        public static Org.Apache.Kafka.Common.IsolationLevel ValueOf(string arg0)
        {
            return SExecute<Org.Apache.Kafka.Common.IsolationLevel>(LocalBridgeClazz, "valueOf", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/IsolationLevel.html#values--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.IsolationLevel"/></returns>
        public static Org.Apache.Kafka.Common.IsolationLevel[] Values()
        {
            return SExecuteArray<Org.Apache.Kafka.Common.IsolationLevel>(LocalBridgeClazz, "values");
        }

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/IsolationLevel.html#id--"/>
        /// </summary>

        /// <returns><see cref="byte"/></returns>
        public byte Id()
        {
            return IExecute<byte>("id");
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}