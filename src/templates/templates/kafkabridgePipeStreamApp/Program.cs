using MASES.KafkaBridge;
using MASES.KafkaBridge.Clients.Consumer;
using MASES.KafkaBridge.Common.Serialization;
using MASES.KafkaBridge.Java.Util;
using MASES.KafkaBridge.Streams;
using System;

namespace MASES.KafkaBridgeTemplate.KafkaBridgeConsumer
{
    class Program
    {
        const string theServer = "localhost:9092";
        const string theTopic = "myTopic";

        static string serverToUse = theServer;
        static string topicToUse = theTopic;

        static void Main(string[] args)
        {
            var appArgs = KafkaBridgeCore.ApplicationArgs;

            if (appArgs.Length != 0)
            {
                serverToUse = args[0];
            }

            var props = new Properties();

            props.Put(StreamsConfig.APPLICATION_ID_CONFIG, "streams-pipe");
            props.Put(StreamsConfig.BOOTSTRAP_SERVERS_CONFIG, serverToUse);
            props.Put(StreamsConfig.DEFAULT_KEY_SERDE_CLASS_CONFIG, Serdes.String.getClass());
            props.Put(StreamsConfig.DEFAULT_VALUE_SERDE_CLASS_CONFIG, Serdes.String.getClass());

            // setting offset reset to earliest so that we can re-run the demo code with the same pre-loaded data
            props.Put(ConsumerConfig.AUTO_OFFSET_RESET_CONFIG, "earliest");

            var builder = new StreamsBuilder();

            builder.Stream<string, string>(topicToUse).To("streams-pipe-output");

            using (var streams = new KafkaStreams(builder.Build(), props))
            {
                streams.Start();
                while (true)
                {
                    var state = streams.State;
                    Console.WriteLine($"KafkaStreams state: {state}");
                }
            }
        }
    }
}
