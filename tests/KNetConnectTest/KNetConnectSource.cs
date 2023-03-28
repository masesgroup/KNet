/*
*  Copyright 2023 MASES s.r.l.
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
using Org.Apache.Kafka.Connect;
using Org.Apache.Kafka.Connect.Data;
using Org.Apache.Kafka.Connect.Source;
using System;
using System.Collections.Generic;
using System.IO;

namespace MASES.KNetConnectTest
{
    public class KNetSourceTestConnector : KNetSourceConnector<KNetSourceTestConnector, KNetSourceTestTask>
    {
        public override void Start(IReadOnlyDictionary<string, string> props)
        {
            LogInfo($"KNetSourceTestConnector Start");
        }

        public override void Stop()
        {
            LogInfo($"KNetSourceTestConnector Stop");
        }

        public override void TaskConfigs(int index, IDictionary<string, string> config)
        {
            LogInfo($"Fill in task {index}");

            foreach (var item in Properties)
            {
                LogInfo($"{item.Key}={item.Value}");
                config.Add(item); // fill in all properties
            }
        }
    }

    public class KNetSourceTestTask : KNetSourceTask<KNetSourceTestTask>
    {
        string _topic = "KNetConnectTestTopic";
        int _batchSize = 10;
        string _filename = "TestFileInput.txt";
        const string FILENAME_FIELD = "filename";
        const string POSITION_FIELD = "position";

        const bool useSourceOffset = false;

        private long lineOffset = 0L;

        public override IList<SourceRecord> Poll()
        {
            var lines = File.ReadAllLines(_filename);
            if (useSourceOffset)
            {
                Map<string, long> offset = OffsetAt<string, long>(FILENAME_FIELD, _filename);
                if (offset != null)
                {
                    long lastRecordedOffset = 0;
                    if (offset.ContainsKey(POSITION_FIELD))
                    {
                        lastRecordedOffset = offset.Get(POSITION_FIELD);
                        LogDebug($"Found previous offset, trying to skip to file offset {lastRecordedOffset}");
                    }
                    lineOffset = lastRecordedOffset;
                }
                else
                {
                    lineOffset = 0L;
                }
            }

            System.Collections.Generic.List<SourceRecord> records = new();
            for (long i = lineOffset; i < lines.LongLength; i++)
            {
                if (useSourceOffset)
                {
                    var record = CreateRecord(OffsetForKey(FILENAME_FIELD, _filename), OffsetForKey(POSITION_FIELD, i), _topic, Schema.STRING_SCHEMA, lines[i], DateTime.Now);
                    records.Add(record);
                }
                else
                {
                    var record = CreateRecord(_topic, Schema.STRING_SCHEMA, lines[i], DateTime.Now);
                    records.Add(record);
                }
              
                lineOffset = i + 1;
                if (records.Count >= _batchSize) break;
            }

            return records;
        }

        public override void Start(IReadOnlyDictionary<string, string> props)
        {
            LogInfo($"KNetSourceTestTask start");
            foreach (var item in props)
            {
                LogInfo($"Task config {item.Key}={item.Value}");
            }
        }

        public override void Stop()
        {
            LogInfo($"KNetSourceTestTask stop");
        }
    }
}
