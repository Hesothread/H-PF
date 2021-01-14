using H_PF.ToolLibs.HesoLogger.Domaine.Models;
using System;
using System.Runtime.CompilerServices;

namespace H_PF.ToolLibs.HesoLogger.Domaine
{
    public interface IHesoLogger
    {
        public string ModuleName { get; set; }
        void Information(HesoLogInformation logInfo);
        void Information(string message, ELogLevel level = ELogLevel.Level1, [CallerMemberName] string title = "");
        void InformationDisplayed(string message, [CallerMemberName] string title = "");
        void InformationAdvanced(string message, [CallerMemberName] string title = "");
        void InformationHidden(string message, [CallerMemberName] string title = "");

        void Error(HesoLogError logError);
        void Error(string message, Exception ex = null, ELogLevel level = ELogLevel.Level1, [CallerMemberName] string title = "");
        void ErrorDisplayed(string message, Exception ex = null, [CallerMemberName] string title = "");
        void ErrorAdvanced(string message, Exception ex = null, [CallerMemberName] string title = "");
        void ErrorHidden(string message, Exception ex = null, [CallerMemberName] string title = "");

        void Warning(HesoLogWarning logWarning);
        void Warning(string message, Exception ex = null, ELogLevel level = ELogLevel.Level1, [CallerMemberName] string title = "");
        void WarningDisplayed(string message, Exception ex = null, [CallerMemberName] string title = "");
        void WarningAdvanced(string message, Exception ex = null, [CallerMemberName] string title = "");
        void WarningHidden(string message, Exception ex = null, [CallerMemberName] string title = "");
    }
}
