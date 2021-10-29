using MASES.KafkaBridge;
using System;

namespace MASES.KafkaBridgeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                KafkaBridgeRunner<KafkaBridgeApp>.Run(args);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        class KafkaBridgeApp : KafkaBridgeCore
        {
            public override void Execute<T>(params T[] args)
            {
                // adds execution here
            }
        }
    }
}
