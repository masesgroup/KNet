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

namespace Org.Apache.Kafka.Common.Security.Authenticator
{
    #region LoginManager
    public partial class LoginManager
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/common/security/authenticator/LoginManager.html#acquireLoginManager-org.apache.kafka.common.security.JaasContext-java.lang.String-java.lang.Class-java.util.Map-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Security.JaasContext"/></param>
        /// <param name="arg1"><see cref="string"/></param>
        /// <param name="arg2"><see cref="Java.Lang.Class"/></param>
        /// <param name="arg3"><see cref="Java.Util.Map"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Common.Security.Authenticator.LoginManager"/></returns>
        /// <exception cref="Javax.Security.Auth.Login.LoginException"/>
        public static Org.Apache.Kafka.Common.Security.Authenticator.LoginManager AcquireLoginManager(Org.Apache.Kafka.Common.Security.JaasContext arg0, string arg1, Java.Lang.Class arg2, Java.Util.Map<string, object> arg3)
        {
            return SExecute<Org.Apache.Kafka.Common.Security.Authenticator.LoginManager>(LocalBridgeClazz, "acquireLoginManager", arg0, arg1, arg2, arg3);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/common/security/authenticator/LoginManager.html#closeAll--"/>
        /// </summary>
        public static void CloseAll()
        {
            SExecute(LocalBridgeClazz, "closeAll");
        }

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/common/security/authenticator/LoginManager.html#serviceName--"/>
        /// </summary>

        /// <returns><see cref="string"/></returns>
        public string ServiceName()
        {
            return IExecute<string>("serviceName");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/common/security/authenticator/LoginManager.html#subject--"/>
        /// </summary>

        /// <returns><see cref="Javax.Security.Auth.Subject"/></returns>
        public Javax.Security.Auth.Subject Subject()
        {
            return IExecute<Javax.Security.Auth.Subject>("subject");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/common/security/authenticator/LoginManager.html#release--"/>
        /// </summary>
        public void Release()
        {
            IExecute("release");
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}