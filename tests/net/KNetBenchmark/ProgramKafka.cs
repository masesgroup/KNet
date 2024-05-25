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
using MASES.JCOBridge.C2JBridge;
using MASES.JCOBridge.C2JBridge.JVMInterop;
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
        static Org.Apache.Kafka.Clients.Producer.IProducer<long, byte[]> kafkaProducer = null;
        static Serializer<long> kafkaKeySerializer = null;
        static Serializer<byte[]> kafkaValueSerializer = null;

        static Org.Apache.Kafka.Clients.Producer.IProducer<long, byte[]> KafkaProducer()
        {
            if (kafkaProducer == null || !SharedObjects)
            {
                Properties props = ProducerConfigBuilder.Create()
                                                        .WithBootstrapServers(Server)
                                                        .WithAcks(Acks ? ProducerConfigBuilder.AcksTypes.One : ProducerConfigBuilder.AcksTypes.None)
                                                        .WithRetries(MessageSendMaxRetries)
                                                        .WithLingerMs(LingerMs)
                                                        .WithBatchSize(BatchSize)
                                                        .WithMaxInFlightRequestPerConnection(MaxInFlight)
                                                        .WithEnableIdempotence(false)
                                                        .WithSendBuffer(SocketSendBufferBytes)
                                                        .WithReceiveBuffer(SocketReceiveBufferBytes)
                                                        .WithBufferMemory(128 * 1024 * 1024)
                                                        .WithKeySerializerClass(Java.Lang.Class.ClassNameOf<Org.Apache.Kafka.Common.Serialization.LongSerializer>())
                                                        .WithValueSerializerClass(Java.Lang.Class.ClassNameOf<Org.Apache.Kafka.Common.Serialization.ByteArraySerializer>())
                                                        .WithPartitionerIgnoreKeys(true)
                                                        .ToProperties();
                if (UseSerdes)
                {
                    kafkaKeySerializer = new Serializer<long>()
                    {
                        OnSerialize3 = (topic, headers, data) =>
                        {
                            var key = BitConverter.GetBytes(data);
                            return key;
                        }
                    };
                    kafkaValueSerializer = new Serializer<byte[]>()
                    {
                        OnSerialize3 = (topic, headers, data) =>
                        {
                            // var value = Encoding.Unicode.GetBytes(data);
                            return data;
                        }
                    };
                }

                kafkaProducer = UseSerdes ? new KafkaProducer<long, byte[]>(props, kafkaKeySerializer, kafkaValueSerializer) : new KafkaProducer<long, byte[]>(props);
            }
            return kafkaProducer;
        }

        static Callback kafkaCallback = null;

        static Stopwatch ProduceKafka(string topicName, int length, int numpacket, byte[] data = null)
        {
            try
            {
                Java.Lang.String jTopicName = topicName;
                var kafkaproducer = KafkaProducer();
                kafkaproducer.PartitionsFor(jTopicName); // used to get metadata before do the test

                if (UseCallback && kafkaCallback == null)
                {
                    kafkaCallback = new Callback()
                    {
                        OnOnCompletion = (o1, o2) =>
                        {
                            if (o2 != null) Console.WriteLine(o2.ToString());
                            else if (ShowLogs) Console.WriteLine($"Produced on topic {o1.Topic()} at offset {o1.Offset()}");
                        }
                    };
                }

                Stopwatch swCreateRecord = null;
                Stopwatch swSendRecord = null;
                Stopwatch stopWatch = null;
                Stopwatch flushTimeWatch = null;
                long testJNICalls = 0;
                TimeSpan testConsumedTime;
                long initialJNICalls = BenchmarkKNetCore.GlobalInstance.CurrentJNICalls;
                TimeSpan initialConsumedTime = BenchmarkKNetCore.GlobalInstance.CurrentTimeSpentInJNICalls;

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
                    var record = new Org.Apache.Kafka.Clients.Producer.ProducerRecord<long, byte[]>(jTopicName, 42, data);
                    if (ProducePreLoad)
                    {
                        swCreateRecord = new();
                        swSendRecord = new();
                        System.Collections.Generic.List<Org.Apache.Kafka.Clients.Producer.ProducerRecord<long, byte[]>> messages = new();
                        for (int i = 0; i < numpacket; i++)
                        {
                            var rand = new System.Random();
                            data = new byte[length];
                            for (int ii = 0; ii < length; ii++)
                            {
                                data[ii] = (byte)rand.Next(0, byte.MaxValue);
                            }
                            swCreateRecord.Start();
                            record = new Org.Apache.Kafka.Clients.Producer.ProducerRecord<long, byte[]>(jTopicName, i, data);
                            swCreateRecord.Stop();
                            messages.Add(record);
                        }
                        stopWatch = Stopwatch.StartNew();
                        for (int i = 0; i < numpacket; i++)
                        {
                            swSendRecord.Start();
                            var result = UseCallback ? kafkaproducer.Send(messages[i], kafkaCallback) : kafkaproducer.Send(messages[i]);
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
                            if (ContinuousFlushKNet) kafkaproducer.Flush();
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
                                var startTimeRecordJniCalls = BenchmarkKNetCore.GlobalInstance.CurrentTimeSpentInJNICalls;
                                var startKRecordJniCalls = BenchmarkKNetCore.GlobalInstance.CurrentJNICalls;
                                stopWatch.Start();
                                swCreateRecord.Start();
                                record = new Org.Apache.Kafka.Clients.Producer.ProducerRecord<long, byte[]>(jTopicName, i, newData);
                                swCreateRecord.Stop();
                                var deltaKRecordJniCalls = BenchmarkKNetCore.GlobalInstance.CurrentJNICalls - startKRecordJniCalls;
                                var deltaTimeJniCalls = BenchmarkKNetCore.GlobalInstance.CurrentTimeSpentInJNICalls - startTimeRecordJniCalls;
                                var singleJniTime = TimeSpan.FromTicks(deltaTimeJniCalls.Ticks / deltaKRecordJniCalls);
                            }
                            swSendRecord.Start();
                            if (UseCallback)
                                kafkaproducer.Send(record, kafkaCallback);
                            else
                                kafkaproducer.Send(record);
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
                            if (ContinuousFlushKNet) kafkaproducer.Flush();
                        }
                    }
                }
                finally
                {
                    if (NoFlushTime) stopWatch.Stop();
                    flushTimeWatch = Stopwatch.StartNew();
                    kafkaproducer.Flush();
                    flushTimeWatch.Stop();
                    stopWatch.Stop();
                    if (!SharedObjects) { kafkaproducer.Dispose(); kafkaproducer = null; }
                    testJNICalls = BenchmarkKNetCore.GlobalInstance.CurrentJNICalls - initialJNICalls;
                    testConsumedTime = BenchmarkKNetCore.GlobalInstance.CurrentTimeSpentInJNICalls - initialConsumedTime;
                }
                if (ShowIntermediateResults && !ProducePreLoad)
                {
                    Console.WriteLine($"KNET: Create {swCreateRecord.ElapsedMicroSeconds()} ({swCreateRecord.ElapsedMicroSeconds() / numpacket}) Send {swSendRecord.ElapsedMicroSeconds()} ({swSendRecord.ElapsedMicroSeconds() / numpacket}) Flush {flushTimeWatch.ElapsedMicroSeconds()} -> TotalTime {stopWatch.ElapsedMicroSeconds()} BackTime {stopWatch.ElapsedMicroSeconds() - (swCreateRecord.ElapsedMicroSeconds() + swSendRecord.ElapsedMicroSeconds())}");
                    Console.WriteLine($"KNET: Test JNICalls {testJNICalls} Mean JNICalls {testJNICalls / numpacket} Test JNI time: {testConsumedTime} Mean packet JNI Time {TimeSpan.FromTicks(testConsumedTime.Ticks / numpacket)}");
                }
                return stopWatch;
            }
            catch (Java.Util.Concurrent.ExecutionException ex)
            {
                throw ex.InnerException;
            }
        }

        static Deserializer<long> kafkaKeyDeserializer = null;
        static Deserializer<byte[]> kafkaValueDeserializer = null;
        static Org.Apache.Kafka.Clients.Consumer.IConsumer<long, byte[]> kafkaConsumer = null;

        static Org.Apache.Kafka.Clients.Consumer.IConsumer<long, byte[]> KafkaConsumer()
        {
            if (kafkaConsumer == null || !SharedObjects)
            {
                Properties props = ConsumerConfigBuilder.Create()
                                                        .WithBootstrapServers(Server)
                                                        .WithGroupId(Guid.NewGuid().ToString())
                                                        .WithEnableAutoCommit(!AlwaysCommit)
                                                        .WithAutoCommitIntervalMs(1000)
                                                        .WithSendBuffer(SocketSendBufferBytes)
                                                        .WithReceiveBuffer(SocketReceiveBufferBytes)
                                                        .WithFetchMinBytes(FetchMinBytes)
                                                        .WithKeyDeserializerClass(Java.Lang.Class.ClassNameOf<Org.Apache.Kafka.Common.Serialization.LongDeserializer>())
                                                        .WithValueDeserializerClass(Java.Lang.Class.ClassNameOf<Org.Apache.Kafka.Common.Serialization.ByteArrayDeserializer>())
                                                        .WithAutoOffsetReset(ConsumerConfigBuilder.AutoOffsetResetTypes.EARLIEST)
                                                        .ToProperties();
                if (UseSerdes)
                {
                    kafkaKeyDeserializer = new Deserializer<long>()
                    {
                        OnDeserialize = (topic, data) =>
                        {
                            var key = BitConverter.ToInt32(data, 0);
                            return key;
                        }
                    };
                    kafkaValueDeserializer = new Deserializer<byte[]>()
                    {
                        OnDeserialize = (topic, data) =>
                        {
                            // var value = Encoding.Unicode.GetString(data);
                            return data;
                        }
                    };
                }

                kafkaConsumer = UseSerdes ? new KafkaConsumer<long, byte[]>(props, kafkaKeyDeserializer, kafkaValueDeserializer) : new KafkaConsumer<long, byte[]>(props);
            }
            return kafkaConsumer;
        }

        static Stopwatch ConsumeKafka(int testNum, string topicName, int length, int numpacket, byte[] data = null)
        {
            try
            {
                Stopwatch stopWatch = null;
                ConsumerRebalanceListener rebalanceListener = new()
                {
                    OnOnPartitionsRevoked = (o) =>
                    {
                        if (ShowLogs) Console.WriteLine("Revoked: {0}", o.ToString());
                    },
                    OnOnPartitionsAssigned = (o) =>
                    {
                        if (ShowLogs) Console.WriteLine("Assigned: {0}", o.ToString());
                        stopWatch = Stopwatch.StartNew();
                    }
                };

                var consumer = KafkaConsumer();
                Java.Time.Duration duration = TimeSpan.FromMinutes(1);
                var topics = Collections.Singleton((Java.Lang.String)topicName);
                try
                {
                    int counter = 0;
                    consumer.Subscribe(topics, rebalanceListener);
                    while (true)
                    {
                        var records = consumer.Poll(duration);
                        if (!CheckOnConsume)
                        {
                            if (ReadAllData)
                            {
                                foreach (var item in records)
                                {
                                    item.Key(); item.Value();
                                    counter++;
                                }
                            }
                            else counter += records.Count();
                        }
                        else
                        {
                            if (UsePrefetch)
                            {
                                foreach (var item in records.WithPrefetch().WithThread().WithConvert((o) => { return (o.Value(), o.Key()); }))
                                {
                                    if (!item.Item1.SequenceEqual(data)
                                        || (!SinglePacket && item.Item2 != counter))
                                    {
                                        throw new InvalidOperationException($"ConsumeKafka test {testNum}: Incorrect data counter {counter} item.Key {item.Item2}");
                                    }
                                    counter++;
                                }
                            }
                            else
                            {
                                foreach (var item in records)
                                {
                                    if (!item.Value().SequenceEqual(data)
                                        || (!SinglePacket && item.Key() != counter))
                                    {
                                        throw new InvalidOperationException($"ConsumeKafka test {testNum}: Incorrect data counter {counter} item.Key {item.Key()}");
                                    }
                                    counter++;
                                }
                            }
                        }
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
                    if (!SharedObjects) { consumer.Dispose(); consumer = null; }
                    rebalanceListener?.Dispose();
                    duration?.Dispose();
                    topics?.Dispose();
                }
            }
            catch (Java.Util.Concurrent.ExecutionException ex)
            {
                throw ex.InnerException;
            }
        }

        static (Stopwatch, IEnumerable<double>) RoundTripKafka(int testNum, string topicName, int length, int numpacket, byte[] data = null)
        {
            try
            {
                System.Collections.Generic.List<double> roundTripTime = new System.Collections.Generic.List<double>();
                ManualResetEvent startEvent = new ManualResetEvent(false);
                var consumer = KafkaConsumer();
                var producer = KafkaProducer();

                System.Threading.Thread thread = new System.Threading.Thread(() =>
                {
                    Java.Time.Duration duration = TimeSpan.FromSeconds(1);
                    var topics = Collections.Singleton((Java.Lang.String)topicName);
                    ConsumerRebalanceListener rebalanceListener = null;
                    try
                    {
                        rebalanceListener = new()
                        {
                            OnOnPartitionsRevoked = (o) =>
                            {
                                if (ShowLogs) Console.WriteLine("Revoked: {0}", o.ToString());
                            },
                            OnOnPartitionsAssigned = (o) =>
                            {
                                if (ShowLogs) Console.WriteLine("Assigned: {0}", o.ToString());
                                startEvent.Set();
                            }
                        };

                        consumer.Subscribe(topics, rebalanceListener);
                        int counter = 0;
                        while (true)
                        {
                            var records = consumer.Poll(duration);
                            if (UsePrefetch)
                            {
                                foreach (var item in records.WithPrefetch().WithThread().WithConvert((o) => { return (o.Key(), o.Value()); }))
                                {
                                    roundTripTime.Add((double)(DateTime.Now.Ticks - item.Item1) / (TimeSpan.TicksPerMillisecond / 1000));

                                    if (CheckOnConsume && !item.Item2.SequenceEqual(data))
                                    {
                                        throw new InvalidOperationException($"ConsumeKafka test {testNum}: Incorrect data counter {counter} item.Key {item.Item1}");
                                    }
                                    counter++;
                                }
                            }
                            else
                            {
                                foreach (var item in records)
                                {
                                    var key = item.Key();
                                    roundTripTime.Add((double)(DateTime.Now.Ticks - key) / (TimeSpan.TicksPerMillisecond / 1000));
                                    byte[] value = Array.Empty<byte>();
                                    if (ReadAllData)
                                    {
                                        value = item.Value();
                                    }
                                    if (CheckOnConsume && !((ReadAllData ? value : item.Value()).SequenceEqual(data)))
                                    {
                                        throw new InvalidOperationException($"ConsumeKafka test {testNum}: Incorrect data counter {counter} item.Key {key}");
                                    }
                                    counter++;
                                }
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
                            consumer = null;
                        }
                        startEvent.Set();
                        duration?.Dispose();
                        topics?.Dispose();
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
                    var record = new Org.Apache.Kafka.Clients.Producer.ProducerRecord<long, byte[]>(topicName, 42, data);
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
                            record = new Org.Apache.Kafka.Clients.Producer.ProducerRecord<long, byte[]>(topicName, DateTime.Now.Ticks, newData);
                            swCreateRecord.Stop();
                        }
                        swSendRecord.Start();
                        if (UseCallback)
                            producer.Send(record, kafkaCallback);
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
                finally
                {
                    producer.Flush();
                    stopWatch.Stop();
                    if (!SharedObjects) { producer.Dispose(); producer = null; }
                }
                startEvent.WaitOne();
                totalExecution.Stop();
                if (ShowIntermediateResults)
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
