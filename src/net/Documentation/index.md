# Welcome to KafkaBridge

Access natively Apache Kafka Java classes from any .NET application using [JCOBridge](https://www.jcobridge.com) engine.

This project adheres to the Contributor [Covenant code of conduct](CODE_OF_CONDUCT.md). By participating, you are expected to uphold this code. Please report unacceptable behavior to coc_reporting@masesgroup.com.

## Scope of the project

This project aims to create a library able to direct access the features available in the [Apache Kafka binary distribution](https://kafka.apache.org/downloads).
There are many client libraries written to manage communication with Apache Kafka. Conversely, this poject use directly the Java packages released from Apache Foundation giving more than one benefit:
* all implemented features are availables;
* avoids  protocol implementation from any third party;
* can access any feature made available.
The benefits comes from tow main points related to JCOBridge:
* its ablitity to manage a direct access to the JVM from any .NET application: any Java / Scala class behind Apache Kafka can be directly managed;
* using the dynamic code feature of JCOBridge it is possible to write a Java/Scala/Kotlin/etc seamless language directly inside a standard .NET application written in C#/VB.NET

## Actual state

The first public version comes with few ready made classes:

* The command line interface classes (i.e. the executables Apache Kafka classes), the ones available under the _bin_ folder of any Apache Kafka binary distribution, can be managed using the KafkaBridgeCLI, e.g. ConsoleConsumer, ConsoleProducer and so on.

## Roadmap

The roadmap can be synthetized in the following points:

* Add more classes to simplify management from .NET;
* Create Kafka Connect and Kafka Streams bridging classes for .NET to mix both any JVM language (Scala, Java) and .NET languages;
* Add features to extend ability to use .NET packages (e.g. EntityFramework) with Kafka Streams.

## KafkaBridgeCLI usage

To use the CLI interface (KafkaBridgeCLI) runs a command like the following:

> KafkaBridgeCLI -ClassToRun ConsoleConsumer --bootstrap-server SERVER-ADDRESS:9093 --topic topic_name --from-beginning

KafkaBridgeCLI accepts the following command-line switch:

* **ClassToRun**: represents the class to be launched
* **KafkaLocation**: represents the path to the root folder of Apache Kafka binary distribution; default value consider that KafkaBridgeCLI is installed within the bin folder of Apache Kafka binary distribution;