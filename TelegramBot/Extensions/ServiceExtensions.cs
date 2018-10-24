using System.IO;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Telegram.Bot;
using TelegramBot.Models.Commands;
using TelegramBot.Models;

namespace TelegramBot.Extensions{
    public static class ServiceExtensions
    {
        private const string Url = "api/bot/update";
        
        public static IServiceCollection AddTelegramBot(this IServiceCollection services)
        {
            services.AddSingleton<TelegramBotClient>(provider => 
            {
                var configuration = provider.GetRequiredService<IConfiguration>();
                var client = new TelegramBotClient(configuration.GetToken());
                
                client.SetWebhookAsync(Path.Combine(configuration.GetBotHost(), Url));                
                
                return client;
            });

            services.AddTransient<IBotRepository, BotRepository>();

            return services;
        }

        public static IServiceCollection AddTelegramBotCommands(this IServiceCollection services){
            IReadOnlyList<Command> botCommands = new List<Command>()
            {
                new HelloCommand(),
                new StartCommand(services.BuildServiceProvider()
                                         .GetService<BotDbContext>())
            };            

            services.AddSingleton<IReadOnlyList<Command>>(provider => botCommands);
            return services;
        }
    }
}