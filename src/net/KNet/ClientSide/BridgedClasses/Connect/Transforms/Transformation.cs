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

using MASES.KNet.Common;
using MASES.KNet.Common.Config;
using MASES.KNet.Connect.Connector;

namespace MASES.KNet.Connect.Transforms
{
    public class Transformation<R> : Configurable where R : ConnectRecord<R>
    {
        public override bool IsInterface => true;

        public override string ClassName => "org.apache.kafka.connect.transforms.Transformation";

        public R Apply(R record) => IExecute<R>("apply", record);

        public ConfigDef Config => IExecute<ConfigDef>("config");

        public void Close() => IExecute("close");
    }
}
