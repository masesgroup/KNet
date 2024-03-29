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
*  using connect-api-3.6.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Connect.Source
{
    #region ITransactionContext
    /// <summary>
    /// .NET interface for TO BE DEFINED FROM USER
    /// </summary>
    public partial interface ITransactionContext
    {
        #region Instance methods

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion

    #region TransactionContext
    public partial class TransactionContext : Org.Apache.Kafka.Connect.Source.ITransactionContext
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
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.6.1/org/apache/kafka/connect/source/TransactionContext.html#abortTransaction--"/>
        /// </summary>
        public void AbortTransaction()
        {
            IExecuteWithSignature("abortTransaction", "()V");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.6.1/org/apache/kafka/connect/source/TransactionContext.html#abortTransaction-org.apache.kafka.connect.source.SourceRecord-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Connect.Source.SourceRecord"/></param>
        public void AbortTransaction(Org.Apache.Kafka.Connect.Source.SourceRecord arg0)
        {
            IExecuteWithSignature("abortTransaction", "(Lorg/apache/kafka/connect/source/SourceRecord;)V", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.6.1/org/apache/kafka/connect/source/TransactionContext.html#commitTransaction--"/>
        /// </summary>
        public void CommitTransaction()
        {
            IExecuteWithSignature("commitTransaction", "()V");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.6.1/org/apache/kafka/connect/source/TransactionContext.html#commitTransaction-org.apache.kafka.connect.source.SourceRecord-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Connect.Source.SourceRecord"/></param>
        public void CommitTransaction(Org.Apache.Kafka.Connect.Source.SourceRecord arg0)
        {
            IExecuteWithSignature("commitTransaction", "(Lorg/apache/kafka/connect/source/SourceRecord;)V", arg0);
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}