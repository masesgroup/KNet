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
using MASES.KNet.Common.Header;
using MASES.KNet.Common.Serialization;
using System;

namespace MASES.KNet.Serialization
{
    public class KNetSerDes<T> : IKNetSerializer<T>, IKNetDeserializer<T>
    {
        readonly bool _IsGenericTypeManaged = KNetSerialization.IsInternalManaged<T>();
        readonly KNetSerialization.SerializationType _SerializationType = KNetSerialization.InternalSerDesType<T>();
        Serializer<byte[]> _KafkaSerializer = new ByteArraySerializer();
        Deserializer<byte[]> _KafkaDeserializer = new ByteArrayDeserializer();
        readonly Func<string, byte[], T> _deserializeFun = null;
        readonly Func<string, Headers, byte[], T> _deserializeWithHeadersFun = null;
        readonly Func<string, T, byte[]> _serializeFun = null;
        readonly Func<string, Headers, T, byte[]> _serializeWithHeadersFun = null;

        public KNetSerDes()
        {
            if (!IsGenericTypeManaged) throw new InvalidOperationException($"{typeof(T)} needs an external serializer, use a different constructor.");
        }

        public KNetSerDes(Func<string, T, byte[]> serializeFun)
        {
            _serializeFun = serializeFun;
        }

        public KNetSerDes(Func<string, Headers, T, byte[]> serializeWithHeadersFun)
        {
            _serializeWithHeadersFun = serializeWithHeadersFun;
        }

        public KNetSerDes(Func<string, byte[], T> deserializeFun)
        {
            _deserializeFun = deserializeFun;
        }

        public KNetSerDes(Func<string, Headers, byte[], T> deserializeWithHeadersFun)
        {
            _deserializeWithHeadersFun = deserializeWithHeadersFun;
        }

        ~KNetSerDes()
        {
            Dispose();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            _KafkaSerializer?.Dispose();
            _KafkaSerializer = null;
            _KafkaDeserializer?.Dispose();
            _KafkaDeserializer = null;
        }

        protected virtual bool IsGenericTypeManaged => _IsGenericTypeManaged;

        public Serializer<byte[]> KafkaSerializer => _KafkaSerializer;

        public Deserializer<byte[]> KafkaDeserializer => _KafkaDeserializer;

        public virtual bool UseHeaders => false;

        public virtual byte[] Serialize(string topic, T data)
        {
            if (_serializeFun != null)
            {
                return _serializeFun.Invoke(topic, data);
            }
            return _SerializationType switch
            {
                KNetSerialization.SerializationType.ByteArray => KNetSerialization.SerializeByteArray(topic, data as byte[]),
                KNetSerialization.SerializationType.ByteBuffer => KNetSerialization.SerializeByteBuffer(topic, data as ByteBuffer),
                KNetSerialization.SerializationType.Bytes => KNetSerialization.SerializeBytes(topic, data as Common.Utils.Bytes),
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

        public virtual byte[] SerializeWithHeaders(string topic, Headers headers, T data)
        {
            if (_serializeWithHeadersFun != null)
            {
                return _serializeWithHeadersFun.Invoke(topic, headers, data);
            }
            return Serialize(topic, data);
        }


        public virtual T Deserialize(string topic, byte[] data)
        {
            if (_deserializeFun != null)
            {
                return _deserializeFun.Invoke(topic, data);
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

        public virtual T DeserializeWithHeaders(string topic, Headers headers, byte[] data)
        {
            if (_deserializeWithHeadersFun != null)
            {
                return _deserializeWithHeadersFun.Invoke(topic, headers, data);
            }

            return Deserialize(topic, data);
        }
    }
}
