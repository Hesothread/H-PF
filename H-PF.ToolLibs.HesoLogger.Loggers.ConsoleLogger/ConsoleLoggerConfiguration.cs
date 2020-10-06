using H_PF.ToolLibs.HesoLogger.Domaine.Models;

namespace H_PF.ToolLibs.HesoLogger.Loggers.ConsoleLogger
{
    public class ConsoleLoggerConfiguration
    {
        public ELogLevel InformationLevel { get; set; }
        public ELogLevel WarningLevel { get; set; }
        public ELogLevel ErrorLevel { get; set; }
    }
}
