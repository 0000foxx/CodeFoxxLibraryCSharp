using System;
using NLog;

namespace LogLibrary
{
    public class LogManager
    {

        private static ILogger sLogger = null;

        static LogManager()
        {
            SetupNLogConfig();
        }

        static void SetupNLogConfig()
        {
            var config = new NLog.Config.LoggingConfiguration();

            var logFile = new NLog.Targets.FileTarget()
            {
                FileName = "${basedir}" + "/Log/${shortdate}.log"
            };

            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logFile);

            NLog.LogManager.Configuration = config;

            sLogger = NLog.LogManager.GetLogger("debug");
        }

        public static void Debug(string message)
        {
            sLogger.Debug(message);
        }

        public static void Error(string message)
        {
            sLogger.Error(message);
        }
    }

}
