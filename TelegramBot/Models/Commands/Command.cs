using System.Threading.Tasks;

using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot.Models.Commands{
    public abstract class Command{
        public abstract string Name{get;}
        public abstract Task ExecuteAsync(Message message, TelegramBotClient client);

        public bool Contains(string command){
            return command.Contains(Name);
        }
    }
}