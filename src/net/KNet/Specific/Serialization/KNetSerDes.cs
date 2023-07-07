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

using Java.Nio;
using Org.Apache.Kafka.Common.Header;
using Org.Apache.Kafka.Common.Serialization;
using System;

namespace MASES.KNet.Serialization
{
    /// <summary>
    /// Common serializer/deserializer
    /// </summary>
    /// <typeparam name="T">The type to serialize/deserialize</typeparam>
    public class KNetSerDes<T> : IKNetSerializer<T>, IKNetDeserializer<T>
    {
        readonly bool _IsGenericTypeManaged = KNetSerialization.IsInternalManaged<T>();
        readonly KNetSerialization.SerializationType _SerializationType = KNetSerialization.InternalSerDesType<T>();
        Serializer<byte[]> _KafkaSerializer = new ByteArraySerializer();
        Deserializer<byte[]> _KafkaDeserializer = new ByteArrayDeserializer();
        /// <summary>
        /// Initialize a new <see cref="KNetSerDes{T}"/>
        /// </summary>
        /// <exception cref="InvalidOperationException">The <typeparamref name="T"/> needs an external serializer</exception>
        public KNetSerDes()
        {
            if (!IsGenericTypeManaged) throw new InvalidOperationException($"{typeof(T)} needs an external serializer, use a different constructor.");
        }
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
        /// <summary>
        /// Finalizer
        /// </summary>
        ~KNetSerDes()
        {
            Dispose();
        }
        /// <inheritdoc cref="IDisposable.Dispose"/>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            _KafkaSerializer?.Dispose();
            _KafkaSerializer = null;
            _KafkaDeserializer?.Dispose();
            _KafkaDeserializer = null;
        }
        /// <summary>
        /// Override in derived classes to indicate the class is able to manage complex types, default is the result of <see cref="KNetSerialization.IsInternalManaged{T}()"/>
        /// </summary>
        protected virtual bool IsGenericTypeManaged => _IsGenericTypeManaged;
        /// <inheritdoc cref="IKNetSerializer{T}.KafkaSerializer"/>
        public Serializer<byte[]> KafkaSerializer => _KafkaSerializer;
        /// <inheritdoc cref="IKNetDeserializer{T}.KafkaDeserializer"/>
        public Deserializer<byte[]> KafkaDeserializer => _KafkaDeserializer;
        /// <inheritdoc cref="IKNetDeserializer{T}.UseHeaders"/>
        public virtual bool UseHeaders => false;
        /// <inheritdoc cref="IKNetSerializer{T}.Serialize(string, T)"/>
        public virtual byte[] Serialize(string topic, T data)
        {
            if (OnSerialize != null)
            {
                return OnSerialize.Invoke(topic, data);
            }
            return _SerializationType switch
            {
                KNetSerialization.SerializationType.ByteArray => KNetSerialization.SerializeByteArray(topic, data as byte[]),
                KNetSerialization.SerializationType.ByteBuffer => KNetSerialization.SerializeByteBuffer(topic, data as ByteBuffer),
                KNetSerialization.SerializationType.Bytes => KNetSerialization.SerializeBytes(topic, data as Org.Apache.Kafka.Common.Utils.Bytes),
                KNetSerialization.SerializationType.Double => KNetSerialization.SerializeDouble(topic, (double)Convert.ChangeType(data, typeof(double))),
                KNetSerialization.SerializationType.Float => KNetSerialization.SerializeFloat(topic, (float)Convert.ChangeType(data, typeof(float))),
                KNetSerialization.SerializationType.Int => KNetSerialization.SerializeInt(topic, (int)Convert.ChangeType(data, typeof(int))),
                KNetSerialization.SerializationType.Long => KNetSerialization.SerializeLong(topic, (long)Convert.ChangeType(data, typeof(long))),
                KNetSerialization.SerializationType.Short => KNetSerialization.SerializeShort(topic, (short)Convert.ChangeType(data, typeof(short))),
                KNetSerialization.SerializationType.String => KNetSerialization.SerializeString(topic, data as string),
                KNetSerialization.SerializationType.Guid => KNetSerialization.SerializeGuid(topic, (Guid)Convert.ChangeType(data, typeof(Guid))),
                KNetSerialization.SerializationType.Void => KNetSerialization.SerializeVoid(topic, data as Java.Lang.Void),
                _ => default,
            };
        }
        /// <inheritdoc cref="IKNetSerializer{T}.SerializeWithHeaders(string, Headers, T)"/>
        public virtual byte[] SerializeWithHeaders(string topic, Headers headers, T data)
        {
            if (OnSerializeWithHeaders != null)
            {
                return OnSerializeWithHeaders.Invoke(topic, headers, data);
            }
            return Serialize(topic, data);
        }

        /// <inheritdoc cref="IKNetDeserializer{T}.Deserialize(string, byte[])"/>
        public virtual T Deserialize(string topic, byte[] data)
        {
            if (OnDeserialize != null)
            {
                return OnDeserialize.Invoke(topic, data);
            }
            return _SerializationType switch
            {
                KNetSerialization.SerializationType.ByteArray => (T)(object)KNetSerialization.DeserializeByteArray(topic, data),
                KNetSerialization.SerializationType.ByteBuffer => (T)(object)KNetSerialization.DeserializeByteBuffer(topic, data),
                KNetSerialization.SerializationType.Bytes => (T)(object)KNetSerialization.DeserializeBytes(topic, data),
                KNetSerialization.SerializationType.Double => (T)(object)KNetSerialization.DeserializeDouble(topic, data),
                KNetSerialization.SerializationType.Float => (T)(object)KNetSerialization.DeserializeFloat(topic, data),
                KNetSerialization.SerializationType.Int => (T)(object)KNetSerialization.DeserializeInt(topic, data),
                KNetSerialization.SerializationType.Long => (T)(object)KNetSerialization.DeserializeLong(topic, data),
                KNetSerialization.SerializationType.String => (T)(object)KNetSerialization.DeserializeString(topic, data),
                KNetSerialization.SerializationType.Guid => (T)(object)KNetSerialization.DeserializeGuid(topic, data),
                KNetSerialization.SerializationType.Void => (T)(object)KNetSerialization.DeserializeVoid(topic, data),
                _ => default,
            };
        }
        /// <inheritdoc cref="IKNetDeserializer{T}.DeserializeWithHeaders(string, Headers, byte[])"/>
        public virtual T DeserializeWithHeaders(string topic, Headers headers, byte[] data)
        {
            if (OnDeserializeWithHeaders != null)
            {
                return OnDeserializeWithHeaders.Invoke(topic, headers, data);
            }

            return Deserialize(topic, data);
        }
    }
}
