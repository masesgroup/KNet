# KNet: .NET gateway for Apache Kafka APIs

[![CI_BUILD](https://github.com/masesgroup/KNet/actions/workflows/build.yaml/badge.svg)](https://github.com/masesgroup/KNet/actions/workflows/build.yaml)
[![CI_PULLREQUEST](https://github.com/masesgroup/KNet/actions/workflows/pullrequest.yaml/badge.svg)](https://github.com/masesgroup/KNet/actions/workflows/pullrequest.yaml)
[![CodeQL](https://github.com/masesgroup/KNet/actions/workflows/codeql-analysis.yml/badge.svg)](https://github.com/masesgroup/KNet/actions/workflows/codeql-analysis.yml)
[![CI_RELEASE](https://github.com/masesgroup/KNet/actions/workflows/release.yaml/badge.svg)](https://github.com/masesgroup/KNet/actions/workflows/release.yaml) 

|KNet | KNetCLI | KNet.Templates |
|---	|---	|---	|
|[![KNet nuget](https://img.shields.io/nuget/v/MASES.KNet)](https://www.nuget.org/packages/MASES.KNet) [![downloads](https://img.shields.io/nuget/dt/MASES.KNet)](https://www.nuget.org/packages/MASES.KNet) | [![KNetCLI nuget](https://img.shields.io/nuget/v/MASES.KNetCLI)](https://www.nuget.org/packages/MASES.KNetCLI) [![downloads](https://img.shields.io/nuget/dt/MASES.KNetCLI)](https://www.nuget.org/packages/MASES.KNetCLI) | [![KNet.Templates nuget](https://img.shields.io/nuget/v/MASES.KNet.Templates)](https://www.nuget.org/packages/MASES.KNet.Templates) [![downloads](https://img.shields.io/nuget/dt/MASES.KNet.Templates)](https://www.nuget.org/packages/MASES.KNet.Templates)|

KNet is a .NET gateway for [Apache Kafka](https://kafka.apache.org/) [APIs](https://kafka.apache.org/documentation/#api) providing all features: Producer, Consumer, Admin, Streams, Connect, backends (ZooKeeper and Kafka).

This project adheres to the Contributor [Covenant code of conduct](CODE_OF_CONDUCT.md). By participating, you are expected to uphold this code. Please report unacceptable behavior to coc_reporting@masesgroup.com.

## Scope of the project

This project aims to create a library to direct access, from .NET, all the features available in the [Apache Kafka binary distribution](https://kafka.apache.org/downloads). The packages are downloaded from:

|kafka-clients | kafka-streams | kafka-tools | kafka_2.13 | connect-runtime | connect-mirror | connect-file | connect-basic-auth-extension |
|---	|---	|---	|---	|---	|---	|---	|---	|
|[![Maven Central](https://img.shields.io/maven-central/v/org.apache.kafka/kafka-clients.svg?label=Maven%20Central)](https://search.maven.org/search?q=g:%22org.apache.kafka%22%20AND%20a:%22kafka-clients%22) | [![Maven Central](https://img.shields.io/maven-central/v/org.apache.kafka/kafka-streams.svg?label=Maven%20Central)](https://search.maven.org/search?q=g:%22org.apache.kafka%22%20AND%20a:%22kafka-streams%22) | [![Maven Central](https://img.shields.io/maven-central/v/org.apache.kafka/kafka-tools.svg?label=Maven%20Central)](https://search.maven.org/search?q=g:%22org.apache.kafka%22%20AND%20a:%22kafka-tools%22) | [![Maven Central](https://img.shields.io/maven-central/v/org.apache.kafka/kafka_2.13.svg?label=Maven%20Central)](https://search.maven.org/search?q=g:%22org.apache.kafka%22%20AND%20a:%22kafka_2.13%22) | [![Maven Central](https://img.shields.io/maven-central/v/org.apache.kafka/connect-runtime.svg?label=Maven%20Central)](https://search.maven.org/search?q=g:%22org.apache.kafka%22%20AND%20a:%22connect-runtime%22) | [![Maven Central](https://img.shields.io/maven-central/v/org.apache.kafka/connect-mirror.svg?label=Maven%20Central)](https://search.maven.org/search?q=g:%22org.apache.kafka%22%20AND%20a:%22connect-mirror%22) | [![Maven Central](https://img.shields.io/maven-central/v/org.apache.kafka/connect-file.svg?label=Maven%20Central)](https://search.maven.org/search?q=g:%22org.apache.kafka%22%20AND%20a:%22connect-file%22) |  [![Maven Central](https://img.shields.io/maven-central/v/org.apache.kafka/connect-basic-auth-extension.svg?label=Maven%20Central)](https://search.maven.org/search?q=g:%22org.apache.kafka%22%20AND%20a:%22connect-basic-auth-extension%22) |

There are many client libraries written to manage communication with Apache Kafka. Conversely, this project use directly the Java packages released from The Apache Foundation giving more than one benefit:
* all implemented features are availables at no extra implementation costs, see [KNet usage](src/net/Documentation/articles/usage.md);
* avoids any third party communication protocol implementation;
* access all features made available from Apache Kafka: the most important are Apache Kafka Streams and Apache Kafka Connect which does not have any C# implementation;
* measured high [performance](src/net/Documentation/articles/performance.md) in many operating conditions.

## Runtime engine

KNet uses [JNet](https://github.com/masesgroup/JNet), and indeed [JCOBridge](https://www.jcobridge.com/) with its [features](https://www.jcobridge.com/features/), to obtain many benefits:
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
* **Dynamic code**: it helps to write a Java/Scala/Kotlin/etc seamless language code directly inside a standard .NET application written in C#/VB.NET: look at this [simple example](https://www.jcobridge.com/net-examples/dotnet-examples/) and [KNet APIs extensibility](src/net/Documentation/articles/API_extensibility.md).

Have a look at the following resources:
- [Release notes](https://www.jcobridge.com/release-notes/)
- [Non Profit or University](https://www.jcobridge.com/pricing/)
- [Commercial info: Professional or Enterprise](https://www.jcobridge.com/pricing/)
- [![JCOBridge nuget](https://img.shields.io/nuget/v/MASES.JCOBridge)](https://www.nuget.org/packages/MASES.JCOBridge)

---
## Summary

* [Roadmap](src/net/Documentation/articles/roadmap.md)
* [Actual state](src/net/Documentation/articles/actualstate.md)
* [Performance](src/net/Documentation/articles/performance.md)
* [Connect SDK](src/net/Documentation/articles/connectSDK.md)
* [KNet usage](src/net/Documentation/articles/usage.md)
* [KNet APIs extensibility](src/net/Documentation/articles/API_extensibility.md)
* [KNetCLI usage](src/net/Documentation/articles/usageCLI.md)
* [Template Usage Guide](src/net/Documentation/articles/usageTemplates.md)
* [How to build from scratch](src/net/Documentation/articles/howtobuild.md)

---

KAFKA is a registered trademark of The Apache Software Foundation. KNet has no affiliation with and is not endorsed by The Apache Software Foundation.
