using Org.Apache.Kafka.Connect;
using Org.Apache.Kafka.Connect.Data;
using Org.Apache.Kafka.Connect.Source;
using System;
using System.Collections.Generic;
using System.IO;

namespace MASES.KNetTemplate.KNetConnect
{
    public class KNetConnectSource : KNetSourceConnector<KNetConnectSource, KNetConnectSourceTask>
    {
        public override void Start(IReadOnlyDictionary<string, string> props)
        {
            LogInfo($"KNetConnectSource Start");
            // starts the connector, the method receives the configuration properties
        }

        public override void Stop()
        {
            LogInfo($"KNetConnectSource Stop");
            // stops the connector
        }

        public override void TaskConfigs(int index, IDictionary<string, string> config)
        {
            // fill in the properties for task configuration
            LogInfo($"Fill properties of task {index}");

            foreach (var item in Properties)
            {
                LogInfo($"{item.Key}={item.Value}");
                config.Add(item); // fill in all properties
            }
        }
    }

    public class KNetConnectSourceTask : KNetSourceTask<KNetConnectSourceTask>
    {
        string _topic = "KNetConnectTestTopic";
        int _batchSize = 10;
        string _filename = "Dante.txt";
        const string FILENAME_FIELD = "filename";
        const string POSITION_FIELD = "position";

        const bool useSourceOffset = false;

        private long lineOffset = 0L;

        public override IList<SourceRecord> Poll()
        {
            // returns the records to Apache Kafka Connect to be used from connector
            var lines = File.ReadAllLines(_filename);
            if (useSourceOffset)
            {
                var offset = OffsetAt<string, long>(FILENAME_FIELD, _filename);
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
            // starts the task with the configuration set from connector
            // in this template we set only _topic local variables from configuration
            LogInfo($"KNetConnectSourceTask start");
            foreach (var item in props)
            {
                LogInfo($"Task config {item.Key}={item.Value}");
                if (item.Key == "topic") _topic = item.Value;
            }
        }

        public override void Stop()
        {
            // stops the task
            LogInfo($"KNetConnectSourceTask stop");
        }
    }
}
