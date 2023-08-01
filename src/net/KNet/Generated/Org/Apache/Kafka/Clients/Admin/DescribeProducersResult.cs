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
*  This file is generated by MASES.JNetReflector (ver. 2.0.1.0)
*  using kafka-clients-3.5.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Clients.Admin
{
    #region DescribeProducersResult
    public partial class DescribeProducersResult
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
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/clients/admin/DescribeProducersResult.html#all--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.KafkaFuture"/></returns>
        public Org.Apache.Kafka.Common.KafkaFuture<Java.Util.Map<Org.Apache.Kafka.Common.TopicPartition, Org.Apache.Kafka.Clients.Admin.DescribeProducersResult.PartitionProducerState>> All()
        {
            return IExecute<Org.Apache.Kafka.Common.KafkaFuture<Java.Util.Map<Org.Apache.Kafka.Common.TopicPartition, Org.Apache.Kafka.Clients.Admin.DescribeProducersResult.PartitionProducerState>>>("all");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/clients/admin/DescribeProducersResult.html#partitionResult-org.apache.kafka.common.TopicPartition-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.TopicPartition"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Common.KafkaFuture"/></returns>
        public Org.Apache.Kafka.Common.KafkaFuture<Org.Apache.Kafka.Clients.Admin.DescribeProducersResult.PartitionProducerState> PartitionResult(Org.Apache.Kafka.Common.TopicPartition arg0)
        {
            return IExecute<Org.Apache.Kafka.Common.KafkaFuture<Org.Apache.Kafka.Clients.Admin.DescribeProducersResult.PartitionProducerState>>("partitionResult", arg0);
        }

        #endregion

        #region Nested classes
        #region PartitionProducerState
        public partial class PartitionProducerState
        {
            #region Constructors
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/clients/admin/DescribeProducersResult.PartitionProducerState.html#org.apache.kafka.clients.admin.DescribeProducersResult$PartitionProducerState(java.util.List)"/>
            /// </summary>
            /// <param name="arg0"><see cref="Java.Util.List"/></param>
            public PartitionProducerState(Java.Util.List<Org.Apache.Kafka.Clients.Admin.ProducerState> arg0)
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
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/clients/admin/DescribeProducersResult.PartitionProducerState.html#activeProducers--"/>
            /// </summary>

            /// <returns><see cref="Java.Util.List"/></returns>
            public Java.Util.List<Org.Apache.Kafka.Clients.Admin.ProducerState> ActiveProducers()
            {
                return IExecute<Java.Util.List<Org.Apache.Kafka.Clients.Admin.ProducerState>>("activeProducers");
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