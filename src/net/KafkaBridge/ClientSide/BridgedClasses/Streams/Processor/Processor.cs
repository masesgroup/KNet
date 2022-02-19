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

namespace MASES.KafkaBridge.Streams.Processor
{
    public interface IProcessor<K, V> : IJVMBridgeBase
    {
        void Init(ProcessorContext context);

        void Process(K key, V value);

        void Close();
    }

    public class Processor<K, V> : CLRListener, IProcessor<K, V>
    {
        /// <inheritdoc cref="CLRListener.ClassName"/>
        public sealed override string ClassName => "org.mases.kafkabridge.streams.processor.ProcessorImpl";

        readonly Action<ProcessorContext> executionFunctionInit = null;
        readonly Action<K, V> executionFunctionProcess = null;
        readonly Action executionFunctionClose = null;

        public virtual Action<ProcessorContext> OnInit { get { return executionFunctionInit; } }

        public virtual Action<K, V> OnProcess { get { return executionFunctionProcess; } }

        public virtual Action OnClose { get { return executionFunctionClose; } }

        public Processor(Action<ProcessorContext> init = null, Action<K, V> process = null, Action close = null, bool attachEventHandler = true)
        {
            if (init != null) executionFunctionInit = init;
            else executionFunctionInit = Init;

            if (process != null) executionFunctionProcess = process;
            else executionFunctionProcess = Process;

            if (close != null) executionFunctionClose = close;
            else executionFunctionClose = Close;

            if (attachEventHandler)
            {
                AddEventHandler("init", new EventHandler<CLRListenerEventArgs<CLREventData<ProcessorContext>>>(EventHandlerInit));
                AddEventHandler("process", new EventHandler<CLRListenerEventArgs<CLREventData<K>>>(EventHandlerProcess));
                AddEventHandler("close", new EventHandler<CLRListenerEventArgs<CLREventData>>(EventHandlerClose));
            }
        }

        void EventHandlerInit(object sender, CLRListenerEventArgs<CLREventData<ProcessorContext>> data)
        {
            OnInit(data.EventData.TypedEventData);
        }

        void EventHandlerProcess(object sender, CLRListenerEventArgs<CLREventData<K>> data)
        {
            OnProcess(data.EventData.TypedEventData, data.EventData.To<V>(0));
        }

        void EventHandlerClose(object sender, CLRListenerEventArgs<CLREventData> data)
        {
            OnClose();
        }

        public virtual void Init(ProcessorContext context)
        {

        }

        public virtual void Process(K key, V value)
        {
         
        }

        public virtual void Close()
        {

        }
    }
}
