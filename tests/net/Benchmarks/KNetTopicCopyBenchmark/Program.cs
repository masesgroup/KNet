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
using System.IO;
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
                singleTestResultsSb.AppendLine("NumPackets;Length;KNETProd;KNETCons;ConfluentProd;ConfluentCons");

                for (int packets = MinPacketsToExchange; packets <= MaxPacketsToExchange; packets *= PacketsToExchangeMultiplier)
                {
                    for (int length = MinPacketLength; length <= MaxPacketLength; length *= PacketLengthMultiplier)
                    {
                        var rand = new Random();
                        byte[] data = new byte[length];
                        for (int i = 0; i < length; i++)
                        {
                            data[i] = (byte)rand.Next(0, byte.MaxValue);
                        }

                        var topicNameKNet = TopicName("KNET", packets, length, 0);
                        var topicNameConfluent = TopicName("CONF", packets, length, 0);
                        try
                        {
                            try
                            {
                                CreateTopic(topicNameKNet);
                            }
                            catch (TopicExistsException)
                            {
                                DeleteTopic(topicNameKNet);
                                CreateTopic(topicNameKNet);
                            }

                            try
                            {
                                CreateTopic(topicNameKNet + "_COPY");
                            }
                            catch (TopicExistsException)
                            {
                                DeleteTopic(topicNameKNet + "_COPY");
                                CreateTopic(topicNameKNet + "_COPY");
                            }

                            if (ShowLogs) Console.WriteLine($"Producing on topic {topicNameKNet}");
                            var KNETProdSW = ProduceKNet(topicNameKNet, length, packets, CheckOnConsume ? data : null);

                            if (ShowLogs) Console.WriteLine($"Consuming from topic {topicNameKNet}");
                            var KNETConsSW = ConsumeProduceKNet(topicNameKNet, length, packets, CheckOnConsume ? data : null);

                            try
                            {
                                CreateTopic(topicNameConfluent);
                            }
                            catch (TopicExistsException)
                            {
                                DeleteTopic(topicNameConfluent);
                                CreateTopic(topicNameConfluent);
                            }

                            try
                            {
                                CreateTopic(topicNameConfluent + "_COPY");
                            }
                            catch (TopicExistsException)
                            {
                                DeleteTopic(topicNameConfluent + "_COPY");
                                CreateTopic(topicNameConfluent + "_COPY");
                            }

                            if (ShowLogs) Console.WriteLine($"Producing on topic {topicNameConfluent}");
                            var ConfluentProdSW = ProduceConfluent(topicNameConfluent, length, packets, CheckOnConsume ? data : null);

                            if (ShowLogs) Console.WriteLine($"Consuming from topic {topicNameConfluent}");
                            var ConfluentConsSW = ConsumeProduceConfluent(topicNameConfluent, length, packets, CheckOnConsume ? data : null);

                            singleTestResultsSb.AppendLine($"{packets};{length};{KNETProdSW.ElapsedMicroSeconds()};{KNETConsSW.ElapsedMicroSeconds()};{ConfluentProdSW.ElapsedMicroSeconds()};{ConfluentConsSW.ElapsedMicroSeconds()}");

                            if (ShowIntermediateResults)
                            {
                                Console.WriteLine($"Length {length} Produce Diff {KNETProdSW.ElapsedMicroSeconds() - ConfluentProdSW.ElapsedMicroSeconds()} Copy Diff {KNETConsSW.ElapsedMicroSeconds() - ConfluentConsSW.ElapsedMicroSeconds()}");

                                Console.WriteLine($"Produce KNET: Total {KNETProdSW.ElapsedMicroSeconds()} us Mean {KNETProdSW.MeanMicroSeconds(packets)} us {KNETProdSW.PacketsPerSeconds(packets)} packets/s {KNETProdSW.MbPerSecond(packets, length)} Mb/s");
                                Console.WriteLine($"Copy KNET: Total {KNETConsSW.ElapsedMicroSeconds()} us Mean {KNETConsSW.MeanMicroSeconds(packets)} us {KNETConsSW.PacketsPerSeconds(packets)} packets/s {KNETConsSW.MbPerSecond(packets, length)} Mb/s");

                                Console.WriteLine($"Produce Confluent: Total {ConfluentProdSW.ElapsedMicroSeconds()} us Mean {ConfluentProdSW.MeanMicroSeconds(packets)} us {ConfluentProdSW.PacketsPerSeconds(packets)} packets/s {ConfluentProdSW.MbPerSecond(packets, length)} Mb/s");
                                Console.WriteLine($"Copy Confluent: Total {ConfluentConsSW.ElapsedMicroSeconds()} us Mean {ConfluentConsSW.MeanMicroSeconds(packets)} us {ConfluentConsSW.PacketsPerSeconds(packets)} packets/s {ConfluentConsSW.MbPerSecond(packets, length)} Mb/s");
                            }
                        }
                        finally
                        {
                            if (!LeaveTopics)
                            {
                                DeleteTopic(topicNameKNet);
                                DeleteTopic(topicNameKNet + "_COPY");
                                DeleteTopic(topicNameConfluent);
                                DeleteTopic(topicNameConfluent + "_COPY");
                            }

                            GC.Collect();
                            Java.Lang.System.Gc();
                        }
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
                File.WriteAllText(Path.Combine(ResultsPath, $"topiccopy_results_{DateTime.Now:yyyyMMdd_HHmmss}.csv"), singleTestResultsSb.ToString());
            }
        }
    }
}
