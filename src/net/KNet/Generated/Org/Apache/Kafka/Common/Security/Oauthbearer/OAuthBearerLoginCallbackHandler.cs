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
*  This file is generated by MASES.JNetReflector (ver. 2.1.0.0)
*  using kafka-clients-3.6.0.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Common.Security.Oauthbearer
{
    #region OAuthBearerLoginCallbackHandler
    public partial class OAuthBearerLoginCallbackHandler
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/common/security/oauthbearer/OAuthBearerLoginCallbackHandler.html#CLIENT_ID_CONFIG"/>
        /// </summary>
        public static string CLIENT_ID_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "CLIENT_ID_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/common/security/oauthbearer/OAuthBearerLoginCallbackHandler.html#CLIENT_ID_DOC"/>
        /// </summary>
        public static string CLIENT_ID_DOC { get { return SGetField<string>(LocalBridgeClazz, "CLIENT_ID_DOC"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/common/security/oauthbearer/OAuthBearerLoginCallbackHandler.html#CLIENT_SECRET_CONFIG"/>
        /// </summary>
        public static string CLIENT_SECRET_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "CLIENT_SECRET_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/common/security/oauthbearer/OAuthBearerLoginCallbackHandler.html#CLIENT_SECRET_DOC"/>
        /// </summary>
        public static string CLIENT_SECRET_DOC { get { return SGetField<string>(LocalBridgeClazz, "CLIENT_SECRET_DOC"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/common/security/oauthbearer/OAuthBearerLoginCallbackHandler.html#SCOPE_CONFIG"/>
        /// </summary>
        public static string SCOPE_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "SCOPE_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/common/security/oauthbearer/OAuthBearerLoginCallbackHandler.html#SCOPE_DOC"/>
        /// </summary>
        public static string SCOPE_DOC { get { return SGetField<string>(LocalBridgeClazz, "SCOPE_DOC"); } }

        #endregion

        #region Static methods

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/common/security/oauthbearer/OAuthBearerLoginCallbackHandler.html#close--"/>
        /// </summary>
        public void Close()
        {
            IExecute("close");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/common/security/oauthbearer/OAuthBearerLoginCallbackHandler.html#configure-java.util.Map-java.lang.String-java.util.List-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.Map"/></param>
        /// <param name="arg1"><see cref="string"/></param>
        /// <param name="arg2"><see cref="Java.Util.List"/></param>
        public void Configure(Java.Util.Map<string, object> arg0, string arg1, Java.Util.List<Javax.Security.Auth.Login.AppConfigurationEntry> arg2)
        {
            IExecute("configure", arg0, arg1, arg2);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/common/security/oauthbearer/OAuthBearerLoginCallbackHandler.html#handle-javax.security.auth.callback.Callback[]-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Javax.Security.Auth.Callback.Callback"/></param>
        /// <exception cref="Java.Io.IOException"/>
        /// <exception cref="Javax.Security.Auth.Callback.UnsupportedCallbackException"/>
        public void Handle(Javax.Security.Auth.Callback.Callback[] arg0)
        {
            IExecute("handle", new object[] { arg0 });
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}