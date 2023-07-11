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
*  using kafka-clients-3.5.0.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Common.Utils
{
    #region PrimitiveRef
    public partial class PrimitiveRef
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/utils/PrimitiveRef.html#ofInt-int-"/>
        /// </summary>
        /// <param name="arg0"><see cref="int"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Common.Utils.PrimitiveRef.IntRef"/></returns>
        public static Org.Apache.Kafka.Common.Utils.PrimitiveRef.IntRef OfInt(int arg0)
        {
            return SExecute<Org.Apache.Kafka.Common.Utils.PrimitiveRef.IntRef>(LocalBridgeClazz, "ofInt", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/utils/PrimitiveRef.html#ofLong-long-"/>
        /// </summary>
        /// <param name="arg0"><see cref="long"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Common.Utils.PrimitiveRef.LongRef"/></returns>
        public static Org.Apache.Kafka.Common.Utils.PrimitiveRef.LongRef OfLong(long arg0)
        {
            return SExecute<Org.Apache.Kafka.Common.Utils.PrimitiveRef.LongRef>(LocalBridgeClazz, "ofLong", arg0);
        }

        #endregion

        #region Instance methods

        #endregion

        #region Nested classes
        #region IntRef
        public partial class IntRef
        {
            #region Constructors

            #endregion

            #region Class/Interface conversion operators

            #endregion

            #region Fields
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/utils/PrimitiveRef.IntRef.html#value"/>
            /// </summary>
            public int value { get { return IGetField<int>("value"); } set { ISetField("value", value); } }

            #endregion

            #region Static methods

            #endregion

            #region Instance methods

            #endregion

            #region Nested classes

            #endregion

            // TODO: complete the class
        }
        #endregion

        #region LongRef
        public partial class LongRef
        {
            #region Constructors

            #endregion

            #region Class/Interface conversion operators

            #endregion

            #region Fields
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/utils/PrimitiveRef.LongRef.html#value"/>
            /// </summary>
            public long value { get { return IGetField<long>("value"); } set { ISetField("value", value); } }

            #endregion

            #region Static methods

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