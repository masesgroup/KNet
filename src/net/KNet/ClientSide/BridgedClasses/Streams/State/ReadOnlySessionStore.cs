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

using MASES.JCOBridge.C2JBridge;
using Java.Time;
using Org.Apache.Kafka.Streams.KStream;

namespace Org.Apache.Kafka.Streams.State
{
    public interface IReadOnlySessionStore<K, AGG> : IJVMBridgeBase
    {
        KeyValueIterator<Windowed<K>, AGG> FindSessions(K key,
                                                        long earliestSessionEndTime,
                                                        long latestSessionStartTime);

        KeyValueIterator<Windowed<K>, AGG> FindSessions(K key,
                                                        Instant earliestSessionEndTime,
                                                        Instant latestSessionStartTime);

        KeyValueIterator<Windowed<K>, AGG> BackwardFindSessions(K key,
                                                                long earliestSessionEndTime,
                                                                long latestSessionStartTime);

        KeyValueIterator<Windowed<K>, AGG> BackwardFindSessions(K key,
                                                                Instant earliestSessionEndTime,
                                                                Instant latestSessionStartTime);
        KeyValueIterator<Windowed<K>, AGG> FindSessions(K keyFrom,
                                                        K keyTo,
                                                        long earliestSessionEndTime,
                                                        long latestSessionStartTime);
        KeyValueIterator<Windowed<K>, AGG> FindSessions(K keyFrom,
                                                        K keyTo,
                                                        Instant earliestSessionEndTime,
                                                        Instant latestSessionStartTime);

        KeyValueIterator<Windowed<K>, AGG> BackwardFindSessions(K keyFrom,
                                                                K keyTo,
                                                                long earliestSessionEndTime,
                                                                long latestSessionStartTime);

        KeyValueIterator<Windowed<K>, AGG> BackwardFindSessions(K keyFrom,
                                                                K keyTo,
                                                                Instant earliestSessionEndTime,
                                                                Instant latestSessionStartTime);

        AGG FetchSession(K key,
                        long sessionStartTime,
                        long sessionEndTime);

        AGG FetchSession(K key,
                        Instant sessionStartTime,
                        Instant sessionEndTime);

        KeyValueIterator<Windowed<K>, AGG> Fetch(K key);

        KeyValueIterator<Windowed<K>, AGG> BackwardFetch(K key);

        KeyValueIterator<Windowed<K>, AGG> Fetch(K keyFrom, K keyTo);

        KeyValueIterator<Windowed<K>, AGG> BackwardFetch(K keyFrom, K keyTo);
    }

    public class ReadOnlySessionStore<K, AGG> : JVMBridgeBase<ReadOnlySessionStore<K, AGG>, IReadOnlySessionStore<K, AGG>>, IReadOnlySessionStore<K, AGG>
    {
        public override string ClassName => "org.apache.kafka.streams.state.ReadOnlySessionStore";

        public KeyValueIterator<Windowed<K>, AGG> BackwardFetch(K key)
        {
            return IExecute<KeyValueIterator<Windowed<K>, AGG>>("backwardFetch", key);
        }

        public KeyValueIterator<Windowed<K>, AGG> BackwardFetch(K keyFrom, K keyTo)
        {
            return IExecute<KeyValueIterator<Windowed<K>, AGG>>("backwardFetch", keyFrom, keyTo);
        }

        public KeyValueIterator<Windowed<K>, AGG> BackwardFindSessions(K key, long earliestSessionEndTime, long latestSessionStartTime)
        {
            return IExecute<KeyValueIterator<Windowed<K>, AGG>>("backwardFindSessions", key, earliestSessionEndTime, latestSessionStartTime);
        }

        public KeyValueIterator<Windowed<K>, AGG> BackwardFindSessions(K key, Instant earliestSessionEndTime, Instant latestSessionStartTime)
        {
            return IExecute<KeyValueIterator<Windowed<K>, AGG>>("backwardFindSessions", key, earliestSessionEndTime, latestSessionStartTime);
        }

        public KeyValueIterator<Windowed<K>, AGG> BackwardFindSessions(K keyFrom, K keyTo, long earliestSessionEndTime, long latestSessionStartTime)
        {
            return IExecute<KeyValueIterator<Windowed<K>, AGG>>("backwardFindSessions", keyFrom, keyTo, earliestSessionEndTime, latestSessionStartTime);
        }

        public KeyValueIterator<Windowed<K>, AGG> BackwardFindSessions(K keyFrom, K keyTo, Instant earliestSessionEndTime, Instant latestSessionStartTime)
        {
            return IExecute<KeyValueIterator<Windowed<K>, AGG>>("backwardFindSessions", keyFrom, keyTo, earliestSessionEndTime, latestSessionStartTime);
        }

        public void Close()
        {
            IExecute("close");
        }

        public KeyValueIterator<Windowed<K>, AGG> Fetch(K key)
        {
            return IExecute<KeyValueIterator<Windowed<K>, AGG>>("fetch", key);
        }

        public KeyValueIterator<Windowed<K>, AGG> Fetch(K keyFrom, K keyTo)
        {
            return IExecute<KeyValueIterator<Windowed<K>, AGG>>("fetch", keyFrom, keyTo);
        }

        public AGG FetchSession(K key, long sessionStartTime, long sessionEndTime)
        {
            return IExecute<AGG>("fetchSession", key, sessionStartTime, sessionEndTime);
        }

        public AGG FetchSession(K key, Instant sessionStartTime, Instant sessionEndTime)
        {
            return IExecute<AGG>("fetchSession", key, sessionStartTime, sessionEndTime);
        }

        public KeyValueIterator<Windowed<K>, AGG> FindSessions(K key, long earliestSessionEndTime, long latestSessionStartTime)
        {
            return IExecute<KeyValueIterator<Windowed<K>, AGG>>("findSessions", key, earliestSessionEndTime, latestSessionStartTime);
        }

        public KeyValueIterator<Windowed<K>, AGG> FindSessions(K key, Instant earliestSessionEndTime, Instant latestSessionStartTime)
        {
            return IExecute<KeyValueIterator<Windowed<K>, AGG>>("findSessions", key, earliestSessionEndTime, latestSessionStartTime);
        }

        public KeyValueIterator<Windowed<K>, AGG> FindSessions(K keyFrom, K keyTo, long earliestSessionEndTime, long latestSessionStartTime)
        {
            return IExecute<KeyValueIterator<Windowed<K>, AGG>>("findSessions", keyFrom, keyTo, earliestSessionEndTime, latestSessionStartTime);
        }

        public KeyValueIterator<Windowed<K>, AGG> FindSessions(K keyFrom, K keyTo, Instant earliestSessionEndTime, Instant latestSessionStartTime)
        {
            return IExecute<KeyValueIterator<Windowed<K>, AGG>>("findSessions", keyFrom, keyTo, earliestSessionEndTime, latestSessionStartTime);
        }

        public void Flush()
        {
            IExecute("flush");
        }

        public void Put(Windowed<K> sessionKey, AGG aggregate)
        {
            IExecute("put", sessionKey, aggregate);
        }

        public void Remove(Windowed<K> sessionKey)
        {
            IExecute("remove", sessionKey);
        }
    }
}

