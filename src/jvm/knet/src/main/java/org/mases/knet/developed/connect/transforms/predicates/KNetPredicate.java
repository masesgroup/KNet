/*
 *  Copyright (c) 2021-2026 MASES s.r.l.
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

package org.mases.knet.developed.connect.transforms.predicates;

import org.apache.kafka.common.config.AbstractConfig;
import org.apache.kafka.common.config.ConfigDef;
import org.apache.kafka.connect.errors.ConnectException;
import org.apache.kafka.connect.components.Versioned;
import org.apache.kafka.connect.connector.ConnectRecord;
import org.apache.kafka.connect.transforms.predicates.Predicate;
import org.mases.knet.developed.connect.*;
import org.mases.jcobridge.*;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.io.IOException;
import java.util.Map;

import org.mases.knet.developed.connect.KNetConnectInitializer;

public class KNetPredicate<R extends ConnectRecord<R>> implements Predicate<R>, Versioned, KNetConnectLogging, KNetConnectInitializer, KNetConnectDataExchange {
    private static final Logger log = LoggerFactory.getLogger(KNetPredicate.class);

    private static final String registrationName = "KNetPredicate";

    public static final ConfigDef CONFIG_DEF = new ConfigDef();

    long predicateId = 0;

    String indexedRegistrationName;

    JCObject predicateObject;

    Object dataToExchange = null;

    public KNetPredicate() throws JCException, IOException {
        super();
        if (!JCOBridge.isCLRHostingProcess()) {
            KNetConnectProxy.initAndGetConnectProxy();
        } else {
            throw new ConnectException("KNetPredicate is not supported from a CLR Hosting process.");
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
    public boolean test(R record) {
        log.debug("Invoking test");
        try {
            if (predicateObject != null) {
                try {
                    dataToExchange = record;
                    return (boolean) predicateObject.Invoke("TestInternal");
                } finally {
                    dataToExchange = null;
                }
            } else {
                log.warn("Cannot execute \"test\" since remote object is missing");
                return false;
            }
        } catch (JCException jcne) {
            log.error("Failed Invoke of \"test\"", jcne);
            throw new ConnectException("Failed Invoke of \"test\"", jcne);
        }
    }

    @Override
    public String version() {
        log.debug("Invoking version");
        try {
            if (predicateObject != null) {
                return (String) predicateObject.Invoke("VersionInternal");
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
                if (predicateObject != null) {
                    predicateObject.Invoke("CloseInternal");
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
            predicateId = KNetConnectProxy.getNewConnectorId();
            if (JCOBridge.isCLRHostingProcess()) {
                throw new ConnectException("KNetPredicate is not supported from a CLR Hosting process.");
            } else {
                indexedRegistrationName = String.format("%s_%d", registrationName, predicateId);
                log.info("Preparing KNetTransform with name {}", indexedRegistrationName);
                if (!KNetConnectProxy.initializePredicate(this, configs, indexedRegistrationName)) {
                    log.error("Failed Invoke of \"initializePredicate\"");
                    throw new ConnectException("Failed Invoke of \"initializePredicate\"");
                }
                JCOBridge.RegisterJVMGlobal(indexedRegistrationName, this);
                log.info("RegisterJVMGlobal done for {}", indexedRegistrationName);
                predicateObject = KNetConnectProxy.getPredicate(indexedRegistrationName);
            }
            if (predicateObject != null) {
                try {
                    AbstractConfig config = new AbstractConfig(config(), configs);
                    dataToExchange = config.values();
                    predicateObject.Invoke("ConfigureInternal");
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
    public String toString() {
        log.debug("Invoking toString");
        String result = null;
        try {
            if (predicateObject != null) {
                result = (String) predicateObject.Invoke("ToStringInternal");
            }
        } catch (JCException jcne) {
            log.error("Failed Invoke of \"toString\"", jcne);
        }
        return result != null ? result : super.toString();
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
