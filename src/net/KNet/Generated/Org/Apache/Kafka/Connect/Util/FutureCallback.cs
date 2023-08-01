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
*  using connect-runtime-3.5.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Connect.Util
{
    #region FutureCallback
    public partial class FutureCallback
    {
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-runtime/3.5.1/org/apache/kafka/connect/util/FutureCallback.html#org.apache.kafka.connect.util.FutureCallback(org.apache.kafka.connect.util.Callback)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Connect.Util.Callback"/></param>
        public FutureCallback(Org.Apache.Kafka.Connect.Util.Callback arg0)
            : base(arg0)
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

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion

    #region FutureCallback<T>
    public partial class FutureCallback<T>
    {
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-runtime/3.5.1/org/apache/kafka/connect/util/FutureCallback.html#org.apache.kafka.connect.util.FutureCallback(org.apache.kafka.connect.util.Callback)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Connect.Util.Callback"/></param>
        public FutureCallback(Org.Apache.Kafka.Connect.Util.Callback<T> arg0)
            : base(arg0)
        {
        }

        #endregion

        #region Class/Interface conversion operators
        /// <summary>
        /// Converter from <see cref="Org.Apache.Kafka.Connect.Util.FutureCallback{T}"/> to <see cref="Org.Apache.Kafka.Connect.Util.FutureCallback"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Connect.Util.FutureCallback(Org.Apache.Kafka.Connect.Util.FutureCallback<T> t) => t.Cast<Org.Apache.Kafka.Connect.Util.FutureCallback>();

        #endregion

        #region Fields

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
}