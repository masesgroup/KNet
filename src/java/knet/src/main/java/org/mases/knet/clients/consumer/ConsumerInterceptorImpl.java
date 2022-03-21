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
