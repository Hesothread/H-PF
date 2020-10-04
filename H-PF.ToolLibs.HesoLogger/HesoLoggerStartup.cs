using H_PF.ToolLibs.HesoLogger.Configuration;
using H_PF.ToolLibs.HesoLogger.Domaine;
using H_PF.ToolLibs.HesoLogger.Loggers.ConsoleLogger;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.IO;

namespace H_PF.ToolLibs.HesoLogger
{
    public static class HesoLoggerStartup
    {
        public static IConfiguration Configuration { get; private set; }
        public static HesoLoggerConfiguration _config { get; private set; }
        public static void Startup(IConfiguration configuration)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("HesoLoggerConfig.json")
                .AddJsonFile($"HesoLoggerConfig.{Environment.GetEnvironmentVariable("HESO_ENVIRONMENT")}.json")
                .Build();
            _config = Configuration.GetSection("HesoLoggerConfiguration").Get<HesoLoggerConfiguration>();
            configuration.Bind("HesoLoggerSettings", Configuration);
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            switch (_config.LogFormatterName)
            {
                case "HesoConsoleLogger":
                    services.AddOptions<ConsoleLoggerConfiguration>()
                        .Bind(Configuration.GetSection("ConsoleLoggerConfiguration"))
                        .ValidateDataAnnotations();
                    services.AddTransient<IHesoLogger, HesoLogger<T>>(x => new HesoLogger<T>(new HesoConsoleLogger(x.GetService<ILogFormatter>(), x.GetService<IOptions<T>>()))));
                    services.AddTransient<IHesoLogger<T>, IHesoLogger>(x => );
                    break;
                case "FileLogger":
                    break;
                case "MultiLogger":
                    break;
                case "ServiceLogger":
                    break;
                case "SerilogLogger":
                    break;
            }
            switch (_config.LoggerName)
            {

            }
        }

        public static void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IWebHostEnvironment env)
        {
            throw new NotImplementedException();
        }
    }
}
