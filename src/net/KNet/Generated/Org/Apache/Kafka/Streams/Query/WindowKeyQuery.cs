/*
*  Copyright 2024 MASES s.r.l.
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
*  This file is generated by MASES.JNetReflector (ver. 2.2.0.0)
*  using kafka-streams-3.6.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Streams.Query
{
    #region WindowKeyQuery
    public partial class WindowKeyQuery
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/query/WindowKeyQuery.html#withKeyAndWindowStartRange-java.lang.Object-java.time.Instant-java.time.Instant-"/>
        /// </summary>
        /// <param name="arg0"><see cref="object"/></param>
        /// <param name="arg1"><see cref="Java.Time.Instant"/></param>
        /// <param name="arg2"><see cref="Java.Time.Instant"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Query.WindowKeyQuery"/></returns>
        public static Org.Apache.Kafka.Streams.Query.WindowKeyQuery WithKeyAndWindowStartRange(object arg0, Java.Time.Instant arg1, Java.Time.Instant arg2)
        {
            return SExecute<Org.Apache.Kafka.Streams.Query.WindowKeyQuery>(LocalBridgeClazz, "withKeyAndWindowStartRange", arg0, arg1, arg2);
        }

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/query/WindowKeyQuery.html#getKey--"/> 
        /// </summary>
        public object Key
        {
            get { return IExecute("getKey"); }
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/query/WindowKeyQuery.html#getTimeFrom--"/> 
        /// </summary>
        public Java.Util.Optional TimeFrom
        {
            get { return IExecute<Java.Util.Optional>("getTimeFrom"); }
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/query/WindowKeyQuery.html#getTimeTo--"/> 
        /// </summary>
        public Java.Util.Optional TimeTo
        {
            get { return IExecute<Java.Util.Optional>("getTimeTo"); }
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion

    #region WindowKeyQuery<K, V>
    public partial class WindowKeyQuery<K, V>
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators
        /// <summary>
        /// Converter from <see cref="Org.Apache.Kafka.Streams.Query.WindowKeyQuery{K, V}"/> to <see cref="Org.Apache.Kafka.Streams.Query.WindowKeyQuery"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.Query.WindowKeyQuery(Org.Apache.Kafka.Streams.Query.WindowKeyQuery<K, V> t) => t.Cast<Org.Apache.Kafka.Streams.Query.WindowKeyQuery>();

        #endregion

        #region Fields

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/query/WindowKeyQuery.html#withKeyAndWindowStartRange-java.lang.Object-java.time.Instant-java.time.Instant-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="K"/></param>
        /// <param name="arg1"><see cref="Java.Time.Instant"/></param>
        /// <param name="arg2"><see cref="Java.Time.Instant"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Query.WindowKeyQuery"/></returns>
        public static Org.Apache.Kafka.Streams.Query.WindowKeyQuery<K, V> WithKeyAndWindowStartRange(K arg0, Java.Time.Instant arg1, Java.Time.Instant arg2)
        {
            return SExecute<Org.Apache.Kafka.Streams.Query.WindowKeyQuery<K, V>>(LocalBridgeClazz, "withKeyAndWindowStartRange", arg0, arg1, arg2);
        }

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/query/WindowKeyQuery.html#getKey--"/> 
        /// </summary>
        public K Key
        {
            get { return IExecute<K>("getKey"); }
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/query/WindowKeyQuery.html#getTimeFrom--"/> 
        /// </summary>
        public Java.Util.Optional<Java.Time.Instant> TimeFrom
        {
            get { return IExecute<Java.Util.Optional<Java.Time.Instant>>("getTimeFrom"); }
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/query/WindowKeyQuery.html#getTimeTo--"/> 
        /// </summary>
        public Java.Util.Optional<Java.Time.Instant> TimeTo
        {
            get { return IExecute<Java.Util.Optional<Java.Time.Instant>>("getTimeTo"); }
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}