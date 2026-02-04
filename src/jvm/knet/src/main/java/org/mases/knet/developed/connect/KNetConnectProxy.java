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

package org.mases.knet.developed.connect;

import org.apache.kafka.common.config.AbstractConfig;
import org.apache.kafka.common.config.ConfigDef;
import org.apache.kafka.common.config.ConfigException;
import org.mases.jcobridge.*;
import org.mases.knet.developed.connect.source.KNetSourceTask;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.io.IOException;
import java.net.ConnectException;
import java.util.Map;
import java.util.concurrent.atomic.AtomicLong;

public class KNetConnectProxy implements KNetConnectLogging, IJCEventLog {
    private static final Logger log = LoggerFactory.getLogger(KNetSourceTask.class);

    public static final String DOTNET_ASSEMBLY_LOCATION_CONFIG = "knet.dotnet.assembly.location";
    public static final String DOTNET_CLASSNAME_CONFIG = "knet.dotnet.classname";

    public static final String CONNECTOR_ID_PROP_NAME = "connector.id.prop.name";

    public static final ConfigDef CONFIG_DEF = new ConfigDef()
            .define(DOTNET_ASSEMBLY_LOCATION_CONFIG, ConfigDef.Type.STRING, null, ConfigDef.Importance.LOW, "Location of the assembly containing the .NET class referred from \"knet.dotnet.classname\".")
            .define(DOTNET_CLASSNAME_CONFIG, ConfigDef.Type.STRING, null, ConfigDef.Importance.HIGH, ".NET class name in the form usable from .NET like \"classname, assembly name\".");

    static JCOBridge bridgeInstance = null;
    static JCObject knetConnectProxy = null;
    static KNetConnectProxy localKNetConnectProxy = null;
    static String sinkConnectorName = null;
    static JCObject sinkConnector = null;
    static String sourceConnectorName = null;
    static JCObject sourceConnector = null;
    static final AtomicLong connectorId = new AtomicLong(0);
    static final AtomicLong taskId = new AtomicLong(0);

    public static long getNewConnectorId() {
        return connectorId.incrementAndGet();
    }

    public static long getNewTaskId() {
        return taskId.incrementAndGet();
    }

    public static synchronized void initAndGetConnectProxy() throws JCException, IOException {
        if (knetConnectProxy == null) {
            log.info("Initialize KNetConnectProxy");
            if (!JCOBridge.isCLRHostingProcess()) {
                log.info("Initializing of KNetConnectProxy starting from JVM");
            }

            // initialize JCOBridge
            log.info("Initializing JCOBridge");
            JCOBridge.Initialize();
            log.info("Initialized JCOBridge");

            // get proxy
            if (JCOBridge.isCLRHostingProcess()) {
                knetConnectProxy = (JCObject) JCOBridge.GetCLRGlobal("KNetConnectProxy");
                log.info("Recoved KNetConnectProxy from CLR");
            } else {
                bridgeInstance = JCOBridge.CreateNew();
                knetConnectProxy = (JCObject) bridgeInstance.NewObject("MASES.KNet.Connect.KNetConnectProxy, MASES.KNet");
                log.info("Created KNetConnectProxy in the CLR");
                localKNetConnectProxy = new KNetConnectProxy();
                bridgeInstance.RegisterEventLog(localKNetConnectProxy);
            }
        }
        log.debug("Returning KNetConnectProxy instance");
    }

    public static synchronized boolean initializeSinkConnector(KNetConnectInitializer sink, Map<String, String> props) throws JCException, IOException {
        log.info("Invoking initializeSinkConnector");

        if (knetConnectProxy == null)
            throw new ConnectException("Missing initialization of infrastructure using initAndGetConnectProxy");

        String className = null;
        if (sink != null) {
            className = sink.getClassName();
        }
        if (className == null) {
            AbstractConfig parsedConfig = new AbstractConfig(CONFIG_DEF, props);
            className = parsedConfig.getString(DOTNET_CLASSNAME_CONFIG);
        }

        if (className == null)
            throw new ConfigException(String.format("'%s' in KNetSinkConnector configuration requires a definition", DOTNET_CLASSNAME_CONFIG));

        log.info("Trying to allocate Sink Connector with class name %s", className);

        return (boolean) knetConnectProxy.Invoke("AllocateSinkConnector", className);
    }

    public static synchronized boolean initializeSourceConnector(KNetConnectInitializer source, Map<String, String> props) throws JCException, IOException {
        log.info("Invoking initializeSourceConnector");

        if (knetConnectProxy == null)
            throw new ConnectException("Missing initialization of infrastructure using initAndGetConnectProxy");

        String className = null;
        if (source != null) {
            className = source.getClassName();
        }
        if (className == null) {
            AbstractConfig parsedConfig = new AbstractConfig(CONFIG_DEF, props);
            className = parsedConfig.getString(DOTNET_CLASSNAME_CONFIG);
        }

        if (className == null)
            throw new ConfigException(String.format("'%s' in KNetSourceConnector configuration requires a definition", DOTNET_CLASSNAME_CONFIG));

        log.info("Trying to allocate Source Connector with class name %s", className);

        return (boolean) knetConnectProxy.Invoke("AllocateSourceConnector", className);
    }

    public static synchronized boolean initializeConnector(KNetConnectInitializer connector, Map<String, String> props, String uniqueId) throws JCException, IOException {
        log.info("Invoking initializeConnector");

        if (knetConnectProxy == null)
            throw new ConnectException("Missing initialization of infrastructure using initAndGetConnectProxy");

        AbstractConfig parsedConfig = new AbstractConfig(CONFIG_DEF, props);
        String location;
        if (connector != null) {
            location = connector.getAssemblyLocation();
        } else {
            location = parsedConfig.getString(DOTNET_ASSEMBLY_LOCATION_CONFIG);
        }
        if (location != null) {
            if (bridgeInstance == null)
                throw new ConnectException("Missing initialization of infrastructure using initAndGetConnectProxy");
            bridgeInstance.AddPath(location);
        }

        String className;
        if (connector != null) {
            className = connector.getClassName();
        } else {
            className = parsedConfig.getString(DOTNET_CLASSNAME_CONFIG);
        }

        if (className == null)
            throw new ConfigException(String.format("'%s' in connector configuration requires a definition", DOTNET_CLASSNAME_CONFIG));

        log.info("Trying to allocate Connector with class name %s", className);

        return (boolean) knetConnectProxy.Invoke("AllocateConnector", className, uniqueId);
    }

    public static synchronized JCObject getSinkConnector() throws JCException, IOException {
        log.info("Invoking getSinkConnector");

        if (knetConnectProxy == null)
            throw new ConnectException("Missing initialization of infrastructure using initAndGetConnectProxy");

        if (sinkConnector == null) {
            log.info("Trying to recover name of Sink Connector");
            sinkConnectorName = (String) knetConnectProxy.Invoke("SinkConnectorName");
            log.info("Trying to recover Sink Connector with name %s", sinkConnectorName);
            if (sinkConnectorName != null) {
                sinkConnector = (JCObject) JCOBridge.GetCLRGlobal(sinkConnectorName);
                log.info("Recovered Sink Connector with name %s", sinkConnectorName);
            }
        }
        return sinkConnector;
    }

    public static synchronized JCObject getSourceConnector() throws JCException, IOException {
        log.info("Invoking getSourceConnector");

        if (knetConnectProxy == null)
            throw new ConnectException("Missing initialization of infrastructure using initAndGetConnectProxy");

        if (sourceConnector == null) {
            log.info("Trying to recover name of Source Connector");
            sourceConnectorName = (String) knetConnectProxy.Invoke("SourceConnectorName");
            log.info("Trying to recover Source Connector with name %s", sourceConnectorName);
            if (sourceConnectorName != null) {
                sourceConnector = (JCObject) JCOBridge.GetCLRGlobal(sourceConnectorName);
                log.info("Recovered Source Connector with name %s", sinkConnectorName);
            }
        }
        return sourceConnector;
    }

    public static synchronized JCObject getConnector(String uniqueId) throws JCException, IOException {
        log.info("Invoking getConnector with id %s", uniqueId);
        return (JCObject) JCOBridge.GetCLRGlobal(uniqueId);
    }

    public static synchronized void applyConnectorId(Map<String, String> props, String uniqueId) {
        props.put(CONNECTOR_ID_PROP_NAME, uniqueId);
    }

    public static synchronized String getConnectorId(Map<String, String> props) throws ConnectException {
        String connectorId = props.get(CONNECTOR_ID_PROP_NAME);
        if (connectorId == null) throw new ConnectException(String.format("Failed to get %s", CONNECTOR_ID_PROP_NAME));
        return connectorId;
    }

    public void FusionLog(String var1) {
        debug(var1);
    }

    public void EventLog(String var1) {
        debug(var1);
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
}
