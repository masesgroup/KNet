# Welcome to KafkaBridge

KafkaBridge is a .NET mirror of [Apache Kafka](https://kafka.apache.org/) [APIs](https://kafka.apache.org/documentation/#api) providing all features: Producer, Consumer, Admin, Streams, Connect, ZooKeeper, Kafka backend.

This project adheres to the Contributor [Covenant code of conduct](CODE_OF_CONDUCT.md). By participating, you are expected to uphold this code. Please report unacceptable behavior to coc_reporting@masesgroup.com.

## Scope of the project

This project aims to create a library to direct access, from .NET, all the features available in the [Apache Kafka binary distribution](https://kafka.apache.org/downloads). The packages are downloaded from:

|kafka-clients | kafka-streams | kafka-tools | kafka_2.13 | connect-runtime |
|---	|---	|---	|---	|---	|
|[![Maven Central](https://img.shields.io/maven-central/v/org.apache.kafka/kafka-clients.svg?label=Maven%20Central)](https://search.maven.org/search?q=g:%22org.apache.kafka%22%20AND%20a:%22kafka-clients%22) | [![Maven Central](https://img.shields.io/maven-central/v/org.apache.kafka/kafka-streams.svg?label=Maven%20Central)](https://search.maven.org/search?q=g:%22org.apache.kafka%22%20AND%20a:%22kafka-streams%22) | [![Maven Central](https://img.shields.io/maven-central/v/org.apache.kafka/kafka-tools.svg?label=Maven%20Central)](https://search.maven.org/search?q=g:%22org.apache.kafka%22%20AND%20a:%22kafka-tools%22) | [![Maven Central](https://img.shields.io/maven-central/v/org.apache.kafka/kafka_2.13.svg?label=Maven%20Central)](https://search.maven.org/search?q=g:%22org.apache.kafka%22%20AND%20a:%22kafka_2.13%22) | [![Maven Central](https://img.shields.io/maven-central/v/org.apache.kafka/connect-runtime.svg?label=Maven%20Central)](https://search.maven.org/search?q=g:%22org.apache.kafka%22%20AND%20a:%22connect-runtime%22) |

There are many client libraries written to manage communication with Apache Kafka. Conversely, this project use directly the Java packages released from The Apache Foundation giving more than one benefit:
* all implemented features are availables at no extra implementation costs, see [KafkaBridge usage](articles/usage.md);
* avoids any third party communication protocol implementation;
* access all features made available from Apache Kafka: the most important one is Kafka Streams which does not have any C# implementation.

## Runtime engine

KafkaBridge uses [JCOBridge](https://www.jcobridge.com), and its [features](https://www.jcobridge.com/features/), to obtain many benefits:
* **Cyber-security**: 
  * [JVM](https://en.wikipedia.org/wiki/Java_virtual_machine) and [CLR, or CoreCLR,](https://en.wikipedia.org/wiki/Common_Language_Runtime) runs in the same process, but are insulated from each other;
  * JCOBridge does not make any code injection into JVM;
  * JCOBridge does not use any other communication mechanism than JNI;
  * .NET (CLR) inherently inherits the cyber-security levels of running JVM and Apache Kafka; 
* **Direct access the JVM from any .NET application**: 
  * Any Java/Scala class behind Apache Kafka can be directly managed: Consumer, Producer, Administration, Streams, Server-side, and so on;
  * No need to learn new APIs: we try to expose the same APIs in C# style;
  * No extra validation cycle on protocol and functionality: bug fix, improvements, new features are immediately available;
  * Documentation is shared;
* **Dynamic code**: it helps to write a Java/Scala/Kotlin/etc seamless language code directly inside a standard .NET application written in C#/VB.NET: look at this [simple example](https://www.jcobridge.com/net-examples/dotnet-examples/) and [KafkaBridge APIs extensibility](articles/API_extensibility.md).

Have a look at [![latest version](https://img.shields.io/nuget/v/MASES.JCOBridge)](https://www.nuget.org/packages/MASES.JCOBridge); plus look at the following resources:
- [Release notes](https://www.jcobridge.com/release-notes/)
- [Commercial info](https://www.jcobridge.com/pricing/)

---
## Summary

* [Roadmap](articles/roadmap.md)
* [Actual state](articles/actualstate.md)
* [KafkaBridge usage](articles/usage.md)
* [KafkaBridge APIs extensibility](articles/API_extensibility.md)
* [KafkaBridgeCLI usage](articles/usageCLI.md)

---
