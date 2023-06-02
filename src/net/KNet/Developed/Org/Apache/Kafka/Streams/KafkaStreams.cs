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
using MASES.JCOBridge.C2JBridge.JVMInterop;
using Org.Apache.Kafka.Common;
using Org.Apache.Kafka.Common.Serialization;
using Org.Apache.Kafka.Common.Utils;
using Java.Time;
using Java.Util;
using Org.Apache.Kafka.Streams.Errors;
using Org.Apache.Kafka.Streams.Processor;
using Org.Apache.Kafka.Streams.Query;
using Java.Lang;
using System;

namespace Org.Apache.Kafka.Streams
{
    public partial class KafkaStreams
    {
        public enum StateType
        {
            CREATED,            // 0
            REBALANCING,        // 1
            RUNNING,            // 2
            PENDING_SHUTDOWN,   // 3
            NOT_RUNNING,        // 4
            PENDING_ERROR,      // 5
            ERROR,              // 6
        }

        public interface IStateListener : IJVMBridgeBase
        {
            void OnChange(StateType newState, StateType oldState);
        }

        /// <summary>
        /// Listener for Kafka StateListener. Extends <see cref="JVMBridgeListener"/>, implements <see cref="IStateListener"/>
        /// </summary>
        /// <remarks>Dispose the object to avoid a resource leak, the object contains a reference to the corresponding JVM object</remarks>
        public partial class StateListener : IStateListener
        {
            /// <inheritdoc cref="JVMBridgeListener.ClassName"/>
            public sealed override string BridgeClassName => "org.mases.knet.streams.StateListenerImpl";

            readonly Action<StateType, StateType> executionFunction = null;
            /// <summary>
            /// The <see cref="Action{StateType, StateType}"/> to be executed
            /// </summary>
            public virtual Action<StateType, StateType> OnOnChange { get { return executionFunction; } }
            /// <summary>
            /// Initialize a new instance of <see cref="StateListener"/>
            /// </summary>
            /// <param name="func">The <see cref="Action{StateType, StateType}"/> to be executed</param>
            /// <param name="attachEventHandler">Set to false to disable attach of <see cref="EventHandler"/> and set an own one</param>
            public StateListener(Action<StateType, StateType> func = null, bool attachEventHandler = true)
            {
                if (func != null) executionFunction = func;
                else executionFunction = OnChange;

                if (attachEventHandler)
                {
                    AddEventHandler("onChange", new EventHandler<CLRListenerEventArgs<CLREventData<StateType>>>(EventHandler));
                }
            }

            void EventHandler(object sender, CLRListenerEventArgs<CLREventData<StateType>> data)
            {
                OnOnChange(data.EventData.TypedEventData, data.EventData.To<StateType>(0));
            }

            public virtual void OnChange(StateType newState, StateType oldState) { }
        }
    }
}

