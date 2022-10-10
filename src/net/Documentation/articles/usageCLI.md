# KNet: CLI

## Installation

KNet CLI is available in two different formats:

- dotnet tool hosted on NuGet.org: check https://www.nuget.org/packages/MASES.KNetCLI/ and https://docs.microsoft.com/en-us/dotnet/core/tools/global-tools for installation deep instructions.
- Docker image hosted on https://github.com/masesgroup/KNet/pkgs/container/mases.knetcli: follow instruction within the page and general instruction on https://docs.docker.com

## Usage

To use the CLI interface (KNetCLI) runs a command like the following:

- **dotnet tool**

> knet -ClassToRun ConsoleConsumer --bootstrap-server SERVER-ADDRESS:9093 --topic topic_name --from-beginning

- **Docker image**

> docker run ghcr.io/masesgroup/mases.knetcli -ClassToRun ConsoleConsumer --bootstrap-server SERVER-ADDRESS:9093 --topic topic_name --from-beginning

### Commands available

_knet_ accepts the following command-line switch:

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
		* MirrorMaker
		* ProducerPerformance
		* ReplicaVerificationTool
		* StorageTool
		* StreamsResetter
		* TransactionsCommand
		* VerifiableConsumer
		* VerifiableProducer
	* Connect scope:
		* ConnectDistributed
		* ConnectStandalone
		* MirrorMaker2
* **KafkaLocation**: represents the path to the root folder of Apache Kafka binary distribution; default value consider that KNetCLI uses the Apache Kafka jars available under the jars folder prepared from the package;
* **ScalaVersion**: the scala version to be used. The default version (_2.13.6_) is binded to the deafult Apache Kafka version available in the package;
* **Log4JConfiguration**: the log4j configuration file; the default uses the file within the package.
