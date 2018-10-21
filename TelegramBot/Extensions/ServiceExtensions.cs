using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Telegram.Bot;

namespace TelegramBot.Extensions{
    public static class ServiceExtensions{
        public static IServiceCollection AddTelegramBot(this IServiceCollection services){
            return services.AddSingleton<TelegramBotClient>(provider => {
                var config = provider.GetRequiredService<IConfiguration>();
                var client = new TelegramBotClient(config["token"]);

                return client;
            });
        }
    }
}