/*
*  Copyright 2023 MASES s.r.l.
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

using System;
using System.Collections.Generic;

namespace Org.Apache.Kafka.Tools
{
    #region StreamsResetter
    public partial class StreamsResetter
    {
        /// <summary>
        /// Resets an <paramref name="applicationId"/> of Apache Kafka Streams
        /// </summary>
        /// <param name="bootstrapserver">The bootstrap server of the Apache Kafka cluster</param>
        /// <param name="applicationId">The application id to be resetted</param>
        /// <param name="inputTopics">Input topics to be resetted</param>
        /// <returns><see langword="true"/> if everything goes well, otherwise <see langword="false"/></returns>
        /// <exception cref="ArgumentNullException">Either <paramref name="applicationId"/> or <paramref name="bootstrapserver"/> are <see langword="null"/></exception>
        public static bool ResetApplication(string bootstrapserver, string applicationId, params string[] inputTopics)
        {
            return ResetApplication(false, bootstrapserver, applicationId, inputTopics);  
        }

        /// <summary>
        /// Resets an <paramref name="applicationId"/> of Apache Kafka Streams and forces deletion of active members from the group
        /// </summary>
        /// <param name="bootstrapserver">The bootstrap server of the Apache Kafka cluster</param>
        /// <param name="applicationId">The application id to be resetted</param>
        /// <param name="inputTopics">Input topics to be resetted</param>
        /// <returns><see langword="true"/> if everything goes well, otherwise <see langword="false"/></returns>
        /// <exception cref="ArgumentNullException">Either <paramref name="applicationId"/> or <paramref name="bootstrapserver"/> are <see langword="null"/></exception>
        public static bool ResetApplicationForced(string bootstrapserver, string applicationId, params string[] inputTopics)
        {
            return ResetApplication(true, bootstrapserver, applicationId, inputTopics);
        }

        static bool ResetApplication(bool force, string bootstrapserver, string applicationId, string[] inputTopics)
        {
            if (bootstrapserver == null) throw new ArgumentNullException(nameof(bootstrapserver));
            if (applicationId == null) throw new ArgumentNullException(nameof(applicationId));

            List<string> strings = new();
            strings.Add("--bootstrap-server");
            strings.Add(bootstrapserver);
            strings.Add("--application-id");
            strings.Add(applicationId);
            if (inputTopics != null && inputTopics.Length != 0)
            {
                strings.Add("--input-topics");
                strings.Add(string.Join(",", inputTopics));
            }
            if (force) strings.Add("--force");

            return new StreamsResetter().Run(strings.ToArray()) == 0;
        }
    }
    #endregion
}