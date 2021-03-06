# KNet: Connect SDK

This is only a quick start guide, many other information related to Apache Kafka Connect can be found at the following link https://kafka.apache.org/documentation/#connect

## General 

To start a Connect session the user shall use the [KNet CLI](usageCLI.md).

The commands related to Apache Kafka Connect are:
- ConnectDistributed
- ConnectStandalone

To go in detail look at https://kafka.apache.org/documentation/#connect and https://kafka.apache.org/quickstart#quickstart_kafkaconnect.

## Standalone

In this guide we focus on the standalone version.
The guide start from the assumption that an assembly was generated: see [Template Usage Guide](usageTemplates.md).
Put the assembly within a folder (__C:\MyConnect__), then go within it.
As explained in https://kafka.apache.org/documentation/#connect Apache Kafka Connect needs at least one configuration file, in standalone mode it needs two configuration files:
1. The first file is **connect-standalone.properties** (or **connect-distributed.properties** for distributed environments): this file contains configuration information for Apache Kafka Connect;
2. The second optional file defines the connector to use and its options.

In the [config folder](https://github.com/masesgroup/KNet/tree/master/src/config) the user can found many configuration files. 
The files named **connect-knet-sink.properties** and **connect-knet-source.properties** contain examples for sink and source connectors.

Copy within __C:\MyConnect__ **connect-standalone.properties** and update it especially on line containing __bootstrap.servers__, then copy **connect-knet-sink.properties** or **connect-knet-source.properties** depending on the connector type.
The main options related to KNet Connect SDK are:
- __connector.class=**KNetSinkConnector**__ where the value is the connector Java class and must be:
  - __KNetSinkConnector__ for sink connectors
  - __KNetSourceConnector__ for source connectors
- __knet.dotnet.classname=MASES.KNetTemplate.KNetConnect.KNetConnectSink, knetConnectSink__ where the value is the .NET class name in the form of __**FullName**, **AssemblyName**__

When the __C:\MyConnect__ folder contains all the files it is possible to run Apache Kafka Connect:

>
> knet -ClassToRun ConnectStandalone connect-standalone.properties connect-knet-sink.properties
>

## Distributed

As stated in [Apache Kafka Connect Guide](https://kafka.apache.org/documentation/#connect ) the distributed version does not use the connector file definition, instead it shall be managed using the REST interface.
The start-up command within __C:\MyConnect__ folder becomes:

>
> knet -ClassToRun ConnectDistributed connect-distributed.properties
>
