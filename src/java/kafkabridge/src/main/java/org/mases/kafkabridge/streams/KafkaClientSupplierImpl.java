/*
 *  MIT License
 *
 *  Copyright (c) 2022 MASES s.r.l.
 *
 *  Permission is hereby granted, free of charge, to any person obtaining a copy
 *  of this software and associated documentation files (the "Software"), to deal
 *  in the Software without restriction, including without limitation the rights
 *  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 *  copies of the Software, and to permit persons to whom the Software is
 *  furnished to do so, subject to the following conditions:
 *
 *  The above copyright notice and this permission notice shall be included in all
 *  copies or substantial portions of the Software.
 *
 *  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 *  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 *  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 *  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 *  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 *  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 *  SOFTWARE.
 */

package org.mases.kafkabridge.streams;

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