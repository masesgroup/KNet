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

using MASES.KNet.Serialization;
using Org.Apache.Kafka.Streams.Processor;

namespace MASES.KNet.Specific.Streams.Processor
{
    /// <summary>
    /// KNet implementation of <see cref="TopicNameExtractor{K, V}"/>
    /// </summary>
    /// <typeparam name="TKey">The key type</typeparam>
    /// <typeparam name="TValue">The value type</typeparam>
    public class KNetTopicNameExtractor<TKey, TValue> : TopicNameExtractor<byte[], byte[]>
    {
        IKNetSerDes<TKey> _keySerializer;
        IKNetSerDes<TValue> _valueSerializer;
        /// <summary>
        /// Default initializer
        /// </summary>
        public KNetTopicNameExtractor(IKNetSerDes<TKey> keySerializer, IKNetSerDes<TValue> valueSerializer) : base()
        {
            _keySerializer = keySerializer;
            _valueSerializer = valueSerializer;
        }
        /// <summary>
        /// The <see cref="IKNetSerDes{T}"/> associated to <typeparamref name="TKey"/>
        /// </summary>
        public IKNetSerDes<TKey> KeySerializer => _keySerializer;
        /// <summary>
        /// The <see cref="IKNetSerDes{T}"/> associated to <typeparamref name="TValue"/>
        /// </summary>
        public IKNetSerDes<TValue> ValueSerializer => _valueSerializer;

        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/processor/TopicNameExtractor.html#extract-java.lang.Object-java.lang.Object-org.apache.kafka.streams.processor.RecordContext-"/>
        /// </summary>
        /// <remarks>If <see cref="OnExtract"/> has a value it takes precedence over corresponding class method</remarks>
        public new System.Func<TKey, TValue, Org.Apache.Kafka.Streams.Processor.RecordContext, string> OnExtract { get; set; } = null;

        /// <inheritdoc/>
        public sealed override string Extract(byte[] arg0, byte[] arg1, Org.Apache.Kafka.Streams.Processor.RecordContext arg2)
        {
            var methodToExecute = (OnExtract != null) ? OnExtract : Extract;
            return methodToExecute(_keySerializer.Deserialize(null, arg0), _valueSerializer.Deserialize(null, arg1), arg2);
        }
        /// <summary>
        /// KNet override of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/processor/TopicNameExtractor.html#extract-java.lang.Object-java.lang.Object-org.apache.kafka.streams.processor.RecordContext-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="TKey"/></param>
        /// <param name="arg1"><typeparamref name="TValue"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Processor.RecordContext"/></param>
        /// <returns><see cref="string"/></returns>
        public virtual string Extract(TKey arg0, TValue arg1, Org.Apache.Kafka.Streams.Processor.RecordContext arg2)
        {
            return default;
        }
    }
}
