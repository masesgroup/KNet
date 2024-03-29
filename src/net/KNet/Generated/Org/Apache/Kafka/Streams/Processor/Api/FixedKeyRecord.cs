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

namespace Org.Apache.Kafka.Streams.Processor.Api
{
    #region FixedKeyRecord
    public partial class FixedKeyRecord
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
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/processor/api/FixedKeyRecord.html#withValue-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><see cref="object"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Processor.Api.FixedKeyRecord"/></returns>
        public Org.Apache.Kafka.Streams.Processor.Api.FixedKeyRecord WithValue(object arg0)
        {
            return IExecuteWithSignature<Org.Apache.Kafka.Streams.Processor.Api.FixedKeyRecord>("withValue", "(Ljava/lang/Object;)Lorg/apache/kafka/streams/processor/api/FixedKeyRecord;", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/processor/api/FixedKeyRecord.html#key--"/>
        /// </summary>

        /// <returns><see cref="object"/></returns>
        public object Key()
        {
            return IExecuteWithSignature("key", "()Ljava/lang/Object;");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/processor/api/FixedKeyRecord.html#timestamp--"/>
        /// </summary>

        /// <returns><see cref="long"/></returns>
        public long Timestamp()
        {
            return IExecuteWithSignature<long>("timestamp", "()J");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/processor/api/FixedKeyRecord.html#headers--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.Header.Headers"/></returns>
        public Org.Apache.Kafka.Common.Header.Headers Headers()
        {
            return IExecuteWithSignature<Org.Apache.Kafka.Common.Header.Headers>("headers", "()Lorg/apache/kafka/common/header/Headers;");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/processor/api/FixedKeyRecord.html#withHeaders-org.apache.kafka.common.header.Headers-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Header.Headers"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Processor.Api.FixedKeyRecord"/></returns>
        public Org.Apache.Kafka.Streams.Processor.Api.FixedKeyRecord WithHeaders(Org.Apache.Kafka.Common.Header.Headers arg0)
        {
            return IExecuteWithSignature<Org.Apache.Kafka.Streams.Processor.Api.FixedKeyRecord>("withHeaders", "(Lorg/apache/kafka/common/header/Headers;)Lorg/apache/kafka/streams/processor/api/FixedKeyRecord;", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/processor/api/FixedKeyRecord.html#withTimestamp-long-"/>
        /// </summary>
        /// <param name="arg0"><see cref="long"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Processor.Api.FixedKeyRecord"/></returns>
        public Org.Apache.Kafka.Streams.Processor.Api.FixedKeyRecord WithTimestamp(long arg0)
        {
            return IExecuteWithSignature<Org.Apache.Kafka.Streams.Processor.Api.FixedKeyRecord>("withTimestamp", "(J)Lorg/apache/kafka/streams/processor/api/FixedKeyRecord;", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/processor/api/FixedKeyRecord.html#value--"/>
        /// </summary>

        /// <returns><see cref="object"/></returns>
        public object Value()
        {
            return IExecuteWithSignature("value", "()Ljava/lang/Object;");
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion

    #region FixedKeyRecord<K, V>
    public partial class FixedKeyRecord<K, V>
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators
        /// <summary>
        /// Converter from <see cref="Org.Apache.Kafka.Streams.Processor.Api.FixedKeyRecord{K, V}"/> to <see cref="Org.Apache.Kafka.Streams.Processor.Api.FixedKeyRecord"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.Processor.Api.FixedKeyRecord(Org.Apache.Kafka.Streams.Processor.Api.FixedKeyRecord<K, V> t) => t.Cast<Org.Apache.Kafka.Streams.Processor.Api.FixedKeyRecord>();

        #endregion

        #region Fields

        #endregion

        #region Static methods

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/processor/api/FixedKeyRecord.html#withValue-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="NewV"/></param>
        /// <typeparam name="NewV"></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Processor.Api.FixedKeyRecord"/></returns>
        public Org.Apache.Kafka.Streams.Processor.Api.FixedKeyRecord<K, NewV> WithValue<NewV>(NewV arg0)
        {
            return IExecuteWithSignature<Org.Apache.Kafka.Streams.Processor.Api.FixedKeyRecord<K, NewV>>("withValue", "(Ljava/lang/Object;)Lorg/apache/kafka/streams/processor/api/FixedKeyRecord;", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/processor/api/FixedKeyRecord.html#key--"/>
        /// </summary>

        /// <returns><typeparamref name="K"/></returns>
        public K Key()
        {
            return IExecuteWithSignature<K>("key", "()Ljava/lang/Object;");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/processor/api/FixedKeyRecord.html#timestamp--"/>
        /// </summary>

        /// <returns><see cref="long"/></returns>
        public long Timestamp()
        {
            return IExecuteWithSignature<long>("timestamp", "()J");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/processor/api/FixedKeyRecord.html#headers--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.Header.Headers"/></returns>
        public Org.Apache.Kafka.Common.Header.Headers Headers()
        {
            return IExecuteWithSignature<Org.Apache.Kafka.Common.Header.Headers>("headers", "()Lorg/apache/kafka/common/header/Headers;");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/processor/api/FixedKeyRecord.html#withHeaders-org.apache.kafka.common.header.Headers-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Header.Headers"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Processor.Api.FixedKeyRecord"/></returns>
        public Org.Apache.Kafka.Streams.Processor.Api.FixedKeyRecord<K, V> WithHeaders(Org.Apache.Kafka.Common.Header.Headers arg0)
        {
            return IExecuteWithSignature<Org.Apache.Kafka.Streams.Processor.Api.FixedKeyRecord<K, V>>("withHeaders", "(Lorg/apache/kafka/common/header/Headers;)Lorg/apache/kafka/streams/processor/api/FixedKeyRecord;", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/processor/api/FixedKeyRecord.html#withTimestamp-long-"/>
        /// </summary>
        /// <param name="arg0"><see cref="long"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Processor.Api.FixedKeyRecord"/></returns>
        public Org.Apache.Kafka.Streams.Processor.Api.FixedKeyRecord<K, V> WithTimestamp(long arg0)
        {
            return IExecuteWithSignature<Org.Apache.Kafka.Streams.Processor.Api.FixedKeyRecord<K, V>>("withTimestamp", "(J)Lorg/apache/kafka/streams/processor/api/FixedKeyRecord;", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/processor/api/FixedKeyRecord.html#value--"/>
        /// </summary>

        /// <returns><typeparamref name="V"/></returns>
        public V Value()
        {
            return IExecuteWithSignature<V>("value", "()Ljava/lang/Object;");
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}