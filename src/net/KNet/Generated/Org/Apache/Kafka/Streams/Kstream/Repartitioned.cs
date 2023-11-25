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
    #region Repartitioned
    public partial class Repartitioned
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.0/org/apache/kafka/streams/kstream/Repartitioned.html#as-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Repartitioned"/></returns>
        public static Org.Apache.Kafka.Streams.Kstream.Repartitioned As(string arg0)
        {
            return SExecute<Org.Apache.Kafka.Streams.Kstream.Repartitioned>(LocalBridgeClazz, "as", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.0/org/apache/kafka/streams/kstream/Repartitioned.html#numberOfPartitions-int-"/>
        /// </summary>
        /// <param name="arg0"><see cref="int"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Repartitioned"/></returns>
        public static Org.Apache.Kafka.Streams.Kstream.Repartitioned NumberOfPartitions(int arg0)
        {
            return SExecute<Org.Apache.Kafka.Streams.Kstream.Repartitioned>(LocalBridgeClazz, "numberOfPartitions", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.0/org/apache/kafka/streams/kstream/Repartitioned.html#streamPartitioner-org.apache.kafka.streams.processor.StreamPartitioner-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Processor.StreamPartitioner"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Repartitioned"/></returns>
        public static Org.Apache.Kafka.Streams.Kstream.Repartitioned StreamPartitioner(Org.Apache.Kafka.Streams.Processor.StreamPartitioner arg0)
        {
            return SExecute<Org.Apache.Kafka.Streams.Kstream.Repartitioned>(LocalBridgeClazz, "streamPartitioner", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.0/org/apache/kafka/streams/kstream/Repartitioned.html#with-org.apache.kafka.common.serialization.Serde-org.apache.kafka.common.serialization.Serde-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Serialization.Serde"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Common.Serialization.Serde"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Repartitioned"/></returns>
        public static Org.Apache.Kafka.Streams.Kstream.Repartitioned With(Org.Apache.Kafka.Common.Serialization.Serde arg0, Org.Apache.Kafka.Common.Serialization.Serde arg1)
        {
            return SExecute<Org.Apache.Kafka.Streams.Kstream.Repartitioned>(LocalBridgeClazz, "with", arg0, arg1);
        }

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.0/org/apache/kafka/streams/kstream/Repartitioned.html#withKeySerde-org.apache.kafka.common.serialization.Serde-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Serialization.Serde"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Repartitioned"/></returns>
        public Org.Apache.Kafka.Streams.Kstream.Repartitioned WithKeySerde(Org.Apache.Kafka.Common.Serialization.Serde arg0)
        {
            return IExecute<Org.Apache.Kafka.Streams.Kstream.Repartitioned>("withKeySerde", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.0/org/apache/kafka/streams/kstream/Repartitioned.html#withNumberOfPartitions-int-"/>
        /// </summary>
        /// <param name="arg0"><see cref="int"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Repartitioned"/></returns>
        public Org.Apache.Kafka.Streams.Kstream.Repartitioned WithNumberOfPartitions(int arg0)
        {
            return IExecute<Org.Apache.Kafka.Streams.Kstream.Repartitioned>("withNumberOfPartitions", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.0/org/apache/kafka/streams/kstream/Repartitioned.html#withStreamPartitioner-org.apache.kafka.streams.processor.StreamPartitioner-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Processor.StreamPartitioner"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Repartitioned"/></returns>
        public Org.Apache.Kafka.Streams.Kstream.Repartitioned WithStreamPartitioner(Org.Apache.Kafka.Streams.Processor.StreamPartitioner arg0)
        {
            return IExecute<Org.Apache.Kafka.Streams.Kstream.Repartitioned>("withStreamPartitioner", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.0/org/apache/kafka/streams/kstream/Repartitioned.html#withValueSerde-org.apache.kafka.common.serialization.Serde-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Serialization.Serde"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Repartitioned"/></returns>
        public Org.Apache.Kafka.Streams.Kstream.Repartitioned WithValueSerde(Org.Apache.Kafka.Common.Serialization.Serde arg0)
        {
            return IExecute<Org.Apache.Kafka.Streams.Kstream.Repartitioned>("withValueSerde", arg0);
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion

    #region Repartitioned<K, V>
    public partial class Repartitioned<K, V>
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators
        /// <summary>
        /// Converter from <see cref="Org.Apache.Kafka.Streams.Kstream.Repartitioned{K, V}"/> to <see cref="Org.Apache.Kafka.Streams.Kstream.Repartitioned"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.Kstream.Repartitioned(Org.Apache.Kafka.Streams.Kstream.Repartitioned<K, V> t) => t.Cast<Org.Apache.Kafka.Streams.Kstream.Repartitioned>();

        #endregion

        #region Fields

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.0/org/apache/kafka/streams/kstream/Repartitioned.html#as-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Repartitioned"/></returns>
        public static Org.Apache.Kafka.Streams.Kstream.Repartitioned<K, V> As(string arg0)
        {
            return SExecute<Org.Apache.Kafka.Streams.Kstream.Repartitioned<K, V>>(LocalBridgeClazz, "as", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.0/org/apache/kafka/streams/kstream/Repartitioned.html#numberOfPartitions-int-"/>
        /// </summary>
        /// <param name="arg0"><see cref="int"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Repartitioned"/></returns>
        public static Org.Apache.Kafka.Streams.Kstream.Repartitioned<K, V> NumberOfPartitions(int arg0)
        {
            return SExecute<Org.Apache.Kafka.Streams.Kstream.Repartitioned<K, V>>(LocalBridgeClazz, "numberOfPartitions", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.0/org/apache/kafka/streams/kstream/Repartitioned.html#streamPartitioner-org.apache.kafka.streams.processor.StreamPartitioner-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Processor.StreamPartitioner"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Repartitioned"/></returns>
        public static Org.Apache.Kafka.Streams.Kstream.Repartitioned<K, V> StreamPartitioner(Org.Apache.Kafka.Streams.Processor.StreamPartitioner<K, V> arg0)
        {
            return SExecute<Org.Apache.Kafka.Streams.Kstream.Repartitioned<K, V>>(LocalBridgeClazz, "streamPartitioner", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.0/org/apache/kafka/streams/kstream/Repartitioned.html#with-org.apache.kafka.common.serialization.Serde-org.apache.kafka.common.serialization.Serde-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Serialization.Serde"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Common.Serialization.Serde"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Repartitioned"/></returns>
        public static Org.Apache.Kafka.Streams.Kstream.Repartitioned<K, V> With(Org.Apache.Kafka.Common.Serialization.Serde<K> arg0, Org.Apache.Kafka.Common.Serialization.Serde<V> arg1)
        {
            return SExecute<Org.Apache.Kafka.Streams.Kstream.Repartitioned<K, V>>(LocalBridgeClazz, "with", arg0, arg1);
        }

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.0/org/apache/kafka/streams/kstream/Repartitioned.html#withKeySerde-org.apache.kafka.common.serialization.Serde-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Serialization.Serde"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Repartitioned"/></returns>
        public Org.Apache.Kafka.Streams.Kstream.Repartitioned<K, V> WithKeySerde(Org.Apache.Kafka.Common.Serialization.Serde<K> arg0)
        {
            return IExecute<Org.Apache.Kafka.Streams.Kstream.Repartitioned<K, V>>("withKeySerde", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.0/org/apache/kafka/streams/kstream/Repartitioned.html#withNumberOfPartitions-int-"/>
        /// </summary>
        /// <param name="arg0"><see cref="int"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Repartitioned"/></returns>
        public Org.Apache.Kafka.Streams.Kstream.Repartitioned<K, V> WithNumberOfPartitions(int arg0)
        {
            return IExecute<Org.Apache.Kafka.Streams.Kstream.Repartitioned<K, V>>("withNumberOfPartitions", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.0/org/apache/kafka/streams/kstream/Repartitioned.html#withStreamPartitioner-org.apache.kafka.streams.processor.StreamPartitioner-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Processor.StreamPartitioner"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Repartitioned"/></returns>
        public Org.Apache.Kafka.Streams.Kstream.Repartitioned<K, V> WithStreamPartitioner(Org.Apache.Kafka.Streams.Processor.StreamPartitioner<K, V> arg0)
        {
            return IExecute<Org.Apache.Kafka.Streams.Kstream.Repartitioned<K, V>>("withStreamPartitioner", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.0/org/apache/kafka/streams/kstream/Repartitioned.html#withValueSerde-org.apache.kafka.common.serialization.Serde-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Serialization.Serde"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Repartitioned"/></returns>
        public Org.Apache.Kafka.Streams.Kstream.Repartitioned<K, V> WithValueSerde(Org.Apache.Kafka.Common.Serialization.Serde<V> arg0)
        {
            return IExecute<Org.Apache.Kafka.Streams.Kstream.Repartitioned<K, V>>("withValueSerde", arg0);
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}