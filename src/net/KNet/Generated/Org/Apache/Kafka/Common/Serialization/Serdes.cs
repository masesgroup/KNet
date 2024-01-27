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
*  This file is generated by MASES.JNetReflector (ver. 2.2.4.0)
*  using kafka-clients-3.6.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Common.Serialization
{
    #region Serdes
    public partial class Serdes
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/serialization/Serdes.html#ListSerde-java.lang.Class-org.apache.kafka.common.serialization.Serde-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.Class"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Common.Serialization.Serde"/></param>
        /// <typeparam name="Inner"></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Common.Serialization.Serde"/></returns>
        public static Org.Apache.Kafka.Common.Serialization.Serde<Java.Util.List<Inner>> ListSerdeMethod<Inner>(Java.Lang.Class arg0, Org.Apache.Kafka.Common.Serialization.Serde<Inner> arg1)
        {
            return SExecute<Org.Apache.Kafka.Common.Serialization.Serde<Java.Util.List<Inner>>>(LocalBridgeClazz, "ListSerde", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/serialization/Serdes.html#serdeFrom-java.lang.Class-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.Class"/></param>
        /// <typeparam name="T"></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Common.Serialization.Serde"/></returns>
        public static Org.Apache.Kafka.Common.Serialization.Serde<T> SerdeFrom<T>(Java.Lang.Class arg0)
        {
            return SExecute<Org.Apache.Kafka.Common.Serialization.Serde<T>>(LocalBridgeClazz, "serdeFrom", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/serialization/Serdes.html#serdeFrom-org.apache.kafka.common.serialization.Serializer-org.apache.kafka.common.serialization.Deserializer-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Serialization.Serializer"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Common.Serialization.Deserializer"/></param>
        /// <typeparam name="T"></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Common.Serialization.Serde"/></returns>
        public static Org.Apache.Kafka.Common.Serialization.Serde<T> SerdeFrom<T>(Org.Apache.Kafka.Common.Serialization.Serializer<T> arg0, Org.Apache.Kafka.Common.Serialization.Deserializer<T> arg1)
        {
            return SExecute<Org.Apache.Kafka.Common.Serialization.Serde<T>>(LocalBridgeClazz, "serdeFrom", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/serialization/Serdes.html#ByteArray--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.Serialization.Serde"/></returns>
        public static Org.Apache.Kafka.Common.Serialization.Serde<byte[]> ByteArray()
        {
            return SExecute<Org.Apache.Kafka.Common.Serialization.Serde<byte[]>>(LocalBridgeClazz, "ByteArray");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/serialization/Serdes.html#Boolean--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.Serialization.Serde"/></returns>
        public static Org.Apache.Kafka.Common.Serialization.Serde<Java.Lang.Boolean> Boolean()
        {
            return SExecute<Org.Apache.Kafka.Common.Serialization.Serde<Java.Lang.Boolean>>(LocalBridgeClazz, "Boolean");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/serialization/Serdes.html#Double--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.Serialization.Serde"/></returns>
        public static Org.Apache.Kafka.Common.Serialization.Serde<Java.Lang.Double> Double()
        {
            return SExecute<Org.Apache.Kafka.Common.Serialization.Serde<Java.Lang.Double>>(LocalBridgeClazz, "Double");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/serialization/Serdes.html#Float--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.Serialization.Serde"/></returns>
        public static Org.Apache.Kafka.Common.Serialization.Serde<Java.Lang.Float> Float()
        {
            return SExecute<Org.Apache.Kafka.Common.Serialization.Serde<Java.Lang.Float>>(LocalBridgeClazz, "Float");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/serialization/Serdes.html#Integer--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.Serialization.Serde"/></returns>
        public static Org.Apache.Kafka.Common.Serialization.Serde<Java.Lang.Integer> Integer()
        {
            return SExecute<Org.Apache.Kafka.Common.Serialization.Serde<Java.Lang.Integer>>(LocalBridgeClazz, "Integer");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/serialization/Serdes.html#Long--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.Serialization.Serde"/></returns>
        public static Org.Apache.Kafka.Common.Serialization.Serde<Java.Lang.Long> Long()
        {
            return SExecute<Org.Apache.Kafka.Common.Serialization.Serde<Java.Lang.Long>>(LocalBridgeClazz, "Long");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/serialization/Serdes.html#Short--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.Serialization.Serde"/></returns>
        public static Org.Apache.Kafka.Common.Serialization.Serde<Java.Lang.Short> Short()
        {
            return SExecute<Org.Apache.Kafka.Common.Serialization.Serde<Java.Lang.Short>>(LocalBridgeClazz, "Short");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/serialization/Serdes.html#String--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.Serialization.Serde"/></returns>
        public static Org.Apache.Kafka.Common.Serialization.Serde<string> String()
        {
            return SExecute<Org.Apache.Kafka.Common.Serialization.Serde<string>>(LocalBridgeClazz, "String");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/serialization/Serdes.html#Void--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.Serialization.Serde"/></returns>
        public static Org.Apache.Kafka.Common.Serialization.Serde<Java.Lang.Void> Void()
        {
            return SExecute<Org.Apache.Kafka.Common.Serialization.Serde<Java.Lang.Void>>(LocalBridgeClazz, "Void");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/serialization/Serdes.html#ByteBuffer--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.Serialization.Serde"/></returns>
        public static Org.Apache.Kafka.Common.Serialization.Serde<Java.Nio.ByteBuffer> ByteBuffer()
        {
            return SExecute<Org.Apache.Kafka.Common.Serialization.Serde<Java.Nio.ByteBuffer>>(LocalBridgeClazz, "ByteBuffer");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/serialization/Serdes.html#UUID--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.Serialization.Serde"/></returns>
        public static Org.Apache.Kafka.Common.Serialization.Serde<Java.Util.UUID> UUID()
        {
            return SExecute<Org.Apache.Kafka.Common.Serialization.Serde<Java.Util.UUID>>(LocalBridgeClazz, "UUID");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/serialization/Serdes.html#Bytes--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.Serialization.Serde"/></returns>
        public static Org.Apache.Kafka.Common.Serialization.Serde<Org.Apache.Kafka.Common.Utils.Bytes> Bytes()
        {
            return SExecute<Org.Apache.Kafka.Common.Serialization.Serde<Org.Apache.Kafka.Common.Utils.Bytes>>(LocalBridgeClazz, "Bytes");
        }

        #endregion

        #region Instance methods

        #endregion

        #region Nested classes
        #region BooleanSerde
        public partial class BooleanSerde
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

        #region ByteArraySerde
        public partial class ByteArraySerde
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

        #region ByteBufferSerde
        public partial class ByteBufferSerde
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

        #region BytesSerde
        public partial class BytesSerde
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

        #region DoubleSerde
        public partial class DoubleSerde
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

        #region FloatSerde
        public partial class FloatSerde
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

        #region IntegerSerde
        public partial class IntegerSerde
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

        #region ListSerde
        public partial class ListSerde
        {
            #region Constructors
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/serialization/Serdes.ListSerde.html#org.apache.kafka.common.serialization.Serdes$ListSerde(java.lang.Class,org.apache.kafka.common.serialization.Serde)"/>
            /// </summary>
            /// <param name="arg0"><see cref="Java.Lang.Class"/></param>
            /// <param name="arg1"><see cref="Org.Apache.Kafka.Common.Serialization.Serde"/></param>
            public ListSerde(Java.Lang.Class arg0, Org.Apache.Kafka.Common.Serialization.Serde arg1)
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

            #endregion

            #region Nested classes

            #endregion

            // TODO: complete the class
        }
        #endregion

        #region ListSerde<Inner>
        public partial class ListSerde<Inner>
        {
            #region Constructors
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/serialization/Serdes.ListSerde.html#org.apache.kafka.common.serialization.Serdes$ListSerde(java.lang.Class,org.apache.kafka.common.serialization.Serde)"/>
            /// </summary>
            /// <param name="arg0"><see cref="Java.Lang.Class"/></param>
            /// <param name="arg1"><see cref="Org.Apache.Kafka.Common.Serialization.Serde"/></param>
            public ListSerde(Java.Lang.Class arg0, Org.Apache.Kafka.Common.Serialization.Serde<Inner> arg1)
                : base(arg0, arg1)
            {
            }

            #endregion

            #region Class/Interface conversion operators
            /// <summary>
            /// Converter from <see cref="Org.Apache.Kafka.Common.Serialization.Serdes.ListSerde{Inner}"/> to <see cref="Org.Apache.Kafka.Common.Serialization.Serdes.ListSerde"/>
            /// </summary>
            public static implicit operator Org.Apache.Kafka.Common.Serialization.Serdes.ListSerde(Org.Apache.Kafka.Common.Serialization.Serdes.ListSerde<Inner> t) => t.Cast<Org.Apache.Kafka.Common.Serialization.Serdes.ListSerde>();

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

        #region LongSerde
        public partial class LongSerde
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

        #region ShortSerde
        public partial class ShortSerde
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

        #region StringSerde
        public partial class StringSerde
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

        #region UUIDSerde
        public partial class UUIDSerde
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

        #region VoidSerde
        public partial class VoidSerde
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

        #region WrapperSerde
        public partial class WrapperSerde
        {
            #region Constructors
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/serialization/Serdes.WrapperSerde.html#org.apache.kafka.common.serialization.Serdes$WrapperSerde(org.apache.kafka.common.serialization.Serializer,org.apache.kafka.common.serialization.Deserializer)"/>
            /// </summary>
            /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Serialization.Serializer"/></param>
            /// <param name="arg1"><see cref="Org.Apache.Kafka.Common.Serialization.Deserializer"/></param>
            public WrapperSerde(Org.Apache.Kafka.Common.Serialization.Serializer arg0, Org.Apache.Kafka.Common.Serialization.Deserializer arg1)
                : base(arg0, arg1)
            {
            }

            #endregion

            #region Class/Interface conversion operators
            /// <summary>
            /// Converter from <see cref="Org.Apache.Kafka.Common.Serialization.Serdes.WrapperSerde"/> to <see cref="Org.Apache.Kafka.Common.Serialization.Serde"/>
            /// </summary>
            public static implicit operator Org.Apache.Kafka.Common.Serialization.Serde(Org.Apache.Kafka.Common.Serialization.Serdes.WrapperSerde t) => t.Cast<Org.Apache.Kafka.Common.Serialization.Serde>();

            #endregion

            #region Fields

            #endregion

            #region Static methods

            #endregion

            #region Instance methods
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/serialization/Serdes.WrapperSerde.html#deserializer--"/>
            /// </summary>

            /// <returns><see cref="Org.Apache.Kafka.Common.Serialization.Deserializer"/></returns>
            public Org.Apache.Kafka.Common.Serialization.Deserializer Deserializer()
            {
                return IExecute<Org.Apache.Kafka.Common.Serialization.Deserializer>("deserializer");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/serialization/Serdes.WrapperSerde.html#serializer--"/>
            /// </summary>

            /// <returns><see cref="Org.Apache.Kafka.Common.Serialization.Serializer"/></returns>
            public Org.Apache.Kafka.Common.Serialization.Serializer Serializer()
            {
                return IExecute<Org.Apache.Kafka.Common.Serialization.Serializer>("serializer");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/serialization/Serdes.WrapperSerde.html#close--"/>
            /// </summary>
            public void Close()
            {
                IExecute("close");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/serialization/Serdes.WrapperSerde.html#configure-java.util.Map-boolean-"/>
            /// </summary>
            /// <param name="arg0"><see cref="Java.Util.Map"/></param>
            /// <param name="arg1"><see cref="bool"/></param>
            public void Configure(Java.Util.Map arg0, bool arg1)
            {
                IExecute("configure", arg0, arg1);
            }

            #endregion

            #region Nested classes

            #endregion

            // TODO: complete the class
        }
        #endregion

        #region WrapperSerde<T>
        public partial class WrapperSerde<T>
        {
            #region Constructors
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/serialization/Serdes.WrapperSerde.html#org.apache.kafka.common.serialization.Serdes$WrapperSerde(org.apache.kafka.common.serialization.Serializer,org.apache.kafka.common.serialization.Deserializer)"/>
            /// </summary>
            /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Serialization.Serializer"/></param>
            /// <param name="arg1"><see cref="Org.Apache.Kafka.Common.Serialization.Deserializer"/></param>
            public WrapperSerde(Org.Apache.Kafka.Common.Serialization.Serializer<T> arg0, Org.Apache.Kafka.Common.Serialization.Deserializer<T> arg1)
                : base(arg0, arg1)
            {
            }

            #endregion

            #region Class/Interface conversion operators
            /// <summary>
            /// Converter from <see cref="Org.Apache.Kafka.Common.Serialization.Serdes.WrapperSerde{T}"/> to <see cref="Org.Apache.Kafka.Common.Serialization.Serde{T}"/>
            /// </summary>
            public static implicit operator Org.Apache.Kafka.Common.Serialization.Serde<T>(Org.Apache.Kafka.Common.Serialization.Serdes.WrapperSerde<T> t) => t.Cast<Org.Apache.Kafka.Common.Serialization.Serde<T>>();
            /// <summary>
            /// Converter from <see cref="Org.Apache.Kafka.Common.Serialization.Serdes.WrapperSerde{T}"/> to <see cref="Org.Apache.Kafka.Common.Serialization.Serdes.WrapperSerde"/>
            /// </summary>
            public static implicit operator Org.Apache.Kafka.Common.Serialization.Serdes.WrapperSerde(Org.Apache.Kafka.Common.Serialization.Serdes.WrapperSerde<T> t) => t.Cast<Org.Apache.Kafka.Common.Serialization.Serdes.WrapperSerde>();

            #endregion

            #region Fields

            #endregion

            #region Static methods

            #endregion

            #region Instance methods
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/serialization/Serdes.WrapperSerde.html#deserializer--"/>
            /// </summary>

            /// <returns><see cref="Org.Apache.Kafka.Common.Serialization.Deserializer"/></returns>
            public Org.Apache.Kafka.Common.Serialization.Deserializer<T> Deserializer()
            {
                return IExecute<Org.Apache.Kafka.Common.Serialization.Deserializer<T>>("deserializer");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/serialization/Serdes.WrapperSerde.html#serializer--"/>
            /// </summary>

            /// <returns><see cref="Org.Apache.Kafka.Common.Serialization.Serializer"/></returns>
            public Org.Apache.Kafka.Common.Serialization.Serializer<T> Serializer()
            {
                return IExecute<Org.Apache.Kafka.Common.Serialization.Serializer<T>>("serializer");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/serialization/Serdes.WrapperSerde.html#close--"/>
            /// </summary>
            public void Close()
            {
                IExecute("close");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/serialization/Serdes.WrapperSerde.html#configure-java.util.Map-boolean-"/>
            /// </summary>
            /// <param name="arg0"><see cref="Java.Util.Map"/></param>
            /// <param name="arg1"><see cref="bool"/></param>
            public void Configure(Java.Util.Map<string, object> arg0, bool arg1)
            {
                IExecute("configure", arg0, arg1);
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