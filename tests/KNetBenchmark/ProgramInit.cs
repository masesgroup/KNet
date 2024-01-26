/*
*  Copyright 2024 MASES s.r.l.
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

using MASES.CLIParser;
using System;
using System.Collections.Generic;

namespace MASES.KNet.Benchmark
{
    class CLIParam
    {
        // CommonArgs
        public const string ShowLogs = "ShowLogs";
        public const string ShowIntermediateResults = "ShowIntermediateResults";
        public const string ShowFinalResults = "ShowFinalResults";
        public const string ResultsPath = "ResultsPath";
        public const string Server = "Server";
        public const string TopicPrefix = "TopicPrefix";
        public const string PartitionsPerTopic = "PartitionsPerTopic";
        public const string Repeat = "Repeat";
        public const string MaxPacketLength = "MaxPacketLength";
        public const string MinPacketLength = "MinPacketLength";
        public const string FixedPacketLength = "FixedPacketLength";
        public const string PacketLengthMultiplier = "PacketLengthMultiplier";
        public const string MinPacketsToExchange = "MinPacketsToExchange";
        public const string MaxPacketsToExchange = "MaxPacketsToExchange";
        public const string FixedPacketsToExchange = "FixedPacketsToExchange";
        public const string PacketsToExchangeMultiplier = "PacketsToExchangeMultiplier";
        public const string UseKNetProducer = "UseKNetProducer";
        public const string UseKNetConsumer = "UseKNetConsumer";
        public const string UseSerdes = "UseSerdes";
        public const string UseCallback = "UseCallback";
        public const string UsePrefetch = "UsePrefetch";
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
        public const string ProduceOnly = "ProduceOnly";
        public const string NoFlushTime = "NoFlushTime";
        // setup
        public const string NoAcks = "NoAcks";
        public const string MaxRetries = "MaxRetries";
        public const string LingerMs = "LingerMs";
        public const string BatchSize = "BatchSize";
        public const string MaxInFlight = "MaxInFlight";
        public const string SendBuffer = "SendBuffer";
        public const string ReceiveBuffer = "ReceiveBuffer";
        public const string FetchMinBytes = "FetchMinBytes";
    }

    public class BenchmarkKNetCore : KNetCore<BenchmarkKNetCore>
    {
        long baseJNICalls = 0;
        long baseExceptionJNICalls = 0;
        public void ShowStats(int numpackets)
        {
            long deltaTotal = JVMStats.TotalJNICalls - baseJNICalls;
            Console.WriteLine($"JNI Calls Total {JVMStats.TotalJNICalls} Delta {deltaTotal} Delta/packet {(double)deltaTotal / numpackets}");
            long deltaEx = JVMStats.ExceptionJNICalls - baseExceptionJNICalls;
            Console.WriteLine($"JNI Exception Calls Total {JVMStats.ExceptionJNICalls} Delta {deltaEx} Delta/packet {(double)deltaEx / numpackets}");
            Console.WriteLine($"Global Ref {JVMStats.GlobalRefCount} Local Ref {JVMStats.LocalRefCount} ");
            baseJNICalls = JVMStats.TotalJNICalls;
            baseExceptionJNICalls = JVMStats.ExceptionJNICalls;
        }

        public long CurrentJNICalls => JVMStats.TotalJNICalls;

#if DEBUG
        public override bool EnableDebug => true;
#endif

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
                        Name = CLIParam.ShowIntermediateResults,
                        Type = ArgumentType.Single,
                        Help = "Show intermediate result logs.",
                    },
                    new ArgumentMetadata<object>()
                    {
                        Name = CLIParam.ShowFinalResults,
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
                        Name = CLIParam.Repeat,
                        Default = 1,
                        Help = "The max number of test repeat.",
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
                        Name = CLIParam.FixedPacketLength,
                        Default = 0,
                        Help = "The fixed packet length to use, overrides MaxPacketLength and MinPacketLength.",
                    },
                    new ArgumentMetadata<int>()
                    {
                        Name = CLIParam.PacketLengthMultiplier,
                        Default = 10,
                        Help = "The packet length mulitplier to use.",
                    },
                    new ArgumentMetadata<int>()
                    {
                        Name = CLIParam.MinPacketsToExchange,
                        Default = 1000,
                        Help = "The minimum packets number to exchange (produce/consume).",
                    },
                    new ArgumentMetadata<int>()
                    {
                        Name = CLIParam.MaxPacketsToExchange,
                        Default = 1000,
                        Help = "The maximum packets number to exchange (produce/consume).",
                    },
                    new ArgumentMetadata<int>()
                    {
                        Name = CLIParam.FixedPacketsToExchange,
                        Default = 0,
                        Help = "The fixed packet packets number to exchange, overrides MinPacketsToExchange and MaxPacketsToExchange.",
                    },
                    new ArgumentMetadata<int>()
                    {
                        Name = CLIParam.PacketsToExchangeMultiplier,
                        Default = 10,
                        Help = "The packets to exchange mulitplier to use.",
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
                        Name = CLIParam.UseKNetProducer,
                        Type = ArgumentType.Single,
                        Help = "Use specific KNet producer.",
                    },
                    new ArgumentMetadata<object>()
                    {
                        Name = CLIParam.UseKNetConsumer,
                        Type = ArgumentType.Single,
                        Help = "Use specific KNet consumer.",
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
                    new ArgumentMetadata<object>()
                    {
                        Name = CLIParam.NoFlushTime,
                        Type = ArgumentType.Single,
                        Help = "Do not consider the time spent in flush when evaluate results.",
                    },
                    new ArgumentMetadata<object>()
                    {
                        Name = CLIParam.ProduceOnly,
                        Type = ArgumentType.Single,
                        Help = "Use to only produce.",
                    },
                    new ArgumentMetadata<object>()
                    {
                        Name = CLIParam.NoAcks,
                        Type = ArgumentType.Single,
                        Help = "Disable acks.",
                    },
                    new ArgumentMetadata<int>()
                    {
                        Name = CLIParam.MaxRetries,
                        Default = 0,
                    },
                    new ArgumentMetadata<int>()
                    {
                        Name = CLIParam.LingerMs,
                        Default = 100,
                    },
                    new ArgumentMetadata<int>()
                    {
                        Name = CLIParam.BatchSize,
                        Default = 1000000,
                    },
                    new ArgumentMetadata<int>()
                    {
                        Name = CLIParam.MaxInFlight,
                        Default = 1000000,
                    },
                    new ArgumentMetadata<int>()
                    {
                        Name = CLIParam.SendBuffer,
                        Default = 32 * 1024 * 1024,
                    },
                    new ArgumentMetadata<int>()
                    {
                        Name = CLIParam.ReceiveBuffer,
                        Default = 32 * 1024 * 1024,
                    },
                    new ArgumentMetadata<int>()
                    {
                        Name = CLIParam.FetchMinBytes,
                        Default = 100000,
                    },
                });
                return lst;
            }
        }
    }

    partial class Program
    {
        static bool ShowLogs;
        static bool ShowIntermediateResults;
        static bool ShowFinalResults;
        static string ResultsPath;
        static string Server;
        static string TopicPrefix;
        static int PartitionsPerTopic;
        static int Repeat;
        static int MaxPacketLength;
        static int MinPacketLength;
        static int FixedPacketLength;
        static int PacketLengthMultiplier;
        static int MinPacketsToExchange;
        static int MaxPacketsToExchange;
        static int FixedPacketsToExchange;
        static int PacketsToExchangeMultiplier;
        static int BurstLength;
        static int BurstInterval;
        static bool UseKNetProducer;
        static bool UseKNetConsumer;
        static bool UseSerdes;
        static bool UseCallback;
        static bool UsePrefetch;
        static bool ProducePreLoad;
        static bool SinglePacket;
        static bool CheckOnConsume;
        static bool LeaveTopics;
        static bool AlwaysCommit;
        static bool ContinuousFlushKNet;
        static bool ContinuousFlushConfluent;
        static bool SharedObjects;
        static bool WithBurst;
        static bool NoFlushTime;
        static bool ProduceOnly;
        static bool Acks;
        static int MessageSendMaxRetries;
        static int LingerMs;
        static int BatchSize;
        static int MaxInFlight;
        static int SocketSendBufferBytes;
        static int SocketReceiveBufferBytes;
        static int FetchMinBytes;

        static void Init(string[] args)
        {
            BenchmarkKNetCore.ApplicationHeapSize = "4G";
            BenchmarkKNetCore.ApplicationInitialHeapSize = "4G";
            BenchmarkKNetCore.CreateGlobalInstance();

            Console.WriteLine($"Unknown params: {string.Join(", ", BenchmarkKNetCore.FilteredArgs)}");

            ShowLogs = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Exist(CLIParam.ShowLogs);
            ShowIntermediateResults = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Exist(CLIParam.ShowIntermediateResults);
            ShowFinalResults = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Exist(CLIParam.ShowFinalResults);
            ResultsPath = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Get<string>(CLIParam.ResultsPath);
            Server = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Get<string>(CLIParam.Server);
            TopicPrefix = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Get<string>(CLIParam.TopicPrefix);
            PartitionsPerTopic = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Get<int>(CLIParam.PartitionsPerTopic);
            Repeat = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Get<int>(CLIParam.Repeat);
            MaxPacketLength = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Get<int>(CLIParam.MaxPacketLength);
            MinPacketLength = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Get<int>(CLIParam.MinPacketLength);
            FixedPacketLength = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Get<int>(CLIParam.FixedPacketLength);
            if (FixedPacketLength != 0)
            {
                MinPacketLength = MaxPacketLength = FixedPacketLength;
            }
            PacketLengthMultiplier = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Get<int>(CLIParam.PacketLengthMultiplier);
            MinPacketsToExchange = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Get<int>(CLIParam.MinPacketsToExchange);
            MaxPacketsToExchange = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Get<int>(CLIParam.MaxPacketsToExchange);
            FixedPacketsToExchange = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Get<int>(CLIParam.FixedPacketsToExchange);
            if (FixedPacketsToExchange != 0)
            {
                MinPacketsToExchange = MaxPacketsToExchange = FixedPacketsToExchange;
            }
            PacketsToExchangeMultiplier = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Get<int>(CLIParam.PacketsToExchangeMultiplier);
            BurstLength = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Get<int>(CLIParam.BurstLength);
            BurstInterval = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Get<int>(CLIParam.BurstInterval);
            UseKNetProducer = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Exist(CLIParam.UseKNetProducer);
            UseKNetConsumer = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Exist(CLIParam.UseKNetConsumer);
            UseSerdes = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Exist(CLIParam.UseSerdes);
            UseCallback = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Exist(CLIParam.UseCallback);
            UsePrefetch = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Exist(CLIParam.UsePrefetch);
            ProducePreLoad = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Exist(CLIParam.ProducePreLoad);
            SinglePacket = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Exist(CLIParam.SinglePacket);
            CheckOnConsume = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Exist(CLIParam.CheckOnConsume);
            LeaveTopics = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Exist(CLIParam.LeaveTopics);
            AlwaysCommit = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Exist(CLIParam.AlwaysCommit);
            ContinuousFlushKNet = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Exist(CLIParam.ContinuousFlushKNet);
            ContinuousFlushConfluent = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Exist(CLIParam.ContinuousFlushConfluent);
            SharedObjects = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Exist(CLIParam.SharedObjects);
            WithBurst = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Exist(CLIParam.WithBurst);
            NoFlushTime = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Exist(CLIParam.NoFlushTime);
            ProduceOnly = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Exist(CLIParam.ProduceOnly);
            Acks = !BenchmarkKNetCore.GlobalInstance.ParsedArgs.Exist(CLIParam.NoAcks);
            MessageSendMaxRetries = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Get<int>(CLIParam.MaxRetries);
            LingerMs = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Get<int>(CLIParam.LingerMs);
            BatchSize = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Get<int>(CLIParam.BatchSize);
            MaxInFlight = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Get<int>(CLIParam.MaxInFlight);
            SocketSendBufferBytes = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Get<int>(CLIParam.SendBuffer);
            SocketReceiveBufferBytes = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Get<int>(CLIParam.ReceiveBuffer);
            FetchMinBytes = BenchmarkKNetCore.GlobalInstance.ParsedArgs.Get<int>(CLIParam.FetchMinBytes);
        }
    }
}
