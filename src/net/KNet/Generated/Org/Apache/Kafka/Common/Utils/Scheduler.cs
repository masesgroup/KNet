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
*  This file is generated by MASES.JNetReflector (ver. 2.0.2.0)
*  using kafka-clients-3.6.0.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Common.Utils
{
    #region IScheduler
    /// <summary>
    /// .NET interface for TO BE DEFINED FROM USER
    /// </summary>
    public partial interface IScheduler
    {
        #region Instance methods

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion

    #region Scheduler
    public partial class Scheduler : Org.Apache.Kafka.Common.Utils.IScheduler
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/common/utils/Scheduler.html#SYSTEM"/>
        /// </summary>
        public static Org.Apache.Kafka.Common.Utils.Scheduler SYSTEM { get { return SGetField<Org.Apache.Kafka.Common.Utils.Scheduler>(LocalBridgeClazz, "SYSTEM"); } }

        #endregion

        #region Static methods

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/common/utils/Scheduler.html#schedule-java.util.concurrent.ScheduledExecutorService-java.util.concurrent.Callable-long-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.Concurrent.ScheduledExecutorService"/></param>
        /// <param name="arg1"><see cref="Java.Util.Concurrent.Callable"/></param>
        /// <param name="arg2"><see cref="long"/></param>
        /// <typeparam name="T"></typeparam>
        /// <returns><see cref="Java.Util.Concurrent.Future"/></returns>
        public Java.Util.Concurrent.Future<T> Schedule<T>(Java.Util.Concurrent.ScheduledExecutorService arg0, Java.Util.Concurrent.Callable<T> arg1, long arg2)
        {
            return IExecute<Java.Util.Concurrent.Future<T>>("schedule", arg0, arg1, arg2);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/common/utils/Scheduler.html#time--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.Utils.Time"/></returns>
        public Org.Apache.Kafka.Common.Utils.Time Time()
        {
            return IExecute<Org.Apache.Kafka.Common.Utils.Time>("time");
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}