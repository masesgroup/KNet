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

/*
*  This file is generated by MASES.JNetReflector (ver. 2.4.0.0)
*  using kafka-clients-3.6.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Common.Utils
{
    #region Timer
    public partial class Timer
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields

        #endregion

        #region Static methods

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/Timer.html#isExpired--"/>
        /// </summary>

        /// <returns><see cref="bool"/></returns>
        public bool IsExpired()
        {
            return IExecuteWithSignature<bool>("isExpired", "()Z");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/Timer.html#notExpired--"/>
        /// </summary>

        /// <returns><see cref="bool"/></returns>
        public bool NotExpired()
        {
            return IExecuteWithSignature<bool>("notExpired", "()Z");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/Timer.html#currentTimeMs--"/>
        /// </summary>

        /// <returns><see cref="long"/></returns>
        public long CurrentTimeMs()
        {
            return IExecuteWithSignature<long>("currentTimeMs", "()J");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/Timer.html#elapsedMs--"/>
        /// </summary>

        /// <returns><see cref="long"/></returns>
        public long ElapsedMs()
        {
            return IExecuteWithSignature<long>("elapsedMs", "()J");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/Timer.html#remainingMs--"/>
        /// </summary>

        /// <returns><see cref="long"/></returns>
        public long RemainingMs()
        {
            return IExecuteWithSignature<long>("remainingMs", "()J");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/Timer.html#timeoutMs--"/>
        /// </summary>

        /// <returns><see cref="long"/></returns>
        public long TimeoutMs()
        {
            return IExecuteWithSignature<long>("timeoutMs", "()J");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/Timer.html#reset-long-"/>
        /// </summary>
        /// <param name="arg0"><see cref="long"/></param>
        public void Reset(long arg0)
        {
            IExecuteWithSignature("reset", "(J)V", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/Timer.html#resetDeadline-long-"/>
        /// </summary>
        /// <param name="arg0"><see cref="long"/></param>
        public void ResetDeadline(long arg0)
        {
            IExecuteWithSignature("resetDeadline", "(J)V", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/Timer.html#sleep-long-"/>
        /// </summary>
        /// <param name="arg0"><see cref="long"/></param>
        public void Sleep(long arg0)
        {
            IExecuteWithSignature("sleep", "(J)V", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/Timer.html#update--"/>
        /// </summary>
        public void Update()
        {
            IExecuteWithSignature("update", "()V");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/Timer.html#update-long-"/>
        /// </summary>
        /// <param name="arg0"><see cref="long"/></param>
        public void Update(long arg0)
        {
            IExecuteWithSignature("update", "(J)V", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/Timer.html#updateAndReset-long-"/>
        /// </summary>
        /// <param name="arg0"><see cref="long"/></param>
        public void UpdateAndReset(long arg0)
        {
            IExecuteWithSignature("updateAndReset", "(J)V", arg0);
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}