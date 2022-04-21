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

using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MASES.KNetBenchmark
{
    partial class Program
    {
        static ISerializer<int> confluentKeySerializer = null;
        static ISerializer<byte[]> confluentValueSerializer = null;
        static IProducer<int, byte[]> confluentProducer = null;

        static IProducer<int, byte[]> ConfluentProducer()
        {
            if (confluentProducer == null || !SharedObjects)
            {
                var producerConfig = new ProducerConfig
                {
                    BootstrapServers = Server,
                    Acks = Acks.Leader,
                    MessageSendMaxRetries = 0,
                    LingerMs = 5,
                    BatchSize = 1000000,
                    MaxInFlight = 1000000,
                    SocketSendBufferBytes = 32 * 1024 * 1024,
                    SocketReceiveBufferBytes = 32 * 1024 * 1024,
                    MessageMaxBytes = MaxPacketLength + 1000,
                    //MessageCopyMaxBytes = length,
                };

                var producerBuilder = new ProducerBuilder<int, byte[]>(producerConfig);

                if (UseSerdes)
                {
                    producerBuilder.SetKeySerializer(confluentKeySerializer);
                    producerBuilder.SetValueSerializer(confluentValueSerializer);
                }


                confluentProducer = producerBuilder.Build();
            }
            return confluentProducer;
        }


        static Stopwatch ProduceConfluent(int length, int numpacket, byte[] data = null)
        {
            Stopwatch swCreateRecord = null;
            Stopwatch swSendRecord = null;
            Stopwatch stopWatch = null;
            IProducer<int, byte[]> producer = ConfluentProducer();
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
                var message = new Message<int, byte[]>
                {
                    Key = 42,
                    Value = data
                };
                if (ProducePreLoad)
                {
                    swCreateRecord = new();
                    swSendRecord = new();
                    List<Message<int, byte[]>> messages = new();
                    for (int i = 0; i < numpacket; i++)
                    {
                        var rand = new Random();
                        data = new byte[length];
                        for (int ii = 0; ii < length; ii++)
                        {
                            data[ii] = (byte)rand.Next(0, byte.MaxValue);
                        }
                        swCreateRecord.Start();
                        message = new Message<int, byte[]>
                        {
                            Key = i,
                            Value = data
                        };
                        swCreateRecord.Stop();
                        messages.Add(message);
                    }
                    stopWatch = Stopwatch.StartNew();
                    foreach (var item in messages)
                    {
                        swSendRecord.Start();
                        producer.Produce(TopicName("CONFLUENT", length), message);
                        swSendRecord.Stop();
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
                            swCreateRecord.Start();
                            byte[] newData = new byte[data.Length];
                            Array.Copy(data, 0, newData, 0, data.Length);
                            message = new Message<int, byte[]>
                            {
                                Key = i,
                                Value = newData
                            };
                            swCreateRecord.Stop();
                        }
                        swSendRecord.Start();
                        producer.Produce(TopicName("CONFLUENT", length), message);
                        swSendRecord.Stop();
                        if (ContinuousFlushConfluent) producer.Flush();
                    }
                }
            }
            finally { producer.Flush(); stopWatch?.Stop(); if (!SharedObjects) producer.Dispose(); }

            if (numpacket != 0 && ShowResults && !ProducePreLoad)
            {
                Console.WriteLine($"Confluent: Create {swCreateRecord.ElapsedMicroSeconds()} Send {swSendRecord.ElapsedMicroSeconds()} -> {swCreateRecord.ElapsedMicroSeconds() + swSendRecord.ElapsedMicroSeconds()} -> BackTime {stopWatch.ElapsedMicroSeconds() - (swCreateRecord.ElapsedMicroSeconds() + swSendRecord.ElapsedMicroSeconds())}");
            }
            return stopWatch;
        }

        static IDeserializer<int> confluentKeyDeserializer = null;
        static IDeserializer<byte[]> confluentValueDeserializer = null;
        static IConsumer<int, byte[]> confluentConsumer = null;

        static IConsumer<int, byte[]> ConfluentConsumer()
        {
            if (confluentConsumer == null || !SharedObjects)
            {
                var consumerConfig = new ConsumerConfig
                {
                    BootstrapServers = Server,
                    GroupId = Guid.NewGuid().ToString(),
                    EnableAutoCommit = true,
                    AutoCommitIntervalMs = 1000,
                    AutoOffsetReset = AutoOffsetReset.Earliest,
                    //MessageCopyMaxBytes = length,
                    FetchMinBytes = 100000,
                };
                var consumerBuilder = new ConsumerBuilder<int, byte[]>(consumerConfig);
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

        static Action<IConsumer<int, byte[]>, List<TopicPartition>> PartitionsAssignedHandler_trampoline;

        static void PartitionsAssignedHandler(IConsumer<int, byte[]> consumer, List<TopicPartition> lst)
        {
            PartitionsAssignedHandler_trampoline?.Invoke(consumer, lst);
        }

        static Stopwatch ConsumeConfluent(int length, int numpacket, byte[] data = null)
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
                consumer.Subscribe(TopicName("CONFLUENT", length));
                while (true)
                {
                    var record = consumer.Consume(TimeSpan.FromMinutes(1));
                    if (record != null)
                    {
                        if (CheckOnConsume
                            && (!record.Message.Value.SequenceEqual(data)
                                || (!SinglePacket && record.Message.Key != counter)))
                        {
                            throw new InvalidOperationException("Incorrect data");
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
                if (!SharedObjects) consumer.Dispose();
            }
        }
    }
}
