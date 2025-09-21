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

using MASES.JCOBridge.C2JBridge;

namespace Kafka.Tools
{
    /// <summary>
    /// Class managing StorageTool
    /// </summary>
    public class StorageTool : MASES.JCOBridge.C2JBridge.JVMBridgeMain<StorageTool>
    {
        /// <summary>
        /// Initialize a new <see cref="StorageTool"/>
        /// </summary>
        public StorageTool()
            : base("kafka.tools.StorageTool")
        {
        }
        /// <inheritdoc/>
        [global::System.Obsolete("This public initializer is needed for JCOBridge internal use, other uses can produce unidentible behaviors.")]
        public StorageTool(IJVMBridgeBaseInitializer initializer) : base(initializer) { }
    }
}
