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

using Java.Util;
using System;
using System.Threading;

namespace MASES.KNet.Streams.Processor.Api
{
    /// <summary>
    /// KNet implementation of <see cref="Org.Apache.Kafka.Streams.Processor.Api.ProcessorContext{TJVMKForward, TJVMVForward}"/>
    /// </summary>
    /// <typeparam name="KForward"></typeparam>
    /// <typeparam name="VForward"></typeparam>
    /// <typeparam name="TJVMKForward">The JVM type of <typeparamref name="KForward"/></typeparam>
    /// <typeparam name="TJVMVForward">The JVM type of <typeparamref name="VForward"/></typeparam>
    public class ProcessorContext<KForward, VForward, TJVMKForward, TJVMVForward> : IDisposable
    {
        readonly Org.Apache.Kafka.Streams.Processor.Api.ProcessorContext<TJVMKForward, TJVMVForward> _context;

        internal ProcessorContext(Org.Apache.Kafka.Streams.Processor.Api.ProcessorContext<TJVMKForward, TJVMVForward> context)
        {
            _context = context;
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
                _context?.Dispose();
            }
        }

        #endregion

        /// <summary>
        /// Converter from <see cref="ProcessorContext{KForward, VForward, TJVMKForward, TJVMVForward}"/> to <see cref="Org.Apache.Kafka.Streams.Processor.Api.ProcessorContext{KForward, VForward}"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.Processor.Api.ProcessorContext<TJVMKForward, TJVMVForward>(ProcessorContext<KForward, VForward, TJVMKForward, TJVMVForward> t) => t._context;

        #region ProcessorContext

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/processor/api/ProcessorContext.html#forward(org.apache.kafka.streams.processor.api.Record,java.lang.String)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Processor.Api.Record"/></param>
        /// <param name="arg1"><see cref="string"/></param>
        /// <typeparam name="K"><typeparamref name="KForward"/></typeparam>
        /// <typeparam name="V"><typeparamref name="VForward"/></typeparam>
        /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
        /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
        public void Forward<K, V, TJVMK, TJVMV>(Record<K, V, TJVMK, TJVMV> arg0, string arg1) where K : KForward where V : VForward where TJVMK : TJVMKForward where TJVMV : TJVMVForward
        {
            CheckDisposed();
            using Java.Lang.String jString = arg1;
            _context.Forward<TJVMK, TJVMV>(arg0, jString);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/processor/api/ProcessorContext.html#forward(org.apache.kafka.streams.processor.api.Record)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Processor.Api.Record"/></param>
        /// <typeparam name="K"><typeparamref name="KForward"/></typeparam>
        /// <typeparam name="V"><typeparamref name="VForward"/></typeparam>
        /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
        /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
        public void Forward<K, V, TJVMK, TJVMV>(Record<K, V, TJVMK, TJVMV> arg0) where K : KForward where V : VForward where TJVMK : TJVMKForward where TJVMV : TJVMVForward
        {
            CheckDisposed();
            _context.Forward<TJVMK, TJVMV>(arg0);
        }

        #endregion

        #region ProcessingContext

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/processor/api/ProcessingContext.html#getStateStore(java.lang.String)"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <typeparam name="S"><see cref="Org.Apache.Kafka.Streams.Processor.IStateStore"/></typeparam>
        /// <returns><typeparamref name="S"/></returns>
        public S GetStateStore<S>(string arg0) where S : Org.Apache.Kafka.Streams.Processor.IStateStore
        {
            CheckDisposed();
            using Java.Lang.String jString = arg0;
            return _context.GetStateStore<S>(jString);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/processor/api/ProcessingContext.html#stateDir()"/>
        /// </summary>
        /// <returns><see cref="Java.Io.File"/></returns>
        public Java.Io.File StateDir { get { CheckDisposed(); return _context.StateDir(); } }

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/processor/api/ProcessingContext.html#applicationId()"/>
        /// </summary>
        /// <returns><see cref="string"/></returns>
        public string ApplicationId { get { CheckDisposed(); using var appId = _context.ApplicationId(); return appId; } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/processor/api/ProcessingContext.html#appConfigs()"/>
        /// </summary>
        /// <returns><see cref="Java.Util.Map"/></returns>
        public Java.Util.Map<Java.Lang.String, object> AppConfigs { get { CheckDisposed(); return _context.AppConfigs(); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/processor/api/ProcessingContext.html#appConfigsWithPrefix(java.lang.String)"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="Java.Util.Map"/></returns>
        public Java.Util.Map<Java.Lang.String, object> AppConfigsWithPrefix(string arg0)
        {
            CheckDisposed();
            using Java.Lang.String jString = arg0;
            using var appConfigs = _context.AppConfigsWithPrefix(jString);
            return appConfigs;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/processor/api/ProcessingContext.html#recordMetadata()"/>
        /// </summary>
        /// <returns><see cref="Java.Util.Optional"/></returns>
        public Org.Apache.Kafka.Streams.Processor.Api.RecordMetadata RecordMetadata
        {
            get
            {
                CheckDisposed();
                var opt = _context.RecordMetadata();
                return opt.IsPresent() ? opt.Get() : null;
            }
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/processor/api/ProcessingContext.html#currentStreamTimeMs()"/>
        /// </summary>
        /// <returns><see cref="long"/></returns>
        public long CurrentStreamTimeMs { get { CheckDisposed(); return _context.CurrentStreamTimeMs(); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/processor/api/ProcessingContext.html#currentStreamTimeMs()"/>
        /// </summary>
        /// <returns><see cref="DateTime"/></returns>
        public DateTime CurrentStreamDateTime { get { CheckDisposed(); return DateTimeOffset.FromUnixTimeMilliseconds(_context.CurrentStreamTimeMs()).DateTime; } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/processor/api/ProcessingContext.html#currentSystemTimeMs()"/>
        /// </summary>
        /// <returns><see cref="long"/></returns>
        public long CurrentSystemTimeMs { get { CheckDisposed(); return _context.CurrentSystemTimeMs(); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/processor/api/ProcessingContext.html#currentSystemTimeMs()"/>
        /// </summary>
        /// <returns><see cref="DateTime"/></returns>
        public DateTime CurrentSystemDateTime { get { CheckDisposed(); return DateTimeOffset.FromUnixTimeMilliseconds(_context.CurrentSystemTimeMs()).DateTime; } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/processor/api/ProcessingContext.html#keySerde()"/>
        /// </summary>
        /// <returns><see cref="Org.Apache.Kafka.Common.Serialization.Serde"/></returns>
        public Org.Apache.Kafka.Common.Serialization.Serde<object> KeySerde { get { CheckDisposed(); return _context.KeySerde(); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/processor/api/ProcessingContext.html#valueSerde()"/>
        /// </summary>
        /// <returns><see cref="Org.Apache.Kafka.Common.Serialization.Serde"/></returns>
        public Org.Apache.Kafka.Common.Serialization.Serde<object> ValueSerde { get { CheckDisposed(); return _context.ValueSerde(); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/processor/api/ProcessingContext.html#schedule(java.time.Duration,org.apache.kafka.streams.processor.PunctuationType,org.apache.kafka.streams.processor.Punctuator)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Time.Duration"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Processor.PunctuationType"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Processor.Punctuator"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Processor.Cancellable"/></returns>
        public Org.Apache.Kafka.Streams.Processor.Cancellable Schedule(Java.Time.Duration arg0, Org.Apache.Kafka.Streams.Processor.PunctuationType arg1, Org.Apache.Kafka.Streams.Processor.Punctuator arg2)
        {
            CheckDisposed();
            return _context.Schedule(arg0, arg1, arg2);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/processor/api/ProcessingContext.html#taskId()"/>
        /// </summary>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Processor.TaskId"/></returns>
        public Org.Apache.Kafka.Streams.Processor.TaskId TaskId { get { CheckDisposed(); return _context.TaskId(); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/processor/api/ProcessingContext.html#metrics()"/>
        /// </summary>
        /// <returns><see cref="Org.Apache.Kafka.Streams.StreamsMetrics"/></returns>
        public Org.Apache.Kafka.Streams.StreamsMetrics Metrics { get { CheckDisposed(); return _context.Metrics(); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/processor/api/ProcessingContext.html#commit()"/>
        /// </summary>
        public void Commit() { CheckDisposed(); _context.Commit(); }
        #endregion
    }
}
