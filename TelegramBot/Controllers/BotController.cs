using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace TelegramBot.Controllers{

    [Route("api/[controller]")]
    public class BotController : Controller{
        [HttpGet("[action]")]
        public async Task<string> GetName(){
            var botClient = HttpContext.RequestServices.GetService<Telegram.Bot.TelegramBotClient>();
            var me = await botClient.GetMeAsync();

            return me.FirstName;
        }
    }
}