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
using System.Diagnostics;

namespace MASES.KNetBenchmark
{
    partial class Program
    {
        static long ProduceConfluent(int length, int numpacket)
        {
            ISerializer<int> keySerializer = null;
            ISerializer<byte[]> valueSerializer = null;

            var producerConfig = new ProducerConfig
            {
                BootstrapServers = MyKNetCore.Server,
                Acks = Acks.None,
                MessageSendMaxRetries = 0,
                LingerMs = 1,
            };

            var producerBuilder = new ProducerBuilder<int, byte[]>(producerConfig);
            if (MyKNetCore.UseSerdes)
            {
                producerBuilder.SetKeySerializer(keySerializer);
                producerBuilder.SetValueSerializer(valueSerializer);
            }

            try
            {
                using (var producer = producerBuilder.Build())
                {
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
                            var message = new Message<int, byte[]>
                            {
                                Key = i,
                                Value = data
                            };
                            producer.Produce(TopicName("CONFLUENT", length), message);
                            if (MyKNetCore.ContinuousFlushConfluent) producer.Flush();
                        }
                    }
                    finally { producer.Flush(); stopWatch.Stop(); }
                    return (long)((double)stopWatch.ElapsedTicks / (Stopwatch.Frequency / 1000000));
                }
            }
            finally
            {
            }
        }

        static long ConsumeConfluent(int length, int numpacket)
        {
            IDeserializer<int> keyDeserializer = null;
            IDeserializer<byte[]> valueDeserializer = null;
            IConsumer<int, byte[]> consumer = null;
            try
            {
                var consumerConfig = new ConsumerConfig
                {
                    BootstrapServers = MyKNetCore.Server,
                    GroupId = "test",
                    EnableAutoCommit = true,
                    AutoCommitIntervalMs = 1000,
                    AutoOffsetReset = AutoOffsetReset.Earliest,
                };
                Stopwatch stopWatch = null;
                int counter = 0;
                var consumerBuilder = new ConsumerBuilder<int, byte[]>(consumerConfig);
                if (MyKNetCore.UseSerdes)
                {
                    consumerBuilder.SetKeyDeserializer(keyDeserializer);
                    consumerBuilder.SetValueDeserializer(valueDeserializer);
                }
                consumerBuilder.SetPartitionsAssignedHandler((o1, o2) =>
                {
                    if (MyKNetCore.ShowLogs) Console.WriteLine("Assigned: {0}", o2.ToString());
                    stopWatch = Stopwatch.StartNew();
                });
                using (consumer = consumerBuilder.Build())
                {
                    consumer.Subscribe(TopicName("CONFLUENT", length));
                    while (true)
                    {
                        var record = consumer.Consume((int)TimeSpan.FromMilliseconds(200).TotalMilliseconds);
                        if (record != null)
                        {
                            if (record.Message.Value?.Length != length) Console.WriteLine($"Incorrect length {record.Message.Value?.Length}");
                            counter++; 
                            if (counter >= numpacket)
                            {
                                stopWatch?.Stop();
                                consumer.Unsubscribe();
                                return (long)((double)stopWatch.ElapsedTicks / (Stopwatch.Frequency / 1000000));
                            }
                        }
                    }
                }
            }
            finally
            {
            }
        }
    }
}
