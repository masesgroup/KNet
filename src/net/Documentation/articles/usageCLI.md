# KafkaBridgeCLI usage

To use the CLI interface (KafkaBridgeCLI) runs a command like the following:

> KafkaBridgeCLI -ClassToRun ConsoleConsumer --bootstrap-server SERVER-ADDRESS:9093 --topic topic_name --from-beginning

KafkaBridgeCLI accepts the following command-line switch:

* **ClassToRun**: represents the class to be launched
* **KafkaLocation**: represents the path to the root folder of Apache Kafka binary distribution; default value consider that KafkaBridgeCLI is installed within the bin folder of Apache Kafka binary distribution;