#!/bin/bash

# Start zookeeper
dotnet /app/MASES.KNetCLI.dll -ClassToRun ZooKeeperStart /app/config/zookeeper.properties &

# Start kafka broker
dotnet /app/MASES.KNetCLI.dll -ClassToRun KafkaStart /app/config/server.properties &

# Wait for any process to exit
wait -n

# Exit with status of process that exited first
exit $?