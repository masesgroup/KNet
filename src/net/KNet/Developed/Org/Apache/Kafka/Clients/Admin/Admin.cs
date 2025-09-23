/*
*  Copyright (c) 2021-2025 MASES s.r.l.
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

using MASES.JCOBridge.C2JBridge;
using Org.Apache.Kafka.Clients.Consumer;
using Org.Apache.Kafka.Common;
using Org.Apache.Kafka.Common.Acl;
using Org.Apache.Kafka.Common.Config;
using Org.Apache.Kafka.Common.Quota;
using Java.Time;
using Java.Util;

namespace Org.Apache.Kafka.Clients.Admin
{
    public partial interface IAdmin : IJVMBridgeBase, System.IDisposable
    {
        /// <inheritdoc cref="Admin.Metrics{ReturnExtendsOrg_Apache_Kafka_Common_Metric}"/>
        Map<MetricName, T> Metrics<T>() where T : Metric;
        /// <inheritdoc cref="Admin.Close()"/>
        void Close();
        /// <inheritdoc cref="Admin.Close(Duration)"/>
        void Close(Duration timeout);
        /// <inheritdoc cref="Admin.CreateTopics(Collection{NewTopic})"/>
        CreateTopicsResult CreateTopics(Collection<NewTopic> newTopics);
        /// <inheritdoc cref="Admin.CreateTopics(Collection{NewTopic}, CreateTopicsOptions)"/>
        CreateTopicsResult CreateTopics(Collection<NewTopic> newTopics, CreateTopicsOptions options);
        /// <inheritdoc cref="Admin.DeleteTopics(Collection{Java.Lang.String})"/>
        DeleteTopicsResult DeleteTopics(Collection<Java.Lang.String> topics);
        /// <inheritdoc cref="Admin.DeleteTopics(Collection{Java.Lang.String}, DeleteTopicsOptions)"/>
        DeleteTopicsResult DeleteTopics(Collection<Java.Lang.String> topics, DeleteTopicsOptions options);
        /// <inheritdoc cref="Admin.DeleteTopics(TopicCollection)"/>
        DeleteTopicsResult DeleteTopics(TopicCollection topics);
        /// <inheritdoc cref="Admin.DeleteTopics(TopicCollection, DeleteTopicsOptions)"/>
        DeleteTopicsResult DeleteTopics(TopicCollection topics, DeleteTopicsOptions options);
        /// <inheritdoc cref="Admin.ListTopics()"/>
        ListTopicsResult ListTopics();
        /// <inheritdoc cref="Admin.ListTopics(ListTopicsOptions)"/>
        ListTopicsResult ListTopics(ListTopicsOptions options);
        /// <inheritdoc cref="Admin.DescribeTopics(Collection{Java.Lang.String})"/>
        DescribeTopicsResult DescribeTopics(Collection<Java.Lang.String> topicNames);
        /// <inheritdoc cref="Admin.DescribeTopics(Collection{Java.Lang.String}, DescribeTopicsOptions)"/>
        DescribeTopicsResult DescribeTopics(Collection<Java.Lang.String> topicNames, DescribeTopicsOptions options);
        /// <inheritdoc cref="Admin.DescribeCluster()"/>
        DescribeClusterResult DescribeCluster();
        /// <inheritdoc cref="Admin.DescribeCluster(DescribeClusterOptions)"/>
        DescribeClusterResult DescribeCluster(DescribeClusterOptions options);
        /// <inheritdoc cref="Admin.DescribeAcls(AclBindingFilter)"/>
        DescribeAclsResult DescribeAcls(AclBindingFilter filter);
        /// <inheritdoc cref="Admin.DescribeAcls(AclBindingFilter, DescribeAclsOptions)"/>
        DescribeAclsResult DescribeAcls(AclBindingFilter filter, DescribeAclsOptions options);
        /// <inheritdoc cref="Admin.CreateAcls(Collection{AclBinding})"/>
        CreateAclsResult CreateAcls(Collection<AclBinding> acls);
        /// <inheritdoc cref="Admin.CreateAcls(Collection{AclBinding}, CreateAclsOptions)"/>
        CreateAclsResult CreateAcls(Collection<AclBinding> acls, CreateAclsOptions options);
        /// <inheritdoc cref="Admin.DeleteAcls(Collection{AclBindingFilter})"/>
        DeleteAclsResult DeleteAcls(Collection<AclBindingFilter> filters);
        /// <inheritdoc cref="Admin.DeleteAcls(Collection{AclBindingFilter}, DeleteAclsOptions)"/>
        DeleteAclsResult DeleteAcls(Collection<AclBindingFilter> filters, DeleteAclsOptions options);
        /// <inheritdoc cref="Admin.DescribeConfigs(Collection{ConfigResource})"/>
        DescribeConfigsResult DescribeConfigs(Collection<ConfigResource> resources);
        /// <inheritdoc cref="Admin.DescribeConfigs(Collection{ConfigResource}, DescribeConfigsOptions)"/>
        DescribeConfigsResult DescribeConfigs(Collection<ConfigResource> resources, DescribeConfigsOptions options);
        /// <inheritdoc cref="Admin.IncrementalAlterConfigs(Map{ConfigResource, Collection{AlterConfigOp}})"/>
        AlterConfigsResult IncrementalAlterConfigs(Map<ConfigResource, Collection<AlterConfigOp>> configs);
        /// <inheritdoc cref="Admin.IncrementalAlterConfigs(Map{ConfigResource, Collection{AlterConfigOp}}, AlterConfigsOptions)"/>
        AlterConfigsResult IncrementalAlterConfigs(Map<ConfigResource, Collection<AlterConfigOp>> configs, AlterConfigsOptions options);
        /// <inheritdoc cref="Admin.AlterReplicaLogDirs(Map{TopicPartitionReplica, Java.Lang.String})"/>
        AlterReplicaLogDirsResult AlterReplicaLogDirs(Map<TopicPartitionReplica, Java.Lang.String> replicaAssignment);
        /// <inheritdoc cref="Admin.AlterReplicaLogDirs(Map{TopicPartitionReplica, Java.Lang.String}, AlterReplicaLogDirsOptions)"/>
        AlterReplicaLogDirsResult AlterReplicaLogDirs(Map<TopicPartitionReplica, Java.Lang.String> replicaAssignment, AlterReplicaLogDirsOptions options);
        /// <inheritdoc cref="Admin.DescribeLogDirs(Collection{Java.Lang.Integer})"/>
        DescribeLogDirsResult DescribeLogDirs(Collection<Java.Lang.Integer> brokers);
        /// <inheritdoc cref="Admin.DescribeLogDirs(Collection{Java.Lang.Integer}, DescribeLogDirsOptions)"/>
        DescribeLogDirsResult DescribeLogDirs(Collection<Java.Lang.Integer> brokers, DescribeLogDirsOptions options);
        /// <inheritdoc cref="Admin.DescribeReplicaLogDirs(Collection{TopicPartitionReplica})"/>
        DescribeReplicaLogDirsResult DescribeReplicaLogDirs(Collection<TopicPartitionReplica> replicas);
        /// <inheritdoc cref="Admin.DescribeReplicaLogDirs(Collection{TopicPartitionReplica}, DescribeReplicaLogDirsOptions)"/>
        DescribeReplicaLogDirsResult DescribeReplicaLogDirs(Collection<TopicPartitionReplica> replicas, DescribeReplicaLogDirsOptions options);
        /// <inheritdoc cref="Admin.CreatePartitions(Map{Java.Lang.String, NewPartitions})"/>
        CreatePartitionsResult CreatePartitions(Map<Java.Lang.String, NewPartitions> newPartitions);
        /// <inheritdoc cref="Admin.CreatePartitions(Map{Java.Lang.String, NewPartitions}, CreatePartitionsOptions)"/>
        CreatePartitionsResult CreatePartitions(Map<Java.Lang.String, NewPartitions> newPartitions, CreatePartitionsOptions options);
        /// <inheritdoc cref="Admin.DeleteRecords(Map{TopicPartition, RecordsToDelete})"/>
        DeleteRecordsResult DeleteRecords(Map<TopicPartition, RecordsToDelete> recordsToDelete);
        /// <inheritdoc cref="Admin.DeleteRecords(Map{TopicPartition, RecordsToDelete}, DeleteRecordsOptions)"/>
        DeleteRecordsResult DeleteRecords(Map<TopicPartition, RecordsToDelete> recordsToDelete, DeleteRecordsOptions options);
        /// <inheritdoc cref="Admin.CreateDelegationToken()"/>
        CreateDelegationTokenResult CreateDelegationToken();
        /// <inheritdoc cref="Admin.CreateDelegationToken(CreateDelegationTokenOptions)"/>
        CreateDelegationTokenResult CreateDelegationToken(CreateDelegationTokenOptions options);
        /// <inheritdoc cref="Admin.RenewDelegationToken(byte[])"/>
        RenewDelegationTokenResult RenewDelegationToken(byte[] hmac);
        /// <inheritdoc cref="Admin.RenewDelegationToken(byte[], RenewDelegationTokenOptions)"/>
        RenewDelegationTokenResult RenewDelegationToken(byte[] hmac, RenewDelegationTokenOptions options);
        /// <inheritdoc cref="Admin.ExpireDelegationToken(byte[])"/>
        ExpireDelegationTokenResult ExpireDelegationToken(byte[] hmac);
        /// <inheritdoc cref="Admin.ExpireDelegationToken(byte[], ExpireDelegationTokenOptions)"/>
        ExpireDelegationTokenResult ExpireDelegationToken(byte[] hmac, ExpireDelegationTokenOptions options);
        /// <inheritdoc cref="Admin.DescribeDelegationToken()"/>
        DescribeDelegationTokenResult DescribeDelegationToken();
        /// <inheritdoc cref="Admin.DescribeDelegationToken(DescribeDelegationTokenOptions)"/>
        DescribeDelegationTokenResult DescribeDelegationToken(DescribeDelegationTokenOptions options);
        /// <inheritdoc cref="Admin.DescribeConsumerGroups(Collection{Java.Lang.String}, DescribeConsumerGroupsOptions)"/>
        DescribeConsumerGroupsResult DescribeConsumerGroups(Collection<Java.Lang.String> groupIds, DescribeConsumerGroupsOptions options);
        /// <inheritdoc cref="Admin.DescribeConsumerGroups(Collection{Java.Lang.String})"/>
        DescribeConsumerGroupsResult DescribeConsumerGroups(Collection<Java.Lang.String> groupIds);
        /// <inheritdoc cref="Admin.ListConsumerGroupOffsets(Java.Lang.String, ListConsumerGroupOffsetsOptions)"/>
        ListConsumerGroupOffsetsResult ListConsumerGroupOffsets(Java.Lang.String groupId, ListConsumerGroupOffsetsOptions options);
        /// <inheritdoc cref="Admin.ListConsumerGroupOffsets(Java.Lang.String)"/>
        ListConsumerGroupOffsetsResult ListConsumerGroupOffsets(Java.Lang.String groupId);
        /// <inheritdoc cref="Admin.ListConsumerGroupOffsets(Map{Java.Lang.String, ListConsumerGroupOffsetsSpec}, ListConsumerGroupOffsetsOptions)"/>
        ListConsumerGroupOffsetsResult ListConsumerGroupOffsets(Map<Java.Lang.String, ListConsumerGroupOffsetsSpec> groupSpecs, ListConsumerGroupOffsetsOptions options);
        /// <inheritdoc cref="Admin.ListConsumerGroupOffsets(Map{Java.Lang.String, ListConsumerGroupOffsetsSpec})"/>
        ListConsumerGroupOffsetsResult ListConsumerGroupOffsets(Map<Java.Lang.String, ListConsumerGroupOffsetsSpec> groupSpecs);
        /// <inheritdoc cref="Admin.DeleteConsumerGroups(Collection{Java.Lang.String}, DeleteConsumerGroupsOptions)"/>
        DeleteConsumerGroupsResult DeleteConsumerGroups(Collection<Java.Lang.String> groupIds, DeleteConsumerGroupsOptions options);
        /// <inheritdoc cref="Admin.DeleteConsumerGroups(Collection{Java.Lang.String})"/>
        DeleteConsumerGroupsResult DeleteConsumerGroups(Collection<Java.Lang.String> groupIds);
        /// <inheritdoc cref="Admin.DeleteConsumerGroupOffsets(Java.Lang.String, Set{TopicPartition}, DeleteConsumerGroupOffsetsOptions)"/>
        DeleteConsumerGroupOffsetsResult DeleteConsumerGroupOffsets(Java.Lang.String groupId, Set<TopicPartition> partitions, DeleteConsumerGroupOffsetsOptions options);
        /// <inheritdoc cref="Admin.DeleteConsumerGroupOffsets(Java.Lang.String, Set{TopicPartition})"/>
        DeleteConsumerGroupOffsetsResult DeleteConsumerGroupOffsets(Java.Lang.String groupId, Set<TopicPartition> partitions);
        /// <inheritdoc cref="Admin.ElectLeaders(ElectionType, Set{TopicPartition})"/>
        ElectLeadersResult ElectLeaders(ElectionType electionType, Set<TopicPartition> partitions);
        /// <inheritdoc cref="Admin.ElectLeaders(ElectionType, Set{TopicPartition}, ElectLeadersOptions)"/>
        ElectLeadersResult ElectLeaders(ElectionType electionType, Set<TopicPartition> partitions, ElectLeadersOptions options);
        /// <inheritdoc cref="Admin.AlterPartitionReassignments(Map{TopicPartition, Optional{NewPartitionReassignment}})"/>
        AlterPartitionReassignmentsResult AlterPartitionReassignments(Map<TopicPartition, Optional<NewPartitionReassignment>> reassignments);
        /// <inheritdoc cref="Admin.AlterPartitionReassignments(Map{TopicPartition, Optional{NewPartitionReassignment}}, AlterPartitionReassignmentsOptions)"/>
        AlterPartitionReassignmentsResult AlterPartitionReassignments(Map<TopicPartition, Optional<NewPartitionReassignment>> reassignments, AlterPartitionReassignmentsOptions options);
        /// <inheritdoc cref="Admin.ListPartitionReassignments()"/>
        ListPartitionReassignmentsResult ListPartitionReassignments();
        /// <inheritdoc cref="Admin.ListPartitionReassignments(Set{TopicPartition})"/>
        ListPartitionReassignmentsResult ListPartitionReassignments(Set<TopicPartition> partitions);
        /// <inheritdoc cref="Admin.ListPartitionReassignments(Set{TopicPartition}, ListPartitionReassignmentsOptions)"/>
        ListPartitionReassignmentsResult ListPartitionReassignments(Set<TopicPartition> partitions, ListPartitionReassignmentsOptions options);
        /// <inheritdoc cref="Admin.ListPartitionReassignments(ListPartitionReassignmentsOptions)"/>
        ListPartitionReassignmentsResult ListPartitionReassignments(ListPartitionReassignmentsOptions options);
        /// <inheritdoc cref="Admin.ListPartitionReassignments(Optional{Set{TopicPartition}}, ListPartitionReassignmentsOptions)"/>
        ListPartitionReassignmentsResult ListPartitionReassignments(Optional<Set<TopicPartition>> partitions, ListPartitionReassignmentsOptions options);
        /// <inheritdoc cref="Admin.RemoveMembersFromConsumerGroup(Java.Lang.String, RemoveMembersFromConsumerGroupOptions)"/>
        RemoveMembersFromConsumerGroupResult RemoveMembersFromConsumerGroup(Java.Lang.String groupId, RemoveMembersFromConsumerGroupOptions options);
        /// <inheritdoc cref="Admin.AlterConsumerGroupOffsets(Java.Lang.String, Map{TopicPartition, OffsetAndMetadata})"/>
        AlterConsumerGroupOffsetsResult AlterConsumerGroupOffsets(Java.Lang.String groupId, Map<TopicPartition, OffsetAndMetadata> offsets);
        /// <inheritdoc cref="Admin.AlterConsumerGroupOffsets(Java.Lang.String, Map{TopicPartition, OffsetAndMetadata}, AlterConsumerGroupOffsetsOptions)"/>
        AlterConsumerGroupOffsetsResult AlterConsumerGroupOffsets(Java.Lang.String groupId, Map<TopicPartition, OffsetAndMetadata> offsets, AlterConsumerGroupOffsetsOptions options);
        /// <inheritdoc cref="Admin.ListOffsets(Map{TopicPartition, OffsetSpec})"/>
        ListOffsetsResult ListOffsets(Map<TopicPartition, OffsetSpec> topicPartitionOffsets);
        /// <inheritdoc cref="Admin.ListOffsets(Map{TopicPartition, OffsetSpec}, ListOffsetsOptions)"/>
        ListOffsetsResult ListOffsets(Map<TopicPartition, OffsetSpec> topicPartitionOffsets, ListOffsetsOptions options);
        /// <inheritdoc cref="Admin.DescribeClientQuotas(ClientQuotaFilter)"/>
        DescribeClientQuotasResult DescribeClientQuotas(ClientQuotaFilter filter);
        /// <inheritdoc cref="Admin.DescribeClientQuotas(ClientQuotaFilter, DescribeClientQuotasOptions)"/>
        DescribeClientQuotasResult DescribeClientQuotas(ClientQuotaFilter filter, DescribeClientQuotasOptions options);
        /// <inheritdoc cref="Admin.AlterClientQuotas(Collection{ClientQuotaAlteration})"/>
        AlterClientQuotasResult AlterClientQuotas(Collection<ClientQuotaAlteration> entries);
        /// <inheritdoc cref="Admin.AlterClientQuotas(Collection{ClientQuotaAlteration}, AlterClientQuotasOptions)"/>
        AlterClientQuotasResult AlterClientQuotas(Collection<ClientQuotaAlteration> entries, AlterClientQuotasOptions options);
        /// <inheritdoc cref="Admin.DescribeUserScramCredentials()"/>
        DescribeUserScramCredentialsResult DescribeUserScramCredentials();
        /// <inheritdoc cref="Admin.DescribeUserScramCredentials(List{Java.Lang.String})"/>
        DescribeUserScramCredentialsResult DescribeUserScramCredentials(List<Java.Lang.String> users);
        /// <inheritdoc cref="Admin.DescribeUserScramCredentials(List{Java.Lang.String}, DescribeUserScramCredentialsOptions)"/>
        DescribeUserScramCredentialsResult DescribeUserScramCredentials(List<Java.Lang.String> users, DescribeUserScramCredentialsOptions options);
        /// <inheritdoc cref="Admin.AlterUserScramCredentials(List{UserScramCredentialAlteration})"/>
        AlterUserScramCredentialsResult AlterUserScramCredentials(List<UserScramCredentialAlteration> alterations);
        /// <inheritdoc cref="Admin.AlterUserScramCredentials(List{UserScramCredentialAlteration}, AlterUserScramCredentialsOptions)"/>
        AlterUserScramCredentialsResult AlterUserScramCredentials(List<UserScramCredentialAlteration> alterations, AlterUserScramCredentialsOptions options);
        /// <inheritdoc cref="Admin.DescribeFeatures()"/>
        DescribeFeaturesResult DescribeFeatures();
        /// <inheritdoc cref="Admin.DescribeFeatures(DescribeFeaturesOptions)"/>
        DescribeFeaturesResult DescribeFeatures(DescribeFeaturesOptions options);
        /// <inheritdoc cref="Admin.UpdateFeatures(Map{Java.Lang.String, FeatureUpdate}, UpdateFeaturesOptions)"/>
        UpdateFeaturesResult UpdateFeatures(Map<Java.Lang.String, FeatureUpdate> featureUpdates, UpdateFeaturesOptions options);
        /// <inheritdoc cref="Admin.DescribeMetadataQuorum()"/>
        DescribeMetadataQuorumResult DescribeMetadataQuorum();
        /// <inheritdoc cref="Admin.DescribeMetadataQuorum(DescribeMetadataQuorumOptions)"/>
        DescribeMetadataQuorumResult DescribeMetadataQuorum(DescribeMetadataQuorumOptions options);
        /// <inheritdoc cref="Admin.UnregisterBroker(int)"/>
        UnregisterBrokerResult UnregisterBroker(int brokerId);
        /// <inheritdoc cref="Admin.UnregisterBroker(int, UnregisterBrokerOptions)"/>
        UnregisterBrokerResult UnregisterBroker(int brokerId, UnregisterBrokerOptions options);
        /// <inheritdoc cref="Admin.DescribeProducers(Collection{TopicPartition})"/>
        DescribeProducersResult DescribeProducers(Collection<TopicPartition> partitions);
        /// <inheritdoc cref="Admin.DescribeProducers(Collection{TopicPartition}, DescribeProducersOptions)"/>
        DescribeProducersResult DescribeProducers(Collection<TopicPartition> partitions, DescribeProducersOptions options);
        /// <inheritdoc cref="Admin.DescribeTransactions(Collection{Java.Lang.String})"/>
        DescribeTransactionsResult DescribeTransactions(Collection<Java.Lang.String> transactionalIds);
        /// <inheritdoc cref="Admin.DescribeTransactions(Collection{Java.Lang.String}, DescribeTransactionsOptions)"/>
        DescribeTransactionsResult DescribeTransactions(Collection<Java.Lang.String> transactionalIds, DescribeTransactionsOptions options);
        /// <inheritdoc cref="Admin.AbortTransaction(AbortTransactionSpec)"/>
        AbortTransactionResult AbortTransaction(AbortTransactionSpec spec);
        /// <inheritdoc cref="Admin.AbortTransaction(AbortTransactionSpec, AbortTransactionOptions)"/>
        AbortTransactionResult AbortTransaction(AbortTransactionSpec spec, AbortTransactionOptions options);
        /// <inheritdoc cref="Admin.ListTransactions()"/>
        ListTransactionsResult ListTransactions();
        /// <inheritdoc cref="Admin.ListTransactions(ListTransactionsOptions)"/>
        ListTransactionsResult ListTransactions(ListTransactionsOptions options);
        /// <inheritdoc cref="Admin.FenceProducers(Collection{Java.Lang.String})"/>
        FenceProducersResult FenceProducers(Collection<Java.Lang.String> transactionalIds);
        /// <inheritdoc cref="Admin.FenceProducers(Collection{Java.Lang.String}, FenceProducersOptions)"/>
        FenceProducersResult FenceProducers(Collection<Java.Lang.String> transactionalIds, FenceProducersOptions options);
    }
}

