/*
*  Copyright 2022 MASES s.r.l.
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

namespace MASES.KafkaBridge.Java.Util
{
    public class ArrayList<E> : Iterable<E>
    {
        public override string ClassName => "java.util.ArrayList";

        public static implicit operator Collection<E>(ArrayList<E> array) { return Wraps<Collection<E>>(array.Instance); }

        public static implicit operator List<E>(ArrayList<E> array) { return Wraps<List<E>>(array.Instance); }

        public bool IsEmpty => IExecute<bool>("isEmpty");

        public bool Add(E element)
        {
            return IExecute<bool>("add", element);
        }

        public bool Add(int index, E element)
        {
            return IExecute<bool>("add", index, element);
        }

        public bool AddAll<TSuperE>(Collection<TSuperE> elements)
            where TSuperE : E
        {
            return IExecute<bool>("addAll", elements);
        }

        public bool AddAll<TSuperE>(int index, Collection<TSuperE> elements)
            where TSuperE : E
        {
            return IExecute<bool>("addAll", index, elements);
        }

        public void Clear()
        {
            IExecute("clear");
        }

        public E Get(int index)
        {
            return IExecute<E>("get", index);
        }

        public E Remove(int index)
        {
            return IExecute<E>("remove", index);
        }

        public E Set(int index, E element)
        {
            return IExecute<E>("set", index, element);
        }
    }
}
