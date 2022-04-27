using System;
using System.Collections.Generic;
using System.Text;

namespace H_PF.ToolLibs.HesoLogger.Domaine.Models
{
    public enum ELogLevel
    {
        Level0, // information
        Level1, // information, error, warning
        Level2, // information, error+, warning+
        Level3  // information, error+, warning+, debug+
    }
}
