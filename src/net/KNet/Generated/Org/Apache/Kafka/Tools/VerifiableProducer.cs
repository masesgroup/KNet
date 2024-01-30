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
*  using kafka-tools-3.6.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Tools
{
    #region VerifiableProducer
    public partial class VerifiableProducer
    {
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-tools/3.6.1/org/apache/kafka/tools/VerifiableProducer.html#org.apache.kafka.tools.VerifiableProducer(org.apache.kafka.clients.producer.KafkaProducer,java.lang.String,int,int,java.lang.Integer,java.lang.Long,java.lang.Integer)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Clients.Producer.KafkaProducer"/></param>
        /// <param name="arg1"><see cref="string"/></param>
        /// <param name="arg2"><see cref="int"/></param>
        /// <param name="arg3"><see cref="int"/></param>
        /// <param name="arg4"><see cref="Java.Lang.Integer"/></param>
        /// <param name="arg5"><see cref="Java.Lang.Long"/></param>
        /// <param name="arg6"><see cref="Java.Lang.Integer"/></param>
        public VerifiableProducer(Org.Apache.Kafka.Clients.Producer.KafkaProducer<string, string> arg0, string arg1, int arg2, int arg3, Java.Lang.Integer arg4, Java.Lang.Long arg5, Java.Lang.Integer arg6)
            : base(arg0, arg1, arg2, arg3, arg4, arg5, arg6)
        {
        }

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-tools/3.6.1/org/apache/kafka/tools/VerifiableProducer.html#loadProps-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="Java.Util.Properties"/></returns>
        /// <exception cref="Java.Io.IOException"/>
        public static Java.Util.Properties LoadProps(string arg0)
        {
            return SExecute<Java.Util.Properties>(LocalBridgeClazz, "loadProps", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-tools/3.6.1/org/apache/kafka/tools/VerifiableProducer.html#main-java.lang.String[]-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        public static void Main(string[] arg0)
        {
            SExecute(LocalBridgeClazz, "main", new object[] { arg0 });
        }

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-tools/3.6.1/org/apache/kafka/tools/VerifiableProducer.html#getKey--"/> 
        /// </summary>
        public string Key
        {
            get { return IExecute<string>("getKey"); }
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-tools/3.6.1/org/apache/kafka/tools/VerifiableProducer.html#getValue-long-"/>
        /// </summary>
        /// <param name="arg0"><see cref="long"/></param>
        /// <returns><see cref="string"/></returns>
        public string GetValue(long arg0)
        {
            return IExecute<string>("getValue", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-tools/3.6.1/org/apache/kafka/tools/VerifiableProducer.html#close--"/>
        /// </summary>
        public void Close()
        {
            IExecute("close");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-tools/3.6.1/org/apache/kafka/tools/VerifiableProducer.html#send-java.lang.String-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="string"/></param>
        public void Send(string arg0, string arg1)
        {
            IExecute("send", arg0, arg1);
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}