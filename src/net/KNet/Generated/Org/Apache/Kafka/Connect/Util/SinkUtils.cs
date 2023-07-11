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
*  using connect-runtime-3.5.0.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Connect.Util
{
    #region SinkUtils
    public partial class SinkUtils
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-runtime/3.5.0/org/apache/kafka/connect/util/SinkUtils.html#KAFKA_OFFSET_KEY"/>
        /// </summary>
        public static string KAFKA_OFFSET_KEY { get { return SGetField<string>(LocalBridgeClazz, "KAFKA_OFFSET_KEY"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-runtime/3.5.0/org/apache/kafka/connect/util/SinkUtils.html#KAFKA_PARTITION_KEY"/>
        /// </summary>
        public static string KAFKA_PARTITION_KEY { get { return SGetField<string>(LocalBridgeClazz, "KAFKA_PARTITION_KEY"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-runtime/3.5.0/org/apache/kafka/connect/util/SinkUtils.html#KAFKA_TOPIC_KEY"/>
        /// </summary>
        public static string KAFKA_TOPIC_KEY { get { return SGetField<string>(LocalBridgeClazz, "KAFKA_TOPIC_KEY"); } }

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-runtime/3.5.0/org/apache/kafka/connect/util/SinkUtils.html#consumerGroupId-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="string"/></returns>
        public static string ConsumerGroupId(string arg0)
        {
            return SExecute<string>(LocalBridgeClazz, "consumerGroupId", arg0);
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