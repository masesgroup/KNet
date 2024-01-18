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
    /// KNet implementation of <see cref="Org.Apache.Kafka.Streams.Kstream.Predicate{K, V}"/>
    /// </summary>
    /// <typeparam name="TKey">The key type</typeparam>
    /// <typeparam name="TValue">The value type</typeparam>
    public class KNetPredicate<TKey, TValue> : Org.Apache.Kafka.Streams.Kstream.Predicate<byte[], byte[]>, IGenericSerDesFactoryApplier
    {
        IKNetSerDes<TKey> _keySerializer = null;
        IKNetSerDes<TValue> _valueSerializer = null;
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }
        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Predicate.html#test-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <remarks>If <see cref="OnTest"/> has a value it takes precedence over corresponding class method</remarks>
        public new System.Func<TKey, TValue, bool> OnTest { get; set; } = null;

        /// <inheritdoc/>
        public sealed override bool Test(byte[] arg0, byte[] arg1)
        {
            _keySerializer ??= _factory.BuildKeySerDes<TKey>();
            _valueSerializer ??= _factory.BuildValueSerDes<TValue>();

            var methodToExecute = (OnTest != null) ? OnTest : Test;
            return methodToExecute(_keySerializer.Deserialize(null, arg0), _valueSerializer.Deserialize(null, arg1));
        }
        /// <summary>
        /// KNet override of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Predicate.html#test-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0">The key of the record</param>
        /// <param name="arg1">The value of the record</param>
        /// <returns><see cref="bool"/></returns>
        public virtual bool Test(TKey arg0, TValue arg1)
        {
            return default;
        }
    }
}
