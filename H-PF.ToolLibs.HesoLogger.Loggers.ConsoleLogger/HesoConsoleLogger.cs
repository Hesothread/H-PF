using H_PF.ToolLibs.HesoLogger.Configuration;
using System;

namespace H_PF.ToolLibs.HesoLogger.Loggers.ConsoleLogger
{
    public class HesoConsoleLogger : IHesoLogger
    {
        private readonly ConsoleLoggerConfiguration _config;
        private readonly ILogFormatter _logFormatter;
        private readonly IConsoleManager _consoleManager;

        public HesoConsoleLogger(ILogFormatter logFormatter, IConsoleManager consoleManager, IOptions<ConsoleLoggerConfiguration> config)
        {
            _config = config.Value;
        }

        #region Log Information
        public void Information(string message, ELogLevel level = ELogLevel.Level2)
        {
            switch (level)
            {
                case ELogLevel.Level0:
                    InformationDisplayed(message);
                    break;
                case ELogLevel.Level1:
                    InformationDisplayed(message);
                    break;
                case ELogLevel.Level2:
                    InformationAdvanced(message);
                    break;
                case ELogLevel.Level3:
                    InformationHidden(message);
                    break;
            }
        }

        public void InformationDisplayed(string message)
        {
            if (_config.InformationLevel < ELogLevel.Level1)
                return;
            _logFormatter.FormatInformation(message, _config.InformationLevel);
        }

        public void InformationAdvanced(string message)
        {
            if (_config.InformationLevel < ELogLevel.Level2)
                return;
            var consoleMessage = _logFormatter.FormatInformation(message, _config.InformationLevel);
            System.Console.WriteLine();
        }

        public void InformationHidden(string message)
        {
            if (_config.InformationLevel < ELogLevel.Level3)
                return;
            _logFormatter.FormatInformation(message, _config.InformationLevel);
        }
        #endregion

        #region Log Warning
        public void Warning(string message, Exception ex = null, ELogLevel level = ELogLevel.Level2)
        {
            throw new NotImplementedException();
        }

        public void WarningAdvanced(string message, Exception ex = null)
        {
            throw new NotImplementedException();
        }

        public void WarningDisplayed(string message, Exception ex = null)
        {
            throw new NotImplementedException();
        }

        public void WarningHidden(string message, Exception ex = null)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Log Error
        public void Error(string message, Exception ex = null, ELogLevel level = ELogLevel.Level2)
        {
            throw new NotImplementedException();
        }

        public void ErrorDisplayed(string message, Exception ex = null)
        {
            throw new NotImplementedException();
        }

        public void ErrorAdvanced(string message, Exception ex = null)
        {
            throw new NotImplementedException();
        }

        public void ErrorHidden(string message, Exception ex = null)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
