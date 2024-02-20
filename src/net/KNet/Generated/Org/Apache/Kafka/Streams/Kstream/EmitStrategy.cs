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
*  This file is generated by MASES.JNetReflector (ver. 2.2.5.0)
*  using kafka-streams-3.6.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Streams.Kstream
{
    #region IEmitStrategy
    /// <summary>
    /// .NET interface for TO BE DEFINED FROM USER
    /// </summary>
    public partial interface IEmitStrategy
    {
        #region Instance methods

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion

    #region EmitStrategy
    public partial class EmitStrategy : Org.Apache.Kafka.Streams.Kstream.IEmitStrategy
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/EmitStrategy.html#onWindowClose--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.EmitStrategy"/></returns>
        public static Org.Apache.Kafka.Streams.Kstream.EmitStrategy OnWindowClose()
        {
            return SExecute<Org.Apache.Kafka.Streams.Kstream.EmitStrategy>(LocalBridgeClazz, "onWindowClose");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/EmitStrategy.html#onWindowUpdate--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.EmitStrategy"/></returns>
        public static Org.Apache.Kafka.Streams.Kstream.EmitStrategy OnWindowUpdate()
        {
            return SExecute<Org.Apache.Kafka.Streams.Kstream.EmitStrategy>(LocalBridgeClazz, "onWindowUpdate");
        }

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/EmitStrategy.html#type--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.EmitStrategy.StrategyType"/></returns>
        public Org.Apache.Kafka.Streams.Kstream.EmitStrategy.StrategyType Type()
        {
            return IExecute<Org.Apache.Kafka.Streams.Kstream.EmitStrategy.StrategyType>("type");
        }

        #endregion

        #region Nested classes
        #region StrategyType
        public partial class StrategyType
        {
            #region Constructors

            #endregion

            #region Class/Interface conversion operators

            #endregion

            #region Fields
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/EmitStrategy.StrategyType.html#ON_WINDOW_CLOSE"/>
            /// </summary>
            public static Org.Apache.Kafka.Streams.Kstream.EmitStrategy.StrategyType ON_WINDOW_CLOSE { get { if (!_ON_WINDOW_CLOSEReady) { _ON_WINDOW_CLOSEContent = SGetField<Org.Apache.Kafka.Streams.Kstream.EmitStrategy.StrategyType>(LocalBridgeClazz, "ON_WINDOW_CLOSE"); _ON_WINDOW_CLOSEReady = true; } return _ON_WINDOW_CLOSEContent; } }
            private static Org.Apache.Kafka.Streams.Kstream.EmitStrategy.StrategyType _ON_WINDOW_CLOSEContent = default;
            private static bool _ON_WINDOW_CLOSEReady = false; // this is used because in case of generics 
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/EmitStrategy.StrategyType.html#ON_WINDOW_UPDATE"/>
            /// </summary>
            public static Org.Apache.Kafka.Streams.Kstream.EmitStrategy.StrategyType ON_WINDOW_UPDATE { get { if (!_ON_WINDOW_UPDATEReady) { _ON_WINDOW_UPDATEContent = SGetField<Org.Apache.Kafka.Streams.Kstream.EmitStrategy.StrategyType>(LocalBridgeClazz, "ON_WINDOW_UPDATE"); _ON_WINDOW_UPDATEReady = true; } return _ON_WINDOW_UPDATEContent; } }
            private static Org.Apache.Kafka.Streams.Kstream.EmitStrategy.StrategyType _ON_WINDOW_UPDATEContent = default;
            private static bool _ON_WINDOW_UPDATEReady = false; // this is used because in case of generics 

            #endregion

            #region Static methods
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/EmitStrategy.StrategyType.html#forType-org.apache.kafka.streams.kstream.EmitStrategy.StrategyType-"/>
            /// </summary>
            /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.EmitStrategy.StrategyType"/></param>
            /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.EmitStrategy"/></returns>
            public static Org.Apache.Kafka.Streams.Kstream.EmitStrategy ForType(Org.Apache.Kafka.Streams.Kstream.EmitStrategy.StrategyType arg0)
            {
                return SExecute<Org.Apache.Kafka.Streams.Kstream.EmitStrategy>(LocalBridgeClazz, "forType", arg0);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/EmitStrategy.StrategyType.html#valueOf-java.lang.String-"/>
            /// </summary>
            /// <param name="arg0"><see cref="Java.Lang.String"/></param>
            /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.EmitStrategy.StrategyType"/></returns>
            public static Org.Apache.Kafka.Streams.Kstream.EmitStrategy.StrategyType ValueOf(Java.Lang.String arg0)
            {
                return SExecute<Org.Apache.Kafka.Streams.Kstream.EmitStrategy.StrategyType>(LocalBridgeClazz, "valueOf", arg0);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/EmitStrategy.StrategyType.html#values--"/>
            /// </summary>

            /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.EmitStrategy.StrategyType"/></returns>
            public static Org.Apache.Kafka.Streams.Kstream.EmitStrategy.StrategyType[] Values()
            {
                return SExecuteArray<Org.Apache.Kafka.Streams.Kstream.EmitStrategy.StrategyType>(LocalBridgeClazz, "values");
            }

            #endregion

            #region Instance methods

            #endregion

            #region Nested classes

            #endregion

            // TODO: complete the class
        }
        #endregion

    
        #endregion

        // TODO: complete the class
    }
    #endregion
}