using MASES.KNet.Connect;
using Org.Apache.Kafka.Connect.Sink;
using System;
using System.Collections.Generic;

namespace MASES.KNetTemplate.KNetConnect
{
    public class KNetConnectSink : KNetSinkConnector<KNetConnectSink, KNetConnectSinkTask>
    {
        public override void Start(IReadOnlyDictionary<string, string> props)
        {
            LogInfo($"KNetConnectSink Start");
            // starts the connector, the method receives the configuration properties
        }

        public override void Stop()
        {
            LogInfo($"KNetConnectSink Stop");
            // stops the connector
        }

        public override void TaskConfigs(int index, IDictionary<string, string> config)
        {
            LogInfo($"Fill properties of task {index}");
            // fill in the properties for task configuration
            foreach (var item in Properties)
            {
                LogInfo($"{item.Key}={item.Value}");
                config.Add(item); // fill in all properties
            }
        }
    }

    public class KNetConnectSinkTask : KNetSinkTask<KNetConnectSinkTask>
    {
        public override void Put(IEnumerable<SinkRecord> collection)
        {
            // receives the records from Apache Kafka Connect to be used from connector
            var castedValues = collection.CastTo<string>();

            foreach (var item in castedValues)
            {
                Console.WriteLine($"Topic: {item.Topic} - Partition: {item.KafkaPartition} - Offset: {item.KafkaOffset} - Value: {item.Value}"); // simply print
            }
        }

        public override void Start(IReadOnlyDictionary<string, string> props)
        {
            // starts the task with the configuration set from connector
            LogInfo($"KNetConnectSinkTask start");
            foreach (var item in props)
            {
                LogInfo($"Task config {item.Key}={item.Value}");
            }
        }

        public override void Stop()
        {
            LogInfo($"KNetConnectSinkTask stop");
            // stops the task
        }
    }
}
