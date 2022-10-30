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

using Java.Util;
using Java.Util.Regex;
using MASES.KNet.Clients.Consumer;
using System.Management.Automation;

namespace MASES.KNetPS.ClientCmdlet
{
    [Cmdlet(VerbsLifecycle.Invoke, "Subscribe")]
    public class InvokeSubscribeCmdletCommand : PSCmdlet
    {
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The KafkaConsumer where execute the Subscribe operation")]
        public KafkaConsumer Consumer { get; set; }

        [Parameter(
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The topic where subscribe on")]
        public string Topic { get; set; }

        [Parameter(
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The pattern where subscribe on")]
        public string PatternRegEx { get; set; }

        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void BeginProcessing()
        {
            WriteVerbose("Begin Subscribe!");
        }

        // This method will be called for each input received from the pipeline to this cmdlet; if no input is received, this method is not called
        protected override void ProcessRecord()
        {
            if (Topic != null)
            {
                Consumer.Subscribe(Collections.Singleton(Topic));
            }
            else if (PatternRegEx != null)
            {
                Consumer.Subscribe(Pattern.Compile(PatternRegEx));
            }
            else throw new PSArgumentException("At least one of Topic or PatternRegEx shall be supplied.");
        }

        // This method will be called once at the end of pipeline execution; if no input is received, this method is not called
        protected override void EndProcessing()
        {
            WriteVerbose("End Subscribe!");
        }
    }
}
