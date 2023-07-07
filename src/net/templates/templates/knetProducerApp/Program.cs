using MASES.KNet;
using Org.Apache.Kafka.Clients.Producer;
using Org.Apache.Kafka.Common.Serialization;
using Java.Util;
using System;
using System.Text;
using System.Threading;
using MASES.KNet.Producer;

namespace MASES.KNetTemplate.KNetProducer
{
    class LocalKNetCore : KNetCore<LocalKNetCore> { }

    class Program
    {
        const bool useSerdes = true;
        const bool useCallback = true;

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

            /**** Direct mode ******
            Properties props = new Properties();
            props.Put(ProducerConfig.BOOTSTRAP_SERVERS_CONFIG, serverToUse);
            props.Put(ProducerConfig.ACKS_CONFIG, "all");
            props.Put(ProducerConfig.RETRIES_CONFIG, 0);
            props.Put(ProducerConfig.LINGER_MS_CONFIG, 1);
            props.Put(ProducerConfig.KEY_SERIALIZER_CLASS_CONFIG, "org.apache.kafka.common.serialization.StringSerializer");
            props.Put(ProducerConfig.VALUE_SERIALIZER_CLASS_CONFIG, "org.apache.kafka.common.serialization.StringSerializer");
            ******/

            Properties props = ProducerConfigBuilder.Create()
                                                    .WithBootstrapServers(serverToUse)
                                                    .WithAcks(ProducerConfigBuilder.AcksTypes.All)
                                                    .WithRetries(0)
                                                    .WithLingerMs(1)
                                                    .WithKeySerializerClass("org.apache.kafka.common.serialization.StringSerializer")
                                                    .WithValueSerializerClass("org.apache.kafka.common.serialization.StringSerializer")
                                                    .ToProperties();

            Serializer<string> keySerializer = null;
            Serializer<string> valueSerializer = null;
            Callback callback = null;
            try
            {
                if (useSerdes)
                {
                    keySerializer = new Serializer<string>()
                    {
                        OnSerialize = (topic, data) =>
                        {
                            var key = Encoding.Unicode.GetBytes(data);
                            return null;
                        }
                    };
                    valueSerializer = new Serializer<string>()
                    {
                        OnSerialize = (topic, data) =>
                        {
                            var value = Encoding.Unicode.GetBytes(data);
                            return value;
                        }
                    };
                }
                if (useCallback)
                {
                    callback = new Callback()
                    {
                        OnOnCompletion = (o1, o2) =>
                        {
                            if (o2 != null) Console.WriteLine(o2.ToString());
                            else Console.WriteLine($"Produced on topic {o1.Topic()} at offset {o1.Offset()}");
                        }
                    };
                }

                Console.CancelKeyPress += Console_CancelKeyPress;
                Console.WriteLine("Press Ctrl-C to exit");

                using (var producer = useSerdes ? new KafkaProducer<string, string>(props, keySerializer, valueSerializer) : new KafkaProducer<string, string>(props))
                {
                    int i = 0;
                    while (!resetEvent.WaitOne(0))
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

        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            if (e.Cancel) resetEvent.Set();
        }
    }
}
