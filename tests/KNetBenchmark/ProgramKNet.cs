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

using MASES.KNet.Clients.Consumer;
using MASES.KNet.Clients.Producer;
using MASES.KNet.Common.Serialization;
using Java.Util;
using System;
using System.Text;
using System.Diagnostics;

namespace MASES.KNetBenchmark
{
    partial class Program
    {
        static long ProduceKNet(int length, int numpacket)
        {
            try
            {
                Properties props = ProducerConfigBuilder.Create()
                                                        .WithBootstrapServers(MyKNetCore.Server)
                                                        .WithAcks(ProducerConfig.Acks.None)
                                                        .WithRetries(0)
                                                        .WithLingerMs(1)
                                                        .WithKeySerializerClass("org.apache.kafka.common.serialization.IntegerSerializer")
                                                        .WithValueSerializerClass("org.apache.kafka.common.serialization.ByteArraySerializer")
                                                        .ToProperties();

                Serializer<int> keySerializer = null;
                Serializer<byte[]> valueSerializer = null;
                if (MyKNetCore.UseSerdes)
                {
                    keySerializer = new Serializer<int>(serializeWithHeadersFun: (topic, headers, data) =>
                    {
                        var key = BitConverter.GetBytes(data);
                        return key;
                    });
                    valueSerializer = new Serializer<byte[]>(serializeWithHeadersFun: (topic, headers, data) =>
                    {
                        // var value = Encoding.Unicode.GetBytes(data);
                        return data;
                    });
                }
                try
                {
                    using (var producer = MyKNetCore.UseSerdes ? new KafkaProducer<int, byte[]>(props, keySerializer, valueSerializer) : new KafkaProducer<int, byte[]>(props))
                    {
                        Callback callback = null;
                        if (MyKNetCore.UseCallback)
                        {
                            callback = new Callback((o1, o2) =>
                            {
                                if (o2 != null) Console.WriteLine(o2.ToString());
                                else Console.WriteLine($"Produced on topic {o1.Topic} at offset {o1.Offset}");
                            });
                        }
                        var stopWatch = Stopwatch.StartNew();
                        try
                        {
                            var rand = new Random();
                            byte[] data = new byte[length];
                            for (int i = 0; i < length; i++)
                            {
                                data[i] = (byte)rand.Next(0, byte.MaxValue);
                            }
                            for (int i = 0; i < numpacket; i++)
                            {
                                var record = new ProducerRecord<int, byte[]>(TopicName("KNET", length), i, data);
                                var result = MyKNetCore.UseCallback ? producer.Send(record, callback) : producer.Send(record);
                                if (MyKNetCore.ContinuousFlushKNet) producer.Flush();
                            }
                        }
                        finally { producer.Flush(); stopWatch.Stop(); if (MyKNetCore.UseCallback) callback.Dispose(); }
                        return (long)((double)stopWatch.ElapsedTicks / (Stopwatch.Frequency / 1000000));
                    }
                }
                finally
                {
                    if (MyKNetCore.UseSerdes)
                    {
                        keySerializer.Dispose();
                        valueSerializer.Dispose();
                    }
                }
            }
            catch (Java.Util.Concurrent.ExecutionException ex)
            {
                throw ex.InnerException;
            }
        }

        static long ConsumeKNet(int length, int numpacket)
        {
            try
            {
                Properties props = ConsumerConfigBuilder.Create()
                                                        .WithBootstrapServers(MyKNetCore.Server)
                                                        .WithGroupId("test")
                                                        .WithEnableAutoCommit(true)
                                                        .WithAutoCommitIntervalMs(1000)
                                                        .WithKeyDeserializerClass("org.apache.kafka.common.serialization.IntegerDeserializer")
                                                        .WithValueDeserializerClass("org.apache.kafka.common.serialization.ByteArrayDeserializer")
                                                        .WithAutoOffsetReset(ConsumerConfig.AutoOffsetReset.EARLIEST)
                                                        .ToProperties();

                Deserializer<int> keyDeserializer = null;
                Deserializer<byte[]> valueDeserializer = null;
                KafkaConsumer<int, byte[]> consumer = null;
                if (MyKNetCore.UseSerdes)
                {
                    keyDeserializer = new Deserializer<int>(deserializeFun: (topic, data) =>
                    {
                        var key = BitConverter.ToInt32(data, 0);
                        return key;
                    });
                    valueDeserializer = new Deserializer<byte[]>(deserializeFun: (topic, data) =>
                    {
                       // var value = Encoding.Unicode.GetString(data);
                        return data;
                    });
                }
                Stopwatch stopWatch = null;
                ConsumerRebalanceListener rebalanceListener = new(
                                    revoked: (o) =>
                                    {
                                        if (MyKNetCore.ShowLogs) Console.WriteLine("Revoked: {0}", o.ToString());
                                    },
                                    assigned: (o) =>
                                    {
                                        if (MyKNetCore.ShowLogs) Console.WriteLine("Assigned: {0}", o.ToString());
                                        stopWatch = Stopwatch.StartNew();
                                    });
                try
                {
                    int counter = 0;
                    using (consumer = MyKNetCore.UseSerdes ? new KafkaConsumer<int, byte[]>(props, keyDeserializer, valueDeserializer) : new KafkaConsumer<int, byte[]>(props))
                    {
                        consumer.Subscribe(Collections.Singleton(TopicName("KNET", length)), rebalanceListener);

                        while (true)
                        {
                            var records = consumer.Poll((long)TimeSpan.FromMilliseconds(200).TotalMilliseconds);
                            foreach (var item in records)
                            {
                                if (item.Value.Length != length) Console.WriteLine($"Incorrect length {item.Value.Length}");
                                counter++; 
                                if (counter >= numpacket)
                                {
                                    stopWatch.Stop();
                                    consumer.Unsubscribe();
                                    return (long)((double)stopWatch.ElapsedTicks / (Stopwatch.Frequency / 1000000));
                                }
                            }
                        }
                    }
                }
                finally
                {
                    keyDeserializer?.Dispose();
                    valueDeserializer?.Dispose();
                    rebalanceListener?.Dispose();
                }
            }
            catch (Java.Util.Concurrent.ExecutionException ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
