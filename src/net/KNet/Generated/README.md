## Generated classes

This folder contains the Java classes generated using JNetReflector at current version of Apache Kafka.

The command used to build the classes is the following:

```cmd
MASES.JNetReflector.exe -TraceLevel 0 -OriginRootPath .\jars -DestinationRootPath .\src\net\KNet\Generated -JarList kafka_2.13-3.4.0.jar,kafka-clients-3.4.0.jar,kafka-streams-3.4.0.jar,kafka-tools-3.4.0.jar,connect-api-3.4.0.jar,connect-basic-auth-extension-3.4.0.jar,connect-json-3.4.0.jar,connect-mirror-3.4.0.jar,connect-mirror-client-3.4.0.jar,connect-runtime-3.4.0.jar,connect-transforms-3.4.0.jar -OriginJavadocJARVersionAndUrls "11|https://www.javadoc.io/static/org.apache.kafka/kafka_2.13/3.4.0/,11|https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/,11|https://www.javadoc.io/static/org.apache.kafka/kafka-streams/3.4.0/,11|https://www.javadoc.io/static/org.apache.kafka/kafka-tools/3.4.0/,11|https://www.javadoc.io/static/org.apache.kafka/connect-api/3.4.0/,11|https://www.javadoc.io/static/org.apache.kafka/connect-basic-auth-extension/3.4.0/,11|https://www.javadoc.io/static/org.apache.kafka/connect-json/3.4.0/,11|https://www.javadoc.io/static/org.apache.kafka/connect-mirror/3.4.0/,11|https://www.javadoc.io/static/org.apache.kafka/connect-mirror-client/3.4.0/,11|https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/,11|https://www.javadoc.io/static/org.apache.kafka/connect-transforms/3.4.0/" -NamespacesToAvoid scala,org.apache.kafka.clients.admin.internals,org.apache.kafka.connect.tools
```