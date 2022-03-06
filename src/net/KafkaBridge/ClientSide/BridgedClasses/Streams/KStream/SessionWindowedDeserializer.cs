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

using MASES.KafkaBridge.Common.Serialization;
using MASES.KafkaBridge.Java.Util;

namespace MASES.KafkaBridge.Streams.KStream
{
    public class SessionWindowedDeserializer<T> : JCOBridge.C2JBridge.JVMBridgeBase<SessionWindowedDeserializer<T>>
    {
        public override bool IsCloseable => true;

        public override string ClassName => "org.apache.kafka.streams.kstream.SessionWindowedDeserializer";

        public SessionWindowedDeserializer() { }

        public SessionWindowedDeserializer(Deserializer<T> inner)
            : base(inner)
        {
        }

        public void Configure(Map<string, object> configs, bool isKey)
        {
            IExecute("configure", configs, isKey);
        }

        public Windowed<T> Deserialize(string topic, byte[] data)
        {
            return IExecute<Windowed<T>>("deserialize", topic, data);
        }
    }
}
