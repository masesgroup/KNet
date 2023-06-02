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

namespace Org.Apache.Kafka.Common.Utils
{
    #region Shell
    public partial class Shell
    {
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/utils/Shell.html#%3Cinit%3E(long)"/>
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
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/utils/Shell.html#execCommand(java.lang.String[])"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="string"/></returns>
        /// <exception cref="Java.Io.IOException"/>
        public static string ExecCommand(params string[] arg0)
        {
            if (arg0.Length == 0) return SExecute<string>(LocalBridgeClazz, "execCommand"); else return SExecute<string>(LocalBridgeClazz, "execCommand", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/utils/Shell.html#execCommand(java.lang.String[],long)"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="long"/></param>
        /// <returns><see cref="string"/></returns>
        /// <exception cref="Java.Io.IOException"/>
        public static string ExecCommand(string[] arg0, long arg1)
        {
            return SExecute<string>(LocalBridgeClazz, "execCommand", arg0, arg1);
        }

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/utils/Shell.html#exitCode()"/>
        /// </summary>

        /// <returns><see cref="int"/></returns>
        public int ExitCode()
        {
            return IExecute<int>("exitCode");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/utils/Shell.html#process()"/>
        /// </summary>

        /// <returns><see cref="Java.Lang.Process"/></returns>
        public Java.Lang.Process Process()
        {
            return IExecute<Java.Lang.Process>("process");
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
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/utils/Shell.ShellCommandExecutor.html#%3Cinit%3E(java.lang.String[],long)"/>
            /// </summary>
            /// <param name="arg0"><see cref="string"/></param>
            /// <param name="arg1"><see cref="long"/></param>
            public ShellCommandExecutor(string[] arg0, long arg1)
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
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/utils/Shell.ShellCommandExecutor.html#output()"/>
            /// </summary>

            /// <returns><see cref="string"/></returns>
            public string Output()
            {
                return IExecute<string>("output");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/utils/Shell.ShellCommandExecutor.html#execute()"/>
            /// </summary>

            /// <exception cref="Java.Io.IOException"/>
            public void Execute()
            {
                IExecute("execute");
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