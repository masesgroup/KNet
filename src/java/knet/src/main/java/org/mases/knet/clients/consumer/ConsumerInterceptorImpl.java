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

package org.mases.knet.clients.consumer;

import org.apache.kafka.clients.consumer.ConsumerInterceptor;
import org.apache.kafka.clients.consumer.ConsumerRecords;
import org.mases.jcobridge.*;

import java.util.Map;

public final class ConsumerInterceptorImpl extends JCListener implements ConsumerInterceptor {
    public ConsumerInterceptorImpl(String key) throws JCNativeException {
        super(key);
    }

    @Override
    public void configure(Map configs) {
        raiseEvent("configure", configs);
    }

    @Override
    public ConsumerRecords onConsume(ConsumerRecords records) {
        raiseEvent("onConsume", records);
        Object retVal = getReturnData();
        return (ConsumerRecords) retVal;
    }

    @Override
    public void onCommit(Map offsets) {
        raiseEvent("onCommit", offsets);
    }

    @Override
    public void close() {
        raiseEvent("close");
    }
}
