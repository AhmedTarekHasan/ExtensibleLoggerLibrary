# Extensible Logger Library

<p align="center">
  <img src="https://i.imgur.com/edKK4GF.png">
</p>

<br/>

This is a logging library which can be extended by new logging libraries and wrappers to be used on .NET applications to log all kind of log entries.

<br/>

## Already Defined Loggers:
* Log4Net
* EventLog

<br/>

## Features:
* Create your own loggers or use already defined
* Add multiple concurrent loggers at runtime
* Enable/disable loggers at runtime

<br/>

## Design Aspects:
* SOLID principles
* Separation of concerns
* Extensible

<br/>

## How To Use:
```c#
ILoggerManager loggerManager = new LoggerManager();
SystemLogger systemLogger = new SystemLogger(loggerManager);

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
```

<br/>

## Results:
<p align="center"><img src="https://i.imgur.com/65yx2Qa.png"></p>
<p align="center"><img src="https://i.imgur.com/prN0TaX.png"></p>
<p align="center"><img src="https://i.imgur.com/rcvj7HR.png"></p>
<p align="center"><img src="https://i.imgur.com/q0LudFN.png"></p>
<p align="center"><img src="https://i.imgur.com/3H2sROE.png"></p>
<p align="center"><img src="https://i.imgur.com/5Itzs32.png"></p>
<p align="center"><img src="https://i.imgur.com/rPHSjvm.png"></p>
<p align="center"><img src="https://i.imgur.com/vhJnAIN.png"></p>
<p align="center"><img src="https://i.imgur.com/yQQCmeM.png"></p>
<p align="center"><img src="https://i.imgur.com/2PIdozP.png"></p>
<p align="center"><img src="https://i.imgur.com/IZFnxFB.png"></p>

<br/>

## Authors:
* [Ahmed Tarek Hasan](https://linkedin.com/in/atarekhasan)
