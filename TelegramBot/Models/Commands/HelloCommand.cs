using System.Threading.Tasks;

using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot.Models.Commands{
    public class HelloCommand : Command
    {
        public override string Name => "hello";

        public override async Task ExecuteAsync(IMessage message, ITelegramBotClient client)
        {
            var chatId = message.Chat.Id;

            var messageId = message.MessageId;

            await client.SendTextMessageAsync(chatId, "Hello", replyToMessageId: messageId);
        }
    }
}