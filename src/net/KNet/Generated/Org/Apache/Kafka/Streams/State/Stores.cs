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
*  This file is generated by MASES.JNetReflector (ver. 2.4.0.0)
*  using kafka-streams-3.6.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Streams.State
{
    #region Stores
    public partial class Stores
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/Stores.html#keyValueStoreBuilder-org.apache.kafka.streams.state.KeyValueBytesStoreSupplier-org.apache.kafka.common.serialization.Serde-org.apache.kafka.common.serialization.Serde-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.State.KeyValueBytesStoreSupplier"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Common.Serialization.Serde"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Common.Serialization.Serde"/></param>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.State.StoreBuilder"/></returns>
        public static Org.Apache.Kafka.Streams.State.StoreBuilder<Org.Apache.Kafka.Streams.State.KeyValueStore<K, V>> KeyValueStoreBuilder<K, V>(Org.Apache.Kafka.Streams.State.KeyValueBytesStoreSupplier arg0, Org.Apache.Kafka.Common.Serialization.Serde<K> arg1, Org.Apache.Kafka.Common.Serialization.Serde<V> arg2)
        {
            return SExecute<Org.Apache.Kafka.Streams.State.StoreBuilder<Org.Apache.Kafka.Streams.State.KeyValueStore<K, V>>>(LocalBridgeClazz, "keyValueStoreBuilder", arg0, arg1, arg2);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/Stores.html#sessionStoreBuilder-org.apache.kafka.streams.state.SessionBytesStoreSupplier-org.apache.kafka.common.serialization.Serde-org.apache.kafka.common.serialization.Serde-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.State.SessionBytesStoreSupplier"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Common.Serialization.Serde"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Common.Serialization.Serde"/></param>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.State.StoreBuilder"/></returns>
        public static Org.Apache.Kafka.Streams.State.StoreBuilder<Org.Apache.Kafka.Streams.State.SessionStore<K, V>> SessionStoreBuilder<K, V>(Org.Apache.Kafka.Streams.State.SessionBytesStoreSupplier arg0, Org.Apache.Kafka.Common.Serialization.Serde<K> arg1, Org.Apache.Kafka.Common.Serialization.Serde<V> arg2)
        {
            return SExecute<Org.Apache.Kafka.Streams.State.StoreBuilder<Org.Apache.Kafka.Streams.State.SessionStore<K, V>>>(LocalBridgeClazz, "sessionStoreBuilder", arg0, arg1, arg2);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/Stores.html#timestampedKeyValueStoreBuilder-org.apache.kafka.streams.state.KeyValueBytesStoreSupplier-org.apache.kafka.common.serialization.Serde-org.apache.kafka.common.serialization.Serde-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.State.KeyValueBytesStoreSupplier"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Common.Serialization.Serde"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Common.Serialization.Serde"/></param>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.State.StoreBuilder"/></returns>
        public static Org.Apache.Kafka.Streams.State.StoreBuilder<Org.Apache.Kafka.Streams.State.TimestampedKeyValueStore<K, V>> TimestampedKeyValueStoreBuilder<K, V>(Org.Apache.Kafka.Streams.State.KeyValueBytesStoreSupplier arg0, Org.Apache.Kafka.Common.Serialization.Serde<K> arg1, Org.Apache.Kafka.Common.Serialization.Serde<V> arg2)
        {
            return SExecute<Org.Apache.Kafka.Streams.State.StoreBuilder<Org.Apache.Kafka.Streams.State.TimestampedKeyValueStore<K, V>>>(LocalBridgeClazz, "timestampedKeyValueStoreBuilder", arg0, arg1, arg2);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/Stores.html#timestampedWindowStoreBuilder-org.apache.kafka.streams.state.WindowBytesStoreSupplier-org.apache.kafka.common.serialization.Serde-org.apache.kafka.common.serialization.Serde-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.State.WindowBytesStoreSupplier"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Common.Serialization.Serde"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Common.Serialization.Serde"/></param>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.State.StoreBuilder"/></returns>
        public static Org.Apache.Kafka.Streams.State.StoreBuilder<Org.Apache.Kafka.Streams.State.TimestampedWindowStore<K, V>> TimestampedWindowStoreBuilder<K, V>(Org.Apache.Kafka.Streams.State.WindowBytesStoreSupplier arg0, Org.Apache.Kafka.Common.Serialization.Serde<K> arg1, Org.Apache.Kafka.Common.Serialization.Serde<V> arg2)
        {
            return SExecute<Org.Apache.Kafka.Streams.State.StoreBuilder<Org.Apache.Kafka.Streams.State.TimestampedWindowStore<K, V>>>(LocalBridgeClazz, "timestampedWindowStoreBuilder", arg0, arg1, arg2);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/Stores.html#versionedKeyValueStoreBuilder-org.apache.kafka.streams.state.VersionedBytesStoreSupplier-org.apache.kafka.common.serialization.Serde-org.apache.kafka.common.serialization.Serde-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.State.VersionedBytesStoreSupplier"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Common.Serialization.Serde"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Common.Serialization.Serde"/></param>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.State.StoreBuilder"/></returns>
        public static Org.Apache.Kafka.Streams.State.StoreBuilder<Org.Apache.Kafka.Streams.State.VersionedKeyValueStore<K, V>> VersionedKeyValueStoreBuilder<K, V>(Org.Apache.Kafka.Streams.State.VersionedBytesStoreSupplier arg0, Org.Apache.Kafka.Common.Serialization.Serde<K> arg1, Org.Apache.Kafka.Common.Serialization.Serde<V> arg2)
        {
            return SExecute<Org.Apache.Kafka.Streams.State.StoreBuilder<Org.Apache.Kafka.Streams.State.VersionedKeyValueStore<K, V>>>(LocalBridgeClazz, "versionedKeyValueStoreBuilder", arg0, arg1, arg2);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/Stores.html#windowStoreBuilder-org.apache.kafka.streams.state.WindowBytesStoreSupplier-org.apache.kafka.common.serialization.Serde-org.apache.kafka.common.serialization.Serde-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.State.WindowBytesStoreSupplier"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Common.Serialization.Serde"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Common.Serialization.Serde"/></param>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.State.StoreBuilder"/></returns>
        public static Org.Apache.Kafka.Streams.State.StoreBuilder<Org.Apache.Kafka.Streams.State.WindowStore<K, V>> WindowStoreBuilder<K, V>(Org.Apache.Kafka.Streams.State.WindowBytesStoreSupplier arg0, Org.Apache.Kafka.Common.Serialization.Serde<K> arg1, Org.Apache.Kafka.Common.Serialization.Serde<V> arg2)
        {
            return SExecute<Org.Apache.Kafka.Streams.State.StoreBuilder<Org.Apache.Kafka.Streams.State.WindowStore<K, V>>>(LocalBridgeClazz, "windowStoreBuilder", arg0, arg1, arg2);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/Stores.html#inMemoryKeyValueStore-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.String"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.State.KeyValueBytesStoreSupplier"/></returns>
        public static Org.Apache.Kafka.Streams.State.KeyValueBytesStoreSupplier InMemoryKeyValueStore(Java.Lang.String arg0)
        {
            return SExecuteWithSignature<Org.Apache.Kafka.Streams.State.KeyValueBytesStoreSupplier>(LocalBridgeClazz, "inMemoryKeyValueStore", "(Ljava/lang/String;)Lorg/apache/kafka/streams/state/KeyValueBytesStoreSupplier;", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/Stores.html#lruMap-java.lang.String-int-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.String"/></param>
        /// <param name="arg1"><see cref="int"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.State.KeyValueBytesStoreSupplier"/></returns>
        public static Org.Apache.Kafka.Streams.State.KeyValueBytesStoreSupplier LruMap(Java.Lang.String arg0, int arg1)
        {
            return SExecute<Org.Apache.Kafka.Streams.State.KeyValueBytesStoreSupplier>(LocalBridgeClazz, "lruMap", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/Stores.html#persistentKeyValueStore-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.String"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.State.KeyValueBytesStoreSupplier"/></returns>
        public static Org.Apache.Kafka.Streams.State.KeyValueBytesStoreSupplier PersistentKeyValueStore(Java.Lang.String arg0)
        {
            return SExecuteWithSignature<Org.Apache.Kafka.Streams.State.KeyValueBytesStoreSupplier>(LocalBridgeClazz, "persistentKeyValueStore", "(Ljava/lang/String;)Lorg/apache/kafka/streams/state/KeyValueBytesStoreSupplier;", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/Stores.html#persistentTimestampedKeyValueStore-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.String"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.State.KeyValueBytesStoreSupplier"/></returns>
        public static Org.Apache.Kafka.Streams.State.KeyValueBytesStoreSupplier PersistentTimestampedKeyValueStore(Java.Lang.String arg0)
        {
            return SExecuteWithSignature<Org.Apache.Kafka.Streams.State.KeyValueBytesStoreSupplier>(LocalBridgeClazz, "persistentTimestampedKeyValueStore", "(Ljava/lang/String;)Lorg/apache/kafka/streams/state/KeyValueBytesStoreSupplier;", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/Stores.html#inMemorySessionStore-java.lang.String-java.time.Duration-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.String"/></param>
        /// <param name="arg1"><see cref="Java.Time.Duration"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.State.SessionBytesStoreSupplier"/></returns>
        public static Org.Apache.Kafka.Streams.State.SessionBytesStoreSupplier InMemorySessionStore(Java.Lang.String arg0, Java.Time.Duration arg1)
        {
            return SExecute<Org.Apache.Kafka.Streams.State.SessionBytesStoreSupplier>(LocalBridgeClazz, "inMemorySessionStore", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/Stores.html#persistentSessionStore-java.lang.String-java.time.Duration-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.String"/></param>
        /// <param name="arg1"><see cref="Java.Time.Duration"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.State.SessionBytesStoreSupplier"/></returns>
        public static Org.Apache.Kafka.Streams.State.SessionBytesStoreSupplier PersistentSessionStore(Java.Lang.String arg0, Java.Time.Duration arg1)
        {
            return SExecute<Org.Apache.Kafka.Streams.State.SessionBytesStoreSupplier>(LocalBridgeClazz, "persistentSessionStore", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/Stores.html#persistentVersionedKeyValueStore-java.lang.String-java.time.Duration-java.time.Duration-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.String"/></param>
        /// <param name="arg1"><see cref="Java.Time.Duration"/></param>
        /// <param name="arg2"><see cref="Java.Time.Duration"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.State.VersionedBytesStoreSupplier"/></returns>
        public static Org.Apache.Kafka.Streams.State.VersionedBytesStoreSupplier PersistentVersionedKeyValueStore(Java.Lang.String arg0, Java.Time.Duration arg1, Java.Time.Duration arg2)
        {
            return SExecute<Org.Apache.Kafka.Streams.State.VersionedBytesStoreSupplier>(LocalBridgeClazz, "persistentVersionedKeyValueStore", arg0, arg1, arg2);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/Stores.html#persistentVersionedKeyValueStore-java.lang.String-java.time.Duration-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.String"/></param>
        /// <param name="arg1"><see cref="Java.Time.Duration"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.State.VersionedBytesStoreSupplier"/></returns>
        public static Org.Apache.Kafka.Streams.State.VersionedBytesStoreSupplier PersistentVersionedKeyValueStore(Java.Lang.String arg0, Java.Time.Duration arg1)
        {
            return SExecute<Org.Apache.Kafka.Streams.State.VersionedBytesStoreSupplier>(LocalBridgeClazz, "persistentVersionedKeyValueStore", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/Stores.html#inMemoryWindowStore-java.lang.String-java.time.Duration-java.time.Duration-boolean-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.String"/></param>
        /// <param name="arg1"><see cref="Java.Time.Duration"/></param>
        /// <param name="arg2"><see cref="Java.Time.Duration"/></param>
        /// <param name="arg3"><see cref="bool"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.State.WindowBytesStoreSupplier"/></returns>
        /// <exception cref="Java.Lang.IllegalArgumentException"/>
        public static Org.Apache.Kafka.Streams.State.WindowBytesStoreSupplier InMemoryWindowStore(Java.Lang.String arg0, Java.Time.Duration arg1, Java.Time.Duration arg2, bool arg3)
        {
            return SExecute<Org.Apache.Kafka.Streams.State.WindowBytesStoreSupplier>(LocalBridgeClazz, "inMemoryWindowStore", arg0, arg1, arg2, arg3);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/Stores.html#persistentTimestampedWindowStore-java.lang.String-java.time.Duration-java.time.Duration-boolean-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.String"/></param>
        /// <param name="arg1"><see cref="Java.Time.Duration"/></param>
        /// <param name="arg2"><see cref="Java.Time.Duration"/></param>
        /// <param name="arg3"><see cref="bool"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.State.WindowBytesStoreSupplier"/></returns>
        /// <exception cref="Java.Lang.IllegalArgumentException"/>
        public static Org.Apache.Kafka.Streams.State.WindowBytesStoreSupplier PersistentTimestampedWindowStore(Java.Lang.String arg0, Java.Time.Duration arg1, Java.Time.Duration arg2, bool arg3)
        {
            return SExecute<Org.Apache.Kafka.Streams.State.WindowBytesStoreSupplier>(LocalBridgeClazz, "persistentTimestampedWindowStore", arg0, arg1, arg2, arg3);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/Stores.html#persistentWindowStore-java.lang.String-java.time.Duration-java.time.Duration-boolean-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.String"/></param>
        /// <param name="arg1"><see cref="Java.Time.Duration"/></param>
        /// <param name="arg2"><see cref="Java.Time.Duration"/></param>
        /// <param name="arg3"><see cref="bool"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.State.WindowBytesStoreSupplier"/></returns>
        /// <exception cref="Java.Lang.IllegalArgumentException"/>
        public static Org.Apache.Kafka.Streams.State.WindowBytesStoreSupplier PersistentWindowStore(Java.Lang.String arg0, Java.Time.Duration arg1, Java.Time.Duration arg2, bool arg3)
        {
            return SExecute<Org.Apache.Kafka.Streams.State.WindowBytesStoreSupplier>(LocalBridgeClazz, "persistentWindowStore", arg0, arg1, arg2, arg3);
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