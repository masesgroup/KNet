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
*  This file is generated by MASES.JNetReflector (ver. 2.1.0.0)
*  using kafka-streams-3.6.0.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Streams.Kstream
{
    #region WindowedSerdes
    public partial class WindowedSerdes
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.0/org/apache/kafka/streams/kstream/WindowedSerdes.html#sessionWindowedSerdeFrom-java.lang.Class-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.Class"/></param>
        /// <typeparam name="T"></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Common.Serialization.Serde"/></returns>
        public static Org.Apache.Kafka.Common.Serialization.Serde<Org.Apache.Kafka.Streams.Kstream.Windowed<T>> SessionWindowedSerdeFrom<T>(Java.Lang.Class arg0)
        {
            return SExecute<Org.Apache.Kafka.Common.Serialization.Serde<Org.Apache.Kafka.Streams.Kstream.Windowed<T>>>(LocalBridgeClazz, "sessionWindowedSerdeFrom", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.0/org/apache/kafka/streams/kstream/WindowedSerdes.html#timeWindowedSerdeFrom-java.lang.Class-long-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.Class"/></param>
        /// <param name="arg1"><see cref="long"/></param>
        /// <typeparam name="T"></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Common.Serialization.Serde"/></returns>
        public static Org.Apache.Kafka.Common.Serialization.Serde<Org.Apache.Kafka.Streams.Kstream.Windowed<T>> TimeWindowedSerdeFrom<T>(Java.Lang.Class arg0, long arg1)
        {
            return SExecute<Org.Apache.Kafka.Common.Serialization.Serde<Org.Apache.Kafka.Streams.Kstream.Windowed<T>>>(LocalBridgeClazz, "timeWindowedSerdeFrom", arg0, arg1);
        }

        #endregion

        #region Instance methods

        #endregion

        #region Nested classes
        #region SessionWindowedSerde
        public partial class SessionWindowedSerde
        {
            #region Constructors
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.0/org/apache/kafka/streams/kstream/WindowedSerdes.SessionWindowedSerde.html#org.apache.kafka.streams.kstream.WindowedSerdes$SessionWindowedSerde(org.apache.kafka.common.serialization.Serde)"/>
            /// </summary>
            /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Serialization.Serde"/></param>
            public SessionWindowedSerde(Org.Apache.Kafka.Common.Serialization.Serde arg0)
                : base(arg0)
            {
            }

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

        #region SessionWindowedSerde<T>
        public partial class SessionWindowedSerde<T>
        {
            #region Constructors
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.0/org/apache/kafka/streams/kstream/WindowedSerdes.SessionWindowedSerde.html#org.apache.kafka.streams.kstream.WindowedSerdes$SessionWindowedSerde(org.apache.kafka.common.serialization.Serde)"/>
            /// </summary>
            /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Serialization.Serde"/></param>
            public SessionWindowedSerde(Org.Apache.Kafka.Common.Serialization.Serde<T> arg0)
                : base(arg0)
            {
            }

            #endregion

            #region Class/Interface conversion operators
            /// <summary>
            /// Converter from <see cref="Org.Apache.Kafka.Streams.Kstream.WindowedSerdes.SessionWindowedSerde{T}"/> to <see cref="Org.Apache.Kafka.Streams.Kstream.WindowedSerdes.SessionWindowedSerde"/>
            /// </summary>
            public static implicit operator Org.Apache.Kafka.Streams.Kstream.WindowedSerdes.SessionWindowedSerde(Org.Apache.Kafka.Streams.Kstream.WindowedSerdes.SessionWindowedSerde<T> t) => t.Cast<Org.Apache.Kafka.Streams.Kstream.WindowedSerdes.SessionWindowedSerde>();

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

        #region TimeWindowedSerde
        public partial class TimeWindowedSerde
        {
            #region Constructors
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.0/org/apache/kafka/streams/kstream/WindowedSerdes.TimeWindowedSerde.html#org.apache.kafka.streams.kstream.WindowedSerdes$TimeWindowedSerde(org.apache.kafka.common.serialization.Serde,long)"/>
            /// </summary>
            /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Serialization.Serde"/></param>
            /// <param name="arg1"><see cref="long"/></param>
            public TimeWindowedSerde(Org.Apache.Kafka.Common.Serialization.Serde arg0, long arg1)
                : base(arg0, arg1)
            {
            }

            #endregion

            #region Class/Interface conversion operators

            #endregion

            #region Fields

            #endregion

            #region Static methods

            #endregion

            #region Instance methods
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.0/org/apache/kafka/streams/kstream/WindowedSerdes.TimeWindowedSerde.html#forChangelog-boolean-"/>
            /// </summary>
            /// <param name="arg0"><see cref="bool"/></param>
            /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.WindowedSerdes.TimeWindowedSerde"/></returns>
            public Org.Apache.Kafka.Streams.Kstream.WindowedSerdes.TimeWindowedSerde ForChangelog(bool arg0)
            {
                return IExecute<Org.Apache.Kafka.Streams.Kstream.WindowedSerdes.TimeWindowedSerde>("forChangelog", arg0);
            }

            #endregion

            #region Nested classes

            #endregion

            // TODO: complete the class
        }
        #endregion

        #region TimeWindowedSerde<T>
        public partial class TimeWindowedSerde<T>
        {
            #region Constructors
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.0/org/apache/kafka/streams/kstream/WindowedSerdes.TimeWindowedSerde.html#org.apache.kafka.streams.kstream.WindowedSerdes$TimeWindowedSerde(org.apache.kafka.common.serialization.Serde,long)"/>
            /// </summary>
            /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Serialization.Serde"/></param>
            /// <param name="arg1"><see cref="long"/></param>
            public TimeWindowedSerde(Org.Apache.Kafka.Common.Serialization.Serde<T> arg0, long arg1)
                : base(arg0, arg1)
            {
            }

            #endregion

            #region Class/Interface conversion operators
            /// <summary>
            /// Converter from <see cref="Org.Apache.Kafka.Streams.Kstream.WindowedSerdes.TimeWindowedSerde{T}"/> to <see cref="Org.Apache.Kafka.Streams.Kstream.WindowedSerdes.TimeWindowedSerde"/>
            /// </summary>
            public static implicit operator Org.Apache.Kafka.Streams.Kstream.WindowedSerdes.TimeWindowedSerde(Org.Apache.Kafka.Streams.Kstream.WindowedSerdes.TimeWindowedSerde<T> t) => t.Cast<Org.Apache.Kafka.Streams.Kstream.WindowedSerdes.TimeWindowedSerde>();

            #endregion

            #region Fields

            #endregion

            #region Static methods

            #endregion

            #region Instance methods
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.0/org/apache/kafka/streams/kstream/WindowedSerdes.TimeWindowedSerde.html#forChangelog-boolean-"/>
            /// </summary>
            /// <param name="arg0"><see cref="bool"/></param>
            /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.WindowedSerdes.TimeWindowedSerde"/></returns>
            public Org.Apache.Kafka.Streams.Kstream.WindowedSerdes.TimeWindowedSerde<T> ForChangelog(bool arg0)
            {
                return IExecute<Org.Apache.Kafka.Streams.Kstream.WindowedSerdes.TimeWindowedSerde<T>>("forChangelog", arg0);
            }

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