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

namespace MASES.KNet.Streams.Kstream
{
    /// <summary>
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.Kstream.Materialized{K, V, S}"/>
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    public class KNetMaterialized<K, V> : IGenericSerDesFactoryApplier
    {
        readonly Org.Apache.Kafka.Streams.Kstream.Materialized<byte[], Java.Lang.Long, Org.Apache.Kafka.Streams.State.KeyValueStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>> _countKeyStore;
        readonly Org.Apache.Kafka.Streams.Kstream.Materialized<byte[], byte[], Org.Apache.Kafka.Streams.State.KeyValueStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>> _keyStore;
        readonly Org.Apache.Kafka.Streams.Kstream.Materialized<byte[], byte[], Org.Apache.Kafka.Streams.State.SessionStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>> _sessionStore;
        readonly Org.Apache.Kafka.Streams.Kstream.Materialized<byte[], byte[], Org.Apache.Kafka.Streams.State.WindowStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>> _windowStore;

        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

        KNetMaterialized(Org.Apache.Kafka.Streams.Kstream.Materialized<byte[], Java.Lang.Long, Org.Apache.Kafka.Streams.State.KeyValueStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>> materialized)
        {
            _countKeyStore = materialized;
        }

        KNetMaterialized(Org.Apache.Kafka.Streams.Kstream.Materialized<byte[], byte[], Org.Apache.Kafka.Streams.State.KeyValueStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>> materialized)
        {
            _keyStore = materialized;
        }

        KNetMaterialized(Org.Apache.Kafka.Streams.Kstream.Materialized<byte[], byte[], Org.Apache.Kafka.Streams.State.SessionStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>> materialized)
        {
            _sessionStore = materialized;
        }

        KNetMaterialized(Org.Apache.Kafka.Streams.Kstream.Materialized<byte[], byte[], Org.Apache.Kafka.Streams.State.WindowStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>> materialized)
        {
            _windowStore = materialized;
        }

        /// <summary>
        /// Converter from <see cref="KNetMaterialized{K, V}"/> to <see cref="Org.Apache.Kafka.Streams.Kstream.Materialized{K, V, S}"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.Kstream.Materialized<byte[], Java.Lang.Long, Org.Apache.Kafka.Streams.State.KeyValueStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>>(KNetMaterialized<K, V> t) => t._countKeyStore;

        /// <summary>
        /// Converter from <see cref="KNetMaterialized{K, V}"/> to <see cref="Org.Apache.Kafka.Streams.Kstream.Materialized{K, V, S}"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.Kstream.Materialized<byte[], byte[], Org.Apache.Kafka.Streams.State.KeyValueStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>>(KNetMaterialized<K, V> t) => t._keyStore;

        /// <summary>
        /// Converter from <see cref="KNetMaterialized{K, V}"/> to <see cref="Org.Apache.Kafka.Streams.Kstream.Materialized{K, V, S}"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.Kstream.Materialized<byte[], byte[], Org.Apache.Kafka.Streams.State.SessionStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>>(KNetMaterialized<K, V> t) => t._sessionStore;

        /// <summary>
        /// Converter from <see cref="KNetMaterialized{K, V}"/> to <see cref="Org.Apache.Kafka.Streams.Kstream.Materialized{K, V, S}"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.Kstream.Materialized<byte[], byte[], Org.Apache.Kafka.Streams.State.WindowStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>>(KNetMaterialized<K, V> t) => t._windowStore;

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.html#as-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="KNetMaterialized{K, V}"/></returns>
        public static KNetMaterialized<K, V> As(string arg0)
        {
            var mat = Org.Apache.Kafka.Streams.Kstream.Materialized<byte[], byte[], Org.Apache.Kafka.Streams.State.KeyValueStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>>.As(arg0);
            return new KNetMaterialized<K, V>(mat.Cast<Org.Apache.Kafka.Streams.Kstream.Materialized<byte[], byte[], Org.Apache.Kafka.Streams.State.KeyValueStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>>>());
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.html#as-org.apache.kafka.streams.kstream.Materialized.StoreType-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized.StoreType"/></param>
        /// <returns><see cref="KNetMaterialized{K, V}"/></returns>
        public static KNetMaterialized<K, V> As(Org.Apache.Kafka.Streams.Kstream.Materialized.StoreType arg0)
        {
            var mat = Org.Apache.Kafka.Streams.Kstream.Materialized<byte[], byte[], Org.Apache.Kafka.Streams.State.KeyValueStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>>.As(arg0);
            return new KNetMaterialized<K, V>(mat.Cast<Org.Apache.Kafka.Streams.Kstream.Materialized<byte[], byte[], Org.Apache.Kafka.Streams.State.KeyValueStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>>>());
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
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.html#as-org.apache.kafka.streams.state.KeyValueBytesStoreSupplier-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.State.KeyValueBytesStoreSupplier"/></param>
        /// <returns><see cref="KNetMaterialized{K, V}"/></returns>
        public static KNetMaterialized<K, V> As(Org.Apache.Kafka.Streams.State.KeyValueBytesStoreSupplier arg0)
        {
            var mat = Org.Apache.Kafka.Streams.Kstream.Materialized<byte[], byte[], Org.Apache.Kafka.Streams.State.KeyValueStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>>.As(arg0);
            return new KNetMaterialized<K, V>(mat);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.html#as-org.apache.kafka.streams.state.SessionBytesStoreSupplier-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.State.SessionBytesStoreSupplier"/></param>
        /// <returns><see cref="KNetMaterialized{K, V}"/></returns>
        public static KNetMaterialized<K, V> As(Org.Apache.Kafka.Streams.State.SessionBytesStoreSupplier arg0)
        {
            var mat = Org.Apache.Kafka.Streams.Kstream.Materialized<byte[], byte[], Org.Apache.Kafka.Streams.State.SessionStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>>.As(arg0);
            return new KNetMaterialized<K, V>(mat);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.html#as-org.apache.kafka.streams.state.WindowBytesStoreSupplier-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.State.WindowBytesStoreSupplier"/></param>
        /// <returns><see cref="KNetMaterialized{K, V}"/></returns>
        public static KNetMaterialized<K, V> As(Org.Apache.Kafka.Streams.State.WindowBytesStoreSupplier arg0)
        {
            var mat = Org.Apache.Kafka.Streams.Kstream.Materialized<byte[], byte[], Org.Apache.Kafka.Streams.State.WindowStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>>.As(arg0);
            return new KNetMaterialized<K, V>(mat);
        }

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.html#withCachingDisabled--"/>
        /// </summary>
        /// <returns><see cref="KNetMaterialized{K, V}"/></returns>
        public KNetMaterialized<K, V> WithCachingDisabled()
        {
            _countKeyStore?.WithCachingDisabled();
            _keyStore?.WithCachingDisabled();
            _sessionStore?.WithCachingDisabled();
            _windowStore?.WithCachingDisabled();
            return this;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.html#withCachingEnabled--"/>
        /// </summary>
        /// <returns><see cref="KNetMaterialized{K, V}"/></returns>
        public KNetMaterialized<K, V> WithCachingEnabled()
        {
            _countKeyStore?.WithCachingEnabled();
            _keyStore?.WithCachingEnabled();
            _sessionStore?.WithCachingEnabled();
            _windowStore?.WithCachingEnabled();
            return this;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.html#withKeySerde-org.apache.kafka.common.serialization.Serde-"/>
        /// </summary>
        /// <param name="arg0"><see cref="IKNetSerDes{K}"/></param>
        /// <returns><see cref="KNetMaterialized{K, V}"/></returns>
        public KNetMaterialized<K, V> WithKeySerde(IKNetSerDes<K> arg0)
        {
            _countKeyStore?.WithKeySerde(arg0.KafkaSerde);
            _keyStore?.WithKeySerde(arg0.KafkaSerde);
            _sessionStore?.WithKeySerde(arg0.KafkaSerde);
            _windowStore?.WithKeySerde(arg0.KafkaSerde);
            return this;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.html#withLoggingDisabled--"/>
        /// </summary>
        /// <returns><see cref="KNetMaterialized{K, V}"/></returns>
        public KNetMaterialized<K, V> WithLoggingDisabled()
        {
            _countKeyStore?.WithLoggingDisabled();
            _keyStore?.WithLoggingDisabled();
            _sessionStore?.WithLoggingDisabled();
            _windowStore?.WithLoggingDisabled();
            return this;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.html#withLoggingEnabled-java.util.Map-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.Map"/></param>
        /// <returns><see cref="KNetMaterialized{K, V}"/></returns>
        public KNetMaterialized<K, V> WithLoggingEnabled(Java.Util.Map<string, string> arg0)
        {
            _countKeyStore?.WithLoggingEnabled(arg0);
            _keyStore?.WithLoggingEnabled(arg0);
            _sessionStore?.WithLoggingEnabled(arg0);
            _windowStore?.WithLoggingEnabled(arg0);
            return this;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.html#withRetention-java.time.Duration-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Time.Duration"/></param>
        /// <returns><see cref="KNetMaterialized{K, V}"/></returns>
        /// <exception cref="Java.Lang.IllegalArgumentException"/>
        public KNetMaterialized<K, V> WithRetention(Java.Time.Duration arg0)
        {
            _countKeyStore?.WithRetention(arg0);
            _keyStore?.WithRetention(arg0);
            _sessionStore?.WithRetention(arg0);
            _windowStore?.WithRetention(arg0);
            return this;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.html#withStoreType-org.apache.kafka.streams.kstream.Materialized.StoreType-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized.StoreType"/></param>
        /// <returns><see cref="KNetMaterialized{K, V}"/></returns>
        /// <exception cref="Java.Lang.IllegalArgumentException"/>
        public KNetMaterialized<K, V> WithStoreType(Org.Apache.Kafka.Streams.Kstream.Materialized.StoreType arg0)
        {
            _countKeyStore?.WithStoreType(arg0);
            _keyStore?.WithStoreType(arg0);
            _sessionStore?.WithStoreType(arg0);
            _windowStore?.WithStoreType(arg0);
            return this;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.html#withValueSerde-org.apache.kafka.common.serialization.Serde-"/>
        /// </summary>
        /// <param name="arg0"><see cref="IKNetSerDes{V}"/></param>
        /// <returns><see cref="KNetMaterialized{K, V}"/></returns>
        public KNetMaterialized<K, V> WithValueSerde(IKNetSerDes<V> arg0)
        {
            _countKeyStore?.WithValueSerde(Serdes.Long());
            _keyStore?.WithValueSerde(arg0.KafkaSerde);
            _sessionStore?.WithValueSerde(arg0.KafkaSerde);
            _windowStore?.WithValueSerde(arg0.KafkaSerde);
            return this;
        }

        #endregion
    }
}
