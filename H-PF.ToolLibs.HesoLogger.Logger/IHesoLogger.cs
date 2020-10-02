using H_PF.ToolLibs.HesoLogger.Domaine.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace H_PF.ToolLibs.HesoLogger.Loggers.Logger
{
    public interface IHesoLogger
    {
        void Information(HesoLogInformation logInfo);
        void Information(string message, ELogLevel level);
        void InformationDisplayed(string message);
        void InformationAdvanced(string message);
        void InformationHidden(string message);

        void Error(HesoLogError logError);
        void Error(string message, Exception ex, ELogLevel level);
        void ErrorDisplayed(string message, Exception ex);
        void ErrorAdvanced(string message, Exception ex);
        void ErrorHidden(string message, Exception ex);

        void Warning(HesoLogWarning logWarning);
        void Warning(string message, Exception ex, ELogLevel level);
        void WarningDisplayed(string message, Exception ex);
        void WarningAdvanced(string message, Exception ex);
        void WarningHidden(string message, Exception ex);
    }
}
