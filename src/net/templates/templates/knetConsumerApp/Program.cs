using Org.Apache.Kafka.Clients.Consumer;
using Org.Apache.Kafka.Common.Serialization;
using Java.Util;
using System;
using System.Text;
using System.Threading;
using MASES.KNet.Consumer;

namespace MASES.KNet.Template.KNetConsumer
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
            props.Put(ConsumerConfig.BOOTSTRAP_SERVERS_CONFIG, serverToUse);
            props.Put(ConsumerConfig.GROUP_ID_CONFIG, "test");
            props.Put(ConsumerConfig.ENABLE_AUTO_COMMIT_CONFIG, "true");
            props.Put(ConsumerConfig.AUTO_COMMIT_INTERVAL_MS_CONFIG, "1000");
            props.Put(ConsumerConfig.KEY_DESERIALIZER_CLASS_CONFIG, "org.apache.kafka.common.serialization.StringDeserializer");
            props.Put(ConsumerConfig.VALUE_DESERIALIZER_CLASS_CONFIG, "org.apache.kafka.common.serialization.StringDeserializer");
            *******/

            Properties props = ConsumerConfigBuilder.Create()
                                                    .WithBootstrapServers(serverToUse)
                                                    .WithGroupId("test")
                                                    .WithEnableAutoCommit(true)
                                                    .WithAutoCommitIntervalMs(1000)
                                                    .WithKeyDeserializerClass("org.apache.kafka.common.serialization.StringDeserializer")
                                                    .WithValueDeserializerClass("org.apache.kafka.common.serialization.StringDeserializer")
                                                    .ToProperties();

            ConsumerRebalanceListener rebalanceListener = null;
            Deserializer<string> keyDeserializer = null;
            Deserializer<string> valueDeserializer = null;
            try
            {
                if (useSerdes)
                {
                    keyDeserializer = new Deserializer<string>()
                    {
                        OnDeserialize = (topic, data) =>
                        {
                            var key = Encoding.Unicode.GetString(data);
                            Console.WriteLine("Received key {0} from topic {1}", key, topic);
                            return key;
                        }
                    };
                    valueDeserializer = new Deserializer<string>()
                    {
                        OnDeserialize = (topic, data) =>
                        {
                            var value = Encoding.Unicode.GetString(data);
                            Console.WriteLine("Received value {0} from topic {1}", value, topic);
                            return value;
                        }
                    };
                }

                if (useCallback)
                {
                    rebalanceListener = new ConsumerRebalanceListener()
                    {
                        OnOnPartitionsRevoked = (o) =>
                        {
                            Console.WriteLine("Revoked: {0}", o.ToString());
                        },
                        OnOnPartitionsAssigned = (o) =>
                        {
                            Console.WriteLine("Assigned: {0}", o.ToString());
                        }
                    };
                }

                Console.CancelKeyPress += Console_CancelKeyPress;
                Console.WriteLine("Press Ctrl-C to exit");

                using (var consumer = useSerdes ? new KafkaConsumer<string, string>(props, keyDeserializer, valueDeserializer) : new KafkaConsumer<string, string>(props))
                {
                    if (useCallback) consumer.Subscribe(Collections.Singleton((Java.Lang.String)topicToUse), rebalanceListener);
                    else consumer.Subscribe(Collections.Singleton((Java.Lang.String)topicToUse));

                    while (!resetEvent.WaitOne(0))
                    {
                        var records = consumer.Poll((long)TimeSpan.FromMilliseconds(200).TotalMilliseconds);
                        foreach (var item in records)
                        {
                            Console.WriteLine($"Consuming from Offset = {item.Offset()}, Key = {item.Key()}, Value = {item.Value()}");
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

        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            if (e.Cancel) resetEvent.Set();
        }
    }
}
