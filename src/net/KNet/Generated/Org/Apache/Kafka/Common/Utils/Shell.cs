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
    #region Shell
    public partial class Shell
    {
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/Shell.html#org.apache.kafka.common.utils.Shell(long)"/>
        /// </summary>
        /// <param name="arg0"><see cref="long"/></param>
        public Shell(long arg0)
            : base(arg0)
        {
        }

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/Shell.html#execCommand-java.lang.String[]-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.String"/></param>
        /// <returns><see cref="Java.Lang.String"/></returns>
        /// <exception cref="Java.Io.IOException"/>
        public static Java.Lang.String ExecCommand(params Java.Lang.String[] arg0)
        {
            if (arg0.Length == 0) return SExecuteWithSignature<Java.Lang.String>(LocalBridgeClazz, "execCommand", "([Ljava/lang/String;)Ljava/lang/String;"); else return SExecuteWithSignature<Java.Lang.String>(LocalBridgeClazz, "execCommand", "([Ljava/lang/String;)Ljava/lang/String;", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/Shell.html#execCommand-java.lang.String[]-long-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.String"/></param>
        /// <param name="arg1"><see cref="long"/></param>
        /// <returns><see cref="Java.Lang.String"/></returns>
        /// <exception cref="Java.Io.IOException"/>
        public static Java.Lang.String ExecCommand(Java.Lang.String[] arg0, long arg1)
        {
            return SExecute<Java.Lang.String>(LocalBridgeClazz, "execCommand", arg0, arg1);
        }

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/Shell.html#exitCode--"/>
        /// </summary>

        /// <returns><see cref="int"/></returns>
        public int ExitCode()
        {
            return IExecuteWithSignature<int>("exitCode", "()I");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/Shell.html#process--"/>
        /// </summary>

        /// <returns><see cref="Java.Lang.Process"/></returns>
        public Java.Lang.Process Process()
        {
            return IExecuteWithSignature<Java.Lang.Process>("process", "()Ljava/lang/Process;");
        }

        #endregion

        #region Nested classes
        #region ExitCodeException
        public partial class ExitCodeException
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

            #endregion

            #region Nested classes

            #endregion

            // TODO: complete the class
        }
        #endregion

        #region ShellCommandExecutor
        public partial class ShellCommandExecutor
        {
            #region Constructors
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/Shell.ShellCommandExecutor.html#org.apache.kafka.common.utils.Shell$ShellCommandExecutor(java.lang.String[],long)"/>
            /// </summary>
            /// <param name="arg0"><see cref="Java.Lang.String"/></param>
            /// <param name="arg1"><see cref="long"/></param>
            public ShellCommandExecutor(Java.Lang.String[] arg0, long arg1)
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
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/Shell.ShellCommandExecutor.html#output--"/>
            /// </summary>

            /// <returns><see cref="Java.Lang.String"/></returns>
            public Java.Lang.String Output()
            {
                return IExecuteWithSignature<Java.Lang.String>("output", "()Ljava/lang/String;");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/utils/Shell.ShellCommandExecutor.html#execute--"/>
            /// </summary>

            /// <exception cref="Java.Io.IOException"/>
            public void Execute()
            {
                IExecuteWithSignature("execute", "()V");
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