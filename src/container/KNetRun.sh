#!/bin/bash

if [ $# -eq 0 ]; then
	echo "Starting zookeeper"
    # Start zookeeper
    dotnet /app/MASES.KNetCLI.dll -ClassToRun ZooKeeperStart -Log4JConfiguration /app/config_alone/log4j.properties /app/config_alone/zookeeper.properties &
   
	echo "Starting broker"   
    # Start kafka broker
    dotnet /app/MASES.KNetCLI.dll -ClassToRun KafkaStart -Log4JConfiguration /app/config_alone/log4j.properties /app/config_alone/server.properties &
    
    # Wait for any process to exit
    wait -n
    
    # Exit with status of process that exited first
    exit $?
fi

if [ $1 = "zookeeper" ]; then
	echo "Starting zookeeper"
    # Start zookeeper
    dotnet /app/MASES.KNetCLI.dll -ClassToRun ZooKeeperStart -Log4JConfiguration /app/config_alone/log4j.properties /app/config_alone/zookeeper.properties
elif [ $1 = "broker" ]; then
	echo "Starting broker"
    # Start kafka broker
    dotnet /app/MASES.KNetCLI.dll -ClassToRun KafkaStart -Log4JConfiguration /app/config_alone/log4j.properties /app/config_alone/server.properties
else
	echo "Starting execution of $@"
	# Generic execution
	dotnet /app/MASES.KNetCLI.dll $@
fi