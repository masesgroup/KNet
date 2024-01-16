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

namespace MASES.KNet.Streams.State
{
    /// <summary>
    /// Supporting interface for <see cref="KNetManagedStore{TStore}"/>
    /// </summary>
    /// <typeparam name="TStore">The Apache Kafka store type</typeparam>
    public interface IKNetManagedStore<TStore> : IGenericSerDesFactoryApplier
    {
        /// <summary>
        /// Sets store data
        /// </summary>
        /// <param name="factory"><see cref="IGenericSerDesFactory"/></param>
        /// <param name="store"><typeparamref name="TStore"/></param>
        void SetData(IGenericSerDesFactory factory, TStore store);
    }

    /// <summary>
    /// Base class for stores managed from KNet
    /// </summary>
    /// <typeparam name="TStore">The Apache Kafka store type</typeparam>
    public class KNetManagedStore<TStore> : IKNetManagedStore<TStore>, IGenericSerDesFactoryApplier
    {
        internal TStore _store;
        internal IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

        void IKNetManagedStore<TStore>.SetData(IGenericSerDesFactory factory, TStore store)
        {
            _factory = factory;
            _store = store;
        }
    }
}
