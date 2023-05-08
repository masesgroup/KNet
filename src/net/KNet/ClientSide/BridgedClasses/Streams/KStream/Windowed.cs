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

namespace MASES.KNet.Streams.KStream
{
    public class Windowed : JCOBridge.C2JBridge.JVMBridgeBase<Windowed>
    {
        public override string BridgeClassName => "org.apache.kafka.streams.kstream.Windowed";

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public Windowed()
        {
        }

        public Windowed(object key, Window window)
             : base(key, window)
        {
        }

        public object Key => IExecute("key");

        public Window Window => IExecute<Window>("window");
    }

    public class Windowed<K> : Windowed
    {
        public Windowed() { }

        public Windowed(K key, Window window)
            : base(key, window)
        {
        }

        public new K Key => IExecute<K>("key");
    }
}
