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
    #region CloseableIterator
    public partial class CloseableIterator
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators
        /// <summary>
        /// Converter from <see cref="Org.Apache.Kafka.Common.Utils.CloseableIterator"/> to <see cref="Java.Io.Closeable"/>
        /// </summary>
        public static implicit operator Java.Io.Closeable(Org.Apache.Kafka.Common.Utils.CloseableIterator t) => t.Cast<Java.Io.Closeable>();

        #endregion

        #region Fields

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/CloseableIterator.html#wrap-java.util.Iterator-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.Iterator"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Common.Utils.CloseableIterator"/></returns>
        public static Org.Apache.Kafka.Common.Utils.CloseableIterator Wrap(Java.Util.Iterator arg0)
        {
            return SExecuteWithSignature<Org.Apache.Kafka.Common.Utils.CloseableIterator>(LocalBridgeClazz, "wrap", "(Ljava/util/Iterator;)Lorg/apache/kafka/common/utils/CloseableIterator;", arg0);
        }

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/CloseableIterator.html#close--"/>
        /// </summary>
        public void Close()
        {
            IExecuteWithSignature("close", "()V");
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion

    #region ICloseableIterator<T>
    /// <summary>
    /// .NET interface for TO BE DEFINED FROM USER
    /// </summary>
    public partial interface ICloseableIterator<T>
    {
        #region Instance methods

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion

    #region CloseableIterator<T>
    public partial class CloseableIterator<T> : Org.Apache.Kafka.Common.Utils.ICloseableIterator<T>, Java.Util.IIterator<T>, Java.Io.ICloseable
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators
        /// <summary>
        /// Converter from <see cref="Org.Apache.Kafka.Common.Utils.CloseableIterator{T}"/> to <see cref="Java.Io.Closeable"/>
        /// </summary>
        public static implicit operator Java.Io.Closeable(Org.Apache.Kafka.Common.Utils.CloseableIterator<T> t) => t.Cast<Java.Io.Closeable>();
        /// <summary>
        /// Converter from <see cref="Org.Apache.Kafka.Common.Utils.CloseableIterator{T}"/> to <see cref="Org.Apache.Kafka.Common.Utils.CloseableIterator"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Common.Utils.CloseableIterator(Org.Apache.Kafka.Common.Utils.CloseableIterator<T> t) => t.Cast<Org.Apache.Kafka.Common.Utils.CloseableIterator>();

        #endregion

        #region Fields

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/CloseableIterator.html#wrap-java.util.Iterator-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.Iterator"/></param>
        /// <typeparam name="R"></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Common.Utils.CloseableIterator"/></returns>
        public static Org.Apache.Kafka.Common.Utils.CloseableIterator<R> Wrap<R>(Java.Util.Iterator<R> arg0)
        {
            return SExecuteWithSignature<Org.Apache.Kafka.Common.Utils.CloseableIterator<R>>(LocalBridgeClazz, "wrap", "(Ljava/util/Iterator;)Lorg/apache/kafka/common/utils/CloseableIterator;", arg0);
        }

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/CloseableIterator.html#close--"/>
        /// </summary>
        public void Close()
        {
            IExecuteWithSignature("close", "()V");
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}