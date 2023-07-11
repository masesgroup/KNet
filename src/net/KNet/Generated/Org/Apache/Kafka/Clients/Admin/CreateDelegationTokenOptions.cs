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
*  using kafka-clients-3.5.0.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Clients.Admin
{
    #region CreateDelegationTokenOptions
    public partial class CreateDelegationTokenOptions
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
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/clients/admin/CreateDelegationTokenOptions.html#renewers--"/>
        /// </summary>

        /// <returns><see cref="Java.Util.List"/></returns>
        public Java.Util.List<Org.Apache.Kafka.Common.Security.Auth.KafkaPrincipal> Renewers()
        {
            return IExecute<Java.Util.List<Org.Apache.Kafka.Common.Security.Auth.KafkaPrincipal>>("renewers");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/clients/admin/CreateDelegationTokenOptions.html#owner--"/>
        /// </summary>

        /// <returns><see cref="Java.Util.Optional"/></returns>
        public Java.Util.Optional<Org.Apache.Kafka.Common.Security.Auth.KafkaPrincipal> Owner()
        {
            return IExecute<Java.Util.Optional<Org.Apache.Kafka.Common.Security.Auth.KafkaPrincipal>>("owner");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/clients/admin/CreateDelegationTokenOptions.html#maxlifeTimeMs--"/>
        /// </summary>

        /// <returns><see cref="long"/></returns>
        public long MaxlifeTimeMs()
        {
            return IExecute<long>("maxlifeTimeMs");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/clients/admin/CreateDelegationTokenOptions.html#maxlifeTimeMs-long-"/>
        /// </summary>
        /// <param name="arg0"><see cref="long"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Clients.Admin.CreateDelegationTokenOptions"/></returns>
        public Org.Apache.Kafka.Clients.Admin.CreateDelegationTokenOptions MaxlifeTimeMs(long arg0)
        {
            return IExecute<Org.Apache.Kafka.Clients.Admin.CreateDelegationTokenOptions>("maxlifeTimeMs", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/clients/admin/CreateDelegationTokenOptions.html#owner-org.apache.kafka.common.security.auth.KafkaPrincipal-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Security.Auth.KafkaPrincipal"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Clients.Admin.CreateDelegationTokenOptions"/></returns>
        public Org.Apache.Kafka.Clients.Admin.CreateDelegationTokenOptions Owner(Org.Apache.Kafka.Common.Security.Auth.KafkaPrincipal arg0)
        {
            return IExecute<Org.Apache.Kafka.Clients.Admin.CreateDelegationTokenOptions>("owner", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/clients/admin/CreateDelegationTokenOptions.html#renewers-java.util.List-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.List"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Clients.Admin.CreateDelegationTokenOptions"/></returns>
        public Org.Apache.Kafka.Clients.Admin.CreateDelegationTokenOptions Renewers(Java.Util.List<Org.Apache.Kafka.Common.Security.Auth.KafkaPrincipal> arg0)
        {
            return IExecute<Org.Apache.Kafka.Clients.Admin.CreateDelegationTokenOptions>("renewers", arg0);
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}