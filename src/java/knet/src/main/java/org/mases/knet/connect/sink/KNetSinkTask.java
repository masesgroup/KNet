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

package org.mases.knet.connect.sink;

import org.apache.kafka.common.config.ConfigException;
import org.apache.kafka.connect.sink.SinkRecord;
import org.apache.kafka.connect.sink.SinkTask;
import org.apache.kafka.connect.sink.SinkTaskContext;
import org.mases.jcobridge.*;
import org.mases.knet.connect.KNetConnectProxy;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.io.IOException;
import java.util.Collection;
import java.util.Map;
import java.util.concurrent.atomic.AtomicLong;

public class KNetSinkTask extends SinkTask {
    private static final Logger log = LoggerFactory.getLogger(KNetSinkTask.class);

    static final AtomicLong taskId = new AtomicLong(0);
    JCObject sinkTask = null;

    Object dataToExchange = null;

    public Object getDataToExchange() {
        return dataToExchange;
    }

    public void setDataToExchange(Object dte) {
        dataToExchange = dte;
    }

    public KNetSinkTask() throws ConfigException, JCException, IOException {
        super();
        long taskid = taskId.incrementAndGet();
        JCOBridge.RegisterJVMGlobal(String.format("KNetSinkTask_%d", taskid), this);
        JCObject sink = KNetConnectProxy.getSinkConnector();
        if (sink == null) throw new ConfigException("getSinkConnector returned null.");
        sinkTask = (JCObject) sink.Invoke("AllocateTask", taskid);
    }

    @Override
    public String version() {
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
        try {
            try {
                dataToExchange = map;
                sinkTask.Invoke("StartInternal");
            } finally {
                dataToExchange = null;
            }
        } catch (JCNativeException jcne) {
            log.error("Failed Invoke of \"start\"", jcne);
        }
    }

    @Override
    public void put(Collection<SinkRecord> collection) {
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
        try {
            sinkTask.Invoke("StopInternal");
        } catch (JCNativeException jcne) {
            log.error("Failed Invoke of \"stop\"", jcne);
        }
    }
}
