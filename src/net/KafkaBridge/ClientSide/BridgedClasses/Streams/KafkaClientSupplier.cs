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
using MASES.KafkaBridge.Clients.Consumer;
using MASES.KafkaBridge.Clients.Producer;
using Java.Util;
using System;

namespace MASES.KafkaBridge.Streams.Processor
{
    /// <summary>
    /// Listener for Kafka KafkaClientSupplier. Extends <see cref="IJVMBridgeBase"/>
    /// </summary>
    public interface IKafkaClientSupplier : IJVMBridgeBase
    {
        Clients.Admin.IAdmin GetAdmin(Map<string, object> config);

        IProducer<byte[], byte[]> GetProducer(Map<string, object> config);

        IConsumer<byte[], byte[]> GetConsumer(Map<string, object> config);

        IConsumer<byte[], byte[]> GetRestoreConsumer(Map<string, object> config);

        IConsumer<byte[], byte[]> GetGlobalConsumer(Map<string, object> config);
    }

    /// <summary>
    /// Listener for Kafka KafkaClientSupplier. Extends <see cref="JVMBridgeListener"/>, implements <see cref="IKafkaClientSupplier"/>
    /// </summary>
    /// <remarks>Remember to Dispose the object otherwise there is a resource leak, the object contains a reference to the the corresponding JVM object</remarks>
    public class KafkaClientSupplier : JVMBridgeListener, IKafkaClientSupplier
    {
        /// <inheritdoc cref="JVMBridgeListener.ClassName"/>
        public sealed override string ClassName => "org.mases.kafkabridge.streams.KafkaClientSupplierImpl";

        readonly Func<Map<string, object>, Clients.Admin.IAdmin> GetAdminFunction = null;
        readonly Func<Map<string, object>, IProducer<byte[], byte[]>> GetProducerFunction = null;
        readonly Func<Map<string, object>, IConsumer<byte[], byte[]>> GetConsumerFunction = null;
        readonly Func<Map<string, object>, IConsumer<byte[], byte[]>> GetRestoreConsumerFunction = null;
        readonly Func<Map<string, object>, IConsumer<byte[], byte[]>> GetGlobalConsumerFunction = null;
        /// <summary>
        /// The <see cref="Func{Map{string, object}, Clients.Admin.Admin}"/> to be executed
        /// </summary>
        public virtual Func<Map<string, object>, Clients.Admin.IAdmin> OnGetAdmin { get { return GetAdminFunction; } }
        /// <summary>
        /// The <see cref="Func{Map{string, object}, IProducer{byte[], byte[]}}"/> to be executed
        /// </summary>
        public virtual Func<Map<string, object>, IProducer<byte[], byte[]>> OnGetProducer { get { return GetProducerFunction; } }
        /// <summary>
        /// The <see cref="Func{Map{string, object}, IConsumer{byte[], byte[]}}"/> to be executed
        /// </summary>
        public virtual Func<Map<string, object>, IConsumer<byte[], byte[]>> OnGetConsumer { get { return GetConsumerFunction; } }
        /// <summary>
        /// The <see cref="Func{Map{string, object}, IConsumer{byte[], byte[]}}"/> to be executed
        /// </summary>
        public virtual Func<Map<string, object>, IConsumer<byte[], byte[]>> OnGetRestoreConsumer { get { return GetRestoreConsumerFunction; } }
        /// <summary>
        /// The <see cref="Func{Map{string, object}, IConsumer{byte[], byte[]}}"/> to be executed
        /// </summary>
        public virtual Func<Map<string, object>, IConsumer<byte[], byte[]>> OnGetGlobalConsumer { get { return GetGlobalConsumerFunction; } }

        /// <summary>
        /// Initialize a new instance of <see cref="KafkaClientSupplier"/>
        /// </summary>
        /// <param name="onGetAdmin">The <see cref="Func{Map{string, object}, Clients.Admin.Admin}"/> to be executed</param>
        /// <param name="onGetProducer">The <see cref="Func{Map{string, object}, IProducer{byte[], byte[]}}"/> to be executed</param>
        /// <param name="onGetConsumer">The <see cref="Func{Map{string, object}, IConsumer{byte[], byte[]}}"/> to be executed</param>
        /// <param name="onGetRestoreConsumer">The <see cref="Func{Map{string, object}, IConsumer{byte[], byte[]}}"/> to be executed</param>
        /// <param name="onGetGlobalConsumer">The <see cref="Func{Map{string, object}, IConsumer{byte[], byte[]}}"/> to be executed</param>
        /// <param name="attachEventHandler">Set to false to disable attach of <see cref="EventHandler"/> and set an own one</param>
        public KafkaClientSupplier(Func<Map<string, object>, Clients.Admin.IAdmin> onGetAdmin = null,
                                       Func<Map<string, object>, IProducer<byte[], byte[]>> onGetProducer = null,
                                       Func<Map<string, object>, IConsumer<byte[], byte[]>> onGetConsumer = null,
                                       Func<Map<string, object>, IConsumer<byte[], byte[]>> onGetRestoreConsumer = null,
                                       Func<Map<string, object>, IConsumer<byte[], byte[]>> onGetGlobalConsumer = null,
                                       bool attachEventHandler = true)
        {
            if (onGetAdmin != null) GetAdminFunction = onGetAdmin;
            else GetAdminFunction = GetAdmin;

            if (onGetProducer != null) GetProducerFunction = onGetProducer;
            else GetProducerFunction = GetProducer;

            if (onGetConsumer != null) GetConsumerFunction = onGetConsumer;
            else GetConsumerFunction = GetConsumer;

            if (onGetRestoreConsumer != null) GetRestoreConsumerFunction = onGetRestoreConsumer;
            else GetRestoreConsumerFunction = GetRestoreConsumer;

            if (onGetGlobalConsumer != null) GetGlobalConsumerFunction = onGetGlobalConsumer;
            else GetGlobalConsumerFunction = GetGlobalConsumer;

            if (attachEventHandler)
            {
                AddEventHandler("getAdmin", new EventHandler<CLRListenerEventArgs<CLREventData<Map<string, object>>>>(EventHandler_getAdmin));
                AddEventHandler("getProducer", new EventHandler<CLRListenerEventArgs<CLREventData<Map<string, object>>>>(EventHandler_getProducer));
                AddEventHandler("getConsumer", new EventHandler<CLRListenerEventArgs<CLREventData<Map<string, object>>>>(EventHandler_getConsumer));
                AddEventHandler("getRestoreConsumer", new EventHandler<CLRListenerEventArgs<CLREventData<Map<string, object>>>>(EventHandler_getRestoreConsumer));
                AddEventHandler("getGlobalConsumer", new EventHandler<CLRListenerEventArgs<CLREventData<Map<string, object>>>>(EventHandler_getGlobalConsumer));
            }
        }

        void EventHandler_getAdmin(object sender, CLRListenerEventArgs<CLREventData<Map<string, object>>> data)
        {
            var retVal = OnGetAdmin(data.EventData.TypedEventData);
            data.SetReturnValue(retVal);
        }

        void EventHandler_getProducer(object sender, CLRListenerEventArgs<CLREventData<Map<string, object>>> data)
        {
            var retVal = OnGetProducer(data.EventData.TypedEventData);
            data.SetReturnValue(retVal);
        }

        void EventHandler_getConsumer(object sender, CLRListenerEventArgs<CLREventData<Map<string, object>>> data)
        {
            var retVal = OnGetConsumer(data.EventData.TypedEventData);
            data.SetReturnValue(retVal);
        }

        void EventHandler_getRestoreConsumer(object sender, CLRListenerEventArgs<CLREventData<Map<string, object>>> data)
        {
            var retVal = OnGetRestoreConsumer(data.EventData.TypedEventData);
            data.SetReturnValue(retVal);
        }

        void EventHandler_getGlobalConsumer(object sender, CLRListenerEventArgs<CLREventData<Map<string, object>>> data)
        {
            var retVal = OnGetGlobalConsumer(data.EventData.TypedEventData);
            data.SetReturnValue(retVal);
        }

        public virtual Clients.Admin.IAdmin GetAdmin(Map<string, object> config)
        {
            return null;
        }

        public virtual IProducer<byte[], byte[]> GetProducer(Map<string, object> config)
        {
            return null;
        }

        public virtual IConsumer<byte[], byte[]> GetConsumer(Map<string, object> config)
        {
            return null;
        }

        public virtual IConsumer<byte[], byte[]> GetRestoreConsumer(Map<string, object> config)
        {
            return null;
        }

        public virtual IConsumer<byte[], byte[]> GetGlobalConsumer(Map<string, object> config)
        {
            return null;
        }
    }
}
