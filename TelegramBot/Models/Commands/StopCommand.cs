using System;
using System.Threading.Tasks;
using Telegram.Bot;

namespace TelegramBot.Models.Commands{
    public class StopCommand : Command
    {
        public override string Name => "stop";

        private readonly IBotRepository _rep;

        public StopCommand(IBotRepository repository){
            _rep = repository;
        }   

        public override async Task ExecuteAsync(IMessage message, ITelegramBotClient client)
        {
            var chatId = message.Chat.Id;

            try{
                await _rep.DeleteUser(chatId);
                await client.SendTextMessageAsync(chatId, "You were succesfully unregistered");
            }
            catch(Exception ex){
                await client.SendTextMessageAsync(chatId, "You are not registered");
            }

        }
    }
}