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

using Java.Util.Concurrent;
using MASES.JCOBridge.C2JBridge;
using MASES.KafkaBridge.Clients.Producer;
using System;
using System.Threading.Tasks;

namespace MASES.KafkaBridge.Extensions
{
    public static class KafkaProducerExtensions
    {
        public static void Produce<K, V>(this IProducer<K, V> producer, string topic, K key, V value, Action<RecordMetadata, JVMBridgeException> action = null)
        {
            Produce(producer, new ProducerRecord<K, V>(topic, key, value), action);
        }

        public static void Produce<K, V>(this IProducer<K, V> producer, string topic, int partition, K key, V value, Action<RecordMetadata, JVMBridgeException> action = null)
        {
            Produce(producer, new ProducerRecord<K, V>(topic, partition, key, value), action);
        }

        public static void Produce<K, V>(this IProducer<K, V> producer, string topic, int partition, long timestamp, K key, V value, Action<RecordMetadata, JVMBridgeException> action = null)
        {
            Produce(producer, new ProducerRecord<K, V>(topic, partition, timestamp, key, value), action);
        }

        public static void Produce<K, V>(this IProducer<K, V> producer, string topic, int partition, DateTime timestamp, K key, V value, Action<RecordMetadata, JVMBridgeException> action = null)
        {
            Produce(producer, new ProducerRecord<K, V>(topic, partition, timestamp, key, value), action);
        }

        public static void Produce<K, V>(this IProducer<K, V> producer, ProducerRecord<K, V> record, Action<RecordMetadata, JVMBridgeException> action = null)
        {
            Callback cb = null;

            try
            {
                Future<RecordMetadata> result;
                if (action != null)
                {
                    cb = new Callback(action);
                    result = producer.Send(record, cb);
                }
                else
                {
                    result = producer.Send(record);
                }
                result.Get();
            }
            catch (ExecutionException e)
            {
                throw e.InnerException;
            }
            finally
            {
                cb?.Dispose();
            }
        }

        public static async Task ProduceAsync<K, V>(this IProducer<K, V> producer, string topic, K key, V value, Action<RecordMetadata, JVMBridgeException> action = null)
        {
            await ProduceAsync(producer, new ProducerRecord<K, V>(topic, key, value), action);
        }

        public static async Task ProduceAsync<K, V>(this IProducer<K, V> producer, string topic, int partition, K key, V value, Action<RecordMetadata, JVMBridgeException> action = null)
        {
            await ProduceAsync(producer, new ProducerRecord<K, V>(topic, partition, key, value), action);
        }

        public static async Task ProduceAsync<K, V>(this IProducer<K, V> producer, string topic, int partition, long timestamp, K key, V value, Action<RecordMetadata, JVMBridgeException> action = null)
        {
            await ProduceAsync(producer, new ProducerRecord<K, V>(topic, partition, timestamp, key, value), action);
        }

        public static async Task ProduceAsync<K, V>(this IProducer<K, V> producer, string topic, int partition, DateTime timestamp, K key, V value, Action<RecordMetadata, JVMBridgeException> action = null)
        {
            await ProduceAsync(producer, new ProducerRecord<K, V>(topic, partition, timestamp, key, value), action);
        }

        public static async Task ProduceAsync<K, V>(this IProducer<K, V> producer, ProducerRecord<K, V> record, Action<RecordMetadata, JVMBridgeException> action = null)
        {
            Task<Task> task = Task.Factory.StartNew(() =>
            {
                Produce(producer, record, action);
                return Task.CompletedTask;
            });

            await task;
            if (task.Result.Status == TaskStatus.Faulted && task.Result.Exception != null)
            {
                throw task.Result.Exception.Flatten().InnerException;
            }
        }
    }
}
