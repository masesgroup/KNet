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
using MASES.KNet;
using MASES.KNetPS;
using System;
using System.Linq;
using System.Management.Automation;
using System.Reflection;

namespace MASES.JNetPS.Cmdlet
{
    public class KafkaClassToRunCmdletCommandBase<T> : StartKNetPSCmdletCommandBase<T>
        where T : KafkaClassToRunCmdletCommandBase<T>
    {
        [Parameter(
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The arguments to be sent to the Kafka command.")]
        public string Arguments { get; set; }

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            var t = typeof(T);
            if (!t.IsDefined(typeof(CmdletAttribute), false)) throw new PSInvalidOperationException("Missing Cmdlet attribute");
            var attribute = t.GetCustomAttributes(typeof(CmdletAttribute), false).First() as CmdletAttribute;
            KNetPSHelper<KNetCore>.SetClassToRun(attribute.NounName);
        }

        protected override void CreateGlobalInstance()
        {
            base.CreateGlobalInstance();
            string[] arguments = Array.Empty<string>();
            if (Arguments != null)
            {
                arguments = Arguments.Split(' ');
            }

            try
            {
                var core = Activator.CreateInstance(KNetCore.MainClassToRun) as JVMBridgeBase;
                if (core == null) throw new ArgumentException("Requested class is not a child of JVMBridgeBase.");

                core.Execute(arguments);
            }
            catch (TargetInvocationException tie)
            {
                throw tie.InnerException;
            }
            catch (JCOBridge.C2JBridge.JVMInterop.JavaException je)
            {
                throw je.Convert();
            }
        }
    }
}
