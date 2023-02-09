# KNet: KNet Connect SDK

## Installation

KNet Connect is available in two different formats:

- dotnet tool hosted on NuGet.org: check https://www.nuget.org/packages/MASES.KNetConnect/ and https://docs.microsoft.com/en-us/dotnet/core/tools/global-tools for installation deep instructions.
- Docker image hosted on https://github.com/masesgroup/KNet/pkgs/container/mases.knetconnect: follow instruction within the page and general instruction on https://docs.docker.com

## Usage

To use the Connect interface (KNetConnect) runs a command like the following:

- **dotnet tool**

> knetconnect -s connect-standalone.properties specific-connector.properties

> knetconnect -d connect-distributed.properties

- **Docker image**

> docker run ghcr.io/masesgroup/mases.knetconnect -s connect-standalone.properties specific-connector.properties

> docker run ghcr.io/masesgroup/mases.knetconnect -d connect-distributed.properties

### Command line switch available

_knetconnect_ accepts the following command-line switch to identify its behavior:
- **d**: starts a distributed version of Connector defined in the file identified from the subsequent parameter
- **s**: starts a standalone version of Connector defined in the file identified from the subsequent parameter
- **k**: starts a KNet version (Distributed or Standalone) accepting environment variables names containing the data associated to the parameters expected from the stanard version
- other parameters in sequence are:
  - Apache Kafka Connect configuration file
  - KNet Connector configuration file
  - or in case of **k** switch is used the parameters are the environemnt variables containing the configuration data in the following form:
	- key and value separated with **=**
	- key-value pair separated with **||**
	- an example is key1=value1||key2=value2||key3
  
### Connector properties

For an overview of configuration see [Connect SDK](connectSDK.md)

