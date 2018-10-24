namespace TelegramBot.Controllers{

    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Linq;
    using System;
    using Microsoft.AspNetCore.Mvc;
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
            try
            {
                await BotRepository.Update(update);                
            }
            catch (System.Exception)
            {
                // Some logic with exceptions;
            }

           return Ok();
        }

        [HttpGet("users")]
        public async Task<ActionResult<IEnumerable<BotUser>>> GetAll()
        {
            return Ok(await BotRepository.GetUsers());
        }
    }
}