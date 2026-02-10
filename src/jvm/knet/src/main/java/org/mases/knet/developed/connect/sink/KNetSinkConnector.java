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

package org.mases.knet.developed.connect.sink;

import org.apache.kafka.common.TopicPartition;
import org.apache.kafka.common.config.ConfigDef;
import org.apache.kafka.connect.connector.Task;
import org.apache.kafka.connect.errors.ConnectException;
import org.apache.kafka.connect.sink.SinkConnector;
import org.apache.kafka.connect.sink.SinkConnectorContext;
import org.mases.jcobridge.*;
import org.mases.knet.developed.connect.KNetConnectDataExchange;
import org.mases.knet.developed.connect.KNetConnectInitializer;
import org.mases.knet.developed.connect.KNetConnectLogging;
import org.mases.knet.developed.connect.KNetConnectProxy;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.io.IOException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class KNetSinkConnector extends SinkConnector implements KNetConnectLogging, KNetConnectInitializer, KNetConnectDataExchange {
    private static final Logger log = LoggerFactory.getLogger(KNetSinkConnector.class);

    private static final String registrationName = "KNetSinkConnector";

    public static final ConfigDef CONFIG_DEF = new ConfigDef(KNetConnectProxy.CONFIG_DEF);

    long connectorId = 0;

    String indexedRegistrationName;

    JCObject sinkConnector;

    Object dataToExchange = null;

    public KNetSinkConnector() throws JCException, IOException {
        super();
        if (!JCOBridge.isCLRHostingProcess()) {
            KNetConnectProxy.initAndGetConnectProxy();
        }
    }

    public Object getDataToExchange() {
        return dataToExchange;
    }

    public void setDataToExchange(Object dte) {
        dataToExchange = dte;
    }

    public SinkConnectorContext getContext() {
        return context();
    }

    @Override
    public Class<? extends Task> taskClass() {
        log.debug("Invoking taskClass");
        return KNetSinkTask.class;
    }

    @Override
    public ConfigDef config() {
        log.debug("Invoking config");
        return CONFIG_DEF;
    }

    public String getAssemblyLocation() {
        return null;
    }

    public String getClassName() {
        return null;
    }

    @Override
    public void start(Map<String, String> props) {
        log.debug("Invoking start");
        try {
            connectorId = KNetConnectProxy.getNewConnectorId();
            JCObject sink;
            if (JCOBridge.isCLRHostingProcess()) {
                if (!KNetConnectProxy.initializeSinkConnector(this, props)) {
                    log.error("Failed Invoke of \"initializeSinkConnector\"");
                    throw new ConnectException("Failed Invoke of \"initializeSinkConnector\"");
                } else {
                    JCOBridge.RegisterJVMGlobal(registrationName, this);
                    log.debug("RegisterJVMGlobal done for {}", registrationName);
                    sink = KNetConnectProxy.getSinkConnector();
                    if (sink == null) throw new ConnectException("getSinkConnector returned null.");
                }
            } else {
                indexedRegistrationName = String.format("%s_%d", registrationName, connectorId);
                log.debug("Preparing KNetSinkConnector with name {}", indexedRegistrationName);
                if (!KNetConnectProxy.initializeConnector(this, props, indexedRegistrationName)) {
                    log.error("Failed Invoke of \"initializeConnector\"");
                    throw new ConnectException("Failed Invoke of \"initializeConnector\"");
                }
                JCOBridge.RegisterJVMGlobal(indexedRegistrationName, this);
                log.debug("RegisterJVMGlobal done for {}", indexedRegistrationName);
                sinkConnector = KNetConnectProxy.getConnector(indexedRegistrationName);
                sink = sinkConnector;
            }
            try {
                log.debug("Executing StartInternal");
                dataToExchange = props;
                sink.Invoke("StartInternal");
            } finally {
                dataToExchange = null;
            }
        } catch (JCException | IOException jcne) {
            log.error("Failed Invoke of \"start\"", jcne);
            throw new ConnectException("Failed Invoke of \"start\"", jcne);
        }
    }

    @Override
    public List<Map<String, String>> taskConfigs(int maxTasks) {
        log.debug("Invoking taskConfigs for maxTasks {}", maxTasks);
        ArrayList<Map<String, String>> configs = new ArrayList<>();
        JCObject sink;
        try {
            if (JCOBridge.isCLRHostingProcess()) {
                sink = KNetConnectProxy.getSinkConnector();
                if (sink == null) throw new ConnectException("getSinkConnector returned null.");
            } else {
                sink = sinkConnector;
            }
        } catch (JCException | IOException jcne) {
            log.error("Failed retrieving sink connector", jcne);
            throw new ConnectException("Failed retrieving sink connector.", jcne);
        }
        for (int i = 0; i < maxTasks; i++) {
            Map<String, String> config = new HashMap<>();
            boolean shallStop = false;
            try {
                KNetConnectProxy.applyConnectorId(config, indexedRegistrationName);
                dataToExchange = config;
                shallStop = (boolean) sink.Invoke("TaskConfigsInternal", i + 1, maxTasks);
            } catch (JCException jcne) {
                log.error("Failed Invoke of \"TaskConfigsInternal\"", jcne);
                throw new ConnectException("Failed Invoke of \"TaskConfigsInternal\"", jcne);
            } finally {
                dataToExchange = null;
            }
            configs.add(config);
            if (shallStop) {
                log.info("Explicit request to stop taskConfigs at iteration {} of {}", i + 1, maxTasks);
                break;
            }
        }
        return configs;
    }

    @Override
    public void stop() {
        log.debug("Invoking stop");
        try {
            try {
                JCObject sink;
                if (JCOBridge.isCLRHostingProcess()) {
                    sink = KNetConnectProxy.getSinkConnector();
                    if (sink == null) throw new ConnectException("getSinkConnector returned null.");
                } else {
                    sink = sinkConnector;
                }
                sink.Invoke("StopInternal");
            } finally {
                if (JCOBridge.isCLRHostingProcess()) {
                    JCOBridge.UnregisterJVMGlobal(registrationName);
                } else {
                    JCOBridge.UnregisterJVMGlobal(indexedRegistrationName);
                }
            }
        } catch (JCException | IOException jcne) {
            log.error("Failed Invoke of \"stop\"", jcne);
            throw new ConnectException("Failed Invoke of \"stop\"", jcne);
        }
    }

    @Override
    public String version() {
        log.debug("Invoking version");
        try {
            JCObject sink;
            if (JCOBridge.isCLRHostingProcess()) {
                sink = KNetConnectProxy.getSinkConnector();
            } else {
                sink = sinkConnector;
            }
            if (sink != null) {
                return (String) sink.Invoke("VersionInternal");
            }
        } catch (JCException | IOException jcne) {
            log.error("Failed Invoke of \"version\"", jcne);
        }
        return "NOT AVAILABLE";
    }

    @Override
    public boolean alterOffsets(Map<String, String> connectorConfig, Map<TopicPartition, Long> offsets) {
        log.debug("Invoking alterOffsets");
        try {
            JCObject sink;
            if (JCOBridge.isCLRHostingProcess()) {
                sink = KNetConnectProxy.getSinkConnector();
            } else {
                sink = sinkConnector;
            }
            return (boolean) sink.Invoke("AlterOffsetsInternal", connectorConfig, offsets);
        } catch (JCException | IOException jcne) {
            log.error("Failed Invoke of \"alterOffsets\", try with base method", jcne);
            return super.alterOffsets(connectorConfig, offsets);
        }
    }

    @Override
    public String getName() {
        return log.getName();
    }

    @Override
    public boolean isTraceEnabled() {
        return log.isTraceEnabled();
    }

    @Override
    public void trace(String var1) {
        log.trace(var1);
    }

    @Override
    public void trace(String var1, Throwable var2) {
        log.trace(var1, var2);
    }

    @Override
    public void trace(String var1, Object... var2) {
        log.trace(var1, var2);
    }

    @Override
    public boolean isDebugEnabled() {
        return log.isDebugEnabled();
    }

    @Override
    public void debug(String var1) {
        log.debug(var1);
    }

    @Override
    public void debug(String var1, Throwable var2) {
        log.debug(var1, var2);
    }

    @Override
    public void debug(String var1, Object... var2) {
        log.trace(var1, var2);
    }

    @Override
    public boolean isInfoEnabled() {
        return log.isInfoEnabled();
    }

    @Override
    public void info(String var1) {
        log.info(var1);
    }

    @Override
    public void info(String var1, Throwable var2) {
        log.info(var1, var2);
    }

    @Override
    public void info(String var1, Object... var2) {
        log.trace(var1, var2);
    }

    @Override
    public boolean isWarnEnabled() {
        return log.isWarnEnabled();
    }

    @Override
    public void warn(String var1) {
        log.warn(var1);
    }

    @Override
    public void warn(String var1, Throwable var2) {
        log.warn(var1, var2);
    }

    @Override
    public void warn(String var1, Object... var2) {
        log.trace(var1, var2);
    }

    @Override
    public boolean isErrorEnabled() {
        return log.isErrorEnabled();
    }

    @Override
    public void error(String var1) {
        log.error(var1);
    }

    @Override
    public void error(String var1, Throwable var2) {
        log.error(var1, var2);
    }

    @Override
    public void error(String var1, Object... var2) {
        log.trace(var1, var2);
    }
}
