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

using Org.Apache.Kafka.Common.Header;
using global::MessagePack;
using System.IO;
using System.Text;
using System;
using Java.Nio;

namespace MASES.KNet.Serialization.MessagePack
{
    /// <summary>
    /// Base class to define extensions of <see cref="ISerDesSelector{T}"/> for MessagePack, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
    /// </summary>
    public static class MessagePackSerDes
    {
        /// <summary>
        /// MessagePack extension of <see cref="ISerDesSelector{T}"/> for Key, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class Key<T> : ISerDesSelector<T>
        {
            /// <summary>
            /// Returns a new instance of <see cref="Key{T}"/>
            /// </summary>
            /// <returns>The <see cref="ISerDesSelector{T}"/> of <see cref="Key{T}"/></returns>
            public static ISerDesSelector<T> NewInstance() => new Key<T>();
            /// <inheritdoc cref="ISerDesSelector.SelectorTypeName"/>
            public static string SelectorTypeName => typeof(Key<>).ToAssemblyQualified();
            /// <inheritdoc cref="ISerDesSelector.ByteArraySerDes"/>
            public static Type ByteArraySerDes => typeof(KeyRaw<T>);
            /// <inheritdoc cref="ISerDesSelector.ByteBufferSerDes"/>
            public static Type ByteBufferSerDes => typeof(KeyBuffered<T>);
            /// <inheritdoc cref="ISerDesSelector{T}.NewSerDes{TJVM}"/>
            public static ISerDes<T, TJVM> NewSerDes<TJVM>()
            {
                if (typeof(TJVM) == typeof(Java.Nio.ByteBuffer)) return NewByteBufferSerDes() as ISerDes<T, TJVM>;
                return NewByteArraySerDes() as ISerDes<T, TJVM>;
            }
            /// <inheritdoc cref="ISerDesSelector{T}.NewByteArraySerDes"/>
            public static ISerDesRaw<T> NewByteArraySerDes() { return new KeyRaw<T>(SelectorTypeName); }
            /// <inheritdoc cref="ISerDesSelector{T}.NewByteBufferSerDes"/>
            public static ISerDesBuffered<T> NewByteBufferSerDes() { return new KeyBuffered<T>(SelectorTypeName); }

            /// <inheritdoc cref="ISerDesSelector.SelectorTypeName"/>
            string ISerDesSelector.SelectorTypeName => SelectorTypeName;
            /// <inheritdoc cref="ISerDesSelector.ByteArraySerDes"/>
            Type ISerDesSelector.ByteArraySerDes => ByteArraySerDes;
            /// <inheritdoc cref="ISerDesSelector.ByteBufferSerDes"/>
            Type ISerDesSelector.ByteBufferSerDes => ByteBufferSerDes;
            /// <inheritdoc cref="ISerDesSelector{T}.NewSerDes{TJVM}"/>
            ISerDes<T, TJVM> ISerDesSelector<T>.NewSerDes<TJVM>() => NewSerDes<TJVM>();
            /// <inheritdoc cref="ISerDesSelector{T}.NewByteArraySerDes"/>
            ISerDesRaw<T> ISerDesSelector<T>.NewByteArraySerDes() => NewByteArraySerDes();
            /// <inheritdoc cref="ISerDesSelector{T}.NewByteBufferSerDes"/>
            ISerDesBuffered<T> ISerDesSelector<T>.NewByteBufferSerDes() => NewByteBufferSerDes();

            /// <summary>
            /// MessagePack extension of <see cref="SerDes{TData, TJVMT}"/> for Key, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
            /// </summary>
            /// <typeparam name="TData"></typeparam>
            sealed class KeyRaw<TData> : SerDesRaw<TData>
            {
                readonly byte[] keySerDesName;
                readonly byte[] keyTypeName = Encoding.UTF8.GetBytes(typeof(TData).ToAssemblyQualified());
                /// <summary>
                /// Get or set the <see cref="global::MessagePack.MessagePackSerializerOptions"/> to be used, default is <see langword="null"/>
                /// </summary>
                public MessagePackSerializerOptions MessagePackSerializerOptions { get; set; } = null;
                /// <inheritdoc/>
                public override bool UseHeaders => true;
                /// <summary>
                /// Default initializer
                /// </summary>
                public KeyRaw(string selectorName)
                {
                    keySerDesName = Encoding.UTF8.GetBytes(selectorName);
                    if (KNetSerialization.IsInternalManaged<TData>())
                    {
                        throw new InvalidOperationException($"{typeof(TData).Name} is a type managed from basic serializer, do not use {typeof(KeyRaw<TData>).FullName}");
                    }
                }
                /// <inheritdoc cref="SerDes{TData, TJVMT}.Serialize(string, TData)"/>
                public override byte[] Serialize(string topic, TData data)
                {
                    return SerializeWithHeaders(topic, null, data);
                }
                /// <inheritdoc cref="SerDes{TData, TJVMT}.SerializeWithHeaders(string, Headers, TData)"/>
                public override byte[] SerializeWithHeaders(string topic, Headers headers, TData data)
                {
                    headers?.Add(KNetSerialization.KeyTypeIdentifierJVM, keyTypeName);
                    headers?.Add(KNetSerialization.KeySerializerIdentifierJVM, keySerDesName);

                    return MessagePackSerializer.Serialize(data, MessagePackSerializerOptions);
                }
                /// <inheritdoc cref="SerDes{TData, TJVMT}.Deserialize(string, TJVMT)"/>
                public override TData Deserialize(string topic, byte[] data)
                {
                    return DeserializeWithHeaders(topic, null, data);
                }
                /// <inheritdoc cref="SerDes{TData, TJVMT}.DeserializeWithHeaders(string, Headers, TJVMT)"/>
                public override TData DeserializeWithHeaders(string topic, Headers headers, byte[] data)
                {
                    if (data == null) return default;
                    using (MemoryStream stream = new MemoryStream(data))
                    {
                        return MessagePackSerializer.Deserialize<TData>(stream, MessagePackSerializerOptions);
                    }
                }
            }

            /// <summary>
            /// MessagePack extension of <see cref="SerDes{TData, TJVMT}"/> for Key, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
            /// </summary>
            /// <typeparam name="TData"></typeparam>
            sealed class KeyBuffered<TData> : SerDesBuffered<TData>
            {
                readonly byte[] keySerDesName;
                readonly byte[] keyTypeName = Encoding.UTF8.GetBytes(typeof(TData).ToAssemblyQualified());
                /// <summary>
                /// Get or set the <see cref="global::MessagePack.MessagePackSerializerOptions"/> to be used, default is <see langword="null"/>
                /// </summary>
                public MessagePackSerializerOptions MessagePackSerializerOptions { get; set; } = null;
                /// <inheritdoc/>
                public override bool UseHeaders => true;
                /// <summary>
                /// Default initializer
                /// </summary>
                public KeyBuffered(string selectorName)
                {
                    keySerDesName = Encoding.UTF8.GetBytes(selectorName);
                    if (KNetSerialization.IsInternalManaged<TData>())
                    {
                        throw new InvalidOperationException($"{typeof(TData).Name} is a type managed from basic serializer, do not use {typeof(KeyBuffered<TData>).FullName}");
                    }
                }
                /// <inheritdoc cref="SerDes{TData, TJVMT}.Serialize(string, TData)"/>
                public override Java.Nio.ByteBuffer Serialize(string topic, TData data)
                {
                    return SerializeWithHeaders(topic, null, data);
                }
                /// <inheritdoc cref="SerDes{TData, TJVMT}.SerializeWithHeaders(string, Headers, TData)"/>
                public override Java.Nio.ByteBuffer SerializeWithHeaders(string topic, Headers headers, TData data)
                {
                    headers?.Add(KNetSerialization.KeyTypeIdentifierJVM, keyTypeName);
                    headers?.Add(KNetSerialization.KeySerializerIdentifierJVM, keySerDesName);

                    var ms = new MemoryStream();
                    MessagePackSerializer.Serialize(ms, data, MessagePackSerializerOptions);
                    return ByteBuffer.From(ms);
                }
                /// <inheritdoc cref="SerDes{TData, TJVMT}.Deserialize(string, TJVMT)"/>
                public override TData Deserialize(string topic, Java.Nio.ByteBuffer data)
                {
                    return DeserializeWithHeaders(topic, null, data);
                }
                /// <inheritdoc cref="SerDes{TData, TJVMT}.DeserializeWithHeaders(string, Headers, TJVMT)"/>
                public override TData DeserializeWithHeaders(string topic, Headers headers, Java.Nio.ByteBuffer data)
                {
                    if (data == null) return default;
                    return MessagePackSerializer.Deserialize<TData>(data.ToStream(), MessagePackSerializerOptions);
                }
            }
        }

        /// <summary>
        /// MessagePack extension of <see cref="ISerDesSelector{T}"/> for Value, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class Value<T> : ISerDesSelector<T>
        {
            /// <summary>
            /// Returns a new instance of <see cref="Value{T}"/>
            /// </summary>
            /// <returns>The <see cref="ISerDesSelector{T}"/> of <see cref="Value{T}"/></returns>
            public static ISerDesSelector<T> NewInstance() => new Value<T>();
            /// <inheritdoc cref="ISerDesSelector.SelectorTypeName"/>
            public static string SelectorTypeName => typeof(Value<>).ToAssemblyQualified();
            /// <inheritdoc cref="ISerDesSelector.ByteArraySerDes"/>
            public static Type ByteArraySerDes => typeof(ValueRaw<T>);
            /// <inheritdoc cref="ISerDesSelector.ByteBufferSerDes"/>
            public static Type ByteBufferSerDes => typeof(ValueBuffered<T>);
            /// <inheritdoc cref="ISerDesSelector{T}.NewSerDes{TJVM}"/>
            public static ISerDes<T, TJVM> NewSerDes<TJVM>()
            {
                if (typeof(TJVM) == typeof(Java.Nio.ByteBuffer)) return NewByteBufferSerDes() as ISerDes<T, TJVM>;
                return NewByteArraySerDes() as ISerDes<T, TJVM>;
            }
            /// <inheritdoc cref="ISerDesSelector{T}.NewByteArraySerDes"/>
            public static ISerDesRaw<T> NewByteArraySerDes() { return new ValueRaw<T>(SelectorTypeName); }
            /// <inheritdoc cref="ISerDesSelector{T}.NewByteBufferSerDes"/>
            public static ISerDesBuffered<T> NewByteBufferSerDes() { return new ValueBuffered<T>(SelectorTypeName); }

            /// <inheritdoc cref="ISerDesSelector.SelectorTypeName"/>
            string ISerDesSelector.SelectorTypeName => SelectorTypeName;
            /// <inheritdoc cref="ISerDesSelector.ByteArraySerDes"/>
            Type ISerDesSelector.ByteArraySerDes => ByteArraySerDes;
            /// <inheritdoc cref="ISerDesSelector.ByteBufferSerDes"/>
            Type ISerDesSelector.ByteBufferSerDes => ByteBufferSerDes;
            /// <inheritdoc cref="ISerDesSelector{T}.NewSerDes{TJVM}"/>
            ISerDes<T, TJVM> ISerDesSelector<T>.NewSerDes<TJVM>() => NewSerDes<TJVM>();
            /// <inheritdoc cref="ISerDesSelector{T}.NewByteArraySerDes"/>
            ISerDesRaw<T> ISerDesSelector<T>.NewByteArraySerDes() => NewByteArraySerDes();
            /// <inheritdoc cref="ISerDesSelector{T}.NewByteBufferSerDes"/>
            ISerDesBuffered<T> ISerDesSelector<T>.NewByteBufferSerDes() => NewByteBufferSerDes();

            /// <summary>
            /// MessagePack extension of <see cref="SerDes{TData, TJVMT}"/> for Value, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
            /// </summary>
            /// <typeparam name="TData"></typeparam>
            sealed class ValueRaw<TData> : SerDesRaw<TData>
            {
                readonly byte[] valueSerDesName;
                readonly byte[] valueTypeName = Encoding.UTF8.GetBytes(typeof(TData).ToAssemblyQualified());
                /// <summary>
                /// Get or set the <see cref="global::MessagePack.MessagePackSerializerOptions"/> to be used, default is <see langword="null"/>
                /// </summary>
                public MessagePackSerializerOptions MessagePackSerializerOptions { get; set; } = null;
                /// <inheritdoc/>
                public override bool UseHeaders => true;
                /// <summary>
                /// Default initializer
                /// </summary>
                public ValueRaw(string selectorName)
                {
                    valueSerDesName = Encoding.UTF8.GetBytes(selectorName);
                    if (KNetSerialization.IsInternalManaged<TData>())
                    {
                        throw new InvalidOperationException($"{typeof(TData).Name} is a type managed from basic serializer, do not use {typeof(ValueRaw<TData>).FullName}");
                    }
                }
                /// <inheritdoc cref="SerDes{TData, TJVMT}.Serialize(string, TData)"/>
                public override byte[] Serialize(string topic, TData data)
                {
                    return SerializeWithHeaders(topic, null, data);
                }
                /// <inheritdoc cref="SerDes{TData, TJVMT}.SerializeWithHeaders(string, Headers, TData)"/>
                public override byte[] SerializeWithHeaders(string topic, Headers headers, TData data)
                {
                    headers?.Add(KNetSerialization.ValueSerializerIdentifierJVM, valueSerDesName);
                    headers?.Add(KNetSerialization.ValueTypeIdentifierJVM, valueTypeName);

                    return MessagePackSerializer.Serialize(data, MessagePackSerializerOptions);
                }
                /// <inheritdoc cref="SerDes{TData, TJVMT}.Deserialize(string, TJVMT)"/>
                public override TData Deserialize(string topic, byte[] data)
                {
                    return DeserializeWithHeaders(topic, null, data);
                }
                /// <inheritdoc cref="SerDes{TData, TJVMT}.DeserializeWithHeaders(string, Headers, TJVMT)"/>
                public override TData DeserializeWithHeaders(string topic, Headers headers, byte[] data)
                {
                    if (data == null) return default;
                    using (MemoryStream stream = new MemoryStream(data))
                    {
                        return MessagePackSerializer.Deserialize<TData>(stream, MessagePackSerializerOptions);
                    }
                }
            }

            /// <summary>
            /// MessagePack extension of <see cref="SerDes{TData, TJVMT}"/> for Value, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
            /// </summary>
            /// <typeparam name="TData"></typeparam>
            sealed class ValueBuffered<TData> : SerDesBuffered<TData>
            {
                readonly byte[] valueSerDesName;
                readonly byte[] valueTypeName = Encoding.UTF8.GetBytes(typeof(TData).ToAssemblyQualified());
                /// <summary>
                /// Get or set the <see cref="global::MessagePack.MessagePackSerializerOptions"/> to be used, default is <see langword="null"/>
                /// </summary>
                public MessagePackSerializerOptions MessagePackSerializerOptions { get; set; } = null;
                /// <inheritdoc/>
                public override bool UseHeaders => true;
                /// <summary>
                /// Default initializer
                /// </summary>
                public ValueBuffered(string selectorName)
                {
                    valueSerDesName = Encoding.UTF8.GetBytes(selectorName);
                    if (KNetSerialization.IsInternalManaged<TData>())
                    {
                        throw new InvalidOperationException($"{typeof(TData).Name} is a type managed from basic serializer, do not use {typeof(ValueBuffered<TData>).FullName}");
                    }
                }
                /// <inheritdoc cref="SerDes{TData, TJVMT}.Serialize(string, TData)"/>
                public override Java.Nio.ByteBuffer Serialize(string topic, TData data)
                {
                    return SerializeWithHeaders(topic, null, data);
                }
                /// <inheritdoc cref="SerDes{TData, TJVMT}.SerializeWithHeaders(string, Headers, TData)"/>
                public override Java.Nio.ByteBuffer SerializeWithHeaders(string topic, Headers headers, TData data)
                {
                    headers?.Add(KNetSerialization.ValueSerializerIdentifierJVM, valueSerDesName);
                    headers?.Add(KNetSerialization.ValueTypeIdentifierJVM, valueTypeName);

                    var ms = new MemoryStream();
                    MessagePackSerializer.Serialize(ms, data, MessagePackSerializerOptions);
                    return ByteBuffer.From(ms);
                }
                /// <inheritdoc cref="SerDes{TData, TJVMT}.Deserialize(string, TJVMT)"/>
                public override TData Deserialize(string topic, Java.Nio.ByteBuffer data)
                {
                    return DeserializeWithHeaders(topic, null, data);
                }
                /// <inheritdoc cref="SerDes{TData, TJVMT}.DeserializeWithHeaders(string, Headers, TJVMT)"/>
                public override TData DeserializeWithHeaders(string topic, Headers headers, Java.Nio.ByteBuffer data)
                {
                    if (data == null) return default;
                    return MessagePackSerializer.Deserialize<TData>(data.ToStream(), MessagePackSerializerOptions);
                }
            }
        }
    }
}
