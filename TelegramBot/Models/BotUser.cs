namespace TelegramBot.Models
{
    public class BotUser
    {
        /// <summary>
        ///Get and set bot user Id 
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        //Get and set bot user FirstName 
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Get and set bot user ChatId 
        /// </summary>
        public long ChatId { get; set; }
    }
}