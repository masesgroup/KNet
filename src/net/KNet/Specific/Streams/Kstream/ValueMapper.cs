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

using Java.Util;
using MASES.KNet.Serialization;
using System;
using System.Collections.Generic;

namespace MASES.KNet.Streams.Kstream
{
    /// <summary>
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.Kstream.ValueMapper{V, VR}"/>
    /// </summary>
    /// <typeparam name="V">first value type</typeparam>
    /// <typeparam name="VR">joined value type</typeparam>
    /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
    /// <typeparam name="TJVMVR">The JVM type of <typeparamref name="VR"/></typeparam>
    public class ValueMapper<V, VR, TJVMV, TJVMVR> : Org.Apache.Kafka.Streams.Kstream.ValueMapper<TJVMV, TJVMVR>, IGenericSerDesFactoryApplier
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
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/ValueMapperWithKey.html#apply-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <remarks>If <see cref="OnApply"/> has a value it takes precedence over corresponding class method</remarks>
        public new System.Func<V, VR> OnApply { get; set; } = null;

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/ValueMapperWithKey.html#apply-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="V"/></param>
        /// <returns><typeparamref name="VR"/></returns>
        public virtual VR Apply(V arg0)
        {
            return default;
        }
    }

    /// <summary>
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.Kstream.ValueMapper{V, VR}"/>
    /// </summary>
    /// <typeparam name="V">first value type</typeparam>
    /// <typeparam name="VR">joined value type</typeparam>
    public class ValueMapper<V, VR> : ValueMapper<V, VR, byte[], byte[]>
    {
        ISerDes<V, byte[]> _vSerializer = null;
        ISerDes<VR, byte[]> _vrSerializer = null;
        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/ValueMapperWithKey.html#apply-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <remarks>If <see cref="OnApply"/> has a value it takes precedence over corresponding class method</remarks>
        public new System.Func<V, VR> OnApply { get; set; } = null;

        /// <inheritdoc/>
        public sealed override byte[] Apply(byte[] arg0)
        {
            _vSerializer ??= Factory?.BuildValueSerDes<V, byte[]>();
            _vrSerializer ??= Factory?.BuildValueSerDes<VR, byte[]>();

            var methodToExecute = (OnApply != null) ? OnApply : Apply;
            var res = methodToExecute(_vSerializer.Deserialize(null, arg0));
            return _vrSerializer.Serialize(null, res);
        }
    }

    /// <summary>
    /// KNet extension of <see cref="ValueMapper{V, VR, TJVMV, TJVMVR}"/>
    /// </summary>
    /// <typeparam name="V">first value type</typeparam>
    /// <typeparam name="VR">joined value type</typeparam>
    /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
    /// <typeparam name="TJVMVR">The JVM type of <typeparamref name="VR"/></typeparam>
    public abstract class EnumerableValueMapper<V, VR, TJVMV, TJVMVR> : ValueMapper<V, VR, TJVMV, Java.Lang.Iterable<TJVMVR>>
    {
        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/ValueMapperWithKey.html#apply-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <remarks>If <see cref="OnApply"/> has a value it takes precedence over corresponding class method</remarks>
        public new System.Func<V, IEnumerable<VR>> OnApply { get; set; } = null;

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/ValueMapperWithKey.html#apply-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="V"/></param>
        /// <returns><typeparamref name="VR"/></returns>
        public new virtual IEnumerable<VR> Apply(V arg0)
        {
            return default;
        }
    }

    /// <summary>
    /// KNet extension of <see cref="EnumerableValueMapper{V, VR, TJVMV, TJVMVR}"/>
    /// </summary>
    /// <typeparam name="V">first value type</typeparam>
    /// <typeparam name="VR">joined value type</typeparam>
    public class EnumerableValueMapper<V, VR> : EnumerableValueMapper<V, VR, byte[], byte[]>
    {
        ISerDes<V, byte[]> _vSerializer = null;
        ISerDes<VR, byte[]> _vrSerializer = null;

        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/ValueMapperWithKey.html#apply-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <remarks>If <see cref="OnApply"/> has a value it takes precedence over corresponding class method</remarks>
        public new System.Func<V, IEnumerable<VR>> OnApply { get; set; } = null;
        /// <inheritdoc/>
        public sealed override Java.Lang.Iterable<byte[]> Apply(byte[] arg0)
        {
            _vSerializer ??= Factory?.BuildValueSerDes<V, byte[]>();
            _vrSerializer ??= Factory?.BuildValueSerDes<VR, byte[]>();

            var methodToExecute = (OnApply != null) ? OnApply : Apply;
            var res = methodToExecute(_vSerializer.Deserialize(null, arg0));
            var result = new ArrayList<byte[]>();
            foreach (var item in res)
            {
                result.Add(_vrSerializer.Serialize(null, item));
            }
            return result;
        }

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/ValueMapperWithKey.html#apply-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="V"/></param>
        /// <returns><typeparamref name="VR"/></returns>
        public new virtual IEnumerable<VR> Apply(V arg0)
        {
            return default;
        }
    }
}
