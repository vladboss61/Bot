using TelegramBot.Extensions;

namespace TelegramBot.Models
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Telegram.Bot.Types;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;
    using Telegram.Bot;
    using TelegramBot.Models.Commands;
    using Telegram.Bot.Types.Enums;
    using System.Linq;

    internal class BotRepository : IBotRepository
    {
        public BotDbContext Context { get; } 

        public ITelegramBotClient BotClient {get;}

        public IReadOnlyList<Command> Commands { get; }
        
        public BotRepository(BotDbContext context, ITelegramBotClient client, IReadOnlyList<Command> commands)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            BotClient = client ?? throw new ArgumentNullException(nameof(client));
            Commands =  commands ?? throw new ArgumentNullException(nameof(commands));
        }

        public async Task<string> GetName()
        {            
            var me = await BotClient.GetMeAsync();
            return me.FirstName;
        }

        public async Task<IEnumerable<BotUser>> GetUsers()
        {
           return await Task.Run(() => Context.BotUsers.ToList());
        }

        public async Task Update(Update update)
        {
            var message = MessageFactory.CreateMessageOrDefault(update);

            //Proccessing updates of concrete type
            if (message == null)
            {
                throw new Exception("thiking about text and type of exceptions");
            } 
            
            //Search corresponding command and execute it
            var command = Commands.FirstOrDefault(cmd => cmd.CanExecute(message.Text));

            if (command == null)
            {
                await BotClient.SendTextMessageAsync(message.Chat.Id, "I don't know this command");
                return;
            }

            await command.ExecuteAsync(message, BotClient);            
            //think about creating of ServiceCommands for such purposes            
        }
    }
}