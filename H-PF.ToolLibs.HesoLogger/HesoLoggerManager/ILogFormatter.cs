using H_PF.ToolLibs.HesoLogger.Domaine.Models;
using H_PF.ToolLibs.HesoLogger.Domains.Logs.Models;

namespace H_PF.ToolLibs.HesoLogger.Domaine
{
    public interface ILogFormatter
    {
        string FormatLog(HesoLog message);
    }
}
