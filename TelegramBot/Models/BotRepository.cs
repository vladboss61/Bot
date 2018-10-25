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
    using Microsoft.EntityFrameworkCore;

    internal class BotRepository : IBotRepository
    {
        public BotDbContext Context { get; } 

        public ITelegramBotClient BotClient {get;}
        
        public BotRepository(BotDbContext context, ITelegramBotClient client)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            BotClient = client ?? throw new ArgumentNullException(nameof(client));
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

        public async Task AddUser(BotUser user){
            if (await Context.BotUsers.FirstOrDefaultAsync(x => x.ChatId == user.ChatId) != null)
                throw new Exception("User with such chat id exists in database");

            Context.BotUsers.Add(user);
            await Context.SaveChangesAsync();
        }

        public async Task DeleteUser(long chatId)
        {
            var user = await Context.BotUsers.FirstOrDefaultAsync(x => x.ChatId == chatId);

            if (user == null){
                throw new Exception("User with such id doesn't exist in database");
            }

            Context.BotUsers.Remove(user);
            await Context.SaveChangesAsync();
        }
    }
}