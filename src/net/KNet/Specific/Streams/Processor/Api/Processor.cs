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
    /// <typeparam name="TJVMKIn">The JVM type of <typeparamref name="KIn"/></typeparam>
    /// <typeparam name="TJVMVIn">The JVM type of <typeparamref name="VIn"/></typeparam>
    /// <typeparam name="TJVMKOut">The JVM type of <typeparamref name="KOut"/></typeparam>
    /// <typeparam name="TJVMVOut">The JVM type of <typeparamref name="VOut"/></typeparam>
    public abstract class Processor<KIn, VIn, KOut, VOut, TJVMKIn, TJVMVIn, TJVMKOut, TJVMVOut> : Org.Apache.Kafka.Streams.Processor.Api.Processor<TJVMKIn, TJVMVIn, TJVMKOut, TJVMVOut>, IGenericSerDesFactoryApplier
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
        /// <see cref="ProcessorContext{KOut, VOut, TJVMKOut, TJVMVOut}"/> received from the init
        /// </summary>
        public abstract ProcessorContext<KOut, VOut, TJVMKOut, TJVMVOut> Context { get; }

        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.7.0/org/apache/kafka/streams/processor/api/Processor.html#process-org.apache.kafka.streams.processor.api.Record-"/>
        /// </summary>
        /// <remarks>If <see cref="OnProcess"/> has a value it takes precedence over corresponding class method</remarks>
        public new System.Action<Record<KIn, VIn, TJVMKIn, TJVMVIn>> OnProcess { get; set; } = null;

        /// <summary>
        /// KNet implementation of <see cref="Org.Apache.Kafka.Streams.Processor.Api.Processor{KIn, VIn, KOut, VOut}.Process(Org.Apache.Kafka.Streams.Processor.Api.Record{KIn, VIn})"/>
        /// </summary>
        /// <param name="arg0"><see cref="Record{KIn, VIn, TJVMKIn, TJVMVIn}"/></param>
        public virtual void Process(Record<KIn, VIn, TJVMKIn, TJVMVIn> arg0)
        {

        }

        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.7.0/org/apache/kafka/streams/processor/api/Processor.html#init-org.apache.kafka.streams.processor.api.ProcessorContext-"/>
        /// </summary>
        /// <remarks>If <see cref="OnInit"/> has a value it takes precedence over corresponding class method</remarks>
        public new System.Action<ProcessorContext<KOut, VOut, TJVMKOut, TJVMVOut>> OnInit { get; set; } = null;

        /// <summary>
        /// KNet implementation of <see cref="Org.Apache.Kafka.Streams.Processor.Api.Processor{TJVMKIn, TJVMVIn, TJVMKOut, TJVMVOut}.Init(Org.Apache.Kafka.Streams.Processor.Api.ProcessorContext{TJVMKOut, TJVMVOut})"/>
        /// </summary>
        /// <param name="arg0"><see cref="ProcessorContext{KOut, VOut, TJVMKOut, TJVMVOut}"/></param>
        public virtual void Init(ProcessorContext<KOut, VOut, TJVMKOut, TJVMVOut> arg0)
        {

        }
    }

    /// <summary>
    /// KNet extension of <see cref="Processor{KIn, VIn, KOut, VOut, TJVMKIn, TJVMVIn, TJVMKOut, TJVMVOut}"/>
    /// </summary>
    /// <typeparam name="KIn">The input key type</typeparam>
    /// <typeparam name="VIn">The input key type</typeparam>
    /// <typeparam name="KOut">The output key type</typeparam>
    /// <typeparam name="VOut">The output value type</typeparam>
    public class Processor<KIn, VIn, KOut, VOut> : Processor<KIn, VIn, KOut, VOut, byte[], byte[], byte[], byte[]>
    {
        ProcessorContext<KOut, VOut, byte[], byte[]> _processorContext = null;
        /// <inheritdoc/>
        public override ProcessorContext<KOut, VOut, byte[], byte[]> Context => _processorContext;
        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.7.0/org/apache/kafka/streams/processor/api/Processor.html#process-org.apache.kafka.streams.processor.api.Record-"/>
        /// </summary>
        /// <remarks>If <see cref="OnProcess"/> has a value it takes precedence over corresponding class method</remarks>
        public new System.Action<Record<KIn, VIn, byte[], byte[]>> OnProcess { get; set; } = null;

        /// <inheritdoc/>
        public sealed override void Process(Org.Apache.Kafka.Streams.Processor.Api.Record<byte[], byte[]> arg0)
        {
            var methodToExecute = OnProcess ?? Process;
            methodToExecute(new Record<KIn, VIn, byte[], byte[]>(Factory, arg0, Context.RecordMetadata));
        }

        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.7.0/org/apache/kafka/streams/processor/api/Processor.html#init-org.apache.kafka.streams.processor.api.ProcessorContext-"/>
        /// </summary>
        /// <remarks>If <see cref="OnInit"/> has a value it takes precedence over corresponding class method</remarks>
        public new System.Action<ProcessorContext<KOut, VOut, byte[], byte[]>> OnInit { get; set; } = null;

        /// <inheritdoc/>
        public sealed override void Init(Org.Apache.Kafka.Streams.Processor.Api.ProcessorContext<byte[], byte[]> arg0)
        {
            _processorContext = new ProcessorContext<KOut, VOut, byte[], byte[]>(arg0);

            var methodToExecute = OnInit ?? Init;
            methodToExecute(_processorContext);
        }
    }
}
