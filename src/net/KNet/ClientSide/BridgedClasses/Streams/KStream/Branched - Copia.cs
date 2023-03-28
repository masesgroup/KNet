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

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Streams.KStream
{
    public class EmitStrategy : JVMBridgeBase<EmitStrategy>
    {
        public override bool IsInterface => true;

        public override string ClassName => "org.apache.kafka.streams.kstream.EmitStrategy";

        public enum StrategyType
        {
            ON_WINDOW_UPDATE,
            ON_WINDOW_CLOSE,
        }

        public StrategyType Type => IExecute<StrategyType>("type");

        public static EmitStrategy OnWindowClose => SExecute<EmitStrategy>("onWindowClose");

        public static EmitStrategy OnWindowUpdate => SExecute<EmitStrategy>("onWindowUpdate");
    }
}
