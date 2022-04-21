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
using System;
using System.Collections.Generic;
using MASES.CLIParser;
using MASES.KNet.Common.Errors;
using MASES.JCOBridge.C2JBridge;
using System.Text;
using System.IO;

namespace MASES.KNetBenchmark
{
    class CLIParam
    {
        // CommonArgs
        public const string ShowLogs = "ShowLogs";
public const string ShowResults = "ShowResults";
        public const string ResultsPath = "ResultsPath";
        public const string Server = "Server";
        public const string TopicPrefix = "TopicPrefix";
        public const string PartitionsPerTopic = "PartitionsPerTopic";
        public const string MaxPacketLength = "MaxPacketLength";
        public const string MinPacketLength = "MinPacketLength";
        public const string PacketLengthMultiplier = "PacketLengthMultiplier";
        public const string PacketToExchange = "PacketToExchange";
        public const string UseSerdes = "UseSerdes";
        public const string UseCallback = "UseCallback";
        public const string SinglePacket = "SinglePacket";
        public const string ProducePreLoad = "ProducePreLoad";
        public const string SimpleCount = "SimpleCount";
        public const string CheckOnConsume = "CheckOnConsume";
        public const string LeaveTopics = "LeaveTopics";
        public const string AlwaysCommit = "AlwaysCommit";
        public const string ContinuousFlushKNet = "ContinuousFlushKNet";
        public const string ContinuousFlushConfluent = "ContinuousFlushConfluent";
        public const string SharedObjects = "SharedObjects";
    }

    public class MyKNetCore : KNetCore<MyKNetCore>
    {
        public override IEnumerable<IArgumentMetadata> CommandLineArguments
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
                    new ArgumentMetadata<object>()
                    {
                        Name = CLIParam.ShowResults,
                        Type = ArgumentType.Single,
                        Help = "Show final result logs.",
                    },
                    new ArgumentMetadata<string>()
                    {
                        Name = CLIParam.ResultsPath,
                        Default = string.Empty,
                        Help = "The results path to be used.",
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
                        Default = "testTopic",
                        Help = "The topic prefix to be used.",
                    },
                    new ArgumentMetadata<int>()
                    {
                        Name = CLIParam.PartitionsPerTopic,
                        Default = 1,
                        Help = "The number of partitions to use.",
                    },
                    new ArgumentMetadata<int>()
                    {
                        Name = CLIParam.MaxPacketLength,
                        Default = 1000*1000,
                        Help = "The max packet length to use.",
                    },
                    new ArgumentMetadata<int>()
                    {
                        Name = CLIParam.MinPacketLength,
                        Default = 10,
                        Help = "The min packet length to use.",
                    },
                    new ArgumentMetadata<int>()
                    {
                        Name = CLIParam.PacketLengthMultiplier,
                        Default = 10,
                        Help = "The packet length mulitplier to use.",
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
                        Name = CLIParam.SinglePacket,
                        Type = ArgumentType.Single,
                        Help = "Use to send always the same packet.",
                    },
                    new ArgumentMetadata<object>()
                    {
                        Name = CLIParam.ProducePreLoad,
                        Type = ArgumentType.Single,
                        Help = "Use to send always the same packet.",
                    },
                    new ArgumentMetadata<object>()
                    {
                        Name = CLIParam.CheckOnConsume,
                        Type = ArgumentType.Single,
                        Help = "Use to check data before count it.",
                    },
                    new ArgumentMetadata<object>()
                    {
                        Name = CLIParam.LeaveTopics,
                        Type = ArgumentType.Single,
                        Help = "Use to do not remove topics.",
                    },
                    new ArgumentMetadata<object>()
                    {
                        Name = CLIParam.AlwaysCommit,
                        Type = ArgumentType.Single,
                        Help = "Use to commit on every cycle.",
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
                    new ArgumentMetadata<object>()
                    {
                        Name = CLIParam.SharedObjects,
                        Type = ArgumentType.Single,
                        Help = "Use to have shared producer/consumer across tests.",
                    },
                });
                return lst;
            }
        }
    }

    partial class Program
    {
        static bool ShowLogs;
        static bool ShowResults;
        static string ResultsPath;
        static string Server;
        static string TopicPrefix;
        static int PartitionsPerTopic;
        static int MaxPacketLength;
        static int MinPacketLength;
        static int PacketLengthMultiplier;
        static int PacketToExchange;
        static bool UseSerdes;
        static bool UseCallback;
        static bool ProducePreLoad;
        static bool SinglePacket;
        static bool CheckOnConsume;
        static bool LeaveTopics;
        static bool AlwaysCommit;
        static bool ContinuousFlushKNet;
        static bool ContinuousFlushConfluent;
 static bool SharedObjects;

        static void Main(string[] args)
        {
            try
            {
                MyKNetCore.ApplicationHeapSize = "4G";
                MyKNetCore.CreateGlobalInstance();

                ShowLogs = MyKNetCore.GlobalInstance.ParsedArgs.Exist(CLIParam.ShowLogs);
                ShowResults = MyKNetCore.GlobalInstance.ParsedArgs.Exist(CLIParam.ShowResults);
                ResultsPath = MyKNetCore.GlobalInstance.ParsedArgs.Get<string>(CLIParam.ResultsPath);
                Server = MyKNetCore.GlobalInstance.ParsedArgs.Get<string>(CLIParam.Server);
                TopicPrefix = MyKNetCore.GlobalInstance.ParsedArgs.Get<string>(CLIParam.TopicPrefix);
                PartitionsPerTopic = MyKNetCore.GlobalInstance.ParsedArgs.Get<int>(CLIParam.PartitionsPerTopic);
                MaxPacketLength = MyKNetCore.GlobalInstance.ParsedArgs.Get<int>(CLIParam.MaxPacketLength);
                MinPacketLength = MyKNetCore.GlobalInstance.ParsedArgs.Get<int>(CLIParam.MinPacketLength);
                PacketLengthMultiplier = MyKNetCore.GlobalInstance.ParsedArgs.Get<int>(CLIParam.PacketLengthMultiplier);
                PacketToExchange = MyKNetCore.GlobalInstance.ParsedArgs.Get<int>(CLIParam.PacketToExchange);
                UseSerdes = MyKNetCore.GlobalInstance.ParsedArgs.Exist(CLIParam.UseSerdes);
                UseCallback = MyKNetCore.GlobalInstance.ParsedArgs.Exist(CLIParam.UseCallback);
                ProducePreLoad = MyKNetCore.GlobalInstance.ParsedArgs.Exist(CLIParam.ProducePreLoad);
                SinglePacket = MyKNetCore.GlobalInstance.ParsedArgs.Exist(CLIParam.SinglePacket);
                CheckOnConsume = MyKNetCore.GlobalInstance.ParsedArgs.Exist(CLIParam.CheckOnConsume);
                LeaveTopics = MyKNetCore.GlobalInstance.ParsedArgs.Exist(CLIParam.LeaveTopics);
                AlwaysCommit = MyKNetCore.GlobalInstance.ParsedArgs.Exist(CLIParam.AlwaysCommit);
                ContinuousFlushKNet = MyKNetCore.GlobalInstance.ParsedArgs.Exist(CLIParam.ContinuousFlushKNet);
                ContinuousFlushConfluent = MyKNetCore.GlobalInstance.ParsedArgs.Exist(CLIParam.ContinuousFlushConfluent);
                SharedObjects = MyKNetCore.GlobalInstance.ParsedArgs.Exist(CLIParam.SharedObjects);

                ProduceConfluent(0, 0); // init lib?

                StringBuilder sb = new();
                sb.AppendLine("Length;NumPackets;KNETProd;KNETCons;ConfluentProd;ConfluentCons");

                for (int length = MinPacketLength; length <= MaxPacketLength; length *= PacketLengthMultiplier)
                {
                    var rand = new Random();
                    byte[] data = new byte[length];
                    for (int i = 0; i < length; i++)
                    {
                        data[i] = (byte)rand.Next(0, byte.MaxValue);
                    }

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

                        if (ShowLogs) Console.WriteLine($"Producing on topic {TopicName("KNET", length)}");
                        var KNETProdSW = ProduceKNet(length, PacketToExchange, CheckOnConsume ? data : null);

                        if (ShowLogs) Console.WriteLine($"Consuming from topic {TopicName("KNET", length)}");
                        var KNETConsSW = ConsumeKNet(length, PacketToExchange, CheckOnConsume ? data : null);

                        try
                        {
                            CreateTopic("CONFLUENT", length);
                        }
                        catch (TopicExistsException)
                        {
                            DeleteTopic("CONFLUENT", length);
                        }

                        if (ShowLogs) Console.WriteLine($"Producing on topic {TopicName("CONFLUENT", length)}");
                        var ConfluentProdSW = ProduceConfluent(length, PacketToExchange, CheckOnConsume ? data : null);

                        if (ShowLogs) Console.WriteLine($"Consuming from topic {TopicName("CONFLUENT", length)}");
                        var ConfluentConsSW = ConsumeConfluent(length, PacketToExchange, CheckOnConsume ? data : null);

                        sb.AppendLine($"{length};{PacketToExchange};{KNETProdSW.ElapsedMicroSeconds()};{KNETConsSW.ElapsedMicroSeconds()};{ConfluentProdSW.ElapsedMicroSeconds()};{ConfluentConsSW.ElapsedMicroSeconds()}");

                        if (ShowResults)
                        {
                            Console.WriteLine($"Length {length} Produce Diff {KNETProdSW.ElapsedMicroSeconds() - ConfluentProdSW.ElapsedMicroSeconds()} Consume Diff {KNETConsSW.ElapsedMicroSeconds() - ConfluentConsSW.ElapsedMicroSeconds()}");
                            
                            Console.WriteLine($"Produce KNET: Total {KNETProdSW.ElapsedMicroSeconds()} us Mean {KNETProdSW.MeanMicroSeconds(PacketToExchange)} us {KNETProdSW.PacketsPerSeconds(PacketToExchange)} packets/s {KNETProdSW.MbPerSecond(PacketToExchange, length)} Mb/s");
                            Console.WriteLine($"Consume KNET: Total {KNETConsSW.ElapsedMicroSeconds()} us Mean {KNETConsSW.MeanMicroSeconds(PacketToExchange)} us {KNETConsSW.PacketsPerSeconds(PacketToExchange)} packets/s {KNETConsSW.MbPerSecond(PacketToExchange, length)} Mb/s");

                            Console.WriteLine($"Produce Confluent: Total {ConfluentProdSW.ElapsedMicroSeconds()} us Mean {ConfluentProdSW.MeanMicroSeconds(PacketToExchange)} us {ConfluentProdSW.PacketsPerSeconds(PacketToExchange)} packets/s {ConfluentProdSW.MbPerSecond(PacketToExchange, length)} Mb/s");
                            Console.WriteLine($"Consume Confluent: Total {ConfluentConsSW.ElapsedMicroSeconds()} us Mean {ConfluentConsSW.MeanMicroSeconds(PacketToExchange)} us {ConfluentConsSW.PacketsPerSeconds(PacketToExchange)} packets/s {ConfluentConsSW.MbPerSecond(PacketToExchange, length)} Mb/s");
                        }
                    }
                    finally
                    {
                        if (!LeaveTopics)
                        {
                            DeleteTopic("KNET", length);
                            DeleteTopic("CONFLUENT", length);
                        }
                    }
                }
                File.WriteAllText(Path.Combine(ResultsPath, $"results_{DateTime.Now:yyyyMMdd_HHmmss}.csv"), sb.ToString());
            }
            catch (JVMBridgeException e)
            {
                Console.WriteLine(e.Message);
                Exception innerException = e.InnerException;
                while (innerException != null)
                {
                    Console.WriteLine(innerException.Message);
                    innerException = innerException.InnerException;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Exception innerException = e.InnerException;
                while (innerException != null)
                {
                    Console.WriteLine(innerException.Message);
                    innerException = innerException.InnerException;
                }
            }
        }
    }
}
