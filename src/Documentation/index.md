# Welcome to KafkaBridge

[![CI_BUILD](https://github.com/masesgroup/KafkaBridge/actions/workflows/build.yaml/badge.svg)](https://github.com/masesgroup/KafkaBridge/actions/workflows/build.yaml) [![CI_RELEASE](https://github.com/masesgroup/KafkaBridge/actions/workflows/release.yaml/badge.svg)](https://github.com/masesgroup/KafkaBridge/actions/workflows/release.yaml) 

Access natively Apache Kafka classes from any .NET application using [JCOBridge](https://www.jcobridge.com) engine.

This project adheres to the Contributor [Covenant code of conduct](CODE_OF_CONDUCT.md). By participating, you are expected to uphold this code. Please report unacceptable behavior to coc_reporting@masesgroup.com.

## Scope of the project

This project aims to create a library set, exposing a simple interface, to manage direct access to the features available in the [Apache Kafka binary distribution](https://kafka.apache.org/downloads).
There are many client libraries able to manages communication with Apache Kafka. This pojects use directly the binaries released from APache Foundation avoiding to wait third party implementations.
The ability of JCOBridge is to directly manages, from any .NET application, the interaction with the JVM and indeed the engine Apache Kafka uses to run.

## Actual state

The first version comes with ready made classes:

* The command line interface tools, available under the _bin_ folder of any Apache Kafka binary distribution can be managed using the KafkaBridgeCLI, i.e. ConsoleConsumer, ConsoleProducer and so on.

## Roadmap

The roadmap can be synthetized in the following points:

* Add more managed classes to simplify management from .NET;
* Bridges Kafka Connect and Kafka Streams to .NET to use both any JVM language (Scala, Java) and .NET languages;
* Extend ability to use .NET packages (e.g. EntityFramework) with Kafka Streams.

## KafkaBridgeCLI usage

To use the CLI interface (KafkaBridgeCLI) runs a command like the following:

> KafkaBridgeCLI -ClassToRun ConsoleConsumer --bootstrap-server SERVER-ADDRESS:9093 --topic topic_name --from-beginning

KafkaBridgeCLI accepts the following command-line switch:

* **ClassToRun**: represents the class to be launched
* **KafkaLocation**: represents the path to the root folder of Apache Kafka binary distribution; default value consider that KafkaBridgeCLI is installed within the bin folder of Apache Kafka binary distribution;