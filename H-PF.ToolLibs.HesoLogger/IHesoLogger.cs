using H_PF.ToolLibs.HesoLogger.Domaine.Models;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using H_PF.ToolLibs.HesoLogger.Domains.Logs.Models;

namespace H_PF.ToolLibs.HesoLogger.Domaine
{
    public interface IHesoLogger
    {
        public string ModuleName { get; set; }
        public List<string> ModuleTags { get; set; }
        
        void Information(string message, List<string> tags, [CallerMemberName] string title = "");
        void Error(string message, List<string> tags, Exception ex = null, [CallerMemberName] string title = "");
        void Warning(string message, List<string> tags, Exception ex = null, [CallerMemberName] string title = "");
        void Debug(string message, List<string> tags, Exception ex = null, [CallerMemberName] string title = "");
    }
}
