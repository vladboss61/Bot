using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramBot.Infrastructure
{

    public class ConfigurationOptions
    {
        /// <summary>
        /// Get and set connection strings.
        /// </summary>
        public string DefaultConnection { get; set; } =
            "Host=localhost;Username=burrito;Password=192036;Database=telegrambot";

        /// <summary>
        /// Get and set microsoft sql connection string. 
        /// </summary>
        public string MssqlConnection { get; set; } = "";
    }
}
