using H_PF.ToolLibs.HesoLogger.Domaine.Models;
using System;
using System.Runtime.CompilerServices;

namespace H_PF.ToolLibs.HesoLogger.Domaine
{
    public interface IHesoLogger
    {
        public Type ModuleType { get; set; }
        void Information(HesoLogInformation logInfo);
        void Information(string message, [CallerMemberName] string title = "", ELogLevel level = ELogLevel.Level1);
        void InformationDisplayed(string message, [CallerMemberName] string title = "");
        void InformationAdvanced(string message, [CallerMemberName] string title = "");
        void InformationHidden(string message, [CallerMemberName] string title = "");

        void Error(HesoLogError logError);
        void Error(string message, [CallerMemberName] string title = "", Exception ex = null, ELogLevel level = ELogLevel.Level1);
        void ErrorDisplayed(string message, [CallerMemberName] string title = "", Exception ex = null);
        void ErrorAdvanced(string message, [CallerMemberName] string title = "", Exception ex = null);
        void ErrorHidden(string message, [CallerMemberName] string title = "", Exception ex = null);

        void Warning(HesoLogWarning logWarning);
        void Warning(string message, [CallerMemberName] string title = "", Exception ex = null, ELogLevel level = ELogLevel.Level1);
        void WarningDisplayed(string message, [CallerMemberName] string title = "", Exception ex = null);
        void WarningAdvanced(string message, [CallerMemberName] string title = "", Exception ex = null);
        void WarningHidden(string message, [CallerMemberName] string title = "", Exception ex = null);
    }
}
