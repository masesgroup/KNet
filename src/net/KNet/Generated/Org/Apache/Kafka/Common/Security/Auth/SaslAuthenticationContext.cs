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

namespace Org.Apache.Kafka.Common.Security.Auth
{
    #region SaslAuthenticationContext
    public partial class SaslAuthenticationContext
    {
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/security/auth/SaslAuthenticationContext.html#org.apache.kafka.common.security.auth.SaslAuthenticationContext(javax.security.sasl.SaslServer,org.apache.kafka.common.security.auth.SecurityProtocol,java.net.InetAddress,java.lang.String,java.util.Optional)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Javax.Security.Sasl.SaslServer"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Common.Security.Auth.SecurityProtocol"/></param>
        /// <param name="arg2"><see cref="Java.Net.InetAddress"/></param>
        /// <param name="arg3"><see cref="string"/></param>
        /// <param name="arg4"><see cref="Java.Util.Optional"/></param>
        public SaslAuthenticationContext(Javax.Security.Sasl.SaslServer arg0, Org.Apache.Kafka.Common.Security.Auth.SecurityProtocol arg1, Java.Net.InetAddress arg2, string arg3, Java.Util.Optional<Javax.Net.Ssl.SSLSession> arg4)
            : base(arg0, arg1, arg2, arg3, arg4)
        {
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/security/auth/SaslAuthenticationContext.html#org.apache.kafka.common.security.auth.SaslAuthenticationContext(javax.security.sasl.SaslServer,org.apache.kafka.common.security.auth.SecurityProtocol,java.net.InetAddress,java.lang.String)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Javax.Security.Sasl.SaslServer"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Common.Security.Auth.SecurityProtocol"/></param>
        /// <param name="arg2"><see cref="Java.Net.InetAddress"/></param>
        /// <param name="arg3"><see cref="string"/></param>
        public SaslAuthenticationContext(Javax.Security.Sasl.SaslServer arg0, Org.Apache.Kafka.Common.Security.Auth.SecurityProtocol arg1, Java.Net.InetAddress arg2, string arg3)
            : base(arg0, arg1, arg2, arg3)
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
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/security/auth/SaslAuthenticationContext.html#listenerName--"/>
        /// </summary>

        /// <returns><see cref="string"/></returns>
        public string ListenerName()
        {
            return IExecute<string>("listenerName");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/security/auth/SaslAuthenticationContext.html#clientAddress--"/>
        /// </summary>

        /// <returns><see cref="Java.Net.InetAddress"/></returns>
        public Java.Net.InetAddress ClientAddress()
        {
            return IExecute<Java.Net.InetAddress>("clientAddress");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/security/auth/SaslAuthenticationContext.html#sslSession--"/>
        /// </summary>

        /// <returns><see cref="Java.Util.Optional"/></returns>
        public Java.Util.Optional<Javax.Net.Ssl.SSLSession> SslSession()
        {
            return IExecute<Java.Util.Optional<Javax.Net.Ssl.SSLSession>>("sslSession");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/security/auth/SaslAuthenticationContext.html#server--"/>
        /// </summary>

        /// <returns><see cref="Javax.Security.Sasl.SaslServer"/></returns>
        public Javax.Security.Sasl.SaslServer Server()
        {
            return IExecute<Javax.Security.Sasl.SaslServer>("server");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/security/auth/SaslAuthenticationContext.html#securityProtocol--"/>
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