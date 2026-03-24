/*
*  Copyright (c) 2021-2026 MASES s.r.l.
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

using Org.Apache.Kafka.Connect.Sink;
using System;
using System.Collections.Generic;

namespace MASES.KNet.Connect.Test
{
    public class KNetSinkTestConnector : KNetSinkConnector<KNetSinkTestConnector, KNetSinkTestTask>
    {
        public override void Start(IKNetConfigurationFromMap props)
        {
            LogInfo($"KNetSinkTestConnector Start");
        }

        public override void Stop()
        {
            LogInfo($"KNetSinkTestConnector Stop");
        }

        public override bool TaskConfigs(int index, int maxTasks, IKNetTaskConfiguration config)
        {
            LogInfo($"Fill in task {index}");

            foreach (var item in Properties)
            {
                LogInfo($"{item.Key}={item.Value}");
                config.Add(item.Key, item.Value?.ToString()); // fill in all properties
            }

            return false;
        }
    }

    public class KNetSinkTestTask : KNetSinkTask<KNetSinkTestTask>
    {
        public override void Put(IEnumerable<SinkRecord> collection)
        {
            var castedValues = collection.CastTo<string>();

            foreach (var item in castedValues)
            {
                Console.WriteLine($"Topic: {item.Topic} - Partition: {item.KafkaPartition} - Offset: {item.KafkaOffset} - Value: {item.Value}");
            }
        }

        public override void Start(IKNetConfigurationFromMap props)
        {
            LogInfo($"KNetSinkTestTask start");
            foreach (var item in props)
            {
                LogInfo($"Task config {item.Key}={item.Value}");
            }
        }

        public override void Stop()
        {
            LogInfo($"KNetSinkTestTask stop");
        }
    }
}
