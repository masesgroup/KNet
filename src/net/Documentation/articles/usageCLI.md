# KafkaBridgeCLI usage

To use the CLI interface (KafkaBridgeCLI) runs a command like the following:

> KafkaBridgeCLI -ClassToRun ConsoleConsumer --bootstrap-server SERVER-ADDRESS:9093 --topic topic_name --from-beginning

KafkaBridgeCLI accepts the following command-line switch:

* **ClassToRun**: represents the class to be launched; the list is:
	* Administration:
		* BrokerApiVersionsCommand
		* ConfigCommand
		* ConsumerGroupCommand
		* DelegationTokenCommand
		* DeleteRecordsCommand
		* LeaderElectionCommand
		* LogDirsCommand
		* ReassignPartitionsCommand
		* TopicCommand
	* Tools:
		* ConsoleConsumer
		* ConsoleProducer
		* ConsumerPerformance
		* DumpLogSegments
		* GetOffsetShell
		* MirrorMaker
		* ProducerPerformance
		* ReplicaVerificationTool
		* StreamsResetter
		* TransactionsCommand
* **KafkaLocation**: represents the path to the root folder of Apache Kafka binary distribution; default value consider that KafkaBridgeCLI uses the Apache Kafka jars available under the jars folder prepared from the package;
* **ScalaVersion**: the scala version to be used. The default version (_2.13.6_) is binded to the deafult Apache Kafka version available in the package;
* **Log4JConfiguration**: the log4j configuration file; the default uses the file within the package.