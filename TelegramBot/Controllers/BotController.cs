namespace TelegramBot.Controllers{

    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Linq;
    using System;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;

    using Telegram.Bot;
    using Telegram.Bot.Types;
    using Telegram.Bot.Types.Enums;

    using TelegramBot.Models.Commands;
    using TelegramBot.Models;
    

    [Route("api/bot")]
    public class BotController : Controller{
        
        public  IBotRepository BotRepository {get;}
        
        public BotController(IBotRepository botRepository )
        {
            BotRepository = botRepository ?? throw  new ArgumentNullException(nameof(botRepository));
        }

        [HttpGet("name")]
        public async Task<ActionResult> Get()
        {            
            return new OkObjectResult(await BotRepository.GetName());
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] Update update)
        {
            var commandsCollection = HttpContext.RequestServices.GetRequiredService<CommandsCollection>();
            var client = HttpContext.RequestServices.GetRequiredService<ITelegramBotClient>();
            var message = MessageFactory.CreateMessageOrDefault(update);

            //Proccessing updates of concrete type
            if (message == null)
            {
                throw new Exception("thiking about text and type of exceptions");
            } 
            
            //Search corresponding command and execute it
            var command = commandsCollection.Commands.FirstOrDefault(cmd => cmd.CanExecute(message.Text));

            if (command == null)
            {
                await client.SendTextMessageAsync(message.Chat.Id, "I don't know this command");
                return Ok();
            }

            await command.ExecuteAsync(message, client);            
            //think about creating of ServiceCommands for such purposes  

           return Ok();
        }

        [HttpGet("users")]
        public async Task<ActionResult<IEnumerable<BotUser>>> GetAll()
        {
            return Ok(await BotRepository.GetUsers());
        }
    }
}