using H_PF.ToolLibs.HesoLogger.Domaine.Models;

namespace H_PF.ToolLibs.HesoLogger.Domaine
{
    public interface ILogFormatter
    {
        string FormatInformation(HesoLogInformation message);
        string FormatWarning(HesoLogWarning message);
        string FormatError(HesoLogError message);
        string FormatDebug(HesoLogError message);
    }
}
