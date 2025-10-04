/*
 *  Copyright (c) 2021-2025 MASES s.r.l.
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

import org.apache.kafka.common.utils.Time;
import org.apache.kafka.connect.connector.policy.ConnectorClientConfigOverridePolicy;
import org.apache.kafka.connect.json.JsonConverter;
import org.apache.kafka.connect.json.JsonConverterConfig;
import org.apache.kafka.connect.runtime.Worker;
import org.apache.kafka.connect.runtime.isolation.Plugins;
import org.apache.kafka.connect.runtime.rest.RestClient;
import org.apache.kafka.connect.runtime.rest.RestServer;
import org.apache.kafka.connect.runtime.standalone.StandaloneConfig;
import org.apache.kafka.connect.runtime.standalone.StandaloneHerder;
import org.apache.kafka.connect.storage.FileOffsetBackingStore;
import org.apache.kafka.connect.storage.OffsetBackingStore;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

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
public class ConnectStandalone extends AbstractConnectCli<StandaloneHerder, StandaloneConfig> {
    private static final Logger log = LoggerFactory.getLogger(ConnectStandalone.class);

    protected ConnectStandalone(String... args) {
        super(args);
    }

    protected String usage() {
        return "ConnectStandalone <Env of worker.properties> [<Env of connector1.properties> <Env of connector2.properties> ...]";
    }

    @Override
    protected StandaloneHerder createHerder(StandaloneConfig config, String workerId, Plugins plugins, ConnectorClientConfigOverridePolicy connectorClientConfigOverridePolicy, RestServer restServer, RestClient restClient) {
        OffsetBackingStore offsetBackingStore = new FileOffsetBackingStore(plugins.newInternalConverter(true, JsonConverter.class.getName(), Collections.singletonMap(JsonConverterConfig.SCHEMAS_ENABLE_CONFIG, "false")));
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