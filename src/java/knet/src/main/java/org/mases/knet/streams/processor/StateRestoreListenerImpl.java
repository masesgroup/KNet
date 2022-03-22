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

package org.mases.knet.streams.processor;

import org.apache.kafka.common.TopicPartition;
import org.apache.kafka.streams.processor.StateRestoreListener;
import org.mases.jcobridge.*;

public final class StateRestoreListenerImpl extends JCListener implements StateRestoreListener {
    public StateRestoreListenerImpl(String key) throws JCNativeException {
        super(key);
    }

    @Override
    public void onRestoreStart(final TopicPartition topicPartition,
                               final String storeName,
                               final long startingOffset,
                               final long endingOffset) {
        raiseEvent("onBatchRestored", topicPartition, storeName, startingOffset, endingOffset);
    }

    @Override
    public void onBatchRestored(final TopicPartition topicPartition,
                                final String storeName,
                                final long batchEndOffset,
                                final long numRestored) {
        raiseEvent("onBatchRestored", topicPartition, storeName, batchEndOffset, numRestored);
    }

    @Override
    public void onRestoreEnd(final TopicPartition topicPartition,
                             final String storeName,
                             final long totalRestored) {
        raiseEvent("onRestoreEnd", topicPartition, storeName, totalRestored);
    }
}
