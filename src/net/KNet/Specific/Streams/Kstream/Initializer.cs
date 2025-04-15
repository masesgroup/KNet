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

using MASES.KNet.Serialization;
using System;

namespace MASES.KNet.Streams.Kstream
{
    /// <summary>
    /// KNet implementation of <see cref="Org.Apache.Kafka.Streams.Kstream.Initializer{TJVMVA}"/>
    /// </summary>
    /// <typeparam name="VA">The key type</typeparam>
    /// <typeparam name="TJVMVA">The JVM type of <typeparamref name="VA"/></typeparam>
    public class Initializer<VA, TJVMVA> : Org.Apache.Kafka.Streams.Kstream.Initializer<TJVMVA>, IGenericSerDesFactoryApplier
    {
        ISerDes<VA, TJVMVA> _valueSerializer = null;

        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }
        /// <summary>
        /// Returns the current <see cref="IGenericSerDesFactory"/>
        /// </summary>
        protected IGenericSerDesFactory Factory
        {
            get
            {
                IGenericSerDesFactory factory = null;
                if (this is IGenericSerDesFactoryApplier applier && (factory = applier.Factory) == null)
                {
                    throw new InvalidOperationException("The serialization factory instance was not set.");
                }
                return factory;
            }
        }
        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/Initializer.html#apply()"/>
        /// </summary>
        /// <remarks>If <see cref="OnApply2"/> has a value it takes precedence over corresponding class method</remarks>
        public System.Func<VA> OnApply2 { get; set; } = null;
        /// <inheritdoc/>
        public sealed override TJVMVA Apply()
        {
            _valueSerializer ??= Factory?.BuildValueSerDes<VA, TJVMVA>();

            var methodToExecute = (OnApply2 != null) ? OnApply2 : Apply2;
            var res = methodToExecute();
            return _valueSerializer.Serialize(null, res);
        }
        /// <inheritdoc cref="Org.Apache.Kafka.Streams.Kstream.Initializer{VAgg}.Apply"/>
        public virtual VA Apply2()
        {
            return default;
        }
    }

    /// <summary>
    /// KNet implementation of <see cref="Org.Apache.Kafka.Streams.Kstream.Initializer{VA}"/>
    /// </summary>
    /// <typeparam name="VA">The key type</typeparam>
    public class Initializer<VA> : Initializer<VA, byte[]>
    {

    }
}
