using MASES.KNet.Connect;
using MASES.KNet.Connect.Source;
using System.Collections.Generic;

namespace MASES.KNetTemplate.KNetConnect
{
    public class KNetConnectSource : KNetSourceConnector<KNetConnectSource, KNetConnectSourceTask>
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

    public class KNetConnectSourceTask : KNetSourceTask<KNetConnectSourceTask>
    {
        public override IList<SourceRecord> Poll()
        {
            // returns the records to Apache Kafka Connect to be used from connector
            return null;
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
