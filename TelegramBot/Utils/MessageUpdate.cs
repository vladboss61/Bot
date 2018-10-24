using System;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace TelegramBot.Utils{
    public class MessageUpdate : Attribute, IActionConstraint
    {
        public int Order => throw new NotImplementedException();

        public bool Accept(ActionConstraintContext context)
        {
            throw new NotImplementedException();
        }
    }
}