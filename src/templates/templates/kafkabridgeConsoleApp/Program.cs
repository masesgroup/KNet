using MASES.JCOBridge.C2JBridge;
using System;

namespace MASES.KafkaBridgeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                JVMBridgeRunner<KafkaBridgeApp>.Run(args);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        class KafkaBridgeApp : JVMBridgeBase<KafkaBridgeApp>
        {
            public override string ClassName => throw new NotImplementedException();

            public override void Execute<T>(params T[] args)
            {
                // adds execution here
            }
        }
    }
}
