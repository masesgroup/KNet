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

using MASES.KNet.Serialization;

namespace MASES.KNet.Streams.Kstream
{
    /// <summary>
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.Kstream.Printed{K, V}"/>
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    public class KNetPrinted<K, V> : IGenericSerDesFactoryApplier
    {
        readonly Org.Apache.Kafka.Streams.Kstream.Printed<byte[], byte[]> _inner;
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

        KNetPrinted(Org.Apache.Kafka.Streams.Kstream.Printed<byte[], byte[]> inner)
        {
            _inner = inner;
        }

        /// <summary>
        /// Converter from <see cref="KNetPrinted{K, V}"/> to <see cref="Org.Apache.Kafka.Streams.Kstream.Printed{K, V}"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.Kstream.Printed<byte[], byte[]>(KNetPrinted<K, V> t) => t._inner;

#warning till now it is only an empty class shall be completed with the method of inner class
    }
}
