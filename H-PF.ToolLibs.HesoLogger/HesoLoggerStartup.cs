using H_PF.ToolLibs.HesoLogger.Domaine;
using H_PF.ToolLibs.HesoLogger.LogFormatters.HesoFormatter;
using H_PF.ToolLibs.HesoLogger.Loggers.ConsoleLogger;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace H_PF.ToolLibs.HesoLogger
{
    public static class HesoLoggerStartup
    {
        public static IConfiguration Configuration { get; private set; }
        public static string HesoEnv { get; private set; }
        public static HesoLoggerConfiguration _config { get; private set; }
        public static void Startup(IConfiguration configuration)
        {
            HesoEnv = Environment.GetEnvironmentVariable("HESO_ENVIRONMENT");

            var ConfigurationBuilder = new ConfigurationBuilder();
            if (File.Exists("Configuration\\HesoLoggerConfig.json"))
            {
                ConfigurationBuilder.AddJsonFile("Configuration\\HesoLoggerConfig.json");
                if (HesoEnv != null && File.Exists($"Configuration\\HesoLoggerConfig.{HesoEnv}.json"))
                    ConfigurationBuilder.AddJsonFile($"Configuration\\HesoLoggerConfig.{HesoEnv}.json");
                Configuration = ConfigurationBuilder.Build();
            }
            else
                Configuration = configuration;
            _config = Configuration.GetSection("HesoLoggerConfiguration").Get<HesoLoggerConfiguration>();
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            switch (_config.LoggerName)
            {
                case "HesoConsoleLogger":
                    services.Configure<ConsoleLoggerConfiguration>(Configuration.GetSection("ConsoleLoggerConfiguration"));
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
                    services.Configure<ConsoleLoggerConfiguration>(Configuration.GetSection("ConsoleLoggerConfiguration"));
                    services.AddTransient<IHesoLogger, HesoConsoleLogger>();
                    break;
            }
            switch (_config.LogFormatterName)
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
