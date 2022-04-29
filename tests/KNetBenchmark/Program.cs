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

using System;
using MASES.KNet.Common.Errors;
using MASES.JCOBridge.C2JBridge;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace MASES.KNet.Benchmark
{
    partial class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Init(args);

                ProduceConfluent(0, 0); // init lib?
                long totalKNetProduce = 0;
                long totalConfluentProduce = 0;
                long totalKNetConsume = 0;
                long totalConfluentConsume = 0;
                StringBuilder sb = new();
                sb.AppendLine("Length;NumPackets;KNETProd;KNETCons;ConfluentProd;ConfluentCons");

                for (int testNum = 0; testNum < Repeat; testNum++)
                {
                    for (int length = MinPacketLength; length <= MaxPacketLength; length *= PacketLengthMultiplier)
                    {
                        var rand = new Random();
                        byte[] data = new byte[length];
                        for (int i = 0; i < length; i++)
                        {
                            data[i] = (byte)rand.Next(0, byte.MaxValue);
                        }

                        if (ShowResults)
                        {
                            Console.WriteLine($"Test {testNum}: Length {length} Packets {PacketToExchange}");
                        }

                        try
                        {
                            try
                            {
                                CreateTopic(TopicName("KNET", length));
                            }
                            catch (TopicExistsException)
                            {
                                DeleteTopic(TopicName("KNET", length));
                                System.Threading.Thread.Sleep(1000); // wait kafka server
                                CreateTopic(TopicName("KNET", length));
                            }

                            if (ShowLogs) Console.WriteLine($"Producing on topic {TopicName("KNET", length)}");
                            var KNETProdSW = UseKNetProducer ? ProduceKNet(length, PacketToExchange, CheckOnConsume ? data : null) : ProduceKafka(length, PacketToExchange, CheckOnConsume ? data : null);
                            Stopwatch KNETConsSW = new();
                            if (!ProduceOnly)
                            {
                                if (ShowLogs) Console.WriteLine($"Consuming from topic {TopicName("KNET", length)}");
                                KNETConsSW = UseKNetConsumer ? ConsumeKNet(length, PacketToExchange, CheckOnConsume ? data : null) : ConsumeKafka(length, PacketToExchange, CheckOnConsume ? data : null);
                            }

                            try
                            {
                                CreateTopic(TopicName("CONFLUENT", length));
                            }
                            catch (TopicExistsException)
                            {
                                DeleteTopic(TopicName("CONFLUENT", length));
                                System.Threading.Thread.Sleep(1000); // wait kafka server
                                CreateTopic(TopicName("CONFLUENT", length));
                            }

                            if (ShowLogs) Console.WriteLine($"Producing on topic {TopicName("CONFLUENT", length)}");
                            var ConfluentProdSW = ProduceConfluent(length, PacketToExchange, CheckOnConsume ? data : null);
                            Stopwatch ConfluentConsSW = new();
                            if (!ProduceOnly)
                            {
                                if (ShowLogs) Console.WriteLine($"Consuming from topic {TopicName("CONFLUENT", length)}");
                                ConfluentConsSW = ConsumeConfluent(length, PacketToExchange, CheckOnConsume ? data : null);
                            }

                            totalKNetProduce += KNETProdSW.ElapsedMicroSeconds();
                            totalConfluentProduce += ConfluentProdSW.ElapsedMicroSeconds();
                            totalKNetConsume += KNETConsSW.ElapsedMicroSeconds();
                            totalConfluentConsume += ConfluentConsSW.ElapsedMicroSeconds();

                            sb.AppendLine($"{length};{PacketToExchange};{KNETProdSW.ElapsedMicroSeconds()};{KNETConsSW?.ElapsedMicroSeconds()};{ConfluentProdSW.ElapsedMicroSeconds()};{ConfluentConsSW?.ElapsedMicroSeconds()}");

                            if (ShowResults)
                            {
                                if (ProduceOnly)
                                {
                                    Console.WriteLine($"Produce Diff {KNETProdSW.ElapsedMicroSeconds() - ConfluentProdSW.ElapsedMicroSeconds()}");
                                }
                                else
                                {
                                    Console.WriteLine($"Produce Diff {KNETProdSW.ElapsedMicroSeconds() - ConfluentProdSW.ElapsedMicroSeconds()} Consume Diff {KNETConsSW.ElapsedMicroSeconds() - ConfluentConsSW.ElapsedMicroSeconds()}");
                                }

                                Console.WriteLine($"Produce KNET: Total {KNETProdSW.ElapsedMicroSeconds()} us Mean {KNETProdSW.MeanMicroSeconds(PacketToExchange)} us {KNETProdSW.PacketsPerSeconds(PacketToExchange)} packets/s {KNETProdSW.MbPerSecond(PacketToExchange, length)} Mb/s");
                                if (!ProduceOnly) Console.WriteLine($"Consume KNET: Total {KNETConsSW.ElapsedMicroSeconds()} us Mean {KNETConsSW.MeanMicroSeconds(PacketToExchange)} us {KNETConsSW.PacketsPerSeconds(PacketToExchange)} packets/s {KNETConsSW.MbPerSecond(PacketToExchange, length)} Mb/s");

                                Console.WriteLine($"Produce Confluent: Total {ConfluentProdSW.ElapsedMicroSeconds()} us Mean {ConfluentProdSW.MeanMicroSeconds(PacketToExchange)} us {ConfluentProdSW.PacketsPerSeconds(PacketToExchange)} packets/s {ConfluentProdSW.MbPerSecond(PacketToExchange, length)} Mb/s");
                                if (!ProduceOnly) Console.WriteLine($"Consume Confluent: Total {ConfluentConsSW.ElapsedMicroSeconds()} us Mean {ConfluentConsSW.MeanMicroSeconds(PacketToExchange)} us {ConfluentConsSW.PacketsPerSeconds(PacketToExchange)} packets/s {ConfluentConsSW.MbPerSecond(PacketToExchange, length)} Mb/s");
                            }
                        }
                        finally
                        {
                            if (!LeaveTopics)
                            {
                                DeleteTopic(TopicName("KNET", length));
                                DeleteTopic(TopicName("CONFLUENT", length));
                            }
                            if (ShowResults) BenchmarkKNetCore.GlobalInstance.ShowStats(PacketToExchange);
                        }
                    }
                }

                if (ProduceOnly)
                {
                    Console.WriteLine($"KNet/Confluent produce time: {100 * (double)totalKNetProduce / totalConfluentProduce} %");
                }
                else
                {
                    Console.WriteLine($"KNet/Confluent produce time: {100 * (double)totalKNetProduce / totalConfluentProduce} % consume time: {100 * (double)totalKNetConsume / totalConfluentConsume} %");
                }

                File.WriteAllText(Path.Combine(ResultsPath, $"results_{DateTime.Now:yyyyMMdd_HHmmss}.csv"), sb.ToString());
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
        }
    }
}
