---
title: Kafka™ Connect SDK of .NET suite for Apache Kafka™
_description: Describes how to use Kafka™ Connect SDK of .NET suite for Apache Kafka™
---

# KNet: KNet Connect SDK

## Create a new connector based on KNet Connect SDK

To start to use KNet Connect SDK and write a connector in C# the following steps can be used:
1. Install the available templates following the [template usage article](usageTemplates.md)
2. Execute one the following commands:
  - Sink connector:
    ```sh
    dotnet new knetConnectSink
    ```
  - Source connector:
    ```sh
    dotnet new knetConnectSource
    ```
3. Update the code to define the needed behavior. 

## Execution

The connector can be used from a JVM hosted runtime and from a .NET hosted runtime.
For an overview of configuration see [Connect SDK](connectSDK.md)

### JVM hosted runtime

To use the connector from a JVM hosted runtime follow the instructions available at https://kafka.apache.org/documentation/#connect and https://kafka.apache.org/quickstart#quickstart_kafkaconnect.

### .NET hosted runtime

KNet Connect .NET hosted runtime is available in two different formats:

- **dotnet tool** hosted on [NuGet](https://www.nuget.org/packages/MASES.KNetConnect/): check https://www.nuget.org/packages/MASES.KNetConnect/ and https://docs.microsoft.com/en-us/dotnet/core/tools/global-tools for installation deep instructions.
- **Docker image** hosted on [GitHub](https://github.com/masesgroup/KNet/pkgs/container/knetconnect) or [Docker Hub](https://hub.docker.com/repository/docker/masesgroup/knetconnect/general): follow instruction within the page and general instruction on https://docs.docker.com

> [!IMPORTANT]
> The **dotnet tool** needs a JRE/JDK installed within the system

#### Usage

To use the .NET hosted runtime Connect interface (KNetConnect) runs a command like the following:

- **dotnet tool**

```sh
knetconnect -s connect-standalone.properties specific-connector.properties
```

```sh
knetconnect -d connect-distributed.properties
```

> [!IMPORTANT]
> If the previous commands raise the error described in [Intel CET and KNet](usage.md#intel-cet-and-knet) the only solution is to apply the following workaround (within an **elevated shell**) and disable CET:
> ```sh
> 	reg add "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\knetconnect.exe" /v MitigationOptions /t REG_BINARY /d "0000000000000000000000000000002000" /f
> ```

- **Docker image**

```sh
docker run ghcr.io/masesgroup/knetconnect -s connect-standalone.properties specific-connector.properties
```

```sh
docker run masesgroup/knetconnect -s connect-standalone.properties specific-connector.properties
```

```sh
docker run ghcr.io/masesgroup/knetconnect -d connect-distributed.properties
```

```sh
docker run masesgroup/knetconnect -d connect-distributed.properties
```

#### Command line switch available

_knetconnect_ accepts the following command-line switch to identify its behavior:
- **d**: starts a distributed version of Connector defined in the file identified from the subsequent parameter
- **s**: starts a standalone version of Connector defined in the file identified from the subsequent parameter
- **k**: starts a KNet version (Distributed or Standalone) accepting environment variables names containing the data associated to the parameters expected from the stanard version
- other parameters in sequence are:
  - Apache Kafka™ Connect configuration file
  - KNet Connector configuration file
  - or in case of **k** switch is used the parameters are the environemnt variables containing the configuration data in the following form:
	- key and value separated with **=**
	- key-value pair separated with **||**
	- an example is key1=value1||key2=value2||key3
