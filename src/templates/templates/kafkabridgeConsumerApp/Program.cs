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
            props.Put(ConsumerConfig.BOOTSTRAP_SERVERS_CONFIG, serverToUse);
            props.Put(ConsumerConfig.GROUP_ID_CONFIG, "test");
            props.Put(ConsumerConfig.ENABLE_AUTO_COMMIT_CONFIG, "true");
            props.Put(ConsumerConfig.AUTO_COMMIT_INTERVAL_MS_CONFIG, "1000");
            props.Put(ConsumerConfig.KEY_DESERIALIZER_CLASS_CONFIG, "org.apache.kafka.common.serialization.StringDeserializer");
            props.Put(ConsumerConfig.VALUE_DESERIALIZER_CLASS_CONFIG, "org.apache.kafka.common.serialization.StringDeserializer");
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
