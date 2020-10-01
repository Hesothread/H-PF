using H_PF.ToolLibs.HesoLogger.Loggers.Logger.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace H_PF.ToolLibs.HesoLogger.Loggers.Logger
{
    public interface IHesoLogger
    {
        void Information(string message, ELogLevel level = ELogLevel.Level2);
        void InformationDisplayed(string message);
        void InformationAdvanced(string message);
        void InformationHidden(string message);

        void Error(string message, Exception ex = null, ELogLevel level = ELogLevel.Level2);
        void ErrorDisplayed(string message, Exception ex = null);
        void ErrorAdvanced(string message, Exception ex = null);
        void ErrorHidden(string message, Exception ex = null);

        void Warning(string message, Exception ex = null, ELogLevel level = ELogLevel.Level2);
        void WarningDisplayed(string message, Exception ex = null);
        void WarningAdvanced(string message, Exception ex = null);
        void WarningHidden(string message, Exception ex = null);
    }
}
