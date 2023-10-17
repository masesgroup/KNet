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

using Google.Protobuf;
using Org.Apache.Kafka.Common.Header;
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace MASES.KNet.Serialization.Protobuf
{
    /// <summary>
    /// Base class to define extensions of <see cref="KNetSerDes{T}"/> for Protobuf, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
    /// </summary>
    public static class ProtobufSerDes
    {
        class ProtobufSerDesBuilder<T> where T : IMessage<T>, new()
        {
            readonly MessageParser<T> _parser = new MessageParser<T>(() => new T());
            public byte[] SerializeWithHeaders(string topic, Headers headers, T data)
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    data.WriteTo(stream);
                    return stream.ToArray();
                }
            }
            public T DeserializeWithHeaders(string topic, Headers headers, byte[] data)
            {
                return _parser.ParseFrom(data);
            }
        }

        /// <summary>
        /// Protobuf extension of <see cref="KNetSerDes{T}"/> for Key, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class Key<T> : KNetSerDes<T> where T : new()
        {
            readonly byte[] keySerDesName = Encoding.UTF8.GetBytes(typeof(Key<>).ToAssemblyQualified());
            readonly byte[] keyTypeName = null;
            readonly IKNetSerDes<T> _defaultSerDes = default!;
            readonly object builderObject = null;
            readonly MethodInfo SerializeWithHeadersMethod;
            readonly MethodInfo DeserializeWithHeadersMethod;
            /// <inheritdoc/>
            public override bool UseHeaders => true;
            /// <summary>
            /// Default initializer
            /// </summary>
            public Key()
            {
                if (KNetSerialization.IsInternalManaged<T>())
                {
                    _defaultSerDes = new KNetSerDes<T>();
                    keyTypeName = Encoding.UTF8.GetBytes(typeof(T).FullName!);
                }
                else
                {
                    var t = new T();
                    var iMessageWithT = typeof(IMessage<>).MakeGenericType(typeof(T));
                    if (iMessageWithT.IsAssignableFrom(typeof(T)))
                    {
                        var builder = typeof(ProtobufSerDesBuilder<>).MakeGenericType(iMessageWithT);
                        builderObject = Activator.CreateInstance(builder);
                        SerializeWithHeadersMethod = builder.GetMethod("SerializeWithHeaders");
                        DeserializeWithHeadersMethod = builder.GetMethod("DeserializeWithHeaders");
                    }
                    else
                    {
                        throw new InvalidOperationException($"Cannot manage {typeof(T).ToAssemblyQualified()} because it does not implement {typeof(IMessage<>).FullName}");
                    }
                    keyTypeName = Encoding.UTF8.GetBytes(typeof(T).ToAssemblyQualified());
                }
            }
            /// <inheritdoc cref="KNetSerDes{T}.Serialize(string, T)"/>
            public override byte[] Serialize(string topic, T data)
            {
                return SerializeWithHeaders(topic, null, data);
            }
            /// <inheritdoc cref="KNetSerDes{T}.SerializeWithHeaders(string, Headers, T)"/>
            public override byte[] SerializeWithHeaders(string topic, Headers headers, T data)
            {
                headers?.Add(KNetSerialization.KeyTypeIdentifier, keyTypeName);
                headers?.Add(KNetSerialization.KeySerializerIdentifier, keySerDesName);

                if (_defaultSerDes != null) return _defaultSerDes.SerializeWithHeaders(topic, headers, data);

                return (byte[])SerializeWithHeadersMethod.Invoke(builderObject, new object[] { topic, headers, data }); 
            }
            /// <inheritdoc cref="KNetSerDes{T}.Deserialize(string, byte[])"/>
            public override T Deserialize(string topic, byte[] data)
            {
                return DeserializeWithHeaders(topic, null, data);
            }
            /// <inheritdoc cref="KNetSerDes{T}.DeserializeWithHeaders(string, Headers, byte[])"/>
            public override T DeserializeWithHeaders(string topic, Headers headers, byte[] data)
            {
                if (_defaultSerDes != null) return _defaultSerDes.DeserializeWithHeaders(topic, headers, data);
                if (data == null) return default;
                return (T)DeserializeWithHeadersMethod.Invoke(builderObject, new object[] { topic, headers, data });
            }
        }

        /// <summary>
        /// Protobuf extension of <see cref="KNetSerDes{T}"/> for Value, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class Value<T> : KNetSerDes<T> where T : new()
        {
            readonly byte[] valueSerDesName = Encoding.UTF8.GetBytes(typeof(Value<>).ToAssemblyQualified());
            readonly byte[] valueTypeName = null!;
            readonly IKNetSerDes<T> _defaultSerDes = default!;
            readonly object builderObject = null;
            readonly MethodInfo SerializeWithHeadersMethod;
            readonly MethodInfo DeserializeWithHeadersMethod;
            /// <inheritdoc/>
            public override bool UseHeaders => true;
            /// <summary>
            /// Default initializer
            /// </summary>
            public Value()
            {
                if (KNetSerialization.IsInternalManaged<T>())
                {
                    _defaultSerDes = new KNetSerDes<T>();
                    valueTypeName = Encoding.UTF8.GetBytes(typeof(T).FullName!);
                }
                else
                {
                    var t = new T();
                    var iMessageWithT = typeof(IMessage<>).MakeGenericType(typeof(T));
                    if (iMessageWithT.IsAssignableFrom(typeof(T)))
                    {
                        var builder = typeof(ProtobufSerDesBuilder<>).MakeGenericType(iMessageWithT);
                        builderObject = Activator.CreateInstance(builder);
                        SerializeWithHeadersMethod = builder.GetMethod("SerializeWithHeaders");
                        DeserializeWithHeadersMethod = builder.GetMethod("DeserializeWithHeaders");
                    }
                    else
                    {
                        throw new InvalidOperationException($"Cannot manage {typeof(T).ToAssemblyQualified()} because it does not implement {typeof(IMessage<>).FullName}");
                    }
                    valueTypeName = Encoding.UTF8.GetBytes(typeof(T).ToAssemblyQualified());
                }
            }
            /// <inheritdoc cref="KNetSerDes{T}.Serialize(string, T)"/>
            public override byte[] Serialize(string topic, T data)
            {
                return SerializeWithHeaders(topic, null, data);
            }
            /// <inheritdoc cref="KNetSerDes{T}.SerializeWithHeaders(string, Headers, T)"/>
            public override byte[] SerializeWithHeaders(string topic, Headers headers, T data)
            {
                headers?.Add(KNetSerialization.ValueSerializerIdentifier, valueSerDesName);
                headers?.Add(KNetSerialization.ValueTypeIdentifier, valueTypeName);

                if (_defaultSerDes != null) return _defaultSerDes.SerializeWithHeaders(topic, headers, data);

                return (byte[])SerializeWithHeadersMethod.Invoke(builderObject, new object[] { topic, headers, data });
            }
            /// <inheritdoc cref="KNetSerDes{T}.Deserialize(string, byte[])"/>
            public override T Deserialize(string topic, byte[] data)
            {
                return DeserializeWithHeaders(topic, null, data);
            }
            /// <inheritdoc cref="KNetSerDes{T}.DeserializeWithHeaders(string, Headers, byte[])"/>
            public override T DeserializeWithHeaders(string topic, Headers headers, byte[] data)
            {
                if (_defaultSerDes != null) return _defaultSerDes.DeserializeWithHeaders(topic, headers, data);
                if (data == null) return default;
                return (T)DeserializeWithHeadersMethod.Invoke(builderObject, new object[] { topic, headers, data });
            }
        }
    }
}
