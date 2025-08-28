/*
 *  Copyright (c) 2021-2025 MASES s.r.l.
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

package org.mases.knet.developed.streams;

public class KeyValueSupport<K, V> {
    final K _key;
    final V _value;

    public static <K, V> org.apache.kafka.streams.KeyValue<K, V> toKeyValue(KeyValueSupport<K, V> kvs) {
        return org.apache.kafka.streams.KeyValue.pair(kvs.getKey(), kvs.getValue());
    }

    public KeyValueSupport(org.apache.kafka.streams.KeyValue<K, V> innerKV) {
        _key = innerKV.key;
        _value = innerKV.value;
    }

    public K getKey() {
        return _key;
    }

    public V getValue() {
        return _value;
    }

    public String toString() {
        String var = String.valueOf(this._key);
        return "KeyValue(" + var + ", " + String.valueOf(this._value) + ")";
    }

    public boolean equals(Object obj) {
        if (this == obj) {
            return true;
        } else if (!(obj instanceof KeyValueSupport)) {
            return false;
        } else {
            KeyValueSupport<?, ?> other = (KeyValueSupport) obj;
            return java.util.Objects.equals(this._key, other._key) && java.util.Objects.equals(this._value, other._value);
        }
    }

    public int hashCode() {
        return java.util.Objects.hash(new Object[]{this._key, this._value});
    }
}
