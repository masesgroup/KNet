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
using MASES.KNet.Clients.Producer;
using MASES.KNet.Extensions;
using MASES.KNetPS.Cmdlet;
using System;
using System.Management.Automation;
using System.Reflection;

namespace MASES.KNetPS.ClientCmdlet
{
    [Cmdlet(VerbsCommon.New, "KafkaProducer")]
    [OutputType(typeof(KafkaProducer<,>))]
    public class NewKafkaProducerCmdletCommand : KNetPSCmdlet
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
            HelpMessage = "The configuration to be used as a ProducerConfigBuilder object")]
        public ProducerConfigBuilder Configuration { get; set; }

        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void BeginProcessing()
        {
            WriteVerbose("Begin KNetProducer!");
        }

        // This method will be called for each input received from the pipeline to this cmdlet; if no input is received, this method is not called
        protected override void ProcessCommand()
        {
            System.Type keyType = System.Type.GetType(KeyClass);
            System.Type valueType = System.Type.GetType(ValueClass);

            var kafkaProducerType = typeof(KafkaProducer<,>).MakeGenericType(keyType, valueType);

            var newConf = Configuration.WithKeySerializerClass(keyType).WithValueSerializerClass(valueType);

            var kafkaProducer = Activator.CreateInstance(kafkaProducerType, newConf.ToProperties());
            WriteObject(kafkaProducer);
        }

        // This method will be called once at the end of pipeline execution; if no input is received, this method is not called
        protected override void EndProcessing()
        {
            WriteVerbose("End KNetProducer!");
        }
    }
}
