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
using MASES.KNet.Clients.Producer;
using MASES.KNet.Connect.Connector;

namespace MASES.KNet.Connect.Source
{
    public class SourceTask : Task
    {
        public override bool IsInterface => false;
        public override bool IsAbstract => true;

        public override string ClassName => "org.apache.kafka.connect.source.SourceTask";

        public void Initialize(SourceTaskContext context) => IExecute("initialize", context);

        public List<SourceRecord> Poll() => IExecute<List<SourceRecord>>("poll");

        public void Commit() => IExecute("commit");

        public void CommitRecord(SourceRecord record, RecordMetadata metadata) => IExecute("commit", record, metadata);
    }
}
