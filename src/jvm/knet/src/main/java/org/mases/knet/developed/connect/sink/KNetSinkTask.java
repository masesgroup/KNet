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

package org.mases.knet.developed.connect.sink;

import org.apache.kafka.connect.errors.ConnectException;
import org.apache.kafka.connect.sink.SinkRecord;
import org.apache.kafka.connect.sink.SinkTask;
import org.apache.kafka.connect.sink.SinkTaskContext;
import org.mases.jcobridge.*;
import org.mases.knet.developed.connect.KNetConnectLogging;
import org.mases.knet.developed.connect.KNetConnectProxy;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.io.IOException;
import java.util.Collection;
import java.util.Map;

public class KNetSinkTask extends SinkTask implements KNetConnectLogging {
    private static final Logger log = LoggerFactory.getLogger(KNetSinkTask.class);

    private static final String registrationName = "KNetSinkTask";

    long taskId = 0;

    String indexedRegistrationName;

    JCObject sinkTask = null;

    Object dataToExchange = null;

    public Object getDataToExchange() {
        return dataToExchange;
    }

    public void setDataToExchange(Object dte) {
        dataToExchange = dte;
    }

    public KNetSinkTask() throws ConnectException, JCException, IOException {
        super();
        log.debug("Invoking ctor of KNetSinkTask");
        taskId = KNetConnectProxy.getNewTaskId();
        indexedRegistrationName = String.format("%s_%d", registrationName, taskId);
        if (JCOBridge.isCLRHostingProcess()) {
            JCOBridge.RegisterJVMGlobal(indexedRegistrationName, this);
            JCObject sink = KNetConnectProxy.getSinkConnector();
            if (sink == null) throw new ConnectException("getSinkConnector returned null.");
            sinkTask = (JCObject) sink.Invoke("AllocateTask", taskId);
        }
    }

    public SinkTaskContext getContext() {
        return context;
    }

    @Override
    public String version() {
        log.debug("Invoking version");
        try {
            if (sinkTask != null) {
                return (String) sinkTask.Invoke("VersionInternal");
            }
        } catch (JCNativeException jcne) {
            log.error("Failed Invoke of \"version\"", jcne);
        }
        return "NOT AVAILABLE";
    }

    @Override
    public void start(Map<String, String> map) {
        log.debug("Invoking start");
        try {
            if (!JCOBridge.isCLRHostingProcess()) {
                JCOBridge.RegisterJVMGlobal(indexedRegistrationName, this);
                String connectorId = KNetConnectProxy.getConnectorId(map);
                JCObject sink = KNetConnectProxy.getConnector(connectorId);
                if (sink == null) throw new ConnectException("getConnector returned null.");
                sinkTask = (JCObject) sink.Invoke("AllocateTask", taskId);
            }

            try {
                dataToExchange = map;
                sinkTask.Invoke("StartInternal");
            } finally {
                dataToExchange = null;
            }
        } catch (JCException | IOException jcne) {
            log.error("Failed Invoke of \"start\"", jcne);
        }
    }

    @Override
    public void put(Collection<SinkRecord> collection) {
        log.debug("Invoking put");
        try {
            try {
                dataToExchange = collection;
                sinkTask.Invoke("PutInternal");
            } finally {
                dataToExchange = null;
            }
        } catch (JCNativeException jcne) {
            log.error("Failed Invoke of \"put\"", jcne);
        }
    }

    @Override
    public void stop() {
        log.debug("Invoking stop");
        try {
            sinkTask.Invoke("StopInternal");
        } catch (JCNativeException jcne) {
            log.error("Failed Invoke of \"stop\"", jcne);
        }
        finally {
            if (!JCOBridge.isCLRHostingProcess()) {
                try {
                    JCOBridge.UnregisterJVMGlobal(indexedRegistrationName);
                } catch (JCNativeException e) {
                    throw new RuntimeException(e);
                }
            }
        }
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
