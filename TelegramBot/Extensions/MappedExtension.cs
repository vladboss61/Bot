using TelegramBot.Models;

using Telegram.Bot.Types;

namespace TelegramBot.Extensions{
    internal static class MappedExtension
    {
        public static TelegramBot.Models.BotUser MessageToUser(this BotUser user, Message message)
        {
             var firstName = message.From.FirstName;
             var chatId = message.Chat.Id;
             
             user.FirstName = firstName;
             user.ChatId = chatId;

             return user;
        }
    }
}