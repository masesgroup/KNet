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

namespace Org.Apache.Kafka.Common.Security.Authenticator
{
    #region SaslClientAuthenticator
    public partial class SaslClientAuthenticator
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/security/authenticator/SaslClientAuthenticator.html#MAX_RESERVED_CORRELATION_ID"/>
        /// </summary>
        public static int MAX_RESERVED_CORRELATION_ID { get { return SGetField<int>(LocalBridgeClazz, "MAX_RESERVED_CORRELATION_ID"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/security/authenticator/SaslClientAuthenticator.html#MIN_RESERVED_CORRELATION_ID"/>
        /// </summary>
        public static int MIN_RESERVED_CORRELATION_ID { get { return SGetField<int>(LocalBridgeClazz, "MIN_RESERVED_CORRELATION_ID"); } }

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/security/authenticator/SaslClientAuthenticator.html#isReserved-int-"/>
        /// </summary>
        /// <param name="arg0"><see cref="int"/></param>
        /// <returns><see cref="bool"/></returns>
        public static bool IsReserved(int arg0)
        {
            return SExecute<bool>(LocalBridgeClazz, "isReserved", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/security/authenticator/SaslClientAuthenticator.html#firstPrincipal-javax.security.auth.Subject-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Javax.Security.Auth.Subject"/></param>
        /// <returns><see cref="string"/></returns>
        public static string FirstPrincipal(Javax.Security.Auth.Subject arg0)
        {
            return SExecute<string>(LocalBridgeClazz, "firstPrincipal", arg0);
        }

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/security/authenticator/SaslClientAuthenticator.html#complete--"/>
        /// </summary>

        /// <returns><see cref="bool"/></returns>
        public bool Complete()
        {
            return IExecute<bool>("complete");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/security/authenticator/SaslClientAuthenticator.html#clientSessionReauthenticationTimeNanos--"/>
        /// </summary>

        /// <returns><see cref="Java.Lang.Long"/></returns>
        public Java.Lang.Long ClientSessionReauthenticationTimeNanos()
        {
            return IExecute<Java.Lang.Long>("clientSessionReauthenticationTimeNanos");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/security/authenticator/SaslClientAuthenticator.html#reauthenticationLatencyMs--"/>
        /// </summary>

        /// <returns><see cref="Java.Lang.Long"/></returns>
        public Java.Lang.Long ReauthenticationLatencyMs()
        {
            return IExecute<Java.Lang.Long>("reauthenticationLatencyMs");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/security/authenticator/SaslClientAuthenticator.html#principalSerde--"/>
        /// </summary>

        /// <returns><see cref="Java.Util.Optional"/></returns>
        public Java.Util.Optional<Org.Apache.Kafka.Common.Security.Auth.KafkaPrincipalSerde> PrincipalSerde()
        {
            return IExecute<Java.Util.Optional<Org.Apache.Kafka.Common.Security.Auth.KafkaPrincipalSerde>>("principalSerde");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/security/authenticator/SaslClientAuthenticator.html#principal--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.Security.Auth.KafkaPrincipal"/></returns>
        public Org.Apache.Kafka.Common.Security.Auth.KafkaPrincipal Principal()
        {
            return IExecute<Org.Apache.Kafka.Common.Security.Auth.KafkaPrincipal>("principal");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/security/authenticator/SaslClientAuthenticator.html#authenticate--"/>
        /// </summary>

        /// <exception cref="Java.Io.IOException"/>
        public void Authenticate()
        {
            IExecute("authenticate");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/security/authenticator/SaslClientAuthenticator.html#close--"/>
        /// </summary>

        /// <exception cref="Java.Io.IOException"/>
        public void Close()
        {
            IExecute("close");
        }

        #endregion

        #region Nested classes
        #region SaslState
        public partial class SaslState
        {
            #region Constructors

            #endregion

            #region Class/Interface conversion operators

            #endregion

            #region Fields
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/security/authenticator/SaslClientAuthenticator.SaslState.html#CLIENT_COMPLETE"/>
            /// </summary>
            public static Org.Apache.Kafka.Common.Security.Authenticator.SaslClientAuthenticator.SaslState CLIENT_COMPLETE { get { return SGetField<Org.Apache.Kafka.Common.Security.Authenticator.SaslClientAuthenticator.SaslState>(LocalBridgeClazz, "CLIENT_COMPLETE"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/security/authenticator/SaslClientAuthenticator.SaslState.html#COMPLETE"/>
            /// </summary>
            public static Org.Apache.Kafka.Common.Security.Authenticator.SaslClientAuthenticator.SaslState COMPLETE { get { return SGetField<Org.Apache.Kafka.Common.Security.Authenticator.SaslClientAuthenticator.SaslState>(LocalBridgeClazz, "COMPLETE"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/security/authenticator/SaslClientAuthenticator.SaslState.html#FAILED"/>
            /// </summary>
            public static Org.Apache.Kafka.Common.Security.Authenticator.SaslClientAuthenticator.SaslState FAILED { get { return SGetField<Org.Apache.Kafka.Common.Security.Authenticator.SaslClientAuthenticator.SaslState>(LocalBridgeClazz, "FAILED"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/security/authenticator/SaslClientAuthenticator.SaslState.html#INITIAL"/>
            /// </summary>
            public static Org.Apache.Kafka.Common.Security.Authenticator.SaslClientAuthenticator.SaslState INITIAL { get { return SGetField<Org.Apache.Kafka.Common.Security.Authenticator.SaslClientAuthenticator.SaslState>(LocalBridgeClazz, "INITIAL"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/security/authenticator/SaslClientAuthenticator.SaslState.html#INTERMEDIATE"/>
            /// </summary>
            public static Org.Apache.Kafka.Common.Security.Authenticator.SaslClientAuthenticator.SaslState INTERMEDIATE { get { return SGetField<Org.Apache.Kafka.Common.Security.Authenticator.SaslClientAuthenticator.SaslState>(LocalBridgeClazz, "INTERMEDIATE"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/security/authenticator/SaslClientAuthenticator.SaslState.html#REAUTH_INITIAL"/>
            /// </summary>
            public static Org.Apache.Kafka.Common.Security.Authenticator.SaslClientAuthenticator.SaslState REAUTH_INITIAL { get { return SGetField<Org.Apache.Kafka.Common.Security.Authenticator.SaslClientAuthenticator.SaslState>(LocalBridgeClazz, "REAUTH_INITIAL"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/security/authenticator/SaslClientAuthenticator.SaslState.html#REAUTH_PROCESS_ORIG_APIVERSIONS_RESPONSE"/>
            /// </summary>
            public static Org.Apache.Kafka.Common.Security.Authenticator.SaslClientAuthenticator.SaslState REAUTH_PROCESS_ORIG_APIVERSIONS_RESPONSE { get { return SGetField<Org.Apache.Kafka.Common.Security.Authenticator.SaslClientAuthenticator.SaslState>(LocalBridgeClazz, "REAUTH_PROCESS_ORIG_APIVERSIONS_RESPONSE"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/security/authenticator/SaslClientAuthenticator.SaslState.html#REAUTH_RECEIVE_HANDSHAKE_OR_OTHER_RESPONSE"/>
            /// </summary>
            public static Org.Apache.Kafka.Common.Security.Authenticator.SaslClientAuthenticator.SaslState REAUTH_RECEIVE_HANDSHAKE_OR_OTHER_RESPONSE { get { return SGetField<Org.Apache.Kafka.Common.Security.Authenticator.SaslClientAuthenticator.SaslState>(LocalBridgeClazz, "REAUTH_RECEIVE_HANDSHAKE_OR_OTHER_RESPONSE"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/security/authenticator/SaslClientAuthenticator.SaslState.html#REAUTH_SEND_HANDSHAKE_REQUEST"/>
            /// </summary>
            public static Org.Apache.Kafka.Common.Security.Authenticator.SaslClientAuthenticator.SaslState REAUTH_SEND_HANDSHAKE_REQUEST { get { return SGetField<Org.Apache.Kafka.Common.Security.Authenticator.SaslClientAuthenticator.SaslState>(LocalBridgeClazz, "REAUTH_SEND_HANDSHAKE_REQUEST"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/security/authenticator/SaslClientAuthenticator.SaslState.html#RECEIVE_APIVERSIONS_RESPONSE"/>
            /// </summary>
            public static Org.Apache.Kafka.Common.Security.Authenticator.SaslClientAuthenticator.SaslState RECEIVE_APIVERSIONS_RESPONSE { get { return SGetField<Org.Apache.Kafka.Common.Security.Authenticator.SaslClientAuthenticator.SaslState>(LocalBridgeClazz, "RECEIVE_APIVERSIONS_RESPONSE"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/security/authenticator/SaslClientAuthenticator.SaslState.html#RECEIVE_HANDSHAKE_RESPONSE"/>
            /// </summary>
            public static Org.Apache.Kafka.Common.Security.Authenticator.SaslClientAuthenticator.SaslState RECEIVE_HANDSHAKE_RESPONSE { get { return SGetField<Org.Apache.Kafka.Common.Security.Authenticator.SaslClientAuthenticator.SaslState>(LocalBridgeClazz, "RECEIVE_HANDSHAKE_RESPONSE"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/security/authenticator/SaslClientAuthenticator.SaslState.html#SEND_APIVERSIONS_REQUEST"/>
            /// </summary>
            public static Org.Apache.Kafka.Common.Security.Authenticator.SaslClientAuthenticator.SaslState SEND_APIVERSIONS_REQUEST { get { return SGetField<Org.Apache.Kafka.Common.Security.Authenticator.SaslClientAuthenticator.SaslState>(LocalBridgeClazz, "SEND_APIVERSIONS_REQUEST"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/security/authenticator/SaslClientAuthenticator.SaslState.html#SEND_HANDSHAKE_REQUEST"/>
            /// </summary>
            public static Org.Apache.Kafka.Common.Security.Authenticator.SaslClientAuthenticator.SaslState SEND_HANDSHAKE_REQUEST { get { return SGetField<Org.Apache.Kafka.Common.Security.Authenticator.SaslClientAuthenticator.SaslState>(LocalBridgeClazz, "SEND_HANDSHAKE_REQUEST"); } }

            #endregion

            #region Static methods
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/security/authenticator/SaslClientAuthenticator.SaslState.html#valueOf-java.lang.String-"/>
            /// </summary>
            /// <param name="arg0"><see cref="string"/></param>
            /// <returns><see cref="Org.Apache.Kafka.Common.Security.Authenticator.SaslClientAuthenticator.SaslState"/></returns>
            public static Org.Apache.Kafka.Common.Security.Authenticator.SaslClientAuthenticator.SaslState ValueOf(string arg0)
            {
                return SExecute<Org.Apache.Kafka.Common.Security.Authenticator.SaslClientAuthenticator.SaslState>(LocalBridgeClazz, "valueOf", arg0);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/security/authenticator/SaslClientAuthenticator.SaslState.html#values--"/>
            /// </summary>

            /// <returns><see cref="Org.Apache.Kafka.Common.Security.Authenticator.SaslClientAuthenticator.SaslState"/></returns>
            public static Org.Apache.Kafka.Common.Security.Authenticator.SaslClientAuthenticator.SaslState[] Values()
            {
                return SExecuteArray<Org.Apache.Kafka.Common.Security.Authenticator.SaslClientAuthenticator.SaslState>(LocalBridgeClazz, "values");
            }

            #endregion

            #region Instance methods

            #endregion

            #region Nested classes

            #endregion

            // TODO: complete the class
        }
        #endregion

    
        #endregion

        // TODO: complete the class
    }
    #endregion
}