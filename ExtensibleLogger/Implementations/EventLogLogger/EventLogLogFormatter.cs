using DevelopmentSimplyPut.ExtensibleLoggerLibrary.Definitions;
using System;
using System.Globalization;

namespace DevelopmentSimplyPut.ExtensibleLoggerLibrary.Implementations.EventLogLogger
{
    /// <summary>
    /// Represents a log formatter for the EventLog logger.
    /// </summary>
    public class EventLogLogFormatter : LogFormatterBase
    {
        #region LogFormatterBase Implementations
        /// <summary>
        /// Gets a formatted log message from a user message.
        /// </summary>
        /// <param name="message">The user message.</param>
        /// <returns>The formatted log message.</returns>
        public override string GetLogMessage(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                message = string.Empty;
            }

            return message;
        }
        /// <summary>
        /// Gets a formatted log message from a system exception.
        /// </summary>
        /// <param name="exception">The system exception.</param>
        /// <returns>The formatted log message.</returns>
        public override string GetLogMessage(Exception exception)
        {
            string finalMessage = string.Empty;

            if (exception != null)
            {
                finalMessage = string.Format(CultureInfo.InvariantCulture, "Exception: {0}. Stack Trace: {1}",
                    exception.Message.TrimEnd('.'),
                    (!string.IsNullOrEmpty(exception.StackTrace)) ? exception.StackTrace : string.Empty);
            }

            return finalMessage;

        }
        /// <summary>
        /// Gets a formatted log message from a user message and a system exception.
        /// </summary>
        /// <param name="message">The user message.</param>
        /// <param name="exception">The system exception.</param>
        /// <returns>The formatted log message.</returns>
        public override string GetLogMessage(string message, Exception exception)
        {
            string finalMessage = string.Empty;

            if (string.IsNullOrEmpty(message))
            {
                message = string.Empty;
            }

            finalMessage = message;

            if (exception != null)
            {
                finalMessage = string.Format(CultureInfo.InvariantCulture, "{0}. Exception: {1}. Stack Trace: {2}",
                    message.TrimEnd('.'),
                    exception.Message.TrimEnd('.'),
                    (!string.IsNullOrEmpty(exception.StackTrace)) ? exception.StackTrace : string.Empty);
            }

            return finalMessage;
        }
        /// <summary>
        /// Gets a formatted log message for a method start.
        /// </summary>
        /// <param name="header">The method header.</param>
        /// <param name="parametersNames">The method parameter names.</param>
        /// <param name="parametersValues">The method parameter values.</param>
        /// <returns>The formatted log message.</returns>
        public override string GetMethodStartMessage(string header, string[] parametersNames, object[] parametersValues)
        {
            string finalMessage = header + " method started";

            if (parametersNames != null && parametersValues != null)
            {
                finalMessage += " with parameters: ";

                try
                {
                    for (int i = 0; i < parametersNames.Length; i++)
                    {
                        if (i > 0)
                        {
                            finalMessage += ", ";
                        }

                        object currentValue = parametersValues[i];
                        finalMessage += parametersNames[i] + "=" + ((currentValue == null) ? "null" : currentValue.ToString());
                    }
                }
                catch
                {
                    //Neglect this parameter.
                }
            }

            return finalMessage;
        }
        /// <summary>
        /// Gets a formatted log message for a method end.
        /// </summary>
        /// <param name="header">The method header.</param>
        /// <param name="succeeded">Indicaing whether the method ended successfully or in failure.</param>
        /// <returns>The formatted log message.</returns>
        public override string GetMethodEndMessage(string header, bool succeeded)
        {
            string finalMessage = header + " ended ";

            if (succeeded)
            {
                finalMessage += "successfully.";
            }
            else
            {
                finalMessage += "in failure.";
            }

            return finalMessage;
        }
        #endregion
    }
}
