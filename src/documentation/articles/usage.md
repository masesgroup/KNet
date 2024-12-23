---
title: Usage of .NET suite for Apache Kafka™
_description: Describes how to use .NET suite for Apache Kafka™
---

# KNet: library usage

To use KNet classes the developer can write code in .NET using the same classes available in the official Apache Kafka™ package.
If classes or methods are not available yet it is possible to use the approach synthetized in [What to do if an API was not yet implemented](API_extensibility.md)

## Environment setup

KNet accepts many command-line switches to customize its behavior. The full list is available at [Command line switch](commandlineswitch.md) page.

### JVM identification

One of the most important command-line switch is **JVMPath** and it is available in [JCOBridge switches](https://www.jcobridge.com/net-examples/command-line-options/): it can be used to set-up the location of the JVM library if JCOBridge is not able to identify a suitable JRE/JDK installation.
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

> [!IMPORTANT]
> `pathToJVM` shall be escaped
> 1. `string pathToJVM = "C:\\Program Files\\Eclipse Adoptium\\jdk-11.0.18.10-hotspot\\bin\\server\\jvm.dll";`
> 2. `string pathToJVM = @"C:\Program Files\Eclipse Adoptium\jdk-11.0.18.10-hotspot\bin\server\jvm.dll";`

### Special initialization conditions

[JCOBridge](https://www.jcobridge.com/) try to identify a suitable JRE/JDK installation within the system using some standard mechanism of JRE/JDK: `JAVA_HOME` environment variable or Windows registry if available.
However it is possible, on Windows operating systems, that the library raises an **InvalidOperationException: Missing Java Key in registry: Couldn't find Java installed on the machine**.
This means that neither `JAVA_HOME` nor Windows registry contains information about a default installed JRE/JDK: some vendors may not setup them.
If the developer/user encounter this condition can do the following steps:
1. On a command prompt execute `set | findstr JAVA_HOME` and verify the result;
2. If something was reported maybe the `JAVA_HOME` environment variable is not set at system level, but at a different level like user level which is not visible from the KNet process that raised the exception;
3. Try to set `JAVA_HOME` at system level e.g. `JAVA_HOME=C:\Program Files\Eclipse Adoptium\jdk-11.0.18.10-hotspot\`;
4. Try to set `JCOBRIDGE_JVMPath` at system level e.g. `JCOBRIDGE_JVMPath=C:\Program Files\Eclipse Adoptium\jdk-11.0.18.10-hotspot\`.

> [!IMPORTANT]
> - One of `JCOBRIDGE_JVMPath` or `JAVA_HOME` environment variables or Windows registry (on Windows OSes) shall be available
> - `JCOBRIDGE_JVMPath` environment variable takes precedence over `JAVA_HOME` and Windows registry: you can set `JCOBRIDGE_JVMPath` to `C:\Program Files\Eclipse Adoptium\jdk-11.0.18.10-hotspot\bin\server\jvm.dll` and avoid to override `JVMPath` in your code
> - After first initialization steps, `JVMPath` takes precedence over `JCOBRIDGE_JVMPath`/`JAVA_HOME` environment variables or Windows registry

### Intel CET and KNet

KNet uses an embedded JVM through JNet/JCOBridge, however JVM initialization is incompatible with [CET](https://www.intel.com/content/www/us/en/developer/articles/technical/technical-look-control-flow-enforcement-technology.html) because the code used to identify CPU try to modify the return address and this is considered from CET a violation: see [this comment](https://github.com/masesgroup/JNet/issues/573#issuecomment-2544249107).

From .NET 9 preview 6, [CET is enabled by default on supported hardware](https://learn.microsoft.com/en-us/dotnet/core/compatibility/interop/9.0/cet-support) when the final stage produce an executable artifact, i.e. the csproj file contains `<OutputType>Exe</OutputType>`.

If the application, upon startup, fails with the error 0xc0000409 (subcode 0x30) it was compiled with CET enabled and it fails during JVM initialization.

To solve the issue there are four possible solutions:
1. use a .NET version, e.g. 8, that does not enable CET by default
2. Add the following snippet to disable CET on executable (templates available for KNet are ready made and solve this issue): 

```xml
	<PropertyGroup Condition="'$(TargetFramework)' == 'net9.0'">
		<!--see https://learn.microsoft.com/en-us/dotnet/core/compatibility/interop/9.0/cet-support-->
		<CETCompat>false</CETCompat>
	</PropertyGroup>
```

3. Use the `dotnet` app host, as reported in https://github.com/masesgroup/JCOBridgePublic/issues/7#issuecomment-2550031946, with a syntax like:

```sh
	dotnet MyApplication.dll
```
 instead of the classic:
 ```sh
	MyApplication.exe
```

4. If you want to run the classic application execute the following command:

 ```sh
	reg add "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\MyApplication.exe" /v MitigationOptions /t REG_BINARY /d "0000000000000000000000000000002000" /f
```
then run:
 ```sh
	MyApplication.exe
```

Use the following to enable again CET:

 ```sh
	reg delete "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\MyApplication.exe" /v MitigationOptions /f
```

## Producer example

Below the reader can found two different version of producer examples.

### Simple producer

A basic producer can be like the following one:

```C#
using MASES.KNet;
using Org.Apache.Kafka™.Clients.Producer;
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
using Org.Apache.Kafka™.Clients.Producer;
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
using Org.Apache.Kafka™.Clients.Consumer;
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
                var topics = Collections.Singleton(topicToUse);
                consumer.Subscribe(topics);
                while (!resetEvent.WaitOne(0))
                {
                    var records = consumer.Poll((long)TimeSpan.FromMilliseconds(200).TotalMilliseconds);
                    foreach (var item in records)
                    {
                        Console.WriteLine($"Offset = {item.Offset}, Key = {item.Key}, Value = {item.Value}");
                    }
                }
                topics?.Dispose(); // needed to avoid Java.Lang.NullPointerException in some conditions where .NET GC retires topics too early
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
