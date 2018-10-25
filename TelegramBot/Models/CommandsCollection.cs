using System.Collections.Generic;

using TelegramBot.Models.Commands;

namespace TelegramBot.Models{
    public class CommandsCollection{
        private IBotRepository _rep;

        private List<Command> _commands;

        public IReadOnlyList<Command> Commands
        {
            get
            {
                return _commands.AsReadOnly();
            }
        }

        public CommandsCollection(IBotRepository repository){
            _rep = repository;

            _commands = new List<Command>(){
                new HelloCommand(),
                new StartCommand(repository),
                new StopCommand(repository)
            };
        }
    }
}