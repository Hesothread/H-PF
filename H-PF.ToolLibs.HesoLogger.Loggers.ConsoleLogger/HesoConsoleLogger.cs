using H_PF.ToolLibs.HesoLogger.Domaine;
using H_PF.ToolLibs.HesoLogger.Domaine.Models;
using Microsoft.Extensions.Options;
using System;

namespace H_PF.ToolLibs.HesoLogger.Loggers.ConsoleLogger
{
    public class HesoConsoleLogger : IHesoLogger
    {
        private readonly ConsoleLoggerConfiguration _config;
        private readonly ILogFormatter _logFormatter;
        private string _moduleName;

        public string ModuleName { get => _moduleName; set => _moduleName = value; }
        public HesoConsoleLogger(IOptions<ConsoleLoggerConfiguration> config, ILogFormatter logFormatter)
        {
            _config = config.Value;
            _logFormatter = logFormatter;
        }

        #region Log Information
        public void Information(HesoLogInformation logInfo)
        {
            logInfo.LogLevel = _config.InformationLevel;
            WriteLine(logInfo);
        }
        public void Information(string message,  ELogLevel level, string title)
        {
            if (_config.InformationLevel < level)
                return;
            var log = BuildHesoLogInformation(message, title);
            Information(log);
        }
        public void InformationDisplayed(string message, string title) => Information(message, ELogLevel.Level1, title);
        public void InformationAdvanced(string message, string title) => Information(message, ELogLevel.Level2, title);
        public void InformationHidden(string message, string title) => Information(message, ELogLevel.Level3, title);
        #endregion

        #region Log Warning
        public void Warning(HesoLogWarning logWarning)
        {
            logWarning.LogLevel = _config.WarningLevel;
            WriteLine(logWarning);
        }
        public void Warning(string message, Exception ex, ELogLevel level, string title)
        {
            if (_config.WarningLevel < level)
                return;
            var log = BuildHesoLogWarning(message, title, ex);
            Warning(log);
        }
        public void WarningAdvanced(string message, Exception ex = null, string title = "") => Warning(message, ex, ELogLevel.Level1, title);
        public void WarningDisplayed(string message, Exception ex = null, string title = "") => Warning(message, ex, ELogLevel.Level2, title);
        public void WarningHidden(string message, Exception ex = null, string title = "") => Warning(message, ex, ELogLevel.Level3, title);
        #endregion

        #region Log Error
        public void Error(HesoLogError logError)
        {
            logError.LogLevel = _config.ErrorLevel;
            WriteLine(logError);
        }
        public void Error(string message, Exception ex, ELogLevel level, string title)
        {
            if (_config.ErrorLevel < level)
                return;
            var log = BuildHesoLogError(message, title, ex);
            Error(log);
        }
        public void ErrorDisplayed(string message, Exception ex = null, string title = "") => Error(message, ex, ELogLevel.Level1, title);
        public void ErrorAdvanced(string message, Exception ex = null, string title = "") => Error(message, ex, ELogLevel.Level2, title);
        public void ErrorHidden(string message, Exception ex = null, string title = "") => Error(message, ex, ELogLevel.Level3, title);
        #endregion

        #region Private
        private void WriteLine(HesoLogInformation log)
        {
            var line = _logFormatter.FormatInformation(log);
            System.Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine(line);
            System.Console.ForegroundColor = ConsoleColor.White;
        }
        private void WriteLine(HesoLogWarning log)
        {
            var line = _logFormatter.FormatWarning(log);
            System.Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine(line);
            System.Console.ForegroundColor = ConsoleColor.White;
        }
        private void WriteLine(HesoLogError log)
        {
            var line = _logFormatter.FormatError(log);
            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine(line);
            System.Console.ForegroundColor = ConsoleColor.White;

        }

        private HesoLogInformation BuildHesoLogInformation(string message, string title)
        {
            return new HesoLogInformation()
            {
                LogLevel = _config.InformationLevel,
                LogTime = DateTime.UtcNow,
                Message = message,
                ModuleName = _moduleName,
                TitleName = title
            };
        }
        private HesoLogWarning BuildHesoLogWarning(string message, string title, Exception ex)
        {
            return new HesoLogWarning()
            {
                LogLevel = _config.InformationLevel,
                LogTime = DateTime.UtcNow,
                Message = message,
                ModuleName = _moduleName,
                TitleName = title,
                Ex = ex
            };
        }
        private HesoLogError BuildHesoLogError(string message, string title, Exception ex)
        {
            return new HesoLogError()
            {
                LogLevel = _config.InformationLevel,
                LogTime = DateTime.UtcNow,
                Message = message,
                ModuleName = _moduleName,
                TitleName = title,
                Ex = ex
            };
        }
        #endregion
    }
}
