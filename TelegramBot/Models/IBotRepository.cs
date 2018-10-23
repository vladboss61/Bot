namespace TelegramBot.Models
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Telegram.Bot.Types;

    public interface IBotRepository    
    {
        Task<string> GetName();        
        
        Task Update(Update update);

        Task<IEnumerable<BotUser>> GetUsers();
    }     
}