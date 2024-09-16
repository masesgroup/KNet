---
title: Templates usage of .NET suite for Apache Kafka™
_description: Describes how to use templates of .NET suite for Apache Kafka™
---

# KNet: Template Usage Guide

For more information related to .NET templates look at https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-new-sdk-templates.

## Installation

To install the templates executes the following command within a command shell:

```sh
dotnet new --install MASES.KNet.Templates
```

The command installs the latest version and on success will list all templates added to the list of available templates.
They are:
1. knetConsumerApp: a project to create a consumer application for Apache Kafka™
2. knetPipeStreamApp: a project to create a pipe stream application for Apache Kafka™ Streams
3. knetProducerApp: a project to create a producer application for Apache Kafka™
4. knetConnectSink: a project to create a library which conforms to an Apache Kafka™ Connect Sink Connector written in .NET
5. knetConnectSource: a project to create a library which conforms to an Apache Kafka™ Connect Source Connector written in .NET

## Simple usage

The first three templates are ready made project with enough code to use them directly.
To use one of the available templates run the following command:

```sh
dotnet new knetConsumerApp
```

the previous command will create a .NET project for an executable. The user can modify the code or just execute it against an Apache Kafka™ server.

## SDK templates

The last two templates (knetConnectSink, knetConnectSource) are not ready made project: they are skeletons for Apache Kafka™ Connect Source/Sink Connector written in .NET.
The available code does not do anything: the functions in the code shall be filled to obtain some results.

With the available code the user can verify how an Apache Kafka™ Connect Source/Sink Connector, written in .NET, works; to do this the projects can be compiled to obtain an assembly.
See [Connect SDK](connectSDK.md) for some information on how use it.
