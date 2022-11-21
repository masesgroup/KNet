using MASES.KNet.Connect;
using MASES.KNet.Connect.Sink;
using System.Collections.Generic;

namespace MASES.KNetTemplate.KNetConnect
{
    public class KNetConnectSink : KNetSinkConnector<KNetConnectSink, KNetConnectSinkTask>
    {
        public override void Start(IReadOnlyDictionary<string, string> props)
        {
            // starts the connector, the method receives the configuration properties
        }

        public override void Stop()
        {
            // stops the connector
        }

        public override void TaskConfigs(int index, IDictionary<string, string> config)
        {
            // fill in the properties for task configuration
        }
    }

    public class KNetConnectSinkTask : KNetSinkTask<KNetConnectSinkTask>
    {
        public override void Put(IEnumerable<SinkRecord> collection)
        {
            // receives the records from Apache Kafka Connect to be used from connector
        }

        public override void Start(IReadOnlyDictionary<string, string> props)
        {
            // starts the task with the configuration set from connector
        }

        public override void Stop()
        {
            // stops the task
        }
    }
}
