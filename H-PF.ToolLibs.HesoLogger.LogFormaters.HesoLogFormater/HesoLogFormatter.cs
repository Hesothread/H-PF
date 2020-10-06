using H_PF.ToolLibs.HesoLogger.Domaine;
using H_PF.ToolLibs.HesoLogger.Domaine.Models;
using System;

namespace H_PF.ToolLibs.HesoLogger.LogFormatters.HesoFormatter
{
    public class HesoLogFormatter : ILogFormatter
    {
        public string FormatInformation(HesoLogInformation message)
        {
            return $"[{message.LogTime.ToString("HH:mm:ss")} INF] [{message.ModuleName}] {message.TitleName}: {message.Message}";
        }

        public string FormatWarning(HesoLogWarning message)
        {
            if (message.LogLevel <= ELogLevel.Level1)
                return $"[{message.LogTime.ToString("HH:mm:ss")} WNG] [{message.ModuleName}] {message.TitleName}: {message.Message}";
            else
                return $"[{message.LogTime.ToString("HH:mm:ss")} WNG] [{message.ModuleName}] {message.TitleName}: {message.Message}{Environment.NewLine}{message.Ex}";
        }
        public string FormatError(HesoLogError message)
        {
            if (message.LogLevel <= ELogLevel.Level1)
                return $"[{message.LogTime.ToString("HH:mm:ss")} ERR] [{message.ModuleName}] {message.TitleName}: {message.Message}";
            else
                return $"[{message.LogTime.ToString("HH:mm:ss")} ERR] [{message.ModuleName}] {message.TitleName}: {message.Message}{Environment.NewLine}{message.Ex}";
        }
    }
}
