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

package org.mases.knet.connect;

import org.apache.kafka.common.config.AbstractConfig;
import org.apache.kafka.common.config.ConfigDef;
import org.apache.kafka.common.config.ConfigException;
import org.mases.jcobridge.*;
import org.mases.knet.connect.source.KNetSourceTask;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.io.IOException;
import java.util.Map;

public class KNetConnectProxy {
    private static final Logger log = LoggerFactory.getLogger(KNetSourceTask.class);

    public static final String DOTNET_CLASSNAME_CONFIG = "knet.dotnet.classname";

    public static final ConfigDef CONFIG_DEF = new ConfigDef()
            .define(DOTNET_CLASSNAME_CONFIG, ConfigDef.Type.STRING, null, ConfigDef.Importance.HIGH, ".NET class name in the form usable from .NET like \"classname, assembly name\".");

    static JCObject knetConnectProxy = null;
    static String sinkConnectorName = null;
    static JCObject sinkConnector = null;
    static String sourceConnectorName = null;
    static JCObject sourceConnector = null;

    static synchronized JCObject getConnectProxy() throws JCException, IOException {
        if (knetConnectProxy == null) {
            JCOBridge.Initialize();
            knetConnectProxy = (JCObject) JCOBridge.GetCLRGlobal("KNetConnectProxy");
        }
        return knetConnectProxy;
    }

    public static synchronized boolean initializeSinkConnector(Map<String, String> props) throws JCException, IOException {
        AbstractConfig parsedConfig = new AbstractConfig(CONFIG_DEF, props);
        String className = parsedConfig.getString(DOTNET_CLASSNAME_CONFIG);
        if (className == null)
            throw new ConfigException("'knet.dotnet.classname' in KNetSinkConnector configuration requires a definition");
        return (boolean) getConnectProxy().Invoke("AllocateSinkConnector", className);
    }

    public static synchronized boolean initializeSourceConnector(Map<String, String> props) throws JCException, IOException {
        AbstractConfig parsedConfig = new AbstractConfig(CONFIG_DEF, props);
        String className = parsedConfig.getString(DOTNET_CLASSNAME_CONFIG);
        if (className == null)
            throw new ConfigException("'knet.dotnet.classname' in KNetSinkConnector configuration requires a definition");
        return (boolean) getConnectProxy().Invoke("AllocateSourceConnector", className);
    }

    public static synchronized JCObject getSinkConnector() throws JCException, IOException {
        if (sinkConnector == null) {
            sinkConnectorName = (String) getConnectProxy().Invoke("SinkConnectorName");
            if (sinkConnectorName != null) {
                sinkConnector = (JCObject) JCOBridge.GetCLRGlobal(sinkConnectorName);
            }
        }
        return sinkConnector;
    }

    public static synchronized JCObject getSourceConnector() throws JCException, IOException {
        if (sourceConnector == null) {
            sourceConnectorName = (String) getConnectProxy().Invoke("SourceConnectorName");
            if (sourceConnectorName != null) {
                sourceConnector = (JCObject) JCOBridge.GetCLRGlobal(sourceConnectorName);
            }
        }
        return sourceConnector;
    }
}
