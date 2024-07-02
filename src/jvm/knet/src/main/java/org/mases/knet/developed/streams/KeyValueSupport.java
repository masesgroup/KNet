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

package org.mases.knet.developed.streams;

public class KeyValueSupport<K, V> {
    org.apache.kafka.streams.KeyValue<K, V> _innerKV;

    public static <K, V> org.apache.kafka.streams.KeyValue<K, V> toKeyValue(KeyValueSupport<K, V> kvs) {
        return new org.apache.kafka.streams.KeyValue<K, V>(kvs.getKey(), kvs.getValue());
    }

    public KeyValueSupport(org.apache.kafka.streams.KeyValue<K, V> innerKV) {
        _innerKV = innerKV;
    }

    public K getKey() {
        return _innerKV.key;
    }

    public V getValue() {
        return _innerKV.value;
    }
}
