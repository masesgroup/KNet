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

namespace Org.Apache.Kafka.Clients.Admin
{
    #region DescribeClientQuotasResult
    public partial class DescribeClientQuotasResult
    {
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/admin/DescribeClientQuotasResult.html#org.apache.kafka.clients.admin.DescribeClientQuotasResult(org.apache.kafka.common.KafkaFuture)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.KafkaFuture"/></param>
        public DescribeClientQuotasResult(Org.Apache.Kafka.Common.KafkaFuture<Java.Util.Map<Org.Apache.Kafka.Common.Quota.ClientQuotaEntity, Java.Util.Map<Java.Lang.String, Java.Lang.Double>>> arg0)
            : base(arg0)
        {
        }

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields

        #endregion

        #region Static methods

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/admin/DescribeClientQuotasResult.html#entities--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.KafkaFuture"/></returns>
        public Org.Apache.Kafka.Common.KafkaFuture<Java.Util.Map<Org.Apache.Kafka.Common.Quota.ClientQuotaEntity, Java.Util.Map<Java.Lang.String, Java.Lang.Double>>> Entities()
        {
            return IExecuteWithSignature<Org.Apache.Kafka.Common.KafkaFuture<Java.Util.Map<Org.Apache.Kafka.Common.Quota.ClientQuotaEntity, Java.Util.Map<Java.Lang.String, Java.Lang.Double>>>>("entities", "()Lorg/apache/kafka/common/KafkaFuture;");
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}