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

package org.mases.knet.streams.processor.api;

import org.apache.kafka.streams.processor.api.Processor;
import org.apache.kafka.streams.processor.api.ProcessorContext;
import org.apache.kafka.streams.processor.api.Record;
import org.mases.jcobridge.*;

public final class ProcessorImpl extends JCListener implements Processor {
    public ProcessorImpl(String key) throws JCNativeException {
        super(key);
    }

    @Override
    public void init(ProcessorContext context) {
        raiseEvent("init", context);
    }
    @Override
    public void process(Record record) {
        raiseEvent("process", record);
    }
    @Override
    public void close() {
        raiseEvent("close");
    }
}
