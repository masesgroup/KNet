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

package org.mases.knet.streams.processor;

import org.apache.kafka.streams.processor.StreamPartitioner;
import org.mases.jcobridge.*;

import java.util.Optional;
import java.util.Set;

public final class StreamPartitionerImpl extends JCListener implements StreamPartitioner {
    public StreamPartitionerImpl(String key) throws JCNativeException {
        super(key);
    }

    @Override
    public Integer partition(String topic, Object key, Object value, int numPartitions) {
        raiseEvent("partition", topic, key, value, numPartitions);
        Object retVal = getReturnData();
        int ret = (int) retVal;
        if (ret == -1) return null;
        return new Integer((int) retVal);
    }

    @Override
    public Optional<Set<Integer>> partitions(String topic, Object key, Object value, int numPartitions) {
        raiseEvent("partitions", topic, key, value, numPartitions);
        Object retVal = getReturnData();
        int ret = (int) retVal;
        if (ret == -1) return null;
        return (Optional<Set<Integer>>) retVal;
    }
}
