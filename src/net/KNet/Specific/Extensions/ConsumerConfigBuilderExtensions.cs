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

using MASES.JCOBridge.C2JBridge;
using Org.Apache.Kafka.Clients.Consumer;
using Org.Apache.Kafka.Common.Serialization;
using MASES.KNet.Serialization;
using System;
using MASES.KNet.Consumer;

namespace MASES.KNet.Extensions
{
    /// <summary>
    /// Extension for <see cref="ConsumerConfigBuilder"/>
    /// </summary>
    public static class ConsumerConfigBuilderExtensions
    {
        /// <summary>
        /// Test if <typeparamref name="T"/> can use basic serializer
        /// </summary>
        /// <typeparam name="T">The type to test</typeparam>
        /// <param name="builder">The <see cref="ConsumerConfigBuilder"/></param>
        /// <returns><see langword="true"/> if <typeparamref name="T"/> can use basic serializer</returns>
        public static bool CanApplyBasicDeserializer<T>(this ConsumerConfigBuilder builder)
        {
            return KNetSerialization.IsInternalManaged<T>();
        }
        /// <summary>
        /// Apply key serializer
        /// </summary>
        /// <typeparam name="T">The type to serialize</typeparam>
        /// <param name="builder">The <see cref="ConsumerConfigBuilder"/></param>
        /// <returns>The updated <see cref="ConsumerConfigBuilder"/></returns>
        public static ConsumerConfigBuilder WithKeyDeserializerClass<T>(this ConsumerConfigBuilder builder)
        {
            return WithKeyDeserializerClass(builder, typeof(T));
        }
        /// <summary>
        /// Apply key serializer
        /// </summary>
        /// <param name="builder">The <see cref="ConsumerConfigBuilder"/></param>
        /// <param name="type">The <see cref="Type"/> to serialize</param>
        /// <returns>The updated <see cref="ConsumerConfigBuilder"/></returns>
        public static ConsumerConfigBuilder WithKeyDeserializerClass(this ConsumerConfigBuilder builder, System.Type type)
        {
            if (!KNetSerialization.IsInternalManaged(type)) throw new InvalidOperationException($"Cannot manage serialization with type {type}");

            if (type == typeof(byte[]))
            {
                return builder.WithKeyDeserializerClass(JVMBridgeBase.ClassNameOf<ByteArrayDeserializer>());
            }
            else if (type == typeof(double))
            {
                return builder.WithKeyDeserializerClass(JVMBridgeBase.ClassNameOf<DoubleDeserializer>());
            }
            else if (type == typeof(float))
            {
                return builder.WithKeyDeserializerClass(JVMBridgeBase.ClassNameOf<FloatDeserializer>());
            }
            else if (type == typeof(int))
            {
                return builder.WithKeyDeserializerClass(JVMBridgeBase.ClassNameOf<IntegerDeserializer>());
            }
            else if (type == typeof(long))
            {
                return builder.WithKeyDeserializerClass(JVMBridgeBase.ClassNameOf<LongDeserializer>());
            }
            else if (type == typeof(short))
            {
                return builder.WithKeyDeserializerClass(JVMBridgeBase.ClassNameOf<ShortDeserializer>());
            }
            else if (type == typeof(string))
            {
                return builder.WithKeyDeserializerClass(JVMBridgeBase.ClassNameOf<StringDeserializer>());
            }
            else if (type == typeof(Guid))
            {
                return builder.WithKeyDeserializerClass(JVMBridgeBase.ClassNameOf<UUIDDeserializer>());
            }
            else if (type == typeof(void))
            {
                return builder.WithKeyDeserializerClass(JVMBridgeBase.ClassNameOf<VoidDeserializer>());
            }
            // add other

            return builder;
        }
        /// <summary>
        /// Apply value serializer
        /// </summary>
        /// <typeparam name="T">The type to serialize</typeparam>
        /// <param name="builder">The <see cref="ConsumerConfigBuilder"/></param>
        /// <returns>The updated <see cref="ConsumerConfigBuilder"/></returns>
        public static ConsumerConfigBuilder WithValueDeserializerClass<T>(this ConsumerConfigBuilder builder)
        {
            return WithValueDeserializerClass(builder, typeof(T));
        }
        /// <summary>
        /// Apply value serializer
        /// </summary>
        /// <param name="builder">The <see cref="ConsumerConfigBuilder"/></param>
        /// <param name="type">The <see cref="Type"/> to serialize</param>
        /// <returns>The updated <see cref="ConsumerConfigBuilder"/></returns>
        public static ConsumerConfigBuilder WithValueDeserializerClass(this ConsumerConfigBuilder builder, System.Type type)
        {
            if (!KNetSerialization.IsInternalManaged(type)) throw new InvalidOperationException($"Cannot manage serialization with type {type}");

            if (type == typeof(byte[]))
            {
                return builder.WithValueDeserializerClass(JVMBridgeBase.ClassNameOf<ByteArrayDeserializer>());
            }
            else if (type == typeof(double))
            {
                return builder.WithValueDeserializerClass(JVMBridgeBase.ClassNameOf<DoubleDeserializer>());
            }
            else if (type == typeof(float))
            {
                return builder.WithValueDeserializerClass(JVMBridgeBase.ClassNameOf<FloatDeserializer>());
            }
            else if (type == typeof(int))
            {
                return builder.WithValueDeserializerClass(JVMBridgeBase.ClassNameOf<IntegerDeserializer>());
            }
            else if (type == typeof(long))
            {
                return builder.WithValueDeserializerClass(JVMBridgeBase.ClassNameOf<LongDeserializer>());
            }
            else if (type == typeof(short))
            {
                return builder.WithValueDeserializerClass(JVMBridgeBase.ClassNameOf<ShortDeserializer>());
            }
            else if (type == typeof(string))
            {
                return builder.WithValueDeserializerClass(JVMBridgeBase.ClassNameOf<StringDeserializer>());
            }
            else if (type == typeof(Guid))
            {
                return builder.WithValueDeserializerClass(JVMBridgeBase.ClassNameOf<UUIDDeserializer>());
            }
            else if (type == typeof(void))
            {
                return builder.WithValueDeserializerClass(JVMBridgeBase.ClassNameOf<VoidDeserializer>());
            }
            // add other

            return builder;
        }
    }
}
