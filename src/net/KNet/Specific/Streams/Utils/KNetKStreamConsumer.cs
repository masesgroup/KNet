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
using MASES.KNet.Streams.Kstream;
using System;

namespace MASES.KNet.Streams.Utils
{
    /// <summary>
    /// KNet implementation of <see cref="Java.Util.Function.Consumer{TObject}"/> over <see cref="Org.Apache.Kafka.Streams.Kstream.KStream{TJVMK, TJVMV}"/>
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="V">The value type</typeparam>
    /// <typeparam name="TJVMK">The JVM key type</typeparam>
    /// <typeparam name="TJVMV">The JVM value type</typeparam>
    public class KStreamConsumer<K, V, TJVMK, TJVMV> : Java.Util.Function.Consumer<Org.Apache.Kafka.Streams.Kstream.KStream<TJVMK, TJVMV>>, IGenericSerDesFactoryApplier
    {
        ISerDes<V> _valueSerializer = null;
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

        /// <summary>
        /// The <see cref="Func{V, KO}"/> to be executed
        /// </summary>
        public new virtual Action<KStream<K, V, TJVMK, TJVMV>> OnAccept { get; set; }

        /// <inheritdoc/>
        public override void Accept(Org.Apache.Kafka.Streams.Kstream.KStream<TJVMK, TJVMV> arg0)
        {
            var methodToExecute = (OnAccept != null) ? OnAccept : Accept;
            methodToExecute(new KStream<K, V, TJVMK, TJVMV>(_factory, arg0));
        }

        /// <summary>
        /// Executes the Function action in the CLR
        /// </summary>
        /// <param name="obj">The <see cref="KStream{K, V, TJVMK, TJVMV}"/> object</param>
        public virtual void Accept(KStream<K, V, TJVMK, TJVMV> obj) { }
    }

    /// <summary>
    /// KNet implementation of <see cref="KStreamConsumer{K, V, TJVMK, TJVMV}"/>
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="V">The value type</typeparam>
    public class KStreamConsumer<K, V> : KStreamConsumer<K, V, byte[], byte[]>
    {
    }
}
