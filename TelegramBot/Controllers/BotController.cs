using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

using TelegramBot.Models.Commands;
using TelegramBot.Models;
using System.Linq;

namespace TelegramBot.Controllers{
    

    [Route("api/bot")]
    public class BotController : Controller{
        private BotDbContext _db;
        public BotController(BotDbContext context)
        {
            _db = context;
        }
        [HttpGet("name")]
        public async Task<string> GetName(){
            var botClient = HttpContext.RequestServices.GetService<Telegram.Bot.TelegramBotClient>();
            var me = await botClient.GetMeAsync();

            return me.FirstName;
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] Update update){
            var commands = HttpContext.RequestServices.GetRequiredService<IReadOnlyList<Command>>();
            var client = HttpContext.RequestServices.GetRequiredService<Telegram.Bot.TelegramBotClient>();

            Message message = null;


            //Proccessing updates of concrete type
            switch(update.Type){
                case UpdateType.Message:
                    message = update.Message;
                    break;
            }

            if (message == null) return Ok();

            //Search corresponding command and execute it
            foreach(var command in commands){
                if (command.Contains(message.Text)){
                    await command.ExecuteAsync(message, client);
                    return Ok();
                }
            }


            //think about creating of ServiceCommands for such purposes
            await client.SendTextMessageAsync(message.Chat.Id, "I dont know this command");

            return Ok();
        }

        [HttpGet("users")]
        public ActionResult<IEnumerable<BotUser>> GetUsers(){
            return Ok(_db.BotUsers.ToList());
        }
    }
}