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

namespace MASES.KafkaBridge.Streams.KStream
{
    public class Windowed<K> : JCOBridge.C2JBridge.JVMBridgeBase<Windowed<K>>
    {
        public override string ClassName => "org.apache.kafka.streams.kstream.Windowed";

        [System.Obsolete("This is not public in Apache Kafka API")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public Windowed() { }

        public Windowed(K key, Window window)
            : base(key, window)
        {
        }

        public K Key => IExecute<K>("key");

        public Window Window => IExecute<Window>("window");
    }

    public class Windowed : Windowed<object>
    {
        public Windowed()
        {
        }

        public Windowed(object key, Window window)
             : base(key, window)
        {
        }
    }
}
