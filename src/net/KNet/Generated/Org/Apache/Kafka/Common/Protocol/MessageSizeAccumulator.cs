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
*  This file is generated by MASES.JNetReflector (ver. 1.5.5.0)
*  using kafka-clients-3.4.0.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Common.Protocol
{
    #region MessageSizeAccumulator
    public partial class MessageSizeAccumulator
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
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/protocol/MessageSizeAccumulator.html#sizeExcludingZeroCopy()"/>
        /// </summary>

        /// <returns><see cref="int"/></returns>
        public int SizeExcludingZeroCopy()
        {
            return IExecute<int>("sizeExcludingZeroCopy");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/protocol/MessageSizeAccumulator.html#totalSize()"/>
        /// </summary>

        /// <returns><see cref="int"/></returns>
        public int TotalSize()
        {
            return IExecute<int>("totalSize");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/protocol/MessageSizeAccumulator.html#zeroCopySize()"/>
        /// </summary>

        /// <returns><see cref="int"/></returns>
        public int ZeroCopySize()
        {
            return IExecute<int>("zeroCopySize");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/protocol/MessageSizeAccumulator.html#add(org.apache.kafka.common.protocol.MessageSizeAccumulator)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Protocol.MessageSizeAccumulator"/></param>
        public void Add(Org.Apache.Kafka.Common.Protocol.MessageSizeAccumulator arg0)
        {
            IExecute("add", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/protocol/MessageSizeAccumulator.html#addBytes(int)"/>
        /// </summary>
        /// <param name="arg0"><see cref="int"/></param>
        public void AddBytes(int arg0)
        {
            IExecute("addBytes", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/protocol/MessageSizeAccumulator.html#addZeroCopyBytes(int)"/>
        /// </summary>
        /// <param name="arg0"><see cref="int"/></param>
        public void AddZeroCopyBytes(int arg0)
        {
            IExecute("addZeroCopyBytes", arg0);
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}