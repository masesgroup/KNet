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
using MASES.KafkaBridge.Clients.Consumer;
using MASES.KafkaBridge.Clients.Producer;
using MASES.KafkaBridge.Common.Config;
using MASES.KafkaBridge.Common.Serialization;
using MASES.KafkaBridge.Java.Util;
using MASES.KafkaBridge.Streams;
using System;
using System.Text;
using System.Threading;

namespace MASES.KafkaBridgeTest
{
    class Program
    {
        const bool useSerdes = true;
        const bool useCallback = true;

        const string theServer = "localhost:9092";
        const string theTopic = "myTopic";

        static string serverToUse = theServer;
        static string topicToUse = theTopic;
        static ManualResetEvent resetEvent = new ManualResetEvent(false);

        static void Main(string[] args)
        {
            var appArgs = KafkaBridgeCore.ApplicationArgs;

            if (appArgs.Length != 0)
            {
                serverToUse = args[0];
            }

            createTopic();

            Thread threadProduce = new Thread(produceSomething)
            {
                Name = "produce"
            };
            threadProduce.Start();

            Thread threadConsume = new Thread(consumeSomething)
            {
                Name = "consume"
            };
            threadConsume.Start();

            Thread threadStream = new Thread(streamSomething)
            {
                Name = "stream"
            };
            threadStream.Start();

            Thread.Sleep(20000);
            resetEvent.Set();
            Thread.Sleep(2000);
        }

        static void createTopic()
        {
            try
            {
                string topicName = topicToUse;
                int partitions = 1;
                short replicationFactor = 1;
                var topicConfig = TopicConfig.DynClazz;

                var topic = new NewTopic(topicName, partitions, replicationFactor);
                var map = Collections.singletonMap((string)topicConfig.CLEANUP_POLICY_CONFIG, (string)topicConfig.CLEANUP_POLICY_COMPACT);
                topic.Configs(map);
                var coll = Collections.singleton(topic);

                Properties props = new Properties();
                props.Put(AdminClientConfig.BOOTSTRAP_SERVERS_CONFIG, serverToUse);

                using (var admin = KafkaAdminClient.Create(props))
                {
                    // Create a compacted topic
                    CreateTopicsResult result = admin.CreateTopics(coll);

                    // Call values() to get the result for a specific topic
                    var future = result.Values.Get(topicName);

                    // Call get() to block until the topic creation is complete or has failed
                    // if creation failed the ExecutionException wraps the underlying cause.
                    future.Get();
                }
            }
            catch (KafkaBridge.Java.Util.Concurrent.ExecutionException ex)
            {
                Console.WriteLine(ex.InnerException.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void produceSomething()
        {
            try
            {
                Properties props = new Properties();
                props.Put(ProducerConfig.BOOTSTRAP_SERVERS_CONFIG, serverToUse);
                props.Put(ProducerConfig.ACKS_CONFIG, "all");
                props.Put(ProducerConfig.RETRIES_CONFIG, 0);
                props.Put(ProducerConfig.LINGER_MS_CONFIG, 1);
                props.Put(ProducerConfig.KEY_SERIALIZER_CLASS_CONFIG, "org.apache.kafka.common.serialization.StringSerializer");
                props.Put(ProducerConfig.VALUE_SERIALIZER_CLASS_CONFIG, "org.apache.kafka.common.serialization.StringSerializer");

                Serializer<string> keySerializer = null;
                Serializer<string> valueSerializer = null;
                if (useSerdes)
                {
                    keySerializer = new Serializer<string>(serializeWithHeadersFun: (topic, headers, data) =>
                    {
                        var key = Encoding.Unicode.GetBytes(data);
                        return key;
                    });
                    valueSerializer = new Serializer<string>(serializeWithHeadersFun: (topic, headers, data) =>
                    {
                        var value = Encoding.Unicode.GetBytes(data);
                        return value;
                    });
                }
                try
                {
                    using (var producer = useSerdes ? new KafkaProducer<string, string>(props, keySerializer, valueSerializer) : new KafkaProducer<string, string>(props))
                    {
                        int i = 0;
                        Callback callback = null;
                        if (useCallback)
                        {
                            callback = new Callback((o1, o2) =>
                            {
                                if (o2 != null) Console.WriteLine(o2.ToString());
                                else Console.WriteLine($"Produced on topic {o1.Topic} at offset {o1.Offset}");
                            });
                        }
                        try
                        {
                            while (!resetEvent.WaitOne(0))
                            {
                                var record = new ProducerRecord<string, string>(topicToUse, i.ToString(), i.ToString());
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
                    if (useSerdes)
                    {
                        keySerializer.Dispose();
                        valueSerializer.Dispose();
                    }
                }
            }
            catch (KafkaBridge.Java.Util.Concurrent.ExecutionException ex)
            {
                Console.WriteLine("Producer ended with error: {0}", ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Producer ended with error: {0}", ex.Message);
            }
        }

        static void consumeSomething()
        {
            try
            {
                Properties props = new Properties();
                props.Put(ConsumerConfig.BOOTSTRAP_SERVERS_CONFIG, serverToUse);
                props.Put(ConsumerConfig.GROUP_ID_CONFIG, "test");
                props.Put(ConsumerConfig.ENABLE_AUTO_COMMIT_CONFIG, "true");
                props.Put(ConsumerConfig.AUTO_COMMIT_INTERVAL_MS_CONFIG, "1000");
                props.Put(ConsumerConfig.KEY_DESERIALIZER_CLASS_CONFIG, "org.apache.kafka.common.serialization.StringDeserializer");
                props.Put(ConsumerConfig.VALUE_DESERIALIZER_CLASS_CONFIG, "org.apache.kafka.common.serialization.StringDeserializer");

                Deserializer<string> keyDeserializer = null;
                Deserializer<string> valueDeserializer = null;
                ConsumerRebalanceListener rebalanceListener = null;
                if (useSerdes)
                {
                    keyDeserializer = new Deserializer<string>(deserializeFun: (topic, data) =>
                    {
                        var key = Encoding.Unicode.GetString(data);
                        Console.WriteLine("Received key {0} from topic {1}", key, topic);
                        return key;
                    });
                    valueDeserializer = new Deserializer<string>(deserializeFun: (topic, data) =>
                    {
                        var value = Encoding.Unicode.GetString(data);
                        Console.WriteLine("Received value {0} from topic {1}", value, topic);
                        return value;
                    });
                }
                if (useCallback)
                {
                    rebalanceListener = new ConsumerRebalanceListener(
                        revoked: (o) =>
                        {
                            Console.WriteLine("Revoked: {0}", o.ToString());
                        },
                        assigned: (o) =>
                        {
                            Console.WriteLine("Assigned: {0}", o.ToString());
                        });
                }
                try
                {
                    {
                        using (var consumer = useSerdes ? new KafkaConsumer<string, string>(props, keyDeserializer, valueDeserializer) : new KafkaConsumer<string, string>(props))
                        {
                            if (useCallback) consumer.Subscribe(Collections.singleton(topicToUse), rebalanceListener);
                            else consumer.Subscribe(Collections.singleton(topicToUse));

                            while (!resetEvent.WaitOne(0))
                            {
                                var records = consumer.Poll((long)TimeSpan.FromMilliseconds(200).TotalMilliseconds);
                                foreach (var item in records)
                                {
                                    Console.WriteLine($"Consuming from Offset = {item.Offset}, Key = {item.Key}, Value = {item.Value}");
                                }
                            }
                        }
                    }
                }
                finally
                {
                    if (useSerdes)
                    {
                        keyDeserializer.Dispose();
                        valueDeserializer.Dispose();
                    }
                }
            }
            catch (KafkaBridge.Java.Util.Concurrent.ExecutionException ex)
            {
                Console.WriteLine("Consumer ended with error: {0}", ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Consumer ended with error: {0}", ex.Message);
            }
        }

        static void streamSomething()
        {
            try
            {
                var props = new Properties();

                props.Put(StreamsConfig.APPLICATION_ID_CONFIG, "streams-pipe");
                props.Put(StreamsConfig.BOOTSTRAP_SERVERS_CONFIG, serverToUse);
                props.Put(StreamsConfig.DEFAULT_KEY_SERDE_CLASS_CONFIG, Serdes.String.getClass());
                props.Put(StreamsConfig.DEFAULT_VALUE_SERDE_CLASS_CONFIG, Serdes.String.getClass());

                // setting offset reset to earliest so that we can re-run the demo code with the same pre-loaded data
                props.Put(ConsumerConfig.AUTO_OFFSET_RESET_CONFIG, "earliest");

                var builder = new StreamsBuilder();

                builder.Stream<string, string>(topicToUse).To("streams-pipe-output");

                using (var streams = new KafkaStreams(builder.Build(), props))
                {
                    streams.Start();
                    while (!resetEvent.WaitOne(1000))
                    {
                        var state = streams.State;
                        Console.WriteLine($"KafkaStreams state: {state}");
                    }
                }
            }
            catch (KafkaBridge.Java.Util.Concurrent.ExecutionException ex)
            {
                Console.WriteLine("Streams ended with error: {0}", ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Streams ended with error: {0}", ex.Message);
            }
        }
    }
}
