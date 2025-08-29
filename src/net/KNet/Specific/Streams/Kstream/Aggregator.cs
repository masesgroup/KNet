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
    /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
    /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
    /// <typeparam name="TJVMVA">The JVM type of <typeparamref name="VA"/></typeparam>
    public class Aggregator<K, V, VA, TJVMK, TJVMV, TJVMVA> : Org.Apache.Kafka.Streams.Kstream.Aggregator<TJVMK, TJVMV, TJVMVA>, IGenericSerDesFactoryApplier
    {
        TJVMK _arg0;
        TJVMV _arg1;
        TJVMVA _arg2;
        K _key;
        bool _keySet = false;
        V _value;
        bool _valueSet = false;
        VA _aggregate;
        bool _aggregateSet = false;
        ISerDes<K, TJVMK> _kSerializer = null;
        ISerDes<V, TJVMV> _vSerializer = null;
        ISerDes<VA, TJVMVA> _vaSerializer = null;

        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set => _factory = value; }
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
        /// Handler for <see cref="Org.Apache.Kafka.Streams.Kstream.Aggregator{K, V, VAgg}.Apply(K, V, VAgg)"/>
        /// </summary>
        /// <remarks>If <see cref="OnApply"/> has a value it takes precedence over corresponding class method <see cref="Apply()"/></remarks>
        public new System.Func<Aggregator<K, V, VA, TJVMK, TJVMV, TJVMVA>, VA> OnApply { get; set; } = null;
        /// <summary>
        /// The <typeparamref name="K"/> content
        /// </summary>
        public virtual K Key { get { if (!_keySet) { _kSerializer ??= Factory?.BuildKeySerDes<K, TJVMK>(); _key = _kSerializer.Deserialize(null, _arg0); _keySet = true; } return _key; } }
        /// <summary>
        /// The <typeparamref name="V"/> content
        /// </summary>
        public virtual V Value { get { if (!_valueSet) { _vSerializer ??= Factory?.BuildValueSerDes<V, TJVMV>(); _value = _vSerializer.Deserialize(null, _arg1); _valueSet = true; } return _value; } }
        /// <summary>
        /// The <typeparamref name="VA"/> content
        /// </summary>
        public virtual VA Aggregate { get { if (!_aggregateSet) { _vaSerializer ??= Factory?.BuildValueSerDes<VA, TJVMVA>(); _aggregate = _vaSerializer.Deserialize(null, _arg2); _aggregateSet = true; } return _aggregate; } }
        /// <inheritdoc/>
        public sealed override TJVMVA Apply(TJVMK arg0, TJVMV arg1, TJVMVA arg2)
        {
            _keySet = _valueSet = _aggregateSet = false;
            _arg0 = arg0;
            _arg1 = arg1;
            _arg2 = arg2;

            VA res = (OnApply != null) ? OnApply(this) : Apply();
            _vaSerializer ??= Factory?.BuildValueSerDes<VA, TJVMVA>();
            return _vaSerializer.Serialize(null, res);
        }
        /// <inheritdoc cref="Org.Apache.Kafka.Streams.Kstream.Aggregator{K, V, VAgg}.Apply(K, V, VAgg)"/>
        public virtual VA Apply()
        {
            return default;
        }
    }

    /// <summary>
    /// KNet implementation of <see cref="Aggregator{K, V, VA, TJVMK, TJVMV, TJVMVA}"/>
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <typeparam name="VA">The key type</typeparam>
    public class Aggregator<K, V, VA> : Aggregator<K, V, VA, byte[], byte[], byte[]>
    {

    }
}
