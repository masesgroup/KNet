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

using MASES.KNet.Serialization;

namespace MASES.KNet.Streams.Processor
{
    /// <summary>
    /// KNet implementation of <see cref="Org.Apache.Kafka.Streams.Processor.TopicNameExtractor{K, V}"/>
    /// </summary>
    /// <typeparam name="TKey">The key type</typeparam>
    /// <typeparam name="TValue">The value type</typeparam>
    public class KNetTopicNameExtractor<TKey, TValue> : Org.Apache.Kafka.Streams.Processor.TopicNameExtractor<byte[], byte[]>, IGenericSerDesFactoryApplier
    {
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }
        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/processor/TopicNameExtractor.html#extract-java.lang.Object-java.lang.Object-org.apache.kafka.streams.processor.RecordContext-"/>
        /// </summary>
        /// <remarks>If <see cref="OnExtract"/> has a value it takes precedence over corresponding class method</remarks>
        public new System.Func<TKey, TValue, Org.Apache.Kafka.Streams.Processor.RecordContext, string> OnExtract { get; set; } = null;

        /// <inheritdoc/>
        public sealed override string Extract(byte[] arg0, byte[] arg1, Org.Apache.Kafka.Streams.Processor.RecordContext arg2)
        {
            IKNetSerDes<TKey> keySerializer = _factory.BuildKeySerDes<TKey>();
            IKNetSerDes<TValue> valueSerializer = _factory.BuildValueSerDes<TValue>();
            var methodToExecute = (OnExtract != null) ? OnExtract : Extract;
            return methodToExecute(keySerializer.Deserialize(null, arg0), valueSerializer.Deserialize(null, arg1), arg2);
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
