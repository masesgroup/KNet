# KNet: .NET suite for [Apache Kafka™](https://kafka.apache.org/)

KNet is a comprehensive .NET suite for [Apache Kafka™](https://kafka.apache.org/) that provides direct access to all [Apache Kafka™ APIs](https://kafka.apache.org/documentation/#api) and features: Producer, Consumer, Admin, Streams, Connect, and KRaft backend support.

KNet client-side features are also compatible with any broker that implements the Kafka wire protocol — see [Backend compatibility](#backend-compatibility) below.

### Libraries and Tools

|KNet | KNetCLI | KNet.Templates | KNetPS | KNetConnect |
|:---:	|:---:	|:---:	|:---:	|:---:	|
|[![KNet nuget](https://img.shields.io/nuget/v/MASES.KNet)](https://www.nuget.org/packages/MASES.KNet) [![downloads](https://img.shields.io/nuget/dt/MASES.KNet)](https://www.nuget.org/packages/MASES.KNet) | [![KNetCLI nuget](https://img.shields.io/nuget/v/MASES.KNetCLI)](https://www.nuget.org/packages/MASES.KNetCLI) [![downloads](https://img.shields.io/nuget/dt/MASES.KNetCLI)](https://www.nuget.org/packages/MASES.KNetCLI) | [![KNet.Templates nuget](https://img.shields.io/nuget/v/MASES.KNet.Templates)](https://www.nuget.org/packages/MASES.KNet.Templates) [![downloads](https://img.shields.io/nuget/dt/MASES.KNet.Templates)](https://www.nuget.org/packages/MASES.KNet.Templates)| [![KNetPS](https://img.shields.io/powershellgallery/v/MASES.KNetPS.svg?style=flat-square&label=MASES.KNetPS)](https://www.powershellgallery.com/packages/MASES.KNetPS/)| [![KNetConnect nuget](https://img.shields.io/nuget/v/MASES.KNetConnect)](https://www.nuget.org/packages/MASES.KNetConnect) [![downloads](https://img.shields.io/nuget/dt/MASES.KNetConnect)](https://www.nuget.org/packages/MASES.KNetConnect) |

### Pipelines

[![CI_BUILD](https://github.com/masesgroup/KNet/actions/workflows/build.yaml/badge.svg)](https://github.com/masesgroup/KNet/actions/workflows/build.yaml)
[![CodeQL](https://github.com/masesgroup/KNet/actions/workflows/codeql-analysis.yml/badge.svg)](https://github.com/masesgroup/KNet/actions/workflows/codeql-analysis.yml)
[![CI_RELEASE](https://github.com/masesgroup/KNet/actions/workflows/release.yaml/badge.svg)](https://github.com/masesgroup/KNet/actions/workflows/release.yaml) 

### Project disclaimer

KNet is a suite for Apache Kafka™, maintained by MASES Group and open to community contributions.

Its primary scope is to support other MASES Group projects — both open-source and commercial — though it is freely available for any use. Dedicated community and commercial subscription plans are available.

The repository and releases may contain bugs. The release cycle follows the Apache Kafka™ release cycle, with additional releases driven by critical issues or enhancement requests from this or other dependent projects.

Looking for Apache Kafka™ expertise? MASES Group can help you design, build, deploy, and manage Apache Kafka™ clusters and streaming applications.

---

## Scope of the project

This project aims to create a set of libraries and tools to directly access, from .NET, all the features available in the [Apache Kafka™ binary distribution](https://kafka.apache.org/downloads).

There are many client libraries written to manage communication with Apache Kafka™. Conversely, this project uses the Java™ packages released from The Apache Foundation directly, providing several benefits:

* all implemented features are available at no extra implementation costs — see [KNet usage](src/documentation/articles/usage.md);
* avoids any third-party communication protocol implementation;
* access to all features made available from Apache Kafka™: the most important are Apache Kafka™ Streams and Apache Kafka™ Connect, which have no native C# implementation;
* measured high [performance](src/documentation/articles/performance.md) in many operating conditions.

Currently the project tries to support, at our best, the [supported Apache Kafka™ binary distribution](https://kafka.apache.org/downloads):

| KNet | State | Apache Kafka™ | Branch | .NET Framework | .NET | JVM™ |
|:---:	|:---:	|:---:	|:---:	|:---:	|:---:	|:---:	|
| 3.x.x | Active | 4.x.x | [master](https://github.com/masesgroup/KNet) | [![.NET 4.6.2+](https://img.shields.io/badge/.NET-4.6.2%2B-purple)](https://dotnet.microsoft.com/) | [![.NET 8+](https://img.shields.io/badge/.NET-8%2B-purple)](https://dotnet.microsoft.com/) | [![Java 17+](https://img.shields.io/badge/Java-17%2B-blue)](https://www.oracle.com/java/) |
| 2.9.* | Active | 3.9.x | [release/2.9.X](https://github.com/masesgroup/KNet/tree/release/2.9.X) | [![.NET 4.6.2+](https://img.shields.io/badge/.NET-4.6.2%2B-purple)](https://dotnet.microsoft.com/) | [![.NET 8+](https://img.shields.io/badge/.NET-8%2B-purple)](https://dotnet.microsoft.com/) | [![Java 11+](https://img.shields.io/badge/Java-11%2B-blue)](https://www.oracle.com/java/) |
| 2.8.* | Deprecated | 3.8.* | [release/2.8.X](https://github.com/masesgroup/KNet/tree/release/2.8.X) | [![.NET 4.6.2+](https://img.shields.io/badge/.NET-4.6.2%2B-purple)](https://dotnet.microsoft.com/) | [![.NET 6+](https://img.shields.io/badge/.NET-6%2B-purple)](https://dotnet.microsoft.com/) | [![Java 11+](https://img.shields.io/badge/Java-11%2B-blue)](https://www.oracle.com/java/) |
| 2.7.* | Deprecated | 3.7.* | [release/2.7.X](https://github.com/masesgroup/KNet/tree/release/2.7.X) | [![.NET 4.6.2+](https://img.shields.io/badge/.NET-4.6.2%2B-purple)](https://dotnet.microsoft.com/) | [![.NET 6+](https://img.shields.io/badge/.NET-6%2B-purple)](https://dotnet.microsoft.com/) | [![Java 11+](https://img.shields.io/badge/Java-11%2B-blue)](https://www.oracle.com/java/) |
| 2.6.* | Deprecated | 3.6.* | [release/2.6.X](https://github.com/masesgroup/KNet/tree/release/2.6.X) | [![.NET 4.6.2+](https://img.shields.io/badge/.NET-4.6.2%2B-purple)](https://dotnet.microsoft.com/) | [![.NET 6+](https://img.shields.io/badge/.NET-6%2B-purple)](https://dotnet.microsoft.com/) | [![Java 11+](https://img.shields.io/badge/Java-11%2B-blue)](https://www.oracle.com/java/) |

The Apache Kafka™ packages are downloaded from:

|kafka-streams-scala_2.13 | kafka-tools | kafka-shell |
|:---:	|:---:	|:---:	|
|[![Maven Central](https://img.shields.io/maven-central/v/org.apache.kafka/kafka-streams-scala_2.13.svg?label=Maven%20Central)](https://search.maven.org/search?q=g:%22org.apache.kafka%22%20AND%20a:%22kafka-streams-scala_2.13%22) | [![Maven Central](https://img.shields.io/maven-central/v/org.apache.kafka/kafka-tools.svg?label=Maven%20Central)](https://search.maven.org/search?q=g:%22org.apache.kafka%22%20AND%20a:%22kafka-tools%22) | [![Maven Central](https://img.shields.io/maven-central/v/org.apache.kafka/kafka-shell.svg?label=Maven%20Central)](https://search.maven.org/search?q=g:%22org.apache.kafka%22%20AND%20a:%22kafka-shell%22) |

|connect-mirror | connect-file | connect-basic-auth-extension | trogdor |
|:---:	|:---:	|:---:	|:---:	|
| [![Maven Central](https://img.shields.io/maven-central/v/org.apache.kafka/connect-mirror.svg?label=Maven%20Central)](https://search.maven.org/search?q=g:%22org.apache.kafka%22%20AND%20a:%22connect-mirror%22) | [![Maven Central](https://img.shields.io/maven-central/v/org.apache.kafka/connect-file.svg?label=Maven%20Central)](https://search.maven.org/search?q=g:%22org.apache.kafka%22%20AND%20a:%22connect-file%22) | [![Maven Central](https://img.shields.io/maven-central/v/org.apache.kafka/connect-basic-auth-extension.svg?label=Maven%20Central)](https://search.maven.org/search?q=g:%22org.apache.kafka%22%20AND%20a:%22connect-basic-auth-extension%22) | [![Maven Central](https://img.shields.io/maven-central/v/org.apache.kafka/trogdor.svg?label=Maven%20Central)](https://search.maven.org/search?q=g:%22org.apache.kafka%22%20AND%20a:%22trogdor%22) |

---

## Backend compatibility

KNet uses the official Apache Kafka™ Java client packages directly. This architecture has a direct impact on backend compatibility: **not all KNet features have the same compatibility scope**.

**Client-side features** — Producer, Consumer, Admin Client, Kafka Streams, KNet Streams SDK, KNet Connect SDK, KNetPS scriptable cmdlets — communicate with the broker exclusively through the Kafka wire protocol and are therefore compatible with **any broker that implements it**, not only Apache Kafka™ itself.

Examples of compatible brokers: [Redpanda](https://redpanda.com/), [Amazon MSK](https://aws.amazon.com/msk/), [Confluent Platform / Cloud](https://www.confluent.io/), [Aiven for Apache Kafka™](https://aiven.io/kafka), [IBM Event Streams](https://www.ibm.com/products/event-streams), [WarpStream](https://www.warpstream.com/), [AutoMQ](https://www.automq.com/), and others.

> **Important**: KNet also includes **server-side features** to start and manage Apache Kafka™ broker nodes, ZooKeeper™ nodes, and KRaft controllers (via KNetCLI, KNetPS, and Docker images). These features are specific to Apache Kafka™ and are not applicable to alternative brokers.

See [Supported Backends](src/documentation/articles/backends.md) for the full compatibility matrix covering all KNet feature areas.

---

### Community and contributions

If you find KNet useful:

* Leave a ⭐ on the repository
* Open [issues](https://github.com/masesgroup/KNet/issues) to report bugs 🐛 or request features
* Submit Pull Requests to improve the project

This project adheres to the Contributor [Covenant code of conduct](https://github.com/masesgroup/KNet/blob/master/CODE_OF_CONDUCT.md). By participating, you are expected to uphold this code. Please report unacceptable behavior to coc_reporting@masesgroup.com.

## Summary

* [Roadmap](src/documentation/articles/roadmap.md)
* [Current state](src/documentation/articles/currentstate.md)
* [Supported backends](src/documentation/articles/backends.md)
* [Performance](src/documentation/articles/performance.md)
* [Connect SDK](src/documentation/articles/connectSDK.md)
* [Streams SDK](src/documentation/articles/streamsSDK.md)
* [RocksDB configuration](src/documentation/articles/rocksdb_configuration.md)
* [KNet usage](src/documentation/articles/usage.md)
* [KNet APIs extensibility](src/documentation/articles/API_extensibility.md)
* [KNet Serializer/Deserializer](src/documentation/articles/usageSerDes.md)
* [KNet CLI usage](src/documentation/articles/usageCLI.md)
* [KNet Connect usage](src/documentation/articles/usageConnect.md)
* [KNet Docker usage](src/documentation/articles/docker.md)
* [KNet PowerShell usage](src/documentation/articles/usagePS.md)
* [KNet Template usage](src/documentation/articles/usageTemplates.md)
* [How to build from scratch](src/documentation/articles/howtobuild.md)

### Recent changes

* **V3.0.3+ / 2.9.4+**: KNet Connect SDK now supports JVM hosted runtime — KNet Connect SDK connectors can be deployed and used like any other JVM-based connector in a standard Kafka Connect cluster; [here full usage](src/documentation/articles/usageConnect.md).
* **V2.7.0+**:
  + KNetProducer, KNetConsumer, and KNet Streams SDK manage JVM™ counter-part types;
  + serializers support data exchange based on `byte` array and `ByteBuffer`;
  + version 2.7.2 introduces `ISerDesSelector` to optimize serialization selection based on `byte` array or `ByteBuffer`.
* **V2.5.0+**: two breaking changes — uses `Java.Lang.String` instead of `string` (`System.String`) in generated classes; KNet Streams SDK manages JVM™ counter-part types.
* **V2.4.0+**: new KNet Streams SDK available.
* **V2.0.0+**: code base fully reflected from the Apache Kafka™ JARs downloaded from Maven; some developed classes remain alongside the specific KNet implementations.
* **V1.5.4+**: new packages dedicated to [KNet Serializer/Deserializer](src/documentation/articles/usageSerDes.md).
* **V1.4.7+**: new KNetConnect project to execute Apache Kafka™ Connect related jobs; [here full usage](src/documentation/articles/usageConnect.md).
* **V1.4.4+**: new KNetPS project — write PowerShell client scripts for an Apache Kafka™ cluster and more; [here full usage](src/documentation/articles/usagePS.md).

---

## Runtime engine

KNet uses [JNet](https://github.com/masesgroup/JNet), and indeed [JCOBridge](https://www.jcobridge.com/) with its [features](https://www.jcobridge.com/features/), as its runtime engine to bridge the JVM™ and the .NET CLR within the same process:

* **Cyber-security**:
  + [JVM™](https://en.wikipedia.org/wiki/Java_virtual_machine) and [CLR, or CoreCLR,](https://en.wikipedia.org/wiki/Common_Language_Runtime) run in the same process, but are isolated from each other;
  + JCOBridge does not make any code injection into JVM™;
  + JCOBridge does not use any other communication mechanism than JNI;
  + .NET (CLR) inherits the cyber-security levels of the running JVM™ and Apache Kafka™;
* **Direct access to the JVM™ from any .NET application**:
  + Any Java™/Scala class behind Apache Kafka™ can be directly managed: Consumer, Producer, Administration, Streams, Connect, and server-side classes;
  + No need to learn new APIs: the same APIs are exposed in C# style;
  + No extra validation cycle on protocol and functionality: bug fixes, improvements, and new features are immediately available;
  + Documentation is shared between Java™ and .NET;
* **Dynamic code**: enables writing Java™/Scala/Kotlin code seamlessly within a standard .NET application in C#/VB.NET — see this [simple example](https://www.jcobridge.com/net-examples/dotnet-examples/) and [KNet APIs extensibility](src/documentation/articles/API_extensibility.md).

> [!NOTE]
> [JCOBridge 2.6.\*](https://www.jcobridge.com) can be used for free without any obligations. A commercial license must be purchased — or the software uninstalled — if you derive direct or indirect income from its usage.

### JCOBridge resources

| JCOBridge | 2.5.\* series | 2.6.\* series |
| --- | --- | --- |
| KNet | > 1.5.\* series | > 3.0.\* series and latest 2.9.\* series |
| Release notes | [Link](https://www.jcobridge.com/release-notes/) | [Link](https://www.jcobridge.com/release-notes/) |
| Community Edition | [Conditions](https://www.jcobridge.com/pricing-25/) | [Conditions](https://www.jcobridge.com/pricing-26/) |
| Commercial Edition | [Information](https://www.jcobridge.com/pricing-25/) | [Information](https://www.jcobridge.com/pricing-26/) |

Latest release: [![JCOBridge nuget](https://img.shields.io/nuget/v/MASES.JCOBridge)](https://www.nuget.org/packages/MASES.JCOBridge)

KAFKA is a registered trademark of The Apache Software Foundation. KNet has no affiliation with and is not endorsed by The Apache Software Foundation.
