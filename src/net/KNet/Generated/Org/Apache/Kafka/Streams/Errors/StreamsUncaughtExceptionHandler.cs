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

/*
*  This file is generated by MASES.JNetReflector (ver. 2.0.1.0)
*  using kafka-streams-3.5.0.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Streams.Errors
{
    #region IStreamsUncaughtExceptionHandler
    /// <summary>
    /// .NET interface for org.mases.knet.generated.org.apache.kafka.streams.errors.StreamsUncaughtExceptionHandler implementing <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.5.0/org/apache/kafka/streams/errors/StreamsUncaughtExceptionHandler.html"/>
    /// </summary>
    public partial interface IStreamsUncaughtExceptionHandler
    {
        #region Instance methods

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion

    #region StreamsUncaughtExceptionHandler
    public partial class StreamsUncaughtExceptionHandler : Org.Apache.Kafka.Streams.Errors.IStreamsUncaughtExceptionHandler
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields

        #endregion

        #region Static methods

        #endregion

        #region Instance methods
        /// <summary>
        /// Handlers initializer for <see cref="StreamsUncaughtExceptionHandler"/>
        /// </summary>
        protected virtual void InitializeHandlers()
        {
            AddEventHandler("handle", new System.EventHandler<CLRListenerEventArgs<CLREventData>>(HandleEventHandler)); OnHandle = Handle;

        }

        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.5.0/org/apache/kafka/streams/errors/StreamsUncaughtExceptionHandler.html#handle-java.lang.Throwable-"/>
        /// </summary>
        public System.Func<MASES.JCOBridge.C2JBridge.JVMBridgeException, Org.Apache.Kafka.Streams.Errors.StreamsUncaughtExceptionHandler.StreamThreadExceptionResponse> OnHandle { get; set; }

        void HandleEventHandler(object sender, CLRListenerEventArgs<CLREventData> data)
        {
            if (OnHandle != null)
            {
                var executionResult = OnHandle.Invoke(JVMBridgeException.New(data.EventData.EventData as MASES.JCOBridge.C2JBridge.JVMInterop.IJavaObject));
                data.SetReturnValue(executionResult);
            }
        }

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.5.0/org/apache/kafka/streams/errors/StreamsUncaughtExceptionHandler.html#handle-java.lang.Throwable-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.Throwable"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Errors.StreamsUncaughtExceptionHandler.StreamThreadExceptionResponse"/></returns>
        public virtual Org.Apache.Kafka.Streams.Errors.StreamsUncaughtExceptionHandler.StreamThreadExceptionResponse Handle(MASES.JCOBridge.C2JBridge.JVMBridgeException arg0)
        {
            return default;
        }

        #endregion

        #region Nested classes
        #region StreamThreadExceptionResponse
        public partial class StreamThreadExceptionResponse
        {
            #region Constructors

            #endregion

            #region Class/Interface conversion operators

            #endregion

            #region Fields
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.5.0/org/apache/kafka/streams/errors/StreamsUncaughtExceptionHandler.StreamThreadExceptionResponse.html#id"/>
            /// </summary>
            public int id { get { return IGetField<int>("id"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.5.0/org/apache/kafka/streams/errors/StreamsUncaughtExceptionHandler.StreamThreadExceptionResponse.html#name"/>
            /// </summary>
            public string name { get { return IGetField<string>("name"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.5.0/org/apache/kafka/streams/errors/StreamsUncaughtExceptionHandler.StreamThreadExceptionResponse.html#REPLACE_THREAD"/>
            /// </summary>
            public static Org.Apache.Kafka.Streams.Errors.StreamsUncaughtExceptionHandler.StreamThreadExceptionResponse REPLACE_THREAD { get { return SGetField<Org.Apache.Kafka.Streams.Errors.StreamsUncaughtExceptionHandler.StreamThreadExceptionResponse>(LocalBridgeClazz, "REPLACE_THREAD"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.5.0/org/apache/kafka/streams/errors/StreamsUncaughtExceptionHandler.StreamThreadExceptionResponse.html#SHUTDOWN_APPLICATION"/>
            /// </summary>
            public static Org.Apache.Kafka.Streams.Errors.StreamsUncaughtExceptionHandler.StreamThreadExceptionResponse SHUTDOWN_APPLICATION { get { return SGetField<Org.Apache.Kafka.Streams.Errors.StreamsUncaughtExceptionHandler.StreamThreadExceptionResponse>(LocalBridgeClazz, "SHUTDOWN_APPLICATION"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.5.0/org/apache/kafka/streams/errors/StreamsUncaughtExceptionHandler.StreamThreadExceptionResponse.html#SHUTDOWN_CLIENT"/>
            /// </summary>
            public static Org.Apache.Kafka.Streams.Errors.StreamsUncaughtExceptionHandler.StreamThreadExceptionResponse SHUTDOWN_CLIENT { get { return SGetField<Org.Apache.Kafka.Streams.Errors.StreamsUncaughtExceptionHandler.StreamThreadExceptionResponse>(LocalBridgeClazz, "SHUTDOWN_CLIENT"); } }

            #endregion

            #region Static methods
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.5.0/org/apache/kafka/streams/errors/StreamsUncaughtExceptionHandler.StreamThreadExceptionResponse.html#valueOf-java.lang.String-"/>
            /// </summary>
            /// <param name="arg0"><see cref="string"/></param>
            /// <returns><see cref="Org.Apache.Kafka.Streams.Errors.StreamsUncaughtExceptionHandler.StreamThreadExceptionResponse"/></returns>
            public static Org.Apache.Kafka.Streams.Errors.StreamsUncaughtExceptionHandler.StreamThreadExceptionResponse ValueOf(string arg0)
            {
                return SExecute<Org.Apache.Kafka.Streams.Errors.StreamsUncaughtExceptionHandler.StreamThreadExceptionResponse>(LocalBridgeClazz, "valueOf", arg0);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.5.0/org/apache/kafka/streams/errors/StreamsUncaughtExceptionHandler.StreamThreadExceptionResponse.html#values--"/>
            /// </summary>

            /// <returns><see cref="Org.Apache.Kafka.Streams.Errors.StreamsUncaughtExceptionHandler.StreamThreadExceptionResponse"/></returns>
            public static Org.Apache.Kafka.Streams.Errors.StreamsUncaughtExceptionHandler.StreamThreadExceptionResponse[] Values()
            {
                return SExecuteArray<Org.Apache.Kafka.Streams.Errors.StreamsUncaughtExceptionHandler.StreamThreadExceptionResponse>(LocalBridgeClazz, "values");
            }

            #endregion

            #region Instance methods

            #endregion

            #region Nested classes

            #endregion

            // TODO: complete the class
        }
        #endregion

    
        #endregion

        // TODO: complete the class
    }
    #endregion
}