using TelegramBot.Models;

using Telegram.Bot.Types;

namespace TelegramBot.Extensions{
    internal static class MappedExtension
    {
        public static TelegramBot.Models.BotUser MapMessageToUser(this BotUser user, IMessage message)
        {
             var firstName = message.From.FirstName;
             var chatId = message.Chat.Id;
             
             user.FirstName = firstName;
             user.ChatId = chatId;

             return user;
        }
    }
}