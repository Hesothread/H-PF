using H_PF.ToolLibs.HesoLogger.Loggers;
using H_PF.ToolLibs.HesoLogger.Loggers.Logger.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace H_PF.ToolLibs.HesoLogger.Configuration
{
    public class ConsoleLoggerConfiguration
    {
        public ELogLevel InformationLevel { get; set; }
        public ELogLevel WarningLevel { get; set; }
        public ELogLevel ErrorLevel { get; set; }
    }
}
