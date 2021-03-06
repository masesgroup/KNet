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

package org.mases.knet.clients.common.serialization;

import org.apache.kafka.common.header.Headers;
import org.apache.kafka.common.serialization.Deserializer;
import org.mases.jcobridge.*;

import java.util.Map;

public final class DeserializerImpl extends JCListener implements Deserializer {
    public DeserializerImpl(String key) throws JCNativeException {
        super(key);
    }

    public Object deserialize(String topic, byte[] data) {
        raiseEvent("deserialize", topic, null, data);
        Object retVal = getReturnData();
        return retVal;
    }

    public Object deserialize(String topic, Headers headers, byte[] data) {
        raiseEvent("deserializeWithHeaders", topic, headers, data);
        Object retVal = getReturnData();
        return retVal;
    }
}