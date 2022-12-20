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

namespace MASES.KNet.Streams.Query
{
    public class KeyQuery<K, V> : Query<V>
    {
        public override bool IsInterface => false;

        public override string ClassName => "org.apache.kafka.streams.query.KeyQuery";

        public static KeyQuery<K, V> WithKey(K key) => SExecute<KeyQuery<K, V>>("withKey", key);

        public KeyQuery<K, V> SkipCache() => IExecute < KeyQuery<K, V>>("skipCache");

        public K Key => IExecute<K>("getKey");

        public bool IsSkipCache => IExecute<bool>("isSkipCache");
    }
}
