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
*  This file is generated by MASES.JNetReflector (ver. 2.2.5.0)
*  using kafka-clients-3.6.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Clients.Admin
{
    #region DescribeConsumerGroupsResult
    public partial class DescribeConsumerGroupsResult
    {
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/admin/DescribeConsumerGroupsResult.html#org.apache.kafka.clients.admin.DescribeConsumerGroupsResult(java.util.Map)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.Map"/></param>
        public DescribeConsumerGroupsResult(Java.Util.Map<string, Org.Apache.Kafka.Common.KafkaFuture<Org.Apache.Kafka.Clients.Admin.ConsumerGroupDescription>> arg0)
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
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/admin/DescribeConsumerGroupsResult.html#describedGroups--"/>
        /// </summary>

        /// <returns><see cref="Java.Util.Map"/></returns>
        public Java.Util.Map<string, Org.Apache.Kafka.Common.KafkaFuture<Org.Apache.Kafka.Clients.Admin.ConsumerGroupDescription>> DescribedGroups()
        {
            return IExecute<Java.Util.Map<string, Org.Apache.Kafka.Common.KafkaFuture<Org.Apache.Kafka.Clients.Admin.ConsumerGroupDescription>>>("describedGroups");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/admin/DescribeConsumerGroupsResult.html#all--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.KafkaFuture"/></returns>
        public Org.Apache.Kafka.Common.KafkaFuture<Java.Util.Map<string, Org.Apache.Kafka.Clients.Admin.ConsumerGroupDescription>> All()
        {
            return IExecute<Org.Apache.Kafka.Common.KafkaFuture<Java.Util.Map<string, Org.Apache.Kafka.Clients.Admin.ConsumerGroupDescription>>>("all");
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}