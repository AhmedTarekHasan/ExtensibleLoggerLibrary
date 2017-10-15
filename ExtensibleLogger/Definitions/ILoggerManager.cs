using System;
using System.Collections.Generic;

namespace DevelopmentSimplyPut.ExtensibleLoggerLibrary.Definitions
{
    /// <summary>
    /// Defines the members required for a logger manager.
    /// </summary>
    public interface ILoggerManager
    {
        #region Properties
        /// <summary>
        /// Gets a list of the defined loggers.
        /// </summary>
        Dictionary<string, LoggerAvailability> Loggers { get; }
        #endregion

        #region Methods
        /// <summary>
        /// Adds a logger to the loggers list.
        /// </summary>
        /// <param name="id">The logger id.</param>
        /// <param name="logger">The logger.</param>
        /// <returns>The added logger with its availability.</returns>
        LoggerAvailability AddLogger(string id, ILogger logger);
        /// <summary>
        /// Removes a logger from the loggers list.
        /// </summary>
        /// <param name="id">The logger id.</param>
        void RemoveLogger(string id);
        /// <summary>
        /// Remove loggers form the loggers list.
        /// </summary>
        /// <param name="predicate">The predicate to be used to determine the loggers to be removed.</param>
        void RemoveLoggers(Func<LoggerAvailability, bool> predicate);
        /// <summary>
        /// Enables a logger.
        /// </summary>
        /// <param name="id">The logger id.</param>
        void EnableLogger(string id);
        /// <summary>
        /// Enables loggers.
        /// </summary>
        /// <param name="predicate">The predicate to be used to determine the loggers to be enabled.</param>
        void EnableLoggers(Func<LoggerAvailability, bool> predicate);
        /// <summary>
        /// Disables a logger.
        /// </summary>
        /// <param name="id">The logger id.</param>
        void DisableLogger(string id);
        /// <summary>
        /// Disables loggers.
        /// </summary>
        /// <param name="predicate">The predicate to be used to determine the loggers to be disabled.</param>
        void DisableLoggers(Func<LoggerAvailability, bool> predicate);
        #endregion
    }

    /// <summary>
    /// Represents the logger availability.
    /// </summary>
    public class LoggerAvailability
    {
        #region Properties
        /// <summary>
        /// Gets/Sets the logger.
        /// </summary>
        public ILogger Logger { get; set; }
        /// <summary>
        /// Gets/Sets the logger availability.
        /// </summary>
        public bool IsAvailable { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes an instance of the LoggerAvailability class.
        /// </summary>
        public LoggerAvailability() : this(null, false)
        {

        }
        /// <summary>
        /// Initializes an instance of the LoggerAvailability class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public LoggerAvailability(ILogger logger):this(logger, true)
        {

        }
        /// <summary>
        /// Initializes an instance of the LoggerAvailability class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="isAvailable">The availability.</param>
        public LoggerAvailability(ILogger logger, bool isAvailable)
        {
            Logger = logger;
            IsAvailable = isAvailable;
        }
        #endregion
    }
}
