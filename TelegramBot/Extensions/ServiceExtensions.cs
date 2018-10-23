using System.IO;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Telegram.Bot;
using TelegramBot.Models.Commands;
using TelegramBot.Models;

namespace TelegramBot.Extensions{
    public static class ServiceExtensions{
        public static IServiceCollection AddTelegramBot(this IServiceCollection services){
            return services.AddSingleton<TelegramBotClient>(provider => {
                var config = provider.GetRequiredService<IConfiguration>();
                var client = new TelegramBotClient(config["Token"]);

                
                client.SetWebhookAsync(Path.Combine(config["Url"], "api/bot/update"));

                return client;
            });
        }

        public static IServiceCollection AddTelegramBotCommands(this IServiceCollection services){
            List<Command> botCommands = new List<Command>();

            //Add new commands here
            botCommands.Add(new HelloCommand());
            botCommands.Add(new StartCommand(services.BuildServiceProvider().GetService<BotDbContext>()));

            services.AddSingleton<IReadOnlyList<Command>>(provider => {
               return botCommands.AsReadOnly(); 
            });

            return services;
        }
    }
}