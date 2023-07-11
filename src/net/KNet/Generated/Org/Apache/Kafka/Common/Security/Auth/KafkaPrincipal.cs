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

namespace Org.Apache.Kafka.Common.Security.Auth
{
    #region KafkaPrincipal
    public partial class KafkaPrincipal
    {
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/security/auth/KafkaPrincipal.html#org.apache.kafka.common.security.auth.KafkaPrincipal(java.lang.String,java.lang.String,boolean)"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="string"/></param>
        /// <param name="arg2"><see cref="bool"/></param>
        public KafkaPrincipal(string arg0, string arg1, bool arg2)
            : base(arg0, arg1, arg2)
        {
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/security/auth/KafkaPrincipal.html#org.apache.kafka.common.security.auth.KafkaPrincipal(java.lang.String,java.lang.String)"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="string"/></param>
        public KafkaPrincipal(string arg0, string arg1)
            : base(arg0, arg1)
        {
        }

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/security/auth/KafkaPrincipal.html#USER_TYPE"/>
        /// </summary>
        public static string USER_TYPE { get { return SGetField<string>(LocalBridgeClazz, "USER_TYPE"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/security/auth/KafkaPrincipal.html#ANONYMOUS"/>
        /// </summary>
        public static Org.Apache.Kafka.Common.Security.Auth.KafkaPrincipal ANONYMOUS { get { return SGetField<Org.Apache.Kafka.Common.Security.Auth.KafkaPrincipal>(LocalBridgeClazz, "ANONYMOUS"); } }

        #endregion

        #region Static methods

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/security/auth/KafkaPrincipal.html#getName--"/> 
        /// </summary>
        public string Name
        {
            get { return IExecute<string>("getName"); }
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/security/auth/KafkaPrincipal.html#getPrincipalType--"/> 
        /// </summary>
        public string PrincipalType
        {
            get { return IExecute<string>("getPrincipalType"); }
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/security/auth/KafkaPrincipal.html#tokenAuthenticated--"/>
        /// </summary>

        /// <returns><see cref="bool"/></returns>
        public bool TokenAuthenticated()
        {
            return IExecute<bool>("tokenAuthenticated");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/security/auth/KafkaPrincipal.html#tokenAuthenticated-boolean-"/>
        /// </summary>
        /// <param name="arg0"><see cref="bool"/></param>
        public void TokenAuthenticated(bool arg0)
        {
            IExecute("tokenAuthenticated", arg0);
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}