#!/bin/bash

ls -las /app

# Start zookeeper
dotnet /app/KNetCLI.dll -ClassToRun ZooKeeperStart /app/config/zookeeper.config &

# Start kafka broker
dotnet /app/KNetCLI.dll -ClassToRun KafkaStart /app/config/zookeeper.config &

# Wait for any process to exit
wait -n

# Exit with status of process that exited first
exit $?