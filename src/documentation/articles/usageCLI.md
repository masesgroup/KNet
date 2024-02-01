---
title: CLI interface of .NET suite for Apache Kafka
_description: Describes how to use CLI interface of .NET suite for Apache Kafka
---

# KNet: CLI

## Installation

KNet CLI is available in two different formats:

- dotnet tool hosted on NuGet.org: check https://www.nuget.org/packages/MASES.KNetCLI/ and https://docs.microsoft.com/en-us/dotnet/core/tools/global-tools for installation deep instructions.
- Docker image hosted on [GitHub](https://github.com/masesgroup/KNet/pkgs/container/knet) and [Docker Hub](https://hub.docker.com/repository/docker/masesgroup/knet/general): follow instruction within the page and general instruction on https://docs.docker.com

## Usage

### Execute an Apache Kafka command

To use the CLI interface (KNetCLI) runs a command like the following:

- **dotnet tool**

> knet -ClassToRun ConsoleConsumer --bootstrap-server SERVER-ADDRESS:9093 --topic topic_name --from-beginning

- **Docker image**

> docker run ghcr.io/masesgroup/knet -ClassToRun ConsoleConsumer --bootstrap-server SERVER-ADDRESS:9093 --topic topic_name --from-beginning

> docker run masesgroup/knet -ClassToRun ConsoleConsumer --bootstrap-server SERVER-ADDRESS:9093 --topic topic_name --from-beginning

### Execute an interactive shell

To use the CLI interface (KNetCLI) in interactive mode runs a command like the following:

- **dotnet tool**

> knet -i

- **Docker image**

> docker run ghcr.io/masesgroup/knet -i

> docker run masesgroup/knet -i

### Execute in script based mode

To use the CLI interface (KNetCLI) in script based mode runs a command like the following:

- **dotnet tool**

> knet -s path-to-script

- **Docker image**

> docker run ghcr.io/masesgroup/knet -s path-to-script

> docker run masesgroup/knet -s path-to-script


### Command line switches available

_knetcli_ needs at least **ClassToRun**, **Interactive** or **Script** command-line switch to identify its behavior. Here the list:
- **ClassToRun**: has precedence to all others and needs a second parameter which identify the command class to be executed
- **Interactive** (**i**): starts an interactive session where the user can write code like in a REPL shell, optionally can be set **JarList**, **NamespaceList** and **ImportList**
- **Script** (**s**): start a session to execute the script of the second parameter, optionally can be set **JarList**, **NamespaceList** and **ImportList**
- **NoLogo** (**nl**): do not display initial informative string

Other options on [Command line switch](commandlineswitch.md) page.
