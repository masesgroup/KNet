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

using MASES.KNet;
using MASES.KNet.Clients.Admin;
using Java.Util;
using System;
using MASES.KNet.Extensions;
using System.Collections.Generic;
using MASES.CLIParser;
using System.Diagnostics;
using MASES.KNet.Common.Errors;

namespace MASES.KNetBenchmark
{
    class CLIParam
    {
        // CommonArgs
        public const string ShowLogs = "ShowLogs";
        public const string Server = "Server";
        public const string TopicPrefix = "TopicPrefix";
        public const string TopicPartitions = "TopicPartitions";
        public const string PacketMaxLength = "PacketMaxLength";
        public const string PacketToExchange = "PacketToExchange";
        public const string UseSerdes = "UseSerdes";
        public const string UseCallback = "UseCallback";
        public const string ContinuousFlushKNet = "ContinuousFlushKNet";
        public const string ContinuousFlushConfluent = "ContinuousFlushConfluent";
    }

    public class MyKNetCore : KNetCore<MyKNetCore>
    {
        public static bool ShowLogs;
        public static string Server;
        public static string TopicPrefix;
        public static int TopicPartitions;
        public static int PacketMaxLength;
        public static int PacketToExchange;
        public static bool UseSerdes;
        public static bool UseCallback;
        public static bool ContinuousFlushKNet;
        public static bool ContinuousFlushConfluent;

        protected override IEnumerable<IArgumentMetadata> CommandLineArguments
        {
            get
            {
                var lst = new System.Collections.Generic.List<IArgumentMetadata>(base.CommandLineArguments);
                lst.AddRange(new IArgumentMetadata[]
                {
                    new ArgumentMetadata<object>()
                    {
                        Name = CLIParam.ShowLogs,
                        Type = ArgumentType.Single,
                        Help = "Show intermediate logs.",
                    },
                    new ArgumentMetadata<string>()
                    {
                        Name = CLIParam.Server,
                        Default = "localhost:9092",
                        Help = "The bootstrap server to be used.",
                    },
                    new ArgumentMetadata<string>()
                    {
                        Name = CLIParam.TopicPrefix,
                        Default = "myTopic",
                        Help = "The topic prefix to be used.",
                    },
                    new ArgumentMetadata<int>()
                    {
                        Name = CLIParam.TopicPartitions,
                        Default = 1,
                        Help = "The number of partitions to use.",
                    },
                    new ArgumentMetadata<int>()
                    {
                        Name = CLIParam.PacketMaxLength,
                        Default = 1000*1000,
                        Help = "The packet length to use.",
                    },
                    new ArgumentMetadata<int>()
                    {
                        Name = CLIParam.PacketToExchange,
                        Default = 1000,
                        Help = "The packet number to exchange (produce/consume).",
                    },
                    new ArgumentMetadata<object>()
                    {
                        Name = CLIParam.UseSerdes,
                        Type = ArgumentType.Single,
                        Help = "Use coded serdes.",
                    },
                    new ArgumentMetadata<object>()
                    {
                        Name = CLIParam.UseCallback,
                        Type = ArgumentType.Single,
                        Help = "Use coded callback.",
                    },
                    new ArgumentMetadata<object>()
                    {
                        Name = CLIParam.ContinuousFlushKNet,
                        Type = ArgumentType.Single,
                        Help = "Use to call Flush on every produce in KNet.",
                    },
                    new ArgumentMetadata<object>()
                    {
                        Name = CLIParam.ContinuousFlushConfluent,
                        Type = ArgumentType.Single,
                        Help = "Use to call Flush on every produce on Confluent.",
                    },
                });
                return lst;
            }
        }

        protected override string[] ProcessCommandLine()
        {
            var res = base.ProcessCommandLine();
            ShowLogs = ParsedArgs.Exist(CLIParam.ShowLogs);
            Server = ParsedArgs.Get<string>(CLIParam.Server);
            TopicPrefix = ParsedArgs.Get<string>(CLIParam.TopicPrefix);
            TopicPartitions = ParsedArgs.Get<int>(CLIParam.TopicPartitions);
            PacketMaxLength = ParsedArgs.Get<int>(CLIParam.PacketMaxLength);
            PacketToExchange = ParsedArgs.Get<int>(CLIParam.PacketToExchange);
            UseSerdes = ParsedArgs.Exist(CLIParam.UseSerdes);
            UseCallback = ParsedArgs.Exist(CLIParam.UseCallback);
            ContinuousFlushKNet = ParsedArgs.Exist(CLIParam.ContinuousFlushKNet);
            ContinuousFlushConfluent = ParsedArgs.Exist(CLIParam.ContinuousFlushConfluent);

            return res;
        }
    }

    partial class Program
    {
        static void Main(string[] args)
        {
            MyKNetCore.ApplicationHeapSize = "2G";
            MyKNetCore.CreateGlobalInstance();

            for (int length = 10; length <= MyKNetCore.PacketMaxLength; length *= 10)
            {
                try
                {
                    try
                    {
                        CreateTopic("KNET", length);
                    }
                    catch (TopicExistsException)
                    {
                        DeleteTopic("KNET", length);
                    }

                    if (MyKNetCore.ShowLogs) Console.WriteLine($"Producing on topic {TopicName("KNET", length)}");
                    long produceTime = ProduceKNet(length, MyKNetCore.PacketToExchange);

                    if (MyKNetCore.ShowLogs) Console.WriteLine($"Consuming from topic {TopicName("KNET", length)}");
                    long consumeTime = ConsumeKNet(length, MyKNetCore.PacketToExchange);

                    Console.WriteLine($"{TopicName("KNET", length)} Length {length} TotalProduceTime {produceTime} us MeanProduceTime {produceTime / MyKNetCore.PacketToExchange} us {(((double)(length * MyKNetCore.PacketToExchange / 2) / (1024 * 1024) / produceTime) * 1000000)} Mb/s");
                    Console.WriteLine($"{TopicName("KNET", length)} Length {length} TotalConsumeTime {consumeTime} us MeanConsumeTime {consumeTime / MyKNetCore.PacketToExchange} us {(((double)(length * MyKNetCore.PacketToExchange / 2) / (1024 * 1024) / consumeTime) * 1000000)} Mb/s");
                }
                finally
                {
                    DeleteTopic("KNET", length);
                }

                try
                {
                    try
                    {
                        CreateTopic("CONFLUENT", length);
                    }
                    catch (TopicExistsException)
                    {
                        DeleteTopic("CONFLUENT", length);
                    }

                    if (MyKNetCore.ShowLogs) Console.WriteLine($"Producing on topic {TopicName("CONFLUENT", length)}");
                    long produceTime = ProduceConfluent(length, MyKNetCore.PacketToExchange);

                    if (MyKNetCore.ShowLogs) Console.WriteLine($"Consuming from topic {TopicName("CONFLUENT", length)}");
                    long consumeTime = ConsumeConfluent(length, MyKNetCore.PacketToExchange);

                    Console.WriteLine($"{TopicName("CONFLUENT", length)} Length {length} TotalProduceTime {produceTime} us MeanProduceTime {produceTime / MyKNetCore.PacketToExchange} us {(((double)(length * MyKNetCore.PacketToExchange / 2) / (1024 * 1024) / produceTime) * 1000000)} Mb/s");
                    Console.WriteLine($"{TopicName("CONFLUENT", length)} Length {length} TotalConsumeTime {consumeTime} us MeanConsumeTime {consumeTime / MyKNetCore.PacketToExchange} us {(((double)(length * MyKNetCore.PacketToExchange / 2) / (1024 * 1024) / consumeTime) * 1000000)} Mb/s");
                }
                finally
                {
                    DeleteTopic("CONFLUENT", length);
                }
            }
        }
    }
}
