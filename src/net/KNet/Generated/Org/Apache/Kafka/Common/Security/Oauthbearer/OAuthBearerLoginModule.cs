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
*  using kafka-clients-3.5.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Common.Security.Oauthbearer
{
    #region OAuthBearerLoginModule
    public partial class OAuthBearerLoginModule
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/common/security/oauthbearer/OAuthBearerLoginModule.html#OAUTHBEARER_MECHANISM"/>
        /// </summary>
        public static string OAUTHBEARER_MECHANISM { get { return SGetField<string>(LocalBridgeClazz, "OAUTHBEARER_MECHANISM"); } }

        #endregion

        #region Static methods

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/common/security/oauthbearer/OAuthBearerLoginModule.html#abort--"/>
        /// </summary>

        /// <returns><see cref="bool"/></returns>
        public bool Abort()
        {
            return IExecute<bool>("abort");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/common/security/oauthbearer/OAuthBearerLoginModule.html#commit--"/>
        /// </summary>

        /// <returns><see cref="bool"/></returns>
        public bool Commit()
        {
            return IExecute<bool>("commit");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/common/security/oauthbearer/OAuthBearerLoginModule.html#login--"/>
        /// </summary>

        /// <returns><see cref="bool"/></returns>
        /// <exception cref="Javax.Security.Auth.Login.LoginException"/>
        public bool Login()
        {
            return IExecute<bool>("login");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/common/security/oauthbearer/OAuthBearerLoginModule.html#logout--"/>
        /// </summary>

        /// <returns><see cref="bool"/></returns>
        public bool Logout()
        {
            return IExecute<bool>("logout");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/common/security/oauthbearer/OAuthBearerLoginModule.html#initialize-javax.security.auth.Subject-javax.security.auth.callback.CallbackHandler-java.util.Map-java.util.Map-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Javax.Security.Auth.Subject"/></param>
        /// <param name="arg1"><see cref="Javax.Security.Auth.Callback.CallbackHandler"/></param>
        /// <param name="arg2"><see cref="Java.Util.Map"/></param>
        /// <param name="arg3"><see cref="Java.Util.Map"/></param>
        public void Initialize(Javax.Security.Auth.Subject arg0, Javax.Security.Auth.Callback.CallbackHandler arg1, Java.Util.Map<string, object> arg2, Java.Util.Map<string, object> arg3)
        {
            IExecute("initialize", arg0, arg1, arg2, arg3);
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}