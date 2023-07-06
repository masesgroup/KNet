# KNet: library usage

To use KNet classes the developer can write code in .NET using the same classes available in the official Apache Kafka package.
If classes or methods are not available yet it is possible to use the approach synthetized in [What to do if an API was not yet implemented](API_extensibility.md)

## Environment setup

KNet accepts many command-line switches to customize its behavior. The full list is available at [Command line switch](commandlineswitch.md) page.

### JVM identification

One of the most important command-line switch is **JVMPath** and it is available in [JCOBridge switches](https://www.jcobridge.com/net-examples/command-line-options/): it can be used to set-up the location of the JVM library if JCOBridge is not able to identify a suitable JRE installation.
If a developer is using KNet within its own product it is possible to override the **JVMPath** property with a snippet like the following one:

```c#
    class MyKNetCore : KNetCore
    {
        public override string JVMPath
        {
            get
            {
                string pathToJVM = "Set here the path to JVM library or use your own search method";
                return pathToJVM;
            }
        }
    }
```

## Producer example

Below the reader can found two different version of producer examples.

### Simple producer

A basic producer can be like the following one:

```C#
using MASES.KNet;
using Org.Apache.Kafka.Clients.Producer;
using Java.Util;
using System;
using System.Threading;

namespace MASES.KNetTemplate.KNetProducer
{
    class Program
    {
        const string theServer = "localhost:9092";
        const string theTopic = "myTopic";

        static string serverToUse = theServer;
        static string topicToUse = theTopic;

        static readonly ManualResetEvent resetEvent = new ManualResetEvent(false);

        static void Main(string[] args)
        {
            KNetCore.CreateGlobalInstance();
            var appArgs = KNetCore.FilteredArgs;

            if (appArgs.Length != 0)
            {
                serverToUse = args[0];
            }

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
                                                    .WithAcks(ProducerConfig.Acks.All)
                                                    .WithRetries(0)
                                                    .WithLingerMs(1)
                                                    .WithKeySerializerClass("org.apache.kafka.common.serialization.StringSerializer")
                                                    .WithValueSerializerClass("org.apache.kafka.common.serialization.StringSerializer")
                                                    .ToProperties();

            Console.CancelKeyPress += Console_CancelKeyPress;
            Console.WriteLine("Press Ctrl-C to exit");

			using (KafkaProducer producer = new KafkaProducer(props))
			{
				int i = 0;
				while (!resetEvent.WaitOne(0))
				{
					var record = new ProducerRecord<string, string>(topicToUse, i.ToString(), i.ToString());
					var result = producer.Send(record);
					Console.WriteLine($"Producing: {record} with result: {result.Get()}");
					producer.Flush();
					i++;
				}
			}
        }

        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            if (e.Cancel) resetEvent.Set();
        }
    }
}
```

The example above can be found in the [templates package](https://www.nuget.org/packages/MASES.KNet.Templates/). Its behavior is:
* during initialization prepares the properties, 
* create a producer using the properties
* create ProducerRecord and send it
* print out the produced data and the resulting RecordMetadata

### Producer with Callback

A producer with Callback can be like the following one. In this example the reader can highlight a slightly difference from the corresponding Java code.
Surf [JVM callbacks]() to go into detail in the callback management from JVM.

```C#
using MASES.KNet;
using Org.Apache.Kafka.Clients.Producer;
using Java.Util;
using System;
using System.Threading;

namespace MASES.KNetTemplate.KNetProducer
{
    class Program
    {
        const string theServer = "localhost:9092";
        const string theTopic = "myTopic";

        static string serverToUse = theServer;
        static string topicToUse = theTopic;

        static readonly ManualResetEvent resetEvent = new ManualResetEvent(false);

        static void Main(string[] args)
        {
            KNetCore.CreateGlobalInstance();
            var appArgs = KNetCore.FilteredArgs;

            if (appArgs.Length != 0)
            {
                serverToUse = args[0];
            }

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
                                                    .WithAcks(ProducerConfig.Acks.All)
                                                    .WithRetries(0)
                                                    .WithLingerMs(1)
                                                    .WithKeySerializerClass("org.apache.kafka.common.serialization.StringSerializer")
                                                    .WithValueSerializerClass("org.apache.kafka.common.serialization.StringSerializer")
                                                    .ToProperties();

            Console.CancelKeyPress += Console_CancelKeyPress;
            Console.WriteLine("Press Ctrl-C to exit");

			using (KafkaProducer producer = new KafkaProducer(props))
			{
				int i = 0;
				using (var callback = new Callback((o1, o2) =>
				{
					if (o2 != null) Console.WriteLine(o2.ToString());
					else Console.WriteLine($"Produced on topic {o1.Topic} at offset {o1.Offset}");
				}))
				{
					while (!resetEvent.WaitOne(0))
					{
						var record = new ProducerRecord<string, string>(topicToUse, i.ToString(), i.ToString());
						var result = producer.Send(record, callback);
						Console.WriteLine($"Producing: {record} with result: {result.Get()}");
						producer.Flush();
						i++;
					}
				}
			}
        }

        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            if (e.Cancel) resetEvent.Set();
        }
    }
}
```

The example above can be found in the [templates package](https://www.nuget.org/packages/MASES.KNet.Templates/). Its behavior is:
* during initialization prepares the properties
* create a producer using the properties
* create ProducerRecord and send it using the API Send with the attached Callback
* when the operation completed the Callback is called:
  * if an Exception was raised it will be printed out 
  * otherwise the RecordMetadata is printed out
* print out the produced data and the resulting RecordMetadata

## Consumer example

A basic consumer can be like the following one:

```C#
using MASES.KNet;
using Org.Apache.Kafka.Clients.Consumer;
using Java.Util;
using System;

namespace MASES.KNetTemplate.KNetConsumer
{
    class Program
    {
        const string theServer = "localhost:9092";
        const string theTopic = "myTopic";

        static string serverToUse = theServer;
        static string topicToUse = theTopic;

        static readonly ManualResetEvent resetEvent = new ManualResetEvent(false);

        static void Main(string[] args)
        {
            KNetCore.CreateGlobalInstance();
            var appArgs = KNetCore.FilteredArgs;

            if (appArgs.Length != 0)
            {
                serverToUse = args[0];
            }

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

            Console.CancelKeyPress += Console_CancelKeyPress;
            Console.WriteLine("Press Ctrl-C to exit");

            using (var consumer = new KafkaConsumer<string, string>(props))
            {
                consumer.Subscribe(Collections.singleton(topicToUse));
                while (!resetEvent.WaitOne(0))
                {
                    var records = consumer.Poll((long)TimeSpan.FromMilliseconds(200).TotalMilliseconds);
                    foreach (var item in records)
                    {
                        Console.WriteLine($"Offset = {item.Offset}, Key = {item.Key}, Value = {item.Value}");
                    }
                }
            }
        }

        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            if (e.Cancel) resetEvent.Set();
        }
    }
}
```

The example above can be found in the [templates package](https://www.nuget.org/packages/MASES.KNet.Templates/). Its behavior is:
* during initialization prepares the properties, 
* create a consumer using the properties
* subscribe and starts consume
* when data are received it logs to the console the information.
