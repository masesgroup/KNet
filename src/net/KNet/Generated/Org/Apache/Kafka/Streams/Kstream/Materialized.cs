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

namespace Org.Apache.Kafka.Streams.Kstream
{
    #region Materialized
    public partial class Materialized
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.html#storeType"/>
        /// </summary>
        public Org.Apache.Kafka.Streams.Kstream.Materialized.StoreType storeType { get { return IGetField<Org.Apache.Kafka.Streams.Kstream.Materialized.StoreType>("storeType"); } set { ISetField("storeType", value); } }

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.html#as-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.String"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized"/></returns>
        public static Org.Apache.Kafka.Streams.Kstream.Materialized As(Java.Lang.String arg0)
        {
            return SExecute<Org.Apache.Kafka.Streams.Kstream.Materialized>(LocalBridgeClazz, "as", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.html#as-org.apache.kafka.streams.kstream.Materialized.StoreType-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized.StoreType"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized"/></returns>
        public static Org.Apache.Kafka.Streams.Kstream.Materialized As(Org.Apache.Kafka.Streams.Kstream.Materialized.StoreType arg0)
        {
            return SExecute<Org.Apache.Kafka.Streams.Kstream.Materialized>(LocalBridgeClazz, "as", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.html#with-org.apache.kafka.common.serialization.Serde-org.apache.kafka.common.serialization.Serde-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Serialization.Serde"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Common.Serialization.Serde"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized"/></returns>
        public static Org.Apache.Kafka.Streams.Kstream.Materialized With(Org.Apache.Kafka.Common.Serialization.Serde arg0, Org.Apache.Kafka.Common.Serialization.Serde arg1)
        {
            return SExecute<Org.Apache.Kafka.Streams.Kstream.Materialized>(LocalBridgeClazz, "with", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.html#as-org.apache.kafka.streams.state.KeyValueBytesStoreSupplier-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.State.KeyValueBytesStoreSupplier"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized"/></returns>
        public static Org.Apache.Kafka.Streams.Kstream.Materialized As(Org.Apache.Kafka.Streams.State.KeyValueBytesStoreSupplier arg0)
        {
            return SExecute<Org.Apache.Kafka.Streams.Kstream.Materialized>(LocalBridgeClazz, "as", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.html#as-org.apache.kafka.streams.state.SessionBytesStoreSupplier-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.State.SessionBytesStoreSupplier"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized"/></returns>
        public static Org.Apache.Kafka.Streams.Kstream.Materialized As(Org.Apache.Kafka.Streams.State.SessionBytesStoreSupplier arg0)
        {
            return SExecute<Org.Apache.Kafka.Streams.Kstream.Materialized>(LocalBridgeClazz, "as", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.html#as-org.apache.kafka.streams.state.WindowBytesStoreSupplier-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.State.WindowBytesStoreSupplier"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized"/></returns>
        public static Org.Apache.Kafka.Streams.Kstream.Materialized As(Org.Apache.Kafka.Streams.State.WindowBytesStoreSupplier arg0)
        {
            return SExecute<Org.Apache.Kafka.Streams.Kstream.Materialized>(LocalBridgeClazz, "as", arg0);
        }

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.html#withCachingDisabled--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized"/></returns>
        public Org.Apache.Kafka.Streams.Kstream.Materialized WithCachingDisabled()
        {
            return IExecuteWithSignature<Org.Apache.Kafka.Streams.Kstream.Materialized>("withCachingDisabled", "()Lorg/apache/kafka/streams/kstream/Materialized;");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.html#withCachingEnabled--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized"/></returns>
        public Org.Apache.Kafka.Streams.Kstream.Materialized WithCachingEnabled()
        {
            return IExecuteWithSignature<Org.Apache.Kafka.Streams.Kstream.Materialized>("withCachingEnabled", "()Lorg/apache/kafka/streams/kstream/Materialized;");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.html#withKeySerde-org.apache.kafka.common.serialization.Serde-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Serialization.Serde"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized"/></returns>
        public Org.Apache.Kafka.Streams.Kstream.Materialized WithKeySerde(Org.Apache.Kafka.Common.Serialization.Serde arg0)
        {
            return IExecuteWithSignature<Org.Apache.Kafka.Streams.Kstream.Materialized>("withKeySerde", "(Lorg/apache/kafka/common/serialization/Serde;)Lorg/apache/kafka/streams/kstream/Materialized;", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.html#withLoggingDisabled--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized"/></returns>
        public Org.Apache.Kafka.Streams.Kstream.Materialized WithLoggingDisabled()
        {
            return IExecuteWithSignature<Org.Apache.Kafka.Streams.Kstream.Materialized>("withLoggingDisabled", "()Lorg/apache/kafka/streams/kstream/Materialized;");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.html#withLoggingEnabled-java.util.Map-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.Map"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized"/></returns>
        public Org.Apache.Kafka.Streams.Kstream.Materialized WithLoggingEnabled(Java.Util.Map arg0)
        {
            return IExecuteWithSignature<Org.Apache.Kafka.Streams.Kstream.Materialized>("withLoggingEnabled", "(Ljava/util/Map;)Lorg/apache/kafka/streams/kstream/Materialized;", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.html#withRetention-java.time.Duration-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Time.Duration"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized"/></returns>
        /// <exception cref="Java.Lang.IllegalArgumentException"/>
        public Org.Apache.Kafka.Streams.Kstream.Materialized WithRetention(Java.Time.Duration arg0)
        {
            return IExecuteWithSignature<Org.Apache.Kafka.Streams.Kstream.Materialized>("withRetention", "(Ljava/time/Duration;)Lorg/apache/kafka/streams/kstream/Materialized;", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.html#withStoreType-org.apache.kafka.streams.kstream.Materialized.StoreType-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized.StoreType"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized"/></returns>
        /// <exception cref="Java.Lang.IllegalArgumentException"/>
        public Org.Apache.Kafka.Streams.Kstream.Materialized WithStoreType(Org.Apache.Kafka.Streams.Kstream.Materialized.StoreType arg0)
        {
            return IExecuteWithSignature<Org.Apache.Kafka.Streams.Kstream.Materialized>("withStoreType", "(Lorg/apache/kafka/streams/kstream/Materialized$StoreType;)Lorg/apache/kafka/streams/kstream/Materialized;", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.html#withValueSerde-org.apache.kafka.common.serialization.Serde-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Serialization.Serde"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized"/></returns>
        public Org.Apache.Kafka.Streams.Kstream.Materialized WithValueSerde(Org.Apache.Kafka.Common.Serialization.Serde arg0)
        {
            return IExecuteWithSignature<Org.Apache.Kafka.Streams.Kstream.Materialized>("withValueSerde", "(Lorg/apache/kafka/common/serialization/Serde;)Lorg/apache/kafka/streams/kstream/Materialized;", arg0);
        }

        #endregion

        #region Nested classes
        #region StoreType
        public partial class StoreType
        {
            #region Constructors

            #endregion

            #region Class/Interface conversion operators

            #endregion

            #region Fields
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.StoreType.html#IN_MEMORY"/>
            /// </summary>
            public static Org.Apache.Kafka.Streams.Kstream.Materialized.StoreType IN_MEMORY { get { if (!_IN_MEMORYReady) { _IN_MEMORYContent = SGetField<Org.Apache.Kafka.Streams.Kstream.Materialized.StoreType>(LocalBridgeClazz, "IN_MEMORY"); _IN_MEMORYReady = true; } return _IN_MEMORYContent; } }
            private static Org.Apache.Kafka.Streams.Kstream.Materialized.StoreType _IN_MEMORYContent = default;
            private static bool _IN_MEMORYReady = false; // this is used because in case of generics 
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.StoreType.html#ROCKS_DB"/>
            /// </summary>
            public static Org.Apache.Kafka.Streams.Kstream.Materialized.StoreType ROCKS_DB { get { if (!_ROCKS_DBReady) { _ROCKS_DBContent = SGetField<Org.Apache.Kafka.Streams.Kstream.Materialized.StoreType>(LocalBridgeClazz, "ROCKS_DB"); _ROCKS_DBReady = true; } return _ROCKS_DBContent; } }
            private static Org.Apache.Kafka.Streams.Kstream.Materialized.StoreType _ROCKS_DBContent = default;
            private static bool _ROCKS_DBReady = false; // this is used because in case of generics 

            #endregion

            #region Static methods
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.StoreType.html#valueOf-java.lang.String-"/>
            /// </summary>
            /// <param name="arg0"><see cref="Java.Lang.String"/></param>
            /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized.StoreType"/></returns>
            public static Org.Apache.Kafka.Streams.Kstream.Materialized.StoreType ValueOf(Java.Lang.String arg0)
            {
                return SExecuteWithSignature<Org.Apache.Kafka.Streams.Kstream.Materialized.StoreType>(LocalBridgeClazz, "valueOf", "(Ljava/lang/String;)Lorg/apache/kafka/streams/kstream/Materialized$StoreType;", arg0);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.StoreType.html#values--"/>
            /// </summary>

            /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized.StoreType"/></returns>
            public static Org.Apache.Kafka.Streams.Kstream.Materialized.StoreType[] Values()
            {
                return SExecuteWithSignatureArray<Org.Apache.Kafka.Streams.Kstream.Materialized.StoreType>(LocalBridgeClazz, "values", "()[Lorg/apache/kafka/streams/kstream/Materialized$StoreType;");
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

    #region Materialized<K, V, S>
    public partial class Materialized<K, V, S>
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators
        /// <summary>
        /// Converter from <see cref="Org.Apache.Kafka.Streams.Kstream.Materialized{K, V, S}"/> to <see cref="Org.Apache.Kafka.Streams.Kstream.Materialized"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.Kstream.Materialized(Org.Apache.Kafka.Streams.Kstream.Materialized<K, V, S> t) => t.Cast<Org.Apache.Kafka.Streams.Kstream.Materialized>();

        #endregion

        #region Fields
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.html#storeType"/>
        /// </summary>
        public Org.Apache.Kafka.Streams.Kstream.Materialized.StoreType storeType { get { return IGetField<Org.Apache.Kafka.Streams.Kstream.Materialized.StoreType>("storeType"); } set { ISetField("storeType", value); } }

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.html#as-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.String"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized"/></returns>
        public static Org.Apache.Kafka.Streams.Kstream.Materialized As(Java.Lang.String arg0)
        {
            return SExecute<Org.Apache.Kafka.Streams.Kstream.Materialized>(LocalBridgeClazz, "as", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.html#as-org.apache.kafka.streams.kstream.Materialized.StoreType-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized.StoreType"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized"/></returns>
        public static Org.Apache.Kafka.Streams.Kstream.Materialized As(Org.Apache.Kafka.Streams.Kstream.Materialized.StoreType arg0)
        {
            return SExecute<Org.Apache.Kafka.Streams.Kstream.Materialized>(LocalBridgeClazz, "as", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.html#with-org.apache.kafka.common.serialization.Serde-org.apache.kafka.common.serialization.Serde-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Serialization.Serde"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Common.Serialization.Serde"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized"/></returns>
        public static Org.Apache.Kafka.Streams.Kstream.Materialized With(Org.Apache.Kafka.Common.Serialization.Serde<K> arg0, Org.Apache.Kafka.Common.Serialization.Serde<V> arg1)
        {
            return SExecute<Org.Apache.Kafka.Streams.Kstream.Materialized>(LocalBridgeClazz, "with", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.html#as-org.apache.kafka.streams.state.KeyValueBytesStoreSupplier-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.State.KeyValueBytesStoreSupplier"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized"/></returns>
        public static Org.Apache.Kafka.Streams.Kstream.Materialized<K, V, Org.Apache.Kafka.Streams.State.KeyValueStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>> As(Org.Apache.Kafka.Streams.State.KeyValueBytesStoreSupplier arg0)
        {
            return SExecute<Org.Apache.Kafka.Streams.Kstream.Materialized<K, V, Org.Apache.Kafka.Streams.State.KeyValueStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>>>(LocalBridgeClazz, "as", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.html#as-org.apache.kafka.streams.state.SessionBytesStoreSupplier-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.State.SessionBytesStoreSupplier"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized"/></returns>
        public static Org.Apache.Kafka.Streams.Kstream.Materialized<K, V, Org.Apache.Kafka.Streams.State.SessionStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>> As(Org.Apache.Kafka.Streams.State.SessionBytesStoreSupplier arg0)
        {
            return SExecute<Org.Apache.Kafka.Streams.Kstream.Materialized<K, V, Org.Apache.Kafka.Streams.State.SessionStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>>>(LocalBridgeClazz, "as", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.html#as-org.apache.kafka.streams.state.WindowBytesStoreSupplier-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.State.WindowBytesStoreSupplier"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized"/></returns>
        public static Org.Apache.Kafka.Streams.Kstream.Materialized<K, V, Org.Apache.Kafka.Streams.State.WindowStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>> As(Org.Apache.Kafka.Streams.State.WindowBytesStoreSupplier arg0)
        {
            return SExecute<Org.Apache.Kafka.Streams.Kstream.Materialized<K, V, Org.Apache.Kafka.Streams.State.WindowStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>>>(LocalBridgeClazz, "as", arg0);
        }

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.html#withCachingDisabled--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized"/></returns>
        public Org.Apache.Kafka.Streams.Kstream.Materialized WithCachingDisabled()
        {
            return IExecuteWithSignature<Org.Apache.Kafka.Streams.Kstream.Materialized>("withCachingDisabled", "()Lorg/apache/kafka/streams/kstream/Materialized;");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.html#withCachingEnabled--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized"/></returns>
        public Org.Apache.Kafka.Streams.Kstream.Materialized WithCachingEnabled()
        {
            return IExecuteWithSignature<Org.Apache.Kafka.Streams.Kstream.Materialized>("withCachingEnabled", "()Lorg/apache/kafka/streams/kstream/Materialized;");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.html#withKeySerde-org.apache.kafka.common.serialization.Serde-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Serialization.Serde"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized"/></returns>
        public Org.Apache.Kafka.Streams.Kstream.Materialized WithKeySerde(Org.Apache.Kafka.Common.Serialization.Serde<K> arg0)
        {
            return IExecuteWithSignature<Org.Apache.Kafka.Streams.Kstream.Materialized>("withKeySerde", "(Lorg/apache/kafka/common/serialization/Serde;)Lorg/apache/kafka/streams/kstream/Materialized;", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.html#withLoggingDisabled--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized"/></returns>
        public Org.Apache.Kafka.Streams.Kstream.Materialized WithLoggingDisabled()
        {
            return IExecuteWithSignature<Org.Apache.Kafka.Streams.Kstream.Materialized>("withLoggingDisabled", "()Lorg/apache/kafka/streams/kstream/Materialized;");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.html#withLoggingEnabled-java.util.Map-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.Map"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized"/></returns>
        public Org.Apache.Kafka.Streams.Kstream.Materialized WithLoggingEnabled(Java.Util.Map<Java.Lang.String, Java.Lang.String> arg0)
        {
            return IExecuteWithSignature<Org.Apache.Kafka.Streams.Kstream.Materialized>("withLoggingEnabled", "(Ljava/util/Map;)Lorg/apache/kafka/streams/kstream/Materialized;", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.html#withRetention-java.time.Duration-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Time.Duration"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized"/></returns>
        /// <exception cref="Java.Lang.IllegalArgumentException"/>
        public Org.Apache.Kafka.Streams.Kstream.Materialized WithRetention(Java.Time.Duration arg0)
        {
            return IExecuteWithSignature<Org.Apache.Kafka.Streams.Kstream.Materialized>("withRetention", "(Ljava/time/Duration;)Lorg/apache/kafka/streams/kstream/Materialized;", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.html#withStoreType-org.apache.kafka.streams.kstream.Materialized.StoreType-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized.StoreType"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized"/></returns>
        /// <exception cref="Java.Lang.IllegalArgumentException"/>
        public Org.Apache.Kafka.Streams.Kstream.Materialized WithStoreType(Org.Apache.Kafka.Streams.Kstream.Materialized.StoreType arg0)
        {
            return IExecuteWithSignature<Org.Apache.Kafka.Streams.Kstream.Materialized>("withStoreType", "(Lorg/apache/kafka/streams/kstream/Materialized$StoreType;)Lorg/apache/kafka/streams/kstream/Materialized;", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Materialized.html#withValueSerde-org.apache.kafka.common.serialization.Serde-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Serialization.Serde"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized"/></returns>
        public Org.Apache.Kafka.Streams.Kstream.Materialized WithValueSerde(Org.Apache.Kafka.Common.Serialization.Serde<V> arg0)
        {
            return IExecuteWithSignature<Org.Apache.Kafka.Streams.Kstream.Materialized>("withValueSerde", "(Lorg/apache/kafka/common/serialization/Serde;)Lorg/apache/kafka/streams/kstream/Materialized;", arg0);
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}