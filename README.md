# KafkaBridge: the Apache Kafka .NET implementation

[![CI_BUILD](https://github.com/masesgroup/KafkaBridge/actions/workflows/build.yaml/badge.svg)](https://github.com/masesgroup/KafkaBridge/actions/workflows/build.yaml) [![CI_RELEASE](https://github.com/masesgroup/KafkaBridge/actions/workflows/release.yaml/badge.svg)](https://github.com/masesgroup/KafkaBridge/actions/workflows/release.yaml) 

KafkaBridge is a .NET mirror of [Apache Kafka](https://kafka.apache.org/) [APIs](https://kafka.apache.org/documentation/#api) providing all features: Producer, Consumer, Admin, Streams, Connect, ZooKeeper, Kafka backend.

This project adheres to the Contributor [Covenant code of conduct](CODE_OF_CONDUCT.md). By participating, you are expected to uphold this code. Please report unacceptable behavior to coc_reporting@masesgroup.com.

## Scope of the project

This project aims to create a library to direct access, from .NET, all the features available in the [Apache Kafka binary distribution](https://kafka.apache.org/downloads). 

There are many client libraries written to manage communication with Apache Kafka. Conversely, this project use directly the Java packages released from The Apache Foundation giving more than one benefit:
* all implemented features are availables at no extra implementation costs, see [KafkaBridge usage](src/Documentation/articles/usage.md);
* avoids any third party communication protocol implementation;
* access all features made available from Apache Kafka: the most important one is Kafka Streams which does not have any C# implementation.

Many benefits comes from the [features of JCOBridge](https://www.jcobridge.com/features/):
* **Cyber-security**: 
  * [JVM](https://en.wikipedia.org/wiki/Java_virtual_machine) and [CLR, or CoreCLR,](https://en.wikipedia.org/wiki/Common_Language_Runtime) runs in the same process, but are insulated from each other;
  * .NET (CLR) inherently inherits the cyber-security levels of running JVM and Apache Kafka; 
* **Direct access the JVM from any .NET application**: 
  * Any Java/Scala class behind Apache Kafka can be directly managed: Consumer, Producer, Administration, Streams, Server-side, and so on;
  * No need to learn new APIs: we try to expose the same APIs in C# style;
  * No extra validation cycle on protocol and functionality;
  * Documentation is shared;
* **Dynamic code**: it helps to write a Java/Scala/Kotlin/etc seamless language code directly inside a standard .NET application written in C#/VB.NET: look at this [simple example](https://www.jcobridge.com/net-examples/dotnet-examples/) and [KafkaBridge usage](src/Documentation/articles/usage.md).

---
## Summary

* [Roadmap](src/Documentation/articles/roadmap.md)
* [Actual state](src/Documentation/articles/actualstate.md)
* [KafkaBridge usage](src/Documentation/articles/usage.md)
* [KafkaBridgeCLI usage](src/Documentation/articles/usageCLI.md)

---

KAFKA is a registered trademark of The Apache Software Foundation. KafkaBridge has no affiliation with and is not endorsed by The Apache Software Foundation.
