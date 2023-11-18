---
title: Command-line switches of .NET suite for Apache Kafka
_description: Describes the command-line switches of .NET suite for Apache Kafka
---

# KNet: Command line switches available

_knet_ accepts the following command-line switches:

* **ClassToRun**: represents the class to be executed; the list is:
	* Administration scope:
		* AclCommand
		* BrokerApiVersionsCommand
		* ConfigCommand
		* ConsumerGroupCommand
		* DelegationTokenCommand
		* DeleteRecordsCommand
		* FeatureCommand
		* LeaderElectionCommand
		* LogDirsCommand
		* MetadataQuorumCommand
		* ReassignPartitionsCommand
		* TopicCommand
		* ZkSecurityMigrator
	* Server scope:
		* KafkaStart
		* ZooKeeperShell
		* ZooKeeperStart
	* Shell scope:
		* MetadataShell
	* Tools scope:
		* ClusterTool
		* ConsoleConsumer
		* ConsoleProducer
		* ConsumerPerformance
		* DumpLogSegments
		* GetOffsetShell
		* MetadataQuorumCommand
		* MirrorMaker
		* ProducerPerformance
		* ReplicaVerificationTool
		* StorageTool
		* StreamsResetter
		* TransactionsCommand
		* VerifiableConsumer
		* VerifiableProducer
	* Connect scope:
		* ConnectDistributed: moved to KNetConnect (see [KNetConnect](usageConnect.md))
		* ConnectStandalone: moved to KNetConnect (see [KNetConnect](usageConnect.md))
		* KNetConnectDistributed: available into KNetConnect (see [KNetConnect](usageConnect.md))
		* KNetConnectStandalone: available into KNetConnect (see [KNetConnect](usageConnect.md))
		* MirrorMaker2
* **KafkaLocation**: represents the path to the root folder of Apache Kafka binary distribution; default value consider that KNetCLI uses the Apache Kafka jars available under the jars folder prepared from the package;
* **ScalaVersion**: the scala version to be used. The default version (_2.13.6_) is binded to the deafult Apache Kafka version available in the package;
* **Log4JConfiguration**: the log4j configuration file; the default uses the file within the package;
* **LogPath**: the path where the logs are stored;
* **DisableJMX**: disable JMX, JMX is enabled by default.

Plus it accepts from:
* **JNet**:
  * **LogClassPath**: put in command line the switch to output all Jars found
* **JCOBridge**:
  * All command-line switches of JCOBridge available at https://www.jcobridge.com/net-examples/command-line-options/

## JVM identification

One of the most important command-line switch is **JVMPath**: see [KNet usage](usage.md) to find more information.

