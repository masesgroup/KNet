using Java.Util;
using MASES.KNet.Connect;
using MASES.KNet.Connect.Sink;

namespace MASES.KNetTemplate.KNetConnect
{
    public class KNetConnectSink : KNetSinkConnector<KNetConnectSink, KnetConnectSinkTask>
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

    public class KnetConnectSinkTask : KNetSinkTask<KnetConnectSinkTask>
    {
        public override void Put(Collection<SinkRecord> collection)
        {

        }

        public override void Start(Map<string, string> props)
        {

        }

        public override void Stop()
        {

        }
    }
}
