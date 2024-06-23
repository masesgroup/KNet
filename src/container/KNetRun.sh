#!/bin/bash -e

if [[ -z "${KNET_DOCKER_RUNNING_MODE}" ]]; then
	echo "Starting command line execution of KNetCLI with arguments: $@"
	# Generic execution
	dotnet /app/MASES.KNetCLI.dll $@
else
### inherited from https://github.com/wurstmeister/kafka-docker/blob/901c084811fa9395f00af3c51e0ac6c32c697034/start-kafka.sh

	# Store original IFS config, so we can restore it at various stages
	ORIG_IFS=$IFS

	if [[ -z "$KAFKA_PORT" ]]; then
		export KAFKA_PORT=9092
	fi

	if [[ -z "$KAFKA_ADVERTISED_PORT" && \
	-z "$KAFKA_LISTENERS" && \
	-z "$KAFKA_ADVERTISED_LISTENERS" && \
	-S /var/run/docker.sock ]]; then
		KAFKA_ADVERTISED_PORT=$(docker port "$(hostname)" $KAFKA_PORT | sed -r 's/.*:(.*)/\1/g' | head -n1) 
		export KAFKA_ADVERTISED_PORT
	fi
	
	if [[ -z "$KAFKA_BROKER_ID" ]]; then
		if [[ -n "$BROKER_ID_COMMAND" ]]; then
			KAFKA_BROKER_ID=$(eval "$BROKER_ID_COMMAND")
			export KAFKA_BROKER_ID
		else
			# By default auto allocate broker ID
			export KAFKA_BROKER_ID=-1
		fi
	fi

	if [[ -n "$KAFKA_HEAP_OPTS" ]]; then
		sed -r -i 's/(export KAFKA_HEAP_OPTS)="(.*)"/\1="'"$KAFKA_HEAP_OPTS"'"/g' "$KAFKA_HOME/bin/kafka-server-start.sh"
		unset KAFKA_HEAP_OPTS
	fi
	
	if [[ -n "$HOSTNAME_COMMAND" ]]; then
		HOSTNAME_VALUE=$(eval "$HOSTNAME_COMMAND")
	
		# Replace any occurrences of _{HOSTNAME_COMMAND} with the value
		IFS=$'\n'
		for VAR in $(env); do
			if [[ $VAR =~ ^KAFKA_ && "$VAR" =~ "_{HOSTNAME_COMMAND}" ]]; then
				eval "export ${VAR//_\{HOSTNAME_COMMAND\}/$HOSTNAME_VALUE}"
			fi
		done
		IFS=$ORIG_IFS
	fi
	
	if [[ -n "$PORT_COMMAND" ]]; then
		PORT_VALUE=$(eval "$PORT_COMMAND")
	
		# Replace any occurrences of _{PORT_COMMAND} with the value
		IFS=$'\n'
		for VAR in $(env); do
			if [[ $VAR =~ ^KAFKA_ && "$VAR" =~ "_{PORT_COMMAND}" ]]; then
			eval "export ${VAR//_\{PORT_COMMAND\}/$PORT_VALUE}"
			fi
		done
		IFS=$ORIG_IFS
	fi
	
	if [[ -n "$RACK_COMMAND" && -z "$KAFKA_BROKER_RACK" ]]; then
		KAFKA_BROKER_RACK=$(eval "$RACK_COMMAND")
		export KAFKA_BROKER_RACK
	fi
	
	# Try and configure minimal settings or exit with error if there isn't enough information
	if [[ -z "$KAFKA_ADVERTISED_HOST_NAME$KAFKA_LISTENERS" ]]; then
		# Maintain existing behaviour
		# If HOSTNAME_COMMAND is provided, set that to the advertised.host.name value if listeners are not defined.
		export KAFKA_ADVERTISED_HOST_NAME="$HOSTNAME_VALUE"
	fi
	
	#Issue newline to config file in case there is not one already
	echo "" >> /app/config_container/server.properties
	
	#Issue newline to config file in case there is not one already
	echo "" >> /app/config_container/zookeeper.properties

	#Issue newline to config file in case there is not one already
	echo "" >> /app/config_container/connect-distributed.properties
	
	#Issue newline to config file in case there is not one already
	echo "" >> /app/config_container/connect-standalone.properties

	#Issue newline to config file in case there is not one already
	echo "" >> /app/config_container/connect-knet-specific.properties
	
	(
		function updateConfig() {
			key=$1
			value=$2
			file=$3
	
			# Omit $value here, in case there is sensitive information
			echo "[Configuring] '$key' in '$file'"
	
			# If config exists in file, replace it. Otherwise, append to file.
			if grep -E -q "^#?$key=" "$file"; then
				sed -r -i "s@^#?$key=.*@$key=$value@g" "$file" #note that no config values may contain an '@' char
			else
				echo "$key=$value" >> "$file"
			fi
		}
	
		# Fixes #312
		# KAFKA_VERSION + KAFKA_HOME + grep -rohe KAFKA[A-Z0-0_]* /opt/kafka/bin | sort | uniq | tr '\n' '|'
		EXCLUSIONS="|KAFKA_VERSION|KAFKA_HOME|KAFKA_DEBUG|KAFKA_GC_LOG_OPTS|KAFKA_HEAP_OPTS|KAFKA_JMX_OPTS|KAFKA_JVM_PERFORMANCE_OPTS|KAFKA_LOG|KAFKA_OPTS|"
	
		# Read in env as a new-line separated array. This handles the case of env variables have spaces and/or carriage returns. See #313
		IFS=$'\n'
		for VAR in $(env)
		do
			env_var=$(echo "$VAR" | cut -d= -f1)
			if [[ "$EXCLUSIONS" = *"|$env_var|"* ]]; then
				echo "Excluding $env_var from broker config"
				continue
			fi
	
			if [[ $env_var =~ ^KAFKA_ ]]; then
				kafka_name=$(echo "$env_var" | cut -d_ -f2- | tr '[:upper:]' '[:lower:]' | tr _ .)
				updateConfig "$kafka_name" "${!env_var}" "/app/config_container/server.properties"
			fi
			
			if [[ $env_var =~ ^ZOOKEEPER_ ]]; then
				zookeeper_name=$(echo "$env_var" | cut -d_ -f2- | tr '[:upper:]' '[:lower:]' | tr _ .)
				updateConfig "$zookeeper_name" "${!env_var}" "/app/config_container/zookeeper.properties"
			fi
	
			if [[ $env_var =~ ^LOG4J_ ]]; then
				log4j_name=$(echo "$env_var" | tr '[:upper:]' '[:lower:]' | tr _ .)
				updateConfig "$log4j_name" "${!env_var}" "/app/config_container/log4j.properties"
			fi
			
			if [[ $env_var =~ ^CONNECT_ ]]; then
				connect_standalone_name=$(echo "$env_var" | tr '[:upper:]' '[:lower:]' | tr _ .)
				updateConfig "$connect_standalone_name" "${!env_var}" "/app/config_container/connect-standalone.properties"
			fi
			
			if [[ $env_var =~ ^CONNECT_ ]]; then
				connect_distributed_name=$(echo "$env_var" | tr '[:upper:]' '[:lower:]' | tr _ .)
				updateConfig "$connect_distributed_name" "${!env_var}" "/app/config_container/connect-distributed.properties"
			fi
			
			if [[ $env_var =~ ^KNET_CONNECT_ ]]; then
				knet_connect_specific_name=$(echo "$env_var" | tr '[:upper:]' '[:lower:]' | tr _ .)
				updateConfig "$knet_connect_specific_name" "${!env_var}" "/app/config_container/connect-knet-specific.properties"
			fi
		done
	)

### end inherited from https://github.com/wurstmeister/kafka-docker/blob/901c084811fa9395f00af3c51e0ac6c32c697034/start-kafka.sh

	if [ ${KNET_DOCKER_RUNNING_MODE} = "zookeeper" ]; then
		echo "Starting zookeeper"
		# Start zookeeper
		dotnet /app/MASES.KNetCLI.dll zookeeperstart -Log4JConfiguration /app/config_container/log4j.properties /app/config_container/zookeeper.properties
	elif [ ${KNET_DOCKER_RUNNING_MODE} = "broker" ]; then
		echo "Starting broker"
		# Start kafka broker
		dotnet /app/MASES.KNetCLI.dll kafkastart -Log4JConfiguration /app/config_container/log4j.properties /app/config_container/server.properties
	elif [ ${KNET_DOCKER_RUNNING_MODE} = "server" ]; then
		echo "Starting zookeeper"
		# Start zookeeper
		dotnet /app/MASES.KNetCLI.dll zookeeperstart -Log4JConfiguration /app/config_container/log4j.properties /app/config_container/zookeeper.properties &
	
		echo "Starting broker"   
		# Start kafka broker
		dotnet /app/MASES.KNetCLI.dll kafkastart -Log4JConfiguration /app/config_container/log4j.properties /app/config_container/server.properties &
		
		# Wait for any process to exit
		wait -n
		
		# Exit with status of process that exited first
		exit $?
	elif [ ${KNET_DOCKER_RUNNING_MODE} = "knet-connect-standalone" ]; then
		echo "Starting KNet Connect standalone mode"
		# Start zookeeper
		dotnet /app/MASES.KNetConnect.dll -s -k -Log4JConfiguration /app/config_container/log4j.properties /app/config_container/connect-standalone.properties /app/config_container/connect-knet-specific.properties &

		# Wait for any process to exit
		wait -n
		
		# Exit with status of process that exited first
		exit $?
	elif [ ${KNET_DOCKER_RUNNING_MODE} = "connect-standalone" ]; then
		echo "Starting Apache Kafka Connect standalone mode"
		# Start zookeeper
		dotnet /app/MASES.KNetConnect.dll -s -Log4JConfiguration /app/config_container/log4j.properties /app/config_container/connect-standalone.properties /app/config_container/connect-knet-specific.properties &

		# Wait for any process to exit
		wait -n
		
		# Exit with status of process that exited first
		exit $?
	elif [ ${KNET_DOCKER_RUNNING_MODE} = "knet-connect-standalone-server" ]; then
		echo "Starting zookeeper"
		# Start zookeeper
		dotnet /app/MASES.KNetCLI.dll zookeeperstart -Log4JConfiguration /app/config_container/log4j.properties /app/config_container/zookeeper.properties  &
	
		echo "Starting broker"   
		# Start kafka broker
		dotnet /app/MASES.KNetCLI.dll kafkastart -Log4JConfiguration /app/config_container/log4j.properties /app/config_container/server.properties &
		
		echo "Starting KNet Connect standalone full mode"
		# Start zookeeper
		dotnet /app/MASES.KNetConnect.dll -s -k -Log4JConfiguration /app/config_container/log4j.properties /app/config_container/connect-standalone.properties /app/config_container/connect-knet-specific.properties &

		# Wait for any process to exit
		wait -n
		
		# Exit with status of process that exited first
		exit $?
	elif [ ${KNET_DOCKER_RUNNING_MODE} = "connect-standalone-server" ]; then
		echo "Starting zookeeper"
		# Start zookeeper
		dotnet /app/MASES.KNetCLI.dll zookeeperstart -Log4JConfiguration /app/config_container/log4j.properties /app/config_container/zookeeper.properties  &
	
		echo "Starting broker"   
		# Start kafka broker
		dotnet /app/MASES.KNetCLI.dll kafkastart -Log4JConfiguration /app/config_container/log4j.properties /app/config_container/server.properties &
		
		echo "Starting Apache Kafka Connect standalone full mode"
		# Start zookeeper
		dotnet /app/MASES.KNetConnect.dll -s -Log4JConfiguration /app/config_container/log4j.properties /app/config_container/connect-standalone.properties /app/config_container/connect-knet-specific.properties &

		# Wait for any process to exit
		wait -n
		
		# Exit with status of process that exited first
		exit $?
	elif [ ${KNET_DOCKER_RUNNING_MODE} = "knet-connect-distributed" ]; then
		echo "Starting KNet Connect distributed mode"
		# Start zookeeper
		dotnet /app/MASES.KNetConnect.dll -d -k -Log4JConfiguration /app/config_container/log4j.properties /app/config_container/connect-distributed.properties &

		# Wait for any process to exit
		wait -n
		
		# Exit with status of process that exited first
		exit $?
	elif [ ${KNET_DOCKER_RUNNING_MODE} = "connect-distributed" ]; then
		echo "Starting Apache Kafka Connect distributed mode"
		# Start zookeeper
		dotnet /app/MASES.KNetConnect.dll -d -Log4JConfiguration /app/config_container/log4j.properties /app/config_container/connect-distributed.properties &

		# Wait for any process to exit
		wait -n
		
		# Exit with status of process that exited first
		exit $?
	else
		echo "KNET_DOCKER_RUNNING_MODE exist, but its value (${KNET_DOCKER_RUNNING_MODE}) is not zookeeper, broker, server, (knet)connect-standalone, (knet)connect-distributed or (knet)connect-standalone-server"
	fi
fi