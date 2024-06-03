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

package org.mases.knet.developed.common.serialization;

import org.apache.kafka.common.serialization.Deserializer;
import org.mases.jcobridge.JCSharedBuffer;

import java.io.IOException;
import java.nio.ByteBuffer;

public class ByteBufferDeserializer implements Deserializer<ByteBuffer> {

    @Override
    public ByteBuffer deserialize(String topic, byte[] data) {
        if (data == null)
            return null;

        try {
            return JCSharedBuffer.Create(data);
        } catch (IOException e) {
            // fallback to non buffered version
            return ByteBuffer.wrap(data);
        }
    }
}
