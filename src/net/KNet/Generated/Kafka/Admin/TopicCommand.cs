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
*  This file is generated by MASES.JNetReflector (ver. 2.1.1.0)
*  using kafka_2.13-3.6.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Kafka.Admin
{
    #region TopicCommand
    public partial class TopicCommand
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.html#isDebugEnabled--"/>
        /// </summary>

        /// <returns><see cref="bool"/></returns>
        public static bool IsDebugEnabled()
        {
            return SExecute<bool>(LocalBridgeClazz, "isDebugEnabled");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.html#isTraceEnabled--"/>
        /// </summary>

        /// <returns><see cref="bool"/></returns>
        public static bool IsTraceEnabled()
        {
            return SExecute<bool>(LocalBridgeClazz, "isTraceEnabled");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.html#parseTopicConfigsToBeAdded-kafka.admin.TopicCommand.TopicCommandOptions-"/>
        /// </summary>
        /// <param name="opts"><see cref="Kafka.Admin.TopicCommand.TopicCommandOptions"/></param>
        /// <returns><see cref="Java.Util.Properties"/></returns>
        public static Java.Util.Properties ParseTopicConfigsToBeAdded(Kafka.Admin.TopicCommand.TopicCommandOptions opts)
        {
            return SExecute<Java.Util.Properties>(LocalBridgeClazz, "parseTopicConfigsToBeAdded", opts);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.html#main-java.lang.String[]-"/>
        /// </summary>
        /// <param name="args"><see cref="string"/></param>
        public static void Main(string[] args)
        {
            SExecute(LocalBridgeClazz, "main", new object[] { args });
        }

        #endregion

        #region Instance methods

        #endregion

        #region Nested classes
        #region CommandTopicPartition
        public partial class CommandTopicPartition
        {
            #region Constructors
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.CommandTopicPartition.html#kafka.admin.TopicCommand$CommandTopicPartition(kafka.admin.TopicCommand.TopicCommandOptions)"/>
            /// </summary>
            /// <param name="opts"><see cref="Kafka.Admin.TopicCommand.TopicCommandOptions"/></param>
            public CommandTopicPartition(Kafka.Admin.TopicCommand.TopicCommandOptions opts)
                : base(opts)
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
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.CommandTopicPartition.html#hasReplicaAssignment--"/>
            /// </summary>

            /// <returns><see cref="bool"/></returns>
            public bool HasReplicaAssignment()
            {
                return IExecute<bool>("hasReplicaAssignment");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.CommandTopicPartition.html#ifTopicDoesntExist--"/>
            /// </summary>

            /// <returns><see cref="bool"/></returns>
            public bool IfTopicDoesntExist()
            {
                return IExecute<bool>("ifTopicDoesntExist");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.CommandTopicPartition.html#name--"/>
            /// </summary>

            /// <returns><see cref="string"/></returns>
            public string Name()
            {
                return IExecute<string>("name");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.CommandTopicPartition.html#configsToAdd--"/>
            /// </summary>

            /// <returns><see cref="Java.Util.Properties"/></returns>
            public Java.Util.Properties ConfigsToAdd()
            {
                return IExecute<Java.Util.Properties>("configsToAdd");
            }

            #endregion

            #region Nested classes

            #endregion

            // TODO: complete the class
        }
        #endregion

        #region DescribeOptions
        public partial class DescribeOptions
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
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.DescribeOptions.html#describeConfigs--"/>
            /// </summary>

            /// <returns><see cref="bool"/></returns>
            public bool DescribeConfigs()
            {
                return IExecute<bool>("describeConfigs");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.DescribeOptions.html#describePartitions--"/>
            /// </summary>

            /// <returns><see cref="bool"/></returns>
            public bool DescribePartitions()
            {
                return IExecute<bool>("describePartitions");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.DescribeOptions.html#maybePrintPartitionDescription-kafka.admin.TopicCommand.PartitionDescription-"/>
            /// </summary>
            /// <param name="desc"><see cref="Kafka.Admin.TopicCommand.PartitionDescription"/></param>
            public void MaybePrintPartitionDescription(Kafka.Admin.TopicCommand.PartitionDescription desc)
            {
                IExecute("maybePrintPartitionDescription", desc);
            }

            #endregion

            #region Nested classes

            #endregion

            // TODO: complete the class
        }
        #endregion

        #region PartitionDescription
        public partial class PartitionDescription : Java.Io.ISerializable
        {
            #region Constructors

            #endregion

            #region Class/Interface conversion operators
            /// <summary>
            /// Converter from <see cref="Kafka.Admin.TopicCommand.PartitionDescription"/> to <see cref="Java.Io.Serializable"/>
            /// </summary>
            public static implicit operator Java.Io.Serializable(Kafka.Admin.TopicCommand.PartitionDescription t) => t.Cast<Java.Io.Serializable>();

            #endregion

            #region Fields

            #endregion

            #region Static methods

            #endregion

            #region Instance methods
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.PartitionDescription.html#canEqual-java.lang.Object-"/>
            /// </summary>
            /// <param name="x_1"><see cref="object"/></param>
            /// <returns><see cref="bool"/></returns>
            public bool CanEqual(object x_1)
            {
                return IExecute<bool>("canEqual", x_1);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.PartitionDescription.html#isAtMinIsrPartitions--"/>
            /// </summary>

            /// <returns><see cref="bool"/></returns>
            public bool IsAtMinIsrPartitions()
            {
                return IExecute<bool>("isAtMinIsrPartitions");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.PartitionDescription.html#isUnderMinIsr--"/>
            /// </summary>

            /// <returns><see cref="bool"/></returns>
            public bool IsUnderMinIsr()
            {
                return IExecute<bool>("isUnderMinIsr");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.PartitionDescription.html#isUnderReplicated--"/>
            /// </summary>

            /// <returns><see cref="bool"/></returns>
            public bool IsUnderReplicated()
            {
                return IExecute<bool>("isUnderReplicated");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.PartitionDescription.html#markedForDeletion--"/>
            /// </summary>

            /// <returns><see cref="bool"/></returns>
            public bool MarkedForDeletion()
            {
                return IExecute<bool>("markedForDeletion");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.PartitionDescription.html#productArity--"/>
            /// </summary>

            /// <returns><see cref="int"/></returns>
            public int ProductArity()
            {
                return IExecute<int>("productArity");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.PartitionDescription.html#productElement-int-"/>
            /// </summary>
            /// <param name="x_1"><see cref="int"/></param>
            /// <returns><see cref="object"/></returns>
            public object ProductElement(int x_1)
            {
                return IExecute("productElement", x_1);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.PartitionDescription.html#productElementName-int-"/>
            /// </summary>
            /// <param name="x_1"><see cref="int"/></param>
            /// <returns><see cref="string"/></returns>
            public string ProductElementName(int x_1)
            {
                return IExecute<string>("productElementName", x_1);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.PartitionDescription.html#productPrefix--"/>
            /// </summary>

            /// <returns><see cref="string"/></returns>
            public string ProductPrefix()
            {
                return IExecute<string>("productPrefix");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.PartitionDescription.html#topic--"/>
            /// </summary>

            /// <returns><see cref="string"/></returns>
            public string Topic()
            {
                return IExecute<string>("topic");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.PartitionDescription.html#info--"/>
            /// </summary>

            /// <returns><see cref="Org.Apache.Kafka.Common.TopicPartitionInfo"/></returns>
            public Org.Apache.Kafka.Common.TopicPartitionInfo Info()
            {
                return IExecute<Org.Apache.Kafka.Common.TopicPartitionInfo>("info");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.PartitionDescription.html#printDescription--"/>
            /// </summary>
            public void PrintDescription()
            {
                IExecute("printDescription");
            }

            #endregion

            #region Nested classes

            #endregion

            // TODO: complete the class
        }
        #endregion

        #region TopicCommandOptions
        public partial class TopicCommandOptions
        {
            #region Constructors
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.TopicCommandOptions.html#kafka.admin.TopicCommand$TopicCommandOptions(java.lang.String[])"/>
            /// </summary>
            /// <param name="args"><see cref="string"/></param>
            public TopicCommandOptions(string[] args)
                : base(args)
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
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.TopicCommandOptions.html#excludeInternalTopics--"/>
            /// </summary>

            /// <returns><see cref="bool"/></returns>
            public bool ExcludeInternalTopics()
            {
                return IExecute<bool>("excludeInternalTopics");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.TopicCommandOptions.html#hasAlterOption--"/>
            /// </summary>

            /// <returns><see cref="bool"/></returns>
            public bool HasAlterOption()
            {
                return IExecute<bool>("hasAlterOption");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.TopicCommandOptions.html#hasCreateOption--"/>
            /// </summary>

            /// <returns><see cref="bool"/></returns>
            public bool HasCreateOption()
            {
                return IExecute<bool>("hasCreateOption");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.TopicCommandOptions.html#hasDeleteOption--"/>
            /// </summary>

            /// <returns><see cref="bool"/></returns>
            public bool HasDeleteOption()
            {
                return IExecute<bool>("hasDeleteOption");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.TopicCommandOptions.html#hasDescribeOption--"/>
            /// </summary>

            /// <returns><see cref="bool"/></returns>
            public bool HasDescribeOption()
            {
                return IExecute<bool>("hasDescribeOption");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.TopicCommandOptions.html#hasListOption--"/>
            /// </summary>

            /// <returns><see cref="bool"/></returns>
            public bool HasListOption()
            {
                return IExecute<bool>("hasListOption");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.TopicCommandOptions.html#ifExists--"/>
            /// </summary>

            /// <returns><see cref="bool"/></returns>
            public bool IfExists()
            {
                return IExecute<bool>("ifExists");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.TopicCommandOptions.html#ifNotExists--"/>
            /// </summary>

            /// <returns><see cref="bool"/></returns>
            public bool IfNotExists()
            {
                return IExecute<bool>("ifNotExists");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.TopicCommandOptions.html#reportAtMinIsrPartitions--"/>
            /// </summary>

            /// <returns><see cref="bool"/></returns>
            public bool ReportAtMinIsrPartitions()
            {
                return IExecute<bool>("reportAtMinIsrPartitions");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.TopicCommandOptions.html#reportOverriddenConfigs--"/>
            /// </summary>

            /// <returns><see cref="bool"/></returns>
            public bool ReportOverriddenConfigs()
            {
                return IExecute<bool>("reportOverriddenConfigs");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.TopicCommandOptions.html#reportUnavailablePartitions--"/>
            /// </summary>

            /// <returns><see cref="bool"/></returns>
            public bool ReportUnavailablePartitions()
            {
                return IExecute<bool>("reportUnavailablePartitions");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.TopicCommandOptions.html#reportUnderMinIsrPartitions--"/>
            /// </summary>

            /// <returns><see cref="bool"/></returns>
            public bool ReportUnderMinIsrPartitions()
            {
                return IExecute<bool>("reportUnderMinIsrPartitions");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.TopicCommandOptions.html#reportUnderReplicatedPartitions--"/>
            /// </summary>

            /// <returns><see cref="bool"/></returns>
            public bool ReportUnderReplicatedPartitions()
            {
                return IExecute<bool>("reportUnderReplicatedPartitions");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.TopicCommandOptions.html#commandConfig--"/>
            /// </summary>

            /// <returns><see cref="Java.Util.Properties"/></returns>
            public Java.Util.Properties CommandConfig()
            {
                return IExecute<Java.Util.Properties>("commandConfig");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.TopicCommandOptions.html#checkArgs--"/>
            /// </summary>
            public void CheckArgs()
            {
                IExecute("checkArgs");
            }

            #endregion

            #region Nested classes

            #endregion

            // TODO: complete the class
        }
        #endregion

        #region TopicDescription
        public partial class TopicDescription : Java.Io.ISerializable
        {
            #region Constructors
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.TopicDescription.html#kafka.admin.TopicCommand$TopicDescription(java.lang.String,org.apache.kafka.common.Uuid,int,int,org.apache.kafka.clients.admin.Config,boolean)"/>
            /// </summary>
            /// <param name="topic"><see cref="string"/></param>
            /// <param name="topicId"><see cref="Org.Apache.Kafka.Common.Uuid"/></param>
            /// <param name="numPartitions"><see cref="int"/></param>
            /// <param name="replicationFactor"><see cref="int"/></param>
            /// <param name="config"><see cref="Org.Apache.Kafka.Clients.Admin.Config"/></param>
            /// <param name="markedForDeletion"><see cref="bool"/></param>
            public TopicDescription(string topic, Org.Apache.Kafka.Common.Uuid topicId, int numPartitions, int replicationFactor, Org.Apache.Kafka.Clients.Admin.Config config, bool markedForDeletion)
                : base(topic, topicId, numPartitions, replicationFactor, config, markedForDeletion)
            {
            }

            #endregion

            #region Class/Interface conversion operators
            /// <summary>
            /// Converter from <see cref="Kafka.Admin.TopicCommand.TopicDescription"/> to <see cref="Java.Io.Serializable"/>
            /// </summary>
            public static implicit operator Java.Io.Serializable(Kafka.Admin.TopicCommand.TopicDescription t) => t.Cast<Java.Io.Serializable>();

            #endregion

            #region Fields

            #endregion

            #region Static methods

            #endregion

            #region Instance methods
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.TopicDescription.html#canEqual-java.lang.Object-"/>
            /// </summary>
            /// <param name="x_1"><see cref="object"/></param>
            /// <returns><see cref="bool"/></returns>
            public bool CanEqual(object x_1)
            {
                return IExecute<bool>("canEqual", x_1);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.TopicDescription.html#markedForDeletion--"/>
            /// </summary>

            /// <returns><see cref="bool"/></returns>
            public bool MarkedForDeletion()
            {
                return IExecute<bool>("markedForDeletion");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.TopicDescription.html#numPartitions--"/>
            /// </summary>

            /// <returns><see cref="int"/></returns>
            public int NumPartitions()
            {
                return IExecute<int>("numPartitions");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.TopicDescription.html#productArity--"/>
            /// </summary>

            /// <returns><see cref="int"/></returns>
            public int ProductArity()
            {
                return IExecute<int>("productArity");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.TopicDescription.html#replicationFactor--"/>
            /// </summary>

            /// <returns><see cref="int"/></returns>
            public int ReplicationFactor()
            {
                return IExecute<int>("replicationFactor");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.TopicDescription.html#productElement-int-"/>
            /// </summary>
            /// <param name="x_1"><see cref="int"/></param>
            /// <returns><see cref="object"/></returns>
            public object ProductElement(int x_1)
            {
                return IExecute("productElement", x_1);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.TopicDescription.html#productElementName-int-"/>
            /// </summary>
            /// <param name="x_1"><see cref="int"/></param>
            /// <returns><see cref="string"/></returns>
            public string ProductElementName(int x_1)
            {
                return IExecute<string>("productElementName", x_1);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.TopicDescription.html#productPrefix--"/>
            /// </summary>

            /// <returns><see cref="string"/></returns>
            public string ProductPrefix()
            {
                return IExecute<string>("productPrefix");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.TopicDescription.html#topic--"/>
            /// </summary>

            /// <returns><see cref="string"/></returns>
            public string Topic()
            {
                return IExecute<string>("topic");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.TopicDescription.html#copy-java.lang.String-org.apache.kafka.common.Uuid-int-int-org.apache.kafka.clients.admin.Config-boolean-"/>
            /// </summary>
            /// <param name="topic"><see cref="string"/></param>
            /// <param name="topicId"><see cref="Org.Apache.Kafka.Common.Uuid"/></param>
            /// <param name="numPartitions"><see cref="int"/></param>
            /// <param name="replicationFactor"><see cref="int"/></param>
            /// <param name="config"><see cref="Org.Apache.Kafka.Clients.Admin.Config"/></param>
            /// <param name="markedForDeletion"><see cref="bool"/></param>
            /// <returns><see cref="Kafka.Admin.TopicCommand.TopicDescription"/></returns>
            public Kafka.Admin.TopicCommand.TopicDescription Copy(string topic, Org.Apache.Kafka.Common.Uuid topicId, int numPartitions, int replicationFactor, Org.Apache.Kafka.Clients.Admin.Config config, bool markedForDeletion)
            {
                return IExecute<Kafka.Admin.TopicCommand.TopicDescription>("copy", topic, topicId, numPartitions, replicationFactor, config, markedForDeletion);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.TopicDescription.html#config--"/>
            /// </summary>

            /// <returns><see cref="Org.Apache.Kafka.Clients.Admin.Config"/></returns>
            public Org.Apache.Kafka.Clients.Admin.Config Config()
            {
                return IExecute<Org.Apache.Kafka.Clients.Admin.Config>("config");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.TopicDescription.html#topicId--"/>
            /// </summary>

            /// <returns><see cref="Org.Apache.Kafka.Common.Uuid"/></returns>
            public Org.Apache.Kafka.Common.Uuid TopicId()
            {
                return IExecute<Org.Apache.Kafka.Common.Uuid>("topicId");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.TopicDescription.html#printDescription--"/>
            /// </summary>
            public void PrintDescription()
            {
                IExecute("printDescription");
            }

            #endregion

            #region Nested classes

            #endregion

            // TODO: complete the class
        }
        #endregion

        #region TopicService
        public partial class TopicService : Java.Lang.IAutoCloseable, Java.Io.ISerializable
        {
            #region Constructors
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.TopicService.html#kafka.admin.TopicCommand$TopicService(org.apache.kafka.clients.admin.Admin)"/>
            /// </summary>
            /// <param name="adminClient"><see cref="Org.Apache.Kafka.Clients.Admin.Admin"/></param>
            public TopicService(Org.Apache.Kafka.Clients.Admin.Admin adminClient)
                : base(adminClient)
            {
            }

            #endregion

            #region Class/Interface conversion operators
            /// <summary>
            /// Converter from <see cref="Kafka.Admin.TopicCommand.TopicService"/> to <see cref="Java.Lang.AutoCloseable"/>
            /// </summary>
            public static implicit operator Java.Lang.AutoCloseable(Kafka.Admin.TopicCommand.TopicService t) => t.Cast<Java.Lang.AutoCloseable>();
            /// <summary>
            /// Converter from <see cref="Kafka.Admin.TopicCommand.TopicService"/> to <see cref="Java.Io.Serializable"/>
            /// </summary>
            public static implicit operator Java.Io.Serializable(Kafka.Admin.TopicCommand.TopicService t) => t.Cast<Java.Io.Serializable>();

            #endregion

            #region Fields

            #endregion

            #region Static methods

            #endregion

            #region Instance methods
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.TopicService.html#canEqual-java.lang.Object-"/>
            /// </summary>
            /// <param name="x_1"><see cref="object"/></param>
            /// <returns><see cref="bool"/></returns>
            public bool CanEqual(object x_1)
            {
                return IExecute<bool>("canEqual", x_1);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.TopicService.html#productArity--"/>
            /// </summary>

            /// <returns><see cref="int"/></returns>
            public int ProductArity()
            {
                return IExecute<int>("productArity");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.TopicService.html#productElement-int-"/>
            /// </summary>
            /// <param name="x_1"><see cref="int"/></param>
            /// <returns><see cref="object"/></returns>
            public object ProductElement(int x_1)
            {
                return IExecute("productElement", x_1);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.TopicService.html#productElementName-int-"/>
            /// </summary>
            /// <param name="x_1"><see cref="int"/></param>
            /// <returns><see cref="string"/></returns>
            public string ProductElementName(int x_1)
            {
                return IExecute<string>("productElementName", x_1);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.TopicService.html#productPrefix--"/>
            /// </summary>

            /// <returns><see cref="string"/></returns>
            public string ProductPrefix()
            {
                return IExecute<string>("productPrefix");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.TopicService.html#copy-org.apache.kafka.clients.admin.Admin-"/>
            /// </summary>
            /// <param name="adminClient"><see cref="Org.Apache.Kafka.Clients.Admin.Admin"/></param>
            /// <returns><see cref="Kafka.Admin.TopicCommand.TopicService"/></returns>
            public Kafka.Admin.TopicCommand.TopicService Copy(Org.Apache.Kafka.Clients.Admin.Admin adminClient)
            {
                return IExecute<Kafka.Admin.TopicCommand.TopicService>("copy", adminClient);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.TopicService.html#adminClient--"/>
            /// </summary>

            /// <returns><see cref="Org.Apache.Kafka.Clients.Admin.Admin"/></returns>
            public Org.Apache.Kafka.Clients.Admin.Admin AdminClient()
            {
                return IExecute<Org.Apache.Kafka.Clients.Admin.Admin>("adminClient");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.TopicService.html#alterTopic-kafka.admin.TopicCommand.TopicCommandOptions-"/>
            /// </summary>
            /// <param name="opts"><see cref="Kafka.Admin.TopicCommand.TopicCommandOptions"/></param>
            public void AlterTopic(Kafka.Admin.TopicCommand.TopicCommandOptions opts)
            {
                IExecute("alterTopic", opts);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.TopicService.html#close--"/>
            /// </summary>
            public void Close()
            {
                IExecute("close");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.TopicService.html#createTopic-kafka.admin.TopicCommand.CommandTopicPartition-"/>
            /// </summary>
            /// <param name="topic"><see cref="Kafka.Admin.TopicCommand.CommandTopicPartition"/></param>
            public void CreateTopic(Kafka.Admin.TopicCommand.CommandTopicPartition topic)
            {
                IExecute("createTopic", topic);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.TopicService.html#createTopic-kafka.admin.TopicCommand.TopicCommandOptions-"/>
            /// </summary>
            /// <param name="opts"><see cref="Kafka.Admin.TopicCommand.TopicCommandOptions"/></param>
            public void CreateTopic(Kafka.Admin.TopicCommand.TopicCommandOptions opts)
            {
                IExecute("createTopic", opts);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.TopicService.html#deleteTopic-kafka.admin.TopicCommand.TopicCommandOptions-"/>
            /// </summary>
            /// <param name="opts"><see cref="Kafka.Admin.TopicCommand.TopicCommandOptions"/></param>
            public void DeleteTopic(Kafka.Admin.TopicCommand.TopicCommandOptions opts)
            {
                IExecute("deleteTopic", opts);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.TopicService.html#describeTopic-kafka.admin.TopicCommand.TopicCommandOptions-"/>
            /// </summary>
            /// <param name="opts"><see cref="Kafka.Admin.TopicCommand.TopicCommandOptions"/></param>
            public void DescribeTopic(Kafka.Admin.TopicCommand.TopicCommandOptions opts)
            {
                IExecute("describeTopic", opts);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/TopicCommand.TopicService.html#listTopics-kafka.admin.TopicCommand.TopicCommandOptions-"/>
            /// </summary>
            /// <param name="opts"><see cref="Kafka.Admin.TopicCommand.TopicCommandOptions"/></param>
            public void ListTopics(Kafka.Admin.TopicCommand.TopicCommandOptions opts)
            {
                IExecute("listTopics", opts);
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