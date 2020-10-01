﻿using H_PF.ToolLibs.HesoLogger.Loggers;
using System;
using System.Collections.Generic;
using System.Text;

namespace H_PF.ToolLibs.HesoLogger.LogFormatters
{
    public interface ILogFormatter
    {
        string FormatInformation(string message, ELogLevel level);
        string FormatWarning(string message, Exception ex, ELogLevel level);
        string FormatError(string message, Exception ex, ELogLevel level);
    }
}