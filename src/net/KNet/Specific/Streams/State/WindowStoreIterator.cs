﻿/*
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

using MASES.JCOBridge.C2JBridge;
using MASES.KNet.Serialization;

namespace MASES.KNet.Streams.State
{
    /// <summary>
    /// KNet implementation of <see cref="Org.Apache.Kafka.Streams.State.WindowStoreIterator"/> 
    /// </summary>
    /// <typeparam name="TValue">The value type</typeparam>
    public class WindowStoreIterator<TValue> : IGenericSerDesFactoryApplier
    { 
        readonly Org.Apache.Kafka.Streams.State.WindowStoreIterator<byte[]> _iterator;
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

        internal WindowStoreIterator(IGenericSerDesFactory factory, Org.Apache.Kafka.Streams.State.WindowStoreIterator<byte[]> iterator)
        {
            _factory = factory;
            _iterator = iterator;
        }

        /// <summary>
        /// Converter from <see cref="WindowStoreIterator{TValue}"/> to <see cref="KeyValueIterator{Int64, TValue}"/>
        /// </summary>
        public static implicit operator KeyValueIterator<long, TValue>(WindowStoreIterator<TValue> t) => new KeyValueIterator<long, TValue>(t._factory, t._iterator.Cast<Org.Apache.Kafka.Streams.State.KeyValueIterator<Java.Lang.Long, byte[]>>());

        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/KeyValueIterator.html#close--"/>
        /// </summary>
        public void Close()
        {
            _iterator.Close();
        }
    }
}
