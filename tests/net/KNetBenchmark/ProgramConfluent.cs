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

using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace MASES.KNet.Benchmark
{
    partial class Program
    {
        static ISerializer<long> confluentKeySerializer = null;
        static ISerializer<byte[]> confluentValueSerializer = null;
        static IProducer<long, byte[]> confluentProducer = null;

        static IProducer<long, byte[]> ConfluentProducer()
        {
            if (confluentProducer == null || !SharedObjects)
            {
                var producerConfig = new ProducerConfig
                {
                    BootstrapServers = Server,
                    Acks = Acks ? Confluent.Kafka.Acks.Leader : Confluent.Kafka.Acks.None,
                    MessageSendMaxRetries = MessageSendMaxRetries,
                    LingerMs = LingerMs,
                    BatchSize = BatchSize,
                    MaxInFlight = MaxInFlight,
                    SocketSendBufferBytes = SocketSendBufferBytes,
                    SocketReceiveBufferBytes = SocketReceiveBufferBytes,
                    MessageMaxBytes = MaxPacketLength + 1000,
                    //MessageCopyMaxBytes = length,
                };

                var producerBuilder = new ProducerBuilder<long, byte[]>(producerConfig);

                if (UseSerdes)
                {
                    producerBuilder.SetKeySerializer(confluentKeySerializer);
                    producerBuilder.SetValueSerializer(confluentValueSerializer);
                }

                confluentProducer = producerBuilder.Build();
            }
            return confluentProducer;
        }


        static Stopwatch ProduceConfluent(string topicName, int length, int numpacket, byte[] data = null)
        {
            Stopwatch swCreateRecord = null;
            Stopwatch swSendRecord = null;
            Stopwatch stopWatch = null;
            Stopwatch flushTimeWatch = null;
            IProducer<long, byte[]> producer = ConfluentProducer();
            try
            {
                if (data == null)
                {
                    var rand = new Random();
                    data = new byte[length];
                    for (int i = 0; i < length; i++)
                    {
                        data[i] = (byte)rand.Next(0, byte.MaxValue);
                    }
                }
                var message = new Message<long, byte[]>
                {
                    Key = 42,
                    Value = data
                };
                if (ProducePreLoad)
                {
                    swCreateRecord = new();
                    swSendRecord = new();
                    List<Message<long, byte[]>> messages = new();
                    for (int i = 0; i < numpacket; i++)
                    {
                        var rand = new Random();
                        data = new byte[length];
                        for (int ii = 0; ii < length; ii++)
                        {
                            data[ii] = (byte)rand.Next(0, byte.MaxValue);
                        }
                        swCreateRecord.Start();
                        message = new Message<long, byte[]>
                        {
                            Key = i,
                            Value = data
                        };
                        swCreateRecord.Stop();
                        messages.Add(message);
                    }
                    stopWatch = Stopwatch.StartNew();
                    for (int i = 0; i < numpacket; i++)
                    {
                        swSendRecord.Start();
                        producer.Produce(topicName, messages[i]);
                        swSendRecord.Stop();
                        if (WithBurst)
                        {
                            if (i % BurstLength == 0)
                            {
                                stopWatch.Stop();
                                System.Threading.Thread.Sleep(BurstInterval);
                                stopWatch.Start();
                            }
                        }
                        if (ContinuousFlushConfluent) producer.Flush();
                    }
                }
                else
                {
                    swCreateRecord = new();
                    swSendRecord = new();
                    stopWatch = Stopwatch.StartNew();
                    for (int i = 0; i < numpacket; i++)
                    {
                        if (!SinglePacket)
                        {
                            stopWatch.Stop();
                            byte[] newData = new byte[data.Length];
                            Array.Copy(data, 0, newData, 0, data.Length);
                            stopWatch.Start();
                            swCreateRecord.Start();
                            message = new Message<long, byte[]>
                            {
                                Key = i,
                                Value = newData
                            };
                            swCreateRecord.Stop();
                        }
                        swSendRecord.Start();
                        if (UseCallback)
                        {
                            producer.Produce(topicName, message, (o) =>
                            {
                                if (o.Error.IsError) Console.WriteLine(o.Error.ToString());
                                else if (ShowLogs) Console.WriteLine($"Produced on topic {o.Topic} at offset {o.Offset}");
                            });
                        }
                        else
                        {
                            producer.Produce(topicName, message);
                        }
                        swSendRecord.Stop();
                        if (WithBurst)
                        {
                            if (i % BurstLength == 0)
                            {
                                stopWatch.Stop();
                                System.Threading.Thread.Sleep(BurstInterval);
                                stopWatch.Start();
                            }
                        }
                        if (ContinuousFlushConfluent) producer.Flush();
                    }
                }
            }
            finally
            {
                if (NoFlushTime) stopWatch.Stop();
                flushTimeWatch = Stopwatch.StartNew();
                producer.Flush();
                flushTimeWatch.Stop();
                stopWatch?.Stop();
                if (!SharedObjects) { producer.Dispose(); producer = null; }
            }

            if (numpacket != 0 && ShowIntermediateResults && !ProducePreLoad)
            {
                Console.WriteLine($"Confluent: Create {swCreateRecord.ElapsedMicroSeconds()} ({swCreateRecord.ElapsedMicroSeconds() / numpacket}) Send {swSendRecord.ElapsedMicroSeconds()} ({swSendRecord.ElapsedMicroSeconds() / numpacket}) Flush {flushTimeWatch.ElapsedMicroSeconds()} -> TotalTime {stopWatch.ElapsedMicroSeconds()} BackTime {stopWatch.ElapsedMicroSeconds() - (swCreateRecord.ElapsedMicroSeconds() + swSendRecord.ElapsedMicroSeconds())}");
            }
            return stopWatch;
        }

        static IDeserializer<long> confluentKeyDeserializer = null;
        static IDeserializer<byte[]> confluentValueDeserializer = null;
        static IConsumer<long, byte[]> confluentConsumer = null;

        static IConsumer<long, byte[]> ConfluentConsumer()
        {
            if (confluentConsumer == null || !SharedObjects)
            {
                var consumerConfig = new ConsumerConfig
                {
                    BootstrapServers = Server,
                    GroupId = Guid.NewGuid().ToString(),
                    EnableAutoCommit = !AlwaysCommit,
                    AutoCommitIntervalMs = 1000,
                    AutoOffsetReset = AutoOffsetReset.Earliest,
                    //MessageCopyMaxBytes = length,
                    FetchMinBytes = FetchMinBytes,
                };
                var consumerBuilder = new ConsumerBuilder<long, byte[]>(consumerConfig);
                if (UseSerdes)
                {
                    consumerBuilder.SetKeyDeserializer(confluentKeyDeserializer);
                    consumerBuilder.SetValueDeserializer(confluentValueDeserializer);
                }
                consumerBuilder.SetPartitionsAssignedHandler(PartitionsAssignedHandler);
                confluentConsumer = consumerBuilder.Build();
            }
            return confluentConsumer;
        }

        static Action<IConsumer<long, byte[]>, List<TopicPartition>> PartitionsAssignedHandler_trampoline;

        static void PartitionsAssignedHandler(IConsumer<long, byte[]> consumer, List<TopicPartition> lst)
        {
            PartitionsAssignedHandler_trampoline?.Invoke(consumer, lst);
        }

        static Stopwatch ConsumeConfluent(int testNum, string topicName, int length, int numpacket, byte[] data = null)
        {
            Stopwatch stopWatch = null;
            int counter = 0;

            PartitionsAssignedHandler_trampoline = (o1, o2) =>
            {
                if (ShowLogs) Console.WriteLine("Assigned: {0}", string.Join(" ", o2.Select((o) => o.ToString()).ToArray()));
                stopWatch = Stopwatch.StartNew();
            };

            var consumer = ConfluentConsumer();
            try
            {
                consumer.Subscribe(topicName);
                while (true)
                {
                    var record = consumer.Consume(TimeSpan.FromMinutes(1));
                    if (record != null)
                    {
                        if (CheckOnConsume
                            && (!record.Message.Value.SequenceEqual(data)
                                || (!SinglePacket && record.Message.Key != counter)))
                        {
                            throw new InvalidOperationException($"ConsumeConfluent test {testNum}: Incorrect data counter {counter} item.Key {record.Message.Key}");
                        }
                        if (AlwaysCommit) consumer.Commit(record);
                        counter++;
                    }
                    if (counter >= numpacket)
                    {
                        try
                        {
                            consumer.Commit();
                        }
                        catch { }
                        stopWatch?.Stop();
                        consumer.Unsubscribe();
                        return stopWatch;
                    }
                }
            }
            finally
            {
                if (!SharedObjects) { consumer.Dispose(); consumer = null; }
            }
        }

        static Stopwatch ConsumeProduceConfluent(string topicName, int length, int numpacket, byte[] data = null)
        {
            Stopwatch stopWatch = null;
            int counter = 0;

            PartitionsAssignedHandler_trampoline = (o1, o2) =>
            {
                if (ShowLogs) Console.WriteLine("Assigned: {0}", string.Join(" ", o2.Select((o) => o.ToString()).ToArray()));
                stopWatch = Stopwatch.StartNew();
            };

            var consumer = ConfluentConsumer();
            var producer = ConfluentProducer();
            try
            {
                consumer.Subscribe(topicName);
                while (true)
                {
                    var record = consumer.Consume(TimeSpan.FromMinutes(1));
                    if (record != null)
                    {
                        stopWatch.Stop();
                        byte[] newVal = new byte[record.Message.Value.Length];
                        Array.Copy(record.Message.Value, newVal, record.Message.Value.Length);
                        stopWatch.Start();
                        var message = new Message<long, byte[]>
                        {
                            Key = record.Message.Key,
                            Value = newVal
                        };
                        producer.Produce(topicName + "_COPY", message);
                        consumer.Commit(record);
                        counter++;
                    }
                    if (counter >= numpacket)
                    {
                        try
                        {
                            consumer.Commit();
                        }
                        catch (Exception ex) { Console.WriteLine($"ConsumeProduceConfluent Commit error: {ex.Message}"); }
                        try
                        {
                            producer.Flush();
                        }
                        catch (Exception ex) { Console.WriteLine($"ConsumeProduceConfluent Flush error: {ex.Message}"); }
                        stopWatch?.Stop();
                        consumer.Unsubscribe();
                        return stopWatch;
                    }
                }
            }
            finally
            {
                if (!SharedObjects)
                {
                    consumer.Dispose();
                    producer.Dispose();
                    consumer = null;
                    producer = null;
                }
            }
        }

        static (Stopwatch, IEnumerable<double>) RoundTripConfluent(int testNum, string topicName, int length, int numpacket, byte[] data = null)
        {
            try
            {
                List<double> roundTripTime = new System.Collections.Generic.List<double>();
                ManualResetEvent startEvent = new ManualResetEvent(false);
                var consumer = ConfluentConsumer();
                var producer = ConfluentProducer();
                PartitionsAssignedHandler_trampoline = (o1, o2) =>
                {
                    if (ShowLogs) Console.WriteLine("Assigned: {0}", string.Join(" ", o2.Select((o) => o.ToString()).ToArray()));
                    startEvent.Set();
                };

                System.Threading.Thread thread = new System.Threading.Thread(() =>
                {
                    try
                    {
                        consumer.Subscribe(topicName);
                        int counter = 0;
                        while (true)
                        {
                            var record = consumer.Consume(TimeSpan.FromSeconds(1));
                            if (record != null)
                            {
                                roundTripTime.Add((double)(DateTime.Now.Ticks - record.Message.Key) / (TimeSpan.TicksPerMillisecond / 1000));

                                if (CheckOnConsume && !record.Message.Value.SequenceEqual(data))
                                {
                                    throw new InvalidOperationException($"ConsumeConfluent test {testNum}: Incorrect data counter {counter} item.Key {record.Message.Key}");
                                }
                                counter++;
                            }

                            if (AlwaysCommit) consumer.Commit(record);
                            if (counter >= numpacket)
                            {
                                consumer.Commit(record);
                                consumer.Unsubscribe();
                                break;
                            }
                        }
                    }
                    finally
                    {
                        if (!SharedObjects)
                        {
                            consumer.Dispose();
                            consumer = null;
                        }
                        startEvent.Set();
                    }
                });

                thread.Start();
                startEvent.WaitOne();
                startEvent.Reset();

                Stopwatch totalExecution = Stopwatch.StartNew();

                Stopwatch swCreateRecord = null;
                Stopwatch swSendRecord = null;
                Stopwatch stopWatch = null;
                try
                {
                    if (data == null)
                    {
                        var rand = new System.Random();
                        data = new byte[length];
                        for (int i = 0; i < length; i++)
                        {
                            data[i] = (byte)rand.Next(0, byte.MaxValue);
                        }
                    }
                    var message = new Message<long, byte[]>
                    {
                        Key = 42,
                        Value = data
                    };
                    swCreateRecord = new();
                    swSendRecord = new();
                    stopWatch = Stopwatch.StartNew();
                    for (int i = 0; i < numpacket; i++)
                    {
                        if (!SinglePacket)
                        {
                            stopWatch.Stop();
                            byte[] newData = new byte[data.Length];
                            Array.Copy(data, 0, newData, 0, data.Length);
                            stopWatch.Start();
                            swCreateRecord.Start();
                            message = new Message<long, byte[]>
                            {
                                Key = DateTime.Now.Ticks,
                                Value = newData
                            };
                            swCreateRecord.Stop();
                        }
                        swSendRecord.Start();
                        if (UseCallback)
                        {
                            producer.Produce(topicName, message, (o) =>
                            {
                                if (o.Error.IsError) Console.WriteLine(o.Error.ToString());
                                else if (ShowLogs) Console.WriteLine($"Produced on topic {o.Topic} at offset {o.Offset}");
                            });
                        }
                        else
                        {
                            producer.Produce(topicName, message);
                        }
                        swSendRecord.Stop();
                        if (WithBurst)
                        {
                            if (i % BurstLength == 0)
                            {
                                stopWatch.Stop();
                                System.Threading.Thread.Sleep(BurstInterval);
                                stopWatch.Start();
                            }
                        }
                        if (ContinuousFlushConfluent) producer.Flush();
                    }
                }
                finally { producer.Flush(); stopWatch.Stop(); if (!SharedObjects) { producer.Dispose(); producer = null; } }
                startEvent.WaitOne();
                totalExecution.Stop();
                if (ShowIntermediateResults)
                {
                    Console.WriteLine($"Confluent: Create {swCreateRecord.ElapsedMicroSeconds()} ({swCreateRecord.ElapsedMicroSeconds() / numpacket}) Send {swSendRecord.ElapsedMicroSeconds()} ({swSendRecord.ElapsedMicroSeconds() / numpacket}) -> {swCreateRecord.ElapsedMicroSeconds() + swSendRecord.ElapsedMicroSeconds()} -> BackTime {stopWatch.ElapsedMicroSeconds() - (swCreateRecord.ElapsedMicroSeconds() + swSendRecord.ElapsedMicroSeconds())}");
                }

                return (totalExecution, roundTripTime);
            }
            catch (Java.Util.Concurrent.ExecutionException ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
