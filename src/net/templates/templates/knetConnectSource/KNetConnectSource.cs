using Java.Util;
using MASES.KNet.Connect;
using MASES.KNet.Connect.Source;

namespace MASES.KNetTemplate.KNetConnect
{
    public class KNetConnectSource : KNetSourceConnector<KnetConnectSourceTask>
    {
        public override string ConnectorName => "MASES.KNetTemplate.KNetConnect.KNetConnectSource";

        public override void Start(Map<string, string> props)
        {

        }

        public override void Stop()
        {

        }

        public override void TaskConfigs(int index, Map<string, string> config)
        {

        }
    }

    public class KnetConnectSourceTask : KNetSourceTask
    {
        public override List<SourceRecord> Poll()
        {
            return null;
        }

        public override void Start(Map<string, string> props)
        {

        }

        public override void Stop()
        {

        }

        public override string Version()
        {
            return "KnetConnectSourceTask";
        }
    }
}
