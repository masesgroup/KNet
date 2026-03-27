---
title: .NET suite for Apache Kafka™
_description: Main page of .NET suite for Apache Kafka™
---

# KNet: .NET suite for [Apache Kafka™](https://kafka.apache.org/)

KNet is a comprehensive .NET suite for [Apache Kafka™](https://kafka.apache.org/) that provides direct access to all [Apache Kafka™ APIs](https://kafka.apache.org/documentation/#api) and features: Producer, Consumer, Admin, Streams, Connect, and KRaft backend support.

KNet client-side features are also compatible with any broker that implements the Kafka wire protocol — see [Backend compatibility](#backend-compatibility) below.

### Libraries and Tools

| KNet | KNetCLI | KNet.Templates | KNetPS | KNetConnect |
| --- | --- | --- | --- | --- |
|[![KNet nuget](https://img.shields.io/nuget/v/MASES.KNet)](https://www.nuget.org/packages/MASES.KNet) [![downloads](https://img.shields.io/nuget/dt/MASES.KNet)](https://www.nuget.org/packages/MASES.KNet) | [![KNetCLI nuget](https://img.shields.io/nuget/v/MASES.KNetCLI)](https://www.nuget.org/packages/MASES.KNetCLI) [![downloads](https://img.shields.io/nuget/dt/MASES.KNetCLI)](https://www.nuget.org/packages/MASES.KNetCLI) | [![KNet.Templates nuget](https://img.shields.io/nuget/v/MASES.KNet.Templates)](https://www.nuget.org/packages/MASES.KNet.Templates) [![downloads](https://img.shields.io/nuget/dt/MASES.KNet.Templates)](https://www.nuget.org/packages/MASES.KNet.Templates)| [![KNetPS](https://img.shields.io/powershellgallery/v/MASES.KNetPS.svg?style=flat-square&label=MASES.KNetPS)](https://www.powershellgallery.com/packages/MASES.KNetPS/)| [![KNetConnect nuget](https://img.shields.io/nuget/v/MASES.KNetConnect)](https://www.nuget.org/packages/MASES.KNetConnect) [![downloads](https://img.shields.io/nuget/dt/MASES.KNetConnect)](https://www.nuget.org/packages/MASES.KNetConnect) |

### Project disclaimer

KNet is a suite for Apache Kafka™, maintained by MASES Group and open to community contributions.
Its primary scope is to support other MASES Group projects — both open-source and commercial — though it is freely available for any use. Dedicated community and commercial subscription plans are available.
The repository and releases may contain bugs. The release cycle follows the Apache Kafka™ release cycle, with additional releases driven by critical issues or enhancement requests from this or other dependent projects.

Looking for Apache Kafka™ expertise? MASES Group can help you design, build, deploy, and manage Apache Kafka™ clusters and streaming applications. [Find out more.](support.md)

---

## Scope of the project

This project aims to create a set of libraries and tools to directly access, from .NET, all the features available in the [Apache Kafka™ binary distribution](https://kafka.apache.org/downloads).

There are many client libraries written to manage communication with Apache Kafka™. Conversely, this project uses the Java™ packages released from The Apache Foundation directly, providing several benefits:

* all implemented features are available at no extra implementation costs — see [KNet usage](articles/usage.md);
* avoids any third-party communication protocol implementation;
* access to all features made available from Apache Kafka™: the most important are Apache Kafka™ Streams and Apache Kafka™ Connect, which have no native C# implementation;
* measured high [performance](articles/performance.md) in many operating conditions.

Currently the project tries to support, at our best, the [supported Apache Kafka™ binary distribution](https://kafka.apache.org/downloads):

| KNet | State | Apache Kafka™ | Branch | .NET Framework | .NET | JVM™ |
| --- | --- | --- | --- | --- | --- | --- |
| 3.x.x | Active | 4.x.x | [master](https://github.com/masesgroup/KNet) | [![.NET 4.6.2+](https://img.shields.io/badge/.NET-4.6.2%2B-purple)](https://dotnet.microsoft.com/) | [![.NET 8+](https://img.shields.io/badge/.NET-8%2B-purple)](https://dotnet.microsoft.com/) | [![Java 17+](https://img.shields.io/badge/Java-17%2B-blue)](https://www.oracle.com/java/) |
| 2.9.* | Active | 3.9.x | [release/2.9.X](https://github.com/masesgroup/KNet/tree/release/2.9.X) | [![.NET 4.6.2+](https://img.shields.io/badge/.NET-4.6.2%2B-purple)](https://dotnet.microsoft.com/) | [![.NET 8+](https://img.shields.io/badge/.NET-8%2B-purple)](https://dotnet.microsoft.com/) | [![Java 11+](https://img.shields.io/badge/Java-11%2B-blue)](https://www.oracle.com/java/) |
| 2.8.* | Deprecated | 3.8.* | [release/2.8.X](https://github.com/masesgroup/KNet/tree/release/2.8.X) | [![.NET 4.6.2+](https://img.shields.io/badge/.NET-4.6.2%2B-purple)](https://dotnet.microsoft.com/) | [![.NET 6+](https://img.shields.io/badge/.NET-6%2B-purple)](https://dotnet.microsoft.com/) | [![Java 11+](https://img.shields.io/badge/Java-11%2B-blue)](https://www.oracle.com/java/) |
| 2.7.* | Deprecated | 3.7.* | [release/2.7.X](https://github.com/masesgroup/KNet/tree/release/2.7.X) | [![.NET 4.6.2+](https://img.shields.io/badge/.NET-4.6.2%2B-purple)](https://dotnet.microsoft.com/) | [![.NET 6+](https://img.shields.io/badge/.NET-6%2B-purple)](https://dotnet.microsoft.com/) | [![Java 11+](https://img.shields.io/badge/Java-11%2B-blue)](https://www.oracle.com/java/) |
| 2.6.* | Deprecated | 3.6.* | [release/2.6.X](https://github.com/masesgroup/KNet/tree/release/2.6.X) | [![.NET 4.6.2+](https://img.shields.io/badge/.NET-4.6.2%2B-purple)](https://dotnet.microsoft.com/) | [![.NET 6+](https://img.shields.io/badge/.NET-6%2B-purple)](https://dotnet.microsoft.com/) | [![Java 11+](https://img.shields.io/badge/Java-11%2B-blue)](https://www.oracle.com/java/) |

The Apache Kafka™ packages are downloaded from:

| kafka-streams-scala\_2.13 | kafka-tools | kafka-shell |
| --- | --- | --- |
|[![Maven Central](https://img.shields.io/maven-central/v/org.apache.kafka/kafka-streams-scala_2.13.svg?label=Maven%20Central)](https://search.maven.org/search?q=g:%22org.apache.kafka%22%20AND%20a:%22kafka-streams-scala_2.13%22) | [![Maven Central](https://img.shields.io/maven-central/v/org.apache.kafka/kafka-tools.svg?label=Maven%20Central)](https://search.maven.org/search?q=g:%22org.apache.kafka%22%20AND%20a:%22kafka-tools%22) | [![Maven Central](https://img.shields.io/maven-central/v/org.apache.kafka/kafka-shell.svg?label=Maven%20Central)](https://search.maven.org/search?q=g:%22org.apache.kafka%22%20AND%20a:%22kafka-shell%22) |
| connect-mirror | connect-file | connect-basic-auth-extension | trogdor |
| --- | --- | --- | --- |
| [![Maven Central](https://img.shields.io/maven-central/v/org.apache.kafka/connect-mirror.svg?label=Maven%20Central)](https://search.maven.org/search?q=g:%22org.apache.kafka%22%20AND%20a:%22connect-mirror%22) | [![Maven Central](https://img.shields.io/maven-central/v/org.apache.kafka/connect-file.svg?label=Maven%20Central)](https://search.maven.org/search?q=g:%22org.apache.kafka%22%20AND%20a:%22connect-file%22) | [![Maven Central](https://img.shields.io/maven-central/v/org.apache.kafka/connect-basic-auth-extension.svg?label=Maven%20Central)](https://search.maven.org/search?q=g:%22org.apache.kafka%22%20AND%20a:%22connect-basic-auth-extension%22) | [![Maven Central](https://img.shields.io/maven-central/v/org.apache.kafka/trogdor.svg?label=Maven%20Central)](https://search.maven.org/search?q=g:%22org.apache.kafka%22%20AND%20a:%22trogdor%22) |

---

## Backend compatibility

KNet uses the official Apache Kafka™ Java client packages directly. This architecture has a direct impact on backend compatibility: **not all KNet features have the same compatibility scope**.

**Client-side features** — Producer, Consumer, Admin Client, Kafka Streams, KNet Streams SDK, KNet Connect SDK, KNetPS scriptable cmdlets — communicate with the broker exclusively through the Kafka wire protocol and are therefore compatible with **any broker that implements it**, not only Apache Kafka™ itself.

Examples of compatible brokers: [Redpanda](https://redpanda.com/), [Amazon MSK](https://aws.amazon.com/msk/), [Confluent Platform / Cloud](https://www.confluent.io/), [Aiven for Apache Kafka™](https://aiven.io/kafka), [IBM Event Streams](https://www.ibm.com/products/event-streams), [WarpStream](https://www.warpstream.com/), [AutoMQ](https://www.automq.com/), and others.

> **Important**: KNet also includes **server-side features** to start and manage Apache Kafka™ broker nodes, ZooKeeper™ nodes, and KRaft controllers (via KNetCLI, KNetPS, and Docker images). These features are specific to Apache Kafka™ and are not applicable to alternative brokers.

See [Supported Backends](articles/backends.md) for the full compatibility matrix covering all KNet feature areas.

---

### Community and contributions

If you find KNet useful:

* Leave a ⭐ on the repository
* Open [issues](https://github.com/masesgroup/KNet/issues) to report bugs 🐛 or request features
* Submit Pull Requests to improve the project

This project adheres to the Contributor [Covenant code of conduct](https://github.com/masesgroup/KNet/blob/master/CODE_OF_CONDUCT.md). By participating, you are expected to uphold this code. Please report unacceptable behavior to coc_reporting@masesgroup.com.
