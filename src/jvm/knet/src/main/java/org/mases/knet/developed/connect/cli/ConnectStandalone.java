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
import org.apache.kafka.common.utils.Time;
import org.apache.kafka.common.utils.Utils;
import org.apache.kafka.connect.cli.AbstractConnectCli;
import org.apache.kafka.connect.connector.policy.ConnectorClientConfigOverridePolicy;
import org.apache.kafka.connect.json.JsonConverter;
import org.apache.kafka.connect.runtime.Connect;
import org.apache.kafka.connect.runtime.ConnectorConfig;
import org.apache.kafka.connect.runtime.Herder;
import org.apache.kafka.connect.runtime.Worker;
import org.apache.kafka.connect.runtime.WorkerConfig;
import org.apache.kafka.connect.runtime.WorkerInfo;
import org.apache.kafka.connect.runtime.isolation.Plugins;
import org.apache.kafka.connect.runtime.rest.ConnectRestServer;
import org.apache.kafka.connect.runtime.rest.RestClient;
import org.apache.kafka.connect.runtime.rest.RestServer;
import org.apache.kafka.connect.runtime.rest.entities.ConnectorInfo;
import org.apache.kafka.connect.runtime.standalone.StandaloneConfig;
import org.apache.kafka.connect.runtime.standalone.StandaloneHerder;
import org.apache.kafka.connect.storage.FileOffsetBackingStore;
import org.apache.kafka.connect.storage.OffsetBackingStore;
import org.apache.kafka.connect.util.FutureCallback;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.net.URI;
import java.util.Arrays;
import java.util.Collections;
import java.util.Map;

/**
 * <p>
 * Command line utility that runs Kafka Connect as a standalone process. In this mode, work is not
 * distributed. Instead, all the normal Connect machinery works within a single process. This is
 * useful for ad hoc, small, or experimental jobs.
 * </p>
 * <p>
 * By default, no job configs or offset data is persistent. You can make jobs persistent and
 * fault tolerant by overriding the settings to use file storage for both.
 * </p>
 */
public class ConnectStandalone extends AbstractConnectCli<StandaloneConfig> {
    private final String[] args;
    private static final Logger log = LoggerFactory.getLogger(ConnectStandalone.class);
    private static final String keyValueSeparator = "=";
    private static final String elementSeparator = "||";

    protected ConnectStandalone(String... args) {
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
            String workerPropsEnv = args[0];
            String workerPropsData = System.getenv(workerPropsEnv);
            Map<String, String> workerProps = !workerPropsData.isEmpty() ?
                    Utils.parseMap(workerPropsData, keyValueSeparator, elementSeparator) : Collections.emptyMap();

            String[] extraArgs = (String[]) Arrays.copyOfRange(this.args, 1, this.args.length);
            Connect connect = this.startConnect(workerProps, extraArgs);
            connect.awaitStop();
        } catch (Throwable t) {
            log.error("Stopping due to error", t);
            Exit.exit(2);
        }
    }

    protected String usage() {
        return "ConnectStandalone <Env of worker.properties> [<Env of connector1.properties> <Env of connector2.properties> ...]";
    }

    protected void processExtraArgs(Herder herder, Connect connect, String[] extraArgs) {
        try {
            for (int i = 0; i < extraArgs.length; ++i) {
                String connectorPropsEnv = extraArgs[i];
                String connectorPropsData = System.getenv(connectorPropsEnv);
                Map<String, String> connectorProps = Utils.parseMap(connectorPropsData, keyValueSeparator, elementSeparator);
                FutureCallback<Herder.Created<ConnectorInfo>> cb = new FutureCallback((error, info) -> {
                    if (error != null) {
                        log.error("Failed to create connector for {}", connectorPropsEnv);
                    } else {
                        log.info("Created connector {}", (((Herder.Created<ConnectorInfo>)info).result()).name());
                    }

                });
                herder.putConnectorConfig((String) connectorProps.get("name"), connectorProps, false, cb);
                cb.get();
            }
        } catch (Throwable t) {
            log.error("Stopping after connector error", t);
            connect.stop();
            Exit.exit(3);
        }

    }

    protected Herder createHerder(StandaloneConfig config, String workerId, Plugins plugins, ConnectorClientConfigOverridePolicy connectorClientConfigOverridePolicy, RestServer restServer, RestClient restClient) {
        OffsetBackingStore offsetBackingStore = new FileOffsetBackingStore(plugins.newInternalConverter(true, JsonConverter.class.getName(), Collections.singletonMap("schemas.enable", "false")));
        offsetBackingStore.configure(config);
        Worker worker = new Worker(workerId, Time.SYSTEM, plugins, config, offsetBackingStore, connectorClientConfigOverridePolicy);
        return new StandaloneHerder(worker, config.kafkaClusterId(), connectorClientConfigOverridePolicy);
    }

    protected StandaloneConfig createConfig(Map<String, String> workerProps) {
        return new StandaloneConfig(workerProps);
    }

    public static void main(String[] args) {
        ConnectStandalone connectStandalone = new ConnectStandalone(args);
        connectStandalone.run();
    }
}