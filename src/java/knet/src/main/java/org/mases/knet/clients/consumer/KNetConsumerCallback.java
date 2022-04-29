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

import org.apache.kafka.clients.consumer.ConsumerRecord;
import org.apache.kafka.common.annotation.InterfaceStability;
import org.mases.jcobridge.*;

@InterfaceStability.Evolving
public class KNetConsumerCallback extends JCListener {
    public KNetConsumerCallback(String key) throws JCNativeException {
        super(key);
    }
    ConsumerRecord _record;
    public void recordReady(ConsumerRecord record) {
        try
        {
            _record = record;
            raiseEvent("recordReady");
        }
        finally {
            _record = null;
        }
    }

    public ConsumerRecord getRecord() {
        return _record;
    }

    public Object getKey() {
        return _record.key();
    }

    public Object getValue() {
        return _record.value();
    }
}
