/*
 *  Copyright 2023 MASES s.r.l.
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

package org.mases.knet.streams;

import org.apache.kafka.clients.admin.Admin;
import org.apache.kafka.clients.consumer.Consumer;
import org.apache.kafka.clients.producer.Producer;
import org.apache.kafka.streams.KafkaClientSupplier;
import org.mases.jcobridge.*;

import java.util.Map;

public final class KafkaClientSupplierImpl extends JCListener implements KafkaClientSupplier {
    public KafkaClientSupplierImpl(String key) throws JCNativeException {
        super(key);
    }

    @Override
    public Admin getAdmin(final Map<String, Object> config) {
        raiseEvent("getAdmin", config);
        Object retVal = getReturnData();
        return (Admin) retVal;
    }

    @Override
    public Producer<byte[], byte[]> getProducer(final Map<String, Object> config) {
        raiseEvent("getProducer", config);
        Object retVal = getReturnData();
        return (Producer<byte[], byte[]>) retVal;
    }

    @Override
    public Consumer<byte[], byte[]> getConsumer(final Map<String, Object> config) {
        raiseEvent("getConsumer", config);
        Object retVal = getReturnData();
        return (Consumer<byte[], byte[]>) retVal;
    }

    @Override
    public Consumer<byte[], byte[]> getRestoreConsumer(final Map<String, Object> config) {
        raiseEvent("getRestoreConsumer", config);
        Object retVal = getReturnData();
        return (Consumer<byte[], byte[]>) retVal;
    }

    @Override
    public Consumer<byte[], byte[]> getGlobalConsumer(final Map<String, Object> config) {
        raiseEvent("getGlobalConsumer", config);
        Object retVal = getReturnData();
        return (Consumer<byte[], byte[]>) retVal;
    }
}