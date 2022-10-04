/*
 *  Copyright 2022 MASES s.r.l.
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

package org.mases.knet.connect.source;

import org.apache.kafka.common.config.ConfigDef;
import org.apache.kafka.connect.connector.Task;
import org.apache.kafka.connect.errors.ConnectException;
import org.apache.kafka.connect.source.*;
import org.mases.jcobridge.*;
import org.mases.knet.connect.KNetConnectProxy;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.io.IOException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class KNetSourceConnector extends SourceConnector {
    private static final Logger log = LoggerFactory.getLogger(KNetSourceConnector.class);

    private static final String registrationName = "KNetSourceConnector";

    Object dataToExchange = null;

    public Object getDataToExchange() {
        return dataToExchange;
    }

    public void setDataToExchange(Object dte) {
        dataToExchange = dte;
    }

    public SourceConnectorContext getContext() {
        return context();
    }

    @Override
    public void start(Map<String, String> props) {
        try {
            if (!KNetConnectProxy.initializeSourceConnector(props)) {
                log.error("Failed Invoke of \"initializeSourceConnector\"");
                throw new ConnectException("Failed Invoke of \"initializeSourceConnector\"");
            } else {
                JCOBridge.RegisterJVMGlobal(registrationName, this);
                try {
                    dataToExchange = props;
                    JCObject source = KNetConnectProxy.getSourceConnector();
                    if (source == null) throw new ConnectException("getSourceConnector returned null.");
                    source.Invoke("StartInternal");
                } finally {
                    dataToExchange = null;
                }
            }
        } catch (JCException | IOException jcne) {
            log.error("Failed Invoke of \"start\"", jcne);
        }
    }

    @Override
    public Class<? extends Task> taskClass() {
        return KNetSourceTask.class;
    }

    @Override
    public List<Map<String, String>> taskConfigs(int maxTasks) {
        ArrayList<Map<String, String>> configs = new ArrayList<>();
        for (int i = 0; i < maxTasks; i++) {
            Map<String, String> config = new HashMap<>();
            try {
                dataToExchange = config;
                JCObject source = KNetConnectProxy.getSourceConnector();
                if (source == null) throw new ConnectException("getSourceConnector returned null.");
                source.Invoke("TaskConfigsInternal", i);
            } catch (JCException | IOException jcne) {
                log.error("Failed Invoke of \"start\"", jcne);
            } finally {
                dataToExchange = null;
            }
            configs.add(config);
        }
        return configs;
    }

    @Override
    public void stop() {
        try {
            try {
                JCObject source = KNetConnectProxy.getSourceConnector();
                if (source == null) throw new ConnectException("getSourceConnector returned null.");
                source.Invoke("StopInternal");
            } finally {
                JCOBridge.UnregisterJVMGlobal(registrationName);
            }
        } catch (JCException | IOException jcne) {
            log.error("Failed Invoke of \"stop\"", jcne);
        }
    }

    @Override
    public ConfigDef config() {
        return KNetConnectProxy.CONFIG_DEF;
    }

    @Override
    public String version() {
        try {
            JCObject source = KNetConnectProxy.getSourceConnector();
            if (source != null) {
                return (String) source.Invoke("VersionInternal");
            }
        } catch (JCException | IOException jcne) {
            log.error("Failed Invoke of \"version\"", jcne);
        }
        return "NOT AVAILABLE";
    }
    @Override
    public ExactlyOnceSupport exactlyOnceSupport(Map<String, String> connectorConfig) {
        try {
            try {
                JCObject source = KNetConnectProxy.getSourceConnector();
                dataToExchange = null;
                source.Invoke("ExactlyOnceSupportInternal", connectorConfig);
                if (dataToExchange != null) return (ExactlyOnceSupport) dataToExchange;
            } finally {
                dataToExchange = null;
            }
        } catch (JCException | IOException jcne) {
            log.error("Failed Invoke of \"exactlyOnceSupport\"", jcne);
        }
        return null;
    }

    @Override
    public ConnectorTransactionBoundaries canDefineTransactionBoundaries(Map<String, String> connectorConfig) {
        try {
            try {
                JCObject source = KNetConnectProxy.getSourceConnector();
                dataToExchange = null;
                source.Invoke("CanDefineTransactionBoundariesInternal", connectorConfig);
                if (dataToExchange != null) return (ConnectorTransactionBoundaries) dataToExchange;
            } finally {
                dataToExchange = null;
            }
        } catch (JCException | IOException jcne) {
            log.error("Failed Invoke of \"canDefineTransactionBoundaries\"", jcne);
        }
        return ConnectorTransactionBoundaries.UNSUPPORTED;
    }
}
