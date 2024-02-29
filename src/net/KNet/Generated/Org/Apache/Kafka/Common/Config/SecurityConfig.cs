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
*  This file is generated by MASES.JNetReflector (ver. 2.4.0.0)
*  using kafka-clients-3.6.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Common.Config
{
    #region SecurityConfig
    public partial class SecurityConfig
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/config/SecurityConfig.html#SECURITY_PROVIDERS_CONFIG"/>
        /// </summary>
        public static Java.Lang.String SECURITY_PROVIDERS_CONFIG { get { if (!_SECURITY_PROVIDERS_CONFIGReady) { _SECURITY_PROVIDERS_CONFIGContent = SGetField<Java.Lang.String>(LocalBridgeClazz, "SECURITY_PROVIDERS_CONFIG"); _SECURITY_PROVIDERS_CONFIGReady = true; } return _SECURITY_PROVIDERS_CONFIGContent; } }
        private static Java.Lang.String _SECURITY_PROVIDERS_CONFIGContent = default;
        private static bool _SECURITY_PROVIDERS_CONFIGReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/config/SecurityConfig.html#SECURITY_PROVIDERS_DOC"/>
        /// </summary>
        public static Java.Lang.String SECURITY_PROVIDERS_DOC { get { if (!_SECURITY_PROVIDERS_DOCReady) { _SECURITY_PROVIDERS_DOCContent = SGetField<Java.Lang.String>(LocalBridgeClazz, "SECURITY_PROVIDERS_DOC"); _SECURITY_PROVIDERS_DOCReady = true; } return _SECURITY_PROVIDERS_DOCContent; } }
        private static Java.Lang.String _SECURITY_PROVIDERS_DOCContent = default;
        private static bool _SECURITY_PROVIDERS_DOCReady = false; // this is used because in case of generics 

        #endregion

        #region Static methods

        #endregion

        #region Instance methods

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}