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
*  This file is generated by MASES.JNetReflector (ver. 2.1.0.0)
*  using kafka-clients-3.6.0.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Common.Utils
{
    #region Exit
    public partial class Exit
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/common/utils/Exit.html#addShutdownHook-java.lang.String-java.lang.Runnable-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="Java.Lang.Runnable"/></param>
        public static void AddShutdownHook(string arg0, Java.Lang.Runnable arg1)
        {
            SExecute(LocalBridgeClazz, "addShutdownHook", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/common/utils/Exit.html#exit-int-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="int"/></param>
        /// <param name="arg1"><see cref="string"/></param>
        public static void ExitMethod(int arg0, string arg1)
        {
            SExecute(LocalBridgeClazz, "exit", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/common/utils/Exit.html#exit-int-"/>
        /// </summary>
        /// <param name="arg0"><see cref="int"/></param>
        public static void ExitMethod(int arg0)
        {
            SExecute(LocalBridgeClazz, "exit", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/common/utils/Exit.html#halt-int-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="int"/></param>
        /// <param name="arg1"><see cref="string"/></param>
        public static void Halt(int arg0, string arg1)
        {
            SExecute(LocalBridgeClazz, "halt", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/common/utils/Exit.html#halt-int-"/>
        /// </summary>
        /// <param name="arg0"><see cref="int"/></param>
        public static void Halt(int arg0)
        {
            SExecute(LocalBridgeClazz, "halt", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/common/utils/Exit.html#resetExitProcedure--"/>
        /// </summary>
        public static void ResetExitProcedure()
        {
            SExecute(LocalBridgeClazz, "resetExitProcedure");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/common/utils/Exit.html#resetHaltProcedure--"/>
        /// </summary>
        public static void ResetHaltProcedure()
        {
            SExecute(LocalBridgeClazz, "resetHaltProcedure");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/common/utils/Exit.html#resetShutdownHookAdder--"/>
        /// </summary>
        public static void ResetShutdownHookAdder()
        {
            SExecute(LocalBridgeClazz, "resetShutdownHookAdder");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/common/utils/Exit.html#setExitProcedure-org.apache.kafka.common.utils.Exit.Procedure-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Utils.Exit.Procedure"/></param>
        public static void SetExitProcedure(Org.Apache.Kafka.Common.Utils.Exit.Procedure arg0)
        {
            SExecute(LocalBridgeClazz, "setExitProcedure", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/common/utils/Exit.html#setHaltProcedure-org.apache.kafka.common.utils.Exit.Procedure-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Utils.Exit.Procedure"/></param>
        public static void SetHaltProcedure(Org.Apache.Kafka.Common.Utils.Exit.Procedure arg0)
        {
            SExecute(LocalBridgeClazz, "setHaltProcedure", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/common/utils/Exit.html#setShutdownHookAdder-org.apache.kafka.common.utils.Exit.ShutdownHookAdder-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Utils.Exit.ShutdownHookAdder"/></param>
        public static void SetShutdownHookAdder(Org.Apache.Kafka.Common.Utils.Exit.ShutdownHookAdder arg0)
        {
            SExecute(LocalBridgeClazz, "setShutdownHookAdder", arg0);
        }

        #endregion

        #region Instance methods

        #endregion

        #region Nested classes
        #region Procedure
        public partial class Procedure
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
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/common/utils/Exit.Procedure.html#execute-int-java.lang.String-"/>
            /// </summary>
            /// <param name="arg0"><see cref="int"/></param>
            /// <param name="arg1"><see cref="string"/></param>
            public void Execute(int arg0, string arg1)
            {
                IExecute("execute", arg0, arg1);
            }

            #endregion

            #region Nested classes

            #endregion

            // TODO: complete the class
        }
        #endregion

        #region ShutdownHookAdder
        public partial class ShutdownHookAdder
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
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/common/utils/Exit.ShutdownHookAdder.html#addShutdownHook-java.lang.String-java.lang.Runnable-"/>
            /// </summary>
            /// <param name="arg0"><see cref="string"/></param>
            /// <param name="arg1"><see cref="Java.Lang.Runnable"/></param>
            public void AddShutdownHook(string arg0, Java.Lang.Runnable arg1)
            {
                IExecute("addShutdownHook", arg0, arg1);
            }

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