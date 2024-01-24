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
*  This file is generated by MASES.JNetReflector (ver. 2.2.3.0)
*  using kafka-streams-3.6.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Streams.State
{
    #region QueryableStoreTypes
    public partial class QueryableStoreTypes
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/QueryableStoreTypes.html#timestampedKeyValueStore--"/>
        /// </summary>

        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.State.QueryableStoreType"/></returns>
        public static Org.Apache.Kafka.Streams.State.QueryableStoreType<Org.Apache.Kafka.Streams.State.ReadOnlyKeyValueStore<K, Org.Apache.Kafka.Streams.State.ValueAndTimestamp<V>>> TimestampedKeyValueStore<K, V>()
        {
            return SExecute<Org.Apache.Kafka.Streams.State.QueryableStoreType<Org.Apache.Kafka.Streams.State.ReadOnlyKeyValueStore<K, Org.Apache.Kafka.Streams.State.ValueAndTimestamp<V>>>>(LocalBridgeClazz, "timestampedKeyValueStore");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/QueryableStoreTypes.html#keyValueStore--"/>
        /// </summary>

        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.State.QueryableStoreType"/></returns>
        public static Org.Apache.Kafka.Streams.State.QueryableStoreType<Org.Apache.Kafka.Streams.State.ReadOnlyKeyValueStore<K, V>> KeyValueStore<K, V>()
        {
            return SExecute<Org.Apache.Kafka.Streams.State.QueryableStoreType<Org.Apache.Kafka.Streams.State.ReadOnlyKeyValueStore<K, V>>>(LocalBridgeClazz, "keyValueStore");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/QueryableStoreTypes.html#sessionStore--"/>
        /// </summary>

        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.State.QueryableStoreType"/></returns>
        public static Org.Apache.Kafka.Streams.State.QueryableStoreType<Org.Apache.Kafka.Streams.State.ReadOnlySessionStore<K, V>> SessionStore<K, V>()
        {
            return SExecute<Org.Apache.Kafka.Streams.State.QueryableStoreType<Org.Apache.Kafka.Streams.State.ReadOnlySessionStore<K, V>>>(LocalBridgeClazz, "sessionStore");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/QueryableStoreTypes.html#timestampedWindowStore--"/>
        /// </summary>

        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.State.QueryableStoreType"/></returns>
        public static Org.Apache.Kafka.Streams.State.QueryableStoreType<Org.Apache.Kafka.Streams.State.ReadOnlyWindowStore<K, Org.Apache.Kafka.Streams.State.ValueAndTimestamp<V>>> TimestampedWindowStore<K, V>()
        {
            return SExecute<Org.Apache.Kafka.Streams.State.QueryableStoreType<Org.Apache.Kafka.Streams.State.ReadOnlyWindowStore<K, Org.Apache.Kafka.Streams.State.ValueAndTimestamp<V>>>>(LocalBridgeClazz, "timestampedWindowStore");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/QueryableStoreTypes.html#windowStore--"/>
        /// </summary>

        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.State.QueryableStoreType"/></returns>
        public static Org.Apache.Kafka.Streams.State.QueryableStoreType<Org.Apache.Kafka.Streams.State.ReadOnlyWindowStore<K, V>> WindowStore<K, V>()
        {
            return SExecute<Org.Apache.Kafka.Streams.State.QueryableStoreType<Org.Apache.Kafka.Streams.State.ReadOnlyWindowStore<K, V>>>(LocalBridgeClazz, "windowStore");
        }

        #endregion

        #region Instance methods

        #endregion

        #region Nested classes
        #region KeyValueStoreType
        public partial class KeyValueStoreType
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

        #region KeyValueStoreType<K, V>
        public partial class KeyValueStoreType<K, V>
        {
            #region Constructors

            #endregion

            #region Class/Interface conversion operators
            /// <summary>
            /// Converter from <see cref="Org.Apache.Kafka.Streams.State.QueryableStoreTypes.KeyValueStoreType{K, V}"/> to <see cref="Org.Apache.Kafka.Streams.State.QueryableStoreTypes.KeyValueStoreType"/>
            /// </summary>
            public static implicit operator Org.Apache.Kafka.Streams.State.QueryableStoreTypes.KeyValueStoreType(Org.Apache.Kafka.Streams.State.QueryableStoreTypes.KeyValueStoreType<K, V> t) => t.Cast<Org.Apache.Kafka.Streams.State.QueryableStoreTypes.KeyValueStoreType>();

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

        #region SessionStoreType
        public partial class SessionStoreType
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

        #region SessionStoreType<K, V>
        public partial class SessionStoreType<K, V>
        {
            #region Constructors

            #endregion

            #region Class/Interface conversion operators
            /// <summary>
            /// Converter from <see cref="Org.Apache.Kafka.Streams.State.QueryableStoreTypes.SessionStoreType{K, V}"/> to <see cref="Org.Apache.Kafka.Streams.State.QueryableStoreTypes.SessionStoreType"/>
            /// </summary>
            public static implicit operator Org.Apache.Kafka.Streams.State.QueryableStoreTypes.SessionStoreType(Org.Apache.Kafka.Streams.State.QueryableStoreTypes.SessionStoreType<K, V> t) => t.Cast<Org.Apache.Kafka.Streams.State.QueryableStoreTypes.SessionStoreType>();

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

        #region WindowStoreType
        public partial class WindowStoreType
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

        #region WindowStoreType<K, V>
        public partial class WindowStoreType<K, V>
        {
            #region Constructors

            #endregion

            #region Class/Interface conversion operators
            /// <summary>
            /// Converter from <see cref="Org.Apache.Kafka.Streams.State.QueryableStoreTypes.WindowStoreType{K, V}"/> to <see cref="Org.Apache.Kafka.Streams.State.QueryableStoreTypes.WindowStoreType"/>
            /// </summary>
            public static implicit operator Org.Apache.Kafka.Streams.State.QueryableStoreTypes.WindowStoreType(Org.Apache.Kafka.Streams.State.QueryableStoreTypes.WindowStoreType<K, V> t) => t.Cast<Org.Apache.Kafka.Streams.State.QueryableStoreTypes.WindowStoreType>();

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
}