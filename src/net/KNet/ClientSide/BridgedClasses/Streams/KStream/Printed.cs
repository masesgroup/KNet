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

namespace MASES.KNet.Streams.KStream
{
    public class Printed<K, V> : JVMBridgeBase<Printed<K, V>>
    {
        public override string ClassName => "org.apache.kafka.streams.kstream.Printed";

        public static Printed<K, V> ToFile(string filePath)
        {
            return SExecute<Printed<K, V>>("toFile", filePath);
        }

        public static Printed<K, V> ToSysOut()
        {
            return SExecute<Printed<K, V>>("toSysOut");
        }

        public Printed<K, V> WithLabel(string label)
        {
            return IExecute<Printed<K, V>>("withLabel", label);
        }

        public Printed<K, V> WithKeyValueMapper<TKey, TValue>(KeyValueMapper<TKey, TValue, string> mapper)
            where TKey : K
            where TValue : V
        {
            return IExecute<Printed<K, V>>("withKeyValueMapper", mapper);
        }

        public Printed<K, V> WithName(string processorName)
        {
            return IExecute<Printed<K, V>>("withName", processorName);
        }
    }
}
