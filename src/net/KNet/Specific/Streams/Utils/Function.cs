/*
*  Copyright (c) 2021-2025 MASES s.r.l.
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
using System;

namespace MASES.KNet.Streams.Utils
{
    /// <summary>
    /// KNet implementation of <see cref="Java.Util.Function.Function{TJVMV, TJVMKO}"/>
    /// </summary>
    /// <typeparam name="V">The type of the input to the function</typeparam>
    /// <typeparam name="KO">The type of the result of the function</typeparam>
    /// <typeparam name="TJVMV">The JVM type of the input to the function</typeparam>
    /// <typeparam name="TJVMKO">The JVM type of the result of the function</typeparam>
    public class Function<V, KO, TJVMV, TJVMKO> : Java.Util.Function.Function<TJVMV, TJVMKO>, IGenericSerDesFactoryApplier
    {
        ISerDes<KO, TJVMKO> _keySerializer = null;
        ISerDes<V, TJVMV> _valueSerializer = null;

        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }
        /// <summary>
        /// The <see cref="Func{V, KO}"/> to be executed
        /// </summary>
        public new virtual Func<V, KO> OnApply { get; set; }
        /// <inheritdoc/>
        public override TJVMKO Apply(TJVMV arg0)
        {
            IGenericSerDesFactory factory = null;
            if (this is IGenericSerDesFactoryApplier applier && (factory = applier.Factory) == null)
            {
                throw new InvalidOperationException("The serialization factory instance was not set.");
            }
            _keySerializer ??= factory?.BuildKeySerDes<KO, TJVMKO>();
            _valueSerializer ??= factory?.BuildValueSerDes<V, TJVMV>();
            var methodToExecute = (OnApply != null) ? OnApply : Apply;
            var res = methodToExecute(_valueSerializer.Deserialize(null, arg0));

            return _keySerializer.Serialize(null, res);
        }
        /// <summary>
        /// Executes the Function action in the CLR
        /// </summary>
        /// <param name="obj">The <typeparamref name="V"/> object</param>
        /// <returns>The apply <typeparamref name="KO"/></returns>
        public virtual KO Apply(V obj) { return default; }
    }

    /// <summary>
    /// KNet implementation of <see cref="Function{V, KO, TJVMV, TJVMKO}"/>
    /// </summary>
    /// <typeparam name="V">The key type</typeparam>
    /// <typeparam name="KO">The value type</typeparam>
    public class Function<V, KO> : Function<V, KO, byte[], byte[]>
    {
    }
}
