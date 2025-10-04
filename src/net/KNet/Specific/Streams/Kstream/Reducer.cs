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
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.Kstream.Reducer{TJVMV}"/>
    /// </summary>
    /// <typeparam name="V">value type</typeparam>
    /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
    public class Reducer<V, TJVMV> : Org.Apache.Kafka.Streams.Kstream.Reducer<TJVMV>, IGenericSerDesFactoryApplier
    {
        TJVMV _arg0;
        TJVMV _arg1;
        V _value1;
        bool _value1Set;
        V _value2;
        bool _value2Set;
        ISerDes<V, TJVMV> _vSerializer = null;

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
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.1.0/org/apache/kafka/streams/kstream/ValueMapperWithKey.html#apply(java.lang.Object,java.lang.Object)"/>
        /// </summary>
        /// <remarks>If <see cref="OnApply"/> has a value it takes precedence over corresponding <see cref="Apply()"/> class method</remarks>
        public new System.Func<Reducer<V, TJVMV>, V> OnApply { get; set; } = null;

        /// <summary>
        /// The <typeparamref name="V"/> content
        /// </summary>
        public virtual V Value1 { get { if (!_value1Set) { _vSerializer ??= Factory?.BuildValueSerDes<V, TJVMV>(); _value1 = _vSerializer.Deserialize(null, _arg0); _value1Set = true; } return _value1; } }

        /// <summary>
        /// The <typeparamref name="V"/> content
        /// </summary>
        public virtual V Value2 { get { if (!_value2Set) { _vSerializer ??= Factory?.BuildValueSerDes<V, TJVMV>(); _value2 = _vSerializer.Deserialize(null, _arg1); _value2Set = true; } return _value2; } }

        /// <inheritdoc/>
        public override TJVMV Apply(TJVMV arg0, TJVMV arg1)
        {
            _value1Set = _value2Set = false;
            _arg0 = arg0;
            _arg1 = arg1;

            V res = (OnApply != null) ? OnApply(this) : Apply();
            _vSerializer ??= Factory?.BuildValueSerDes<V, TJVMV>();
            return _vSerializer.Serialize(null, res);
        }

        /// <inheritdoc cref="Org.Apache.Kafka.Streams.Kstream.Reducer{V}.Apply(V, V)"/>
        public virtual V Apply()
        {
            return default;
        }
    }

    /// <summary>
    /// KNet extension of <see cref="Reducer{V, TJVMV}"/>
    /// </summary>
    /// <typeparam name="V">value type</typeparam>
    public class Reducer<V> : Reducer<V, byte[]>
    {
    }
}
