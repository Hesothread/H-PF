using System;
using System.Collections.Generic;
using H_PF.ToolLibs.HesoLogger.Domaine.Models;

namespace H_PF.ToolLibs.HesoLogger.Domains.Logs.Models
{
    public abstract class HesoLog
    {
        public ELogType LogType { get; set; }
        public ELogLevel LogLevel { get; set; }
        public DateTime LogTime { get; set; }

        public string Message { get; set; }
        public string ModuleName { get; set; }
        public string TitleName { get; set; }
        public Exception Exception { get; set; }

        public List<string> Tags { get; set; }
    }
}
