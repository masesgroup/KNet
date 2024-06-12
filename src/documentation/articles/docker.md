---
title: Docker images of .NET suite for Apache Kafka
_description: Describes the Docker images of .NET suite for Apache Kafka
---

# KNet: Docker images

.NET suite for Apache Kafka comes with a ready made Docker image can work in multiple modes:
- _knet_: 
  - it is a CLI invocable from Docker with the following command (see [KNet CLI usage](usageCLI.md) for command line information):
  > docker run -it knet [commands]
  - it supports server mode execution if the environment variable **KNET_DOCKER_RUNNING_MODE** reports the following values:
    - **zookeeper**: starts a zookeeper node, defaults to run a standalone zookeeper exposing on port 2181
	- **broker**: starts an Apache Kafka node, defaults to run a standalone broker exposing on port 9092
	- **server**: starts, within the container, both a zookeeper node and an Apache Kafka node, it defaults to run exposing zookeeper on port 2181 and Kafka on port 9092 

All kafka properties can be updated using environment variables in the following form:
- Shall start with **KAFKA_**
- Each property shall be capitalized and the '.' shall be replaced with '_'
- The value of the environment variable is the value will be used in the configuration file

As an example: the environment variable **KAFKA_ADVERTISED_LISTENERS** represents **advertised.listeners**.

- _knetconnect_: it is the KNet Connect invocable from Docker, see [KNet Connect usage](usageConnect.md) for command line information

> [!IMPORTANT]
> The Docker images produced from this repository uses, as base image, the one available at mcr.microsoft.com/dotnet/runtime:6.0 (latest is mcr.microsoft.com/dotnet/runtime:6.0-jammy). Within [GitHub Container Registry](https://github.com/microsoft/containerregistry) you can find many legal information, specifically read carefully the following before use the image:
> - [Container Images Legal Notice](https://github.com/microsoft/containerregistry/blob/39d2e014897475ef6cdb08e29c08645f53f0dc93/legal/Container-Images-Legal-Notice.md): maybe an updated verion is available at https://github.com/microsoft/containerregistry/blob/main/legal/Container-Images-Legal-Notice.md
> - [Linux-Legal-Metadata](https://github.com/microsoft/containerregistry/blob/39d2e014897475ef6cdb08e29c08645f53f0dc93/legal/Linux-Legal-Metadata.md): maybe a updated verion is available at https://github.com/microsoft/containerregistry/blob/main/legal/Linux-Legal-Metadata.md