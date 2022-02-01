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
using MASES.KafkaBridge.Common;
using MASES.KafkaBridge.Java.Time;
using MASES.KafkaBridge.Java.Util;

namespace MASES.KafkaBridge.Clients.Admin
{
    public class KafkaAdminClient : JVMBridgeBase<KafkaAdminClient>, IAdmin
    {
        public override string ClassName => "org.apache.kafka.clients.admin.KafkaAdminClient";

        public Map<MetricName, Metric> Metrics => IExecute<Map<MetricName, Metric>>("metrics");

        public static KafkaAdminClient Create(Properties props)
        {
            return SExecute<KafkaAdminClient>("create", props.Instance);
        }

        public CreateTopicsResult CreateTopics(Collection<NewTopic> newTopics)
        {
            return IExecute<CreateTopicsResult>("createTopics", newTopics.Instance);
        }

        public CreateTopicsResult CreateTopics(Collection<NewTopic> newTopics, CreateTopicsOptions options)
        {
            return IExecute<CreateTopicsResult>("createTopics", newTopics.Instance, options.Instance);
        }

        public CreateTopicsResult DeleteTopics(Collection<NewTopic> newTopics)
        {
            return IExecute<CreateTopicsResult>("deleteTopics", newTopics.Instance);
        }

        public DescribeConsumerGroupsResult DescribeConsumerGroups(Collection<string> groupIds)
        {
            return IExecute<DescribeConsumerGroupsResult>("describeConsumerGroups", groupIds.Instance);
        }

        public ListConsumerGroupsResult ListConsumerGroups()
        {
            return IExecute<ListConsumerGroupsResult>("listConsumerGroups");
        }

        public ElectLeadersResult ElectLeaders(ElectionType electionType, Set<TopicPartition> partitions)
        {
            return IExecute<ElectLeadersResult>("electLeaders", (byte)electionType, partitions.Instance);
        }

        public void Close()
        {
            IExecute("close");
        }

        public void Close(Duration timeout)
        {
            IExecute("close", timeout.Instance);
        }

        public DeleteTopicsResult DeleteTopics(Collection<string> topics)
        {
          return IExecute<DeleteTopicsResult>("deleteTopics", topics.Instance);
        }

        public DeleteTopicsResult DeleteTopics(Collection<string> topics, DeleteTopicsOptions options)
        {
            return IExecute<DeleteTopicsResult>("deleteTopics", topics.Instance, options.Instance);
        }

        public ListTopicsResult ListTopics()
        {
            return IExecute<ListTopicsResult>("listTopics");
        }

        public DescribeTopicsResult DescribeTopics(Collection<string> topicNames)
        {
            return IExecute<DescribeTopicsResult>("describeTopics", topicNames.Instance);
        }

        public DescribeClusterResult DescribeCluster()
        {
            return IExecute<DescribeClusterResult>("describeCluster");
        }
    }
}

