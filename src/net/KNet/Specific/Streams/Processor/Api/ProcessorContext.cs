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

using System;

namespace MASES.KNet.Streams.Processor.Api
{
    /// <summary>
    /// KNet implementation of <see cref="Org.Apache.Kafka.Streams.Processor.Api.ProcessorContext{TJVMKForward, TJVMVForward}"/>
    /// </summary>
    /// <typeparam name="KForward"></typeparam>
    /// <typeparam name="VForward"></typeparam>
    /// <typeparam name="TJVMKForward">The JVM type of <typeparamref name="KForward"/></typeparam>
    /// <typeparam name="TJVMVForward">The JVM type of <typeparamref name="VForward"/></typeparam>
    public class ProcessorContext<KForward, VForward, TJVMKForward, TJVMVForward>
    {
        internal ProcessorContext(Org.Apache.Kafka.Streams.Processor.Api.ProcessorContext<TJVMKForward, TJVMVForward> context)
        {
            _context = context;
        }

        readonly Org.Apache.Kafka.Streams.Processor.Api.ProcessorContext<TJVMKForward, TJVMVForward> _context;

        /// <summary>
        /// Converter from <see cref="ProcessorContext{KForward, VForward, TJVMKForward, TJVMVForward}"/> to <see cref="Org.Apache.Kafka.Streams.Processor.Api.ProcessorContext{KForward, VForward}"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.Processor.Api.ProcessorContext<TJVMKForward, TJVMVForward>(ProcessorContext<KForward, VForward, TJVMKForward, TJVMVForward> t) => t._context;

        #region ProcessorContext

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/processor/api/ProcessorContext.html#forward(org.apache.kafka.streams.processor.api.Record,java.lang.String)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Processor.Api.Record"/></param>
        /// <param name="arg1"><see cref="string"/></param>
        /// <typeparam name="K"><typeparamref name="KForward"/></typeparam>
        /// <typeparam name="V"><typeparamref name="VForward"/></typeparam>
        /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
        /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
        public void Forward<K, V, TJVMK, TJVMV>(Record<K, V, TJVMK, TJVMV> arg0, string arg1) where K : KForward where V : VForward where TJVMK : TJVMKForward where TJVMV : TJVMVForward
        {
            _context.Forward<TJVMK, TJVMV>(arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/processor/api/ProcessorContext.html#forward(org.apache.kafka.streams.processor.api.Record)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Processor.Api.Record"/></param>
        /// <typeparam name="K"><typeparamref name="KForward"/></typeparam>
        /// <typeparam name="V"><typeparamref name="VForward"/></typeparam>
        /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
        /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
        public void Forward<K, V, TJVMK, TJVMV>(Record<K, V, TJVMK, TJVMV> arg0) where K : KForward where V : VForward where TJVMK : TJVMKForward where TJVMV : TJVMVForward
        {
            _context.Forward<TJVMK, TJVMV>(arg0);
        }

        #endregion

        #region ProcessingContext

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/processor/api/ProcessingContext.html#getStateStore(java.lang.String)"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <typeparam name="S"><see cref="Org.Apache.Kafka.Streams.Processor.IStateStore"/></typeparam>
        /// <returns><typeparamref name="S"/></returns>
        public S GetStateStore<S>(string arg0) where S : Org.Apache.Kafka.Streams.Processor.IStateStore, new()
        {
            return _context.GetStateStore<S>(arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/processor/api/ProcessingContext.html#stateDir()"/>
        /// </summary>
        /// <returns><see cref="Java.Io.File"/></returns>
        public Java.Io.File StateDir => _context.StateDir();

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/processor/api/ProcessingContext.html#applicationId()"/>
        /// </summary>
        /// <returns><see cref="string"/></returns>
        public string ApplicationId => _context.ApplicationId();
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/processor/api/ProcessingContext.html#appConfigs()"/>
        /// </summary>
        /// <returns><see cref="Java.Util.Map"/></returns>
        public Java.Util.Map<Java.Lang.String, object> AppConfigs => _context.AppConfigs();
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/processor/api/ProcessingContext.html#appConfigsWithPrefix(java.lang.String)"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="Java.Util.Map"/></returns>
        public Java.Util.Map<Java.Lang.String, object> AppConfigsWithPrefix(string arg0)
        {
            return _context.AppConfigsWithPrefix(arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/processor/api/ProcessingContext.html#recordMetadata()"/>
        /// </summary>
        /// <returns><see cref="Java.Util.Optional"/></returns>
        public Org.Apache.Kafka.Streams.Processor.Api.RecordMetadata? RecordMetadata
        {
            get
            {
                var opt = _context.RecordMetadata();
                return opt.IsPresent() ? opt.Get() : null;
            }
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/processor/api/ProcessingContext.html#currentStreamTimeMs()"/>
        /// </summary>
        /// <returns><see cref="long"/></returns>
        public long CurrentStreamTimeMs => _context.CurrentStreamTimeMs();
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/processor/api/ProcessingContext.html#currentStreamTimeMs()"/>
        /// </summary>
        /// <returns><see cref="DateTime"/></returns>
        public DateTime CurrentStreamDateTime => DateTimeOffset.FromUnixTimeMilliseconds(_context.CurrentStreamTimeMs()).DateTime;
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/processor/api/ProcessingContext.html#currentSystemTimeMs()"/>
        /// </summary>
        /// <returns><see cref="long"/></returns>
        public long CurrentSystemTimeMs => _context.CurrentSystemTimeMs();
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/processor/api/ProcessingContext.html#currentSystemTimeMs()"/>
        /// </summary>
        /// <returns><see cref="DateTime"/></returns>
        public DateTime CurrentSystemDateTime => DateTimeOffset.FromUnixTimeMilliseconds(_context.CurrentSystemTimeMs()).DateTime;
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/processor/api/ProcessingContext.html#keySerde()"/>
        /// </summary>
        /// <returns><see cref="Org.Apache.Kafka.Common.Serialization.Serde"/></returns>
        public Org.Apache.Kafka.Common.Serialization.Serde<object> KeySerde => _context.KeySerde();
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/processor/api/ProcessingContext.html#valueSerde()"/>
        /// </summary>
        /// <returns><see cref="Org.Apache.Kafka.Common.Serialization.Serde"/></returns>
        public Org.Apache.Kafka.Common.Serialization.Serde<object> ValueSerde => _context.ValueSerde();
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/processor/api/ProcessingContext.html#schedule(java.time.Duration,org.apache.kafka.streams.processor.PunctuationType,org.apache.kafka.streams.processor.Punctuator)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Time.Duration"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Processor.PunctuationType"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Processor.Punctuator"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Processor.Cancellable"/></returns>
        public Org.Apache.Kafka.Streams.Processor.Cancellable Schedule(Java.Time.Duration arg0, Org.Apache.Kafka.Streams.Processor.PunctuationType arg1, Org.Apache.Kafka.Streams.Processor.Punctuator arg2)
        {
            return _context.Schedule(arg0, arg1, arg2);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/processor/api/ProcessingContext.html#taskId()"/>
        /// </summary>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Processor.TaskId"/></returns>
        public Org.Apache.Kafka.Streams.Processor.TaskId TaskId => _context.TaskId();
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/processor/api/ProcessingContext.html#metrics()"/>
        /// </summary>
        /// <returns><see cref="Org.Apache.Kafka.Streams.StreamsMetrics"/></returns>
        public Org.Apache.Kafka.Streams.StreamsMetrics Metrics => _context.Metrics();
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/processor/api/ProcessingContext.html#commit()"/>
        /// </summary>
        public void Commit() => _context.Commit();
        #endregion
    }
}
