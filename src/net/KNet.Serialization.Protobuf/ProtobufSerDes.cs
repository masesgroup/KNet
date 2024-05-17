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

using Google.Protobuf;
using Java.Nio;
using Org.Apache.Kafka.Common.Header;
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace MASES.KNet.Serialization.Protobuf
{
    /// <summary>
    /// Base class to define extensions of <see cref="SerDes{T, TJVMT}"/> for Protobuf, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
    /// </summary>
    public static class ProtobufSerDes
    {
        /// <summary>
        /// Protobuf extension of <see cref="SerDes{T, TJVMT}"/> for Key, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class KeyRaw<T> : SerDesRaw<T> where T : IMessage<T>, new()
        {
            readonly MessageParser<T> _parser = new MessageParser<T>(() => new T());
            readonly byte[] keySerDesName = Encoding.UTF8.GetBytes(typeof(KeyRaw<>).ToAssemblyQualified());
            readonly byte[] keyTypeName = Encoding.UTF8.GetBytes(typeof(T).ToAssemblyQualified());
            /// <inheritdoc/>
            public override bool UseHeaders => true;
            /// <summary>
            /// Default initializer
            /// </summary>
            public KeyRaw()
            {

            }
            /// <inheritdoc cref="SerDes{T, TJVMT}.Serialize(string, T)"/>
            public override byte[] Serialize(string topic, T data)
            {
                return SerializeWithHeaders(topic, null, data);
            }
            /// <inheritdoc cref="SerDes{T, TJVMT}.SerializeWithHeaders(string, Headers, T)"/>
            public override byte[] SerializeWithHeaders(string topic, Headers headers, T data)
            {
                headers?.Add(KNetSerialization.KeyTypeIdentifier, keyTypeName);
                headers?.Add(KNetSerialization.KeySerializerIdentifier, keySerDesName);

                using (MemoryStream stream = new MemoryStream())
                {
                    data.WriteTo(stream);
                    return stream.ToArray();
                }
            }
            /// <inheritdoc cref="SerDes{T, TJVMT}.Deserialize(string, TJVMT)"/>
            public override T Deserialize(string topic, byte[] data)
            {
                return DeserializeWithHeaders(topic, null, data);
            }
            /// <inheritdoc cref="SerDes{T, TJVMT}.DeserializeWithHeaders(string, Headers, TJVMT)"/>
            public override T DeserializeWithHeaders(string topic, Headers headers, byte[] data)
            {
                if (data == null) return default;
                return _parser.ParseFrom(data);
            }
        }

        /// <summary>
        /// Protobuf extension of <see cref="SerDes{T, TJVMT}"/> for Key, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class KeyBuffered<T> : SerDesBuffered<T> where T : IMessage<T>, new()
        {
            readonly MessageParser<T> _parser = new MessageParser<T>(() => new T());
            readonly byte[] keySerDesName = Encoding.UTF8.GetBytes(typeof(KeyBuffered<>).ToAssemblyQualified());
            readonly byte[] keyTypeName = Encoding.UTF8.GetBytes(typeof(T).ToAssemblyQualified());
            /// <inheritdoc/>
            public override bool UseHeaders => true;
            /// <inheritdoc/>
            public override bool IsDirectBuffered => true;
            /// <summary>
            /// Default initializer
            /// </summary>
            public KeyBuffered()
            {

            }
            /// <inheritdoc cref="SerDes{T, TJVMT}.Serialize(string, T)"/>
            public override Java.Nio.ByteBuffer Serialize(string topic, T data)
            {
                return SerializeWithHeaders(topic, null, data);
            }
            /// <inheritdoc cref="SerDes{T, TJVMT}.SerializeWithHeaders(string, Headers, T)"/>
            public override Java.Nio.ByteBuffer SerializeWithHeaders(string topic, Headers headers, T data)
            {
                headers?.Add(KNetSerialization.KeyTypeIdentifier, keyTypeName);
                headers?.Add(KNetSerialization.KeySerializerIdentifier, keySerDesName);

                MemoryStream stream = new MemoryStream();
                {
                    data.WriteTo(stream);
                    return ByteBuffer.From(stream);
                }
            }
            /// <inheritdoc cref="SerDes{T, TJVMT}.Deserialize(string, TJVMT)"/>
            public override T Deserialize(string topic, Java.Nio.ByteBuffer data)
            {
                return DeserializeWithHeaders(topic, null, data);
            }
            /// <inheritdoc cref="SerDes{T, TJVMT}.DeserializeWithHeaders(string, Headers, TJVMT)"/>
            public override T DeserializeWithHeaders(string topic, Headers headers, Java.Nio.ByteBuffer data)
            {
                if (data == null) return default;
                return _parser.ParseFrom(data.ToStream());
            }
        }

        /// <summary>
        /// Protobuf extension of <see cref="SerDes{T, TJVMT}"/> for Value, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class ValueRaw<T> : SerDesRaw<T> where T : IMessage<T>, new()
        {
            readonly MessageParser<T> _parser = new MessageParser<T>(() => new T());
            readonly byte[] valueSerDesName = Encoding.UTF8.GetBytes(typeof(ValueRaw<>).ToAssemblyQualified());
            readonly byte[] valueTypeName = Encoding.UTF8.GetBytes(typeof(T).ToAssemblyQualified());
            /// <inheritdoc/>
            public override bool UseHeaders => true;
            /// <summary>
            /// Default initializer
            /// </summary>
            public ValueRaw()
            {

            }
            /// <inheritdoc cref="SerDes{T, TJVMT}.Serialize(string, T)"/>
            public override byte[] Serialize(string topic, T data)
            {
                return SerializeWithHeaders(topic, null, data);
            }
            /// <inheritdoc cref="SerDes{T, TJVMT}.SerializeWithHeaders(string, Headers, T)"/>
            public override byte[] SerializeWithHeaders(string topic, Headers headers, T data)
            {
                headers?.Add(KNetSerialization.ValueSerializerIdentifier, valueSerDesName);
                headers?.Add(KNetSerialization.ValueTypeIdentifier, valueTypeName);

                using (MemoryStream stream = new MemoryStream())
                {
                    data.WriteTo(stream);
                    return stream.ToArray();
                }
            }
            /// <inheritdoc cref="SerDes{T, TJVMT}.Deserialize(string, TJVMT)"/>
            public override T Deserialize(string topic, byte[] data)
            {
                return DeserializeWithHeaders(topic, null, data);
            }
            /// <inheritdoc cref="SerDes{T, TJVMT}.DeserializeWithHeaders(string, Headers, TJVMT)"/>
            public override T DeserializeWithHeaders(string topic, Headers headers, byte[] data)
            {
                if (data == null) return default;
                return _parser.ParseFrom(data);
            }
        }

        /// <summary>
        /// Protobuf extension of <see cref="SerDes{T, TJVMT}"/> for Value, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class ValueBuffered<T> : SerDesBuffered<T> where T : IMessage<T>, new()
        {
            readonly MessageParser<T> _parser = new MessageParser<T>(() => new T());
            readonly byte[] valueSerDesName = Encoding.UTF8.GetBytes(typeof(ValueBuffered<>).ToAssemblyQualified());
            readonly byte[] valueTypeName = Encoding.UTF8.GetBytes(typeof(T).ToAssemblyQualified());
            /// <inheritdoc/>
            public override bool UseHeaders => true;
            /// <inheritdoc/>
            public override bool IsDirectBuffered => true;
            /// <summary>
            /// Default initializer
            /// </summary>
            public ValueBuffered()
            {

            }
            /// <inheritdoc cref="SerDes{T, TJVMT}.Serialize(string, T)"/>
            public override Java.Nio.ByteBuffer Serialize(string topic, T data)
            {
                return SerializeWithHeaders(topic, null, data);
            }
            /// <inheritdoc cref="SerDes{T, TJVMT}.SerializeWithHeaders(string, Headers, T)"/>
            public override Java.Nio.ByteBuffer SerializeWithHeaders(string topic, Headers headers, T data)
            {
                headers?.Add(KNetSerialization.ValueSerializerIdentifier, valueSerDesName);
                headers?.Add(KNetSerialization.ValueTypeIdentifier, valueTypeName);

                MemoryStream stream = new MemoryStream();
                {
                    data.WriteTo(stream);
                    return ByteBuffer.From(stream);
                }
            }
            /// <inheritdoc cref="SerDes{T, TJVMT}.Deserialize(string, TJVMT)"/>
            public override T Deserialize(string topic, Java.Nio.ByteBuffer data)
            {
                return DeserializeWithHeaders(topic, null, data);
            }
            /// <inheritdoc cref="SerDes{T, TJVMT}.DeserializeWithHeaders(string, Headers, TJVMT)"/>
            public override T DeserializeWithHeaders(string topic, Headers headers, Java.Nio.ByteBuffer data)
            {
                if (data == null) return default;
                return _parser.ParseFrom(data.ToStream());
            }
        }
    }
}
