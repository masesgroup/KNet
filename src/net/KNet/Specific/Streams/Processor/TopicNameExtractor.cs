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
using System;

namespace MASES.KNet.Streams.Processor
{
    /// <summary>
    /// KNet implementation of <see cref="Org.Apache.Kafka.Streams.Processor.TopicNameExtractor{TJVMK, TJVMV}"/>
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="V">The value type</typeparam>
    /// <typeparam name="TJVMK">The JVM key type</typeparam>
    /// <typeparam name="TJVMV">The JVM value type</typeparam>
    public class TopicNameExtractor<K, V, TJVMK, TJVMV> : Org.Apache.Kafka.Streams.Processor.TopicNameExtractor<TJVMK, TJVMV>, IGenericSerDesFactoryApplier
    {
        TJVMK _arg0;
        TJVMV _arg1;
        K _key;
        bool _keySet = false;
        V _value;
        bool _valueSet = false;
        Org.Apache.Kafka.Streams.Processor.RecordContext _context;
        ISerDes<K, TJVMK> _kSerializer = null;
        ISerDes<V, TJVMV> _vSerializer = null;

        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }
        /// <summary>
        /// Returns the current <see cref="IGenericSerDesFactory"/>
        /// </summary>
        protected IGenericSerDesFactory Factory
        {
            get
            {
                IGenericSerDesFactory factory = null;
                if (this is IGenericSerDesFactoryApplier applier && (factory = applier.Factory) == null)
                {
                    throw new InvalidOperationException("The serialization factory instance was not set.");
                }
                return factory;
            }
        }
        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.7.0/org/apache/kafka/streams/processor/TopicNameExtractor.html#extract-java.lang.Object-java.lang.Object-org.apache.kafka.streams.processor.RecordContext-"/>
        /// </summary>
        /// <remarks>If <see cref="OnExtract"/> has a value it takes precedence over corresponding <see cref="Extract()"/> class method</remarks>
        public new System.Func<TopicNameExtractor<K, V, TJVMK, TJVMV>, string> OnExtract { get; set; } = null;
        /// <summary>
        /// The <typeparamref name="K"/> content
        /// </summary>
        public virtual K Key { get { if (!_keySet) { _kSerializer ??= Factory?.BuildKeySerDes<K, TJVMK>(); _key = _kSerializer.Deserialize(null, _arg0); _keySet = true; } return _key; } }
        /// <summary>
        /// The <typeparamref name="V"/> content
        /// </summary>
        public virtual V Value { get { if (!_valueSet) { _vSerializer ??= Factory?.BuildValueSerDes<V, TJVMV>(); _value = _vSerializer.Deserialize(null, _arg1); _valueSet = true; } return _value; } }
        /// <summary>
        /// Current <see cref="Org.Apache.Kafka.Streams.Processor.RecordContext"/> metadata of the record
        /// </summary>
        public virtual Org.Apache.Kafka.Streams.Processor.RecordContext RecordContext => _context;
        /// <inheritdoc/>
        public sealed override Java.Lang.String Extract(TJVMK arg0, TJVMV arg1, Org.Apache.Kafka.Streams.Processor.RecordContext arg2)
        {
            _keySet = _valueSet = false;
            _arg0 = arg0;
            _arg1 = arg1;
            _context = arg2;

            return (OnExtract != null) ? OnExtract(this) : Extract();
        }
        /// <summary>
        /// KNet override of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.7.0/org/apache/kafka/streams/processor/TopicNameExtractor.html#extract-java.lang.Object-java.lang.Object-org.apache.kafka.streams.processor.RecordContext-"/>
        /// </summary>
        /// <returns><see cref="string"/></returns>
        public virtual string Extract()
        {
            return default;
        }
    }

    /// <summary>
    /// KNet implementation of <see cref="Org.Apache.Kafka.Streams.Processor.TopicNameExtractor{K, V}"/>
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="V">The value type</typeparam>
    public class TopicNameExtractor<K, V> : TopicNameExtractor<K, V, byte[], byte[]>
    {

    }
}
