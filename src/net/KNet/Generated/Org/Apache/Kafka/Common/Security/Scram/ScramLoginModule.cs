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
*  This file is generated by MASES.JNetReflector (ver. 1.5.5.0)
*  using kafka-clients-3.4.0.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Common.Security.Scram
{
    #region ScramLoginModule
    public partial class ScramLoginModule
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators
        /// <summary>
        /// Converter from <see cref="Org.Apache.Kafka.Common.Security.Scram.ScramLoginModule"/> to <see cref="Javax.Security.Auth.Spi.LoginModule"/>
        /// </summary>
        public static implicit operator Javax.Security.Auth.Spi.LoginModule(Org.Apache.Kafka.Common.Security.Scram.ScramLoginModule t) => t.Cast<Javax.Security.Auth.Spi.LoginModule>();

        #endregion

        #region Fields
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/security/scram/ScramLoginModule.html#TOKEN_AUTH_CONFIG"/>
        /// </summary>
        public static string TOKEN_AUTH_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "TOKEN_AUTH_CONFIG"); } }

        #endregion

        #region Static methods

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/security/scram/ScramLoginModule.html#abort()"/>
        /// </summary>

        /// <returns><see cref="bool"/></returns>
        public bool Abort()
        {
            return IExecute<bool>("abort");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/security/scram/ScramLoginModule.html#commit()"/>
        /// </summary>

        /// <returns><see cref="bool"/></returns>
        public bool Commit()
        {
            return IExecute<bool>("commit");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/security/scram/ScramLoginModule.html#login()"/>
        /// </summary>

        /// <returns><see cref="bool"/></returns>
        public bool Login()
        {
            return IExecute<bool>("login");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/security/scram/ScramLoginModule.html#logout()"/>
        /// </summary>

        /// <returns><see cref="bool"/></returns>
        public bool Logout()
        {
            return IExecute<bool>("logout");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/security/scram/ScramLoginModule.html#initialize(javax.security.auth.Subject,javax.security.auth.callback.CallbackHandler,java.util.Map,java.util.Map)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Javax.Security.Auth.Subject"/></param>
        /// <param name="arg1"><see cref="Javax.Security.Auth.Callback.CallbackHandler"/></param>
        /// <param name="arg2"><see cref="Java.Util.Map"/></param>
        /// <param name="arg3"><see cref="Java.Util.Map"/></param>
        /// <typeparam name="Arg2Extendsobject"></typeparam>
        /// <typeparam name="Arg3Extendsobject"></typeparam>
        public void Initialize<Arg2Extendsobject, Arg3Extendsobject>(Javax.Security.Auth.Subject arg0, Javax.Security.Auth.Callback.CallbackHandler arg1, Java.Util.Map<string, Arg2Extendsobject> arg2, Java.Util.Map<string, Arg3Extendsobject> arg3)
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