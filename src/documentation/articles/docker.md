---
title: Docker images of .NET suite for Apache Kafka
_description: Describes the Docker images of .NET suite for Apache Kafka
---

# KNet: Docker images

.NET suite for Apache Kafka comes with some ready made Docker images:
- KNet CLI: see [KNet CLI usage](usageCLI.md)
- KNet Connect: see [KNet Connect usage](usageConnect.md)

> [!IMPORTANT]
> The Docker images produced from this repository uses, as base image, the one available at mcr.microsoft.com/dotnet/runtime:6.0 (latest is mcr.microsoft.com/dotnet/runtime:6.0-jammy). Within [GitHub Container Registry](https://github.com/microsoft/containerregistry) you can find many legal information, specifically read carefully the following before use the image:
> - [Container Images Legal Notice](https://github.com/microsoft/containerregistry/blob/39d2e014897475ef6cdb08e29c08645f53f0dc93/legal/Container-Images-Legal-Notice.md): maybe an updated verion is available at https://github.com/microsoft/containerregistry/blob/main/legal/Container-Images-Legal-Notice.md
> - [Linux-Legal-Metadata](https://github.com/microsoft/containerregistry/blob/39d2e014897475ef6cdb08e29c08645f53f0dc93/legal/Linux-Legal-Metadata.md): maybe a updated verion is available at https://github.com/microsoft/containerregistry/blob/main/legal/Linux-Legal-Metadata.md