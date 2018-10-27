using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TelegramBot.Models
{
    internal class MessageFactory
    {
        public static Message CreateMessage(Update update)
        {
            Message message;
            switch(update.Type)
            {
                case UpdateType.Message:
                    message = update.Message;
                    break;         
                default:
                    message =  null;
                    break;                               
            }
            return message;
        }
    }
}