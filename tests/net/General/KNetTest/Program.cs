/*
*  Copyright (c) 2021-2026 MASES s.r.l.
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
using MASES.JCOBridge.C2JBridge;
using MASES.KNet.Admin;
using MASES.KNet.Common;
using MASES.KNet.Consumer;
using MASES.KNet.Extensions;
using MASES.KNet.Producer;
using MASES.KNet.Serialization;
using MASES.KNet.Serialization.Json;
using MASES.KNet.TestCommon;
using Org.Apache.Kafka.Clients.Admin;
using Org.Apache.Kafka.Clients.Consumer;
using Org.Apache.Kafka.Clients.Producer;
using Org.Apache.Kafka.Common;
using Org.Apache.Kafka.Common.Errors;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace MASES.KNetTest
{
    class Program
    {
        static bool deleteTopic = false;
        static bool withExtraValue = false;
        static bool withBigExtraValue = false;
        static bool withBigBigExtraValue = false;
        static bool consoleOutput = Debugger.IsAttached;
        static bool runBuffered = false;
        static bool useProduceCallback = false;
        static bool useConsumeCallback = false;
        static bool onlyProduce = false;
        static bool flushWhileSend = false;
        static bool withAck = false;
        static bool runInParallel = false;
        static bool avoidThrows = false;
        static bool randomizeTopicName = false;
        static bool useAsyncConsume = false;
#if NET7_0_OR_GREATER
        static bool withPrefetch = false;
#endif

        const string theServer = "localhost:9092";
        const string theTopic = "myTopic";
#if DEBUG
        static int NonParallelLimit = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? 100_000 : 1000;
#else
        static int NonParallelLimit = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? 10000 : 100000;
#endif
        static long _firstOffset = -1;
        static readonly int waitMultiplier = 1;
        const int checkTime = 200;
        const int maxEmptyCycle = 200;
        static int waitTime = waitMultiplier * 60 * 1000;

        static string serverToUse = theServer;
        static string topicToUse = theTopic;
        static readonly ManualResetEvent resetEvent = new(false);

        static void Main(string[] args)
        {
            SharedKNetCore.Create();
            var appArgs = SharedKNetCore.FilteredArgs;

            if (appArgs.Length != 0)
            {
                serverToUse = appArgs[0];
                if (appArgs.Length > 1)
                {
                    for (int i = 1; i < appArgs.Length; i++)
                    {
                        var arg = appArgs[i].ToLowerInvariant();

                        if (arg.Equals("deleteTopic", StringComparison.InvariantCultureIgnoreCase)) { deleteTopic = true; continue; }
                        if (arg.Equals("runBuffered", StringComparison.InvariantCultureIgnoreCase)) { runBuffered = true; continue; }
                        if (arg.Equals("consoleOutput", StringComparison.InvariantCultureIgnoreCase)) { consoleOutput = true; continue; }
                        if (arg.Equals("useProduceCallback", StringComparison.InvariantCultureIgnoreCase)) { useProduceCallback = true; continue; }
                        if (arg.Equals("useConsumeCallback", StringComparison.InvariantCultureIgnoreCase)) { useConsumeCallback = true; continue; }
                        if (arg.Equals("withExtraValue", StringComparison.InvariantCultureIgnoreCase)) { withExtraValue = true; NonParallelLimit /= 10; continue; }
                        if (arg.Equals("withBigExtraValue", StringComparison.InvariantCultureIgnoreCase)) { withBigExtraValue = true; NonParallelLimit /= 10; continue; }
                        if (arg.Equals("withBigBigExtraValue", StringComparison.InvariantCultureIgnoreCase)) { withBigBigExtraValue = true; NonParallelLimit /= 100; continue; }
                        if (arg.Equals("onlyProduce", StringComparison.InvariantCultureIgnoreCase)) { onlyProduce = true; continue; }
                        if (arg.Equals("flushWhileSend", StringComparison.InvariantCultureIgnoreCase)) { flushWhileSend = true; continue; }
                        if (arg.Equals("withAck", StringComparison.InvariantCultureIgnoreCase)) { withAck = true; continue; }
                        if (arg.Equals("runInParallel", StringComparison.InvariantCultureIgnoreCase)) { runInParallel = true; continue; }
                        if (arg.Equals("avoidThrows", StringComparison.InvariantCultureIgnoreCase)) { avoidThrows = true; continue; }
                        if (arg.Equals("randomizeTopicName", StringComparison.InvariantCultureIgnoreCase)) { randomizeTopicName = true; continue; }
                        if (arg.Equals("useAsyncConsume", StringComparison.InvariantCultureIgnoreCase)) { useAsyncConsume = true; continue; }
#if NET7_0_OR_GREATER
                        if (arg.Equals("withPrefetch", StringComparison.InvariantCultureIgnoreCase)) { withPrefetch = true; continue; }
#endif
                        Console.WriteLine($"Unknown {arg}");
                    }
                }
            }
#if DEBUG
            consoleOutput = false;
#endif

            if (randomizeTopicName)
            {
                topicToUse += "-" + Guid.NewGuid().ToString();
                Console.WriteLine($"Topic name will be {topicToUse}");
            }

            try
            {
                CreateTopic(topicToUse);
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

                        if (useAsyncConsume)
                        {
                            threadConsume = new(ConsumeAsyncSomethingBuffered)
                            {
                                Name = "consume buffered"
                            };
                        }
                        else
                        {
                            threadConsume = new(ConsumeSomethingBuffered)
                            {
                                Name = "consume buffered"
                            };
                        }
                    }
                    else
                    {
                        threadProduce = new(ProduceSomething)
                        {
                            Name = "produce"
                        };

                        if (useAsyncConsume)
                        {
                            threadConsume = new(ConsumeAsyncSomething)
                            {
                                Name = "consume"
                            };
                        }
                        else
                        {
                            threadConsume = new(ConsumeSomething)
                            {
                                Name = "consume"
                            };
                        }
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
                        if (!onlyProduce)
                        {
                            if (useAsyncConsume) ConsumeAsyncSomethingBuffered();
                            else ConsumeSomethingBuffered();
                        }
                    }
                    else
                    {
                        ProduceSomething();
                        if (!onlyProduce)
                        {
                            if (useAsyncConsume) ConsumeAsyncSomething();
                            else ConsumeSomething();
                        }
                    }
                }
                Thread.Sleep(2000); // wait the threads exit

                Console.WriteLine($"End of {(runBuffered ? "buffered" : "non buffered")} test");
            }
            catch (Exception e)
            {
                Environment.ExitCode = SharedKNetCore.ManageException(e);
            }
            finally
            {
                DeleteTopic(topicToUse);
            }
        }

        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            if (e.Cancel) resetEvent.Set();
        }

        static void CreateTopic(string topicName)
        {
            try
            {
                int partitions = 1;
                short replicationFactor = 1;

                using var topic1 = new NewTopic(topicName, partitions, replicationFactor);

                /**** Direct mode ******
                var map = Collections.SingletonMap(TopicConfig.CLEANUP_POLICY_CONFIG, TopicConfig.CLEANUP_POLICY_COMPACT);
                topic.Configs(map);
                *********/
                using var topic = topic1.Configs(TopicConfigBuilder.Create().WithCleanupPolicy(TopicConfigBuilder.CleanupPolicyTypes.Delete)
                                                                            .WithDeleteRetentionMs(100)
                                                                            .WithMinCleanableDirtyRatio(0.01)
                                                                            .WithMaxMessageBytes(100 * 1024 * 1024)
                                                                            .WithSegmentMs(10000));

                // using var coll = Collections.Singleton(topic);

                /**** Direct mode ******
                Properties props = new Properties();
                props.Put(AdminClientConfig.BOOTSTRAP_SERVERS_CONFIG, serverToUse);
                *******/

                using Properties props = AdminClientConfigBuilder.Create().WithBootstrapServers(serverToUse).ToProperties();

                Console.WriteLine($"Creating {topic} using an AdminClient based on {props}");

                using IAdmin admin = KafkaAdminClient.Create(props);
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

        static void DeleteTopic(string topicName)
        {
            if (!deleteTopic) return;

            try
            {
                Properties props = AdminClientConfigBuilder.Create().WithBootstrapServers(serverToUse).ToProperties();

                Console.WriteLine($"Deleting {topicName} using an AdminClient based on {props}");

                using IAdmin admin = KafkaAdminClient.Create(props);
                admin.DeleteTopic(topicName);
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

        static IDictionary<int, long> LastOffsetOfTopic(string topicName)
        {
            try
            {
                Properties props = AdminClientConfigBuilder.Create().WithBootstrapServers(serverToUse).ToProperties();

                Console.WriteLine($"LastOffsetOfTopic for {topicName} using an AdminClient based on {props}");

                using IAdmin admin = KafkaAdminClient.Create(props);
                return admin.LastPartitionOffsetForTopic(topicName);
            }
            catch (Java.Util.Concurrent.ExecutionException ex)
            {
                if (!avoidThrows) throw;
                Console.WriteLine(ex.InnerException.Message);
            }
            catch (Exception e)
            {
                if (!avoidThrows) throw;
                Console.WriteLine(e.Message);
            }
            return null;
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
                            using var scope = new JCOBridgeDisposeFastScope();
                            while (runInParallel ? !resetEvent.WaitOne(0) : i < NonParallelLimit)
                            {
                                watcher.Start();
                                var record = producer.NewRecord(topicToUse, i.ToString(), new TestType(i, withExtraValue, withBigExtraValue, withBigBigExtraValue));
                                using var result = useProduceCallback ? producer.Send(record, callback) : producer.Send(record);
                                if (!runInParallel && _firstOffset == -1)
                                {
                                    using var metadata = result.Get();
                                    _firstOffset = metadata.Offset();
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
                        }
                        finally
                        {
                            baseJNICalls = SharedKNetCore.GlobalInstance.CurrentJNICalls - baseJNICalls;
                            if (useProduceCallback) callback.Dispose();
                            if (i != 0) Console.WriteLine($"Flushed {i} elements in {watcher.Elapsed}, produce mean time is {TimeSpan.FromTicks(watcher.Elapsed.Ticks / i)} with mean JNI Calls {baseJNICalls / i}");
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
                                                                   .WithGroupId(topicToUse + "-group")
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

                long elements = 0;
                Stopwatch watcherTotal = new Stopwatch();
                Stopwatch watcher = new Stopwatch();
                using var topics = Collections.Singleton((Java.Lang.String)topicToUse);
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
                            using var tp = new Org.Apache.Kafka.Common.TopicPartition(topicToUse, 0);
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

                        Stopwatch swCycleTime = Stopwatch.StartNew();
                        int emptyCycle = 0;
                        long firstOffset = -1;
                        long lastOffset = -1;
                        TopicPartition topicPartition = new TopicPartition(topicToUse, 0);
                        using var scope = new JCOBridgeDisposeFastScope();
                        while (runInParallel ? !resetEvent.WaitOne(0) : elements < NonParallelLimit)
                        {
                            var positionBeforePoll = consumer.Position(topicPartition);
                            watcherTotal.Start();
                            using var records = consumer.Poll(checkTime);
                            watcherTotal.Stop();
                            var positionAfterPoll = consumer.Position(topicPartition);
                            if (records.IsEmpty) emptyCycle++;
                            else if (consoleOutput) Console.WriteLine($"Rceived {records.Count} records");

                            var recordsCount = records.Count;
                            int forEachIteration = 0;
                            bool jumpWrotten = false;
#if NET7_0_OR_GREATER
                            foreach (var item in records.ApplyPrefetch(withPrefetch, prefetchThreshold: 0))
#else
                            foreach (var item in records)
#endif
                            {
                                using (item)
                                {
                                    emptyCycle = 0;
                                    elements++;
                                    if (firstOffset == -1) firstOffset = item.Offset;
                                    watcherTotal.Start();
                                    lastOffset = item.Offset;
                                    if (!jumpWrotten && lastOffset != elements - 1)
                                    {
                                        Console.WriteLine($"Lost message - expected offset {elements - 1} received {lastOffset} positionBeforePoll={positionBeforePoll} positionAfterPoll={positionAfterPoll}");
                                        jumpWrotten = true;
                                    }
                                    var key = item.Key;
                                    var value = item.Value;
                                    var str = $"Consuming from Offset = {lastOffset}, Key = {key}, Value = {value}";
                                    watcherTotal.Stop();
                                    watcher.Start();
                                    if (consoleOutput) Console.WriteLine(str);
                                    watcher.Stop();
                                }
                                forEachIteration++;
                            }
                            if (recordsCount != (positionAfterPoll - positionBeforePoll))
                            {
                                Console.WriteLine($"Missing records - records.Count={recordsCount} positionBeforePoll={positionBeforePoll} positionAfterPoll={positionAfterPoll}");
                            }
                            if (forEachIteration != recordsCount)
                            {
                                Console.WriteLine($"BATCH TRUNCATED: declared={recordsCount} delivered={forEachIteration}");
                            }
                            bool elapsedTimeout = !runInParallel && swCycleTime.ElapsedMilliseconds > waitTime;
                            bool tooManyEmptyCycles = elements != 0 && emptyCycle > maxEmptyCycle;
                            if (elapsedTimeout // exit for elapsed timeout or
                                || tooManyEmptyCycles) // if we have at least maxEmptyCycle empty cycles after received something
                            {
                                long headOffset = -1;
                                var lastOffsets = LastOffsetOfTopic(topicToUse);
                                if (lastOffsets != null)
                                {
                                    headOffset = lastOffsets[0];
                                }

                                if (tooManyEmptyCycles && elements < headOffset && !elapsedTimeout)
                                {
                                    Console.WriteLine($"Wait some more cycles elements={elements} headOffset={headOffset}");
                                    continue;
                                }

                                var str = $"Forcibly exit since no {NonParallelLimit} record was received within {swCycleTime.ElapsedMilliseconds} ms. Current received is {elements} over {headOffset} in topics started from {firstOffset} till {lastOffset} - elapsedTimeout {elapsedTimeout} tooManyEmptyCycles {tooManyEmptyCycles}";
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
                    if (elements != 0) Console.WriteLine($"Total consume time is {watcherTotal.Elapsed}, consume mean time is {TimeSpan.FromTicks(watcherTotal.Elapsed.Ticks / elements)}, console write mean time is {TimeSpan.FromTicks(watcher.Elapsed.Ticks / elements)}");
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

        static void ConsumeAsyncSomething()
        {
            Console.WriteLine("Starting ConsumeAsyncSomething");
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
                                                                   .WithGroupId(topicToUse + "-group")
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
                long elements = 0;
                Stopwatch watcherTotal = new Stopwatch();
                Stopwatch watcher = new Stopwatch();
                Stopwatch consumeAsyncPrecision = new Stopwatch();

                using var topics = Collections.Singleton((Java.Lang.String)topicToUse);
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
                            using var tp = new Org.Apache.Kafka.Common.TopicPartition(topicToUse, 0);
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


                        Stopwatch swCycleTime = Stopwatch.StartNew();

                        int emptyCycle = 0;
                        long firstOffset = -1;
                        long lastOffset = -1;
                        TopicPartition topicPartition = new TopicPartition(topicToUse, 0);
#if NET7_0_OR_GREATER
                        consumer.ApplyPrefetch(withPrefetch);
#endif
                        consumer.SetCallback((record) =>
                        {
                            Volatile.Write(ref emptyCycle, 0);
                            elements++;
                            if (firstOffset == -1) firstOffset = record.Offset;
                            watcherTotal.Start();
                            lastOffset = record.Offset;
                            if (lastOffset != elements - 1) Console.WriteLine($"Lost message - expected offset {elements - 1} received {lastOffset}");
                            var key = record.Key;
                            var value = record.Value;
                            var str = $"Consuming from Offset = {lastOffset}, Key = {key}, Value = {value}";
                            watcherTotal.Stop();
                            watcher.Start();
                            if (consoleOutput) Console.WriteLine(str);
                            watcher.Stop();
                            return true;
                        });
                        while (runInParallel ? !resetEvent.WaitOne(0) : elements < NonParallelLimit)
                        {
                            var positionBeforePoll = consumer.Position(topicPartition);
                            consumeAsyncPrecision.Start();
                            if (!consumer.ConsumeAsync(checkTime))
                            {
                                Interlocked.Increment(ref emptyCycle);
                            }
                            consumeAsyncPrecision.Stop();
                            var positionAfterPoll = consumer.Position(topicPartition);
                            bool elapsedTimeout = !runInParallel && swCycleTime.ElapsedMilliseconds > waitTime;
                            bool tooManyEmptyCycles = elements != 0 && Volatile.Read(ref emptyCycle) > maxEmptyCycle;
                            if (elapsedTimeout // exit for elapsed timeout or
                                || tooManyEmptyCycles) // if we have at least maxEmptyCycle empty cycles after received something
                            {
                                long headOffset = -1;
                                var lastOffsets = LastOffsetOfTopic(topicToUse);
                                if (lastOffsets != null)
                                {
                                    headOffset = lastOffsets[0];
                                }

                                if (tooManyEmptyCycles && elements < headOffset && !elapsedTimeout)
                                {
                                    Console.WriteLine($"Wait some more cycles elements={elements} headOffset={headOffset} - consumer IsEmpty={consumer.IsEmpty} IsCompleting={consumer.IsCompleting}");
                                    continue;
                                }

                                var str = $"Forcibly exit since no {NonParallelLimit} record was received within {swCycleTime.ElapsedMilliseconds} ms. Current received is {elements} over {headOffset} in topics started from {firstOffset} till {lastOffset} - consumer IsEmpty={consumer.IsEmpty} IsCompleting={consumer.IsCompleting} - elapsedTimeout {elapsedTimeout} tooManyEmptyCycles {tooManyEmptyCycles} -> {emptyCycle} emptyCycles in {consumeAsyncPrecision.Elapsed} ms";
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
                    if (elements != 0) Console.WriteLine($"Total consume time is {watcherTotal.Elapsed} with Poll time {consumeAsyncPrecision.Elapsed}, consume mean time is {TimeSpan.FromTicks(watcherTotal.Elapsed.Ticks / elements)}, console write mean time is {TimeSpan.FromTicks(watcher.Elapsed.Ticks / elements)}");
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
                            using var scope = new JCOBridgeDisposeFastScope();
                            while (runInParallel ? !resetEvent.WaitOne(0) : i < NonParallelLimit)
                            {
                                watcher.Start();
                                var record = producer.NewRecord(topicToUse, i.ToString(), new TestType(i, withExtraValue, withBigExtraValue, withBigBigExtraValue));
                                using var result = useProduceCallback ? producer.Send(record, callback) : producer.Send(record);
                                if (!runInParallel && _firstOffset == -1)
                                {
                                    using var metadata = result.Get();
                                    _firstOffset = metadata.Offset();
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
                        }
                        finally
                        {
                            baseJNICalls = SharedKNetCore.GlobalInstance.CurrentJNICalls - baseJNICalls;
                            if (useProduceCallback) callback.Dispose();
                            if (i != 0) Console.WriteLine($"Flushed {i} elements in {watcher.Elapsed}, produce mean time is {TimeSpan.FromTicks(watcher.Elapsed.Ticks / i)} with mean JNI Calls {baseJNICalls / i}");
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
                                                                   .WithGroupId(topicToUse + "-group")
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

                long elements = 0;
                Stopwatch watcherTotal = new Stopwatch();
                Stopwatch watcher = new Stopwatch();
                using var topics = Collections.Singleton((Java.Lang.String)topicToUse);
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
                            using var tp = new Org.Apache.Kafka.Common.TopicPartition(topicToUse, 0);
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

                        Stopwatch swCycleTime = Stopwatch.StartNew();
                        int emptyCycle = 0;
                        long firstOffset = -1;
                        long lastOffset = -1;
                        TopicPartition topicPartition = new TopicPartition(topicToUse, 0);
                        using var scope = new JCOBridgeDisposeFastScope();
                        while (runInParallel ? !resetEvent.WaitOne(0) : elements < NonParallelLimit)
                        {
                            var positionBeforePoll = consumer.Position(topicPartition);
                            watcherTotal.Start();
                            using var records = consumer.Poll(checkTime);
                            watcherTotal.Stop();
                            var positionAfterPoll = consumer.Position(topicPartition);
                            if (records.IsEmpty) emptyCycle++;
                            else if (consoleOutput) Console.WriteLine($"Rceived {records.Count} records");
                            var recordsCount = records.Count;
                            int forEachIteration = 0;
                            bool jumpWrotten = false;
#if NET7_0_OR_GREATER
                            foreach (var item in records.ApplyPrefetch(withPrefetch, prefetchThreshold: 0))
#else
                            foreach (var item in records)
#endif
                            {
                                using (item)
                                {
                                    emptyCycle = 0;
                                    elements++;
                                    if (firstOffset == -1) firstOffset = item.Offset;
                                    watcherTotal.Start();
                                    lastOffset = item.Offset;
                                    if (!jumpWrotten && lastOffset != elements - 1)
                                    {
                                        Console.WriteLine($"Lost message - expected offset {elements - 1} received {lastOffset} positionBeforePoll={positionBeforePoll} positionAfterPoll={positionAfterPoll}");
                                        jumpWrotten = true;
                                    }
                                    var key = item.Key;
                                    var value = item.Value;
                                    var str = $"Consuming from Offset = {lastOffset}, Key = {key}, Value = {value}";
                                    watcherTotal.Stop();
                                    watcher.Start();
                                    if (consoleOutput) Console.WriteLine(str);
                                    watcher.Stop();
                                }
                                forEachIteration++;
                            }
                            if (recordsCount != (positionAfterPoll - positionBeforePoll))
                            {
                                Console.WriteLine($"Missing records - records.Count={recordsCount} positionBeforePoll={positionBeforePoll} positionAfterPoll={positionAfterPoll}");
                            }
                            if (forEachIteration != recordsCount)
                            {
                                Console.WriteLine($"BATCH TRUNCATED: declared={recordsCount} delivered={forEachIteration}");
                            }
                            bool elapsedTimeout = !runInParallel && swCycleTime.ElapsedMilliseconds > waitTime;
                            bool tooManyEmptyCycles = elements != 0 && emptyCycle > maxEmptyCycle;
                            if (elapsedTimeout // exit for elapsed timeout or
                                || tooManyEmptyCycles) // if we have at least maxEmptyCycle empty cycles after received something
                            {
                                long headOffset = -1;
                                var lastOffsets = LastOffsetOfTopic(topicToUse);
                                if (lastOffsets != null)
                                {
                                    headOffset = lastOffsets[0];
                                }

                                if (tooManyEmptyCycles && elements < headOffset && !elapsedTimeout)
                                {
                                    Console.WriteLine($"Wait some more cycles elements={elements} headOffset={headOffset}");
                                    continue;
                                }

                                var str = $"Forcibly exit since no {NonParallelLimit} record was received within {swCycleTime.ElapsedMilliseconds} ms. Current received is {elements} over {headOffset} in topics started from {firstOffset} - elapsedTimeout {elapsedTimeout} tooManyEmptyCycles {tooManyEmptyCycles}";
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
                    if (elements != 0) Console.WriteLine($"Total consume time is {watcherTotal.Elapsed}, consume mean time is {TimeSpan.FromTicks(watcherTotal.Elapsed.Ticks / elements)}, console write mean time is {TimeSpan.FromTicks(watcher.Elapsed.Ticks / elements)}");
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

        static void ConsumeAsyncSomethingBuffered()
        {
            Console.WriteLine("Starting ConsumeAsyncSomethingBuffered");
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
                                                                   .WithGroupId(topicToUse + "-group")
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
                long elements = 0;
                Stopwatch watcherTotal = new Stopwatch();
                Stopwatch watcher = new Stopwatch();
                Stopwatch consumeAsyncPrecision = new Stopwatch();

                using var topics = Collections.Singleton((Java.Lang.String)topicToUse);
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
                            using var tp = new Org.Apache.Kafka.Common.TopicPartition(topicToUse, 0);
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

                        Stopwatch swCycleTime = Stopwatch.StartNew();
                        int emptyCycle = 0;
                        long firstOffset = -1;
                        long lastOffset = -1;
#if NET7_0_OR_GREATER
                        consumer.ApplyPrefetch(withPrefetch);
#endif
                        consumer.SetCallback((record) =>
                        {
                            Volatile.Write(ref emptyCycle, 0);
                            elements++;
                            if (firstOffset == -1) firstOffset = record.Offset;
                            watcherTotal.Start();
                            lastOffset = record.Offset;
                            if (lastOffset != elements - 1) Console.WriteLine($"Lost message - expected offset {elements - 1} received {lastOffset}");
                            var key = record.Key;
                            var value = record.Value;
                            var str = $"Consuming from Offset = {lastOffset}, Key = {key}, Value = {value}";
                            watcherTotal.Stop();
                            watcher.Start();
                            if (consoleOutput) Console.WriteLine(str);
                            watcher.Stop();
                            return true;
                        });
                        while (runInParallel ? !resetEvent.WaitOne(0) : elements < NonParallelLimit)
                        {
                            consumeAsyncPrecision.Start();
                            if (!consumer.ConsumeAsync(checkTime))
                            {
                                Interlocked.Increment(ref emptyCycle);
                            }
                            consumeAsyncPrecision.Stop();
                            bool elapsedTimeout = !runInParallel && swCycleTime.ElapsedMilliseconds > waitTime;
                            bool tooManyEmptyCycles = elements != 0 && Volatile.Read(ref emptyCycle) > maxEmptyCycle;
                            if (elapsedTimeout // exit for elapsed timeout or
                                || tooManyEmptyCycles) // if we have at least maxEmptyCycle empty cycles after received something
                            {
                                long headOffset = -1;
                                var lastOffsets = LastOffsetOfTopic(topicToUse);
                                if (lastOffsets != null)
                                {
                                    headOffset = lastOffsets[0];
                                }

                                if (tooManyEmptyCycles && elements < headOffset && !elapsedTimeout)
                                {
                                    Console.WriteLine($"Wait some more cycles elements={elements} headOffset={headOffset} - consumer IsEmpty={consumer.IsEmpty} IsCompleting={consumer.IsCompleting}");
                                    continue;
                                }

                                var str = $"Forcibly exit since no {NonParallelLimit} record was received within {swCycleTime.ElapsedMilliseconds} ms. Current received is {elements} over {headOffset} in topics started from {firstOffset} offset - consumer IsEmpty={consumer.IsEmpty} IsCompleting={consumer.IsCompleting} - elapsedTimeout {elapsedTimeout} tooManyEmptyCycles {tooManyEmptyCycles} -> {emptyCycle} emptyCycles in {consumeAsyncPrecision.Elapsed} ms";
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
                    if (elements != 0) Console.WriteLine($"Total consume time is {watcherTotal.Elapsed} with Poll time {consumeAsyncPrecision.Elapsed}, consume mean time is {TimeSpan.FromTicks(watcherTotal.Elapsed.Ticks / elements)}, console write mean time is {TimeSpan.FromTicks(watcher.Elapsed.Ticks / elements)}");
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
