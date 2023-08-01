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
    #region ConsumerGroupListing
    public partial class ConsumerGroupListing
    {
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/clients/admin/ConsumerGroupListing.html#org.apache.kafka.clients.admin.ConsumerGroupListing(java.lang.String,boolean,java.util.Optional)"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="bool"/></param>
        /// <param name="arg2"><see cref="Java.Util.Optional"/></param>
        public ConsumerGroupListing(string arg0, bool arg1, Java.Util.Optional<Org.Apache.Kafka.Common.ConsumerGroupState> arg2)
            : base(arg0, arg1, arg2)
        {
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/clients/admin/ConsumerGroupListing.html#org.apache.kafka.clients.admin.ConsumerGroupListing(java.lang.String,boolean)"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="bool"/></param>
        public ConsumerGroupListing(string arg0, bool arg1)
            : base(arg0, arg1)
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
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/clients/admin/ConsumerGroupListing.html#isSimpleConsumerGroup--"/>
        /// </summary>

        /// <returns><see cref="bool"/></returns>
        public bool IsSimpleConsumerGroup()
        {
            return IExecute<bool>("isSimpleConsumerGroup");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/clients/admin/ConsumerGroupListing.html#groupId--"/>
        /// </summary>

        /// <returns><see cref="string"/></returns>
        public string GroupId()
        {
            return IExecute<string>("groupId");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/clients/admin/ConsumerGroupListing.html#state--"/>
        /// </summary>

        /// <returns><see cref="Java.Util.Optional"/></returns>
        public Java.Util.Optional<Org.Apache.Kafka.Common.ConsumerGroupState> State()
        {
            return IExecute<Java.Util.Optional<Org.Apache.Kafka.Common.ConsumerGroupState>>("state");
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}