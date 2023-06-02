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
    #region IncrementalAlterConfigsResponse
    public partial class IncrementalAlterConfigsResponse
    {
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/IncrementalAlterConfigsResponse.html#%3Cinit%3E(int,java.util.Map)"/>
        /// </summary>
        /// <param name="arg0"><see cref="int"/></param>
        /// <param name="arg1"><see cref="Java.Util.Map"/></param>
        public IncrementalAlterConfigsResponse(int arg0, Java.Util.Map<Org.Apache.Kafka.Common.Config.ConfigResource, Org.Apache.Kafka.Common.Requests.ApiError> arg1)
            : base(arg0, arg1)
        {
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/IncrementalAlterConfigsResponse.html#%3Cinit%3E(org.apache.kafka.common.message.IncrementalAlterConfigsResponseData)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Message.IncrementalAlterConfigsResponseData"/></param>
        public IncrementalAlterConfigsResponse(Org.Apache.Kafka.Common.Message.IncrementalAlterConfigsResponseData arg0)
            : base(arg0)
        {
        }

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/IncrementalAlterConfigsResponse.html#fromResponseData(org.apache.kafka.common.message.IncrementalAlterConfigsResponseData)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Message.IncrementalAlterConfigsResponseData"/></param>
        /// <returns><see cref="Java.Util.Map"/></returns>
        public static Java.Util.Map<Org.Apache.Kafka.Common.Config.ConfigResource, Org.Apache.Kafka.Common.Requests.ApiError> FromResponseData(Org.Apache.Kafka.Common.Message.IncrementalAlterConfigsResponseData arg0)
        {
            return SExecute<Java.Util.Map<Org.Apache.Kafka.Common.Config.ConfigResource, Org.Apache.Kafka.Common.Requests.ApiError>>(LocalBridgeClazz, "fromResponseData", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/IncrementalAlterConfigsResponse.html#parse(java.nio.ByteBuffer,short)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Nio.ByteBuffer"/></param>
        /// <param name="arg1"><see cref="short"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Common.Requests.IncrementalAlterConfigsResponse"/></returns>
        public static Org.Apache.Kafka.Common.Requests.IncrementalAlterConfigsResponse Parse(Java.Nio.ByteBuffer arg0, short arg1)
        {
            return SExecute<Org.Apache.Kafka.Common.Requests.IncrementalAlterConfigsResponse>(LocalBridgeClazz, "parse", arg0, arg1);
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