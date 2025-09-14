/*
*  Copyright (c) 2021-2025 MASES s.r.l.
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
    public class TestType
    {
        static readonly byte[] _extraValue = null;
        static readonly byte[] _bigExtraValue = null;
        static readonly byte[] _bigBigExtraValue = null;
        static TestType()
        {
            _extraValue = new byte[100];
            for (int i = 0; i < _extraValue.LongLength; i++)
            {
                _extraValue[i] = (byte)(i % byte.MaxValue);
            }
            _bigExtraValue = new byte[100000];
            for (int i = 0; i < _bigExtraValue.LongLength; i++)
            {
                _bigExtraValue[i] = (byte)(i % byte.MaxValue);
            }
            _bigBigExtraValue = new byte[1000000];
            for (int i = 0; i < _bigBigExtraValue.LongLength; i++)
            {
                _bigBigExtraValue[i] = (byte)(i % byte.MaxValue);
            }
        }

        public TestType() { }

        public TestType(int i, bool withExtraValue, bool withBigExtraValue, bool withBigBigExtraValue)
        {
            name = description = value = i.ToString();
            if (withExtraValue)
            {
                extraValue = _extraValue;
            }
            else if (withBigExtraValue)
            {
                extraValue = _bigExtraValue;
            }
            else if (withBigBigExtraValue)
            {
                extraValue = _bigBigExtraValue;
            }
        }

        public string name { get; set; }
        public string description { get; set; }
        public string value { get; set; }
        public byte[] extraValue { get; set; }

        public override string ToString()
        {
            return $"name {name} - description {description} - value {value}";
        }
    }

    internal class SharedKNetCore : KNetCore<SharedKNetCore>
    {
        public static void Create()
        {
            ApplicationHeapSize = "2G";
            ApplicationInitialHeapSize = "1G";

            ApplicationJarRootPath = Const.DefaultJarsPath;
            CreateGlobalInstance();
            if (GlobalInstance == null)
            {
                throw new InvalidOperationException("Failed to create GlobalInstance");
            }
            if (JCOBridge.C2JBridge.JCOBridge.Global == null)
            {
                throw new InvalidOperationException("JCOBridge.C2JBridge.JCOBridge.Global is null!!!");
            }
        }

        public static int ManageException(System.Exception e)
        {
            int retCode = 0;
            if (e is TypeInitializationException tie)
            {
                return ManageException(tie.InnerException);
            }
            else if (e is ClassNotFoundException cnfe)
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
