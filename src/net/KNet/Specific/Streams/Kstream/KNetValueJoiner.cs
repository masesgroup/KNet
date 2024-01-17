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
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.Kstream.ValueJoiner{V1, V2, VR}"/>
    /// </summary>
    /// <typeparam name="V1">first value type</typeparam>
    /// <typeparam name="V2">second value type</typeparam>
    /// <typeparam name="VR">joined value type</typeparam>
    public class KNetValueJoiner<V1, V2, VR> : Org.Apache.Kafka.Streams.Kstream.ValueJoiner<byte[], byte[], byte[]>, IGenericSerDesFactoryApplier
    {
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/ValueJoinerWithKey.html#apply-java.lang.Object-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <remarks>If <see cref="OnApply"/> has a value it takes precedence over corresponding class method</remarks>
        public new System.Func<V1, V2, VR> OnApply { get; set; } = null;
        /// <inheritdoc/>
        public sealed override byte[] Apply(byte[] arg0, byte[] arg1)
        {
            IKNetSerDes<V1> v1Serializer = _factory.BuildValueSerDes<V1>();
            IKNetSerDes<V2> v2Serializer = _factory.BuildValueSerDes<V2>();
            IKNetSerDes<VR> vrSerializer = _factory.BuildValueSerDes<VR>();

            var methodToExecute = (OnApply != null) ? OnApply : Apply;
            var res = methodToExecute(v1Serializer.Deserialize(null, arg0), v2Serializer.Deserialize(null, arg1));
            return vrSerializer.Serialize(null, res);
        }

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/ValueJoinerWithKey.html#apply-java.lang.Object-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="V1"/></param>
        /// <param name="arg1"><typeparamref name="V2"/></param>
        /// <returns><typeparamref name="VR"/></returns>
        public virtual VR Apply(V1 arg0, V2 arg1)
        {
            return default;
        }

    }
}
