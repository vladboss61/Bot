using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Capturing;

namespace TelegramBot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration().WriteTo.Console(Serilog.Events.LogEventLevel.Error)
                .WriteTo.File(path: "Logs\\BotLogs.txt", 
                              rollingInterval: RollingInterval.Day, 
                              restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Verbose).CreateLogger();
            try
            {
                CreateWebHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex,
                    $"Unhandled exception from Telegram Bot {Environment.NewLine} StackTrace: {ex.StackTrace}.");
                throw;
            }
            finally
            {
                Log.Logger.Information("Application is stopped.");
            }            
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddCommandLine(args)
                .Build();
            
            return WebHost.CreateDefaultBuilder(args)          
                    .UseConfiguration(configuration)
                    .UseStartup<Startup>();
        }
    }
}
