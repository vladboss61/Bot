using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramBot.Models
{
    public static class LogWhen
    {
        public static bool Logging(Action logIn)
        {
            logIn();

            return false;
        }
    }
}
