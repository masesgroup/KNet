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
*  using kafka-clients-3.6.0.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Clients.Admin
{
    #region AbortTransactionSpec
    public partial class AbortTransactionSpec
    {
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/admin/AbortTransactionSpec.html#org.apache.kafka.clients.admin.AbortTransactionSpec(org.apache.kafka.common.TopicPartition,long,short,int)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.TopicPartition"/></param>
        /// <param name="arg1"><see cref="long"/></param>
        /// <param name="arg2"><see cref="short"/></param>
        /// <param name="arg3"><see cref="int"/></param>
        public AbortTransactionSpec(Org.Apache.Kafka.Common.TopicPartition arg0, long arg1, short arg2, int arg3)
            : base(arg0, arg1, arg2, arg3)
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
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/admin/AbortTransactionSpec.html#coordinatorEpoch--"/>
        /// </summary>

        /// <returns><see cref="int"/></returns>
        public int CoordinatorEpoch()
        {
            return IExecute<int>("coordinatorEpoch");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/admin/AbortTransactionSpec.html#producerId--"/>
        /// </summary>

        /// <returns><see cref="long"/></returns>
        public long ProducerId()
        {
            return IExecute<long>("producerId");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/admin/AbortTransactionSpec.html#topicPartition--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.TopicPartition"/></returns>
        public Org.Apache.Kafka.Common.TopicPartition TopicPartition()
        {
            return IExecute<Org.Apache.Kafka.Common.TopicPartition>("topicPartition");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/admin/AbortTransactionSpec.html#producerEpoch--"/>
        /// </summary>

        /// <returns><see cref="short"/></returns>
        public short ProducerEpoch()
        {
            return IExecute<short>("producerEpoch");
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}