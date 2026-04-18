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
	/// KNet extension of <see cref="Org.Apache.Kafka.Streams.Kstream.StreamJoined{TJVMK, TJVMV1, TJVMV2}"/>
	/// </summary>
	/// <typeparam name="K"></typeparam>
	/// <typeparam name="V1"></typeparam>
	/// <typeparam name="V2"></typeparam>
	/// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
	/// <typeparam name="TJVMV1">The JVM type of <typeparamref name="V1"/></typeparam>
	/// <typeparam name="TJVMV2">The JVM type of <typeparamref name="V2"/></typeparam>
	public class StreamJoined<K, V1, V2, TJVMK, TJVMV1, TJVMV2> : IGenericSerDesFactoryApplier, IDisposable
	{
		readonly Org.Apache.Kafka.Streams.Kstream.StreamJoined<TJVMK, TJVMV1, TJVMV2> _inner;
		IGenericSerDesFactory _factory;
		IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set => _factory = value; }

		StreamJoined(Org.Apache.Kafka.Streams.Kstream.StreamJoined<TJVMK, TJVMV1, TJVMV2> inner)
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
		/// Converter from <see cref="StreamJoined{K, V1, V2, TJVMK, TJVMV1, TJVMV2}"/> to <see cref="Org.Apache.Kafka.Streams.Kstream.StreamJoined{TJVMK, TJVMV1, TJVMV2}"/>
		/// </summary>
		public static implicit operator Org.Apache.Kafka.Streams.Kstream.StreamJoined<TJVMK, TJVMV1, TJVMV2>(StreamJoined<K, V1, V2, TJVMK, TJVMV1, TJVMV2> t) => t._inner;

		#region Static methods
		/// <summary>
		/// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/kstream/StreamJoined.html#as(java.lang.String)"/>
		/// </summary>
		/// <param name="arg0"><see cref="string"/></param>
		/// <returns><see cref="StreamJoined{K, V1, V2, TJVMK, TJVMV1, TJVMV2}"/></returns>
		public static StreamJoined<K, V1, V2, TJVMK, TJVMV1, TJVMV2> As(string arg0)
		{
			var cons = Org.Apache.Kafka.Streams.Kstream.StreamJoined<TJVMK, TJVMV1, TJVMV2>.As(arg0);
			return new StreamJoined<K, V1, V2, TJVMK, TJVMV1, TJVMV2>(cons);
		}
		/// <summary>
		/// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/kstream/StreamJoined.html#with(org.apache.kafka.common.serialization.Serde,org.apache.kafka.common.serialization.Serde,org.apache.kafka.common.serialization.Serde)"/>
		/// </summary>
		/// <param name="arg0"><see cref="ISerDes{K, TJVMK}"/></param>
		/// <param name="arg1"><see cref="ISerDes{V1, TJVMV1}"/></param>
		/// <param name="arg2"><see cref="ISerDes{V2, TJVMV2}"/></param>
		/// <returns><see cref="StreamJoined{K, V1, V2, TJVMK, TJVMV1, TJVMV2}"/></returns>
		public static StreamJoined<K, V1, V2, TJVMK, TJVMV1, TJVMV2> With(ISerDes<K, TJVMK> arg0, ISerDes<V1, TJVMV1> arg1, ISerDes<V2, TJVMV2> arg2)
		{
			var cons = Org.Apache.Kafka.Streams.Kstream.StreamJoined<TJVMK, TJVMV1, TJVMV2>.With(arg0.KafkaSerde, arg1.KafkaSerde, arg2.KafkaSerde);
			return new StreamJoined<K, V1, V2, TJVMK, TJVMV1, TJVMV2>(cons);
		}
		/// <summary>
		/// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/kstream/StreamJoined.html#with(org.apache.kafka.streams.state.DslStoreSuppliers)"/>
		/// </summary>
		/// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.State.DslStoreSuppliers"/></param>
		/// <returns><see cref="StreamJoined{K, V1, V2, TJVMK, TJVMV1, TJVMV2}"/></returns>
		public static StreamJoined<K, V1, V2, TJVMK, TJVMV1, TJVMV2> With(Org.Apache.Kafka.Streams.State.DslStoreSuppliers arg0)
		{
			var cons = Org.Apache.Kafka.Streams.Kstream.StreamJoined<TJVMK, TJVMV1, TJVMV2>.With(arg0);
			return new StreamJoined<K, V1, V2, TJVMK, TJVMV1, TJVMV2>(cons);
		}
		/// <summary>
		/// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/kstream/StreamJoined.html#with(org.apache.kafka.streams.state.WindowBytesStoreSupplier,org.apache.kafka.streams.state.WindowBytesStoreSupplier)"/>
		/// </summary>
		/// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.State.WindowBytesStoreSupplier"/></param>
		/// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.State.WindowBytesStoreSupplier"/></param>
		/// <returns><see cref="StreamJoined{K, V1, V2, TJVMK, TJVMV1, TJVMV2}"/></returns>
		public static StreamJoined<K, V1, V2, TJVMK, TJVMV1, TJVMV2> With(Org.Apache.Kafka.Streams.State.WindowBytesStoreSupplier arg0, Org.Apache.Kafka.Streams.State.WindowBytesStoreSupplier arg1)
		{
			var cons = Org.Apache.Kafka.Streams.Kstream.StreamJoined<TJVMK, TJVMV1, TJVMV2>.With(arg0, arg1);
			return new StreamJoined<K, V1, V2, TJVMK, TJVMV1, TJVMV2>(cons);
		}

		#endregion

		#region Instance methods
		/// <summary>
		/// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/kstream/StreamJoined.html#withDslStoreSuppliers(org.apache.kafka.streams.state.DslStoreSuppliers)"/>
		/// </summary>
		/// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.State.DslStoreSuppliers"/></param>
		/// <returns><see cref="StreamJoined{K, V1, V2, TJVMK, TJVMV1, TJVMV2}"/></returns>
		public StreamJoined<K, V1, V2, TJVMK, TJVMV1, TJVMV2> WithDslStoreSuppliers(Org.Apache.Kafka.Streams.State.DslStoreSuppliers arg0)
		{
			CheckDisposed();
			_inner?.WithDslStoreSuppliers(arg0);
			return this;
		}
		/// <summary>
		/// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/kstream/StreamJoined.html#withKeySerde(org.apache.kafka.common.serialization.Serde)"/>
		/// </summary>
		/// <param name="arg0"><see cref="ISerDes{K, TJVMK}"/></param>
		/// <returns><see cref="StreamJoined{K, V1, V2, TJVMK, TJVMV1, TJVMV2}"/></returns>
		public StreamJoined<K, V1, V2, TJVMK, TJVMV1, TJVMV2> WithKeySerde(ISerDes<K, TJVMK> arg0)
		{
			CheckDisposed();
			_inner?.WithKeySerde(arg0.KafkaSerde);
			return this;
		}
		/// <summary>
		/// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/kstream/StreamJoined.html#withLoggingDisabled()"/>
		/// </summary>
		/// <returns><see cref="StreamJoined{K, V1, V2, TJVMK, TJVMV1, TJVMV2}"/></returns>
		public StreamJoined<K, V1, V2, TJVMK, TJVMV1, TJVMV2> WithLoggingDisabled()
		{
			CheckDisposed();
			_inner?.WithLoggingDisabled();
			return this;
		}
		/// <summary>
		/// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/kstream/StreamJoined.html#withLoggingEnabled(java.util.Map)"/>
		/// </summary>
		/// <param name="arg0"><see cref="Java.Util.Map"/></param>
		/// <returns><see cref="StreamJoined{K, V1, V2, TJVMK, TJVMV1, TJVMV2}"/></returns>
		public StreamJoined<K, V1, V2, TJVMK, TJVMV1, TJVMV2> WithLoggingEnabled(Java.Util.Map<Java.Lang.String, Java.Lang.String> arg0)
		{
			CheckDisposed();
			_inner?.WithLoggingEnabled(arg0);
			return this;
		}
		/// <summary>
		/// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/kstream/StreamJoined.html#withOtherStoreSupplier(org.apache.kafka.streams.state.WindowBytesStoreSupplier)"/>
		/// </summary>
		/// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.State.WindowBytesStoreSupplier"/></param>
		/// <returns><see cref="StreamJoined{K, V1, V2, TJVMK, TJVMV1, TJVMV2}"/></returns>
		public StreamJoined<K, V1, V2, TJVMK, TJVMV1, TJVMV2> WithOtherStoreSupplier(Org.Apache.Kafka.Streams.State.WindowBytesStoreSupplier arg0)
		{
			CheckDisposed();
			_inner?.WithOtherStoreSupplier(arg0);
			return this;
		}
		/// <summary>
		/// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/kstream/StreamJoined.html#withOtherValueSerde(org.apache.kafka.common.serialization.Serde)"/>
		/// </summary>
		/// <param name="arg0"><see cref="ISerDes{V2, TJVMV2}"/></param>
		/// <returns><see cref="StreamJoined{K, V1, V2, TJVMK, TJVMV1, TJVMV2}"/></returns>
		public StreamJoined<K, V1, V2, TJVMK, TJVMV1, TJVMV2> WithOtherValueSerde(ISerDes<V2, TJVMV2> arg0)
		{
			CheckDisposed();
			_inner?.WithOtherValueSerde(arg0.KafkaSerde);
			return this;
		}
		/// <summary>
		/// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/kstream/StreamJoined.html#withStoreName(java.lang.String)"/>
		/// </summary>
		/// <param name="arg0"><see cref="string"/></param>
		/// <returns><see cref="StreamJoined{K, V1, V2, TJVMK, TJVMV1, TJVMV2}"/></returns>
		public StreamJoined<K, V1, V2, TJVMK, TJVMV1, TJVMV2> WithStoreName(string arg0)
		{
			CheckDisposed();
			_inner?.WithStoreName(arg0);
			return this;
		}
		/// <summary>
		/// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/kstream/StreamJoined.html#withThisStoreSupplier(org.apache.kafka.streams.state.WindowBytesStoreSupplier)"/>
		/// </summary>
		/// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.State.WindowBytesStoreSupplier"/></param>
		/// <returns><see cref="StreamJoined{K, V1, V2, TJVMK, TJVMV1, TJVMV2}"/></returns>
		public StreamJoined<K, V1, V2, TJVMK, TJVMV1, TJVMV2> WithThisStoreSupplier(Org.Apache.Kafka.Streams.State.WindowBytesStoreSupplier arg0)
		{
			CheckDisposed();
			_inner?.WithThisStoreSupplier(arg0);
			return this;
		}
		/// <summary>
		/// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/kstream/StreamJoined.html#withValueSerde(org.apache.kafka.common.serialization.Serde)"/>
		/// </summary>
		/// <param name="arg0"><see cref="ISerDes{V1, TJVMV1}"/></param>
		/// <returns><see cref="StreamJoined{K, V1, V2, TJVMK, TJVMV1, TJVMV2}"/></returns>
		public StreamJoined<K, V1, V2, TJVMK, TJVMV1, TJVMV2> WithValueSerde(ISerDes<V1, TJVMV1> arg0)
		{
			CheckDisposed();
			_inner?.WithValueSerde(arg0.KafkaSerde);
			return this;
		}

		#endregion
	}
}
