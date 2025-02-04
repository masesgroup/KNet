/*
*  Copyright 2025 MASES s.r.l.
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

using MASES.JNetPSCore;
using MASES.KNet;

namespace MASES.KNetPS
{
    /// <summary>
    /// Public Helper class
    /// </summary>
    public static class KNetPSHelper<TClass> where TClass : KNetCore<TClass>
    {
        public static void SetClassToRun(string classToRun) { JNetPSHelper<TClass>.Set(typeof(KNetCore<>), nameof(KNetPSCore.ApplicationClassToRun), classToRun); }

        public static void SetJarRootPath(string jarRootPath) { JNetPSHelper<TClass>.Set(typeof(KNetCore<>), nameof(KNetPSCore.ApplicationJarRootPath), jarRootPath); }

        public static void SetLog4JPath(string log4JPath) { JNetPSHelper<TClass>.Set(typeof(KNetCore<>), nameof(KNetPSCore.ApplicationLog4JPath), log4JPath); }

        public static void SetLogPath(string logPath) { JNetPSHelper<TClass>.Set(typeof(KNetCore<>), nameof(KNetPSCore.ApplicationLogPath), logPath); }

        public static void SetScalaVersion(string scalaVersion) { JNetPSHelper<TClass>.Set(typeof(KNetCore<>), nameof(KNetPSCore.ApplicationScalaVersion), scalaVersion); }

        public static void SetDisableJMX(bool? disableJMX) { JNetPSHelper<TClass>.Set(typeof(KNetCore<>), nameof(KNetPSCore.ApplicationDisableJMX), disableJMX); }
    }
}