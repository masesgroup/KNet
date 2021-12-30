using MASES.KafkaBridge;
using MASES.KafkaBridge.Clients.Producer;
using MASES.KafkaBridge.Java.Util;
using System;

namespace MASES.KafkaBridgeTemplate.KafkaBridgeProducer
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
            props.Put(ProducerConfig.BOOTSTRAP_SERVERS_CONFIG, serverToUse);
            props.Put(ProducerConfig.ACKS_CONFIG, "all");
            props.Put(ProducerConfig.RETRIES_CONFIG, 0);
            props.Put(ProducerConfig.LINGER_MS_CONFIG, 1);
            props.Put(ProducerConfig.KEY_SERIALIZER_CLASS_CONFIG, "org.apache.kafka.common.serialization.StringSerializer");
            props.Put(ProducerConfig.VALUE_SERIALIZER_CLASS_CONFIG, "org.apache.kafka.common.serialization.StringSerializer");

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
