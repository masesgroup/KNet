using MASES.JCOBridge.C2JBridge;
using Org.Apache.Kafka.Clients.Consumer;
using Org.Apache.Kafka.Common.Serialization;
using Java.Util;
using Org.Apache.Kafka.Streams;
using System;
using System.Threading;

namespace MASES.KNet.Template.KNetStreamPipe
{
    class LocalKNetCore : KNetCore<LocalKNetCore> { }

    class Program
    {
        const string theServer = "localhost:9092";
        const string theTopic = "myTopic";

        static string serverToUse = theServer;
        static string topicToUse = theTopic;

        static readonly ManualResetEvent resetEvent = new ManualResetEvent(false);

        static void Main(string[] args)
        {
            LocalKNetCore.CreateGlobalInstance();
            var appArgs = LocalKNetCore.FilteredArgs;

            if (appArgs.Length != 0)
            {
                serverToUse = args[0];
            }

            Console.WriteLine("Server in use {0}", serverToUse);

            var props = new Properties();

            props.Put(StreamsConfig.APPLICATION_ID_CONFIG, "streams-pipe");
            props.Put(StreamsConfig.BOOTSTRAP_SERVERS_CONFIG, serverToUse);
            props.Put(StreamsConfig.DEFAULT_KEY_SERDE_CLASS_CONFIG, Serdes.String().Dyn().getClass());
            props.Put(StreamsConfig.DEFAULT_VALUE_SERDE_CLASS_CONFIG, Serdes.String().Dyn().getClass());

            // setting offset reset to earliest so that we can re-run the demo code with the same pre-loaded data
            props.Put(ConsumerConfig.AUTO_OFFSET_RESET_CONFIG, "earliest");

            var builder = new StreamsBuilder();

            builder.Stream<string, string>(topicToUse).To("streams-pipe-output");

            Console.CancelKeyPress += Console_CancelKeyPress;
            Console.WriteLine("Press Ctrl-C to exit");

            using (var streams = new KafkaStreams(builder.Build(), props))
            {
                streams.Start();
                while (!resetEvent.WaitOne(0))
                {
                    var state = streams.StateMethod();
                    Console.WriteLine($"KafkaStreams state: {state}");
                }
            }
        }

        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            if (e.Cancel) resetEvent.Set();
        }
    }
}
