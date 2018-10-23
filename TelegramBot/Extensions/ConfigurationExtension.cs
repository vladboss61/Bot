namespace TelegramBot.Extensions
{
    using Microsoft.Extensions.Configuration;

    internal static class ConfigurationExtension
    {
        
        public static string GetToken(this IConfiguration configuration) => configuration["Token"];

        public static string GetBotHost(this IConfiguration configuration) => configuration["Url"];         

    }
}