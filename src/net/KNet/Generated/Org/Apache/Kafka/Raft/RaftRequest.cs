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
*  This file is generated by MASES.JNetReflector (ver. 2.0.2.0)
*  using kafka-raft-3.6.0.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Raft
{
    #region RaftRequest
    public partial class RaftRequest
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
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.0/org/apache/kafka/raft/RaftRequest.html#correlationId--"/>
        /// </summary>

        /// <returns><see cref="int"/></returns>
        public int CorrelationId()
        {
            return IExecute<int>("correlationId");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.0/org/apache/kafka/raft/RaftRequest.html#createdTimeMs--"/>
        /// </summary>

        /// <returns><see cref="long"/></returns>
        public long CreatedTimeMs()
        {
            return IExecute<long>("createdTimeMs");
        }

        #endregion

        #region Nested classes
        #region Inbound
        public partial class Inbound
        {
            #region Constructors

            #endregion

            #region Class/Interface conversion operators

            #endregion

            #region Fields
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.0/org/apache/kafka/raft/RaftRequest.Inbound.html#completion"/>
            /// </summary>
            public Java.Util.Concurrent.CompletableFuture completion { get { return IGetField<Java.Util.Concurrent.CompletableFuture>("completion"); } }

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

        #region Outbound
        public partial class Outbound
        {
            #region Constructors

            #endregion

            #region Class/Interface conversion operators

            #endregion

            #region Fields
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.0/org/apache/kafka/raft/RaftRequest.Outbound.html#completion"/>
            /// </summary>
            public Java.Util.Concurrent.CompletableFuture completion { get { return IGetField<Java.Util.Concurrent.CompletableFuture>("completion"); } }

            #endregion

            #region Static methods

            #endregion

            #region Instance methods
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.0/org/apache/kafka/raft/RaftRequest.Outbound.html#destinationId--"/>
            /// </summary>

            /// <returns><see cref="int"/></returns>
            public int DestinationId()
            {
                return IExecute<int>("destinationId");
            }

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