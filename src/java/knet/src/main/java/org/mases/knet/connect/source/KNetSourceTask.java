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

import org.apache.kafka.connect.errors.ConnectException;
import org.apache.kafka.connect.source.SourceRecord;
import org.apache.kafka.connect.source.SourceTask;
import org.apache.kafka.connect.source.SourceTaskContext;
import org.mases.jcobridge.*;
import org.mases.knet.connect.KNetConnectLogging;
import org.mases.knet.connect.KNetConnectProxy;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.io.IOException;
import java.util.List;
import java.util.Map;
import java.util.concurrent.atomic.AtomicLong;

public class KNetSourceTask extends SourceTask implements KNetConnectLogging {
    private static final Logger log = LoggerFactory.getLogger(KNetSourceTask.class);
    static final AtomicLong taskId = new AtomicLong(0);

    JCObject sourceTask = null;

    Object dataToExchange = null;

    public Object getDataToExchange() {
        return dataToExchange;
    }

    public void setDataToExchange(Object dte) {
        dataToExchange = dte;
    }

    public KNetSourceTask() throws ConnectException, JCException, IOException {
        super();
        long taskid = taskId.incrementAndGet();
        JCOBridge.RegisterJVMGlobal(String.format("KNetSourceTask_%d", taskid), this);
        JCObject source = KNetConnectProxy.getSourceConnector();
        if (source == null) throw new ConnectException("getSourceConnector returned null.");
        sourceTask = (JCObject) source.Invoke("AllocateTask", taskid);
    }

    public SourceTaskContext getContext() {
        return context;
    }

    @Override
    public String version() {
        try {
            if (sourceTask != null) {
                return (String) sourceTask.Invoke("VersionInternal");
            }
        } catch (JCNativeException jcne) {
            log.error("Failed Invoke of \"version\"", jcne);
        }
        return "NOT AVAILABLE";
    }

    @Override
    public void start(Map<String, String> map) {
        try {
            try {
                dataToExchange = map;
                sourceTask.Invoke("StartInternal");
            } finally {
                dataToExchange = null;
            }
        } catch (JCNativeException jcne) {
            log.error("Failed Invoke of \"start\"", jcne);
        }
    }

    @Override
    public List<SourceRecord> poll() throws InterruptedException {
        try {
            try {
                dataToExchange = null;
                sourceTask.Invoke("PollInternal");
                if (dataToExchange != null) return (List<SourceRecord>) dataToExchange;
            } finally {
                dataToExchange = null;
            }
        } catch (JCNativeException jcne) {
            log.error("Failed Invoke of \"poll\"", jcne);
        }
        return null;
    }

    @Override
    public void stop() {
        try {
            sourceTask.Invoke("StopInternal");
        } catch (JCNativeException jcne) {
            log.error("Failed Invoke of \"stop\"", jcne);
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
