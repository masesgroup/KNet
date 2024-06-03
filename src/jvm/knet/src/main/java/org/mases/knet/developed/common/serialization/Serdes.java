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

import org.apache.kafka.common.serialization.Serde;

import java.nio.ByteBuffer;

public class Serdes {
    static public final class ByteBufferSerde extends org.apache.kafka.common.serialization.Serdes.WrapperSerde<ByteBuffer> {
        public ByteBufferSerde() {
            super(new ByteBufferSerializer(), new ByteBufferDeserializer());
        }
    }

    /**
     * A serde for nullable {@code ByteBuffer} type.
     *
     * @return {@link Serde} of {@link ByteBuffer}
     */
    static public Serde<ByteBuffer> ByteBuffer() {
        return new ByteBufferSerde();
    }
}
