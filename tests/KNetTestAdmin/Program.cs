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

using MASES.KNet;
using MASES.KNet.Clients.Admin;
using MASES.KNet.Common.Config;
using Java.Util;
using System;

namespace MASES.KNetTestAdmin
{
    class Program
    {
        const string theServer = "localhost:9092";
        const string theTopic = "myTopicAdmin";

        static string serverToUse = theServer;
        static string topicToUse = theTopic;

        static void Main(string[] args)
        {
            KNetCore.CreateGlobalInstance();
            var appArgs = KNetCore.FilteredArgs;

            if (appArgs.Length != 0)
            {
                serverToUse = args[0];
            }

            var builder = AdminClientConfigBuilder.Create().WithBootstrapServers(serverToUse);

            //Properties props = new Properties();
            //props.Put(AdminClientConfig.BOOTSTRAP_SERVERS_CONFIG, serverToUse);

            using (var admin = KafkaAdminClient.Create(builder))
            {
                CreateTopic(admin);
                DeleteTopic(admin);
            }
        }

        static void CreateTopic(IAdmin admin)
        {
            try
            {
                string topicName = topicToUse;
                int partitions = 1;
                short replicationFactor = 1;

                var topic = new NewTopic(topicName, partitions, replicationFactor);
                var map = Collections.SingletonMap(TopicConfig.CLEANUP_POLICY_CONFIG, TopicConfig.CLEANUP_POLICY_COMPACT);
                topic.Configs(map);
                var coll = Collections.Singleton(topic);

                // Create a compacted topic
                CreateTopicsResult result = admin.CreateTopics(coll);

                // Call values() to get the result for a specific topic
                var future = result.Values.Get(topicName);

                // Call get() to block until the topic creation is complete or has failed
                // if creation failed the ExecutionException wraps the underlying cause.
                future.Get();
            }
            catch (Java.Util.Concurrent.ExecutionException ex)
            {
                Console.WriteLine(ex.InnerException.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void DeleteTopic(IAdmin admin)
        {
            try
            {
                string topicName = topicToUse;
                var coll = Collections.Singleton(topicName);

                // Create a compacted topic
                DeleteTopicsResult result = admin.DeleteTopics(coll);

                // Call All to get the result
                var future = result.All;

                // Call get() to block until the topic deletion is complete or has failed
                // if deletion failed the ExecutionException wraps the underlying cause.
                future.Get();
            }
            catch (Java.Util.Concurrent.ExecutionException ex)
            {
                Console.WriteLine(ex.InnerException.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
