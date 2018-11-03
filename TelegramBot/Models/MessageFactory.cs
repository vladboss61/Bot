using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TelegramBot.Models
{
    internal class MessageFactory
    {
        public static IMessage CreateMessage(Update update)
        {
            MessageAdapter message;
            switch(update.Type)
            {
                case UpdateType.Message:
                    message = new MessageAdapter(update.Message);
                    break;         
                default:
                    message =  null;
                    break;                               
            }
            return message;
        }
    }
}