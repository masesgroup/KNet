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

namespace Org.Apache.Kafka.Common.Network
{
    #region TransportLayer
    public partial class TransportLayer
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators
        /// <summary>
        /// Converter from <see cref="Org.Apache.Kafka.Common.Network.TransportLayer"/> to <see cref="Java.Nio.Channels.ScatteringByteChannel"/>
        /// </summary>
        public static implicit operator Java.Nio.Channels.ScatteringByteChannel(Org.Apache.Kafka.Common.Network.TransportLayer t) => t.Cast<Java.Nio.Channels.ScatteringByteChannel>();
        /// <summary>
        /// Converter from <see cref="Org.Apache.Kafka.Common.Network.TransportLayer"/> to <see cref="Org.Apache.Kafka.Common.Network.TransferableChannel"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Common.Network.TransferableChannel(Org.Apache.Kafka.Common.Network.TransportLayer t) => t.Cast<Org.Apache.Kafka.Common.Network.TransferableChannel>();

        #endregion

        #region Fields

        #endregion

        #region Static methods

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/network/TransportLayer.html#finishConnect()"/>
        /// </summary>

        /// <returns><see cref="bool"/></returns>
        /// <exception cref="Java.Io.IOException"/>
        public bool FinishConnect()
        {
            return IExecute<bool>("finishConnect");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/network/TransportLayer.html#hasBytesBuffered()"/>
        /// </summary>

        /// <returns><see cref="bool"/></returns>
        public bool HasBytesBuffered()
        {
            return IExecute<bool>("hasBytesBuffered");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/network/TransportLayer.html#isConnected()"/>
        /// </summary>

        /// <returns><see cref="bool"/></returns>
        public bool IsConnected()
        {
            return IExecute<bool>("isConnected");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/network/TransportLayer.html#isMute()"/>
        /// </summary>

        /// <returns><see cref="bool"/></returns>
        public bool IsMute()
        {
            return IExecute<bool>("isMute");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/network/TransportLayer.html#ready()"/>
        /// </summary>

        /// <returns><see cref="bool"/></returns>
        public bool Ready()
        {
            return IExecute<bool>("ready");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/network/TransportLayer.html#selectionKey()"/>
        /// </summary>

        /// <returns><see cref="Java.Nio.Channels.SelectionKey"/></returns>
        public Java.Nio.Channels.SelectionKey SelectionKey()
        {
            return IExecute<Java.Nio.Channels.SelectionKey>("selectionKey");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/network/TransportLayer.html#socketChannel()"/>
        /// </summary>

        /// <returns><see cref="Java.Nio.Channels.SocketChannel"/></returns>
        public Java.Nio.Channels.SocketChannel SocketChannel()
        {
            return IExecute<Java.Nio.Channels.SocketChannel>("socketChannel");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/network/TransportLayer.html#peerPrincipal()"/>
        /// </summary>

        /// <returns><see cref="Java.Security.Principal"/></returns>
        /// <exception cref="Java.Io.IOException"/>
        public Java.Security.Principal PeerPrincipal()
        {
            return IExecute<Java.Security.Principal>("peerPrincipal");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/network/TransportLayer.html#addInterestOps(int)"/>
        /// </summary>
        /// <param name="arg0"><see cref="int"/></param>
        public void AddInterestOps(int arg0)
        {
            IExecute("addInterestOps", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/network/TransportLayer.html#disconnect()"/>
        /// </summary>
        public void Disconnect()
        {
            IExecute("disconnect");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/network/TransportLayer.html#handshake()"/>
        /// </summary>

        /// <exception cref="Org.Apache.Kafka.Common.Errors.AuthenticationException"/>
        /// <exception cref="Java.Io.IOException"/>
        public void Handshake()
        {
            IExecute("handshake");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/network/TransportLayer.html#removeInterestOps(int)"/>
        /// </summary>
        /// <param name="arg0"><see cref="int"/></param>
        public void RemoveInterestOps(int arg0)
        {
            IExecute("removeInterestOps", arg0);
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}