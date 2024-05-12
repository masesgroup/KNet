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

using System;

namespace MASES.KNet.Serialization
{
    /// <summary>
    /// Generic interface to access serializers
    /// </summary>
    public interface IGenericSerDesFactory
    {
        /// <summary>
        /// The <see cref="Type"/> used to create an instance of <see cref="ISerDes{T, TJVMT}"/> for keys with <see cref="BuildKeySerDes{TKey, TJVMTKey}"/>
        /// </summary>
        Type KNetKeySerDes { get; }
        /// <summary>
        /// The <see cref="Type"/> used to create an instance of <see cref="ISerDes{T, TJVMT}"/> for values with <see cref="BuildValueSerDes{TValue, TJVMTValue}"/>
        /// </summary>
        Type KNetValueSerDes { get; }
        /// <summary>
        /// Builds an instance of <see cref="ISerDes{TKey, TJVMKey}"/> using the <see cref="Type"/> defined in <see cref="KNetKeySerDes"/>
        /// </summary>
        /// <typeparam name="TKey">The type of the key</typeparam>
        /// <typeparam name="TJVMTKey">The JVM type of the key</typeparam>
        /// <returns>An instance of <see cref="ISerDes{TKey, TJVMKey}"/></returns>
        /// <exception cref="InvalidOperationException">If <see cref="KNetKeySerDes"/> is <see langword="null"/></exception>
        ISerDes<TKey, TJVMTKey> BuildKeySerDes<TKey, TJVMTKey>();
        /// <summary>
        /// Builds an instance of <see cref="ISerDes{TValue, TJVMTValue}"/> using the <see cref="Type"/> defined in <see cref="KNetValueSerDes"/>
        /// </summary>
        /// <typeparam name="TValue">The type of the key</typeparam>
        /// <typeparam name="TJVMTValue">The JVM type of the key</typeparam>
        /// <returns>An instance of <see cref="ISerDes{TValue, TJVMTValue}"/></returns>
        /// <exception cref="InvalidOperationException">If <see cref="KNetValueSerDes"/> is <see langword="null"/></exception>
        ISerDes<TValue, TJVMTValue> BuildValueSerDes<TValue, TJVMTValue>();
        /// <summary>
        /// Clear the current factory
        /// </summary>
        void Clear();
    }
}
