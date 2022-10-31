/*
*  Copyright 2022 MASES s.r.l.
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
using MASES.KNet.Clients.Consumer;
using MASES.KNet.Common.Serialization;

namespace MASES.KNet.Extensions
{
    public static class ConsumerConfigBuilderExtensions
    {
        public static ConsumerConfigBuilder WithKeyDeserializerClass<T>(this ConsumerConfigBuilder builder)
        {
            return WithKeyDeserializerClass(builder, typeof(T));
        }

        public static ConsumerConfigBuilder WithKeyDeserializerClass(this ConsumerConfigBuilder builder, System.Type type)
        {
            if (type == typeof(string))
            {
                return builder.WithKeyDeserializerClass(JVMBridgeBase.ClassNameOf<StringDeserializer>());
            }
            // add other

            return builder;
        }

        public static ConsumerConfigBuilder WithValueDeserializerClass<T>(this ConsumerConfigBuilder builder)
        {
            return WithValueDeserializerClass(builder, typeof(T));
        }

        public static ConsumerConfigBuilder WithValueDeserializerClass(this ConsumerConfigBuilder builder, System.Type type)
        {
            if (type == typeof(string))
            {
                return builder.WithValueDeserializerClass(JVMBridgeBase.ClassNameOf<StringDeserializer>());
            }
            // add other

            return builder;
        }
    }
}
