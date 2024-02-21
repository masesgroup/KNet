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
using System;

namespace MASES.KNet.Streams.Processor.Api
{
    /// <summary>
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.Processor.Api.Processor{TJVMKIn, TJVMVIn, TJVMKOut, TJVMVOut}"/>
    /// </summary>
    /// <typeparam name="KIn">The input key type</typeparam>
    /// <typeparam name="VIn">The input key type</typeparam>
    /// <typeparam name="KOut">The output key type</typeparam>
    /// <typeparam name="VOut">The output value type</typeparam>
    public abstract class KNetProcessor<KIn, VIn, KOut, VOut, TJVMKIn, TJVMVIn, TJVMKOut, TJVMVOut> : Org.Apache.Kafka.Streams.Processor.Api.Processor<TJVMKIn, TJVMVIn, TJVMKOut, TJVMVOut>, IGenericSerDesFactoryApplier
    {
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
        /// <see cref="KNetProcessorContext{KOut, VOut}"/> received from the init
        /// </summary>
        public abstract KNetProcessorContext<KOut, VOut> Context { get; }

        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/processor/api/Processor.html#process-org.apache.kafka.streams.processor.api.Record-"/>
        /// </summary>
        /// <remarks>If <see cref="OnProcess"/> has a value it takes precedence over corresponding class method</remarks>
        public new System.Action<KNetRecord<KIn, VIn>> OnProcess { get; set; } = null;

        /// <summary>
        /// KNet implementation of <see cref="Org.Apache.Kafka.Streams.Processor.Api.Processor{KIn, VIn, KOut, VOut}.Process(Org.Apache.Kafka.Streams.Processor.Api.Record{KIn, VIn})"/>
        /// </summary>
        /// <param name="arg0"><see cref="KNetRecord{KIn, VIn}"/></param>
        public virtual void Process(KNetRecord<KIn, VIn> arg0)
        {

        }

        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/processor/api/Processor.html#init-org.apache.kafka.streams.processor.api.ProcessorContext-"/>
        /// </summary>
        /// <remarks>If <see cref="OnInit"/> has a value it takes precedence over corresponding class method</remarks>
        public new System.Action<KNetProcessorContext<KOut, VOut>> OnInit { get; set; } = null;

        /// <summary>
        /// KNet implementation of <see cref="Org.Apache.Kafka.Streams.Processor.Api.Processor{KIn, VIn, KOut, VOut}.Init(Org.Apache.Kafka.Streams.Processor.Api.ProcessorContext{KOut, VOut})"/>
        /// </summary>
        /// <param name="arg0"><see cref="KNetProcessorContext{KOut, VOut}"/></param>
        public virtual void Init(KNetProcessorContext<KOut, VOut> arg0)
        {

        }
    }

    /// <summary>
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.Processor.Api.Processor{KIn, VIn, KOut, VOut}"/>
    /// </summary>
    /// <typeparam name="KIn">The input key type</typeparam>
    /// <typeparam name="VIn">The input key type</typeparam>
    /// <typeparam name="KOut">The output key type</typeparam>
    /// <typeparam name="VOut">The output value type</typeparam>
    public class KNetProcessor<KIn, VIn, KOut, VOut> : KNetProcessor<KIn, VIn, KOut, VOut, byte[], byte[], byte[], byte[]>
    {
        KNetProcessorContext<KOut, VOut> _processorContext = null;
        /// <inheritdoc/>
        public override KNetProcessorContext<KOut, VOut> Context => _processorContext;
        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/processor/api/Processor.html#process-org.apache.kafka.streams.processor.api.Record-"/>
        /// </summary>
        /// <remarks>If <see cref="OnProcess"/> has a value it takes precedence over corresponding class method</remarks>
        public new System.Action<KNetRecord<KIn, VIn>> OnProcess { get; set; } = null;

        /// <inheritdoc/>
        public sealed override void Process(Org.Apache.Kafka.Streams.Processor.Api.Record<byte[], byte[]> arg0)
        {
            var methodToExecute = OnProcess ?? Process;
            methodToExecute(new KNetRecord<KIn, VIn>(Factory, arg0, Context.RecordMetadata));
        }

        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/processor/api/Processor.html#init-org.apache.kafka.streams.processor.api.ProcessorContext-"/>
        /// </summary>
        /// <remarks>If <see cref="OnInit"/> has a value it takes precedence over corresponding class method</remarks>
        public new System.Action<KNetProcessorContext<KOut, VOut>> OnInit { get; set; } = null;

        /// <inheritdoc/>
        public sealed override void Init(Org.Apache.Kafka.Streams.Processor.Api.ProcessorContext<byte[], byte[]> arg0)
        {
            _processorContext = new KNetProcessorContext<KOut, VOut>(arg0);

            var methodToExecute = OnInit ?? Init;
            methodToExecute(_processorContext);
        }
    }
}
