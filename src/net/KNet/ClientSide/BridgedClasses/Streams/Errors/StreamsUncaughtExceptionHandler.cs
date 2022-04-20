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
using MASES.JCOBridge.C2JBridge.JVMInterop;
using System;

namespace MASES.KNet.Streams.Errors
{
    public enum StreamThreadExceptionResponse
    {
        REPLACE_THREAD = 0,
        SHUTDOWN_CLIENT = 1,
        SHUTDOWN_APPLICATION = 2
    }

    /// <summary>
    /// Listener for Kafka StreamsUncaughtExceptionHandler. Extends <see cref="IJVMBridgeBase"/>
    /// </summary>
    public interface IStreamsUncaughtExceptionHandler : IJVMBridgeBase
    {
        /// <summary>
        /// Executes the StreamsUncaughtExceptionHandler action in the CLR
        /// </summary>
        /// <param name="exception">The StreamsUncaughtExceptionHandler object</param>
        /// <returns>The <see cref="StreamThreadExceptionResponse"/> handle evaluation</returns>
        StreamThreadExceptionResponse Handle(JVMBridgeException exception);
    }

    /// <summary>
    /// Listener for Kafka StreamsUncaughtExceptionHandler. Extends <see cref="JVMBridgeListener"/>, implements <see cref="IStreamsUncaughtExceptionHandler"/>
    /// </summary>
    /// <remarks>Dispose the object to avoid a resource leak, the object contains a reference to the corresponding JVM object</remarks>
    public class StreamsUncaughtExceptionHandler : JVMBridgeListener, IStreamsUncaughtExceptionHandler
    {
        /// <inheritdoc cref="JVMBridgeListener.ClassName"/>
        public sealed override string ClassName => "org.mases.knet.streams.errors.StreamsUncaughtExceptionHandlerImpl";

        readonly Func<JVMBridgeException, StreamThreadExceptionResponse> executionFunction = null;
        /// <summary>
        /// The <see cref="Func{JVMBridgeException, StreamThreadExceptionResponse}"/> to be executed
        /// </summary>
        public virtual Func<JVMBridgeException, StreamThreadExceptionResponse> OnHandle { get { return executionFunction; } }
        /// <summary>
        /// Initialize a new instance of <see cref="StreamsUncaughtExceptionHandler"/>
        /// </summary>
        /// <param name="func">The <see cref="Func{JVMBridgeException, StreamThreadExceptionResponse}"/> to be executed</param>
        /// <param name="attachEventHandler">Set to false to disable attach of <see cref="EventHandler"/> and set an own one</param>
        public StreamsUncaughtExceptionHandler(Func<JVMBridgeException, StreamThreadExceptionResponse> func = null, bool attachEventHandler = true)
        {
            if (func != null) executionFunction = func;
            else executionFunction = Handle;
            if (attachEventHandler)
            {
                AddEventHandler("handle", new EventHandler<CLRListenerEventArgs<CLREventData>>(EventHandler));
            }
        }

        void EventHandler(object sender, CLRListenerEventArgs<CLREventData> data)
        {
            var retVal = OnHandle(JVMBridgeException.New(data.EventData.EventData as IJavaObject));
            data.SetReturnValue(retVal.ToString());
        }
        /// <summary>
        /// Executes the StreamsUncaughtExceptionHandler action in the CLR
        /// </summary>
        /// <param name="exception">The StreamsUncaughtExceptionHandler object</param>
        /// <returns>The <see cref="StreamThreadExceptionResponse"/> handle evaluation</returns>
        public virtual StreamThreadExceptionResponse Handle(JVMBridgeException exception) { return StreamThreadExceptionResponse.SHUTDOWN_APPLICATION; }
    }
}
