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

namespace Org.Apache.Kafka.Common.Requests
{
    #region AbstractControlRequest
    public partial class AbstractControlRequest
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/AbstractControlRequest.html#UNKNOWN_BROKER_EPOCH"/>
        /// </summary>
        public static long UNKNOWN_BROKER_EPOCH { get { return SGetField<long>(LocalBridgeClazz, "UNKNOWN_BROKER_EPOCH"); } }

        #endregion

        #region Static methods

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/AbstractControlRequest.html#isKRaftController()"/>
        /// </summary>

        /// <returns><see cref="bool"/></returns>
        public bool IsKRaftController()
        {
            return IExecute<bool>("isKRaftController");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/AbstractControlRequest.html#controllerEpoch()"/>
        /// </summary>

        /// <returns><see cref="int"/></returns>
        public int ControllerEpoch()
        {
            return IExecute<int>("controllerEpoch");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/AbstractControlRequest.html#controllerId()"/>
        /// </summary>

        /// <returns><see cref="int"/></returns>
        public int ControllerId()
        {
            return IExecute<int>("controllerId");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/AbstractControlRequest.html#brokerEpoch()"/>
        /// </summary>

        /// <returns><see cref="long"/></returns>
        public long BrokerEpoch()
        {
            return IExecute<long>("brokerEpoch");
        }

        #endregion

        #region Nested classes
        #region Builder
        public partial class Builder
        {
            #region Constructors

            #endregion

            #region Class/Interface conversion operators

            #endregion

            #region Fields

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

        #region Builder<T>
        public partial class Builder<T>
        {
            #region Constructors

            #endregion

            #region Class/Interface conversion operators
            /// <summary>
            /// Converter from <see cref="Org.Apache.Kafka.Common.Requests.AbstractControlRequest.Builder{T}"/> to <see cref="Org.Apache.Kafka.Common.Requests.AbstractControlRequest.Builder"/>
            /// </summary>
            public static implicit operator Org.Apache.Kafka.Common.Requests.AbstractControlRequest.Builder(Org.Apache.Kafka.Common.Requests.AbstractControlRequest.Builder<T> t) => t.Cast<Org.Apache.Kafka.Common.Requests.AbstractControlRequest.Builder>();

            #endregion

            #region Fields

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

    
        #endregion

        // TODO: complete the class
    }
    #endregion
}