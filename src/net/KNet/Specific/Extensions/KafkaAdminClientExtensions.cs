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

using Java.Util;
using Java.Util.Concurrent;
using MASES.JNet.Specific.Extensions;
using Org.Apache.Kafka.Clients.Admin;
using Org.Apache.Kafka.Clients.Consumer;
using Org.Apache.Kafka.Common;
using Org.Apache.Kafka.Common.Acl;
using Org.Apache.Kafka.Common.Config;
using Org.Apache.Kafka.Common.Quota;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MASES.KNet.Extensions
{
    /// <summary>
    /// Extension for <see cref="KafkaAdminClient"/>
    /// </summary>
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
        /// <summary>
        /// Async version of <see cref="IAdmin.CreateTopics(Collection{NewTopic})"/>
        /// </summary>
        public static async Task<CreateTopicsResult> CreateTopicsAsync(this IAdmin admin, Collection<NewTopic> newTopics)
        {
            return await Execute(admin.CreateTopics, newTopics);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.CreateTopics(Collection{NewTopic})"/>
        /// </summary>
        public static void CreateTopic(this IAdmin admin, string topicName, int numPartitions = 1, short replicationFactor = 1)
        {
            NewTopic topic = null;
            Set<NewTopic> coll = null;
            try
            {
                topic = new NewTopic(topicName, numPartitions, replicationFactor);
                coll = Collections.Singleton(topic);
                var res = admin.CreateTopics(coll);
                res.All().Get();
            }
            catch (ExecutionException ex)
            {
                throw ex.InnerException;
            }
            finally
            { // this piece of code tryies to mitigate the effect of GC object recall
                if (coll != null && coll.IsBridgeStatic)
                {
                    topic.ToString();
                    coll.ToString();
                }
            }
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.CreateTopics(Collection{NewTopic})"/>
        /// </summary>
        public static void CreateTopic(this IAdmin admin, NewTopic topic)
        {
            Set<NewTopic> coll = null;
            try
            {
                coll = Collections.Singleton(topic);
                var res = admin.CreateTopics(coll);
                res.All().Get();
            }
            catch (ExecutionException ex)
            {
                throw ex.InnerException;
            }
            finally
            { // this piece of code tryies to mitigate the effect of GC object recall
                if (coll != null && coll.IsBridgeStatic)
                {
                    topic.ToString();
                    coll.ToString();
                }
            }
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.CreateTopics(Collection{NewTopic})"/>
        /// </summary>
        public static async Task<CreateTopicsResult> CreateTopicAsync(this IAdmin admin, string topicName, int numPartitions = 1, short replicationFactor = 1)
        {
            NewTopic topic = null;
            Set<NewTopic> coll = null;
            try
            {
                topic = new NewTopic(topicName, numPartitions, replicationFactor);
                coll = Collections.Singleton(topic);
                return await CreateTopicsAsync(admin, coll);
            }
            finally
            { // this piece of code tryies to mitigate the effect of GC object recall
                if (coll != null && coll.IsBridgeStatic)
                {
                    topic.ToString();
                    coll.ToString();
                }
            }
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.CreateTopics(Collection{NewTopic})"/>
        /// </summary>
        public static async Task<CreateTopicsResult> CreateTopicsAsync(this IAdmin admin, Collection<NewTopic> newTopics, CreateTopicsOptions options)
        {
            return await Execute(admin.CreateTopics, newTopics, options);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.DeleteTopics(Collection{Java.Lang.String})"/>
        /// </summary>
        public static void DeleteTopic(this IAdmin admin, string topicName)
        {
            Set<Java.Lang.String> coll = null;
            try
            {
                coll = Collections.Singleton((Java.Lang.String)topicName);
                var res = admin.DeleteTopics(coll);
                res.All().Get();
            }
            catch (ExecutionException ex)
            {
                throw ex.InnerException;
            }
            finally
            { // this piece of code tryies to mitigate the effect of GC object recall
                if (coll != null && coll.IsBridgeStatic) coll.ToString();
            }
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.DeleteTopics(Collection{Java.Lang.String})"/>
        /// </summary>
        public static async Task<DeleteTopicsResult> DeleteTopicsAsync(this IAdmin admin, IEnumerable<string> topics)
        {
            return await Execute(admin.DeleteTopics, topics.ToJCollection());
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.DeleteTopics(Collection{Java.Lang.String})"/>
        /// </summary>
        public static async Task<DeleteTopicsResult> DeleteTopicAsync(this IAdmin admin, string topicName)
        {
            return await DeleteTopicsAsync(admin, new string[] { topicName });
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.DeleteTopics(Collection{Java.Lang.String})"/>
        /// </summary>
        public static async Task<DeleteTopicsResult> DeleteTopicsAsync(this IAdmin admin, IEnumerable<string> topics, DeleteTopicsOptions options)
        {
            return await Execute(admin.DeleteTopics, topics.ToJCollection(), options);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.DeleteTopics(TopicCollection)"/>
        /// </summary>
        public static async Task<DeleteTopicsResult> DeleteTopicsAsync(this IAdmin admin, TopicCollection topics)
        {
            return await Execute(admin.DeleteTopics, topics);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.DeleteTopics(TopicCollection, DeleteTopicsOptions)"/>
        /// </summary>
        public static async Task<DeleteTopicsResult> DeleteTopicsAsync(this IAdmin admin, TopicCollection topics, DeleteTopicsOptions options)
        {
            return await Execute(admin.DeleteTopics, topics, options);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.ListTopics()"/>
        /// </summary>
        public static async Task<ListTopicsResult> ListTopicsAsync(this IAdmin admin)
        {
            return await Execute(admin.ListTopics);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.ListTopics(ListTopicsOptions)"/>
        /// </summary>
        public static async Task<ListTopicsResult> ListTopicsAsync(this IAdmin admin, ListTopicsOptions options)
        {
            return await Execute(admin.ListTopics, options);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.DescribeTopics(Collection{Java.Lang.String})"/>
        /// </summary>
        public static async Task<DescribeTopicsResult> DescribeTopicsAsync(this IAdmin admin, IEnumerable<string> topicNames)
        {
            return await Execute(admin.DescribeTopics, topicNames.ToJCollection());
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.DescribeTopics(Collection{Java.Lang.String})"/>
        /// </summary>
        public static async Task<DescribeTopicsResult> DescribeTopicAsync(this IAdmin admin, string topicName)
        {
            return await DescribeTopicsAsync(admin, new string[] { topicName });
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.DescribeTopics(Collection{Java.Lang.String}, DescribeTopicsOptions)"/>
        /// </summary>
        public static async Task<DescribeTopicsResult> DescribeTopicsAsync(this IAdmin admin, IEnumerable<string> topicNames, DescribeTopicsOptions options)
        {
            return await Execute(admin.DescribeTopics, topicNames.ToJCollection(), options);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.DescribeCluster()"/>
        /// </summary>
        public static async Task<DescribeClusterResult> DescribeClusterAsync(this IAdmin admin)
        {
            return await Execute(admin.DescribeCluster);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.DescribeCluster(DescribeClusterOptions)"/>
        /// </summary>
        public static async Task<DescribeClusterResult> DescribeClusterAsync(this IAdmin admin, DescribeClusterOptions options)
        {
            return await Execute(admin.DescribeCluster, options);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.DescribeAcls(AclBindingFilter)"/>
        /// </summary>
        public static async Task<DescribeAclsResult> DescribeAclsAsync(this IAdmin admin, AclBindingFilter filter)
        {
            return await Execute(admin.DescribeAcls, filter);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.DescribeAcls(AclBindingFilter, DescribeAclsOptions)"/>
        /// </summary>
        public static async Task<DescribeAclsResult> DescribeAclsAsync(this IAdmin admin, AclBindingFilter filter, DescribeAclsOptions options)
        {
            return await Execute(admin.DescribeAcls, filter, options);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.CreateAcls(Collection{AclBinding})"/>
        /// </summary>
        public static async Task<CreateAclsResult> CreateAclsAsync(this IAdmin admin, Collection<AclBinding> acls)
        {
            return await Execute(admin.CreateAcls, acls);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.CreateAcls(Collection{AclBinding}, CreateAclsOptions)"/>
        /// </summary>
        public static async Task<CreateAclsResult> CreateAclsAsync(this IAdmin admin, Collection<AclBinding> acls, CreateAclsOptions options)
        {
            return await Execute(admin.CreateAcls, acls, options);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.DeleteAcls(Collection{AclBindingFilter})"/>
        /// </summary>
        public static async Task<DeleteAclsResult> DeleteAclsAsync(this IAdmin admin, Collection<AclBindingFilter> filters)
        {
            return await Execute(admin.DeleteAcls, filters);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.DeleteAcls(Collection{AclBindingFilter}, DeleteAclsOptions)"/>
        /// </summary>
        public static async Task<DeleteAclsResult> DeleteAclsAsync(this IAdmin admin, Collection<AclBindingFilter> filters, DeleteAclsOptions options)
        {
            return await Execute(admin.DeleteAcls, filters, options);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.DescribeConfigs(Collection{ConfigResource})"/>
        /// </summary>
        public static async Task<DescribeConfigsResult> DescribeConfigsAsync(this IAdmin admin, Collection<ConfigResource> resources)
        {
            return await Execute(admin.DescribeConfigs, resources);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.DescribeConfigs(Collection{ConfigResource}, DescribeConfigsOptions)"/>
        /// </summary>
        public static async Task<DescribeConfigsResult> DescribeConfigsAsync(this IAdmin admin, Collection<ConfigResource> resources, DescribeConfigsOptions options)
        {
            return await Execute(admin.DescribeConfigs, resources, options);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.IncrementalAlterConfigs(Map{ConfigResource, Collection{AlterConfigOp}})"/>
        /// </summary>
        public static async Task<AlterConfigsResult> IncrementalAlterConfigsAsync(this IAdmin admin, Map<ConfigResource, Collection<AlterConfigOp>> configs)
        {
            return await Execute(admin.IncrementalAlterConfigs, configs);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.IncrementalAlterConfigs(Map{ConfigResource, Collection{AlterConfigOp}}, AlterConfigsOptions)"/>
        /// </summary>
        public static async Task<AlterConfigsResult> IncrementalAlterConfigsAsync(this IAdmin admin, Map<ConfigResource, Collection<AlterConfigOp>> configs, AlterConfigsOptions options)
        {
            return await Execute(admin.IncrementalAlterConfigs, configs, options);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.AlterReplicaLogDirs(Map{TopicPartitionReplica, Java.Lang.String})"/>
        /// </summary>
        public static async Task<AlterReplicaLogDirsResult> AlterReplicaLogDirsAsync(this IAdmin admin, Map<TopicPartitionReplica, Java.Lang.String> replicaAssignment)
        {
            return await Execute(admin.AlterReplicaLogDirs, replicaAssignment);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.AlterReplicaLogDirs(Map{TopicPartitionReplica, Java.Lang.String}, AlterReplicaLogDirsOptions)"/>
        /// </summary>
        public static async Task<AlterReplicaLogDirsResult> AlterReplicaLogDirsAsync(this IAdmin admin, Map<TopicPartitionReplica, Java.Lang.String> replicaAssignment, AlterReplicaLogDirsOptions options)
        {
            return await Execute(admin.AlterReplicaLogDirs, replicaAssignment, options);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.DescribeLogDirs(Collection{Java.Lang.Integer})"/>
        /// </summary>
        public static async Task<DescribeLogDirsResult> DescribeLogDirsAsync(this IAdmin admin, Collection<Java.Lang.Integer> brokers)
        {
            return await Execute(admin.DescribeLogDirs, brokers);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.DescribeLogDirs(Collection{Java.Lang.Integer}, DescribeLogDirsOptions)"/>
        /// </summary>
        public static async Task<DescribeLogDirsResult> DescribeLogDirsAsync(this IAdmin admin, Collection<Java.Lang.Integer> brokers, DescribeLogDirsOptions options)
        {
            return await Execute(admin.DescribeLogDirs, brokers, options);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.DescribeReplicaLogDirs(Collection{TopicPartitionReplica})"/>
        /// </summary>
        public static async Task<DescribeReplicaLogDirsResult> DescribeReplicaLogDirsAsync(this IAdmin admin, Collection<TopicPartitionReplica> replicas)
        {
            return await Execute(admin.DescribeReplicaLogDirs, replicas);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.DescribeReplicaLogDirs(Collection{TopicPartitionReplica}, DescribeReplicaLogDirsOptions)"/>
        /// </summary>
        public static async Task<DescribeReplicaLogDirsResult> DescribeReplicaLogDirsAsync(this IAdmin admin, Collection<TopicPartitionReplica> replicas, DescribeReplicaLogDirsOptions options)
        {
            return await Execute(admin.DescribeReplicaLogDirs, replicas, options);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.CreatePartitions(Map{Java.Lang.String, NewPartitions})"/>
        /// </summary>
        public static async Task<CreatePartitionsResult> CreatePartitionsAsync(this IAdmin admin, Map<Java.Lang.String, NewPartitions> newPartitions)
        {
            return await Execute(admin.CreatePartitions, newPartitions);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.CreatePartitions(Map{Java.Lang.String, NewPartitions}, CreatePartitionsOptions)"/>
        /// </summary>
        public static async Task<CreatePartitionsResult> CreatePartitionsAsync(this IAdmin admin, Map<Java.Lang.String, NewPartitions> newPartitions, CreatePartitionsOptions options)
        {
            return await Execute(admin.CreatePartitions, newPartitions, options);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.DeleteRecords(Map{TopicPartition, RecordsToDelete})"/>
        /// </summary>
        public static async Task<DeleteRecordsResult> DeleteRecordsAsync(this IAdmin admin, Map<TopicPartition, RecordsToDelete> recordsToDelete)
        {
            return await Execute(admin.DeleteRecords, recordsToDelete);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.DeleteRecords(Map{TopicPartition, RecordsToDelete}, DeleteRecordsOptions)"/>
        /// </summary>
        public static async Task<DeleteRecordsResult> DeleteRecordsAsync(this IAdmin admin, Map<TopicPartition, RecordsToDelete> recordsToDelete, DeleteRecordsOptions options)
        {
            return await Execute(admin.DeleteRecords, recordsToDelete, options);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.CreateDelegationToken()"/>
        /// </summary>
        public static async Task<CreateDelegationTokenResult> CreateDelegationTokenAsync(this IAdmin admin)
        {
            return await Execute(admin.CreateDelegationToken);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.CreateDelegationToken(CreateDelegationTokenOptions)"/>
        /// </summary>
        public static async Task<CreateDelegationTokenResult> CreateDelegationTokenAsync(this IAdmin admin, CreateDelegationTokenOptions options)
        {
            return await Execute(admin.CreateDelegationToken, options);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.RenewDelegationToken(byte[])"/>
        /// </summary>
        public static async Task<RenewDelegationTokenResult> RenewDelegationTokenAsync(this IAdmin admin, byte[] hmac)
        {
            return await Execute(admin.RenewDelegationToken, hmac);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.RenewDelegationToken(byte[], RenewDelegationTokenOptions)"/>
        /// </summary>
        public static async Task<RenewDelegationTokenResult> RenewDelegationTokenAsync(this IAdmin admin, byte[] hmac, RenewDelegationTokenOptions options)
        {
            return await Execute(admin.RenewDelegationToken, hmac, options);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.ExpireDelegationToken(byte[])"/>
        /// </summary>
        public static async Task<ExpireDelegationTokenResult> ExpireDelegationTokenAsync(this IAdmin admin, byte[] hmac)
        {
            return await Execute(admin.ExpireDelegationToken, hmac);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.ExpireDelegationToken(byte[], ExpireDelegationTokenOptions)"/>
        /// </summary>
        public static async Task<ExpireDelegationTokenResult> ExpireDelegationTokenAsync(this IAdmin admin, byte[] hmac, ExpireDelegationTokenOptions options)
        {
            return await Execute(admin.ExpireDelegationToken, hmac, options);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.DescribeDelegationToken()"/>
        /// </summary>
        public static async Task<DescribeDelegationTokenResult> DescribeDelegationTokenAsync(this IAdmin admin)
        {
            return await Execute(admin.DescribeDelegationToken);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.DescribeDelegationToken(DescribeDelegationTokenOptions)"/>
        /// </summary>
        public static async Task<DescribeDelegationTokenResult> DescribeDelegationTokenAsync(this IAdmin admin, DescribeDelegationTokenOptions options)
        {
            return await Execute(admin.DescribeDelegationToken, options);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.DescribeConsumerGroups(Collection{Java.Lang.String})"/>
        /// </summary>
        public static async Task<DescribeConsumerGroupsResult> DescribeConsumerGroupsAsync(this IAdmin admin, IEnumerable<string> groupIds, DescribeConsumerGroupsOptions options)
        {
            return await Execute(admin.DescribeConsumerGroups, groupIds.ToJCollection(), options);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.DescribeConsumerGroups(Collection{Java.Lang.String}, DescribeConsumerGroupsOptions)"/>
        /// </summary>
        public static async Task<DescribeConsumerGroupsResult> DescribeConsumerGroupsAsync(this IAdmin admin, IEnumerable<string> groupIds)
        {
            return await Execute(admin.DescribeConsumerGroups, groupIds.ToJCollection());
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.ListConsumerGroups(ListConsumerGroupsOptions)"/>
        /// </summary>
        public static async Task<ListConsumerGroupsResult> ListConsumerGroupsAsync(this IAdmin admin, ListConsumerGroupsOptions options)
        {
            return await Execute(admin.ListConsumerGroups, options);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.ListConsumerGroups()"/>
        /// </summary>
        public static async Task<ListConsumerGroupsResult> ListConsumerGroupsAsync(this IAdmin admin)
        {
            return await Execute(admin.ListConsumerGroups);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.ListConsumerGroupOffsets(Java.Lang.String, ListConsumerGroupOffsetsOptions)"/>
        /// </summary>
        public static async Task<ListConsumerGroupOffsetsResult> ListConsumerGroupOffsetsAsync(this IAdmin admin, string groupId, ListConsumerGroupOffsetsOptions options)
        {
            return await Execute(admin.ListConsumerGroupOffsets, (Java.Lang.String)groupId, options);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.ListConsumerGroupOffsets(Java.Lang.String)"/>
        /// </summary>
        public static async Task<ListConsumerGroupOffsetsResult> ListConsumerGroupOffsetsAsync(this IAdmin admin, string groupId)
        {
            return await Execute(admin.ListConsumerGroupOffsets, (Java.Lang.String)groupId);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.DeleteConsumerGroups(Collection{Java.Lang.String}, DeleteConsumerGroupsOptions)"/>
        /// </summary>
        public static async Task<DeleteConsumerGroupsResult> DeleteConsumerGroupsAsync(this IAdmin admin, IEnumerable<string> groupIds, DeleteConsumerGroupsOptions options)
        {
            return await Execute(admin.DeleteConsumerGroups, groupIds.ToJCollection(), options);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.DeleteConsumerGroups(Collection{Java.Lang.String})"/>
        /// </summary>
        public static async Task<DeleteConsumerGroupsResult> DeleteConsumerGroupsAsync(this IAdmin admin, IEnumerable<string> groupIds)
        {
            return await Execute(admin.DeleteConsumerGroups, groupIds.ToJCollection());
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.DeleteConsumerGroupOffsets(Java.Lang.String, Set{TopicPartition}, DeleteConsumerGroupOffsetsOptions)"/>
        /// </summary>
        public static async Task<DeleteConsumerGroupOffsetsResult> DeleteConsumerGroupOffsetsAsync(this IAdmin admin, string groupId, Set<TopicPartition> partitions, DeleteConsumerGroupOffsetsOptions options)
        {
            return await Execute(admin.DeleteConsumerGroupOffsets, (Java.Lang.String)groupId, partitions, options);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.DeleteConsumerGroupOffsets(Java.Lang.String, Set{TopicPartition})"/>
        /// </summary>
        public static async Task<DeleteConsumerGroupOffsetsResult> DeleteConsumerGroupOffsetsAsync(this IAdmin admin, string groupId, Set<TopicPartition> partitions)
        {
            return await Execute(admin.DeleteConsumerGroupOffsets, (Java.Lang.String)groupId, partitions);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.ElectLeaders(ElectionType, Set{TopicPartition})"/>
        /// </summary>
        public static async Task<ElectLeadersResult> ElectLeadersAsync(this IAdmin admin, ElectionType electionType, Set<TopicPartition> partitions)
        {
            return await Execute(admin.ElectLeaders, electionType, partitions);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.ElectLeaders(ElectionType, Set{TopicPartition}, ElectLeadersOptions)"/>
        /// </summary>
        public static async Task<ElectLeadersResult> ElectLeadersAsync(this IAdmin admin, ElectionType electionType, Set<TopicPartition> partitions, ElectLeadersOptions options)
        {
            return await Execute(admin.ElectLeaders, electionType, partitions, options);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.AlterPartitionReassignments(Map{TopicPartition, Optional{NewPartitionReassignment}})"/>
        /// </summary>
        public static async Task<AlterPartitionReassignmentsResult> AlterPartitionReassignmentsAsync(this IAdmin admin, Map<TopicPartition, Optional<NewPartitionReassignment>> reassignments)
        {
            return await Execute(admin.AlterPartitionReassignments, reassignments);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.AlterPartitionReassignments(Map{TopicPartition, Optional{NewPartitionReassignment}}, AlterPartitionReassignmentsOptions)"/>
        /// </summary>
        public static async Task<AlterPartitionReassignmentsResult> AlterPartitionReassignmentsAsync(this IAdmin admin, Map<TopicPartition, Optional<NewPartitionReassignment>> reassignments, AlterPartitionReassignmentsOptions options)
        {
            return await Execute(admin.AlterPartitionReassignments, reassignments, options);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.ListPartitionReassignments()"/>
        /// </summary>
        public static async Task<ListPartitionReassignmentsResult> ListPartitionReassignmentsAsync(this IAdmin admin)
        {
            return await Execute(admin.ListPartitionReassignments);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.ListPartitionReassignments(Set{TopicPartition})"/>
        /// </summary>
        public static async Task<ListPartitionReassignmentsResult> ListPartitionReassignmentsAsync(this IAdmin admin, Set<TopicPartition> partitions)
        {
            return await Execute(admin.ListPartitionReassignments, partitions);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.ListPartitionReassignments(Set{TopicPartition}, ListPartitionReassignmentsOptions)"/>
        /// </summary>
        public static async Task<ListPartitionReassignmentsResult> ListPartitionReassignmentsAsync(this IAdmin admin, Set<TopicPartition> partitions, ListPartitionReassignmentsOptions options)
        {
            return await Execute(admin.ListPartitionReassignments, partitions, options);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.ListPartitionReassignments(ListPartitionReassignmentsOptions)"/>
        /// </summary>
        public static async Task<ListPartitionReassignmentsResult> ListPartitionReassignmentsAsync(this IAdmin admin, ListPartitionReassignmentsOptions options)
        {
            return await Execute(admin.ListPartitionReassignments, options);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.ListPartitionReassignments(Optional{Set{TopicPartition}}, ListPartitionReassignmentsOptions)"/>
        /// </summary>
        public static async Task<ListPartitionReassignmentsResult> ListPartitionReassignmentsAsync(this IAdmin admin, Optional<Set<TopicPartition>> partitions, ListPartitionReassignmentsOptions options)
        {
            return await Execute(admin.ListPartitionReassignments, partitions, options);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.RemoveMembersFromConsumerGroup(Java.Lang.String, RemoveMembersFromConsumerGroupOptions)"/>
        /// </summary>
        public static async Task<RemoveMembersFromConsumerGroupResult> RemoveMembersFromConsumerGroupAsync(this IAdmin admin, string groupId, RemoveMembersFromConsumerGroupOptions options)
        {
            return await Execute(admin.RemoveMembersFromConsumerGroup, (Java.Lang.String)groupId, options);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.AlterConsumerGroupOffsets(Java.Lang.String, Map{TopicPartition, OffsetAndMetadata})"/>
        /// </summary>
        public static async Task<AlterConsumerGroupOffsetsResult> AlterConsumerGroupOffsetsAsync(this IAdmin admin, string groupId, Map<TopicPartition, OffsetAndMetadata> offsets)
        {
            return await Execute(admin.AlterConsumerGroupOffsets, (Java.Lang.String)groupId, offsets);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.AlterConsumerGroupOffsets(Java.Lang.String, Map{TopicPartition, OffsetAndMetadata}, AlterConsumerGroupOffsetsOptions)"/>
        /// </summary>
        public static async Task<AlterConsumerGroupOffsetsResult> AlterConsumerGroupOffsetsAsync(this IAdmin admin, string groupId, Map<TopicPartition, OffsetAndMetadata> offsets, AlterConsumerGroupOffsetsOptions options)
        {
            return await Execute(admin.AlterConsumerGroupOffsets, (Java.Lang.String)groupId, offsets, options);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.ListOffsets(Map{TopicPartition, OffsetSpec})"/>
        /// </summary>
        public static async Task<ListOffsetsResult> ListOffsetsAsync(this IAdmin admin, Map<TopicPartition, OffsetSpec> topicPartitionOffsets)
        {
            return await Execute(admin.ListOffsets, topicPartitionOffsets);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.ListOffsets(Map{TopicPartition, OffsetSpec}, ListOffsetsOptions)"/>
        /// </summary>
        public static async Task<ListOffsetsResult> ListOffsetsAsync(this IAdmin admin, Map<TopicPartition, OffsetSpec> topicPartitionOffsets, ListOffsetsOptions options)
        {
            return await Execute(admin.ListOffsets, topicPartitionOffsets, options);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.DescribeClientQuotas(ClientQuotaFilter)"/>
        /// </summary>
        public static async Task<DescribeClientQuotasResult> DescribeClientQuotasAsync(this IAdmin admin, ClientQuotaFilter filter)
        {
            return await Execute(admin.DescribeClientQuotas, filter);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.DescribeClientQuotas(ClientQuotaFilter, DescribeClientQuotasOptions)"/>
        /// </summary>
        public static async Task<DescribeClientQuotasResult> DescribeClientQuotasAsync(this IAdmin admin, ClientQuotaFilter filter, DescribeClientQuotasOptions options)
        {
            return await Execute(admin.DescribeClientQuotas, filter, options);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.AlterClientQuotas(Collection{ClientQuotaAlteration})"/>
        /// </summary>
        public static async Task<AlterClientQuotasResult> AlterClientQuotasAsync(this IAdmin admin, Collection<ClientQuotaAlteration> entries)
        {
            return await Execute(admin.AlterClientQuotas, entries);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.AlterClientQuotas(Collection{ClientQuotaAlteration}, AlterClientQuotasOptions)"/>
        /// </summary>
        public static async Task<AlterClientQuotasResult> AlterClientQuotasAsync(this IAdmin admin, Collection<ClientQuotaAlteration> entries, AlterClientQuotasOptions options)
        {
            return await Execute(admin.AlterClientQuotas, entries, options);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.DescribeUserScramCredentials()"/>
        /// </summary>
        public static async Task<DescribeUserScramCredentialsResult> DescribeUserScramCredentialsAsync(this IAdmin admin)
        {
            return await Execute(admin.DescribeUserScramCredentials);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.DescribeUserScramCredentials(Java.Util.List{Java.Lang.String})"/>
        /// </summary>
        public static async Task<DescribeUserScramCredentialsResult> DescribeUserScramCredentialsAsync(this IAdmin admin, Java.Util.List<Java.Lang.String> users)
        {
            return await Execute(admin.DescribeUserScramCredentials, users);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.DescribeUserScramCredentials(Java.Util.List{Java.Lang.String}, DescribeUserScramCredentialsOptions)"/>
        /// </summary>
        public static async Task<DescribeUserScramCredentialsResult> DescribeUserScramCredentialsAsync(this IAdmin admin, Java.Util.List<Java.Lang.String> users, DescribeUserScramCredentialsOptions options)
        {
            return await Execute(admin.DescribeUserScramCredentials, users, options);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.AlterUserScramCredentials(Java.Util.List{UserScramCredentialAlteration})"/>
        /// </summary>
        public static async Task<AlterUserScramCredentialsResult> AlterUserScramCredentialsAsync(this IAdmin admin, Java.Util.List<UserScramCredentialAlteration> alterations)
        {
            return await Execute(admin.AlterUserScramCredentials, alterations);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.AlterUserScramCredentials(Java.Util.List{UserScramCredentialAlteration}, AlterUserScramCredentialsOptions)"/>
        /// </summary>
        public static async Task<AlterUserScramCredentialsResult> AlterUserScramCredentialsAsync(this IAdmin admin, Java.Util.List<UserScramCredentialAlteration> alterations, AlterUserScramCredentialsOptions options)
        {
            return await Execute(admin.AlterUserScramCredentials, alterations, options);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.DescribeFeatures()"/>
        /// </summary>
        public static async Task<DescribeFeaturesResult> DescribeFeaturesAsync(this IAdmin admin)
        {
            return await Execute(admin.DescribeFeatures);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.DescribeFeatures(DescribeFeaturesOptions)"/>
        /// </summary>
        public static async Task<DescribeFeaturesResult> DescribeFeaturesAsync(this IAdmin admin, DescribeFeaturesOptions options)
        {
            return await Execute(admin.DescribeFeatures, options);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.UpdateFeatures(Map{Java.Lang.String, FeatureUpdate}, UpdateFeaturesOptions)"/>
        /// </summary>
        public static async Task<UpdateFeaturesResult> UpdateFeaturesAsync(this IAdmin admin, Map<Java.Lang.String, FeatureUpdate> featureUpdates, UpdateFeaturesOptions options)
        {
            return await Execute(admin.UpdateFeatures, featureUpdates, options);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.UnregisterBroker(int)"/>
        /// </summary>
        public static async Task<UnregisterBrokerResult> UnregisterBrokerAsync(this IAdmin admin, int brokerId)
        {
            return await Execute(admin.UnregisterBroker, brokerId);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.UnregisterBroker(int, UnregisterBrokerOptions)"/>
        /// </summary>
        public static async Task<UnregisterBrokerResult> UnregisterBrokerAsync(this IAdmin admin, int brokerId, UnregisterBrokerOptions options)
        {
            return await Execute(admin.UnregisterBroker, brokerId, options);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.DescribeProducers(Collection{TopicPartition})"/>
        /// </summary>
        public static async Task<DescribeProducersResult> DescribeProducersAsync(this IAdmin admin, Collection<TopicPartition> partitions)
        {
            return await Execute(admin.DescribeProducers, partitions);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.DescribeProducers(Collection{TopicPartition}, DescribeProducersOptions)"/>
        /// </summary>
        public static async Task<DescribeProducersResult> DescribeProducersAsync(this IAdmin admin, Collection<TopicPartition> partitions, DescribeProducersOptions options)
        {
            return await Execute(admin.DescribeProducers, partitions, options);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.DescribeTransactions(Collection{Java.Lang.String})"/>
        /// </summary>
        public static async Task<DescribeTransactionsResult> DescribeTransactionsAsync(this IAdmin admin, IEnumerable<string> transactionalIds)
        {
            return await Execute(admin.DescribeTransactions, transactionalIds.ToJCollection());
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.DescribeTransactions(Collection{Java.Lang.String}, DescribeTransactionsOptions)"/>
        /// </summary>
        public static async Task<DescribeTransactionsResult> DescribeTransactionsAsync(this IAdmin admin, IEnumerable<string> transactionalIds, DescribeTransactionsOptions options)
        {
            return await Execute(admin.DescribeTransactions, transactionalIds.ToJCollection(), options);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.AbortTransaction(AbortTransactionSpec)"/>
        /// </summary>
        public static async Task<AbortTransactionResult> AbortTransactionAsync(this IAdmin admin, AbortTransactionSpec spec)
        {
            return await Execute(admin.AbortTransaction, spec);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.AbortTransaction(AbortTransactionSpec, AbortTransactionOptions)"/>
        /// </summary>
        public static async Task<AbortTransactionResult> AbortTransactionAsync(this IAdmin admin, AbortTransactionSpec spec, AbortTransactionOptions options)
        {
            return await Execute(admin.AbortTransaction, spec, options);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.ListTransactions()"/>
        /// </summary>
        public static async Task<ListTransactionsResult> ListTransactionsAsync(this IAdmin admin)
        {
            return await Execute(admin.ListTransactions);
        }
        /// <summary>
        /// Async version of <see cref="IAdmin.ListTransactions(ListTransactionsOptions)"/>
        /// </summary>
        public static async Task<ListTransactionsResult> ListTransactionsAsync(this IAdmin admin, ListTransactionsOptions options)
        {
            return await Execute(admin.ListTransactions, options);
        }
    }
}
