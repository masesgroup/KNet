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
using System;
using System.Text;

namespace MASES.KNet.Serialization.Json
{
    /// <summary>
    /// Base class to define extensions of <see cref="SerDes{T}"/> for Json, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
    /// </summary>
    public static class JsonSerDes
    {
        /// <summary>
        /// Json extension of <see cref="SerDes{T}"/> for Key, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class Key<T> : SerDes<T>
        {
            readonly byte[] keySerDesName = Encoding.UTF8.GetBytes(typeof(Key<>).ToAssemblyQualified());
            readonly byte[] keyTypeName = null;
            readonly ISerDes<T> _defaultSerDes = default!;
            /// <inheritdoc/>
            public override bool UseHeaders => true;
            /// <summary>
            /// Default initializer
            /// </summary>
            public Key()
            {
                if (KNetSerialization.IsInternalManaged<T>())
                {
                    _defaultSerDes = new SerDes<T>();
                    keyTypeName = Encoding.UTF8.GetBytes(typeof(T).FullName!);
                }
                else
                {
                    keyTypeName = Encoding.UTF8.GetBytes(typeof(T).ToAssemblyQualified());
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

                if (_defaultSerDes != null) return _defaultSerDes.SerializeWithHeaders(topic, headers, data);

#if NET462_OR_GREATER
                var jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.None);
                return Encoding.UTF8.GetBytes(jsonStr);
#else
                var jsonStr = System.Text.Json.JsonSerializer.Serialize<T>(data);
                return Encoding.UTF8.GetBytes(jsonStr);
#endif
            }
            /// <inheritdoc cref="SerDes{T, TJVMT}.Deserialize(string, byte[])"/>
            public override T Deserialize(string topic, byte[] data)
            {
                return DeserializeWithHeaders(topic, null, data);
            }
            /// <inheritdoc cref="SerDes{T, TJVMT}.DeserializeWithHeaders(string, Headers, byte[])"/>
            public override T DeserializeWithHeaders(string topic, Headers headers, byte[] data)
            {
                if (_defaultSerDes != null) return _defaultSerDes.DeserializeWithHeaders(topic, headers, data);
                if (data == null) return default;
#if NET462_OR_GREATER
                var jsonStr = Encoding.UTF8.GetString(data);
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonStr);
#else
                return System.Text.Json.JsonSerializer.Deserialize<T>(data)!;
#endif
            }
        }

        /// <summary>
        /// Json extension of <see cref="SerDes{T}"/> for Value, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class Value<T> : SerDes<T>
        {
            readonly byte[] valueSerDesName = Encoding.UTF8.GetBytes(typeof(Value<>).ToAssemblyQualified());
            readonly byte[] valueTypeName = null!;
            readonly ISerDes<T> _defaultSerDes = default!;
            /// <inheritdoc/>
            public override bool UseHeaders => true;
            /// <summary>
            /// Default initializer
            /// </summary>
            public Value()
            {
                if (KNetSerialization.IsInternalManaged<T>())
                {
                    _defaultSerDes = new SerDes<T>();
                    valueTypeName = Encoding.UTF8.GetBytes(typeof(T).FullName!);
                }
                else
                {
                    valueTypeName = Encoding.UTF8.GetBytes(typeof(T).ToAssemblyQualified());
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

                if (_defaultSerDes != null) return _defaultSerDes.SerializeWithHeaders(topic, headers, data);

#if NET462_OR_GREATER
                var jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.None);
                return Encoding.UTF8.GetBytes(jsonStr);
#else
                var jsonStr = System.Text.Json.JsonSerializer.Serialize<T>(data);
                return Encoding.UTF8.GetBytes(jsonStr);
#endif
            }
            /// <inheritdoc cref="SerDes{T, TJVMT}.Deserialize(string, byte[])"/>
            public override T Deserialize(string topic, byte[] data)
            {
                return DeserializeWithHeaders(topic, null, data);
            }
            /// <inheritdoc cref="SerDes{T, TJVMT}.DeserializeWithHeaders(string, Headers, byte[])"/>
            public override T DeserializeWithHeaders(string topic, Headers headers, byte[] data)
            {
                if (_defaultSerDes != null) return _defaultSerDes.DeserializeWithHeaders(topic, headers, data);

                if (data == null) return default;
#if NET462_OR_GREATER
                var jsonStr = Encoding.UTF8.GetString(data);
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonStr);
#else
                return System.Text.Json.JsonSerializer.Deserialize<T>(data)!;
#endif
            }
        }
    }
}
