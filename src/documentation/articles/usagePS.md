---
title: PowerShell module of .NET suite for Apache Kafka™
_description: Describes how to use PowerShell module of .NET suite for Apache Kafka™
---

# KNet: PowerShell Module

## Installation

To install the tool executes the following command within a PowerShell shell:

```
Install-Module -Name MASES.KNetPS
```

If the above command fails, reporting errors related to *authenticode*, use the following command:

```
Install-Module -Name MASES.KNetPS -SkipPublisherCheck
```

## Backend compatibility

KNetPS cmdlets are divided into two categories with different backend compatibility scope:

**Scriptable cmdlets and client-side admin tool cmdlets** use the standard Apache Kafka™ client APIs (Producer, Consumer, Admin Client) and are compatible with any broker that implements the Kafka wire protocol — including [Redpanda](https://redpanda.com/), [Amazon MSK](https://aws.amazon.com/msk/), [Confluent Platform / Cloud](https://www.confluent.io/), and others.

**Server-side cmdlets** start, configure, or manage an Apache Kafka™ broker node, ZooKeeper™ node, or KRaft controller directly. These are specific to Apache Kafka™ and are not applicable to alternative brokers.

See [Supported Backends](backends.md) for the full compatibility matrix.

## Usage

To use the PowerShell interface (KNetPS) runs the following commands within a **PowerShell** shell:

### Initialization

The following cmdlet must be called prior anything else to initialize the environment:

```
Start-KNetPS [arguments]
```

then the user can use objects created using **New-KObject** and other cmdlets, otherwise it is possible to invoke the desired Main-Class command which automatically executes **Start-KNetPS**.

Here below two simple examples of producer/consumer from PowerShell.
The examples are very minimal, but demonstrate how send to and receive from an Apache Kafka™ cluster.
The terms **MY\_KAFKA\_CLUSTER** shall be replaced with the address of the broker cluster.

### Producer

The following snippet builds needed objects to send a record to a broker cluster:

```
Start-KNetPS
$prodConfig = New-ProducerConfigBuilder
$prodConfig = $prodConfig.WithBootstrapServers("MY_KAFKA_CLUSTER:9092")
$producer = New-KafkaProducer -KeyClass "System.String" -ValueClass "System.String" -Configuration $prodConfig
$record = New-ProducerRecord -KeyClass "System.String" -Key "MyKey" -ValueClass "System.String" -Value "MyPayload" -Topic "testTopic"
$sendResult = Invoke-Send -Producer $producer -ProducerRecord $record
```

### Consumer

The following snippet builds needed objects to subscribe to a broker cluster and receives records from the specified topic:

```
Start-KNetPS
$builder = New-ConsumerConfigBuilder
$builder = $builder.WithBootstrapServers("MY_KAFKA_CLUSTER:9092")
$builder = $builder.WithGroupId("myGroup")
$builder = $builder.WithClientId("myCLient")
$consumer = New-KafkaConsumer -KeyClass "System.String" -ValueClass "System.String" -Configuration $builder
Invoke-Subscribe -Consumer $consumer -Topic "testTopic"
$results = Invoke-Poll -KeyClass "System.String" -ValueClass "System.String" -Consumer $consumer -PollTimeout 10000
$record = Get-ConsumerRecord -KeyClass "System.String" -ValueClass "System.String" -ConsumerRecords $results
```

## Cmdlets available

KNetPS accepts cmdlets divided by two main groups: Main-Class command cmdlets and Scriptable cmdlets.

### Scriptable cmdlets

Compatible with any Kafka wire-protocol broker.

Here a list of cmdlets usable within a script:

* **New-AdminClientConfigBuilder**: creates an AdminClientConfigBuilder object which can be extended using fluent APIs
* **New-ConsumerConfigBuilder**: creates a ConsumerConfigBuilder object which can be extended using fluent APIs
* **New-ProducerConfigBuilder**: creates a ProducerConfigBuilder object which can be extended using fluent APIs
* **New-KafkaAdminClient**: creates a KafkaAdminClient object to invoke administration APIs
* **New-KafkaConsumer**: creates a KafkaConsumer object
* **New-KafkaProducer**: creates a KafkaProducer object
* **New-KNetConsumer**: creates a KNetConsumer object
* **New-KNetProducer**: creates a KNetProducer object
* **Invoke-Subscribe**: invokes a Subscribe on an instance of KafkaConsumer
* **Invoke-Poll**: invokes a Poll on an instance of KafkaConsumer
* **Get-ConsumerRecord**: retrieve a ConsumerRecord from the result of Invoke-Poll
* **Get-ConsumerGroupMetadata**: retrieve a ConsumerGroupMetadata from an instance of KafkaConsumer
* **Invoke-Unsubscribe**: invokes a Unsubscribe on an instance of KafkaConsumer
* **New-ProducerRecord**: creates a new instance of ProducerRecord
* **Invoke-Send**: sends an instance of ProducerRecord to an instance of KafkaProducer

### Main-Class command cmdlets

These cmdlets execute well-known tasks defined by Apache Kafka™, equivalent to the scripts available in the Apache Kafka™ binary distribution.

#### Client-side admin tool cmdlets

Compatible with any Kafka wire-protocol broker (with possible caveats on brokers with partial Admin API support — see [Supported Backends](backends.md)):

* **Start-AclCommand**: start AclCommand
* **Start-BrokerApiVersionsCommand**: start BrokerApiVersionsCommand
* **Start-ConfigCommand**: start ConfigCommand
* **Start-ConsumerGroupCommand**: start ConsumerGroupCommand
* **Start-DelegationTokenCommand**: start DelegationTokenCommand
* **Start-DeleteRecordsCommand**: start DeleteRecordsCommand
* **Start-LeaderElectionCommand**: start LeaderElectionCommand
* **Start-LogDirsCommand**: start LogDirsCommand
* **Start-ReassignPartitionsCommand**: start ReassignPartitionsCommand
* **Start-TopicCommand**: start TopicCommand
* **Start-ConsoleConsumer**: start ConsoleConsumer
* **Start-ConsoleProducer**: start ConsoleProducer
* **Start-ConsumerPerformance**: start ConsumerPerformance
* **Start-DumpLogSegments**: start DumpLogSegments
* **Start-GetOffsetShell**: start GetOffsetShell
* **Start-MirrorMaker**: start MirrorMaker
* **Start-MirrorMaker2**: start MirrorMaker2
* **Start-ProducerPerformance**: start ProducerPerformance
* **Start-ReplicaVerificationTool**: start ReplicaVerificationTool
* **Start-StreamsResetter**: start StreamsResetter
* **Start-TransactionsCommand**: start TransactionsCommand
* **Start-VerifiableConsumer**: start VerifiableConsumer
* **Start-VerifiableProducer**: start VerifiableProducer

#### Server-side cmdlets — Apache Kafka™ only

These cmdlets start or manage an Apache Kafka™ broker node, ZooKeeper™ node, or KRaft controller directly. They are specific to Apache Kafka™ and are not applicable to alternative brokers:

* **Start-KafkaStart**: start KafkaStart
* **Start-ZooKeeperStart**: start ZooKeeperStart
* **Start-ZooKeeperShell**: start ZooKeeperShell
* **Start-StorageTool**: start StorageTool
* **Start-MetadataShell**: start MetadataShell
* **Start-MetadataQuorumCommand**: start MetadataQuorumCommand
* **Start-ClusterTool**: start ClusterTool
* **Start-ZkSecurityMigrator**: start ZkSecurityMigrator
* **Start-FeatureCommand**: start FeatureCommand

All cmdlets accept the following arguments (inherited from Start-KNetPS):

* All available arguments of Start-KNetPS;
* Arguments: a string containing the arguments accepted from the Java Main-Class

### Start-KNetPS arguments

* **Start-KNetPS**: Initialize the engine and can be the first command to be invoked. The arguments are:
  + Inherited from JnetPS:
    - LicensePath
    - JDKHome
    - JVMPath
    - JNIVerbosity
    - JNIOutputFile
    - JmxPort
    - EnableDebug
    - JavaDebugPort
    - DebugSuspendFlag
    - JavaDebugOpts
    - HeapSize
    - InitialHeapSize
    - LogClassPath
  + Specific of KnetPS:
    - ScalaVersion
    - KafkaJarLocation
    - Log4JPath
    - LogPath
    - DisableJMX
* **New-KObject**: Creates a new JVM™ object of the class specified in argument using the parameters within command line for constructor. The arguments are:
  + Inherited from JnetPS:
    - Class
    - Arguments
  + Specific of KnetPS:
    - ScalaVersion
    - KafkaJarLocation
    - Log4JPath
    - LogPath
