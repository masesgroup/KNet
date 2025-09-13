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

package org.mases.knet.developed.streams.kstream;

import org.apache.kafka.streams.state.StoreBuilder;

import java.util.Set;

public final class ValueTransformerWithKeySupplier extends org.mases.jcobridge.JCListener implements org.apache.kafka.streams.kstream.ValueTransformerWithKeySupplier {
    public ValueTransformerWithKeySupplier(String key) throws org.mases.jcobridge.JCNativeException {
        super(key);
    }

    public Set<StoreBuilder<?>> storesDefault() {
        return org.apache.kafka.streams.kstream.ValueTransformerWithKeySupplier.super.stores();
    }

    @Override
    public Set<StoreBuilder<?>> stores() {
        raiseEvent("stores");
        Object retVal = getReturnData();
        return (Set<StoreBuilder<?>>) retVal;
    }

    @Override
    public org.apache.kafka.streams.kstream.ValueTransformerWithKey get() {
        raiseEvent("get");
        Object retVal = getReturnData();
        return (org.apache.kafka.streams.kstream.ValueTransformerWithKey) retVal;
    }
}