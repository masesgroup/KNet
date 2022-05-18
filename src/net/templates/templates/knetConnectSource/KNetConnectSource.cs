using Java.Util;
using MASES.KNet.Connect;
using MASES.KNet.Connect.Source;

namespace MASES.KNetTemplate.KNetConnect
{
    public class KNetConnectSource : KNetSourceConnector<KNetConnectSource, KNetConnectSourceTask>
    {
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

    public class KNetConnectSourceTask : KNetSourceTask<KNetConnectSourceTask>
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
    }
}
