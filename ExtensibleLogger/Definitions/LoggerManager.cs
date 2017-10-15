using System;
using System.Collections.Generic;
using System.Linq;

namespace DevelopmentSimplyPut.ExtensibleLoggerLibrary.Definitions
{
    /// <summary>
    /// Represents the base implementation of the ILoggerManager interface.
    /// </summary>
    public class LoggerManager : ILoggerManager
    {
        #region Fields
        private Dictionary<string, LoggerAvailability> loggers = new Dictionary<string, LoggerAvailability>();
        #endregion

        #region ILoggerManager Implementaions
        #region Properties
        /// <summary>
        /// Gets a list of the defined loggers.
        /// </summary>
        public virtual Dictionary<string, LoggerAvailability> Loggers
        {
            get
            {
                return loggers;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Adds a logger to the loggers list.
        /// </summary>
        /// <param name="id">The logger id.</param>
        /// <param name="logger">The logger.</param>
        /// <returns>The added logger with its availability.</returns>
        public virtual LoggerAvailability AddLogger(string id, ILogger logger)
        {
            LoggerAvailability added = null;

            if (Loggers.ContainsKey(id))
            {
                throw new ExensibleLoggerException("A logger with the same key already exists.");
            }

            if (logger != null)
            {
                added = new LoggerAvailability(logger, true);
                Loggers.Add(id, added);
            }

            return added;
        }
        /// <summary>
        /// Removes a logger from the loggers list.
        /// </summary>
        /// <param name="id">The logger id.</param>
        public virtual void RemoveLogger(string id)
        {
            if (Loggers.ContainsKey(id))
            {
                Loggers.Remove(id);
            }
        }
        /// <summary>
        /// Remove loggers form the loggers list.
        /// </summary>
        /// <param name="predicate">The predicate to be used to determine the loggers to be removed.</param>
        public virtual void RemoveLoggers(Func<LoggerAvailability, bool> predicate)
        {
            if (predicate != null)
            {
                KeyValuePair<string, LoggerAvailability> pair;

                for (int i = Loggers.Count - 1; i >= 0; i--)
                {
                    pair = Loggers.ElementAt(i);

                    if (predicate(pair.Value))
                    {
                        Loggers.Remove(pair.Key);
                    }
                }
            }
        }
        /// <summary>
        /// Enables a logger.
        /// </summary>
        /// <param name="id">The logger id.</param>
        public virtual void EnableLogger(string id)
        {
            EnableDisableLogger(id, true);
        }
        /// <summary>
        /// Enables loggers.
        /// </summary>
        /// <param name="predicate">The predicate to be used to determine the loggers to be enabled.</param>
        public virtual void EnableLoggers(Func<LoggerAvailability, bool> predicate)
        {
            EnableDisableLogger(predicate, true);
        }
        /// <summary>
        /// Disables a logger.
        /// </summary>
        /// <param name="id">The logger id.</param>
        public virtual void DisableLogger(string id)
        {
            EnableDisableLogger(id, false);
        }
        /// <summary>
        /// Disables loggers.
        /// </summary>
        /// <param name="predicate">The predicate to be used to determine the loggers to be disabled.</param>
        public virtual void DisableLoggers(Func<LoggerAvailability, bool> predicate)
        {
            EnableDisableLogger(predicate, false);
        }
        #endregion
        #endregion

        #region Helpers
        /// <summary>
        /// Enables/Disables a logger.
        /// </summary>
        /// <param name="id">The logger id.</param>
        /// <param name="shouldEnable">Whether to enable or disable the logger.</param>
        private void EnableDisableLogger(string id, bool shouldEnable)
        {
            if (Loggers.ContainsKey(id))
            {
                EnableDisableLogger(Loggers[id], shouldEnable);
            }
        }
        /// <summary>
        /// Enables/Disables a logger.
        /// </summary>
        /// <param name="predicate">The predicate to be used to determine the loggers to be enabled/disabled.</param>
        /// <param name="shouldEnable">Whether to enable or disable the logger.</param>
        private void EnableDisableLogger(Func<LoggerAvailability, bool> predicate, bool shouldEnable)
        {
            if (predicate != null)
            {
                foreach (KeyValuePair<string, LoggerAvailability> pair in Loggers)
                {
                    if (predicate(pair.Value))
                    {
                        EnableDisableLogger(pair.Value, shouldEnable);
                    }
                }
            }
        }
        /// <summary>
        /// Enables/Disables a logger.
        /// </summary>
        /// <param name="loggerAvailability">The logger availability.</param>
        /// <param name="shouldEnable">Whether to enable or disable the logger.</param>
        private void EnableDisableLogger(LoggerAvailability loggerAvailability, bool shouldEnable)
        {
            if (loggerAvailability != null)
            {
                loggerAvailability.IsAvailable = shouldEnable;
            }
        }
        #endregion
    }
}
