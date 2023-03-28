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

using Java.Util;
using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Connect.Rest.Basic.Auth.Extension
{
    public class PropertyFileLoginModule : JVMBridgeBase<PropertyFileLoginModule>
    {
        public override string ClassName => "org.apache.kafka.connect.rest.basic.auth.extension.PropertyFileLoginModule";

#warning need classes into JNet: use dynamic until now
        //public void Initialize(Subject subject, CallbackHandler callbackHandler, Map<string, object> sharedState, Map<string, object> options)
        //{
        //    IExecute("initialize", subject, callbackHandler, sharedState, options);
        //}

        public bool Login() => IExecute<bool>("login");

        public bool Commit() => IExecute<bool>("commit");

        public bool Abort() => IExecute<bool>("abort");

        public bool Logout() => IExecute<bool>("logout");
    }
}
