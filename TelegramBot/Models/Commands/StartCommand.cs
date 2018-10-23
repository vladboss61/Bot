using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

using TelegramBot.Models;
using TelegramBot.Extensions;

namespace TelegramBot.Models.Commands{
    public class StartCommand : Command
    {
        public override string Name => "start";
        private BotDbContext _db;

        public StartCommand(BotDbContext context)
        {
            _db = context;
        }

        public override async Task ExecuteAsync(Message message, TelegramBotClient client)
        {
            BotUser user = new BotUser().MessageToUser(message);
            _db.BotUsers.Add(user);
            await _db.SaveChangesAsync();
            
            await client.SendTextMessageAsync(user.ChatId, 
                $"You are now registered, {user.FirstName}");
        }
    }

    
}