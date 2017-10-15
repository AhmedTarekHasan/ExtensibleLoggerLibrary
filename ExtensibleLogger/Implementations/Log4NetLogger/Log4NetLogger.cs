using System;
using System.Collections.Generic;
using log4net;
using log4net.Config;
using DevelopmentSimplyPut.ExtensibleLoggerLibrary.Definitions;
using log4net.Repository.Hierarchy;
using log4net.Layout;
using log4net.Appender;
using log4net.Core;

namespace DevelopmentSimplyPut.ExtensibleLoggerLibrary.Implementations.Log4NetLogger
{
    /// <summary>
    /// Represents a Log4Net logger. 
    /// </summary>
    public class Log4NetLogger : LoggerBase
    {
        #region Fields
        private ILog logger;
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
                    logFormatter = new Log4NetLoggerLogFormatter();
                }
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the Log4NetLogger class.
        /// </summary>
        /// <param name="log4netAppenderName">The appender name.</param>
        public Log4NetLogger(string log4netAppenderName) : this(log4netAppenderName, null)
        {
        }
        /// <summary>
        /// Initializes a new instance of the Log4NetLogger class.
        /// </summary>
        /// <param name="log4netAppenderName">The appender name.</param>
        /// <param name="logFormatter">The log formatter.</param>
        public Log4NetLogger(string log4netAppenderName, ILogFormatter logFormatter)
        {
            logger = LogManager.GetLogger(log4netAppenderName);
            LogFormatter = logFormatter;
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
            try
            {
                XmlConfigurator.Configure();

                //if configuration doesn't exist in the config files, fall back to the manual config
                if (!LogManager.GetRepository().Configured)
                {
                    string conversionPattern = null;
                    string file = null;
                    int maxSizeRollBackups = -1;
                    string maximumFileSize = null;

                    if (configurations != null && configurations.Count > 0)
                    {
                        if (configurations.ContainsKey("Log4Net.ConversionPattern"))
                        {
                            conversionPattern = configurations["Log4Net.ConversionPattern"].ToString();
                        }

                        if (configurations.ContainsKey("Log4Net.File"))
                        {
                            file = configurations["Log4Net.File"].ToString();
                        }

                        if (configurations.ContainsKey("Log4Net.MaxSizeRollBackups"))
                        {
                            maxSizeRollBackups = (int)configurations["Log4Net.MaxSizeRollBackups"];
                        }

                        if (configurations.ContainsKey("Log4Net.MaximumFileSize"))
                        {
                            maximumFileSize = configurations["Log4Net.MaximumFileSize"].ToString();
                        }
                    }

                    Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();

                    PatternLayout patternLayout = new PatternLayout();
                    patternLayout.ConversionPattern = conversionPattern;
                    patternLayout.ActivateOptions();

                    RollingFileAppender roller = new RollingFileAppender();
                    roller.AppendToFile = true;
                    roller.File = file;
                    roller.Layout = patternLayout;
                    roller.MaxSizeRollBackups = maxSizeRollBackups;
                    roller.MaximumFileSize = maximumFileSize;
                    roller.RollingStyle = RollingFileAppender.RollingMode.Size;
                    roller.StaticLogFileName = true;
                    roller.ActivateOptions();
                    hierarchy.Root.AddAppender(roller);

                    ConsoleAppender console = new ConsoleAppender();
                    console.Layout = patternLayout;
                    console.ActivateOptions();
                    hierarchy.Root.AddAppender(console);
                    hierarchy.Root.Level = Level.Debug;
                    hierarchy.Configured = true;
                }
            }
            catch (Exception ex)
            {
                throw new ExensibleLoggerException("Failed to configure logger.", ex);
            }
        }
        /// <summary>
        /// Logs an info log.
        /// </summary>
        /// <param name="message">The user message.</param>
        public override void LogInfo(string message)
        {
            try
            {
                if (InfoIsEnabled && logger.IsInfoEnabled)
                {
                    logger.Info(LogFormatter.GetLogMessage(message));
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
                if (DebugIsEnabled && logger.IsDebugEnabled)
                {
                    logger.Debug(LogFormatter.GetLogMessage(message));
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
                if (WarningIsEnabled && logger.IsWarnEnabled)
                {
                    logger.Warn(LogFormatter.GetLogMessage(message));
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
                if (ErrorIsEnabled && logger.IsErrorEnabled)
                {
                    message = LogFormatter.GetLogMessage(message);

                    switch (severity)
                    {
                        case ErrorSeverity.Low:
                            if (LowErrorIsEnabled)
                            {
                                if (ex != null)
                                {
                                    logger.Error(message, ex);
                                }
                                else
                                {
                                    logger.Error(message);
                                }
                            }

                            break;
                        case ErrorSeverity.Medium:
                            if (MediumErrorIsEnabled)
                            {
                                if (ex != null)
                                {
                                    logger.Error(message, ex);
                                }
                                else
                                {
                                    logger.Error(message);
                                }
                            }

                            break;
                        case ErrorSeverity.High:
                            if (HighErrorIsEnabled)
                            {
                                if (ex != null)
                                {
                                    logger.Fatal(message, ex);
                                }
                                else
                                {
                                    logger.Fatal(message);
                                }
                            }

                            break;
                        case ErrorSeverity.Extreme:
                            if (ExtremeErrorIsEnabled)
                            {
                                if (ex != null)
                                {
                                    logger.Fatal(message, ex);
                                }
                                else
                                {
                                    logger.Fatal(message);
                                }
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
                if (InfoIsEnabled && logger.IsInfoEnabled)
                {
                    logger.Info(LogFormatter.GetMethodStartMessage(header, parametersNames, parametersValues));
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
                if (InfoIsEnabled && logger.IsInfoEnabled)
                {
                    logger.Info(LogFormatter.GetMethodEndMessage(header, succeeded));
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
