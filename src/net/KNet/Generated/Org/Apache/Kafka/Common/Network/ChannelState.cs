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
*  This file is generated by MASES.JNetReflector (ver. 1.5.5.0)
*  using kafka-clients-3.4.0.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Common.Network
{
    #region ChannelState
    public partial class ChannelState
    {
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/network/ChannelState.html#%3Cinit%3E(org.apache.kafka.common.network.ChannelState.State,java.lang.String)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Network.ChannelState.State"/></param>
        /// <param name="arg1"><see cref="string"/></param>
        public ChannelState(Org.Apache.Kafka.Common.Network.ChannelState.State arg0, string arg1)
            : base(arg0, arg1)
        {
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/network/ChannelState.html#%3Cinit%3E(org.apache.kafka.common.network.ChannelState.State,org.apache.kafka.common.errors.AuthenticationException,java.lang.String)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Network.ChannelState.State"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Common.Errors.AuthenticationException"/></param>
        /// <param name="arg2"><see cref="string"/></param>
        public ChannelState(Org.Apache.Kafka.Common.Network.ChannelState.State arg0, Org.Apache.Kafka.Common.Errors.AuthenticationException arg1, string arg2)
            : base(arg0, arg1, arg2)
        {
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/network/ChannelState.html#%3Cinit%3E(org.apache.kafka.common.network.ChannelState.State)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Network.ChannelState.State"/></param>
        public ChannelState(Org.Apache.Kafka.Common.Network.ChannelState.State arg0)
            : base(arg0)
        {
        }

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/network/ChannelState.html#AUTHENTICATE"/>
        /// </summary>
        public static Org.Apache.Kafka.Common.Network.ChannelState AUTHENTICATE { get { return SGetField<Org.Apache.Kafka.Common.Network.ChannelState>(LocalBridgeClazz, "AUTHENTICATE"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/network/ChannelState.html#EXPIRED"/>
        /// </summary>
        public static Org.Apache.Kafka.Common.Network.ChannelState EXPIRED { get { return SGetField<Org.Apache.Kafka.Common.Network.ChannelState>(LocalBridgeClazz, "EXPIRED"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/network/ChannelState.html#FAILED_SEND"/>
        /// </summary>
        public static Org.Apache.Kafka.Common.Network.ChannelState FAILED_SEND { get { return SGetField<Org.Apache.Kafka.Common.Network.ChannelState>(LocalBridgeClazz, "FAILED_SEND"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/network/ChannelState.html#LOCAL_CLOSE"/>
        /// </summary>
        public static Org.Apache.Kafka.Common.Network.ChannelState LOCAL_CLOSE { get { return SGetField<Org.Apache.Kafka.Common.Network.ChannelState>(LocalBridgeClazz, "LOCAL_CLOSE"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/network/ChannelState.html#NOT_CONNECTED"/>
        /// </summary>
        public static Org.Apache.Kafka.Common.Network.ChannelState NOT_CONNECTED { get { return SGetField<Org.Apache.Kafka.Common.Network.ChannelState>(LocalBridgeClazz, "NOT_CONNECTED"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/network/ChannelState.html#READY"/>
        /// </summary>
        public static Org.Apache.Kafka.Common.Network.ChannelState READY { get { return SGetField<Org.Apache.Kafka.Common.Network.ChannelState>(LocalBridgeClazz, "READY"); } }

        #endregion

        #region Static methods

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/network/ChannelState.html#remoteAddress()"/>
        /// </summary>

        /// <returns><see cref="string"/></returns>
        public string RemoteAddress()
        {
            return IExecute<string>("remoteAddress");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/network/ChannelState.html#exception()"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.Errors.AuthenticationException"/></returns>
        public Org.Apache.Kafka.Common.Errors.AuthenticationException Exception()
        {
            var obj = IExecute<MASES.JCOBridge.C2JBridge.JVMInterop.IJavaObject>("exception"); return MASES.JCOBridge.C2JBridge.JVMBridgeException.New<Org.Apache.Kafka.Common.Errors.AuthenticationException>(obj);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/network/ChannelState.html#state()"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.Network.ChannelState.State"/></returns>
        public Org.Apache.Kafka.Common.Network.ChannelState.State StateMethod()
        {
            return IExecute<Org.Apache.Kafka.Common.Network.ChannelState.State>("state");
        }

        #endregion

        #region Nested classes
        #region State
        public partial class State
        {
            #region Constructors

            #endregion

            #region Class/Interface conversion operators

            #endregion

            #region Fields
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/network/ChannelState.State.html#AUTHENTICATE"/>
            /// </summary>
            public static Org.Apache.Kafka.Common.Network.ChannelState.State AUTHENTICATE { get { return SGetField<Org.Apache.Kafka.Common.Network.ChannelState.State>(LocalBridgeClazz, "AUTHENTICATE"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/network/ChannelState.State.html#AUTHENTICATION_FAILED"/>
            /// </summary>
            public static Org.Apache.Kafka.Common.Network.ChannelState.State AUTHENTICATION_FAILED { get { return SGetField<Org.Apache.Kafka.Common.Network.ChannelState.State>(LocalBridgeClazz, "AUTHENTICATION_FAILED"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/network/ChannelState.State.html#EXPIRED"/>
            /// </summary>
            public static Org.Apache.Kafka.Common.Network.ChannelState.State EXPIRED { get { return SGetField<Org.Apache.Kafka.Common.Network.ChannelState.State>(LocalBridgeClazz, "EXPIRED"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/network/ChannelState.State.html#FAILED_SEND"/>
            /// </summary>
            public static Org.Apache.Kafka.Common.Network.ChannelState.State FAILED_SEND { get { return SGetField<Org.Apache.Kafka.Common.Network.ChannelState.State>(LocalBridgeClazz, "FAILED_SEND"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/network/ChannelState.State.html#LOCAL_CLOSE"/>
            /// </summary>
            public static Org.Apache.Kafka.Common.Network.ChannelState.State LOCAL_CLOSE { get { return SGetField<Org.Apache.Kafka.Common.Network.ChannelState.State>(LocalBridgeClazz, "LOCAL_CLOSE"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/network/ChannelState.State.html#NOT_CONNECTED"/>
            /// </summary>
            public static Org.Apache.Kafka.Common.Network.ChannelState.State NOT_CONNECTED { get { return SGetField<Org.Apache.Kafka.Common.Network.ChannelState.State>(LocalBridgeClazz, "NOT_CONNECTED"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/network/ChannelState.State.html#READY"/>
            /// </summary>
            public static Org.Apache.Kafka.Common.Network.ChannelState.State READY { get { return SGetField<Org.Apache.Kafka.Common.Network.ChannelState.State>(LocalBridgeClazz, "READY"); } }

            #endregion

            #region Static methods
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/network/ChannelState.State.html#valueOf(java.lang.String)"/>
            /// </summary>
            /// <param name="arg0"><see cref="string"/></param>
            /// <returns><see cref="Org.Apache.Kafka.Common.Network.ChannelState.State"/></returns>
            public static Org.Apache.Kafka.Common.Network.ChannelState.State ValueOf(string arg0)
            {
                return SExecute<Org.Apache.Kafka.Common.Network.ChannelState.State>(LocalBridgeClazz, "valueOf", arg0);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/network/ChannelState.State.html#values()"/>
            /// </summary>

            /// <returns><see cref="Org.Apache.Kafka.Common.Network.ChannelState.State"/></returns>
            public static Org.Apache.Kafka.Common.Network.ChannelState.State[] Values()
            {
                return SExecuteArray<Org.Apache.Kafka.Common.Network.ChannelState.State>(LocalBridgeClazz, "values");
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