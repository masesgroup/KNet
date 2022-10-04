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

using Java.Util;
using MASES.JCOBridge.C2JBridge;
using MASES.KNet.Connect.Storage;

namespace MASES.KNet.Connect.Source
{
    public class SourceTaskContext : JVMBridgeBase<SourceTaskContext>
    {
        public override bool IsInterface => true;
        public override string ClassName => "org.apache.kafka.connect.source.SourceTaskContext";

        public Map<string, string> Configs => IExecute<Map<string, string>>("configs");

        public OffsetStorageReader OffsetStorageReader => IExecute<OffsetStorageReader>("offsetStorageReader");

        public TransactionContext TransactionContext => IExecute<TransactionContext>("transactionContext");
    }
}
