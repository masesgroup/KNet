/*
*  Copyright (c) 2021-2025 MASES s.r.l.
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

using MASES.JCOBridge.C2JBridge;
using Org.Apache.Kafka.Common.Errors;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace MASES.KNet.Benchmark
{
    partial class Program
    {
        static void Main(string[] args)
        {
            StringBuilder singleTestResultsSb = new();
            try
            {
                Init(args);

                ProduceConfluent("", 0, 0); // init lib?
                List<long> kNetProduceTimes = new();
                List<long> confluentProduceTimes = new();
                List<long> kNetConsumeTimes = new();
                List<long> confluentConsumeTimes = new();

                singleTestResultsSb.AppendLine("NumPackets;Length;KNETProd;KNETCons;ConfluentProd;ConfluentCons");

                for (int packets = MinPacketsToExchange; packets <= MaxPacketsToExchange; packets *= PacketsToExchangeMultiplier)
                {
                    for (int length = MinPacketLength; length <= MaxPacketLength; length *= PacketLengthMultiplier)
                    {
                        for (int testNum = 0; testNum < Repeat; testNum++)
                        {
                            var rand = new Random();
                            byte[] data = new byte[length];
                            for (int i = 0; i < length; i++)
                            {
                                data[i] = (byte)rand.Next(0, byte.MaxValue);
                            }

                            if (ShowIntermediateResults)
                            {
                                Console.WriteLine($"Test {testNum}: Length {length} Packets {packets}");
                            }

                            var topicNameKNet = TopicName("KNET", packets, length, testNum);
                            var topicNameConfluent = TopicName("CONF", packets, length, testNum);
                            try
                            {
                                try
                                {
                                    CreateTopic(topicNameKNet);
                                }
                                catch (TopicExistsException)
                                {
                                    DeleteTopic(topicNameKNet);
                                    System.Threading.Thread.Sleep(1000); // wait kafka server
                                    CreateTopic(topicNameKNet);
                                }

                                if (ShowLogs) Console.WriteLine($"Producing on topic {topicNameKNet}");
                                var KNETProdSW = UseKNetProducer ? ProduceKNet(topicNameKNet, length, packets, CheckOnConsume ? data : null) : ProduceKafka(topicNameKNet, length, packets, CheckOnConsume ? data : null);
                                Stopwatch KNETConsSW = new();
                                if (!ProduceOnly)
                                {
                                    if (ShowLogs) Console.WriteLine($"Consuming from topic {topicNameKNet}");
                                    KNETConsSW = UseKNetConsumer ? ConsumeKNet(testNum, topicNameKNet, length, packets, CheckOnConsume ? data : null) : ConsumeKafka(testNum, topicNameKNet, length, packets, CheckOnConsume ? data : null);
                                }

                                try
                                {
                                    CreateTopic(topicNameConfluent);
                                }
                                catch (TopicExistsException)
                                {
                                    DeleteTopic(topicNameConfluent);
                                    System.Threading.Thread.Sleep(1000); // wait kafka server
                                    CreateTopic(topicNameConfluent);
                                }

                                if (ShowLogs) Console.WriteLine($"Producing on topic {topicNameConfluent}");
                                var ConfluentProdSW = ProduceConfluent(topicNameConfluent, length, packets, CheckOnConsume ? data : null);
                                Stopwatch ConfluentConsSW = new();
                                if (!ProduceOnly)
                                {
                                    if (ShowLogs) Console.WriteLine($"Consuming from topic {topicNameConfluent}");
                                    ConfluentConsSW = ConsumeConfluent(testNum, topicNameConfluent, length, packets, CheckOnConsume ? data : null);
                                }

                                kNetProduceTimes.Add(KNETProdSW.ElapsedMicroSeconds());
                                confluentProduceTimes.Add(ConfluentProdSW.ElapsedMicroSeconds());
                                kNetConsumeTimes.Add(KNETConsSW.ElapsedMicroSeconds());
                                confluentConsumeTimes.Add(ConfluentConsSW.ElapsedMicroSeconds());

                                singleTestResultsSb.AppendLine($"{packets};{length};{KNETProdSW.ElapsedMicroSeconds()};{KNETConsSW?.ElapsedMicroSeconds()};{ConfluentProdSW.ElapsedMicroSeconds()};{ConfluentConsSW?.ElapsedMicroSeconds()}");

                                if (ShowIntermediateResults)
                                {
                                    if (ProduceOnly)
                                    {
                                        Console.WriteLine($"Produce Diff {KNETProdSW.ElapsedMicroSeconds() - ConfluentProdSW.ElapsedMicroSeconds()}");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Produce Diff {KNETProdSW.ElapsedMicroSeconds() - ConfluentProdSW.ElapsedMicroSeconds()} us - Consume Diff {KNETConsSW.ElapsedMicroSeconds() - ConfluentConsSW.ElapsedMicroSeconds()}");
                                    }

                                    Console.WriteLine($"Produce KNET: Total {KNETProdSW.ElapsedMicroSeconds()} us -  Mean {KNETProdSW.MeanMicroSeconds(packets)} us - {KNETProdSW.PacketsPerSeconds(packets)} packets/s - {KNETProdSW.MbPerSecond(packets, length)} Mb/s");
                                    if (!ProduceOnly) Console.WriteLine($"Consume KNET: Total {KNETConsSW.ElapsedMicroSeconds()} us - Mean {KNETConsSW.MeanMicroSeconds(packets)} us - {KNETConsSW.PacketsPerSeconds(packets)} packets/s - {KNETConsSW.MbPerSecond(packets, length)} Mb/s");

                                    Console.WriteLine($"Produce Confluent: Total {ConfluentProdSW.ElapsedMicroSeconds()} us - Mean {ConfluentProdSW.MeanMicroSeconds(packets)} us - {ConfluentProdSW.PacketsPerSeconds(packets)} packets/s - {ConfluentProdSW.MbPerSecond(packets, length)} Mb/s");
                                    if (!ProduceOnly) Console.WriteLine($"Consume Confluent: Total {ConfluentConsSW.ElapsedMicroSeconds()} us - Mean {ConfluentConsSW.MeanMicroSeconds(packets)} us - {ConfluentConsSW.PacketsPerSeconds(packets)} packets/s - {ConfluentConsSW.MbPerSecond(packets, length)} Mb/s");
                                }
                            }
                            finally
                            {
                                if (!LeaveTopics)
                                {
                                    DeleteTopic(topicNameKNet);
                                    DeleteTopic(topicNameConfluent);
                                }
                                if (ShowIntermediateResults) BenchmarkKNetCore.GlobalInstance.ShowStats(packets);

                                GC.Collect();
                                Java.Lang.System.Gc();
                            }
                        }
                    }

                    if (ShowFinalResults)
                    {
                        Console.WriteLine($"FINAL REPORT Exchanged {packets} packets with size from {MinPacketLength} to {MaxPacketLength} repeated {Repeat} times");

                        if (ProduceOnly)
                        {
                            Console.WriteLine("Produce");
                            Console.WriteLine($"KNet       microseconds -> Max {kNetProduceTimes.Max():####.##} - Min {kNetProduceTimes.Min():####.##} - Avg {kNetProduceTimes.Average():####.##} - SD {kNetProduceTimes.StandardDeviation():####.##} - CV {100 * kNetProduceTimes.StandardDeviation() / kNetProduceTimes.Average():####.##} %");
                            Console.WriteLine($"KNet       microseconds -> Avg Filtered {kNetProduceTimes.FilterMinMax().Average():####.##} - SD Filtered {kNetProduceTimes.FilterMinMax().StandardDeviation():####.##} - CV Filtered {100 * kNetProduceTimes.FilterMinMax().StandardDeviation() / kNetProduceTimes.FilterMinMax().Average():####.##} %");
                            Console.WriteLine($"Confluent  microseconds -> Max {confluentProduceTimes.Max():####.##} - Min {confluentProduceTimes.Min():####.##} - Avg {confluentProduceTimes.Average():####.##} SD {confluentProduceTimes.StandardDeviation():####.##} - CV {100 * confluentProduceTimes.StandardDeviation() / confluentProduceTimes.Average():####.##} %");
                            Console.WriteLine($"Confluent  microseconds -> Avg Filtered {confluentProduceTimes.FilterMinMax().Average():####.##} - SD Filtered {confluentProduceTimes.FilterMinMax().StandardDeviation():####.##} - CV Filtered {100 * confluentProduceTimes.FilterMinMax().StandardDeviation() / confluentProduceTimes.FilterMinMax().Average():####.##} %");
                            Console.WriteLine($"KNet/Confluent ratio(%) -> Max {100 * (double)kNetProduceTimes.Max() / confluentProduceTimes.Max():####.##} - Min {100 * (double)kNetProduceTimes.Min() / confluentProduceTimes.Min():####.##} - Avg {100 * (double)kNetProduceTimes.Average() / confluentProduceTimes.Average():####.##} - SD {100 * (double)kNetProduceTimes.StandardDeviation() / confluentProduceTimes.StandardDeviation():####.##} - CV {100 * kNetProduceTimes.CoefficientOfVariation() / confluentProduceTimes.CoefficientOfVariation():####.##}");
                            Console.WriteLine($"KNet/Confluent ratio(%) -> Avg Filtered {100 * (double)kNetProduceTimes.FilterMinMax().Average() / confluentProduceTimes.FilterMinMax().Average():####.##} - SD Filtered {100 * (double)kNetProduceTimes.FilterMinMax().StandardDeviation() / confluentProduceTimes.FilterMinMax().StandardDeviation():####.##} - CV Filtered {100 * kNetProduceTimes.FilterMinMax().CoefficientOfVariation() / confluentProduceTimes.FilterMinMax().CoefficientOfVariation():####.##}");
                        }
                        else
                        {
                            Console.WriteLine("Produce");
                            Console.WriteLine($"KNet       microseconds -> Max {kNetProduceTimes.Max():####.##} - Min {kNetProduceTimes.Min():####.##} - Avg {kNetProduceTimes.Average():####.##} - SD {kNetProduceTimes.StandardDeviation():####.##} - CV {100 * kNetProduceTimes.StandardDeviation() / kNetProduceTimes.Average():####.##} %");
                            Console.WriteLine($"KNet       microseconds -> Avg Filtered {kNetProduceTimes.FilterMinMax().Average():####.##} - SD Filtered {kNetProduceTimes.FilterMinMax().StandardDeviation():####.##} - CV Filtered {100 * kNetProduceTimes.FilterMinMax().StandardDeviation() / kNetProduceTimes.FilterMinMax().Average():####.##} %");
                            Console.WriteLine($"Confluent  microseconds -> Max {confluentProduceTimes.Max():####.##} - Min {confluentProduceTimes.Min():####.##} - Avg {confluentProduceTimes.Average():####.##} - SD {confluentProduceTimes.StandardDeviation():####.##} - CV {100 * confluentProduceTimes.StandardDeviation() / confluentProduceTimes.Average():####.##} %");
                            Console.WriteLine($"Confluent  microseconds -> Avg Filtered {confluentProduceTimes.FilterMinMax().Average():####.##} - SD Filtered {confluentProduceTimes.FilterMinMax().StandardDeviation():####.##} - CV Filtered {100 * confluentProduceTimes.FilterMinMax().StandardDeviation() / confluentProduceTimes.FilterMinMax().Average():####.##} %");
                            Console.WriteLine($"KNet/Confluent ratio(%) -> Max {100 * (double)kNetProduceTimes.Max() / confluentProduceTimes.Max():####.##} - Min {100 * (double)kNetProduceTimes.Min() / confluentProduceTimes.Min():####.##} - Avg {100 * (double)kNetProduceTimes.Average() / confluentProduceTimes.Average():####.##} - SD {100 * (double)kNetProduceTimes.StandardDeviation() / confluentProduceTimes.StandardDeviation():####.##} - CV {100 * kNetProduceTimes.CoefficientOfVariation() / confluentProduceTimes.CoefficientOfVariation():####.##}");
                            Console.WriteLine($"KNet/Confluent ratio(%) -> Avg Filtered {100 * (double)kNetProduceTimes.FilterMinMax().Average() / confluentProduceTimes.FilterMinMax().Average():####.##} - SD Filtered {100 * (double)kNetProduceTimes.FilterMinMax().StandardDeviation() / confluentProduceTimes.FilterMinMax().StandardDeviation():####.##} - CV Filtered {100 * kNetProduceTimes.FilterMinMax().CoefficientOfVariation() / confluentProduceTimes.FilterMinMax().CoefficientOfVariation():####.##}");
                            Console.WriteLine("Consume");
                            Console.WriteLine($"KNet       microseconds -> Max {kNetConsumeTimes.Max():####.##} - Min {kNetConsumeTimes.Min():####.##} Avg {kNetConsumeTimes.Average():####.##} - SD {kNetConsumeTimes.StandardDeviation():####.##} - CV {100 * kNetConsumeTimes.CoefficientOfVariation():####.##} %");
                            Console.WriteLine($"KNet       microseconds -> Avg Filtered {kNetConsumeTimes.FilterMinMax().Average():####.##} - SD Filtered {kNetConsumeTimes.FilterMinMax().StandardDeviation():####.##} - CV Filtered {100 * kNetConsumeTimes.FilterMinMax().CoefficientOfVariation():####.##} %");
                            Console.WriteLine($"Confluent  microseconds -> Max {confluentConsumeTimes.Max():####.##} - Min {confluentConsumeTimes.Min():####.##} - Avg {confluentConsumeTimes.Average():####.##} - SD {confluentConsumeTimes.StandardDeviation():####.##} - CV {100 * confluentConsumeTimes.CoefficientOfVariation():####.##} %");
                            Console.WriteLine($"Confluent  microseconds -> Avg Filtered {confluentConsumeTimes.FilterMinMax().Average():####.##} - SD Filtered {confluentConsumeTimes.FilterMinMax().StandardDeviation():####.##} - CV Filtered {100 * confluentConsumeTimes.FilterMinMax().CoefficientOfVariation():####.##} %");
                            Console.WriteLine($"KNet/Confluent ratio(%) -> Max {100 * (double)kNetConsumeTimes.Max() / confluentConsumeTimes.Max():########.##} - Min {100 * (double)kNetConsumeTimes.Min() / confluentConsumeTimes.Min():####.##} - Avg {100 * (double)kNetConsumeTimes.Average() / confluentConsumeTimes.Average():####.##} - SD {100 * (double)kNetConsumeTimes.StandardDeviation() / confluentConsumeTimes.StandardDeviation():####.##} - CV {100 * kNetConsumeTimes.CoefficientOfVariation() / confluentConsumeTimes.CoefficientOfVariation():####.##}");
                            Console.WriteLine($"KNet/Confluent ratio(%) -> Avg Filtered {100 * (double)kNetConsumeTimes.FilterMinMax().Average() / confluentConsumeTimes.FilterMinMax().Average():####.##} - SD Filtered {100 * (double)kNetConsumeTimes.FilterMinMax().StandardDeviation() / confluentConsumeTimes.FilterMinMax().StandardDeviation():####.##} - CV Filtered {100 * kNetConsumeTimes.FilterMinMax().CoefficientOfVariation() / confluentConsumeTimes.FilterMinMax().CoefficientOfVariation():####.##}");
                        }
                    }
                }
            }
            catch (Java.Lang.NullPointerException e)
            {
                Console.WriteLine($"{e.GetType().Name}: {e.StackTrace}");
                Exception innerException = e.InnerException;
                while (innerException != null)
                {
                    Console.WriteLine(innerException.Message);
                    innerException = innerException.InnerException;
                }
            }
            catch (JVMBridgeException e)
            {
                Console.WriteLine($"{e.GetType().Name}: {e.Message}");
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
            finally
            {
                File.WriteAllText(Path.Combine(ResultsPath, $"results_{DateTime.Now:yyyyMMdd_HHmmss}.csv"), singleTestResultsSb.ToString());
            }
        }
    }
}
