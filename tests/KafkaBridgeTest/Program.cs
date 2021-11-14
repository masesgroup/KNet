/*
 *  MIT License
 *
 *  Copyright (c) 2021 MASES s.r.l.
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

using MASES.JCOBridge.C2JBridge;
using MASES.KafkaBridge;
using MASES.KafkaBridge.Clients.Admin;
using MASES.KafkaBridge.Clients.Consumer;
using MASES.KafkaBridge.Clients.Producer;
using MASES.KafkaBridge.Common.Config;
using MASES.KafkaBridge.Java.Util;
using System;
using System.Threading;

namespace MASES.KafkaBridgeTest
{
    class Program
    {
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

                var adminClientConfig = AdminClientConfig.DynClazz;
                Properties props = new Properties();
                props.Put(adminClientConfig.BOOTSTRAP_SERVERS_CONFIG, serverToUse);

                using (var admin = KafkaAdminClient.Create(props))
                {
                    // Create a compacted topic
                    CreateTopicsResult result = admin.CreateTopics(coll);

                    // Call values() to get the result for a specific topic
                    var future = result.Dyn().values().get(topicName);

                    // Call get() to block until the topic creation is complete or has failed
                    // if creation failed the ExecutionException wraps the underlying cause.
                    future.get();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void produceSomething()
        {
            Properties props = Properties.New();
            props.Put("bootstrap.servers", serverToUse);
            props.Put("acks", "all");
            props.Put("retries", 0);
            props.Put("linger.ms", 1);
            props.Put("key.serializer", "org.apache.kafka.common.serialization.StringSerializer");
            props.Put("value.serializer", "org.apache.kafka.common.serialization.StringSerializer");

            using (KafkaProducer producer = new KafkaProducer(props))
            {
                int i = 0;
                while (!resetEvent.WaitOne(0))
                {
                    var record = new ProducerRecord<string, string>(topicToUse, i.ToString(), i.ToString());
                    var result = producer.Send(record);
                    Console.WriteLine($"Producing: {record}");
                    producer.Flush();
                    i++;
                }
            }
        }

        static void consumeSomething()
        {
            Properties props = Properties.New();
            props.Put("bootstrap.servers", serverToUse);
            props.Put("group.id", "test");
            props.Put("enable.auto.commit", "true");
            props.Put("auto.commit.interval.ms", "1000");
            props.Put("key.deserializer", "org.apache.kafka.common.serialization.StringDeserializer");
            props.Put("value.deserializer", "org.apache.kafka.common.serialization.StringDeserializer");
            KafkaConsumer consumer = new KafkaConsumer(props);
            consumer.Subscribe(Collections.singleton(topicToUse));
            while (!resetEvent.WaitOne(0))
            {
                ConsumerRecords records = consumer.Poll((long)TimeSpan.FromMilliseconds(200).TotalMilliseconds);
                foreach (var item in records)
                {
                    Console.WriteLine($"Offset = {item.Offset}, Key = {item.Key}, Value = {item.Value}");
                }
            }
        }
    }
}
