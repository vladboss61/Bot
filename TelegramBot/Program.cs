namespace TelegramBot
{
    using System;
    using System.IO;
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using NLog.Config;
    using NLog.Targets;
    using NLog;
    public class Program
    {
        public static void Main(string[] args)
        {
            LogManager.Configuration = CreateLoggingConfiguration();
            var logger = LogManager.GetLogger("StartServerLogger");

            try
            {
                var host = CreateWebHostBuilder(args).Build();
                //something before run Kestral server, all services are configured. DI is done. Can do before start.
                //For Example Test Logging in file and console by Nlog  =>  throw new Exception("Test Exception");
                host.Run();
            }
            catch(Exception ex)
            {
                logger.Fatal(ex, "Server is down. Fatal");
                throw;
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var config = new ConfigurationBuilder()
                        .AddCommandLine(args)
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", true, true)
                        .AddJsonFile("botsettings.json", false, true)
                        .Build();

            return WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .UseConfiguration(config)
                .UseStartup<Startup>();
        }

        public static LoggingConfiguration CreateLoggingConfiguration()
        {
            var loggerConfiguration = new LoggingConfiguration();

            loggerConfiguration.AddTarget(new FileTarget($"BotFileTarget")
            {
                FileName = Path.Combine(Directory.GetCurrentDirectory(), "Logs", "BotLogs.txt"),
                Layout = "${longdate} -- ${level} -- ${message} -- ${exception} --"
            });

            loggerConfiguration.AddTarget(new ColoredConsoleTarget("BotConsoleTarget")
            {
                Layout = @"${date:format=HH\:mm\:ss} -- ${level} -- ${message} -- ${exception} --"
            });

            loggerConfiguration.AddRuleForOneLevel(LogLevel.Warn, "BotFileTarget");
            loggerConfiguration.AddRuleForOneLevel(LogLevel.Error, "BotFileTarget");
            loggerConfiguration.AddRuleForOneLevel(LogLevel.Fatal, "BotFileTarget");

            loggerConfiguration.AddRuleForAllLevels("BotConsoleTarget");

            return loggerConfiguration;
        }
    }
}