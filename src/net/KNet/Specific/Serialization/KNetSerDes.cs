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

using Java.Nio;
using MASES.JCOBridge.C2JBridge;
using Org.Apache.Kafka.Common.Header;
using Org.Apache.Kafka.Common.Serialization;
using System;

namespace MASES.KNet.Serialization
{
    /// <summary>
    /// KNet common serializer/deserializer
    /// </summary>
    /// <typeparam name="T">The type to serialize/deserialize</typeparam>
    /// <typeparam name="TJVMT">The corresponding JVM type used</typeparam>
    public interface ISerDes<T, TJVMT> : ISerializer<T, TJVMT>, IDeserializer<T, TJVMT>
    {
        /// <summary>
        /// The <see cref="Serde{T}"/> to use in Apache Kafka
        /// </summary>
        Serde<TJVMT> KafkaSerde { get; }
    }

    /// <summary>
    /// KNet common serializer/deserializer based on <see cref="byte"/> array JVM type
    /// </summary>
    /// <typeparam name="T">The type to serialize/deserialize</typeparam>
    public interface ISerDes<T> : ISerDes<T, byte[]>, ISerializer<T>, IDeserializer<T>
    {

    }

    /// <summary>
    /// Common serializer/deserializer
    /// </summary>
    /// <typeparam name="T">The type to serialize/deserialize</typeparam>
    /// <typeparam name="TJVMT">The corresponding JVM type used</typeparam>
    public class SerDes<T, TJVMT> : ISerDes<T, TJVMT>
    {
        #region private fields
        readonly KNetSerialization.SerializationType _SerializationType;
        readonly KNetSerialization.SerializationType _JVMSerializationType;
        Serdes.WrapperSerde<TJVMT> _KafkaWrapperSerde;
        Serde<TJVMT> _KafkaSerde;
        Serializer<TJVMT> _KafkaSerializer;
        Deserializer<TJVMT> _KafkaDeserializer;
        #endregion

        #region Constructor
        /// <summary>
        /// Default initializer
        /// </summary>
        public SerDes()
        {
            _SerializationType = KNetSerialization.InternalSerDesType<T>();
            _JVMSerializationType = KNetSerialization.InternalJVMSerDesType<TJVMT>();
            if (_JVMSerializationType == KNetSerialization.SerializationType.External)
            {
                throw new ArgumentException($"Cannot manage {typeof(TJVMT).FullName} into TJVMT generic parameter");
            }

            if (_SerializationType == KNetSerialization.SerializationType.External &&
                _JVMSerializationType != KNetSerialization.SerializationType.ByteArray)
            {
                throw new InvalidOperationException($"Serialization of {typeof(T).Name} can only be managed with TJVMT set to byte[].");
            }

            switch (_SerializationType)
            {
                case KNetSerialization.SerializationType.External:
                    if (_JVMSerializationType != KNetSerialization.SerializationType.ByteArray)
                    {
                        throw new InvalidOperationException($"Serialization of {typeof(T).Name} can only be managed with TJVMT set to byte[].");
                    }
                    break;
                case KNetSerialization.SerializationType.Boolean:
                case KNetSerialization.SerializationType.ByteArray:
                case KNetSerialization.SerializationType.ByteBuffer:
                case KNetSerialization.SerializationType.Bytes:
                case KNetSerialization.SerializationType.Double:
                case KNetSerialization.SerializationType.Float:
                case KNetSerialization.SerializationType.Integer:
                case KNetSerialization.SerializationType.Long:
                case KNetSerialization.SerializationType.Short:
                case KNetSerialization.SerializationType.String:
                case KNetSerialization.SerializationType.Guid:
                case KNetSerialization.SerializationType.Void:
                    if (_JVMSerializationType != _SerializationType && _JVMSerializationType != KNetSerialization.SerializationType.ByteArray)
                    {
                        throw new InvalidOperationException($"{typeof(T).Name} is incompatible with {typeof(TJVMT).Name}.");
                    }
                    break;
                default:
                    throw new InvalidOperationException($"{_SerializationType} is not valid.");
            }

            var kafkaSerde = _JVMSerializationType switch
            {
                KNetSerialization.SerializationType.Boolean => Serdes.Boolean().Cast<Serdes.WrapperSerde<TJVMT>>(),
                KNetSerialization.SerializationType.ByteArray => Serdes.ByteArray().Cast<Serdes.WrapperSerde<TJVMT>>(),
                KNetSerialization.SerializationType.ByteBuffer => Serdes.ByteBuffer().Cast<Serdes.WrapperSerde<TJVMT>>(),
                KNetSerialization.SerializationType.Bytes => Serdes.Bytes().Cast<Serdes.WrapperSerde<TJVMT>>(),
                KNetSerialization.SerializationType.Double => Serdes.Double().Cast<Serdes.WrapperSerde<TJVMT>>(),
                KNetSerialization.SerializationType.Float => Serdes.Float().Cast<Serdes.WrapperSerde<TJVMT>>(),
                KNetSerialization.SerializationType.Integer => Serdes.Integer().Cast<Serdes.WrapperSerde<TJVMT>>(),
                KNetSerialization.SerializationType.Long => Serdes.Long().Cast<Serdes.WrapperSerde<TJVMT>>(),
                KNetSerialization.SerializationType.Short => Serdes.Short().Cast<Serdes.WrapperSerde<TJVMT>>(),
                KNetSerialization.SerializationType.String => Serdes.String().Cast<Serdes.WrapperSerde<TJVMT>>(),
                KNetSerialization.SerializationType.Guid => Serdes.UUID().Cast<Serdes.WrapperSerde<TJVMT>>(),
                KNetSerialization.SerializationType.Void => Serdes.Void().Cast<Serdes.WrapperSerde<TJVMT>>(),
                KNetSerialization.SerializationType.External => throw new InvalidOperationException($"{typeof(T)} needs an external serializer: set {nameof(OnSerialize)} or {nameof(OnSerializeWithHeaders)}."),
                _ => default,
            };

            _KafkaSerializer = kafkaSerde.Serializer();
            _KafkaDeserializer = kafkaSerde.Deserializer();

            _KafkaSerde = kafkaSerde;
        }
        /// <summary>
        /// Finalizer
        /// </summary>
        ~SerDes()
        {
            Dispose();
        }
        /// <inheritdoc cref="IDisposable.Dispose"/>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            _KafkaSerde = null;
            _KafkaSerializer = null;
            _KafkaDeserializer = null;
            _KafkaWrapperSerde = null;
        }
        #endregion

        #region IKNetSerDes<T>
        /// <summary>
        /// External serialization function
        /// </summary>
        public Func<string, T, byte[]> OnSerialize { get; set; }
        /// <summary>
        /// External serialization function using <see cref="Headers"/>
        /// </summary>
        public Func<string, Headers, T, byte[]> OnSerializeWithHeaders { get; set; }
        /// <summary>
        /// External deserialization function
        /// </summary>
        public Func<string, byte[], T> OnDeserialize { get; set; }
        /// <summary>
        /// External deserialization function using <see cref="Headers"/>
        /// </summary>
        public Func<string, Headers, byte[], T> OnDeserializeWithHeaders { get; set; }
        /// <inheritdoc cref="ISerDes{T, TJVMT}.KafkaSerde"/>
        public Serde<TJVMT> KafkaSerde => _KafkaSerde;
        /// <inheritdoc cref="ISerializer{T, TJVMT}.KafkaSerializer"/>
        public Serializer<TJVMT> KafkaSerializer => _KafkaSerializer;
        /// <inheritdoc cref="IDeserializer{T, TJVMT}.KafkaDeserializer"/>
        public Deserializer<TJVMT> KafkaDeserializer => _KafkaDeserializer;
        /// <inheritdoc cref="IDeserializer{T, TJVMT}.UseHeaders"/>
        public virtual bool UseHeaders => false;
        /// <inheritdoc cref="ISerializer{T, TJVMT}.Serialize(string, T)"/>
        public virtual byte[] Serialize(string topic, T data)
        {
            if (OnSerialize != null)
            {
                return OnSerialize.Invoke(topic, data);
            }
            return _SerializationType switch
            {
                KNetSerialization.SerializationType.Boolean => KNetSerialization.SerializeBoolean(topic, (bool)Convert.ChangeType(data, typeof(bool))),
                KNetSerialization.SerializationType.ByteArray => KNetSerialization.SerializeByteArray(topic, data as byte[]),
                KNetSerialization.SerializationType.ByteBuffer => KNetSerialization.SerializeByteBuffer(topic, data as ByteBuffer),
                KNetSerialization.SerializationType.Bytes => KNetSerialization.SerializeBytes(topic, data as Org.Apache.Kafka.Common.Utils.Bytes),
                KNetSerialization.SerializationType.Double => KNetSerialization.SerializeDouble(topic, (double)Convert.ChangeType(data, typeof(double))),
                KNetSerialization.SerializationType.Float => KNetSerialization.SerializeFloat(topic, (float)Convert.ChangeType(data, typeof(float))),
                KNetSerialization.SerializationType.Integer => KNetSerialization.SerializeInt(topic, (int)Convert.ChangeType(data, typeof(int))),
                KNetSerialization.SerializationType.Long => KNetSerialization.SerializeLong(topic, (long)Convert.ChangeType(data, typeof(long))),
                KNetSerialization.SerializationType.Short => KNetSerialization.SerializeShort(topic, (short)Convert.ChangeType(data, typeof(short))),
                KNetSerialization.SerializationType.String => KNetSerialization.SerializeString(topic, data as string),
                KNetSerialization.SerializationType.Guid => KNetSerialization.SerializeGuid(topic, (Guid)Convert.ChangeType(data, typeof(Guid))),
                KNetSerialization.SerializationType.Void => KNetSerialization.SerializeVoid(topic, data as Java.Lang.Void),
                KNetSerialization.SerializationType.External => throw new InvalidOperationException($"{typeof(T)} needs an external serializer: set {nameof(OnSerialize)} or {nameof(OnSerializeWithHeaders)}."),
                _ => default,
            };
        }
        /// <inheritdoc cref="ISerializer{T, TJVMT}.SerializeWithHeaders(string, Headers, T)"/>
        public virtual byte[] SerializeWithHeaders(string topic, Headers headers, T data)
        {
            if (OnSerializeWithHeaders != null)
            {
                return OnSerializeWithHeaders.Invoke(topic, headers, data);
            }
            return Serialize(topic, data);
        }

        /// <inheritdoc cref="IDeserializer{T, TJVMT}.Deserialize(string, byte[])"/>
        public virtual T Deserialize(string topic, byte[] data)
        {
            if (OnDeserialize != null)
            {
                return OnDeserialize.Invoke(topic, data);
            }
            return _SerializationType switch
            {
                KNetSerialization.SerializationType.Boolean => (T)(object)KNetSerialization.DeserializeBoolean(topic, data),
                KNetSerialization.SerializationType.ByteArray => (T)(object)KNetSerialization.DeserializeByteArray(topic, data),
                KNetSerialization.SerializationType.ByteBuffer => (T)(object)KNetSerialization.DeserializeByteBuffer(topic, data),
                KNetSerialization.SerializationType.Bytes => (T)(object)KNetSerialization.DeserializeBytes(topic, data),
                KNetSerialization.SerializationType.Double => (T)(object)KNetSerialization.DeserializeDouble(topic, data),
                KNetSerialization.SerializationType.Float => (T)(object)KNetSerialization.DeserializeFloat(topic, data),
                KNetSerialization.SerializationType.Integer => (T)(object)KNetSerialization.DeserializeInt(topic, data),
                KNetSerialization.SerializationType.Long => (T)(object)KNetSerialization.DeserializeLong(topic, data),
                KNetSerialization.SerializationType.String => (T)(object)KNetSerialization.DeserializeString(topic, data),
                KNetSerialization.SerializationType.Guid => (T)(object)KNetSerialization.DeserializeGuid(topic, data),
                KNetSerialization.SerializationType.Void => (T)(object)KNetSerialization.DeserializeVoid(topic, data),
                KNetSerialization.SerializationType.External => throw new InvalidOperationException($"{typeof(T)} needs an external deserializer: set {nameof(OnDeserialize)} or {nameof(OnDeserializeWithHeaders)}."),
                _ => default,
            };
        }
        /// <inheritdoc cref="IDeserializer{T, TJVMT}.DeserializeWithHeaders(string, Headers, byte[])"/>
        public virtual T DeserializeWithHeaders(string topic, Headers headers, byte[] data)
        {
            if (OnDeserializeWithHeaders != null)
            {
                return OnDeserializeWithHeaders.Invoke(topic, headers, data);
            }

            return Deserialize(topic, data);
        }
        #endregion
    }

    /// <summary>
    /// Common serializer/deserializer
    /// </summary>
    /// <typeparam name="T">The type to serialize/deserialize</typeparam>
    public class SerDes<T> : SerDes<T, byte[]>, ISerDes<T>
    {
    }

}
