---
title: How to build .NET suite for Apache Kafka™
_description: Describes how to build the Java™/JVM™ suite for .NET from scatch
---

# KNet: How to build from scratch

If the user clones the repo, the following steps shall be done to use the project. The full steps can be found within the repo, under the **.github\workflows** folder.

Let's start with the tools needed to achieve the goal:
* An installed version of __git for Windows__
* An installed version of .NET 8/9 SDK
* An installed version of Apache Maven (> 3.8.1)

Then the steps are the following (the steps are made for Windows shell):

* Clone the repository in a folder (named for convenience RootFolder)

  > cd RootFolder
  > git clone https://github.com/masesgroup/KNet.git
  >

* The project now needs to compile Java™ classes and obtains the Maven artifacts; this is done with a single step (it is important to use the **package** key as command for Maven):

  > cd RootFolder
  > {PathToMavenInstallation}\bin\mvn -f src/java/knet/pom.xml package
  >

  * The result of this step produces the artifacts within RootFolder\jars folder.

* The next step builds the executables:

  > cd RootFolder
  > dotnet build --no-incremental --configuration Release /p:Platform="Any CPU" src\net\KNetCLI\KNetCLI.csproj
  >

  * The previous command generates many folders under RootFolder\bin folder; each folder refers to the usable .NET version;
* The compilation does not complete the preparation; in the last step the developer shall make some manual copy:
  * Copy the **RootFolder\jars** folder within each runtime folder under **RootFolder\bin**
  * Copy the **RootFolder\src\config** folder within each runtime folder under **RootFolder\bin**.
  
The final result shall look like this:
* RootFolder
  * bin
    * net8.0
      * config
	  * jars
	  * other folders
    * net9.0
      * config
	  * jars
	  * other folders
    * net462
      * config
	  * jars
  * Other folders