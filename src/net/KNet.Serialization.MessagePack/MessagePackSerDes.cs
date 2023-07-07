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

using Org.Apache.Kafka.Common.Header;
using MessagePack;
using System.IO;

namespace MASES.KNet.Serialization.MessagePack
{
    /// <summary>
    /// MessagePack extension of <see cref="KNetSerDes{T}"/>, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MessagePackSerDes<T> : KNetSerDes<T>
    {
        /// <summary>
        /// Can manage any type in <typeparamref name="T"/>
        /// </summary>
        protected override bool ManagesAnyType => true;
        /// <summary>
        /// The extension uses <see cref="Headers"/>
        /// </summary>
        public override bool UseHeaders => true;
        /// <inheritdoc cref="KNetSerDes{T}.SerializeWithHeaders(string, Headers, T)"/>
        public override byte[] SerializeWithHeaders(string topic, Headers headers, T data)
        {
            return MessagePackSerializer.Serialize(data);
        }
        /// <inheritdoc cref="KNetSerDes{T}.DeserializeWithHeaders(string, Headers, byte[])"/>
        public override T DeserializeWithHeaders(string topic, Headers headers, byte[] data)
        {
            using (MemoryStream stream = new MemoryStream(data))
            {
                return MessagePackSerializer.Deserialize<T>(stream);
            }
        }
    }
}
