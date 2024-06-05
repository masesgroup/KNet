#!/bin/bash

# Start zookeeper
dotnet KNetCLI.dll -ClassToRun ZooKeeperStart ./config/zookeeper.config &

# Start kafka broker
dotnet KNetCLI.dll -ClassToRun KafkaStart ./config/zookeeper.config &

# Wait for any process to exit
wait -n

# Exit with status of process that exited first
exit $?