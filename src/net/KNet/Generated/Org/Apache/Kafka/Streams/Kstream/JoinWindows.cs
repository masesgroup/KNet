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
*  using kafka-streams-3.6.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Streams.Kstream
{
    #region JoinWindows
    public partial class JoinWindows
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/JoinWindows.html#afterMs"/>
        /// </summary>
        public long afterMs { get { if (!_afterMsReady) { _afterMsContent = IGetField<long>("afterMs"); _afterMsReady = true; } return _afterMsContent; } }
        private long _afterMsContent = default;
        private bool _afterMsReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/JoinWindows.html#beforeMs"/>
        /// </summary>
        public long beforeMs { get { if (!_beforeMsReady) { _beforeMsContent = IGetField<long>("beforeMs"); _beforeMsReady = true; } return _beforeMsContent; } }
        private long _beforeMsContent = default;
        private bool _beforeMsReady = false; // this is used because in case of generics 

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/JoinWindows.html#ofTimeDifferenceAndGrace-java.time.Duration-java.time.Duration-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Time.Duration"/></param>
        /// <param name="arg1"><see cref="Java.Time.Duration"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.JoinWindows"/></returns>
        public static Org.Apache.Kafka.Streams.Kstream.JoinWindows OfTimeDifferenceAndGrace(Java.Time.Duration arg0, Java.Time.Duration arg1)
        {
            return SExecute<Org.Apache.Kafka.Streams.Kstream.JoinWindows>(LocalBridgeClazz, "ofTimeDifferenceAndGrace", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/JoinWindows.html#ofTimeDifferenceWithNoGrace-java.time.Duration-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Time.Duration"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.JoinWindows"/></returns>
        public static Org.Apache.Kafka.Streams.Kstream.JoinWindows OfTimeDifferenceWithNoGrace(Java.Time.Duration arg0)
        {
            return SExecuteWithSignature<Org.Apache.Kafka.Streams.Kstream.JoinWindows>(LocalBridgeClazz, "ofTimeDifferenceWithNoGrace", "(Ljava/time/Duration;)Lorg/apache/kafka/streams/kstream/JoinWindows;", arg0);
        }

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/JoinWindows.html#after-java.time.Duration-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Time.Duration"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.JoinWindows"/></returns>
        /// <exception cref="Java.Lang.IllegalArgumentException"/>
        public Org.Apache.Kafka.Streams.Kstream.JoinWindows After(Java.Time.Duration arg0)
        {
            return IExecuteWithSignature<Org.Apache.Kafka.Streams.Kstream.JoinWindows>("after", "(Ljava/time/Duration;)Lorg/apache/kafka/streams/kstream/JoinWindows;", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/JoinWindows.html#before-java.time.Duration-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Time.Duration"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.JoinWindows"/></returns>
        /// <exception cref="Java.Lang.IllegalArgumentException"/>
        public Org.Apache.Kafka.Streams.Kstream.JoinWindows Before(Java.Time.Duration arg0)
        {
            return IExecuteWithSignature<Org.Apache.Kafka.Streams.Kstream.JoinWindows>("before", "(Ljava/time/Duration;)Lorg/apache/kafka/streams/kstream/JoinWindows;", arg0);
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}