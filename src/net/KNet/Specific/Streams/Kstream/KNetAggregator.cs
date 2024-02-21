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

namespace MASES.KNet.Streams.Kstream
{
    /// <summary>
    /// KNet implementation of <see cref="Org.Apache.Kafka.Streams.Kstream.Aggregator{TJVMK, TJVMV, TJVMVA}"/>
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <typeparam name="VA">The key type</typeparam>
    public abstract class KNetAggregator<K, V, VA, TJVMK, TJVMV, TJVMVA> : Org.Apache.Kafka.Streams.Kstream.Aggregator<TJVMK, TJVMV, TJVMVA>, IGenericSerDesFactoryApplier
    {
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
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Aggregator.html#apply-java.lang.Object-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <remarks>If <see cref="OnApply"/> has a value it takes precedence over corresponding class method <see cref="Apply()"/></remarks>
        public new System.Func<KNetAggregator<K, V, VA>, VA> OnApply { get; set; } = null;
        /// <summary>
        /// The <typeparamref name="K"/> content
        /// </summary>
        public abstract K Key { get; }
        /// <summary>
        /// The <typeparamref name="V"/> content
        /// </summary>
        public abstract V Value { get; }
        /// <summary>
        /// The <typeparamref name="VA"/> content
        /// </summary>
        public abstract VA Aggregate { get; }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Aggregator.html#apply-java.lang.Object-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <returns><typeparamref name="VA"/></returns>
        public virtual VA Apply()
        {
            return default;
        }
    }

    /// <summary>
    /// KNet implementation of <see cref="KNetAggregator{K, V, VA, TJVMK, TJVMV, TJVMVA}"/>
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <typeparam name="VA">The key type</typeparam>
    public class KNetAggregator<K, V, VA> : KNetAggregator<K, V, VA, byte[], byte[], byte[]>
    {
        byte[] _arg0, _arg1, _arg2;
        K _key;
        bool _keySet = false;
        V _value;
        bool _valueSet = false;
        VA _aggregate;
        bool _aggregateSet = false;
        IKNetSerDes<K> _kSerializer = null;
        IKNetSerDes<V> _vSerializer = null;
        IKNetSerDes<VA> _vaSerializer = null;
        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Aggregator.html#apply-java.lang.Object-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <remarks>If <see cref="OnApply"/> has a value it takes precedence over corresponding class method <see cref="KNetAggregator{K, V, VA, TJVMK, TJVMV, TJVMVA}.Apply()"/></remarks>
        public new System.Func<KNetAggregator<K, V, VA>, VA> OnApply { get; set; } = null;
        /// <inheritdoc/>
        public override K Key { get { if (!_keySet) { _kSerializer ??= Factory?.BuildKeySerDes<K>(); _key = _kSerializer.Deserialize(null, _arg0); _keySet = true; } return _key; } }
        /// <inheritdoc/>
        public override V Value { get { if (!_valueSet) { _vSerializer ??= Factory?.BuildValueSerDes<V>(); _value = _vSerializer.Deserialize(null, _arg1); _valueSet = true; } return _value; } }
        /// <inheritdoc/>
        public override VA Aggregate { get { if (!_aggregateSet) { _vaSerializer ??= Factory?.BuildValueSerDes<VA>(); _aggregate = _vaSerializer.Deserialize(null, _arg2); _aggregateSet = true; } return _aggregate; } }
        /// <inheritdoc/>
        public sealed override byte[] Apply(byte[] arg0, byte[] arg1, byte[] arg2)
        {       
            _keySet = _valueSet = _aggregateSet = false;
            _arg0 = arg0;
            _arg1 = arg1;
            _arg2 = arg2;

            VA res = (OnApply != null) ? OnApply(this) : Apply();
            _vaSerializer ??= Factory?.BuildValueSerDes<VA>();
            return _vaSerializer.Serialize(null, res);
        }
    }
}
