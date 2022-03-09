/*
 *  MIT License
 *
 *  Copyright (c) 2022 MASES s.r.l.
 *
 *  Permission is hereby granted, free of charge, to any person obtaining a copy
 *  of this software and associated documentation files (the "Software"), to deal
 *  in the Software without restriction, including without limitation the rights
 *  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 *  copies of the Software, and to permit persons to whom the Software is
 *  furnished to do so, subject to the following conditions:
 *
 *  The above copyright notice and this permission notice shall be included in all
 *  copies or substantial portions of the Software.
 *
 *  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 *  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 *  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 *  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 *  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 *  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 *  SOFTWARE.
 */

using MASES.KafkaBridge;
using MASES.KafkaBridge.Clients.Admin;
using MASES.KafkaBridge.Common.Config;
using Java.Util;
using System;

namespace MASES.KafkaBridgeTestAdmin
{
    class Program
    {
        const string theServer = "localhost:9092";
        const string theTopic = "myTopic";

        static string serverToUse = theServer;
        static string topicToUse = theTopic;

        static void Main(string[] args)
        {
            var appArgs = KafkaBridgeCore.ApplicationArgs;

            if (appArgs.Length != 0)
            {
                serverToUse = args[0];
            }

            Properties props = new Properties();
            props.Put(AdminClientConfig.BOOTSTRAP_SERVERS_CONFIG, serverToUse);

            using (var admin = KafkaAdminClient.Create(props))
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
