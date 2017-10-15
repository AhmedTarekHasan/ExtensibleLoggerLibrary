using DevelopmentSimplyPut.ExtensibleLoggerLibrary.Definitions;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DevelopmentSimplyPut.ExtensibleLoggerLibrary.Implementations.EventLogLogger
{
    /// <summary>
    /// Represents an EventLog logger.
    /// </summary>
    public class EventLogLogger : LoggerBase
    {
        #region Fields
        private bool infoIsEnabled = true;
        private bool debugIsEnabled = true;
        private bool warningIsEnabled = true;
        private bool errorIsEnabled = true;
        private bool lowErrorIsEnabled = true;
        private bool mediumErrorIsEnabled = true;
        private bool highErrorIsEnabled = true;
        private bool extremeErrorIsEnabled = true;
        private ILogFormatter logFormatter;
        #endregion

        #region Properties
        /// <summary>
        /// Gets/Sets the logger source.
        /// </summary>
        public virtual string Source { get; set; }
        /// <summary>
        /// Gets/Sets the logger log name.
        /// </summary>
        public virtual string LogName { get; set; }
        /// <summary>
        /// Gets/Sets the logger machine name.
        /// </summary>
        public virtual string MachineName { get; set; }
        /// <summary>
        /// Gets/Sets the logger event id.
        /// </summary>
        public virtual int EventId { get; set; }
        /// <summary>
        /// Gets/Sets the log formatter.
        /// </summary>
        public virtual ILogFormatter LogFormatter
        {
            get
            {
                return logFormatter;
            }

            set
            {
                logFormatter = value;

                if (logFormatter == null)
                {
                    logFormatter = new EventLogLogFormatter();
                }
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the EventLogLogger class.
        /// </summary>
        /// <param name="source">The logger source.</param>
        /// <param name="logName">The logger log name.</param>
        /// <param name="eventId">The logger event id.</param>
        /// <param name="machineName">The logger machine name.</param>
        public EventLogLogger(string source, string logName, int eventId, string machineName) : this(source, logName, eventId, machineName, null)
        {
        }
        /// <summary>
        /// Initializes a new instance of the EventLogLogger class.
        /// </summary>
        /// <param name="source">The logger source.</param>
        /// <param name="logName">The logger log name.</param>
        /// <param name="eventId">The logger event id.</param>
        /// <param name="machineName">The logger machine name.</param>
        /// <param name="logFormatter">The log formatter.</param>
        public EventLogLogger(string source, string logName, int eventId, string machineName, ILogFormatter logFormatter)
        {
            Source = source;
            LogName = logName;
            EventId = eventId;
            MachineName = machineName;
            LogFormatter = logFormatter;

            if (!EventLog.SourceExists(Source))
            {
                if (string.IsNullOrEmpty(MachineName))
                {
                    EventLog.CreateEventSource(Source, LogName);
                }
                else
                {
                    EventSourceCreationData data = new EventSourceCreationData(Source, LogName);
                    data.MachineName = MachineName;
                    EventLog.CreateEventSource(data);
                }
            }
        }
        #endregion

        #region LoggerBase Members
        #region Properties
        /// <summary>
        /// Get/Sets whether logging logs of type info is enabled.
        /// </summary>
        public override bool InfoIsEnabled
        {
            get
            {
                return infoIsEnabled;
            }

            set
            {
                infoIsEnabled = value;
            }
        }
        /// <summary>
        /// Get/Sets whether logging logs of type debug is enabled.
        /// </summary>
        public override bool DebugIsEnabled
        {
            get
            {
                return debugIsEnabled;
            }

            set
            {
                debugIsEnabled = value;
            }
        }
        /// <summary>
        /// Get/Sets whether logging logs of type warning is enabled.
        /// </summary>
        public override bool WarningIsEnabled
        {
            get
            {
                return warningIsEnabled;
            }

            set
            {
                warningIsEnabled = value;
            }
        }
        /// <summary>
        /// Get/Sets whether logging logs of type error is enabled.
        /// </summary>
        public override bool ErrorIsEnabled
        {
            get
            {
                return errorIsEnabled;
            }

            set
            {
                errorIsEnabled = value;
            }
        }
        /// <summary>
        /// Get/Sets whether logging logs of type low error is enabled.
        /// </summary>
        public override bool LowErrorIsEnabled
        {
            get
            {
                return lowErrorIsEnabled;
            }

            set
            {
                lowErrorIsEnabled = value;
            }
        }
        /// <summary>
        /// Get/Sets whether logging logs of type medium error is enabled.
        /// </summary>
        public override bool MediumErrorIsEnabled
        {
            get
            {
                return mediumErrorIsEnabled;
            }

            set
            {
                mediumErrorIsEnabled = value;
            }
        }
        /// <summary>
        /// Get/Sets whether logging logs of type high error is enabled.
        /// </summary>
        public override bool HighErrorIsEnabled
        {
            get
            {
                return highErrorIsEnabled;
            }

            set
            {
                highErrorIsEnabled = value;
            }
        }
        /// <summary>
        /// Get/Sets whether logging logs of type extreme error is enabled.
        /// </summary>
        public override bool ExtremeErrorIsEnabled
        {
            get
            {
                return extremeErrorIsEnabled;
            }

            set
            {
                extremeErrorIsEnabled = value;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Configures logger.
        /// </summary>
        /// <param name="configurations">The available configurations.</param>
        public override void Configure(Dictionary<string, object> configurations)
        {

        }
        /// <summary>
        /// Logs an info log.
        /// </summary>
        /// <param name="message">The user message.</param>
        public override void LogInfo(string message)
        {
            try
            {
                if (InfoIsEnabled)
                {
                    EventLog.WriteEntry(Source, LogFormatter.GetLogMessage(message), EventLogEntryType.Information, EventId);
                }
            }
            catch (Exception ex)
            {
                throw new ExensibleLoggerException("Failed to log.", ex);
            }
        }
        /// <summary>
        /// Logs a debug log.
        /// </summary>
        /// <param name="message">The user message.</param>
        public override void LogDebug(string message)
        {
            try
            {
                if (DebugIsEnabled)
                {
                    EventLog.WriteEntry(Source, LogFormatter.GetLogMessage(message), EventLogEntryType.Information, EventId);
                }
            }
            catch (Exception ex)
            {
                throw new ExensibleLoggerException("Failed to log.", ex);
            }
        }
        /// <summary>
        /// Logs a warn log.
        /// </summary>
        /// <param name="message">The user message.</param>
        public override void LogWarning(string message)
        {
            try
            {
                if (WarningIsEnabled)
                {
                    EventLog.WriteEntry(Source, LogFormatter.GetLogMessage(message), EventLogEntryType.Warning, EventId);
                }
            }
            catch (Exception ex)
            {
                throw new ExensibleLoggerException("Failed to log.", ex);
            }
        }
        /// <summary>
        /// Logs an error log.
        /// </summary>
        /// <param name="severity">The error severity of the log.</param>
        /// <param name="message">The user message.</param>
        /// <param name="ex">The system exception.</param>
        public override void LogError(ErrorSeverity severity, string message, Exception ex)
        {
            try
            {
                if (ErrorIsEnabled)
                {
                    switch (severity)
                    {
                        case ErrorSeverity.Low:
                            if (LowErrorIsEnabled)
                            {
                                EventLog.WriteEntry(Source, LogFormatter.GetLogMessage(message, ex), EventLogEntryType.Error, EventId);
                            }

                            break;
                        case ErrorSeverity.Medium:
                            if (MediumErrorIsEnabled)
                            {
                                EventLog.WriteEntry(Source, LogFormatter.GetLogMessage(message, ex), EventLogEntryType.Error, EventId);
                            }

                            break;
                        case ErrorSeverity.High:
                            if (HighErrorIsEnabled)
                            {
                                EventLog.WriteEntry(Source, LogFormatter.GetLogMessage(message, ex), EventLogEntryType.Error, EventId);
                            }

                            break;
                        case ErrorSeverity.Extreme:
                            if (ExtremeErrorIsEnabled)
                            {
                                EventLog.WriteEntry(Source, LogFormatter.GetLogMessage(message, ex), EventLogEntryType.Error, EventId);
                            }

                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception exception)
            {
                throw new ExensibleLoggerException("Failed to log.", exception);
            }
        }
        /// <summary>
        /// Logs a method start log.
        /// </summary>
        /// <param name="header">The method header.</param>
        /// <param name="parametersNames">The method parameter names.</param>
        /// <param name="parametersValues">The method parameter values.</param>
        public override void LogMethodStart(string header, string[] parametersNames, object[] parametersValues)
        {
            try
            {
                if (InfoIsEnabled)
                {
                    EventLog.WriteEntry(Source, LogFormatter.GetMethodStartMessage(header, parametersNames, parametersValues), EventLogEntryType.Information, EventId);
                }
            }
            catch (Exception ex)
            {
                throw new ExensibleLoggerException("Failed in Log Method Start.", ex);
            }
        }
        /// <summary>
        /// Logs a method end log.
        /// </summary>
        /// <param name="header">The method header.</param>
        /// <param name="succeeded">Indicates whether the method ended successfully or in failure.</param>
        public override void LogMethodEnd(string header, bool succeeded)
        {
            try
            {
                if (InfoIsEnabled)
                {
                    EventLog.WriteEntry(Source, LogFormatter.GetMethodEndMessage(header, succeeded), EventLogEntryType.Information, EventId);
                }
            }
            catch (Exception ex)
            {
                throw new ExensibleLoggerException("Failed in Log Method End.", ex);
            }
        }
        #endregion
        #endregion
    }
}
