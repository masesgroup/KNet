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

namespace Org.Apache.Kafka.Common.Quota
{
    #region ClientQuotaEntity
    public partial class ClientQuotaEntity
    {
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/quota/ClientQuotaEntity.html#org.apache.kafka.common.quota.ClientQuotaEntity(java.util.Map)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.Map"/></param>
        public ClientQuotaEntity(Java.Util.Map<string, string> arg0)
            : base(arg0)
        {
        }

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/quota/ClientQuotaEntity.html#CLIENT_ID"/>
        /// </summary>
        public static string CLIENT_ID { get { if (!_CLIENT_IDReady) { _CLIENT_IDContent = SGetField<string>(LocalBridgeClazz, "CLIENT_ID"); _CLIENT_IDReady = true; } return _CLIENT_IDContent; } }
        private static string _CLIENT_IDContent = default;
        private static bool _CLIENT_IDReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/quota/ClientQuotaEntity.html#IP"/>
        /// </summary>
        public static string IP { get { if (!_IPReady) { _IPContent = SGetField<string>(LocalBridgeClazz, "IP"); _IPReady = true; } return _IPContent; } }
        private static string _IPContent = default;
        private static bool _IPReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/quota/ClientQuotaEntity.html#USER"/>
        /// </summary>
        public static string USER { get { if (!_USERReady) { _USERContent = SGetField<string>(LocalBridgeClazz, "USER"); _USERReady = true; } return _USERContent; } }
        private static string _USERContent = default;
        private static bool _USERReady = false; // this is used because in case of generics 

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/quota/ClientQuotaEntity.html#isValidEntityType-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="bool"/></returns>
        public static bool IsValidEntityType(string arg0)
        {
            return SExecute<bool>(LocalBridgeClazz, "isValidEntityType", arg0);
        }

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/quota/ClientQuotaEntity.html#entries--"/>
        /// </summary>

        /// <returns><see cref="Java.Util.Map"/></returns>
        public Java.Util.Map<string, string> Entries()
        {
            return IExecute<Java.Util.Map<string, string>>("entries");
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}