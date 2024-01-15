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

using MASES.JCOBridge.C2JBridge;
using MASES.KNet.Serialization;
using Org.Apache.Kafka.Common.Serialization;
using System;

namespace MASES.KNet.Streams.Kstream
{
    /// <summary>
    /// KNet extension of <see cref="KNetMaterialized{K, V, S, TContainer}"/>
    /// </summary>
    /// <typeparam name="K"></typeparam>
    public class KNetCountingMaterialized<K> : KNetMaterialized<K, long, Java.Lang.Long, KNetCountingMaterialized<K>>
    {
        internal KNetCountingMaterialized(Org.Apache.Kafka.Streams.Kstream.Materialized<byte[], Java.Lang.Long, Org.Apache.Kafka.Streams.State.KeyValueStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>> materialized)
            : base(materialized)
        {
        }

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.html#with-org.apache.kafka.common.serialization.Serde-org.apache.kafka.common.serialization.Serde-"/>
        /// </summary>
        /// <param name="arg0"><see cref="IKNetSerDes{K}"/></param>
        /// <returns><see cref="KNetMaterialized{K, V}"/></returns>
        public static KNetCountingMaterialized<K> With(IKNetSerDes<K> arg0)
        {
            var mat = Org.Apache.Kafka.Streams.Kstream.Materialized<byte[], Java.Lang.Long, Org.Apache.Kafka.Streams.State.KeyValueStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>>.With(arg0.KafkaSerde, Serdes.Long());
            return new KNetCountingMaterialized<K>(mat.Cast<Org.Apache.Kafka.Streams.Kstream.Materialized<byte[], Java.Lang.Long, Org.Apache.Kafka.Streams.State.KeyValueStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>>>());
        }

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.html#withValueSerde-org.apache.kafka.common.serialization.Serde-"/>
        /// </summary>
        /// <param name="arg0"><see cref="IKNetSerDes{V}"/></param>
        /// <returns><see cref="KNetMaterialized{K, V}"/></returns>
        public KNetCountingMaterialized<K> WithValueSerde(IKNetSerDes<long> arg0)
        {
            _keyStore?.WithValueSerde(Serdes.Long());
            return this;
        }
    }

    /// <summary>
    /// KNet extension of <see cref="KNetMaterialized{K, V, S, TContainer}"/>
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    public class KNetMaterialized<K, V> : KNetMaterialized<K, V, byte[], KNetMaterialized<K, V>>
    {
        internal KNetMaterialized(Org.Apache.Kafka.Streams.Kstream.Materialized<byte[], byte[], Org.Apache.Kafka.Streams.State.KeyValueStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>> materialized)
            : base(materialized)
        {
        }

        internal KNetMaterialized(Org.Apache.Kafka.Streams.Kstream.Materialized<byte[], byte[], Org.Apache.Kafka.Streams.State.SessionStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>> materialized)
            : base(materialized)
        {
        }

        internal KNetMaterialized(Org.Apache.Kafka.Streams.Kstream.Materialized<byte[], byte[], Org.Apache.Kafka.Streams.State.WindowStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>> materialized)
            : base(materialized)
        {
        }

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.html#with-org.apache.kafka.common.serialization.Serde-org.apache.kafka.common.serialization.Serde-"/>
        /// </summary>
        /// <param name="arg0"><see cref="IKNetSerDes{K}"/></param>
        /// <param name="arg1"><see cref="IKNetSerDes{V}"/></param>
        /// <returns><see cref="KNetMaterialized{K, V}"/></returns>
        public static KNetMaterialized<K, V> With(IKNetSerDes<K> arg0, IKNetSerDes<V> arg1)
        {
            var mat = Org.Apache.Kafka.Streams.Kstream.Materialized<byte[], byte[], Org.Apache.Kafka.Streams.State.KeyValueStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>>.With(arg0.KafkaSerde, arg1.KafkaSerde);
            return new KNetMaterialized<K, V>(mat.Cast<Org.Apache.Kafka.Streams.Kstream.Materialized<byte[], byte[], Org.Apache.Kafka.Streams.State.KeyValueStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>>>());
        }

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.html#withValueSerde-org.apache.kafka.common.serialization.Serde-"/>
        /// </summary>
        /// <param name="arg0"><see cref="IKNetSerDes{V}"/></param>
        /// <returns><see cref="KNetMaterialized{K, V}"/></returns>
        public KNetMaterialized<K, V> WithValueSerde(IKNetSerDes<V> arg0)
        {
            _keyStore?.WithValueSerde(arg0.KafkaSerde);
            _sessionStore?.WithValueSerde(arg0.KafkaSerde);
            _windowStore?.WithValueSerde(arg0.KafkaSerde);
            return this;
        }
    }

    /// <summary>
    /// KNet base extension of <see cref="Org.Apache.Kafka.Streams.Kstream.Materialized{K, V, S}"/>
    /// </summary>
    /// <typeparam name="K">Key type</typeparam>
    /// <typeparam name="V">Value type</typeparam>
    /// <typeparam name="TJVM">Backend JVM type</typeparam>
    /// <typeparam name="TContainer">The implementing class, see <see cref="KNetMaterialized{K, V}"/> or <see cref="KNetCountingMaterialized{K}"/></typeparam>
    public abstract class KNetMaterialized<K, V, TJVM, TContainer> : IGenericSerDesFactoryApplier where TContainer : class
    {
        internal readonly Org.Apache.Kafka.Streams.Kstream.Materialized<byte[], TJVM, Org.Apache.Kafka.Streams.State.KeyValueStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>> _keyStore;
        internal readonly Org.Apache.Kafka.Streams.Kstream.Materialized<byte[], TJVM, Org.Apache.Kafka.Streams.State.SessionStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>> _sessionStore;
        internal readonly Org.Apache.Kafka.Streams.Kstream.Materialized<byte[], TJVM, Org.Apache.Kafka.Streams.State.WindowStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>> _windowStore;

        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

        internal KNetMaterialized(Org.Apache.Kafka.Streams.Kstream.Materialized<byte[], TJVM, Org.Apache.Kafka.Streams.State.KeyValueStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>> materialized)
        {
            _keyStore = materialized;
        }

        internal KNetMaterialized(Org.Apache.Kafka.Streams.Kstream.Materialized<byte[], TJVM, Org.Apache.Kafka.Streams.State.SessionStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>> materialized)
        {
            _sessionStore = materialized;
        }

        internal KNetMaterialized(Org.Apache.Kafka.Streams.Kstream.Materialized<byte[], TJVM, Org.Apache.Kafka.Streams.State.WindowStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>> materialized)
        {
            _windowStore = materialized;
        }

        /// <summary>
        /// Converter from <see cref="KNetMaterialized{K, V, TJVM, TContainer}"/> to <see cref="Org.Apache.Kafka.Streams.Kstream.Materialized{K, V, S}"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.Kstream.Materialized<byte[], TJVM, Org.Apache.Kafka.Streams.State.KeyValueStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>>(KNetMaterialized<K, V, TJVM, TContainer> t) => t._keyStore;

        /// <summary>
        /// Converter from <see cref="KNetMaterialized{K, V, TJVM, TContainer}"/> to <see cref="Org.Apache.Kafka.Streams.Kstream.Materialized{K, V, S}"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.Kstream.Materialized<byte[], TJVM, Org.Apache.Kafka.Streams.State.SessionStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>>(KNetMaterialized<K, V, TJVM, TContainer> t) => t._sessionStore;

        /// <summary>
        /// Converter from <see cref="KNetMaterialized{K, V, TJVM, TContainer}"/> to <see cref="Org.Apache.Kafka.Streams.Kstream.Materialized{K, V, S}"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.Kstream.Materialized<byte[], TJVM, Org.Apache.Kafka.Streams.State.WindowStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>>(KNetMaterialized<K, V, TJVM, TContainer> t) => t._windowStore;

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.html#as-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><typeparamref name="TContainer"/></returns>
        public static TContainer As(string arg0)
        {
            var mat = Org.Apache.Kafka.Streams.Kstream.Materialized<byte[], TJVM, Org.Apache.Kafka.Streams.State.KeyValueStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>>.As(arg0);
            return Activator.CreateInstance(typeof(TContainer), mat.Cast<Org.Apache.Kafka.Streams.Kstream.Materialized<byte[], TJVM, Org.Apache.Kafka.Streams.State.KeyValueStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>>>()) as TContainer;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.html#as-org.apache.kafka.streams.kstream.Materialized.StoreType-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized.StoreType"/></param>
        /// <returns><typeparamref name="TContainer"/></returns>
        public static TContainer As(Org.Apache.Kafka.Streams.Kstream.Materialized.StoreType arg0)
        {
            var mat = Org.Apache.Kafka.Streams.Kstream.Materialized<byte[], TJVM, Org.Apache.Kafka.Streams.State.KeyValueStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>>.As(arg0);
            return Activator.CreateInstance(typeof(TContainer), mat.Cast<Org.Apache.Kafka.Streams.Kstream.Materialized<byte[], TJVM, Org.Apache.Kafka.Streams.State.KeyValueStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>>>()) as TContainer;
        }
 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.html#as-org.apache.kafka.streams.state.KeyValueBytesStoreSupplier-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.State.KeyValueBytesStoreSupplier"/></param>
        /// <returns><typeparamref name="TContainer"/></returns>
        public static TContainer As(Org.Apache.Kafka.Streams.State.KeyValueBytesStoreSupplier arg0)
        {
            var mat = Org.Apache.Kafka.Streams.Kstream.Materialized<byte[], TJVM, Org.Apache.Kafka.Streams.State.KeyValueStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>>.As(arg0);
            return Activator.CreateInstance(typeof(TContainer), mat) as TContainer;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.html#as-org.apache.kafka.streams.state.SessionBytesStoreSupplier-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.State.SessionBytesStoreSupplier"/></param>
        /// <returns><typeparamref name="TContainer"/></returns>
        public static TContainer As(Org.Apache.Kafka.Streams.State.SessionBytesStoreSupplier arg0)
        {
            var mat = Org.Apache.Kafka.Streams.Kstream.Materialized<byte[], TJVM, Org.Apache.Kafka.Streams.State.SessionStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>>.As(arg0);
            return Activator.CreateInstance(typeof(TContainer), mat) as TContainer;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.html#as-org.apache.kafka.streams.state.WindowBytesStoreSupplier-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.State.WindowBytesStoreSupplier"/></param>
        /// <returns><typeparamref name="TContainer"/></returns>
        public static TContainer As(Org.Apache.Kafka.Streams.State.WindowBytesStoreSupplier arg0)
        {
            var mat = Org.Apache.Kafka.Streams.Kstream.Materialized<byte[], TJVM, Org.Apache.Kafka.Streams.State.WindowStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>>.As(arg0);
            return Activator.CreateInstance(typeof(TContainer), mat) as TContainer;
        }

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.html#withCachingDisabled--"/>
        /// </summary>
        /// <returns><typeparamref name="TContainer"/></returns>
        public TContainer WithCachingDisabled()
        {
            _keyStore?.WithCachingDisabled();
            _sessionStore?.WithCachingDisabled();
            _windowStore?.WithCachingDisabled();
            return this as TContainer;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.html#withCachingEnabled--"/>
        /// </summary>
        /// <returns><typeparamref name="TContainer"/></returns>
        public TContainer WithCachingEnabled()
        {
            _keyStore?.WithCachingEnabled();
            _sessionStore?.WithCachingEnabled();
            _windowStore?.WithCachingEnabled();
            return this as TContainer;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.html#withKeySerde-org.apache.kafka.common.serialization.Serde-"/>
        /// </summary>
        /// <param name="arg0"><see cref="IKNetSerDes{K}"/></param>
        /// <returns><typeparamref name="TContainer"/></returns>
        public TContainer WithKeySerde(IKNetSerDes<K> arg0)
        {
            _keyStore?.WithKeySerde(arg0.KafkaSerde);
            _sessionStore?.WithKeySerde(arg0.KafkaSerde);
            _windowStore?.WithKeySerde(arg0.KafkaSerde);
            return this as TContainer;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.html#withLoggingDisabled--"/>
        /// </summary>
        /// <returns><typeparamref name="TContainer"/></returns>
        public TContainer WithLoggingDisabled()
        {
            _keyStore?.WithLoggingDisabled();
            _sessionStore?.WithLoggingDisabled();
            _windowStore?.WithLoggingDisabled();
            return this as TContainer;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.html#withLoggingEnabled-java.util.Map-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.Map"/></param>
        /// <returns><typeparamref name="TContainer"/></returns>
        public TContainer WithLoggingEnabled(Java.Util.Map<string, string> arg0)
        {
            _keyStore?.WithLoggingEnabled(arg0);
            _sessionStore?.WithLoggingEnabled(arg0);
            _windowStore?.WithLoggingEnabled(arg0);
            return this as TContainer;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.html#withRetention-java.time.Duration-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Time.Duration"/></param>
        /// <returns><typeparamref name="TContainer"/></returns>
        /// <exception cref="Java.Lang.IllegalArgumentException"/>
        public TContainer WithRetention(Java.Time.Duration arg0)
        {
            _keyStore?.WithRetention(arg0);
            _sessionStore?.WithRetention(arg0);
            _windowStore?.WithRetention(arg0);
            return this as TContainer;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.html#withStoreType-org.apache.kafka.streams.kstream.Materialized.StoreType-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized.StoreType"/></param>
        /// <returns><typeparamref name="TContainer"/></returns>
        /// <exception cref="Java.Lang.IllegalArgumentException"/>
        public TContainer WithStoreType(Org.Apache.Kafka.Streams.Kstream.Materialized.StoreType arg0)
        {
            _keyStore?.WithStoreType(arg0);
            _sessionStore?.WithStoreType(arg0);
            _windowStore?.WithStoreType(arg0);
            return this as TContainer;
        }

        #endregion
    }
}
