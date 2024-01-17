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

package org.mases.knet.streams.kstream;

import org.apache.kafka.streams.kstream.Predicate;
import org.mases.jcobridge.*;

import java.util.Arrays;

public final class KNetPredicateEqualityTest implements Predicate<byte[], byte[]> {
    Boolean _isKey = null;
    byte[] _key = null;
    byte[] _value = null;

    public synchronized void setWorkingState(byte[] key, byte[] value, Boolean isKey) {
        _isKey = isKey;
        _key = key;
        _value = value;
    }

    @Override
    public synchronized boolean test(byte[] bytes, byte[] bytes2) {
        if (_isKey != null) {
            if (_isKey == true) {
                return Arrays.equals(bytes, _key);
            } else {
                return Arrays.equals(bytes2, _value);
            }
        } else {
            return Arrays.equals(bytes, _key) && Arrays.equals(bytes2, _value);
        }
    }
}
