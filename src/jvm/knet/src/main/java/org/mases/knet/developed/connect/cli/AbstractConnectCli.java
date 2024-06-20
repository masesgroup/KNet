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

import org.apache.kafka.common.utils.Exit;
import org.apache.kafka.common.utils.Utils;
import org.apache.kafka.connect.runtime.Connect;
import org.apache.kafka.connect.runtime.Herder;
import org.apache.kafka.connect.runtime.WorkerConfig;
import org.apache.kafka.connect.runtime.rest.entities.ConnectorInfo;
import org.apache.kafka.connect.util.FutureCallback;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.io.IOException;
import java.util.Arrays;
import java.util.Collections;
import java.util.Map;

public abstract class AbstractConnectCli<T extends WorkerConfig> extends org.apache.kafka.connect.cli.AbstractConnectCli<T> {
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

    @Override
    public void run() {
        if (this.args.length < 1 || Arrays.asList(this.args).contains("--help")) {
            log.info("Usage: {}", this.usage());
            Exit.exit(1);
        }

        try {
            Map<String, String> workerProps = mapFromArgument(args[0]);
            String[] extraArgs = Arrays.copyOfRange(this.args, 1, this.args.length);
            Connect connect = this.startConnect(workerProps, extraArgs);
            connect.awaitStop();
        } catch (Throwable t) {
            log.error("Stopping due to error", t);
            Exit.exit(2);
        }
    }

    protected void processExtraArgs(Herder herder, Connect connect, String[] extraArgs) {
        try {
            for (String argument : extraArgs) {
                Map<String, String> connectorProps = mapFromArgument(argument);
                FutureCallback<Herder.Created<ConnectorInfo>> cb = new FutureCallback<>((error, info) -> {
                    if (error != null) {
                        log.error("Failed to create connector for {}", argument);
                    } else {
                        log.info("Created connector {}", (info.result()).name());
                    }

                });
                herder.putConnectorConfig(connectorProps.get("name"), connectorProps, false, cb);
                cb.get();
            }
        } catch (Throwable t) {
            log.error("Stopping after connector error", t);
            connect.stop();
            Exit.exit(3);
        }
    }

    protected Map<String, String> mapFromArgument(String argument) throws IOException {
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
