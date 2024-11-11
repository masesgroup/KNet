---
title: Docker images of .NET suite for Apache Kafka™
_description: Describes the Docker images of .NET suite for Apache Kafka™
---


> [!IMPORTANT]
> The Docker images produced from this repository uses, as base image, the one available at mcr.microsoft.com/dotnet/runtime:8.0 (latest is mcr.microsoft.com/dotnet/runtime:8.0-jammy). Within [GitHub Container Registry](https://github.com/microsoft/containerregistry) you can find many legal information, specifically read carefully the following before use the image:
> - [Container Images Legal Notice](https://github.com/microsoft/containerregistry/blob/39d2e014897475ef6cdb08e29c08645f53f0dc93/legal/Container-Images-Legal-Notice.md): maybe an updated verion is available at https://github.com/microsoft/containerregistry/blob/main/legal/Container-Images-Legal-Notice.md
> - [Linux-Legal-Metadata](https://github.com/microsoft/containerregistry/blob/39d2e014897475ef6cdb08e29c08645f53f0dc93/legal/Linux-Legal-Metadata.md): maybe a updated verion is available at https://github.com/microsoft/containerregistry/blob/main/legal/Linux-Legal-Metadata.md

# KNet: Docker images

.NET suite for Apache Kafka™ comes with a ready made Docker image can work in multiple modes, the image name is _knet_:
- it is avialble in the following registries:
  - GitHub: https://github.com/masesgroup/KNet/pkgs/container/knet
  - Docker Hub: https://hub.docker.com/repository/docker/masesgroup/knet/general
  
The container image can work in multiple modes based on the environment variable **KNET_DOCKER_RUNNING_MODE**:
- **KNET_DOCKER_RUNNING_MODE** not existent or empty: the image expect to run in command-line mode and it is the default behavior. The Docker image invokes the command-line module **KNetCLI** using the same commands available in [KNet CLI usage](usageCLI.md):
  - With the following:
  > docker run -it knet [commands]
  - the Docker image will issue the command:
  > dotnet /app/MASES.KNetCLI.dll $@

- The image can run [ZooKeeper™](https://zookeeper.apache.org/) node and/or [Apache Kafka™](https://kafka.apache.org/) broker node using specific values for **KNET_DOCKER_RUNNING_MODE**:

  - **KNET_DOCKER_RUNNING_MODE**=**zookeeper**: starts a [ZooKeeper™](https://zookeeper.apache.org/) node, defaults to run a standalone [ZooKeeper™](https://zookeeper.apache.org/) exposing on port 2181
    -  the Docker image will issue the command:
    > dotnet /app/MASES.KNetCLI.dll zookeeperstart -Log4JConfiguration /app/config_container/log4j.properties /app/config_container/zookeeper.properties
    - the image can add, or update, configuration variables of zookeeper.properties using the following pattern for environment variables:
      - Shall start with **ZOOKEEPER_**
      - Each property shall be capitalized and the '.' shall be replaced with '_'
      - The value of the environment variable is the value will be used in the configuration file
      - The default file is available at https://github.com/masesgroup/KNet/blob/master/src/container/config_container/zookeeper.properties, all configuration information are available at https://zookeeper.apache.org/doc/r3.8.3/index.html
  
  - **KNET_DOCKER_RUNNING_MODE**=**broker**: starts an [Apache Kafka™](https://kafka.apache.org/) broker node, defaults to run a standalone broker exposing on port 9092
    -  the Docker image will issue the command:
    > dotnet /app/MASES.KNetCLI.dll kafkastart -Log4JConfiguration /app/config_container/log4j.properties /app/config_container/server.properties
    - the image can add, or update, configuration variables of server.properties using the following pattern for environment variables:
      - Shall start with **KAFKA_**
      - Each property shall be capitalized and the '.' shall be replaced with '_'
      - The value of the environment variable is the value will be used in the configuration file
      - As an example: the environment variable **KAFKA_ADVERTISED_LISTENERS** represents **advertised.listeners**
      - The default file is available at https://github.com/masesgroup/KNet/blob/master/src/container/config_container/server.properties, all configuration information are available at https://kafka.apache.org/documentation/
  
  - **KNET_DOCKER_RUNNING_MODE**=**server**: starts, within the container, both a [ZooKeeper™](https://zookeeper.apache.org/) node and an [Apache Kafka™](https://kafka.apache.org/) broker node, it defaults to run exposing [ZooKeeper™](https://zookeeper.apache.org/) on port 2181 and [Apache Kafka™](https://kafka.apache.org/) broker on port 9092; the image can add, or update, configuration variables of [ZooKeeper™](https://zookeeper.apache.org/) and [Apache Kafka™](https://kafka.apache.org/) using the same pattern of previous points.

- The image can run [Apache Kafka™](https://kafka.apache.org/) in [KRaft](https://developer.confluent.io/learn/kraft/) mode using specific values for **KNET_DOCKER_RUNNING_MODE**:

  - **KNET_DOCKER_RUNNING_MODE**=**kraft-broker**: starts a [Apache Kafka™](https://kafka.apache.org/) as broker node
    -  the Docker image will issue the command:
    > dotnet /app/MASES.KNetCLI.dll kafkastart -Log4JConfiguration /app/config_container/log4j.properties /app/config_container/kraft/broker.properties
    - the image can add, or update, configuration variables of broker.properties using the following pattern for environment variables:
      - Shall start with **KRAFT_**
      - Each property shall be capitalized and the '.' shall be replaced with '_'
      - The value of the environment variable is the value will be used in the configuration file
      - The default file is available at https://github.com/masesgroup/KNet/blob/master/src/container/config_container/kraft/broker.properties, all configuration information are available at https://kafka.apache.org/documentation/
  
  - **KNET_DOCKER_RUNNING_MODE**=**kraft-controller**: starts a [Apache Kafka™](https://kafka.apache.org/) as controller node
    -  the Docker image will issue the command:
    > dotnet /app/MASES.KNetCLI.dll kafkastart -Log4JConfiguration /app/config_container/log4j.properties /app/config_container/kraft/controller.properties
    - the image can add, or update, configuration variables of controller.properties using the following pattern for environment variables:
      - Shall start with **KRAFT_**
      - Each property shall be capitalized and the '.' shall be replaced with '_'
      - The value of the environment variable is the value will be used in the configuration file
      - The default file is available at https://github.com/masesgroup/KNet/blob/master/src/container/config_container/kraft/controller.properties, all configuration information are available at https://kafka.apache.org/documentation/
  
  - **KNET_DOCKER_RUNNING_MODE**=**kraft-server**: starts a [Apache Kafka™](https://kafka.apache.org/) as server node
    -  the Docker image will issue the command:
    > dotnet /app/MASES.KNetCLI.dll kafkastart -Log4JConfiguration /app/config_container/log4j.properties /app/config_container/kraft/server.properties
    - the image can add, or update, configuration variables of server.properties using the following pattern for environment variables:
      - Shall start with **KRAFT_**
      - Each property shall be capitalized and the '.' shall be replaced with '_'
      - The value of the environment variable is the value will be used in the configuration file
      - The default file is available at https://github.com/masesgroup/KNet/blob/master/src/container/config_container/kraft/server.properties, all configuration information are available at https://kafka.apache.org/documentation/

- The image can run both Apache Connect and KNet Connect using specific values for **KNET_DOCKER_RUNNING_MODE**:
  - **KNET_DOCKER_RUNNING_MODE**=**knet-connect-standalone**: starts, within the container, a standalone KNet Connect instance
    -  the Docker image will issue the command:
    > dotnet /app/MASES.KNetConnect.dll -s -k -Log4JConfiguration /app/config_container/log4j.properties /app/config_container/connect-standalone.properties /app/config_container/connect-knet-specific.properties
    - the image can add, or update, configuration variables of connect-standalone.properties using the following pattern for environment variables:
      - Shall start with **CONNECT_**
      - Each property shall be capitalized and the '.' shall be replaced with '_'
      - The value of the environment variable is the value will be used in the configuration file
      - The default file is available at https://github.com/masesgroup/KNet/blob/master/src/container/config_container/connect-standalone.properties, all configuration information are available at https://kafka.apache.org/documentation/
    - the image can add, or update, configuration variables of connect-knet-specific.properties using the following pattern for environment variables:
      - Shall start with **KNETCONNECT_**
      - Each property shall be capitalized and the '.' shall be replaced with '_'
      - The value of the environment variable is the value will be used in the configuration file
      - The default file is available at https://github.com/masesgroup/KNet/blob/master/src/container/config_container/connect-knet-specific.properties, all configuration information depends from the connector in use
  
  - **KNET_DOCKER_RUNNING_MODE**=**connect-standalone**: starts, within the container, a standalone Apache Connect instance
    -  the Docker image will issue the command:
    > dotnet /app/MASES.KNetConnect.dll -s -Log4JConfiguration /app/config_container/log4j.properties /app/config_container/connect-standalone.properties /app/config_container/connect-knet-specific.properties
    - the image can add, or update, configuration variables of connect-standalone.properties and connect-knet-specific.properties using the same pattern of **knet-connect-standalone**:
  
  - **KNET_DOCKER_RUNNING_MODE**=**knet-connect-standalone-server**: starts, within the container, a [ZooKeeper™](https://zookeeper.apache.org/) node and an [Apache Kafka™](https://kafka.apache.org/) broker node like in **server**, then starts the same command of **knet-connect-standalone**; this is an autonoumous instance can be used for development or any other possible usage
    - the image can add, or update, configuration variables of using the same pattern of **zookeeper**, **broker** and **knet-connect-standalone**
  
  - **KNET_DOCKER_RUNNING_MODE**=**connect-standalone-server**: starts, within the container, a [ZooKeeper™](https://zookeeper.apache.org/) node and an [Apache Kafka™](https://kafka.apache.org/) broker node like in **server**, then starts the same command of **connect-standalone**; this is an autonoumous instance can be used for development or any other possible usage
    - the image can add, or update, configuration variables of using the same pattern of **zookeeper**, **broker** and **connect-standalone**
  
  - **KNET_DOCKER_RUNNING_MODE**=**knet-connect-distributed**: starts, within the container, a distributed KNet Connect instance
    -  the Docker image will issue the command:
    > dotnet /app/MASES.KNetConnect.dll -d -k -Log4JConfiguration /app/config_container/log4j.properties /app/config_container/connect-distributed.properties
    - the image can add, or update, configuration variables of connect-standalone.properties using the following pattern for environment variables:
      - Shall start with **CONNECT_**
      - Each property shall be capitalized and the '.' shall be replaced with '_'
      - The value of the environment variable is the value will be used in the configuration file
      - The default file is available at https://github.com/masesgroup/KNet/blob/master/src/container/config_container/connect-distributed.properties, all configuration information are available at https://kafka.apache.org/documentation/
  
  - **KNET_DOCKER_RUNNING_MODE**=**connect-distributed**: starts, within the container, a distributed Apache Connect instance
    -  the Docker image will issue the command:
    > dotnet /app/MASES.KNetConnect.dll -d -Log4JConfiguration /app/config_container/log4j.properties /app/config_container/connect-distributed.properties
    - the image can add, or update, configuration variables of connect-distributed.propertiesusing the same pattern of **knet-connect-distributed**:

  - All previous commands use a single configuration file for logging; the image can add, or update, configuration variables of log4j.properties using the following pattern for environment variables:
    - Shall start with **LOG4J_**
    - Each property shall be capitalized and the '.' shall be replaced with '_'
    - The value of the environment variable is the value will be used in the configuration file
    - The default file is available at https://github.com/masesgroup/KNet/blob/master/src/container/config_container/log4j.properties
