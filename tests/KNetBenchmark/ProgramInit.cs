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

namespace MASES.KNet.Benchmark
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
        public const string BurstLength = "BurstLength";
        public const string BurstInterval = "BurstInterval";
        public const string WithBurst = "WithBurst";
    }

    public class BenchmarkKNetCore : KNetCore<BenchmarkKNetCore>
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
                    new ArgumentMetadata<int>()
                    {
                        Name = CLIParam.BurstLength,
                        Default = 100,
                        Help = "The packet to send within each interval.",
                    },
                    new ArgumentMetadata<int>()
                    {
                        Name = CLIParam.BurstInterval,
                        Default = 100,
                        Help = "The interval time to wait between each burst.",
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
                    new ArgumentMetadata<object>()
                    {
                        Name = CLIParam.WithBurst,
                        Type = ArgumentType.Single,
                        Help = "Use to activate burst produce.",
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
        static int BurstLength;
        static int BurstInterval;
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
        static bool WithBurst;

        static void Init(string[] args)
        {
            BenchmarkKNetCore.ApplicationHeapSize = "4G";
            BenchmarkKNetCore.CreateGlobalInstance();

            ShowLogs = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Exist(CLIParam.ShowLogs);
            ShowResults = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Exist(CLIParam.ShowResults);
            ResultsPath = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Get<string>(CLIParam.ResultsPath);
            Server = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Get<string>(CLIParam.Server);
            TopicPrefix = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Get<string>(CLIParam.TopicPrefix);
            PartitionsPerTopic = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Get<int>(CLIParam.PartitionsPerTopic);
            MaxPacketLength = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Get<int>(CLIParam.MaxPacketLength);
            MinPacketLength = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Get<int>(CLIParam.MinPacketLength);
            PacketLengthMultiplier = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Get<int>(CLIParam.PacketLengthMultiplier);
            PacketToExchange = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Get<int>(CLIParam.PacketToExchange);
            BurstLength = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Get<int>(CLIParam.BurstLength);
            BurstInterval = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Get<int>(CLIParam.BurstInterval);
            UseSerdes = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Exist(CLIParam.UseSerdes);
            UseCallback = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Exist(CLIParam.UseCallback);
            ProducePreLoad = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Exist(CLIParam.ProducePreLoad);
            SinglePacket = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Exist(CLIParam.SinglePacket);
            CheckOnConsume = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Exist(CLIParam.CheckOnConsume);
            LeaveTopics = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Exist(CLIParam.LeaveTopics);
            AlwaysCommit = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Exist(CLIParam.AlwaysCommit);
            ContinuousFlushKNet = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Exist(CLIParam.ContinuousFlushKNet);
            ContinuousFlushConfluent = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Exist(CLIParam.ContinuousFlushConfluent);
            SharedObjects = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Exist(CLIParam.SharedObjects);
            WithBurst = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Exist(CLIParam.WithBurst);
        }
    }
}
