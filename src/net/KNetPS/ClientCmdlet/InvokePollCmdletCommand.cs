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

using Org.Apache.Kafka.Clients.Consumer;
using MASES.KNetPS.Cmdlet;
using System.Management.Automation;
using System.Reflection;

namespace MASES.KNetPS.ClientCmdlet
{
    [Cmdlet(VerbsLifecycle.Invoke, "Poll")]
    [OutputType(typeof(ConsumerRecords<,>))]
    public class InvokePollCmdletCommand : KNetPSCmdlet
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
            HelpMessage = "The KafkaConsumer where execute the poll operation")]
        public KafkaConsumer Consumer { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 3,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The timeout to be used in operation")]
        public long PollTimeout { get; set; }

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
            var kafkaConsumerType = typeof(KafkaConsumer<,>).MakeGenericType(keyType, valueType);
            MethodInfo poll = kafkaConsumerType.GetMethod("Poll", new System.Type[] { typeof(long) });
            var result = poll.Invoke(Consumer, new object[] { PollTimeout });
            WriteObject(result);
        }

        // This method will be called once at the end of pipeline execution; if no input is received, this method is not called
        protected override void EndProcessing()
        {
            WriteVerbose("End ConsumerRecords!");
        }
    }
}
