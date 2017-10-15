using System;

namespace DevelopmentSimplyPut.ExtensibleLoggerLibrary.Definitions
{
    /// <summary>
    /// Represents errors that occur during application execution.
    /// </summary>
    public class ExensibleLoggerException : Exception
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the ExensibleLoggerException class.
        /// </summary>
        public ExensibleLoggerException() : base()
        {
        }
        /// <summary>
        /// Initializes a new instance of the ExensibleLoggerException class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ExensibleLoggerException(string message) : base(message)
        {
        }
        /// <summary>
        /// Initializes a new instance of the ExensibleLoggerException class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public ExensibleLoggerException(string message, Exception innerException) : base(message, innerException)
        {
        }
        #endregion
    }
}
