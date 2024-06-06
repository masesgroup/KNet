#!/bin/bash

# Start zookeeper
dotnet /app/MASES.KNetCLI.dll -ClassToRun ZooKeeperStart -Log4JConfiguration /app/config/log4j.properties /app/zookeeper.properties &

# Start kafka broker
dotnet /app/MASES.KNetCLI.dll -ClassToRun KafkaStart -Log4JConfiguration /app/config/log4j.properties /app/server.properties &

# Wait for any process to exit
wait -n

# Exit with status of process that exited first
exit $?