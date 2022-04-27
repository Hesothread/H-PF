using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Reflection;
using System.Text.Json;
using Microsoft.Extensions.Configuration.Json;

namespace H_PF.ToolLibs.HesoConfiguration
{

    public static class HesoConfigurationExtensions
    {
        private const string _configFolderName = "Config";

        public static IConfigurationBuilder AddHesoConfiguration(this IConfigurationBuilder builder)
        {
            var fileInfo = new FileInfo(Assembly.GetEntryAssembly().Location);
            var configPath = Path.Combine(fileInfo.Directory.FullName, _configFolderName);
           
            var paths = Directory.GetFiles(configPath, "*.config.json");
            foreach (var path in paths)
                builder.Add(new JsonConfigurationSource() {Path = path});
            return builder;
        }
    }
}
