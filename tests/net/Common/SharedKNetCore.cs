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

using Java.Lang;
using System;

namespace MASES.KNet.TestCommon
{
    internal class SharedKNetCore : KNetCore<SharedKNetCore>
    {
        public static void Create()
        {
            ApplicationJarRootPath = Const.DefaultJarsPath;
            CreateGlobalInstance();
        }

        public static int ManageException(System.Exception e)
        {
            int retCode = 0;
            if (e is ClassNotFoundException cnfe)
            {
                Console.WriteLine($"Failed with {cnfe}, current ClassPath is {SharedKNetCore.GlobalInstance.ClassPath}");
                retCode = 1;
            }
            else if (e is NoClassDefFoundError ncdfe)
            {
                Console.WriteLine($"Failed with {ncdfe}, current ClassPath is {SharedKNetCore.GlobalInstance.ClassPath}");
                retCode = 1;
            }
            else
            {
                Console.WriteLine($"Failed with {e}");
                retCode = 1;
            }
            return retCode;
        }

        public override bool LogClassPath => false;

        public long CurrentJNICalls => JVMStats.TotalJNICalls;

        public TimeSpan CurrentTimeSpentInJNICalls => JVMStats.TotalTimeInJNICalls;
    }
}
