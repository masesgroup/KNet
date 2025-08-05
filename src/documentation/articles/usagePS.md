---
title: PowerShell module of .NET suite for Apache Kafka™
_description: Describes how to use PowerShell module of .NET suite for Apache Kafka™
---

# KNet: PowerShell Module

## Installation

To install the tool executes the following command within a PowerShell shell:

```powershell
Install-Module -Name MASES.KNetPS
```

If the above command fails, reporting errors related to _authenticode_, use the following command:

```powershell
Install-Module -Name MASES.KNetPS -SkipPublisherCheck
```

## Usage

To use the PowerShell interface (KNetPS) runs the following commands within a **PowerShell** shell:

### Initialization

The following cmdlet must be called prior anything else to initialize the environment:

```powershell
Start-KNetPS [arguments]
```

then the user can use objects created using **New-KObject** and other cmdlets, otherwise it is possible to invoke the desired Main-Class command which automatically executes **Start-KNetPS**.

Here below two simple examples of producer/consumer from PowerShell.
The examples are very minimal, but demonstrate how send to and receive from an Apache Kafka™ cluster.
The terms __MY_KAFKA_CLUSTER__ shall be replaced with the address of Apache Kafka™ cluster.

### Producer

The following snippet builds needed objects to send a record to an Apache Kafka™ cluster:

```powershell

Start-KNetPS
$prodConfig = New-ProducerConfigBuilder
$prodConfig = $prodConfig.WithBootstrapServers("MY_KAFKA_CLUSTER:9092")
$producer = New-KafkaProducer -KeyClass "System.String" -ValueClass "System.String" -Configuration $prodConfig
$record = New-ProducerRecord -KeyClass "System.String" -Key "MyKey" -ValueClass "System.String" -Value "MyPayload" -Topic "testTopic"
$sendResult = Invoke-Send -Producer $producer -ProducerRecord $record

```

### Consumer 

The following snippet builds needed objects to subscribe to an Apache Kafka™ cluster and receives records from the specified topic:

```powershell

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

Here a list of cmdlets which executes well known tasks defined from Apache Kafka™ like you use the scripts available in the Apache Kafka™ release:

* **Start-KNetPS**: Initialize the engine and can be the first command to be invoked. The arguments are:
  * Inherited from JnetPS:
	* LicensePath
	* JDKHome
	* JVMPath
	* JNIVerbosity
	* JNIOutputFile
	* JmxPort
	* EnableDebug
	* JavaDebugPort
	* DebugSuspendFlag
	* JavaDebugOpts
	* HeapSize
	* InitialHeapSize
	* LogClassPath
  * Specific of KnetPS:
    * ScalaVersion
	* KafkaJarLocation
	* Log4JPath
	* LogPath
	* DisableJMX
* **New-KObject**: Creates a new JVM™ object of the class specified in argument using the parameters within command line for constructor. The arguments are:
  * Inherited from JnetPS:
    * Class
    * Arguments
  * Specific of KnetPS:
      * ScalaVersion
	  * KafkaJarLocation
	  * Log4JPath
	  * LogPath	  
* **Start-AclCommand**: start AclCommand. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-BrokerApiVersionsCommand**: start BrokerApiVersionsCommand. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-ConfigCommand**: start ConfigCommand. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-ConsumerGroupCommand**: start ConsumerGroupCommand. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-DelegationTokenCommand**: start DelegationTokenCommand. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-DeleteRecordsCommand**: start DeleteRecordsCommand. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-FeatureCommand**: start FeatureCommand. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-LeaderElectionCommand**: start LeaderElectionCommand. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-LogDirsCommand**: start LogDirsCommand. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-MetadataQuorumCommand**: start MetadataQuorumCommand. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-ReassignPartitionsCommand**: start ReassignPartitionsCommand. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-TopicCommand**: start TopicCommand. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-ZkSecurityMigrator**: start ZkSecurityMigrator. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-KafkaStart**: start KafkaStart. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-ZooKeeperShell**: start ZooKeeperShell. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-ZooKeeperStart**: start ZooKeeperStart. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-MetadataShell**: start MetadataShell. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-ClusterTool**: start ClusterTool. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-ConsoleConsumer**: start ConsoleConsumer. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-ConsoleProducer**: start ConsoleProducer. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-ConsumerPerformance**: start ConsumerPerformance. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-DumpLogSegments**: start DumpLogSegments. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-GetOffsetShell**: start GetOffsetShell. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-MirrorMaker**: start MirrorMaker. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-ProducerPerformance**: start ProducerPerformance. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-ReplicaVerificationTool**: start ReplicaVerificationTool. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-StorageTool**: start StorageTool. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-StreamsResetter**: start StreamsResetter. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-TransactionsCommand**: start TransactionsCommand. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-VerifiableConsumer**: start VerifiableConsumer. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-VerifiableProducer**: start VerifiableProducer. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-MirrorMaker2**: start MirrorMaker2. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
	  
