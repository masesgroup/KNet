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
using MASES.JCOBridge.C2JBridge;
using MASES.KNet.Consumer;
using MASES.KNet.Producer;
using Org.Apache.Kafka.Clients.Consumer;
using Org.Apache.Kafka.Clients.Producer;
using Org.Apache.Kafka.Common.Serialization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace MASES.KNet.Benchmark
{
    partial class Program
    {
        static IKNetProducer<long, byte[]> knetProducer = null;
        static KNetSerDes<long> knetKeySerializer = null;
        static KNetSerDes<byte[]> knetValueSerializer = null;

        static IKNetProducer<long, byte[]> KNetProducer()
        {
            if (knetProducer == null || !SharedObjects)
            {
                Properties props = ProducerConfigBuilder.Create()
                                                        .WithBootstrapServers(Server)
                                                        .WithAcks(Acks ? ProducerConfig.Acks.One : ProducerConfig.Acks.None)
                                                        .WithRetries(MessageSendMaxRetries)
                                                        .WithLingerMs(LingerMs)
                                                        .WithBatchSize(BatchSize)
                                                        .WithMaxInFlightRequestPerConnection(MaxInFlight)
                                                        .WithEnableIdempotence(false)
                                                        .WithSendBuffer(SocketSendBufferBytes)
                                                        .WithReceiveBuffer(SocketReceiveBufferBytes)
                                                        .WithBufferMemory(128 * 1024 * 1024)
                                                        .WithKeySerializerClass("org.apache.kafka.common.serialization.LongSerializer")
                                                        .WithValueSerializerClass("org.apache.kafka.common.serialization.ByteArraySerializer")
                                                        .ToProperties();

                knetKeySerializer = new KNetSerDes<long>(serializeWithHeadersFun: (topic, headers, data) =>
                {
                    var key = BitConverter.GetBytes(data);
                    return key;
                });
                knetValueSerializer = new KNetSerDes<byte[]>(serializeWithHeadersFun: (topic, headers, data) =>
                {
                    // var value = Encoding.Unicode.GetBytes(data);
                    return data;
                });
                knetProducer = new KNetProducer<long, byte[]>(props, knetKeySerializer, knetValueSerializer);
            }
            return knetProducer;
        }

        static Callback kNetCallback = null;

        static Stopwatch ProduceKNet(string topicName, int length, int numpacket, byte[] data = null)
        {
            try
            {
                var knetproducer = KNetProducer();
                knetproducer.PartitionsFor(topicName); // used to get metadata before do the test

                if (UseCallback && kNetCallback == null)
                {
                    kNetCallback = new Callback((o1, o2) =>
                    {
                        if (o2 != null) Console.WriteLine(o2.ToString());
                        else if (ShowLogs) Console.WriteLine($"Produced on topic {o1.Topic} at offset {o1.Offset}");
                    });
                }

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
                    if (ProducePreLoad)
                    {
                        throw new NotImplementedException("Not implemented when using KNet producer");
                    }
                    else
                    {
                        swCreateRecord = new();
                        swSendRecord = new();
                        if (UseCallback)
                        {
                            knetproducer.SetCallback(kNetCallback);
                        }
                        stopWatch = Stopwatch.StartNew();
                        for (int i = 0; i < numpacket; i++)
                        {
                            if (!SinglePacket)
                            {
                                stopWatch.Stop();
                                byte[] newData = new byte[data.Length];
                                Array.Copy(data, 0, newData, 0, data.Length);
                                stopWatch.Start();
                                swSendRecord.Start();
                                knetproducer.Send(topicName, i, newData);
                                swSendRecord.Stop();
                            }
                            else
                            {
                                swSendRecord.Start();
                                knetproducer.Send(topicName, i, data);
                                swSendRecord.Stop();
                            }
                            if (WithBurst)
                            {
                                if (i % BurstLength == 0)
                                {
                                    stopWatch.Stop();
                                    System.Threading.Thread.Sleep(BurstInterval);
                                    stopWatch.Start();
                                }
                            }
                            if (ContinuousFlushKNet) knetproducer.Flush();
                        }
                    }
                }
                finally { knetproducer.Flush(); stopWatch.Stop(); if (!SharedObjects) knetproducer.Dispose(); }
                if (ShowResults && !ProducePreLoad)
                {
                    Console.WriteLine($"KNET: Create {swCreateRecord.ElapsedMicroSeconds()} ({swCreateRecord.ElapsedMicroSeconds() / numpacket}) Send {swSendRecord.ElapsedMicroSeconds()} ({swSendRecord.ElapsedMicroSeconds() / numpacket}) -> {swCreateRecord.ElapsedMicroSeconds() + swSendRecord.ElapsedMicroSeconds()} -> BackTime {stopWatch.ElapsedMicroSeconds() - (swCreateRecord.ElapsedMicroSeconds() + swSendRecord.ElapsedMicroSeconds())}");
                }
                return stopWatch;
            }
            catch (Java.Util.Concurrent.ExecutionException ex)
            {
                throw ex.InnerException;
            }
        }

        static KNetSerDes<long> knetKeyDeserializer = null;
        static KNetSerDes<byte[]> knetValueDeserializer = null;
        static IKNetConsumer<long, byte[]> knetConsumer = null;

        static IKNetConsumer<long, byte[]> KNetConsumer()
        {
            if (knetConsumer == null || !SharedObjects)
            {
                Properties props = ConsumerConfigBuilder.Create()
                                                        .WithBootstrapServers(Server)
                                                        .WithGroupId(Guid.NewGuid().ToString())
                                                        .WithEnableAutoCommit(!AlwaysCommit)
                                                        .WithAutoCommitIntervalMs(1000)
                                                        .WithSendBuffer(SocketSendBufferBytes)
                                                        .WithReceiveBuffer(SocketReceiveBufferBytes)
                                                        .WithFetchMinBytes(FetchMinBytes)
                                                        .WithKeyDeserializerClass("org.apache.kafka.common.serialization.LongDeserializer")
                                                        .WithValueDeserializerClass("org.apache.kafka.common.serialization.ByteArrayDeserializer")
                                                        .WithAutoOffsetReset(ConsumerConfig.AutoOffsetReset.EARLIEST)
                                                        .ToProperties();
                if (UseSerdes)
                {
                    knetKeyDeserializer = new KNetSerDes<long>(deserializeFun: (topic, data) =>
                    {
                        var key = BitConverter.ToInt32(data, 0);
                        return key;
                    });
                    knetValueDeserializer = new KNetSerDes<byte[]>(deserializeFun: (topic, data) =>
                    {
                        // var value = Encoding.Unicode.GetString(data);
                        return data;
                    });
                }

                knetConsumer = UseSerdes ? new KNetConsumer<long, byte[]>(props, knetKeyDeserializer, knetValueDeserializer) : new KNetConsumer<long, byte[]>(props);
            }
            return knetConsumer;
        }

        static Stopwatch ConsumeKNet(int testNum, string topicName, int length, int numpacket, byte[] data = null)
        {
            try
            {
                Stopwatch stopWatch = null;
                ConsumerRebalanceListener rebalanceListener = new(
                                    revoked: (o) =>
                                    {
                                        if (ShowLogs) Console.WriteLine("Revoked: {0}", o.ToString());
                                    },
                                    assigned: (o) =>
                                    {
                                        if (ShowLogs) Console.WriteLine("Assigned: {0}", o.ToString());
                                        stopWatch = Stopwatch.StartNew();
                                    });

                var consumer = KNetConsumer();
                try
                {
                    int counter = 0;
                    consumer.Subscribe(Collections.Singleton(topicName), rebalanceListener);
                    consumer.SetCallback((message) =>
                    {
                        if (CheckOnConsume)
                        {
                            if (!message.Value.SequenceEqual(data)
                                || (!SinglePacket && message.Key != counter))
                            {
                                throw new InvalidOperationException($"KNetConsumer test {testNum}: Incorrect data counter {counter} item.Key {message.Key}");
                            }
                        }
                        counter++;
                    });
                    while (true)
                    {
                        consumer.ConsumeAsync((long)TimeSpan.FromMilliseconds(100).TotalMilliseconds);

                        if (AlwaysCommit) consumer.CommitSync();
                        if (counter >= numpacket)
                        {
                            consumer.CommitSync();
                            stopWatch.Stop();
                            consumer.Unsubscribe();
                            return stopWatch;
                        }
                    }
                }
                finally
                {
                    if (!SharedObjects) consumer.Dispose();
                    rebalanceListener?.Dispose();
                }
            }
            catch (Java.Util.Concurrent.ExecutionException ex)
            {
                throw ex.InnerException;
            }
        }

        static Stopwatch ConsumeProduceKNet(string topicName, int length, int numpacket, byte[] data = null)
        {
            try
            {
                Stopwatch stopWatch = null;
                ConsumerRebalanceListener rebalanceListener = new(
                                    revoked: (o) =>
                                    {
                                        if (ShowLogs) Console.WriteLine("Revoked: {0}", o.ToString());
                                    },
                                    assigned: (o) =>
                                    {
                                        if (ShowLogs) Console.WriteLine("Assigned: {0}", o.ToString());
                                        stopWatch = Stopwatch.StartNew();
                                    });

                var consumer = KNetConsumer();
                var producer = KNetProducer();
                try
                {
                    int counter = 0;
                    consumer.Subscribe(Collections.Singleton(topicName), rebalanceListener);
                    while (true)
                    {
                        var records = consumer.Poll(TimeSpan.FromMinutes(1));
                        foreach (var item in records)
                        {
                            stopWatch.Stop();
                            byte[] newVal = new byte[item.Value.Length];
                            Array.Copy(item.Value, newVal, item.Value.Length);
                            stopWatch.Start();
                            var record = new ProducerRecord<long, byte[]>(topicName + "_COPY", item.Key, newVal);
                            producer.Send(record);
                            counter++;
                        }
                        producer.Flush();
                        consumer.CommitSync();
                        if (counter >= numpacket)
                        {
                            stopWatch.Stop();
                            consumer.Unsubscribe();
                            return stopWatch;
                        }
                    }
                }
                finally
                {
                    rebalanceListener?.Dispose();
                    if (!SharedObjects)
                    {
                        consumer.Dispose();
                        producer.Dispose();
                    }
                }
            }
            catch (Java.Util.Concurrent.ExecutionException ex)
            {
                throw ex.InnerException;
            }
        }

        static (Stopwatch, IEnumerable<double>) RoundTripKNet(int testNum, string topicName, int length, int numpacket, byte[] data = null)
        {
            try
            {
                System.Collections.Generic.List<double> roundTripTime = new System.Collections.Generic.List<double>();
                ManualResetEvent startEvent = new ManualResetEvent(false);
                var consumer = KNetConsumer();
                var producer = KNetProducer();

                System.Threading.Thread thread = new System.Threading.Thread(() =>
                {
                    ConsumerRebalanceListener rebalanceListener = null;
                    try
                    {
                        rebalanceListener = new(revoked: (o) =>
                                                {
                                                    if (ShowLogs) Console.WriteLine("Revoked: {0}", o.ToString());
                                                },
                                                assigned: (o) =>
                                                {
                                                    if (ShowLogs) Console.WriteLine("Assigned: {0}", o.ToString());
                                                    startEvent.Set();
                                                });
                        consumer.Subscribe(Collections.Singleton(topicName), rebalanceListener);
                        Java.Time.Duration duration = TimeSpan.FromSeconds(1);
                        int counter = 0;
                        while (true)
                        {
                            var records = consumer.Poll(duration);
                            foreach (var item in records)
                            {
                                roundTripTime.Add((double)(DateTime.Now.Ticks - item.Key) / (TimeSpan.TicksPerMillisecond / 1000));

                                if (CheckOnConsume && !item.Value.SequenceEqual(data))
                                {
                                    throw new InvalidOperationException($"ConsumeKafka test {testNum}: Incorrect data counter {counter} item.Key {item.Key}");
                                }
                                counter++;
                            }

                            if (AlwaysCommit) consumer.CommitSync();
                            if (counter >= numpacket)
                            {
                                consumer.CommitSync();
                                consumer.Unsubscribe();
                                break;
                            }
                        }
                    }
                    finally
                    {
                        rebalanceListener?.Dispose();
                        if (!SharedObjects)
                        {
                            consumer.Dispose();
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
                    var record = new ProducerRecord<long, byte[]>(topicName, 42, data);
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
                            record = new ProducerRecord<long, byte[]>(topicName, DateTime.Now.Ticks, newData);
                            swCreateRecord.Stop();
                        }
                        swSendRecord.Start();
                        if (UseCallback)
                            producer.Send(record, kNetCallback);
                        else
                            producer.Send(record);
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
                        if (ContinuousFlushKNet) producer.Flush();
                    }
                }
                finally { producer.Flush(); stopWatch.Stop(); if (!SharedObjects) producer.Dispose(); }
                startEvent.WaitOne();
                totalExecution.Stop();
                if (ShowResults)
                {
                    Console.WriteLine($"KNET: Create {swCreateRecord.ElapsedMicroSeconds()} ({swCreateRecord.ElapsedMicroSeconds() / numpacket}) Send {swSendRecord.ElapsedMicroSeconds()} ({swSendRecord.ElapsedMicroSeconds() / numpacket}) -> {swCreateRecord.ElapsedMicroSeconds() + swSendRecord.ElapsedMicroSeconds()} -> BackTime {stopWatch.ElapsedMicroSeconds() - (swCreateRecord.ElapsedMicroSeconds() + swSendRecord.ElapsedMicroSeconds())}");
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
