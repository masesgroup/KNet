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

using MASES.CLIParser;
using Org.Apache.Kafka.Clients.Consumer;
using Org.Apache.Kafka.Clients.Producer;
using Org.Apache.Kafka.Common;
using Org.Apache.Kafka.Common.Errors;
using Org.Apache.Kafka.Connect.Errors;
using Org.Apache.Kafka.Streams.Errors;
using System;
using System.Collections.Generic;
using System.IO;
using MASES.JNet;
using Org.Apache.Kafka.Common.Config;

namespace MASES.KNet
{
    /// <summary>
    /// Public entry point of <see cref="KNetCore{T}"/>
    /// </summary>
    /// <typeparam name="T">A class which inherits from <see cref="KNetCore{T}"/></typeparam>
    public class KNetCore<T> : JNetCore<T>
        where T : KNetCore<T>
    {
        /// <inheritdoc cref="JNetCore{T}.CommandLineArguments"/>
        public override IEnumerable<IArgumentMetadata> CommandLineArguments
        {
            get
            {
                var lst = new List<IArgumentMetadata>(base.CommandLineArguments);
                lst.AddRange(new IArgumentMetadata[]
                {
                    new ArgumentMetadata<string>()
                    {
                        Name = CLIParam.ClassToRun,
                        Help = "The class to be instantiated from CLI.",
                    },
                    new ArgumentMetadata<string>()
                    {
                        Name = CLIParam.ScalaVersion,
                        Default = Const.DefaultScalaVersion,
                        Help = "The version of scala to be used.",
                    },
                    new ArgumentMetadata<string>()
                    {
                        Name = CLIParam.KafkaLocation,
                        Default = Const.DefaultRootPath,
                        Help = "The folder where Kafka package are stored. Default consider the application use the Jars in the package.",
                    },
                    new ArgumentMetadata<string>()
                    {
                        Name = CLIParam.Log4JConfiguration,
                        Default = Const.DefaultLog4JPath,
                        Help = "The file containing the configuration of log4j.",
                    },
                    new ArgumentMetadata<string>()
                    {
                        Name = CLIParam.LogPath,
                        Default = Const.DefaultLogPath,
                        Help = "The path where log will be stored.",
                    },
                    new ArgumentMetadata<string>()
                    {
                        Name = CLIParam.DisableJMX,
                        Type = ArgumentType.Single,
                        Help = "Disable JMX. Default is JMX enabled without security.",
                    },
                    /* hide until other arguments will be added
                    new ArgumentMetadata<string>()
                    {
                        Name = CLIParam.EnableJMXAuth,
                        Type = ArgumentType.Single,
                        Help = "Enable authenticate on JMX. Default is not enabled",
                    },
                    new ArgumentMetadata<string>()
                    {
                        Name = CLIParam.EnableJMXSSL,
                        Type = ArgumentType.Single,
                        Help = "Enable SSL on JMX. Default is not enabled.",
                    },
                    */
                });
                return lst;
            }
        }
        /// <summary>
        /// Public initializer
        /// </summary>
        public KNetCore()
        {
            #region Base Exceptions

            JCOBridge.C2JBridge.JCOBridge.RegisterException<KafkaException>();
            JCOBridge.C2JBridge.JCOBridge.RegisterException<InvalidRecordException>();

            #endregion

            #region Common Exceptions

            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(ConfigException));

            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(ApiException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(AuthenticationException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(AuthorizationException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(AuthorizerNotReadyException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(BrokerIdNotRegisteredException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(BrokerNotAvailableException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(ClusterAuthorizationException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(ConcurrentTransactionsException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(ControllerMovedException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(CoordinatorLoadInProgressException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(CoordinatorNotAvailableException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(CorruptRecordException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(DelegationTokenAuthorizationException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(DelegationTokenDisabledException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(DelegationTokenExpiredException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(DelegationTokenNotFoundException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(DelegationTokenOwnerMismatchException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(DisconnectException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(DuplicateBrokerRegistrationException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(DuplicateResourceException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(DuplicateSequenceException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(ElectionNotNeededException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(EligibleLeadersNotAvailableException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(FeatureUpdateFailedException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(FencedInstanceIdException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(FencedLeaderEpochException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(FetchSessionIdNotFoundException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(GroupAuthorizationException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(GroupIdNotFoundException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(GroupMaxSizeReachedException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(GroupNotEmptyException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(GroupSubscribedToTopicException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(IllegalGenerationException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(IllegalSaslStateException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(InconsistentClusterIdException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(InconsistentGroupProtocolException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(InconsistentTopicIdException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(InconsistentVoterSetException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(IneligibleReplicaException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(InterruptException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(InvalidCommitOffsetSizeException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(InvalidConfigurationException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(InvalidFetchSessionEpochException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(InvalidFetchSizeException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(InvalidGroupIdException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(InvalidMetadataException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(Org.Apache.Kafka.Clients.Consumer.InvalidOffsetException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(InvalidPartitionsException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(InvalidPidMappingException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(InvalidPrincipalTypeException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(InvalidProducerEpochException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(InvalidReplicaAssignmentException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(InvalidReplicationFactorException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(InvalidRequestException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(InvalidRequiredAcksException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(InvalidSessionTimeoutException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(InvalidTimestampException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(InvalidTopicException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(InvalidTxnStateException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(InvalidTxnTimeoutException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(InvalidUpdateVersionException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(KafkaStorageException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(LeaderNotAvailableException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(ListenerNotFoundException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(LogDirNotFoundException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(MemberIdRequiredException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(NetworkException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(NewLeaderElectedException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(NoReassignmentInProgressException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(NotControllerException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(NotCoordinatorException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(NotEnoughReplicasAfterAppendException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(NotEnoughReplicasException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(NotLeaderForPartitionException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(NotLeaderOrFollowerException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(OffsetMetadataTooLarge));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(OffsetNotAvailableException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(Org.Apache.Kafka.Common.Errors.OffsetOutOfRangeException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(OperationNotAttemptedException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(OutOfOrderSequenceException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(PolicyViolationException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(PositionOutOfRangeException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(PreferredLeaderNotAvailableException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(PrincipalDeserializationException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(ProducerFencedException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(ReassignmentInProgressException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(RebalanceInProgressException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(RecordBatchTooLargeException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(RecordDeserializationException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(RecordTooLargeException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(ReplicaNotAvailableException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(ResourceNotFoundException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(Org.Apache.Kafka.Common.Errors.RetriableException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(SaslAuthenticationException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(SecurityDisabledException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(SerializationException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(SnapshotNotFoundException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(SslAuthenticationException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(StaleBrokerEpochException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(ThrottlingQuotaExceededException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(Org.Apache.Kafka.Common.Errors.TimeoutException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(TopicAuthorizationException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(TopicDeletionDisabledException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(TopicExistsException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(TransactionAbortedException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(TransactionalIdAuthorizationException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(TransactionalIdNotFoundException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(TransactionCoordinatorFencedException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(UnacceptableCredentialException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(UnknownLeaderEpochException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(UnknownMemberIdException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(UnknownProducerIdException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(UnknownServerException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(UnknownTopicIdException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(UnknownTopicOrPartitionException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(UnstableOffsetCommitException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(UnsupportedByAuthenticationException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(UnsupportedCompressionTypeException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(UnsupportedForMessageFormatException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(UnsupportedSaslMechanismException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(UnsupportedVersionException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(WakeupException));

            #endregion

            #region Consumer Exceptions

            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(CommitFailedException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(Org.Apache.Kafka.Clients.Consumer.InvalidOffsetException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(LogTruncationException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(NoOffsetForPartitionException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(Org.Apache.Kafka.Clients.Consumer.OffsetOutOfRangeException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(RetriableCommitFailedException));

            #endregion

            #region Producer Exceptions

            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(BufferExhaustedException));

            #endregion

            #region Streams Exceptions
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(BrokerNotFoundException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(InvalidStateStoreException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(InvalidStateStorePartitionException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(LockException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(MissingSourceTopicException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(ProcessorStateException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(StateStoreMigratedException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(StateStoreNotAvailableException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(StreamsException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(StreamsNotStartedException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(StreamsRebalancingException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(StreamsStoppedException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(TaskAssignmentException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(TaskCorruptedException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(TaskIdFormatException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(TaskMigratedException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(TopologyException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(UnknownStateStoreException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(UnknownTopologyException));
            #endregion

            #region Connect Exceptions
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(AlreadyExistsException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(ConnectException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(DataException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(IllegalWorkerStateException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(NotFoundException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(Org.Apache.Kafka.Connect.Errors.RetriableException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(SchemaBuilderException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(SchemaProjectorException));
            #endregion
        }

        /// <inheritdoc cref="JNetCore{T}.ProcessCommandLine" />
        protected override string[] ProcessCommandLine()
        {
            var result = base.ProcessCommandLine();

            _classToRun = ParsedArgs.Get<string>(CLIParam.ClassToRun);
            _JarRootPath = ParsedArgs.Get<string>(CLIParam.KafkaLocation);
            _log4JPath = ParsedArgs.Get<string>(CLIParam.Log4JConfiguration);
            _logPath = ParsedArgs.Get<string>(CLIParam.LogPath);
            _scalaVersion = ParsedArgs.Get<string>(CLIParam.ScalaVersion);
            _disableJMX = ParsedArgs.Exist(CLIParam.DisableJMX);
            return result;
        }

        /// <summary>
        /// Sets the <see cref="Type"/> to be invoked at startup
        /// </summary>
        public static Type MainClassToRun { get; protected set; }

        /// <summary>
        /// Sets the global value of class to run
        /// </summary>
        public static string ApplicationClassToRun { get; set; }

        /// <summary>
        /// Sets the global value of Jar root path
        /// </summary>
        public static string ApplicationJarRootPath { get; set; }

        /// <summary>
        /// Sets the global value of log4j path
        /// </summary>
        public static string ApplicationLog4JPath { get; set; }

        /// <summary>
        /// Sets the global value of log path
        /// </summary>
        public static string ApplicationLogPath { get; set; }

        /// <summary>
        /// Sets the global value of scala version
        /// </summary>
        public static string ApplicationScalaVersion { get; set; }

        /// <summary>
        /// Sets the global value to disable JMX
        /// </summary>
        public static bool? ApplicationDisableJMX { get; set; }

        string _classToRun;
        /// <summary>
        /// The class to run in CLI version
        /// </summary>
        public virtual string ClassToRun { get { return ApplicationClassToRun ?? _classToRun; } }

        string _scalaVersion;
        /// <summary>
        /// The Scala version to be used
        /// </summary>
        public virtual string ScalaVersion { get { return ApplicationScalaVersion ?? _scalaVersion; } }

        /// <summary>
        /// The Scala binary version to be used
        /// </summary>
        public virtual string ScalaBinaryVersion { get { var ver = Version.Parse(ScalaVersion); return (ver.Revision == 0) ? string.Format("{0}", ver.Minor) : string.Format("{0}.{1}", ver.Minor, ver.Revision); } }

        string _JarRootPath;
        /// <summary>
        /// The root path where Apache Kafka is installed
        /// </summary>
        public virtual string JarRootPath { get { return ApplicationJarRootPath ?? _JarRootPath; } }

        string _log4JPath;
        /// <summary>
        /// The log4j folder
        /// </summary>
        public virtual string Log4JPath { get { return ApplicationLog4JPath ?? _log4JPath; } }

        string _logPath;
        /// <summary>
        /// The log folder
        /// </summary>
        public virtual string LogDir { get { return ApplicationLogPath ?? _logPath; } }

        /// <summary>
        /// The log4j configuration
        /// </summary>
        public virtual string Log4JOpts { get { return string.Format("file:{0}", Path.Combine(JarRootPath, "config", "tools-log4j.properties")); } }

        bool _disableJMX;
        /// <summary>
        /// Disable JMX
        /// </summary>
        public virtual bool DisableJMX { get { return ApplicationDisableJMX ?? _disableJMX; } }

        /// <inheritdoc cref="JNetCore{T}.PerformanceOptions"/>
        protected override IList<string> PerformanceOptions
        {
            get
            {
                var lst = new List<string>(base.PerformanceOptions);
                lst.AddRange(new string[]
                {
                    // "-server", <- Disabled because it avoids starts of embedded JVM
                    "-XX:+UseG1GC",
                    "-XX:MaxGCPauseMillis=20",
                    "-XX:InitiatingHeapOccupancyPercent=35",
                    "-XX:+ExplicitGCInvokesConcurrent",
                });
                return lst;
            }
        }

        /// <inheritdoc cref="JNetCore{T}.Options"/>
        protected override IDictionary<string, string> Options
        {
            get
            {
                if (!Directory.Exists(LogDir)) Directory.CreateDirectory(LogDir);

                IDictionary<string, string> options = new Dictionary<string, string>(base.Options)
                {
                    { "log4j.configuration", string.IsNullOrEmpty(Log4JPath) ? ((JarRootPath == Const.DefaultRootPath) ? Log4JOpts : null) : $"file:{Log4JPath}"},
                    { "kafka.logs.dir", LogDir},
                    { "java.awt.headless", "true" },
                };

                if (!_disableJMX)
                {
                    options.Add("-Dcom.sun.management.jmxremote", null);
                    options.Add("com.sun.management.jmxremote.authenticate", ParsedArgs.Exist(CLIParam.EnableJMXAuth) ? "true" : "false");
                    options.Add("com.sun.management.jmxremote.ssl", ParsedArgs.Exist(CLIParam.EnableJMXSSL) ? "true" : "false");
                }

                return options;
            }
        }

        /// <inheritdoc cref="JNetCore{T}.PathToParse"/>
        protected override IList<string> PathToParse
        {
            get
            {
                var lst = new List<string>(base.PathToParse);
                var assembly = typeof(KNetCore<>).Assembly;
                var version = assembly.GetName().Version.ToString();
                // 1. check first full version
                var knetFile = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(assembly.Location), JARsSubFolder, $"knet-{version}.jar");
                if (!System.IO.File.Exists(knetFile) && version.EndsWith(".0"))
                {
                    // 2. if not exist remove last part of version
                    version = version.Substring(0, version.LastIndexOf(".0"));
                    knetFile = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(assembly.Location), JARsSubFolder, $"knet-{version}.jar");
                }
                // 3. add knet at this version first...
                lst.Add(knetFile);
                // 2. ...then add everything else
                lst.Add(JarRootPath != null ? Path.Combine(JarRootPath, "*.jar") : JarRootPath);
                return lst;
            }
        }

#if DEBUG
        public override bool EnableDebug => true;
#endif
    }
}