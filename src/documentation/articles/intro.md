---
title: .NET suite for Apache Kafka™
_description: Main page of .NET suite for Apache Kafka™
---

# KNet: .NET suite for [Apache Kafka™](https://kafka.apache.org/)

KNet is a comprehensive .NET suite for [Apache Kafka™](https://kafka.apache.org/) providing access to all [APIs](https://kafka.apache.org/documentation/#api) and features: Producer, Consumer, Admin, Streams, Connect, backends (KRaft™).

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
* all implemented features are availables at no extra implementation costs, see [KNet usage](usage.md);
* avoids any third party communication protocol implementation;
* access all features made available from Apache Kafka™: the most important are Apache Kafka™ Streams and Apache Kafka™ Connect which does not have any C# implementation;
* measured high [performance](performance.md) in many operating conditions.

Currently the project tries to support, at our best, the [supported Apache Kafka™ binary distribution](https://kafka.apache.org/downloads):

|KNet | State | Apache Kafka™ | Branch | .NET | JVM |
|:---:	|:---:	|:---:	|:---:	|:---:	|:---:	|
|3.0.*|Active|4.0.*|[master](https://github.com/masesgroup/KNet)| 462 and 8 | 17+ |
|2.9.*|Active|3.9.*|[release/2.9.X](https://github.com/masesgroup/KNet/tree/release/2.9.X)| 462 and 8 | 11+ |
|2.8.*|Active|3.8.*|[release/2.8.X](https://github.com/masesgroup/KNet/tree/release/2.8.X)| 462 and 6 | 11+ |
|2.7.*|Deprecated|3.7.*|[release/2.7.X](https://github.com/masesgroup/KNet/tree/release/2.7.X)| 462 and 6 | 11+ |
|2.6.*|Deprecated|3.6.*|[release/2.6.X](https://github.com/masesgroup/KNet/tree/release/2.6.X)| 462 and 6 | 11+ |

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

This project adheres to the Contributor [Covenant code of conduct](https://github.com/masesgroup/KNet/blob/master/CODE_OF_CONDUCT.md). By participating, you are expected to uphold this code. Please report unacceptable behavior to coc_reporting@masesgroup.com.
