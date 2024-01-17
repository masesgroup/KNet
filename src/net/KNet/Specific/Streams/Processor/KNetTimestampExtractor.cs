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

using MASES.JCOBridge.C2JBridge;
using MASES.KNet.Consumer;
using MASES.KNet.Serialization;

namespace MASES.KNet.Streams.Processor
{
    /// <summary>
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.Processor.TimestampExtractor"/>
    /// </summary>
    /// <typeparam name="TKey">The key type</typeparam>
    /// <typeparam name="TValue">The value type</typeparam>
    public class KNetTimestampExtractor<TKey, TValue> : Org.Apache.Kafka.Streams.Processor.TimestampExtractor, IGenericSerDesFactoryApplier
    {
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }
        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/processor/TimestampExtractor.html#extract-org.apache.kafka.clients.consumer.ConsumerRecord-long-"/>
        /// </summary>
        /// <remarks>If <see cref="OnExtract"/> has a value it takes precedence over corresponding class method</remarks>
        public new System.Func<KNetConsumerRecord<TKey, TValue>, long, long> OnExtract { get; set; } = null;

        /// <inheritdoc/>
        public sealed override long Extract(Org.Apache.Kafka.Clients.Consumer.ConsumerRecord<object, object> arg0, long arg1)
        {
            IKNetSerDes<TKey> keySerializer = _factory.BuildKeySerDes<TKey>();
            IKNetSerDes<TValue> valueSerializer = _factory.BuildValueSerDes<TValue>();
            var record = arg0.Cast<Org.Apache.Kafka.Clients.Consumer.ConsumerRecord<byte[], byte[]>>(); // KNet consider the data within Apache Kafka Streams defined always as byte[]
            var methodToExecute = (OnExtract != null) ? OnExtract : Extract;
            return methodToExecute(new KNetConsumerRecord<TKey, TValue>(record, keySerializer, valueSerializer), arg1);
        }
        /// <summary>
        /// KNet implementation of <see cref="Org.Apache.Kafka.Streams.Processor.TimestampExtractor.Extract(Org.Apache.Kafka.Clients.Consumer.ConsumerRecord{object, object}, long)"/>
        /// </summary>
        /// <param name="arg0">The <see cref="KNetConsumerRecord{K, V}"/> with information</param>
        /// <param name="arg1"></param>
        /// <returns></returns>
        public virtual long Extract(KNetConsumerRecord<TKey, TValue> arg0, long arg1)
        {
            return default;
        }
    }
}
