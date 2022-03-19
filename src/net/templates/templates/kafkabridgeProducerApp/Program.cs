using MASES.KafkaBridge;
using MASES.KafkaBridge.Clients.Producer;
using MASES.KafkaBridge.Common.Serialization;
using Java.Util;
using System;
using System.Text;

namespace MASES.KafkaBridgeTemplate.KafkaBridgeProducer
{
    class Program
    {
        const bool useSerdes = true;
        const bool useCallback = true;

        const string theServer = "localhost:9092";
        const string theTopic = "myTopic";

        static string serverToUse = theServer;
        static string topicToUse = theTopic;

        static void Main(string[] args)
        {
            KafkaBridgeCore.CreateGlobalInstance();
            var appArgs = KafkaBridgeCore.FilteredArgs;

            if (appArgs.Length != 0)
            {
                serverToUse = args[0];
            }

            Console.WriteLine("Server in use {0}", serverToUse);

            Properties props = new Properties();
            props.Put(ProducerConfig.BOOTSTRAP_SERVERS_CONFIG, serverToUse);
            props.Put(ProducerConfig.ACKS_CONFIG, "all");
            props.Put(ProducerConfig.RETRIES_CONFIG, 0);
            props.Put(ProducerConfig.LINGER_MS_CONFIG, 1);
            props.Put(ProducerConfig.KEY_SERIALIZER_CLASS_CONFIG, "org.apache.kafka.common.serialization.StringSerializer");
            props.Put(ProducerConfig.VALUE_SERIALIZER_CLASS_CONFIG, "org.apache.kafka.common.serialization.StringSerializer");

            Serializer<string> keySerializer = null;
            Serializer<string> valueSerializer = null;
            Callback callback = null;
            try
            {
                if (useSerdes)
                {
                    keySerializer = new Serializer<string>(serializeFun: (topic, data) =>
                    {
                        var key = Encoding.Unicode.GetBytes(data);
                        return null;
                    });
                    valueSerializer = new Serializer<string>(serializeFun: (topic, data) =>
                    {
                        var value = Encoding.Unicode.GetBytes(data);
                        return value;
                    });
                }
                if (useCallback)
                {
                    callback = new Callback((o1, o2) =>
                    {
                        if (o2 != null) Console.WriteLine(o2.ToString());
                        else Console.WriteLine($"Produced on topic {o1.Topic} at offset {o1.Offset}");
                    });
                }

                using (var producer = useSerdes ? new KafkaProducer<string, string>(props, keySerializer, valueSerializer) : new KafkaProducer<string, string>(props))
            {
                    int i = 0;
                    while (true)
                    {
                        var record = new ProducerRecord<string, string>(topicToUse, i.ToString(), i.ToString());
                        var result = useCallback ? producer.Send(record, callback) : producer.Send(record);
                        Console.WriteLine($"Producing: {record} with result: {result.Get()}");
                        producer.Flush();
                        i++;
                    }
                }
            }
            finally
            {
                if (callback != null) callback.Dispose();
                if (keySerializer != null) keySerializer.Dispose();
                if (valueSerializer != null) valueSerializer.Dispose();
            }

        }
    }
}
