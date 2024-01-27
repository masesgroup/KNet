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
*  This file is generated by MASES.JNetReflector (ver. 2.2.4.0)
*  using connect-mirror-3.6.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Connect.Mirror
{
    #region DefaultConfigPropertyFilter
    public partial class DefaultConfigPropertyFilter
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/DefaultConfigPropertyFilter.html#CONFIG_PROPERTIES_EXCLUDE_ALIAS_CONFIG"/>
        /// </summary>
        public static string CONFIG_PROPERTIES_EXCLUDE_ALIAS_CONFIG { get { if (!_CONFIG_PROPERTIES_EXCLUDE_ALIAS_CONFIGReady) { _CONFIG_PROPERTIES_EXCLUDE_ALIAS_CONFIGContent = SGetField<string>(LocalBridgeClazz, "CONFIG_PROPERTIES_EXCLUDE_ALIAS_CONFIG"); _CONFIG_PROPERTIES_EXCLUDE_ALIAS_CONFIGReady = true; } return _CONFIG_PROPERTIES_EXCLUDE_ALIAS_CONFIGContent; } }
        private static string _CONFIG_PROPERTIES_EXCLUDE_ALIAS_CONFIGContent = default;
        private static bool _CONFIG_PROPERTIES_EXCLUDE_ALIAS_CONFIGReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/DefaultConfigPropertyFilter.html#CONFIG_PROPERTIES_EXCLUDE_CONFIG"/>
        /// </summary>
        public static string CONFIG_PROPERTIES_EXCLUDE_CONFIG { get { if (!_CONFIG_PROPERTIES_EXCLUDE_CONFIGReady) { _CONFIG_PROPERTIES_EXCLUDE_CONFIGContent = SGetField<string>(LocalBridgeClazz, "CONFIG_PROPERTIES_EXCLUDE_CONFIG"); _CONFIG_PROPERTIES_EXCLUDE_CONFIGReady = true; } return _CONFIG_PROPERTIES_EXCLUDE_CONFIGContent; } }
        private static string _CONFIG_PROPERTIES_EXCLUDE_CONFIGContent = default;
        private static bool _CONFIG_PROPERTIES_EXCLUDE_CONFIGReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/DefaultConfigPropertyFilter.html#CONFIG_PROPERTIES_EXCLUDE_DEFAULT"/>
        /// </summary>
        public static string CONFIG_PROPERTIES_EXCLUDE_DEFAULT { get { if (!_CONFIG_PROPERTIES_EXCLUDE_DEFAULTReady) { _CONFIG_PROPERTIES_EXCLUDE_DEFAULTContent = SGetField<string>(LocalBridgeClazz, "CONFIG_PROPERTIES_EXCLUDE_DEFAULT"); _CONFIG_PROPERTIES_EXCLUDE_DEFAULTReady = true; } return _CONFIG_PROPERTIES_EXCLUDE_DEFAULTContent; } }
        private static string _CONFIG_PROPERTIES_EXCLUDE_DEFAULTContent = default;
        private static bool _CONFIG_PROPERTIES_EXCLUDE_DEFAULTReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/DefaultConfigPropertyFilter.html#USE_DEFAULTS_FROM"/>
        /// </summary>
        public static string USE_DEFAULTS_FROM { get { if (!_USE_DEFAULTS_FROMReady) { _USE_DEFAULTS_FROMContent = SGetField<string>(LocalBridgeClazz, "USE_DEFAULTS_FROM"); _USE_DEFAULTS_FROMReady = true; } return _USE_DEFAULTS_FROMContent; } }
        private static string _USE_DEFAULTS_FROMContent = default;
        private static bool _USE_DEFAULTS_FROMReady = false; // this is used because in case of generics 

        #endregion

        #region Static methods

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/DefaultConfigPropertyFilter.html#shouldReplicateConfigProperty-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="bool"/></returns>
        public bool ShouldReplicateConfigProperty(string arg0)
        {
            return IExecute<bool>("shouldReplicateConfigProperty", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/DefaultConfigPropertyFilter.html#shouldReplicateSourceDefault-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="bool"/></returns>
        public bool ShouldReplicateSourceDefault(string arg0)
        {
            return IExecute<bool>("shouldReplicateSourceDefault", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/DefaultConfigPropertyFilter.html#configure-java.util.Map-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.Map"/></param>
        public void Configure(Java.Util.Map<string, object> arg0)
        {
            IExecute("configure", arg0);
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}