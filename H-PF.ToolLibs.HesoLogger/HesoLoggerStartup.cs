using H_PF.ToolLibs.HesoLogger.Domaine;
using H_PF.ToolLibs.HesoLogger.LogFormatters.HesoFormatter;
using H_PF.ToolLibs.HesoLogger.Loggers.ConsoleLogger;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
                .AddJsonFile("Configuration\\HesoLoggerConfig.json")
                .AddJsonFile($"Configuration\\HesoLoggerConfig.{Environment.GetEnvironmentVariable("HESO_ENVIRONMENT")}.json")
                .Build();
            configuration.Bind("HesoLoggerSettings", Configuration);
            _config = Configuration.GetSection("HesoLoggerConfiguration").Get<HesoLoggerConfiguration>();
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            switch (_config.LogFormatterName)
            {
                case "HesoConsoleLogger":
                    services.Configure<HesoLoggerConfiguration>(Configuration.GetSection("ConsoleLoggerConfiguration"));
                    services.AddTransient<IHesoLogger, HesoConsoleLogger>();
                    break;
                case "FileLogger":
                    break;
                case "MultiLogger":
                    break;
                case "ServiceLogger":
                    break;
                case "SerilogLogger":
                    break;
                default:
                    services.Configure<HesoLoggerConfiguration>(Configuration.GetSection("ConsoleLoggerConfiguration"));
                    services.AddTransient<IHesoLogger, HesoConsoleLogger>();
                    break;
            }
            switch (_config.LoggerName)
            {
                case "HesoLogFormatter":
                    services.Configure<HesoLogFormatterConfiguration>(Configuration.GetSection("HesoLogFormatterConfiguration"));
                    services.AddTransient<ILogFormatter, HesoLogFormatter>();
                    break;
                default:
                    services.Configure<HesoLogFormatterConfiguration>(Configuration.GetSection("HesoLogFormatterConfiguration"));
                    services.AddTransient<ILogFormatter, HesoLogFormatter>();
                    break;
            }
        }
    }
}
