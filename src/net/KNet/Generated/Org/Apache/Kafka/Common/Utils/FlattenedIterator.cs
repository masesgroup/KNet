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
*  This file is generated by MASES.JNetReflector (ver. 2.1.1.0)
*  using kafka-clients-3.6.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Common.Utils
{
    #region FlattenedIterator
    public partial class FlattenedIterator
    {
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/FlattenedIterator.html#org.apache.kafka.common.utils.FlattenedIterator(java.util.Iterator,java.util.function.Function)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.Iterator"/></param>
        /// <param name="arg1"><see cref="Java.Util.Function.Function"/></param>
        public FlattenedIterator(Java.Util.Iterator arg0, Java.Util.Function.Function arg1)
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
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/FlattenedIterator.html#makeNext--"/>
        /// </summary>

        /// <returns><see cref="object"/></returns>
        public object MakeNext()
        {
            return IExecute("makeNext");
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion

    #region FlattenedIterator<O, I>
    public partial class FlattenedIterator<O, I>
    {
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/FlattenedIterator.html#org.apache.kafka.common.utils.FlattenedIterator(java.util.Iterator,java.util.function.Function)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.Iterator"/></param>
        /// <param name="arg1"><see cref="Java.Util.Function.Function"/></param>
        public FlattenedIterator(Java.Util.Iterator<O> arg0, Java.Util.Function.Function<O, Java.Util.Iterator<I>> arg1)
            : base(arg0, arg1)
        {
        }

        #endregion

        #region Class/Interface conversion operators
        /// <summary>
        /// Converter from <see cref="Org.Apache.Kafka.Common.Utils.FlattenedIterator{O, I}"/> to <see cref="Org.Apache.Kafka.Common.Utils.FlattenedIterator"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Common.Utils.FlattenedIterator(Org.Apache.Kafka.Common.Utils.FlattenedIterator<O, I> t) => t.Cast<Org.Apache.Kafka.Common.Utils.FlattenedIterator>();

        #endregion

        #region Fields

        #endregion

        #region Static methods

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/FlattenedIterator.html#makeNext--"/>
        /// </summary>

        /// <returns><typeparamref name="I"/></returns>
        public I MakeNext()
        {
            return IExecute<I>("makeNext");
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}