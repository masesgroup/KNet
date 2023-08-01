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

namespace Org.Apache.Kafka.Common.Utils
{
    #region ConfigUtils
    public partial class ConfigUtils
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/common/utils/ConfigUtils.html#translateDeprecatedConfigs-java.util.Map-java.lang.String[][]-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.Map"/></param>
        /// <param name="arg1"><see cref="string"/></param>
        /// <typeparam name="T"></typeparam>
        /// <returns><see cref="Java.Util.Map"/></returns>
        public static Java.Util.Map<string, T> TranslateDeprecatedConfigs<T>(Java.Util.Map<string, T> arg0, string[][] arg1)
        {
            return SExecute<Java.Util.Map<string, T>>(LocalBridgeClazz, "translateDeprecatedConfigs", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/common/utils/ConfigUtils.html#translateDeprecatedConfigs-java.util.Map-java.util.Map-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.Map"/></param>
        /// <param name="arg1"><see cref="Java.Util.Map"/></param>
        /// <typeparam name="T"></typeparam>
        /// <returns><see cref="Java.Util.Map"/></returns>
        public static Java.Util.Map<string, T> TranslateDeprecatedConfigs<T>(Java.Util.Map<string, T> arg0, Java.Util.Map<string, Java.Util.List<string>> arg1)
        {
            return SExecute<Java.Util.Map<string, T>>(LocalBridgeClazz, "translateDeprecatedConfigs", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/common/utils/ConfigUtils.html#configMapToRedactedString-java.util.Map-org.apache.kafka.common.config.ConfigDef-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.Map"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Common.Config.ConfigDef"/></param>
        /// <returns><see cref="string"/></returns>
        public static string ConfigMapToRedactedString(Java.Util.Map<string, object> arg0, Org.Apache.Kafka.Common.Config.ConfigDef arg1)
        {
            return SExecute<string>(LocalBridgeClazz, "configMapToRedactedString", arg0, arg1);
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