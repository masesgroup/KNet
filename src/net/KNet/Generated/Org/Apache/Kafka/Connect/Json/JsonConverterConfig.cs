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
*  This file is generated by MASES.JNetReflector (ver. 2.3.0.0)
*  using connect-json-3.6.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Connect.Json
{
    #region JsonConverterConfig
    public partial class JsonConverterConfig
    {
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-json/3.6.1/org/apache/kafka/connect/json/JsonConverterConfig.html#org.apache.kafka.connect.json.JsonConverterConfig(java.util.Map)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.Map"/></param>
        public JsonConverterConfig(Java.Util.Map<Java.Lang.String, object> arg0)
            : base(arg0)
        {
        }

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-json/3.6.1/org/apache/kafka/connect/json/JsonConverterConfig.html#REPLACE_NULL_WITH_DEFAULT_DEFAULT"/>
        /// </summary>
        public static bool REPLACE_NULL_WITH_DEFAULT_DEFAULT { get { if (!_REPLACE_NULL_WITH_DEFAULT_DEFAULTReady) { _REPLACE_NULL_WITH_DEFAULT_DEFAULTContent = SGetField<bool>(LocalBridgeClazz, "REPLACE_NULL_WITH_DEFAULT_DEFAULT"); _REPLACE_NULL_WITH_DEFAULT_DEFAULTReady = true; } return _REPLACE_NULL_WITH_DEFAULT_DEFAULTContent; } }
        private static bool _REPLACE_NULL_WITH_DEFAULT_DEFAULTContent = default;
        private static bool _REPLACE_NULL_WITH_DEFAULT_DEFAULTReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-json/3.6.1/org/apache/kafka/connect/json/JsonConverterConfig.html#SCHEMAS_ENABLE_DEFAULT"/>
        /// </summary>
        public static bool SCHEMAS_ENABLE_DEFAULT { get { if (!_SCHEMAS_ENABLE_DEFAULTReady) { _SCHEMAS_ENABLE_DEFAULTContent = SGetField<bool>(LocalBridgeClazz, "SCHEMAS_ENABLE_DEFAULT"); _SCHEMAS_ENABLE_DEFAULTReady = true; } return _SCHEMAS_ENABLE_DEFAULTContent; } }
        private static bool _SCHEMAS_ENABLE_DEFAULTContent = default;
        private static bool _SCHEMAS_ENABLE_DEFAULTReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-json/3.6.1/org/apache/kafka/connect/json/JsonConverterConfig.html#SCHEMAS_CACHE_SIZE_DEFAULT"/>
        /// </summary>
        public static int SCHEMAS_CACHE_SIZE_DEFAULT { get { if (!_SCHEMAS_CACHE_SIZE_DEFAULTReady) { _SCHEMAS_CACHE_SIZE_DEFAULTContent = SGetField<int>(LocalBridgeClazz, "SCHEMAS_CACHE_SIZE_DEFAULT"); _SCHEMAS_CACHE_SIZE_DEFAULTReady = true; } return _SCHEMAS_CACHE_SIZE_DEFAULTContent; } }
        private static int _SCHEMAS_CACHE_SIZE_DEFAULTContent = default;
        private static bool _SCHEMAS_CACHE_SIZE_DEFAULTReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-json/3.6.1/org/apache/kafka/connect/json/JsonConverterConfig.html#DECIMAL_FORMAT_CONFIG"/>
        /// </summary>
        public static Java.Lang.String DECIMAL_FORMAT_CONFIG { get { if (!_DECIMAL_FORMAT_CONFIGReady) { _DECIMAL_FORMAT_CONFIGContent = SGetField<Java.Lang.String>(LocalBridgeClazz, "DECIMAL_FORMAT_CONFIG"); _DECIMAL_FORMAT_CONFIGReady = true; } return _DECIMAL_FORMAT_CONFIGContent; } }
        private static Java.Lang.String _DECIMAL_FORMAT_CONFIGContent = default;
        private static bool _DECIMAL_FORMAT_CONFIGReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-json/3.6.1/org/apache/kafka/connect/json/JsonConverterConfig.html#DECIMAL_FORMAT_DEFAULT"/>
        /// </summary>
        public static Java.Lang.String DECIMAL_FORMAT_DEFAULT { get { if (!_DECIMAL_FORMAT_DEFAULTReady) { _DECIMAL_FORMAT_DEFAULTContent = SGetField<Java.Lang.String>(LocalBridgeClazz, "DECIMAL_FORMAT_DEFAULT"); _DECIMAL_FORMAT_DEFAULTReady = true; } return _DECIMAL_FORMAT_DEFAULTContent; } }
        private static Java.Lang.String _DECIMAL_FORMAT_DEFAULTContent = default;
        private static bool _DECIMAL_FORMAT_DEFAULTReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-json/3.6.1/org/apache/kafka/connect/json/JsonConverterConfig.html#REPLACE_NULL_WITH_DEFAULT_CONFIG"/>
        /// </summary>
        public static Java.Lang.String REPLACE_NULL_WITH_DEFAULT_CONFIG { get { if (!_REPLACE_NULL_WITH_DEFAULT_CONFIGReady) { _REPLACE_NULL_WITH_DEFAULT_CONFIGContent = SGetField<Java.Lang.String>(LocalBridgeClazz, "REPLACE_NULL_WITH_DEFAULT_CONFIG"); _REPLACE_NULL_WITH_DEFAULT_CONFIGReady = true; } return _REPLACE_NULL_WITH_DEFAULT_CONFIGContent; } }
        private static Java.Lang.String _REPLACE_NULL_WITH_DEFAULT_CONFIGContent = default;
        private static bool _REPLACE_NULL_WITH_DEFAULT_CONFIGReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-json/3.6.1/org/apache/kafka/connect/json/JsonConverterConfig.html#SCHEMAS_CACHE_SIZE_CONFIG"/>
        /// </summary>
        public static Java.Lang.String SCHEMAS_CACHE_SIZE_CONFIG { get { if (!_SCHEMAS_CACHE_SIZE_CONFIGReady) { _SCHEMAS_CACHE_SIZE_CONFIGContent = SGetField<Java.Lang.String>(LocalBridgeClazz, "SCHEMAS_CACHE_SIZE_CONFIG"); _SCHEMAS_CACHE_SIZE_CONFIGReady = true; } return _SCHEMAS_CACHE_SIZE_CONFIGContent; } }
        private static Java.Lang.String _SCHEMAS_CACHE_SIZE_CONFIGContent = default;
        private static bool _SCHEMAS_CACHE_SIZE_CONFIGReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-json/3.6.1/org/apache/kafka/connect/json/JsonConverterConfig.html#SCHEMAS_ENABLE_CONFIG"/>
        /// </summary>
        public static Java.Lang.String SCHEMAS_ENABLE_CONFIG { get { if (!_SCHEMAS_ENABLE_CONFIGReady) { _SCHEMAS_ENABLE_CONFIGContent = SGetField<Java.Lang.String>(LocalBridgeClazz, "SCHEMAS_ENABLE_CONFIG"); _SCHEMAS_ENABLE_CONFIGReady = true; } return _SCHEMAS_ENABLE_CONFIGContent; } }
        private static Java.Lang.String _SCHEMAS_ENABLE_CONFIGContent = default;
        private static bool _SCHEMAS_ENABLE_CONFIGReady = false; // this is used because in case of generics 

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-json/3.6.1/org/apache/kafka/connect/json/JsonConverterConfig.html#configDef--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.Config.ConfigDef"/></returns>
        public static Org.Apache.Kafka.Common.Config.ConfigDef ConfigDef()
        {
            return SExecute<Org.Apache.Kafka.Common.Config.ConfigDef>(LocalBridgeClazz, "configDef");
        }

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-json/3.6.1/org/apache/kafka/connect/json/JsonConverterConfig.html#replaceNullWithDefault--"/>
        /// </summary>

        /// <returns><see cref="bool"/></returns>
        public bool ReplaceNullWithDefault()
        {
            return IExecute<bool>("replaceNullWithDefault");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-json/3.6.1/org/apache/kafka/connect/json/JsonConverterConfig.html#schemasEnabled--"/>
        /// </summary>

        /// <returns><see cref="bool"/></returns>
        public bool SchemasEnabled()
        {
            return IExecute<bool>("schemasEnabled");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-json/3.6.1/org/apache/kafka/connect/json/JsonConverterConfig.html#schemaCacheSize--"/>
        /// </summary>

        /// <returns><see cref="int"/></returns>
        public int SchemaCacheSize()
        {
            return IExecute<int>("schemaCacheSize");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-json/3.6.1/org/apache/kafka/connect/json/JsonConverterConfig.html#decimalFormat--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Connect.Json.DecimalFormat"/></returns>
        public Org.Apache.Kafka.Connect.Json.DecimalFormat DecimalFormat()
        {
            return IExecute<Org.Apache.Kafka.Connect.Json.DecimalFormat>("decimalFormat");
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}