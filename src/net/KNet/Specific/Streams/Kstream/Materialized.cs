/*
*  Copyright (c) 2021-2026 MASES s.r.l.
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
using System.Threading;

namespace MASES.KNet.Streams.Kstream
{
    /// <summary>
    /// KNet extension of <see cref="Materialized{K, V, TJVMK, TJVMV, TContainer}"/>
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="TJVMK">Key JVM type</typeparam>
    public sealed class CountingMaterialized<K, TJVMK> : Materialized<K, long, TJVMK, Java.Lang.Long, CountingMaterialized<K, TJVMK>>
    {
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.3.1/org/apache/kafka/streams/kstream/Materialized.html#with(org.apache.kafka.common.serialization.Serde,org.apache.kafka.common.serialization.Serde)"/>
        /// </summary>
        /// <param name="arg0"><see cref="ISerDes{K, TJVMK}"/></param>
        /// <returns><see cref="Materialized{K, V, TJVMK}"/></returns>
        public static CountingMaterialized<K, TJVMK> With(ISerDes<K, TJVMK> arg0)
        {
            var mat = Org.Apache.Kafka.Streams.Kstream.Materialized<TJVMK, Java.Lang.Long, Org.Apache.Kafka.Streams.State.KeyValueStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>>.With(arg0.KafkaSerde, Org.Apache.Kafka.Common.Serialization.Serdes.Long());
            CountingMaterialized<K, TJVMK> cont = new();
            if (cont is IKNetMaterialized<TJVMK, Java.Lang.Long> setStore)
            {
                setStore.SetStore(mat.CastDirectAndDispose<Org.Apache.Kafka.Streams.Kstream.Materialized<TJVMK, Java.Lang.Long, Org.Apache.Kafka.Streams.State.KeyValueStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>>>());
            }
            return cont;
        }

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.3.1/org/apache/kafka/streams/kstream/Materialized.html#withValueSerde(org.apache.kafka.common.serialization.Serde)"/>
        /// </summary>
        /// <param name="arg0"><see cref="ISerDes{V, TJVMK}"/></param>
        /// <returns><see cref="Materialized{K, V, TJVMK}"/></returns>
        public CountingMaterialized<K, TJVMK> WithValueSerde(ISerDes<long, Java.Lang.Long> arg0)
        {
            _keyStore?.WithValueSerde(arg0.KafkaSerde);
            return this;
        }
    }

    /// <summary>
    /// KNet extension of <see cref="Materialized{K, V, TJVMK, S, TContainer}"/>
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <typeparam name="TJVMK">Key JVM type</typeparam>
    /// <typeparam name="TJVMV">Value JVM type</typeparam>
    public sealed class Materialized<K, V, TJVMK, TJVMV> : Materialized<K, V, TJVMK, TJVMV, Materialized<K, V, TJVMK, TJVMV>>
    {
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.3.1/org/apache/kafka/streams/kstream/Materialized.html#with(org.apache.kafka.common.serialization.Serde,org.apache.kafka.common.serialization.Serde)"/>
        /// </summary>
        /// <param name="arg0"><see cref="ISerDes{K, TJVMK}"/></param>
        /// <param name="arg1"><see cref="ISerDes{V, TJVMV}"/></param>
        /// <returns><see cref="Materialized{K, V, TJVMK, TJVMV}"/></returns>
        public static Materialized<K, V, TJVMK, TJVMV> With(ISerDes<K, TJVMK> arg0, ISerDes<V, TJVMV> arg1)
        {
            var mat = Org.Apache.Kafka.Streams.Kstream.Materialized<TJVMK, TJVMV, Org.Apache.Kafka.Streams.State.KeyValueStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>>.With(arg0.KafkaSerde, arg1.KafkaSerde);
            Materialized<K, V, TJVMK, TJVMV> cont = new();
            if (cont is IKNetMaterialized<TJVMK, TJVMV> setStore)
            {
                setStore.SetStore(mat.CastDirectAndDispose<Org.Apache.Kafka.Streams.Kstream.Materialized<TJVMK, TJVMV, Org.Apache.Kafka.Streams.State.KeyValueStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>>>());
            }
            return cont;
        }

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.3.1/org/apache/kafka/streams/kstream/Materialized.html#withValueSerde(org.apache.kafka.common.serialization.Serde)"/>
        /// </summary>
        /// <param name="arg0"><see cref="ISerDes{V, TJVMV}"/></param>
        /// <returns><see cref="Materialized{K, V, TJVMK}"/></returns>
        public Materialized<K, V, TJVMK, TJVMV> WithValueSerde(ISerDes<V, TJVMV> arg0)
        {
            _keyStore?.WithValueSerde(arg0.KafkaSerde);
            _sessionStore?.WithValueSerde(arg0.KafkaSerde);
            _windowStore?.WithValueSerde(arg0.KafkaSerde);
            return this;
        }
    }

    /// <summary>
    /// KNet extension of <see cref="Materialized{K, V, TJVMK, S, TContainer}"/>
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <typeparam name="TJVMK">Key JVM type</typeparam>
    public sealed class Materialized<K, V, TJVMK> : Materialized<K, V, TJVMK, byte[], Materialized<K, V, TJVMK>>
    {

    }
    /// <summary>
    /// Supporting interface for <see cref="Materialized{K, V, TJVMK, TJVMV, TContainer}"/>
    /// </summary>
    /// <typeparam name="TJVMK">Key JVM type</typeparam>
    /// <typeparam name="TJVMV">Value JVM type</typeparam>
    public interface IKNetMaterialized<TJVMK, TJVMV> : IDisposable
    {
        /// <summary>
        /// Supporting method for <see cref="Materialized{K, V, TJVMK, TJVMV, TContainer}"/>
        /// </summary>
        void SetStore(Org.Apache.Kafka.Streams.Kstream.Materialized<TJVMK, TJVMV, Org.Apache.Kafka.Streams.State.KeyValueStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>> materialized);
        /// <summary>
        /// Supporting method for <see cref="Materialized{K, V, TJVMK, TJVMV, TContainer}"/>
        /// </summary>
        void SetStore(Org.Apache.Kafka.Streams.Kstream.Materialized<TJVMK, TJVMV, Org.Apache.Kafka.Streams.State.SessionStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>> materialized);
        /// <summary>
        /// Supporting method for <see cref="Materialized{K, V, TJVMK, TJVMV, TContainer}"/>
        /// </summary>
        void SetStore(Org.Apache.Kafka.Streams.Kstream.Materialized<TJVMK, TJVMV, Org.Apache.Kafka.Streams.State.WindowStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>> materialized);
    }

    /// <summary>
    /// KNet base extension of <see cref="Org.Apache.Kafka.Streams.Kstream.Materialized{K, V, S}"/>
    /// </summary>
    /// <typeparam name="K">Key type</typeparam>
    /// <typeparam name="V">Value type</typeparam>
    /// <typeparam name="TJVMK">Key JVM type</typeparam>
    /// <typeparam name="TJVMV">Value JVM type</typeparam>
    /// <typeparam name="TContainer">The implementing class, see <see cref="Materialized{K, V, TJVMK}"/> or <see cref="CountingMaterialized{K, TJVMK}"/></typeparam>
    public abstract class Materialized<K, V, TJVMK, TJVMV, TContainer> : IGenericSerDesFactoryApplier, IKNetMaterialized<TJVMK, TJVMV> where TContainer : class, new()
    {
        internal Org.Apache.Kafka.Streams.Kstream.Materialized<TJVMK, TJVMV, Org.Apache.Kafka.Streams.State.KeyValueStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>> _keyStore;
        internal Org.Apache.Kafka.Streams.Kstream.Materialized<TJVMK, TJVMV, Org.Apache.Kafka.Streams.State.SessionStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>> _sessionStore;
        internal Org.Apache.Kafka.Streams.Kstream.Materialized<TJVMK, TJVMV, Org.Apache.Kafka.Streams.State.WindowStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>> _windowStore;

        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set => _factory = value; }

        void IKNetMaterialized<TJVMK, TJVMV>.SetStore(Org.Apache.Kafka.Streams.Kstream.Materialized<TJVMK, TJVMV, Org.Apache.Kafka.Streams.State.KeyValueStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>> materialized)
        {
            _keyStore = materialized;
        }

        void IKNetMaterialized<TJVMK, TJVMV>.SetStore(Org.Apache.Kafka.Streams.Kstream.Materialized<TJVMK, TJVMV, Org.Apache.Kafka.Streams.State.SessionStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>> materialized)
        {
            _sessionStore = materialized;
        }

        void IKNetMaterialized<TJVMK, TJVMV>.SetStore(Org.Apache.Kafka.Streams.Kstream.Materialized<TJVMK, TJVMV, Org.Apache.Kafka.Streams.State.WindowStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>> materialized)
        {
            _windowStore = materialized;
        }

        #region IDisposable

        volatile int _disposed; // 0 = live, 1 = disposed
        /// <summary>
        /// Test if this instance was disposed
        /// </summary>
        /// <exception cref="ObjectDisposedException">When this instance was disposed</exception>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        protected void CheckDisposed() { if (_disposed != 0) throw new ObjectDisposedException(GetType().Name); }
        /// <inheritdoc cref="IDisposable.Dispose"/>
        public void Dispose()
        {
            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Implements the pattern described in https://learn.microsoft.com/en-en/dotnet/standard/garbage-collection/implementing-dispose
        /// </summary>
        /// <param name="disposing">The disposing parameter is a <see langword="bool"/> that indicates whether the method call comes from a <see cref="IDisposable.Dispose"/> method (its value is <see langword="true"/>) or from a finalizer (its value is <see langword="false"/>)</param>
        protected virtual void Dispose(bool disposing)
        {
            if (Interlocked.Exchange(ref _disposed, 1) != 0)
                return;

            if (disposing)
            {
                _keyStore?.Dispose();
                _sessionStore?.Dispose();
                _windowStore?.Dispose();
            }
        }

        #endregion

        /// <summary>
        /// Converter from <see cref="Materialized{K, V, TJVMK, TJVMV, TContainer}"/> to <see cref="Org.Apache.Kafka.Streams.Kstream.Materialized{TJVMK, TJVMV, S}"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.Kstream.Materialized<TJVMK, TJVMV, Org.Apache.Kafka.Streams.State.KeyValueStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>>(Materialized<K, V, TJVMK, TJVMV, TContainer> t) => t._keyStore;

        /// <summary>
        /// Converter from <see cref="Materialized{K, V, TJVMK, TJVMV, TContainer}"/> to <see cref="Org.Apache.Kafka.Streams.Kstream.Materialized{TJVMK, TJVMV, S}"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.Kstream.Materialized<TJVMK, TJVMV, Org.Apache.Kafka.Streams.State.SessionStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>>(Materialized<K, V, TJVMK, TJVMV, TContainer> t) => t._sessionStore;

        /// <summary>
        /// Converter from <see cref="Materialized{K, V, TJVMK, TJVMV, TContainer}"/> to <see cref="Org.Apache.Kafka.Streams.Kstream.Materialized{TJVMK, TJVMV, S}"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.Kstream.Materialized<TJVMK, TJVMV, Org.Apache.Kafka.Streams.State.WindowStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>>(Materialized<K, V, TJVMK, TJVMV, TContainer> t) => t._windowStore;

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.3.1/org/apache/kafka/streams/kstream/Materialized.html#as(java.lang.String)"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><typeparamref name="TContainer"/></returns>
        public static TContainer As(string arg0)
        {
            var mat = Org.Apache.Kafka.Streams.Kstream.Materialized<TJVMK, TJVMV, Org.Apache.Kafka.Streams.State.KeyValueStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>>.As(arg0);
            TContainer cont = new();
            if (cont is IKNetMaterialized<TJVMK, TJVMV> setStore)
            {
                setStore.SetStore(mat.CastDirectAndDispose<Org.Apache.Kafka.Streams.Kstream.Materialized<TJVMK, TJVMV, Org.Apache.Kafka.Streams.State.KeyValueStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>>>());
            }
            return cont;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.3.1/org/apache/kafka/streams/kstream/Materialized.html#as(org.apache.kafka.streams.kstream.Materialized.StoreType)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized.StoreType"/></param>
        /// <returns><typeparamref name="TContainer"/></returns>
        public static TContainer As(Org.Apache.Kafka.Streams.Kstream.Materialized.StoreType arg0)
        {
            var mat = Org.Apache.Kafka.Streams.Kstream.Materialized<TJVMK, TJVMV, Org.Apache.Kafka.Streams.State.KeyValueStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>>.As(arg0);
            TContainer cont = new();
            if (cont is IKNetMaterialized<TJVMK, TJVMV> setStore)
            {
                setStore.SetStore(mat.CastDirectAndDispose<Org.Apache.Kafka.Streams.Kstream.Materialized<TJVMK, TJVMV, Org.Apache.Kafka.Streams.State.KeyValueStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>>>());
            }
            return cont;
        }

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.3.1/org/apache/kafka/streams/kstream/Materialized.html#as(org.apache.kafka.streams.state.KeyValueBytesStoreSupplier)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.State.KeyValueBytesStoreSupplier"/></param>
        /// <returns><typeparamref name="TContainer"/></returns>
        public static TContainer As(Org.Apache.Kafka.Streams.State.KeyValueBytesStoreSupplier arg0)
        {
            var mat = Org.Apache.Kafka.Streams.Kstream.Materialized<TJVMK, TJVMV, Org.Apache.Kafka.Streams.State.KeyValueStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>>.As(arg0);
            TContainer cont = new();
            if (cont is IKNetMaterialized<TJVMK, TJVMV> setStore)
            {
                setStore.SetStore(mat);
            }
            return cont;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.3.1/org/apache/kafka/streams/kstream/Materialized.html#as(org.apache.kafka.streams.state.SessionBytesStoreSupplier)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.State.SessionBytesStoreSupplier"/></param>
        /// <returns><typeparamref name="TContainer"/></returns>
        public static TContainer As(Org.Apache.Kafka.Streams.State.SessionBytesStoreSupplier arg0)
        {
            var mat = Org.Apache.Kafka.Streams.Kstream.Materialized<TJVMK, TJVMV, Org.Apache.Kafka.Streams.State.SessionStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>>.As(arg0);
            TContainer cont = new();
            if (cont is IKNetMaterialized<TJVMK, TJVMV> setStore)
            {
                setStore.SetStore(mat);
            }
            return cont;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.3.1/org/apache/kafka/streams/kstream/Materialized.html#as(org.apache.kafka.streams.state.WindowBytesStoreSupplier)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.State.WindowBytesStoreSupplier"/></param>
        /// <returns><typeparamref name="TContainer"/></returns>
        public static TContainer As(Org.Apache.Kafka.Streams.State.WindowBytesStoreSupplier arg0)
        {
            var mat = Org.Apache.Kafka.Streams.Kstream.Materialized<TJVMK, TJVMV, Org.Apache.Kafka.Streams.State.WindowStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>>.As(arg0);
            TContainer cont = new();
            if (cont is IKNetMaterialized<TJVMK, TJVMV> setStore)
            {
                setStore.SetStore(mat);
            }
            return cont;
        }

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.3.1/org/apache/kafka/streams/kstream/Materialized.html#withCachingDisabled()"/>
        /// </summary>
        /// <returns><typeparamref name="TContainer"/></returns>
        public TContainer WithCachingDisabled()
        {
            CheckDisposed();
            _keyStore?.WithCachingDisabled();
            _sessionStore?.WithCachingDisabled();
            _windowStore?.WithCachingDisabled();
            return this as TContainer;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.3.1/org/apache/kafka/streams/kstream/Materialized.html#withCachingEnabled()"/>
        /// </summary>
        /// <returns><typeparamref name="TContainer"/></returns>
        public TContainer WithCachingEnabled()
        {
            CheckDisposed();
            _keyStore?.WithCachingEnabled();
            _sessionStore?.WithCachingEnabled();
            _windowStore?.WithCachingEnabled();
            return this as TContainer;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.3.1/org/apache/kafka/streams/kstream/Materialized.html#withKeySerde(org.apache.kafka.common.serialization.Serde)"/>
        /// </summary>
        /// <param name="arg0"><see cref="ISerDes{K, TJVMK}"/></param>
        /// <returns><typeparamref name="TContainer"/></returns>
        public TContainer WithKeySerde(ISerDes<K, TJVMK> arg0)
        {
            CheckDisposed();
            _keyStore?.WithKeySerde(arg0.KafkaSerde);
            _sessionStore?.WithKeySerde(arg0.KafkaSerde);
            _windowStore?.WithKeySerde(arg0.KafkaSerde);
            return this as TContainer;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.3.1/org/apache/kafka/streams/kstream/Materialized.html#withLoggingDisabled()"/>
        /// </summary>
        /// <returns><typeparamref name="TContainer"/></returns>
        public TContainer WithLoggingDisabled()
        {
            CheckDisposed();
            _keyStore?.WithLoggingDisabled();
            _sessionStore?.WithLoggingDisabled();
            _windowStore?.WithLoggingDisabled();
            return this as TContainer;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.3.1/org/apache/kafka/streams/kstream/Materialized.html#withLoggingEnabled(java.util.Map)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.Map"/></param>
        /// <returns><typeparamref name="TContainer"/></returns>
        public TContainer WithLoggingEnabled(Java.Util.Map<Java.Lang.String, Java.Lang.String> arg0)
        {
            CheckDisposed();
            _keyStore?.WithLoggingEnabled(arg0);
            _sessionStore?.WithLoggingEnabled(arg0);
            _windowStore?.WithLoggingEnabled(arg0);
            return this as TContainer;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.3.1/org/apache/kafka/streams/kstream/Materialized.html#withRetention(java.time.Duration)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Time.Duration"/></param>
        /// <returns><typeparamref name="TContainer"/></returns>
        /// <exception cref="Java.Lang.IllegalArgumentException"/>
        public TContainer WithRetention(Java.Time.Duration arg0)
        {
            CheckDisposed();
            _keyStore?.WithRetention(arg0);
            _sessionStore?.WithRetention(arg0);
            _windowStore?.WithRetention(arg0);
            return this as TContainer;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.3.1/org/apache/kafka/streams/kstream/Materialized.html#withStoreType(org.apache.kafka.streams.kstream.Materialized.StoreType)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized.StoreType"/></param>
        /// <returns><typeparamref name="TContainer"/></returns>
        /// <exception cref="Java.Lang.IllegalArgumentException"/>
        public TContainer WithStoreType(Org.Apache.Kafka.Streams.Kstream.Materialized.StoreType arg0)
        {
            CheckDisposed();
            _keyStore?.WithStoreType(arg0);
            _sessionStore?.WithStoreType(arg0);
            _windowStore?.WithStoreType(arg0);
            return this as TContainer;
        }

        #endregion
    }
}
