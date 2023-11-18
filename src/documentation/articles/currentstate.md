---
title: Current development state of .NET suite for Apache Kafka
_description: Describes the current development state of .NET suite for Apache Kafka
---

# KNet: development state

This release comes with some ready made classes:

* [X] The command line interface classes (i.e. the executables Apache Kafka classes), the ones available under the _bin_ folder of any Apache Kafka binary distribution, can be managed using the [KNetCLI](usageCLI.md), e.g. ConsoleConsumer, ConsoleProducer and so on. 
* [X] Producer/Consumer classes
* [X] Apache Kafka Admin Client covering all available APIs: since many classes are marked with @InterfaceStability.Evolving annotation some properties or methods can be missed; use **dynamic** code to interact with Admin API types.
* [X] Almost completed Apache Kafka Streams
* [X] Almost completed Apache Kafka Connect
* [X] .NET Apache Kafka Connect SDK (a basic version)
* [X] KNet Connect: added autonomous executable to start connectors based on KNet Connect SDK
* [X] KNet PowerShell: added some cmdlets

If something is not available use [API extensibility](API_extensibility.md) to cover missing features.
