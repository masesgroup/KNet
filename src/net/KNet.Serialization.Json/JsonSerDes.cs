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
using System.Text;

namespace MASES.KNet.Serialization.Json
{
    /// <summary>
    /// Json extension of <see cref="KNetSerDes{T}"/>, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class JsonSerDes<T> : KNetSerDes<T>
    {
        /// <summary>
        /// The extension uses <see cref="Headers"/>
        /// </summary>
        public override bool UseHeaders => true;
        /// <inheritdoc cref="KNetSerDes{T}.SerializeWithHeaders(string, Headers, T)"/>
        public override byte[] SerializeWithHeaders(string topic, Headers headers, T data)
        {
#if NET462_OR_GREATER
            var jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.None);
            return Encoding.UTF8.GetBytes(jsonStr);
#else
            var jsonStr = System.Text.Json.JsonSerializer.Serialize<T>(data);
            return Encoding.UTF8.GetBytes(jsonStr);
#endif
        }
        /// <inheritdoc cref="KNetSerDes{T}.DeserializeWithHeaders(string, Headers, byte[])"/>
        public override T DeserializeWithHeaders(string topic, Headers headers, byte[] data)
        {
#if NET462_OR_GREATER
            var jsonStr = Encoding.UTF8.GetString(data);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonStr);
#else
            return System.Text.Json.JsonSerializer.Deserialize<T>(data)!;
#endif
        }
    }
}
