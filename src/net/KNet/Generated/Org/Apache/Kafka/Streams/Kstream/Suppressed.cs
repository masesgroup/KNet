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
*  This file is generated by MASES.JNetReflector (ver. 2.1.1.0)
*  using kafka-streams-3.6.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Streams.Kstream
{
    #region Suppressed
    public partial class Suppressed
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Suppressed.html#untilTimeLimit-java.time.Duration-org.apache.kafka.streams.kstream.Suppressed.BufferConfig-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Time.Duration"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.Suppressed.BufferConfig"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Suppressed"/></returns>
        public static Org.Apache.Kafka.Streams.Kstream.Suppressed UntilTimeLimit(Java.Time.Duration arg0, Org.Apache.Kafka.Streams.Kstream.Suppressed.BufferConfig arg1)
        {
            return SExecute<Org.Apache.Kafka.Streams.Kstream.Suppressed>(LocalBridgeClazz, "untilTimeLimit", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Suppressed.html#untilWindowCloses-org.apache.kafka.streams.kstream.Suppressed.StrictBufferConfig-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.Suppressed.StrictBufferConfig"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Suppressed"/></returns>
        public static Org.Apache.Kafka.Streams.Kstream.Suppressed UntilWindowCloses(Org.Apache.Kafka.Streams.Kstream.Suppressed.StrictBufferConfig arg0)
        {
            return SExecute<Org.Apache.Kafka.Streams.Kstream.Suppressed>(LocalBridgeClazz, "untilWindowCloses", arg0);
        }

        #endregion

        #region Instance methods

        #endregion

        #region Nested classes
        #region BufferConfig
        public partial class BufferConfig
        {
            #region Constructors

            #endregion

            #region Class/Interface conversion operators

            #endregion

            #region Fields

            #endregion

            #region Static methods
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Suppressed.BufferConfig.html#maxBytes-long-"/>
            /// </summary>
            /// <param name="arg0"><see cref="long"/></param>
            /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Suppressed.EagerBufferConfig"/></returns>
            public static Org.Apache.Kafka.Streams.Kstream.Suppressed.EagerBufferConfig MaxBytes(long arg0)
            {
                return SExecute<Org.Apache.Kafka.Streams.Kstream.Suppressed.EagerBufferConfig>(LocalBridgeClazz, "maxBytes", arg0);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Suppressed.BufferConfig.html#maxRecords-long-"/>
            /// </summary>
            /// <param name="arg0"><see cref="long"/></param>
            /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Suppressed.EagerBufferConfig"/></returns>
            public static Org.Apache.Kafka.Streams.Kstream.Suppressed.EagerBufferConfig MaxRecords(long arg0)
            {
                return SExecute<Org.Apache.Kafka.Streams.Kstream.Suppressed.EagerBufferConfig>(LocalBridgeClazz, "maxRecords", arg0);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Suppressed.BufferConfig.html#unbounded--"/>
            /// </summary>

            /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Suppressed.StrictBufferConfig"/></returns>
            public static Org.Apache.Kafka.Streams.Kstream.Suppressed.StrictBufferConfig Unbounded()
            {
                return SExecute<Org.Apache.Kafka.Streams.Kstream.Suppressed.StrictBufferConfig>(LocalBridgeClazz, "unbounded");
            }

            #endregion

            #region Instance methods
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Suppressed.BufferConfig.html#withLoggingDisabled--"/>
            /// </summary>

            /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Suppressed.BufferConfig"/></returns>
            public Org.Apache.Kafka.Streams.Kstream.Suppressed.BufferConfig WithLoggingDisabled()
            {
                return IExecute<Org.Apache.Kafka.Streams.Kstream.Suppressed.BufferConfig>("withLoggingDisabled");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Suppressed.BufferConfig.html#withLoggingEnabled-java.util.Map-"/>
            /// </summary>
            /// <param name="arg0"><see cref="Java.Util.Map"/></param>
            /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Suppressed.BufferConfig"/></returns>
            public Org.Apache.Kafka.Streams.Kstream.Suppressed.BufferConfig WithLoggingEnabled(Java.Util.Map arg0)
            {
                return IExecute<Org.Apache.Kafka.Streams.Kstream.Suppressed.BufferConfig>("withLoggingEnabled", arg0);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Suppressed.BufferConfig.html#withMaxBytes-long-"/>
            /// </summary>
            /// <param name="arg0"><see cref="long"/></param>
            /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Suppressed.BufferConfig"/></returns>
            public Org.Apache.Kafka.Streams.Kstream.Suppressed.BufferConfig WithMaxBytes(long arg0)
            {
                return IExecute<Org.Apache.Kafka.Streams.Kstream.Suppressed.BufferConfig>("withMaxBytes", arg0);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Suppressed.BufferConfig.html#withMaxRecords-long-"/>
            /// </summary>
            /// <param name="arg0"><see cref="long"/></param>
            /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Suppressed.BufferConfig"/></returns>
            public Org.Apache.Kafka.Streams.Kstream.Suppressed.BufferConfig WithMaxRecords(long arg0)
            {
                return IExecute<Org.Apache.Kafka.Streams.Kstream.Suppressed.BufferConfig>("withMaxRecords", arg0);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Suppressed.BufferConfig.html#emitEarlyWhenFull--"/>
            /// </summary>

            /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Suppressed.EagerBufferConfig"/></returns>
            public Org.Apache.Kafka.Streams.Kstream.Suppressed.EagerBufferConfig EmitEarlyWhenFull()
            {
                return IExecute<Org.Apache.Kafka.Streams.Kstream.Suppressed.EagerBufferConfig>("emitEarlyWhenFull");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Suppressed.BufferConfig.html#shutDownWhenFull--"/>
            /// </summary>

            /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Suppressed.StrictBufferConfig"/></returns>
            public Org.Apache.Kafka.Streams.Kstream.Suppressed.StrictBufferConfig ShutDownWhenFull()
            {
                return IExecute<Org.Apache.Kafka.Streams.Kstream.Suppressed.StrictBufferConfig>("shutDownWhenFull");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Suppressed.BufferConfig.html#withNoBound--"/>
            /// </summary>

            /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Suppressed.StrictBufferConfig"/></returns>
            public Org.Apache.Kafka.Streams.Kstream.Suppressed.StrictBufferConfig WithNoBound()
            {
                return IExecute<Org.Apache.Kafka.Streams.Kstream.Suppressed.StrictBufferConfig>("withNoBound");
            }

            #endregion

            #region Nested classes

            #endregion

            // TODO: complete the class
        }
        #endregion

        #region BufferConfig<BC>
        public partial class BufferConfig<BC>
        {
            #region Constructors

            #endregion

            #region Class/Interface conversion operators
            /// <summary>
            /// Converter from <see cref="Org.Apache.Kafka.Streams.Kstream.Suppressed.BufferConfig{BC}"/> to <see cref="Org.Apache.Kafka.Streams.Kstream.Suppressed.BufferConfig"/>
            /// </summary>
            public static implicit operator Org.Apache.Kafka.Streams.Kstream.Suppressed.BufferConfig(Org.Apache.Kafka.Streams.Kstream.Suppressed.BufferConfig<BC> t) => t.Cast<Org.Apache.Kafka.Streams.Kstream.Suppressed.BufferConfig>();

            #endregion

            #region Fields

            #endregion

            #region Static methods
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Suppressed.BufferConfig.html#maxBytes-long-"/>
            /// </summary>
            /// <param name="arg0"><see cref="long"/></param>
            /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Suppressed.EagerBufferConfig"/></returns>
            public static Org.Apache.Kafka.Streams.Kstream.Suppressed.EagerBufferConfig MaxBytes(long arg0)
            {
                return SExecute<Org.Apache.Kafka.Streams.Kstream.Suppressed.EagerBufferConfig>(LocalBridgeClazz, "maxBytes", arg0);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Suppressed.BufferConfig.html#maxRecords-long-"/>
            /// </summary>
            /// <param name="arg0"><see cref="long"/></param>
            /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Suppressed.EagerBufferConfig"/></returns>
            public static Org.Apache.Kafka.Streams.Kstream.Suppressed.EagerBufferConfig MaxRecords(long arg0)
            {
                return SExecute<Org.Apache.Kafka.Streams.Kstream.Suppressed.EagerBufferConfig>(LocalBridgeClazz, "maxRecords", arg0);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Suppressed.BufferConfig.html#unbounded--"/>
            /// </summary>

            /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Suppressed.StrictBufferConfig"/></returns>
            public static Org.Apache.Kafka.Streams.Kstream.Suppressed.StrictBufferConfig Unbounded()
            {
                return SExecute<Org.Apache.Kafka.Streams.Kstream.Suppressed.StrictBufferConfig>(LocalBridgeClazz, "unbounded");
            }

            #endregion

            #region Instance methods
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Suppressed.BufferConfig.html#withLoggingDisabled--"/>
            /// </summary>

            /// <returns><typeparamref name="BC"/></returns>
            public BC WithLoggingDisabled()
            {
                return IExecute<BC>("withLoggingDisabled");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Suppressed.BufferConfig.html#withLoggingEnabled-java.util.Map-"/>
            /// </summary>
            /// <param name="arg0"><see cref="Java.Util.Map"/></param>
            /// <returns><typeparamref name="BC"/></returns>
            public BC WithLoggingEnabled(Java.Util.Map<string, string> arg0)
            {
                return IExecute<BC>("withLoggingEnabled", arg0);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Suppressed.BufferConfig.html#withMaxBytes-long-"/>
            /// </summary>
            /// <param name="arg0"><see cref="long"/></param>
            /// <returns><typeparamref name="BC"/></returns>
            public BC WithMaxBytes(long arg0)
            {
                return IExecute<BC>("withMaxBytes", arg0);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Suppressed.BufferConfig.html#withMaxRecords-long-"/>
            /// </summary>
            /// <param name="arg0"><see cref="long"/></param>
            /// <returns><typeparamref name="BC"/></returns>
            public BC WithMaxRecords(long arg0)
            {
                return IExecute<BC>("withMaxRecords", arg0);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Suppressed.BufferConfig.html#emitEarlyWhenFull--"/>
            /// </summary>

            /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Suppressed.EagerBufferConfig"/></returns>
            public Org.Apache.Kafka.Streams.Kstream.Suppressed.EagerBufferConfig EmitEarlyWhenFull()
            {
                return IExecute<Org.Apache.Kafka.Streams.Kstream.Suppressed.EagerBufferConfig>("emitEarlyWhenFull");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Suppressed.BufferConfig.html#shutDownWhenFull--"/>
            /// </summary>

            /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Suppressed.StrictBufferConfig"/></returns>
            public Org.Apache.Kafka.Streams.Kstream.Suppressed.StrictBufferConfig ShutDownWhenFull()
            {
                return IExecute<Org.Apache.Kafka.Streams.Kstream.Suppressed.StrictBufferConfig>("shutDownWhenFull");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Suppressed.BufferConfig.html#withNoBound--"/>
            /// </summary>

            /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Suppressed.StrictBufferConfig"/></returns>
            public Org.Apache.Kafka.Streams.Kstream.Suppressed.StrictBufferConfig WithNoBound()
            {
                return IExecute<Org.Apache.Kafka.Streams.Kstream.Suppressed.StrictBufferConfig>("withNoBound");
            }

            #endregion

            #region Nested classes

            #endregion

            // TODO: complete the class
        }
        #endregion

        #region EagerBufferConfig
        public partial class EagerBufferConfig
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

            #endregion

            #region Nested classes

            #endregion

            // TODO: complete the class
        }
        #endregion

        #region StrictBufferConfig
        public partial class StrictBufferConfig
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

    #region ISuppressed<K>
    /// <summary>
    /// .NET interface for TO BE DEFINED FROM USER
    /// </summary>
    public partial interface ISuppressed<K>
    {
        #region Instance methods

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion

    #region Suppressed<K>
    public partial class Suppressed<K> : Org.Apache.Kafka.Streams.Kstream.ISuppressed<K>
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators
        /// <summary>
        /// Converter from <see cref="Org.Apache.Kafka.Streams.Kstream.Suppressed{K}"/> to <see cref="Org.Apache.Kafka.Streams.Kstream.Suppressed"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.Kstream.Suppressed(Org.Apache.Kafka.Streams.Kstream.Suppressed<K> t) => t.Cast<Org.Apache.Kafka.Streams.Kstream.Suppressed>();

        #endregion

        #region Fields

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Suppressed.html#untilTimeLimit-java.time.Duration-org.apache.kafka.streams.kstream.Suppressed.BufferConfig-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Time.Duration"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.Suppressed.BufferConfig"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Suppressed"/></returns>
        public static Org.Apache.Kafka.Streams.Kstream.Suppressed<K> UntilTimeLimit(Java.Time.Duration arg0, Org.Apache.Kafka.Streams.Kstream.Suppressed.BufferConfig arg1)
        {
            return SExecute<Org.Apache.Kafka.Streams.Kstream.Suppressed<K>>(LocalBridgeClazz, "untilTimeLimit", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Suppressed.html#untilWindowCloses-org.apache.kafka.streams.kstream.Suppressed.StrictBufferConfig-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.Suppressed.StrictBufferConfig"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Suppressed"/></returns>
        public static Org.Apache.Kafka.Streams.Kstream.Suppressed<Org.Apache.Kafka.Streams.Kstream.Windowed> UntilWindowCloses(Org.Apache.Kafka.Streams.Kstream.Suppressed.StrictBufferConfig arg0)
        {
            return SExecute<Org.Apache.Kafka.Streams.Kstream.Suppressed<Org.Apache.Kafka.Streams.Kstream.Windowed>>(LocalBridgeClazz, "untilWindowCloses", arg0);
        }

        #endregion

        #region Instance methods

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}