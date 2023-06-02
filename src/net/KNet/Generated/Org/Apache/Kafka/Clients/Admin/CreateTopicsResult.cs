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

namespace Org.Apache.Kafka.Clients.Admin
{
    #region CreateTopicsResult
    public partial class CreateTopicsResult
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
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/clients/admin/CreateTopicsResult.html#values()"/>
        /// </summary>

        /// <returns><see cref="Java.Util.Map"/></returns>
        public Java.Util.Map<string, Org.Apache.Kafka.Common.KafkaFuture<Java.Lang.Void>> Values()
        {
            return IExecute<Java.Util.Map<string, Org.Apache.Kafka.Common.KafkaFuture<Java.Lang.Void>>>("values");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/clients/admin/CreateTopicsResult.html#numPartitions(java.lang.String)"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Common.KafkaFuture"/></returns>
        public Org.Apache.Kafka.Common.KafkaFuture<int?> NumPartitions(string arg0)
        {
            return IExecute<Org.Apache.Kafka.Common.KafkaFuture<int?>>("numPartitions", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/clients/admin/CreateTopicsResult.html#replicationFactor(java.lang.String)"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Common.KafkaFuture"/></returns>
        public Org.Apache.Kafka.Common.KafkaFuture<int?> ReplicationFactor(string arg0)
        {
            return IExecute<Org.Apache.Kafka.Common.KafkaFuture<int?>>("replicationFactor", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/clients/admin/CreateTopicsResult.html#all()"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.KafkaFuture"/></returns>
        public Org.Apache.Kafka.Common.KafkaFuture<Java.Lang.Void> All()
        {
            return IExecute<Org.Apache.Kafka.Common.KafkaFuture<Java.Lang.Void>>("all");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/clients/admin/CreateTopicsResult.html#config(java.lang.String)"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Common.KafkaFuture"/></returns>
        public Org.Apache.Kafka.Common.KafkaFuture<Org.Apache.Kafka.Clients.Admin.Config> Config(string arg0)
        {
            return IExecute<Org.Apache.Kafka.Common.KafkaFuture<Org.Apache.Kafka.Clients.Admin.Config>>("config", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/clients/admin/CreateTopicsResult.html#topicId(java.lang.String)"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Common.KafkaFuture"/></returns>
        public Org.Apache.Kafka.Common.KafkaFuture<Org.Apache.Kafka.Common.Uuid> TopicId(string arg0)
        {
            return IExecute<Org.Apache.Kafka.Common.KafkaFuture<Org.Apache.Kafka.Common.Uuid>>("topicId", arg0);
        }

        #endregion

        #region Nested classes
        #region TopicMetadataAndConfig
        public partial class TopicMetadataAndConfig
        {
            #region Constructors
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/clients/admin/CreateTopicsResult.TopicMetadataAndConfig.html#%3Cinit%3E(org.apache.kafka.common.errors.ApiException)"/>
            /// </summary>
            /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Errors.ApiException"/></param>
            public TopicMetadataAndConfig(Org.Apache.Kafka.Common.Errors.ApiException arg0)
                : base(arg0)
            {
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/clients/admin/CreateTopicsResult.TopicMetadataAndConfig.html#%3Cinit%3E(org.apache.kafka.common.Uuid,int,int,org.apache.kafka.clients.admin.Config)"/>
            /// </summary>
            /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Uuid"/></param>
            /// <param name="arg1"><see cref="int"/></param>
            /// <param name="arg2"><see cref="int"/></param>
            /// <param name="arg3"><see cref="Org.Apache.Kafka.Clients.Admin.Config"/></param>
            public TopicMetadataAndConfig(Org.Apache.Kafka.Common.Uuid arg0, int arg1, int arg2, Org.Apache.Kafka.Clients.Admin.Config arg3)
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
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/clients/admin/CreateTopicsResult.TopicMetadataAndConfig.html#numPartitions()"/>
            /// </summary>

            /// <returns><see cref="int"/></returns>
            public int NumPartitions()
            {
                return IExecute<int>("numPartitions");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/clients/admin/CreateTopicsResult.TopicMetadataAndConfig.html#replicationFactor()"/>
            /// </summary>

            /// <returns><see cref="int"/></returns>
            public int ReplicationFactor()
            {
                return IExecute<int>("replicationFactor");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/clients/admin/CreateTopicsResult.TopicMetadataAndConfig.html#config()"/>
            /// </summary>

            /// <returns><see cref="Org.Apache.Kafka.Clients.Admin.Config"/></returns>
            public Org.Apache.Kafka.Clients.Admin.Config Config()
            {
                return IExecute<Org.Apache.Kafka.Clients.Admin.Config>("config");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/clients/admin/CreateTopicsResult.TopicMetadataAndConfig.html#topicId()"/>
            /// </summary>

            /// <returns><see cref="Org.Apache.Kafka.Common.Uuid"/></returns>
            public Org.Apache.Kafka.Common.Uuid TopicId()
            {
                return IExecute<Org.Apache.Kafka.Common.Uuid>("topicId");
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