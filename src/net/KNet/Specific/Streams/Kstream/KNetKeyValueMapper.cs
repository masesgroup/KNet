/*
*  Copyright 2023 MASES s.r.l.
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
using System.Collections;
using System.Collections.Generic;

namespace MASES.KNet.Streams.Kstream
{
    /// <summary>
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.Kstream.KeyValueMapper{K, V, VR}"/>
    /// </summary>
    /// <typeparam name="K">key value type</typeparam>
    /// <typeparam name="V">first value type</typeparam>
    /// <typeparam name="VR">joined value type</typeparam>
    public class KNetKeyValueMapper<K, V, VR> : Org.Apache.Kafka.Streams.Kstream.KeyValueMapper<byte[], byte[], byte[]>, IGenericSerDesFactoryApplier
    {
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KeyValueMapper.html#apply-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <remarks>If <see cref="OnApply"/> has a value it takes precedence over corresponding class method</remarks>
        public new System.Func<K, V, VR> OnApply { get; set; } = null;
        /// <inheritdoc/>
        public sealed override byte[] Apply(byte[] arg0, byte[] arg1)
        {
            IKNetSerDes<K> kSerializer = _factory.BuildKeySerDes<K>();
            IKNetSerDes<V> vSerializer = _factory.BuildValueSerDes<V>();
            IKNetSerDes<VR> vrSerializer = _factory.BuildValueSerDes<VR>();

            var methodToExecute = (OnApply != null) ? OnApply : Apply;
            var res = methodToExecute(kSerializer.Deserialize(null, arg0), vSerializer.Deserialize(null, arg1));
            return vrSerializer.Serialize(null, res);
        }
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
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.Kstream.KeyValueMapper{K, V, VR}"/>
    /// </summary>
    /// <typeparam name="K">key value type</typeparam>
    /// <typeparam name="V">first value type</typeparam>
    /// <typeparam name="KR">first value type</typeparam>
    /// <typeparam name="VR">joined value type</typeparam>
    public class KNetKeyValueKeyValueMapper<K, V, KR, VR> : Org.Apache.Kafka.Streams.Kstream.KeyValueMapper<byte[], byte[], Org.Apache.Kafka.Streams.KeyValue<byte[], byte[]>>, IGenericSerDesFactoryApplier
    {
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KeyValueMapper.html#apply-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <remarks>If <see cref="OnApply"/> has a value it takes precedence over corresponding class method</remarks>
        public new System.Func<K, V, (KR, VR)> OnApply { get; set; } = null;
        /// <inheritdoc/>
        public sealed override Org.Apache.Kafka.Streams.KeyValue<byte[], byte[]> Apply(byte[] arg0, byte[] arg1)
        {
            IKNetSerDes<K> kSerializer = _factory.BuildKeySerDes<K>();
            IKNetSerDes<V> vSerializer = _factory.BuildValueSerDes<V>();
            IKNetSerDes<KR> krSerializer = _factory.BuildValueSerDes<KR>();
            IKNetSerDes<VR> vrSerializer = _factory.BuildValueSerDes<VR>();

            var methodToExecute = (OnApply != null) ? OnApply : Apply;
            var res = methodToExecute(kSerializer.Deserialize(null, arg0), vSerializer.Deserialize(null, arg1));
            return new Org.Apache.Kafka.Streams.KeyValue<byte[], byte[]>(krSerializer.Serialize(null, res.Item1), vrSerializer.Serialize(null, res.Item2)); ;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KeyValueMapper.html#apply-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="K"/></param>
        /// <param name="arg1"><typeparamref name="V"/></param>
        /// <returns><typeparamref name="VR"/></returns>
        public virtual (KR, VR) Apply(K arg0, V arg1)
        {
            return default;
        }
    }

    /// <summary>
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.Kstream.KeyValueMapper{K, V, VR}"/>
    /// </summary>
    /// <typeparam name="K">key value type</typeparam>
    /// <typeparam name="V">first value type</typeparam>
    /// <typeparam name="KR">first value type</typeparam>
    /// <typeparam name="VR">joined value type</typeparam>
    public class KNetEnumerableKeyValueMapper<K, V, KR, VR> : Org.Apache.Kafka.Streams.Kstream.KeyValueMapper<byte[], byte[], Java.Lang.Iterable<Org.Apache.Kafka.Streams.KeyValue<byte[], byte[]>>>, IGenericSerDesFactoryApplier
    {
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KeyValueMapper.html#apply-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <remarks>If <see cref="OnApply"/> has a value it takes precedence over corresponding class method</remarks>
        public new System.Func<K, V, IEnumerable<(KR, VR)>> OnApply { get; set; } = null;
        /// <inheritdoc/>
        public sealed override Java.Lang.Iterable<Org.Apache.Kafka.Streams.KeyValue<byte[], byte[]>> Apply(byte[] arg0, byte[] arg1)
        {
            IKNetSerDes<K> kSerializer = _factory.BuildKeySerDes<K>();
            IKNetSerDes<V> vSerializer = _factory.BuildValueSerDes<V>();
            IKNetSerDes<KR> krSerializer = _factory.BuildValueSerDes<KR>();
            IKNetSerDes<VR> vrSerializer = _factory.BuildValueSerDes<VR>();

            var methodToExecute = (OnApply != null) ? OnApply : Apply;
            var res = methodToExecute(kSerializer.Deserialize(null, arg0), vSerializer.Deserialize(null, arg1));
            var result = new ArrayList<Org.Apache.Kafka.Streams.KeyValue<byte[], byte[]>>();
            foreach (var item in res)
            { 
                var data = new Org.Apache.Kafka.Streams.KeyValue<byte[], byte[]>(krSerializer.Serialize(null, item.Item1), vrSerializer.Serialize(null, item.Item2));
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
        public virtual IEnumerable<(KR, VR)> Apply(K arg0, V arg1)
        {
            return default;
        }
    }
}
