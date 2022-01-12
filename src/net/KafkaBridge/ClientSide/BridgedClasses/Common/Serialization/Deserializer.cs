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
using MASES.KafkaBridge.Common.Header;
using System;

namespace MASES.KafkaBridge.Common.Serialization
{
    /// <summary>
    /// Listerner for Kafka Deserializer. Extends <see cref="CLRListener"/>
    /// </summary>
    /// <typeparam name="E">The data associated to the event</typeparam>
    /// <remarks>Remember to Dispose the object otherwise there is a resource leak, the object contains a reference to the the corresponding JVM object</remarks>
    public class Deserializer<E> : JCOBridge.C2JBridge.CLRListener
    {
        /// <inheritdoc cref="CLRListener.JniClass"/>
        public sealed override string JniClass => "org.mases.kafkabridge.clients.common.serialization.DeserializerImpl";

        readonly Func<string, byte[], E> deserialize = null;
        readonly Func<string, Headers, byte[], E> deserializeWithHeaders = null;
        /// <summary>
        /// The <see cref="Func{String, Byte[], E}"/> to be executed on deserialize
        /// </summary>
        public virtual Func<string, byte[], E> OnDeserialize { get { return deserialize; } }
        /// <summary>
        /// The <see cref="Func{String, Headers, Byte[], E}"/> to be executed on deserialize
        /// </summary>
        public virtual Func<string, Headers, byte[], E> OnDeserializeWithHeaders { get { return deserializeWithHeaders; } }
        /// <summary>
        /// Initialize a new instance of <see cref="Deserializer{E}"/>
        /// </summary>
        /// <param name="deserializeFun">The <see cref="Func{String, Byte[], E}"/> to be executed on deserialize</param>
        /// <param name="deserializeWithHeadersFun">The <see cref="Func{String, Headers, Byte[], E}"/> to be executed on deserialize</param>
        /// <param name="attachEventHandler">Set to false to disable attach of <see cref="EventHandler"/> and set an own one</param>
        public Deserializer(Func<string, byte[], E> deserializeFun = null, Func<string, Headers, byte[], E> deserializeWithHeadersFun = null, bool attachEventHandler = true)
        {
            if (deserializeFun != null) deserialize = deserializeFun;
            else deserialize = Deserialize;
            if (deserializeWithHeadersFun != null) deserializeWithHeaders = deserializeWithHeadersFun;
            else deserializeWithHeaders = DeserializeWithHeaders;
            if (attachEventHandler)
            {
                AddEventHandler("deserialize", new EventHandler<CLRListenerEventArgs<CLREventData<string>>>(EventHandler));
                AddEventHandler("deserializeWithHeaders", new EventHandler<CLRListenerEventArgs<CLREventData<string>>>(EventHandlerWithHeaders));
            }
        }

        void EventHandler(object sender, CLRListenerEventArgs<CLREventData<string>> data)
        {
            var container = data.EventData.ExtraData.Get(0) as IJavaObject; // it is a byte[]
            var array = container.ToArray() as IJavaArray;
            byte[] bytes = (byte[])array.ToPrimitive();
            var retVal = OnDeserialize(data.EventData.TypedEventData, bytes);
            data.CLRReturnValue = retVal;
        }

        void EventHandlerWithHeaders(object sender, CLRListenerEventArgs<CLREventData<string>> data)
        {
            var headers = data.EventData.ExtraData.Get(0) as IJavaObject; // it is a Headers
            var container = data.EventData.ExtraData.Get(1) as IJavaObject; // it is an IJavaObject
            var array = container.ToArray() as IJavaArray; // convert to an IJavaArray
            byte[] bytes = (byte[])array.ToPrimitive(); // extract the array
            var retVal = OnDeserializeWithHeaders(data.EventData.TypedEventData, JVMBridgeBase.New<Headers>(headers), bytes);
            data.CLRReturnValue = retVal;
        }

        /// <summary>
        /// Executes the Deserializer action in the CLR
        /// </summary>
        /// <param name="topic">topic associated with the data</param>
        /// <param name="data">serialized bytes; may be null; implementations are recommended to handle null by returning a value or null rather than throwing an exception</param>
        /// <returns>The deserialized <typeparamref name="E"/></returns>
        public virtual E Deserialize(string topic, byte[] data) { return default(E); }
        /// <summary>
        /// Executes the Deserializer action in the CLR
        /// </summary>
        /// <param name="topic">topic associated with the data</param>
        /// <param name="headers"><see cref="Headers"/> associated with the record; may be empty.</param>
        /// <param name="data">serialized bytes; may be null; implementations are recommended to handle null by returning a value or null rather than throwing an exception</param>
        /// <returns>The deserialized <typeparamref name="E"/></returns>
        public virtual E DeserializeWithHeaders(string topic, Headers headers, byte[] data) { return OnDeserialize(topic, data); }
    }

    /// <summary>
    /// Listerner for Kafka Serializer. Extends <see cref="JVMBridgeDeserializer{E}"/>
    /// </summary>
    /// <typeparam name="E">The data associated to the event as an <see cref="JVMBridgeBase"/> object</typeparam>
    /// <remarks>Remember to Dispose the object otherwise there is a resource leak, the object contains a reference to the the corresponding JVM object</remarks>
    public class JVMBridgeDeserializer<E> : Deserializer<E>
        where E : JVMBridgeBase, new()
    {
        /// <summary>
        /// Initialize a new instance of <see cref="JVMBridgeDeserializer{E}"/>
        /// </summary>
        /// <param name="deserializeFun">The <see cref="Func{String, Byte[], E}"/> to be executed on deserialize</param>
        /// <param name="deserializeWithHeadersFun">The <see cref="Func{String, Headers, Byte[], E}"/> to be executed on deserialize</param>
        public JVMBridgeDeserializer(Func<string, byte[], E> deserializeFun = null, Func<string, Headers, byte[], E> deserializeWithHeadersFun = null)
            : base(deserializeFun, deserializeWithHeadersFun, false)
        {
            AddEventHandler("deserialize", new EventHandler<CLRListenerEventArgs<CLREventData<string>>>(EventHandler));
            AddEventHandler("deserializeWithHeaders", new EventHandler<CLRListenerEventArgs<CLREventData<string>>>(EventHandlerWithHeaders));
        }

        void EventHandler(object sender, CLRListenerEventArgs<CLREventData<string>> data)
        {
            var array = data.EventData.ExtraData.Get(0) as IJavaArray; // it is a byte[]
            byte[] bytes = (byte[])array.ToPrimitive();
            var retVal = OnDeserialize(data.EventData.TypedEventData, bytes);
            data.CLRReturnValue = retVal?.Instance;
        }

        void EventHandlerWithHeaders(object sender, CLRListenerEventArgs<CLREventData<string>> data)
        {
            var headers = data.EventData.ExtraData.Get(0) as IJavaObject; // it is a Headers
            var array = data.EventData.ExtraData.Get(1) as IJavaArray; // it is a byte[]
            byte[] bytes = (byte[])array.ToPrimitive();
            var retVal = OnDeserializeWithHeaders(data.EventData.TypedEventData, JVMBridgeBase.New<Headers>(headers), bytes);
            data.CLRReturnValue = retVal?.Instance;
        }
    }
}
