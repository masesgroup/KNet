/*
*  Copyright 2021 MASES s.r.l.
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

using System.Collections.Generic;

namespace MASES.KafkaBridge
{
    public static class KafkaBridgeCoreExtensions
    {
        /// <summary>
        /// Filters arguments related to JCOBridge
        /// </summary>
        /// <param name="args">The argument to filter</param>
        /// <returns>The filtered arguments</returns>
        public static T[] FilterJCOBridgeArguments<T>(this T[] args)
        {
            var argumentsToAnalyze = new List<T>(args);
            foreach (var argument in argumentsToAnalyze.ToArray())
            {
                string item = argument as string;

                if (item == null) continue;

                if (item.ToLowerInvariant().StartsWith(InternalConst.JCOBridgeLicensePathString.ToLowerInvariant()))
                {
                    argumentsToAnalyze.Remove(argument);
                }
                else if (item.ToLowerInvariant().StartsWith(InternalConst.JCOBridgeHelpString.ToLowerInvariant()))
                {
                    argumentsToAnalyze.Remove(argument);
                }
                else if (item.ToLowerInvariant().StartsWith(InternalConst.JDKHomeString.ToLowerInvariant()))
                {
                    argumentsToAnalyze.Remove(argument);
                }
                else if (item.ToLowerInvariant().StartsWith(InternalConst.JVMPathString.ToLowerInvariant()))
                {
                    argumentsToAnalyze.Remove(argument);
                }
                else if (item.ToLowerInvariant().StartsWith(InternalConst.ClassPathString.ToLowerInvariant()))
                {
                    argumentsToAnalyze.Remove(argument);
                }
                else if (item.ToLowerInvariant().StartsWith(InternalConst.JNIVerbosityString.ToLowerInvariant()))
                {
                    argumentsToAnalyze.Remove(argument);
                }
                else if (item.ToLowerInvariant().StartsWith(InternalConst.JNIOutputFileString.ToLowerInvariant()))
                {
                    argumentsToAnalyze.Remove(argument);
                }
                else if (item.ToLowerInvariant().StartsWith(InternalConst.JVMPackagesString.ToLowerInvariant()))
                {
                    argumentsToAnalyze.Remove(argument);
                }
                else if (item.ToLowerInvariant().StartsWith(InternalConst.JVMKVOptionString.ToLowerInvariant()))
                {
                    argumentsToAnalyze.Remove(argument);
                }
                else if (item.ToLowerInvariant().StartsWith(InternalConst.JVMOptionString.ToLowerInvariant()))
                {
                    argumentsToAnalyze.Remove(argument);
                }
            }

            return argumentsToAnalyze.ToArray();
        }
    }
}
