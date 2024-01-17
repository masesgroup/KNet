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
*  This file is generated by MASES.JNetReflector (ver. 2.2.0.0)
*  using connect-basic-auth-extension-3.6.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Connect.Rest.Basic.Auth.Extension
{
    #region JaasBasicAuthFilter
    public partial class JaasBasicAuthFilter
    {
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-basic-auth-extension/3.6.1/org/apache/kafka/connect/rest/basic/auth/extension/JaasBasicAuthFilter.html#org.apache.kafka.connect.rest.basic.auth.extension.JaasBasicAuthFilter(javax.security.auth.login.Configuration)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Javax.Security.Auth.Login.Configuration"/></param>
        public JaasBasicAuthFilter(Javax.Security.Auth.Login.Configuration arg0)
            : base(arg0)
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

        #endregion

        #region Nested classes
        #region BasicAuthCallBackHandler
        public partial class BasicAuthCallBackHandler
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
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-basic-auth-extension/3.6.1/org/apache/kafka/connect/rest/basic/auth/extension/JaasBasicAuthFilter.BasicAuthCallBackHandler.html#handle-javax.security.auth.callback.Callback[]-"/>
            /// </summary>
            /// <param name="arg0"><see cref="Javax.Security.Auth.Callback.Callback"/></param>
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

    
        #endregion

        // TODO: complete the class
    }
    #endregion
}