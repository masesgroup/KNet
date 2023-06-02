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
*  This file is generated by MASES.JNetReflector (ver. 1.5.5.0)
*  using kafka-clients-3.4.0.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Clients.Producer
{
    #region ProducerRecord
    public partial class ProducerRecord
    {
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/clients/producer/ProducerRecord.html#%3Cinit%3E(java.lang.String,java.lang.Integer,java.lang.Long,java.lang.Object,java.lang.Object,java.lang.Iterable)"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="int"/></param>
        /// <param name="arg2"><see cref="long"/></param>
        /// <param name="arg3"><see cref="object"/></param>
        /// <param name="arg4"><see cref="object"/></param>
        /// <param name="arg5"><see cref="Java.Lang.Iterable"/></param>
        public ProducerRecord(string arg0, int? arg1, long? arg2, object arg3, object arg4, Java.Lang.Iterable arg5)
            : base(arg0, arg1, arg2, arg3, arg4, arg5)
        {
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/clients/producer/ProducerRecord.html#%3Cinit%3E(java.lang.String,java.lang.Integer,java.lang.Long,java.lang.Object,java.lang.Object)"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="int"/></param>
        /// <param name="arg2"><see cref="long"/></param>
        /// <param name="arg3"><see cref="object"/></param>
        /// <param name="arg4"><see cref="object"/></param>
        public ProducerRecord(string arg0, int? arg1, long? arg2, object arg3, object arg4)
            : base(arg0, arg1, arg2, arg3, arg4)
        {
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/clients/producer/ProducerRecord.html#%3Cinit%3E(java.lang.String,java.lang.Integer,java.lang.Object,java.lang.Object,java.lang.Iterable)"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="int"/></param>
        /// <param name="arg2"><see cref="object"/></param>
        /// <param name="arg3"><see cref="object"/></param>
        /// <param name="arg4"><see cref="Java.Lang.Iterable"/></param>
        public ProducerRecord(string arg0, int? arg1, object arg2, object arg3, Java.Lang.Iterable arg4)
            : base(arg0, arg1, arg2, arg3, arg4)
        {
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/clients/producer/ProducerRecord.html#%3Cinit%3E(java.lang.String,java.lang.Integer,java.lang.Object,java.lang.Object)"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="int"/></param>
        /// <param name="arg2"><see cref="object"/></param>
        /// <param name="arg3"><see cref="object"/></param>
        public ProducerRecord(string arg0, int? arg1, object arg2, object arg3)
            : base(arg0, arg1, arg2, arg3)
        {
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/clients/producer/ProducerRecord.html#%3Cinit%3E(java.lang.String,java.lang.Object,java.lang.Object)"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="object"/></param>
        /// <param name="arg2"><see cref="object"/></param>
        public ProducerRecord(string arg0, object arg1, object arg2)
            : base(arg0, arg1, arg2)
        {
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/clients/producer/ProducerRecord.html#%3Cinit%3E(java.lang.String,java.lang.Object)"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="object"/></param>
        public ProducerRecord(string arg0, object arg1)
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
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/clients/producer/ProducerRecord.html#partition()"/>
        /// </summary>

        /// <returns><see cref="int"/></returns>
        public int? Partition()
        {
            return IExecute<int?>("partition");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/clients/producer/ProducerRecord.html#timestamp()"/>
        /// </summary>

        /// <returns><see cref="long"/></returns>
        public long? Timestamp()
        {
            return IExecute<long?>("timestamp");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/clients/producer/ProducerRecord.html#topic()"/>
        /// </summary>

        /// <returns><see cref="string"/></returns>
        public string Topic()
        {
            return IExecute<string>("topic");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/clients/producer/ProducerRecord.html#key()"/>
        /// </summary>

        /// <returns><see cref="object"/></returns>
        public object Key()
        {
            return IExecute("key");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/clients/producer/ProducerRecord.html#headers()"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.Header.Headers"/></returns>
        public Org.Apache.Kafka.Common.Header.Headers Headers()
        {
            return IExecute<Org.Apache.Kafka.Common.Header.Headers>("headers");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/clients/producer/ProducerRecord.html#value()"/>
        /// </summary>

        /// <returns><see cref="object"/></returns>
        public object Value()
        {
            return IExecute("value");
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion

    #region ProducerRecord<K, V>
    public partial class ProducerRecord<K, V>
    {
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/clients/producer/ProducerRecord.html#%3Cinit%3E(java.lang.String,java.lang.Integer,java.lang.Long,java.lang.Object,java.lang.Object,java.lang.Iterable)"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="int"/></param>
        /// <param name="arg2"><see cref="long"/></param>
        /// <param name="arg3"><typeparamref name="K"/></param>
        /// <param name="arg4"><typeparamref name="V"/></param>
        /// <param name="arg5"><see cref="Java.Lang.Iterable"/></param>
        public ProducerRecord(string arg0, int? arg1, long? arg2, K arg3, V arg4, Java.Lang.Iterable<Org.Apache.Kafka.Common.Header.Header> arg5)
            : base(arg0, arg1, arg2, arg3, arg4, arg5)
        {
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/clients/producer/ProducerRecord.html#%3Cinit%3E(java.lang.String,java.lang.Integer,java.lang.Long,java.lang.Object,java.lang.Object)"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="int"/></param>
        /// <param name="arg2"><see cref="long"/></param>
        /// <param name="arg3"><typeparamref name="K"/></param>
        /// <param name="arg4"><typeparamref name="V"/></param>
        public ProducerRecord(string arg0, int? arg1, long? arg2, K arg3, V arg4)
            : base(arg0, arg1, arg2, arg3, arg4)
        {
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/clients/producer/ProducerRecord.html#%3Cinit%3E(java.lang.String,java.lang.Integer,java.lang.Object,java.lang.Object,java.lang.Iterable)"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="int"/></param>
        /// <param name="arg2"><typeparamref name="K"/></param>
        /// <param name="arg3"><typeparamref name="V"/></param>
        /// <param name="arg4"><see cref="Java.Lang.Iterable"/></param>
        public ProducerRecord(string arg0, int? arg1, K arg2, V arg3, Java.Lang.Iterable<Org.Apache.Kafka.Common.Header.Header> arg4)
            : base(arg0, arg1, arg2, arg3, arg4)
        {
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/clients/producer/ProducerRecord.html#%3Cinit%3E(java.lang.String,java.lang.Integer,java.lang.Object,java.lang.Object)"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="int"/></param>
        /// <param name="arg2"><typeparamref name="K"/></param>
        /// <param name="arg3"><typeparamref name="V"/></param>
        public ProducerRecord(string arg0, int? arg1, K arg2, V arg3)
            : base(arg0, arg1, arg2, arg3)
        {
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/clients/producer/ProducerRecord.html#%3Cinit%3E(java.lang.String,java.lang.Object,java.lang.Object)"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><typeparamref name="K"/></param>
        /// <param name="arg2"><typeparamref name="V"/></param>
        public ProducerRecord(string arg0, K arg1, V arg2)
            : base(arg0, arg1, arg2)
        {
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/clients/producer/ProducerRecord.html#%3Cinit%3E(java.lang.String,java.lang.Object)"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><typeparamref name="V"/></param>
        public ProducerRecord(string arg0, V arg1)
            : base(arg0, arg1)
        {
        }

        #endregion

        #region Class/Interface conversion operators
        /// <summary>
        /// Converter from <see cref="Org.Apache.Kafka.Clients.Producer.ProducerRecord{K, V}"/> to <see cref="Org.Apache.Kafka.Clients.Producer.ProducerRecord"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Clients.Producer.ProducerRecord(Org.Apache.Kafka.Clients.Producer.ProducerRecord<K, V> t) => t.Cast<Org.Apache.Kafka.Clients.Producer.ProducerRecord>();

        #endregion

        #region Fields

        #endregion

        #region Static methods

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/clients/producer/ProducerRecord.html#partition()"/>
        /// </summary>

        /// <returns><see cref="int"/></returns>
        public int? Partition()
        {
            return IExecute<int?>("partition");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/clients/producer/ProducerRecord.html#timestamp()"/>
        /// </summary>

        /// <returns><see cref="long"/></returns>
        public long? Timestamp()
        {
            return IExecute<long?>("timestamp");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/clients/producer/ProducerRecord.html#topic()"/>
        /// </summary>

        /// <returns><see cref="string"/></returns>
        public string Topic()
        {
            return IExecute<string>("topic");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/clients/producer/ProducerRecord.html#key()"/>
        /// </summary>

        /// <returns><typeparamref name="K"/></returns>
        public K Key()
        {
            return IExecute<K>("key");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/clients/producer/ProducerRecord.html#headers()"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.Header.Headers"/></returns>
        public Org.Apache.Kafka.Common.Header.Headers Headers()
        {
            return IExecute<Org.Apache.Kafka.Common.Header.Headers>("headers");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/clients/producer/ProducerRecord.html#value()"/>
        /// </summary>

        /// <returns><typeparamref name="V"/></returns>
        public V Value()
        {
            return IExecute<V>("value");
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}