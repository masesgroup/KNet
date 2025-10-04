---
title: Connect SDK of .NET suite for Apache Kafka™
_description: Describes how to use a connector based on KNet Connect SDK of .NET suite for Apache Kafka™
---

# KNet: Connect SDK

This is only a quick start guide for KNet Connect SDK, other information related to Apache Kafka™ Connect can be found at the following link https://kafka.apache.org/documentation/#connect

> [!IMPORTANT]
> Starting from KNet 3.0.3, the infrastructure of the KNet Connect SDK supports both the .NET hosted runtime and the JVM hosted runtime: supporting the JVM hosted runtime guarantee that the connectors written in .NET languages can be deployed using the [official documentation](https://kafka.apache.org/documentation/#connect)

## Code structure

The code for a connector based on KNet Connect SDK follows the same rules for both .NET and the JVM hosted runtimes.

### Source connector

A source connector shall be defined extending the following class:
```c#
public abstract class KNetSourceConnector<TSourceConnector, TTask> : KNetConnector<TSourceConnector>
    where TSourceConnector : KNetSourceConnector<TSourceConnector, TTask>
    where TTask : KNetSourceTask<TTask>
```

where the `TTask` type shall extend the following class:

```c#
public abstract class KNetSourceTask<TTask> : KNetTask<TTask>
    where TTask : KNetSourceTask<TTask>
```

The mandatory method to be implemented is:

```c#
public abstract System.Collections.Generic.IList<SourceRecord> Poll();
```
which returns a set of `SourceRecord`, each `SourceRecord` can be created directly or by using the `CreateRecord` helper methods available.

> [!TIP]
> Starting from KNet 3.0.3, beside the standard invocation where the `SourceRecord`s will be returned once at the end of the `Poll` invocation and then pushed to the JVM,
by using the `CreateAndPushRecord` helper methods available each `SourceRecord` is created and directly pushed to the JVM: 
this new way can be used to take advantage of the idle time if the `KNetSourceTask<TTask>` is waiting to receive data, e.g. socket, disk access, etc.

### Sink connector

A sink connector shall be defined extending the following class:
```c#
public abstract class KNetSinkConnector<TSinkConnector, TTask> : KNetConnector<TSinkConnector>
    where TSinkConnector : KNetSinkConnector<TSinkConnector, TTask>
    where TTask : KNetSinkTask<TTask>
```
where the `TTask` type shall extend the following class:

```c#
public abstract class KNetSinkTask<TTask> : KNetTask<TTask>
    where TTask : KNetSinkTask<TTask>
```

The mandatory method to be implemented is:

```c#
public abstract void Put(IEnumerable<SinkRecord> collection);
```
which gives a set of `SinkRecord` to be used.

## General 

To start a Connect session the user shall use the [KNet Connect](usageConnect.md) or the information available at https://kafka.apache.org/documentation/#connect and https://kafka.apache.org/quickstart#quickstart_kafkaconnect.

The commands related to Apache Kafka™ Connect are:
- ConnectDistributed: starts a distributed session
- ConnectStandalone: starts a standalone session

To go in detail look at https://kafka.apache.org/documentation/#connect and https://kafka.apache.org/quickstart#quickstart_kafkaconnect.

## Standalone

In this guide we focus on the standalone version.
The guide start from the assumption that an assembly was generated: see [Template Usage Guide](usageTemplates.md).
Put the assembly within a folder (__C:\MyConnect__), then go within it.
As explained in https://kafka.apache.org/documentation/#connect Apache Kafka™ Connect needs at least one configuration file, in standalone mode it needs two configuration files:
1. The first file is **connect-standalone.properties** (or **connect-distributed.properties** for distributed environments): this file contains configuration information for Apache Kafka™ Connect;
2. The second file (optional for distributed version) defines the connector to use and its options.

In the [config folder](https://github.com/masesgroup/KNet/tree/master/src/config) the user can found many configuration files. 
The files named **connect-knet-sink.properties** and **connect-knet-source.properties** contain examples for sink and source connectors.

Copy within __C:\MyConnect__ **connect-standalone.properties** and update it especially within the line containing __bootstrap.servers__; then copy **connect-knet-sink.properties** or **connect-knet-source.properties** depending on the connector type and update using the information available in [Configuration properties](#configuration-properties).

### Execution

When the __C:\MyConnect__ folder contains all the files it is possible to run Apache Kafka™ Connect:

- .NET hosted runtime:
```shell
knetconnect -s connect-standalone.properties connect-knet-sink.properties
```

- JVM hosted runtime:
```shell
connect-standalone.sh connect-standalone.properties connect-knet-sink.properties
```

## Distributed

As stated in [Apache Kafka™ Connect Guide](https://kafka.apache.org/documentation/#connect ) the distributed version does not use the connector file definition, instead it shall be managed using the REST interface.
The start-up command within __C:\MyConnect__ folder becomes:

- .NET hosted runtime
```shell
knetconnect -d connect-distributed.properties
```
- JVM hosted runtime
```shell
connect-distributed.sh connect-distributed.properties
```

## Configuration properties

Each connector needs some configuration properties. 
Some common configuration properties, inherited from Apache Kafka™ Connect, are:
- __name=**name of connector**__ where the **name of connector** is the connector name
- __connector.class=**value**__ where the **value** is the connector Java™ class and must be:
  - __KNetSinkConnector__ for sink connectors
  - __KNetSourceConnector__ for source connectors
- __tasks.max=**value**__ where the **value** represents the maximum number of tasks the connector can allocate

The mandatory configuration property needed by KNet Connect SDK is:
- __knet.dotnet.classname=**value**__ where the **value** is the .NET class name in the form of __**FullName**, **AssemblyName**__, e.g. MASES.KNet.Template.KNetConnect.KNetConnectSink, knetConnectSink

When the connector is based on a JVM hosted runtime other optional properties are available:
- __knet.jcobridge.license.path=**value**__ where the **value** represents the license to be used by JCOBridge
- __knet.jcobridge.scope.on=**value**__ where the **value** represents the **scope on** to be used by JCOBridge
- __knet.jcobridge.scope.on.version=**value**__ where the **value** represents the **scope on version** used by JCOBridge
- __knet.jcobridge.clr.version=**value**__ where the **value** represents the .NET version to be used by JCOBridge, default is .NET 8
- __knet.jcobridge.clr.rid=**value**__ where the **value** represents the RID to be used by JCOBridge
- __knet.dotnet.assembly.location=**value**__ where the **value** represents the location where to find the connector assembly

### Source connector

A source connector needs other configuration properties inherited from Apache Kafka™ Connect like:
- __topic=**value**__ where the **value** represents the name of topic where the records will be sent

#### Exactly Once and Transaction properties for Source Connector

From version 3.3.1 of Apache Kafka™ Connect it is possible to manage Exactly Once and Transaction in the source connector.

Two new fallback options are available in case the infrastructure is not ready to receive request in .NET side to obtain values related to Exactly Once and Transaction:
- __knet.dotnet.source.exactlyOnceSupport=**value**__: set **value** to true if .NET Source Connector supports Exactly Once
- __knet.dotnet.source.canDefineTransactionBoundaries=**value**__: set **value** to true if .NET Source Connector can define Transaction Boundaries

### Sink connector

A source connector needs other configuration properties inherited from Apache Kafka™ Connect like:
- __topics=**value**__ where the **value** represents the CSV list of the topics will be the source of the records
