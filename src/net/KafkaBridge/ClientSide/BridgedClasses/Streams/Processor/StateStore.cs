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

namespace MASES.KafkaBridge.Streams.Processor
{
    public interface IStateStore : IJVMBridgeBase
    {
        string Name { get; }

        void Flush();

        void Close();

        bool Persistent { get; }

        bool IsOpen { get; }
    }

    public class StateStore : JVMBridgeBase<StateStore, IStateStore>, IStateStore
    {
        public override string ClassName => "org.apache.kafka.streams.processor.StateStore";

        public string Name => IExecute<string>("name");

        public bool Persistent => IExecute<bool>("persistent");

        public bool IsOpen => IExecute<bool>("isOpen");

        public void Close()
        {
            IExecute("close");
        }

        public void Flush()
        {
            IExecute("flush");
        }
    }
}
