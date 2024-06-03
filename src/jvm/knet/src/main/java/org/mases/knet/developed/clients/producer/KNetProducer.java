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

package org.mases.knet.developed.clients.producer;

import org.apache.kafka.clients.producer.Callback;
import org.apache.kafka.clients.producer.KafkaProducer;
import org.apache.kafka.clients.producer.ProducerRecord;
import org.apache.kafka.common.header.Header;
import org.apache.kafka.common.serialization.Serializer;

import java.util.Map;
import java.util.Properties;

public class KNetProducer<K, V> extends KafkaProducer<byte[], byte[]> {
    Callback _callback = null;

    public KNetProducer(Map<String, Object> configs) {
        super(configs);
    }

    public KNetProducer(Map<String, Object> configs, Serializer<byte[]> keySerializer, Serializer<byte[]> valueSerializer) {
        super(configs, keySerializer, valueSerializer);
    }

    public KNetProducer(Properties properties) {
        super(properties);
    }

    public KNetProducer(Properties properties, Serializer<byte[]> keySerializer, Serializer<byte[]> valueSerializer) {
        super(properties, keySerializer, valueSerializer);
    }

    public void setCallback(Callback callback) {
        _callback = callback;
    }

    public void send(String topic, Integer partition, Long timestamp, byte[] key, byte[] value, Iterable<Header> headers) {
        ProducerRecord record = new ProducerRecord(topic, partition, timestamp, key, value, headers);
        send(record, _callback);
    }

    public void send(String topic, Integer partition, Long timestamp, byte[] key, byte[] value) {
        ProducerRecord record = new ProducerRecord(topic, partition, timestamp, key, value);
        send(record, _callback);
    }

    public void send(String topic, Integer partition, byte[] key, byte[] value, Iterable<Header> headers) {
        ProducerRecord record = new ProducerRecord(topic, partition, key, value, headers);
        send(record, _callback);
    }

    public void send(String topic, Integer partition, byte[] key, byte[] value) {
        ProducerRecord record = new ProducerRecord(topic, partition, key, value);
        send(record, _callback);
    }

    public void send(String topic, byte[] key, byte[] value) {
        ProducerRecord record = new ProducerRecord(topic, key, value);
        send(record, _callback);
    }

    public void send(String topic, byte[] value) {
        ProducerRecord record = new ProducerRecord(topic, value);
        send(record, _callback);
    }

}
