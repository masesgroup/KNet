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
using System.Collections.Generic;

namespace MASES.KNet.Streams.Kstream
{
    /// <summary>
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.Kstream.KeyValueMapper{K, V, VR}"/>
    /// </summary>
    /// <typeparam name="K">key value type</typeparam>
    /// <typeparam name="V">first value type</typeparam>
    /// <typeparam name="VR">joined value type</typeparam>
    /// <typeparam name="TJVMK">JVM key value type</typeparam>
    /// <typeparam name="TJVMV">JVM first value type</typeparam>
    /// <typeparam name="TJVMVR">The return JVM type to be managed</typeparam>
    public abstract class KNetKeyValueMapper<K, V, VR, TJVMK, TJVMV, TJVMVR> : Org.Apache.Kafka.Streams.Kstream.KeyValueMapper<TJVMK, TJVMV, TJVMVR>, IGenericSerDesFactoryApplier
    {
        IKNetSerDes<K> _kSerializer = null;
        IKNetSerDes<V> _vSerializer = null;
        /// <summary>
        /// <see cref="IGenericSerDesFactory"/> can be used from any class inherited from <see cref="KNetKeyValueMapper{K, V, VR, TJVMK, TJVMV, TJVMVR}"/>
        /// </summary>
        protected IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }
        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KeyValueMapper.html#apply-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <remarks>If <see cref="OnApply"/> has a value it takes precedence over corresponding class method</remarks>
        public new System.Func<K, V, VR> OnApply { get; set; } = null;
        /// <inheritdoc/>
        public override abstract TJVMVR Apply(TJVMK arg0, TJVMV arg1);
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KeyValueMapper.html#apply-java.lang.Object-java.lang.Object-"/>
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
    /// KNet extension of <see cref="KNetKeyValueMapper{K, V, VR, TJVMK, TJVMV, TJVMVR}"/>
    /// </summary>
    /// <typeparam name="K">key value type</typeparam>
    /// <typeparam name="V">first value type</typeparam>
    /// <typeparam name="VR">joined value type</typeparam>
    public class KNetKeyValueMapper<K, V, VR> : KNetKeyValueMapper<K, V, VR, byte[], byte[], byte[]>
    {
        IKNetSerDes<K> _kSerializer = null;
        IKNetSerDes<V> _vSerializer = null;
        IKNetSerDes<VR> _vrSerializer = null;
        /// <inheritdoc/>
        public override byte[] Apply(byte[] arg0, byte[] arg1)
        {
            _kSerializer ??= _factory.BuildKeySerDes<K>();
            _vSerializer ??= _factory.BuildValueSerDes<V>();
            _vrSerializer ??= _factory.BuildValueSerDes<VR>();
            var methodToExecute = (OnApply != null) ? OnApply : Apply;
            var res = methodToExecute(_kSerializer.Deserialize(null, arg0), _vSerializer.Deserialize(null, arg1));
            return _vrSerializer.Serialize(null, res);
        }
    }

    /// <summary>
    /// KNet extension of <see cref="KNetKeyValueMapper{K, V, VR, TJVMK, TJVMV, TJVMVR}"/>
    /// </summary>
    /// <typeparam name="K">key value type</typeparam>
    /// <typeparam name="V">first value type</typeparam>
    public class KNetKeyValueMapperForString<K, V> : KNetKeyValueMapper<K, V, string, byte[], byte[], Java.Lang.String>
    {
        IKNetSerDes<K> _kSerializer = null;
        IKNetSerDes<V> _vSerializer = null;
        /// <inheritdoc/>
        public override Java.Lang.String Apply(byte[] arg0, byte[] arg1)
        {
            _kSerializer ??= _factory.BuildKeySerDes<K>();
            _vSerializer ??= _factory.BuildValueSerDes<V>();
            var methodToExecute = (OnApply != null) ? OnApply : Apply;
            var res = methodToExecute(_kSerializer.Deserialize(null, arg0), _vSerializer.Deserialize(null, arg1));
            return res;
        }
    }

    /// <summary>
    /// KNet extension of <see cref="KNetKeyValueMapper{K, V, VR, TJVMK, TJVMV, TJVMVR}"/>
    /// </summary>
    /// <typeparam name="K">key value type</typeparam>
    /// <typeparam name="V">first value type</typeparam>
    /// <typeparam name="KR">first value type</typeparam>
    /// <typeparam name="VR">joined value type</typeparam>
    public abstract class KNetKeyValueKeyValueMapper<K, V, KR, VR, TJVMK, TJVMV, TJVMKR, TJVMVR> : KNetKeyValueMapper<K, V, VR, TJVMK, TJVMV, Org.Apache.Kafka.Streams.KeyValue<TJVMKR, TJVMVR>>
    {
        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KeyValueMapper.html#apply-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <remarks>If <see cref="OnApply"/> has a value it takes precedence over corresponding class method</remarks>
        public new System.Func<K, V, (KR, VR)> OnApply { get; set; } = null;
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KeyValueMapper.html#apply-java.lang.Object-java.lang.Object-"/>
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
    /// KNet extension of <see cref="KNetKeyValueKeyValueMapper{K, V, KR, VR, TJVMK, TJVMV, TJVMKR, TJVMVR}"/>
    /// </summary>
    /// <typeparam name="K">key value type</typeparam>
    /// <typeparam name="V">first value type</typeparam>
    /// <typeparam name="KR">first value type</typeparam>
    /// <typeparam name="VR">joined value type</typeparam>
    public class KNetKeyValueKeyValueMapper<K, V, KR, VR> : KNetKeyValueKeyValueMapper<K, V, KR, VR, byte[], byte[], byte[], byte[]>
    {
        IKNetSerDes<K> _kSerializer = null;
        IKNetSerDes<V> _vSerializer = null;
        IKNetSerDes<KR> _krSerializer = null;
        IKNetSerDes<VR> _vrSerializer = null;
        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KeyValueMapper.html#apply-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <remarks>If <see cref="OnApply"/> has a value it takes precedence over corresponding class method</remarks>
        public new System.Func<K, V, (KR, VR)> OnApply { get; set; } = null;
        /// <inheritdoc/>
        public sealed override Org.Apache.Kafka.Streams.KeyValue<byte[], byte[]> Apply(byte[] arg0, byte[] arg1)
        {
            _kSerializer ??= _factory.BuildKeySerDes<K>();
            _vSerializer ??= _factory.BuildValueSerDes<V>();
            _krSerializer ??= _factory.BuildValueSerDes<KR>();
            _vrSerializer ??= _factory.BuildValueSerDes<VR>();

            var methodToExecute = (OnApply != null) ? OnApply : Apply;
            var res = methodToExecute(_kSerializer.Deserialize(null, arg0), _vSerializer.Deserialize(null, arg1));
            return new Org.Apache.Kafka.Streams.KeyValue<byte[], byte[]>(_krSerializer.Serialize(null, res.Item1), _vrSerializer.Serialize(null, res.Item2)); ;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KeyValueMapper.html#apply-java.lang.Object-java.lang.Object-"/>
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
    /// KNet extension of <see cref="KNetKeyValueMapper{K, V, VR, TJVMK, TJVMV, TJVMVR}"/>
    /// </summary>
    /// <typeparam name="K">key value type</typeparam>
    /// <typeparam name="V">first value type</typeparam>
    /// <typeparam name="KR">first value type</typeparam>
    /// <typeparam name="VR">joined value type</typeparam>
    public abstract class KNetEnumerableKeyValueMapper<K, V, KR, VR, TJVMK, TJVMV, TJVMKR, TJVMVR> : KNetKeyValueMapper<K, V, VR, TJVMK, TJVMV, Java.Lang.Iterable<Org.Apache.Kafka.Streams.KeyValue<TJVMKR, TJVMVR>>>
    {
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KeyValueMapper.html#apply-java.lang.Object-java.lang.Object-"/>
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
    /// KNet extension of <see cref="KNetEnumerableKeyValueMapper{K, V, KR, VR, TJVMK, TJVMV, TJVMKR, TJVMVR}"/>
    /// </summary>
    /// <typeparam name="K">key value type</typeparam>
    /// <typeparam name="V">first value type</typeparam>
    /// <typeparam name="KR">first value type</typeparam>
    /// <typeparam name="VR">joined value type</typeparam>
    public class KNetEnumerableKeyValueMapper<K, V, KR, VR> : KNetEnumerableKeyValueMapper<K, V, KR, VR, byte[], byte[], byte[], byte[]>
    {
        IKNetSerDes<K> _kSerializer = null;
        IKNetSerDes<V> _vSerializer = null;
        IKNetSerDes<KR> _krSerializer = null;
        IKNetSerDes<VR> _vrSerializer = null;
        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KeyValueMapper.html#apply-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <remarks>If <see cref="OnApply"/> has a value it takes precedence over corresponding class method</remarks>
        public new System.Func<K, V, IEnumerable<(KR, VR)>> OnApply { get; set; } = null;
        /// <inheritdoc/>
        public sealed override Java.Lang.Iterable<Org.Apache.Kafka.Streams.KeyValue<byte[], byte[]>> Apply(byte[] arg0, byte[] arg1)
        {
            _kSerializer ??= _factory.BuildKeySerDes<K>();
            _vSerializer ??= _factory.BuildValueSerDes<V>();
            _krSerializer ??= _factory.BuildValueSerDes<KR>();
            _vrSerializer ??= _factory.BuildValueSerDes<VR>();

            var methodToExecute = (OnApply != null) ? OnApply : Apply;
            var res = methodToExecute(_kSerializer.Deserialize(null, arg0), _vSerializer.Deserialize(null, arg1));
            var result = new ArrayList<Org.Apache.Kafka.Streams.KeyValue<byte[], byte[]>>();
            foreach (var item in res)
            {
                var data = new Org.Apache.Kafka.Streams.KeyValue<byte[], byte[]>(_krSerializer.Serialize(null, item.Item1), _vrSerializer.Serialize(null, item.Item2));
                result.Add(data);
            }
            return result;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KeyValueMapper.html#apply-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="K"/></param>
        /// <param name="arg1"><typeparamref name="V"/></param>
        /// <returns><typeparamref name="VR"/></returns>
        public new virtual IEnumerable<(KR, VR)> Apply(K arg0, V arg1)
        {
            return default;
        }
    }
}
