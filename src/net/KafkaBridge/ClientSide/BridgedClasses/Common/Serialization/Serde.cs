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
using MASES.KafkaBridge.Java.Util;
using System;

namespace MASES.KafkaBridge.Common.Serialization
{
    public interface ISerde : IJVMBridgeBase
    {
        void Configure(Map<string, object> configs, bool isKey);
    }

    public class Serde : JVMBridgeBase<Serde>, ISerde
    {
        public override string ClassName => "org.apache.kafka.common.serialization.Serde";

        public void Configure(Map<string, object> configs, bool isKey)
        {
            IExecute("configure", configs, isKey);
        }
    }

    public interface ISerde<T> : ISerde
    {
        Serializer<T> Serializer { get; }

        Deserializer<T> Deserializer { get; }
    }

    public class Serde<T> : Serde, ISerde<T>
    {
        public override string ClassName => "org.apache.kafka.common.serialization.Serde";

        public Serializer<T> Serializer => IExecute<Serializer<T>>("serializer");

        public Deserializer<T> Deserializer => IExecute<Deserializer<T>>("deserializer");
    }
}
