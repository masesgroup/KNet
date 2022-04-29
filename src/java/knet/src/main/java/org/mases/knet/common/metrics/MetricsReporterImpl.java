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

package org.mases.knet.common.metrics;

import org.apache.kafka.common.config.ConfigException;
import org.apache.kafka.common.metrics.KafkaMetric;
import org.apache.kafka.common.metrics.MetricsContext;
import org.apache.kafka.common.metrics.MetricsReporter;
import org.mases.jcobridge.*;

import java.util.List;
import java.util.Map;
import java.util.Set;

public final class MetricsReporterImpl extends JCListener implements MetricsReporter {
    public MetricsReporterImpl(String key) throws JCNativeException {
        super(key);
    }

    @Override
    public void init(List<KafkaMetric> metrics) {
        raiseEvent("init", metrics);
    }

    @Override
    public void metricChange(KafkaMetric metric) {
        raiseEvent("metricChange", metric);
    }

    @Override
    public void metricRemoval(KafkaMetric metric) {
        raiseEvent("metricRemoval", metric);
    }

    @Override
    public void close() {
        raiseEvent("close");
    }

    @Override
    public Set<String> reconfigurableConfigs() {
        raiseEvent("reconfigurableConfigs");
        Object retVal = getReturnData();
        return (Set<String>) retVal;
    }

    @Override
    public void configure(Map<String, ?> configs) {
        raiseEvent("configure", configs);
    }

    @Override
    public void reconfigure(Map<String, ?> configs) {
        raiseEvent("reconfigure", configs);
    }

    @Override
    public void validateReconfiguration(Map<String, ?> configs) throws ConfigException {
        raiseEvent("validateReconfiguration", configs);
    }

    @Override
    public void contextChange(MetricsContext metricsContext) {
        raiseEvent("contextChange", metricsContext);
    }
}