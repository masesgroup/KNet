using MASES.KafkaBridge;
using MASES.KafkaBridge.Clients.Consumer;
using MASES.KafkaBridge.Java.Util;
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

            Properties props = new Properties();
            props.Put("bootstrap.servers", serverToUse);
            props.Put("group.id", "test");
            props.Put("enable.auto.commit", "true");
            props.Put("auto.commit.interval.ms", "1000");
            props.Put("key.deserializer", "org.apache.kafka.common.serialization.StringDeserializer");
            props.Put("value.deserializer", "org.apache.kafka.common.serialization.StringDeserializer");
            var consumer = new KafkaConsumer<string, string>(props);
            consumer.Subscribe(Collections.singleton(topicToUse));
            while (true)
            {
                var records = consumer.Poll((long)TimeSpan.FromMilliseconds(200).TotalMilliseconds);
                foreach (var item in records)
                {
                    Console.WriteLine($"Offset = {item.Offset}, Key = {item.Key}, Value = {item.Value}");
                }
            }
        }
    }
}
