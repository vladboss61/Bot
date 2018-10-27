namespace TelegramBot.Models
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Telegram.Bot.Types;

    public interface IBotRepository    
    {
        Task<string> GetName();    
        Task<IEnumerable<BotUser>> GetUsers();
        Task AddUser(BotUser user);
        Task DeleteUser(long chatId);
    }     
}