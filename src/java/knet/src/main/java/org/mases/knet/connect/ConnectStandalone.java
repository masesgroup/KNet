/*
 *  Copyright 2023 MASES s.r.l.
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

package org.mases.knet.connect;

import org.apache.kafka.common.utils.Exit;
import org.apache.kafka.common.utils.Time;
import org.apache.kafka.common.utils.Utils;
import org.apache.kafka.connect.connector.policy.ConnectorClientConfigOverridePolicy;
import org.apache.kafka.connect.runtime.Connect;
import org.apache.kafka.connect.runtime.ConnectorConfig;
import org.apache.kafka.connect.runtime.Herder;
import org.apache.kafka.connect.runtime.Worker;
import org.apache.kafka.connect.runtime.WorkerConfig;
import org.apache.kafka.connect.runtime.WorkerInfo;
import org.apache.kafka.connect.runtime.isolation.Plugins;
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
public class ConnectStandalone {
    private static final Logger log = LoggerFactory.getLogger(ConnectStandalone.class);
    private static final String keyValueSeparator = "=";
    private static final String elementSeparator = "||";

    public static void main(String[] args) {

        if (args.length < 1 || Arrays.asList(args).contains("--help")) {
            log.info("Usage: ConnectStandalone <Env of worker.properties> [<Env of connector1.properties> <Env of connector2.properties> ...]");
            Exit.exit(1);
        }

        try {
            Time time = Time.SYSTEM;
            log.info("KNet Connect standalone worker initializing ...");
            long initStart = time.hiResClockMs();
            WorkerInfo initInfo = new WorkerInfo();
            initInfo.logAll();

            String workerPropsEnv = args[0];
            String workerPropsData = System.getenv(workerPropsEnv);
            Map<String, String> workerProps = !workerPropsData.isEmpty() ?
                    Utils.parseMap(workerPropsData, keyValueSeparator, elementSeparator) : Collections.emptyMap();

            log.info("Scanning for plugin classes. This might take a moment ...");
            Plugins plugins = new Plugins(workerProps);
            plugins.compareAndSwapWithDelegatingLoader();
            StandaloneConfig config = new StandaloneConfig(workerProps);

            String kafkaClusterId = config.kafkaClusterId();
            log.debug("Kafka cluster ID: {}", kafkaClusterId);

            // Do not initialize a RestClient because the ConnectorsResource will not use it in standalone mode.
            RestServer rest = new RestServer(config, null);
            rest.initializeServer();

            URI advertisedUrl = rest.advertisedUrl();
            String workerId = advertisedUrl.getHost() + ":" + advertisedUrl.getPort();

            OffsetBackingStore offsetBackingStore = new FileOffsetBackingStore();
            offsetBackingStore.configure(config);

            ConnectorClientConfigOverridePolicy connectorClientConfigOverridePolicy = plugins.newPlugin(
                    config.getString(WorkerConfig.CONNECTOR_CLIENT_POLICY_CLASS_CONFIG),
                    config, ConnectorClientConfigOverridePolicy.class);
            Worker worker = new Worker(workerId, time, plugins, config, offsetBackingStore,
                    connectorClientConfigOverridePolicy);

            Herder herder = new StandaloneHerder(worker, kafkaClusterId, connectorClientConfigOverridePolicy);
            final Connect connect = new Connect(herder, rest);
            log.info("Kafka Connect standalone worker initialization took {}ms", time.hiResClockMs() - initStart);

            try {
                connect.start();
                for (final String connectorPropsEnv : Arrays.copyOfRange(args, 1, args.length)) {
                    String connectorPropsData = System.getenv(connectorPropsEnv);
                    Map<String, String> connectorProps = Utils.parseMap(connectorPropsData, keyValueSeparator, elementSeparator);
                    FutureCallback<Herder.Created<ConnectorInfo>> cb = new FutureCallback<>((error, info) -> {
                        if (error != null)
                            log.error("Failed to create job for {}", connectorPropsEnv);
                        else
                            log.info("Created connector {}", info.result().name());
                    });
                    herder.putConnectorConfig(
                            connectorProps.get(ConnectorConfig.NAME_CONFIG),
                            connectorProps, false, cb);
                    cb.get();
                }
            } catch (Throwable t) {
                log.error("Stopping after connector error", t);
                connect.stop();
                Exit.exit(3);
            }

            // Shutdown will be triggered by Ctrl-C or via HTTP shutdown request
            connect.awaitStop();

        } catch (Throwable t) {
            log.error("Stopping due to error", t);
            Exit.exit(2);
        }
    }
}