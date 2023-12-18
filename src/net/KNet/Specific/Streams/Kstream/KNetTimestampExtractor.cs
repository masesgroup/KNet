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

using Java.Security;
using MASES.JCOBridge.C2JBridge;
using MASES.KNet.Consumer;
using MASES.KNet.Serialization;
using Org.Apache.Kafka.Clients.Consumer;
using Org.Apache.Kafka.Streams.Kstream;
using Org.Apache.Kafka.Streams.Processor;
using System;

namespace MASES.KNet.Specific.Streams.Kstream
{
    /// <summary>
    /// KNet extension of <see cref="TimestampExtractor"/>
    /// </summary>
    /// <typeparam name="TKey">The key type</typeparam>
    /// <typeparam name="TValue">The value type</typeparam>
    public class KNetTimestampExtractor<TKey, TValue> : TimestampExtractor
    {
        IKNetSerDes<TKey> _keySerializer;
        IKNetSerDes<TValue> _valueSerializer;
        /// <summary>
        /// Default initializer
        /// </summary>
        public KNetTimestampExtractor(IKNetSerDes<TKey> keySerializer, IKNetSerDes<TValue> valueSerializer) : base()
        {
            _keySerializer = keySerializer;
            _valueSerializer = valueSerializer;
        }

        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/processor/TimestampExtractor.html#extract-org.apache.kafka.clients.consumer.ConsumerRecord-long-"/>
        /// </summary>
        /// <remarks>If <see cref="OnExtract"/> has a value it takes precedence over corresponding class method</remarks>
        public new System.Func<KNetConsumerRecord<TKey, TValue>, long, long> OnExtract { get; set; } = null;

        /// <inheritdoc/>
        public sealed override long Extract(ConsumerRecord<object, object> arg0, long arg1)
        {
            var record = arg0.Cast<ConsumerRecord<byte[], byte[]>>(); // KNet consider the data within Apache Kafka Streams defined always as byte[]
            var methodToExecute = (OnExtract != null) ? OnExtract : Extract;
            return methodToExecute(new KNetConsumerRecord<TKey, TValue>(record, _keySerializer, _valueSerializer), arg1);
        }
        /// <summary>
        /// KNet implementation of <see cref="TimestampExtractor.Extract(ConsumerRecord{object, object}, long)"/>
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
