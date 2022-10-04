/*
*  Copyright 2022 MASES s.r.l.
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
using MASES.KNet.Clients.Consumer;
using MASES.KNet.Common;
using MASES.KNet.Common.Acl;
using MASES.KNet.Common.Config;
using MASES.KNet.Common.Quota;
using Java.Time;
using Java.Util;

namespace MASES.KNet.Clients.Admin
{
    public interface IAdmin : IJVMBridgeBase, System.IDisposable
    {
        Map<MetricName, Metric> Metrics { get; }

        void Close();

        void Close(Duration timeout);

        CreateTopicsResult CreateTopics(Collection<NewTopic> newTopics);

        CreateTopicsResult CreateTopics(Collection<NewTopic> newTopics, CreateTopicsOptions options);

        DeleteTopicsResult DeleteTopics(Collection<string> topics);

        DeleteTopicsResult DeleteTopics(Collection<string> topics, DeleteTopicsOptions options);

        DeleteTopicsResult DeleteTopics(TopicCollection topics);

        DeleteTopicsResult DeleteTopics(TopicCollection topics, DeleteTopicsOptions options);

        ListTopicsResult ListTopics();

        ListTopicsResult ListTopics(ListTopicsOptions options);

        DescribeTopicsResult DescribeTopics(Collection<string> topicNames);

        DescribeTopicsResult DescribeTopics(Collection<string> topicNames, DescribeTopicsOptions options);

        DescribeClusterResult DescribeCluster();

        DescribeClusterResult DescribeCluster(DescribeClusterOptions options);

        DescribeAclsResult DescribeAcls(AclBindingFilter filter);

        DescribeAclsResult DescribeAcls(AclBindingFilter filter, DescribeAclsOptions options);

        CreateAclsResult CreateAcls(Collection<AclBinding> acls);

        CreateAclsResult CreateAcls(Collection<AclBinding> acls, CreateAclsOptions options);

        DeleteAclsResult DeleteAcls(Collection<AclBindingFilter> filters);

        DeleteAclsResult DeleteAcls(Collection<AclBindingFilter> filters, DeleteAclsOptions options);

        DescribeConfigsResult DescribeConfigs(Collection<ConfigResource> resources);

        DescribeConfigsResult DescribeConfigs(Collection<ConfigResource> resources, DescribeConfigsOptions options);

        AlterConfigsResult IncrementalAlterConfigs(Map<ConfigResource, Collection<AlterConfigOp>> configs);

        AlterConfigsResult IncrementalAlterConfigs(Map<ConfigResource, Collection<AlterConfigOp>> configs, AlterConfigsOptions options);

        AlterReplicaLogDirsResult AlterReplicaLogDirs(Map<TopicPartitionReplica, string> replicaAssignment);

        AlterReplicaLogDirsResult AlterReplicaLogDirs(Map<TopicPartitionReplica, string> replicaAssignment, AlterReplicaLogDirsOptions options);

        DescribeLogDirsResult DescribeLogDirs(Collection<int> brokers);

        DescribeLogDirsResult DescribeLogDirs(Collection<int> brokers, DescribeLogDirsOptions options);

        DescribeReplicaLogDirsResult DescribeReplicaLogDirs(Collection<TopicPartitionReplica> replicas);

        DescribeReplicaLogDirsResult DescribeReplicaLogDirs(Collection<TopicPartitionReplica> replicas, DescribeReplicaLogDirsOptions options);

        CreatePartitionsResult CreatePartitions(Map<string, NewPartitions> newPartitions);

        CreatePartitionsResult CreatePartitions(Map<string, NewPartitions> newPartitions, CreatePartitionsOptions options);

        DeleteRecordsResult DeleteRecords(Map<TopicPartition, RecordsToDelete> recordsToDelete);

        DeleteRecordsResult DeleteRecords(Map<TopicPartition, RecordsToDelete> recordsToDelete, DeleteRecordsOptions options);

        CreateDelegationTokenResult CreateDelegationToken();

        CreateDelegationTokenResult CreateDelegationToken(CreateDelegationTokenOptions options);

        RenewDelegationTokenResult RenewDelegationToken(byte[] hmac);

        RenewDelegationTokenResult RenewDelegationToken(byte[] hmac, RenewDelegationTokenOptions options);

        ExpireDelegationTokenResult ExpireDelegationToken(byte[] hmac);

        ExpireDelegationTokenResult ExpireDelegationToken(byte[] hmac, ExpireDelegationTokenOptions options);

        DescribeDelegationTokenResult DescribeDelegationToken();

        DescribeDelegationTokenResult DescribeDelegationToken(DescribeDelegationTokenOptions options);

        DescribeConsumerGroupsResult DescribeConsumerGroups(Collection<string> groupIds, DescribeConsumerGroupsOptions options);

        DescribeConsumerGroupsResult DescribeConsumerGroups(Collection<string> groupIds);

        ListConsumerGroupsResult ListConsumerGroups(ListConsumerGroupsOptions options);

        ListConsumerGroupsResult ListConsumerGroups();

        ListConsumerGroupOffsetsResult ListConsumerGroupOffsets(string groupId, ListConsumerGroupOffsetsOptions options);

        ListConsumerGroupOffsetsResult ListConsumerGroupOffsets(string groupId);

        ListConsumerGroupOffsetsResult ListConsumerGroupOffsets(Map<string, ListConsumerGroupOffsetsSpec> groupSpecs, ListConsumerGroupOffsetsOptions options);

        ListConsumerGroupOffsetsResult ListConsumerGroupOffsets(Map<string, ListConsumerGroupOffsetsSpec> groupSpecs);

        DeleteConsumerGroupsResult DeleteConsumerGroups(Collection<string> groupIds, DeleteConsumerGroupsOptions options);

        DeleteConsumerGroupsResult DeleteConsumerGroups(Collection<string> groupIds);

        DeleteConsumerGroupOffsetsResult DeleteConsumerGroupOffsets(string groupId, Set<TopicPartition> partitions, DeleteConsumerGroupOffsetsOptions options);

        DeleteConsumerGroupOffsetsResult DeleteConsumerGroupOffsets(string groupId, Set<TopicPartition> partitions);

        ElectLeadersResult ElectLeaders(ElectionType electionType, Set<TopicPartition> partitions);

        ElectLeadersResult ElectLeaders(ElectionType electionType, Set<TopicPartition> partitions, ElectLeadersOptions options);

        AlterPartitionReassignmentsResult AlterPartitionReassignments(Map<TopicPartition, Optional<NewPartitionReassignment>> reassignments);

        AlterPartitionReassignmentsResult AlterPartitionReassignments(Map<TopicPartition, Optional<NewPartitionReassignment>> reassignments, AlterPartitionReassignmentsOptions options);

        ListPartitionReassignmentsResult ListPartitionReassignments();

        ListPartitionReassignmentsResult ListPartitionReassignments(Set<TopicPartition> partitions);

        ListPartitionReassignmentsResult ListPartitionReassignments(Set<TopicPartition> partitions, ListPartitionReassignmentsOptions options);

        ListPartitionReassignmentsResult ListPartitionReassignments(ListPartitionReassignmentsOptions options);

        ListPartitionReassignmentsResult ListPartitionReassignments(Optional<Set<TopicPartition>> partitions, ListPartitionReassignmentsOptions options);

        RemoveMembersFromConsumerGroupResult RemoveMembersFromConsumerGroup(string groupId, RemoveMembersFromConsumerGroupOptions options);

        AlterConsumerGroupOffsetsResult AlterConsumerGroupOffsets(string groupId, Map<TopicPartition, OffsetAndMetadata> offsets);

        AlterConsumerGroupOffsetsResult AlterConsumerGroupOffsets(string groupId, Map<TopicPartition, OffsetAndMetadata> offsets, AlterConsumerGroupOffsetsOptions options);

        ListOffsetsResult ListOffsets(Map<TopicPartition, OffsetSpec> topicPartitionOffsets);

        ListOffsetsResult ListOffsets(Map<TopicPartition, OffsetSpec> topicPartitionOffsets, ListOffsetsOptions options);

        DescribeClientQuotasResult DescribeClientQuotas(ClientQuotaFilter filter);

        DescribeClientQuotasResult DescribeClientQuotas(ClientQuotaFilter filter, DescribeClientQuotasOptions options);

        AlterClientQuotasResult AlterClientQuotas(Collection<ClientQuotaAlteration> entries);

        AlterClientQuotasResult AlterClientQuotas(Collection<ClientQuotaAlteration> entries, AlterClientQuotasOptions options);

        DescribeUserScramCredentialsResult DescribeUserScramCredentials();

        DescribeUserScramCredentialsResult DescribeUserScramCredentials(List<string> users);

        DescribeUserScramCredentialsResult DescribeUserScramCredentials(List<string> users, DescribeUserScramCredentialsOptions options);

        AlterUserScramCredentialsResult AlterUserScramCredentials(List<UserScramCredentialAlteration> alterations);

        AlterUserScramCredentialsResult AlterUserScramCredentials(List<UserScramCredentialAlteration> alterations, AlterUserScramCredentialsOptions options);

        DescribeFeaturesResult DescribeFeatures();

        DescribeFeaturesResult DescribeFeatures(DescribeFeaturesOptions options);

        UpdateFeaturesResult UpdateFeatures(Map<string, FeatureUpdate> featureUpdates, UpdateFeaturesOptions options);

        DescribeMetadataQuorumResult DescribeMetadataQuorum();

        DescribeMetadataQuorumResult DescribeMetadataQuorum(DescribeMetadataQuorumOptions options);

        UnregisterBrokerResult UnregisterBroker(int brokerId);

        UnregisterBrokerResult UnregisterBroker(int brokerId, UnregisterBrokerOptions options);

        DescribeProducersResult DescribeProducers(Collection<TopicPartition> partitions);

        DescribeProducersResult DescribeProducers(Collection<TopicPartition> partitions, DescribeProducersOptions options);

        DescribeTransactionsResult DescribeTransactions(Collection<string> transactionalIds);

        DescribeTransactionsResult DescribeTransactions(Collection<string> transactionalIds, DescribeTransactionsOptions options);

        AbortTransactionResult AbortTransaction(AbortTransactionSpec spec);

        AbortTransactionResult AbortTransaction(AbortTransactionSpec spec, AbortTransactionOptions options);

        ListTransactionsResult ListTransactions();

        ListTransactionsResult ListTransactions(ListTransactionsOptions options);

        FenceProducersResult FenceProducers(Collection<string> transactionalIds);

        FenceProducersResult FenceProducers(Collection<string> transactionalIds, FenceProducersOptions options);
    }
}

