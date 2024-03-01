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
*  using kafka-clients-3.7.0.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Common.Telemetry
{
    #region ClientTelemetryState
    public partial class ClientTelemetryState
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/telemetry/ClientTelemetryState.html#PUSH_IN_PROGRESS"/>
        /// </summary>
        public static Org.Apache.Kafka.Common.Telemetry.ClientTelemetryState PUSH_IN_PROGRESS { get { if (!_PUSH_IN_PROGRESSReady) { _PUSH_IN_PROGRESSContent = SGetField<Org.Apache.Kafka.Common.Telemetry.ClientTelemetryState>(LocalBridgeClazz, "PUSH_IN_PROGRESS"); _PUSH_IN_PROGRESSReady = true; } return _PUSH_IN_PROGRESSContent; } }
        private static Org.Apache.Kafka.Common.Telemetry.ClientTelemetryState _PUSH_IN_PROGRESSContent = default;
        private static bool _PUSH_IN_PROGRESSReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/telemetry/ClientTelemetryState.html#PUSH_NEEDED"/>
        /// </summary>
        public static Org.Apache.Kafka.Common.Telemetry.ClientTelemetryState PUSH_NEEDED { get { if (!_PUSH_NEEDEDReady) { _PUSH_NEEDEDContent = SGetField<Org.Apache.Kafka.Common.Telemetry.ClientTelemetryState>(LocalBridgeClazz, "PUSH_NEEDED"); _PUSH_NEEDEDReady = true; } return _PUSH_NEEDEDContent; } }
        private static Org.Apache.Kafka.Common.Telemetry.ClientTelemetryState _PUSH_NEEDEDContent = default;
        private static bool _PUSH_NEEDEDReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/telemetry/ClientTelemetryState.html#SUBSCRIPTION_IN_PROGRESS"/>
        /// </summary>
        public static Org.Apache.Kafka.Common.Telemetry.ClientTelemetryState SUBSCRIPTION_IN_PROGRESS { get { if (!_SUBSCRIPTION_IN_PROGRESSReady) { _SUBSCRIPTION_IN_PROGRESSContent = SGetField<Org.Apache.Kafka.Common.Telemetry.ClientTelemetryState>(LocalBridgeClazz, "SUBSCRIPTION_IN_PROGRESS"); _SUBSCRIPTION_IN_PROGRESSReady = true; } return _SUBSCRIPTION_IN_PROGRESSContent; } }
        private static Org.Apache.Kafka.Common.Telemetry.ClientTelemetryState _SUBSCRIPTION_IN_PROGRESSContent = default;
        private static bool _SUBSCRIPTION_IN_PROGRESSReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/telemetry/ClientTelemetryState.html#SUBSCRIPTION_NEEDED"/>
        /// </summary>
        public static Org.Apache.Kafka.Common.Telemetry.ClientTelemetryState SUBSCRIPTION_NEEDED { get { if (!_SUBSCRIPTION_NEEDEDReady) { _SUBSCRIPTION_NEEDEDContent = SGetField<Org.Apache.Kafka.Common.Telemetry.ClientTelemetryState>(LocalBridgeClazz, "SUBSCRIPTION_NEEDED"); _SUBSCRIPTION_NEEDEDReady = true; } return _SUBSCRIPTION_NEEDEDContent; } }
        private static Org.Apache.Kafka.Common.Telemetry.ClientTelemetryState _SUBSCRIPTION_NEEDEDContent = default;
        private static bool _SUBSCRIPTION_NEEDEDReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/telemetry/ClientTelemetryState.html#TERMINATED"/>
        /// </summary>
        public static Org.Apache.Kafka.Common.Telemetry.ClientTelemetryState TERMINATED { get { if (!_TERMINATEDReady) { _TERMINATEDContent = SGetField<Org.Apache.Kafka.Common.Telemetry.ClientTelemetryState>(LocalBridgeClazz, "TERMINATED"); _TERMINATEDReady = true; } return _TERMINATEDContent; } }
        private static Org.Apache.Kafka.Common.Telemetry.ClientTelemetryState _TERMINATEDContent = default;
        private static bool _TERMINATEDReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/telemetry/ClientTelemetryState.html#TERMINATING_PUSH_IN_PROGRESS"/>
        /// </summary>
        public static Org.Apache.Kafka.Common.Telemetry.ClientTelemetryState TERMINATING_PUSH_IN_PROGRESS { get { if (!_TERMINATING_PUSH_IN_PROGRESSReady) { _TERMINATING_PUSH_IN_PROGRESSContent = SGetField<Org.Apache.Kafka.Common.Telemetry.ClientTelemetryState>(LocalBridgeClazz, "TERMINATING_PUSH_IN_PROGRESS"); _TERMINATING_PUSH_IN_PROGRESSReady = true; } return _TERMINATING_PUSH_IN_PROGRESSContent; } }
        private static Org.Apache.Kafka.Common.Telemetry.ClientTelemetryState _TERMINATING_PUSH_IN_PROGRESSContent = default;
        private static bool _TERMINATING_PUSH_IN_PROGRESSReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/telemetry/ClientTelemetryState.html#TERMINATING_PUSH_NEEDED"/>
        /// </summary>
        public static Org.Apache.Kafka.Common.Telemetry.ClientTelemetryState TERMINATING_PUSH_NEEDED { get { if (!_TERMINATING_PUSH_NEEDEDReady) { _TERMINATING_PUSH_NEEDEDContent = SGetField<Org.Apache.Kafka.Common.Telemetry.ClientTelemetryState>(LocalBridgeClazz, "TERMINATING_PUSH_NEEDED"); _TERMINATING_PUSH_NEEDEDReady = true; } return _TERMINATING_PUSH_NEEDEDContent; } }
        private static Org.Apache.Kafka.Common.Telemetry.ClientTelemetryState _TERMINATING_PUSH_NEEDEDContent = default;
        private static bool _TERMINATING_PUSH_NEEDEDReady = false; // this is used because in case of generics 

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/telemetry/ClientTelemetryState.html#valueOf-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.String"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Common.Telemetry.ClientTelemetryState"/></returns>
        public static Org.Apache.Kafka.Common.Telemetry.ClientTelemetryState ValueOf(Java.Lang.String arg0)
        {
            return SExecuteWithSignature<Org.Apache.Kafka.Common.Telemetry.ClientTelemetryState>(LocalBridgeClazz, "valueOf", "(Ljava/lang/String;)Lorg/apache/kafka/common/telemetry/ClientTelemetryState;", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/telemetry/ClientTelemetryState.html#values--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.Telemetry.ClientTelemetryState"/></returns>
        public static Org.Apache.Kafka.Common.Telemetry.ClientTelemetryState[] Values()
        {
            return SExecuteWithSignatureArray<Org.Apache.Kafka.Common.Telemetry.ClientTelemetryState>(LocalBridgeClazz, "values", "()[Lorg/apache/kafka/common/telemetry/ClientTelemetryState;");
        }

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/telemetry/ClientTelemetryState.html#validateTransition-org.apache.kafka.common.telemetry.ClientTelemetryState-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Telemetry.ClientTelemetryState"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Common.Telemetry.ClientTelemetryState"/></returns>
        public Org.Apache.Kafka.Common.Telemetry.ClientTelemetryState ValidateTransition(Org.Apache.Kafka.Common.Telemetry.ClientTelemetryState arg0)
        {
            return IExecuteWithSignature<Org.Apache.Kafka.Common.Telemetry.ClientTelemetryState>("validateTransition", "(Lorg/apache/kafka/common/telemetry/ClientTelemetryState;)Lorg/apache/kafka/common/telemetry/ClientTelemetryState;", arg0);
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}