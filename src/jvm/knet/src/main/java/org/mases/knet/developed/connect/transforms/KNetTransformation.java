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

package org.mases.knet.developed.connect.transforms;

import org.apache.kafka.common.config.ConfigDef;
import org.apache.kafka.connect.errors.ConnectException;
import org.apache.kafka.connect.components.Versioned;
import org.apache.kafka.connect.connector.ConnectRecord;
import org.apache.kafka.connect.transforms.Transformation;
import org.mases.knet.developed.connect.KNetConnectDataExchange;
import org.mases.knet.developed.connect.KNetConnectInitializer;
import org.mases.knet.developed.connect.KNetConnectLogging;
import org.mases.knet.developed.connect.KNetConnectProxy;
import org.mases.jcobridge.*;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.io.IOException;
import java.util.Map;

public class KNetTransformation<R extends ConnectRecord<R>> implements Transformation<R>, Versioned, KNetConnectLogging, KNetConnectInitializer, KNetConnectDataExchange {
    private static final Logger log = LoggerFactory.getLogger(KNetTransformation.class);

    private static final String registrationName = "KNetTransformation";

    public static final ConfigDef CONFIG_DEF = new ConfigDef();

    long transformationId = 0;

    String indexedRegistrationName;

    JCObject transformationObject;

    Object dataToExchange = null;

    public KNetTransformation() throws JCException, IOException {
        super();
        if (!JCOBridge.isCLRHostingProcess()) {
            KNetConnectProxy.initAndGetConnectProxy();
        } else {
            throw new ConnectException("KNetTransformation is not supported from a CLR Hosting process.");
        }
    }

    public String getAssemblyLocation() {
        return null;
    }

    public String getClassName() {
        return null;
    }

    public Object getDataToExchange() {
        return dataToExchange;
    }

    public void setDataToExchange(Object dte) {
        dataToExchange = dte;
    }

    @Override
    public R apply(R record) {
        log.debug("Invoking apply");
        try {
            if (transformationObject != null) {
                try {
                    dataToExchange = record;
                    transformationObject.Invoke("ApplyInternal");
                    R dataToExchange1 = (R) dataToExchange;
                    return dataToExchange1;
                } finally {
                    dataToExchange = null;
                }
            } else {
                log.warn("Cannot execute \"apply\" since remote object is missing");
                return record;
            }
        } catch (JCException jcne) {
            log.error("Failed Invoke of \"apply\"", jcne);
            throw new ConnectException("Failed Invoke of \"apply\"", jcne);
        }
    }

    @Override
    public String version() {
        log.debug("Invoking version");
        try {
            if (transformationObject != null) {
                return (String) transformationObject.Invoke("VersionInternal");
            }
        } catch (JCException jcne) {
            log.error("Failed Invoke of \"version\"", jcne);
        }
        return "NOT AVAILABLE";
    }

    @Override
    public ConfigDef config() {
        return CONFIG_DEF;
    }

    @Override
    public void close() {
        log.debug("Invoking close");
        try {
            try {
                if (transformationObject != null) {
                    transformationObject.Invoke("CloseInternal");
                }
            } finally {
                if (!JCOBridge.isCLRHostingProcess()) {
                    JCOBridge.UnregisterJVMGlobal(indexedRegistrationName);
                }
            }
        } catch (JCException jcne) {
            log.error("Failed Invoke of \"close\"", jcne);
        }
    }

    @Override
    public void configure(Map<String, ?> configs) {
        log.debug("Invoking configure");
        try {
            transformationId = KNetConnectProxy.getNewConnectorId();
            if (JCOBridge.isCLRHostingProcess()) {
                throw new ConnectException("KNetTransformation is not supported from a CLR Hosting process.");
            } else {
                indexedRegistrationName = String.format("%s_%d", registrationName, transformationId);
                log.info("Preparing KNetTransformation with name %s", indexedRegistrationName);
                if (!KNetConnectProxy.initializeTransformation(this, configs, indexedRegistrationName)) {
                    log.error("Failed Invoke of \"initializeTransformation\"");
                    throw new ConnectException("Failed Invoke of \"initializeTransformation\"");
                }
                JCOBridge.RegisterJVMGlobal(indexedRegistrationName, this);
                log.info("RegisterJVMGlobal done for %s", indexedRegistrationName);
                transformationObject = KNetConnectProxy.getTransform(indexedRegistrationName);
            }
            if (transformationObject != null) {
                try {
                    dataToExchange = configs;
                    transformationObject.Invoke("ConfigureInternal");
                } finally {
                    dataToExchange = null;
                }
            }
        } catch (JCException | IOException jcne) {
            log.error("Failed Invoke of \"configure\"", jcne);
            throw new ConnectException("Failed Invoke of \"configure\"", jcne);
        }
    }

    @Override
    public String getName() { return log.getName(); }

    @Override
    public boolean isTraceEnabled() {
        return log.isTraceEnabled();
    }

    @Override
    public void trace(String var1) { log.trace(var1); }

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
    public void warn(String var1, Object... var2) { log.trace(var1, var2); }

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
