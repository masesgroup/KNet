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

using MASES.JCOBridge.C2JBridge;
using MASES.KNet.Serialization;

namespace MASES.KNet.Streams.State
{
    /// <summary>
    /// KNet implementation of <see cref="Org.Apache.Kafka.Streams.State.WindowStoreIterator{V}"/> 
    /// </summary>
    /// <typeparam name="V">The value type</typeparam>
    /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
    public class WindowStoreIterator<V, TJVMV> : IGenericSerDesFactoryApplier
    { 
        readonly Org.Apache.Kafka.Streams.State.WindowStoreIterator<TJVMV> _iterator;
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

        internal WindowStoreIterator(IGenericSerDesFactory factory, Org.Apache.Kafka.Streams.State.WindowStoreIterator<TJVMV> iterator)
        {
            _factory = factory;
            _iterator = iterator;
        }

        /// <summary>
        /// Converter from <see cref="WindowStoreIterator{V, TJVMV}"/> to <see cref="KeyValueIterator{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        public static implicit operator KeyValueIterator<long, V, Java.Lang.Long, TJVMV>(WindowStoreIterator<V, TJVMV> t) => new KeyValueIterator<long, V, Java.Lang.Long, TJVMV>(t._factory, t._iterator.Cast<Org.Apache.Kafka.Streams.State.KeyValueIterator<Java.Lang.Long, TJVMV>>());

        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/state/KeyValueIterator.html#close()"/>
        /// </summary>
        public void Close()
        {
            _iterator.Close();
        }
    }
}
