# KNet: the Apache Kafka .NET suite

KNet is a comprehensive .NET suite for [Apache Kafka](https://kafka.apache.org/) [APIs](https://kafka.apache.org/documentation/#api) providing all features: Producer, Consumer, Admin, Streams, Connect, backends (ZooKeeper and Kafka).

### Libraries and Tools

|KNet | KNetCLI | KNet.Templates | KNetPS | KNetConnect |
|:---:	|:---:	|:---:	|:---:	|:---:	|
|[![KNet nuget](https://img.shields.io/nuget/v/MASES.KNet)](https://www.nuget.org/packages/MASES.KNet) [![downloads](https://img.shields.io/nuget/dt/MASES.KNet)](https://www.nuget.org/packages/MASES.KNet) | [![KNetCLI nuget](https://img.shields.io/nuget/v/MASES.KNetCLI)](https://www.nuget.org/packages/MASES.KNetCLI) [![downloads](https://img.shields.io/nuget/dt/MASES.KNetCLI)](https://www.nuget.org/packages/MASES.KNetCLI) | [![KNet.Templates nuget](https://img.shields.io/nuget/v/MASES.KNet.Templates)](https://www.nuget.org/packages/MASES.KNet.Templates) [![downloads](https://img.shields.io/nuget/dt/MASES.KNet.Templates)](https://www.nuget.org/packages/MASES.KNet.Templates)| [![KNetPS](https://img.shields.io/powershellgallery/v/MASES.KNetPS.svg?style=flat-square&label=MASES.KNetPS)](https://www.powershellgallery.com/packages/MASES.KNetPS/)| [![KNetConnect nuget](https://img.shields.io/nuget/v/MASES.KNetConnect)](https://www.nuget.org/packages/MASES.KNetConnect) [![downloads](https://img.shields.io/nuget/dt/MASES.KNetConnect)](https://www.nuget.org/packages/MASES.KNetConnect) |

### Pipelines

[![CI_BUILD](https://github.com/masesgroup/KNet/actions/workflows/build.yaml/badge.svg)](https://github.com/masesgroup/KNet/actions/workflows/build.yaml)
[![CodeQL](https://github.com/masesgroup/KNet/actions/workflows/codeql-analysis.yml/badge.svg)](https://github.com/masesgroup/KNet/actions/workflows/codeql-analysis.yml)
[![CI_RELEASE](https://github.com/masesgroup/KNet/actions/workflows/release.yaml/badge.svg)](https://github.com/masesgroup/KNet/actions/workflows/release.yaml) 

---

## Scope of the project

This project aims to create a set of libraries and tools to direct access, from .NET, all the features available in the [Apache Kafka binary distribution](https://kafka.apache.org/downloads). 

There are many client libraries written to manage communication with Apache Kafka. Conversely, this project use directly the Java packages released from The Apache Foundation giving more than one benefit:
* all implemented features are availables at no extra implementation costs, see [KNet usage](src/net/Documentation/articles/usage.md);
* avoids any third party communication protocol implementation;
* access all features made available from Apache Kafka: the most important are Apache Kafka Streams and Apache Kafka Connect which does not have any C# implementation;
* measured high [performance](src/net/Documentation/articles/performance.md) in many operating conditions.

The Apache Kafka packages are downloaded from:

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
