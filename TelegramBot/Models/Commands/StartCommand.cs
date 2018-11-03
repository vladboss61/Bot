using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

using TelegramBot.Models;
using TelegramBot.Extensions;

namespace TelegramBot.Models.Commands{
    public class StartCommand : Command
    {
        public override string Name => "start";

        private readonly IBotRepository _repository;

        public StartCommand(IBotRepository repository)
        {
            _repository = repository;
        }

        public override async Task ExecuteAsync(IMessage message, ITelegramBotClient client)
        {   
            var user = new BotUser().MapMessageToUser(message);
            
            try{
                await _repository.AddUser(user);
                await client.SendTextMessageAsync(user.ChatId, $"You are now registered, {user.FirstName}");
            }
            catch(Exception)
            {
                await client.SendTextMessageAsync(user.ChatId, "You're already registered");
            }                       
        }
    }    
}