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
using Org.Apache.Kafka.Common.Serialization;
using System;

namespace MASES.KNet.Serialization
{
    /// <summary>
    /// KNet interface for serializers
    /// </summary>
    /// <typeparam name="T">The .NET type</typeparam>
    /// <typeparam name="TJVMT">The JVM type used</typeparam>
    public interface IKNetSerializer<T, TJVMT> : IDisposable
    {
        /// <summary>
        /// The <see cref="Serializer{T}"/> to use in Apache Kafka
        /// </summary>
        public Serializer<TJVMT> KafkaSerializer { get; }
        /// <summary>
        /// <see langword="true"/> if <see cref="Headers"/>are used
        /// </summary>
        bool UseHeaders { get; }
        /// <inheritdoc cref="ISerializer{T}.Serialize(Java.Lang.String, T)"/>
        byte[] Serialize(string topic, T data);
        /// <inheritdoc cref="ISerializer{T}.Serialize(Java.Lang.String, Headers, T)"/>
        byte[] SerializeWithHeaders(string topic, Headers headers, T data);
    }

    /// <summary>
    /// KNet interface for serializers based on <see cref="byte"/> array JVM type
    /// </summary>
    /// <typeparam name="T">The .NET type</typeparam>
    public interface IKNetSerializer<T> : IKNetSerializer<T, byte[]>
    {

    }
}
