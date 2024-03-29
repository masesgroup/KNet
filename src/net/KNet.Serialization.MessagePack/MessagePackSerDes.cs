﻿/*
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

using Org.Apache.Kafka.Common.Header;
using global::MessagePack;
using System.IO;
using System.Text;
using System;

namespace MASES.KNet.Serialization.MessagePack
{
    /// <summary>
    /// Base class to define extensions of <see cref="SerDes{T}"/> for MessagePack, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
    /// </summary>
    public static class MessagePackSerDes
    {
        /// <summary>
        /// MessagePack extension of <see cref="SerDes{T}"/> for Key, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class Key<T> : SerDes<T>
        {
            readonly byte[] keySerDesName = Encoding.UTF8.GetBytes(typeof(Key<>).ToAssemblyQualified());
            readonly byte[] keyTypeName = Encoding.UTF8.GetBytes(typeof(T).ToAssemblyQualified());
            /// <summary>
            /// Get or set the <see cref="global::MessagePack.MessagePackSerializerOptions"/> to be used, default is <see langword="null"/>
            /// </summary>
            public MessagePackSerializerOptions MessagePackSerializerOptions { get; set; } = null;
            /// <inheritdoc/>
            public override bool UseHeaders => true;
            /// <summary>
            /// Default initializer
            /// </summary>
            public Key()
            {
                if (KNetSerialization.IsInternalManaged<T>())
                {
                    throw new InvalidOperationException($"{typeof(T).Name} is a type managed from basic serializer, do not use {typeof(Key<T>).FullName}");
                }
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

                return MessagePackSerializer.Serialize(data, MessagePackSerializerOptions);
            }
            /// <inheritdoc cref="SerDes{T, TJVMT}.Deserialize(string, byte[])"/>
            public override T Deserialize(string topic, byte[] data)
            {
                return DeserializeWithHeaders(topic, null, data);
            }
            /// <inheritdoc cref="SerDes{T, TJVMT}.DeserializeWithHeaders(string, Headers, byte[])"/>
            public override T DeserializeWithHeaders(string topic, Headers headers, byte[] data)
            {
                if (data == null) return default;
                using (MemoryStream stream = new MemoryStream(data))
                {
                    return MessagePackSerializer.Deserialize<T>(stream, MessagePackSerializerOptions);
                }
            }
        }

        /// <summary>
        /// MessagePack extension of <see cref="SerDes{T}"/> for Value, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class Value<T> : SerDes<T>
        {
            readonly byte[] valueSerDesName = Encoding.UTF8.GetBytes(typeof(Value<>).ToAssemblyQualified());
            readonly byte[] valueTypeName = Encoding.UTF8.GetBytes(typeof(T).ToAssemblyQualified());
            /// <summary>
            /// Get or set the <see cref="global::MessagePack.MessagePackSerializerOptions"/> to be used, default is <see langword="null"/>
            /// </summary>
            public MessagePackSerializerOptions MessagePackSerializerOptions { get; set; } = null;
            /// <inheritdoc/>
            public override bool UseHeaders => true;
            /// <summary>
            /// Default initializer
            /// </summary>
            public Value()
            {
                if (KNetSerialization.IsInternalManaged<T>())
                {
                    throw new InvalidOperationException($"{typeof(T).Name} is a type managed from basic serializer, do not use {typeof(Key<T>).FullName}");
                }
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

                return MessagePackSerializer.Serialize(data, MessagePackSerializerOptions);
            }
            /// <inheritdoc cref="SerDes{T, TJVMT}.Deserialize(string, byte[])"/>
            public override T Deserialize(string topic, byte[] data)
            {
                return DeserializeWithHeaders(topic, null, data);
            }
            /// <inheritdoc cref="SerDes{T, TJVMT}.DeserializeWithHeaders(string, Headers, byte[])"/>
            public override T DeserializeWithHeaders(string topic, Headers headers, byte[] data)
            {
                if (data == null) return default;
                using (MemoryStream stream = new MemoryStream(data))
                {
                    return MessagePackSerializer.Deserialize<T>(stream, MessagePackSerializerOptions);
                }
            }
        }
    }
}
