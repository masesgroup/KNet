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

package org.mases.knet.developed.clients.producer;

import org.apache.kafka.clients.producer.Callback;
import org.apache.kafka.clients.producer.KafkaProducer;
import org.apache.kafka.clients.producer.ProducerRecord;
import org.apache.kafka.clients.producer.RecordMetadata;
import org.apache.kafka.common.header.Header;
import org.apache.kafka.common.serialization.Serializer;

import java.util.Map;
import java.util.Properties;
import java.util.concurrent.Future;

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

    public Future<RecordMetadata> send(String topic, Integer partition, Long timestamp, byte[] key, byte[] value, Iterable<Header> headers) {
        ProducerRecord record = new ProducerRecord(topic, partition, timestamp, key, value, headers);
        return send(record, _callback);
    }

    public Future<RecordMetadata> send(String topic, Integer partition, Long timestamp, java.nio.ByteBuffer key, java.nio.ByteBuffer value, Iterable<Header> headers) {
        ProducerRecord<java.nio.ByteBuffer, java.nio.ByteBuffer> record = new ProducerRecord<>(topic, partition, timestamp, key, value, headers);
        return ((KafkaProducer)this).send(record, _callback);
    }

    public Future<RecordMetadata> send(String topic, Integer partition, Long timestamp, byte[] key, byte[] value) {
        ProducerRecord record = new ProducerRecord(topic, partition, timestamp, key, value);
        return send(record, _callback);
    }

    public Future<RecordMetadata> send(String topic, Integer partition, Long timestamp, java.nio.ByteBuffer key, java.nio.ByteBuffer value) {
        ProducerRecord<java.nio.ByteBuffer, java.nio.ByteBuffer> record = new ProducerRecord<>(topic, partition, timestamp, key, value);
        return ((KafkaProducer)this).send(record, _callback);
    }

    public Future<RecordMetadata> send(String topic, Integer partition, byte[] key, byte[] value, Iterable<Header> headers) {
        ProducerRecord record = new ProducerRecord(topic, partition, key, value, headers);
        return send(record, _callback);
    }

    public Future<RecordMetadata> send(String topic, Integer partition, byte[] key, java.nio.ByteBuffer value, Iterable<Header> headers) {
        ProducerRecord<byte[], java.nio.ByteBuffer> record = new ProducerRecord<>(topic, partition, key, value, headers);
        return ((KafkaProducer)this).send(record, _callback);
    }

    public Future<RecordMetadata> send(String topic, Integer partition, java.nio.ByteBuffer key, java.nio.ByteBuffer value, Iterable<Header> headers) {
        ProducerRecord<java.nio.ByteBuffer, java.nio.ByteBuffer> record = new ProducerRecord<>(topic, partition, key, value, headers);
        return ((KafkaProducer)this).send(record, _callback);
    }

    public Future<RecordMetadata> send(String topic, Integer partition, byte[] key, byte[] value) {
        ProducerRecord record = new ProducerRecord(topic, partition, key, value);
        return send(record, _callback);
    }

    public Future<RecordMetadata> send(String topic, Integer partition, java.nio.ByteBuffer key, java.nio.ByteBuffer value) {
        ProducerRecord<java.nio.ByteBuffer, java.nio.ByteBuffer> record = new ProducerRecord<>(topic, partition, key, value);
        return ((KafkaProducer)this).send(record, _callback);
    }

    public Future<RecordMetadata> send(String topic, byte[] key, byte[] value) {
        ProducerRecord record = new ProducerRecord(topic, key, value);
        return send(record, _callback);
    }

    public Future<RecordMetadata> send(String topic, java.nio.ByteBuffer key, java.nio.ByteBuffer value) {
        ProducerRecord<java.nio.ByteBuffer, java.nio.ByteBuffer> record = new ProducerRecord<>(topic, key, value);
        return ((KafkaProducer)this).send(record, _callback);
    }

    public Future<RecordMetadata> send(String topic, byte[] value) {
        ProducerRecord record = new ProducerRecord(topic, value);
        return send(record, _callback);
    }

    public Future<RecordMetadata> send(String topic, java.nio.ByteBuffer value) {
        ProducerRecord<java.nio.ByteBuffer, java.nio.ByteBuffer> record = new ProducerRecord<>(topic, value);
        return ((KafkaProducer)this).send(record, _callback);
    }
}
