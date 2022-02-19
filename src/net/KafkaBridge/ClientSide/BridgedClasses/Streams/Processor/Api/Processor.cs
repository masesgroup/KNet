/*
*  Copyright 2022 MASES s.r.l.
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
using System;

namespace MASES.KafkaBridge.Streams.Processor.Api
{
    public interface IProcessor<KIn, VIn, KOut, VOut> : IJVMBridgeBase
    {
        void Init(ProcessorContext<KOut, VOut> context);

        void Process(Record<KIn, VIn> record);

        void Close();
    }

    public class Processor<KIn, VIn, KOut, VOut> : CLRListener, IProcessor<KIn, VIn, KOut, VOut>
    {
        /// <inheritdoc cref="CLRListener.ClassName"/>
        public sealed override string ClassName => "org.apache.kafka.streams.processor.api.ProcessorImpl";

        readonly Action<ProcessorContext<KOut, VOut>> executionFunctionInit = null;
        readonly Action<Record<KIn, VIn>> executionFunctionProcess = null;
        readonly Action executionFunctionClose = null;

        public virtual Action<ProcessorContext<KOut, VOut>> OnInit { get { return executionFunctionInit; } }

        public virtual Action<Record<KIn, VIn>> OnProcess { get { return executionFunctionProcess; } }

        public virtual Action OnClose { get { return executionFunctionClose; } }

        public Processor(Action<ProcessorContext<KOut, VOut>> init = null, Action<Record<KIn, VIn>> process = null, Action close = null, bool attachEventHandler = true)
        {
            if (init != null) executionFunctionInit = init;
            else executionFunctionInit = Init;

            if (process != null) executionFunctionProcess = process;
            else executionFunctionProcess = Process;

            if (close != null) executionFunctionClose = close;
            else executionFunctionClose = Close;

            if (attachEventHandler)
            {
                AddEventHandler("init", new EventHandler<CLRListenerEventArgs<CLREventData<ProcessorContext<KOut, VOut>>>>(EventHandlerInit));
                AddEventHandler("process", new EventHandler<CLRListenerEventArgs<CLREventData<Record<KIn, VIn>>>>(EventHandlerProcess));
                AddEventHandler("close", new EventHandler<CLRListenerEventArgs<CLREventData>>(EventHandlerClose));
            }
        }

        void EventHandlerInit(object sender, CLRListenerEventArgs<CLREventData<ProcessorContext<KOut, VOut>>> data)
        {
            OnInit(data.EventData.TypedEventData);
        }

        void EventHandlerProcess(object sender, CLRListenerEventArgs<CLREventData<Record<KIn, VIn>>> data)
        {
            OnProcess(data.EventData.TypedEventData, data.EventData.To<V>(0));
        }

        void EventHandlerClose(object sender, CLRListenerEventArgs<CLREventData> data)
        {
            OnClose();
        }

        public virtual void Init(ProcessorContext<KOut, VOut> context)
        {

        }

        public virtual void Process(Record<KIn, VIn> record)
        {

        }

        public virtual void Close()
        {

        }
    }
}
