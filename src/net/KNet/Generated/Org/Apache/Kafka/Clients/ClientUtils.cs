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
*  This file is generated by MASES.JNetReflector (ver. 2.0.2.0)
*  using kafka-clients-3.6.0.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Clients
{
    #region ClientUtils
    public partial class ClientUtils
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/ClientUtils.html#createConfiguredInterceptors-org.apache.kafka.common.config.AbstractConfig-java.lang.String-java.lang.Class-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Config.AbstractConfig"/></param>
        /// <param name="arg1"><see cref="string"/></param>
        /// <param name="arg2"><see cref="Java.Lang.Class"/></param>
        /// <returns><see cref="Java.Util.List"/></returns>
        public static Java.Util.List CreateConfiguredInterceptors(Org.Apache.Kafka.Common.Config.AbstractConfig arg0, string arg1, Java.Lang.Class arg2)
        {
            return SExecute<Java.Util.List>(LocalBridgeClazz, "createConfiguredInterceptors", arg0, arg1, arg2);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/ClientUtils.html#parseAndValidateAddresses-java.util.List-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.List"/></param>
        /// <param name="arg1"><see cref="string"/></param>
        /// <returns><see cref="Java.Util.List"/></returns>
        public static Java.Util.List<Java.Net.InetSocketAddress> ParseAndValidateAddresses(Java.Util.List<string> arg0, string arg1)
        {
            return SExecute<Java.Util.List<Java.Net.InetSocketAddress>>(LocalBridgeClazz, "parseAndValidateAddresses", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/ClientUtils.html#parseAndValidateAddresses-java.util.List-org.apache.kafka.clients.ClientDnsLookup-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.List"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Clients.ClientDnsLookup"/></param>
        /// <returns><see cref="Java.Util.List"/></returns>
        public static Java.Util.List<Java.Net.InetSocketAddress> ParseAndValidateAddresses(Java.Util.List<string> arg0, Org.Apache.Kafka.Clients.ClientDnsLookup arg1)
        {
            return SExecute<Java.Util.List<Java.Net.InetSocketAddress>>(LocalBridgeClazz, "parseAndValidateAddresses", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/ClientUtils.html#parseAndValidateAddresses-org.apache.kafka.common.config.AbstractConfig-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Config.AbstractConfig"/></param>
        /// <returns><see cref="Java.Util.List"/></returns>
        public static Java.Util.List<Java.Net.InetSocketAddress> ParseAndValidateAddresses(Org.Apache.Kafka.Common.Config.AbstractConfig arg0)
        {
            return SExecute<Java.Util.List<Java.Net.InetSocketAddress>>(LocalBridgeClazz, "parseAndValidateAddresses", arg0);
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