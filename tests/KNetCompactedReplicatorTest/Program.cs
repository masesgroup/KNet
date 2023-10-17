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

using MASES.KNet.Replicator;
using MASES.KNet.Serialization.Json;
using MASES.KNet.TestCommon;
using System;
using System.Diagnostics;
using System.Threading;

namespace MASES.KNetTest
{
    class Program
    {
        static bool useCallback = true;

        const string theServer = "localhost:9092";
        const string theTopic = "myTopic";

        static string serverToUse = theServer;
        static string topicToUse = theTopic;
        static readonly ManualResetEvent resetEvent = new(false);

        public class TestType
        {
            public TestType(int i)
            {
                name = description = value = i.ToString();
            }

            public string name;
            public string description;
            public string value;

            public override string ToString()
            {
                return $"name {name} - description {description} - value {value}";
            }
        }

        static void Main(string[] args)
        {
            SharedKNetCore.CreateGlobalInstance();
            var appArgs = SharedKNetCore.FilteredArgs;

            if (appArgs.Length != 0)
            {
                serverToUse = args[0];
            }
            var sw = Stopwatch.StartNew();
            TestValues("TestValues", 100, UpdateModeTypes.OnDelivery, 5);
            sw.Stop();
            Console.WriteLine($"End TestValues in {sw.Elapsed}");
            sw = Stopwatch.StartNew();
            Test("TestOnDelivery", 100, UpdateModeTypes.OnDelivery | UpdateModeTypes.Delayed, 5);
            sw.Stop();
            Console.WriteLine($"End TestOnDelivery in {sw.Elapsed}");
            sw = Stopwatch.StartNew();
            Test("TestOnConsume", 100, UpdateModeTypes.OnConsume | UpdateModeTypes.Delayed, 5);
            sw.Stop();
            Console.WriteLine($"End TestOnConsume in {sw.Elapsed}");
            sw = Stopwatch.StartNew();
            TestOnlyRead("TestOnConsume", 100, UpdateModeTypes.OnConsume | UpdateModeTypes.Delayed, 5);
            sw.Stop();
            Console.WriteLine($"End TestOnlyRead for TestOnConsume in {sw.Elapsed}");
            sw = Stopwatch.StartNew();
            Test("TestOnConsumeLessConsumers", 100, UpdateModeTypes.OnConsume | UpdateModeTypes.Delayed, 5, 2);
            sw.Stop();
            Console.WriteLine($"End TestOnConsume in {sw.Elapsed}");
            Console.CancelKeyPress += Console_CancelKeyPress;
            Console.WriteLine("Press Ctrl-C to exit");
            resetEvent.WaitOne();
            Thread.Sleep(2000); // wait the threads exit
        }

        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            if (e.Cancel) resetEvent.Set();
        }

        private static void TestValues(string topicName, int length, UpdateModeTypes type, int partitions, int? consumers = null)
        {
            using (var replicator = new KNetCompactedReplicator<int, TestType>()
            {
                Partitions = partitions,
                ConsumerInstances = consumers,
                UpdateMode = type,
                BootstrapServers = serverToUse,
                StateName = topicName,
                ValueSerDes = new JsonSerDes.Value<TestType>(),
            })
            {
                replicator.StartAndWait();

                for (int i = 0; i < length; i++)
                {
                    replicator[i] = new TestType(i);
                }

                replicator.SyncWait();

                foreach (var item in replicator.Values)
                {
                    Console.WriteLine($"Value: {item}");
                }
            }
        }

        private static void Test(string topicName, int length, UpdateModeTypes type, int partitions, int? consumers = null)
        {
            using (var replicator = new KNetCompactedReplicator<int, TestType>()
            {
                Partitions = partitions,
                ConsumerInstances = consumers,
                UpdateMode = type,
                BootstrapServers = serverToUse,
                StateName = topicName,
                ValueSerDes = new JsonSerDes.Value<TestType>(),
            })
            {
                replicator.StartAndWait();

                for (int i = 0; i < length; i++)
                {
                    replicator[i] = new TestType(i);
                }

                replicator.SyncWait();

                foreach (var item in replicator)
                {
                    Console.WriteLine($"Key: {item.Key} - Value: {item.Value}");
                }
            }
        }

        private static void TestOnlyRead(string topicName, int length, UpdateModeTypes type, int partitions, int? consumers = null)
        {
            using (var replicator = new KNetCompactedReplicator<int, TestType>()
            {
                Partitions = partitions,
                ConsumerInstances = consumers,
                UpdateMode = type,
                BootstrapServers = serverToUse,
                StateName = topicName,
                ValueSerDes = new JsonSerDes.Value<TestType>(),
            })
            {
                replicator.StartAndWait();

                foreach (var item in replicator)
                {
                    Console.WriteLine($"Key: {item.Key} - Value: {item.Value}");
                }
            }
        }
    }
}
