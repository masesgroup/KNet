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

import org.apache.kafka.common.serialization.Serializer;
import org.mases.jcobridge.JCSharedBuffer;

import java.io.IOException;
import java.nio.ByteBuffer;

/**
 * {@code ByteBufferSerializer} always {@link ByteBuffer#rewind() rewinds} the position of the input buffer to zero for
 * serialization. A manual rewind is not necessary.
 * <p>
 * Note: any existing buffer position is ignored.
 * <p>
 * The position is also rewound back to zero before {@link #serialize(String, ByteBuffer)}
 * returns.
 */
public class ByteBufferSerializer implements Serializer<ByteBuffer> {
    public byte[] serialize(String topic, ByteBuffer data) {
        if (data == null)
            return null;

        try {
            try (JCSharedBuffer sb = JCSharedBuffer.Create(data)) {
                sb.rewind();

                if (sb.hasArray()) {
                    byte[] arr = sb.array();
                    if (sb.arrayOffset() == 0 && arr.length == sb.remaining()) {
                        return arr;
                    }
                }

                byte[] ret = new byte[data.remaining()];
                sb.get(ret, 0, ret.length);
                sb.rewind();
                return ret;
            }
        } catch (IOException iae) {
            // fallback to non buffered version
            data.rewind();

            if (data.hasArray()) {
                byte[] arr = data.array();
                if (data.arrayOffset() == 0 && arr.length == data.remaining()) {
                    return arr;
                }
            }

            byte[] ret = new byte[data.remaining()];
            data.get(ret, 0, ret.length);
            data.rewind();
            return ret;
        }
    }
}
