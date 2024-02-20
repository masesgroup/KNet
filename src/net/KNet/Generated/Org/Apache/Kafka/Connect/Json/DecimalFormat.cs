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
*  This file is generated by MASES.JNetReflector (ver. 2.2.5.0)
*  using connect-json-3.6.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Connect.Json
{
    #region DecimalFormat
    public partial class DecimalFormat
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-json/3.6.1/org/apache/kafka/connect/json/DecimalFormat.html#BASE64"/>
        /// </summary>
        public static Org.Apache.Kafka.Connect.Json.DecimalFormat BASE64 { get { if (!_BASE64Ready) { _BASE64Content = SGetField<Org.Apache.Kafka.Connect.Json.DecimalFormat>(LocalBridgeClazz, "BASE64"); _BASE64Ready = true; } return _BASE64Content; } }
        private static Org.Apache.Kafka.Connect.Json.DecimalFormat _BASE64Content = default;
        private static bool _BASE64Ready = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-json/3.6.1/org/apache/kafka/connect/json/DecimalFormat.html#NUMERIC"/>
        /// </summary>
        public static Org.Apache.Kafka.Connect.Json.DecimalFormat NUMERIC { get { if (!_NUMERICReady) { _NUMERICContent = SGetField<Org.Apache.Kafka.Connect.Json.DecimalFormat>(LocalBridgeClazz, "NUMERIC"); _NUMERICReady = true; } return _NUMERICContent; } }
        private static Org.Apache.Kafka.Connect.Json.DecimalFormat _NUMERICContent = default;
        private static bool _NUMERICReady = false; // this is used because in case of generics 

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-json/3.6.1/org/apache/kafka/connect/json/DecimalFormat.html#valueOf-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.String"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Connect.Json.DecimalFormat"/></returns>
        public static Org.Apache.Kafka.Connect.Json.DecimalFormat ValueOf(Java.Lang.String arg0)
        {
            return SExecute<Org.Apache.Kafka.Connect.Json.DecimalFormat>(LocalBridgeClazz, "valueOf", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-json/3.6.1/org/apache/kafka/connect/json/DecimalFormat.html#values--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Connect.Json.DecimalFormat"/></returns>
        public static Org.Apache.Kafka.Connect.Json.DecimalFormat[] Values()
        {
            return SExecuteArray<Org.Apache.Kafka.Connect.Json.DecimalFormat>(LocalBridgeClazz, "values");
        }

        #endregion

        #region Instance methods

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}