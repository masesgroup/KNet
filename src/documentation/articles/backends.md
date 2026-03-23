---
title: Supported backends for .NET suite for Apache Kafka™
_description: Supported backends for .NET suite for Apache Kafka™
---

# KNet: Supported Backends

KNet is a comprehensive .NET suite built directly on top of the official Apache Kafka™ Java packages via [JNet](https://github.com/masesgroup/JNet) and [JCOBridge](https://www.jcobridge.com/).
This architecture has a direct impact on backend compatibility: **not all KNet features have the same compatibility scope**.

The key distinction is between the **server-side** and the **client-side** of KNet.

## Server-side features: Apache Kafka™ only

Some KNet features start, configure, or manage an Apache Kafka™ broker or its supporting infrastructure (ZooKeeper™, KRaft controller). These are by nature tied to Apache Kafka™ and are not compatible with alternative Kafka-protocol-compatible brokers.

Server-side features include:

- **KNetCLI / KNetPS Main-Class server commands**: `Start-KafkaStart`, `Start-ZooKeeperStart`, `Start-ZooKeeperShell`, `Start-StorageTool`, `Start-MetadataShell`, `Start-MetadataQuorumCommand`, `Start-ClusterTool`, `Start-ZkSecurityMigrator`, `Start-FeatureCommand`
- **Docker image server modes**: `broker`, `zookeeper`, `server`, `kraft-broker`, `kraft-controller`, `kraft-server`, `knet-connect-standalone-server`, `connect-standalone-server`

These features use the Apache Kafka™ server binaries directly and are not designed to work with any other broker.

## Client-side features: Kafka wire-protocol compatible brokers

KNet client-side features use only the standard Apache Kafka™ client APIs: Producer, Consumer, Admin Client, and Kafka Streams. These APIs communicate with the broker exclusively through the Kafka wire protocol.

Any broker that fully implements the Kafka wire protocol is therefore compatible with the following KNet features:

- **Producer and Consumer APIs** (`KafkaProducer`, `KafkaConsumer`, `KNetProducer`, `KNetConsumer`)
- **Admin Client API** (`KafkaAdminClient`)
- **Kafka Streams / KNet Streams SDK** (runs entirely embedded in the .NET process; the broker only sees standard topics)
- **KNetPS scriptable cmdlets**: `New-KafkaProducer`, `New-KafkaConsumer`, `New-KafkaAdminClient`, `New-KNetProducer`, `New-KNetConsumer`, `Invoke-Send`, `Invoke-Poll`, `Invoke-Subscribe`, etc.
- **KNetPS admin tool cmdlets** (client-side): `Start-TopicCommand`, `Start-ConsumerGroupCommand`, `Start-ConfigCommand`, `Start-AclCommand`, `Start-DelegationTokenCommand`, `Start-DeleteRecordsCommand`, `Start-LogDirsCommand`, `Start-ReassignPartitionsCommand`, `Start-BrokerApiVersionsCommand`, `Start-MirrorMaker`, `Start-MirrorMaker2`, `Start-ConsoleConsumer`, `Start-ConsoleProducer`, `Start-ConsumerPerformance`, `Start-ProducerPerformance`, `Start-StreamsResetter`, `Start-TransactionsCommand`, `Start-GetOffsetShell`, `Start-DumpLogSegments`, `Start-ReplicaVerificationTool`, `Start-VerifiableConsumer`, `Start-VerifiableProducer`
- **KNet Connect SDK** (connectors run embedded in the .NET or JVM process; the broker is accessed as a standard Kafka client)
- **Docker image client modes**: `knet-connect-standalone`, `connect-standalone`, `knet-connect-distributed`, `connect-distributed`

> **Note on Kafka Streams**: Kafka Streams runs entirely embedded within the application process. The broker is not aware of Streams: it only stores the standard topics that Streams creates and manages (state store changelog topics, repartition topics). No server-side Streams support is required from the broker.

> **Note on KNet Connect SDK**: The Connect framework connects to the broker as a standard Kafka client. Connectors written with KNet Connect SDK run embedded in the process (.NET hosted runtime) or as standard JVM connectors (JVM hosted runtime). In both cases no specific broker-side feature beyond the Kafka wire protocol is required.

## Compatible brokers for client-side features

The following brokers declare full or substantial Kafka wire-protocol compatibility and are therefore compatible with all KNet client-side features:

| Broker | Type | Compatibility notes |
|---|---|---|
| [Apache Kafka™](https://kafka.apache.org/) | Self-hosted | Reference implementation, full compatibility |
| [Redpanda](https://redpanda.com/) | Self-hosted / Cloud | Declares full Kafka wire-protocol compatibility |
| [Amazon MSK](https://aws.amazon.com/msk/) | Managed Cloud (AWS) | Kafka-native managed service, full compatibility |
| [Confluent Platform / Cloud](https://www.confluent.io/) | Self-hosted / Cloud | Commercial Kafka distribution, full compatibility |
| [Aiven for Apache Kafka™](https://aiven.io/kafka) | Managed Cloud (multi-cloud) | Kafka-native managed service, full compatibility |
| [IBM Event Streams](https://www.ibm.com/products/event-streams) | Self-hosted / Cloud | Based on Apache Kafka™, full compatibility |
| [WarpStream](https://www.warpstream.com/) | Cloud (S3-backed) | Kafka-compatible, zero inter-broker network |
| [AutoMQ](https://www.automq.com/) | Self-hosted / Cloud | Kafka-compatible, S3-backed cloud-native |
| [Azure Event Hubs](https://azure.microsoft.com/en-us/products/event-hubs/) | Managed Cloud (Azure) | Kafka endpoint available; partial compatibility — some Admin API features may not be supported |
| [Apache Pulsar](https://pulsar.apache.org/) (KoP) | Self-hosted | Kafka-on-Pulsar translation layer; partial compatibility — verify Admin API and topic configuration support |

> **Important**: KNet directly uses the official Apache Kafka™ Java client packages. Compatibility with Kafka-protocol-compatible brokers is therefore **inherited from the Apache Kafka™ client libraries themselves**, not from a custom implementation. Any broker compatible with the Apache Kafka™ client is automatically compatible with KNet client-side features.

## Summary table

| KNet feature area | Apache Kafka™ | Kafka-compatible brokers |
|---|:---:|:---:|
| Broker / ZooKeeper™ / KRaft server management | ✅ | ❌ |
| Docker server modes | ✅ | ❌ |
| Producer / Consumer / Admin API | ✅ | ✅ |
| Kafka Streams / KNet Streams SDK | ✅ | ✅ |
| KNetPS scriptable cmdlets | ✅ | ✅ |
| KNetPS admin tool cmdlets (client-side) | ✅ | ✅ * |
| KNet Connect SDK | ✅ | ✅ |
| Docker client/connect modes | ✅ | ✅ |

\* Some advanced admin operations may not be available on brokers with partial Admin API compatibility (e.g. Azure Event Hubs, Pulsar KoP).
