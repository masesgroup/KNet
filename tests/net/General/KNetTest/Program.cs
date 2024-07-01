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
using Org.Apache.Kafka.Common.Errors;

namespace MASES.KNetTest
{
    class Program
    {
        static bool withBigExtraValue = false;
        static bool withBigBigExtraValue = false;
        static bool consoleOutput = System.Diagnostics.Debugger.IsAttached ? true : false;
        static bool runBuffered = false;
        static bool useProduceCallback = false;
        static bool useConsumeCallback = false;
        static bool onlyProduce = false;
        static bool flushWhileSend = false;
        static bool withAck = false;
        static bool runInParallel = false;
        static bool avoidThrows = false;
        static bool randomizeTopicName = false;

        const string theServer = "localhost:9092";
        const string theTopic = "myTopic";

        static int NonParallelLimit = 100000;
        static long _firstOffset = -1;
        static int waitMultiplier = 1;

        static string serverToUse = theServer;
        static string topicToUse = theTopic;
        static readonly ManualResetEvent resetEvent = new(false);

        public class TestType
        {
            static byte[] _bigExtraValue = null;
            static byte[] _bigBigExtraValue = null;
            static TestType()
            {
                _bigExtraValue = new byte[100000];
                for (int i = 0; i < _bigExtraValue.LongLength; i++)
                {
                    _bigExtraValue[i] = (byte)(i % byte.MaxValue);
                }
                _bigBigExtraValue = new byte[1000000];
                for (int i = 0; i < _bigBigExtraValue.LongLength; i++)
                {
                    _bigBigExtraValue[i] = (byte)(i % byte.MaxValue);
                }
            }

            public TestType()
            {

            }

            public TestType(int i, bool withBigExtraValue, bool bigBigExtraValue)
            {
                name = description = value = i.ToString();
                if (withBigExtraValue)
                {
                    extraValue = _bigExtraValue;
                }
                else if (bigBigExtraValue)
                {
                    extraValue = _bigBigExtraValue;
                }
            }

            public string name { get; set; }
            public string description { get; set; }
            public string value { get; set; }
            public byte[] extraValue { get; set; }

            public override string ToString()
            {
                return $"name {name} - description {description} - value {value}";
            }
        }

        static void Main(string[] args)
        {
            SharedKNetCore.Create();
            var appArgs = SharedKNetCore.FilteredArgs;

            if (appArgs.Length != 0)
            {
                serverToUse = args[0];
                if (args.Length > 1)
                {
                    for (int i = 1; i < args.Length; i++)
                    {
                        if (args[i] == "runBuffered") { runBuffered = true; continue; }
                        if (args[i] == "consoleOutput") { consoleOutput = true; continue; }
                        if (args[i] == "useProduceCallback") { useProduceCallback = true; continue; }
                        if (args[i] == "useConsumeCallback") { useConsumeCallback = true; continue; }
                        if (args[i] == "withBigExtraValue") { withBigExtraValue = true; NonParallelLimit /= 10; continue; }
                        if (args[i] == "withBigBigExtraValue") { withBigBigExtraValue = true; NonParallelLimit /= 100; continue; }
                        if (args[i] == "onlyProduce") { onlyProduce = true; continue; }
                        if (args[i] == "flushWhileSend") { flushWhileSend = true; continue; }
                        if (args[i] == "withAck") { withAck = true; continue; }
                        if (args[i] == "runInParallel") { runInParallel = true; continue; }
                        if (args[i] == "avoidThrows") { avoidThrows = true; continue; }
                        if (args[i] == "randomizeTopicName") { randomizeTopicName = true; continue; }
                        Console.WriteLine($"Unknown {args[i]}");
                    }
                }
            }

            if (randomizeTopicName)
            {
                topicToUse += "-" + Guid.NewGuid().ToString();
                Console.WriteLine($"Topic name will be {topicToUse}");
            }

            try
            {
                CreateTopic();
                Console.CancelKeyPress += Console_CancelKeyPress;
                Console.WriteLine("Press Ctrl-C to exit");
                if (runInParallel)
                {
                    Thread threadProduce;
                    Thread threadConsume;
                    if (runBuffered)
                    {
                        threadProduce = new(ProduceSomethingBuffered)
                        {
                            Name = "produce buffered"
                        };

                        threadConsume = new(ConsumeSomethingBuffered)
                        {
                            Name = "consume buffered"
                        };
                    }
                    else
                    {
                        threadProduce = new(ProduceSomething)
                        {
                            Name = "produce"
                        };

                        threadConsume = new(ConsumeSomething)
                        {
                            Name = "consume"
                        };
                    }
                    threadProduce.Start();
                    if (!onlyProduce) threadConsume.Start();
                    resetEvent.WaitOne(TimeSpan.FromSeconds(Debugger.IsAttached ? 1000 : 60));
                    resetEvent.Set();
                }
                else
                {
                    if (runBuffered)
                    {
                        ProduceSomethingBuffered();
                        if (!onlyProduce) ConsumeSomethingBuffered();
                    }
                    else
                    {
                        ProduceSomething();
                        if (!onlyProduce) ConsumeSomething();
                    }
                }
                Thread.Sleep(2000); // wait the threads exit

                Console.WriteLine($"End of {(runBuffered ? "buffered" : "non buffered")} test");
            }
            catch (Exception e)
            {
                Environment.ExitCode = SharedKNetCore.ManageException(e);
            }
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
                                                                 .WithMaxMessageBytes(100 * 1024 * 1024)
                                                                 .WithSegmentMs(100));

                var coll = Collections.Singleton(topic);

                /**** Direct mode ******
                Properties props = new Properties();
                props.Put(AdminClientConfig.BOOTSTRAP_SERVERS_CONFIG, serverToUse);
                *******/

                Properties props = AdminClientConfigBuilder.Create().WithBootstrapServers(serverToUse).ToProperties();

                Console.WriteLine($"Creating {topic} using an AdminClient based on {props}");

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
                    admin.CreateTopic(topic);
                }
            }
            catch (Java.Util.Concurrent.ExecutionException ex)
            {
                if (!avoidThrows) throw;
                Console.WriteLine(ex.InnerException.Message);
            }
            catch (TopicExistsException) { }
            catch (Exception e)
            {
                if (!avoidThrows) throw;
                Console.WriteLine(e.Message);
            }
        }

        static void ProduceSomething()
        {
            Console.WriteLine("Starting ProduceSomething");
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
                                                                   .WithAcks(withAck ? ProducerConfigBuilder.AcksTypes.All : ProducerConfigBuilder.AcksTypes.None)
                                                                   .WithMaxRequestSize(10 * 1024 * 1024)
                                                                   .WithRetries(0)
                                                                   .WithLingerMs(1);

                var keySerializer = DefaultSerDes<string>.NewByteArraySerDes();
                var valueSerializer = JsonSerDes.Value<TestType>.NewByteArraySerDes();
                Stopwatch watcher = new Stopwatch();
                try
                {
                    using (var producer = new KNetProducer<string, TestType>(props, keySerializer, valueSerializer))
                    {
                        int i = 0;
                        Callback callback = null;
                        if (useProduceCallback)
                        {
                            callback = new Callback()
                            {
                                OnOnCompletion = (o1, o2) =>
                                {
                                    if (o2 != null) Console.WriteLine(o2.ToString());
                                    else if (consoleOutput) Console.WriteLine($"Produced on topic {o1.Topic()} at offset {o1.Offset()}");
                                }
                            };
                        }
                        var baseJNICalls = SharedKNetCore.GlobalInstance.CurrentJNICalls;
                        try
                        {
                            while (runInParallel ? !resetEvent.WaitOne(0) : i < NonParallelLimit)
                            {
                                watcher.Start();
                                var record = producer.NewRecord(topicToUse, i.ToString(), new TestType(i, withBigExtraValue, withBigBigExtraValue));
                                var result = useProduceCallback ? producer.Send(record, callback) : producer.Send(record);
                                if (!runInParallel && _firstOffset == -1)
                                {
                                    _firstOffset = result.Get().Offset();
                                }
                                watcher.Stop();
                                if (consoleOutput) Console.WriteLine($"Producing: {record}");
                                if (flushWhileSend)
                                {
                                    watcher.Start();
                                    producer.Flush();
                                    watcher.Stop();
                                }
                                i++;
                            }
                            if (!flushWhileSend)
                            {
                                watcher.Start();
                                producer.Flush();
                                watcher.Stop();
                            }
                            baseJNICalls = SharedKNetCore.GlobalInstance.CurrentJNICalls - baseJNICalls;
                        }
                        finally
                        {
                            if (useProduceCallback) callback.Dispose();
                            if (i != 0) Console.WriteLine($"Flushed {i} elements in {watcher.Elapsed}, produce mean time is {TimeSpan.FromTicks(watcher.ElapsedTicks / i)} with mean JNI Calls {baseJNICalls / i}");
                        }
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
                if (!avoidThrows) throw;
                Console.WriteLine("Producer ended with error: {0}", ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                if (!avoidThrows) throw;
                Console.WriteLine("Producer ended with error: {0}", ex.Message);
            }
        }

        static void ConsumeSomething()
        {
            Console.WriteLine("Starting ConsumeSomething");
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
                                                                   .WithGroupId(Guid.NewGuid().ToString())
                                                                   .WithAutoOffsetReset(runInParallel ? ConsumerConfigBuilder.AutoOffsetResetTypes.LATEST
                                                                                                      : ConsumerConfigBuilder.AutoOffsetResetTypes.EARLIEST)
                                                                   .WithEnableAutoCommit(true)
                                                                   .WithAutoCommitIntervalMs(1000);

                ISerDesRaw<string> keyDeserializer = DefaultSerDes<string>.NewByteArraySerDes();
                var valueDeserializer = JsonSerDes.Value<TestType>.NewByteArraySerDes();
                ConsumerRebalanceListener rebalanceListener = null;
                KNetConsumer<string, TestType> consumer = null;
                ManualResetEvent manualResetEvent = new ManualResetEvent(false);

                if (useConsumeCallback)
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
                            manualResetEvent.Set();
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
                        if (runInParallel)
                        {
                            if (useConsumeCallback) consumer.Subscribe(topics, rebalanceListener);
                            else consumer.Subscribe(topics);
                        }
                        else
                        {
                            var tp = new Org.Apache.Kafka.Common.TopicPartition(topicToUse, 0);
                            consumer.Assign(Collections.Singleton(tp));
                            if (_firstOffset != -1)
                            {
                                consumer.Seek(tp, _firstOffset);
                                Console.WriteLine("Seek to: {0}", _firstOffset);
                            }
                            else
                            {
                                consumer.SeekToBeginning(Collections.Singleton(tp));
                                Console.WriteLine("SeekToBeginning");
                            }
                        }
                        if (runInParallel && useConsumeCallback) manualResetEvent.WaitOne();
                        const int checkTime = 200;
                        int waitTime = waitMultiplier * 60 * 1000;
                        Stopwatch swCycleTime = Stopwatch.StartNew();
                        int emptyCycle = 0;
                        while (runInParallel ? !resetEvent.WaitOne(0) : elements < NonParallelLimit)
                        {
                            var records = consumer.Poll((long)TimeSpan.FromMilliseconds(checkTime).TotalMilliseconds);
                            watcherTotal.Start();
                            emptyCycle++;
#if NET7_0_OR_GREATER
                            foreach (var item in records.ApplyPrefetch(withPrefetch, prefetchThreshold: 0))
#else
                            foreach (var item in records)
#endif
                            {
                                emptyCycle = 0;
                                elements++;
                                watcherTotal.Start();
                                var str = $"Consuming from Offset = {item.Offset}, Key = {item.Key}, Value = {item.Value}";
                                watcherTotal.Stop();
                                watcher.Start();
                                if (consoleOutput) Console.WriteLine(str);
                                watcher.Stop();
                            }
                            bool elapsedTimeout = !runInParallel && swCycleTime.ElapsedMilliseconds > waitTime;
                            bool tooManyEmptyCycles = elements != 0 && emptyCycle > 5;
                            if (elapsedTimeout // exit for elapsed timeout or
                                || tooManyEmptyCycles) // if we have at least 5 empty cycles after received something
                            {
                                var str = $"Forcibly exit since no {NonParallelLimit} record was received within {waitTime} ms. Current received is {elements} elapsedTimeout {elapsedTimeout} tooManyEmptyCycles {tooManyEmptyCycles}  ";
                                if (elements != 0)
                                {
                                    Console.WriteLine(str);
                                    break;
                                }
                                else throw new InvalidOperationException(str);
                            }
                        }
                        watcherTotal.Stop();
                    }
                }
                finally
                {
                    keyDeserializer?.Dispose();
                    valueDeserializer?.Dispose();
                    topics?.Dispose();
                    if (elements != 0) Console.WriteLine($"Total mean time is {TimeSpan.FromTicks(watcherTotal.ElapsedTicks / elements)}, console write mean time is {TimeSpan.FromTicks(watcher.ElapsedTicks / elements)}");
                }
            }
            catch (Java.Util.Concurrent.ExecutionException ex)
            {
                if (!avoidThrows) throw;
                Console.WriteLine("Consumer ended with error: {0}", ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                if (!avoidThrows) throw;
                Console.WriteLine("Consumer ended with error: {0}", ex.Message);
            }
        }

        static void ProduceSomethingBuffered()
        {
            Console.WriteLine("Starting ProduceSomethingBuffered");
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
                                                                   .WithAcks(withAck ? ProducerConfigBuilder.AcksTypes.All : ProducerConfigBuilder.AcksTypes.None)
                                                                   .WithMaxRequestSize(10 * 1024 * 1024)
                                                                   .WithRetries(0)
                                                                   .WithLingerMs(1);

                var keySerializer = DefaultSerDes<string>.NewByteArraySerDes(); // standard serDes for string
                var valueSerializer = JsonSerDes.Value<TestType>.NewByteBufferSerDes();
                Stopwatch watcher = new Stopwatch();
                try
                {
                    using (var producer = new KNetProducerValueBuffered<string, TestType>(props, keySerializer, valueSerializer))
                    {
                        int i = 0;
                        Callback callback = null;
                        if (useProduceCallback)
                        {
                            callback = new Callback()
                            {
                                OnOnCompletion = (o1, o2) =>
                                {
                                    if (o2 != null) Console.WriteLine(o2.ToString());
                                    else if (consoleOutput) Console.WriteLine($"Produced on topic {o1.Topic()} at offset {o1.Offset()}");
                                }
                            };
                        }
                        var baseJNICalls = SharedKNetCore.GlobalInstance.CurrentJNICalls;
                        try
                        {
                            while (runInParallel ? !resetEvent.WaitOne(0) : i < NonParallelLimit)
                            {
                                watcher.Start();
                                var record = producer.NewRecord(topicToUse, i.ToString(), new TestType(i, withBigExtraValue, withBigBigExtraValue));
                                var result = useProduceCallback ? producer.Send(record, callback) : producer.Send(record);
                                if (!runInParallel && _firstOffset == -1)
                                {
                                    _firstOffset = result.Get().Offset();
                                }
                                watcher.Stop();
                                if (consoleOutput) Console.WriteLine($"Producing: {record}");
                                if (flushWhileSend)
                                {
                                    watcher.Start();
                                    producer.Flush();
                                    watcher.Stop();
                                }
                                i++;
                            }
                            if (!flushWhileSend)
                            {
                                watcher.Start();
                                producer.Flush();
                                watcher.Stop();
                            }
                            baseJNICalls = SharedKNetCore.GlobalInstance.CurrentJNICalls - baseJNICalls;
                        }
                        finally
                        {
                            if (useProduceCallback) callback.Dispose();
                            if (i != 0) Console.WriteLine($"Flushed {i} elements in {watcher.Elapsed}, produce mean time is {TimeSpan.FromTicks(watcher.ElapsedTicks / i)} with mean JNI Calls {baseJNICalls / i}");
                        }
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
                if (!avoidThrows) throw;
                Console.WriteLine("Producer ended with error: {0}", ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                if (!avoidThrows) throw;
                Console.WriteLine("Producer ended with error: {0}", ex.Message);
            }
        }

        static void ConsumeSomethingBuffered()
        {
            Console.WriteLine("Starting ConsumeSomethingBuffered");
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
                                                                   .WithGroupId(Guid.NewGuid().ToString())
                                                                   .WithAutoOffsetReset(runInParallel ? ConsumerConfigBuilder.AutoOffsetResetTypes.LATEST
                                                                                                      : ConsumerConfigBuilder.AutoOffsetResetTypes.EARLIEST)
                                                                   .WithEnableAutoCommit(true)
                                                                   .WithAutoCommitIntervalMs(1000);

                var keyDeserializer = DefaultSerDes<string>.NewByteArraySerDes();
                var valueDeserializer = JsonSerDes.Value<TestType>.NewByteBufferSerDes();
                ConsumerRebalanceListener rebalanceListener = null;
                KNetConsumerValueBuffered<string, TestType> consumer = null;
                ManualResetEvent manualResetEvent = new ManualResetEvent(false);

                if (useConsumeCallback)
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
                            manualResetEvent.Set();
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
                    using (consumer = new KNetConsumerValueBuffered<string, TestType>(props, keyDeserializer, valueDeserializer))
                    {
                        if (runInParallel)
                        {
                            if (useConsumeCallback) consumer.Subscribe(topics, rebalanceListener);
                            else consumer.Subscribe(topics);
                        }
                        else
                        {
                            var tp = new Org.Apache.Kafka.Common.TopicPartition(topicToUse, 0);
                            consumer.Assign(Collections.Singleton(tp));
                            if (_firstOffset != -1)
                            {
                                consumer.Seek(tp, _firstOffset);
                                Console.WriteLine("Seek to: {0}", _firstOffset);
                            }
                            else
                            {
                                consumer.SeekToBeginning(Collections.Singleton(tp));
                                Console.WriteLine("SeekToBeginning");
                            }
                        }
                        if (runInParallel && useConsumeCallback) manualResetEvent.WaitOne();
                        const int checkTime = 200;
                        int waitTime = waitMultiplier * 60 * 1000;
                        Stopwatch swCycleTime = Stopwatch.StartNew();
                        int emptyCycle = 0;
                        while (runInParallel ? !resetEvent.WaitOne(0) : elements < NonParallelLimit)
                        {
                            var records = consumer.Poll((long)TimeSpan.FromMilliseconds(checkTime).TotalMilliseconds);
                            watcherTotal.Start();
                            emptyCycle++;
#if NET7_0_OR_GREATER
                            foreach (var item in records.ApplyPrefetch(withPrefetch, prefetchThreshold: 0))
#else
                            foreach (var item in records)
#endif
                            {
                                emptyCycle = 0;
                                elements++;
                                watcherTotal.Start();
                                var str = $"Consuming from Offset = {item.Offset}, Key = {item.Key}, Value = {item.Value}";
                                watcherTotal.Stop();
                                watcher.Start();
                                if (consoleOutput) Console.WriteLine(str);
                                watcher.Stop();
                            }
                            bool elapsedTimeout = !runInParallel && swCycleTime.ElapsedMilliseconds > waitTime;
                            bool tooManyEmptyCycles = elements != 0 && emptyCycle > 5;
                            if (elapsedTimeout // exit for elapsed timeout or
                                || tooManyEmptyCycles) // if we have at least 5 empty cycles after received something
                            {
                                var str = $"Forcibly exit since no {NonParallelLimit} record was received within {waitTime} ms. Current received is {elements} elapsedTimeout {elapsedTimeout} tooManyEmptyCycles {tooManyEmptyCycles}  ";
                                if (elements != 0)
                                {
                                    Console.WriteLine(str);
                                    break;
                                }
                                else throw new InvalidOperationException(str);
                            }
                        }
                        watcherTotal.Stop();
                    }
                }
                finally
                {
                    keyDeserializer?.Dispose();
                    valueDeserializer?.Dispose();
                    topics?.Dispose();
                    if (elements != 0) Console.WriteLine($"Total mean time is {TimeSpan.FromTicks(watcherTotal.ElapsedTicks / elements)}, console write mean time is {TimeSpan.FromTicks(watcher.ElapsedTicks / elements)}");
                }
            }
            catch (Java.Util.Concurrent.ExecutionException ex)
            {
                if (!avoidThrows) throw;
                Console.WriteLine("Consumer ended with error: {0}", ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                if (!avoidThrows) throw;
                Console.WriteLine("Consumer ended with error: {0}", ex.Message);
            }
        }
    }
}
