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

namespace Org.Apache.Kafka.Common.Security.Auth
{
    #region SslAuthenticationContext
    public partial class SslAuthenticationContext
    {
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/security/auth/SslAuthenticationContext.html#org.apache.kafka.common.security.auth.SslAuthenticationContext(javax.net.ssl.SSLSession,java.net.InetAddress,java.lang.String)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Javax.Net.Ssl.SSLSession"/></param>
        /// <param name="arg1"><see cref="Java.Net.InetAddress"/></param>
        /// <param name="arg2"><see cref="string"/></param>
        public SslAuthenticationContext(Javax.Net.Ssl.SSLSession arg0, Java.Net.InetAddress arg1, string arg2)
            : base(arg0, arg1, arg2)
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
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/security/auth/SslAuthenticationContext.html#listenerName--"/>
        /// </summary>

        /// <returns><see cref="string"/></returns>
        public string ListenerName()
        {
            return IExecute<string>("listenerName");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/security/auth/SslAuthenticationContext.html#clientAddress--"/>
        /// </summary>

        /// <returns><see cref="Java.Net.InetAddress"/></returns>
        public Java.Net.InetAddress ClientAddress()
        {
            return IExecute<Java.Net.InetAddress>("clientAddress");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/security/auth/SslAuthenticationContext.html#session--"/>
        /// </summary>

        /// <returns><see cref="Javax.Net.Ssl.SSLSession"/></returns>
        public Javax.Net.Ssl.SSLSession Session()
        {
            return IExecute<Javax.Net.Ssl.SSLSession>("session");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/security/auth/SslAuthenticationContext.html#securityProtocol--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.Security.Auth.SecurityProtocol"/></returns>
        public Org.Apache.Kafka.Common.Security.Auth.SecurityProtocol SecurityProtocol()
        {
            return IExecute<Org.Apache.Kafka.Common.Security.Auth.SecurityProtocol>("securityProtocol");
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}