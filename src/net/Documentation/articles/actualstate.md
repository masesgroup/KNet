# KafkaBridge development state

This release comes with some ready made classes:

* The command line interface classes (i.e. the executables Apache Kafka classes), the ones available under the _bin_ folder of any Apache Kafka binary distribution, can be managed using the [KafkaBridgeCLI](usageCLI.md), e.g. ConsoleConsumer, ConsoleProducer and so on. 
* Producer/Consumer classes
* Kafka Admin Client covering all available APIs: not all types expose method and properties (this is a development choice due to @InterfaceStability.Evolving annotation); use **dynamic** code to interact with Admin API types.
* Almost completed Kafka Streams
* Initial development of Kafka Connect (under development)
