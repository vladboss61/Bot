namespace TelegramBot.Models
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Telegram.Bot.Types;

    public interface IBotRepository    
    {
        /// <summary>
        /// Get name of user of telegram bot.
        /// </summary>
        /// <returns></returns>
        Task<string> GetName();

        Task<IEnumerable<BotUser>> GetUsers();

        Task AddUser(BotUser user);

        Task DeleteUser(long chatId);
    }     
}