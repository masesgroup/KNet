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
*  This file is generated by MASES.JNetReflector (ver. 2.1.0.0)
*  using connect-api-3.6.0.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Connect.Source
{
    #region ExactlyOnceSupport
    public partial class ExactlyOnceSupport
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.6.0/org/apache/kafka/connect/source/ExactlyOnceSupport.html#SUPPORTED"/>
        /// </summary>
        public static Org.Apache.Kafka.Connect.Source.ExactlyOnceSupport SUPPORTED { get { return SGetField<Org.Apache.Kafka.Connect.Source.ExactlyOnceSupport>(LocalBridgeClazz, "SUPPORTED"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.6.0/org/apache/kafka/connect/source/ExactlyOnceSupport.html#UNSUPPORTED"/>
        /// </summary>
        public static Org.Apache.Kafka.Connect.Source.ExactlyOnceSupport UNSUPPORTED { get { return SGetField<Org.Apache.Kafka.Connect.Source.ExactlyOnceSupport>(LocalBridgeClazz, "UNSUPPORTED"); } }

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.6.0/org/apache/kafka/connect/source/ExactlyOnceSupport.html#valueOf-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Connect.Source.ExactlyOnceSupport"/></returns>
        public static Org.Apache.Kafka.Connect.Source.ExactlyOnceSupport ValueOf(string arg0)
        {
            return SExecute<Org.Apache.Kafka.Connect.Source.ExactlyOnceSupport>(LocalBridgeClazz, "valueOf", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.6.0/org/apache/kafka/connect/source/ExactlyOnceSupport.html#values--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Connect.Source.ExactlyOnceSupport"/></returns>
        public static Org.Apache.Kafka.Connect.Source.ExactlyOnceSupport[] Values()
        {
            return SExecuteArray<Org.Apache.Kafka.Connect.Source.ExactlyOnceSupport>(LocalBridgeClazz, "values");
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