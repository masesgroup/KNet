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

using Java.Util;
using MASES.KNet.Serialization;
using System;
using System.Collections.Generic;

namespace MASES.KNet.Streams.Kstream
{
    /// <summary>
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.Kstream.KeyValueMapper{K, V, VR}"/>
    /// </summary>
    /// <typeparam name="K">key value type</typeparam>
    /// <typeparam name="V">first value type</typeparam>
    /// <typeparam name="VR">joined value type</typeparam>
    /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
    /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
    /// <typeparam name="TJVMVR">The JVM type of <typeparamref name="VR"/></typeparam>
    public class KeyValueMapper<K, V, VR, TJVMK, TJVMV, TJVMVR> : Org.Apache.Kafka.Streams.Kstream.KeyValueMapper<TJVMK, TJVMV, TJVMVR>, IGenericSerDesFactoryApplier
    {
        ISerDes<K, TJVMK> _kSerializer = null;
        ISerDes<V, TJVMV> _vSerializer = null;
        ISerDes<VR, TJVMVR> _vrSerializer = null;

        /// <summary>
        /// <see cref="IGenericSerDesFactory"/> can be used from any class inherited from <see cref="KeyValueMapper{K, V, VR, TJVMK, TJVMV, TJVMVR}"/>
        /// </summary>
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
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.7.1/org/apache/kafka/streams/kstream/KeyValueMapper.html#apply-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <remarks>If <see cref="OnApply"/> has a value it takes precedence over corresponding class method</remarks>
        public new System.Func<K, V, VR> OnApply { get; set; } = null;
        /// <inheritdoc/>
        public override TJVMVR Apply(TJVMK arg0, TJVMV arg1)
        {
            _kSerializer ??= Factory?.BuildKeySerDes<K, TJVMK>();
            _vSerializer ??= Factory?.BuildValueSerDes<V, TJVMV>();
            _vrSerializer ??= Factory?.BuildValueSerDes<VR, TJVMVR>();
            var methodToExecute = (OnApply != null) ? OnApply : Apply;
            var res = methodToExecute(_kSerializer.Deserialize(null, arg0), _vSerializer.Deserialize(null, arg1));
            return _vrSerializer.Serialize(null, res);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.7.1/org/apache/kafka/streams/kstream/KeyValueMapper.html#apply-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="K"/></param>
        /// <param name="arg1"><typeparamref name="V"/></param>
        /// <returns><typeparamref name="VR"/></returns>
        public virtual VR Apply(K arg0, V arg1)
        {
            return default;
        }
    }

    /// <summary>
    /// KNet extension of <see cref="KeyValueMapper{K, V, VR, TJVMK, TJVMV, TJVMVR}"/>
    /// </summary>
    /// <typeparam name="K">key value type</typeparam>
    /// <typeparam name="V">first value type</typeparam>
    /// <typeparam name="VR">joined value type</typeparam>
    public class KeyValueMapper<K, V, VR> : KeyValueMapper<K, V, VR, byte[], byte[], byte[]>
    {

    }

    /// <summary>
    /// KNet extension of <see cref="KeyValueMapper{K, V, VR, TJVMK, TJVMV, TJVMVR}"/>
    /// </summary>
    /// <typeparam name="K">key value type</typeparam>
    /// <typeparam name="V">first value type</typeparam>
    /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
    /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
    public class KeyValueMapperForString<K, V, TJVMK, TJVMV> : KeyValueMapper<K, V, string, TJVMK, TJVMV, Java.Lang.String>
    {
        ISerDes<K, TJVMK> _kSerializer = null;
        ISerDes<V, TJVMV> _vSerializer = null;
        /// <inheritdoc/>
        public override Java.Lang.String Apply(TJVMK arg0, TJVMV arg1)
        {
            _kSerializer ??= Factory?.BuildKeySerDes<K, TJVMK>();
            _vSerializer ??= Factory?.BuildValueSerDes<V, TJVMV>();
            var methodToExecute = (OnApply != null) ? OnApply : Apply;
            var res = methodToExecute(_kSerializer.Deserialize(null, arg0), _vSerializer.Deserialize(null, arg1));
            return res;
        }
    }

    /// <summary>
    /// KNet extension of <see cref="KeyValueMapper{K, V, VR, TJVMK, TJVMV, TJVMVR}"/>
    /// </summary>
    /// <typeparam name="K">key value type</typeparam>
    /// <typeparam name="V">first value type</typeparam>
    public class KeyValueMapperForString<K, V> : KeyValueMapperForString<K, V, byte[], byte[]>
    {
    }

    /// <summary>
    /// KNet extension of <see cref="KeyValueMapper{K, V, VR, TJVMK, TJVMV, TJVMVR}"/>
    /// </summary>
    /// <typeparam name="K">key value type</typeparam>
    /// <typeparam name="V">first value type</typeparam>
    /// <typeparam name="KR">first value type</typeparam>
    /// <typeparam name="VR">joined value type</typeparam>
    /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
    /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
    /// <typeparam name="TJVMKR">The JVM type of <typeparamref name="KR"/></typeparam>
    /// <typeparam name="TJVMVR">The JVM type of <typeparamref name="VR"/></typeparam>
    public class KeyValueKeyValueMapper<K, V, KR, VR, TJVMK, TJVMV, TJVMKR, TJVMVR> : KeyValueMapper<K, V, VR, TJVMK, TJVMV, Org.Apache.Kafka.Streams.KeyValue<TJVMKR, TJVMVR>>
    {
        ISerDes<K, TJVMK> _kSerializer = null;
        ISerDes<V, TJVMV> _vSerializer = null;
        ISerDes<KR, TJVMKR> _krSerializer = null;
        ISerDes<VR, TJVMVR> _vrSerializer = null;
        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.7.1/org/apache/kafka/streams/kstream/KeyValueMapper.html#apply-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <remarks>If <see cref="OnApply"/> has a value it takes precedence over corresponding class method</remarks>
        public new System.Func<K, V, (KR, VR)> OnApply { get; set; } = null;
        /// <inheritdoc/>
        public override Org.Apache.Kafka.Streams.KeyValue<TJVMKR, TJVMVR> Apply(TJVMK arg0, TJVMV arg1)
        {
            _kSerializer ??= Factory?.BuildKeySerDes<K, TJVMK>();
            _vSerializer ??= Factory?.BuildValueSerDes<V, TJVMV>();
            _krSerializer ??= Factory?.BuildValueSerDes<KR, TJVMKR>();
            _vrSerializer ??= Factory?.BuildValueSerDes<VR, TJVMVR>();

            var methodToExecute = (OnApply != null) ? OnApply : Apply;
            var res = methodToExecute(_kSerializer.Deserialize(null, arg0), _vSerializer.Deserialize(null, arg1));
            return new Org.Apache.Kafka.Streams.KeyValue<TJVMKR, TJVMVR>(_krSerializer.Serialize(null, res.Item1), _vrSerializer.Serialize(null, res.Item2)); ;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.7.1/org/apache/kafka/streams/kstream/KeyValueMapper.html#apply-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="K"/></param>
        /// <param name="arg1"><typeparamref name="V"/></param>
        /// <returns><typeparamref name="VR"/></returns>
        public new virtual (KR, VR) Apply(K arg0, V arg1)
        {
            return default;
        }
    }

    /// <summary>
    /// KNet extension of <see cref="KeyValueKeyValueMapper{K, V, KR, VR, TJVMK, TJVMV, TJVMKR, TJVMVR}"/>
    /// </summary>
    /// <typeparam name="K">key value type</typeparam>
    /// <typeparam name="V">first value type</typeparam>
    /// <typeparam name="KR">first value type</typeparam>
    /// <typeparam name="VR">joined value type</typeparam>
    public class KeyValueKeyValueMapper<K, V, KR, VR> : KeyValueKeyValueMapper<K, V, KR, VR, byte[], byte[], byte[], byte[]>
    {

    }

    /// <summary>
    /// KNet extension of <see cref="KeyValueMapper{K, V, VR, TJVMK, TJVMV, TJVMVR}"/>
    /// </summary>
    /// <typeparam name="K">key value type</typeparam>
    /// <typeparam name="V">first value type</typeparam>
    /// <typeparam name="KR">first value type</typeparam>
    /// <typeparam name="VR">joined value type</typeparam>
    /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
    /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
    /// <typeparam name="TJVMKR">The JVM type of <typeparamref name="KR"/></typeparam>
    /// <typeparam name="TJVMVR">The JVM type of <typeparamref name="VR"/></typeparam>
    public class EnumerableKeyValueMapper<K, V, KR, VR, TJVMK, TJVMV, TJVMKR, TJVMVR> : KeyValueMapper<K, V, VR, TJVMK, TJVMV, Java.Lang.Iterable<Org.Apache.Kafka.Streams.KeyValue<TJVMKR, TJVMVR>>>
    {
        ISerDes<K, TJVMK> _kSerializer = null;
        ISerDes<V, TJVMV> _vSerializer = null;
        ISerDes<KR, TJVMKR> _krSerializer = null;
        ISerDes<VR, TJVMVR> _vrSerializer = null;
        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.7.1/org/apache/kafka/streams/kstream/KeyValueMapper.html#apply-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <remarks>If <see cref="OnApply"/> has a value it takes precedence over corresponding class method</remarks>
        public new System.Func<K, V, IEnumerable<(KR, VR)>> OnApply { get; set; } = null;
        /// <inheritdoc/>
        public override Java.Lang.Iterable<Org.Apache.Kafka.Streams.KeyValue<TJVMKR, TJVMVR>> Apply(TJVMK arg0, TJVMV arg1)
        {
            _kSerializer ??= Factory?.BuildKeySerDes<K, TJVMK>();
            _vSerializer ??= Factory?.BuildValueSerDes<V, TJVMV>();
            _krSerializer ??= Factory?.BuildValueSerDes<KR, TJVMKR>();
            _vrSerializer ??= Factory?.BuildValueSerDes<VR, TJVMVR>();

            var methodToExecute = (OnApply != null) ? OnApply : Apply;
            var res = methodToExecute(_kSerializer.Deserialize(null, arg0), _vSerializer.Deserialize(null, arg1));
            var result = new ArrayList<Org.Apache.Kafka.Streams.KeyValue<TJVMKR, TJVMVR>>();
            foreach (var item in res)
            {
                var data = new Org.Apache.Kafka.Streams.KeyValue<TJVMKR, TJVMVR>(_krSerializer.Serialize(null, item.Item1), _vrSerializer.Serialize(null, item.Item2));
                result.Add(data);
            }
            return result;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.7.1/org/apache/kafka/streams/kstream/KeyValueMapper.html#apply-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="K"/></param>
        /// <param name="arg1"><typeparamref name="V"/></param>
        /// <returns><typeparamref name="VR"/></returns>
        public new virtual IEnumerable<(KR, VR)> Apply(K arg0, V arg1)
        {
            return default;
        }
    }

    /// <summary>
    /// KNet extension of <see cref="EnumerableKeyValueMapper{K, V, KR, VR, TJVMK, TJVMV, TJVMKR, TJVMVR}"/>
    /// </summary>
    /// <typeparam name="K">key value type</typeparam>
    /// <typeparam name="V">first value type</typeparam>
    /// <typeparam name="KR">first value type</typeparam>
    /// <typeparam name="VR">joined value type</typeparam>
    public class EnumerableKeyValueMapper<K, V, KR, VR> : EnumerableKeyValueMapper<K, V, KR, VR, byte[], byte[], byte[], byte[]>
    {
    }
}
