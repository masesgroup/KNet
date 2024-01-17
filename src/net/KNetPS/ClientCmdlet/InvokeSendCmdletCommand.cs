/*
*  Copyright 2024 MASES s.r.l.
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

using Java.Util.Concurrent;
using Org.Apache.Kafka.Clients.Producer;
using MASES.KNetPS.Cmdlet;
using System.Management.Automation;

namespace MASES.KNetPS.ClientCmdlet
{
    [Cmdlet(VerbsLifecycle.Invoke, "Send")]
    [OutputType(typeof(Future<RecordMetadata>))]
    public class InvokeSendCmdletCommand : KNetPSCmdlet
    {
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The KafkaProducer where execute the Send operation")]
        public KafkaProducer Producer { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The ProducerRecord to use")]
        public ProducerRecord ProducerRecord { get; set; }

        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void BeginProcessing()
        {
            WriteVerbose("Begin Send!");
        }

        // This method will be called for each input received from the pipeline to this cmdlet; if no input is received, this method is not called
        protected override void ProcessCommand()
        {
            var result = Producer.Send(ProducerRecord);
            WriteObject(result);
        }

        // This method will be called once at the end of pipeline execution; if no input is received, this method is not called
        protected override void EndProcessing()
        {
            WriteVerbose("End Send!");
        }
    }
}
