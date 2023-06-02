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
    public partial class KafkaAdminClient : IAdmin
    {
        public Map<MetricName, Metric> Metrics => IExecute<Map<MetricName, Metric>>("metrics");

        public static KafkaAdminClient Create(Properties props)
        {
            return SExecute<KafkaAdminClient>("create", props);
        }

        public CreateTopicsResult CreateTopics(Collection<NewTopic> newTopics)
        {
            return IExecute<CreateTopicsResult>("createTopics", newTopics);
        }

        public CreateTopicsResult CreateTopics(Collection<NewTopic> newTopics, CreateTopicsOptions options)
        {
            return IExecute<CreateTopicsResult>("createTopics", newTopics, options);
        }

        public CreateTopicsResult DeleteTopics(Collection<NewTopic> newTopics)
        {
            return IExecute<CreateTopicsResult>("deleteTopics", newTopics);
        }

        public DescribeConsumerGroupsResult DescribeConsumerGroups(Collection<string> groupIds)
        {
            return IExecute<DescribeConsumerGroupsResult>("describeConsumerGroups", groupIds);
        }

        public ListConsumerGroupsResult ListConsumerGroups()
        {
            return IExecute<ListConsumerGroupsResult>("listConsumerGroups");
        }

        public ElectLeadersResult ElectLeaders(ElectionType electionType, Set<TopicPartition> partitions)
        {
            return IExecute<ElectLeadersResult>("electLeaders", (byte)electionType, partitions);
        }

        public void Close()
        {
            IExecute("close");
        }

        public void Close(Duration timeout)
        {
            IExecute("close", timeout);
        }

        public DeleteTopicsResult DeleteTopics(Collection<string> topics)
        {
            return IExecute<DeleteTopicsResult>("deleteTopics", topics);
        }

        public DeleteTopicsResult DeleteTopics(Collection<string> topics, DeleteTopicsOptions options)
        {
            return IExecute<DeleteTopicsResult>("deleteTopics", topics, options);
        }

        public ListTopicsResult ListTopics()
        {
            return IExecute<ListTopicsResult>("listTopics");
        }

        public DescribeTopicsResult DescribeTopics(Collection<string> topicNames)
        {
            return IExecute<DescribeTopicsResult>("describeTopics", topicNames);
        }

        public DescribeClusterResult DescribeCluster()
        {
            return IExecute<DescribeClusterResult>("describeCluster");
        }

        public DeleteTopicsResult DeleteTopics(TopicCollection topics)
        {
            return IExecute<DeleteTopicsResult>("deleteTopics", topics);
        }

        public DeleteTopicsResult DeleteTopics(TopicCollection topics, DeleteTopicsOptions options)
        {
            return IExecute<DeleteTopicsResult>("deleteTopics", topics, options);
        }

        public ListTopicsResult ListTopics(ListTopicsOptions options)
        {
            return IExecute<ListTopicsResult>("listTopics", options);
        }

        public DescribeTopicsResult DescribeTopics(Collection<string> topicNames, DescribeTopicsOptions options)
        {
            return IExecute<DescribeTopicsResult>("describeTopics", topicNames, options);
        }

        public DescribeClusterResult DescribeCluster(DescribeClusterOptions options)
        {
            return IExecute<DescribeClusterResult>("describeCluster", options);
        }

        public DescribeAclsResult DescribeAcls(AclBindingFilter filter)
        {
            return IExecute<DescribeAclsResult>("describeAcls", filter);
        }

        public DescribeAclsResult DescribeAcls(AclBindingFilter filter, DescribeAclsOptions options)
        {
            return IExecute<DescribeAclsResult>("describeAcls", filter, options);
        }

        public CreateAclsResult CreateAcls(Collection<AclBinding> acls)
        {
            return IExecute<CreateAclsResult>("createAcls", acls);
        }

        public CreateAclsResult CreateAcls(Collection<AclBinding> acls, CreateAclsOptions options)
        {
            return IExecute<CreateAclsResult>("createAcls", acls, options);
        }

        public DeleteAclsResult DeleteAcls(Collection<AclBindingFilter> filters)
        {
            return IExecute<DeleteAclsResult>("deleteAcls", filters);
        }

        public DeleteAclsResult DeleteAcls(Collection<AclBindingFilter> filters, DeleteAclsOptions options)
        {
            return IExecute<DeleteAclsResult>("deleteAcls", filters, options);
        }

        public DescribeConfigsResult DescribeConfigs(Collection<ConfigResource> resources)
        {
            return IExecute<DescribeConfigsResult>("describeConfigs", resources);
        }

        public DescribeConfigsResult DescribeConfigs(Collection<ConfigResource> resources, DescribeConfigsOptions options)
        {
            return IExecute<DescribeConfigsResult>("describeConfigs", resources, options);
        }

        public AlterConfigsResult IncrementalAlterConfigs(Map<ConfigResource, Collection<AlterConfigOp>> configs)
        {
            return IExecute<AlterConfigsResult>("incrementalAlterConfigs", configs);
        }

        public AlterConfigsResult IncrementalAlterConfigs(Map<ConfigResource, Collection<AlterConfigOp>> configs, AlterConfigsOptions options)
        {
            return IExecute<AlterConfigsResult>("incrementalAlterConfigs", configs, options);
        }

        public AlterReplicaLogDirsResult AlterReplicaLogDirs(Map<TopicPartitionReplica, string> replicaAssignment)
        {
            return IExecute<AlterReplicaLogDirsResult>("alterReplicaLogDirs", replicaAssignment);
        }

        public AlterReplicaLogDirsResult AlterReplicaLogDirs(Map<TopicPartitionReplica, string> replicaAssignment, AlterReplicaLogDirsOptions options)
        {
            return IExecute<AlterReplicaLogDirsResult>("alterReplicaLogDirs", replicaAssignment, options);
        }

        public DescribeLogDirsResult DescribeLogDirs(Collection<int> brokers)
        {
            return IExecute<DescribeLogDirsResult>("describeLogDirs", brokers);
        }

        public DescribeLogDirsResult DescribeLogDirs(Collection<int> brokers, DescribeLogDirsOptions options)
        {
            return IExecute<DescribeLogDirsResult>("describeLogDirs", brokers, options);
        }

        public DescribeReplicaLogDirsResult DescribeReplicaLogDirs(Collection<TopicPartitionReplica> replicas)
        {
            return IExecute<DescribeReplicaLogDirsResult>("describeReplicaLogDirs", replicas);
        }

        public DescribeReplicaLogDirsResult DescribeReplicaLogDirs(Collection<TopicPartitionReplica> replicas, DescribeReplicaLogDirsOptions options)
        {
            return IExecute<DescribeReplicaLogDirsResult>("describeReplicaLogDirs", replicas, options);
        }

        public CreatePartitionsResult CreatePartitions(Map<string, NewPartitions> newPartitions)
        {
            return IExecute<CreatePartitionsResult>("createPartitions", newPartitions);
        }

        public CreatePartitionsResult CreatePartitions(Map<string, NewPartitions> newPartitions, CreatePartitionsOptions options)
        {
            return IExecute<CreatePartitionsResult>("createPartitions", newPartitions, options);
        }

        public DeleteRecordsResult DeleteRecords(Map<TopicPartition, RecordsToDelete> recordsToDelete)
        {
            return IExecute<DeleteRecordsResult>("deleteRecords", recordsToDelete);
        }

        public DeleteRecordsResult DeleteRecords(Map<TopicPartition, RecordsToDelete> recordsToDelete, DeleteRecordsOptions options)
        {
            return IExecute<DeleteRecordsResult>("deleteRecords", recordsToDelete, options);
        }

        public CreateDelegationTokenResult CreateDelegationToken()
        {
            return IExecute<CreateDelegationTokenResult>("createDelegationToken");
        }

        public CreateDelegationTokenResult CreateDelegationToken(CreateDelegationTokenOptions options)
        {
            return IExecute<CreateDelegationTokenResult>("createDelegationToken", options);
        }

        public RenewDelegationTokenResult RenewDelegationToken(byte[] hmac)
        {
            return IExecute<RenewDelegationTokenResult>("renewDelegationToken", hmac);
        }

        public RenewDelegationTokenResult RenewDelegationToken(byte[] hmac, RenewDelegationTokenOptions options)
        {
            return IExecute<RenewDelegationTokenResult>("renewDelegationToken", hmac, options);
        }

        public ExpireDelegationTokenResult ExpireDelegationToken(byte[] hmac)
        {
            return IExecute<ExpireDelegationTokenResult>("expireDelegationToken", hmac);
        }

        public ExpireDelegationTokenResult ExpireDelegationToken(byte[] hmac, ExpireDelegationTokenOptions options)
        {
            return IExecute<ExpireDelegationTokenResult>("expireDelegationToken", hmac, options);
        }

        public DescribeDelegationTokenResult DescribeDelegationToken()
        {
            return IExecute<DescribeDelegationTokenResult>("describeDelegationToken");
        }

        public DescribeDelegationTokenResult DescribeDelegationToken(DescribeDelegationTokenOptions options)
        {
            return IExecute<DescribeDelegationTokenResult>("describeDelegationToken", options);
        }

        public DescribeConsumerGroupsResult DescribeConsumerGroups(Collection<string> groupIds, DescribeConsumerGroupsOptions options)
        {
            return IExecute<DescribeConsumerGroupsResult>("describeConsumerGroups", groupIds, options);
        }

        public ListConsumerGroupsResult ListConsumerGroups(ListConsumerGroupsOptions options)
        {
            return IExecute<ListConsumerGroupsResult>("listConsumerGroups", options);
        }

        public ListConsumerGroupOffsetsResult ListConsumerGroupOffsets(string groupId, ListConsumerGroupOffsetsOptions options)
        {
            return IExecute<ListConsumerGroupOffsetsResult>("listConsumerGroupOffsets", groupId, options);
        }

        public ListConsumerGroupOffsetsResult ListConsumerGroupOffsets(string groupId)
        {
            return IExecute<ListConsumerGroupOffsetsResult>("listConsumerGroupOffsets", groupId);
        }

        public ListConsumerGroupOffsetsResult ListConsumerGroupOffsets(Map<string, ListConsumerGroupOffsetsSpec> groupSpecs, ListConsumerGroupOffsetsOptions options)
        {
            return IExecute<ListConsumerGroupOffsetsResult>("listConsumerGroupOffsets", groupSpecs, options);
        }

        public ListConsumerGroupOffsetsResult ListConsumerGroupOffsets(Map<string, ListConsumerGroupOffsetsSpec> groupSpecs)
        {
            return IExecute<ListConsumerGroupOffsetsResult>("listConsumerGroupOffsets", groupSpecs);
        }

        public DeleteConsumerGroupsResult DeleteConsumerGroups(Collection<string> groupIds, DeleteConsumerGroupsOptions options)
        {
            return IExecute<DeleteConsumerGroupsResult>("deleteConsumerGroups", groupIds, options);
        }

        public DeleteConsumerGroupsResult DeleteConsumerGroups(Collection<string> groupIds)
        {
            return IExecute<DeleteConsumerGroupsResult>("deleteConsumerGroups", groupIds);
        }

        public DeleteConsumerGroupOffsetsResult DeleteConsumerGroupOffsets(string groupId, Set<TopicPartition> partitions, DeleteConsumerGroupOffsetsOptions options)
        {
            return IExecute<DeleteConsumerGroupOffsetsResult>("deleteConsumerGroupOffsets", groupId, partitions, options);
        }

        public DeleteConsumerGroupOffsetsResult DeleteConsumerGroupOffsets(string groupId, Set<TopicPartition> partitions)
        {
            return IExecute<DeleteConsumerGroupOffsetsResult>("deleteConsumerGroupOffsets", groupId, partitions);
        }

        public ElectLeadersResult ElectLeaders(ElectionType electionType, Set<TopicPartition> partitions, ElectLeadersOptions options)
        {
            return IExecute<ElectLeadersResult>("electLeaders", electionType, partitions, options);
        }

        public AlterPartitionReassignmentsResult AlterPartitionReassignments(Map<TopicPartition, Optional<NewPartitionReassignment>> reassignments)
        {
            return IExecute<AlterPartitionReassignmentsResult>("alterPartitionReassignments", reassignments);
        }

        public AlterPartitionReassignmentsResult AlterPartitionReassignments(Map<TopicPartition, Optional<NewPartitionReassignment>> reassignments, AlterPartitionReassignmentsOptions options)
        {
            return IExecute<AlterPartitionReassignmentsResult>("alterPartitionReassignments", reassignments, options);
        }

        public ListPartitionReassignmentsResult ListPartitionReassignments()
        {
            return IExecute<ListPartitionReassignmentsResult>("listPartitionReassignments");
        }

        public ListPartitionReassignmentsResult ListPartitionReassignments(Set<TopicPartition> partitions)
        {
            return IExecute<ListPartitionReassignmentsResult>("listPartitionReassignments", partitions);
        }

        public ListPartitionReassignmentsResult ListPartitionReassignments(Set<TopicPartition> partitions, ListPartitionReassignmentsOptions options)
        {
            return IExecute<ListPartitionReassignmentsResult>("listPartitionReassignments", partitions, options);
        }

        public ListPartitionReassignmentsResult ListPartitionReassignments(ListPartitionReassignmentsOptions options)
        {
            return IExecute<ListPartitionReassignmentsResult>("listPartitionReassignments", options);
        }

        public ListPartitionReassignmentsResult ListPartitionReassignments(Optional<Set<TopicPartition>> partitions, ListPartitionReassignmentsOptions options)
        {
            return IExecute<ListPartitionReassignmentsResult>("listPartitionReassignments", partitions, options);
        }

        public RemoveMembersFromConsumerGroupResult RemoveMembersFromConsumerGroup(string groupId, RemoveMembersFromConsumerGroupOptions options)
        {
            return IExecute<RemoveMembersFromConsumerGroupResult>("removeMembersFromConsumerGroup", groupId, options);
        }

        public AlterConsumerGroupOffsetsResult AlterConsumerGroupOffsets(string groupId, Map<TopicPartition, OffsetAndMetadata> offsets)
        {
            return IExecute<AlterConsumerGroupOffsetsResult>("alterConsumerGroupOffsets", groupId, offsets);
        }

        public AlterConsumerGroupOffsetsResult AlterConsumerGroupOffsets(string groupId, Map<TopicPartition, OffsetAndMetadata> offsets, AlterConsumerGroupOffsetsOptions options)
        {
            return IExecute<AlterConsumerGroupOffsetsResult>("alterConsumerGroupOffsets", groupId, offsets, options);
        }

        public ListOffsetsResult ListOffsets(Map<TopicPartition, OffsetSpec> topicPartitionOffsets)
        {
            return IExecute<ListOffsetsResult>("listOffsets", topicPartitionOffsets);
        }

        public ListOffsetsResult ListOffsets(Map<TopicPartition, OffsetSpec> topicPartitionOffsets, ListOffsetsOptions options)
        {
            return IExecute<ListOffsetsResult>("listOffsets", topicPartitionOffsets, options);
        }

        public DescribeClientQuotasResult DescribeClientQuotas(ClientQuotaFilter filter)
        {
            return IExecute<DescribeClientQuotasResult>("describeClientQuotas", filter);
        }

        public DescribeClientQuotasResult DescribeClientQuotas(ClientQuotaFilter filter, DescribeClientQuotasOptions options)
        {
            return IExecute<DescribeClientQuotasResult>("describeClientQuotas", filter, options);
        }

        public AlterClientQuotasResult AlterClientQuotas(Collection<ClientQuotaAlteration> entries)
        {
            return IExecute<AlterClientQuotasResult>("alterClientQuotas", entries);
        }

        public AlterClientQuotasResult AlterClientQuotas(Collection<ClientQuotaAlteration> entries, AlterClientQuotasOptions options)
        {
            return IExecute<AlterClientQuotasResult>("alterClientQuotas", entries, options);
        }

        public DescribeUserScramCredentialsResult DescribeUserScramCredentials()
        {
            return IExecute<DescribeUserScramCredentialsResult>("describeUserScramCredentials");
        }

        public DescribeUserScramCredentialsResult DescribeUserScramCredentials(List<string> users)
        {
            return IExecute<DescribeUserScramCredentialsResult>("describeUserScramCredentials", users);
        }

        public DescribeUserScramCredentialsResult DescribeUserScramCredentials(List<string> users, DescribeUserScramCredentialsOptions options)
        {
            return IExecute<DescribeUserScramCredentialsResult>("describeUserScramCredentials", users, options);
        }

        public AlterUserScramCredentialsResult AlterUserScramCredentials(List<UserScramCredentialAlteration> alterations)
        {
            return IExecute<AlterUserScramCredentialsResult>("alterUserScramCredentials", alterations);
        }

        public AlterUserScramCredentialsResult AlterUserScramCredentials(List<UserScramCredentialAlteration> alterations, AlterUserScramCredentialsOptions options)
        {
            return IExecute<AlterUserScramCredentialsResult>("alterUserScramCredentials", alterations, options);
        }

        public DescribeFeaturesResult DescribeFeatures()
        {
            return IExecute<DescribeFeaturesResult>("describeFeatures");
        }

        public DescribeFeaturesResult DescribeFeatures(DescribeFeaturesOptions options)
        {
            return IExecute<DescribeFeaturesResult>("describeFeatures", options);
        }

        public UpdateFeaturesResult UpdateFeatures(Map<string, FeatureUpdate> featureUpdates, UpdateFeaturesOptions options)
        {
            return IExecute<UpdateFeaturesResult>("updateFeatures", featureUpdates, options);
        }

        public DescribeMetadataQuorumResult DescribeMetadataQuorum()
        {
            return IExecute<DescribeMetadataQuorumResult>("describeMetadataQuorum");
        }

        public DescribeMetadataQuorumResult DescribeMetadataQuorum(DescribeMetadataQuorumOptions options)
        {
            return IExecute<DescribeMetadataQuorumResult>("describeMetadataQuorum", options);
        }


        public UnregisterBrokerResult UnregisterBroker(int brokerId)
        {
            return IExecute<UnregisterBrokerResult>("unregisterBroker", brokerId);
        }

        public UnregisterBrokerResult UnregisterBroker(int brokerId, UnregisterBrokerOptions options)
        {
            return IExecute<UnregisterBrokerResult>("unregisterBroker", brokerId, options);
        }

        public DescribeProducersResult DescribeProducers(Collection<TopicPartition> partitions)
        {
            return IExecute<DescribeProducersResult>("describeProducers", partitions);
        }

        public DescribeProducersResult DescribeProducers(Collection<TopicPartition> partitions, DescribeProducersOptions options)
        {
            return IExecute<DescribeProducersResult>("describeProducers", partitions, options);
        }

        public DescribeTransactionsResult DescribeTransactions(Collection<string> transactionalIds)
        {
            return IExecute<DescribeTransactionsResult>("describeTransactions", transactionalIds);
        }

        public DescribeTransactionsResult DescribeTransactions(Collection<string> transactionalIds, DescribeTransactionsOptions options)
        {
            return IExecute<DescribeTransactionsResult>("describeTransactions", transactionalIds, options);
        }

        public AbortTransactionResult AbortTransaction(AbortTransactionSpec spec)
        {
            return IExecute<AbortTransactionResult>("abortTransaction", spec);
        }

        public AbortTransactionResult AbortTransaction(AbortTransactionSpec spec, AbortTransactionOptions options)
        {
            return IExecute<AbortTransactionResult>("abortTransaction", spec, options);
        }

        public ListTransactionsResult ListTransactions()
        {
            return IExecute<ListTransactionsResult>("listTransactions");
        }

        public ListTransactionsResult ListTransactions(ListTransactionsOptions options)
        {
            return IExecute<ListTransactionsResult>("listTransactions", options);
        }

        public FenceProducersResult FenceProducers(Collection<string> transactionalIds)
        {
            return IExecute<FenceProducersResult>("fenceProducers", transactionalIds);
        }

        public FenceProducersResult FenceProducers(Collection<string> transactionalIds, FenceProducersOptions options)
        {
            return IExecute<FenceProducersResult>("fenceProducers", transactionalIds, options);
        }
    }
}

