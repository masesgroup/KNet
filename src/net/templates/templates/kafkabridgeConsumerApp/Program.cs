using MASES.KafkaBridge;
using MASES.KafkaBridge.Clients.Consumer;
using MASES.KafkaBridge.Common.Serialization;
using Java.Util;
using System;
using System.Text;

namespace MASES.KafkaBridgeTemplate.KafkaBridgeConsumer
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
            var appArgs = KafkaBridgeCore.ApplicationArgs;

            if (appArgs.Length != 0)
            {
                serverToUse = args[0];
            }

            Console.WriteLine("Server in use {0}", serverToUse);

            Properties props = new Properties();
            props.Put(ConsumerConfig.BOOTSTRAP_SERVERS_CONFIG, serverToUse);
            props.Put(ConsumerConfig.GROUP_ID_CONFIG, "test");
            props.Put(ConsumerConfig.ENABLE_AUTO_COMMIT_CONFIG, "true");
            props.Put(ConsumerConfig.AUTO_COMMIT_INTERVAL_MS_CONFIG, "1000");
            props.Put(ConsumerConfig.KEY_DESERIALIZER_CLASS_CONFIG, "org.apache.kafka.common.serialization.StringDeserializer");
            props.Put(ConsumerConfig.VALUE_DESERIALIZER_CLASS_CONFIG, "org.apache.kafka.common.serialization.StringDeserializer");

            ConsumerRebalanceListener rebalanceListener = null;
            Deserializer<string> keyDeserializer = null;
            Deserializer<string> valueDeserializer = null;
            try
            {
                if (useSerdes)
                {
                    keyDeserializer = new Deserializer<string>(deserializeFun: (topic, data) =>
                    {
                        var key = Encoding.Unicode.GetString(data);
                        Console.WriteLine("Received key {0} from topic {1}", key, topic);
                        return key;
                    });
                    valueDeserializer = new Deserializer<string>(deserializeFun: (topic, data) =>
                    {
                        var value = Encoding.Unicode.GetString(data);
                        Console.WriteLine("Received value {0} from topic {1}", value, topic);
                        return value;
                    });
                }

                if (useCallback)
                {
                    rebalanceListener = new ConsumerRebalanceListener(
                        revoked: (o) =>
                        {
                            Console.WriteLine("Revoked: {0}", o.ToString());
                        },
                        assigned: (o) =>
                        {
                            Console.WriteLine("Assigned: {0}", o.ToString());
                        });
                }

                using (var consumer = useSerdes ? new KafkaConsumer<string, string>(props, keyDeserializer, valueDeserializer) : new KafkaConsumer<string, string>(props))
                {
                    if (useCallback) consumer.Subscribe(Collections.Singleton(topicToUse), rebalanceListener);
                    else consumer.Subscribe(Collections.Singleton(topicToUse));

                    while (true)
                    {
                        var records = consumer.Poll((long)TimeSpan.FromMilliseconds(200).TotalMilliseconds);
                        foreach (var item in records)
                        {
                            Console.WriteLine($"Consuming from Offset = {item.Offset}, Key = {item.Key}, Value = {item.Value}");
                        }
                    }
                }
            }
            finally
            {
                if (rebalanceListener != null) rebalanceListener.Dispose();
                if (keyDeserializer != null) keyDeserializer.Dispose();
                if (valueDeserializer != null) valueDeserializer.Dispose();
            }
        }
    }
}
