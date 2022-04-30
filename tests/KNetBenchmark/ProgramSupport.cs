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

using MASES.KNet.Clients.Admin;
using Java.Util;
using System;
using MASES.KNet.Extensions;
using MASES.KNet.Common.Errors;
using System.Diagnostics;

namespace MASES.KNet.Benchmark
{
    public static class Utility
    {
        public static long ElapsedNanoSeconds(this Stopwatch watch)
        {
            return (long)((double)watch.ElapsedTicks / Stopwatch.Frequency * 1000000000);
        }
        public static long ElapsedMicroSeconds(this Stopwatch watch)
        {
            return (long)((double)watch.ElapsedTicks / Stopwatch.Frequency * 1000000);
        }
        public static double MeanMicroSeconds(this Stopwatch watch, int numPacket)
        {
            return (double)watch.ElapsedMicroSeconds() / numPacket;
        }
        public static double PacketsPerSeconds(this Stopwatch watch, int numPacket)
        {
            return (double)numPacket * 1000000 / watch.ElapsedMicroSeconds();
        }
        public static double MbPerSecond(this Stopwatch watch, int numPacket, int length)
        {
            return (double)(length * numPacket) / (1024 * 1024) / ((double)watch.ElapsedMicroSeconds() / 1000000);
        }
        public static double KbPerSecond(this Stopwatch watch, int numPacket, int length)
        {
            return (double)(length * numPacket) / 1024 / ((double)watch.ElapsedMicroSeconds() / 1000000);
        }
    }

    partial class Program
    {
        static string TopicName(string testName, int length, int testNum)
        {
            return $"{TopicPrefix}_{testName}_{length}_{testNum}";
        }

        static IAdmin knetAdmin = null;
        static IAdmin GetAdmin()
        {
            if (knetAdmin == null)
            {
                Properties props = AdminClientConfigBuilder.Create().WithBootstrapServers(Server).ToProperties();
                knetAdmin = KafkaAdminClient.Create(props);
            }
            return knetAdmin;
        }

        static void CreateTopic(string topicName)
        {
            try
            {
                int partitions = PartitionsPerTopic;
                short replicationFactor = 1;

                GetAdmin().CreateTopic(topicName, partitions, replicationFactor);
                if (ShowLogs) Console.WriteLine($"Created topic {topicName}");
            }
            catch (Java.Util.Concurrent.ExecutionException ex)
            {
                throw ex.InnerException;
            }
        }

        static void DeleteTopic(string topicName)
        {
            try
            {
                try
                {
                    GetAdmin().DeleteTopic(topicName);
                    if (ShowLogs) Console.WriteLine($"Deleted topic {topicName}");
                }
                catch (Java.Util.Concurrent.ExecutionException ex)
                {
                    throw ex.InnerException;
                }
            }
            catch (UnknownTopicOrPartitionException) { }
        }
    }
}
