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
using MASES.KNet.Streams.Kstream;
using System;

namespace MASES.KNet.Streams.Utils
{
    /// <summary>
    /// KNet implementation of <see cref="Java.Util.Function.Function{TObject, TReturn}"/> over <see cref="Org.Apache.Kafka.Streams.Kstream.KStream{TJVMK, TJVMV}"/>
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="V">The value type</typeparam>
    /// <typeparam name="TJVMK">The JVM key type</typeparam>
    /// <typeparam name="TJVMV">The JVM value type</typeparam>
    public class KStreamFunction<K, V, TJVMK, TJVMV> : Java.Util.Function.Function<Org.Apache.Kafka.Streams.Kstream.KStream<TJVMK, TJVMV>, Org.Apache.Kafka.Streams.Kstream.KStream<TJVMK, TJVMV>>, IGenericSerDesFactoryApplier
    {
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

        /// <summary>
        /// The <see cref="Func{T, TResult}"/> to be executed over <see cref="KStream{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        public new virtual Func<KStream<K, V, TJVMK, TJVMV>, KStream<K, V, TJVMK, TJVMV>> OnApply { get; set; }

        /// <inheritdoc/>
        public override Org.Apache.Kafka.Streams.Kstream.KStream<TJVMK, TJVMV> Apply(Org.Apache.Kafka.Streams.Kstream.KStream<TJVMK, TJVMV> arg0)
        {
            var methodToExecute = (OnApply != null) ? OnApply : Apply;
            var res = methodToExecute(new KStream<K, V, TJVMK, TJVMV>(_factory, arg0));
            return res;
        }

        /// <summary>
        /// Executes the Function action in the CLR
        /// </summary>
        /// <param name="obj">The <see cref="KStream{K, V, TJVMK, TJVMV}"/> object</param>
        /// <returns>The <see cref="KStream{K, V, TJVMK, TJVMV}"/></returns>
        public virtual KStream<K, V, TJVMK, TJVMV> Apply(KStream<K, V, TJVMK, TJVMV> obj) { return default; }
    }

    /// <summary>
    /// KNet implementation of <see cref="KStreamFunction{K, V, TJVMK, TJVMV}"/>
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="V">The value type</typeparam>
    public class KStreamFunction<K, V> : KStreamFunction<K, V, byte[], byte[]>
    {

    }
}
