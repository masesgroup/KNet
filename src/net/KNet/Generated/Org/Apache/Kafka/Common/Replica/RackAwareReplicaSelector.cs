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
*  using kafka-clients-3.6.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Common.Replica
{
    #region RackAwareReplicaSelector
    public partial class RackAwareReplicaSelector
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
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/replica/RackAwareReplicaSelector.html#select-org.apache.kafka.common.TopicPartition-org.apache.kafka.common.replica.ClientMetadata-org.apache.kafka.common.replica.PartitionView-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.TopicPartition"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Common.Replica.ClientMetadata"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Common.Replica.PartitionView"/></param>
        /// <returns><see cref="Java.Util.Optional"/></returns>
        public Java.Util.Optional<Org.Apache.Kafka.Common.Replica.ReplicaView> Select(Org.Apache.Kafka.Common.TopicPartition arg0, Org.Apache.Kafka.Common.Replica.ClientMetadata arg1, Org.Apache.Kafka.Common.Replica.PartitionView arg2)
        {
            return IExecute<Java.Util.Optional<Org.Apache.Kafka.Common.Replica.ReplicaView>>("select", arg0, arg1, arg2);
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}