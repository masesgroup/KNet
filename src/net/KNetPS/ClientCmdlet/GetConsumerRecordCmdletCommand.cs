/*
*  Copyright 2025 MASES s.r.l.
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
using MASES.JCOBridge.C2JBridge.JVMInterop;
using Org.Apache.Kafka.Clients.Consumer;
using MASES.KNetPS.Cmdlet;
using System;
using System.Collections;
using System.Management.Automation;
using System.Reflection;

namespace MASES.KNetPS.ClientCmdlet
{
    [Cmdlet(VerbsCommon.Get, "ConsumerRecord")]
    [OutputType(typeof(ConsumerRecord<,>))]
    public class GetConsumerRecordCmdletCommand : KNetPSCmdlet
    {
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The dotnet class of the key")]
        public string KeyClass { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The dotnet class of the value")]
        public string ValueClass { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The object returned from Invoke-Poll")]
        public object ConsumerRecords { get; set; }

        [Parameter(
            Position = 3,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The topic where operate on, otherwise all elements")]
        public string Topic { get; set; }

        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void BeginProcessing()
        {
            WriteVerbose("Begin ConsumerRecords!");
        }

        // This method will be called for each input received from the pipeline to this cmdlet; if no input is received, this method is not called
        protected override void ProcessCommand()
        {
            System.Type keyType = System.Type.GetType(KeyClass);
            System.Type valueType = System.Type.GetType(ValueClass);
            var consumerRecordsType = typeof(ConsumerRecords<,>).MakeGenericType(keyType, valueType);

            var consumerRecords = ConsumerRecords;
            if (consumerRecords is PSObject psRecords) consumerRecords = psRecords.BaseObject;

            if (Topic == null)
            {
                var consumerRecordType = typeof(ConsumerRecord<,>).MakeGenericType(keyType, valueType);

                foreach (IJavaObject item in consumerRecords as IEnumerable)
                {
                    var res = JVMBridgeBase.Wraps(consumerRecordType, item, JVMBridgeBase.ClassNameOf<ConsumerRecord>());
                    WriteObject(res);
                }
            }
            else
            {
                MethodInfo recordsMethod = consumerRecordsType.GetMethod("Records", new Type[] { typeof(string) });
                var records = recordsMethod.Invoke(consumerRecords, new object[] { Topic });
                throw new NotImplementedException();
            }
        }

        // This method will be called once at the end of pipeline execution; if no input is received, this method is not called
        protected override void EndProcessing()
        {
            WriteVerbose("End ConsumerRecords!");
        }
    }
}
