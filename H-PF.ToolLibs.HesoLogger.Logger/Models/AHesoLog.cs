using H_PF.ToolLibs.HesoLogger.Domaine.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace H_PF.ToolLibs.HesoLogger.Domaine.Models
{
    public abstract class AHesoLog
    {
        public ELogLevel LogLevel { get; set; }
        public DateTime LogTime { get; set; }
        public string Message { get; set; }
        public string ModuleName { get; set; }
        public string TitleName { get; set; }
    }
}
