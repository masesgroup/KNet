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
    #region ReadOnlyKeyValueStore
    public partial class ReadOnlyKeyValueStore
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
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyKeyValueStore.html#approximateNumEntries--"/>
        /// </summary>

        /// <returns><see cref="long"/></returns>
        public long ApproximateNumEntries()
        {
            return IExecuteWithSignature<long>("approximateNumEntries", "()J");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyKeyValueStore.html#all--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Streams.State.KeyValueIterator"/></returns>
        public Org.Apache.Kafka.Streams.State.KeyValueIterator All()
        {
            return IExecuteWithSignature<Org.Apache.Kafka.Streams.State.KeyValueIterator>("all", "()Lorg/apache/kafka/streams/state/KeyValueIterator;");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyKeyValueStore.html#range-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><see cref="object"/></param>
        /// <param name="arg1"><see cref="object"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.State.KeyValueIterator"/></returns>
        public Org.Apache.Kafka.Streams.State.KeyValueIterator Range(object arg0, object arg1)
        {
            return IExecute<Org.Apache.Kafka.Streams.State.KeyValueIterator>("range", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyKeyValueStore.html#get-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><see cref="object"/></param>
        /// <returns><see cref="object"/></returns>
        public object Get(object arg0)
        {
            return IExecuteWithSignature("get", "(Ljava/lang/Object;)Ljava/lang/Object;", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyKeyValueStore.html#prefixScan-java.lang.Object-org.apache.kafka.common.serialization.Serializer-"/>
        /// </summary>
        /// <param name="arg0"><see cref="object"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Common.Serialization.Serializer"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.State.KeyValueIterator"/></returns>
        public Org.Apache.Kafka.Streams.State.KeyValueIterator PrefixScan(object arg0, Org.Apache.Kafka.Common.Serialization.Serializer arg1)
        {
            return IExecute<Org.Apache.Kafka.Streams.State.KeyValueIterator>("prefixScan", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyKeyValueStore.html#reverseAll--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Streams.State.KeyValueIterator"/></returns>
        public Org.Apache.Kafka.Streams.State.KeyValueIterator ReverseAll()
        {
            return IExecuteWithSignature<Org.Apache.Kafka.Streams.State.KeyValueIterator>("reverseAll", "()Lorg/apache/kafka/streams/state/KeyValueIterator;");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyKeyValueStore.html#reverseRange-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><see cref="object"/></param>
        /// <param name="arg1"><see cref="object"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.State.KeyValueIterator"/></returns>
        public Org.Apache.Kafka.Streams.State.KeyValueIterator ReverseRange(object arg0, object arg1)
        {
            return IExecute<Org.Apache.Kafka.Streams.State.KeyValueIterator>("reverseRange", arg0, arg1);
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion

    #region IReadOnlyKeyValueStore<K, V>
    /// <summary>
    /// .NET interface for TO BE DEFINED FROM USER
    /// </summary>
    public partial interface IReadOnlyKeyValueStore<K, V>
    {
        #region Instance methods

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion

    #region ReadOnlyKeyValueStore<K, V>
    public partial class ReadOnlyKeyValueStore<K, V> : Org.Apache.Kafka.Streams.State.IReadOnlyKeyValueStore<K, V>
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators
        /// <summary>
        /// Converter from <see cref="Org.Apache.Kafka.Streams.State.ReadOnlyKeyValueStore{K, V}"/> to <see cref="Org.Apache.Kafka.Streams.State.ReadOnlyKeyValueStore"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.State.ReadOnlyKeyValueStore(Org.Apache.Kafka.Streams.State.ReadOnlyKeyValueStore<K, V> t) => t.Cast<Org.Apache.Kafka.Streams.State.ReadOnlyKeyValueStore>();

        #endregion

        #region Fields

        #endregion

        #region Static methods

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyKeyValueStore.html#approximateNumEntries--"/>
        /// </summary>

        /// <returns><see cref="long"/></returns>
        public long ApproximateNumEntries()
        {
            return IExecuteWithSignature<long>("approximateNumEntries", "()J");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyKeyValueStore.html#all--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Streams.State.KeyValueIterator"/></returns>
        public Org.Apache.Kafka.Streams.State.KeyValueIterator<K, V> All()
        {
            return IExecuteWithSignature<Org.Apache.Kafka.Streams.State.KeyValueIterator<K, V>>("all", "()Lorg/apache/kafka/streams/state/KeyValueIterator;");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyKeyValueStore.html#range-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="K"/></param>
        /// <param name="arg1"><typeparamref name="K"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.State.KeyValueIterator"/></returns>
        public Org.Apache.Kafka.Streams.State.KeyValueIterator<K, V> Range(K arg0, K arg1)
        {
            return IExecute<Org.Apache.Kafka.Streams.State.KeyValueIterator<K, V>>("range", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyKeyValueStore.html#get-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="K"/></param>
        /// <returns><typeparamref name="V"/></returns>
        public V Get(K arg0)
        {
            return IExecuteWithSignature<V>("get", "(Ljava/lang/Object;)Ljava/lang/Object;", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyKeyValueStore.html#prefixScan-java.lang.Object-org.apache.kafka.common.serialization.Serializer-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="P"/></param>
        /// <param name="arg1"><typeparamref name="PS"/></param>
        /// <typeparam name="P"></typeparam>
        /// <typeparam name="PS"><see cref="Org.Apache.Kafka.Common.Serialization.Serializer{P}"/></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.State.KeyValueIterator"/></returns>
        public Org.Apache.Kafka.Streams.State.KeyValueIterator<K, V> PrefixScan<P, PS>(P arg0, PS arg1) where PS: Org.Apache.Kafka.Common.Serialization.Serializer<P>
        {
            return IExecute<Org.Apache.Kafka.Streams.State.KeyValueIterator<K, V>>("prefixScan", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyKeyValueStore.html#reverseAll--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Streams.State.KeyValueIterator"/></returns>
        public Org.Apache.Kafka.Streams.State.KeyValueIterator<K, V> ReverseAll()
        {
            return IExecuteWithSignature<Org.Apache.Kafka.Streams.State.KeyValueIterator<K, V>>("reverseAll", "()Lorg/apache/kafka/streams/state/KeyValueIterator;");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ReadOnlyKeyValueStore.html#reverseRange-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="K"/></param>
        /// <param name="arg1"><typeparamref name="K"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.State.KeyValueIterator"/></returns>
        public Org.Apache.Kafka.Streams.State.KeyValueIterator<K, V> ReverseRange(K arg0, K arg1)
        {
            return IExecute<Org.Apache.Kafka.Streams.State.KeyValueIterator<K, V>>("reverseRange", arg0, arg1);
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}