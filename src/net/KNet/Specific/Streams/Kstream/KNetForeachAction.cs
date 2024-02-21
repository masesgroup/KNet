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

namespace MASES.KNet.Streams.Kstream
{
    /// <summary>
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.Kstream.ForeachAction{K, V}"/>
    /// </summary>
    /// <typeparam name="K">key value type</typeparam>
    /// <typeparam name="V">first value type</typeparam>
    public abstract class KNetForeachAction<K, V, TJVMK, TJVMV> : Org.Apache.Kafka.Streams.Kstream.ForeachAction<TJVMK, TJVMV>, IGenericSerDesFactoryApplier
    {
        protected IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }
        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/ForeachAction.html#apply-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <remarks>If <see cref="OnApply"/> has a value it takes precedence over corresponding <see cref="Apply()"/> class method</remarks>
        public new System.Action<KNetForeachAction<K, V>> OnApply { get; set; } = null;
        /// <summary>
        /// The <typeparamref name="K"/> content
        /// </summary>
        public abstract K Key { get; }
        /// <summary>
        /// The <typeparamref name="V"/> content
        /// </summary>
        public abstract V Value { get; }

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/ForeachAction.html#apply-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        public virtual void Apply()
        {

        }
    }

    /// <summary>
    /// KNet extension of <see cref="KNetForeachAction{K, V, TJVMK, TJVMV}"/>
    /// </summary>
    /// <typeparam name="K">key value type</typeparam>
    /// <typeparam name="V">first value type</typeparam>
    public class KNetForeachAction<K, V> : KNetForeachAction<K, V, byte[], byte[]>
    {
        byte[] _arg0, _arg1;
        K _key;
        bool _keySet = false;
        V _value;
        bool _valueSet = false;
        IKNetSerDes<K> _kSerializer = null;
        IKNetSerDes<V> _vSerializer = null;
        /// <summary>
        /// Default initializer
        /// </summary>
        public KNetForeachAction()
        {
            _kSerializer ??= _factory.BuildKeySerDes<K>();
            _vSerializer ??= _factory.BuildValueSerDes<V>();
        }

        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/ForeachAction.html#apply-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <remarks>If <see cref="OnApply"/> has a value it takes precedence over corresponding <see cref="KNetForeachAction{K, V, TJVMK, TJVMV}.Apply()"/> class method</remarks>
        public new System.Action<KNetForeachAction<K, V>> OnApply { get; set; } = null;
        /// <inheritdoc/>
        public override K Key { get { if (!_keySet) { _kSerializer ??= _factory.BuildKeySerDes<K>(); _key = _kSerializer.Deserialize(null, _arg0); _keySet = true; } return _key; } }
        /// <inheritdoc/>
        public override V Value { get { if (!_valueSet) { _vSerializer ??= _factory.BuildValueSerDes<V>(); _value = _vSerializer.Deserialize(null, _arg1); _valueSet = true; } return _value; } }
        /// <inheritdoc/>
        public sealed override void Apply(byte[] arg0, byte[] arg1)
        {
            _kSerializer ??= _factory.BuildKeySerDes<K>();
            _vSerializer ??= _factory.BuildValueSerDes<V>();
            _keySet = _valueSet = false;
            _arg0 = arg0;
            _arg1 = arg1;

            if (OnApply != null) OnApply(this); else Apply();
        }
    }
}
