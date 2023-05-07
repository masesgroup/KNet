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
using System;

namespace MASES.KNet.Streams.Processor.Api
{
    public interface IFixedKeyProcessor<KIn, VIn, VOut> : IJVMBridgeBase
    {
        void Init(FixedKeyProcessorContext<KIn, VOut> context);

        void Process(FixedKeyRecord<KIn, VIn> record);

        void Close();
    }

    public class FixedKeyProcessor<KIn, VIn, VOut> : JVMBridgeListener, IFixedKeyProcessor<KIn, VIn, VOut>
    {
        /// <inheritdoc cref="JVMBridgeListener.ClassName"/>
        public override string BridgeClassName => "org.apache.kafka.streams.processor.api.FixedKeyProcessorImpl";

        readonly Action<FixedKeyProcessorContext<KIn, VOut>> executionFunctionInit = null;
        readonly Action<FixedKeyRecord<KIn, VIn>> executionFunctionProcess = null;
        readonly Action executionFunctionClose = null;

        public virtual Action<FixedKeyProcessorContext<KIn, VOut>> OnInit { get { return executionFunctionInit; } }

        public virtual Action<FixedKeyRecord<KIn, VIn>> OnProcess { get { return executionFunctionProcess; } }

        public virtual Action OnClose { get { return executionFunctionClose; } }

        public FixedKeyProcessor(Action<FixedKeyProcessorContext<KIn, VOut>> init = null, Action<FixedKeyRecord<KIn, VIn>> process = null, Action close = null, bool attachEventHandler = true)
        {
            if (init != null) executionFunctionInit = init;
            else executionFunctionInit = Init;

            if (process != null) executionFunctionProcess = process;
            else executionFunctionProcess = Process;

            if (close != null) executionFunctionClose = close;
            else executionFunctionClose = Close;

            if (attachEventHandler)
            {
                AddEventHandler("init", new EventHandler<CLRListenerEventArgs<CLREventData<FixedKeyProcessorContext<KIn, VOut>>>>(EventHandlerInit));
                AddEventHandler("process", new EventHandler<CLRListenerEventArgs<CLREventData<FixedKeyRecord<KIn, VIn>>>>(EventHandlerProcess));
                AddEventHandler("close", new EventHandler<CLRListenerEventArgs<CLREventData>>(EventHandlerClose));
            }
        }

        void EventHandlerInit(object sender, CLRListenerEventArgs<CLREventData<FixedKeyProcessorContext<KIn, VOut>>> data)
        {
            OnInit(data.EventData.TypedEventData);
        }

        void EventHandlerProcess(object sender, CLRListenerEventArgs<CLREventData<FixedKeyRecord<KIn, VIn>>> data)
        {
            OnProcess(data.EventData.TypedEventData);
        }

        void EventHandlerClose(object sender, CLRListenerEventArgs<CLREventData> data)
        {
            OnClose();
        }

        public virtual void Init(FixedKeyProcessorContext<KIn, VOut> context)
        {

        }

        public virtual void Process(FixedKeyRecord<KIn, VIn> record)
        {

        }

        public virtual void Close()
        {

        }
    }
}
