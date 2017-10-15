using System;
using System.Collections.Generic;

namespace DevelopmentSimplyPut.ExtensibleLoggerLibrary.Definitions
{
    /// <summary>
    /// Represents the base implementation of the ILogger interface.
    /// </summary>
    public abstract class LoggerBase : ILogger
    {
        #region Properties
        /// <summary>
        /// Get/Sets whether logging logs of type info is enabled.
        /// </summary>
        public abstract bool InfoIsEnabled { get; set; }
        /// <summary>
        /// Get/Sets whether logging logs of type debug is enabled.
        /// </summary>
        public abstract bool DebugIsEnabled { get; set; }
        /// <summary>
        /// Get/Sets whether logging logs of type warning is enabled.
        /// </summary>
        public abstract bool WarningIsEnabled { get; set; }
        /// <summary>
        /// Get/Sets whether logging logs of type error is enabled.
        /// </summary>
        public abstract bool ErrorIsEnabled { get; set; }
        /// <summary>
        /// Get/Sets whether logging logs of type low error is enabled.
        /// </summary>
        public abstract bool LowErrorIsEnabled { get; set; }
        /// <summary>
        /// Get/Sets whether logging logs of type medium error is enabled.
        /// </summary>
        public abstract bool MediumErrorIsEnabled { get; set; }
        /// <summary>
        /// Get/Sets whether logging logs of type high error is enabled.
        /// </summary>
        public abstract bool HighErrorIsEnabled { get; set; }
        /// <summary>
        /// Get/Sets whether logging logs of type extreme error is enabled.
        /// </summary>
        public abstract bool ExtremeErrorIsEnabled { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Configures logger.
        /// </summary>
        /// <param name="configurations">The available configurations.</param>
        public abstract void Configure(Dictionary<string, object> configurations);
        /// <summary>
        /// Logs a generic log.
        /// </summary>
        /// <param name="type">The tpe of the log.</param>
        /// <param name="severity">The error severity of the log in case of error log.</param>
        /// <param name="message">The user message.</param>
        public virtual void Log(IncidentType type, ErrorSeverity severity, string message)
        {
            Log(type, severity, message, null);
        }
        /// <summary>
        /// Logs a generic log.
        /// </summary>
        /// <param name="type">The tpe of the log.</param>
        /// <param name="severity">The error severity of the log in case of error log.</param>
        /// <param name="ex">The system exception.</param>
        public virtual void Log(IncidentType type, ErrorSeverity severity, Exception ex)
        {
            Log(type, severity, null, ex);
        }
        /// <summary>
        /// Logs a generic log.
        /// </summary>
        /// <param name="type">The tpe of the log.</param>
        /// <param name="severity">The error severity of the log in case of error log.</param>
        /// <param name="message">The user message.</param>
        /// <param name="ex">The system exception.</param>
        public virtual void Log(IncidentType type, ErrorSeverity severity, string message, Exception ex)
        {
            switch (type)
            {
                case IncidentType.Info:
                    LogInfo(message);
                    break;
                case IncidentType.Debug:
                    LogDebug(message);
                    break;
                case IncidentType.Warning:
                    LogWarning(message);
                    break;
                case IncidentType.Error:
                    LogError(severity, message, ex);
                    break;
                default:
                    break;
            }
        }       
        /// <summary>
        /// Logs an info log.
        /// </summary>
        /// <param name="message">The user message.</param>
        public abstract void LogInfo(string message);
        /// <summary>
        /// Logs a debug log.
        /// </summary>
        /// <param name="message">The user message.</param>
        public abstract void LogDebug(string message);
        /// <summary>
        /// Logs a warn log.
        /// </summary>
        /// <param name="message">The user message.</param>
        public abstract void LogWarning(string message);
        /// <summary>
        /// Logs an error log.
        /// </summary>
        /// <param name="severity">The error severity of the log.</param>
        /// <param name="message">The user message.</param>
        public virtual void LogError(ErrorSeverity severity, string message)
        {
            LogError(severity, message);
        }
        /// <summary>
        /// Logs an error log.
        /// </summary>
        /// <param name="severity">The error severity of the log.</param>
        /// <param name="ex">The system exception.</param>
        public virtual void LogError(ErrorSeverity severity, Exception ex)
        {
            LogError(severity, ex);
        }
        /// <summary>
        /// Logs an error log.
        /// </summary>
        /// <param name="severity">The error severity of the log.</param>
        /// <param name="message">The user message.</param>
        /// <param name="ex">The system exception.</param>
        public abstract void LogError(ErrorSeverity severity, string message, Exception ex);
        /// <summary>
        /// Logs a method start log.
        /// </summary>
        /// <param name="header">The method header.</param>
        /// <param name="parametersNames">The method parameter names.</param>
        /// <param name="parametersValues">The method parameter values.</param>
        public abstract void LogMethodStart(string header, string[] parametersNames, object[] parametersValues);
        /// <summary>
        /// Logs a method end log.
        /// </summary>
        /// <param name="header">The method header.</param>
        /// <param name="succeeded">Indicates whether the method ended successfully or in failure.</param>
        public abstract void LogMethodEnd(string header, bool succeeded);
        #endregion
    }
}
