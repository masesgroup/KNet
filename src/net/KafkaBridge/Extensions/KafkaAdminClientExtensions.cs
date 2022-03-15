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

using Java.Util;
using Java.Util.Concurrent;
using MASES.KafkaBridge.Clients.Admin;
using MASES.KafkaBridge.Clients.Consumer;
using MASES.KafkaBridge.Common;
using MASES.KafkaBridge.Common.Acl;
using MASES.KafkaBridge.Common.Config;
using MASES.KafkaBridge.Common.Quota;
using System;
using System.Threading.Tasks;

namespace MASES.KafkaBridge.Extensions
{
    public static class KafkaAdminClientExtensions
    {
        async static Task<TReturn> Execute<TReturn>(Func<TReturn> func)
        {
            Task<TReturn> task = Task.Run(() =>
            {
                return func();
            });

            await task;
            if (task.Status == TaskStatus.Faulted && task.Exception != null)
            {
                var innerException = task.Exception.Flatten().InnerException;
                if (innerException is ExecutionException exException)
                {
                    throw exException.InnerException;
                }
                else throw innerException;
            }
            return task.Result;
        }

        async static Task<TReturn> Execute<TIn, TReturn>(Func<TIn, TReturn> func, TIn input)
        {
            Task<TReturn> task = Task.Run(() =>
            {
                return func(input);
            });

            await task;
            if (task.Status == TaskStatus.Faulted && task.Exception != null)
            {
                var innerException = task.Exception.Flatten().InnerException;
                if (innerException is ExecutionException exException)
                {
                    throw exException.InnerException;
                }
                else throw innerException;
            }
            return task.Result;
        }

        async static Task<TReturn> Execute<TIn1, TIn2, TReturn>(Func<TIn1, TIn2, TReturn> func, TIn1 input1, TIn2 input2)
        {
            Task<TReturn> task = Task.Run(() =>
            {
                return func(input1, input2);
            });

            await task;
            if (task.Status == TaskStatus.Faulted && task.Exception != null)
            {
                var innerException = task.Exception.Flatten().InnerException;
                if (innerException is ExecutionException exException)
                {
                    throw exException.InnerException;
                }
                else throw innerException;
            }
            return task.Result;
        }

        async static Task<TReturn> Execute<TIn1, TIn2, Tin3, TReturn>(Func<TIn1, TIn2, Tin3, TReturn> func, TIn1 input1, TIn2 input2, Tin3 input3)
        {
            Task<TReturn> task = Task.Run(() =>
            {
                return func(input1, input2, input3);
            });

            await task;
            if (task.Status == TaskStatus.Faulted && task.Exception != null)
            {
                var innerException = task.Exception.Flatten().InnerException;
                if (innerException is ExecutionException exException)
                {
                    throw exException.InnerException;
                }
                else throw innerException;
            }
            return task.Result;
        }

        public static async Task<CreateTopicsResult> CreateTopicsAsync(this IAdmin admin, Collection<NewTopic> newTopics)
        {
            return await Execute(admin.CreateTopics, newTopics);
        }

        public static void CreateTopic(this IAdmin admin, string topicName, int numPartitions = 1, short replicationFactor = 1)
        {
            try
            {
                var res = admin.CreateTopics(Collections.Singleton(new NewTopic(topicName, numPartitions, replicationFactor)));
                res.All.Get();
            }
            catch (ExecutionException ex)
            {
                throw ex.InnerException;
            }
        }

        public static async Task<CreateTopicsResult> CreateTopicAsync(this IAdmin admin, string topicName, int numPartitions = 1, short replicationFactor = 1)
        {
            return await CreateTopicsAsync(admin, Collections.Singleton(new NewTopic(topicName, numPartitions, replicationFactor)));
        }

        public static async Task<CreateTopicsResult> CreateTopicsAsync(this IAdmin admin, Collection<NewTopic> newTopics, CreateTopicsOptions options)
        {
            return await Execute(admin.CreateTopics, newTopics, options);
        }

        public static async Task<DeleteTopicsResult> DeleteTopicsAsync(this IAdmin admin, Collection<string> topics)
        {
            return await Execute(admin.DeleteTopics, topics);
        }

        public static async Task<DeleteTopicsResult> DeleteTopicAsync(this IAdmin admin, string topicName)
        {
            return await DeleteTopicsAsync(admin, Collections.Singleton(topicName));
        }

        public static async Task<DeleteTopicsResult> DeleteTopicsAsync(this IAdmin admin, Collection<string> topics, DeleteTopicsOptions options)
        {
            return await Execute(admin.DeleteTopics, topics, options);
        }

        public static async Task<DeleteTopicsResult> DeleteTopicsAsync(this IAdmin admin, TopicCollection topics)
        {
            return await Execute(admin.DeleteTopics, topics);
        }

        public static async Task<DeleteTopicsResult> DeleteTopicsAsync(this IAdmin admin, TopicCollection topics, DeleteTopicsOptions options)
        {
            return await Execute(admin.DeleteTopics, topics, options);
        }

        public static async Task<ListTopicsResult> ListTopicsAsync(this IAdmin admin)
        {
            return await Execute(admin.ListTopics);
        }

        public static async Task<ListTopicsResult> ListTopicsAsync(this IAdmin admin, ListTopicsOptions options)
        {
            return await Execute(admin.ListTopics, options);
        }

        public static async Task<DescribeTopicsResult> DescribeTopicsAsync(this IAdmin admin, Collection<string> topicNames)
        {
            return await Execute(admin.DescribeTopics, topicNames);
        }

        public static async Task<DescribeTopicsResult> DescribeTopicAsync(this IAdmin admin, string topicName)
        {
            return await Execute(admin.DescribeTopics, Collections.Singleton(topicName)) ;
        }

        public static async Task<DescribeTopicsResult> DescribeTopicsAsync(this IAdmin admin, Collection<string> topicNames, DescribeTopicsOptions options)
        {
            return await Execute(admin.DescribeTopics, topicNames, options);
        }

        public static async Task<DescribeClusterResult> DescribeClusterAsync(this IAdmin admin)
        {
            return await Execute(admin.DescribeCluster);
        }

        public static async Task<DescribeClusterResult> DescribeClusterAsync(this IAdmin admin, DescribeClusterOptions options)
        {
            return await Execute(admin.DescribeCluster, options);
        }

        public static async Task<DescribeAclsResult> DescribeAclsAsync(this IAdmin admin, AclBindingFilter filter)
        {
            return await Execute(admin.DescribeAcls, filter);
        }

        public static async Task<DescribeAclsResult> DescribeAclsAsync(this IAdmin admin, AclBindingFilter filter, DescribeAclsOptions options)
        {
            return await Execute(admin.DescribeAcls, filter, options);
        }

        public static async Task<CreateAclsResult> CreateAclsAsync(this IAdmin admin, Collection<AclBinding> acls)
        {
            return await Execute(admin.CreateAcls, acls);
        }

        public static async Task<CreateAclsResult> CreateAclsAsync(this IAdmin admin, Collection<AclBinding> acls, CreateAclsOptions options)
        {
            return await Execute(admin.CreateAcls, acls, options);
        }

        public static async Task<DeleteAclsResult> DeleteAclsAsync(this IAdmin admin, Collection<AclBindingFilter> filters)
        {
            return await Execute(admin.DeleteAcls, filters);
        }

        public static async Task<DeleteAclsResult> DeleteAclsAsync(this IAdmin admin, Collection<AclBindingFilter> filters, DeleteAclsOptions options)
        {
            return await Execute(admin.DeleteAcls, filters, options);
        }

        public static async Task<DescribeConfigsResult> DescribeConfigsAsync(this IAdmin admin, Collection<ConfigResource> resources)
        {
            return await Execute(admin.DescribeConfigs, resources);
        }

        public static async Task<DescribeConfigsResult> DescribeConfigsAsync(this IAdmin admin, Collection<ConfigResource> resources, DescribeConfigsOptions options)
        {
            return await Execute(admin.DescribeConfigs, resources, options);
        }

        public static async Task<AlterConfigsResult> IncrementalAlterConfigsAsync(this IAdmin admin, Map<ConfigResource, Collection<AlterConfigOp>> configs)
        {
            return await Execute(admin.IncrementalAlterConfigs, configs);
        }

        public static async Task<AlterConfigsResult> IncrementalAlterConfigsAsync(this IAdmin admin, Map<ConfigResource, Collection<AlterConfigOp>> configs, AlterConfigsOptions options)
        {
            return await Execute(admin.IncrementalAlterConfigs, configs, options);
        }

        public static async Task<AlterReplicaLogDirsResult> AlterReplicaLogDirsAsync(this IAdmin admin, Map<TopicPartitionReplica, string> replicaAssignment)
        {
            return await Execute(admin.AlterReplicaLogDirs, replicaAssignment);
        }

        public static async Task<AlterReplicaLogDirsResult> AlterReplicaLogDirsAsync(this IAdmin admin, Map<TopicPartitionReplica, string> replicaAssignment, AlterReplicaLogDirsOptions options)
        {
            return await Execute(admin.AlterReplicaLogDirs, replicaAssignment, options);
        }

        public static async Task<DescribeLogDirsResult> DescribeLogDirsAsync(this IAdmin admin, Collection<int> brokers)
        {
            return await Execute(admin.DescribeLogDirs, brokers);
        }

        public static async Task<DescribeLogDirsResult> DescribeLogDirsAsync(this IAdmin admin, Collection<int> brokers, DescribeLogDirsOptions options)
        {
            return await Execute(admin.DescribeLogDirs, brokers, options);
        }

        public static async Task<DescribeReplicaLogDirsResult> DescribeReplicaLogDirsAsync(this IAdmin admin, Collection<TopicPartitionReplica> replicas)
        {
            return await Execute(admin.DescribeReplicaLogDirs, replicas);
        }

        public static async Task<DescribeReplicaLogDirsResult> DescribeReplicaLogDirsAsync(this IAdmin admin, Collection<TopicPartitionReplica> replicas, DescribeReplicaLogDirsOptions options)
        {
            return await Execute(admin.DescribeReplicaLogDirs, replicas, options);
        }

        public static async Task<CreatePartitionsResult> CreatePartitionsAsync(this IAdmin admin, Map<string, NewPartitions> newPartitions)
        {
            return await Execute(admin.CreatePartitions, newPartitions);
        }

        public static async Task<CreatePartitionsResult> CreatePartitionsAsync(this IAdmin admin, Map<string, NewPartitions> newPartitions, CreatePartitionsOptions options)
        {
            return await Execute(admin.CreatePartitions, newPartitions, options);
        }

        public static async Task<DeleteRecordsResult> DeleteRecordsAsync(this IAdmin admin, Map<TopicPartition, RecordsToDelete> recordsToDelete)
        {
            return await Execute(admin.DeleteRecords, recordsToDelete);
        }

        public static async Task<DeleteRecordsResult> DeleteRecordsAsync(this IAdmin admin, Map<TopicPartition, RecordsToDelete> recordsToDelete, DeleteRecordsOptions options)
        {
            return await Execute(admin.DeleteRecords, recordsToDelete, options);
        }

        public static async Task<CreateDelegationTokenResult> CreateDelegationTokenAsync(this IAdmin admin)
        {
            return await Execute(admin.CreateDelegationToken);
        }

        public static async Task<CreateDelegationTokenResult> CreateDelegationTokenAsync(this IAdmin admin, CreateDelegationTokenOptions options)
        {
            return await Execute(admin.CreateDelegationToken, options);
        }

        public static async Task<RenewDelegationTokenResult> RenewDelegationTokenAsync(this IAdmin admin, byte[] hmac)
        {
            return await Execute(admin.RenewDelegationToken, hmac);
        }

        public static async Task<RenewDelegationTokenResult> RenewDelegationTokenAsync(this IAdmin admin, byte[] hmac, RenewDelegationTokenOptions options)
        {
            return await Execute(admin.RenewDelegationToken, hmac, options);
        }

        public static async Task<ExpireDelegationTokenResult> ExpireDelegationTokenAsync(this IAdmin admin, byte[] hmac)
        {
            return await Execute(admin.ExpireDelegationToken, hmac);
        }

        public static async Task<ExpireDelegationTokenResult> ExpireDelegationTokenAsync(this IAdmin admin, byte[] hmac, ExpireDelegationTokenOptions options)
        {
            return await Execute(admin.ExpireDelegationToken, hmac, options);
        }

        public static async Task<DescribeDelegationTokenResult> DescribeDelegationTokenAsync(this IAdmin admin)
        {
            return await Execute(admin.DescribeDelegationToken);
        }

        public static async Task<DescribeDelegationTokenResult> DescribeDelegationTokenAsync(this IAdmin admin, DescribeDelegationTokenOptions options)
        {
            return await Execute(admin.DescribeDelegationToken, options);
        }

        public static async Task<DescribeConsumerGroupsResult> DescribeConsumerGroupsAsync(this IAdmin admin, Collection<string> groupIds, DescribeConsumerGroupsOptions options)
        {
            return await Execute(admin.DescribeConsumerGroups, groupIds, options);
        }

        public static async Task<DescribeConsumerGroupsResult> DescribeConsumerGroupsAsync(this IAdmin admin, Collection<string> groupIds)
        {
            return await Execute(admin.DescribeConsumerGroups, groupIds);
        }

        public static async Task<ListConsumerGroupsResult> ListConsumerGroupsAsync(this IAdmin admin, ListConsumerGroupsOptions options)
        {
            return await Execute(admin.ListConsumerGroups, options);
        }

        public static async Task<ListConsumerGroupsResult> ListConsumerGroupsAsync(this IAdmin admin)
        {
            return await Execute(admin.ListConsumerGroups);
        }

        public static async Task<ListConsumerGroupOffsetsResult> ListConsumerGroupOffsetsAsync(this IAdmin admin, string groupId, ListConsumerGroupOffsetsOptions options)
        {
            return await Execute(admin.ListConsumerGroupOffsets, groupId, options);
        }

        public static async Task<ListConsumerGroupOffsetsResult> ListConsumerGroupOffsetsAsync(this IAdmin admin, string groupId)
        {
            return await Execute(admin.ListConsumerGroupOffsets, groupId);
        }

        public static async Task<DeleteConsumerGroupsResult> DeleteConsumerGroupsAsync(this IAdmin admin, Collection<string> groupIds, DeleteConsumerGroupsOptions options)
        {
            return await Execute(admin.DeleteConsumerGroups, groupIds, options);
        }

        public static async Task<DeleteConsumerGroupsResult> DeleteConsumerGroupsAsync(this IAdmin admin, Collection<string> groupIds)
        {
            return await Execute(admin.DeleteConsumerGroups, groupIds);
        }

        public static async Task<DeleteConsumerGroupOffsetsResult> DeleteConsumerGroupOffsetsAsync(this IAdmin admin, string groupId, Set<TopicPartition> partitions, DeleteConsumerGroupOffsetsOptions options)
        {
            return await Execute(admin.DeleteConsumerGroupOffsets, groupId, partitions, options);
        }

        public static async Task<DeleteConsumerGroupOffsetsResult> DeleteConsumerGroupOffsetsAsync(this IAdmin admin, string groupId, Set<TopicPartition> partitions)
        {
            return await Execute(admin.DeleteConsumerGroupOffsets, groupId, partitions);
        }

        public static async Task<ElectLeadersResult> ElectLeadersAsync(this IAdmin admin, ElectionType electionType, Set<TopicPartition> partitions)
        {
            return await Execute(admin.ElectLeaders, electionType, partitions);
        }

        public static async Task<ElectLeadersResult> ElectLeadersAsync(this IAdmin admin, ElectionType electionType, Set<TopicPartition> partitions, ElectLeadersOptions options)
        {
            return await Execute(admin.ElectLeaders, electionType, partitions, options);
        }

        public static async Task<AlterPartitionReassignmentsResult> AlterPartitionReassignmentsAsync(this IAdmin admin, Map<TopicPartition, Optional<NewPartitionReassignment>> reassignments)
        {
            return await Execute(admin.AlterPartitionReassignments, reassignments);
        }

        public static async Task<AlterPartitionReassignmentsResult> AlterPartitionReassignmentsAsync(this IAdmin admin, Map<TopicPartition, Optional<NewPartitionReassignment>> reassignments, AlterPartitionReassignmentsOptions options)
        {
            return await Execute(admin.AlterPartitionReassignments, reassignments, options);
        }

        public static async Task<ListPartitionReassignmentsResult> ListPartitionReassignmentsAsync(this IAdmin admin)
        {
            return await Execute(admin.ListPartitionReassignments);
        }

        public static async Task<ListPartitionReassignmentsResult> ListPartitionReassignmentsAsync(this IAdmin admin, Set<TopicPartition> partitions)
        {
            return await Execute(admin.ListPartitionReassignments, partitions);
        }

        public static async Task<ListPartitionReassignmentsResult> ListPartitionReassignmentsAsync(this IAdmin admin, Set<TopicPartition> partitions, ListPartitionReassignmentsOptions options)
        {
            return await Execute(admin.ListPartitionReassignments, partitions, options);
        }

        public static async Task<ListPartitionReassignmentsResult> ListPartitionReassignmentsAsync(this IAdmin admin, ListPartitionReassignmentsOptions options)
        {
            return await Execute(admin.ListPartitionReassignments, options);
        }

        public static async Task<ListPartitionReassignmentsResult> ListPartitionReassignmentsAsync(this IAdmin admin, Optional<Set<TopicPartition>> partitions, ListPartitionReassignmentsOptions options)
        {
            return await Execute(admin.ListPartitionReassignments, partitions, options);
        }

        public static async Task<RemoveMembersFromConsumerGroupResult> RemoveMembersFromConsumerGroupAsync(this IAdmin admin, string groupId, RemoveMembersFromConsumerGroupOptions options)
        {
            return await Execute(admin.RemoveMembersFromConsumerGroup, groupId, options);
        }

        public static async Task<AlterConsumerGroupOffsetsResult> AlterConsumerGroupOffsetsAsync(this IAdmin admin, string groupId, Map<TopicPartition, OffsetAndMetadata> offsets)
        {
            return await Execute(admin.AlterConsumerGroupOffsets, groupId, offsets);
        }

        public static async Task<AlterConsumerGroupOffsetsResult> AlterConsumerGroupOffsetsAsync(this IAdmin admin, string groupId, Map<TopicPartition, OffsetAndMetadata> offsets, AlterConsumerGroupOffsetsOptions options)
        {
            return await Execute(admin.AlterConsumerGroupOffsets, groupId, offsets, options);
        }

        public static async Task<ListOffsetsResult> ListOffsetsAsync(this IAdmin admin, Map<TopicPartition, OffsetSpec> topicPartitionOffsets)
        {
            return await Execute(admin.ListOffsets, topicPartitionOffsets);
        }

        public static async Task<ListOffsetsResult> ListOffsetsAsync(this IAdmin admin, Map<TopicPartition, OffsetSpec> topicPartitionOffsets, ListOffsetsOptions options)
        {
            return await Execute(admin.ListOffsets, topicPartitionOffsets, options);
        }

        public static async Task<DescribeClientQuotasResult> DescribeClientQuotasAsync(this IAdmin admin, ClientQuotaFilter filter)
        {
            return await Execute(admin.DescribeClientQuotas, filter);
        }

        public static async Task<DescribeClientQuotasResult> DescribeClientQuotasAsync(this IAdmin admin, ClientQuotaFilter filter, DescribeClientQuotasOptions options)
        {
            return await Execute(admin.DescribeClientQuotas, filter, options);
        }

        public static async Task<AlterClientQuotasResult> AlterClientQuotasAsync(this IAdmin admin, Collection<ClientQuotaAlteration> entries)
        {
            return await Execute(admin.AlterClientQuotas, entries);
        }

        public static async Task<AlterClientQuotasResult> AlterClientQuotasAsync(this IAdmin admin, Collection<ClientQuotaAlteration> entries, AlterClientQuotasOptions options)
        {
            return await Execute(admin.AlterClientQuotas, entries, options);
        }

        public static async Task<DescribeUserScramCredentialsResult> DescribeUserScramCredentialsAsync(this IAdmin admin)
        {
            return await Execute(admin.DescribeUserScramCredentials);
        }

        public static async Task<DescribeUserScramCredentialsResult> DescribeUserScramCredentialsAsync(this IAdmin admin, Java.Util.List<string> users)
        {
            return await Execute(admin.DescribeUserScramCredentials, users);
        }

        public static async Task<DescribeUserScramCredentialsResult> DescribeUserScramCredentialsAsync(this IAdmin admin, Java.Util.List<string> users, DescribeUserScramCredentialsOptions options)
        {
            return await Execute(admin.DescribeUserScramCredentials, users, options);
        }

        public static async Task<AlterUserScramCredentialsResult> AlterUserScramCredentialsAsync(this IAdmin admin, Java.Util.List<UserScramCredentialAlteration> alterations)
        {
            return await Execute(admin.AlterUserScramCredentials, alterations);
        }

        public static async Task<AlterUserScramCredentialsResult> AlterUserScramCredentialsAsync(this IAdmin admin, Java.Util.List<UserScramCredentialAlteration> alterations, AlterUserScramCredentialsOptions options)
        {
            return await Execute(admin.AlterUserScramCredentials, alterations, options);
        }

        public static async Task<DescribeFeaturesResult> DescribeFeaturesAsync(this IAdmin admin)
        {
            return await Execute(admin.DescribeFeatures);
        }

        public static async Task<DescribeFeaturesResult> DescribeFeaturesAsync(this IAdmin admin, DescribeFeaturesOptions options)
        {
            return await Execute(admin.DescribeFeatures, options);
        }

        public static async Task<UpdateFeaturesResult> UpdateFeaturesAsync(this IAdmin admin, Map<string, FeatureUpdate> featureUpdates, UpdateFeaturesOptions options)
        {
            return await Execute(admin.UpdateFeatures, featureUpdates, options);
        }

        public static async Task<UnregisterBrokerResult> UnregisterBrokerAsync(this IAdmin admin, int brokerId)
        {
            return await Execute(admin.UnregisterBroker, brokerId);
        }

        public static async Task<UnregisterBrokerResult> UnregisterBrokerAsync(this IAdmin admin, int brokerId, UnregisterBrokerOptions options)
        {
            return await Execute(admin.UnregisterBroker, brokerId, options);
        }

        public static async Task<DescribeProducersResult> DescribeProducersAsync(this IAdmin admin, Collection<TopicPartition> partitions)
        {
            return await Execute(admin.DescribeProducers, partitions);
        }

        public static async Task<DescribeProducersResult> DescribeProducersAsync(this IAdmin admin, Collection<TopicPartition> partitions, DescribeProducersOptions options)
        {
            return await Execute(admin.DescribeProducers, partitions, options);
        }

        public static async Task<DescribeTransactionsResult> DescribeTransactionsAsync(this IAdmin admin, Collection<string> transactionalIds)
        {
            return await Execute(admin.DescribeTransactions, transactionalIds);
        }

        public static async Task<DescribeTransactionsResult> DescribeTransactionsAsync(this IAdmin admin, Collection<string> transactionalIds, DescribeTransactionsOptions options)
        {
            return await Execute(admin.DescribeTransactions, transactionalIds, options);
        }

        public static async Task<AbortTransactionResult> AbortTransactionAsync(this IAdmin admin, AbortTransactionSpec spec)
        {
            return await Execute(admin.AbortTransaction, spec);
        }

        public static async Task<AbortTransactionResult> AbortTransactionAsync(this IAdmin admin, AbortTransactionSpec spec, AbortTransactionOptions options)
        {
            return await Execute(admin.AbortTransaction, spec, options);
        }

        public static async Task<ListTransactionsResult> ListTransactionsAsync(this IAdmin admin)
        {
            return await Execute(admin.ListTransactions);
        }

        public static async Task<ListTransactionsResult> ListTransactionsAsync(this IAdmin admin, ListTransactionsOptions options)
        {
            return await Execute(admin.ListTransactions, options);
        }
    }
}
