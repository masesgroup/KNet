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
using Org.Apache.Kafka.Clients.Producer;
using Org.Apache.Kafka.Common.Serialization;
using MASES.KNet.Serialization;
using System;
using MASES.KNet.Producer;

namespace MASES.KNet.Extensions
{
    /// <summary>
    /// Extensions for <see cref="ProducerConfigBuilder"/>
    /// </summary>
    public static class ProducerConfigBuilderExtensions
    {
        /// <summary>
        /// Test if <typeparamref name="T"/> can use basic serializer
        /// </summary>
        /// <typeparam name="T">The type to test</typeparam>
        /// <param name="builder">The <see cref="ProducerConfigBuilder"/></param>
        /// <returns><see langword="true"/> if <typeparamref name="T"/> can use basic serializer</returns>
        public static bool CanApplyBasicSerializer<T>(this ProducerConfigBuilder builder)
        {
            return KNetSerialization.IsInternalManaged<T>();
        }
        /// <summary>
        /// Apply key serializer
        /// </summary>
        /// <typeparam name="T">The type to serialize</typeparam>
        /// <param name="builder">The <see cref="ProducerConfigBuilder"/></param>
        /// <returns>The updated <see cref="ProducerConfigBuilder"/></returns>
        public static ProducerConfigBuilder WithKeySerializerClass<T>(this ProducerConfigBuilder builder)
        {
            return WithKeySerializerClass(builder, typeof(T));
        }
        /// <summary>
        /// Apply key serializer
        /// </summary>
        /// <param name="builder">The <see cref="ProducerConfigBuilder"/></param>
        /// <param name="type">The <see cref="Type"/> to serialize</param>
        /// <returns>The updated <see cref="ProducerConfigBuilder"/></returns>
        public static ProducerConfigBuilder WithKeySerializerClass(this ProducerConfigBuilder builder, System.Type type)
        {
            if (!KNetSerialization.IsInternalManaged(type)) throw new InvalidOperationException($"Cannot manage serialization with type {type}");

            if (type == typeof(byte[]))
            {
                return builder.WithKeySerializerClass(JVMBridgeBase.ClassNameOf<ByteArraySerializer>());
            }
            else if (type == typeof(double))
            {
                return builder.WithKeySerializerClass(JVMBridgeBase.ClassNameOf<DoubleSerializer>());
            }
            else if (type == typeof(float))
            {
                return builder.WithKeySerializerClass(JVMBridgeBase.ClassNameOf<FloatSerializer>());
            }
            else if (type == typeof(int))
            {
                return builder.WithKeySerializerClass(JVMBridgeBase.ClassNameOf<IntegerSerializer>());
            }
            else if (type == typeof(long))
            {
                return builder.WithKeySerializerClass(JVMBridgeBase.ClassNameOf<LongSerializer>());
            }
            else if (type == typeof(short))
            {
                return builder.WithKeySerializerClass(JVMBridgeBase.ClassNameOf<ShortSerializer>());
            }
            else if (type == typeof(string))
            {
                return builder.WithKeySerializerClass(JVMBridgeBase.ClassNameOf<StringSerializer>());
            }
            else if (type == typeof(Guid))
            {
                return builder.WithKeySerializerClass(JVMBridgeBase.ClassNameOf<UUIDSerializer>());
            }
            else if (type == typeof(void))
            {
                return builder.WithKeySerializerClass(JVMBridgeBase.ClassNameOf<VoidSerializer>());
            }
            // add other

            return builder;
        }
        /// <summary>
        /// Apply value serializer
        /// </summary>
        /// <typeparam name="T">The type to serialize</typeparam>
        /// <param name="builder">The <see cref="ProducerConfigBuilder"/></param>
        /// <returns>The updated <see cref="ProducerConfigBuilder"/></returns>
        public static ProducerConfigBuilder WithValueSerializerClass<T>(this ProducerConfigBuilder builder)
        {
            return WithValueSerializerClass(builder, typeof(T));
        }
        /// <summary>
        /// Apply value serializer
        /// </summary>
        /// <param name="builder">The <see cref="ProducerConfigBuilder"/></param>
        /// <param name="type">The <see cref="Type"/> to serialize</param>
        /// <returns>The updated <see cref="ProducerConfigBuilder"/></returns>
        public static ProducerConfigBuilder WithValueSerializerClass(this ProducerConfigBuilder builder, System.Type type)
        {
            if (!KNetSerialization.IsInternalManaged(type)) throw new InvalidOperationException($"Cannot manage serialization with type {type}");

            if (type == typeof(byte[]))
            {
                return builder.WithValueSerializerClass(JVMBridgeBase.ClassNameOf<ByteArraySerializer>());
            }
            else if (type == typeof(double))
            {
                return builder.WithValueSerializerClass(JVMBridgeBase.ClassNameOf<DoubleSerializer>());
            }
            else if (type == typeof(float))
            {
                return builder.WithValueSerializerClass(JVMBridgeBase.ClassNameOf<FloatSerializer>());
            }
            else if (type == typeof(int))
            {
                return builder.WithValueSerializerClass(JVMBridgeBase.ClassNameOf<IntegerSerializer>());
            }
            else if (type == typeof(long))
            {
                return builder.WithValueSerializerClass(JVMBridgeBase.ClassNameOf<LongSerializer>());
            }
            else if (type == typeof(short))
            {
                return builder.WithValueSerializerClass(JVMBridgeBase.ClassNameOf<ShortSerializer>());
            }
            else if (type == typeof(string))
            {
                return builder.WithValueSerializerClass(JVMBridgeBase.ClassNameOf<StringSerializer>());
            }
            else if (type == typeof(Guid))
            {
                return builder.WithValueSerializerClass(JVMBridgeBase.ClassNameOf<UUIDSerializer>());
            }
            else if (type == typeof(void))
            {
                return builder.WithValueSerializerClass(JVMBridgeBase.ClassNameOf<VoidSerializer>());
            }
            // add other

            return builder;
        }
    }
}
