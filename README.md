# KNet: .NET suite for [Apache Kafka™](https://kafka.apache.org/)

KNet is a comprehensive .NET suite for [Apache Kafka™](https://kafka.apache.org/) providing access to all [APIs](https://kafka.apache.org/documentation/#api) and features: Producer, Consumer, Admin, Streams, Connect, backends (ZooKeeper and Kafka).

### Libraries and Tools

|KNet | KNetCLI | KNet.Templates | KNetPS | KNetConnect |
|:---:	|:---:	|:---:	|:---:	|:---:	|
|[![KNet nuget](https://img.shields.io/nuget/v/MASES.KNet)](https://www.nuget.org/packages/MASES.KNet) [![downloads](https://img.shields.io/nuget/dt/MASES.KNet)](https://www.nuget.org/packages/MASES.KNet) | [![KNetCLI nuget](https://img.shields.io/nuget/v/MASES.KNetCLI)](https://www.nuget.org/packages/MASES.KNetCLI) [![downloads](https://img.shields.io/nuget/dt/MASES.KNetCLI)](https://www.nuget.org/packages/MASES.KNetCLI) | [![KNet.Templates nuget](https://img.shields.io/nuget/v/MASES.KNet.Templates)](https://www.nuget.org/packages/MASES.KNet.Templates) [![downloads](https://img.shields.io/nuget/dt/MASES.KNet.Templates)](https://www.nuget.org/packages/MASES.KNet.Templates)| [![KNetPS](https://img.shields.io/powershellgallery/v/MASES.KNetPS.svg?style=flat-square&label=MASES.KNetPS)](https://www.powershellgallery.com/packages/MASES.KNetPS/)| [![KNetConnect nuget](https://img.shields.io/nuget/v/MASES.KNetConnect)](https://www.nuget.org/packages/MASES.KNetConnect) [![downloads](https://img.shields.io/nuget/dt/MASES.KNetConnect)](https://www.nuget.org/packages/MASES.KNetConnect) |

### Pipelines

[![CI_BUILD](https://github.com/masesgroup/KNet/actions/workflows/build.yaml/badge.svg)](https://github.com/masesgroup/KNet/actions/workflows/build.yaml)
[![CodeQL](https://github.com/masesgroup/KNet/actions/workflows/codeql-analysis.yml/badge.svg)](https://github.com/masesgroup/KNet/actions/workflows/codeql-analysis.yml)
[![CI_RELEASE](https://github.com/masesgroup/KNet/actions/workflows/release.yaml/badge.svg)](https://github.com/masesgroup/KNet/actions/workflows/release.yaml) 

### Project disclaimer

KNet is a suite for Apache Kafka™, curated by MASES Group, can be supported by the open-source community.

Its primary scope is to support other, public or internal, MASES Group projects: open-source community and commercial entities can use it for their needs and support this project, moreover there are dedicated community and commercial subscription plans.

The repository code and releases may contain bugs, the release cycle depends from Apache Kafka™ release cycle, critical discovered issues and/or enhancement requested from this or other projects.

Looking for the help of Apache Kafka™ experts? MASES Group can help you design, build, deploy, and manage Apache Kafka™ clusters and streaming applications.

---

## Scope of the project

This project aims to create a set of libraries and tools to direct access, from .NET, all the features available in the [Apache Kafka™ binary distribution](https://kafka.apache.org/downloads). 

There are many client libraries written to manage communication with Apache Kafka™. Conversely, this project use directly the Java packages released from The Apache Foundation giving more than one benefit:
* all implemented features are availables at no extra implementation costs, see [KNet usage](src/documentation/articles/usage.md);
* avoids any third party communication protocol implementation;
* access all features made available from Apache Kafka™: the most important are Apache Kafka™ Streams and Apache Kafka™ Connect which does not have any C# implementation;
* measured high [performance](src/documentation/articles/performance.md) in many operating conditions.

Currently the project tries to support, at our best, the [supported Apache Kafka™ binary distribution](https://kafka.apache.org/downloads):
- Apache Kafka™ version 3.8.*:
  - branch [master](https://github.com/masesgroup/KNet)
  - KNet version 2.8.*
- Apache Kafka™ version 3.7.*:
  - branch [release/2.7.X](https://github.com/masesgroup/KNet/tree/release/2.7.X)
  - KNet version 2.7.*
- Apache Kafka™ version 3.6.*:
  - branch [release/2.6.X](https://github.com/masesgroup/KNet/tree/release/2.6.X)
  - KNet version 2.6.*

The Apache Kafka™ packages are downloaded from:

|kafka-clients | kafka-streams | kafka-tools | kafka_2.13 |
|:---:	|:---:	|:---:	|:---:	|
|[![Maven Central](https://img.shields.io/maven-central/v/org.apache.kafka/kafka-clients.svg?label=Maven%20Central)](https://search.maven.org/search?q=g:%22org.apache.kafka%22%20AND%20a:%22kafka-clients%22) | [![Maven Central](https://img.shields.io/maven-central/v/org.apache.kafka/kafka-streams.svg?label=Maven%20Central)](https://search.maven.org/search?q=g:%22org.apache.kafka%22%20AND%20a:%22kafka-streams%22) | [![Maven Central](https://img.shields.io/maven-central/v/org.apache.kafka/kafka-tools.svg?label=Maven%20Central)](https://search.maven.org/search?q=g:%22org.apache.kafka%22%20AND%20a:%22kafka-tools%22) | [![Maven Central](https://img.shields.io/maven-central/v/org.apache.kafka/kafka_2.13.svg?label=Maven%20Central)](https://search.maven.org/search?q=g:%22org.apache.kafka%22%20AND%20a:%22kafka_2.13%22) |


|connect-runtime | connect-mirror | connect-file | connect-basic-auth-extension |
|:---:	|:---:	|:---:	|:---:	|
| [![Maven Central](https://img.shields.io/maven-central/v/org.apache.kafka/connect-runtime.svg?label=Maven%20Central)](https://search.maven.org/search?q=g:%22org.apache.kafka%22%20AND%20a:%22connect-runtime%22) | [![Maven Central](https://img.shields.io/maven-central/v/org.apache.kafka/connect-mirror.svg?label=Maven%20Central)](https://search.maven.org/search?q=g:%22org.apache.kafka%22%20AND%20a:%22connect-mirror%22) | [![Maven Central](https://img.shields.io/maven-central/v/org.apache.kafka/connect-file.svg?label=Maven%20Central)](https://search.maven.org/search?q=g:%22org.apache.kafka%22%20AND%20a:%22connect-file%22) |  [![Maven Central](https://img.shields.io/maven-central/v/org.apache.kafka/connect-basic-auth-extension.svg?label=Maven%20Central)](https://search.maven.org/search?q=g:%22org.apache.kafka%22%20AND%20a:%22connect-basic-auth-extension%22) |


### Community and Contribution

Do you like the project? 
- Request your free [community subscription](https://www.jcobridge.com/pricing-25/).

Do you want to help us?
- put a :star: on this project
- open [issues](https://github.com/masesgroup/KNet/issues) to request features or report bugs :bug:
- improves the project with Pull Requests

This project adheres to the Contributor [Covenant code of conduct](CODE_OF_CONDUCT.md). By participating, you are expected to uphold this code. Please report unacceptable behavior to coc_reporting@masesgroup.com.

## Summary

* [Roadmap](src/documentation/articles/roadmap.md)
* [Current state](src/documentation/articles/currentstate.md)
* [Performance](src/documentation/articles/performance.md)
* [Connect SDK](src/documentation/articles/connectSDK.md)
* [Streams SDK](src/documentation/articles/streamsSDK.md)
* [KNet usage](src/documentation/articles/usage.md)
* [KNet APIs extensibility](src/documentation/articles/API_extensibility.md)
* [KNet Serializer/Deserializer](src/documentation/articles/usageSerDes.md)
* [KNet CLI usage](src/documentation/articles/usageCLI.md)
* [KNet Connect usage](src/documentation/articles/usageConnect.md)
* [KNet Docker usage](src/documentation/articles/docker.md)
* [KNet PowerShell usage](src/documentation/articles/usagePS.md)
* [KNet Template usage](src/documentation/articles/usageTemplates.md)
* [How to build from scratch](src/documentation/articles/howtobuild.md)

### News

* V1.4.4+: From version 1.4.4 there is a new project, named KNetPS, which permits to write PowerShell client scripts for an Apache Kafka™ cluster and many other things, [here full usage](src/documentation/articles/usagePS.md).
* V1.4.7+: From version 1.4.7 there is a new project, named KNetConnect, to execute Apache Kafka™ Connect related jobs, [here full usage](src/documentation/articles/usageConnect.md).
* V1.5.4+: From version 1.5.4 there are new packages dedicated to [KNet Serializer/Deserializer](src/documentation/articles/usageSerDes.md)
* V2.0.0+: From version 2.0.0 the code base is fully reflected from the JARs of the Apache Kafka™ distribution downloaded from Maven; some developed classes still remains beside the specific KNet implementations
* V2.4.0+: From version 2.4.0 it is available the new KNet Streams SDK
* V2.5.0+: From version 2.5.0 there are two breaking changes: uses `Java.Lang.String` instead of `string` (`System.String`) in generated classes and KNet Streams SDK manages the counter-part JVM types
* V2.7.0+: From version 2.7.0:
  * all classes KNetProducer, KNetConsumer and KNet Streams SDK manage the counter-part JVM types
  * serializers supports data exchange based on `byte` array and `ByteBuffer`
  * version 2.7.2 introduces `ISerDesSelector` to optimize serialization selection based on `byte` array or `ByteBuffer`
* V2.8.0+: From version 2.8.0: supports Apache Kafka™ version 3.8.*

---

## Runtime engine

KNet uses [JNet](https://github.com/masesgroup/JNet), and indeed [JCOBridge](https://www.jcobridge.com/) with its [features](https://www.jcobridge.com/features/), to obtain many benefits:
* **Cyber-security**: 
  * [JVM](https://en.wikipedia.org/wiki/Java_virtual_machine) and [CLR, or CoreCLR,](https://en.wikipedia.org/wiki/Common_Language_Runtime) runs in the same process, but are insulated from each other;
  * JCOBridge does not make any code injection into JVM;
  * JCOBridge does not use any other communication mechanism than JNI;
  * .NET (CLR) inherently inherits the cyber-security levels of running JVM and Apache Kafka™; 
* **Direct access the JVM from any .NET application**: 
  * Any Java/Scala class behind Apache Kafka™ can be directly managed: Consumer, Producer, Administration, Streams, Server-side, and so on;
  * No need to learn new APIs: we try to expose the same APIs in C# style;
  * No extra validation cycle on protocol and functionality: bug fix, improvements, new features are immediately available;
  * Documentation is shared;
* **Dynamic code**: it helps to write a Java/Scala/Kotlin/etc seamless language code directly inside a standard .NET application written in C#/VB.NET: look at this [simple example](https://www.jcobridge.com/net-examples/dotnet-examples/) and [KNet APIs extensibility](src/documentation/articles/API_extensibility.md).

### JCOBridge resources

Have a look at the following JCOBridge resources:
- [Release notes](https://www.jcobridge.com/release-notes/)
- [Community Edition](https://www.jcobridge.com/pricing-25/)
- [Commercial Edition](https://www.jcobridge.com/pricing-25/)
- Latest release: [![JCOBridge nuget](https://img.shields.io/nuget/v/MASES.JCOBridge)](https://www.nuget.org/packages/MASES.JCOBridge)

KAFKA is a registered trademark of The Apache Software Foundation. KNet has no affiliation with and is not endorsed by The Apache Software Foundation.
