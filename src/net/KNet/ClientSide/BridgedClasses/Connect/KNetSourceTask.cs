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
using MASES.KNet.Connect.Source;

namespace MASES.KNet.Connect
{
    /// <summary>
    /// An implementation of <see cref="KNetTask"/> for source task
    /// </summary>
    public abstract class KNetSourceTask : KNetTask
    {
        /// <summary>
        /// The <see cref="SourceTaskContext"/>
        /// </summary>
        public SourceTaskContext Context => Context<SourceTaskContext>();
        /// <summary>
        /// Set the <see cref="ReflectedTaskClassName"/> of the connector to a fixed value
        /// </summary>
        public override string ReflectedTaskClassName => "KNetSourceTask";
        /// <summary>
        /// Public method used from Java to trigger <see cref="Poll"/>
        /// </summary>
        public void PollInternal()
        {
            var result = Poll();
            DataToExchange(result);
        }
        /// <summary>
        /// Implement the method to execute the Poll action
        /// </summary>
        /// <returns>The list of <see cref="SourceRecord"/> to return to Apache Kafka Connect framework</returns>
        public abstract List<SourceRecord> Poll();
    }
}
