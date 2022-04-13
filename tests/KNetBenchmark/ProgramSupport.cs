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

namespace MASES.KNetBenchmark
{
    partial class Program
    {
        static string TopicName(string testName, int length)
        {
            return $"{MyKNetCore.TopicPrefix}_{testName}_{length}";
        }

        static void CreateTopic(string testName, int length)
        {
            try
            {
                int partitions = MyKNetCore.TopicPartitions;
                short replicationFactor = 1;

                Properties props = AdminClientConfigBuilder.Create().WithBootstrapServers(MyKNetCore.Server).ToProperties();
                using (IAdmin admin = KafkaAdminClient.Create(props))
                {
                    admin.CreateTopic(TopicName(testName, length), partitions, replicationFactor);
                }
                if (MyKNetCore.ShowLogs) Console.WriteLine($"Created topic {TopicName(testName, length)}");
            }
            catch (Java.Util.Concurrent.ExecutionException ex)
            {
                throw ex.InnerException;
            }
        }

        static void DeleteTopic(string testName, int length)
        {
            try
            {
                try
                {
                    Properties props = AdminClientConfigBuilder.Create().WithBootstrapServers(MyKNetCore.Server).ToProperties();
                    using (IAdmin admin = KafkaAdminClient.Create(props))
                    {
                        admin.DeleteTopic(TopicName(testName, length));
                    }
                    if (MyKNetCore.ShowLogs) Console.WriteLine($"Deleted topic {TopicName(testName, length)}");
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
