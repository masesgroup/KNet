# Welcome to KafkaBridge

[![CI_BUILD](https://github.com/masesgroup/KafkaBridge/actions/workflows/build.yaml/badge.svg)](https://github.com/masesgroup/KafkaBridge/actions/workflows/build.yaml) [![CI_RELEASE](https://github.com/masesgroup/KafkaBridge/actions/workflows/release.yaml/badge.svg)](https://github.com/masesgroup/KafkaBridge/actions/workflows/release.yaml) 

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

---
## Summary

* [Roadmap](src/Documentation/articles/roadmap.md)
* [Actual state](src/Documentation/articles/actualstate.md)
* [KafkaBridge usage](src/Documentation/articles/usage.md)
* [KafkaBridgeCLI usage](src/Documentation/articles/usageCLI.md)

---
