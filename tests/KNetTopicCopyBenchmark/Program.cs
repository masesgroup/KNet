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

using MASES.JCOBridge.C2JBridge;
using MASES.KNet.Common.Errors;
using System;
using System.IO;
using System.Text;

namespace MASES.KNet.Benchmark
{
    partial class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Init(args);

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

                    var topicNameKNet = TopicName("KNET", length, 0);
                    var topicNameConfluent = TopicName("CONF", length, 0);
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
                        var KNETProdSW = ProduceKNet(topicNameKNet, length, PacketToExchange, CheckOnConsume ? data : null);

                        if (ShowLogs) Console.WriteLine($"Consuming from topic {topicNameKNet}");
                        var KNETConsSW = ConsumeProduceKNet(topicNameKNet, length, PacketToExchange, CheckOnConsume ? data : null);

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
                        var ConfluentProdSW = ProduceConfluent(topicNameConfluent, length, PacketToExchange, CheckOnConsume ? data : null);

                        if (ShowLogs) Console.WriteLine($"Consuming from topic {topicNameConfluent}");
                        var ConfluentConsSW = ConsumeProduceConfluent(topicNameConfluent, length, PacketToExchange, CheckOnConsume ? data : null);

                        sb.AppendLine($"{length};{PacketToExchange};{KNETProdSW.ElapsedMicroSeconds()};{KNETConsSW.ElapsedMicroSeconds()};{ConfluentProdSW.ElapsedMicroSeconds()};{ConfluentConsSW.ElapsedMicroSeconds()}");

                        if (ShowResults)
                        {
                            Console.WriteLine($"Length {length} Produce Diff {KNETProdSW.ElapsedMicroSeconds() - ConfluentProdSW.ElapsedMicroSeconds()} Copy Diff {KNETConsSW.ElapsedMicroSeconds() - ConfluentConsSW.ElapsedMicroSeconds()}");

                            Console.WriteLine($"Produce KNET: Total {KNETProdSW.ElapsedMicroSeconds()} us Mean {KNETProdSW.MeanMicroSeconds(PacketToExchange)} us {KNETProdSW.PacketsPerSeconds(PacketToExchange)} packets/s {KNETProdSW.MbPerSecond(PacketToExchange, length)} Mb/s");
                            Console.WriteLine($"Copy KNET: Total {KNETConsSW.ElapsedMicroSeconds()} us Mean {KNETConsSW.MeanMicroSeconds(PacketToExchange)} us {KNETConsSW.PacketsPerSeconds(PacketToExchange)} packets/s {KNETConsSW.MbPerSecond(PacketToExchange, length)} Mb/s");

                            Console.WriteLine($"Produce Confluent: Total {ConfluentProdSW.ElapsedMicroSeconds()} us Mean {ConfluentProdSW.MeanMicroSeconds(PacketToExchange)} us {ConfluentProdSW.PacketsPerSeconds(PacketToExchange)} packets/s {ConfluentProdSW.MbPerSecond(PacketToExchange, length)} Mb/s");
                            Console.WriteLine($"Copy Confluent: Total {ConfluentConsSW.ElapsedMicroSeconds()} us Mean {ConfluentConsSW.MeanMicroSeconds(PacketToExchange)} us {ConfluentConsSW.PacketsPerSeconds(PacketToExchange)} packets/s {ConfluentConsSW.MbPerSecond(PacketToExchange, length)} Mb/s");
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
                    }
                }
                File.WriteAllText(Path.Combine(ResultsPath, $"topiccopy_results_{DateTime.Now:yyyyMMdd_HHmmss}.csv"), sb.ToString());
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
