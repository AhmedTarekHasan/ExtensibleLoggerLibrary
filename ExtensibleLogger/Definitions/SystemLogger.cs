using System;
using System.Collections.Generic;

namespace DevelopmentSimplyPut.ExtensibleLoggerLibrary.Definitions
{
    /// <summary>
    /// Represents the main system logger.
    /// </summary>
    public class SystemLogger : ILogger
    {
        #region Fields
        private bool debugIsEnabled;
        private bool errorIsEnabled;
        private bool extremeErrorIsEnabled;
        private bool highErrorIsEnabled;
        private bool infoIsEnabled;
        private bool lowErrorIsEnabled;
        private bool mediumErrorIsEnabled;
        private bool warningIsEnabled;
        #endregion

        #region Properties
        /// <summary>
        /// Gets/Sets the logger manager.
        /// </summary>
        public ILoggerManager LoggerManager { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the SystemLogger class.
        /// </summary>
        /// <param name="loggerManager">The logger manager.</param>
        public SystemLogger(ILoggerManager loggerManager)
        {
            if (loggerManager == null)
            {
                throw new ArgumentNullException("loggerManager");
            }

            LoggerManager = loggerManager;
        }
        #endregion

        #region ILogger Implementations
        #region Properties
        /// <summary>
        /// Get/Sets whether logging logs of type info is enabled.
        /// </summary>
        public bool InfoIsEnabled
        {
            get
            {
                return infoIsEnabled;
            }

            set
            {
                infoIsEnabled = value;
                ApplyOnLoggers((ILogger logger) => { logger.InfoIsEnabled = value; });
            }
        }
        /// <summary>
        /// Get/Sets whether logging logs of type debug is enabled.
        /// </summary>
        public bool DebugIsEnabled
        {
            get
            {
                return debugIsEnabled;
            }

            set
            {
                debugIsEnabled = value;
                ApplyOnLoggers((ILogger logger) => { logger.DebugIsEnabled = value; });
            }
        }
        /// <summary>
        /// Get/Sets whether logging logs of type warning is enabled.
        /// </summary>
        public bool WarningIsEnabled
        {
            get
            {
                return warningIsEnabled;
            }

            set
            {
                warningIsEnabled = value;
                ApplyOnLoggers((ILogger logger) => { logger.WarningIsEnabled = value; });
            }
        }
        /// <summary>
        /// Get/Sets whether logging logs of type error is enabled.
        /// </summary>
        public bool ErrorIsEnabled
        {
            get
            {
                return errorIsEnabled;
            }

            set
            {
                errorIsEnabled = value;
                ApplyOnLoggers((ILogger logger) => { logger.ErrorIsEnabled = value; });
            }
        }
        /// <summary>
        /// Get/Sets whether logging logs of type low error is enabled.
        /// </summary>
        public bool LowErrorIsEnabled
        {
            get
            {
                return lowErrorIsEnabled;
            }

            set
            {
                lowErrorIsEnabled = value;
                ApplyOnLoggers((ILogger logger) => { logger.LowErrorIsEnabled = value; });
            }
        }
        /// <summary>
        /// Get/Sets whether logging logs of type medium error is enabled.
        /// </summary>
        public bool MediumErrorIsEnabled
        {
            get
            {
                return mediumErrorIsEnabled;
            }

            set
            {
                mediumErrorIsEnabled = value;
                ApplyOnLoggers((ILogger logger) => { logger.MediumErrorIsEnabled = value; });
            }
        }
        /// <summary>
        /// Get/Sets whether logging logs of type high error is enabled.
        /// </summary>
        public bool HighErrorIsEnabled
        {
            get
            {
                return highErrorIsEnabled;
            }

            set
            {
                highErrorIsEnabled = value;
                ApplyOnLoggers((ILogger logger) => { logger.HighErrorIsEnabled = value; });
            }
        }
        /// <summary>
        /// Get/Sets whether logging logs of type extreme error is enabled.
        /// </summary>
        public bool ExtremeErrorIsEnabled
        {
            get
            {
                return extremeErrorIsEnabled;
            }

            set
            {
                extremeErrorIsEnabled = value;
                ApplyOnLoggers((ILogger logger) => { logger.ExtremeErrorIsEnabled = value; });
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Configures logger.
        /// </summary>
        /// <param name="configurations">The available configurations.</param>
        public void Configure(Dictionary<string, object> configurations)
        {
            ApplyOnLoggers((ILogger logger) => { logger.Configure(configurations); });
        }
        /// <summary>
        /// Logs a generic log.
        /// </summary>
        /// <param name="type">The tpe of the log.</param>
        /// <param name="severity">The error severity of the log in case of error log.</param>
        /// <param name="message">The user message.</param>
        public void Log(IncidentType type, ErrorSeverity severity, string message)
        {
            ApplyOnLoggers((ILogger logger) => { logger.Log(type, severity, message); });
        }
        /// <summary>
        /// Logs a generic log.
        /// </summary>
        /// <param name="type">The tpe of the log.</param>
        /// <param name="severity">The error severity of the log in case of error log.</param>
        /// <param name="ex">The system exception.</param>
        public void Log(IncidentType type, ErrorSeverity severity, Exception ex)
        {
            ApplyOnLoggers((ILogger logger) => { logger.Log(type, severity, ex); });
        }
        /// <summary>
        /// Logs a generic log.
        /// </summary>
        /// <param name="type">The tpe of the log.</param>
        /// <param name="severity">The error severity of the log in case of error log.</param>
        /// <param name="message">The user message.</param>
        /// <param name="ex">The system exception.</param>
        public void Log(IncidentType type, ErrorSeverity severity, string message, Exception ex)
        {
            ApplyOnLoggers((ILogger logger) => { logger.Log(type, severity, message, ex); });
        }
        /// <summary>
        /// Logs an info log.
        /// </summary>
        /// <param name="message">The user message.</param>
        public void LogInfo(string message)
        {
            ApplyOnLoggers((ILogger logger) => { logger.LogInfo(message); });
        }
        /// <summary>
        /// Logs a debug log.
        /// </summary>
        /// <param name="message">The user message.</param>
        public void LogDebug(string message)
        {
            ApplyOnLoggers((ILogger logger) => { logger.LogDebug(message); });
        }
        /// <summary>
        /// Logs a warn log.
        /// </summary>
        /// <param name="message">The user message.</param>
        public void LogWarning(string message)
        {
            ApplyOnLoggers((ILogger logger) => { logger.LogWarning(message); });
        }
        /// <summary>
        /// Logs an error log.
        /// </summary>
        /// <param name="severity">The error severity of the log.</param>
        /// <param name="message">The user message.</param>
        public void LogError(ErrorSeverity severity, string message)
        {
            ApplyOnLoggers((ILogger logger) => { logger.LogError(severity, message); });
        }
        /// <summary>
        /// Logs an error log.
        /// </summary>
        /// <param name="severity">The error severity of the log.</param>
        /// <param name="ex">The system exception.</param>
        public void LogError(ErrorSeverity severity, Exception ex)
        {
            ApplyOnLoggers((ILogger logger) => { logger.LogError(severity, ex); });
        }
        /// <summary>
        /// Logs an error log.
        /// </summary>
        /// <param name="severity">The error severity of the log.</param>
        /// <param name="message">The user message.</param>
        /// <param name="ex">The system exception.</param>
        public void LogError(ErrorSeverity severity, string message, Exception ex)
        {
            ApplyOnLoggers((ILogger logger) => { logger.LogError(severity, message, ex); });
        }
        /// <summary>
        /// Logs a method start log.
        /// </summary>
        /// <param name="header">The method header.</param>
        /// <param name="parametersNames">The method parameter names.</param>
        /// <param name="parametersValues">The method parameter values.</param>
        public void LogMethodStart(string header, string[] parametersNames, object[] parametersValues)
        {
            ApplyOnLoggers((ILogger logger) => { logger.LogMethodStart(header, parametersNames, parametersValues); });
        }
        /// <summary>
        /// Logs a method end log.
        /// </summary>
        /// <param name="header">The method header.</param>
        /// <param name="succeeded">Indicates whether the method ended successfully or in failure.</param>
        public void LogMethodEnd(string header, bool succeeded)
        {
            ApplyOnLoggers((ILogger logger) => { logger.LogMethodEnd(header, succeeded); });
        }
        #endregion
        #endregion

        #region Helpers
        /// <summary>
        /// Iterates through the list of loggers and applies the provided action on each of them.
        /// </summary>
        /// <param name="action">The action to apply.</param>
        private void ApplyOnLoggers(Action<ILogger> action)
        {
            if (LoggerManager != null && action != null)
            {
                if (LoggerManager.Loggers != null && LoggerManager.Loggers.Count > 0)
                {
                    foreach (LoggerAvailability loggerAvailability in LoggerManager.Loggers.Values)
                    {
                        if (loggerAvailability != null && loggerAvailability.Logger != null)
                        {
                            action(loggerAvailability.Logger);
                        }
                    }
                }
            }
        }
        #endregion
    }
}
