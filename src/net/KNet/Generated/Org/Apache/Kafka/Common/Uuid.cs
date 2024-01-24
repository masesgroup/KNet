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
*  This file is generated by MASES.JNetReflector (ver. 2.2.3.0)
*  using kafka-clients-3.6.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Common
{
    #region Uuid
    public partial class Uuid
    {
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/Uuid.html#org.apache.kafka.common.Uuid(long,long)"/>
        /// </summary>
        /// <param name="arg0"><see cref="long"/></param>
        /// <param name="arg1"><see cref="long"/></param>
        public Uuid(long arg0, long arg1)
            : base(arg0, arg1)
        {
        }

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/Uuid.html#METADATA_TOPIC_ID"/>
        /// </summary>
        public static Org.Apache.Kafka.Common.Uuid METADATA_TOPIC_ID { get { if (!_METADATA_TOPIC_IDReady) { _METADATA_TOPIC_IDContent = SGetField<Org.Apache.Kafka.Common.Uuid>(LocalBridgeClazz, "METADATA_TOPIC_ID"); _METADATA_TOPIC_IDReady = true; } return _METADATA_TOPIC_IDContent; } }
        private static Org.Apache.Kafka.Common.Uuid _METADATA_TOPIC_IDContent = default;
        private static bool _METADATA_TOPIC_IDReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/Uuid.html#ZERO_UUID"/>
        /// </summary>
        public static Org.Apache.Kafka.Common.Uuid ZERO_UUID { get { if (!_ZERO_UUIDReady) { _ZERO_UUIDContent = SGetField<Org.Apache.Kafka.Common.Uuid>(LocalBridgeClazz, "ZERO_UUID"); _ZERO_UUIDReady = true; } return _ZERO_UUIDContent; } }
        private static Org.Apache.Kafka.Common.Uuid _ZERO_UUIDContent = default;
        private static bool _ZERO_UUIDReady = false; // this is used because in case of generics 

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/Uuid.html#fromString-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Common.Uuid"/></returns>
        public static Org.Apache.Kafka.Common.Uuid FromString(string arg0)
        {
            return SExecute<Org.Apache.Kafka.Common.Uuid>(LocalBridgeClazz, "fromString", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/Uuid.html#randomUuid--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.Uuid"/></returns>
        public static Org.Apache.Kafka.Common.Uuid RandomUuid()
        {
            return SExecute<Org.Apache.Kafka.Common.Uuid>(LocalBridgeClazz, "randomUuid");
        }

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/Uuid.html#getLeastSignificantBits--"/> 
        /// </summary>
        public long LeastSignificantBits
        {
            get { return IExecute<long>("getLeastSignificantBits"); }
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/Uuid.html#getMostSignificantBits--"/> 
        /// </summary>
        public long MostSignificantBits
        {
            get { return IExecute<long>("getMostSignificantBits"); }
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/Uuid.html#compareTo-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><see cref="object"/></param>
        /// <returns><see cref="int"/></returns>
        public int CompareTo(object arg0)
        {
            return IExecute<int>("compareTo", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/Uuid.html#compareTo-org.apache.kafka.common.Uuid-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Uuid"/></param>
        /// <returns><see cref="int"/></returns>
        public int CompareTo(Org.Apache.Kafka.Common.Uuid arg0)
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