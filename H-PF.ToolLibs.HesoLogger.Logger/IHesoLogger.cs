using H_PF.ToolLibs.HesoLogger.Domaine.Models;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace H_PF.ToolLibs.HesoLogger.Domaine
{
    public interface IHesoLogger : ILogger
    {
        public string ModuleName { get; set; }
        void Information(HesoLogInformation logInfo);
        void Information(string message, List<string> groups, [Caller] [CallerMemberName] string title = "");

        void Error(HesoLogError logError);
        void Error(string message, List<string> groups, Exception ex = null, [CallerMemberName] string title = "");

        void Warning(HesoLogWarning logWarning);
        void Warning(string message, List<string> groups, Exception ex = null, [CallerMemberName] string title = "");

        void Debug(HesoLogWarning logWarning);
        void Debug(string message, List<string> groups, Exception ex = null, [CallerMemberName] string title = "");
    }
}
