using System;
using System.Collections.Generic;

namespace DevelopmentSimplyPut.ExtensibleLoggerLibrary.Definitions
{
    /// <summary>
    /// Defines members required for a logger.
    /// </summary>
    public interface ILogger
    {
        #region Properties
        /// <summary>
        /// Get/Sets whether logging logs of type info is enabled.
        /// </summary>
        bool InfoIsEnabled { get; set; }
        /// <summary>
        /// Get/Sets whether logging logs of type debug is enabled.
        /// </summary>
        bool DebugIsEnabled { get; set; }
        /// <summary>
        /// Get/Sets whether logging logs of type warning is enabled.
        /// </summary>
        bool WarningIsEnabled { get; set; }
        /// <summary>
        /// Get/Sets whether logging logs of type error is enabled.
        /// </summary>
        bool ErrorIsEnabled { get; set; }
        /// <summary>
        /// Get/Sets whether logging logs of type low error is enabled.
        /// </summary>
        bool LowErrorIsEnabled { get; set; }
        /// <summary>
        /// Get/Sets whether logging logs of type medium error is enabled.
        /// </summary>
        bool MediumErrorIsEnabled { get; set; }
        /// <summary>
        /// Get/Sets whether logging logs of type high error is enabled.
        /// </summary>
        bool HighErrorIsEnabled { get; set; }
        /// <summary>
        /// Get/Sets whether logging logs of type extreme error is enabled.
        /// </summary>
        bool ExtremeErrorIsEnabled { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Configures logger.
        /// </summary>
        /// <param name="configurations">The available configurations.</param>
        void Configure(Dictionary<string, object> configurations);
        /// <summary>
        /// Logs a generic log.
        /// </summary>
        /// <param name="type">The tpe of the log.</param>
        /// <param name="severity">The error severity of the log in case of error log.</param>
        /// <param name="message">The user message.</param>
        void Log(IncidentType type, ErrorSeverity severity, string message);
        /// <summary>
        /// Logs a generic log.
        /// </summary>
        /// <param name="type">The tpe of the log.</param>
        /// <param name="severity">The error severity of the log in case of error log.</param>
        /// <param name="ex">The system exception.</param>
        void Log(IncidentType type, ErrorSeverity severity, Exception ex);
        /// <summary>
        /// Logs a generic log.
        /// </summary>
        /// <param name="type">The tpe of the log.</param>
        /// <param name="severity">The error severity of the log in case of error log.</param>
        /// <param name="message">The user message.</param>
        /// <param name="ex">The system exception.</param>
        void Log(IncidentType type, ErrorSeverity severity, string message, Exception ex);
        /// <summary>
        /// Logs an info log.
        /// </summary>
        /// <param name="message">The user message.</param>
        void LogInfo(string message);
        /// <summary>
        /// Logs a debug log.
        /// </summary>
        /// <param name="message">The user message.</param>
        void LogDebug(string message);
        /// <summary>
        /// Logs a warn log.
        /// </summary>
        /// <param name="message">The user message.</param>
        void LogWarning(string message);
        /// <summary>
        /// Logs an error log.
        /// </summary>
        /// <param name="severity">The error severity of the log.</param>
        /// <param name="message">The user message.</param>
        void LogError(ErrorSeverity severity, string message);
        /// <summary>
        /// Logs an error log.
        /// </summary>
        /// <param name="severity">The error severity of the log.</param>
        /// <param name="ex">The system exception.</param>
        void LogError(ErrorSeverity severity, Exception ex);
        /// <summary>
        /// Logs an error log.
        /// </summary>
        /// <param name="severity">The error severity of the log.</param>
        /// <param name="message">The user message.</param>
        /// <param name="ex">The system exception.</param>
        void LogError(ErrorSeverity severity, string message, Exception ex);
        /// <summary>
        /// Logs a method start log.
        /// </summary>
        /// <param name="header">The method header.</param>
        /// <param name="parametersNames">The method parameter names.</param>
        /// <param name="parametersValues">The method parameter values.</param>
        void LogMethodStart(string header, string[] parametersNames, object[] parametersValues);
        /// <summary>
        /// Logs a method end log.
        /// </summary>
        /// <param name="header">The method header.</param>
        /// <param name="succeeded">Indicates whether the method ended successfully or in failure.</param>
        void LogMethodEnd(string header, bool succeeded);       
        #endregion
    }
}
