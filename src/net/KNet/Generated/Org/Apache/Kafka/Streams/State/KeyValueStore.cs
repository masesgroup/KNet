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
*  This file is generated by MASES.JNetReflector (ver. 2.2.5.0)
*  using kafka-streams-3.6.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Streams.State
{
    #region KeyValueStore
    public partial class KeyValueStore
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators
        /// <summary>
        /// Converter from <see cref="Org.Apache.Kafka.Streams.State.KeyValueStore"/> to <see cref="Org.Apache.Kafka.Streams.Processor.StateStore"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.Processor.StateStore(Org.Apache.Kafka.Streams.State.KeyValueStore t) => t.Cast<Org.Apache.Kafka.Streams.Processor.StateStore>();
        /// <summary>
        /// Converter from <see cref="Org.Apache.Kafka.Streams.State.KeyValueStore"/> to <see cref="Org.Apache.Kafka.Streams.State.ReadOnlyKeyValueStore"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.State.ReadOnlyKeyValueStore(Org.Apache.Kafka.Streams.State.KeyValueStore t) => t.Cast<Org.Apache.Kafka.Streams.State.ReadOnlyKeyValueStore>();

        #endregion

        #region Fields

        #endregion

        #region Static methods

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/KeyValueStore.html#delete-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><see cref="object"/></param>
        /// <returns><see cref="object"/></returns>
        public object Delete(object arg0)
        {
            return IExecute("delete", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/KeyValueStore.html#putIfAbsent-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><see cref="object"/></param>
        /// <param name="arg1"><see cref="object"/></param>
        /// <returns><see cref="object"/></returns>
        public object PutIfAbsent(object arg0, object arg1)
        {
            return IExecute("putIfAbsent", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/KeyValueStore.html#put-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><see cref="object"/></param>
        /// <param name="arg1"><see cref="object"/></param>
        public void Put(object arg0, object arg1)
        {
            IExecute("put", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/KeyValueStore.html#putAll-java.util.List-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.List"/></param>
        public void PutAll(Java.Util.List arg0)
        {
            IExecute("putAll", arg0);
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion

    #region IKeyValueStore<K, V>
    /// <summary>
    /// .NET interface for TO BE DEFINED FROM USER
    /// </summary>
    public partial interface IKeyValueStore<K, V>
    {
        #region Instance methods

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion

    #region KeyValueStore<K, V>
    public partial class KeyValueStore<K, V> : Org.Apache.Kafka.Streams.State.IKeyValueStore<K, V>, Org.Apache.Kafka.Streams.Processor.IStateStore, Org.Apache.Kafka.Streams.State.IReadOnlyKeyValueStore<K, V>
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators
        /// <summary>
        /// Converter from <see cref="Org.Apache.Kafka.Streams.State.KeyValueStore{K, V}"/> to <see cref="Org.Apache.Kafka.Streams.Processor.StateStore"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.Processor.StateStore(Org.Apache.Kafka.Streams.State.KeyValueStore<K, V> t) => t.Cast<Org.Apache.Kafka.Streams.Processor.StateStore>();
        /// <summary>
        /// Converter from <see cref="Org.Apache.Kafka.Streams.State.KeyValueStore{K, V}"/> to <see cref="Org.Apache.Kafka.Streams.State.ReadOnlyKeyValueStore{K, V}"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.State.ReadOnlyKeyValueStore<K, V>(Org.Apache.Kafka.Streams.State.KeyValueStore<K, V> t) => t.Cast<Org.Apache.Kafka.Streams.State.ReadOnlyKeyValueStore<K, V>>();
        /// <summary>
        /// Converter from <see cref="Org.Apache.Kafka.Streams.State.KeyValueStore{K, V}"/> to <see cref="Org.Apache.Kafka.Streams.State.KeyValueStore"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.State.KeyValueStore(Org.Apache.Kafka.Streams.State.KeyValueStore<K, V> t) => t.Cast<Org.Apache.Kafka.Streams.State.KeyValueStore>();

        #endregion

        #region Fields

        #endregion

        #region Static methods

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/KeyValueStore.html#delete-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="K"/></param>
        /// <returns><typeparamref name="V"/></returns>
        public V Delete(K arg0)
        {
            return IExecute<V>("delete", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/KeyValueStore.html#putIfAbsent-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="K"/></param>
        /// <param name="arg1"><typeparamref name="V"/></param>
        /// <returns><typeparamref name="V"/></returns>
        public V PutIfAbsent(K arg0, V arg1)
        {
            return IExecute<V>("putIfAbsent", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/KeyValueStore.html#put-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="K"/></param>
        /// <param name="arg1"><typeparamref name="V"/></param>
        public void Put(K arg0, V arg1)
        {
            IExecute("put", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/KeyValueStore.html#putAll-java.util.List-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.List"/></param>
        public void PutAll(Java.Util.List<Org.Apache.Kafka.Streams.KeyValue<K, V>> arg0)
        {
            IExecute("putAll", arg0);
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}