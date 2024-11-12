/*
 *  Copyright 2024 MASES s.r.l.
 *
 *  Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 *
 *  http://www.apache.org/licenses/LICENSE-2.0
 *
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License.
 *
 *  Refer to LICENSE for more information.
 */

// Copied from original Apache Kafka source file ConnectStandalone.java

package org.mases.knet.developed.connect.cli;

import com.fasterxml.jackson.core.exc.StreamReadException;
import com.fasterxml.jackson.core.type.TypeReference;
import com.fasterxml.jackson.databind.DatabindException;
import com.fasterxml.jackson.databind.DeserializationFeature;
import com.fasterxml.jackson.databind.ObjectMapper;
import org.apache.kafka.common.utils.Exit;
import org.apache.kafka.common.utils.Utils;
import org.apache.kafka.connect.errors.ConnectException;
import org.apache.kafka.connect.runtime.Connect;
import org.apache.kafka.connect.runtime.Herder;
import org.apache.kafka.connect.runtime.AbstractHerder;
import org.apache.kafka.connect.runtime.standalone.StandaloneHerder;
import org.apache.kafka.connect.runtime.Worker;
import org.apache.kafka.connect.runtime.WorkerConfig;
import org.apache.kafka.connect.runtime.rest.entities.ConnectorInfo;
import org.apache.kafka.connect.runtime.rest.entities.CreateConnectorRequest;
import org.apache.kafka.connect.util.FutureCallback;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.io.File;
import java.net.URI;
import java.util.Arrays;
import java.io.IOException;
import java.nio.file.Paths;
import java.util.Collections;
import java.util.Map;

import static org.apache.kafka.connect.runtime.ConnectorConfig.NAME_CONFIG;

public abstract class AbstractConnectCli<H extends AbstractHerder, T extends WorkerConfig> extends org.apache.kafka.connect.cli.AbstractConnectCli<H, T> {
    private static final Logger log = LoggerFactory.getLogger(AbstractConnectCli.class);
    private static final String keyValueSeparator = "=";
    private static final String keyValueSeparatorEnv = "KNET_CONNECT_KEYVALUE_SEPARATOR";
    private static final String elementSeparator = "___";
    private static final String elementSeparatorEnv = "KNET_CONNECT_ELEMENT_SEPARATOR";
    private final String[] args;

    protected AbstractConnectCli(String... args) {
        super(args);
        this.args = args;
    }

    public void run() {
        if (args.length < 1 || Arrays.asList(args).contains("--help")) {
            log.info("Usage: {}", usage());
            Exit.exit(1);
        }

        try {
            Map<String, String> workerProps = mapFromArgument(args[0]);
            String[] extraArgs = Arrays.copyOfRange(args, 1, args.length);
            Connect<H> connect = this.startConnect(workerProps);
            processExtraArgs(connect, extraArgs);

            // Shutdown will be triggered by Ctrl-C or via HTTP shutdown request
            connect.awaitStop();
        } catch (Throwable t) {
            log.error("Stopping due to error", t);
            Exit.exit(2);
        }
    }

    @Override
    public void processExtraArgs(Connect<H> connect, String[] extraArgs) {
        try {
            for (final String connectorConfigFile : extraArgs) {
                CreateConnectorRequest createConnectorRequest = parseConnectorConfigurationFile(connectorConfigFile);
                FutureCallback<Herder.Created<ConnectorInfo>> cb = new FutureCallback<>((error, info) -> {
                    if (error != null)
                        log.error("Failed to create connector for {}", connectorConfigFile);
                    else
                        log.info("Created connector {}", info.result().name());
                });
                connect.herder().putConnectorConfig(
                        createConnectorRequest.name(), createConnectorRequest.config(),
                        createConnectorRequest.initialTargetState(),
                        false, cb);
                cb.get();
            }
            AbstractHerder herder = connect.herder();
            if (herder instanceof StandaloneHerder) {
                ((StandaloneHerder)herder).ready();
            }
        } catch (Throwable t) {
            log.error("Stopping after connector error", t);
            connect.stop();
            Exit.exit(3);
        }
    }

    /**
     * Parse a connector configuration file into a {@link CreateConnectorRequest}. The file can have any one of the following formats (note that
     * we attempt to parse the file in this order):
     * <ol>
     *     <li>A JSON file containing an Object with only String keys and values that represent the connector configuration.</li>
     *     <li>A JSON file containing an Object that can be parsed directly into a {@link CreateConnectorRequest}</li>
     *     <li>A valid Java Properties file (i.e. containing String key/value pairs representing the connector configuration)</li>
     * </ol>
     * <p>
     * Visible for testing.
     *
     * @param filePath the path of the connector configuration file
     * @return the parsed connector configuration in the form of a {@link CreateConnectorRequest}
     */
    CreateConnectorRequest parseConnectorConfigurationFile(String filePath) throws IOException {
        ObjectMapper objectMapper = new ObjectMapper();

        File connectorConfigurationFile = Paths.get(filePath).toFile();
        try {
            Map<String, String> connectorConfigs = objectMapper.readValue(
                    connectorConfigurationFile,
                    new TypeReference<Map<String, String>>() { });

            if (!connectorConfigs.containsKey(NAME_CONFIG)) {
                throw new ConnectException("Connector configuration at '" + filePath + "' is missing the mandatory '" + NAME_CONFIG + "' "
                        + "configuration");
            }
            return new CreateConnectorRequest(connectorConfigs.get(NAME_CONFIG), connectorConfigs, null);
        } catch (StreamReadException | DatabindException e) {
            log.debug("Could not parse connector configuration file '{}' into a Map with String keys and values", filePath);
        }

        try {
            objectMapper.configure(DeserializationFeature.FAIL_ON_UNKNOWN_PROPERTIES, false);
            CreateConnectorRequest createConnectorRequest = objectMapper.readValue(connectorConfigurationFile,
                    new TypeReference<CreateConnectorRequest>() { });
            if (createConnectorRequest.config().containsKey(NAME_CONFIG)) {
                if (!createConnectorRequest.config().get(NAME_CONFIG).equals(createConnectorRequest.name())) {
                    throw new ConnectException("Connector name configuration in 'config' doesn't match the one specified in 'name' at '" + filePath
                            + "'");
                }
            } else {
                createConnectorRequest.config().put(NAME_CONFIG, createConnectorRequest.name());
            }
            return createConnectorRequest;
        } catch (StreamReadException | DatabindException e) {
            log.debug("Could not parse connector configuration file '{}' into an object of type {}",
                    filePath, CreateConnectorRequest.class.getSimpleName());
        }

        Map<String, String> connectorConfigs = mapFromArgument(filePath);
        if (!connectorConfigs.containsKey(NAME_CONFIG)) {
            throw new ConnectException("Connector configuration at '" + filePath + "' is missing the mandatory '" + NAME_CONFIG + "' "
                    + "configuration");
        }
        return new CreateConnectorRequest(connectorConfigs.get(NAME_CONFIG), connectorConfigs, null);
    }

    Map<String, String> mapFromArgument(String argument) throws IOException {
        Map<String, String> connectorProps;
        String connectorPropsData = System.getenv(argument); // analyze environment with input
        if (connectorPropsData == null || connectorPropsData.isEmpty()) {
            // argument can be a file, try with it
            connectorProps = !argument.isEmpty() ? Utils.propsToStringMap(Utils.loadProps(argument)) : Collections.emptyMap();
        } else {
            String keyValueSeparatorStr = System.getenv(keyValueSeparatorEnv);
            if (keyValueSeparatorStr == null || keyValueSeparatorStr.isEmpty())
                keyValueSeparatorStr = keyValueSeparator;
            String elementSeparatorStr = System.getenv(elementSeparatorEnv);
            if (elementSeparatorStr == null || elementSeparatorStr.isEmpty())
                elementSeparatorStr = elementSeparator;

            connectorProps = Utils.parseMap(connectorPropsData, keyValueSeparatorStr, elementSeparatorStr);
        }
        return connectorProps;
    }
}
