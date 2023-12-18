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

namespace Org.Apache.Kafka.Clients
{
    #region ClientDnsLookup
    public partial class ClientDnsLookup
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/ClientDnsLookup.html#RESOLVE_CANONICAL_BOOTSTRAP_SERVERS_ONLY"/>
        /// </summary>
        public static Org.Apache.Kafka.Clients.ClientDnsLookup RESOLVE_CANONICAL_BOOTSTRAP_SERVERS_ONLY { get { return SGetField<Org.Apache.Kafka.Clients.ClientDnsLookup>(LocalBridgeClazz, "RESOLVE_CANONICAL_BOOTSTRAP_SERVERS_ONLY"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/ClientDnsLookup.html#USE_ALL_DNS_IPS"/>
        /// </summary>
        public static Org.Apache.Kafka.Clients.ClientDnsLookup USE_ALL_DNS_IPS { get { return SGetField<Org.Apache.Kafka.Clients.ClientDnsLookup>(LocalBridgeClazz, "USE_ALL_DNS_IPS"); } }

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/ClientDnsLookup.html#forConfig-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Clients.ClientDnsLookup"/></returns>
        public static Org.Apache.Kafka.Clients.ClientDnsLookup ForConfig(string arg0)
        {
            return SExecute<Org.Apache.Kafka.Clients.ClientDnsLookup>(LocalBridgeClazz, "forConfig", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/ClientDnsLookup.html#valueOf-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Clients.ClientDnsLookup"/></returns>
        public static Org.Apache.Kafka.Clients.ClientDnsLookup ValueOf(string arg0)
        {
            return SExecute<Org.Apache.Kafka.Clients.ClientDnsLookup>(LocalBridgeClazz, "valueOf", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/ClientDnsLookup.html#values--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Clients.ClientDnsLookup"/></returns>
        public static Org.Apache.Kafka.Clients.ClientDnsLookup[] Values()
        {
            return SExecuteArray<Org.Apache.Kafka.Clients.ClientDnsLookup>(LocalBridgeClazz, "values");
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