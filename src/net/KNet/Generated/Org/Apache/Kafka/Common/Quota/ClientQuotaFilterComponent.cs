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
*  This file is generated by MASES.JNetReflector (ver. 2.2.5.0)
*  using kafka-clients-3.6.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Common.Quota
{
    #region ClientQuotaFilterComponent
    public partial class ClientQuotaFilterComponent
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/quota/ClientQuotaFilterComponent.html#ofDefaultEntity-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Common.Quota.ClientQuotaFilterComponent"/></returns>
        public static Org.Apache.Kafka.Common.Quota.ClientQuotaFilterComponent OfDefaultEntity(string arg0)
        {
            return SExecute<Org.Apache.Kafka.Common.Quota.ClientQuotaFilterComponent>(LocalBridgeClazz, "ofDefaultEntity", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/quota/ClientQuotaFilterComponent.html#ofEntity-java.lang.String-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="string"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Common.Quota.ClientQuotaFilterComponent"/></returns>
        public static Org.Apache.Kafka.Common.Quota.ClientQuotaFilterComponent OfEntity(string arg0, string arg1)
        {
            return SExecute<Org.Apache.Kafka.Common.Quota.ClientQuotaFilterComponent>(LocalBridgeClazz, "ofEntity", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/quota/ClientQuotaFilterComponent.html#ofEntityType-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Common.Quota.ClientQuotaFilterComponent"/></returns>
        public static Org.Apache.Kafka.Common.Quota.ClientQuotaFilterComponent OfEntityType(string arg0)
        {
            return SExecute<Org.Apache.Kafka.Common.Quota.ClientQuotaFilterComponent>(LocalBridgeClazz, "ofEntityType", arg0);
        }

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/quota/ClientQuotaFilterComponent.html#entityType--"/>
        /// </summary>

        /// <returns><see cref="string"/></returns>
        public string EntityType()
        {
            return IExecute<string>("entityType");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/quota/ClientQuotaFilterComponent.html#match--"/>
        /// </summary>

        /// <returns><see cref="Java.Util.Optional"/></returns>
        public Java.Util.Optional<string> Match()
        {
            return IExecute<Java.Util.Optional<string>>("match");
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}