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
*  using connect-runtime-3.6.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Connect.Util
{
    #region LoggingContext
    public partial class LoggingContext
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-runtime/3.6.1/org/apache/kafka/connect/util/LoggingContext.html#CONNECTOR_CONTEXT"/>
        /// </summary>
        public static string CONNECTOR_CONTEXT { get { return SGetField<string>(LocalBridgeClazz, "CONNECTOR_CONTEXT"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-runtime/3.6.1/org/apache/kafka/connect/util/LoggingContext.html#ALL_CONTEXTS"/>
        /// </summary>
        public static Java.Util.Collection ALL_CONTEXTS { get { return SGetField<Java.Util.Collection>(LocalBridgeClazz, "ALL_CONTEXTS"); } }

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-runtime/3.6.1/org/apache/kafka/connect/util/LoggingContext.html#forConnector-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Connect.Util.LoggingContext"/></returns>
        public static Org.Apache.Kafka.Connect.Util.LoggingContext ForConnector(string arg0)
        {
            return SExecute<Org.Apache.Kafka.Connect.Util.LoggingContext>(LocalBridgeClazz, "forConnector", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-runtime/3.6.1/org/apache/kafka/connect/util/LoggingContext.html#forOffsets-org.apache.kafka.connect.util.ConnectorTaskId-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Connect.Util.ConnectorTaskId"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Connect.Util.LoggingContext"/></returns>
        public static Org.Apache.Kafka.Connect.Util.LoggingContext ForOffsets(Org.Apache.Kafka.Connect.Util.ConnectorTaskId arg0)
        {
            return SExecute<Org.Apache.Kafka.Connect.Util.LoggingContext>(LocalBridgeClazz, "forOffsets", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-runtime/3.6.1/org/apache/kafka/connect/util/LoggingContext.html#forTask-org.apache.kafka.connect.util.ConnectorTaskId-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Connect.Util.ConnectorTaskId"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Connect.Util.LoggingContext"/></returns>
        public static Org.Apache.Kafka.Connect.Util.LoggingContext ForTask(Org.Apache.Kafka.Connect.Util.ConnectorTaskId arg0)
        {
            return SExecute<Org.Apache.Kafka.Connect.Util.LoggingContext>(LocalBridgeClazz, "forTask", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-runtime/3.6.1/org/apache/kafka/connect/util/LoggingContext.html#forValidation-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Connect.Util.LoggingContext"/></returns>
        public static Org.Apache.Kafka.Connect.Util.LoggingContext ForValidation(string arg0)
        {
            return SExecute<Org.Apache.Kafka.Connect.Util.LoggingContext>(LocalBridgeClazz, "forValidation", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-runtime/3.6.1/org/apache/kafka/connect/util/LoggingContext.html#clear--"/>
        /// </summary>
        public static void Clear()
        {
            SExecute(LocalBridgeClazz, "clear");
        }

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-runtime/3.6.1/org/apache/kafka/connect/util/LoggingContext.html#close--"/>
        /// </summary>
        public void Close()
        {
            IExecute("close");
        }

        #endregion

        #region Nested classes
        #region Scope
        public partial class Scope
        {
            #region Constructors

            #endregion

            #region Class/Interface conversion operators

            #endregion

            #region Fields
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-runtime/3.6.1/org/apache/kafka/connect/util/LoggingContext.Scope.html#OFFSETS"/>
            /// </summary>
            public static Org.Apache.Kafka.Connect.Util.LoggingContext.Scope OFFSETS { get { return SGetField<Org.Apache.Kafka.Connect.Util.LoggingContext.Scope>(LocalBridgeClazz, "OFFSETS"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-runtime/3.6.1/org/apache/kafka/connect/util/LoggingContext.Scope.html#TASK"/>
            /// </summary>
            public static Org.Apache.Kafka.Connect.Util.LoggingContext.Scope TASK { get { return SGetField<Org.Apache.Kafka.Connect.Util.LoggingContext.Scope>(LocalBridgeClazz, "TASK"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-runtime/3.6.1/org/apache/kafka/connect/util/LoggingContext.Scope.html#VALIDATE"/>
            /// </summary>
            public static Org.Apache.Kafka.Connect.Util.LoggingContext.Scope VALIDATE { get { return SGetField<Org.Apache.Kafka.Connect.Util.LoggingContext.Scope>(LocalBridgeClazz, "VALIDATE"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-runtime/3.6.1/org/apache/kafka/connect/util/LoggingContext.Scope.html#WORKER"/>
            /// </summary>
            public static Org.Apache.Kafka.Connect.Util.LoggingContext.Scope WORKER { get { return SGetField<Org.Apache.Kafka.Connect.Util.LoggingContext.Scope>(LocalBridgeClazz, "WORKER"); } }

            #endregion

            #region Static methods
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-runtime/3.6.1/org/apache/kafka/connect/util/LoggingContext.Scope.html#valueOf-java.lang.String-"/>
            /// </summary>
            /// <param name="arg0"><see cref="string"/></param>
            /// <returns><see cref="Org.Apache.Kafka.Connect.Util.LoggingContext.Scope"/></returns>
            public static Org.Apache.Kafka.Connect.Util.LoggingContext.Scope ValueOf(string arg0)
            {
                return SExecute<Org.Apache.Kafka.Connect.Util.LoggingContext.Scope>(LocalBridgeClazz, "valueOf", arg0);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-runtime/3.6.1/org/apache/kafka/connect/util/LoggingContext.Scope.html#values--"/>
            /// </summary>

            /// <returns><see cref="Org.Apache.Kafka.Connect.Util.LoggingContext.Scope"/></returns>
            public static Org.Apache.Kafka.Connect.Util.LoggingContext.Scope[] Values()
            {
                return SExecuteArray<Org.Apache.Kafka.Connect.Util.LoggingContext.Scope>(LocalBridgeClazz, "values");
            }

            #endregion

            #region Instance methods

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