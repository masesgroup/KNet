# KNet: KNet Connect SDK

## Installation

KNet Connect is available in two different formats:

- dotnet tool hosted on NuGet.org: check https://www.nuget.org/packages/MASES.KNetConnect/ and https://docs.microsoft.com/en-us/dotnet/core/tools/global-tools for installation deep instructions.
- Docker image hosted on https://github.com/masesgroup/KNet/pkgs/container/mases.knetconnect: follow instruction within the page and general instruction on https://docs.docker.com

## Usage

To use the Connect interface (KNetConnect) runs a command like the following:

- **dotnet tool**

> knetconnect -ClassToRun ConsoleConsumer --bootstrap-server SERVER-ADDRESS:9093 --topic topic_name --from-beginning

- **Docker image**

> docker run ghcr.io/masesgroup/mases.knetconnect -ClassToRun ConsoleConsumer --bootstrap-server SERVER-ADDRESS:9093 --topic topic_name --from-beginning

### Command line switch available

_knetcli_ needs at least **ClassToRun** command-line switch to identify its behavior.
Other options on [Command line switch](commandlineswitch.md) page.
