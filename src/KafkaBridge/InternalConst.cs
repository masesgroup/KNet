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

using System;

namespace MASES.KafkaBridge
{
    class InternalConst
    {
        public const string JCOBridgeLicensePathString = "--LicensePath";
        public const string JCOBridgeHelpString = "--JCOBridgeHelp";
        public const string JDKHomeString = "--JDKHome:";
        public const string JVMPathString = "--JVMPath:";
        public const string ClassPathString = "--JVMClassPath:";
        public const string JNIVerbosityString = "--JNIVerbosity:";
        public const string JNIOutputFileString = "--JNIOutputFile:";
        public const string JVMPackagesString = "--JVMPackages:";
        public const string JVMOptionString = "--JVMOption:";
        public const string JVMKVOptionString = "--JVMKVOption:";

        public static readonly char PathSeparator = (Environment.OSVersion.Platform == PlatformID.Unix || Environment.OSVersion.Platform == PlatformID.MacOSX) ? ':' : ';';
    }
}
