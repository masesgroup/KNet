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

using MASES.JCOBridge.C2JBridge;
using Org.Apache.Kafka.Common.Errors;
using System;
using System.Collections.Generic;
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
                List<double> KNETData = new();
                List<double> ConfluentData = new();

                singleTestResultsSb.AppendLine("NumPackets;Length;KNETMax;KNETMin;KNETMean;ConfluentMax;ConfluentMin;ConfluentMean");

                for (int packets = MinPacketsToExchange; packets <= MaxPacketsToExchange; packets *= PacketsToExchangeMultiplier)
                {
                    for (int length = MinPacketLength; length <= MaxPacketLength; length *= PacketLengthMultiplier)
                    {
                        for (int testIndex = 0; testIndex < Repeat; testIndex++)
                        {
                            var rand = new Random();
                            byte[] data = new byte[length];
                            for (int i = 0; i < length; i++)
                            {
                                data[i] = (byte)rand.Next(0, byte.MaxValue);
                            }

                            var topicNameKNet = TopicName("KNET", packets, length, testIndex);
                            var topicNameConfluent = TopicName("CONF", packets, length, testIndex);
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

                                if (ShowLogs) Console.WriteLine($"Round Trip on topic {topicNameKNet}");
                                var tempKNETData = (UseKNetProducer && UseKNetConsumer) ? RoundTripKNet(testIndex, topicNameKNet, length, packets, CheckOnConsume ? data : null)
                                                                                        : RoundTripKafka(testIndex, topicNameKNet, length, packets, CheckOnConsume ? data : null);
                                if (ShowIntermediateResults)
                                {
                                    Console.WriteLine($"RoundTrip KNET {testIndex} in {tempKNETData.Item1.Elapsed}: Total {tempKNETData.Item2.Sum()} us Mean {tempKNETData.Item2.MeanMicroSeconds(packets)} us {tempKNETData.Item1.PacketsPerSeconds(packets)} packets/s {tempKNETData.Item1.MbPerSecond(packets, 2 * length)} Mb/s");
                                }

                                KNETData.AddRange(tempKNETData.Item2);
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

                                if (ShowLogs) Console.WriteLine($"Round Trip on topic {topicNameConfluent}");
                                var tempConfluentData = RoundTripConfluent(testIndex, topicNameConfluent, length, packets, CheckOnConsume ? data : null);
                                if (ShowIntermediateResults)
                                {
                                    Console.WriteLine($"RoundTrip Confluent {testIndex} in {tempConfluentData.Item1.Elapsed}: Total {tempConfluentData.Item2.Sum()} us Mean {tempConfluentData.Item2.MeanMicroSeconds(packets)} us {tempConfluentData.Item1.PacketsPerSeconds(packets)} packets/s {tempConfluentData.Item1.MbPerSecond(packets, 2 * length)} Mb/s");
                                }
                                ConfluentData.AddRange(tempConfluentData.Item2);

                                singleTestResultsSb.AppendLine($"{packets};{length};{KNETData.Max()};{KNETData.Min()};{KNETData.Average()};{ConfluentData.Max()};{ConfluentData.Min()};{ConfluentData.Average()};");

                                if (ShowIntermediateResults)
                                {
                                    Console.WriteLine($"RoundTrip KNET-Confluent {testIndex} in {tempKNETData.Item1.Elapsed + tempConfluentData.Item1.Elapsed}: Length {length} Max Diff {tempKNETData.Item2.Max() - tempConfluentData.Item2.Max()} Min Diff {tempKNETData.Item2.Min() - tempConfluentData.Item2.Min()} Mean Diff {tempKNETData.Item2.Average() - tempConfluentData.Item2.Average()}");
                                }
                            }
                            finally
                            {
                                if (!LeaveTopics)
                                {
                                    DeleteTopic(topicNameKNet);
                                    DeleteTopic(topicNameConfluent);
                                }

                                GC.Collect();
                                Java.Lang.System.Gc();
                            }
                        }
                    }
                    if (ShowFinalResults)
                    {
                        Console.WriteLine($"KNet       microseconds -> Max {KNETData.Max():####.##} - Min {KNETData.Min():####.##} - Avg {KNETData.Average():####.##} - SD {KNETData.StandardDeviation():####.##} - CV {100 * KNETData.StandardDeviation() / KNETData.Average():####.##} %");
                        Console.WriteLine($"KNet       microseconds -> Avg Filtered {KNETData.FilterMinMax().Average():####.##} - SD Filtered {KNETData.FilterMinMax().StandardDeviation():####.##} - CV Filtered {100 * KNETData.FilterMinMax().StandardDeviation() / KNETData.FilterMinMax().Average():####.##} %");
                        Console.WriteLine($"Confluent  microseconds -> Max {ConfluentData.Max():####.##} - Min {ConfluentData.Min():####.##} - Avg {ConfluentData.Average():####.##} SD {ConfluentData.StandardDeviation():####.##} - CV {100 * ConfluentData.StandardDeviation() / ConfluentData.Average():####.##} %");
                        Console.WriteLine($"Confluent  microseconds -> Avg Filtered {ConfluentData.FilterMinMax().Average():####.##} - SD Filtered {ConfluentData.FilterMinMax().StandardDeviation():####.##} - CV Filtered {100 * ConfluentData.FilterMinMax().StandardDeviation() / ConfluentData.FilterMinMax().Average():####.##} %");
                        Console.WriteLine($"KNet/Confluent ratio(%) -> Max {100 * (double)KNETData.Max() / ConfluentData.Max():####.##} - Min {100 * (double)KNETData.Min() / ConfluentData.Min():####.##} - Avg {100 * (double)KNETData.Average() / ConfluentData.Average():####.##} - SD {100 * (double)KNETData.StandardDeviation() / ConfluentData.StandardDeviation():####.##} - CV {100 * KNETData.CoefficientOfVariation() / ConfluentData.CoefficientOfVariation():####.##}");
                        Console.WriteLine($"KNet/Confluent ratio(%) -> Avg Filtered {100 * (double)KNETData.FilterMinMax().Average() / ConfluentData.FilterMinMax().Average():####.##} - SD Filtered {100 * (double)KNETData.FilterMinMax().StandardDeviation() / ConfluentData.FilterMinMax().StandardDeviation():####.##} - CV Filtered {100 * KNETData.FilterMinMax().CoefficientOfVariation() / ConfluentData.FilterMinMax().CoefficientOfVariation():####.##}");
                    }
                }
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
            finally
            {
                File.WriteAllText(Path.Combine(ResultsPath, $"roundtrip_results_{DateTime.Now:yyyyMMdd_HHmmss}.csv"), singleTestResultsSb.ToString());
            }
        }
    }
}
