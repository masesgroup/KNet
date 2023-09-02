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
using MASES.KNet.Admin;
using MASES.KNet.Common;
using MASES.KNet.Consumer;
using MASES.KNet.Extensions;
using MASES.KNet.Producer;
using MASES.KNet.Replicator;
using MASES.KNet.Serialization;
using MASES.KNet.Serialization.Json;
using MASES.KNet.TestCommon;
using Org.Apache.Kafka.Clients.Admin;
using Org.Apache.Kafka.Clients.Consumer;
using Org.Apache.Kafka.Clients.Producer;
using System;
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

            Test("TestOnConsume", 100, UpdateModeTypes.OnConsume | UpdateModeTypes.Delayed);

            Test("TestOnDelivery", 100, UpdateModeTypes.OnDelivery | UpdateModeTypes.Delayed);

            Console.CancelKeyPress += Console_CancelKeyPress;
            Console.WriteLine("Press Ctrl-C to exit");
            resetEvent.WaitOne();
            Thread.Sleep(2000); // wait the threads exit
        }

        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            if (e.Cancel) resetEvent.Set();
        }

        private static void Test(string topicName, int length, UpdateModeTypes type)
        {
            using (var replicator = new KNetCompactedReplicator<int, TestType>()
            {
                Partitions = 5,
                UpdateMode = type,
                BootstrapServers = serverToUse,
                StateName = topicName,
                ValueSerDes = new JsonSerDes<TestType>(),
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
    }
}
