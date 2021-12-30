/*
*  Copyright 2021 MASES s.r.l.
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

namespace MASES.KafkaBridge.Tools
{
    /// <summary>
    /// Class managing VerifiableConsumer
    /// </summary>
    public class VerifiableConsumer : JCOBridge.C2JBridge.JVMBridgeMain<VerifiableConsumer>
    {
        static VerifiableConsumer()
        {
            KafkaBridgeCore.GlobalHeapSize = "512M";
        }

        /// <summary>
        /// Initialize a new <see cref="VerifiableConsumer"/>
        /// </summary>
        public VerifiableConsumer()
            : base("org.apache.kafka.tools.VerifiableConsumer")
        {
        }
    }
}
