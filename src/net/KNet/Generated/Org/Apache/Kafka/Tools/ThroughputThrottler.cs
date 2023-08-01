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

/*
*  This file is generated by MASES.JNetReflector (ver. 2.0.1.0)
*  using kafka-tools-3.5.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Tools
{
    #region ThroughputThrottler
    public partial class ThroughputThrottler
    {
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-tools/3.5.1/org/apache/kafka/tools/ThroughputThrottler.html#org.apache.kafka.tools.ThroughputThrottler(long,long)"/>
        /// </summary>
        /// <param name="arg0"><see cref="long"/></param>
        /// <param name="arg1"><see cref="long"/></param>
        public ThroughputThrottler(long arg0, long arg1)
            : base(arg0, arg1)
        {
        }

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields

        #endregion

        #region Static methods

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-tools/3.5.1/org/apache/kafka/tools/ThroughputThrottler.html#shouldThrottle-long-long-"/>
        /// </summary>
        /// <param name="arg0"><see cref="long"/></param>
        /// <param name="arg1"><see cref="long"/></param>
        /// <returns><see cref="bool"/></returns>
        public bool ShouldThrottle(long arg0, long arg1)
        {
            return IExecute<bool>("shouldThrottle", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-tools/3.5.1/org/apache/kafka/tools/ThroughputThrottler.html#throttle--"/>
        /// </summary>
        public void Throttle()
        {
            IExecute("throttle");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-tools/3.5.1/org/apache/kafka/tools/ThroughputThrottler.html#wakeup--"/>
        /// </summary>
        public void Wakeup()
        {
            IExecute("wakeup");
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}