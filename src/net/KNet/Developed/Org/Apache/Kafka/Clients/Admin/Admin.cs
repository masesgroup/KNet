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
        /// <inheritdoc cref="Admin.DeleteTopics(Collection{string})"/>
        DeleteTopicsResult DeleteTopics(Collection<string> topics);
        /// <inheritdoc cref="Admin.DeleteTopics(Collection{string}, DeleteTopicsOptions)"/>
        DeleteTopicsResult DeleteTopics(Collection<string> topics, DeleteTopicsOptions options);
        /// <inheritdoc cref="Admin.DeleteTopics(TopicCollection)"/>
        DeleteTopicsResult DeleteTopics(TopicCollection topics);
        /// <inheritdoc cref="Admin.DeleteTopics(TopicCollection, DeleteTopicsOptions)"/>
        DeleteTopicsResult DeleteTopics(TopicCollection topics, DeleteTopicsOptions options);
        /// <inheritdoc cref="Admin.ListTopics()"/>
        ListTopicsResult ListTopics();
        /// <inheritdoc cref="Admin.ListTopics(ListTopicsOptions)"/>
        ListTopicsResult ListTopics(ListTopicsOptions options);
        /// <inheritdoc cref="Admin.DescribeTopics(Collection{string})"/>
        DescribeTopicsResult DescribeTopics(Collection<string> topicNames);
        /// <inheritdoc cref="Admin.DescribeTopics(Collection{string}, DescribeTopicsOptions)"/>
        DescribeTopicsResult DescribeTopics(Collection<string> topicNames, DescribeTopicsOptions options);
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
        /// <inheritdoc cref="Admin.AlterReplicaLogDirs(Map{TopicPartitionReplica, string})"/>
        AlterReplicaLogDirsResult AlterReplicaLogDirs(Map<TopicPartitionReplica, string> replicaAssignment);
        /// <inheritdoc cref="Admin.AlterReplicaLogDirs(Map{TopicPartitionReplica, string}, AlterReplicaLogDirsOptions)"/>
        AlterReplicaLogDirsResult AlterReplicaLogDirs(Map<TopicPartitionReplica, string> replicaAssignment, AlterReplicaLogDirsOptions options);
        /// <inheritdoc cref="Admin.DescribeLogDirs(Collection{Java.Lang.Integer})"/>
        DescribeLogDirsResult DescribeLogDirs(Collection<Java.Lang.Integer> brokers);
        /// <inheritdoc cref="Admin.DescribeLogDirs(Collection{Java.Lang.Integer}, DescribeLogDirsOptions)"/>
        DescribeLogDirsResult DescribeLogDirs(Collection<Java.Lang.Integer> brokers, DescribeLogDirsOptions options);
        /// <inheritdoc cref="Admin.DescribeReplicaLogDirs(Collection{TopicPartitionReplica})"/>
        DescribeReplicaLogDirsResult DescribeReplicaLogDirs(Collection<TopicPartitionReplica> replicas);
        /// <inheritdoc cref="Admin.DescribeReplicaLogDirs(Collection{TopicPartitionReplica}, DescribeReplicaLogDirsOptions)"/>
        DescribeReplicaLogDirsResult DescribeReplicaLogDirs(Collection<TopicPartitionReplica> replicas, DescribeReplicaLogDirsOptions options);
        /// <inheritdoc cref="Admin.CreatePartitions(Map{string, NewPartitions})"/>
        CreatePartitionsResult CreatePartitions(Map<string, NewPartitions> newPartitions);
        /// <inheritdoc cref="Admin.CreatePartitions(Map{string, NewPartitions}, CreatePartitionsOptions)"/>
        CreatePartitionsResult CreatePartitions(Map<string, NewPartitions> newPartitions, CreatePartitionsOptions options);
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
        /// <inheritdoc cref="Admin.DescribeConsumerGroups(Collection{string}, DescribeConsumerGroupsOptions)"/>
        DescribeConsumerGroupsResult DescribeConsumerGroups(Collection<string> groupIds, DescribeConsumerGroupsOptions options);
        /// <inheritdoc cref="Admin.DescribeConsumerGroups(Collection{string})"/>
        DescribeConsumerGroupsResult DescribeConsumerGroups(Collection<string> groupIds);
        /// <inheritdoc cref="Admin.ListConsumerGroups(ListConsumerGroupsOptions)"/>
        ListConsumerGroupsResult ListConsumerGroups(ListConsumerGroupsOptions options);
        /// <inheritdoc cref="Admin.ListConsumerGroups()"/>
        ListConsumerGroupsResult ListConsumerGroups();
        /// <inheritdoc cref="Admin.ListConsumerGroupOffsets(string, ListConsumerGroupOffsetsOptions)"/>
        ListConsumerGroupOffsetsResult ListConsumerGroupOffsets(string groupId, ListConsumerGroupOffsetsOptions options);
        /// <inheritdoc cref="Admin.ListConsumerGroupOffsets(string)"/>
        ListConsumerGroupOffsetsResult ListConsumerGroupOffsets(string groupId);
        /// <inheritdoc cref="Admin.ListConsumerGroupOffsets(Map{string, ListConsumerGroupOffsetsSpec}, ListConsumerGroupOffsetsOptions)"/>
        ListConsumerGroupOffsetsResult ListConsumerGroupOffsets(Map<string, ListConsumerGroupOffsetsSpec> groupSpecs, ListConsumerGroupOffsetsOptions options);
        /// <inheritdoc cref="Admin.ListConsumerGroupOffsets(Map{string, ListConsumerGroupOffsetsSpec})"/>
        ListConsumerGroupOffsetsResult ListConsumerGroupOffsets(Map<string, ListConsumerGroupOffsetsSpec> groupSpecs);
        /// <inheritdoc cref="Admin.DeleteConsumerGroups(Collection{string}, DeleteConsumerGroupsOptions)"/>
        DeleteConsumerGroupsResult DeleteConsumerGroups(Collection<string> groupIds, DeleteConsumerGroupsOptions options);
        /// <inheritdoc cref="Admin.DeleteConsumerGroups(Collection{string})"/>
        DeleteConsumerGroupsResult DeleteConsumerGroups(Collection<string> groupIds);
        /// <inheritdoc cref="Admin.DeleteConsumerGroupOffsets(string, Set{TopicPartition}, DeleteConsumerGroupOffsetsOptions)"/>
        DeleteConsumerGroupOffsetsResult DeleteConsumerGroupOffsets(string groupId, Set<TopicPartition> partitions, DeleteConsumerGroupOffsetsOptions options);
        /// <inheritdoc cref="Admin.DeleteConsumerGroupOffsets(string, Set{TopicPartition})"/>
        DeleteConsumerGroupOffsetsResult DeleteConsumerGroupOffsets(string groupId, Set<TopicPartition> partitions);
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
        /// <inheritdoc cref="Admin.RemoveMembersFromConsumerGroup(string, RemoveMembersFromConsumerGroupOptions)"/>
        RemoveMembersFromConsumerGroupResult RemoveMembersFromConsumerGroup(string groupId, RemoveMembersFromConsumerGroupOptions options);
        /// <inheritdoc cref="Admin.AlterConsumerGroupOffsets(string, Map{TopicPartition, OffsetAndMetadata})"/>
        AlterConsumerGroupOffsetsResult AlterConsumerGroupOffsets(string groupId, Map<TopicPartition, OffsetAndMetadata> offsets);
        /// <inheritdoc cref="Admin.AlterConsumerGroupOffsets(string, Map{TopicPartition, OffsetAndMetadata}, AlterConsumerGroupOffsetsOptions)"/>
        AlterConsumerGroupOffsetsResult AlterConsumerGroupOffsets(string groupId, Map<TopicPartition, OffsetAndMetadata> offsets, AlterConsumerGroupOffsetsOptions options);
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
        /// <inheritdoc cref="Admin.DescribeUserScramCredentials(List{string})"/>
        DescribeUserScramCredentialsResult DescribeUserScramCredentials(List<string> users);
        /// <inheritdoc cref="Admin.DescribeUserScramCredentials(List{string}, DescribeUserScramCredentialsOptions)"/>
        DescribeUserScramCredentialsResult DescribeUserScramCredentials(List<string> users, DescribeUserScramCredentialsOptions options);
        /// <inheritdoc cref="Admin.AlterUserScramCredentials(List{UserScramCredentialAlteration})"/>
        AlterUserScramCredentialsResult AlterUserScramCredentials(List<UserScramCredentialAlteration> alterations);
        /// <inheritdoc cref="Admin.AlterUserScramCredentials(List{UserScramCredentialAlteration}, AlterUserScramCredentialsOptions)"/>
        AlterUserScramCredentialsResult AlterUserScramCredentials(List<UserScramCredentialAlteration> alterations, AlterUserScramCredentialsOptions options);
        /// <inheritdoc cref="Admin.DescribeFeatures()"/>
        DescribeFeaturesResult DescribeFeatures();
        /// <inheritdoc cref="Admin.DescribeFeatures(DescribeFeaturesOptions)"/>
        DescribeFeaturesResult DescribeFeatures(DescribeFeaturesOptions options);
        /// <inheritdoc cref="Admin.UpdateFeatures(Map{string, FeatureUpdate}, UpdateFeaturesOptions)"/>
        UpdateFeaturesResult UpdateFeatures(Map<string, FeatureUpdate> featureUpdates, UpdateFeaturesOptions options);
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
        /// <inheritdoc cref="Admin.DescribeTransactions(Collection{string})"/>
        DescribeTransactionsResult DescribeTransactions(Collection<string> transactionalIds);
        /// <inheritdoc cref="Admin.DescribeTransactions(Collection{string}, DescribeTransactionsOptions)"/>
        DescribeTransactionsResult DescribeTransactions(Collection<string> transactionalIds, DescribeTransactionsOptions options);
        /// <inheritdoc cref="Admin.AbortTransaction(AbortTransactionSpec)"/>
        AbortTransactionResult AbortTransaction(AbortTransactionSpec spec);
        /// <inheritdoc cref="Admin.AbortTransaction(AbortTransactionSpec, AbortTransactionOptions)"/>
        AbortTransactionResult AbortTransaction(AbortTransactionSpec spec, AbortTransactionOptions options);
        /// <inheritdoc cref="Admin.ListTransactions()"/>
        ListTransactionsResult ListTransactions();
        /// <inheritdoc cref="Admin.ListTransactions(ListTransactionsOptions)"/>
        ListTransactionsResult ListTransactions(ListTransactionsOptions options);
        /// <inheritdoc cref="Admin.FenceProducers(Collection{string})"/>
        FenceProducersResult FenceProducers(Collection<string> transactionalIds);
        /// <inheritdoc cref="Admin.FenceProducers(Collection{string}, FenceProducersOptions)"/>
        FenceProducersResult FenceProducers(Collection<string> transactionalIds, FenceProducersOptions options);
    }
}

