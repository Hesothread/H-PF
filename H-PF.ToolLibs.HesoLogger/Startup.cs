using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace H_PF.ToolLibs.HesoLogger
{
    public class StartupModule
    {
        public IConfiguration Configuration { get; }

        public StartupModule(IConfiguration configuration)
        {
            var onfiguration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var config = Configuration.GetSection("MuninConfig").Get<MuninConfig>();

        }
    }
}
