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

using MASES.JCOBridge.C2JBridge;
using MASES.KNet.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace MASES.KNet.Streams.State
{
    class PrefetchableEnumeratorSettings : IEnumerableExtension
    {
        public PrefetchableEnumeratorSettings()
        {
            UsePrefetch = true;
            UseThread = true;
        }
        public bool UsePrefetch { get; set; }
        public bool UseThread { get; set; }
        public IConverterBridge ConverterBridge { get; set; }
    }

    /// <summary>
    /// A common class for all iterators
    /// </summary>
    /// <typeparam name="TIteratorType">The return <see cref="Type"/> of <see cref="IEnumerable{T}"/> and <see cref="IAsyncEnumerable{T}"/></typeparam>
    public abstract class CommonIterator<TIteratorType> : IGenericSerDesFactoryApplier, IEnumerable<TIteratorType>, IAsyncEnumerable<TIteratorType>
    {
        /// <summary>
        /// Initialize a new instance of <see cref="CommonIterator{TIteratorType}"/>
        /// </summary>
        /// <param name="factory">The <see cref="IGenericSerDesFactory"/> associated to this instance</param>
        public CommonIterator(IGenericSerDesFactory factory)
        {
            _factory = factory;
        }
        /// <summary>
        /// The <see cref="IGenericSerDesFactory"/> associated to this instance
        /// </summary>
        protected IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }
        /// <summary>
        /// Used to get or set the type of enumerator to retrieve, default is with prefetch if the platform accept it
        /// </summary>
        public bool UsePrefetch { get; set; } = true;
        /// <inheritdoc/>
        public IEnumerator<TIteratorType> GetEnumerator()
        {
            return GetEnumerator(false) as IEnumerator<TIteratorType>;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
           return GetEnumerator();
        }
        /// <inheritdoc/>
        public IAsyncEnumerator<TIteratorType> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            return GetEnumerator(true, cancellationToken) as IAsyncEnumerator<TIteratorType>;
        }
        /// <summary>
        /// Internally gets the <see cref="IEnumerable{T}"/> or <see cref="IAsyncEnumerable{T}"/>
        /// </summary>
        /// <param name="isAsync">If requesting an <see cref="IAsyncEnumerator{T}"/></param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to be used in <see cref="IAsyncEnumerator{T}"/></param>
        /// <returns>An <see cref="IEnumerable{T}"/> or <see cref="IAsyncEnumerable{T}"/></returns>
        protected abstract object GetEnumerator(bool isAsync, CancellationToken cancellationToken = default);
    }
}
