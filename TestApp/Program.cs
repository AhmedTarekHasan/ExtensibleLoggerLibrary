using DevelopmentSimplyPut.ExtensibleLoggerLibrary.Definitions;
using DevelopmentSimplyPut.ExtensibleLoggerLibrary.Implementations.EventLogLogger;
using DevelopmentSimplyPut.ExtensibleLoggerLibrary.Implementations.Log4NetLogger;
using System;
using System.Collections.Generic;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ILoggerManager loggerManager = new LoggerManager();

            Dictionary<string, object> settings = new Dictionary<string, object>();
            settings.Add("Log4Net.ConversionPattern", "%date [%thread] %-5level %logger - %message%newline");
            settings.Add("Log4Net.MaximumFileSize", "1MB");
            settings.Add("Log4Net.MaxSizeRollBackups", 5);
            settings.Add("Log4Net.File", @"d:\Log4NetLogger.txt");

            ILogger log4NetLogger = new Log4NetLogger("Log4NetLogger");     
            log4NetLogger.Configure(settings);
            loggerManager.AddLogger("Log4NetLogger", log4NetLogger);

            ILogger eventLogLogger = new EventLogLogger("TestApp", "Application", 400, null);
            loggerManager.AddLogger("EventLogLogger", eventLogLogger);

            SystemLogger systemLogger = new SystemLogger(loggerManager);
            systemLogger.LogInfo("This is my first info log.");
            systemLogger.LogDebug("This is my first debug log.");
            systemLogger.LogWarning("This is my first warning log.");
            systemLogger.LogError(ErrorSeverity.Low, "This is my first low error log.", new Exception("This is my first low error log."));
            systemLogger.LogError(ErrorSeverity.Medium, "This is my first medium error log.", new Exception("This is my first medium error log."));
            systemLogger.LogError(ErrorSeverity.High, "This is my first high error log.", new Exception("This is my first high error log."));
            systemLogger.LogError(ErrorSeverity.Extreme, "This is my first extreme error log.", new Exception("This is my first extreme error log."));
            systemLogger.LogMethodStart("static void Main(string[] args)", new string[] { "args" }, new object[] { args });
            systemLogger.LogMethodEnd("static void Main(string[] args)", true);
            systemLogger.LogMethodEnd("static void Main(string[] args)", false);
        }
    }
}
