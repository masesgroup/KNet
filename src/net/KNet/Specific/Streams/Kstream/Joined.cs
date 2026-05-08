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

using MASES.KNet.Serialization;
using System;
using System.Threading;

namespace MASES.KNet.Streams.Kstream
{
    /// <summary>
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.Kstream.Joined{TJVMK, TJVMV, TJVMVO}"/>
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <typeparam name="VO"></typeparam>
    /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
    /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
    /// <typeparam name="TJVMVO">The JVM type of <typeparamref name="VO"/></typeparam>
    public class Joined<K, V, VO, TJVMK, TJVMV, TJVMVO> : IGenericSerDesFactoryApplier, IDisposable
    {
        readonly Org.Apache.Kafka.Streams.Kstream.Joined<TJVMK, TJVMV, TJVMVO> _inner;
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set => _factory = value; }

        internal Joined(Org.Apache.Kafka.Streams.Kstream.Joined<TJVMK, TJVMV, TJVMVO> inner)
        {
            _inner = inner;
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
                _inner?.Dispose();
            }
        }

        #endregion

        /// <summary>
        /// Converter from <see cref="Joined{K, V, VO, TJVMK, TJVMV, TJVMVO}"/> to <see cref="Org.Apache.Kafka.Streams.Kstream.Joined{TJVMK, TJVMV, TJVMVO}"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.Kstream.Joined<TJVMK, TJVMV, TJVMVO>(Joined<K, V, VO, TJVMK, TJVMV, TJVMVO> t) => t._inner;

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/kstream/Joined.html#as(java.lang.String)"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="Joined{K, V, VO, TJVMK, TJVMV, TJVMVO}"/></returns>
        public static Joined<K, V, VO, TJVMK, TJVMV, TJVMVO> As(string arg0)
        {
            using Java.Lang.String jString = arg0;
            var cons = Org.Apache.Kafka.Streams.Kstream.Joined<TJVMK, TJVMV, TJVMVO>.As(jString);
            return new Joined<K, V, VO, TJVMK, TJVMV, TJVMVO>(cons);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/kstream/Joined.html#keySerde(org.apache.kafka.common.serialization.Serde)"/>
        /// </summary>
        /// <param name="arg0"><see cref="ISerDes{K, TJVMK}"/></param>
        /// <returns><see cref="Joined{K, V, VO, TJVMK, TJVMV, TJVMVO}"/></returns>
        public static Joined<K, V, VO, TJVMK, TJVMV, TJVMVO> KeySerde(ISerDes<K, TJVMK> arg0)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Joined<TJVMK, TJVMV, TJVMVO>.KeySerde(arg0.KafkaSerde);
            return new Joined<K, V, VO, TJVMK, TJVMV, TJVMVO>(cons);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/kstream/Joined.html#otherValueSerde(org.apache.kafka.common.serialization.Serde)"/>
        /// </summary>
        /// <param name="arg0"><see cref="ISerDes{VO, TJVMVO}"/></param>
        /// <returns><see cref="Joined{K, V, VO, TJVMK, TJVMV, TJVMVO}"/></returns>
        public static Joined<K, V, VO, TJVMK, TJVMV, TJVMVO> OtherValueSerde(ISerDes<VO, TJVMVO> arg0)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Joined<TJVMK, TJVMV, TJVMVO>.OtherValueSerde(arg0.KafkaSerde);
            return new Joined<K, V, VO, TJVMK, TJVMV, TJVMVO>(cons);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/kstream/Joined.html#valueSerde(org.apache.kafka.common.serialization.Serde)"/>
        /// </summary>
        /// <param name="arg0"><see cref="ISerDes{V, TJVMV}"/></param>
        /// <returns><see cref="Joined{K, V, VO, TJVMK, TJVMV, TJVMVO}"/></returns>
        public static Joined<K, V, VO, TJVMK, TJVMV, TJVMVO> ValueSerde(ISerDes<V, TJVMV> arg0)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Joined<TJVMK, TJVMV, TJVMVO>.ValueSerde(arg0.KafkaSerde);
            return new Joined<K, V, VO, TJVMK, TJVMV, TJVMVO>(cons);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/kstream/Joined.html#with(org.apache.kafka.common.serialization.Serde,org.apache.kafka.common.serialization.Serde,org.apache.kafka.common.serialization.Serde,java.lang.String-java.time.Duration)"/>
        /// </summary>
        /// <param name="arg0"><see cref="ISerDes{K, TJVMK}"/></param>
        /// <param name="arg1"><see cref="ISerDes{V, TJVMV}"/></param>
        /// <param name="arg2"><see cref="ISerDes{VO, TJVMVO}"/></param>
        /// <param name="arg3"><see cref="string"/></param>
        /// <param name="arg4"><see cref="System.TimeSpan"/></param>
        /// <returns><see cref="Joined{K, V, VO, TJVMK, TJVMV, TJVMVO}"/></returns>
        public static Joined<K, V, VO, TJVMK, TJVMV, TJVMVO> With(ISerDes<K, TJVMK> arg0, ISerDes<V, TJVMV> arg1, ISerDes<VO, TJVMVO> arg2, string arg3, System.TimeSpan arg4)
        {
            using Java.Lang.String jString = arg3;
            using Java.Time.Duration duration = arg4;
            var cons = Org.Apache.Kafka.Streams.Kstream.Joined<TJVMK, TJVMV, TJVMVO>.With(arg0.KafkaSerde, arg1.KafkaSerde, arg2.KafkaSerde, jString, duration);
            return new Joined<K, V, VO, TJVMK, TJVMV, TJVMVO>(cons);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/kstream/Joined.html#with(org.apache.kafka.common.serialization.Serde,org.apache.kafka.common.serialization.Serde,org.apache.kafka.common.serialization.Serde,java.lang.String)"/>
        /// </summary>
        /// <param name="arg0"><see cref="ISerDes{K, TJVMK}"/></param>
        /// <param name="arg1"><see cref="ISerDes{V, TJVMV}"/></param>
        /// <param name="arg2"><see cref="ISerDes{VO, TJVMVO}"/></param>
        /// <param name="arg3"><see cref="string"/></param>
        /// <returns><see cref="Joined{K, V, VO, TJVMK, TJVMV, TJVMVO}"/></returns>
        public static Joined<K, V, VO, TJVMK, TJVMV, TJVMVO> With(ISerDes<K, TJVMK> arg0, ISerDes<V, TJVMV> arg1, ISerDes<VO, TJVMVO> arg2, string arg3)
        {
            using Java.Lang.String jString = arg3;
            var cons = Org.Apache.Kafka.Streams.Kstream.Joined<TJVMK, TJVMV, TJVMVO>.With(arg0.KafkaSerde, arg1.KafkaSerde, arg2.KafkaSerde, jString);
            return new Joined<K, V, VO, TJVMK, TJVMV, TJVMVO>(cons);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/kstream/Joined.html#with(org.apache.kafka.common.serialization.Serde,org.apache.kafka.common.serialization.Serde,org.apache.kafka.common.serialization.Serde)"/>
        /// </summary>
        /// <param name="arg0"><see cref="ISerDes{K, TJVMK}"/></param>
        /// <param name="arg1"><see cref="ISerDes{V, TJVMV}"/></param>
        /// <param name="arg2"><see cref="ISerDes{VO, TJVMVO}"/></param>
        /// <returns><see cref="Joined{K, V, VO, TJVMK, TJVMV, TJVMVO}"/></returns>
        public static Joined<K, V, VO, TJVMK, TJVMV, TJVMVO> With(ISerDes<K, TJVMK> arg0, ISerDes<V, TJVMV> arg1, ISerDes<VO, TJVMVO> arg2)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Joined<TJVMK, TJVMV, TJVMVO>.With(arg0.KafkaSerde, arg1.KafkaSerde, arg2.KafkaSerde);
            return new Joined<K, V, VO, TJVMK, TJVMV, TJVMVO>(cons);
        }

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/kstream/Joined.html#withGracePeriod(java.time.Duration)"/>
        /// </summary>
        /// <param name="arg0"><see cref="System.TimeSpan"/></param>
        /// <returns><see cref="Joined{K, V, VO, TJVMK, TJVMV, TJVMVO}"/></returns>
        public Joined<K, V, VO, TJVMK, TJVMV, TJVMVO> WithGracePeriod(System.TimeSpan arg0)
        {
            CheckDisposed();
            using Java.Time.Duration duration = arg0;
            _inner?.WithGracePeriod(duration);
            return this;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/kstream/Joined.html#withKeySerde(org.apache.kafka.common.serialization.Serde)"/>
        /// </summary>
        /// <param name="arg0"><see cref="ISerDes{K, TJVMK}"/></param>
        /// <returns><see cref="Joined{K, V, VO, TJVMK, TJVMV, TJVMVO}"/></returns>
        public Joined<K, V, VO, TJVMK, TJVMV, TJVMVO> WithKeySerde(ISerDes<K, TJVMK> arg0)
        {
            CheckDisposed();
            _inner?.WithKeySerde(arg0.KafkaSerde);
            return this;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/kstream/Joined.html#withOtherValueSerde(org.apache.kafka.common.serialization.Serde)"/>
        /// </summary>
        /// <param name="arg0"><see cref="ISerDes{VO, TJVMVO}"/></param>
        /// <returns><see cref="Joined{K, V, VO, TJVMK, TJVMV, TJVMVO}"/></returns>
        public Joined<K, V, VO, TJVMK, TJVMV, TJVMVO> WithOtherValueSerde(ISerDes<VO, TJVMVO> arg0)
        {
            CheckDisposed();
            _inner?.WithOtherValueSerde(arg0.KafkaSerde);
            return this;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/kstream/Joined.html#withValueSerde(org.apache.kafka.common.serialization.Serde)"/>
        /// </summary>
        /// <param name="arg0"><see cref="ISerDes{V, TJVMV}"/></param>
        /// <returns><see cref="Joined{K, V, VO, TJVMK, TJVMV, TJVMVO}"/></returns>
        public Joined<K, V, VO, TJVMK, TJVMV, TJVMVO> WithValueSerde(ISerDes<V, TJVMV> arg0)
        {
            CheckDisposed();
            _inner?.WithValueSerde(arg0.KafkaSerde);
            return this;
        }

        #endregion
    }

    /// <summary>
    /// KNet extension of <see cref="Joined{K, V, VO, TJVMK, TJVMV, TJVMVO}"/>
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <typeparam name="VO"></typeparam>
    public class Joined<K, V, VO> : Joined<K, V, VO, byte[], byte[], byte[]>
    {
        Joined(Org.Apache.Kafka.Streams.Kstream.Joined<byte[], byte[], byte[]> inner) : base(inner)
        {

        }
    }
}
