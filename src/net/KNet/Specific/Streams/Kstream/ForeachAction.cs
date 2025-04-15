/*
*  Copyright 2025 MASES s.r.l.
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
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.Kstream.ForeachAction{K, V}"/>
    /// </summary>
    /// <typeparam name="K">key value type</typeparam>
    /// <typeparam name="V">first value type</typeparam>
    /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
    /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
    public class ForeachAction<K, V, TJVMK, TJVMV> : Org.Apache.Kafka.Streams.Kstream.ForeachAction<TJVMK, TJVMV>, IGenericSerDesFactoryApplier
    {
        TJVMK _arg0;
        TJVMV _arg1;
        K _key;
        bool _keySet = false;
        V _value;
        bool _valueSet = false;
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
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/ForeachAction.html#apply(java.lang.Object-java.lang.Object)"/>
        /// </summary>
        /// <remarks>If <see cref="OnApply"/> has a value it takes precedence over corresponding <see cref="Apply()"/> class method</remarks>
        public new System.Action<ForeachAction<K, V, TJVMK, TJVMV>> OnApply { get; set; } = null;
        /// <summary>
        /// The <typeparamref name="K"/> content
        /// </summary>
        public virtual K Key { get { if (!_keySet) { _kSerializer ??= Factory?.BuildKeySerDes<K, TJVMK>(); _key = _kSerializer.Deserialize(null, _arg0); _keySet = true; } return _key; } }
        /// <summary>
        /// The <typeparamref name="V"/> content
        /// </summary>
        public virtual V Value { get { if (!_valueSet) { _vSerializer ??= Factory?.BuildValueSerDes<V, TJVMV>(); _value = _vSerializer.Deserialize(null, _arg1); _valueSet = true; } return _value; } }
        /// <inheritdoc/>
        public sealed override void Apply(TJVMK arg0, TJVMV arg1)
        {
            _kSerializer ??= Factory?.BuildKeySerDes<K, TJVMK>();
            _vSerializer ??= Factory?.BuildValueSerDes<V, TJVMV>();
            _keySet = _valueSet = false;
            _arg0 = arg0;
            _arg1 = arg1;

            if (OnApply != null) OnApply(this); else Apply();
        }
        /// <inheritdoc cref="Org.Apache.Kafka.Streams.Kstream.ForeachAction{K, V}.Apply(K, V)"/>
        public virtual void Apply()
        {

        }
    }

    /// <summary>
    /// KNet extension of <see cref="ForeachAction{K, V, TJVMK, TJVMV}"/>
    /// </summary>
    /// <typeparam name="K">key value type</typeparam>
    /// <typeparam name="V">first value type</typeparam>
    public class ForeachAction<K, V> : ForeachAction<K, V, byte[], byte[]>
    {

    }
}
