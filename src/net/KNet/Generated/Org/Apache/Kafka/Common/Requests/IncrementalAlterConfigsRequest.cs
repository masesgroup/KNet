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
    #region IncrementalAlterConfigsRequest
    public partial class IncrementalAlterConfigsRequest
    {
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/IncrementalAlterConfigsRequest.html#%3Cinit%3E(org.apache.kafka.common.message.IncrementalAlterConfigsRequestData,short)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Message.IncrementalAlterConfigsRequestData"/></param>
        /// <param name="arg1"><see cref="short"/></param>
        public IncrementalAlterConfigsRequest(Org.Apache.Kafka.Common.Message.IncrementalAlterConfigsRequestData arg0, short arg1)
            : base(arg0, arg1)
        {
        }

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/IncrementalAlterConfigsRequest.html#parse(java.nio.ByteBuffer,short)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Nio.ByteBuffer"/></param>
        /// <param name="arg1"><see cref="short"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Common.Requests.IncrementalAlterConfigsRequest"/></returns>
        public static Org.Apache.Kafka.Common.Requests.IncrementalAlterConfigsRequest Parse(Java.Nio.ByteBuffer arg0, short arg1)
        {
            return SExecute<Org.Apache.Kafka.Common.Requests.IncrementalAlterConfigsRequest>(LocalBridgeClazz, "parse", arg0, arg1);
        }

        #endregion

        #region Instance methods

        #endregion

        #region Nested classes
        #region Builder
        public partial class Builder
        {
            #region Constructors
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/IncrementalAlterConfigsRequest.Builder.html#%3Cinit%3E(java.util.Collection,java.util.Map,boolean)"/>
            /// </summary>
            /// <param name="arg0"><see cref="Java.Util.Collection"/></param>
            /// <param name="arg1"><see cref="Java.Util.Map"/></param>
            /// <param name="arg2"><see cref="bool"/></param>
            public Builder(Java.Util.Collection<Org.Apache.Kafka.Common.Config.ConfigResource> arg0, Java.Util.Map<Org.Apache.Kafka.Common.Config.ConfigResource, Java.Util.Collection<Org.Apache.Kafka.Clients.Admin.AlterConfigOp>> arg1, bool arg2)
                : base(arg0, arg1, arg2)
            {
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/IncrementalAlterConfigsRequest.Builder.html#%3Cinit%3E(java.util.Map,boolean)"/>
            /// </summary>
            /// <param name="arg0"><see cref="Java.Util.Map"/></param>
            /// <param name="arg1"><see cref="bool"/></param>
            public Builder(Java.Util.Map<Org.Apache.Kafka.Common.Config.ConfigResource, Java.Util.Collection<Org.Apache.Kafka.Clients.Admin.AlterConfigOp>> arg0, bool arg1)
                : base(arg0, arg1)
            {
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/IncrementalAlterConfigsRequest.Builder.html#%3Cinit%3E(org.apache.kafka.common.message.IncrementalAlterConfigsRequestData)"/>
            /// </summary>
            /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Message.IncrementalAlterConfigsRequestData"/></param>
            public Builder(Org.Apache.Kafka.Common.Message.IncrementalAlterConfigsRequestData arg0)
                : base(arg0)
            {
            }

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

    
        #endregion

        // TODO: complete the class
    }
    #endregion
}