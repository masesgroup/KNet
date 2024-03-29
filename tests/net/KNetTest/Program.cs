﻿/*
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
using Org.Apache.Kafka.Clients.Admin;
using Org.Apache.Kafka.Clients.Consumer;
using Org.Apache.Kafka.Clients.Producer;
using MASES.KNet.Extensions;
using MASES.KNet.Serialization;
using MASES.KNet.Serialization.Json;
using MASES.KNet.TestCommon;
using System;
using System.Threading;
using MASES.KNet.Admin;
using MASES.KNet.Producer;
using MASES.KNet.Consumer;
using MASES.KNet.Common;
using System.Diagnostics;

namespace MASES.KNetTest
{
    class Program
    {
        static bool useCallback = true;

        const string theServer = "localhost:9092";
        const string theTopic = "myTopic";

        static string serverToUse = theServer;
        static string topicToUse = theTopic;
        static readonly ManualResetEvent resetEvent = new(false);

        public class TestType
        {
            public TestType(int i)
            {
                name = description = value = i.ToString();
            }

            public string name;
            public string description;
            public string value;

            public override string ToString()
            {
                return $"name {name} - description {description} - value {value}";
            }
        }

        static void Main(string[] args)
        {
            SharedKNetCore.CreateGlobalInstance();
            var appArgs = SharedKNetCore.FilteredArgs;

            if (appArgs.Length != 0)
            {
                serverToUse = args[0];
            }

            SerDes<TestType> serializer = new SerDes<TestType>()
            {
                OnSerialize = (topic, type) => { return Array.Empty<byte>(); }
            };

            SerDes<TestType> deserializer = new SerDes<TestType>()
            {
                OnDeserialize = (topic, data) => { return new TestType(0); }
            };

            CreateTopic();

            Thread threadProduce = new(ProduceSomething)
            {
                Name = "produce"
            };
            threadProduce.Start();

            Thread threadConsume = new(ConsumeSomething)
            {
                Name = "consume"
            };
            threadConsume.Start();

            Console.CancelKeyPress += Console_CancelKeyPress;
            Console.WriteLine("Press Ctrl-C to exit");
            resetEvent.WaitOne(TimeSpan.FromSeconds(10));
            resetEvent.Set();
            Thread.Sleep(2000); // wait the threads exit
        }

        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            if (e.Cancel) resetEvent.Set();
        }

        static void CreateTopic()
        {
            try
            {
                string topicName = topicToUse;
                int partitions = 1;
                short replicationFactor = 1;

                var topic = new NewTopic(topicName, partitions, replicationFactor);

                /**** Direct mode ******
                var map = Collections.SingletonMap(TopicConfig.CLEANUP_POLICY_CONFIG, TopicConfig.CLEANUP_POLICY_COMPACT);
                topic.Configs(map);
                *********/
                topic = topic.Configs(TopicConfigBuilder.Create().WithCleanupPolicy(TopicConfigBuilder.CleanupPolicyTypes.Compact | TopicConfigBuilder.CleanupPolicyTypes.Delete)
                                                                 .WithDeleteRetentionMs(100)
                                                                 .WithMinCleanableDirtyRatio(0.01)
                                                                 .WithSegmentMs(100));

                var coll = Collections.Singleton(topic);

                /**** Direct mode ******
                Properties props = new Properties();
                props.Put(AdminClientConfig.BOOTSTRAP_SERVERS_CONFIG, serverToUse);
                *******/

                Properties props = AdminClientConfigBuilder.Create().WithBootstrapServers(serverToUse).ToProperties();

                using (IAdmin admin = KafkaAdminClient.Create(props))
                {
                    /******* standard
                    // Create a compacted topic
                    CreateTopicsResult result = admin.CreateTopics(coll);

                    // Call values() to get the result for a specific topic
                    var future = result.Values.Get(topicName);

                    // Call get() to block until the topic creation is complete or has failed
                    // if creation failed the ExecutionException wraps the underlying cause.
                    future.Get();
                    ********/
                    admin.CreateTopic(topicName, partitions, replicationFactor);
                }
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

        static void ProduceSomething()
        {
            try
            {
                /**** Direct mode ******
                Properties props = new Properties();
                props.Put(ProducerConfig.BOOTSTRAP_SERVERS_CONFIG, serverToUse);
                props.Put(ProducerConfig.ACKS_CONFIG, "all");
                props.Put(ProducerConfig.RETRIES_CONFIG, 0);
                props.Put(ProducerConfig.LINGER_MS_CONFIG, 1);
                ******/

                ProducerConfigBuilder props = ProducerConfigBuilder.Create()
                                                                   .WithBootstrapServers(serverToUse)
                                                                   .WithAcks(ProducerConfigBuilder.AcksTypes.All)
                                                                   .WithRetries(0)
                                                                   .WithLingerMs(1);

                SerDes<string> keySerializer = new SerDes<string>();
                JsonSerDes.Value<TestType> valueSerializer = new JsonSerDes.Value<TestType>();
                try
                {
                    using (var producer = new KNetProducer<string, TestType>(props, keySerializer, valueSerializer))
                    {
                        int i = 0;
                        Callback callback = null;
                        if (useCallback)
                        {
                            callback = new Callback()
                            {
                                OnOnCompletion = (o1, o2) =>
                                {
                                    if (o2 != null) Console.WriteLine(o2.ToString());
                                    else Console.WriteLine($"Produced on topic {o1.Topic()} at offset {o1.Offset()}");
                                }
                            };
                        }
                        try
                        {
                            while (!resetEvent.WaitOne(0))
                            {
                                var record = new KNet.Producer.ProducerRecord<string, TestType>(topicToUse, i.ToString(), new TestType(i));
                                var result = useCallback ? producer.Send(record, callback) : producer.Send(record);
                                Console.WriteLine($"Producing: {record} with result: {result.Get()}");
                                producer.Flush();
                                i++;
                            }
                        }
                        finally { if (useCallback) callback.Dispose(); }
                    }
                }
                finally
                {
                    keySerializer?.Dispose();
                    valueSerializer?.Dispose();
                }
            }
            catch (Java.Util.Concurrent.ExecutionException ex)
            {
                Console.WriteLine("Producer ended with error: {0}", ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Producer ended with error: {0}", ex.Message);
            }
        }

        static void ConsumeSomething()
        {
            try
            {
                /**** Direct mode ******
                Properties props = new Properties();
                props.Put(ConsumerConfig.BOOTSTRAP_SERVERS_CONFIG, serverToUse);
                props.Put(ConsumerConfig.GROUP_ID_CONFIG, "test");
                props.Put(ConsumerConfig.ENABLE_AUTO_COMMIT_CONFIG, "true");
                props.Put(ConsumerConfig.AUTO_COMMIT_INTERVAL_MS_CONFIG, "1000");
                *******/

                ConsumerConfigBuilder props = ConsumerConfigBuilder.Create()
                                                                   .WithBootstrapServers(serverToUse)
                                                                   .WithGroupId("test")
                                                                   .WithEnableAutoCommit(true)
                                                                   .WithAutoCommitIntervalMs(1000);

                SerDes<string> keyDeserializer = new SerDes<string>();
                SerDes<TestType> valueDeserializer = new JsonSerDes.Value<TestType>();
                ConsumerRebalanceListener rebalanceListener = null;
                KNetConsumer<string, TestType> consumer = null;

                if (useCallback)
                {
                    rebalanceListener = new ConsumerRebalanceListener()
                    {
                        OnOnPartitionsRevoked = (o) =>
                        {
                            Console.WriteLine("Revoked: {0}", o.ToString());
                        },
                        OnOnPartitionsAssigned = (o) =>
                        {
                            Console.WriteLine("Assigned: {0}", o.ToString());
                        }
                    };
                }
                const bool withPrefetch = true;
                long elements = 0;
                Stopwatch watcherTotal = new Stopwatch();
                Stopwatch watcher = new Stopwatch();
                var topics = Collections.Singleton((Java.Lang.String)topicToUse);
                try
                {
                    using (consumer = new KNetConsumer<string, TestType>(props, keyDeserializer, valueDeserializer))
                    {
                        if (useCallback) consumer.Subscribe(topics, rebalanceListener);
                        else consumer.Subscribe(topics);

                        while (!resetEvent.WaitOne(0))
                        {
                            var records = consumer.Poll((long)TimeSpan.FromMilliseconds(200).TotalMilliseconds);
                            watcherTotal.Start();
#if NET7_0_OR_GREATER
                            foreach (var item in records.ApplyPrefetch(withPrefetch, prefetchThreshold: 0))
#else
                            foreach (var item in records)
#endif
                            {
                                elements++;
                                watcher.Start();
                                var str = $"Consuming from Offset = {item.Offset}, Key = {item.Key}, Value = {item.Value}";
                                watcher.Stop();
                                watcherTotal.Stop();
                                Console.WriteLine(str);
                            }
                        }
                    }
                }
                finally
                {
                    keyDeserializer?.Dispose();
                    valueDeserializer?.Dispose();
                    topics?.Dispose();
                    if (elements != 0) Console.WriteLine($"Total mean time is {TimeSpan.FromTicks(watcherTotal.ElapsedTicks / elements)}, write mean time is {TimeSpan.FromTicks(watcher.ElapsedTicks / elements)}");
                }
            }
            catch (Java.Util.Concurrent.ExecutionException ex)
            {
                Console.WriteLine("Consumer ended with error: {0}", ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Consumer ended with error: {0}", ex.Message);
            }
        }
    }
}
