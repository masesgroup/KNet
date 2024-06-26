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

using MASES.KNet.Serialization;
using MASES.KNet.TestCommon;
using System;
using System.Linq;

namespace MASES.KNetTestAdmin
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SharedKNetCore.Create();

                ExecuteTests(); // call tests outside Main so KNetSerialization static initialization happens later and JCOBridge.Global is ready
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Environment.ExitCode = 1;
            }
        }

        static void ExecuteTests()
        {
            byte[] bb, bb1;

            bb = KNetSerialization.SerializeBoolean(false, "test", false);
            bb1 = KNetSerialization.SerializeBoolean(true, "test", false);
            if (!bb.SequenceEqual(bb1)) throw new System.Exception();

            if (KNetSerialization.DeserializeBoolean(true, "test", bb) != false) throw new System.Exception();

            bb = KNetSerialization.SerializeBoolean(false, "test", true);
            bb1 = KNetSerialization.SerializeBoolean(true, "test", true);
            if (!bb.SequenceEqual(bb1)) throw new System.Exception();

            if (KNetSerialization.DeserializeBoolean(true, "test", bb) != true) throw new System.Exception();

            const int cycles = 100;

            long cycleDelta = short.MaxValue / cycles;

            for (short i = 0; i < cycles; i++)
            {
                short val = (short)(short.MinValue + i * (short)cycleDelta);

                bb = KNetSerialization.SerializeShort(false, "test", val);
                bb1 = KNetSerialization.SerializeShort(true, "test", val);
                if (!bb.SequenceEqual(bb1)) throw new System.Exception();

                if (KNetSerialization.DeserializeShort(true, "test", bb) != val) throw new System.Exception();
            }

            cycleDelta = int.MaxValue / cycles;

            for (int i = 0; i < cycles; i++)
            {
                int val = int.MinValue + i * (int)cycleDelta;

                bb = KNetSerialization.SerializeInt(false, "test", val);
                bb1 = KNetSerialization.SerializeInt(true, "test", val);
                if (!bb.SequenceEqual(bb1)) throw new System.Exception();

                if (KNetSerialization.DeserializeInt(true, "test", bb) != val) throw new System.Exception();
            }

            cycleDelta = long.MaxValue / cycles;

            for (long i = 0; i < cycles; i++)
            {
                long val = long.MinValue + i * (long)cycleDelta;

                bb = KNetSerialization.SerializeLong(false, "test", val);
                bb1 = KNetSerialization.SerializeLong(true, "test", val);
                if (!bb.SequenceEqual(bb1)) throw new System.Exception();

                if (KNetSerialization.DeserializeLong(true, "test", bb) != val) throw new System.Exception();
            }

            float cycleDeltaF = float.MaxValue / cycles;

            for (long i = 0; i < cycles; i++)
            {
                float val = float.MinValue + i * cycleDeltaF;

                bb = KNetSerialization.SerializeFloat(false, "test", val);
                bb1 = KNetSerialization.SerializeFloat(true, "test", val);
                if (!bb.SequenceEqual(bb1)) throw new System.Exception();

                if (KNetSerialization.DeserializeFloat(true, "test", bb) != val) throw new System.Exception();
            }

            double cycleDeltaD = double.MaxValue / cycles;

            for (long i = 0; i < cycles; i++)
            {
                double val = double.MinValue + i * cycleDeltaD;

                bb = KNetSerialization.SerializeDouble(false, "test", val);
                bb1 = KNetSerialization.SerializeDouble(true, "test", val);
                if (!bb.SequenceEqual(bb1)) throw new System.Exception();

                if (KNetSerialization.DeserializeDouble(true, "test", bb) != val) throw new System.Exception();
            }
        }
    }
}
