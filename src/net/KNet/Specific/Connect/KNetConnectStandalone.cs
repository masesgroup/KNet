/*
*  Copyright (c) 2021-2025 MASES s.r.l.
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

using MASES.KNet.Connect;

namespace MASES.KNet.Connect
{
    /// <summary>
    /// Class managing KNetConnectStandalone
    /// </summary>
    public class KNetConnectStandalone : MASES.JCOBridge.C2JBridge.JVMBridgeMain<KNetConnectStandalone>
    {
        /// <summary>
        /// Initialize a new <see cref="KNetConnectStandalone"/>
        /// </summary>
        public KNetConnectStandalone()
            : base("org.mases.knet.developed.connect.cli.ConnectStandalone")
        {
            KNetConnectProxy.Register();
        }
    }
}
