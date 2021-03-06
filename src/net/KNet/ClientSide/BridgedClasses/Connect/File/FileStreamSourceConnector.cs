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

using MASES.KNet.Connect.Source;

namespace MASES.KNet.Connect.File
{
    public class FileStreamSourceConnector : SourceConnector
    {
        public override bool IsAbstract => false;

        public override string ClassName => "org.apache.kafka.connect.file.FileStreamSourceConnector";

        public static string TOPIC_CONFIG = SExecute<string>("TOPIC_CONFIG");
        public static string FILE_CONFIG = SExecute<string>("FILE_CONFIG");
        public static string TASK_BATCH_SIZE_CONFIG = SExecute<string>("TASK_BATCH_SIZE_CONFIG");
        public static string DEFAULT_TASK_BATCH_SIZE = SExecute<string>("DEFAULT_TASK_BATCH_SIZE");
    }
}
