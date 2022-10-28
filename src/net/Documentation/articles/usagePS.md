# KNet: PowerShell Module

## Installation

To install the tool executes the following command within a PowerShell shell:

> Install-Module -Name MASES.KNetPS

## Usage

To use the PowerShell interface (JNetPS) runs the following commands within a **PowerShell** shell:

### Initialization

* The following cmdlet initialize the environment:

> Start-KNetPS [arguments]

then the user can use objects created using **New-KObject**, otherwise it is possible to invoke the desired command listed below.

### Commands available

_knetps_ accepts the following cmdlets:

* **Start-KNetPS**: Initialize the engine and can be the first command to be invoked. The arguments are:
  * Inherited from JnetPS:
	* LicensePath
	* JDKHome
	* JVMPath
	* JNIVerbosity
	* JNIOutputFile
	* JmxPort
	* EnableDebug
	* JavaDebugPort
	* DebugSuspendFlag
	* JavaDebugOpts
	* HeapSize
	* InitialHeapSize
	* LogClassPath
  * Specific of KnetPS:
    * ScalaVersion
	* KafkaJarLocation
	* Log4JPath
	* LogPath
* **New-KObject**: Creates a new JVM object of the class specified in argument using the parameters within command line for constructor. The arguments are:
  * Inherited from JnetPS:
    * Class
    * Arguments
  * Specific of KnetPS:
      * ScalaVersion
	  * KafkaJarLocation
	  * Log4JPath
	  * LogPath	  
* **Start-AclCommand: start AclCommand. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-BrokerApiVersionsCommand: start AclCommand. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-ConfigCommand: start AclCommand. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-ConsumerGroupCommand: start AclCommand. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-DelegationTokenCommand: start AclCommand. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-DeleteRecordsCommand: start AclCommand. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-FeatureCommand: start AclCommand. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-LeaderElectionCommand: start AclCommand. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-LogDirsCommand: start AclCommand. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-MetadataQuorumCommand: start AclCommand. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-ReassignPartitionsCommand: start AclCommand. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-TopicCommand: start AclCommand. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-ZkSecurityMigrator: start AclCommand. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-KafkaStart: start AclCommand. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-ZooKeeperShell: start AclCommand. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-ZooKeeperStart: start AclCommand. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-MetadataShell: start AclCommand. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-ClusterTool: start AclCommand. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-ConsoleConsumer: start AclCommand. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-ConsoleProducer: start AclCommand. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-ConsumerPerformance: start AclCommand. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-DumpLogSegments: start AclCommand. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-GetOffsetShell: start AclCommand. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-MirrorMaker: start AclCommand. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-ProducerPerformance: start AclCommand. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-ReplicaVerificationTool: start AclCommand. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-StorageTool: start AclCommand. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-StreamsResetter: start AclCommand. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-TransactionsCommand: start AclCommand. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-VerifiableConsumer: start AclCommand. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-VerifiableProducer: start AclCommand. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-ConnectDistributed: start AclCommand. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-ConnectStandalone: start AclCommand. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
* **Start-MirrorMaker2: start AclCommand. The arguments are:
  * All available arguments of Start-KNetPS;
  * Arguments: a string containing the arguments accepted from the Java Main-Class
	  
