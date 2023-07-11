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
    #region AbstractIterator
    public partial class AbstractIterator
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
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/utils/AbstractIterator.html#hasNext--"/>
        /// </summary>

        /// <returns><see cref="bool"/></returns>
        public bool HasNext()
        {
            return IExecute<bool>("hasNext");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/utils/AbstractIterator.html#next--"/>
        /// </summary>

        /// <returns><see cref="object"/></returns>
        public object Next()
        {
            return IExecute("next");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/utils/AbstractIterator.html#peek--"/>
        /// </summary>

        /// <returns><see cref="object"/></returns>
        public object Peek()
        {
            return IExecute("peek");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/utils/AbstractIterator.html#remove--"/>
        /// </summary>
        public void Remove()
        {
            IExecute("remove");
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion

    #region AbstractIterator<T>
    public partial class AbstractIterator<T>
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators
        /// <summary>
        /// Converter from <see cref="Org.Apache.Kafka.Common.Utils.AbstractIterator{T}"/> to <see cref="Org.Apache.Kafka.Common.Utils.AbstractIterator"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Common.Utils.AbstractIterator(Org.Apache.Kafka.Common.Utils.AbstractIterator<T> t) => t.Cast<Org.Apache.Kafka.Common.Utils.AbstractIterator>();

        #endregion

        #region Fields

        #endregion

        #region Static methods

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/utils/AbstractIterator.html#hasNext--"/>
        /// </summary>

        /// <returns><see cref="bool"/></returns>
        public bool HasNext()
        {
            return IExecute<bool>("hasNext");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/utils/AbstractIterator.html#next--"/>
        /// </summary>

        /// <returns><typeparamref name="T"/></returns>
        public T Next()
        {
            return IExecute<T>("next");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/utils/AbstractIterator.html#peek--"/>
        /// </summary>

        /// <returns><typeparamref name="T"/></returns>
        public T Peek()
        {
            return IExecute<T>("peek");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/utils/AbstractIterator.html#remove--"/>
        /// </summary>
        public void Remove()
        {
            IExecute("remove");
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}