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
import org.apache.kafka.clients.consumer.ConsumerRecords;
import org.apache.kafka.clients.consumer.KafkaConsumer;
import org.apache.kafka.common.serialization.Deserializer;

import java.time.Duration;
import java.util.Map;
import java.util.Properties;

public class KNetConsumer<K, V> extends KafkaConsumer<K, V> {
    KNetConsumerCallback _callback = null;

    public KNetConsumer(Map<String, Object> configs) {
        super(configs);
    }

    public KNetConsumer(Properties properties) {
        super(properties);
    }

    public KNetConsumer(Properties properties, Deserializer<K> keyDeserializer, Deserializer<V> valueDeserializer) {
        super(properties, keyDeserializer, valueDeserializer);
    }

    public KNetConsumer(Map<String, Object> configs, Deserializer<K> keyDeserializer, Deserializer<V> valueDeserializer) {
        super(configs, keyDeserializer, valueDeserializer);
    }

    public void consume(long timeoutMs) {
        ConsumerRecords<K, V> records = super.poll(timeoutMs);
        for (ConsumerRecord<K, V> record : records) {
            if (_callback != null) _callback.recordReady(record);
        }
    }

    public void consume(Duration timeout) {
        ConsumerRecords<K, V> records = super.poll(timeout);
        for (ConsumerRecord<K, V> record : records) {
            if (_callback != null) _callback.recordReady(record);
        }
    }

    public void setCallback(KNetConsumerCallback callback) {
        _callback = callback;
    }
}
