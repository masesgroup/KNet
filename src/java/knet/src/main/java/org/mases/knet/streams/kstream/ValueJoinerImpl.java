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

package org.mases.knet.streams.kstream;

import org.apache.kafka.streams.kstream.ValueJoiner;
import org.mases.jcobridge.*;

public final class ValueJoinerImpl extends JCListener implements ValueJoiner {
    public ValueJoinerImpl(String key) throws JCNativeException {
        super(key);
    }

    @Override
    public Object apply(final Object value1, final Object value2) {
        raiseEvent("apply", value1, value2);
        Object retVal = getReturnData();
        return retVal;
    }
}
