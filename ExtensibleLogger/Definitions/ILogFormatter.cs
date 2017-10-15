using System;

namespace DevelopmentSimplyPut.ExtensibleLoggerLibrary.Definitions
{
    /// <summary>
    /// Defines methods required to format a logger message.
    /// </summary>
    public interface ILogFormatter
    {
        #region Methods
        /// <summary>
        /// Gets a formatted log message from a user message.
        /// </summary>
        /// <param name="message">The user message.</param>
        /// <returns>The formatted log message.</returns>
        string GetLogMessage(string message);
        /// <summary>
        /// Gets a formatted log message from a system exception.
        /// </summary>
        /// <param name="exception">The system exception.</param>
        /// <returns>The formatted log message.</returns>
        string GetLogMessage(Exception exception);
        /// <summary>
        /// Gets a formatted log message from a user message and a system exception.
        /// </summary>
        /// <param name="message">The user message.</param>
        /// <param name="exception">The system exception.</param>
        /// <returns>The formatted log message.</returns>
        string GetLogMessage(string message, Exception exception);
        /// <summary>
        /// Gets a formatted log message for a method start.
        /// </summary>
        /// <param name="header">The method header.</param>
        /// <param name="parametersNames">The method parameter names.</param>
        /// <param name="parametersValues">The method parameter values.</param>
        /// <returns>The formatted log message.</returns>
        string GetMethodStartMessage(string header, string[] parametersNames, object[] parametersValues);
        /// <summary>
        /// Gets a formatted log message for a method end.
        /// </summary>
        /// <param name="header">The method header.</param>
        /// <param name="succeeded">Indicaing whether the method ended successfully or in failure.</param>
        /// <returns>The formatted log message.</returns>
        string GetMethodEndMessage(string header, bool succeeded);
        #endregion
    }
}
