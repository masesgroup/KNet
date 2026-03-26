/*
 *  Copyright (c) 2021-2026 MASES s.r.l.
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

package org.mases.knet.developed.streams.state;

import org.apache.kafka.streams.state.RocksDBConfigSetter;
import org.rocksdb.Options;

import java.util.Map;

public class KNetRocksDBConfigSetter implements RocksDBConfigSetter {
    static KNetRocksDBConfigSetterCallback _callback;

    public static synchronized void setCallback(KNetRocksDBConfigSetterCallback callback) {
        _callback = callback;
    }

    @Override
    public synchronized void setConfig(String s, Options options, Map<String, Object> map) {
        if (_callback != null) {
            _callback.onSetConfig(this, s, options, map);
        }
        else {
            throw new IllegalStateException("The callback has not been set; use static method \"setCallback\" to set the callback every instance will use.");
        }
    }

    @Override
    public synchronized void close(String s, Options options) {
        if (_callback != null) {
            _callback.onClose(this, s, options);
        }
        else {
            throw new IllegalStateException("The callback has not been set; use static method \"setCallback\" to set the callback every instance will use.");
        }
    }
}
