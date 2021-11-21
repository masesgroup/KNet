using MASES.KafkaBridge;
using MASES.KafkaBridge.Clients.Consumer;
using MASES.KafkaBridge.Clients.Producer;
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
            props.Put("acks", "all");
            props.Put("retries", 0);
            props.Put("linger.ms", 1);
            props.Put("key.serializer", "org.apache.kafka.common.serialization.StringSerializer");
            props.Put("value.serializer", "org.apache.kafka.common.serialization.StringSerializer");

            using (KafkaProducer producer = new KafkaProducer(props))
            {
                int i = 0;
                while (true)
                {
                    var record = new ProducerRecord<string, string>(topicToUse, i.ToString(), i.ToString());
                    var result = producer.Send(record);
                    Console.WriteLine($"Producing: {record} with result: {result.Get()}");
                    producer.Flush();
                    i++;
                }
            }
        }
    }
}
