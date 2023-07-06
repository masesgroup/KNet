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

using Java.Util;
using Org.Apache.Kafka.Clients.Admin;
using Org.Apache.Kafka.Common.Errors;
using MASES.KNet.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using MASES.KNet.Admin;

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

        public static IEnumerable<double> FilterMinMax(this IEnumerable<long> values)
        {
            return FilterMinMax(values.Select(p => (double)p));
        }

        public static IEnumerable<double> FilterMinMax(this IEnumerable<double> values)
        {
            System.Collections.Generic.List<double> result = new(values);
            if (result.Count > 2)
            {
                var min = result.Min();
                var max = result.Max();
                result.Remove(min);
                result.Remove(max);
            }
            return result;
        }

        public static double StandardDeviation(this IEnumerable<long> values)
        {
            return StandardDeviation(values.Select(p => (double)p));
        }

        public static double StandardDeviation(this IEnumerable<double> values) // from stackoverflow
        {
            double standardDeviation = 0;

            if (values.Any())
            {
                // Compute the average.     
                double avg = values.Average();

                // Perform the Sum of (value-avg)_2_2.      
                double sum = values.Sum(d => Math.Pow(d - avg, 2));

                // Put it all together.      
                standardDeviation = Math.Sqrt((sum) / (values.Count() - 1));
            }

            return standardDeviation;
        }

        public static double CoefficientOfVariation(this IEnumerable<long> values)
        {
            return values.StandardDeviation() / values.Average();
        }

        public static double CoefficientOfVariation(this IEnumerable<double> values)
        {
            return values.StandardDeviation() / values.Average();
        }

        public static double MeanMicroSeconds(this IEnumerable<double> values, int numPacket)
        {
            return (double)values.Sum() / numPacket;
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
